
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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using eschool.Classes;
using RMG;

namespace eschool.Modules.Library
{
	/// <summary>
	/// Summary description for IssueBookReport.
	/// </summary>
	public class IssueBookReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		protected System.Web.UI.WebControls.DropDownList Dropstype;
		protected System.Web.UI.WebControls.DropDownList Dropsopt;
	    public SqlDataReader dr1=null;
		protected System.Web.UI.HtmlControls.HtmlButton Btnexcel;
		public int flage=0;
		
		protected System.Web.UI.WebControls.TextBox Txtfdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
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
				CreateLogFiles.ErrorLog("Form : IssueBookReport.aspx,Method : Page_Load,  Exception :  "+ex.Message+",    Userid:  "+ pass   );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					Txtfdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="1";
					string SubModule="13";
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
						Response.Redirect("/eLibrary/Forms/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : IssueBookReport.aspx,Method : Page_Load,  Exception :  "+ex.Message+",    Userid:  "+ pass   );
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
			
			this.Dropstype.SelectedIndexChanged += new System.EventHandler(this.DropBookid_SelectedIndexChanged);
			this.Dropsopt.SelectedIndexChanged += new System.EventHandler(this.DropUBookid_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Btnexcel.ServerClick += new System.EventHandler(this.Btnexcel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void IssueBookReportGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
				Response .Redirect("../../PrintPreview/IssueBookrptPrint.aspx");
		}


		/// <summary>
		/// this method use to Concrate The first Name with lastname.
		/// </summary>
		public string FullName(string fname,string mname,string lname)
		{
			return fname+" "+mname+" "+lname;
		}

		/// <summary>
		/// this method use to assign 1 value of flage variable.after that excute the HTML code.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				flage=1;
				if(Dropstype.SelectedIndex!=0 && Dropsopt.SelectedIndex!=0)
				{
					CreateLogFiles.ErrorLog("Form : IssueBookReport.aspx,Method : Search_ServerClick, Report Shown for  BookID"+Dropstype.SelectedItem.Value.ToString()+",    Userid:  "+ pass   );		
				}
		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : IssueBookReport.aspx,Method : Search_ServerClick,  Exception :  "+ex.Message+",    Userid:  "+ pass   );

			}
					
		}

		/// <summary>
		/// This method use to Remove Space from pass date as string.
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
		/// this Method use to create the Report into the text file and data fetch from Stock_table,Issue_Book,student_record,staff_information tables and save that file into the eschoolprintservices.
		/// </summary>
		public void MakingReport()
		{
			InventoryClass obj=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\IssuBookInformationReport.txt";
			StreamWriter sw = new StreamWriter(path);
			try
			{
				SqlDataReader rdr=null;
				string sql="";
				if (Dropstype.SelectedIndex!=0 && Dropsopt.SelectedIndex!=0)
				{
					if(Dropstype.SelectedItem.Text.Equals ("Staff Wise"))
					{
						if(Dropsopt.SelectedItem .Text .Equals ("All"))
						{
							sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						}
						else
						{
							sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.Book_ID in (select Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff') and st.book_id in (select  Book_ID from issue_book where memberid="+Dropsopt.SelectedItem.Text+" and type='Staff') and si.staff_id="+Dropsopt.SelectedItem.Text+" and ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff'";
						}
						
					}
					else if(Dropstype.SelectedItem.Text.Equals ("Student Wise"))
					{
						if(Dropsopt.SelectedItem .Text .Equals ("All"))
						{
							sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						}
					}
					else 
						sql="select ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig ,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No,cg.class from Stock_table st,Card_Generation cg,Issue_Book ib where ib.Book_ID=st.Book_ID and cg.memberid=ib.memberid";			 
				}	 
				else
							   sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				rdr=obj.GetRecordSet(sql);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);							
				sw.Write((char)27);
				sw.Write((char)15);				
				sw.WriteLine("                                       -------------------------------");                    
				sw.WriteLine("                                         Issue Book Information Report");
				sw.WriteLine("                                       -------------------------------");
				string info = "",info2 = "",info3 = "",info1="";
				info1 = "                     {0,-15:S}  {1,-13:S}                    {2,20:S}      {3,-20:S}";
				if(Dropstype.SelectedIndex==0)
					sw.WriteLine(info1,"Search By:", "All", "Option:",  "All");
				else
					sw.WriteLine(info1,"Search By:",Dropstype.SelectedItem.Text,"Option:",Dropsopt.SelectedItem.Text);
				if(Dropstype.SelectedItem.Text.Equals ("Staff Wise"))
				{
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+-------------+-----------+------------+");
					sw.WriteLine("|MemberID| Member Name                  | BID |   Book Name                       | Card No |Designation  |Issue Date |Return Date  ");
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+-------------+-----------+------------+");
					//             12345678 123456789012345678901234567890 12345 12345678901234567890123456789012345 123456789 1234567890123 12345678901 12345678901
					info2 = " {0,-8:S} {1,-25:S}      {2,5:S} {3,-35:S} {4,9:S}  {5,-13:S}{6,11:S} {7,11:S}";//designation
				}
				else if(Dropstype.SelectedItem.Text.Equals ("Student Wise"))
				{
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+------+-----------+------------+");
					sw.WriteLine("|MemberID| Member Name                  | BID |   Book Name                       | Card No |Class |Issue Date |Return Date  ");
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+------+-----------+------------+");
					//             12345678 123456789012345678901234567890 12345 12345678901234567890123456789012345 123456789 123456 12345678901 12345678901
					info3 = " {0,-8:S} {1,-25:S}      {2,5:S} {3,-35:S} {4,9:S}  {5,-6:S}{6,11:S} {7,11:S}";//class
				}
				else 
				{
					sw.WriteLine("+--------+------------------------------+-----+---------------------------------+---------+-------------+------+-----------+------------+");
					sw.WriteLine("|MemberID| Member Name                  | BID |   Book Name                     | Card No |Designation  |Class |Issue Date |Return Date  ");
					sw.WriteLine("+--------+------------------------------+-----+---------------------------------+---------+-------------+------+-----------+------------+");
					//             12345678 123456789012345678901234567890 12345 123456789012345678901234567890123 123456789 1234567890123 123456 12345678901 12345678901
					info = " {0,-8:S} {1,-25:S}      {2,5:S} {3,-33:S}{4,9:S}  {5,-13:S} {6,-6:S}{7,11:S} {8,11:S}";//all
				}
				
				while(rdr.Read())
				{
					if (Dropstype.SelectedIndex!=0 && Dropsopt.SelectedIndex!=0)
					{
						if(Dropstype.SelectedItem.Text.Equals("Staff Wise"))
						{
							sw.WriteLine (info2,rdr["memberID"].ToString(),
								GenUtil.TrimLength(rdr["Name_Of_Librarian"].ToString(),30),
								rdr["Book_ID"].ToString(),
								GenUtil.TrimLength(rdr["BookName"].ToString(),35),
								GenUtil.TrimLength(rdr["Card_NO"].ToString(),9),
								GenUtil.TrimLength(rdr["desig"].ToString(),13),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_Of_Issue"].ToString())),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Return_Date"].ToString()))
								);
						}
					
						else if(Dropstype.SelectedItem.Text.Equals("Student Wise"))
						{
							sw.WriteLine (info3,rdr["memberID"].ToString(),
								GenUtil.TrimLength(rdr["Name_Of_Librarian"].ToString(),30),
								rdr["Book_ID"].ToString(),
								GenUtil.TrimLength(rdr["BookName"].ToString(),35),
								GenUtil.TrimLength(rdr["Card_NO"].ToString(),9),
								GenUtil.TrimLength(rdr["class"].ToString(),6),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_Of_Issue"].ToString())),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Return_Date"].ToString()))
								);
						}
						else
						{
							sw.WriteLine (info,rdr["memberID"].ToString(),
								GenUtil.TrimLength(rdr["Name_Of_Librarian"].ToString(),30),
								rdr["Book_ID"].ToString(),
								GenUtil.TrimLength(rdr["BookName"].ToString(),35),
								GenUtil.TrimLength(rdr["Card_NO"].ToString(),9),
								GenUtil.TrimLength(rdr["desig"].ToString(),13),
								GenUtil.TrimLength(rdr["class"].ToString(),6),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Date_Of_Issue"].ToString())),
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Return_Date"].ToString()))
								);
						}
					}
													
				}
				rdr.Close();
				if(Dropstype.SelectedItem.Text.Equals ("Staff Wise"))
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+-------------+-----------+------------+");
				else if(Dropstype.SelectedItem.Text.Equals ("Student Wise"))
					sw.WriteLine("+--------+------------------------------+-----+-----------------------------------+---------+------+-----------+------------+");
				else 
					sw.WriteLine("+--------+------------------------------+-----+---------------------------------+---------+-------------+------+-----------+------------+");
				sw.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			 
			} 
		}

		/// <summary>
		/// this Method use to create the Report into the text file and data fetch from Stock_table,Issue_Book,student_record,staff_information tables and save that file into the eschoolprintservices.
		/// </summary>
		public void Making_Report()
		{
			try
			{
				int i=1;
				flage=1;
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj4=new InventoryClass();			
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\IssuBookInformationReport1.txt";
				  string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\IssuBookInformationReport.txt";
				StreamWriter sw = new StreamWriter(path);

				try
				{
					string sql="";
					
						SqlConnection scon2;
						SqlCommand cmd2;
						SqlDataReader dr2;
						scon2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon2.Open();
						if(Dropstype.SelectedItem.Text=="All")
						{
							sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						}
						else if(Dropstype.SelectedItem.Text=="Staff Wise")
						{
							if(Dropsopt.SelectedItem.Text=="All")
							{
								sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							}
							else
							{
								sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff'and si.staff_id=ib.memberid and st.book_id=ib.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							}

						}
						else if(Dropstype.SelectedItem.Text=="Student Wise")
						{
							if(Dropsopt.SelectedItem.Text=="All")
							{
								sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							}
							else
							{
								sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Student' and sr.student_id= ib.memberid and ib.Book_ID = st.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
							}
						}
						else if(Dropstype.SelectedItem.Text=="Select")
						{
							MessageBox.Show("Please Select Search Type");
							return;
						}
						cmd2=new SqlCommand(sql,scon2);
						dr2=cmd2.ExecuteReader();
						 
                        string info=" {0,-3:S} {1,-6:S} {2,-25:S} {3,-6:S} {4,-30:S} {5,-6:S} {6,-10:S} {7,-10:S}"; 
						sw.WriteLine("                                       -------------------------------");                    
						sw.WriteLine("                                         Issue Book Information Report");
						sw.WriteLine("                                       -------------------------------");
                        sw.WriteLine();
						sw.WriteLine("+---+------+-------------------------+------+------------------------------+------+----------+----------+");
						sw.WriteLine("|SNo|MemID |    Member Name          |BookID|        Book Name             |Cls/De|Issue Date|Retur Date|");
						sw.WriteLine("+---+------+-------------------------+------+------------------------------+------+----------+----------+");
                        //             123 123456 1234567890123456789012345 123456 123456789012345678901234567890 123456 1234567890 1234567890 
                         
						while(dr2.Read())
						{
							if(Dropstype.SelectedItem.Text=="Staff Wise")
							{
								    sw.WriteLine(info,i.ToString(),dr2["memberID"].ToString(),GenUtil.TrimLength(dr2["staff_name"].ToString(),20),
									dr2["Book_ID"].ToString(),GenUtil.TrimLength(dr2["bookname"].ToString(),30),dr2["staff_type"].ToString(),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Date_Of_Issue"].ToString())),GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Return_Date"].ToString())));
							}
							
							else
							{
								    sw.WriteLine(info,i.ToString(),dr2["memberID"].ToString(),GenUtil.TrimLength(dr2["student_fname"].ToString(),20),
									dr2["Book_ID"].ToString(),GenUtil.TrimLength(dr2["bookname"].ToString(),30),GenUtil.TrimLength( dr2["student_class"].ToString(),6),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Date_Of_Issue"].ToString())),GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Return_Date"].ToString())));
							}
							i++;
					    }
                      sw.WriteLine("+---+------+-------------------------+------+------------------------------+------+----------+----------+");
							
						dr2.Close();
					    sw.Close();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				
			}

		}
		/// <summary>
		/// Method for sending the text file to the printer and issueing the print command.
		/// </summary>
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{
				Making_Report();			
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\IssuBookInformationReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Issue Book Report  Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				
				CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropUBookid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this Method use to fill dropsopt by member id which fetch from issue_book table, staff_information and student_record table also.
		/// </summary>
		private void DropBookid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="";
				Dropsopt .Enabled=true;
				Dropsopt .Items.Clear();
				Dropsopt .Items.Add("All");
				if(Dropstype  .SelectedItem.Text.Equals("Staff Wise"))
				{
					str="select distinct memberid from Issue_Book ib,staff_information si where ib.memberid=si.staff_id and Type='Staff'";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
				else if(Dropstype .SelectedItem.Text.Equals("Student Wise"))
				{
					str="select distinct memberid from Issue_Book ib,staff_information si where ib.memberid=si.staff_id and Type='Student'";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropsopt .Items.Add(SqlDtr.GetValue(0).ToString());
					}
				}
	
				else
				{
					Dropsopt .Enabled=false;
					Dropsopt .Items.Add("All");
					Dropsopt .SelectedIndex=1;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to convert file in xls formate.
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
		/// this Method use to create the Report into the xls format and data fetch from Stock_table,Issue_Book,student_record,staff_information tables and save that file into the eschool_excelfle folder which exist in home drive.
		/// </summary>
		public void ConvertIntoExcel()
		{

			try
			{
				int i=1;
				flage=1;
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj4=new InventoryClass();			
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 

				string strExcelPath  = home_drive+"\\eschool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eschool_ExcelFile\IssuBookInformationReport1.xls";

				StreamWriter sw = new StreamWriter(path);
				try
				{
					string sql="";
					SqlConnection scon2;
					SqlCommand cmd2;
					SqlDataReader dr2;
					scon2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon2.Open();
					if(Dropstype.SelectedItem.Text=="All")
					{
						sql="select ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' union select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					}
					else if(Dropstype.SelectedItem.Text=="Staff Wise")
					{
						if(Dropsopt.SelectedItem.Text=="All")
						{
							sql="select distinct ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where ib.Book_ID=st.Book_ID and si.staff_id=ib.memberID and Type='Staff' and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						}
						else
							sql="select ib.Book_ID,st.bookname,si.staff_name,si.staff_type,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,staff_information si where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Staff'and si.staff_id=ib.memberid and st.book_id=ib.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					}
					else if(Dropstype.SelectedItem.Text=="Student Wise")
					{
						if(Dropsopt.SelectedItem.Text=="All")
						{
							sql="select distinct ib.Book_ID,st.bookname,sr.student_fname,sr.student_class,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr,staff_information si where (ib.Book_ID=st.Book_ID and sr.student_id=ib.memberID and Type='Student') and Date_Of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						}
						else
							sql="select ib.Book_ID,st.bookname,sr.student_class,sr.student_fname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib,student_record sr where ib.memberid="+Dropsopt.SelectedItem.Text+" and Type='Student' and sr.student_id= ib.memberid and ib.Book_ID = st.book_id and ib.date_of_issue between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					}
					else if(Dropstype.SelectedItem.Text=="Select")
					{
						MessageBox.Show("Please Select Search Type");
						return;
					}
					cmd2=new SqlCommand(sql,scon2);
					dr2=cmd2.ExecuteReader();
						 
					string info=" {0,-3:S} {1,-6:S} {2,-25:S} {3,-6:S} {4,-30:S} {5,-6:S} {6,-10:S} {7,-10:S}"; 
					sw.WriteLine("                                       -------------------------------");                    
					sw.WriteLine("                                         Issue Book Information Report");
					sw.WriteLine("                                       -------------------------------");
					sw.WriteLine();
					sw.WriteLine("SNo\tMemID\tMember Name\tBookID\tBook Name\tCls/De\tIssue Date\tRetur Date");
					//             123 123456 1234567890123456789012345 123456 123456789012345678901234567890 123456 1234567890 1234567890 
                         
					while(dr2.Read())
					{
						if(Dropstype.SelectedItem.Text=="Staff Wise")
						{
							sw.WriteLine(i.ToString()+"\t"+dr2["memberID"].ToString()+"\t"+GenUtil.TrimLength(dr2["staff_name"].ToString(),20)+"\t"+
								dr2["Book_ID"].ToString()+"\t"+GenUtil.TrimLength(dr2["bookname"].ToString(),30)+"\t"+dr2["staff_type"].ToString()+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Date_Of_Issue"].ToString()))+"\t"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Return_Date"].ToString())));
						}
							
						else
						{
							sw.WriteLine(i.ToString()+"\t"+dr2["memberID"].ToString()+"\t"+GenUtil.TrimLength(dr2["student_fname"].ToString(),20)+"\t"+
								dr2["Book_ID"].ToString()+"\t"+GenUtil.TrimLength(dr2["bookname"].ToString(),30)+"\t"+dr2["student_class"].ToString()+"\t"+
								GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Date_Of_Issue"].ToString()))+"\t"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dr2["Return_Date"].ToString())));
						}
						i++;
					}
					dr2.Close();
					sw.Close();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					CreateLogFiles.ErrorLog(" Form :IssueBookReport.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				
			}

		}
	}
}
