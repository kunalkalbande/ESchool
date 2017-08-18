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
using System.Data .SqlClient ;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
# endregion

namespace eschool.Reports
{
	
	/// <summary>
	/// Summary description for TimeTableAdjustmentReport.
	/// </summary>
	public class TimeTableAdjustmentReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid Datastafftype;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.DropDownList Dropstaffid;
		protected System.Web.UI.HtmlControls.HtmlButton btnPrint;
		protected System.Web.UI.HtmlControls.HtmlButton Btn;
		protected System.Web.UI.WebControls.TextBox txtadjustdate;
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
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false); 
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader dtratt;
				if(!Page.IsPostBack)
				{
                    txtadjustdate.Attributes.Add("readonly", "readonly");
                    txtadjustdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year; 
					string strstr="select distinct staff_id from timetableadjust";
					dtratt=obj.GetRecordSet(strstr);
					Dropstaffid.Items.Clear();
					Dropstaffid.Items.Add("Select");
					Dropstaffid.Items.Add("All");
					while(dtratt.Read())
					{
						Dropstaffid.Items.Add(dtratt.GetValue(0).ToString());//+":"+dtratt.GetValue(1).ToString());
					}
					dtratt.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false); 
				return;
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="41";
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
				if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(Add_Flag=="False")
				{
					
				}
				#endregion
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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.btnPrint.ServerClick += new System.EventHandler(this.btnPrint_ServerClick);
			this.Btn.ServerClick += new System.EventHandler(this.Btn_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to generate report and show on grid. data fetch from staff_information and timetableadjustment.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				if(Dropstaffid.SelectedIndex==0)
				{
					MessageBox.Show("Please select the Teacher id ");
				}
				else if(Dropstaffid.SelectedItem.Text.Equals("All"))
				{
					SqlConnection con1 ;
					string strInsert1;
					SqlCommand cmdInsert1;
					con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con1.Open ();
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"'";
					cmdInsert1=new SqlCommand (strInsert1,con1);
					Datastafftype.DataSource =cmdInsert1.ExecuteReader();
					Datastafftype.DataBind ();
					CreateLogFiles.ErrorLog(" Form : timetableAdjustmentReport.aspx,Method  Search_ServerClick,  Time Table Adjustment Report , Userid :  "+ pass   );		
					if(Datastafftype.Items.Count==0)
					{
						MessageBox.Show("No such record found");
						Datastafftype.Visible=false;
						pangrid.Visible=false;
					}
					else
					{
						Dropstaffid.Visible=true;
						Datastafftype.Visible=true;
						pangrid.Visible=true;
					}
					con1.Close();
					
				}
				else 
				{
					SqlConnection con1 ;
					string strInsert1;
					SqlCommand cmdInsert1;
					con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con1.Open ();
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"' and staff_id='"+Dropstaffid.SelectedItem.Text.Trim()+"'";
					cmdInsert1=new SqlCommand (strInsert1,con1);
					Datastafftype.DataSource =cmdInsert1.ExecuteReader();
					Datastafftype.DataBind ();
					CreateLogFiles.ErrorLog(" Form : timetableAdjustmentReport.aspx,Method  Search_ServerClick,  Time Table Adjustment Report , Userid :  "+ pass   );		
					if(Datastafftype.Items.Count==0)
					{
						MessageBox.Show("No such record found");
						Datastafftype.Visible=false;
						pangrid.Visible=false;
					}
					else
					{
						Datastafftype.Visible=true;
						Dropstaffid.Visible=true;
						pangrid.Visible=true;
					}
					con1.Close();
					
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Teacherstimetable.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
                 
			}
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method :  Print(),  TimeTableAdjustment Printed , Userid :  "+ pass   );							 
			     } 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to generate report and show in text format. data fetch from staff_information and timetableadjustment.
		/// </summary>
		private void btnPrint_ServerClick(object sender, System.EventArgs e)
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr=null;
			String strInsert1="";
			try
			{
				Search_ServerClick(sender,e);
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentReport1.txt";
				StreamWriter sw = new StreamWriter(path); 
				if(Dropstaffid.SelectedIndex==0)
				{
					MessageBox.Show("Please select the Teacher id ");
				}
				else if(Dropstaffid.SelectedItem.Text.Equals("All"))
				{
						
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"'";
											
				}
				else 
				{
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"' and staff_id='"+Dropstaffid.SelectedItem.Text.Trim()+"'";
				}
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
				string des="+---------+--------------------+----------------------------+----------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("TimeTableAdjustmentReport For "+txtadjustdate.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------------------",des.Length));
				info = " {0,9:S} {1,-20:S} {2,-28:S} {3,-16:S} ";
				sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				sw.WriteLine("|AdjustmID|  Staff Name        | AdjustTeacherID & Name     |     Class      |");
				sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				//             123456789 12345678901234567890 1234567890123456789012345678 1234567890123456 
				SqlDtr=obj.GetRecordSet(strInsert1);
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine (info,SqlDtr.GetValue(0).ToString(),GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),20),
						GenUtil.TrimLength(SqlDtr.GetValue(2).ToString(),28),GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),16));
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				sw.Close();
				Print();
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  btnPrint_Click, TimeTableAdjustment View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to ConvertIntoExcel() function.
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
		/// this method use to generate report and show in excel format. data fetch from staff_information and timetableadjustment.
		/// </summary>
		public void ConvertIntoExcel()
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr=null;
			String strInsert1="";
			try
			{
				//Search_ServerClick(sender,e);
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";

				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\TimeTableAdjustmentReport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				if(Dropstaffid.SelectedIndex==0)
				{
					MessageBox.Show("Please select the Teacher id ");
				}
				else if(Dropstaffid.SelectedItem.Text.Equals("All"))
				{
						
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"'";
											
				}
				else 
				{
					strInsert1="select adjustid, (Select staff_name from staff_information s where s.staff_id=t.staff_id) Staff_name,adjustteacherid,class_name from timetableadjust t where ttime='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"' and staff_id='"+Dropstaffid.SelectedItem.Text.Trim()+"'";
				}
				
				sw.WriteLine();
				string des="+---------+--------------------+----------------------------+----------------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("-------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("TimeTableAdjustmentReport For "+txtadjustdate.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("-------------------------------------",des.Length));
				info = " {0,9:S} {1,-20:S} {2,-28:S} {3,-16:S} ";
				//sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				sw.WriteLine("AdjustmID\tStaff Name\tAdjustTeacherID & Name \t   Class  ");
				//sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				//             123456789 12345678901234567890 1234567890123456789012345678 1234567890123456 
				SqlDtr=obj.GetRecordSet(strInsert1);
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine (SqlDtr.GetValue(0).ToString()+"\t"+GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),20)+"\t"+
							GenUtil.TrimLength(SqlDtr.GetValue(2).ToString(),28)+"\t"+GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),16));
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+---------+--------------------+----------------------------+----------------+");
				sw.Close();
				//Print();
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  btnPrint_Click, TimeTableAdjustment View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustmentReport.aspx,Method  btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
		
	}
}
