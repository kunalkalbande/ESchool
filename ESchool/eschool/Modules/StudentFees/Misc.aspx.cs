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
	/// Summary description for Misc.
	/// </summary>
	public class Form2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.ValidationSummary svMisc;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText DropCountryValue;
		protected System.Web.UI.WebControls.DropDownList DropEmpID;
		protected System.Web.UI.WebControls.TextBox txtEmpID;
		protected System.Web.UI.WebControls.TextBox txtqty;
		protected System.Web.UI.WebControls.TextBox txtdate;
		protected System.Web.UI.WebControls.TextBox txtremark;
		protected System.Web.UI.WebControls.TextBox txtEmpName;
		protected System.Web.UI.WebControls.DropDownList DropItemCategory;
		protected System.Web.UI.WebControls.Label lblIssueID;
		protected System.Web.UI.WebControls.DropDownList DropIssueID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList DropItemName;
		protected System.Web.UI.WebControls.Button btnSave;
		SqlDataReader sdtr;
		SqlCommand scom;
		protected System.Web.UI.WebControls.DropDownList DropUnit;
		protected System.Web.UI.WebControls.DropDownList Droplocation;
		protected System.Web.UI.WebControls.CompareValidator CompairValidation1;
		protected System.Web.UI.WebControls.CompareValidator compvadation1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqvali1;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		protected System.Web.UI.WebControls.Label Label4;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Issue_Items.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Issue_Items.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
			 	if(!IsPostBack)
				{
                    txtdate.Attributes.Add("readonly", "readonly");
                    fill();
					fillID();
					btnUpdate.Visible =false;
					btnSave .Visible =true;
					DropUnit.Items.Clear();
					DropUnit.Items.Add("Select");
					DropItemName.Items.Clear();
					DropItemName.Items.Add("Select");
					Droplocation.Items.Clear();
					Droplocation.Items.Add("Select");
					txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="7";
					string SubModule="6";
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

				if(!IsPostBack)
				{
					FillIssueID();
					DropIssueID.Visible=false;
				}
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad, Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;
			}
		}

		/// <summary>
		/// this method use to Fill the DropDown from stockmaster table and staff_information table.
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
				DropItemCategory.Items.Add("Select");
				while(dr1.Read())
				{
					DropItemCategory.Items.Add(dr1.GetValue(0).ToString());
				}
				dr1.Close();
				cmd1=new SqlCommand("Select Staff_id,staff_name from staff_information",scon1);
				dr1=cmd1.ExecuteReader();
				while(dr1.Read())
				{
					DropEmpID.Items.Add(dr1.GetValue(0).ToString()+":"+dr1.GetValue(1).ToString());
				}
				dr1.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.DropIssueID.SelectedIndexChanged += new System.EventHandler(this.DropIssueID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropEmpID.SelectedIndexChanged += new System.EventHandler(this.DropEmpID_SelectedIndexChanged);
			this.DropItemCategory.SelectedIndexChanged += new System.EventHandler(this.DropItemCategory_SelectedIndexChanged);
			this.txtqty.TextChanged += new System.EventHandler(this.txtqty_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.ID = "Form2";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
 
		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void Clear()
		{
			DropEmpID .SelectedIndex=0;
			DropItemName.SelectedIndex=0;
			DropItemCategory .SelectedIndex=0;	
			DropItemName.SelectedIndex=0;
			txtqty.Text="";
			DropUnit.SelectedIndex=0;
			Droplocation.SelectedIndex=0;
			txtremark.Text="";
			txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			if(btnEdit.Visible==true)
			{
				Clear();
			}
			else
			{
				btnUpdate .Visible =false;
				btnSave .Visible =true;
				btnEdit.Visible=true;
				lblIssueID.Visible=true;
				DropIssueID.Visible=false;
				///DropEmpID.Items.Clear();
				///DropEmpID.Items.Add("Select");
				DropEmpID.SelectedIndex=0;
				//DropItemCategory.Items.Clear();
				DropItemCategory.SelectedIndex=0;
				DropItemName.Items.Clear();
				DropItemName.Items.Add("Select");
				DropItemName.SelectedIndex=0;
				DropUnit.Items.Clear();
				DropUnit.Items.Add("Select");
				DropUnit.SelectedIndex=0;
				Droplocation.Items.Clear();
				Droplocation.Items.Add("Select");
				Droplocation.SelectedIndex=0;
				txtqty.Text="";
				txtremark.Text="";
				txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			}
		}
		
		/// <summary>
		/// this Method use to generate next id from stock_transaction table.
		/// </summary>
		string i="";
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select Tran_no from stock_transaction where st_id=(select max(st_id) from stock_transaction where tran_no like '%I%')",con);
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
						lblIssueID.Text=no.ToString ();
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to save information in to stock_transaction table with the help of ProInsertStockTransaction() function and also use 'ProInsertStockTransaction' procedure. and record also save in stock_movement table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropEmpID.SelectedIndex!=0)
				{
					string itemname;
					InventoryClass obj1=new InventoryClass();
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string quty="";
					double closing=0,opening=0;
					string qty,trano,vendorname;
					DateTime bldate;
					if(DropItemName.SelectedIndex==0)                                     
					{
						obj.Itemname=""; 
						itemname="";
					}
					else
					{
						string name=DropItemName.SelectedItem.Text.Trim ();
						string[] emp=name.Split(new char[] {':'},name.Length); 
						itemname=emp[0];
						obj.Itemname=emp[0];
					 }
					string str="select closing from stock_movement where itemno="+itemname+" order by tran_date desc";                        
					SqlDtr=obj1.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						quty=SqlDtr.GetValue(0).ToString();
					}
					SqlDtr.Close();
					if(txtqty.Text!="")
					{
						if(int.Parse(quty)<int.Parse(txtqty.Text))
						{
							MessageBox.Show("Qty is greater then stockqty");
							txtqty.Text="";
							return;
						}
					}
					string st_id="";
					str="select max(st_id)+1 from stock_transaction";                     
					SqlDtr=obj1.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						if(SqlDtr.GetValue(0).ToString()!=null && SqlDtr.GetValue(0).ToString()!="")
							st_id=SqlDtr.GetValue(0).ToString();
						else
							st_id="1";
					}
					SqlDtr.Close();
					obj.IssueID = lblIssueID.Text.Trim().ToString();
 					if(st_id!=""||st_id!=null)
					{
						obj.ST_ID=st_id;
					}
					else
					{
						MessageBox.Show("Some Problem in database");
						CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnSave_Click,  Error is that Stock Transaction id is not found  , Userid :  "+ pass   );		
						return ;
					}
					obj.Tran_Type="ISSUE";
     				str="select Tran_No from stock_Transaction where tran_type Like '%ISSUE%' order by tran_date desc";
					SqlDtr =obj1.GetRecordSet (str);
					if(SqlDtr.Read())
					{
						if(SqlDtr.GetString(0)!=null &&  SqlDtr.GetString(0)!="")
						{
							int  TNo=Convert.ToInt32 (SqlDtr.GetString(0).Substring(2));
							TNo=TNo+1;
							obj.Tran_No ="I:"+TNo.ToString();
							trano="I:"+TNo.ToString();     
						}
						else
						{
							obj.Tran_No ="I:1";
							trano="I:1";
						}				
					}
					else
					{
						obj.Tran_No ="I:1";
						trano="I:1";
					}	 

					/*if(DropEmpID.SelectedIndex==0)
					{
						obj.Vendor_Name="";
						vendorname="";
					}
					else 
					{
						obj.Vendor_Name=DropEmpID.SelectedItem.Text.Trim();
						vendorname=DropEmpID.SelectedItem.Text.Trim();
						
					}*/

					if(DropEmpID.SelectedIndex==0)                                       
					{
						obj.EmpID=""; 
						obj.Vendor_Name="";
						vendorname="";
					}
					else
					{
						string empid=DropEmpID.SelectedItem.Text.Trim ();
						string[] emp=empid.Split(new char[] {':'},empid.Length); 
						obj.EmpID=emp[0];
						obj.Empname=emp[1];
						obj.Vendor_Name=DropEmpID.SelectedItem.Text.Trim();
						vendorname=DropEmpID.SelectedItem.Text.Trim();
						
					}	

				
					if(txtqty.Text=="")
					{
						obj.Qty="";
						qty="";
					}
					else
					{
						obj.Qty=txtqty.Text;
						qty=txtqty.Text;
					}
					
					if(txtqty.Text=="")
						obj.Qty ="";
					else
						obj.Qty  =txtqty.Text.ToString().Trim ();
				

					if(txtdate.Text=="")
					{
						obj.Issuedate ="";
						
					}
					else
					{
						obj.Issuedate=GenUtil.str2MMDDYYYY(txtdate.Text.ToString().Trim ());
						
					}
					obj.Place="0";
					obj.Stock_Location=Droplocation.SelectedItem.Text;
					obj.Rate="0";
					obj.BillDate="";
					obj.BillNo="0";
					obj.Vehicle="0";
					obj.Trans_Date=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtdate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
					bldate=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtdate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
					if(txtremark.Text=="")
						obj.Remarks  ="";
					else
						obj.Remarks   =txtremark.Text.ToString().Trim ();
					if(DropItemCategory.SelectedIndex==0)
						obj.ItemCategory="";
					else
						obj.ItemCategory=DropItemCategory.SelectedItem.Text.Trim();
					obj.ProInsertStockTransaction();         
					SqlConnection scon;
					SqlCommand cmd;
					SqlDataReader dtr;
					scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					str="select closing from stock_movement where itemno="+itemname+" order by tran_date desc";
					cmd=new SqlCommand(str,scon);
					dtr=cmd.ExecuteReader();
					if(dtr.Read())
					{
						closing=Convert.ToDouble(dtr.GetValue(0));
						opening=closing;
						closing=closing-Convert.ToDouble(obj.Qty);
					}
					dtr.Close();
					str="insert into stock_movement (itemno,tran_no,tran_date,opening,recieved,issued,closing) values('"+itemname+"','"+trano+"','"+GenUtil.str2MMDDYYYY(bldate.ToString())+"',"+opening+",0,"+qty+","+closing+")";
					cmd=new SqlCommand(str,scon);
					cmd.ExecuteNonQuery();
					MessageBox.Show("Transaction Successfully Saved");
					CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnSave_Click, Userid :  "+ pass   );		
					FillIssueID();
					clear1();
					fill();
				}
				else
				{
					MessageBox.Show("Please Select Employee ID");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}
	
		private void DropType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			 
		}

		private void DropEmpID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
		
	

		private void chkTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void chkNonTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		
		/// <summary>
		/// this Method use to generate next id of stock_transaction table.
		/// </summary>
		public void FillIssueID()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="select Tran_no from stock_transaction where tran_no like '%I%'";
				int no=1;
				SqlDtr=obj.GetRecordSet(str);
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
				}
				lblIssueID.Text=no.ToString ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to fetch record from stoc_transaction table of a selected id.
		/// </summary>
		private void DropIssueID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropIssueID.SelectedIndex!=0)
			{
				try
				{
					btnUpdate .Visible =true;
					btnSave .Visible =false;
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
            	    string str="select * from stock_transaction st,stockmaster sm where tran_no like '%I:"+DropIssueID.SelectedItem.Text.Trim()+"' and stockid=item_id";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						///DropEmpID.Items.Clear();
						///DropEmpID.Items.Add(SqlDtr["Vendor_name"].ToString().Trim ());
						DropEmpID.SelectedIndex=DropEmpID.Items.IndexOf(DropEmpID.Items.FindByValue(SqlDtr["Vendor_name"].ToString().Trim ()));
						txtdate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Tran_date"].ToString().Trim()));
						DropItemName.Items.Clear();
						DropItemName.Items.Add(SqlDtr["stockid"].ToString().Trim()+":"+SqlDtr["ItemName"].ToString().Trim());
						DropItemName.SelectedIndex=DropItemCategory.Items.IndexOf(DropItemCategory.Items.FindByValue(SqlDtr["ItemName"].ToString().Trim()));
						///DropItemCategory.Items.Clear();
						///DropItemCategory.Items.Add(SqlDtr["Itemcategory"].ToString().Trim());
						DropItemCategory.SelectedIndex=DropItemCategory.Items.IndexOf(DropItemCategory.Items.FindByValue(SqlDtr["Itemcategory"].ToString().Trim()));
						DropUnit.Items.Clear();
						DropUnit.Items.Add(SqlDtr["unit"].ToString().Trim());
						DropUnit.SelectedIndex=DropItemCategory.Items.IndexOf(DropItemCategory.Items.FindByValue(SqlDtr["unit"].ToString().Trim()));
						Droplocation.Items.Clear();
						Droplocation.Items.Add(SqlDtr["stock_loc"].ToString().Trim());
						Droplocation.SelectedIndex=DropItemCategory.Items.IndexOf(DropItemCategory.Items.FindByValue(SqlDtr["stock_loc"].ToString().Trim()));
					    txtqty .Text=SqlDtr["item_qty"].ToString();
						txtremark .Text=SqlDtr["Remark"].ToString();
					}
					else
					{
						MessageBox.Show("Data not available");
					}
				}
				catch(Exception ex)
				{
                      CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				}
			}
		}

		/// <summary>
		/// this method use to fetch id from stock_transaction table and add in dropdown.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				//string str="select Tran_no from stock_transaction where tran_no like '%I%'";
				string str="select Tran_no from stock_transaction where tran_no like '%I%'";
				int no=1;
				DropIssueID.Items.Clear();
				DropIssueID.Items.Add("Select");
				SqlDtr=obj.GetRecordSet(str);
				while(SqlDtr.Read ())
				{
					if(SqlDtr.GetString(0)!=null||SqlDtr.GetString(0)!="")
					{	
						if(SqlDtr.GetString (0).IndexOf(":")==1)
						{
							DropIssueID.Items.Add(Convert.ToInt32(SqlDtr.GetString (0).Substring(2)).ToString());
						}
					}
				}
				btnUpdate .Visible =true;
				btnSave .Visible =false;
				DropIssueID.Visible=true;
				lblIssueID.Visible=false;
				btnEdit.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to update record in to stock_transaction table with the help of UpdateStockTransaction() function and also use 'ProUpdateStockTransaction' procedure.also update record in stock_movement table.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr;
				string itemname,qty="",Qty="";
				DateTime bldate;
               	double closing=0,opening=0;
				string itemidname=DropItemName.SelectedItem.Text;
				string[] itemid=itemidname.Split(new char[] {':'},itemidname.Length);
				string str="";
				/*
				string str="select closing from stock_movement where itemno="+itemid[0]+" order by tran_date desc";
				SqlDtr=obj1.GetRecordSet(str);
				if(SqlDtr.Read())
				{
					qty=SqlDtr["closing"].ToString().Trim();
				}
				if(txtqty.Text!="")
				{
					if(int.Parse(qty)<int.Parse(txtqty.Text))
					{
						MessageBox.Show("Qty is greater then stockqty");
						txtqty.Text="";
						return;
					}
				}*/
				obj.IssueID = DropIssueID.SelectedItem.Text.Trim().ToString();
				if(DropIssueID.SelectedIndex ==0)
				{
					MessageBox.Show ("Please Select Stock ID");
				}
				else
				{
					obj.ST_ID=DropIssueID.SelectedItem.Text.Trim ();
					obj.Vendor_Name=DropEmpID.SelectedItem.Text.Trim();
				}
				obj.Place="0";
				obj.Rate="0";
				obj.BillNo="0";
				obj.BillDate="";
				obj.Vehicle="0";

				if(Droplocation.SelectedItem.Text.Trim()=="")
                   obj.Stock_Location="";
				else
				   obj.Stock_Location=Droplocation.SelectedItem.Text.Trim();

				if(DropIssueID.SelectedIndex!=0)
				{
					obj.Tran_No ="I:"+DropIssueID.SelectedItem .Text.Trim() ;
				}
				else
				{
					MessageBox.Show("Please Select Issue Id");
					return;
				}
				string name=DropItemName.SelectedItem .Text.Trim ();
				name=name.Substring(0,name.IndexOf(":")); 
				obj.Itemname=name;
				itemname=name;
			    obj.Itemname=itemid[0];
				if(txtqty.Text=="")
					obj.Qty ="";
				else
					obj.Qty  =txtqty.Text.ToString().Trim ();
				obj.Trans_Date=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtdate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
				bldate=System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(txtdate.Text)+" "+DateTime.Now.TimeOfDay.ToString());
				if(txtdate.Text=="")
					obj.Issuedate ="";
				else
					obj.Issuedate=GenUtil.str2DDMMYYYY(txtdate .Text.ToString().Trim ());
				if(txtremark.Text=="")
					obj.Remarks  ="";
				else
					obj.Remarks   =txtremark.Text.ToString().Trim ();
				if(DropItemCategory.SelectedIndex==0)
					obj.ItemCategory="";
				else
					obj.ItemCategory=DropItemCategory.SelectedItem.Text.Trim();
				
				obj.UpdateStockTransaction();
				SqlConnection scon;
				SqlCommand cmd;
				SqlDataReader dtr;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				/*str="select closing from stock_movement where itemno="+itemname+" order by tran_date desc";
				cmd=new SqlCommand(str,scon);
				dtr=cmd.ExecuteReader();
				if(dtr.Read())
				{
					closing=Convert.ToDouble(dtr.GetValue(0));
					opening=closing;
					closing=closing-Convert.ToDouble(obj.Qty);
				}
				dtr.Close();*/
                //str="update stock_movement set tran_date='"+bldate+"',Issued="+txtqty.Text.ToString().Trim()+",closing="+closing+" where itemno="+itemname+" and Tran_no = 'I:"+ DropIssueID.SelectedItem.Text .Trim()+"'" ;
				//str="update stock_movement set tran_date='"+bldate+"',Issued="+txftqty.Text.ToString().Trim()+" where itemno="+itemname+" and Tran_no = 'I:"+ DropIssueID.SelectedItem.Text .Trim()+"'" ;
				str="update stock_movement set tran_date='"+ GenUtil.str2MMDDYYYY(bldate.ToString()) +"',Issued="+txtqty.Text.ToString().Trim()+" ,itemno="+itemname+" where Tran_no = 'I:"+ DropIssueID.SelectedItem.Text .Trim()+"'" ;
				cmd=new SqlCommand(str,scon);
				cmd.ExecuteNonQuery();
				StockMasterUpdate(itemname);
				MessageBox.Show("Transaction Successfully Updated");
				clear1();
				fillID();
				fill();
				DropIssueID.Visible=false;
				btnUpdate.Visible=false;
				btnSave.Visible=true;
				lblIssueID.Visible=true;
				btnEdit.Visible=true;
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnUpdate_Click, Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Misc.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void clear1()
		{
			DropEmpID.Items.Clear();
			DropEmpID.Items.Add("Select");
			DropEmpID.SelectedIndex=0;
			DropItemCategory.Items.Clear();
            DropItemCategory.Items.Add("Select");
            DropItemCategory.SelectedIndex=0;
			DropItemName.Items.Clear();
			DropItemName.Items.Add("Select");
			DropItemName.SelectedIndex=0;
			DropUnit.Items.Clear();
			DropUnit.Items.Add("Select");
			DropUnit.SelectedIndex=0;
			Droplocation.Items.Clear();
			Droplocation.Items.Add("Select");
			Droplocation.SelectedIndex=0;
			txtqty.Text="";
			txtremark.Text="";
			txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}
	
		/// <summary>
		/// this method use to fill dropdowns from stockmaster table.
		/// </summary>
		private void DropItemCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1=null;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				if(DropItemCategory.SelectedIndex >0)
				{
					cmd1=new SqlCommand("select distinct stockid, itemname,stocklocation from stockmaster where itemcategory='"+DropItemCategory.SelectedItem.Text +"'",scon1);

					dr1=cmd1.ExecuteReader();
					DropItemName.Items.Clear();
					DropItemName.Items.Add("Select");

					while(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							DropItemName.Items.Add(dr1.GetValue(0).ToString()+":"+dr1.GetValue(1).ToString());
						}
					}

					dr1.Close();

					cmd1=new SqlCommand("select distinct stocklocation from stockmaster where itemcategory='"+DropItemCategory.SelectedItem.Text +"'",scon1);

					dr1=cmd1.ExecuteReader();
					Droplocation.Items.Clear();
					Droplocation.Items.Add("Select");

					while(dr1.Read())
					{
						if(dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="")
						{
							Droplocation.Items.Add(dr1.GetValue(0).ToString());
						}
					}
					dr1.Close();

					cmd1=new SqlCommand("select distinct Unit from stockmaster where itemcategory='"+DropItemCategory.SelectedItem.Text +"'",scon1);

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
				CreateLogFiles.ErrorLog ("Form: Misc.aspx.cs, Method: DropItemName_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void chkactivity_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void chkgroupd_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void txtqty_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to update closing balance of stock_movement table from the date. 
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
					//CS=OS+double.Parse(rdr1["received"].ToString())-(double.Parse(rdr1["issued"].ToString())+double.Parse(rdr1["salesfoc"].ToString()));
					Con.Open();
					cmd = new SqlCommand("update Stock_Movement set opening='"+OS.ToString()+"', Closing='"+CS.ToString()+"' where itemno="+itemname1+" and Tran_Date='"+rdr1["Tran_date"].ToString()+"'",Con);
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
