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
using eschool.Classes;
using DBOperations;
using RMG;



namespace eschool.Modules.Form
{
	/// <summary>
	/// Summary description for Supplier_Entry.
	/// </summary>
	public class Supplier_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
		protected System.Web.UI.WebControls.Label lblSupplierID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.TextBox txtOpBalance;
		protected System.Web.UI.WebControls.DropDownList DropBal;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.DropDownList DropID;
		protected System.Web.UI.WebControls.TextBox TempVenderName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btndelete;
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
				pass=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Supplier_Entry.aspx,Method:page_load"+"  EXCEPTION  "+ ex.Message + pass);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			if(!IsPostBack)
			{
				try
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="3";
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
					if(View_flag=="0")
					{
						//	string msg="UnAthourized Visit to Vendor Entry Page";
						//	dbobj.LogActivity(msg,Session["User_Name"].ToString());  
						Response.Redirect("../../AccessDeny.aspx",false);
					}
					if(Add_Flag=="0")
						btnUpdate.Enabled=false;
					#endregion

					getbeat();
					// Fills the Credit Limit combo with 30 Numbers.
					//for(i=1;i<=30;i++)
					//{
					//	DropCrDay.Items.Add(i.ToString ());
					//}

					PartiesClass obj=new PartiesClass();
					
					SqlDataReader SqlDtr;
					string sql;

					GetNextSupplierID();
				
					//sql="select distinct City from Beat_Master order by City asc";
					sql="select distinct City from country order by City asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						DropCity.Items.Add(SqlDtr.GetValue(0).ToString()); 
				
					}
					SqlDtr.Close();


					//sql="select distinct state from Beat_Master order by state asc";
					sql="select distinct state from country order by state asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
				
						DropState.Items.Add(SqlDtr.GetValue(0).ToString()); 
				
					}
					SqlDtr.Close();

					//sql="select distinct country from Beat_Master order by country asc";
					sql="select distinct country from country order by country asc";
					SqlDtr=obj.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
				
						DropCountry.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,Method:page_load"+"  EXCEPTION  "+ ex.Message+pass);
				}
			}
		}
		
		/// <summary>
		/// This is used to concatinate city,state,country for javascript.
		/// </summary>
		public void getbeat()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader sqldtr;
				string sql;
				string str="";
				//sql="select city,state,country from beat_master";
				sql="select country,state,city from Country";
				sqldtr=obj.GetRecordSet(sql);
				while(sqldtr.Read())
				{
					//str=str+sqldtr.GetValue(0).ToString()+":";
					//str=str+sqldtr.GetValue(1).ToString()+":";
					//str=str+sqldtr.GetValue(2).ToString()+",";
					txtName.Text=txtName.Text+sqldtr.GetString(0).ToString().Trim()+ ":" +sqldtr.GetString(1).ToString().Trim()+ ":" +sqldtr.GetString(2).ToString().Trim()+ ",";
				}
				//txtbeatname.Text=str;
				//txtName.Text=str;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,class:Inventoryclass.cs,method:getbeat()"+"Exception"+ex.Message+pass);
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
			this.DropID.SelectedIndexChanged += new System.EventHandler(this.DropID_SelectedIndexChanged);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Its checks the before save that the account period is inserted in organisaton table or not if not then return false otherwise return true.
		/// </summary>
		public bool checkAcc_Period()
		{
			SqlDataReader SqlDtr = null;
			int c = 0;
			dbobj.SelectQuery("Select count(Acc_Date_From) from Organisation",ref SqlDtr);
			if(SqlDtr.Read())
			{
				c = System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());  
			}
			SqlDtr.Close();

			if(c > 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// this Method use to save and update the information of venders.with the help of InsertSupplier() save the information and in the time of update UpdateSupplier() function use.
		/// and also use AccountLedgerUpdate(Ledger_ID) function to update AccountsLedgerTable.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			PartiesClass obj=new PartiesClass();
			try
			{
				if(!checkAcc_Period())
				{
					MessageBox.Show("Please enter the Accounts Period from Organization Details");
					return;
				}
				//                string sname=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() )); 				SqlDataReader SqlDtr;
				//				string sql1="select Supp_ID from supplier where Supp_Name='"+sname+"'";
				//				
				//				SqlDtr=obj.GetRecordSet(sql1);
				//				
				//				if(SqlDtr.HasRows)
				//				{
				//					MessageBox.Show("Vendor Name  "+sname+" Already Exist");
				//					return;
				//				}
				//				SqlDtr.Close();
				string sql1; 
				SqlDataReader SqlDtr = null;
				string sname="";
				if(txtFName.Text.Trim()!="")
					sname+=txtFName.Text.Trim();
				//if(txtMName.Text.Trim()!="")
				//	sname+=" "+txtMName.Text.Trim();
				//if(txtLName.Text.Trim()!="")
				//	sname+=" "+txtLName.Text.Trim();
				//((txtFName.Text.ToString().Trim() )) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim() ))+" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim() ));
				if(btnedit.Visible==true)
				{
					sql1="select Supp_Id from Supplier where Supp_Name='"+sname.Trim()+"'";
					SqlDtr=obj.GetRecordSet(sql1);
					if(SqlDtr.HasRows)
					{
						MessageBox.Show("Vendor Name  "+sname+" Already Exist");
						return;
					}
					SqlDtr.Close();
					sql1="select * from Ledger_Master where Ledger_Name='"+sname.Trim()+"'";
					SqlDtr=obj.GetRecordSet(sql1);
					if(SqlDtr.HasRows)
					{
						MessageBox.Show("Ledger Name  "+sname+" Already Exist");
						return;
					}
					SqlDtr.Close();
				}
				//				sql1 = "Select Tin_No from supplier where Tin_No = '"+txtTinNo.Text.Trim()+"'";
				//				SqlDtr= obj.GetRecordSet(sql1);
				//				if(SqlDtr.HasRows)
				//				{
				//					MessageBox.Show("The Tin No. "+txtTinNo.Text.Trim()+" Already Exist");
				//					return;
				//				}
				//				SqlDtr.Close();
				if(btnedit.Visible==true)
				{
					obj.Supp_ID=lblSupplierID.Text;
				}
				else
				{
					obj.Supp_ID=DropID.SelectedValue.ToString();
				}
				//if(txtMName.Text!="" && txtLName.Text!="")
				//	obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim() )) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim())+" "+ (txtLName.Text.ToString().Trim()));
				//else if(txtMName.Text=="" &&  txtLName.Text!="" )
				//	obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtLName.Text.ToString().Trim()));
				//else if(txtMName.Text!="" &&  txtLName.Text=="")
				//	obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim())) +" "+ StringUtil.FirstCharUpper((txtMName.Text.ToString().Trim()));
				//else if (txtLName.Text=="" &&  txtMName.Text=="")
				obj.Supp_Name=StringUtil.FirstCharUpper((txtFName.Text.ToString().Trim()));
				//obj.Supp_Type=DropType.SelectedItem.Value.ToString(); 
				obj.Supp_Type="";
				obj.Address=txtAddress.Text.Trim();
				obj.City=DropCity.SelectedItem.Value.ToString();
				obj.State=DropState.SelectedItem.Value.ToString();
				obj.Country=DropCountry.SelectedItem.Value.ToString();
				if(txtPhoneOff.Text=="")
					obj.Tel_Off="0";
				else
					obj.Tel_Off =txtPhoneOff.Text;
				//if(txtPhoneRes.Text=="")
				//		obj.Tel_Res="0";
				//	else
				//		obj.Tel_Res =txtPhoneRes.Text;
				obj.Tel_Res="0";
				if(txtMobile.Text=="")
					obj.Mobile="0";
				else
					obj.Mobile =txtMobile.Text;
				obj.EMail =txtEMail.Text.Trim();
				if(txtOpBalance.Text=="")
					obj.Op_Balance="0";
				else
					obj.Op_Balance=txtOpBalance.Text;
				obj.Balance_Type =DropBal.SelectedItem.Value.ToString();
				//if(DropCrDay.SelectedIndex==0)
				//	obj.CR_Days="0";
				//else
				//	obj.CR_Days=DropCrDay.SelectedItem.Value.ToString();
				//obj.Tin_No = txtTinNo.Text.Trim(); 
				// call the function to insert the supplier details.
				obj.CR_Days="0";
				obj.Tin_No="0";
				if(btnedit.Visible==true)
				{
					obj.InsertSupplier();
					MessageBox.Show("Vendor Successfully Saved");
				}
				else
				{
					obj.TempCustName=TempVenderName.Text;
					obj.UpdateSupplier();

					string Ledger_ID = "";
					dbobj.SelectQuery("select Ledger_ID from Ledger_Master where Ledger_Name=(select Supp_Name from Supplier where Supp_ID='"+DropID.SelectedValue.ToString().Trim()+"')",ref SqlDtr);
					if(SqlDtr.Read())
					{
						Ledger_ID = SqlDtr.GetValue(0).ToString();
					}

					AccountledgerUpdate(Ledger_ID);
					MessageBox.Show("Vendor Successfully Updated");
					btnedit.Visible=true;
					DropID.Visible=false;
					lblSupplierID.Visible=true;
					btndelete.Visible=false;
					btnUpdate.Text="Save";
				}
	
				Clear();
				GetNextSupplierID();
				CreateLogFiles.ErrorLog("Form:Vender_Entry.aspx, Method:btnUpdate_Click "+"   Supplier_ID "+	obj.Supp_ID  +"   Supplier Type   "+obj.Supp_Type+" supplier City "+obj.City+"  IS SAVED  " +"  user  "+pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Vender_Entry.aspx, Method:btnUpdate_Click ().  EXCEPTION:  "+ ex.Message+"  user  "+pass );
			}
		}
	
		/// <summary>
		/// This method use to Clear the form.
		/// </summary>
		public void Clear()
		{
			lblSupplierID.Text="";
			txtFName.Text="";
			//txtMName.Text="";
			//txtLName.Text="";
			txtEMail.Text="";
			txtAddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			//DropType.SelectedIndex=0; 
			DropBal.SelectedIndex=0; 
			//DropCrDay.SelectedIndex=0; 
			txtPhoneOff.Text="";
			//txtPhoneRes.Text="";
			txtMobile.Text="";
			txtOpBalance.Text="";
			//txtTinNo.Text = "";
		}

		
		/// <summary>
		/// this method use to Returns the Next Supplier ID from table Supplier.
		/// </summary>
		public void GetNextSupplierID()
		{
			PartiesClass obj=new PartiesClass();
			SqlDataReader SqlDtr;
			SqlDtr =obj.GetNextSupplierID();
			while(SqlDtr.Read())
			{
				lblSupplierID.Text =SqlDtr.GetSqlValue(0) .ToString ();
				if (lblSupplierID.Text =="Null")
					lblSupplierID.Text ="1001";
			}	
			SqlDtr.Close();
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				/*InventoryClass  obj=new InventoryClass ();
				SqlDataReader SqlDtr;
				string sql;
				sql="select State,Country from Beat_Master where City='"+ DropCity.SelectedItem.Value +"'" ;
				SqlDtr=obj.GetRecordSet(sql); 
				while(SqlDtr.Read())
				{
				
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(SqlDtr.GetValue(0).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(SqlDtr.GetValue(1).ToString()))));
				
				} */ 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Supplier_Entry.aspx,Method:DropCity_SelectedIndexChanged().  EXCEPTION: "+ ex.Message+" User_ID: "+pass);
			}
		}

		/// <summary>
		/// txtPhoneOff_TextChanged...
		/// </summary>
		private void txtPhoneOff_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to fill id in dropID form supplier table.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropID.Visible=true;
				btnedit.Visible=false;
				lblSupplierID.Visible=false;
				btndelete.Visible=true;
				SqlDataReader sdtr=null;
				InventoryClass obj=new InventoryClass();
				string str=" Select Supp_Id from supplier";
				sdtr=obj.GetRecordSet(str);
				DropID.Items.Clear();
				DropID.Items.Add("Select");
				while(sdtr.Read())
				{
					DropID.Items.Add(sdtr.GetValue(0).ToString());
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Supplier_Entry.aspx, Method : btnedit_Click.  EXCEPTION: "+ ex.Message+" User_ID: "+pass);
			}
		}

		/// <summary>
		/// this Method use to fetch all the information of selected id from Supplier table.
		/// </summary>
		private void DropID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlDataReader sdtr=null;
				InventoryClass obj=new InventoryClass();
				string str="Select * from supplier where Supp_id="+DropID.SelectedValue.ToString().Trim();
				sdtr=obj.GetRecordSet(str);
				while(sdtr.Read())
				{
					txtFName.Text=sdtr["Supp_Name"].ToString();
					txtPhoneOff.Text=sdtr["Tel_Off"].ToString();
					txtMobile.Text=sdtr["Mobile"].ToString();
					txtOpBalance.Text=sdtr["Op_Balance"].ToString();
					txtAddress.Text=sdtr["Address"].ToString();
					txtEMail.Text=sdtr["EMail"].ToString();
					DropBal.SelectedValue=sdtr["Balance_Type"].ToString();
					DropCity.SelectedIndex=DropCity.Items.IndexOf(DropCity.Items.FindByValue(sdtr["City"].ToString()));
					DropState.SelectedIndex=DropState.Items.IndexOf(DropState.Items.FindByValue(sdtr["State"].ToString()));
					DropCountry.SelectedIndex=DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(sdtr["Country"].ToString()));
					TempVenderName.Text=sdtr["Supp_Name"].ToString();
				}
				sdtr.Close();
				btnUpdate.Text="Update";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Supplier_Entry.aspx, Method : DropID_SelectedIndexChanged.  EXCEPTION: "+ ex.Message+" User_ID: "+pass);
			}
		}

		/// <summary>
		/// this Method use to update closing balance of particular ledger in AccountsLedgerTables.
		/// </summary>
		public void AccountledgerUpdate(string LedgerID)
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			
			//*************************
			/*string[] CheckDate = Invoice_Date.Split(new char[] {' '},Invoice_Date.Length);
			if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(txtDate.Text)))>0)
				Invoice_Date=GenUtil.str2MMDDYYYY(txtDate.Text);
			for(int k=0;k<LedgerID.Count;k++)
			{
				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
				if(rdr.Read())
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				else
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
				rdr.Close();*/
			//*************************
			
			str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
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
		}

		/// <summary>
		/// this method use to delete record from supplior table and ledger_master table.
		/// </summary>
		private void btndelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();

				string ledger_name="";
				SqlDataReader SqlDtr1; 
				SqlCommand cmd4=new SqlCommand("select supp_name from supplier where supp_ID='"+DropID.SelectedValue.ToString()+"'",con);
				SqlDtr1=cmd4.ExecuteReader();
				while(SqlDtr1.Read())
				{
					ledger_name=SqlDtr1.GetValue(0).ToString();
				}
				SqlDtr1.Close();
				cmd4.Dispose();
				
				int ii=0,ledg_id=0;
				SqlDataReader SqlDtr2;
				SqlCommand cmd1=new SqlCommand("Select Ledger_id from Ledger_Master where Ledger_Name='"+ledger_name+"' and Sub_Grp_Id=130",con);
				SqlDtr2=cmd1.ExecuteReader();
				while(SqlDtr2.Read())
				{
					ledg_id=Convert.ToInt32(SqlDtr2.GetValue(0));
				}
				cmd1.Dispose();
				SqlDtr2.Close();
                    
				string str="Delete from Ledger_Master where Ledger_Id="+ledg_id;
				SqlCommand cmd2=new SqlCommand(str,con);
				ii=cmd2.ExecuteNonQuery();
				cmd2.Dispose();
                
				if(ii>0)
				{
					int row=0;
					string delete="Delete from supplier where supp_id='"+DropID.SelectedValue.ToString()+"'";
					dbobj.Insert_or_Update(delete,ref row);
				}

				MessageBox.Show("Vendor Successfully Deleted");
				btnedit.Visible=true;
				DropID.Visible=false;
				lblSupplierID.Visible=true;
				btndelete.Visible=false;
				btnUpdate.Text="Save";
				Clear();
				GetNextSupplierID();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Supplier_Entry.aspx, Method : btndelete_Click.  EXCEPTION: "+ ex.Message+" User_ID: "+pass);
			}
		}
	}

}

