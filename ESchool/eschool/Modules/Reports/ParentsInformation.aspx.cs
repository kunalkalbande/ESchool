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
using System.Data .SqlClient;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for ParentsInformation.
	/// </summary>
	public class ParentsInformation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgrdParentsInfo;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		protected System.Web.UI.WebControls.DropDownList DropSearchName1;
		protected System.Web.UI.WebControls.TextBox DropSearchName;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		string pass;
		# region page load...
		private void Page_Load(object sender, System.EventArgs e)
		{
				try
				{

//					if(Session["view"]!=null)
//					{
//						try
//						{
//							if(Session["password"].ToString().Length<=0&&(bool)Session["view"]==false)
//							{
//								Session.Abandon();
//								Session.RemoveAll();
// 
//								Response.Redirect(@"./HolidayEntryForm.aspx");
//							}
//							else
//							{
//								Response.Buffer=false;
//								Response.CacheControl="no-cache";
//								Response.Expires=System.DateTime.Now.Minute-1;	
//								Session["view"]=false;
//							}
//						}
//						catch(System.NullReferenceException)
//						{
//						
//							CreateLogFiles.ErrorLog(" Form : ParentsInformation.aspx,Method  PageLoad,  Exception: System.NullReferenceException , Userid :  "+ Session["password"].ToString()   );		
//							Session.Abandon();
//							Response.Redirect(@".\HolidayEntryForm.aspx");
//						}
//					}
//					else
//					{
//						Response.Buffer=false;
//						Response.CacheControl="no-cache";
//						Response.Expires=System.DateTime.Now.Minute-1;
//						Session["view"]=false;
//					}
				
					
					
					try
					{
						
						pass=(Session["password"].ToString());
					}
					catch(Exception ex)
					{
						Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
						CreateLogFiles.ErrorLog ("Form: ParentsInformation.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
						return;
					}	
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page .IsPostBack)
				{
//Method for adding the studentid into the combobox.                
					/*
					SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
					SqlDataReader sdred;
					sdred=obj.showStudentIDInCombo();
					while(sdred.Read())
					{
						DropSearchName.Items .Add (sdred.GetValue(0).ToString());
				
					}*/		
				}
			 
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="7";
				string SubModule="4";
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
					CreateLogFiles.ErrorLog(" Form :ParentsInformation.aspx.cs,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
				}			
				
				
				
				}
		# endregion

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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		  

		# region  Method for viewing the student report on the datagrid.
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				if(DropSearchName.Text=="")
				{
					MessageBox.Show("Please Enter Student ID");
					dgrdParentsInfo.Visible=false; 
				}
				else
				{
					//dgrdParentsInfo.Visible=true; 
					//SqlConnection conNorthwind;
					InventoryClass obj = new InventoryClass();
					SqlDataReader SqlDtr;
					string  strSelect;
					//SqlCommand cmdSelect;
					//conNorthwind = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					
					strSelect = "select Student_FatherName,Student_MotherName,Student_FatherMobileno,Student_MotherMobileno,Student_FatherOccp,Student_MotherOccp,Student_FatherAnnualIncome,Student_MotherAnnualIncome,Student_FatherEmailID,Student_MotherEmailID,Student_Category,scategory,rank from  Student_Record  where Student_ID='"+DropSearchName.Text+"'";
										
					//cmdSelect.Parameters.Add("@Student_ID",DropSearchName .SelectedItem .Value .ToString());
					//cmdSelect.Parameters.Add("@Student_ID",DropSearchName.Text);
					SqlDtr=obj.GetRecordSet(strSelect);
					if(SqlDtr.HasRows)
					{
						dgrdParentsInfo.DataSource = SqlDtr;
						dgrdParentsInfo.DataBind();
						dgrdParentsInfo.Visible=true; 
					}
					else
					{
						MessageBox.Show("Student ID Is Not Fount");
						dgrdParentsInfo.Visible=false; 
					}
                    CreateLogFiles.ErrorLog(" Form :ParentsInformation.aspx.cs,Method  Search_ServerClick, Parents information viewed for studentID:"+DropSearchName.Text+" , Userid :  "+ Session["Password"].ToString()   );
				
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :ParentsInformation.aspx.cs,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
 			}	
		}
		# endregion
//Method for issuing the print command to the printer for printing the report. 
		public void Print()
		{		
			byte[] bytes = new byte[1024];

			// Connect to a remote device.
			try 
			{				
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".


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
					//CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentParentReport.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					 
				
				
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form : ParenrInformation.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );
					 
					 
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : ParenrInformation.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
					 
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
				 
				}		
			
			} 
			
			catch(Exception ex)
			{
			 
					CreateLogFiles.ErrorLog(" Form : ParenrInformation.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );			
			}

		}
//Method for writing the report into the text file and call method for issuing the print command to printer for print the Report.
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";

				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentParentReport.txt";
				StreamWriter sw = new StreamWriter(path); 
 
				SqlConnection conNorthwind;
				string  strSelect;
				SqlCommand cmdSelect;
				SqlDataReader SqlDtr = null;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				strSelect = "";
				conNorthwind.Open();
			
				strSelect ="select Student_FatherName,Student_MotherName,Student_FatherMobileno,Student_MotherMobileno,Student_FatherOccp,Student_MotherOccp,Student_FatherAnnualIncome,Student_MotherAnnualIncome,Student_FatherEmailID,Student_MotherEmailID,Student_Category,scategory,rank from  Student_Record  where Student_ID=@Student_ID";
				//strSelect = "select Student_FatherName,Student_MotherName,Student_FatherMobileno,Student_MotherMobileno,Student_FatherOccp,Student_MotherOccp from  Student_Record  where seq_Student_ID=@Student_ID ";
				cmdSelect = new SqlCommand( strSelect, conNorthwind );
				//cmdSelect.Parameters.Add("@Student_ID",DropSearchName .SelectedItem .Value .ToString());
				cmdSelect.Parameters.Add("@Student_ID",DropSearchName.Text);
				SqlDtr = cmdSelect.ExecuteReader();
				//*****set page break

				/*sw.Write((char)27);//added by vishnu
				sw.Write((char)67);//added by vishnu
				sw.Write((char)0);//added by vishnu
				sw.Write((char)12);//added by vishnu/*

				sw.Write((char)27);
				sw.Write((char)64);

				//sw.Write((char)27);
				//sw.Write((char)33);
				//sw.Write((char)10);


				sw.Write((char)27);
				sw.Write((char)38);
				sw.Write((char)108);
				sw.Write((char)49);
				sw.Write((char)79);*/



				sw.Write((char)27);//added by vishnu
				sw.Write((char)67);//added by vishnu
				sw.Write((char)0);//added by vishnu
				sw.Write((char)12);//added by vishnu


				sw.Write((char)27);//added by vishnu
				sw.Write((char)78);//added by vishnu
				sw.Write((char)5);//added by vishnu
							
				sw.Write((char)27);//added by vishnu
				sw.Write((char)15);
				
				//sw.Write((char)27);//added by vishnu
				//sw.Write((char)68);

				
				//****************

				sw.WriteLine("				   ==========================") ;
				sw.WriteLine("		                   PARENTS INFORMATION REPORT") ;
				sw.WriteLine("                                   ==========================") ;
				sw.WriteLine("");
				sw.WriteLine("+--------------------+---------------+-----------+-----------+------------+------------+--------+--------+--------------------+--------------------+--------+----------+---------+") ;
				sw.WriteLine("|    Father Name     | Mother Name   |F MobileNo |M MobileNo |F Occupation|M Occupation|FAIncome|MAIccome|    FEmailID        |  MEmailID          |Category|SCategory | Rank    |") ;				
				sw.WriteLine("+--------------------+---------------+-----------+-----------+------------+------------+--------+--------+--------------------+--------------------+--------+----------+---------+") ;
				 //			   12345678901234567890	123456789012345 12345678901 12345678901 123456789012 123456789012 12345678 12345678 12345678901234567890 12345678901234567890 12345678 1234567890 123456789
				
				
				info = " {0,-20:S} {1,-15:S} {2,-11:S} {3,-11:S} {4,-12:S} {5,-12:S} {6,8:S} {7,8:S} {8,-20:S} {9,-20:S} {10,-8:S} {11,-10:S} {12,-9:S}";
				 
				
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{	
						sw.WriteLine (info,
							SqlDtr["Student_FatherName"].ToString(),
							GenUtil.TrimLength(SqlDtr["Student_MotherName"].ToString(),15),
							GenUtil.TrimLength(SqlDtr["Student_FatherMobileno"].ToString(),11),
							GenUtil.TrimLength(SqlDtr["Student_MotherMobileno"].ToString(),11),
							GenUtil.TrimLength(SqlDtr["Student_FatherOccp"].ToString(),12),
							GenUtil.TrimLength(SqlDtr["Student_MotherOccp"].ToString(),12),
							GenUtil.TrimLength(SqlDtr["Student_FatherAnnualIncome"].ToString(),8),
							GenUtil.TrimLength(SqlDtr["Student_MotherAnnualIncome"].ToString(),8),
							GenUtil.TrimLength(SqlDtr["Student_FatherEmailID"].ToString(),20),
							GenUtil.TrimLength(SqlDtr["Student_MotherEmailID"].ToString(),20),
							GenUtil.TrimLength(SqlDtr["Student_Category"].ToString(),8),
							GenUtil.TrimLength(SqlDtr["scategory"].ToString(),10),
							GenUtil.TrimLength(SqlDtr["rank"].ToString(),9)
						);
										


							
						
						
					//						sw.WriteLine(info,SqlDtr.GetValue(0).ToString(),
					//							SqlDtr.GetValue(1).ToString(),
					//							SqlDtr.GetValue(2).ToString(),
					//							SqlDtr.GetValue(3).ToString(),
					//							SqlDtr.GetValue(4).ToString(),
					//							SqlDtr.GetValue(5).ToString()) ;						
				}
				}
				SqlDtr.Close();
				sw.WriteLine("+--------------------+---------------+-----------+-----------+------------+------------+--------+--------+--------------------+--------------------+--------+----------+---------+") ;				

				//sw.Write((char)27);
				//sw.Write((char)38);
				//sw.Write((char)108);
				//sw.Write((char)49);
				//sw.Write((char)79);


				sw.Close(); 
				Print();
				CreateLogFiles.ErrorLog(" Form : DetailsOFCaste.aspx,Method  Button1_Click, Student Parent Information View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());  
				CreateLogFiles.ErrorLog(" Form : ParenrtInformation.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}

		}
			
	}
}
