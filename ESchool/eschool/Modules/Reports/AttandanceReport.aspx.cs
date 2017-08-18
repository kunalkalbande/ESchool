
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
   # region Directives...
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
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
#endregion

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for AttandanceReport.
	/// </summary>
	public class AttandanceReport : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgrdStudentLeaveInfo;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.TextBox txtfromdate;
		protected System.Web.UI.WebControls.TextBox txttodate;
		protected System.Web.UI.HtmlControls.HtmlButton Btn;
		protected System.Web.UI.WebControls.DropDownList DropdStream;
		protected System.Web.UI.WebControls.Panel pangrid;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: AttendanceReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				
				if(!Page.IsPostBack)
				{
					txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;   //add by vikas sharma date on 06.10.07
					txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;     //add by vikas sharma date on 06.10.07
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlDataReader sdtr;
					//SqlCommand scom2=new SqlCommand("Select distinct class_Name from class order by class_id ",scon); 
					SqlCommand scom2=new SqlCommand("Select class_Name from class order by class_id ",scon); 
					sdtr=scom2.ExecuteReader();
					while(sdtr.Read())
					{
						DropClass.Items.Add(sdtr.GetValue(0).ToString().Trim());
					}
					sdtr.Close();
					scon.Close();
				}
				 
				if(!IsPostBack)
				{
                    txtfromdate.Attributes.Add("readonly", "readonly");
                    txttodate.Attributes.Add("readonly", "readonly");

                    #region Check Privileges
                    int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="32";
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
				CreateLogFiles.ErrorLog(" Form :AttendanceReport.aspx.cs,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
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
			this.dgrdStudentLeaveInfo.SelectedIndexChanged += new System.EventHandler(this.dgrdStudentLeaveInfo_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Btn.ServerClick += new System.EventHandler(this.Btn_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// this Method for viewing the report on the datagrid. data fetch from Student_Roll table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			string str="";
			try
			{
				if(DropClass.SelectedIndex==0 && DropSection.SelectedIndex==0 && DropdStream.SelectedIndex==0)
				{
					MessageBox.Show("Please select Valid Data");
					dgrdStudentLeaveInfo.Visible=false; 
				}
				else
				{
					if(!txtfromdate.Text.ToString().Equals("")&&!txttodate.Text.ToString().Equals(""))
					{
						dgrdStudentLeaveInfo.Visible=true;
						SqlConnection conNorthwind;
						SqlCommand cmdSelect;
						str="select studentid,rollNo,Sname,ClassId,st_section , stream  from Student_Roll  where classID='"+DropClass.SelectedItem.Text+ "' and st_section='"+ DropSection.SelectedItem.Text+" ' and stream='" + DropdStream.SelectedItem.Text+ "'";
								
						conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						conNorthwind.Open();
						cmdSelect = new SqlCommand( str, conNorthwind );
						dgrdStudentLeaveInfo.DataSource = cmdSelect.ExecuteReader();
						dgrdStudentLeaveInfo.DataBind();
						if(dgrdStudentLeaveInfo.Items.Count==0)
						{
							MessageBox.Show("No such record found");
							dgrdStudentLeaveInfo.Visible=false;
							pangrid.Visible=false;
						}
						else
						{
							dgrdStudentLeaveInfo.Visible=true;
							pangrid.Visible=true;
						}
						if(dgrdStudentLeaveInfo.Items.Count<10)
						{
							dgrdStudentLeaveInfo.PagerStyle.Visible=false;
						}
						else
						{
							dgrdStudentLeaveInfo.PagerStyle.Visible=true;
						}
						CreateLogFiles.ErrorLog(" Form :AttendanceReport.aspx.cs,Method  Search_ServerClick,  Report Viewed for StudentID : "+DropClass.SelectedItem .Value .ToString()+", Userid :  "+ pass   );			
					}
					else
					{
						MessageBox.Show("Plese select From date and To date");
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :AttendanceReport.aspx.cs,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
	
		/// <summary>
		/// this Method use for paging the datagrid.
		/// </summary>
		private void dgrdStudentLeaveInfo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				dgrdStudentLeaveInfo.CurrentPageIndex=e.NewPageIndex;
				dgrdStudentLeaveInfo.DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :AttendanceReport.aspx.cs,Method  : dgrdStudentLeaveInfo_PageIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void printa_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this Method for return only the date part.
		/// </summary>
		public string trimDate(string date)
		{
			int pos = date.IndexOf(" ");
			if(pos > -1)
			{
				date = date.Substring(0,pos); 
			}
			return date;
		}
		
		/// <summary>
		/// this Method use to create connection between remote device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentAttandanceReport1.txt<EOF>");
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
					CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );					
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass);
					
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass);
				}				
			} 			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
												
			}
		}

		/// <summary>
		/// Method for writing the report into the text file and call method for issueing the print command to the printer for print the report.
		/// </summary>
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentAttandanceReport1.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "";
				conNorthwind.Open();
				//strSelect="select studentid,rollno,sname,classid,st_section,stream,(select count(*) from attendance_sheet where student_id=s.studentid and attendance_status='Yes' and today_date between '"+GenUtil.ToMMddYYYY(txtfromdate.Text.ToString()) +"' and '"+GenUtil.ToMMddYYYY(txttodate.Text.ToString()) +"') TotalAttandance from Student_Roll s";
				strSelect="select studentid,rollno,sname,classid,st_section,stream,(select count(*) from attendance_sheet where student_id=s.studentid and attendance_status='Yes' and today_date between '"+GenUtil.ToMMddYYYY(txtfromdate.Text.ToString()) +"' and '"+GenUtil.ToMMddYYYY(txttodate.Text.ToString()) +"') TotalAttandance from Student_Roll s where classID='"+DropClass.SelectedItem.Text+ "' and st_section='"+ DropSection.SelectedItem.Text+" ' and stream='" + DropdStream.SelectedItem.Text+ "'";
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				sw.WriteLine();
				string des="+----------+---------+---------------------------+-------+-------+--------------+----------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("STUDENT ATTANDANCE REPORT",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------",des.Length)) ;
				sw.WriteLine("");
				sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				sw.WriteLine("|Student ID| Roll No |        Student Name       | Class |Section|    Stream    |Total Attandance|");
				sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				//            1234567890 123456789 1234567890123456789012345678 1234567 1234567 12345678901234  1234567890123456         
				info = " {0,-10:S} {1,9:S} {2,-28:S}{3,7:S} {4,-7:S} {5,-14:S} {6,16:S}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,SqlDtr.GetValue(0).ToString(),
							SqlDtr.GetValue(1).ToString(),
							GenUtil.TrimLength(SqlDtr.GetValue(2).ToString(),28),
							SqlDtr.GetValue(3).ToString(),
							SqlDtr.GetValue(4).ToString(),
							SqlDtr.GetValue(5).ToString(),
							SqlDtr.GetValue(6).ToString()) ;
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Button1_Click, Attandance Report View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to count Total Attendance of a particular student from attendance_sheet table.
		/// </summary>
		public string Total_Attendance(string sid)
		{
			try
			{
				InventoryClass obj =new InventoryClass();
				SqlDataReader SqlDtr;
				string count="";
				string str="select count(*) from attendance_sheet where student_id='"+sid+"' and attendance_status='Yes' and today_date between '"+GenUtil.ToMMddYYYY(txtfromdate.Text.ToString()) +"' and '"+GenUtil.ToMMddYYYY(txttodate.Text.ToString()) +"'";
				SqlDtr=obj.GetRecordSet(str);
				if(SqlDtr.Read())
				{
					count=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();			
				return count;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Total_Attendance,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				return "";
			}
		}

		private void dgrdStudentLeaveInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Btn_ServerClick(object sender, System.EventArgs e)
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
		/// this method use to create Report in to excel formate. and data also fetch from attendance_sheet table.
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
				string path = home_drive+@"\eSchool_ExcelFile\StudentAttandanceReport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentAttandanceReport1.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "";
				conNorthwind.Open();
				//strSelect="select studentid,rollno,sname,classid,st_section,stream,(select count(*) from attendance_sheet where student_id=s.studentid and attendance_status='Yes' and today_date between '"+GenUtil.ToMMddYYYY(txtfromdate.Text.ToString()) +"' and '"+GenUtil.ToMMddYYYY(txttodate.Text.ToString()) +"') TotalAttandance from Student_Roll s";
				strSelect="select studentid,rollno,sname,classid,st_section,stream,(select count(*) from attendance_sheet where student_id=s.studentid and attendance_status='Yes' and today_date between '"+GenUtil.ToMMddYYYY(txtfromdate.Text.ToString()) +"' and '"+GenUtil.ToMMddYYYY(txttodate.Text.ToString()) +"') TotalAttandance from Student_Roll s where classID='"+DropClass.SelectedItem.Text+ "' and st_section='"+ DropSection.SelectedItem.Text+" ' and stream='" + DropdStream.SelectedItem.Text+ "'";
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				
				sw.WriteLine();
				string des="+----------+---------+---------------------------+-------+-------+--------------+----------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("STUDENT ATTANDANCE REPORT",des.Length)) ;
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------",des.Length)) ;
				sw.WriteLine("");
				//sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				sw.WriteLine("|Student ID\tRoll No\t Student Name\tClass\tSection\t Stream\tTotal Attandance");
				//sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				//            1234567890 123456789 1234567890123456789012345678 1234567 1234567 12345678901234  1234567890123456         
				info = " {0,-10:S} {1,9:S} {2,-28:S}{3,7:S} {4,-7:S} {5,-14:S} {6,16:S}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+
							SqlDtr.GetValue(1).ToString()+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(2).ToString(),28)+"\t"+
							SqlDtr.GetValue(3).ToString()+"\t"+
							SqlDtr.GetValue(4).ToString()+"\t"+
							SqlDtr.GetValue(5).ToString()+"\t"+
							SqlDtr.GetValue(6).ToString()) ;
					}
				}
				SqlDtr.Close();
				//sw.WriteLine("+----------+---------+---------------------------+-------+-------+--------------+----------------+");
				sw.Close(); 
				//Print();
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Button1_Click, Attandance Report View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : AttandanceReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
	}
}

