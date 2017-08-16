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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using eschool.Classes;

 
# endregion

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for Staffleaverpt.
	/// </summary>
	public class Staffleaverpt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropempid;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid Datastaffleave;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		protected System.Web.UI.WebControls.ValidationSummary vsamary1;
		protected System.Web.UI.HtmlControls.HtmlButton Btnexcel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel pandata;
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
				CreateLogFiles.ErrorLog ("Form: Staffleaverpt.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				
				if(!Page.IsPostBack)
				{
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					//cmdselect = new SqlCommand( "Select staff_id  From Staff_leave where adjustment='1'", con );
					cmdselect = new SqlCommand( "Select distinct staff_id  From Staff_leave where adjustment='1'", con );
					dtrclass= cmdselect.ExecuteReader();
					while(dtrclass.Read())
					{
						Dropempid.Items.Add(dtrclass.GetValue(0).ToString());
					}
					 
					dtrclass.Close();
					con.Close ();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="27";
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
				CreateLogFiles.ErrorLog(" Form : Staffleaverpt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.Dropempid.SelectedIndexChanged += new System.EventHandler(this.Dropempid_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Btnexcel.ServerClick += new System.EventHandler(this.Btnexcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Method for adding the staff name to the textbox as per the selection of the staff_id.
		/// </summary>
		private void Dropempid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*InventoryClass obj=new InventoryClass();
			SqlDataReader rdr;
			string str="";
			try
			{
				if(Dropempid.SelectedIndex!=0)
				{
					if(Dropempid.SelectedValue=="All")
					{
						str = "Select staff_name  From staff_information ";
					}
					else
					{
						str = "Select staff_name  From staff_information where Staff_id='"+Dropempid.SelectedItem.Text+"'";
					}
				}
				rdr = obj.GetRecordSet(str);
				if(rdr.Read()) 
				{
					//txtempnm.Text =rdr.GetValue(0).ToString();
				}
				rdr.Close();
				Datastaffleave.Visible=false;
				pandata.Visible=false;
					
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Staffleaverpt.aspx,Method  Dropempid_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}*/
		}
		/// <summary>
		/// Method for viewing the report on the datagrid.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				//********************Date 18.02.09*****************************
				/*if(Dropempid.SelectedIndex==0)                
				{
					MessageBox.Show("Please Select Teacher Id ");
					Datastaffleave.Visible=false;
				}
				else 
				{*/
				//*********************End**************************************

				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str = "";
				if (Dropempid.SelectedItem.Text.Equals ("All"))
				{
					//18.02.09 str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and adjustment=1";
					str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and Adjustment=1 order by Staff_Name";
				}	
				else
				{
					str ="Select sr.staff_name,s.staff_id,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type  From Staff_leave s,staff_information sr where sr.Staff_id=s.staff_id and adjustment='1' and sr.staff_id='"+Dropempid .SelectedItem .Text +"'";
				}
				SqlDtr=obj.GetRecordSet(str);
				Datastaffleave.DataSource =SqlDtr;
				Datastaffleave.DataBind ();
				CreateLogFiles.ErrorLog(" Form : Staffleaverpt.aspx,Method  Serch_ServerClick,  Staff Leave Report Viewed for StaffID"+ Dropempid.SelectedItem.Text.ToString() +" , Userid :  "+ pass   );							
				if(Datastaffleave.Items.Count==0)
				{
					MessageBox.Show("No such record found");
					Datastaffleave.Visible=false;
					pandata.Visible=false;
				}
				else
				{
					Datastaffleave.Visible=true;
					pandata.Visible=true;
				}
				//}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Staffleaverpt.aspx,Method  Serch_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for writing the report into the text file and save it into the eschoolprintservices forlder.
		/// </summary>
		public void MakingReport()
		{
			try
			{
				
				string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StaffLeaveReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string info = "";
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str = "";
				if (Dropempid.SelectedItem.Text.Equals ("All"))
				{
					//18.02.09 str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and adjustment=1";
					str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and Adjustment=1 order by Staff_Name";
				}	
				else
				{
					str ="Select sr.staff_name,s.staff_id,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type  From Staff_leave s,staff_information sr where sr.Staff_id=s.staff_id and adjustment='1' and sr.staff_id='"+Dropempid .SelectedItem .Text +"'";
				}
				
				sw.WriteLine();
				rdr=obj.GetRecordSet(str);
				sw.WriteLine("				----------------------");
				sw.WriteLine("				  Staff Leave  Report ");
				sw.WriteLine("				----------------------");
				sw.WriteLine("");
				sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				sw.WriteLine("|Staff ID|         Name                 |Leave Type| Leave From    | Leave TO  |");
				sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				//               12345678 123456789012345678901234567890 1234567890 123456789012345 12345678901234
				if(rdr.HasRows)
				{
					info = " {0,-8:S} {1,-30:S} {2,-10:S}  {3,-16:S}{4,-14:S} ";
					while(rdr.Read())
					{
						sw.WriteLine(info,rdr["Staff_ID"].ToString().Trim(),
							GenUtil.TrimLength(rdr["Staff_Name"].ToString(),30),
							rdr["Leave_Type"].ToString().Trim(),
							trimDate(GenUtil.str2DDMMYYYY(rdr["Staff_leavefromdt"].ToString().Trim())),
							trimDate(GenUtil.str2DDMMYYYY(rdr["Staff_leavefromto"].ToString().Trim())));
					}
					rdr.Close();
				}
				sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				sw.Close(); 
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
		/// Method for sending the text file to the printer and issueing the print command to the printer for print the textfile.
		/// </summary>
		private void Button1_ServerClick(object sender, System.EventArgs e)
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
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StaffLeaveReport.txt<EOF>");
					///byte[] msg = Encoding.ASCII.GetBytes("StaffLeaveReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  Button1_ServerClick, Staff Leave Report Printed, Userid :  "+ pass   );		              
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  Button1_ServerClick,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  Button1_ServerClick,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  Button1_ServerClick,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
     
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel()function.
		/// </summary>
		private void Btnexcel_ServerClick(object sender, System.EventArgs e)
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
		/// this method use to generate a Report in to Excel format data fetch from staff_leave and staff_information table. 
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{

				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);

				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\StaffLeaveReport1.xls";


				//string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StaffLeaveReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string info = "";
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str = "";
				if (Dropempid.SelectedItem.Text.Equals ("All"))
				{
					//18.02.09 str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and adjustment=1";
					str = "Select s. Staff_ID,sr.Staff_Name,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type From Staff_leave s, staff_information sr where s.Staff_ID=sr.Staff_ID and Adjustment=1 order by Staff_Name";
				}	
				else
				{
					str ="Select sr.staff_name,s.staff_id,s.Staff_leavefromdt,s.Staff_leavefromto,s.Leave_Type  From Staff_leave s,staff_information sr where sr.Staff_id=s.staff_id and adjustment='1' and sr.staff_id='"+Dropempid .SelectedItem .Text +"'";
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
				rdr=obj.GetRecordSet(str);
				sw.WriteLine("				----------------------");
				sw.WriteLine("				  Staff Leave  Report ");
				sw.WriteLine("				----------------------");
				sw.WriteLine("");
				//sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				sw.WriteLine("Staff ID\tName\tLeave Type\tLeave From\tLeave TO");
				//sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				//               12345678 123456789012345678901234567890 1234567890 123456789012345 12345678901234
				if(rdr.HasRows)
				{
					info = " {0,-8:S} {1,-30:S} {2,-10:S}  {3,-16:S}{4,-14:S} ";
					while(rdr.Read())
					{
						sw.WriteLine(rdr["Staff_ID"].ToString().Trim()+"\t"+
							GenUtil.TrimLength(rdr["Staff_Name"].ToString(),30)+"\t"+
							rdr["Leave_Type"].ToString().Trim()+"\t"+
							trimDate(GenUtil.str2DDMMYYYY(rdr["Staff_leavefromdt"].ToString().Trim()))+"\t"+
							trimDate(GenUtil.str2DDMMYYYY(rdr["Staff_leavefromto"].ToString().Trim())));
					}
					rdr.Close();
				}
				//sw.WriteLine("+--------+------------------------------+----------+---------------+-----------+");
				sw.Close(); 
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Staffleaverpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

	}

}

