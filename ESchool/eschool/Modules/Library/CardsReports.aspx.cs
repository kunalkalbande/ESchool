
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
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

using eschool.Classes;

namespace eschool.Library.FORMS
{
	/// <summary>
	/// Summary description for CardsReports.
	/// </summary>
	public class CardsReports : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.Button Print;
		protected System.Web.UI.WebControls.DataGrid CardReportGrid;
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
				try
				  {
					  
					  pass=(Session["password"].ToString());
			
	//For Viewing the Card Genration report on the datagrid.		
					 LibraryClass .CardGenerationClass  obj=new LibraryClass.CardGenerationClass();
					 DataSet ds=new DataSet();
					 ds=obj.ShowCardInformation();
					 CardReportGrid.DataSource=ds;
					 CardReportGrid.DataBind();
			
					CreateLogFiles.ErrorLog("Form : CardsReport.aspx,Method  Page_Load,  Cards Report Viewed,  Userid:  "+ pass   );						 					
				
				
				
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form : CardReport.aspx,Method Page_Load,  Exception :  "+ex.Message+",    Userid:  "+ pass   );					
					Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
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
			this.Print.Click += new System.EventHandler(this.Print_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.CardReportGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.CardReportGrid_PageIndexChanged);
			this.CardReportGrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.CardReportGrid_CancelCommand);
			this.CardReportGrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.CardReportGrid_EditCommand);
			this.CardReportGrid.SelectedIndexChanged += new System.EventHandler(this.CardReportGrid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void CardReportGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				CardReportGrid.EditItemIndex=(int)e.Item .ItemIndex ;
				DataBind ();
			}
			catch(Exception ex)
			{
			
				CreateLogFiles.ErrorLog("Form : CardReport.aspx,Method CardReportGrid_EditCommand,  Exception :  "+ex.Message+",    Userid:  "+ pass   );								
			
			}
		}

		private void CardReportGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				CardReportGrid .EditItemIndex  =-1;
				DataBind();
			}
			catch(Exception ex)
			{
			
				CreateLogFiles.ErrorLog("Form : CardReport.aspx,Method : CardReportGrid_CancelCommand,  Exception :  "+ex.Message+",    Userid:  "+ pass   );								
			
			}
		
		
		}
    //Method for paging the datagrid.
		private void CardReportGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				CardReportGrid.CurrentPageIndex  =(int)e.NewPageIndex ;
				DataBind ();
			}
			catch(Exception ex)
			{
			
				CreateLogFiles.ErrorLog("Form : CardReport.aspx,Method : CardReportGrid_PageIndexChanged,  Exception :  "+ex.Message+",    Userid:  "+ pass   );								
			
			}
		
		
		}

		private void CardReportGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
//Method for redirecting the page for printpreview.
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
//			try
//			{
//				Response .Redirect("../../PrintPreview/CardrptPrint.aspx");
//			}
//			catch(Exception ex)
//			{
//				CreateLogFiles.ErrorLog("Form : CardsReport.aspx,Method  BtnPrint_Click,  Exception   :"+ex.Message+",  Userid:  "+ Session["password"].ToString()   );						 	
//			}

		}
 
//Method for getting the date part form the string which contain the data and time combine.
		public string trimDate(string date)
		{
			int pos = date.IndexOf(" ");
			if(pos > -1)
			{
				date = date.Substring(0,pos); 
			}
			return date;

		}

//method for wrinting the card genration report in text file and save the file into the eschoolprintservice folder.
		public void MakingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CardReport.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection con1 ;
				string strInsert1;
				SqlCommand cmdInsert1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				strInsert1 ="Select *  From  Card_Generation";
				cmdInsert1=new SqlCommand (strInsert1,con1);
				SqlDataReader rdr= cmdInsert1.ExecuteReader();
				
				sw.Write((char)27);//added by vishnu
				sw.Write((char)67);//added by vishnu
				sw.Write((char)0);//added by vishnu
				sw.Write((char)12);//added by vishnu

				sw.Write((char)27);//added by vishnu
				sw.Write((char)78);//added by vishnu
				sw.Write((char)5);//added by vishnu
							
				sw.Write((char)27);//added by vishnu
				sw.Write((char)15);
				
				sw.WriteLine("				      --------------------------");                    
				sw.WriteLine("                                       Card Generation Report");
				sw.WriteLine("				      --------------------------");

				sw.WriteLine("+---------+-------------+-----+------------------------------+--------+-----+-----------+---------+---------------+");
				sw.WriteLine("|  MemID  | Designation |Class|Candidate Name                |CardNo  |TC   | CG Date   |Time(Yr.)|     Remark    |");
				sw.WriteLine("+---------+-------------+-----+------------------------------+--------+-----+-----------+---------+---------------+");
				//             123456789 1234567890123 12345 123456789012345678901234567890 12345678 12345 12345678901 123456789 123456789012345
				if(rdr.HasRows)
				{
					info = " {0,-9:S} {1,-13:S} {2,-5:S} {3,-30:S} {4,8:S} {5,5:S} {6,11:S} {7,9:S}  {8,-15:S}";
					while(rdr.Read())
					{
						//						sw.WriteLine(info,rdr["Candidateid"].ToString().Trim(),
						//							rdr["Card_no"].ToString().Trim(),
						//							rdr["No_of_card"].ToString(),
						//								 
						//							rdr["Validity_of_card"].ToString().Trim(),trimDate(rdr["Date_of_cardgen"].ToString().Trim()),rdr["name_of_librarian"].ToString().Trim(),
						//							rdr["remark"].ToString().Trim()  );
						 
						sw.WriteLine (info,rdr["memberID"].ToString(),
							GenUtil.TrimLength(rdr["desig"].ToString(),14),
							GenUtil.TrimLength(rdr["class"].ToString(),6),
							GenUtil.TrimLength(rdr["Name_Of_Librarian"].ToString(),31),
							GenUtil.TrimLength(rdr["Card_NO"].ToString(),8),
							rdr["No_Of_Card"].ToString(),
							GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_Of_CardGen"].ToString())),
							rdr["Validity_Of_Card"].ToString(),
							GenUtil.TrimLength(rdr["Remark"].ToString(),15)
							);
					}
					rdr.Close();
				}
				sw.WriteLine("+---------+-------------+-----+------------------------------+--------+-----+-----------+---------+---------------+");
				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Member_Report.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}
//Method for sending the text file to the eschoolprintservice folder and issue the print command.
		private void Print_Click(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];
			
			// Connect to a remote device.
			try 
			{
				MakingReport();//Method call for writing the report into the text file.
							
			 
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
			
				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
			
				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
			
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());
 
 
			
					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CardGenerationReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
			
					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
			
					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :CardsReport.aspx,Method  Print_Click,  Cards Report Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :CardsReport.aspx,Method  Print_Click,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :CardsReport.aspx,Method  Print_Click,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :CardsReport.aspx,Method  Print_Click,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{

				CreateLogFiles.ErrorLog(" Form :CardsReport.aspx,Method  Print_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}

		}

		
	}
}
