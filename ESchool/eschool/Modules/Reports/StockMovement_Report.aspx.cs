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
using DBOperations;

namespace eschool.Modules.Reports
{
	/// <summary>
	/// Summary description for StockMovement_Report.
	/// </summary>
	public class StockMovement_Report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TxtDateTo;
		protected System.Web.UI.WebControls.Button BtnShow;
		protected System.Web.UI.WebControls.Button BtnPrint;
		protected System.Web.UI.WebControls.DropDownList DropTrType;
		//protected System.Web.UI.WebControls.DataGrid Gridreceipt;
		//protected System.Web.UI.WebControls.DataGrid Gridissue;
		protected System.Web.UI.WebControls.DataGrid GridAll;
		protected System.Web.UI.WebControls.Button btnexcel;
		protected System.Web.UI.WebControls.TextBox TxtDatefrom;
		protected System.Web.UI.WebControls.DataGrid GridOpenig;
		protected System.Web.UI.WebControls.Panel panlopen;
		protected System.Web.UI.WebControls.DataGrid GridReceipt;
		protected System.Web.UI.WebControls.Panel panlreceipt;
		protected System.Web.UI.WebControls.DataGrid GridIssue;
		protected System.Web.UI.WebControls.Panel Panlissue;
		protected System.Web.UI.WebControls.DataGrid GridClosing;
		protected System.Web.UI.WebControls.Panel Panlclose;
		protected System.Web.UI.WebControls.Panel Panlall;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					TxtDatefrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtDateTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;

					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
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
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{

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
			this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to get date in ddmmyyyy format but return mmddyyy formate.
		/// </summary>
		private DateTime getdate(string dat,bool to)
		{
			string[] dt=dat.Split(new char[]{'/'},dat.Length);
			if(to)
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
			else
				return new DateTime(Int32.Parse(dt[2]),Int32.Parse(dt[1]),Int32.Parse(dt[0]));
		}

		/// <summary>
		/// this method use to show report in grid. first get stock id from stock_movement and stock_master table.after that call sp_stockmovement procedure
		/// and pass with stock id. this procedure create stkmv table and insert record.after that dataset fill from stkmv table.
		/// </summary>
		private void BtnShow_Click(object sender, System.EventArgs e)
		{
			try
			{
				int x=0;
				object op=null;	
				string sql="";
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dr;
				scon=new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				
				//if(DropTrType.SelectedItem.Text=="Opening Balance")
					//sql="select distinct (sm.itemname),sm.itemcategory,Smt.opening from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select min(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
					//  sql="select distinct (sm.itemname),sm.itemcategory,Smt.opening from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select min(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				//else if(DropTrType.SelectedItem.Text=="Receipt")
				//	sql="select sm.itemname,sm.itemcategory,Smt.recieved from stockMaster sm, stock_movement smt where tran_no like '%R%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				//else if(DropTrType.SelectedItem.Text=="Issue")
				//	sql="select sm.itemname,sm.itemcategory,Smt.Issued from stockMaster sm, stock_movement smt where tran_no like '%I%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				//else if(DropTrType.SelectedItem.Text=="Closing Balance")
				//	sql="select distinct (sm.itemname),sm.itemcategory,Smt.closing from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select max(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				//else if(DropTrType.SelectedItem.Text=="All")
					//sql="select sm.itemno,smt.itemcategory,smt.itemname,sm.tran_no,sm.tran_date,sm.opening,sm.recieved,sm.issued,sm.closing from stock_movement sm,stockmaster smt where itemno=stockid and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"' order by tran_date";
					sql="select distinct stockid from stock_Movement s,Stockmaster p where s.itemno=p.stockid";
				cmd=new SqlCommand(sql,scon);
				dr=cmd.ExecuteReader();
				//if(dr.HasRows)
				//{
				//	if(DropTrType.SelectedItem.Text=="All")
				//	{
						try
						{
							while(dr.Read())
							{
								dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(dr["stockid"].ToString()),"@fromdate",GenUtil.str2MMDDYYYY(TxtDatefrom.Text),"@todate",GenUtil.str2MMDDYYYY(TxtDateTo.Text));
							}
							dr.Close();
						}
						catch(Exception ex)
						{
                            CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  btnshow_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		   
						}
				//	}
				sql="select * from stkmv";

				SqlDataAdapter da=new SqlDataAdapter(sql,scon);
				DataSet ds=new DataSet();	
				da.Fill(ds,"stkmv");
				DataTable dtcustomer=ds.Tables["stkmv"];
				DataView dv=new DataView(dtcustomer);
				//dv.Sort=strorderby;
				//Cache["strorderby"]=strorderby;
				//grdLeg.DataSource=dv;
				//GridAll.DataSource=dv;
				//if(dv.Count!=0)
				//{
				//	GridAll.DataBind();
				//	GridAll.Visible=true;
				//}
				//else
				//{
				//	GridAll.Visible=false;
				//	MessageBox.Show("Data Not Available");
				//}
				
				
					if(DropTrType.SelectedItem.Text=="Opening Balance")
					{

						panlopen.Visible=true;
                        panlreceipt.Visible=false;
                        Panlissue.Visible=false;
						Panlclose.Visible=false;
						Panlall.Visible=false;
						GridOpenig.DataSource=dv;
						GridOpenig.DataBind();
						GridOpenig.Visible=true;
						GridReceipt.Visible=false;
						GridIssue.Visible=false;
						GridClosing.Visible=false;
						GridAll.Visible=false;						
					}
					else if(DropTrType.SelectedItem.Text=="Receipt")
					{
						panlopen.Visible=false;
						Panlissue.Visible=false;
						Panlclose.Visible=false;
						Panlall.Visible=false;
						panlreceipt.Visible=true;
						GridReceipt.DataSource=dv;
						GridReceipt.DataBind();
						GridOpenig.Visible=false;
						GridReceipt.Visible=true;
						GridIssue.Visible=false;
						GridClosing.Visible=false;
						GridAll.Visible=false;
					}
					else if(DropTrType.SelectedItem.Text=="Issue")
					{
						panlopen.Visible=false;
						panlreceipt.Visible=false;
						Panlissue.Visible=true;
						Panlclose.Visible=false;
						Panlall.Visible=false;
						GridIssue.DataSource=dv;
						GridIssue.DataBind();
						GridOpenig.Visible=false;
						GridReceipt.Visible=false;
						GridIssue.Visible=true;
						GridClosing.Visible=false;
						GridAll.Visible=false;
					}
					else if(DropTrType.SelectedItem.Text=="Closing Balance")
					{
						panlopen.Visible=false;
						panlreceipt.Visible=false;
						Panlissue.Visible=false;
						Panlclose.Visible=true;
						Panlall.Visible=false;
						GridClosing.DataSource=dv;
						GridClosing.DataBind();
						GridOpenig.Visible=false;
						GridReceipt.Visible=false;
						GridIssue.Visible=false;
						GridClosing.Visible=true;
						GridAll.Visible=false;
					}
					else 
					{
						
						panlopen.Visible=false;
						panlreceipt.Visible=false;
						Panlissue.Visible=false;
						Panlclose.Visible=false;
						Panlall.Visible=true;
						GridAll.DataSource=dv;
						GridAll.DataBind();
						GridOpenig.Visible=false;
						GridReceipt.Visible=false;
						GridIssue.Visible=false;
						GridClosing.Visible=false;
						GridAll.Visible=true;
					}
					scon.Dispose();
				//}
				//else
				//{
				//	MessageBox.Show("Data Not Available");
			    //		GridAll.Visible=false;
			    //		return;
			    //	}

				
				// truncate table after use.
				dbobj.Insert_or_Update("truncate table stkmv", ref x);
			}
		    catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for issueing the print command to the printer for printing the text file..
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StockMovement_Report.txt<EOF>");
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
		/// this method use to show report in text file. first get stock id from stock_movement and stock_master table.after that call sp_stockmovement procedure
		/// and pass with stock id. this procedure create stkmv table and insert record.after that data fetch from stkmv table.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				object op=null;	
				string home_drive=Environment.SystemDirectory;
				home_drive=home_drive.Substring(0,2);
				string path=home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StockMovement_Report.Txt";
				StreamWriter sw=new StreamWriter(path);
			    string info = "",des="";
				string sql="";
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dr;
				scon=new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				/*if(DropTrType.SelectedItem.Text=="Opening Balance")
					sql="select distinct (sm.itemname),sm.itemcategory,Smt.opening from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select min(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				else if(DropTrType.SelectedItem.Text=="Receipt")
					sql="select sm.itemname,sm.itemcategory,Smt.recieved from stockMaster sm, stock_movement smt where tran_no like '%R%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				else if(DropTrType.SelectedItem.Text=="Issue")
					sql="select sm.itemname,sm.itemcategory,Smt.Issued from stockMaster sm, stock_movement smt where tran_no like '%I%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				else if(DropTrType.SelectedItem.Text=="Closing Balance")
					sql="select distinct (sm.itemname),sm.itemcategory,Smt.closing from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select max(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				else
					sql="select sm.itemno,smt.itemcategory,smt.itemname,sm.tran_no,sm.tran_date,sm.opening,sm.recieved,sm.issued,sm.closing from stock_movement sm,stockmaster smt where itemno=stockid and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"' order by tran_date";*/
				
				sql="select distinct stockid from stock_Movement s,Stockmaster p where s.itemno=p.stockid";
				cmd=new SqlCommand(sql,scon);
				dr=cmd.ExecuteReader();
				cmd.Dispose();
				des="+-------------------------+-------------------------+------------------------------+";
				//if(dr.HasRows)
				//	{
				try
				{
					while(dr.Read())
					{
						dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(dr["stockid"].ToString()),"@fromdate",getdate(TxtDatefrom.Text,true).Date.ToShortDateString(),"@todate",getdate(TxtDateTo.Text,true).Date.ToShortDateString());
					}
					dr.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  btnshow_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		   
				}
					 
				sql="select * from stkmv";

				cmd=new SqlCommand(sql,scon);
				dr=cmd.ExecuteReader();
				
				
				// sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
					     sw.WriteLine(GenUtil.GetCenterAddr("Stock Movement Report",des.Length));
						if(DropTrType.SelectedItem.Text=="Opening Balance")
						{
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							sw.WriteLine("|      Item Name          |       Category          |      Opening Balance         |");
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							info=" {0,-25:S} {1,-25:S} {2,30:S}";
							while(dr.Read())
							{
								sw.WriteLine(info,dr["Prod_Name"].ToString(),dr["category"].ToString(),dr["op"].ToString());
							}
							dr.Close();
                            sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						}
						else if(DropTrType.SelectedItem.Text=="Receipt")
						{
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							sw.WriteLine("|      Item Name          |       Category          |             Receipt          |");
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							info="{ 0,-25:S} {1,-25:S} {2,30:S}";
							while(dr.Read())
							{
								sw.WriteLine(info,dr["Prod_Name"].ToString(),dr["category"].ToString(),dr["rcpt"].ToString());
							}
							dr.Close();
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						}
						else if(DropTrType.SelectedItem.Text=="Issue")
						{
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							sw.WriteLine("|      Item Name          |       Category          |              Issue           |");
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							info="{ 0,-25:S} {1,-25:S} {2,30:S}";
							while(dr.Read())
							{
								sw.WriteLine(info,dr["Prod_Name"].ToString(),dr["category"].ToString(),dr["Sales"].ToString());
							}
							dr.Close();
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						}
						else if(DropTrType.SelectedItem.Text=="Closing Balance")
						{
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							sw.WriteLine("|      Item Name          |       Category          |      Closing Balance         |");
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
							info="{ 0,-25:S} {1,-25:S} {2,30:S}";
							while(dr.Read())
							{
								sw.WriteLine(info,dr["Prod_Name"].ToString(),dr["category"].ToString(),dr["cs"].ToString());
							}
							dr.Close();
							sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						}
						else 
						{
							sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
							sw.WriteLine("|     Item Name      |      Category      |   Opening  |   Receipt  |    Issue   |   Closing  |");
							sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
							info=" {0,-20:S} {1,-20:S} {2,12:S} {3,12:S} {4,12:S} {5,12:S}";
							while(dr.Read())
							{
								sw.WriteLine(info,dr["Prod_Name"].ToString(),dr["category"].ToString(),dr["op"].ToString(),dr["rcpt"].ToString(),dr["Sales"].ToString(),dr["cs"].ToString());
							}
							dr.Close();
							sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
						}
					sw.Close();
					Print();
					//}
			}
			catch(Exception ex)
			{ 
				CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  ,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to show report in excel file. first get stock id from stock_movement and stock_master table.after that call sp_stockmovement procedure
		/// and pass with stock id. this procedure create stkmv table and insert record.after that fetch data from stkmv table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			object op=null;	
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\Stock_Movement_Report.xls";
				StreamWriter sw = new StreamWriter(path);
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dr;
				scon=new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
			     string sql="";
				/*if(DropTrType.SelectedItem.Text=="Opening Balance")
					
					sql="select distinct (sm.itemname),sm.itemcategory,Smt.opening from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select min(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				else if(DropTrType.SelectedItem.Text=="Receipt")
					
					sql="select sm.itemname,sm.itemcategory,Smt.recieved from stockMaster sm, stock_movement smt where tran_no like '%R%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				else if(DropTrType.SelectedItem.Text=="Issue")
					
					sql="select sm.itemname,sm.itemcategory,Smt.Issued from stockMaster sm, stock_movement smt where tran_no like '%I%' and sm.stockid=smt.itemno and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"'";
				else if(DropTrType.SelectedItem.Text=="Closing Balance")
					
					sql="select distinct (sm.itemname),sm.itemcategory,Smt.closing from stockMaster sm, stock_movement smt  where itemno=stockid  and closing in ( select  closing from  stock_movement  where tran_date in  (select max(tran_date) from stock_movement  where  cast(floor(cast(cast(tran_date as datetime) as float))as datetime) = '"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"' group by itemno))";
				else
					
					sql="select sm.itemno,smt.itemcategory,smt.itemname,sm.tran_no,sm.tran_date,sm.opening,sm.recieved,sm.issued,sm.closing from stock_movement sm,stockmaster smt where itemno=stockid and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)>='"+GenUtil.str2MMDDYYYY(TxtDatefrom.Text).Trim()+"'and cast(floor(cast(cast(tran_date as datetime) as float)) as datetime)<='"+GenUtil.str2MMDDYYYY(TxtDateTo.Text).Trim()+"' order by tran_date";*/
				
				sql="select distinct stockid from stock_Movement s,Stockmaster p where s.itemno=p.stockid";
				cmd=new SqlCommand(sql,scon);
				dr=cmd.ExecuteReader();
				//if(dr.HasRows)
				//{
				try
				{
					while(dr.Read())
					{
						dbobj.ExecProc(OprType.Insert,"sp_stockmovement",ref op,"@id",Int32.Parse(dr["stockid"].ToString()),"@fromdate",getdate(TxtDatefrom.Text,true).Date.ToShortDateString(),"@todate",getdate(TxtDateTo.Text,true).Date.ToShortDateString());
					}
					dr.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  btnshow_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		   
				}
					 
				sql="select * from stkmv";

				cmd=new SqlCommand(sql,scon);
				dr=cmd.ExecuteReader();

					//sw.WriteLine("No.1 Air Force School");
					sw.WriteLine("Stock Movement Report");
					if(DropTrType.SelectedItem.Text=="Opening Balance")
					{
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						sw.WriteLine("Item Name\tCategory\tOpening Balance");
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						while(dr.Read())
						{
							sw.WriteLine(dr["Prod_name"].ToString()+"\t"+dr["category"].ToString()+"\t"+dr["op"].ToString());
						}
						dr.Close();
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
					}
					else if(DropTrType.SelectedItem.Text=="Receipt")
					{
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						sw.WriteLine("Item Name\tCategory\tReceipt");
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						while(dr.Read())
						{
							sw.WriteLine(dr["Prod_Name"].ToString()+"\t"+dr["category"].ToString()+"\t"+dr["rcpt"].ToString());
						}
						dr.Close();
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
					}
					else if(DropTrType.SelectedItem.Text=="Issue")
					{
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						sw.WriteLine("Item Name\tCategory\tIssue");
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						while(dr.Read())
						{
							sw.WriteLine(dr["Prod_Name"].ToString()+"\t"+dr["category"].ToString()+"\t"+dr["Sales"].ToString());
						}
						dr.Close();
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
					}
					else if(DropTrType.SelectedItem.Text=="Closing Balance")
					{
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						sw.WriteLine("Item Name\tCategory\tClosing Balance");
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
						while(dr.Read())
						{
							sw.WriteLine(dr["Prod_name"].ToString()+"\t"+dr["category"].ToString()+"\t"+dr["cs"].ToString());
						}
						dr.Close();
						sw.WriteLine("+-------------------------+-------------------------+------------------------------+");
					}
					else 
					{
						sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
						sw.WriteLine("Item Name\tCategory\tOpening\tReceipt\tIssue\tClosing");
						sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
						while(dr.Read())
						{
							sw.WriteLine(dr["Prod_Name"].ToString()+"\t"+dr["category"].ToString()+"\t"+dr["op"].ToString()+"\t"+dr["rcpt"].ToString()+"\t"+dr["Sales"].ToString()+"\t"+dr["cs"].ToString());
						}
						dr.Close();
						sw.WriteLine("+--------------------+--------------------+------------+------------+------------+------------+");
					}

                  //}
				sw.Close();
			}
			catch(Exception ex)
			{
                 CreateLogFiles.ErrorLog(" Form : StockMovementReport.aspx,Method  ,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void btnexcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method: btnExcel_Click, Bank Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method:btnExcel_Click   Bank Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
				
