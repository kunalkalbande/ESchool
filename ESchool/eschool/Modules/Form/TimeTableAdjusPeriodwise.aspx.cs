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
using System.IO ;
using System.Text;
using System.Net ;
using System.Net.Sockets;

namespace eschool.Modules.Form
{
	/// <summary>
	/// Summary description for TimeTaleAdjusPeriodwise.
	/// </summary>
	public class TimeTaleAdjusPeriodwise : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TxtTodyDate;
		protected System.Web.UI.WebControls.Button BttonPrint;
		protected System.Web.UI.WebControls.Button BttonSave;
		protected System.Web.UI.WebControls.DropDownList Dropday;
		protected System.Web.UI.HtmlControls.HtmlInputText Txtstaffid;
		protected System.Web.UI.WebControls.CompareValidator Compare1;
		protected System.Web.UI.HtmlControls.HtmlInputText Txtstaffid1;
		protected System.Web.UI.WebControls.ValidationSummary Summary1; 
		public int flage=0;
		string pass;
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            TxtTodyDate.Attributes.Add("readonly", "readonly");
            try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Time_TableAdjustmentperiod.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Time_Tableadjustmentperiod.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass="";
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{
					TxtTodyDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
                	#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="5";
					string SubModule="3";
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
						//10.05.08--Response.Redirect("../AccessDeny.aspx");
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					if(Add_Flag=="False")
					{
						//10.05.08--btnSave.Enabled=false;
					}
					#endregion
				}
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Page_Load  User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Dropday.SelectedIndexChanged += new System.EventHandler(this.Dropday_SelectedIndexChanged);
			this.BttonSave.Click += new System.EventHandler(this.BttonSave_Click);
			this.BttonPrint.Click += new System.EventHandler(this.BttonPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method use to save data from teachertimatable,staff_information and staff_attendance into two hidden textbox. 
		/// </summary>
		private void Dropday_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
			  if(Dropday.SelectedIndex !=0 )
				{
					Txtstaffid.Value="";
					Txtstaffid1.Value="";
					SqlConnection con;
					SqlCommand cmd;
					SqlDataReader dr;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open();
					string day=Dropday.SelectedItem.Text.Substring(0,3);
					for(int i=1;i<=8;i++)
					{
						string str="select t.shortname,s.staff_type,t.employee_id,sa.Half_day,t."+day+i+" from teachertimetable t,staff_information s,staff_attandance sa where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Half_Day!=0 and st.Attendance_Date='"+GenUtil.str2MMDDYYYY (TxtTodyDate.Text.Trim())+"') and sa.Attendance_Date='"+GenUtil.str2MMDDYYYY (TxtTodyDate.Text.Trim())+"') and sa.Attendance_Date='"+GenUtil.str2MMDDYYYY (TxtTodyDate.Text.Trim())+"' and t."+day+i+"='' and sa.staff_id=s.staff_id  order by t.tpd";
						cmd=new SqlCommand(str,con);
						dr=cmd.ExecuteReader();
						while(dr.Read())
						{
							Txtstaffid.Value+=dr.GetValue(0).ToString().Trim()+":"+dr.GetValue(1).ToString().Trim()+":"+dr.GetValue(2)+":"+dr.GetValue(3).ToString().Trim()+":"+i+",";
						}
						dr.Close();
						cmd.Dispose();
					}
					for(int j=1;j<=8;j++)
					{
    					string str="select "+day+j+" from teachertimetable  where employee_id in (select staff_id from  staff_attandance st where st.Attandance_Status='0' and st.Half_Day=0 and st.Attendance_Date='"+GenUtil.str2MMDDYYYY (TxtTodyDate.Text.Trim())+"')";
						cmd=new SqlCommand(str,con);
						dr=cmd.ExecuteReader();
						while(dr.Read())
						{
	    					if(dr.GetValue(0).ToString().Trim()!="" && dr.GetValue(0).ToString().Trim()!=null)
							{
								Txtstaffid1.Value+=dr.GetValue(0).ToString().Trim()+":"+j+",";
							}
						}
						dr.Close();
					}
					flage=1;
				}
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Dropday_SelectedIndexChanged  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Dropday_SelectedIndexChanged  Exception: " + ex.Message + " User: " + pass );
				return;
			}
		}

		/// <summary>
		/// This method use to make text file. this text show all the information off time table adjustment.
		/// </summary>
		private void BttonPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				bool flag=false;
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
				sw.WriteLine(GenUtil.GetCenterAddr("SUBSTITUTION CHART "+Dropday.SelectedItem.Value+", "+TxtTodyDate.Text,des.Length));
				sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				sw.WriteLine("|          NAME        |CLAS|   SIGN(FULL NAME)   |     |          NAME        |CLAS|   SIGN(FULL NAME)   |");
				sw.WriteLine("+----------------------+----+---------------------+     +----------------------+----+---------------------+");
				int i=0;
				string info1=" {0,-21:S} {1,4:S} ";
				string info2=" {0,-21:S} {1,4:S}                           ";
				string str="select st.Staff_Name,tt.Period,tt.Teacher_Id,tt.Class,tt.Sections from timetableadjustmentperiodwise tt,staff_information st where st.staff_id=tt.Teacher_Id and Todate='"+GenUtil.str2MMDDYYYY(TxtTodyDate.Text)+"' and days='"+Dropday.SelectedItem.Value+"'";
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
					   if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("III PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
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
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("V PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
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
						if(flag==false)
						{
							sw.WriteLine("");
							sw.WriteLine(GenUtil.GetCenterAddr("VII PERIOD",des.Length));
							sw.WriteLine(des);
							flag=true;
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
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWiseReport.aspx.cs, Method: Button_Print. Exception: " + ex.Message + " User: " + pass );
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
					CreateLogFiles.ErrorLog(" Form :AdvanceFeeReport.aspx,Method :  Print(),  DailyFeeReport Printed , Userid :  "+ pass   );							 
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Button_Print. Exception: " + ane.Message + " User: " + pass );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Button_Print. Exception: " + se.Message + " User: " + pass );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Button_Print. Exception: " + es.Message + " User: " + pass );
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentPeriodWise.aspx.cs, Method: Button_Print. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void BttonSave_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
