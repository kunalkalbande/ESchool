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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using eschool.Classes;
namespace eschool.Reports
{
	/// <summary>
	/// Summary description for PeriodWise.
	/// </summary>
	public class PeriodWise : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDay;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.DropDownList DropPeriod;
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
				CreateLogFiles.ErrorLog (" Form : PeriodWise.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				
				if(!Page.IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="38";
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
						return;
					}
					#endregion

				}
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: PeriodWise.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				//return;
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
			this.DropPeriod.SelectedIndexChanged += new System.EventHandler(this.DropPeriod_SelectedIndexChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DropPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to show time table in datagrid. data fetch from teachertimetable table.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader SqlDtr;
			string day="",period="";
			if(DropDay.SelectedIndex!=0)
			{
				if(DropDay.SelectedItem.Text.Equals("Monday"))
					day="mon";
				else if(DropDay.SelectedItem.Text.Equals("Tuesday"))
					day="tue";
				else if(DropDay.SelectedItem.Text.Equals("Wednesday"))
					day="wed";
				else if(DropDay.SelectedItem.Text.Equals("Thruesday"))
					day="thu";
				else if(DropDay.SelectedItem.Text.Equals("Friday"))
					day="fri";
				else if(DropDay.SelectedItem.Text.Equals("Saturday"))
					day="sat";
			}
			else
			{
				MessageBox.Show("Please Select The Day");
				pangrid.Visible=false;
				return;
			}
			if(DropPeriod.SelectedIndex!=0)
			{
				if(DropPeriod.SelectedItem.Text.Equals("I"))
					period="1";
				else if(DropPeriod.SelectedItem.Text.Equals("II"))
					period="2";
				else if(DropPeriod.SelectedItem.Text.Equals("III"))
					period="3";
				else if(DropPeriod.SelectedItem.Text.Equals("IV"))
					period="4";
				else if(DropPeriod.SelectedItem.Text.Equals("V"))
					period="5";
				else if(DropPeriod.SelectedItem.Text.Equals("VI"))
					period="6";
				else if(DropPeriod.SelectedItem.Text.Equals("VII"))
                    period="7";
				else if(DropPeriod.SelectedItem.Text.Equals("VIII"))
					period="8";
			}
			else
			{
				MessageBox.Show("Please Select The Period");
				pangrid.Visible=false;
				return;
			}
			string str="select shortname,"+day+period+" sub from teachertimetable";
			SqlDtr=obj.GetRecordSet(str);
			if(SqlDtr.HasRows)
			{
				pangrid.Visible=true;
				DataGrid1.DataSource=SqlDtr;
				DataGrid1.DataBind();
			}
			else
			{
				MessageBox.Show("Data Not Available");
				pangrid.Visible=false;
			}
		}

		/// <summary>
		/// This method use to show time table in text format. data fetch from teachertimetable table.
		/// </summary>
		public void MakingReport()
		{
			try
			{
				string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Periodwisereport.txt";
				StreamWriter sw = new StreamWriter(path);
				string day="",period="";
				if(DropDay.SelectedIndex!=0)
				{
					if(DropDay.SelectedItem.Text.Equals("Monday"))
						day="mon";
					else if(DropDay.SelectedItem.Text.Equals("Tuesday"))
						day="tue";
					else if(DropDay.SelectedItem.Text.Equals("Wednesday"))
						day="wed";
					else if(DropDay.SelectedItem.Text.Equals("Thruesday"))
						day="thu";
					else if(DropDay.SelectedItem.Text.Equals("Friday"))
						day="fri";
					else if(DropDay.SelectedItem.Text.Equals("Saturday"))
						day="sat";
				}
				else
				{
					MessageBox.Show("Please Select The Day");
					return;
				}

				if(DropPeriod.SelectedIndex!=0)
				{
					if(DropPeriod.SelectedItem.Text.Equals("I"))
						period="1";
					else if(DropPeriod.SelectedItem.Text.Equals("II"))
						period="2";
					else if(DropPeriod.SelectedItem.Text.Equals("III"))
						period="3";
					else if(DropPeriod.SelectedItem.Text.Equals("IV"))
						period="4";
					else if(DropPeriod.SelectedItem.Text.Equals("V"))
						period="5";
					else if(DropPeriod.SelectedItem.Text.Equals("VI"))
						period="6";
					else if(DropPeriod.SelectedItem.Text.Equals("VII"))
						period="7";
					else if(DropPeriod.SelectedItem.Text.Equals("VIII"))
						period="8";
				}
				else
				{
					MessageBox.Show("Please Select The Period");
					return;
				}
				string info1 = "";
				info1 = " {0,-14:S} {1,-34:S}";
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str = "";
				str = "select shortname,"+day+period+" sub from teachertimetable";
				rdr=obj.GetRecordSet(str);
				sw.WriteLine("				---------------------------------");
				sw.WriteLine("				  Period Wise Time Table Report ");
				sw.WriteLine("				----------------------------------");
				sw.WriteLine("");
				sw.WriteLine(info1,"Teacher Code : "+DropDay .SelectedItem.Text,"Period : "+DropPeriod .SelectedItem.Text);
				sw.WriteLine("+--------------+------------------------+");
				sw.WriteLine("|Teacher Code  |   Class Wise Subject   |");
				sw.WriteLine("+--------------+------------------------+");
				//             12345678901234 123456789012345678901234
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{
						sw.WriteLine(info1,
							rdr["shortname"].ToString(),
							rdr["sub"].ToString()
							);				
					}
				}
				rdr.Close();
				sw.WriteLine("+--------------+------------------------+");
				sw.Close();
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass);		
			}
		}

		/// <summary>
		/// Method for returning the date part of the string.
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
		/// Method for issueing the print command to the printer for printing the text file.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];
     		try 
			{
				MakingReport();
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
					byte[] msg = Encoding.ASCII.GetBytes("periodwiseReport1.txt<EOF>");
       				/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				 	CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  btnPrint_Click, PeriodWise Report Printed, Userid :  "+ pass   );		              
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  btnPrint_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  btnPrint_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  btnPrint_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
     
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
		/// this method use to show time table excel format. data fetch from teachertimetable table.
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
				string path = home_drive+@"\eSchool_ExcelFile\Periodwisereport.xls";
				
				//string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Periodwisereport.txt";
				StreamWriter sw = new StreamWriter(path);
				string day="",period="";
				if(DropDay.SelectedIndex!=0)
				{
					if(DropDay.SelectedItem.Text.Equals("Monday"))
						day="mon";
					else if(DropDay.SelectedItem.Text.Equals("Tuesday"))
						day="tue";
					else if(DropDay.SelectedItem.Text.Equals("Wednesday"))
						day="wed";
					else if(DropDay.SelectedItem.Text.Equals("Thruesday"))
						day="thu";
					else if(DropDay.SelectedItem.Text.Equals("Friday"))
						day="fri";
					else if(DropDay.SelectedItem.Text.Equals("Saturday"))
						day="sat";
				}
				else
				{
					MessageBox.Show("Please Select The Day");
					return;
				}

				if(DropPeriod.SelectedIndex!=0)
				{
					if(DropPeriod.SelectedItem.Text.Equals("I"))
						period="1";
					else if(DropPeriod.SelectedItem.Text.Equals("II"))
						period="2";
					else if(DropPeriod.SelectedItem.Text.Equals("III"))
						period="3";
					else if(DropPeriod.SelectedItem.Text.Equals("IV"))
						period="4";
					else if(DropPeriod.SelectedItem.Text.Equals("V"))
						period="5";
					else if(DropPeriod.SelectedItem.Text.Equals("VI"))
						period="6";
					else if(DropPeriod.SelectedItem.Text.Equals("VII"))
						period="7";
					else if(DropPeriod.SelectedItem.Text.Equals("VIII"))
						period="8";
				}
				else
				{
					MessageBox.Show("Please Select The Period");
					return;
				}
				string info1 = "";
				info1 = " {0,-14:S} {1,-34:S}";
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str = "";
				str = "select shortname,"+day+period+" sub from teachertimetable";
				rdr=obj.GetRecordSet(str);
				sw.WriteLine("				---------------------------------");
				sw.WriteLine("				  Period Wise Time Table Report ");
				sw.WriteLine("				----------------------------------");
				sw.WriteLine("");
				sw.WriteLine(info1,"Teacher Code : "+DropDay .SelectedItem.Text,"Period : "+DropPeriod .SelectedItem.Text);
				//sw.WriteLine("+--------------+------------------------+");
				sw.WriteLine("Teacher Code  \t  Class Wise Subject   ");
				//sw.WriteLine("+--------------+------------------------+");
				//             12345678901234 123456789012345678901234
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{
						sw.WriteLine(
							rdr["shortname"].ToString()+"\t"+
							rdr["sub"].ToString()
							);				
					}
				}
				rdr.Close();
				//sw.WriteLine("+--------------+------------------------+");
				sw.Close();
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :PeriodWise.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass);		
			}
		}
	}
}
