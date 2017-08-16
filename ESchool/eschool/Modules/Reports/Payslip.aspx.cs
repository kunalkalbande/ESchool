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


namespace eschool.Reports
{
	/// <summary>
	/// Summary description for Payslip.
	/// </summary>
	public class Payslip : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Datapayslip;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CompareValidator cvEmpID;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.DropDownList dropEmpName;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.ValidationSummary vsPaySlip;
		protected System.Web.UI.WebControls.Button Btnexcel;
		string uid="";
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
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: payslip.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
    			
				if(!Page.IsPostBack)
				{
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrall;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					//cmdselect = new SqlCommand( "Select Staff_Name  From Staff_Information order by Staff_Name", con );    03.10.08
					cmdselect = new SqlCommand( "Select Staff_Name,staff_id  From Staff_Information order by Staff_Name", con ); 
					dtrall = cmdselect.ExecuteReader();
					while(dtrall.Read())
					{
						//dropEmpName.Items.Add(dtrall.GetValue(0).ToString());						03.10.08
						dropEmpName.Items.Add(dtrall.GetValue(0).ToString()+":"+dtrall.GetValue(1).ToString());
					}
					dtrall.Close();
					con.Close ();
				} 
			}

			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Payslip.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
			}	

			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="24";
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
			this.dropEmpName.SelectedIndexChanged += new System.EventHandler(this.Dropempid_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Add employee name to the textbox after selecting id from dropdowmbox.
		/// this method not in use.
		/// </summary>
		private void Dropempid_SelectedIndexChanged(object sender, System.EventArgs e)
		{ 
			/*panal1.Visible=false;
			SqlConnection con4;
			SqlCommand cmdselect4;
			SqlDataReader dtrall1;
			con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con4.Open ();
			cmdselect4 = new SqlCommand( "Select Staff_ID From Staff_Information where Staff_Name=@Staff_Name", con4 );
			cmdselect4.Parameters .Add ("@Staff_Name",dropEmpName.SelectedItem.Text.ToString().Trim());
			dtrall1 = cmdselect4.ExecuteReader();
			while (dtrall1.Read()) 
			{
    			txtEmpID.Text =dtrall1.GetValue(0).ToString();
				 		 
			}
			dtrall1.Close();
			con4.Close ();
			if(dropEmpName.SelectedItem.Text.ToString()=="All")
			{
				labl1.Visible=false;
				txtEmpID.Visible=false;
			}
			else
			{
				labl1.Visible=true;
				txtEmpID.Visible=true;
			}*/
			
		}

		/// <summary>
		/// DateTime Function for returning the date into MM/DD/YYYY format.
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
		/// Method for viwed the report on the datagrid. data fetch from  Staff_Information and Allowancesdeduction tables.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
					SqlConnection con3;
					SqlCommand cmdInsert1;
					string strInsert1;
					con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con3.Open ();
					string empid=dropEmpName.SelectedValue;
					string[] empid1=empid.Split(new char[]{':'});
        			if(dropEmpName.SelectedIndex==0)
		      		{
			    		strInsert1 ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID";
				    	cmdInsert1=new SqlCommand (strInsert1,con3);
				    }
				    else
				    {
					    strInsert1 ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and si.Staff_ID=@Staff_ID and  si.Staff_Name=@Staff_Name";
					    cmdInsert1=new SqlCommand (strInsert1,con3);
						//cmdInsert1.Parameters .Add("@Staff_Name",dropEmpName.SelectedItem .Text .ToString () ); 
						//cmdInsert1.Parameters .Add("@Staff_ID",txtEmpID.Text.Trim()); 
						cmdInsert1.Parameters .Add("@Staff_Name",empid1[0] ); 
						cmdInsert1.Parameters .Add("@Staff_ID",empid1[1]); 
					}
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
			 }
	 		catch(Exception ex)
	         {
		            CreateLogFiles.ErrorLog(" Form : Payslip.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Payslip.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_ServerClick,  Employee Payslip information  Printed , Userid :  "+ pass   );							 
			     } 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_ServerClick,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_ServerClick,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_ServerClick,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for viwed the report in text format. data fetch from  Staff_Information and Allowancesdeduction tables.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			string empid=dropEmpName.SelectedValue;
			string[] empid1=empid.Split(new char[]{':'});
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Payslip.txt";
			StreamWriter sw = new StreamWriter(path); 
			try
			{
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "";
				conNorthwind.Open();
				
				if(dropEmpName.SelectedIndex==0)
				{
					strSelect ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID";
					cmdSelect=new SqlCommand (strSelect,conNorthwind);
				}
				else
				{
					strSelect ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and si.Staff_ID=@Staff_ID and  si.Staff_Name=@Staff_Name";
					cmdSelect=new SqlCommand (strSelect,conNorthwind);
					//cmdSelect.Parameters .Add("@Staff_Name",dropEmpName.SelectedItem .Text .ToString () ); 
					//cmdSelect.Parameters .Add("@Staff_ID",txtEmpID.Text.Trim()); 
					cmdSelect.Parameters .Add("@Staff_Name",empid1[0] ); 
					cmdSelect.Parameters .Add("@Staff_ID",empid1[1]); 
				}
				SqlDtr = cmdSelect.ExecuteReader();
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
				sw.WriteLine("                                        -----------------");
				sw.WriteLine("                                         Pay Slip Report") ;
				sw.WriteLine("                                        -----------------");
				sw.WriteLine(" ");
				string info1="";
				info1 = " {0,-15:S} {1,1:S} {2,-50:S}";
				sw.WriteLine(info1,"Employee Name",":",dropEmpName.SelectedItem.Text);
				//sw.WriteLine(info1,"Employee ID",":",txtEmpID.Text);
				sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
				sw.WriteLine("|StaffID|Designation    |Staff Name               | BSalary |Total Allow| GTotal |TDeduction| Net Salary|");
				sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
				//            12345678 123456789012345 1234567890123456789012345 123456789 12345678901 12345678 1234567890 12345678901 
				info = " {0,-8:S}{1,-15:S} {2,-25:S} {3,9:S} {4,11:S} {5,8:S} {6,10:S} {7,11:S}";
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{	
						sw.WriteLine (info,
							SqlDtr["Staff_ID"].ToString(),
							GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),15),
							GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),20),
							GenUtil.TrimLength(SqlDtr["Basic_salary"].ToString(),9),
							GenUtil.TrimLength(SqlDtr["allowances_total"].ToString(),11),
							GenUtil.TrimLength(SqlDtr["G_total"].ToString(),8),
							GenUtil.TrimLength(SqlDtr["Deduction_total"].ToString(),10),
							GenUtil.TrimLength(SqlDtr["Net_Sal"].ToString(),8)
							
							);
					}
				}
				SqlDtr.Close();
				sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
                sw.Close();
 				Print();
				CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_Click, Employee Payslip Information View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
 		/// Method for viwed the report in excel format. data fetch from  Staff_Information and Allowancesdeduction tables.
		/// </summary>
		public void ConvertIntoExcel()
		{
			string empid=dropEmpName.SelectedValue;
			string[] empid1=empid.Split(new char[]{':'});
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";

			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\Payslip.xls";
			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Payslip.txt";
			StreamWriter sw = new StreamWriter(path); 
			try
			{
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "";
				conNorthwind.Open();
				
				if(dropEmpName.SelectedIndex==0)
				{
					strSelect ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID";
					cmdSelect=new SqlCommand (strSelect,conNorthwind);
				}
				else
				{
					strSelect ="Select si.Staff_ID, si.Staff_Name, Allow.Basic_salary,Allow.allowances_total,Allow.G_total,Allow.Deduction_total,Allow.Net_Sal,Allow.fromdt,Allow.todt,si.Staff_Type  From Staff_Information si ,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and si.Staff_ID=@Staff_ID and  si.Staff_Name=@Staff_Name";
					cmdSelect=new SqlCommand (strSelect,conNorthwind);
					//cmdSelect.Parameters .Add("@Staff_Name",dropEmpName.SelectedItem .Text .ToString () ); 
					//cmdSelect.Parameters .Add("@Staff_ID",txtEmpID.Text.Trim()); 
					cmdSelect.Parameters .Add("@Staff_Name",empid1[0] ); 
					cmdSelect.Parameters .Add("@Staff_ID",empid1[1]); 
				}
				SqlDtr = cmdSelect.ExecuteReader();
				
				sw.WriteLine();
				sw.WriteLine("                                        -----------------");
				sw.WriteLine("                                         Pay Slip Report") ;
				sw.WriteLine("                                        -----------------");
				sw.WriteLine(" ");
				string info1="";
				info1 = " {0,-15:S} {1,1:S} {2,-50:S}";
				sw.WriteLine(info1,"Employee Name",":",dropEmpName.SelectedItem.Text);
				//sw.WriteLine(info1,"Employee ID",":",txtEmpID.Text);
				//sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
				sw.WriteLine("StaffID\tDesignation\tStaff Name\tBSalary\tTotal Allow\tGTotal\tTDeduction\tNet Salary");
				//sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
				//            12345678 123456789012345 1234567890123456789012345 123456789 12345678901 12345678 1234567890 12345678901 
				info = " {0,-8:S}{1,-15:S} {2,-25:S} {3,9:S} {4,11:S} {5,8:S} {6,10:S} {7,11:S}";
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{	
						sw.WriteLine
							(
							SqlDtr["Staff_ID"].ToString()+"\t"+
							GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),15)+"\t"+
							GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),20)+"\t"+
							GenUtil.TrimLength(SqlDtr["Basic_salary"].ToString(),9)+"\t"+
							GenUtil.TrimLength(SqlDtr["allowances_total"].ToString(),11)+"\t"+
							GenUtil.TrimLength(SqlDtr["G_total"].ToString(),8)+"\t"+
							GenUtil.TrimLength(SqlDtr["Deduction_total"].ToString(),10)+"\t"+
							GenUtil.TrimLength(SqlDtr["Net_Sal"].ToString(),8)
							);
					}
				}
				SqlDtr.Close();
				//sw.WriteLine("+-------+---------------+-------------------------+---------+-----------+--------+----------+-----------+");
				sw.Close();
				//Print();
				CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_Click, Employee Payslip Information View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Payslip.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
	}
}

