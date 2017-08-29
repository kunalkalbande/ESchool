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
using System.Data .SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using RMG;
using eschool.Classes;
# endregion

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for Investments.
	/// </summary>
	public class ReceiptItem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.ValidationSummary svInvestment;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState;
		protected System.Web.UI.HtmlControls.HtmlInputText Txtitemcat;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText DropCountryValue;
		protected System.Web.UI.WebControls.DropDownList DropOutSider;
		protected System.Web.UI.WebControls.TextBox txtQty;
		protected System.Web.UI.WebControls.TextBox TxtBilDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.TextBox TxtAmount;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnSave;
		SqlDataReader sdtr;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		protected System.Web.UI.WebControls.Label lblStockID;
		protected System.Web.UI.WebControls.DropDownList DropStockID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button BtnUpdate;
		protected System.Web.UI.WebControls.DropDownList DropUnit;
		protected System.Web.UI.WebControls.DropDownList DropVendername;
		protected System.Web.UI.WebControls.TextBox TxtRate;
		protected System.Web.UI.WebControls.TextBox TxtVihicle;
		protected System.Web.UI.WebControls.TextBox TxtVehicle;
		protected System.Web.UI.WebControls.DropDownList DropItem;
		protected System.Web.UI.WebControls.DropDownList DropLocation;
		protected System.Web.UI.WebControls.TextBox Txtinvoice;
		protected System.Web.UI.WebControls.TextBox TxtRemark;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.WebControls.CompareValidator compvadation1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqvali1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		SqlCommand scom;
		static string Invoice_Date = "";
		static ArrayList LedgerID= new ArrayList();
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
				CreateLogFiles.ErrorLog (" Form : Recuring_FeesReceipt.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Recuring_FeesReceipt.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				scon.Open ();	
				//string pass;
				//pass=(Session["password"].ToString ());
				if(! IsPostBack)
				{
					fill();
					btnSave .Visible =true;
					BtnUpdate .Visible =false;
					DropStockID .Visible =false;
					lblStockID.Visible=true;
					TxtBilDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					NextStockID();
					if(!Page.IsPostBack)
					{
						DropUnit.Items.Clear();
						DropUnit.Items.Add("Select");
						#region
						scom=new SqlCommand("select itemcategory,unit from stockmaster",scon);
						sdtr=scom.ExecuteReader();
						while(sdtr.Read())
						{
							Txtitemcat.Value=Txtitemcat.Value+sdtr.GetValue(0).ToString().Trim()+":"+sdtr.GetValue(1).ToString().Trim()+",";
							
						}
						#endregion
					}
				}
				if(!IsPostBack)
				{
                    TxtBilDate.Attributes.Add("readonly", "readonly");
                    DropStockID.Visible=false;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="7";
					string SubModule="7";
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
						btnSave.Enabled=false;
					}
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad, Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				//Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				//return;
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
			this.DropStockID.SelectedIndexChanged += new System.EventHandler(this.DropStockID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropOutSider.SelectedIndexChanged += new System.EventHandler(this.DropOutSider_SelectedIndexChanged);
			this.DropItem.SelectedIndexChanged += new System.EventHandler(this.DropItem_SelectedIndexChanged);
			this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
			this.ID = "Form2";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This Method is use to Fill Stock Id from stock_Transaction table
		/// </summary>
		public void FillStockID()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="Select st_id from stock_transaction";
				SqlDtr=obj.GetRecordSet(str);
				DropStockID.Items.Clear();
				DropStockID.Items.Add ("Select");
				while(SqlDtr.Read())
				{
					DropStockID.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close ();
			}
			catch(Exception ex)
			{
                CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// This Method Fill DropOutSider,DropUnit  from stockmaster table, and DropVendername from Supplir table
		/// </summary>
		public void fill()
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1=null;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				cmd1=new SqlCommand("select distinct itemcategory from stockmaster",scon1);
				dr1=cmd1.ExecuteReader();
				DropOutSider.Items.Clear();
				DropOutSider.Items.Add("Select");
				while(dr1.Read())
				{
					DropOutSider.Items.Add(dr1.GetValue(0).ToString());
				}
				dr1.Close();
			    cmd1=new SqlCommand("select distinct unit from stockmaster",scon1);
			    dr1=cmd1.ExecuteReader();
				DropUnit.Items.Clear();
			    DropUnit.Items.Add("Select");
			    while(dr1.Read())
			    {
				    DropUnit.Items.Add(dr1.GetValue(0).ToString());
			    }
			    dr1.Close();
    			//cmd1=new SqlCommand("Select ledger_name,ledger_id from ledger_master order by ledger_id",scon1);
				//string str="Select Ledger_Name,ledger_Id From Ledger_master lm,Ledger_Master_sub_grp lmsg where lmsg.sub_grp_id=lm.sub_grp_id and lmsg.sub_grp_name not like 'Cash in hand' and lmsg.sub_grp_name not like 'Bank%' order by Ledger_Name";
				string str="select ledger_id,ledger_name from ledger_master where Ledger_Name in(Select Supp_Name from Supplier) order by ledger_name";
				cmd1=new SqlCommand(str,scon1);
			    dr1=cmd1.ExecuteReader();
				DropVendername.Items.Clear();
			    DropVendername.Items.Add("Select");
			    while(dr1.Read())
			    {
                  	DropVendername.Items.Add(dr1.GetValue(1).ToString().Trim().ToUpper()+":"+dr1.GetValue(0).ToString().Trim().ToUpper());
			    }
                  // DropVendername.Items.Add("Other");
			       dr1.Close();
			       DropLocation.Items.Add("Select");
			       DropItem .Items.Add("Select");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
	    }

		/// <summary>
		/// This method is used to Generate next ReceiptID based on Stock_Transaction table.
		/// </summary>
		string i="";
		public void NextStockID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select Tran_no from stock_transaction where st_id=(select max(st_id) from stock_transaction where tran_no like '%R%')",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					int no=1;
					while(SqlDtr.Read ())
					{
						if(SqlDtr.GetString(0)!=null||SqlDtr.GetString(0)!="")
						{	
							if(SqlDtr.GetString (0).IndexOf(":")==1)
							{
								no=Convert.ToInt32(SqlDtr.GetString (0).Substring(2));
								no+=1;
							}
							else 
								no=1;
						}
						else
							no=1;
						lblStockID.Text=no.ToString();
					}
				}
				else
					lblStockID.Text="1";
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// This Method use to Clear all the Control.
		/// </summary>
		public void clear1()
		{
			DropOutSider.Items.Clear();
            DropOutSider.Items.Add("Select");
			DropUnit.Items.Clear();
			DropUnit.Items.Add("Select");
			DropItem.Items.Clear();
			DropItem.Items.Add("Select");
			DropLocation.Items.Clear();
			DropLocation.Items.Add("Select");
			DropVendername.Items.Clear();
			DropVendername.Items.Add("Select");
			txtQty.Text="";
			TxtRate.Text="";
			Txtinvoice.Text="";
			TxtBilDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtRemark.Text="";
			TxtAmount.Text="";
			TxtVehicle.Text="";
		}

		/// <summary>
		/// This Method use to Clear all the Control.
		/// </summary>
		public void clear()
		{
			DropOutSider.SelectedIndex=0;
			DropUnit.Items.Clear();
			DropUnit.Items.Add("Select");
			DropUnit.SelectedIndex=0;
			DropItem.Items.Clear();
			DropItem.Items.Add("Select");
			DropItem.SelectedIndex=0;
			txtQty.Text="";
			TxtRate.Text="";
			Txtinvoice.Text="";
			TxtBilDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			DropLocation.Items.Clear();
			DropLocation.Items.Add("Select");
			DropLocation.SelectedIndex=0;
			DropVendername.SelectedIndex=0;
			TxtRemark.Text="";
			TxtAmount.Text="";
			TxtVehicle.Text="";
		}


		/// <summary>
		/// This Method is use to Reset the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			//clear();
			if(btnEdit.Visible==true)
			{
				clear();
			}
			else
			{
				DropVendername.SelectedIndex=0;
				BtnUpdate.Visible =false;
				btnSave.Visible =true;
				btnEdit.Visible=true;
				lblStockID.Visible=true;
				DropStockID.Visible=false;
				DropOutSider.SelectedIndex=0;
				DropItem.Items.Clear();
				DropItem.Items.Add("Select");
				DropItem.SelectedIndex=0;
				DropUnit.Items.Clear();
				DropUnit.Items.Add("Select");
				DropUnit.SelectedIndex=0;
				DropLocation.Items.Clear();
				DropLocation.Items.Add("Select");
				DropLocation.SelectedIndex=0;
				txtQty.Text="";
				TxtRemark.Text="";
				TxtRate.Text="";
				TxtAmount.Text="";
				Txtinvoice.Text="";
				TxtVehicle.Text="";
				TxtBilDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			}
		}

		/// <summary>
		/// This Method for returning the date in MM/DD/YYYY format but first pass a string sa an agument.
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
		/// This Method is use to Generate Next id of stock_transaction
		/// </summary>
		string ii="";
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;

			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(St_id)+1 from Stock_Transaction",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						ii=SqlDtr.GetValue(0).ToString ();
						if(ii.Trim().Equals(""))
							ii="1";
					}
				}
				
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );
			}
		}

     	/// <summary>
		/// This Method Use to save information in to Stock_transaction with the help of 'ProInsertStockTransaction'
		/// Procedure record save in to Two table Stock_Transaction table and Stock_Master table. another procedure 'ProInsertAccountsLedger' use to save record in AccountsLedgerTable.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj1=new InventoryClass ();
				SqlDataReader SqlDtr;
				int count=0;
				double closing=0,opening=0;
				string itemname,qty,trano,rate,bno,bldate,vendorname,stockloc,remark;
				DateTime trandt;
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				fillID();
				obj.ST_ID = ii.Trim().ToString();
				if(DropOutSider.SelectedIndex==0)
				{
					obj.OutsiderPayment ="0";
				}
				else
				{
					obj.OutsiderPayment =DropOutSider .SelectedItem.Value.ToString().Trim ();
				}
				obj.Tran_Type="RECEIPT";
				
				string str="select Tran_No from stock_Transaction where tran_type Like '%RECEIPT%' order by tran_date desc";
				SqlDtr =obj1.GetRecordSet (str);
				if(SqlDtr.Read())
				{
					if(SqlDtr.GetString(0)!=null &&  SqlDtr.GetString(0)!="")
					{
						int  TNo=Convert.ToInt32 (SqlDtr.GetString(0).Substring(2));
						TNo=TNo+1;
						obj.Tran_No ="R:"+TNo.ToString();
						trano="R:"+TNo.ToString();     
					}
					else
					{
						obj.Tran_No ="R:1";
						trano="R:1";
					}				
				}
				else
				{
					obj.Tran_No ="R:1";
					trano="R:1";
				}		
				if(DropItem.SelectedIndex==0)
				{
					obj.Itemname ="";
					itemname="";
				}
				else
				{
					obj.Itemname =DropItem.SelectedItem.Text.ToUpper().Trim ();
					itemname=DropItem.SelectedItem.Text.ToUpper().Trim ();
				}
				if(TxtVehicle.Text=="")
				{
					obj.Vehicle="";
				}
				else
				{
					obj.Vehicle=TxtVehicle.Text.Trim();
				}
				if(DropItem .SelectedIndex==0)
				{
					obj.Itemname ="";
					itemname="";
				}
				else
				{
					string name=DropItem.SelectedItem .Text.Trim ();
					name=name.Substring(0,name.IndexOf(":"));
					obj.Itemname=name;
					itemname=name;
				}
				if(txtQty.Text=="")
				{
					obj.Qty="";
					qty="";
				}
				else
				{
					obj.Qty=txtQty.Text;
					qty=txtQty.Text;
				}

				if(TxtRate .Text=="")
				{
					obj.Rate ="";
					rate="";
				}
				else
				{
					obj.Rate=TxtRate.Text;
					rate=TxtRate.Text;
				}

				if(Txtinvoice.Text=="")
				{
					bno="";
					obj.BillNo ="";
				}
				else
				{
					bno=Txtinvoice.Text.Trim ();
					obj.BillNo =Txtinvoice.Text.Trim ();
				}
				if(Txtinvoice.Text=="")
				{
					obj.BillNo ="";
					bno="";
				}
				else
				{
					obj.BillNo =Txtinvoice.Text.Trim ();
					bno=Txtinvoice.Text.Trim ();
				}

				if(TxtBilDate .Text=="")
				{
					obj.BillDate  ="";
					bldate="";
				}
				else
				{
					obj.BillDate =GenUtil.str2MMDDYYYY (GenUtil.trimDate (TxtBilDate.Text.Trim ())).ToString ();
					bldate=GenUtil.str2MMDDYYYY (GenUtil.trimDate (TxtBilDate.Text.Trim ())).ToString ();
				}
				obj.Trans_Date=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
				trandt=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
				if(DropVendername.SelectedIndex ==0)
				{
					obj.Vendor_Name  ="";
					vendorname="";
				}
				else 
				{
					if(DropVendername.SelectedItem.Text.Trim ()!="Other")
					{
						obj.Vendor_Name=DropVendername.SelectedItem .Text.Trim ();
						vendorname=DropVendername.SelectedItem .Text.Trim ();
						//string vendor=DropVendername.SelectedItem .Text.Trim ();
						//vendor=vendor.Substring(0,vendor.IndexOf(":"));
						//obj.Vendor_Name =vendor;
						//vendorname=vendor;
					}
					else
					{
						
						obj.Vendor_Name =Request.Params.Get("txtVName").ToString();
						vendorname=Request.Params.Get("txtVName").ToString();
					}
				}
				if(DropLocation.SelectedIndex ==0)
				{
					obj.Stock_Location ="";
					stockloc="";
				}
				else 
				{
					obj.Stock_Location =DropLocation.SelectedItem.Text;
					stockloc=DropLocation.SelectedItem .Text;
				}
				obj.Place ="";
				if(TxtRemark.Text =="")
				{
					obj.Remarks ="";
					remark="";
				}
				else 
				{
					obj.Remarks =TxtRemark.Text.Trim();
					remark=TxtRemark.Text.Trim();
				}
				if(TxtVehicle.Text=="")
				{
					obj.Vehicle="";
				}
				else
				{
					obj.Vehicle=TxtVehicle.Text.Trim();
				}
				obj.ProInsertStockTransaction();
				fillAccountsLedgerTable();
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dtr;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				//scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				//scon.Open();
				str="select closing from stock_movement where itemno="+itemname+" order by tran_date desc";
				cmd=new SqlCommand(str,scon);
				dtr=cmd.ExecuteReader();
				if(dtr.Read())
				{
					closing=Convert.ToDouble(dtr.GetValue(0));
					opening=closing;
					closing=closing+Convert.ToDouble(obj.Qty);
				}
				dtr.Close();
				str="insert into stock_movement (itemno,tran_no,tran_date,opening,recieved,issued,closing) values('"+itemname+"','"+trano+"','"+trandt+"',"+opening+","+qty+",0,"+closing+")";
				cmd=new SqlCommand(str,scon);
				cmd.ExecuteNonQuery();
				NextStockID();
				FillStockID();
				//AccountledgerUpdate();
				//MessageBox.Show("Item Inserted Sucessfully In Stock");
				MessageBox.Show("Transaction Successfully Saved");
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnSave_Click,  Record saved for BillNo :"+ ToMMddYYYY(TxtBilDate.Text.ToUpper().ToString()).ToShortDateString() +" , Userid :  "+ pass   );		
				clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}

		/// <summary>
		/// This Function Use to procedure 'ProInsertAccountsLedger' use to save record in AccountsLedgerTable.
		/// </summary>
		public void fillAccountsLedgerTable()
		{
			try
			{
				SqlCommand cmd;
				string cust_id1=DropVendername.SelectedItem.Text.Trim();
				string[] cust1=cust_id1.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",scon);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust1[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Purchase("+lblStockID.Text.ToString().Trim()+")");
				cmd.Parameters.Add("@Debit_Amount",TxtAmount.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",TxtAmount.Text.Trim());
				cmd.Parameters.Add("@type","Cr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// This Function Use to procedure 'ProInsertAccountsLedger' use to Update record in AccountsLedgerTable we also pass as an argument.
		/// </summary>
		public void fillAccountsLedgerTable(string InvoiceId)
		{
			try
			{
				SqlCommand cmd;
				string cust_id1=DropVendername.SelectedItem.Text.Trim();
				string[] cust1=cust_id1.Split(new char[]{':'});
				cmd=new SqlCommand("ProInsertAccountsLedger",scon);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@Ledger_Id",cust1[1].Trim().ToString());
				cmd.Parameters.Add("@Particulars","Purchase("+InvoiceId.ToString().Trim()+")");
				cmd.Parameters.Add("@Debit_Amount",TxtAmount.Text.Trim());
				cmd.Parameters.Add("@Credit_Amount",TxtAmount.Text.Trim());
				cmd.Parameters.Add("@type","Cr");
				cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text+" "+DateTime.Now.TimeOfDay.ToString())));
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DropPaybleMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// This Method Use to fetch Receipt id from Stock_Transaction 
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="select Tran_no from stock_transaction where tran_no like '%R%'";
				int no=1;
				SqlDtr=obj.GetRecordSet(str);
				DropStockID.Items.Clear();
				DropStockID.Items.Add("Select");
				while(SqlDtr.Read ())
				{
					if(SqlDtr.GetString(0)!=null||SqlDtr.GetString(0)!="")
					{	
						if(SqlDtr.GetString (0).IndexOf(":")==1)
						{
							DropStockID.Items.Add(Convert.ToInt32(SqlDtr.GetString (0).Substring(2)).ToString());
							
						}
					}
				}
				btnSave.Visible =false;
				BtnUpdate.Visible =true;
				DropStockID.Visible=true;
				lblStockID.Visible=false;
				btnEdit.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
        }

		/// <summary>
		/// This Method is use to fetch records from Stock_Transaction and Stock_Movement table.
		/// </summary>
		private void DropStockID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropStockID.SelectedIndex!=0)
			{
				double i=0,j=0,k=0;
				try
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					//02.10.08 string str="select st.vendor_name,st.vehicle,sm.itemcategory,sm.itemname,sm.unit,st.stock_Loc,st.item_id,st.item_qty,st.rate,st.billno,st.billdate,st.remark from stock_transaction st,stockmaster sm where tran_no like '%R:"+DropStockID.SelectedItem.Text.Trim()+"' and item_id=stockid"; // ad by vikas sharma date on 26.12.07
					string str="select st.vendor_name,st.vehicle,sm.itemcategory,sm.itemname,sm.unit,st.stock_Loc,st.item_id,st.item_qty,st.rate,st.billno,st.tran_date,st.remark from stock_transaction st,stockmaster sm where tran_no like '%R:"+DropStockID.SelectedItem.Text.Trim()+"' and item_id=stockid"; 
					//string str="select * from	stock_transaction st,stockmaster sm where tran_no like '%I:"+DropIssueID.SelectedItem.Text.Trim()+"' and stockid=item_id";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						DropOutSider.SelectedIndex=DropOutSider.Items.IndexOf(DropOutSider.Items.FindByValue(SqlDtr["itemcategory"].ToString().Trim ()));
						DropUnit.Items.Clear();
						DropUnit.Items.Add(SqlDtr["unit"].ToString().Trim());
						DropUnit.SelectedIndex=DropUnit.Items.IndexOf(DropUnit.Items.FindByValue(SqlDtr["unit"].ToString().Trim ()));
						DropItem.Items.Clear();
						DropItem.Items.Add(SqlDtr["item_id"].ToString().Trim()+":"+SqlDtr["itemname"].ToString().Trim());
						DropItem.SelectedIndex=DropItem.Items.IndexOf(DropItem.Items.FindByValue(SqlDtr["itemname"].ToString().Trim ()));
						txtQty.Text=SqlDtr["item_qty"].ToString().Trim();
						TxtRate.Text=SqlDtr["rate"].ToString().Trim();
						Txtinvoice.Text=SqlDtr["billno"].ToString().Trim();
						//TxtBilDate.Text=SqlDtr["billdate"].ToString().Trim();
						//TxtBilDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["billdate"].ToString().Trim()));
						TxtBilDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["tran_date"].ToString().Trim()));
						Invoice_Date = SqlDtr["tran_date"].ToString();
						DropLocation.Items.Clear();
						DropLocation.Items.Add(SqlDtr["stock_Loc"].ToString().Trim());
						DropLocation.SelectedIndex=DropLocation.Items.IndexOf(DropLocation.Items.FindByValue(SqlDtr["stock_Loc"].ToString().Trim()));
						TxtRemark.Text=SqlDtr["remark"].ToString().Trim();
						string vendor=SqlDtr["vendor_name"].ToString().Trim();
						string[] vendor1=vendor.Split(new char[]{':'});
						DropVendername.SelectedIndex=DropVendername.Items.IndexOf(DropVendername.Items.FindByValue(SqlDtr["vendor_name"].ToString().Trim()));
						LedgerID.Add(vendor1[1].ToString());
						i=Convert.ToDouble(txtQty.Text);
						j=Convert.ToDouble(TxtRate.Text);
						k=i*j;
						TxtAmount.Text=k.ToString();
						TxtVehicle.Text=SqlDtr["vehicle"].ToString();
					}
					else
					{
						MessageBox.Show("Data may be not available");
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				}
			}
			else
			{
				MessageBox.Show("Please Selected Stock ID");
				clear();
			}

		}

		private void DropCountry_ServerChange(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This Method use to Update Record in Both table Stock_Transaction and Stock_Master
		/// </summary>
		private void BtnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj1=new InventoryClass ();
				double closing=0,opening=0;
                string itemname="",qty="",InvoiceId="";
				DateTime bldate;
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				if(DropStockID.SelectedIndex ==0)
					MessageBox.Show ("Please Select Stock ID");
				else
				{
					obj.ST_ID=DropStockID .SelectedItem .Text.Trim (); 
					InvoiceId=DropStockID .SelectedItem .Text.Trim ();
				}
    			if(DropOutSider.SelectedIndex==0)
					obj.OutsiderPayment ="0";
				else
					obj.OutsiderPayment =DropOutSider .SelectedItem.Text.ToString().Trim ();
								
				if(DropStockID.SelectedIndex!=0)
				{
					obj.Tran_No ="R:"+DropStockID .SelectedItem .Text.Trim() ;
				}
				else
				{
					MessageBox.Show("Please Select Stock Id");
					return;
				}
     				string name=DropItem.SelectedItem .Text.Trim ();
					name=name.Substring(0,name.IndexOf(":"));
					
					obj.Itemname=name;
				        itemname=name;
				if(TxtVehicle.Text=="")
				{
					obj.Vehicle="";
				}
				else
				{
					obj.Vehicle=TxtVehicle.Text.Trim();
				}
				if(txtQty.Text=="")
				{
					obj.Qty="";
					qty="";
				}
				else
				{
					obj.Qty=txtQty.Text;
					qty=txtQty.Text;
				}

				if(TxtRate .Text=="")
					obj.Rate ="";
				else
					obj.Rate=TxtRate.Text;

				if(Txtinvoice .Text=="")
					obj.BillNo ="";
				else
					obj.BillNo =Txtinvoice.Text.Trim ();
				if(TxtBilDate .Text=="")
				{
					obj.BillDate ="";
					bldate=System.Convert.ToDateTime("");
				}
				else
				{
					
					obj.Trans_Date=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
					bldate=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
				}
    				if(DropVendername.SelectedItem .Text.ToUpper() .Trim ()!="Other")
					{
						obj.Vendor_Name =DropVendername.SelectedItem .Text.ToUpper() .Trim ();
					}
					else
					{
						obj.Vendor_Name =Request.Params .Get("txtVName");
					}
				 
					obj.Stock_Location =DropLocation.SelectedItem.Text;
			
				obj.Place ="";
				
				if(TxtRemark.Text =="")
					obj.Remarks ="";
				else 
					obj.Remarks =TxtRemark.Text.Trim ();
				obj.UpdateStockTransaction(); 
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dtr;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				string str="";

				str="Delete from accountsledgertable where Particulars='Purchase("+DropStockID.SelectedValue.ToString()+")'" ;
				cmd=new SqlCommand(str,scon);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				fillAccountsLedgerTable(InvoiceId);
    			/*string str="select closing from stock_movement where itemno="+itemname+" order by tran_date desc";
				cmd=new SqlCommand(str,scon);
				dtr=cmd.ExecuteReader();
				if(dtr.Read())
				{
					closing=Convert.ToDouble(dtr.GetValue(0));
					opening=closing;
					closing=closing+Convert.ToDouble(obj.Qty);
				}
				dtr.Close();*/
				//str="update stock_movement set tran_date='"+bldate+"', Opening="+opening+",recieved="+qty+",closing="+closing+" where itemno="+itemname+" and Tran_no = 'R:"+ DropStockID.SelectedItem.Text .Trim()+"'" ;
				///01.010.08 str="update stock_movement set tran_date='"+bldate+"', recieved="+qty+" where itemno="+itemname+" and Tran_no = 'R:"+ DropStockID.SelectedItem.Text .Trim()+"'" ;
				str="update stock_movement set tran_date='"+GenUtil.str2MMDDYYYY(bldate.ToString())+"', recieved="+qty+",itemno="+itemname+" where Tran_no = 'R:"+ DropStockID.SelectedItem.Text .Trim()+"'" ;
				cmd=new SqlCommand(str,scon);
				cmd.ExecuteNonQuery();
				
				AccountledgerUpdate();
				StockMasterUpdate(itemname);
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnUpdate_Click,  Update for BillNo :"+ Txtinvoice.Text.Trim ()+" , Userid :  "+ pass   );		
				clear();
				fillID();
				//fill();
				NextStockID();
				DropStockID.Visible=false;
				BtnUpdate.Visible=false;
				btnSave.Visible=true;
				lblStockID.Visible=true;
				btnEdit.Visible=true;
				//MessageBox.Show("Item Updated Sucessfully In Stock");
				MessageBox.Show("Transaction Successfully Updated");
				
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
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
			if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtBilDate.Text)))>0)
				Invoice_Date=GenUtil.str2DDMMYYYY(TxtBilDate.Text);
			for(int k=0;k<LedgerID.Count;k++)
			{
				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+GenUtil.str2MMDDYYYY(Invoice_Date.ToString())+"' order by entry_date desc");
				if(rdr.Read())
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				else
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
			
				//*************************
				//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
				//rdr=obj.GetRecordSet(str);
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
                        rdr.Close();
                        Con.Open();
						string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
						cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}		
				}
				rdr.Close();
				
			}
		}

		/// <summary>
		/// This Method Use to Fill Required data in these dropdown DropItem,DropLocation,DropUnit DropDown from stockmaster table.
		/// </summary>
		private void DropOutSider_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1=null;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				if(DropOutSider.SelectedIndex >0)
				{
					cmd1=new SqlCommand("select distinct stockid, itemname,stocklocation from stockmaster where itemcategory='"+DropOutSider.SelectedItem.Text +"'",scon1);
					dr1=cmd1.ExecuteReader();
					DropItem.Items.Clear();
					DropItem.Items.Add("Select");
					while(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							DropItem.Items.Add(dr1.GetValue(0).ToString()+":"+dr1.GetValue(1).ToString());
						}
					}
					dr1.Close();
					cmd1=new SqlCommand("select distinct stocklocation from stockmaster where itemcategory='"+DropOutSider.SelectedItem.Text +"'",scon1);
					dr1=cmd1.ExecuteReader();
					DropLocation.Items.Clear();
					DropLocation.Items.Add("Select");
					while(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							DropLocation.Items.Add(dr1.GetValue(0).ToString());
						}
					}
					dr1.Close();
					cmd1=new SqlCommand("select distinct Unit from stockmaster where itemcategory='"+DropOutSider.SelectedItem.Text +"'",scon1);
					dr1=cmd1.ExecuteReader();
					DropUnit.Items.Clear();
					DropUnit.Items.Add("Select");
					while(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							DropUnit.Items.Add(dr1.GetValue(0).ToString());
						}
					}
					dr1.Close();
				}
			}
			catch(Exception ex)
			{
                 CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// Fetch Rate of the item In TextBox from Stockmaster.
		/// </summary>
		private void DropItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1=null;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				if(DropItem .SelectedIndex >0)
				{
					cmd1=new SqlCommand("select rate from stockmaster where stockid='"+DropItem.SelectedItem.Text.Substring(0, DropItem.SelectedItem.Text.IndexOf(":"))+"'",scon1);

					dr1=cmd1.ExecuteReader();
					if(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							TxtRate.Text =dr1.GetValue(0).ToString();
						}
					}
					dr1.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReceiptItem.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		private void txtQty_TextChanged(object sender, System.EventArgs e)
		{
		
		}	

		/// <summary>
		/// This Method use to Update theClosing balance of a particular iteme from a selected date.
		/// </summary>
		public void StockMasterUpdate(string itemname1)
		{
			try
			{
				InventoryClass obj1 = new InventoryClass();
				SqlCommand cmd;
				SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				SqlDataReader rdr1=null;
				//string str="select * from Stock_Master where Productid='"+rdr["Prod_ID"].ToString()+"' order by Stock_date";
				string str="select * from stock_movement where itemno="+itemname1+" order by tran_date ";
				rdr1=obj1.GetRecordSet(str);
				double OS=0,CS=0,k=0;
				while(rdr1.Read())
				{
					if(k==0)
					{
						OS=double.Parse(rdr1["opening"].ToString());
						k++;
					}
					else
						OS=CS;
					CS=OS+double.Parse(rdr1["recieved"].ToString())-double.Parse(rdr1["issued"].ToString());
                    string TD = rdr1["Tran_date"].ToString();
                    //CS=OS+double.Parse(rdr1["received"].ToString())-(double.Parse(rdr1["issued"].ToString())+double.Parse(rdr1["salesfoc"].ToString()));
                    Con.Open();
					cmd = new SqlCommand("update Stock_Movement set opening='"+OS.ToString()+"', Closing='"+CS.ToString()+"' where itemno="+itemname1+" and Tran_Date='"+GenUtil.str2MMDDYYYY(TD.ToString())+"'",Con);
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					Con.Close();
				}
				rdr1.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
