
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
using System.Data .SqlClient ;
using RMG;
using eschool.Classes;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for salarysheet.
	/// </summary>
	public class salarysheet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtfromdt;
		protected System.Web.UI.WebControls.TextBox txttodt;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator ReqCompanyName;
		protected System.Web.UI.WebControls.ValidationSummary vsSalarySheet;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button BtnExcel;
		protected System.Web.UI.WebControls.DataGrid Datapayslip;
		protected System.Web.UI.WebControls.Panel panal1;
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
				CreateLogFiles.ErrorLog ("Form: salarysheet.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}	
			try
			{
				
				if(!IsPostBack)
				{
                    txtfromdt.Attributes.Add("readonly", "readonly");
                    txttodt.Attributes.Add("readonly", "readonly");

                    txtfromdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txttodt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="25";
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
				CreateLogFiles.ErrorLog(" Form : salarysheet.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// DateTime Function for returning the date in MM/DD/YYYY
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
		/// this Method use to show the report on the Datagrid.data fetch from Staff_Information and Allowancesdeduction tables. 
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				if(DateTime.Compare(ToMMddYYYY(txttodt.Text),ToMMddYYYY(txtfromdt.Text))>0)
				{
					SqlConnection con3;
					SqlCommand cmdInsert1;
					string strInsert1;
					con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con3.Open ();
					strInsert1 ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.allowances_benefits,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt From Staff_Information si,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and Allow.fromdt=@fromdt and Allow.todt=@todt";
					cmdInsert1=new SqlCommand (strInsert1,con3);
					cmdInsert1.Parameters .Add("@fromdt",GenUtil.str2MMDDYYYY(txtfromdt.Text.Trim().ToUpper())); 
					cmdInsert1.Parameters .Add("@todt",GenUtil.str2MMDDYYYY(txttodt.Text.Trim().ToUpper())); 
    				Datapayslip.DataSource =cmdInsert1.ExecuteReader();
					Datapayslip.DataBind ();
					if(Datapayslip.Items.Count==0)
					{
						MessageBox.Show("Record Not Found");
						panal1.Visible=false;
						return;
					}
					else
					{
						panal1.Visible=true;
					}
					CreateLogFiles.ErrorLog(" Form : salarysheet.aspx,Method : Search_ServerClick,  Salary Sheet Report Viewed , Userid :  "+ pass   );		
				}
				else
				{
					MessageBox.Show("To date must be greater than from date");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : salarysheet.aspx,Method : Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}
		
		/// <summary>
		/// this Method use to show the report on the txt.data fetch from Staff_Information and Allowancesdeduction tables. 
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				string info="",des="";
				string path=home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SalarySheet_Report1.Txt";
				StreamWriter sw=new StreamWriter(path);
				SqlConnection con3;
				SqlCommand cmdInsert1;
				SqlDataReader sdtr=null;
				string strInsert1;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				des="+-----+-------------------------+--------+-----------+-----------";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Salary Sheet Report",des.Length));
				sw.WriteLine("+--------+-------------------------+--------+-----------+-----------+");
				sw.WriteLine("|STAFF_ID|      STAFF NAME         | SALARY | FROM DATE |  TO DATE  |");
				sw.WriteLine("+--------+-------------------------+--------+-----------+-----------+");
				//             12345678 1234567890123456789012345 12345678 12345678901 12345678901
				info=" {0,8:S} {1,-25:S} {2,8:S} {3,11:S} {4,11:S} ";
				strInsert1 ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.allowances_benefits,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt From Staff_Information si,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and Allow.fromdt=@fromdt and Allow.todt=@todt";
				cmdInsert1=new SqlCommand (strInsert1,con3);
				cmdInsert1.Parameters .Add("@fromdt",GenUtil.str2MMDDYYYY(txtfromdt.Text.Trim().ToUpper())); 
				cmdInsert1.Parameters .Add("@todt",GenUtil.str2MMDDYYYY(txttodt.Text.Trim().ToUpper())); 
				sdtr=cmdInsert1.ExecuteReader();
				while(sdtr.Read())
				{
					sw.WriteLine(info,sdtr.GetValue(0).ToString(),
					GenUtil.TrimLength(sdtr.GetValue(1).ToString(),25),
					sdtr.GetValue(2).ToString(),
					GenUtil.trimDate(sdtr.GetValue(13).ToString()),
					GenUtil.trimDate(sdtr.GetValue(14).ToString()));
				}
				sdtr.Close();
				sw.Close();
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : salarysheet.aspx,Method : btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This method use to create connection between remot device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SalarySheet_Report.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method :  Print(),  BankReport Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void BtnExcel_Click(object sender, System.EventArgs e)
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
		/// this Method use to show the report on the excel format.data fetch from Staff_Information and Allowancesdeduction tables. 
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				string info="",des="";
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\SalarySheet_Report1.xls";
				
				//string path=home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SalarySheet_Report.Txt";
				StreamWriter sw=new StreamWriter(path);
				SqlConnection con3;
				SqlCommand cmdInsert1;
				SqlDataReader sdtr=null;
				string strInsert1;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				des="+-----+-------------------------+--------+-----------+-----------";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Salary Sheet Report",des.Length));
				//sw.WriteLine("+--------+-------------------------+--------+-----------+-----------+");
				sw.WriteLine("STAFF_ID\tSTAFF NAME\tSALARY\tFROM DATE\tTO DATE");
				//sw.WriteLine("+--------+-------------------------+--------+-----------+-----------+");
				//             12345678 1234567890123456789012345 12345678 12345678901 12345678901
				//info=" {0,8:S} {1,-25:S} {2,8:S} {3,11:S} {4,11:S} ";
				strInsert1 ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.allowances_benefits,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt From Staff_Information si,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and Allow.fromdt=@fromdt and Allow.todt=@todt";
				cmdInsert1=new SqlCommand (strInsert1,con3);
				cmdInsert1.Parameters .Add("@fromdt",GenUtil.str2MMDDYYYY(txtfromdt.Text.Trim().ToUpper())); 
				cmdInsert1.Parameters .Add("@todt",GenUtil.str2MMDDYYYY(txttodt.Text.Trim().ToUpper())); 
				sdtr=cmdInsert1.ExecuteReader();
			
				while(sdtr.Read())
				{
					sw.WriteLine(sdtr.GetValue(0).ToString()+"\t"+
						sdtr.GetValue(1).ToString()+"\t"+
						sdtr.GetValue(2).ToString()+"\t"+
						sdtr.GetValue(13).ToString()+"\t"+
						sdtr.GetValue(14).ToString());
				}
				sdtr.Close();
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Salary Sheet Report.aspx , Method : btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
