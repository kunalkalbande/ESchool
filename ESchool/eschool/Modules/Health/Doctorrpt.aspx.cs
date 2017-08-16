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
using eschool.Classes;
using System.Net;
using System.Net.Sockets; 
using System.IO;
using System.Text;
using RMG;

namespace eschool.Health
{
	/// <summary>
	/// Summary description for Doctorrpt.
	/// </summary>
	public class Doctorrpt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.DataGrid dgrdsuspend;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.HtmlControls.HtmlButton BtnExcel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel pandoc;
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
				CreateLogFiles.ErrorLog (" Form : Doctor_Report.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Doctor_Report.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select docid  From doctor", con );
					dtrclass = cmdselect.ExecuteReader();
					while(dtrclass.Read())
					{
						Dropstudentid.Items.Add(dtrclass.GetValue(0).ToString());
					}
					dtrclass.Close();
					con.Close ();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="16";
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
				CreateLogFiles.ErrorLog (" Form : Doctor.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Dropstudentid.SelectedIndexChanged += new System.EventHandler(this.Dropstudentid_SelectedIndexChanged);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.BtnExcel.ServerClick += new System.EventHandler(this.BtnExcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to Fetch Doctors Name from doctors table.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*try
			{
				txtstudentname.Text="";
				SqlConnection con44;
				SqlCommand cmdselect44;
				SqlDataReader dtrdrive44;
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				cmdselect44 = new SqlCommand( "Select doctor_name  From doctor where docid=@docid", con44 );
				cmdselect44.Parameters .Add ("@docid",Dropstudentid.SelectedItem .Text.ToString());
				dtrdrive44 = cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{
					txtstudentname.Text  =dtrdrive44.GetString(0);
				}
				dtrdrive44.Close();
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Doctor's_Report.aspx,Method  Dropstudentid_SelectedIndexChanged, Exception"+ ex.Message+",  Fees Decision Report Printed, Userid :  "+ pass);
			}*/
		}

		/// <summary>
		/// This method fetch record from doctor table and show through the datagrid.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con1 ;
				string strInsert1="";
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				
				if(Dropstudentid.SelectedIndex!=0)
				{
					strInsert1 ="Select * From doctor where docid =@docid";
				}
				else
				{
					strInsert1 ="Select * From doctor order by doctor_name";
				}

				cmdInsert1=new SqlCommand (strInsert1,con1);	
				if(Dropstudentid.SelectedIndex!=0)
					cmdInsert1.Parameters .Add("@docid",Dropstudentid.SelectedItem .Text .ToString () ); 
				dgrdsuspend.DataSource =cmdInsert1.ExecuteReader();
				dgrdsuspend.DataBind ();
				if(dgrdsuspend.Items.Count==0)
				{
					MessageBox.Show("Record not found");
					pandoc.Visible=false;
				}
				else
				{
					pandoc.Visible=true;
				}
				con1.Close();    
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Doctors's_Report.aspx,Method  Search_ServerClick, Exception"+ ex.Message+",  Fees Decision Report Printed, Userid :  "+ pass);
			}
		}

		/// <summary>
		/// This method use to create connection between remote device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Doctor's_Report.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Doctor's_Report.txt
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

		/// <summary>
		/// This method use to print the report. informaton fetch from doctor table. save as DoctorReport.txt in to eschoolprintservice folder.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			//Response .Redirect("../PrintPreview/DoctorrptPrint.aspx");
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Doctor's_Report.txt";
			StreamWriter sw = new StreamWriter(path); 
			SqlConnection conNorthwind;
			string  strSelect="";
			SqlCommand cmdSelect=null;
			SqlDataReader SqlDtr = null;
			conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			if(Dropstudentid.SelectedIndex!=0)
			{
				strSelect="Select *  From doctor where docid ="+Dropstudentid.SelectedItem.Text;
			}
			else
			{
				strSelect="Select *  From doctor";
			}
			conNorthwind.Open();
			cmdSelect = new SqlCommand( strSelect, conNorthwind );
			string des="+--------------------+-----------+--------------------+-------+------+------------+------------+----------+";
			//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("DOCTOR'S REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
			//sw.WriteLine("Class : "+dropStudentClasss.SelectedItem.Text);
			sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			sw.WriteLine("|    First_Name      |Specialty  |     Address        | City  | State|  Phone(O)  |   Phone(R) | Mobile   |");
			sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			//             123 12345678901234 12345678 12345678901 12345678901 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 123456 12345678901
			info = " {0,-20:S} {1,-11:S} {2,-20:S} {3,-7:F} {4,-6:F} {5,12:F} {6,12:F} {7,10:F}";
			SqlDtr = cmdSelect.ExecuteReader();
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					sw.WriteLine(info,
						SqlDtr["doctor_name"].ToString(),
						SqlDtr["specialisation"].ToString(),
						GenUtil.TrimLength(SqlDtr["add1"].ToString(),11),
						GenUtil.TrimLength(SqlDtr["city"].ToString(),11),
						SqlDtr["state"].ToString(),
						SqlDtr["phone1_off"].ToString(),
						SqlDtr["phone1_res"].ToString(),
						SqlDtr["mobile"].ToString()						
						);
				}
			}
			SqlDtr.Close();
			sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			sw.Close(); 
			Print();
		}

		/// <summary>
		/// This method use to create report in .xls format.
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
		/// This method use to create the report. informaton fetch from doctor table. save as DoctorReport.xls in to eschool_excelfile in home drive.
		/// </summary>
		public void ConvertIntoExcel()
		{

			/*string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DoctorReport.txt";*/

			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\DoctorReport.xls";
						
			StreamWriter sw = new StreamWriter(path); 
			SqlConnection conNorthwind;
			string  strSelect="";
			SqlCommand cmdSelect=null;
			SqlDataReader SqlDtr = null;
			conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);

			if(Dropstudentid.SelectedIndex!=0)
			{
				strSelect=" Select *  From doctor where docid ="+Dropstudentid.SelectedItem.Text;
			}
			else
			{
				strSelect=" Select *  From doctor ";
			}

			conNorthwind.Open();
			cmdSelect = new SqlCommand( strSelect, conNorthwind );
			string des="+--------------------+-----------+--------------------+-------+------+------------+------------+----------+";
			//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("DOCTOR'S REPORT",des.Length));
			sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
			//sw.WriteLine("Class : "+dropStudentClasss.SelectedItem.Text);
			//sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			sw.WriteLine("First_Name \tSpecialty\tAddress\tCity\tState\tPhone(O)\tPhone(R)\tMobile");
			//sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			//             123 12345678901234 12345678 12345678901 12345678901 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 1234 123456 12345678901
			info = " {0,-20:S} {1,-11:S} {2,-20:S} {3,-7:F} {4,-6:F} {5,12:F} {6,12:F} {7,10:F}";
			SqlDtr = cmdSelect.ExecuteReader();
			if(SqlDtr.HasRows)
			{
				while(SqlDtr.Read())
				{
					sw.WriteLine(
						SqlDtr["doctor_name"].ToString()+"\t"+
						SqlDtr["specialisation"].ToString()+"\t"+
						SqlDtr["add1"].ToString()+"\t"+
						SqlDtr["city"].ToString()+"\t"+
						SqlDtr["state"].ToString()+"\t"+
						SqlDtr["phone1_off"].ToString()+"\t"+
						SqlDtr["phone1_res"].ToString()+"\t"+
						SqlDtr["mobile"].ToString()						
						);
				}
			}
			SqlDtr.Close();
			//sw.WriteLine("+--------------------+-----------+--------------------+-------+------+------------+------------+----------+");
			sw.Close(); 

		}
	}
}
