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

namespace eschool.certificate
{
	/// <summary>
	/// Summary description for Tcrpt.
	/// </summary>
	public class Tcrpt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgrdsuspend;
		protected System.Web.UI.WebControls.Button btnPrintD;
		protected System.Web.UI.WebControls.TextBox TxtFromdt;
		protected System.Web.UI.WebControls.TextBox TxtTodt;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		public int i=1;
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
				CreateLogFiles.ErrorLog(" Form : TC_Report.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					TxtFromdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtTodt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "select t.student_id from student_record sr,tc1 t where sr.student_id=t.student_id", con );
					dtrclass = cmdselect.ExecuteReader();
					while (dtrclass.Read()) 
					{
					
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
					string SubModule="14";
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
				CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
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
			this.btnPrintD.Click += new System.EventHandler(this.btnPrintD_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this methos not in use.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This Method use to viewing the report on the datagrid. data fetch from student_record and tc1 table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="select sr.student_fname,sr.student_class,sr.student_id,sr.seq_student_id,t.tcdate from student_record sr,tc1 t where t.student_id=sr.student_id and cast(floor(cast(cast(t.tcdate as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (TxtFromdt.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TxtTodt.Text.Trim())+"'";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				dgrdsuspend.DataSource =cmdInsert1.ExecuteReader();
				dgrdsuspend.DataBind ();
				if(dgrdsuspend.Items.Count==0)
				{
					MessageBox.Show("No such record found");
					dgrdsuspend.Visible=false;
					pangrid.Visible=false;
				}
				else
				{
					dgrdsuspend.Visible=true;
					pangrid.Visible=true;
				}
				con1.Close(); 
						
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			} 
		}
			

		/// <summary>
		/// This method use to create Report in .xls format in eschool_excelfile folder which is located in C drive.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:CompleteFeesReport.aspx,Method: btnExcel_Click, Complete Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:CompleteFeesReport.aspx,Method:btnExcel_Click   Complete Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
			
		}

		/// <summary>
		/// Convert in to excel file
		/// </summary>
		public void ConvertIntoExcel()
		{
			string Home_Drive=Environment.SystemDirectory;
			Home_Drive=Home_Drive.Substring(0,2);
			string strExcelPath=Home_Drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string Path=Home_Drive+@"\eSchool_ExcelFile\TC_Report.xls";
			StreamWriter sw=new StreamWriter(Path);
			SqlConnection con1 ;
			string strInsert1;
			SqlCommand cmdInsert1;
			con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con1.Open ();
			strInsert1 ="select sr.student_fname,sr.student_class,sr.student_id,sr.seq_student_id,t.tcdate from student_record sr,tc1 t where t.student_id=sr.student_id and cast(floor(cast(cast(t.tcdate as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (TxtFromdt.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TxtTodt.Text.Trim())+"'"; //add by vikas sharma date on 1.2.08
			cmdInsert1=new SqlCommand (strInsert1,con1);
			SqlDataReader rdr= cmdInsert1.ExecuteReader();
			sw.WriteLine("                          =============");
			sw.WriteLine("                            TC Report");
			sw.WriteLine("                          =============");
			sw.WriteLine("                  From "+TxtFromdt.Text+" And To "+TxtTodt.Text);
			sw.WriteLine("");
			sw.WriteLine("");			
			sw.WriteLine("+----+-----+-------------------------+------+---+----------+");
			sw.WriteLine("|SNO.\tS.ID.\tFIRST NAME\tCLASS\tSEC\tTC DATE");
			sw.WriteLine("+----+-----+-------------------------+------+---+----------+");
			if(rdr.HasRows)
			{
				while(rdr.Read())
				{
					sw.WriteLine(i.ToString()+"\t"+rdr["student_id"].ToString().Trim()+"\t"+
					rdr["student_Fname"].ToString().Trim()+"\t"+
					rdr["student_class"].ToString().Trim()+"\t"+
					rdr["seq_student_id"].ToString().Trim()+"\t"+
					GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["tcdate"].ToString().Trim())));
					i++;
				}
			
				rdr.Close();
			}
    		sw.Close(); 

		}
		/// <summary>
		/// Method for returning the date part.
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
		/// Method for writting the report into the text file and save into the eschoolprintservices folder on homedrive.		
		/// </summary>
		public void MakingReport()
		{
			try
			{
				i=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TC_Report.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="select sr.student_fname,sr.student_class,sr.student_id,sr.seq_student_id,t.tcdate from student_record sr,tc1 t where t.student_id=sr.student_id and cast(floor(cast(cast(t.tcdate as datetime) as float))as datetime) between '"+GenUtil.str2MMDDYYYY (TxtFromdt.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TxtTodt.Text.Trim())+"'"; //add by vikas sharma date on 1.2.08
				cmdInsert1=new SqlCommand (strInsert1,con1);
			 	SqlDataReader rdr= cmdInsert1.ExecuteReader();
    			sw.WriteLine("                          =============");
				sw.WriteLine("                            TC Report");
				sw.WriteLine("                          =============");
				sw.WriteLine("                         From "+TxtFromdt.Text+" And To"+TxtTodt.Text);
				sw.WriteLine("");
				sw.WriteLine("");			
				sw.WriteLine("+----+-----+-------------------------+------+---+----------+");
				sw.WriteLine("|SNO.|S.ID.|       FIRST NAME        |CLASS |Sec|  TC Date |");
				sw.WriteLine("+----+-----+-------------------------+------+---+----------+");
			    if(rdr.HasRows)
				{
					info = " {0,-4:S} {1,-5:S} {2,-25:S} {3,-6:S} {4,-3:S} {5,10:S} ";
					while(rdr.Read())
					{
							sw.WriteLine(info,i.ToString(),rdr["student_id"].ToString().Trim(),
							rdr["student_Fname"].ToString().Trim(),
							rdr["student_class"].ToString().Trim(),
							rdr["seq_student_id"].ToString().Trim(),
							GenUtil.trimDate(GenUtil.str2DDMMYYYY(rdr["tcdate"].ToString().Trim())));
						 
						i++;
					}
			
					rdr.Close();
				}
				sw.WriteLine("+----+-----+-------------------------+------+---+----------+");
				sw.Close(); 
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This Method use to create connection to remote device and print the document file.
		/// </summary>
		private void btnPrintD_Click(object sender, System.EventArgs e)
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TC_Report.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TC_Report.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				 	CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  btnPrintD_Click,  Tc Report Printed, Userid :  "+ pass   );								                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  btnPrintD_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  btnPrintD_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  btnPrintD_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Tcrpt.aspx,Method  btnPrintD_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
	}
}
