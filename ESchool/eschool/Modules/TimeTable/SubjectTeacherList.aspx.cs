/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using eschool.SchoolClass;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
using RMG;

namespace eschool.TimeTable
{
	/// <summary>
	/// Summary description for SubjectTeacherList.
	/// </summary>
	public class SubjectTeacherList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList dropsubject;
		protected System.Web.UI.HtmlControls.HtmlButton Button2;
		protected System.Web.UI.HtmlControls.HtmlButton Button3;
		protected System.Web.UI.HtmlControls.HtmlButton Btnexcel;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Panel pangrid;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					SchoolMgs obj=new SchoolMgs();
					SqlDataReader sqred;
					sqred=obj.showSubjectID();
					dropsubject.Items.Add("Select");
					while(sqred.Read())
					{
			
						dropsubject.Items.Add(sqred.GetValue(0).ToString()); 
					}
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="39";
					string[,] Priv=(string[,]) Session["Privileges"];
					for(i=0;i<Priv.GetLength(0);i++)
					{
						if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
						{						
							View_flag=Priv[i,2];
							Add_Flag=Priv[i,3];
							Edit_Flag=Priv[i,4];
							Del_Flag=Priv[i,5];
							break;
						}
					}	
					if(View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
		 
			}	
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dropsubject.SelectedIndexChanged += new System.EventHandler(this.dropsubject_SelectedIndexChanged);
			this.Button2.ServerClick += new System.EventHandler(this.Button2_ServerClick);
			this.Button3.ServerClick += new System.EventHandler(this.Button3_ServerClick);
			this.Btnexcel.ServerClick += new System.EventHandler(this.Btnexcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dropsubject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// Method for issueing the print command to the printer for printing the text file.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{				
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
				SocketType.Stream, ProtocolType.Tcp );
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
 					Console.WriteLine("Socket connected to {0}",
					sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherSubjectReport2.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());					 
					CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}

		}

		/// <summary>
		/// this Method use to show the report on the datagrid. data fetch from subject and TeacherTimetable.
		/// </summary>
		private void Button2_ServerClick(object sender, System.EventArgs e)
		{
			if(dropsubject.SelectedIndex!=0)
			{
				try
				{
					SqlConnection conNorthwind;
					string  strSelect;
					SqlCommand cmdSelect;
					conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					strSelect = "select distinct s.staff_name Staff_Name ,(select  Subject_name from subject where subject_name like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"') Subject from TeacherTimetable t,staff_information s where Subject_take like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"%' and t.employee_id=s.staff_id";
					try
					{
						
						conNorthwind.Open();
						cmdSelect = new SqlCommand( strSelect, conNorthwind );
						DataGrid1.DataSource = cmdSelect.ExecuteReader();
						DataGrid1.DataBind();

						if(DataGrid1.Items.Count==0)
						{
							pangrid.Visible=false;
							DataGrid1.Visible=false;
							MessageBox.Show("Record not found");
						}
						else
						{
							pangrid.Visible=true;
							DataGrid1.Visible=true;
						}
						CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  btnSerch_Click,  Subject Teacher List for SubjectID :"+ dropsubject.SelectedItem.Value .ToString ()  +", Userid :  "+ pass   );		
						conNorthwind.Close();
					}
					catch(Exception)
					{
						MessageBox.Show("Insufficient Data or Data not available");
						return;
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  btnSerch_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
				}	
			}
			else
			{
				MessageBox.Show("Please select subject name");
				DataGrid1.Visible=false;
			}
		}

		/// <summary>
		/// method for writing the report to the text file and send the file to printer and issue the print command for print the report.
		/// </summary>
		private void Button3_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherSubjectReport5.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "select distinct s.staff_name Staff_Name ,(select  Subject_name from subject where subject_name like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"%') Subject from TeacherTimetable t,staff_information s where Subject_take like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"%' and t.employee_id=s.staff_id";
				conNorthwind.Open();
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				sw.WriteLine("                 ===========================") ;
				sw.WriteLine("         	   TEACHER's SUBJECT  LIST") ;
				sw.WriteLine("                 ===========================") ;
				sw.WriteLine("") ;
				sw.WriteLine("+-----------------------------------+--------------------+") ;
				sw.WriteLine("|             Staff Name            |        Subject     |") ;
				sw.WriteLine("+-----------------------------------+--------------------+") ;
 				info = " {0,-35:S} {1,-20:S}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,SqlDtr.GetValue(0).ToString(),
							SqlDtr.GetValue(1).ToString()) ;						
					}
				}				
				SqlDtr.Close();		
				sw.WriteLine("+-----------------------------------+--------------------+") ;
				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Button1_Click,  Teacher's SubjectList View, Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
 
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel().
		/// </summary>
		private void Btnexcel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
		
		/// <summary>
		/// method for writing the report to the excel file and send the file to printer and issue the print command for print the report.
		/// </summary>
		public void ConvertIntoExcel()
		{

			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\TeacherSubjectReport.xls";
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherSubjectReport5.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "select distinct s.staff_name Staff_Name ,(select  Subject_name from subject where subject_name like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"%') Subject from TeacherTimetable t,staff_information s where Subject_take like '%"+dropsubject.SelectedItem.Text.ToString().Trim()+"%' and t.employee_id=s.staff_id";
				conNorthwind.Open();
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				sw.WriteLine("                 ===========================") ;
				sw.WriteLine("         	   TEACHER's SUBJECT  LIST") ;
				sw.WriteLine("                 ===========================") ;
				sw.WriteLine("") ;
				//sw.WriteLine("+-----------------------------------+--------------------+") ;
				sw.WriteLine("            Staff Name         \t      Subject     ") ;
				//sw.WriteLine("+-----------------------------------+--------------------+") ;
				info = " {0,-35:S} {1,-20:S}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+
							SqlDtr.GetValue(1).ToString()) ;						
					}
				}				
				SqlDtr.Close();		
				//sw.WriteLine("+-----------------------------------+--------------------+") ;
				sw.Close(); 
				//Print();
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Button1_Click,  Teacher's SubjectList View, Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
 
				CreateLogFiles.ErrorLog(" Form : SubjectTeacherList.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
	}
}
