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
using System.Data .SqlClient ;
using RMG;
using eschool.Classes;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
# endregion

namespace eschool.Pta
{
	/// <summary>
	/// Summary description for meetingrpt.
	/// </summary>
	public class meetingrpt1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgrdcomp;
		protected System.Web.UI.WebControls.TextBox txtdt;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDate;
		protected System.Web.UI.WebControls.Button ButtonPrint;
		protected System.Web.UI.WebControls.TextBox txtToDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel pangrid;
	    string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
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
				CreateLogFiles.ErrorLog (" Form: meetingrpt.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					txtdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtToDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="21";
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
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.ButtonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// DateTime Function for return the date in MM/DD/YYYY format.
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}

		/// <summary>
		/// this method use to View the Report on the datagrid data fetch from ptameetingagenda.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			DateTime dt=System.DateTime.Now;
			try
			{
				DateTime dToday=Convert.ToDateTime(ToMMddYYYY(txtdt.Text));
				System.TimeSpan diff=dToday.Subtract(dt);
				int iDays=diff.Days;
 				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="Select *  From ptameetingagenda where meetingdt >=@meetingdt and meetingdt <=@meetingtodate";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				cmdInsert1.Parameters .Add("@meetingdt",GenUtil.str2MMDDYYYY(txtdt.Text)); 
				cmdInsert1.Parameters .Add("@meetingtodate",GenUtil.str2MMDDYYYY(txtToDate.Text)); 
				dgrdcomp.DataSource =cmdInsert1.ExecuteReader();
				dgrdcomp.DataBind ();
					if(dgrdcomp.Items.Count==0)
					{
						MessageBox.Show("No such record found");
						dgrdcomp.Visible=false;
						pangrid.Visible=false;
					}
					else
					{
						dgrdcomp.Visible=true;
						pangrid.Visible	=true;
					}
					con1.Close();   
			
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  Search_ServerClick, PTA Meeting Report viewed for date:"+txtdt.Text.Trim().ToString ()+", Userid :  "+ pass   );		
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				
			} 	
		}

		/// <summary>
		/// this method use to create excel report.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			/*try
			{
				Response .Redirect("../PrintPreview/MeetingrptPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["password"].ToString()   );		
				
			} */

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
        /// This method use to create report in to excel format. and svae in to eschool_excelfile folder which is exist in home drive.
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
				string path = home_drive+@"\eSchool_ExcelFile\PTAMeetingReport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PTAMeetingReport.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="Select *  From ptameetingagenda where meetingdt >=@meetingdt and meetingdt <=@meetingtodate";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				cmdInsert1.Parameters .Add("@meetingdt",ToMMddYYYY(txtdt.Text.Trim().ToString ()).ToShortDateString() ); 
				cmdInsert1.Parameters .Add("@meetingtodate",ToMMddYYYY(txtToDate.Text.Trim().ToString ()).ToShortDateString() ); 
				SqlDataReader rdr= cmdInsert1.ExecuteReader();
				sw.WriteLine("                                 =======================");
				sw.WriteLine("                                   PTA Meeting Report");
				sw.WriteLine("                                 =======================");
				sw.WriteLine("");
				sw.WriteLine("");
				sw.WriteLine("");			
				//sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				sw.WriteLine("Date\tAgendaClass\tDiscussion1\tDiscussion2\tDiscussion3\tDiscussion4\tDiscussion5\tDiscussion6");
				//sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				if(rdr.HasRows)
				{
					info = " {0,-15:S} {1,-16:S}{2,-16:S}{3,-16:S}{4,-16:S}{5,-16:S}{6,-16:S}{7,-16:S}";
					while(rdr.Read())
					{		 
						sw.WriteLine(info,trimDate(	rdr["meetingdt"].ToString())+"\t"+
							rdr["agenda"].ToString().Trim()+"\t"+
							rdr["min1"].ToString().Trim()+"\t"+
							rdr["min2"].ToString().Trim()+"\t"+
							rdr["min3"].ToString().Trim()+"\t"+
							rdr["min4"].ToString().Trim()+"\t"+
							rdr["min5"].ToString().Trim()+"\t"+
							rdr["min6"].ToString().Trim());
					}
			
					rdr.Close();
				}
				sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				sw.Close(); 
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method get date with time but it return with out time.
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
		/// Method for writing the report in text file and save the text file into the eschoolprintservices.
		/// </summary>
		public void MakingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PTAMeetingReport.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="Select *  From ptameetingagenda where meetingdt >=@meetingdt and meetingdt <=@meetingtodate";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				cmdInsert1.Parameters .Add("@meetingdt",ToMMddYYYY(txtdt.Text.Trim().ToString ()).ToShortDateString() ); 
				cmdInsert1.Parameters .Add("@meetingtodate",ToMMddYYYY(txtToDate.Text.Trim().ToString ()).ToShortDateString() ); 
				SqlDataReader rdr= cmdInsert1.ExecuteReader();
				sw.WriteLine("                                 =======================");
				sw.WriteLine("                                   PTA Meeting Report");
				sw.WriteLine("                                 =======================");
				sw.WriteLine("");
				sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				sw.WriteLine("|Date           |AgendaClass    |Discussion1    |Discussion2    | Discussion3   |Discussion4    | Discussion5   |Discussion6     ");
				sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				if(rdr.HasRows)
				{
					info = " {0,-15:S} {1,-16:S}{2,-16:S}{3,-16:S}{4,-16:S}{5,-16:S}{6,-16:S}{7,-16:S}";
					while(rdr.Read())
					{		 
						sw.WriteLine(info,trimDate(	rdr["meetingdt"].ToString()),
							rdr["agenda"].ToString().Trim(),
							rdr["min1"].ToString().Trim(),
							rdr["min2"].ToString().Trim(),
							rdr["min3"].ToString().Trim(),
							rdr["min4"].ToString().Trim(),
							rdr["min5"].ToString().Trim(),
							rdr["min6"].ToString().Trim());
					}
			
					rdr.Close();
				}
				sw.WriteLine("+---------------+---------------+---------------+---------------+---------------+---------------+---------------+---------------+");
				sw.Close(); 
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method use to create connection between remot device.
		/// </summary>
		private void ButtonPrint_Click(object sender, System.EventArgs e)
		{
 			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
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
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PTAMeetingReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
                    CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  ButtonPrint_Click,  PTA Meeting  Report Printed, Userid :  "+ pass   );								 							 
			     } 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  ButtonPrint_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  ButtonPrint_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  ButtonPrint_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :meetingrpt.aspx,Method  ButtonPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
	}
}
