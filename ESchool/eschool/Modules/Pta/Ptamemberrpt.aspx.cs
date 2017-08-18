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
	/// Summary description for Ptamemberrpt.
	/// </summary>
	public class Ptamemberrpt1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.DataGrid dgrdcomp;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Button btnPrintD;
		protected System.Web.UI.WebControls.Label Label1;
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
            txtstudentname.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form: meetingrpt.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
					cmdselect = new SqlCommand( "Select ptamem  From ptamembership", con );
					dtrclass = cmdselect.ExecuteReader();
					while(dtrclass.Read())
					{
						Dropstudentid.Items.Add(dtrclass.GetValue(0).ToString());
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
					string SubModule="22";
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
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.btnPrintD.Click += new System.EventHandler(this.btnPrintD_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use for add the name of selected memberid into the textbox.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*SqlConnection con44;
			SqlCommand cmdselect44;
			SqlDataReader dtrdrive44;
			try
			{
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				cmdselect44 = new SqlCommand( "Select name  From ptamembership where ptamem=@ptamem", con44 );
				cmdselect44.Parameters .Add ("@ptamem",Dropstudentid.SelectedItem .Text.ToString());
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
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  Dropstudentid_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} */
		}
	
		/// <summary>
		/// this method use to show the Report on the datagrid
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			SqlConnection con1 ;
			string strInsert1;
			SqlCommand cmdInsert1;
			try
			{
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				if(Dropstudentid.SelectedIndex!=0)
					strInsert1 =" Select *  From ptamembership where ptamem =@ptamem";
				else
					strInsert1 =" Select *  From ptamembership order by name";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				if(Dropstudentid.SelectedIndex!=0)
					cmdInsert1.Parameters .Add("@ptamem",Dropstudentid.SelectedItem .Text .ToString () ); 

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
					pangrid.Visible=true;
				}
				con1.Close();        
					
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  Search_ServerClick,  Ptamemberrpt Report Viewed for Member:"+Dropstudentid.SelectedItem .Text .ToString () +", Userid :  "+ pass   );		
						
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
							 
			} 
		}
									
		/// <summary>
		/// this method for writting the text file into the eschoolprintservies folder on homedrive.
		/// </summary>
		public void MakingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ptamemberreport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				if(Dropstudentid.SelectedIndex!=0)
					strInsert1 ="Select *  From ptamembership where ptamem ='"+Dropstudentid.SelectedItem .Text .ToString ()+"'";
				else
					strInsert1 ="Select *  From ptamembership order by name";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				SqlDataReader rdr= cmdInsert1.ExecuteReader();
				sw.WriteLine("                                ======================");                    
				sw.WriteLine("                                	PTA MEMBER  REPORT");
				sw.WriteLine("			                      ======================");
				//16.02.09 sw.WriteLine("+----------------------+-----------+----------- --+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");
				//16.02.09 sw.WriteLine("|  First Name          |Designation      type             Email             contact No.    Mobaile No   studentID staff_id            Address            |  City       |  State         |country    ");
				//16.02.09 sw.WriteLine("+----------------------+-----------+--------------+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");

				sw.WriteLine("+----------------------+-----------+--------------+-----------------------+-----------+-----------+------+------+------------------+----------+-------+");
				sw.WriteLine("|  First Name          |Designation|     type     |         Email         |   Phone   |   Mobile  |Std.ID|Stf.ID|      Address     |   City   | State |");
				sw.WriteLine("+----------------------+-----------+--------------+-----------------------+-----------+-----------+------+------+------------------+----------+-------+");
				if(rdr.HasRows)
				{
					//16.02.09 info = " {0,-23:S}{1,-12:S}{2,-14:S}{3,-25:S}{4,-16:S}{5,-13:S} {6,-9:S}{7,-10:S}{8,-31:S}{9,-14:S}{10,-16:S}{11,-11:S}   ";
					info = " {0,-22:S} {1,-11:S} {2,-14:S} {3,-23:S} {4,-11:S} {5,-11:S} {6,-6:S} {7,-6:S} {8,-18:S} {9,-10:S} {10,-7:S} ";
					while(rdr.Read())
					{
						sw.WriteLine(info,GenUtil.TrimLength( rdr["name"].ToString().Trim(),22),
							GenUtil.TrimLength(rdr["Designation"].ToString().Trim(),11),
							//sw.WriteLine(info,rdr["name"].ToString().Trim(),rdr["Designation"].ToString().Trim(),
							//rdr["membertype"].ToString().Trim(),
							GenUtil.TrimLength(rdr["membertype"].ToString().Trim(),11),
                            //rdr["email"].ToString(),
							GenUtil.TrimLength(rdr["email"].ToString().Trim(),23),
							rdr["teleno"].ToString().Trim(),
							rdr["mobileno"].ToString().Trim(),rdr["Student_ID"].ToString().Trim(),rdr["Staffid"].ToString().Trim(),
							//rdr["address"].ToString().Trim(),
							GenUtil.TrimLength(rdr["address"].ToString().Trim(),18),
							rdr["Pcity"].ToString().Trim(),
							rdr["state"].ToString().Trim());
							//16.02.09 rdr["Country"].ToString().Trim() );
					}
					rdr.Close();
				}
				sw.WriteLine("+----------------------+-----------+--------------+-----------------------+-----------+-----------+------+------+------------------+----------+-------+");
				//16.02.09 sw.WriteLine("+----------------------+-----------+--------------+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");
				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		/// <summary>
		/// This method use to convert in to excel format.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			/*try
			{
				Response .Redirect("../PrintPreview/PtaMeetingrptPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["password"].ToString()   );		
 
			}*/
            
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
		/// this method use to create report in to excel format.
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
				string path = home_drive+@"\eSchool_ExcelFile\ptamemberreport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ptamemberreport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				
				if(Dropstudentid.SelectedIndex!=0)
					strInsert1 ="Select *  From ptamembership where ptamem ='"+Dropstudentid.SelectedItem .Text .ToString ()+"'";
				else
					strInsert1 ="Select *  From ptamembership order by name";
				
				cmdInsert1=new SqlCommand (strInsert1,con1);
				SqlDataReader rdr= cmdInsert1.ExecuteReader();
				sw.WriteLine("                                 ======================");                    
				sw.WriteLine("                                	PTA MEMBER  REPORT");
				sw.WriteLine("			                       ======================");
				//sw.WriteLine("+----------------------+-----------+----------- --+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");
				sw.WriteLine("First Name\tDesignation\ttype\tEmail\tcontact No.\tMobaile No\tstudentID\tstaff_id\tAddress\tCity\tState\tcountry");
				//sw.WriteLine("+----------------------+-----------+--------------+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");
				if(rdr.HasRows)
				{
					info = " {0,-23:S}{1,-12:S}{2,-14:S}{3,-25:S}{4,-16:S}{5,-13:S} {6,-9:S}{7,-10:S}{8,-31:S}{9,-14:S}{10,-16:S}{11,-11:S}   ";
					while(rdr.Read())
					{
						sw.WriteLine(rdr["name"].ToString().Trim()+"\t"+
							rdr["Designation"].ToString().Trim()+"\t"+
							rdr["membertype"].ToString().Trim()+"\t"+
							rdr["email"].ToString()+"\t"+
							rdr["teleno"].ToString().Trim()+"\t"+
							rdr["mobileno"].ToString().Trim()+"\t"+
							rdr["Student_ID"].ToString().Trim()+"\t"+
							rdr["Staffid"].ToString().Trim()+"\t"+
							rdr["address"].ToString().Trim()+"\t"+
							rdr["Pcity"].ToString().Trim()+"\t"+
							rdr["state"].ToString().Trim()+"\t"+
							rdr["Country"].ToString().Trim() );
					}
					rdr.Close();
				}
				//sw.WriteLine("+----------------------+-----------+--------------+-----------------------+---------------+------------+---------+--------+------------------------------+-------------+----------------+-----------+");
				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}


		/// <summary>
		/// Method for sending the text file to the printer and issue the print commmand.
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
				///Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\PTAMemberReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  btnPrintD_Click,  PTA Member Report Printed, Userid :  "+ pass   );								 
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  btnPrintD_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  btnPrintD_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  btnPrintD_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :Ptamemberrpt.aspx,Method  btnPrintD_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
	}
}
