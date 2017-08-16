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
using System.Text;
using eschool.Classes ;
using System.IO;
using System.Net;
using System.Net.Sockets;
using RMG;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for TeacherWiseTimeTable.
	/// </summary>
	public class TeacherWiseTimeTable : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.DropDownList DropTCode;
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
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form: Teacherwise_TimeTable .aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string str="Select shortname from teachertimetable order by shortname";
					SqlDtr= obj.GetRecordSet(str);
					DataGrid1.Visible=false;
					DropTCode.Items.Clear();
					DropTCode.Items.Add("All");
					while(SqlDtr.Read())
					{
						DropTCode.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="40";
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
				CreateLogFiles.ErrorLog (" Form: Teacherwise_TimeTable .aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.DropTCode.SelectedIndexChanged += new System.EventHandler(this.DropTCode_SelectedIndexChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to generate report in text format. only for teacher wise.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;				
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherWiseTimeTable1.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				string  strSelect="";
				SqlDataReader SqlDtr = null;
				if(DropTCode.SelectedIndex!=0)
				{
					strSelect = "select * from TeacherTimeTable where shortname='"+DropTCode.SelectedItem.Text+"'";
				}
				else
				{
					//strSelect = "select * from TeacherTimeTable ";
					//return;
				}
				SqlDtr=obj.GetRecordSet(strSelect);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				sw.WriteLine("                   --------------------------------");
				sw.WriteLine("                    TEACHER WISE TIME TABLE REPORT");
				sw.WriteLine("                   --------------------------------");
				sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
				sw.WriteLine("|  D / P  |    I     |    II    |   III    |    IV    |    V     |    VI    |    VII   |   VIII   |") ;
				sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
				info = " {0,-9:S} {1,-10:S} {2,-10:S} {3,-10:S} {4,-10:S} {5,-10:S} {6,-10:S} {7,-10:S} {8,-10:S}";
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(info,"Monday",SqlDtr["mon1"].ToString(),SqlDtr["mon2"].ToString(),SqlDtr["mon3"].ToString(),SqlDtr["mon4"].ToString(),SqlDtr["mon5"].ToString(),SqlDtr["mon6"].ToString(),SqlDtr["mon7"].ToString(),SqlDtr["mon8"].ToString());
						sw.WriteLine(info,"Tuesday",SqlDtr["tue1"].ToString(),SqlDtr["tue2"].ToString(),SqlDtr["tue3"].ToString(),SqlDtr["tue4"].ToString(),SqlDtr["tue5"].ToString(),SqlDtr["tue6"].ToString(),SqlDtr["tue7"].ToString(),SqlDtr["tue8"].ToString());
						sw.WriteLine(info,"Wednesday",SqlDtr["wed1"].ToString(),SqlDtr["wed2"].ToString(),SqlDtr["wed3"].ToString(),SqlDtr["wed4"].ToString(),SqlDtr["wed5"].ToString(),SqlDtr["wed6"].ToString(),SqlDtr["wed7"].ToString(),SqlDtr["wed8"].ToString());
						sw.WriteLine(info,"Thruesday",SqlDtr["thu1"].ToString(),SqlDtr["thu2"].ToString(),SqlDtr["thu3"].ToString(),SqlDtr["thu4"].ToString(),SqlDtr["thu5"].ToString(),SqlDtr["thu6"].ToString(),SqlDtr["thu7"].ToString(),SqlDtr["thu8"].ToString());
						sw.WriteLine(info,"Friday",SqlDtr["fri1"].ToString(),SqlDtr["fri2"].ToString(),SqlDtr["fri3"].ToString(),SqlDtr["fri4"].ToString(),SqlDtr["fri5"].ToString(),SqlDtr["fri6"].ToString(),SqlDtr["fri7"].ToString(),SqlDtr["fri8"].ToString());
						sw.WriteLine(info,"Saturday",SqlDtr["sat1"].ToString(),SqlDtr["sat2"].ToString(),SqlDtr["sat3"].ToString(),SqlDtr["sat4"].ToString(),SqlDtr["sat5"].ToString(),SqlDtr["sat6"].ToString(),SqlDtr["sat7"].ToString(),SqlDtr["sat8"].ToString());						
					}
				}								
				SqlDtr.Close();
		
				sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form : Teachertimetable.aspx,Method  Button1_Click,Teacher TimeTable View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form: Teacherwise_TimeTable .aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherWiseTimeTable.txt<EOF>");
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
					CreateLogFiles.ErrorLog(" Form : Teachertimetable.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());CreateLogFiles.ErrorLog(" Form : Teachertimetable.aspx,Method  Button1_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );
				} 
				catch (Exception es) 
				{
					CreateLogFiles.ErrorLog(" Form : Teachertimetable.aspx,Method  Button1_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
				}			
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Teachertimetable.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to show report on the grid. data fetch from teachertimetable table.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			if(DropTCode.SelectedIndex==0)
			{
				btnPrint.Visible=false;
				InventoryClass obj = new InventoryClass();
				SqlDataReader rdr;
				//string str="select * from teachertimetable";
				string str="select * from teachertimetable order by employee_id";
				rdr=obj.GetRecordSet(str);
				if(rdr.HasRows)
				{
					DataGrid1.DataSource=rdr;
					DataGrid1.DataBind();
					DataGrid1.Visible=true;
					pangrid.Visible=true;
				}
				else
				{
					MessageBox.Show("Data Not Available");
					DataGrid1.Visible=false;
					pangrid.Visible=false;
				}
			}
			else
			{
				DataGrid1.Visible=false;
				pangrid.Visible=false;
				btnPrint.Visible=true;
				
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function. 
		/// </summary>
		private void Btnexcel_Click(object sender, System.EventArgs e)
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
		/// this method use to show report on the excel file. data fetch from teachertimetable table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			string home_drive = Environment.SystemDirectory;				
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\TeacherWiseTimeTable1.xls";
			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TeacherWiseTimeTable.txt";
			StreamWriter sw = new StreamWriter(path); 
			InventoryClass obj=new InventoryClass();
			string  strSelect;
			SqlDataReader SqlDtr = null;
			if(DropTCode.SelectedIndex!=0)
			{
				strSelect = "select * from TeacherTimeTable where shortname='"+DropTCode.SelectedItem.Text+"'";
				///else
				///{
				///	return;
				///}
				SqlDtr=obj.GetRecordSet(strSelect);
				sw.WriteLine("                   --------------------------------");
				sw.WriteLine("                    TEACHER WISE TIME TABLE REPORT");
				sw.WriteLine("                   --------------------------------");
				//sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
				sw.WriteLine("  D / P  \t    I     \t    II    \t   III    \t    IV    \t    V     \t    VI    \t    VII   \t   VIII   ") ;
				//sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
				info = " {0,-9:S} {1,-10:S} {2,-10:S} {3,-10:S} {4,-10:S} {5,-10:S} {6,-10:S} {7,-10:S} {8,-10:S}";
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine("Monday"+"\t"+SqlDtr["mon1"].ToString()+"\t"+SqlDtr["mon2"].ToString()+"\t"+SqlDtr["mon3"].ToString()+"\t"+SqlDtr["mon4"].ToString()+"\t"+SqlDtr["mon5"].ToString()+"\t"+SqlDtr["mon6"].ToString()+"\t"+SqlDtr["mon7"].ToString()+"\t"+SqlDtr["mon8"].ToString());
						sw.WriteLine("Tuesday"+"\t"+SqlDtr["tue1"].ToString()+"\t"+SqlDtr["tue2"].ToString()+"\t"+SqlDtr["tue3"].ToString()+"\t"+SqlDtr["tue4"].ToString()+"\t"+SqlDtr["tue5"].ToString()+"\t"+SqlDtr["tue6"].ToString()+"\t"+SqlDtr["tue7"].ToString()+"\t"+SqlDtr["tue8"].ToString());
						sw.WriteLine("Wednesday"+"\t"+SqlDtr["wed1"].ToString()+"\t"+SqlDtr["wed2"].ToString()+"\t"+SqlDtr["wed3"].ToString()+"\t"+SqlDtr["wed4"].ToString()+"\t"+SqlDtr["wed5"].ToString()+"\t"+SqlDtr["wed6"].ToString()+"\t"+SqlDtr["wed7"].ToString()+"\t"+SqlDtr["wed8"].ToString());
						sw.WriteLine("Thruesday"+"\t"+SqlDtr["thu1"].ToString()+"\t"+SqlDtr["thu2"].ToString()+"\t"+SqlDtr["thu3"].ToString()+"\t"+SqlDtr["thu4"].ToString()+"\t"+SqlDtr["thu5"].ToString()+"\t"+SqlDtr["thu6"].ToString()+"\t"+SqlDtr["thu7"].ToString()+"\t"+SqlDtr["thu8"].ToString());
						sw.WriteLine("Friday"+"\t"+SqlDtr["fri1"].ToString()+"\t"+SqlDtr["fri2"].ToString()+"\t"+SqlDtr["fri3"].ToString()+"\t"+SqlDtr["fri4"].ToString()+"\t"+SqlDtr["fri5"].ToString()+"\t"+SqlDtr["fri6"].ToString()+"\t"+SqlDtr["fri7"].ToString()+"\t"+SqlDtr["fri8"].ToString());
						sw.WriteLine("Saturday"+"\t"+SqlDtr["sat1"].ToString()+"\t"+SqlDtr["sat2"].ToString()+"\t"+SqlDtr["sat3"].ToString()+"\t"+SqlDtr["sat4"].ToString()+"\t"+SqlDtr["sat5"].ToString()+"\t"+SqlDtr["sat6"].ToString()+"\t"+SqlDtr["sat7"].ToString()+"\t"+SqlDtr["sat8"].ToString());						
					}
				}								
				SqlDtr.Close();
				//sw.WriteLine("+---------+----------+----------+----------+----------+----------+----------+----------+----------+");
			}
			else
			{
				strSelect="select * from teachertimetable order by employee_id";
				SqlDtr=obj.GetRecordSet(strSelect);
				sw.WriteLine("                   --------------------------------");
				sw.WriteLine("                    TEACHER WISE TIME TABLE REPORT");
				sw.WriteLine("                   --------------------------------");
				sw.WriteLine("Employee Id\tShortname\tMon1\tMon2\tMon3\tMon4\tMon5\tMon6\tMon7\tMon8\tTue1\tTue2\tTue3\tTue4\tTue5\tTue6\tTue7\tTue8\tWed1\tWed2\tWed3\tWed4\tWed5\tWed6\tWed7\tWed8\tThu1\tThu2\tThu3\tThu4\tThu5\tThu6\tThu7\tThu8\tFri1\tFri2\tFri3\tFri4\tFri5\tFri6\tFri7\tFri8\tSat1\tSat2\tSat3\tSat4\tSat5\tSat6\tSat7\tSat8") ;
				info = " {0,-9:S} {1,-10:S} {2,-10:S} {3,-10:S} {4,-10:S} {5,-10:S} {6,-10:S} {7,-10:S} {8,-10:S}";
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						sw.WriteLine(SqlDtr["employee_id"].ToString()+"\t"+SqlDtr["shortname"].ToString()+"\t"+SqlDtr["mon1"].ToString()+"\t"+SqlDtr["mon2"].ToString()+"\t"+SqlDtr["mon3"].ToString()+"\t"+SqlDtr["mon4"].ToString()+"\t"+SqlDtr["mon5"].ToString()+"\t"+SqlDtr["mon6"].ToString()+"\t"+SqlDtr["mon7"].ToString()+"\t"+SqlDtr["mon8"].ToString()+"\t"+SqlDtr["tue1"].ToString()+"\t"+SqlDtr["tue2"].ToString()+"\t"+SqlDtr["tue3"].ToString()+"\t"+SqlDtr["tue4"].ToString()+"\t"+SqlDtr["tue5"].ToString()+"\t"+SqlDtr["tue6"].ToString()+"\t"+SqlDtr["tue7"].ToString()+"\t"+SqlDtr["tue8"].ToString()+"\t"+SqlDtr["wed1"].ToString()+"\t"+SqlDtr["wed2"].ToString()+"\t"+SqlDtr["wed3"].ToString()+"\t"+SqlDtr["wed4"].ToString()+"\t"+SqlDtr["wed5"].ToString()+"\t"+SqlDtr["wed6"].ToString()+"\t"+SqlDtr["wed7"].ToString()+"\t"+SqlDtr["wed8"].ToString()+"\t"+SqlDtr["thu1"].ToString()+"\t"+SqlDtr["thu2"].ToString()+"\t"+SqlDtr["thu3"].ToString()+"\t"+SqlDtr["thu4"].ToString()+"\t"+SqlDtr["thu5"].ToString()+"\t"+SqlDtr["thu6"].ToString()+"\t"+SqlDtr["thu7"].ToString()+"\t"+SqlDtr["thu8"].ToString()+"\t"+SqlDtr["fri1"].ToString()+"\t"+SqlDtr["fri2"].ToString()+"\t"+SqlDtr["fri3"].ToString()+"\t"+SqlDtr["fri4"].ToString()+"\t"+SqlDtr["fri5"].ToString()+"\t"+SqlDtr["fri6"].ToString()+"\t"+SqlDtr["fri7"].ToString()+"\t"+SqlDtr["fri8"].ToString()+"\t"+SqlDtr["sat1"].ToString()+"\t"+SqlDtr["sat2"].ToString()+"\t"+SqlDtr["sat3"].ToString()+"\t"+SqlDtr["sat4"].ToString()+"\t"+SqlDtr["sat5"].ToString()+"\t"+SqlDtr["sat6"].ToString()+"\t"+SqlDtr["sat7"].ToString()+"\t"+SqlDtr["sat8"].ToString());						
					}
				}
				SqlDtr.Close();
			}
			sw.Close(); 
		}

		private void DropTCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
