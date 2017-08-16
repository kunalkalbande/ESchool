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
using eschool.Classes;
using RMG; 
using System.Data .SqlClient ;
using System.Net; 
using System.Net.Sockets ;
using System.IO ;
using System.Text;
using DBOperations;

namespace eschool.Forms.Reports
{
	/// <summary>
	/// Summary description for CustomerLedger.
	/// </summary>
	public class CustomerLedger : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button cmdrpt;
		protected System.Web.UI.WebControls.Button BtnPrint;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
		protected System.Web.UI.WebControls.DropDownList DropPartyName;
		string pass;
		static string strOrderBy="";
		public double debit_total = 0;
		public double credit_total = 0;
		public string balance = "";
		public string baltype = "";
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.DataGrid CustomerGrid;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DataGrid TotalSales;
		protected System.Web.UI.WebControls.Panel pangrid;
		System.Globalization.NumberFormatInfo  nfi = new System.Globalization.CultureInfo("en-US",false).NumberFormat;
		
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
				CreateLogFiles.ErrorLog(" Form : LedgerReport.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ pass );
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}

			try
			{
				if(! IsPostBack)
				{
					txtDateFrom.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 		
					txtDateTo.Text=DateTime.Now.Day +"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year; 
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="9";
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
					if(View_flag=="0")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
						return;
					}
					#endregion  
					getParties(); 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : LedgerReport.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"  "+ pass );
			}
		}

		/// <summary>
		/// this method use to fetch the parties(customer) and city from customer table and fills the Party name combo.
		/// </summary>
		public void getParties()
		{
			ArrayList Party=new ArrayList();
			SqlDataReader SqlDtr = null;
			///06.10.08 dbobj.SelectQuery("Select Ledger_Name+':' from Ledger_Master order by Ledger_Name" ,ref SqlDtr);
			dbobj.SelectQuery("Select Ledger_Name,ledger_id from Ledger_Master order by Ledger_Name" ,ref SqlDtr);
			while(SqlDtr.Read())
			{
				Party.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1));
			}
			SqlDtr.Close();
			Party.Sort();
			for(int i=0;i<Party.Count;i++)
			{
				DropPartyName.Items.Add(Party[i].ToString());
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
			this.cmdrpt.Click += new System.EventHandler(this.cmdrpt_Click);
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// this checks the validity of filled and selected values before firing a query.
		/// </summary>
		public bool checkValidity()
		{
			string ErrorMessage = "";
			bool flag = true;
			
			if(txtDateFrom.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select From Date\n";
				flag = false;
			}
			if(txtDateTo.Text.Trim().Equals(""))
			{
				ErrorMessage = ErrorMessage + " - Please Select To Date\n";
				flag = false;
			}
			if(DropPartyName.SelectedIndex  == 0)
			{
				ErrorMessage = ErrorMessage + " - Please Select Party Name\n";
				flag = false;
			}
			
			if(flag == false)
			{
				MessageBox.Show(ErrorMessage);
				return false;
			}
			
			if(System.DateTime.Compare(ToMMddYYYY(txtDateFrom.Text.Trim()),ToMMddYYYY(txtDateTo.Text.Trim())) > 0)
			{
				MessageBox.Show("Date From Should be less than Date To");
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// return the data in MM/dd/YYYY format
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
		/// calculates the total debit amount by passing value
		/// </summary>
		protected void TotalDebit(double _debittotal)
		{
			debit_total  += _debittotal; 
		}

		/// <summary>
		/// calculates total credit amount by passing value
		/// </summary>
		protected void TotalCredit(double _credittotal)
		{
			credit_total  += _credittotal; 
		}

		/// <summary>
		/// Its set the last Balance value and called from .aspx page from closing balance template coulumn
		/// </summary>
		protected string setBal(string _balance)
		{
			balance  = _balance; 
			return _balance;
		}

		/// <summary>
		/// Its set the last Balance value and called from .aspx page from closing balance template coulumn
		/// </summary>
		double Balance=0;
		protected string setBalance(string _Bal)
		{
			Balance  += double.Parse(_Bal);
			return GenUtil.strNumericFormat(Balance.ToString());
		}

		/// <summary>
		/// Its set the last Balance value and called from .aspx page from closing balance template coulumn
		/// </summary>
		double Balance1=0;
		protected string setBalance1(string _Debit,string _Credit)
		{
			if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
				Balance1  += double.Parse(_Debit);
			else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
				Balance1  += double.Parse(_Credit);
			return GenUtil.strNumericFormat(Balance1.ToString());
		}

		/// <summary>
		/// Its set last Balance Type and called from .aspx page from closing balance template coulumn
		/// </summary>
		protected string setType(string _baltype)
		{
			baltype  = _baltype; 
			return _baltype;
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		
		public void ItemTotal(object sender,DataGridItemEventArgs e)
		{
			try
			{
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					string trans_no = "";
					if(str.StartsWith("Opening"))
					{
						e.Item.Cells[0].Text = "&nbsp;";
					}
					else
					{
						trans_no = str.Substring(str.IndexOf("(")+1);
						trans_no = trans_no.Substring(0,trans_no.Length-1);
						str = str.Substring(0,str.IndexOf("("));
						e.Item.Cells[0].Text = trans_no ;
						e.Item.Cells[1].Text = str.Trim();
					}
                    
				}
				else if(e.Item.ItemType == ListItemType.Footer)
				{
					e.Item.Cells[5].Text = "(CB) "+balance+" "+baltype;                
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass );
			}
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal2(object sender,DataGridItemEventArgs e)
		{
			try
			{
				/// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					string trans_no = "";
					/// if transaction type is Opening Balance then show the blank value in transaction no.
					if(str.StartsWith("Opening"))
					{
						e.Item.Cells[0].Text = "&nbsp;";
					}
					else
					{
						/// else show take the substring and display the no. in transaction no. and assign the remaining substring to transaction type.
						trans_no = str.Substring(str.IndexOf("(")+1);
						trans_no = trans_no.Substring(0,trans_no.Length-1);
						str = str.Substring(0,str.IndexOf("("));
						e.Item.Cells[0].Text = trans_no ;
						e.Item.Cells[1].Text = str.Trim();
					}
				}
				else if(e.Item.ItemType == ListItemType.Footer)
				{
					e.Item.Cells[5].Text = "(CB) "+GenUtil.strNumericFormat(Balance1.ToString())+" Dr";
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass );
			}
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnItemDataBound"
		/// </summary>
		public void ItemTotal1(object sender,DataGridItemEventArgs e)
		{
			try
			{
				/// If datagrid item is a bound column other than header and footer
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem)  )
				{
					string str = e.Item.Cells[1].Text;
					/// if transaction type is Opening Balance then  do not show the Datagrid1.
					if(str.StartsWith("Opening"))
					{
						Datagrid1.Visible=false;
					}
					else
					{
						SqlDataReader SqlDtr=null;
						dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
						if(SqlDtr.Read())
						{
							Ledger_ID = SqlDtr.GetValue(0).ToString();  
						}
						SqlDtr.Close();
						dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
						string bt="";
						string bl="";
						if(SqlDtr.Read())
						{
							bt=SqlDtr.GetValue(5).ToString();
							bl=SqlDtr.GetValue(4).ToString();
						}
						if(bt.Equals("Dr"))
						{
							e.Item.Cells[3].Text = GenUtil.strNumericFormat(bl);
							e.Item.Cells[4].Text = "0.00";
						}
						else
						{
							e.Item.Cells[4].Text = GenUtil.strNumericFormat(bl);
							e.Item.Cells[3].Text = "0.00";
						}
						e.Item.Cells[0].Text = "&nbsp;";
						e.Item.Cells[1].Text = "Opening Balance";
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass );
			}
		}

		/// <summary>
		/// This event occurres after pressing the view button.
		/// </summary>
		private void cmdrpt_Click(object sender, System.EventArgs e)
		{
			try
			{
				///Checks the validity of inputs.
				if(!checkValidity())
				{
					return;
				}
				pangrid.Visible=true;
				strOrderBy = "Entry_Date ASC";
				Session["Column"] = "Entry_Date";
				Session["Order"] = "ASC";
				BindTheData();
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:cmdrpt_Click(),   User_ID:"+ pass ); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:cmdrpt_Click()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass ); 
			}
		}
		string party_name = "";
		string Ledger_ID = "";
		/// <summary>
		/// To bind the datagrid and display the information by given order and display the data grid.
		/// </summary>
		public void BindTheData()
		{
			try
			{
				SqlConnection sqlcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				SqlConnection sqlcon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				SqlDataReader SqlDtr = null;
				string  sql="";
				int Flag=0;
				string drop_value = DropPartyName.SelectedItem.Text.Trim();
				if(drop_value.IndexOf(":")>0)
				{
					string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
					if(strArr.Length > 0)
					{
						party_name = strArr[0].Trim();
					}
					dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();  
					}
					SqlDtr.Close();
					Flag=0;
					sql="Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' order by Entry_Date desc"; 
				}
				SqlDataAdapter da=new SqlDataAdapter(sql,sqlcon);
				DataSet ds=new DataSet();
				da.Fill(ds,"AccountsLedgerTable");
				DataTable dtcustomer=ds.Tables["AccountsLedgerTable"]; 
				DataView dv=new DataView(dtcustomer);
				dv.Sort=strOrderBy;
				Cache["strorderby"]=strOrderBy;
				TotalSales.Visible=false;
				if(Flag==0)
				{
					Datagrid1.DataSource=dv;
					if(dv.Count!=0)
						
					{
						Datagrid1.DataBind();
						Datagrid1.Visible=true;
						CustomerGrid.ShowHeader=false;	
					}
					else
					{
						Datagrid1.Visible=false;
						CustomerGrid.ShowHeader=true;
	
					}
				}
				else
				{
					Datagrid1.Visible=false;
					CustomerGrid.Visible=false;
					CustomerGrid.ShowHeader=false;
					TotalSales.DataSource=dv;
					if(dv.Count!=0)
					{
						TotalSales.DataBind();
						TotalSales.Visible=true;
					}
					else
					{
						TotalSales.Visible=false;
						MessageBox.Show("Data Not Available");
						pangrid.Visible=false;
					}
				}
				
				if(Flag == 0)
				{
					string  sql1="Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"'";
					SqlDataAdapter da1=new SqlDataAdapter(sql1,sqlcon1);
					
					DataSet ds1=new DataSet();	
					da1.Fill(ds1," AccountsLedgerTable");
					DataTable dtcustomer1=ds1.Tables[" AccountsLedgerTable"]; 
					DataView dv1=new DataView(dtcustomer1);
					dv1.Sort=strOrderBy;
					Cache["strOrderBy"]=strOrderBy;
					CustomerGrid.DataSource=dv1;
					if(dv1.Count==0)
						
					{
						CustomerGrid.Visible=false;
						Datagrid1.Visible=false;
						MessageBox.Show("Data not available");
						pangrid.Visible=false;
						return;
					}
					else
					{
						CustomerGrid.DataBind();
						CustomerGrid.Visible=true;
					}
				}
			
				sqlcon.Dispose();
				sqlcon1.Dispose();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:cmdrpt_Click()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass ); 
			}
			
		}

		/// <summary>
		/// Its calls from data grid  and define in the data grid tag parameter "OnSortCommand"
		/// </summary>
		public void SortCommand_Click(object sender,DataGridSortCommandEventArgs e)
		{
			try
			{
				///Check to see if same column clicked again
				if(e.SortExpression.ToString().Equals(Session["Column"]))
				{
					if(Session["Order"].Equals("ASC"))
					{
						strOrderBy=e.SortExpression.ToString() +" DESC";
						Session["Order"]="DESC";
					}
					else
					{
						strOrderBy=e.SortExpression.ToString() +" ASC";
						Session["Order"]="ASC";
					}
				}
				///Different column selected, so default to ascending order
				else
				{
					strOrderBy = e.SortExpression.ToString() +" ASC";
					Session["Order"] = "ASC";
				}
				Session["Column"] = e.SortExpression.ToString();
				BindTheData();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method : ShortCommand_Click,  EXCEPTION  "+ex.Message+" userid ");
			}
		}

		/// <summary>
		/// This method use to create ledger report in text format. in this method parties name fetch from ledger_master table. and its transaction fetch from AccountsLedgerTable.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				/// checks for input validity.
				if(!checkValidity())
				{
					return;
				}
				/// Get the home drive and opens the file CustomerLedger.txt in eschoolPrintServices folder.
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				//string path = home_drive+@"\Inetpub\wwwroot\eschool\eschoolPrintServices\Ledger.txt";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\LedgerReport.txt";
				
				StreamWriter sw = new StreamWriter(path);
				string info = "";		
				SqlDataReader SqlDtr = null;
				string drop_value = DropPartyName.SelectedItem.Text.Trim();  
				string party_name = "";
				string Ledger_ID = "";
			    string trans_type = "";
				string trans_id = "";
				double debit = 0;
				double credit = 0;
				string bal = "";
				string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
				if(strArr.Length > 0)
				{
					party_name = strArr[0].Trim(); 
					
					dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 

					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();  
					}
					SqlDtr.Close();
				}
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				/// Condensed
				sw.Write((char)27);
				sw.Write((char)15);
				sw.WriteLine("");
				string des="--------------------------------------------------------------------------------";
				sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr(" LEDGER REPORT From "+txtDateFrom.Text+" to "+txtDateTo.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("=============================================",des.Length));
				sw.WriteLine("");
				sw.WriteLine("Party Name: "+DropPartyName.SelectedItem.Text);
				sw.WriteLine("Remark    : (CB) Closing Balance");
				sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
				sw.WriteLine("|Trans.| Transaction    |   Date   |   Debit   |   Credit  |  Closing Balance  | ");
				sw.WriteLine("|  ID  |     Type       |          |           |           |                   |");  
				sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
				info = " {0,-6:S} {1,-16:S} {2,-10:S} {3,11:F} {4,11:F} {5,19:S}";
 				string bt="";
				string bl="";
				string dbt="";
				string cdt="";
				if(Datagrid1.Items.Count!=0)
				{
					dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();  
					}
					SqlDtr.Close();
						
					dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
					
					if(SqlDtr.Read())
					{
						bt=SqlDtr.GetValue(5).ToString();
						bl=SqlDtr.GetValue(4).ToString();
					}
					
					if(bt.Equals("Dr"))
					{
						dbt = GenUtil.strNumericFormat(bl);
						cdt = "0.00";
					}
					else
					{
						cdt = GenUtil.strNumericFormat(bl);
						dbt = "0.00";
					}
					sw.WriteLine(info,"","Opening Balance",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr.GetValue(0).ToString())),dbt,cdt,bl+" "+bt);
				}
				string BalType="";
				SqlDtr.Close();
				if(TotalSales.Visible==false)
				{
					dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"],ref SqlDtr); 
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							trans_type = SqlDtr["Particulars"].ToString();
							if(trans_type.StartsWith("Opening"))
							{
								trans_id = "";
							}
							else
							{
								trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
								trans_id = trans_id.Substring(0,trans_id.Length-1);
								trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
							}

							debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
							credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
							bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
							sw.WriteLine(info,trans_id,
								GenUtil.TrimLength(trans_type,16),
								GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
								GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
								GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
								GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString()); 
						}	
					}
					else
					{
						MessageBox.Show("Data not available" );
						return;
					}
				}
				else
				{
					if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where (Particulars like 'Sales Invoice (%' or Particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								trans_type = SqlDtr["Particulars"].ToString();
								if(trans_type.StartsWith("Opening"))
								{
									trans_id = "";
								}
								else
								{
									trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
									trans_id = trans_id.Substring(0,trans_id.Length-1);
									trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
								}
								
								BalType=SqlDtr["Bal_Type"].ToString();
									sw.WriteLine(info,trans_id,
									GenUtil.TrimLength(trans_type,16),
									GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
									GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
									GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
									GenUtil.strNumericFormat(setBalance(SqlDtr["Debit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
							}	
						}
					}
					else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
					{
						dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								trans_type = SqlDtr["Particulars"].ToString();
								if(trans_type.StartsWith("Opening"))
								{
									trans_id = "";
								}
								else
								{
									trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
									trans_id = trans_id.Substring(0,trans_id.Length-1);
									trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
								}
								
								debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
								credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
								bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
  
								BalType=SqlDtr["Bal_Type"].ToString();
								sw.WriteLine(info,trans_id,
									GenUtil.TrimLength(trans_type,16),
									GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString())), 
									GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString()),
									GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString()),
									GenUtil.strNumericFormat(setBalance(SqlDtr["Credit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
							}	
						}
					}
				}
				SqlDtr.Close ();
				sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
				if(DropPartyName.SelectedItem.Text.Equals("Sales A/C") || DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
					sw.WriteLine(info,"Total:","","","","","(CB)"+GenUtil.strNumericFormat(Balance.ToString())+" "+BalType);
				else
					sw.WriteLine(info,"Total:","","","","","(CB)"+bal);
				sw.WriteLine("+------+----------------+----------+-----------+-----------+-------------------+");
				sw.Close(); 

				Print(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:BtnPrint_Click()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass );  
			}
		}

		/// <summary>
		/// This method use to create ledger report in excel format. in this method parties name fetch from ledger_master table. and its transaction fetch from AccountsLedgerTable.
		/// </summary>
		public void ConvertToExcel()
		{
			InventoryClass obj=new InventoryClass();
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2); 
			string strExcelPath  = home_drive+"\\eschool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eschool_ExcelFile\LedgerReport.xls";
			StreamWriter sw = new StreamWriter(path);
			SqlDataReader SqlDtr=null;
			string drop_value = DropPartyName.SelectedItem.Text.Trim();  
			string party_name = "";
			string Ledger_ID = "";
			string trans_type = "";
			string trans_id = "";
			double debit = 0;
			double credit = 0;
			string bal = "";
			string[] strArr = drop_value.Split(new char[] {':'},drop_value.Length);
			if(strArr.Length > 0)
			{
				party_name = strArr[0].Trim(); 
			}
			
			dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 

			if(SqlDtr.Read())
			{
				Ledger_ID = SqlDtr.GetValue(0).ToString();  
			}
			SqlDtr.Close();
			//sw.WriteLine(" LEDGER REPORT From Date\t"+txtDateFrom.Text+"\t To Date\t"+txtDateTo.Text);
			sw.WriteLine("               LEDGER REPORT From Date "+txtDateFrom.Text+" To Date "+txtDateTo.Text);
			//sw.WriteLine("To Date\t"+txtDateTo.Text);
			sw.WriteLine("Party Name\t"+DropPartyName.SelectedItem.Text);
			sw.WriteLine("Trans. ID\tTransaction Type\tDate\tDebit\tCredit\tClosing Balance");
			string bt="";
			string bl="";
			string dbt="";
			string cdt="";
			if(Datagrid1.Items.Count!=0)
			{
				dbobj.SelectQuery("Select top 1 Ledger_ID from Ledger_Master where Ledger_Name = '"+party_name+"'",ref SqlDtr); 
				if(SqlDtr.Read())
				{
					Ledger_ID = SqlDtr.GetValue(0).ToString();  
				}
				SqlDtr.Close();
				dbobj.SelectQuery("Select top 1 Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) < '"+ToMMddYYYY(txtDateFrom.Text)+"' order by Entry_Date desc",ref SqlDtr); 
				if(SqlDtr.Read())
				{
					bt=SqlDtr.GetValue(5).ToString();
					bl=SqlDtr.GetValue(4).ToString();
				}
				if(bt.Equals("Dr"))
				{
					dbt = GenUtil.strNumericFormat(bl);
					cdt = "0.00";
				}
				else
				{
					cdt = GenUtil.strNumericFormat(bl);
					dbt = "0.00";
				}
				sw.WriteLine("\tOpening Balance\t"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr.GetValue(0).ToString()))+"\t"+dbt+"\t"+cdt+"\t"+bl+" "+bt);
			}
			SqlDtr.Close();
			string BalType="";
			if(TotalSales.Visible==false)
			{
				dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Ledger_ID = "+Ledger_ID+" and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strOrderBy"],ref SqlDtr); 
				if(SqlDtr.HasRows)
				{
					while(SqlDtr.Read())
					{
						trans_type = SqlDtr["Particulars"].ToString();
						if(trans_type.StartsWith("Opening"))
							trans_id = "";
						else
						{
							trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
							trans_id = trans_id.Substring(0,trans_id.Length-1);
							trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
						}
						debit += Double.Parse(SqlDtr["Debit_Amount"].ToString());  
						credit += Double.Parse(SqlDtr["Credit_Amount"].ToString());
						bal = GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString();
						sw.WriteLine(trans_id+"\t"+
							trans_type+"\t"+
							GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
							GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
							GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
							GenUtil.strNumericFormat(SqlDtr["Balance"].ToString())+" "+SqlDtr["Bal_Type"].ToString()); 
					}	
				}
			}
			else
			{
				if(DropPartyName.SelectedItem.Text.Equals("Sales A/C"))
				{
					dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where (Particulars like 'Sales Invoice (%' or Particulars like 'Sales in Cash(%') and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							trans_type = SqlDtr["Particulars"].ToString();
							if(trans_type.StartsWith("Opening"))
							{
								trans_id = "";
							}
							else
							{
								trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
								trans_id = trans_id.Substring(0,trans_id.Length-1);
								trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
							}
							BalType=SqlDtr["Bal_Type"].ToString();
							sw.WriteLine(trans_id+"\t"+
								trans_type+"\t"+
								GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(setBalance(SqlDtr["Debit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
						}	
					}
				}
				else if(DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
				{
					dbobj.SelectQuery("Select Entry_Date,Particulars,Debit_Amount,Credit_Amount,Balance, Bal_Type,(Balance-Debit_Amount+Credit_Amount) opb from AccountsLedgerTable where Particulars like 'Purchase Invoice (%' and cast(floor(cast(Entry_Date as float)) as datetime) >= '"+ToMMddYYYY(txtDateFrom.Text)+"' and cast(floor(cast(Entry_Date as float)) as datetime) <= '"+ToMMddYYYY(txtDateTo.Text)+"' order by "+Cache["strorderby"],ref SqlDtr); 
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							trans_type = SqlDtr["Particulars"].ToString();
							if(trans_type.StartsWith("Opening"))
							{
								trans_id = "";
							}
							else
							{
								trans_id = trans_type.Substring(trans_type.IndexOf("(")+1);
								trans_id = trans_id.Substring(0,trans_id.Length-1);
								trans_type = trans_type.Substring(0,trans_type.IndexOf("(")).Trim();  
							}
							BalType=SqlDtr["Bal_Type"].ToString();
							sw.WriteLine(trans_id+"\t"+
								trans_type+"\t"+
								GenUtil.str2DDMMYYYY (trimDate(SqlDtr["Entry_Date"].ToString()))+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Debit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(SqlDtr["Credit_Amount"].ToString())+"\t"+
								GenUtil.strNumericFormat(setBalance(SqlDtr["Credit_Amount"].ToString()))+" "+SqlDtr["Bal_Type"].ToString()); 
						}	
					}
				}
			}
			SqlDtr.Close ();
			if(DropPartyName.SelectedItem.Text.Equals("Sales A/C") || DropPartyName.SelectedItem.Text.Equals("Purchase A/C"))
				sw.WriteLine("Total\t\t\t\t\t"+"(CB)"+GenUtil.strNumericFormat(Balance.ToString())+" "+BalType);
			else
				//sw.WriteLine("Total\t\t\t\t\t"+"(CB)"+bal);
				sw.WriteLine("Total\t\t\t\t"+"(CB)\t"+bal);
			dbobj.Dispose();
			sw.Close();
		}

		/// <summary>
		///  This function displays returns the date from passed datetime string.
		/// </summary>
		public string trimDate(string str)
		{
			if(str.IndexOf(" ")>0)
			{
				return str = str.Substring(0,str.IndexOf(" "));  
			}
			return str;
		}

		/// <summary>
		///  contacst the Print_WiindowServices via socket and sends the CustomerLedger.txt file name to print.
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
					//byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\eschool\\eschoolPrintServices\\LedgerReport.txt<EOF>");
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\LedgerReport.txt<EOF>");
					//												   Inetpub\ wwwroot\ eschool\ eSchoolPrintService\ LedgerReport
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print. Report Printed   userid  "+pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +ane.Message+"  userid  "+pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +se.Message+"  userid  "+pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print"+ " EXCEPTION "  +es.Message+"  userid  "+pass);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:print  EXCEPTION "  +ex.Message+"  userid  "+pass);
			}
		}

		/// <summary>
		///  this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Datagrid1.Visible==true || CustomerGrid.Visible==true || TotalSales.Visible==true)
				{
					ConvertToExcel();
					MessageBox.Show("Successfully Convert File into Excel Format");
					CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method: btnExcel_Click, Ledger Report Convert Into Excel Format ,  userid  "+pass);
				}
				else
				{
					MessageBox.Show("Please Click the View Button First");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:LedgerReport.aspx,Method:btnExcel_Click   Ledger Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
