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

namespace eschool.Modules.Reports
{
	/// <summary>
	/// Summary description for TimeTableAdjustmentPeriodWise.
	/// </summary>
	public class TimeTableAdjustmentPeriodWise : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropday;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox Txtdate;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.DataGrid GridAdjustment;
		protected System.Web.UI.WebControls.Panel pangrid;
		string pass="";

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=Session["password"].ToString();
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
                    Txtdate.Attributes.Add("readonly", "readonly");
                    Txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;

					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="42";
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
					if(View_flag=="False")
					{
						
					}
				
					#endregion
				}
			}
			catch(Exception ex)
			{
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to show report on to grid. data fetch from timetableadjustmentperiodwise and staff_information tables.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{ 
				SqlConnection Con;
				SqlCommand Cmd;
				SqlDataReader Dtr;
				Con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				Con.Open();
				string str="select st.Staff_Name,tt.Period,tt.Teacher_Id,tt.Class from timetableadjustmentperiodwise tt,staff_information st where st.staff_id=tt.Teacher_Id and Todate='"+GenUtil.str2MMDDYYYY(Txtdate.Text)+"' and days='"+Dropday.SelectedItem.Value+"'";
				Cmd=new SqlCommand(str,Con);
				Dtr=Cmd.ExecuteReader();
				GridAdjustment.DataSource=Dtr;
				//GridAdjustment.DataBind();
				if(!Dtr.HasRows)
				{
					MessageBox.Show("Record not found");
					pangrid.Visible=false;
				}
				else
				{
					pangrid.Visible=true;
					GridAdjustment.DataBind();	
				}
				Cmd.Dispose();
				Dtr.Close();
			}
			catch(Exception ex)
			{
                 CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Search. Exception: " + ex.Message + " User: " + pass );
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentPeriodWise_Report1.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: TimeTableAdjustmentPeriodWiseReport, User: " + pass );
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + ane.Message + " User: " + pass );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + se.Message + " User: " + pass );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + es.Message + " User: " + pass );
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to show report on to grid. data fetch from timetableadjustmentperiodwise and staff_information tables.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				bool flag=false,flage1=true;
				string Path=home_drive+ @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentPeriodWise_Report1.txt";
				SqlCommand cmd;
				SqlConnection con;
				SqlDataReader dtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();
				StreamWriter sw=new StreamWriter(Path);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				string des="+----------------------+----+---------------------+     +----------------------+----+---------------------+";
				string des1="---------------------------------------------------     ---------------------------------------------------";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SUBSTITUTION CHART "+Dropday.SelectedItem.Value+", "+Txtdate.Text,des.Length));
				sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				sw.WriteLine("|          NAME        |CLAS|   SIGN(FULL NAME)   |     |          NAME        |CLAS|   SIGN(FULL NAME)   |");
				sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				int i=0;
				string info1=" {0,-21:S} {1,4:S} ";
				string info2=" {0,-21:S} {1,4:S}                           ";
				string str="select st.Staff_Name,tt.Period,tt.Teacher_Id,tt.Class,tt.Sections from timetableadjustmentperiodwise tt,staff_information st where st.staff_id=tt.Teacher_Id and Todate='"+GenUtil.str2MMDDYYYY(Txtdate.Text)+"' and days='"+Dropday.SelectedItem.Value+"'";
				cmd=new SqlCommand(str,con);
				dtr=cmd.ExecuteReader();
    			while(dtr.Read())
				{
					
					if(Convert.ToInt16(dtr["period"])==1)
					{ 			
						//if(flag==false)
						if(flag==false || flage1==true)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("I PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
							flage1=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					}
					else if(Convert.ToInt16(dtr["period"])==2)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("II PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==3)
					{ 				   
						//if(flag==false)
						if(flag==false || flage1==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("III PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
							flage1=true;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					}
					else if(Convert.ToInt16(dtr["period"])==4)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("IV PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
				    
					else if(Convert.ToInt16(dtr["period"])==5)
					{ 				   
						//if(flag==false)
						if(flag==false ||flage1==true )
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("V PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
							flage1=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					}
					
					else if(Convert.ToInt16(dtr["period"])==6)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("VI PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==7)
					{ 				   
						//if(flag==false)
						if(flag==false || flage1==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("VII PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
							flage1=true;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==8)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("VIII PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						
						if(i%2==0)
						{
							sw.Write(info2,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
						}
						else if(i%2==1)
						{
							sw.WriteLine(info1,GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
					
					i++;
				}
				sw.Close();
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + ex.Message + " User: " + pass );
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
		/// this method use to show report on to excel. data fetch from timetableadjustmentperiodwise and staff_information tables.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				bool flag=false;
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string Path = home_drive+@"\eSchool_ExcelFile\TimeTableAdjustmentPeriodWise_Report.xls";
				StreamWriter sw=new StreamWriter(Path);
				//string Path=home_drive+ @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustmentPeriodWise_Report1.txt";
				SqlCommand cmd;
				SqlConnection con;
				SqlDataReader dtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();
				
				string des="+----------------------+----+---------------------+     +----------------------+----+---------------------+";
				string des1="---------------------------------------------------     ---------------------------------------------------";
				//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SUBSTITUTION CHART "+Dropday.SelectedItem.Value+", "+Txtdate.Text,des.Length));
				//sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				sw.WriteLine("NAME\tCLAS\tSIGN(FULL NAME)\t\tNAME\tCLAS\tSIGN(FULL NAME)");
				//sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				int i=0;
				string info1=" {0,-21:S} {1,4:S} ";
				string info2=" {0,-21:S} {1,4:S}                           ";
				string str="select st.Staff_Name,tt.Period,tt.Teacher_Id,tt.Class,tt.Sections from timetableadjustmentperiodwise tt,staff_information st where st.staff_id=tt.Teacher_Id and Todate='"+GenUtil.str2MMDDYYYY(Txtdate.Text)+"' and days='"+Dropday.SelectedItem.Value+"'";
				cmd=new SqlCommand(str,con);
				dtr=cmd.ExecuteReader();
				while(dtr.Read())
				{
					if(Convert.ToInt16(dtr["period"])==1)
					{ 			
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("I PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					}
					else if(Convert.ToInt16(dtr["period"])==2)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("II PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==3)
					{ 				   
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("III PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					}
					else if(Convert.ToInt16(dtr["period"])==4)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("IV PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
				    
					else if(Convert.ToInt16(dtr["period"])==5)
					{ 				   
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("V PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					}
					
					else if(Convert.ToInt16(dtr["period"])==6)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("VI PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21),"|"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+" |");
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==7)
					{ 				   
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("VII PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					   
					}
					else if(Convert.ToInt16(dtr["period"])==8)
					{ 				   
						if(flag==true)
						{
							sw.WriteLine("");
							sw.WriteLine(des1);
							sw.WriteLine(GenUtil.GetCenterAddr("VIII PERIOD",des.Length));
							sw.WriteLine(des);
							flag=false;
						}
						if(i%2==0)
						{
							sw.Write(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3)+"\t\t\t");
						}
						else if(i%2==1)
						{
							//sw.WriteLine("\t\t\t"+GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(GenUtil.TrimLength(dtr["Staff_Name"].ToString().Trim(),21)+"\t"+GenUtil.TrimLength(dtr["Class"].ToString(),3));
							sw.WriteLine(des1);
						}
					   
					}
					
					i++;
				}
				sw.Close();
				//Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + ex.Message + " User: " + pass );
			}

		}
	}
}
