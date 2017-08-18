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
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient ;
using System.Text;
using RMG;
using eschool.Classes;
# endregion


namespace eschool.Library.FORMS
{
	/// <summary>
	/// Summary description for Itemform.
	/// </summary>
	public class Itemform : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TxtBookName;
		protected System.Web.UI.WebControls.TextBox TxtNumberOfBook;
		protected System.Web.UI.WebControls.Button BtnOK;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredBookName;
		protected System.Web.UI.WebControls.CompareValidator CompareBookName;
		protected System.Web.UI.WebControls.TextBox TxtPublisherName;
		protected System.Web.UI.WebControls.TextBox TxtAuthorName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblBookID;
		protected System.Web.UI.WebControls.ValidationSummary vsBookEntry;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox  txtBookID;
		protected System.Web.UI.WebControls.TextBox txtrno;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtremark;
		protected System.Web.UI.WebControls.TextBox txtpdate;
		protected System.Web.UI.WebControls.TextBox txtqty;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtsubname;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button BtnReset;
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
				CreateLogFiles.ErrorLog (" Form : Book_Entry.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Book_Entry.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}

			try
			{
				if(!Page .IsPostBack)
				{
                    txtpdate.Attributes.Add("readonly", "readonly");
                    txtpdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					increasevalueID();
					txtBookID.Visible=false;
					lblBookID.Visible=true;
				}
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method  Page_Load, Userid :  "+ pass   );
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="1";
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
						BtnOK.Enabled=false;
					}
					if(Edit_Flag=="False")
					{
						btnEdit.Enabled=false;
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method  Page_Load  , Exception : "+ex.Message + "   Userid :  "+ pass   ); 

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
			this.txtBookID.TextChanged += new System.EventHandler(this.txtBookID_TextChanged);
			this.btnEdit.Click += new System.EventHandler(this.Button1_Click);
			this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// DateTime Function for returning the date in MM/DD/YYYYY.
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
		/// this Method use to save information of book.this method also use InsertItem() function.and also use 'proInsertItem' precedure.
		/// </summary>
		private void BtnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				string msg="";
				LibraryClass .ItemClass obj =new LibraryClass.ItemClass();
				if(txtsubname .Text  =="")
					obj.subname ="";
				else
					obj.subname  =txtsubname.Text .Trim ();
				if(txtrno.Text =="")
					obj.rackno ="";
				else
					obj.rackno =txtrno.Text .Trim ();
				if(TxtBookName.Text =="")
					obj.bookname="";
				else
					obj.bookname =TxtBookName.Text .Trim ();
				if(lblBookID.Visible==true)
				{
					if(lblBookID.Text=="")
						obj.Book_ID="";
					else
						obj.Book_ID=lblBookID.Text.Trim().ToUpper();
					msg="Save";
				}
				else
				{
					if(txtBookID.Text=="")
						obj.Book_ID="";
					else
						obj.Book_ID=txtBookID.Text.Trim().ToUpper();
					msg="Update";
				}
 
				if(TxtNumberOfBook.Text=="")
					obj.bprice  ="";
				else
					obj.bprice =TxtNumberOfBook.Text.Trim();
				if(TxtAuthorName.Text =="")
					obj.aname ="";
				else
					obj.aname =TxtAuthorName.Text.Trim();
				if(txtpdate.Text=="")
					obj.pdate ="0";
				else
					obj.pdate =ToMMddYYYY(txtpdate.Text.Trim()).ToShortDateString();
    			if(txtremark.Text =="")
					obj.remark  ="";
				else
					obj.remark  =txtremark.Text.Trim ();
				if(txtqty.Text=="")
					obj.Qty=0;
				else
					obj.Qty=int.Parse(txtqty.Text);
				if(TxtPublisherName.Text =="")
					obj.pname ="";
				else
					obj.pname =TxtPublisherName.Text.Trim ();
				obj.InsertItem();
				txtBookID.Visible=false;
				lblBookID.Visible=true;
				btnEdit.Visible=true;
				MessageBox.Show("Book Information Successfully "+msg);
				clear();
				increasevalueID();
				BtnOK.Text="Save";
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method  BtnSave_Click, Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method  BtnSave_Click  , Exception : "+ex.Message + "   Userid :  "+ pass   );
					
			}
    	}

		/// <summary>
		/// this Method use to generate next id of stock_table.
		/// </summary>
		public void increasevalueID()
		{
			LibraryClass.ItemClass  obj=new LibraryClass.ItemClass();
			SqlDataReader sdred;
			try
			{
				sdred=obj.getBookID();
				while(sdred.Read())
				{
					lblBookID .Text =sdred.GetValue(0).ToString();
				}	
				if(lblBookID.Text=="")
					lblBookID.Text="1";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method : increasevalueID  , Exception : "+ex.Message + "   Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// Method for fill the purchaseid into the dropdownbox for book entry.increasevalueID()  Method for adding the next bookid to the lable.
		/// This method not in use.
		/// </summary>
		public void getpurchaseid()
		{
			LibraryClass.ProductOrderClass obj=new LibraryClass .ProductOrderClass();
			SqlDataReader sdr;
			try
			{
				sdr=obj.getClearedPuchaseID();
				while(sdr.Read())
				{
					
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method : getpurchaseid  , Exception : "+ex.Message + "   Userid :  "+ pass   );			
			}		
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void clear()
		{
			txtqty.Text ="";
			txtsubname .Text ="";
			txtrno.Text ="";
			txtBookID .Text ="";
			TxtAuthorName .Text="";
			TxtBookName .Text="";
			TxtNumberOfBook .Text="";
			TxtPublisherName .Text="";
			txtremark.Text ="";
			txtpdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}

		/// <summary>
		/// this Method use to fetch data from the stock_table with the help of ShowBookToSupplier() function. and also use 'proSelectedClickPurID' this procedure.
		/// </summary>
		private void dropPurchaseID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				LibraryClass.ProductOrderClass obj=new LibraryClass .ProductOrderClass();;
		    	SqlDataReader sdred;
				sdred=obj.ShowBookToSupplier();
				while(sdred.Read())
				{				
					TxtBookName.Text=sdred.GetValue(0).ToString();
					TxtAuthorName.Text=sdred.GetValue(1).ToString();
					TxtPublisherName .Text =sdred.GetValue(2).ToString();
					TxtNumberOfBook.Text =sdred.GetValue(3).ToString();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method :  dropPurchaseID  , Exception : "+ex.Message + "   Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			lblBookID.Visible=true;
			btnEdit.Visible=true;
			txtBookID.Visible=false;
			BtnOK.Text="Save";
			clear();
		}

		/// <summary>
		/// this method use to show and hide some control.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			btnEdit.Visible=false;
			txtBookID.Visible=true;
			lblBookID.Visible=false;
			BtnOK.Text="Update";
		}

		/// <summary>
		/// this method use to fetch book information from stock table.
		/// </summary>
		private void txtBookID_TextChanged(object sender, System.EventArgs e)
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader sdred;
			int flag=0;
			try
			{		
				string str="select * from stock_table where Book_ID="+txtBookID.Text+"";
				sdred=obj.GetRecordSet(str);
				while(sdred.Read())
				{
					TxtBookName.Text=sdred["bookname"].ToString();
					TxtAuthorName.Text=sdred["aname"].ToString();
					TxtPublisherName.Text=sdred["pname"].ToString();
					txtrno.Text=sdred["rackno"].ToString();
					TxtNumberOfBook.Text=GenUtil.strNumericFormat(sdred["price"].ToString());
					txtremark.Text =sdred["remark"].ToString ();
					txtpdate.Text =GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdred["pdate"].ToString()));
					txtqty.Text=sdred["qty"].ToString();
					txtsubname.Text =sdred["subname"].ToString ();
					flag=1;
				}
				if(flag==0)
					MessageBox.Show("Invalid Book ID");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ItemForm.aspx,Method : btnEdit_Click()  , Exception : "+ex.Message + "   Userid :  "+ pass   );
			}
		}
	}
}
