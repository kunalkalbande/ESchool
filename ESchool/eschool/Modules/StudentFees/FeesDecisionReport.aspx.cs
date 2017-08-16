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
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets; 




namespace eschool.StudentFees
{
	/// <summary>
	
	/// </summary>
	public class FeesDecisionReport : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.DataGrid gridfeesdecision;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlButton BtnPrint;
		protected System.Web.UI.HtmlControls.HtmlButton BtnExcel;
		protected System.Web.UI.WebControls.DropDownList dropStudentClasss;
		protected System.Web.UI.WebControls.Panel panfees;
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
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : FeesDecision_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{

				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="7";
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
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page .IsPostBack)
				{
					SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
					SqlDataReader sdred;
					sdred=obj.showStudentClassforReport();
					while(sdred.Read())
					{
						dropStudentClasss.Items .Add (sdred.GetValue(0).ToString());
					}		
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;
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
			this.dropStudentClasss.SelectedIndexChanged += new System.EventHandler(this.dropStudentClasss_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.BtnPrint.ServerClick += new System.EventHandler(this.BtnPrint_ServerClick);
			this.BtnExcel.ServerClick += new System.EventHandler(this.BtnExcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method use to viewing the report on the datagrid. data fetch from feedecision and class table also.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				if(dropStudentClasss.SelectedIndex==0 )
				{
					MessageBox.Show("Please select the class");
					gridfeesdecision.Visible=false;
				}
				else 
				{
					SqlConnection conNorthwind;
					string  strSelect="",class_id="";
					SqlCommand cmdSelect;
					SqlDataReader dtr=null;
					conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					conNorthwind.Open();
	       
					/*strSelect="Select class_id from class where class_name='"+dropStudentClasss.SelectedItem .Value .ToString()+"'";
					cmdSelect= new SqlCommand(strSelect,conNorthwind);
					dtr=cmdSelect.ExecuteReader();
					if(dtr.Read())
					{
						class_id=dtr.GetValue(0).ToString();
					}
					dtr.Close();*/


					if(dropStudentClasss.SelectedIndex==1)
					{
						//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision"; 
						strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id order by f.class_id"; 
					}
					else
					{
						//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision where class_id='"+dropStudentClasss.SelectedItem .Value .ToString()+"'"; 
						strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id and class_name='"+dropStudentClasss.SelectedItem.Value.ToString()+"'"; 
					}
					
					   
					cmdSelect = new SqlCommand( strSelect, conNorthwind );
					gridfeesdecision.DataSource = cmdSelect.ExecuteReader();
					gridfeesdecision.DataBind();
					if(gridfeesdecision.Items.Count==0)
					{
						MessageBox.Show("No such Record found");
						gridfeesdecision.Visible=false;
						panfees.Visible=false;
					}
					else
					{
						gridfeesdecision.Visible=true;
						panfees.Visible=true;
					}
					CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  Search_ServerClick,  FeesDecision Report viewed for studentClass:"+dropStudentClasss.SelectedItem .Value .ToString()+",Userid :  "+ pass   );					
				
				}
			}
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			 
			}	
				
		}
	
		/// <summary>
		/// Method for writing the report into the text file and data fetch from feesdecision table.calling the method for print the text file.
		/// </summary>
		private void BtnPrint_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesDecisionReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect="",class_id="";
				SqlCommand cmdSelect=null;
				SqlDataReader SqlDtr = null,dtr=null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				conNorthwind.Open();
				strSelect="Select class_id from class where class_name='"+dropStudentClasss.SelectedItem .Value .ToString()+"'";
				cmdSelect= new SqlCommand(strSelect,conNorthwind);
				dtr=cmdSelect.ExecuteReader();
				if(dtr.Read())
				{
					class_id=dtr.GetValue(0).ToString();
				}
				dtr.Close();
				
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)72);				
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)6);
				sw.Write((char)27);
				sw.Write((char)15);
				if(dropStudentClasss.SelectedIndex==1)
				{
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision"; 
					strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id order by f.class_id"; 
				}
				else
				{
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision where class_id='"+dropStudentClasss.SelectedItem .Value .ToString()+"'"; 
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision where class_id='"+class_id.Trim().ToString()+"'"; 
					strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id and class_name='"+dropStudentClasss.SelectedItem.Value.ToString()+"'"; 
				}
				
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				string des="+----+------+---------+-------+-----+-----+------+-----+-----+-----+------+-----+-----+-----+-----+-----+-----------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("FEES DECISION REPORT",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Class : "+dropStudentClasss.SelectedItem.Text,des.Length));
				//sw.WriteLine("+----+------+---------+-------+-----+-----+------+-----+-----+-----+-----+----+------+------+-----+-----+-----+-----+-----+-----------+");
				//sw.WriteLine("|cls |Stream|Fees Mode| S.Cat.|Rank |Diary|Tution|Comp.|Scie.|Acti.|Games|Late|Trans.|Admis.|Secu.|Annu.|Envp.|Host.|Total|  Remarks  |");
				//sw.WriteLine("+----+------+---------+-------+-----+-----+------+-----+-----+-----+-----+----+------+------+-----+-----+-----+-----+-----+-----------+");
				sw.WriteLine("+----+------+---------+-------+-----+-----+------+-----+-----+-----+------+-----+-----+-----+-----+-----+-----------+");
				sw.WriteLine("|cls |Stream|Fees Mode| S.Cat.|Rank |Diary|Tution|Comp.|Scie.|Games|Admis.|Secu.|Annu.|Env. |Host.|Total|  Remarks  |");
				sw.WriteLine("+----+------+---------+-------+-----+-----+------+-----+-----+-----+------+-----+-----+-----+-----+-----+-----------+");
				//			   1234	123456 123456789 1234567 12345 12345 123456	12345 12345	12345 123456 12345 12345 12345 12345 12345 12345678901
				info = " {0,-4:S} {1,-6:S} {2,-9:S} {3,-7:F} {4,-5:F} {5,5:F} {6,6:F} {7,5:F} {8,5:F} {9,5:F} {10,6:F} {11,5:F} {12,5:F} {13,5:F} {14,5:F} {15,5:F} {16,11:F} ";
				//info = " {0,-4:S} {1,-6:S} {2,-9:S} {3,-7:F} {4,-5:F} {5,5:F} {6,6:F} {7,5:F} {8,5:F} {9,5:F} {10,5:F} {11,5:F} {12,4:F} {13,6:F} {14,6:F} {15,5:F} {16,5:F} {17,5:F} {18,5:F} {19,11:F}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,GenUtil.TrimLength(SqlDtr["class_name"].ToString(),4),
							GenUtil.TrimLength(SqlDtr["student_stream"].ToString(),6),
							SqlDtr["feemode"].ToString(),
							GenUtil.TrimLength(SqlDtr["scategory"].ToString(),11),
							GenUtil.TrimLength(SqlDtr["srank"].ToString(),11),
							SqlDtr["diary_fee"].ToString(),
							SqlDtr["tution_fee"].ToString(),
							SqlDtr["computer_fee"].ToString(),
							SqlDtr["science_fee"].ToString(),
							//SqlDtr["activity_fee"].ToString(),
							SqlDtr["games_fee"].ToString(),
							//SqlDtr["late_fee"].ToString(),
							//SqlDtr["transport_fee"].ToString(),
							SqlDtr["admission_fee"].ToString(),
							SqlDtr["caution_fee"].ToString(),
							SqlDtr["annual_fee"].ToString(),
							SqlDtr["envp_fee"].ToString(),
							SqlDtr["hostel_fee"].ToString(),
							SqlDtr["total"].ToString(),
							GenUtil.TrimLength(SqlDtr["remarks"].ToString(),11)
							);
					}
				}
				
				SqlDtr.Close();
				sw.WriteLine("+----+------+---------+-------+-----+-----+------+-----+-----+-----+------+-----+-----+-----+-----+-----+-----------+");
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}

		/// <summary>
		/// Method for sending the text file to the printer and issue the print command to printer to print the report.
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
					///CreateLogFiles.ErrorLog("Form:StudentInformation.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesDecisionReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click,  Fees Decision Report Printed, Userid :  "+ pass);								                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click, Exception"+ ane.Message+",  Fees Decision Report Printed, Userid :  "+ pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click, Exception"+ se.Message+",  Fees Decision Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click, Exception"+ es.Message+",  Fees Decision Report Printed, Userid :  "+ pass);
				}			
			} 
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click, Exception :"+ex.Message +", Fees Decision Report Printed, Userid :  "+ pass);
								
			}

		}

		private void dropStudentClasss_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void BtnExcel_ServerClick(object sender, System.EventArgs e)
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
		/// Method for writing the report into the text file and data fetch from feesdecision table.calling the method for print the text file.
		/// </summary>
		public void ConvertIntoExcel()
		{
			/*int i=1;
			SqlDataReader SqlDtr=null;
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\Pending_AdvanceFeesReport1.xls";*/
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\FeesDecisionReport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesDecisionReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				string  strSelect="",class_id="";
				SqlCommand cmdSelect=null;
				SqlDataReader SqlDtr = null,dtr=null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				conNorthwind.Open();
				strSelect="Select class_id from class where class_name='"+dropStudentClasss.SelectedItem .Value .ToString()+"'";
				cmdSelect= new SqlCommand(strSelect,conNorthwind);
				dtr=cmdSelect.ExecuteReader();
				if(dtr.Read())
				{
					class_id=dtr.GetValue(0).ToString();
				}
				dtr.Close();

				if(dropStudentClasss.SelectedIndex==1)
				{
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision"; 
					strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id order by f.class_id"; 
				}
				else
				{
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision where class_id='"+dropStudentClasss.SelectedItem .Value .ToString()+"'"; 
					//strSelect = "select  class_id,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision where class_id='"+class_id.ToString()+"'"; 
					strSelect = "select class_name,student_stream,feemode ,diary_fee,tution_fee,computer_fee,science_fee,activity_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,remarks, total,scategory,srank from feesdecision f,class c where f.class_id=c.class_id and class_name='"+dropStudentClasss.SelectedItem.Value.ToString()+"'"; 
				}
				
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				string des="+---+--------------+--------+-----+------+-----+-----+--------+----+----+-----+-----+--------+------+----+------+-------+---------------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("FEES DECISION REPORT",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Class : "+dropStudentClasss.SelectedItem.Text,des.Length));
				//sw.WriteLine("+---+--------------+--------+-----------+-----------+----+----+----+----+----+----+----+----+----+----+----+----+----+------+-----------+");
				sw.WriteLine("CID\tStudent Stream\tFee Mode\t SCategory\tRank\tDiar\tTutn\tComp\tScie\tGame\tAdmi\tSecu\tAnnu\tEnv\tHost\tTotal\tRemarks");
				//sw.WriteLine("+---+--------------+--------+-----------+-----------+----+----+----+----+----+----+----+----+----+----+----+----+----+------+-----------+");
				//             123 12345678901234 12345678 12345678901 12345678901 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 123456 12345678901
				info = " {0,-3:S} {1,-14:S} {2,-8:S} {3,-11:F} {4,-11:F} {5,4:F} {6,4:F} {7,4:F} {8,4:F} {9,4:F} {10,4:F} {11,4:F} {12,4:F} {13,4:F} {14,4:F} {15,4:F} {16,4:F} {17,4:F} {18,6:F} {19,-11:F}";
				SqlDtr = cmdSelect.ExecuteReader();
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr["class_name"].ToString()+"\t"+
							SqlDtr["student_stream"].ToString()+"\t"+
							SqlDtr["feemode"].ToString()+"\t"+
							SqlDtr["scategory"].ToString()+"\t"+
							SqlDtr["srank"].ToString()+"\t"+
							SqlDtr["diary_fee"].ToString()+"\t"+
							SqlDtr["tution_fee"].ToString()+"\t"+
							SqlDtr["computer_fee"].ToString()+"\t"+
							SqlDtr["science_fee"].ToString()+"\t"+
							//SqlDtr["activity_fee"].ToString()+"\t"+
							SqlDtr["games_fee"].ToString()+"\t"+
							//SqlDtr["late_fee"].ToString()+"\t"+
							//SqlDtr["transport_fee"].ToString()+"\t"+
							SqlDtr["admission_fee"].ToString()+"\t"+
							SqlDtr["caution_fee"].ToString()+"\t"+
							SqlDtr["annual_fee"].ToString()+"\t"+
							SqlDtr["envp_fee"].ToString()+"\t"+
							SqlDtr["hostel_fee"].ToString()+"\t"+
							SqlDtr["total"].ToString()+"\t"+
							SqlDtr["remarks"].ToString()
							);
						
					}
				}			
				SqlDtr.Close();
				//sw.WriteLine("+---+--------------+--------+-----------+-----------+----+----+----+----+----+----+----+----+----+----+----+----+----+------+-----------+");
				sw.Close(); 
				//Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDecisionReport.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}

		}
	
	}
}
