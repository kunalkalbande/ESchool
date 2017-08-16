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

namespace eschool.Modules.StudentFees
{
	/// <summary>
	/// Summary description for Payment.
	/// </summary>
	public class Payment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtchckno;
		protected System.Web.UI.WebControls.Panel panmode;
		protected System.Web.UI.WebControls.TextBox txtchkdt;
		protected System.Web.UI.WebControls.TextBox txtamnt;
		protected System.Web.UI.WebControls.TextBox txtRemark;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.DropDownList dropLedgid;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList Dropedit;
		protected System.Web.UI.WebControls.Button btnsave;
		protected System.Web.UI.WebControls.DropDownList Dropmode;
	    SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand cmd;
		SqlDataReader sdtr;
		string str="";
		protected System.Web.UI.WebControls.Label LblId;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.CompareValidator CompVali;
		protected System.Web.UI.WebControls.CompareValidator CompVali1;
		protected System.Web.UI.WebControls.ValidationSummary simmry1;
		protected System.Web.UI.WebControls.RequiredFieldValidator valireq1;
		protected System.Web.UI.HtmlControls.HtmlInputText tempMode;
		static string Receipt_no="";
		string pass="";
		static string Invoice_Date = "";
		static ArrayList LedgerID= new ArrayList();

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Page_Load. Exception: " + ex.Message);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
			  	if(!Page.IsPostBack)
				{
					con.Open();
					txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtchkdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					str="Select distinct Ledger_Name,Ledger_ID from Ledger_Master lm,Ledger_master_sub_grp lmsg  where  lm.sub_grp_id = lmsg.sub_grp_id and lmsg.sub_grp_name not like 'Bank%' and lmsg.sub_grp_name not like 'Cash in hand'  Order by Ledger_Name";
					cmd=new SqlCommand(str,con);
					sdtr=cmd.ExecuteReader();
					while(sdtr.Read())
					{
						dropLedgid.Items.Add(sdtr.GetValue(0).ToString().ToUpper()+":"+sdtr.GetValue(1).ToString());
					}
					sdtr.Close();
					str="Select Ledger_Name,Ledger_ID from Ledger_Master lm,Ledger_master_sub_grp lmsg  where  lm.sub_grp_id = lmsg.sub_grp_id and (lmsg.sub_grp_name  like 'Bank%' or lmsg.sub_grp_name  = 'Cash in hand')  Order by Ledger_Name";
					cmd=new SqlCommand(str,con);
					sdtr=cmd.ExecuteReader();
					while(sdtr.Read())
					{
						Dropmode.Items.Add(sdtr.GetValue(0).ToString().ToUpper()+":"+sdtr.GetValue(1).ToString().ToUpper());
					}
					sdtr.Close();
					con.Close();
				}
				con.Open();
				NextId();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="7";
				string SubModule="3";
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
				if(Add_Flag=="False"&&Edit_Flag=="False"&&Del_Flag=="False"&&View_flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(Add_Flag=="False")
				{
					btnsave.Enabled=false;
				}
				#endregion
			}
		}
		
		/// <summary>
		/// this method use to fill record from ledger_master and payment_receipt table.
		/// </summary>
		public void Filldropedit()
		{
			try
			{
				str="select Ledger_name,cast(cust_id as varchar),cast(receipt_No as varchar) from ledger_master lm,payment_receipt pr where lm.ledger_id=pr.cust_id order by receipt_No";
				cmd=new SqlCommand(str,con);
				sdtr=cmd.ExecuteReader();
				Dropedit.Items.Clear();
				Dropedit.Items.Add("Select");
				while(sdtr.Read())
				{
					Dropedit.Items.Add(sdtr.GetValue(0).ToString().ToUpper()+";"+sdtr.GetValue(1).ToString()+":"+sdtr.GetValue(2).ToString());
				}
				sdtr.Close();
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
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.Dropedit.SelectedIndexChanged += new System.EventHandler(this.Dropedit_SelectedIndexChanged);
			this.dropLedgid.SelectedIndexChanged += new System.EventHandler(this.dropLedgid_SelectedIndexChanged);
			this.Dropmode.SelectedIndexChanged += new System.EventHandler(this.Dropmode_SelectedIndexChanged);
			this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// thid method use to call Filldropedit() function.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			try
			{
				Dropedit.Visible=true;
				btnedit.Visible=false;
				btnsave.Text="Update";
				panmode.Visible=false;
				LblId.Visible=false;
				Filldropedit();
				CreateLogFiles.ErrorLog ("Form : Payment.aspx.cs, Method: btnEdit_Click. User : " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: btnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// this method use to hide or visible some controls. 
		/// </summary>
		private void Dropmode_SelectedIndexChanged(object sender, System.EventArgs e)
		{    
			string mode = Dropmode.SelectedItem.Text.ToUpper();
            string[] mode1=mode.Split(new char[] {':'});
			if(mode1[0].ToString().Trim().ToUpper()!="CASH")
			{
				panmode.Visible=true;
				txtchckno.Text="";
				txtchkdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			}
			else
			{
                panmode.Visible=false;
			}
		}

		/// <summary>
		/// this method use to get next id of payment_receipt table.
		/// </summary>
		public void NextId()
		{
			try
			{
				str="Select Max(Receipt_no)+1 from Payment_Receipt";
				cmd=new SqlCommand(str,con);
				sdtr=cmd.ExecuteReader();
				while(sdtr.Read())
				{    
					Receipt_no=sdtr.GetValue(0).ToString();
					LblId.Text=sdtr.GetValue(0).ToString();
					if(Receipt_no=="" || Receipt_no==null)
					{
						Receipt_no="1001";
						LblId.Text="1001";
					}
				}
				sdtr.Close();
				cmd.Dispose();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void clear()
		{
			txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtchkdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtamnt.Text="";
			txtchckno.Text="";
			txtRemark.Text="";
			dropLedgid.SelectedIndex=0;
			Dropmode.SelectedIndex=0;
			panmode.Visible=false;
		}
		
		/// <summary>
		/// This Method use for two Work Save And Update the Record. we use fillAccountsLedgerTable() function to insert value into AccountsLedgerTable to save record. 
		/// also use fillAccountsLedgerTable(string) this function use to update record in update time first delete the record and after that insert record with same id;
		/// also use AccountledgerUpdate() this function update closing balance of a perticular Ledgerid from selected date.
		/// </summary>
		private void btnsave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string receipt_id="",oldname="",oldname12="",NewpayMode="",NewpayModeidd="",OldPaymode="";
						
				if(Dropedit.SelectedIndex!=0)
				{
					oldname=Dropedit.SelectedItem.Text.ToString();
					string[] oldname1=oldname.Split(new char[]{':'});
					string[] oldname2=oldname1[0].Split(new char[]{';'});
					receipt_id=oldname1[1].ToString().Trim();
					oldname12=oldname2[1].ToString().Trim();
					NewpayMode=Dropmode.SelectedItem.Text.ToString();
					string[] OldpayModeid=NewpayMode.Split(new char[]{':'});
					NewpayModeidd=OldpayModeid[1].ToString();
					OldPaymode=tempMode.Value.ToString();
				}
				string Bankname=Dropmode.SelectedItem.Text.Trim();
				string[] Bank=Bankname.Split(new char[]{':'});
				int i=0;
				string msg="";
				string cust_id=dropLedgid.SelectedItem.Text.Trim();
				string[] cust=cust_id.Split(new char[]{':'});
				string newname=cust[1].ToString().Trim();
				
				DateTime entry_date=System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text.Trim())+" "+DateTime.Now.TimeOfDay.ToString());
				
				if(btnedit.Visible==true)
				{
					str="insert into Payment_Receipt (Receipt_no,Receipt_Date,Invoice_No,received_Amount,bankname,chequeno,chequedate,mode,cust_id,narration) values(@Receipt_no,@Receipt_Date,@Invoice_No,@received_Amount,@bankname,@chequeno,@chequedate,@mode,@cust_id,@narration)";
					msg="Save";
				}
				else
				{
                    str="update Payment_Receipt set Receipt_Date=@Receipt_Date,Invoice_No=@Invoice_No,received_Amount=@received_Amount,cust_id=@cust_id,bankname=@bankname,chequeno=@chequeno,chequedate=@chequedate,mode=@mode,narration=@narration where Receipt_no=@Receipt_no";
					msg="Update";
				}
				cmd=new SqlCommand(str,con);
				
				if(btnedit.Visible==true)
				{
					cmd.Parameters.Add("@Receipt_No",Receipt_no.Trim());
				}
				else
				{
					cmd.Parameters.Add("@Receipt_No",receipt_id.ToString().Trim());
				}
				//cmd.Parameters.Add("@Receipt_Date",GenUtil.str2MMDDYYYY(txtDate.Text.Trim()));
				cmd.Parameters.Add("@Receipt_Date",entry_date);
				cmd.Parameters.Add("@Invoice_No"," ");
				cmd.Parameters.Add("@received_Amount",txtamnt.Text.Trim());
				//cmd.Parameters.Add("@bankname",Bank[0]);
				cmd.Parameters.Add("@bankname",Bank[1]);
				if(Bank[0].Trim().ToString().ToUpper()=="CASH")
				{
					cmd.Parameters.Add("@chequeno"," ");
					cmd.Parameters.Add("@chequedate"," ");
					cmd.Parameters.Add("@mode"," ");
				}
				else
				{
					cmd.Parameters.Add("@chequeno",txtchckno.Text.Trim());
					cmd.Parameters.Add("@chequedate",GenUtil.str2MMDDYYYY(txtchkdt.Text.Trim()));
					cmd.Parameters.Add("@mode"," ");
				}
                cmd.Parameters.Add("@cust_id",cust[1].Trim().ToString());
				cmd.Parameters.Add("@narration",txtRemark.Text.Trim());
				i=cmd.ExecuteNonQuery();
				cmd.Dispose();
				if(i>0)
				{
					//MessageBox.Show("Record "+msg.ToString()); 
					if(btnedit.Visible==true)
					{
						fillAccountsLedgerTable();
					}
					else
					{
						if(!newname.ToString().Equals(oldname12.ToString()) || !NewpayModeidd.ToString().Equals(OldPaymode.ToString()))
						{
                            str="Delete from Accountsledgertable where Particulars='Payment("+receipt_id+")'";
							cmd=new SqlCommand(str,con);
							int c=cmd.ExecuteNonQuery();
							if(c>0)
							{
								fillAccountsLedgerTable(receipt_id);
								AccountledgerUpdate();
							}
						}
						else
						{
							if(!NewpayModeidd.ToString().Equals(OldPaymode.ToString()))
							{
								str="Delete from Accountsledgertable where Particulars='Payment("+receipt_id+")'";
								cmd=new SqlCommand(str,con);
								int c=cmd.ExecuteNonQuery();
								if(c>0)
								{
									fillAccountsLedgerTable(receipt_id);
									AccountledgerUpdate();
								}
							}
							else
							{
								UpdateAccountsLedger(receipt_id);
								AccountledgerUpdate();
							}
						}
					}
				}
				MessageBox.Show("Transaction Successfully "+msg.ToString());
				clear();
				Filldropedit();
				btnsave.Text="Save";
				dropLedgid.Visible=true;
				Dropedit.Visible=false;
				btnedit.Visible=true;
				LblId.Visible=true;
				NextId();
				CreateLogFiles.ErrorLog (" Form : Payment.aspx.cs, Method: btn"+msg+"_Click. User: " + pass );
			}
			catch(Exception ex)
			{
                //MessageBox.Show(ex.Message.ToString());
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this function update AccountsLedgerTable.
		/// </summary>
		public void UpdateAccountsLedger(string receipt_id)
		{
			try
			{
				string cust_id=dropLedgid.SelectedItem.Text.Trim();
				string[] cust=cust_id.Split(new char[]{':'});
				cmd=new SqlCommand("ProUpdateAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Voucher_ID","Payment("+receipt_id.ToString().Trim()+")");
				cmd.Parameters.Add("@Ledger_Id",cust[1].Trim().ToString());
				cmd.Parameters.Add("@Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Dr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();

				string cust_id1=Dropmode.SelectedItem.Text.Trim();
				string[] cust1=cust_id1.Split(new char[]{':'});
				cmd=new SqlCommand("ProUpdateAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Voucher_ID","Payment("+receipt_id.ToString().Trim()+")");
				cmd.Parameters.Add("@Ledger_Id",cust1[1].Trim().ToString());
				cmd.Parameters.Add("@Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Cr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message.ToString());
			}
		}

		/// <summary>
		/// this Method Use to Fetch the data from Recipt table. and in ArrayList add LedgerId which are use.
		/// </summary>
		public void fillAccountsLedgerTable(string Receipt)
		{
			try
			{
				string cust_id=dropLedgid.SelectedItem.Text.Trim();
				string[] cust=cust_id.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Payment("+Receipt+")");
				cmd.Parameters.Add("@Debit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Dr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();

				string cust_id1=Dropmode.SelectedItem.Text.Trim();
				string[] cust1=cust_id1.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust1[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Payment("+Receipt+")");
				cmd.Parameters.Add("@Debit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Cr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			catch(Exception ex)
			{

			}
		}

		/// <summary>
		/// This Method Use to Insert Record with the help of 'ProInsertAccountsLedger' Procedure. 
		/// </summary>
		public void fillAccountsLedgerTable()
		{
			try
			{
				string cust_id=dropLedgid.SelectedItem.Text.Trim();
				string[] cust=cust_id.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Payment("+Receipt_no+")");
				cmd.Parameters.Add("@Debit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Dr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();

				string cust_id1=Dropmode.SelectedItem.Text.Trim();
				string[] cust1=cust_id1.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",con);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust1[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Payment("+Receipt_no+")");
				cmd.Parameters.Add("@Debit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",txtamnt.Text.Trim());
				cmd.Parameters.Add("@type","Cr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			catch(Exception ex)
			{
                  
			}
		}

		/// <summary>
		/// this Method Use to Fetch the data from Recipt table. and in ArrayList add LedgerId which are use.
		/// </summary>
		private void Dropedit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				string ss="",sss="";
				SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();  
				SchoolClass .SchoolMgs obj1= new SchoolClass .SchoolMgs ();  
               
				string oldname=Dropedit.SelectedItem.Text.ToString();
				string[] oldname1=oldname.Split(new char[]{':'});
				string[] oldname2=oldname1[0].Split(new char[]{';'});

				
				str="Select * from Payment_Receipt where Receipt_No="+oldname1[1].ToString().Trim();
				cmd=new SqlCommand(str,con);
				sdtr=cmd.ExecuteReader();
				while(sdtr.Read())
				{
					txtDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Receipt_Date"].ToString()));
					Invoice_Date=sdtr["Receipt_Date"].ToString();
					txtamnt.Text=sdtr["Received_Amount"].ToString();
					txtRemark.Text=sdtr["Narration"].ToString();
					SqlDataReader sdtr12;
					sdtr12=obj.GetRecordSet("Select Ledger_Name From Ledger_Master where Ledger_id='"+sdtr["Cust_Id"].ToString()+"'");
					while(sdtr12.Read())
					{
						sss=sdtr12["Ledger_Name"].ToString().Trim();
					}
					sdtr12.Close();
								
					dropLedgid.SelectedIndex=dropLedgid.Items.IndexOf(dropLedgid.Items.FindByValue(sss.ToString().Trim().ToUpper()+":"+sdtr["Cust_Id"].ToString()));
				
					string mode = sdtr["Bankname"].ToString().ToUpper();
					string mode1="";
					SqlDataReader dtr12=null;
					dtr12=obj1.GetRecordSet("Select Ledger_Name From Ledger_Master where Ledger_id='"+mode.ToString()+"'");
					while(dtr12.Read())
					{
						mode1=dtr12["Ledger_Name"].ToString().Trim();
					}
					dtr12.Close();

					LedgerID.Add(sdtr["Cust_ID"].ToString());
					LedgerID.Add(sdtr["Bankname"].ToString());

					if( mode1.ToString().ToUpper()!="CASH")
					{
						panmode.Visible=true;
						txtchckno.Text=sdtr["chequeno"].ToString();
						txtchkdt.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["chequeDate"].ToString()));
					}
					else
					{
						panmode.Visible=false;
					}
						//SqlDataReader sdtr1;
						//sdtr1=obj.GetRecordSet("Select Ledger_Id From Ledger_Master where ledger_name='"+sdtr["BankName"].ToString()+"'");
						//while(sdtr1.Read())
						//{
						//	ss=sdtr1["Ledger_id"].ToString().Trim();
							//tempMode.Value=sdtr1["Ledger_id"].ToString().Trim();
							tempMode.Value=mode.ToString().Trim();

						//}
						//sdtr1.Close();
						
						//Dropmode.SelectedIndex=Dropmode.Items.IndexOf(Dropmode.Items.FindByValue(sdtr["BankName"].ToString()+":"+ss));
					Dropmode.SelectedIndex=Dropmode.Items.IndexOf(Dropmode.Items.FindByValue(mode1.ToString().ToUpper().Trim()+":"+mode));
						
				}
				sdtr.Close();
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Dropedit_SelectedIndexChanged. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Payment.aspx.cs, Method: Dropedit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void dropLedgid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// AccountledgerUpdate() this function update closing balance of a perticular Ledgerid from selected date.
		/// </summary>
		public void AccountledgerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			//*************************
			string[] CheckDate = Invoice_Date.Split(new char[] {' '},Invoice_Date.Length);
			if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text)))>0)
				Invoice_Date=GenUtil.str2MMDDYYYY(txtDate.Text);
			for(int k=0;k<LedgerID.Count;k++)
			{
				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
				if(rdr.Read())
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				else
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
				rdr.Close();
				//*************************
				//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				BalType="";
				i=0;
				while(rdr.Read())
				{
					if(i==0)
					{
						BalType=rdr["Bal_Type"].ToString();
						Bal=double.Parse(rdr["Balance"].ToString());
						i++;
					}
					else
					{
						if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
						{
							if(BalType=="Cr")
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal+=double.Parse(rdr["Credit_Amount"].ToString());
								BalType="Cr";
							}
							else
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal-=double.Parse(rdr["Credit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Cr";
								}
								else
									BalType="Dr";
							}
						}
						else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
						{
							if(BalType=="Dr")
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal+=double.Parse(rdr["Debit_Amount"].ToString());
							}
							else
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal-=double.Parse(rdr["Debit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Dr";
								}
								else
									BalType="Cr";
							}
						}
						Con.Open();
						string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
						cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}		
				}
				rdr.Close();
				//*************************
				/*rdr = obj.GetRecordSet("select top 1 EntryDate from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') and EntryDate<='"+Invoice_Date+"' order by entrydate desc");
				if(rdr.Read())
					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer,Ledger_Master where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') and EntryDate>='"+rdr.GetValue(0).ToString()+"' order by entrydate";
				else
					str="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID[k].ToString()+"') order by entrydate";
				rdr.Close();
				//*************************
				//string str1="select * from CustomerLedgerTable where CustID=(select Cust_ID from Customer c,Ledger_Master l where Ledger_Name=Cust_Name and Ledger_ID='"+LedgerID+"') order by entrydate";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				i=0;
				BalType="";
				while(rdr.Read())
				{
					if(i==0)
					{
						BalType=rdr["BalanceType"].ToString();
						Bal=double.Parse(rdr["Balance"].ToString());
						i++;
					}
					else
					{
						if(double.Parse(rdr["CreditAmount"].ToString())!=0)
						{
							if(BalType=="Cr.")
							{
								Bal+=double.Parse(rdr["CreditAmount"].ToString());
								BalType="Cr.";
							}
							else
							{
								Bal-=double.Parse(rdr["CreditAmount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Cr.";
								}
								else
									BalType="Dr.";
							}
						}
						else if(double.Parse(rdr["DebitAmount"].ToString())!=0)
						{
							if(BalType=="Dr.")
								Bal+=double.Parse(rdr["DebitAmount"].ToString());
							else
							{
								Bal-=double.Parse(rdr["DebitAmount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Dr.";
								}
								else
									BalType="Cr.";
							}
						}
						Con.Open();
						cmd = new SqlCommand("update CustomerLedgerTable set Balance='"+Bal.ToString()+"',BalanceType='"+BalType+"' where CustID='"+rdr["CustID"].ToString()+"' and Particular='"+rdr["Particular"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}
				}
				rdr.Close();*/
			}
		}
		
	}
}
