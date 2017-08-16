
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
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
using eschool.Classes;
using eschool;
using RMG;


namespace eschool.Modules.Library
{
	/// <summary>
	/// Summary description for BooksInformationReport.
	/// </summary>
	public class BooksInformationReport : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton btnPrint;
		protected System.Web.UI.WebControls.DropDownList Dropsearchopt;
		protected System.Web.UI.WebControls.DropDownList Dropvalue;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.DataGrid BookReportGrid;
		protected System.Web.UI.WebControls.TextBox txtbookid;
		protected System.Web.UI.HtmlControls.HtmlButton Button2;
		public  int i=1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.HtmlControls.HtmlButton Button3;
		protected System.Web.UI.WebControls.Panel pangrid;
		
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
				CreateLogFiles.ErrorLog (" Form : BookInformation_Report.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : BookInformation_Report.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				DataSet ds=new DataSet();
				if(!Page.IsPostBack)
				{
					Txtfdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					ds=obj.ShowBookInformation();
					BookReportGrid.DataSource=ds;
					BookReportGrid.Visible=false;
					BookReportGrid.DataBind();
					CreateLogFiles.ErrorLog("Form : BooksInformationReprot.aspx,Method  Page_Load,  Books Information Report Viewed,  Userid:  "+ pass   );			
			 
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="1";
					string SubModule="12";
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
				CreateLogFiles.ErrorLog("Form : BooksInformationReprot.aspx,Method  Page_Load,  Exception :  "+ex.Message+",  Userid:  "+ pass   );					
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
			
			this.Dropsearchopt.SelectedIndexChanged += new System.EventHandler(this.Dropsearchopt_SelectedIndexChanged);
			this.BookReportGrid.SelectedIndexChanged += new System.EventHandler(this.BookReportGrid_SelectedIndexChanged);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Button3.ServerClick += new System.EventHandler(this.Button3_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void BookReportGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{   
			try
			{
     	        BookReportGrid.EditItemIndex=(int)e.Item .ItemIndex ;
				DataBind();
			}
			catch(Exception ex)
			{
		    	CreateLogFiles.ErrorLog("Form : BooksInformationReport.aspx,Method  BookReportGrid_EditCommand,  Exception :  "+ex.Message+",    Userid:  "+ pass   );	
			}
		}

		/// <summary>
		/// this Method not in use.
		/// </summary>
		private void BookReportGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				BookReportGrid .EditItemIndex =-1;
				DataBind();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : BooksInformationReport.aspx,Method  BookReportGrid_CancelCommand,  Exception :  "+ex.Message+",    Userid:  "+ pass   );	
			}
		}

		/// <summary>
		/// this Method use to paging of the datagrid.	
		/// </summary>
		public void BookReportGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		 
			try
			{
				string fdate=GenUtil.str2MMDDYYYY(Txtfdate.Text);
				string todate=GenUtil.str2MMDDYYYY(Txttodate.Text);
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				DataView dv=new DataView();
				dv=obj.ShowBookInfo(Dropsearchopt.SelectedItem.Text,Dropvalue.SelectedItem.Text); 
				BookReportGrid.DataSource=dv;
				BookReportGrid.DataBind();
				BookReportGrid .CurrentPageIndex =(int)e.NewPageIndex ;
				DataBind ();
				i=BookReportGrid .CurrentPageIndex*10;
				i++;
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : BookinformationReport.aspx,Method  BookReportGrid_PageIndexChanged,  Exception :  "+ex.Message+",    Userid:  "+ pass   );	
			}
		}

		/// <summary>
		/// this Method not in use.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				Response .Redirect("../../PrintPreview/BooklistPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : BookinformationReport.aspx,Method  BtnPrint_Click,  Exception :  "+ex.Message+",    Userid:  "+ pass   );
			}
		}

		/// <summary>
		/// Method for sending text file to the printer and then issueing the print command.
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
					CreateLogFiles.ErrorLog("Form:LY_PS_SalesReport.aspx,Class:InventoryClass.cs,Method:btnPrint_Click    LY_PS_Sales Report  Printed"+"  userid  ");
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BookInformationReport.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BookInformationReport.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
    			} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
		
			} 
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
								
			}

		}

    	/// <summary>
		/// Method for writing the Book information Report to the text file and save into the eschoolprintservices folder on homedrive. 
		/// data fetch from stock_table. 
		/// </summary>
		private void btnPrint_ServerClick(object sender, System.EventArgs e)
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BookDetailsReport.txt";
			StreamWriter sw = new StreamWriter(path);
			sw.Write((char)27);
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);
			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);							
			sw.Write((char)27);
			sw.Write((char)15);			
			sw.WriteLine("						===================");
			sw.WriteLine("						  BOOK    REPORT");
			sw.WriteLine("						===================");
		    string info1="";
			info1 = "                  {0,-15:S}  {1,-13:S}                       {2,-10:S}  {3,-20:S}";
			if(Dropsearchopt .SelectedIndex==0)
				sw.WriteLine(info1,"Search Option","All","All");
			else
				sw.WriteLine(info1,"Search By:-",Dropsearchopt.SelectedItem.Text,"Option:-",Dropvalue.SelectedItem.Text);
			sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
			sw.WriteLine("|Book ID|            Book Name                   |  Sub Name  |  Author Name   | Publisher Name | Price  |Purc. date|RNo|Qty|  Remark   |");
			sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
			//             1234678 1234567890123456789012345678901234567890 123456789012 1234567890123456 1234567890123456 12345678 1234567890 123 123 12345678901	
			info = " {0,-8:S}{1,-40:S} {2,-12:S} {3,-16:S} {4,-16:S} {5,8:S} {6,-10:S} {7,3:S} {8,3:S} {9,-11:S}  ";
			try
			{
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql="";
				if(Dropsearchopt.SelectedIndex!=0 && Dropvalue.SelectedIndex!=0)
				{
					if(Dropsearchopt.SelectedItem.Text.Equals("Book Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where bookname='"+Dropvalue.SelectedItem.Text+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Rack Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where rackno='"+Dropvalue.SelectedItem.Text+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Subject Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where subname='"+Dropvalue.SelectedItem.Text+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Remark Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where remark='"+Dropvalue.SelectedItem.Text+"'";
					else
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table order by bookname";
				}
				else
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table";
				SqlDtr=obj1.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					    sw.WriteLine (info,SqlDtr["Book_ID"].ToString(),
						GenUtil.TrimLength(SqlDtr["bookname"].ToString(),40),
						GenUtil.TrimLength(SqlDtr["subname"].ToString(),12),
						GenUtil.TrimLength(SqlDtr["aname"].ToString(),16),
						GenUtil.TrimLength(SqlDtr["pname"].ToString(),16),
						SqlDtr["price"].ToString(),
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["pdate"].ToString())),
						SqlDtr["rackno"].ToString(),
						SqlDtr["qty"].ToString(),
						SqlDtr["remark"].ToString()
						);
				}
				SqlDtr.Close ();
				sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
				sw.Close ();							
				Print();
				CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  btnPrint_ServerClick,  Book Information Report Printed , Userid :  "+ pass   );		
 											 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  btnPrint_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for writing the Book information Report to the text file and save into the eschoolprintservices folder on homedrive. 
		/// </summary>
		private void Dropsearchopt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				pangrid.Visible=false;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="";
				i=1;
				txtbookid.Text="";
				Dropvalue.Enabled=true;
				Dropvalue.Items.Clear();
				Dropvalue.Items.Add("Select");
				if(Dropsearchopt.SelectedItem.Text.Equals("Book Wise"))
				{
					Dropvalue.Visible=false;
					txtbookid.Visible=true;
				}
				else if(Dropsearchopt.SelectedItem.Text.Equals("Rack Wise"))
				{
					//str="select  distinct (cast(rackno as int)) from stock_table order by  cast(rackno as int) asc "; //add by vikas sharma 29.10.07
					str="select  distinct (cast(rackno as varchar)) from stock_table order by  cast(rackno as varchar) asc "; //add by vikas sharma 29.10.07
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropvalue.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					Dropvalue.Visible=true;
					txtbookid.Visible=false;
				}
				else if(Dropsearchopt.SelectedItem.Text.Equals("Subject Wise"))
				{
					str="select distinct subname from stock_table order by subname";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropvalue.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					Dropvalue.Visible=true;
					txtbookid.Visible=false;
				}
				else if(Dropsearchopt.SelectedItem.Text.Equals("Remark Wise"))
				{
					str="select distinct remark from stock_table order by remark";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						Dropvalue.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					Dropvalue.Visible=true;
					txtbookid.Visible=false;
				}
				else
				{
					Dropvalue.Enabled=false;
					Dropvalue.Visible=true;
					txtbookid.Visible=false;
					Dropvalue.Items.Add("All");
					Dropvalue.SelectedIndex=1;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : BooksInformationReprot.aspx,Method  Search_ServerClick,  Books Information Report Viewed, Exception"+ex.Message+  "Userid:  "+ pass   );						 	
			}
		}

		private void Dropvalue_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to show the report data fetch from stock_table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
				string fdate=GenUtil.str2MMDDYYYY(Txtfdate.Text);
				string todate=GenUtil.str2MMDDYYYY(Txttodate.Text);
				string sql="";
				i=1;
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				DataView dv;
				BookReportGrid.CurrentPageIndex =0;
				
				if(Dropsearchopt.SelectedItem.Text.Equals("Book Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where book_id='"+txtbookid.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Rack Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where rackno='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Subject Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where subname='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Remark Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where remark='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' order by bookname";

				SqlDataAdapter Adt=new SqlDataAdapter(sql,cn);
				DataSet ds=new DataSet();
				Adt.Fill(ds);
				DataTable dt=ds.Tables[0];
				dv=new DataView(dt);

				if(dv.Count!=0)
				{
					BookReportGrid.DataSource=dv;
					BookReportGrid.Visible=true;
					pangrid.Visible=true;
					BookReportGrid.DataBind();
				}
				else
				{
					BookReportGrid.Visible=false;
					pangrid.Visible=false;
					MessageBox.Show("Data Not Found");
				}
				CreateLogFiles.ErrorLog("Form : BooksInformationReprot.aspx,Method  Page_Load,  Books Information Report Viewed,  Userid:  "+ pass   );						 	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : BooksInformationReprot.aspx,Method  Search_ServerClick,  Books Information Report Viewed, Exception"+ex.Message+  "Userid:  "+ pass   );						 	
			}
		}

		private void BookReportGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Button2_ServerClick(object sender, System.EventArgs e)
		{
			
		}
        
		/// <summary>
		/// this method use to generate report in to .xls formate.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string strExcelPath  = home_drive+"\\eschool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eschool_ExcelFile\BookDetailsReport.xls";
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BookDetailsReport.txt";
				StreamWriter sw = new StreamWriter(path);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);							
				sw.Write((char)27);
				sw.Write((char)15);			
				sw.WriteLine("						===================");
				sw.WriteLine("						  BOOK    REPORT");
				sw.WriteLine("						===================");
				string info1="";
				info1 = "                  {0,-15:S}  {1,-13:S}                       {2,-10:S}  {3,-20:S}";
				if(Dropsearchopt .SelectedIndex==0)
					sw.WriteLine(info1,"Search Option","All","All");
				else
					sw.WriteLine(info1,"Search By:-",Dropsearchopt.SelectedItem.Text,"Option:-",Dropvalue.SelectedItem.Text);
				//sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
				sw.WriteLine("|Book ID\tBook Name\tSub Name\tAuthor Name\tPublisher Name\tPrice\tPurc. date\tRNo\tQty\tRemark");
				//sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
				//             1234678 1234567890123456789012345678901234567890 123456789012 1234567890123456 1234567890123456 12345678 1234567890 123 123 12345678901	
				info = " {0,-8:S}{1,-40:S} {2,-12:S} {3,-16:S} {4,-16:S} {5,8:S} {6,-10:S} {7,3:S} {8,3:S} {9,-11:S}  ";
			
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql="";
				if(Dropsearchopt.SelectedItem.Text.Equals("Book Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where book_id='"+txtbookid.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Rack Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where rackno='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Subject Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where subname='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else if(Dropsearchopt.SelectedItem.Text.Equals("Remark Wise"))
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where remark='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
				else
					sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' order by bookname";
				SqlDtr=obj1.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					sw.WriteLine (SqlDtr["Book_ID"].ToString()+"\t"+
						GenUtil.TrimLength(SqlDtr["bookname"].ToString(),40)+"\t"+
						GenUtil.TrimLength(SqlDtr["subname"].ToString(),12)+"\t"+
						GenUtil.TrimLength(SqlDtr["aname"].ToString(),16)+"\t"+
						GenUtil.TrimLength(SqlDtr["pname"].ToString(),16)+"\t"+
						SqlDtr["price"].ToString()+"\t"+
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["pdate"].ToString()))+"\t"+
						SqlDtr["rackno"].ToString()+"\t"+
						SqlDtr["qty"].ToString()+"\t"+
						SqlDtr["remark"].ToString()
						);
				}
				SqlDtr.Close ();
				sw.Close ();
	
			}
			catch( Exception ex)
			{

			}

		}
		
		/// <summary>
		/// this method use to generate report in to txt fromat.
		/// </summary>
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BookInformationReport.txt";
			StreamWriter sw = new StreamWriter(path);
			sw.Write((char)27);
			sw.Write((char)67);
			sw.Write((char)0);
			sw.Write((char)12);
			sw.Write((char)27);
			sw.Write((char)78);
			sw.Write((char)5);							
			sw.Write((char)27);
			sw.Write((char)15);			
			sw.WriteLine("						===================");
			sw.WriteLine("						  BOOK    REPORT");
			sw.WriteLine("						===================");
			string info1="";
			info1 = "                  {0,-15:S}  {1,-13:S}                       {2,-10:S}  {3,-20:S}";
			if(Dropsearchopt .SelectedIndex==0)
				sw.WriteLine(info1,"Search Option","All","All");
			else
				sw.WriteLine(info1,"Search By:-",Dropsearchopt.SelectedItem.Text,"Option:-",Dropvalue.SelectedItem.Text);
			sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
			sw.WriteLine("|Book ID|            Book Name                   |  Sub Name  |  Author Name   | Publisher Name | Price  |Purc. date|RNo|Qty|  Remark   |");
			sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
			//             1234678 1234567890123456789012345678901234567890 123456789012 1234567890123456 1234567890123456 12345678 1234567890 123 123 12345678901	
			info = " {0,-8:S}{1,-40:S} {2,-12:S} {3,-16:S} {4,-16:S} {5,8:S} {6,-10:S} {7,3:S} {8,3:S} {9,-11:S}  ";
			try
			{
				LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr;
				string sql="";
					if(Dropsearchopt.SelectedItem.Text.Equals("Book Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where book_id='"+txtbookid.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Rack Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where rackno='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Subject Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where subname='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					else if(Dropsearchopt.SelectedItem.Text.Equals("Remark Wise"))
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where remark='"+Dropvalue.SelectedItem.Text+"' and pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
					else
						sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where pdate between '"+GenUtil.str2MMDDYYYY(Txtfdate.Text)+"' and '"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"' order by bookname";
				SqlDtr=obj1.GetRecordSet(sql);
				while(SqlDtr.Read ())
				{
					sw.WriteLine (info,SqlDtr["Book_ID"].ToString(),
						GenUtil.TrimLength(SqlDtr["bookname"].ToString(),40),
						GenUtil.TrimLength(SqlDtr["subname"].ToString(),12),
						GenUtil.TrimLength(SqlDtr["aname"].ToString(),16),
						GenUtil.TrimLength(SqlDtr["pname"].ToString(),16),
						SqlDtr["price"].ToString(),
						GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["pdate"].ToString())),
						SqlDtr["rackno"].ToString(),
						SqlDtr["qty"].ToString(),
						GenUtil.TrimLength(SqlDtr["remark"].ToString(),10)
						);
				}
				SqlDtr.Close ();
				sw.WriteLine("+-------+----------------------------------------+------------+----------------+----------------+--------+----------+---+---+-----------+");
				sw.Close ();							
				Print();
				CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  btnPrint_ServerClick,  Book Information Report Printed , Userid :  "+ pass   );		
 											 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :BookInformationReport.aspx,Method  btnPrint_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call convertintoexcel() function.
		/// </summary>
		private void Button3_ServerClick(object sender, System.EventArgs e)
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
	}
}
