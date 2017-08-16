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
	public class Stock : System.Web.UI.Page
	{
		
		protected System.Web.UI.WebControls.TextBox TxtRemarks;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.WebControls.DropDownList DropOutSider;
		protected System.Web.UI.WebControls.TextBox txtItem;
		protected System.Web.UI.WebControls.TextBox txtQty;
		protected System.Web.UI.WebControls.Button btnSave;
		SqlDataReader sdtr;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		protected System.Web.UI.WebControls.Label lblStockID;
		protected System.Web.UI.WebControls.DropDownList DropStockID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button BtnUpdate;
		protected System.Web.UI.WebControls.DropDownList DropUnit;
		protected System.Web.UI.WebControls.TextBox txtRate;
		protected System.Web.UI.WebControls.TextBox txtrem;
		protected System.Web.UI.WebControls.DropDownList Droplocation;
		protected System.Web.UI.WebControls.CompareValidator validatin2;
		protected System.Web.UI.WebControls.CompareValidator com1;
		protected System.Web.UI.WebControls.ValidationSummary summary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox Txtdate;
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
				CreateLogFiles.ErrorLog(" Form : Stock_Master.aspx,Method : Page_Load  User: "+ pass);     
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Stock_Master,Method : Page_Load  Exception: "+ex.Message+"  User: "+ pass);     
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				scon.Open ();	
				//string pass;
				//pass=(Session["password"].ToString ());
				fillID();
				if(! IsPostBack)
				{
					btnSave .Visible =true;
					BtnUpdate .Visible =false;
					DropStockID.Visible=false;
					Txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					//NextStockID();
					fill();
				}
				
				if(! IsPostBack)
				{
					DropStockID.Visible=false;
					lblStockID.Visible=true;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
					string SubModule="10";
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
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  Page_Load,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  Page_Load,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
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
			this.DropStockID.SelectedIndexChanged += new System.EventHandler(this.DropStockID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropOutSider.SelectedIndexChanged += new System.EventHandler(this.DropOutSider_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
			this.ID = "St";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

 
		/// <summary>
		/// this method use to Fill dropdowns from stockmaster table.
		/// </summary>
		public void fill()
		{
			try
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader sdtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select Distinct ItemCategory  From StockMaster order by ItemCategory", con );
				sdtr = cmdselect.ExecuteReader();
				DropOutSider.Items.Clear();
				DropOutSider.Items.Add("Select");
				while (sdtr.Read()) 
				{
					DropOutSider.Items.Add(sdtr.GetValue(0).ToString());
				}
				DropOutSider.Items.Add("Other");
				sdtr.Close();
				cmdselect = new SqlCommand( "Select Distinct Unit  From StockMaster order by Unit", con );
				sdtr = cmdselect.ExecuteReader();
				DropUnit.Items.Clear();
				DropUnit.Items.Add("Select");
				while (sdtr.Read()) 
				{
					DropUnit.Items.Add(sdtr.GetValue(0).ToString());
				}
				DropUnit.Items.Add("Other");
				sdtr.Close();
				cmdselect=new SqlCommand("select Distinct stocklocation from stockmaster order by stocklocation",con);
				sdtr=cmdselect.ExecuteReader();
				Droplocation.Items.Clear();
				Droplocation.Items.Add("---Select---");
				while(sdtr.Read())
				{
					if(sdtr.GetValue(0).ToString()!="")
					{
						Droplocation.Items.Add(sdtr.GetValue(0).ToString());
					}
				}
				Droplocation.Items.Add("Other");
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form: Investment.aspx.cs, Method: NextStockID. Exception: "+ex.Message+"     userid  "+ pass );
			}
		}

		/// <summary>
		/// this method use to Fill Dropdown from stock_transaction table.
		/// </summary>
		public void FillStockID()
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
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This method is used to get next stock id of stockmaster table.
		/// </summary>
		public void NextStockID()
		{
			InventoryClass obj = new InventoryClass();
			SqlDataReader SqlDtr;
			try
			{
				string str="select max(cast(Stockid as int))+1 from StockMaster";
				SqlDtr=obj.GetRecordSet(str);
				if (SqlDtr.Read()) 
				{
					lblStockID.Text=SqlDtr.GetValue(0).ToString();
					if(lblStockID.Text.Trim().Equals(""))
						lblStockID.Text="1";
					DropStockID.Visible=false;
					lblStockID.Visible=true;
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Investment.aspx.cs, Method: NextStockID. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void clear()
		{
			txtQty.Text="";
			txtRate .Text="";
			txtItem .Text ="";
			DropOutSider.SelectedIndex=0;
			DropUnit.SelectedIndex =0;
			Droplocation.SelectedIndex=0;
			txtrem .Text="";
			btnSave .Visible =true;
			BtnUpdate .Visible =false;
			DropStockID.Visible=false;
		}
	
		/// <summary>
		///  this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Visible=true;
				lblStockID.Visible=true;
				clear();
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnReset_Click,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnReset_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
		/// <summary>
		/// Method for returning the date in MM/DD/YYYY format.
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
		/// this method use to Get NextID from stockmaster table.
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
				
				cmd=new SqlCommand("select max(Stockid)+1 from StockMaster",con);
				SqlDtr=cmd.ExecuteReader();
				while(SqlDtr.Read ())
				{
					i=SqlDtr.GetValue(0).ToString ();
					lblStockID.Text=SqlDtr.GetValue(0).ToString ();
					if(i.Trim().Equals("")||SqlDtr.GetValue(0).ToString ()==null)
					{
						i="1";
						lblStockID.Text="1";
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to save information in to stockmaster table. first it check record all ready exist or not. after that save information in stockmaster and also save record in to stock_movement table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=0;
				InventoryClass obj1=new InventoryClass ();
				SqlDataReader SqlDtr;
				int count=0;
				string trandt;
				SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//fillID();
				string sdtr;
				//01.10.09 sdtr="select * from stockmaster where stockid="+lblStockID.Text;
				sdtr="select * from stockmaster where itemcategory='"+DropOutSider.SelectedItem.Value.ToString().Trim()+"' and itemname='"+txtItem.Text.ToString().Trim()+"'";
				cmdInsert=new SqlCommand(sdtr,con);
				SqlDataReader sdr=cmdInsert.ExecuteReader();
				if(sdr.HasRows)
				{
					MessageBox.Show("Record Already Exists");
					clear();
					return;
				}
				sdr.Close();


				string acc_date_from="";
				sdtr="select acc_date_from from Organisation where Organisation_id=1001";
				cmdInsert=new SqlCommand(sdtr,con);
				SqlDataReader sdr1=cmdInsert.ExecuteReader();
				if(sdr1.Read())
				{
					acc_date_from=sdr1.GetValue(0).ToString();
				}
				sdr1.Close();
				trandt=GenUtil.str2MMDDYYYY (DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year).ToString ()+" "+DateTime.Now .Hour+":"+DateTime.Now .Minute +":"+DateTime.Now .Second;
				strInsert = "Insert into StockMaster(Stockid,ItemCategory,ItemName,Quantity,Unit,Rate,Remark,stocklocation,open_bal) values (@Stockid,@ItemCategory,@ItemName,@Quantity,@Unit,@Rate,@Remark,@stocklocation,@open_bal)";
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.Parameters .Add ("@Stockid",lblStockID.Text);
				if (DropOutSider.SelectedIndex>0 &&  DropOutSider.SelectedItem.Text!="Other")  
					cmdInsert.Parameters .Add ("@ItemCategory",DropOutSider.SelectedItem.Text.Trim());
				else if(DropOutSider.SelectedItem.Text=="Other")  
					cmdInsert.Parameters .Add ("@ItemCategory",Request.Params.Get("txtItemOther"));
				if(txtItem.Text=="")
					cmdInsert.Parameters .Add ("@ItemName","");
				else
					cmdInsert.Parameters .Add ("@ItemName",txtItem.Text.Trim());
				if(txtQty.Text=="")
				{
					cmdInsert.Parameters .Add ("@Quantity","0" );
					cmdInsert.Parameters.Add("@open_bal","0");
				}
				else
				{
					cmdInsert.Parameters .Add ("@Quantity",txtQty.Text.Trim());
					cmdInsert.Parameters.Add("@open_bal",txtQty.Text.Trim());
				}
				
				if(DropUnit.SelectedIndex>0 && DropUnit.SelectedItem.Text!="Other")
					cmdInsert.Parameters .Add ("@Unit",DropUnit.SelectedItem.Text.Trim());
				else if(DropUnit.SelectedItem.Text=="Other")  
					cmdInsert.Parameters .Add ("@Unit",Request.Params.Get("txtUnit"));
  				
				if(txtRate.Text=="")
					cmdInsert.Parameters .Add ("@Rate","" );
				else
					cmdInsert.Parameters .Add ("@Rate",txtRate.Text);
				if(txtrem.Text=="")
					cmdInsert.Parameters .Add ("@Remark","" );
				else
					cmdInsert.Parameters .Add ("@Remark",txtrem.Text.Trim());
				if(Droplocation.SelectedIndex>0 && Droplocation.SelectedItem.Text!="Other")
					cmdInsert.Parameters.Add("@stocklocation",Droplocation.SelectedItem.Text);
				else if(Droplocation.SelectedItem.Text=="Other")
					cmdInsert.Parameters.Add("@stocklocation",Request.Params.Get("TxtLocation"));
				
				i=cmdInsert.ExecuteNonQuery();
				if(i==1)
				{  
					//sdtr="insert into stock_movement(itemno,tran_no,tran_date,opening,recieved,issued,closing) values ("+lblStockID.Text+",'OB','"+trandt+"',"+txtQty.Text.Trim().ToUpper()+",0,0,"+txtQty.Text.Trim().ToUpper()+")";
					sdtr="insert into stock_movement(itemno,tran_no,tran_date,opening,recieved,issued,closing) values ("+lblStockID.Text+",'OB','"+GenUtil.str2MMDDYYYY(GenUtil.trimDate(acc_date_from))+"',"+txtQty.Text.Trim().ToUpper()+",0,0,"+txtQty.Text.Trim().ToUpper()+")";
					cmdInsert=new SqlCommand(sdtr,con);
					cmdInsert.ExecuteReader();
				}
				con.Close ();
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnSave_Click,  Record saved for BillNo :"+ lblStockID.Text.ToUpper().ToString() +" , Userid :  "+ pass   );		
				//NextStockID();
				//FillStockID();
				//MessageBox.Show("Item Inserted Sucessfully In Stock");
				MessageBox.Show("Stock Successfully Saved");
				lblStockID.Visible=true;
				fillID();
				fill();
				clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}
	
		private void DropPaybleMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to fill stockid in dropdown from stockmaster table.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader sdtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//cmdselect = new SqlCommand( "Select stockid  From StockMaster order by cast (stockid as int)", con );
				cmdselect = new SqlCommand(" Select stockid From StockMaster order by cast (stockid as int)", con );
				sdtr = cmdselect.ExecuteReader();
				DropStockID.Items.Clear();
				DropStockID.Items.Add("---Select---");
				while (sdtr.Read()) 
				{
					//DropStockID.Items.Add(sdtr.GetValue(0).ToString());
					DropStockID.Items.Add(sdtr.GetValue(0).ToString());
				}
				
				sdtr.Close();
				
				btnSave .Visible =false;
				BtnUpdate .Visible =true;
				DropStockID.Visible=true;
				lblStockID.Visible=false;
				btnEdit .Visible=false;
			}
			catch(Exception ex)
			{
                
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to fetch data from stockmaster table.and show data in controls.  
		/// </summary>
		private void DropStockID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			try
			{
				if(DropStockID.SelectedIndex!=0)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string str="Select stockid,itemcategory,itemname,quantity,unit,rate,remark,Stocklocation  From StockMaster where stockid='"+DropStockID.SelectedItem.Text+"'";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						DropOutSider.SelectedIndex=DropOutSider.Items.IndexOf(DropOutSider.Items.FindByValue(SqlDtr["itemcategory"].ToString().Trim ()));
						DropUnit.SelectedIndex =DropUnit . Items.IndexOf(DropUnit .Items.FindByValue(SqlDtr["unit"].ToString().Trim ()));
						Droplocation.SelectedIndex=Droplocation.Items.IndexOf(Droplocation.Items.FindByValue(SqlDtr["Stocklocation"].ToString().Trim()));
						txtItem.Text=SqlDtr["itemname"].ToString().Trim ();
						txtQty.Text=SqlDtr["Quantity"].ToString().Trim ();
						txtRate .Text=SqlDtr["rate"].ToString().Trim ();
						txtrem.Text  =SqlDtr["remark"].ToString().Trim ();
					}
					else
					{
						MessageBox.Show("Data may be not available");
					}
				}
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  DropStockID_SelectedIndexChanged,   Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  DropStockID_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void DropOutSider_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to update information in to stockmaster table. and also update stock_movement table.
		/// </summary>
		private void BtnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=0;
				InventoryClass obj1=new InventoryClass ();
				SqlDataReader SqlDtr;
				int count=0;
				SqlConnection con;
				string strUpdate,trandt;
				SqlCommand cmdUpdate;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//fillID();
				strUpdate = "Update StockMaster set ItemCategory=@ItemCategory,ItemName=@ItemName,Quantity=@Quantity,Unit=@Unit,Rate=@Rate,Remark=@Remark,Stocklocation=@stocklocation,open_bal=@open_bal where Stockid=@Stockid";
				cmdUpdate=new SqlCommand (strUpdate,con);
				if (DropStockID .SelectedIndex>0)  
					cmdUpdate.Parameters.Add ("@Stockid",DropStockID.SelectedItem.Text.Trim ());
				else
				{
					MessageBox.Show ("Please Select Proper  Stock Id");
					return;
				}
				if (DropOutSider.SelectedIndex>0 &&  DropOutSider.SelectedItem.Text!="Other")  
					cmdUpdate.Parameters .Add ("@ItemCategory",DropOutSider.SelectedItem.Text.Trim());
				else if(DropOutSider.SelectedItem.Text=="Other")  
					cmdUpdate.Parameters .Add ("@ItemCategory",Request.Params.Get("txtItemOther"));
				if(txtItem.Text=="")
					cmdUpdate.Parameters .Add ("@ItemName","");
				else
					cmdUpdate.Parameters .Add ("@ItemName",txtItem.Text.Trim());
				if(txtQty.Text=="")
				{
					cmdUpdate.Parameters .Add ("@Quantity","0" );
					cmdUpdate.Parameters.Add("@open_bal","0");
				}
				else
				{
					cmdUpdate.Parameters .Add ("@Quantity",txtQty.Text.Trim());
					cmdUpdate.Parameters.Add("@open_bal",txtQty.Text.Trim());
				}
				
				if(DropUnit.SelectedIndex>0 && DropUnit.SelectedItem.Text!="Other")
					cmdUpdate.Parameters .Add ("@Unit",DropUnit.SelectedItem.Text.Trim());
				else if(DropUnit.SelectedItem.Text=="Other")  
					cmdUpdate.Parameters .Add ("@Unit",Request.Params.Get("txtUnit"));
				// ==================================================================
				//if(DropUnit.SelectedIndex>0 && DropUnit.SelectedItem.Text!="Other")
				//	cmdInsert.Parameters .Add ("@Unit",DropUnit.SelectedItem.Text.Trim());
				//else if(DropOutSider.SelectedItem.Text=="Other")  
				//	cmdInsert.Parameters .Add ("@Unit",Request.Params.Get("txtUnit"));
				// ========================================================================================
				trandt=GenUtil.str2MMDDYYYY (DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year).ToString ()+" "+DateTime.Now .Hour+":"+DateTime.Now .Minute +":"+DateTime.Now .Second;
				
				if(txtRate.Text=="")
					cmdUpdate.Parameters .Add ("@Rate","" );
				else
					cmdUpdate.Parameters .Add ("@Rate",txtRate.Text);

				if(txtrem.Text=="")
					cmdUpdate.Parameters .Add ("@Remark","" );
				else
					cmdUpdate.Parameters .Add ("@Remark",txtrem.Text.Trim());
				
				if(Droplocation.SelectedIndex>0 && Droplocation.SelectedItem.Text!="Other")
					cmdUpdate.Parameters.Add("@stocklocation",Droplocation.SelectedItem.Text.Trim());
				else if(Droplocation.SelectedItem.Text=="Other")
					cmdUpdate.Parameters.Add("@stocklocation",Request.Params.Get("TxtLocation"));
				
				i=cmdUpdate.ExecuteNonQuery();
				if(i==1)
				{
					//strUpdate="update stock_movement set tran_date='"+trandt+"',opening="+txtQty.Text.Trim().ToUpper()+",closing="+txtQty.Text.Trim().ToUpper()+" where itemno="+DropStockID.SelectedItem.Text.Trim ();
					strUpdate="update stock_movement set opening="+txtQty.Text.Trim().ToUpper()+",closing="+txtQty.Text.Trim().ToUpper()+" where itemno="+DropStockID.SelectedItem.Text.Trim ();
					cmdUpdate=new SqlCommand (strUpdate,con);
					cmdUpdate.ExecuteNonQuery();
				}
				con.Close ();
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  BtnUpdate_Click,  Record Updated:"+ lblStockID.Text.ToUpper().ToString() +" , Userid :  "+ pass   );		
				//NextStockID();
				//FillStockID();
				//MessageBox.Show("Item Updated Sucessfully In Stock");
				MessageBox.Show("Stock Successfully Updated");
				btnEdit.Visible=true;
				lblStockID.Visible=true;
				fillID();
				fill();
				clear();
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog(" Form : Investment.aspx,Method  BtnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
	}
}
