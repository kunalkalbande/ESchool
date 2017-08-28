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
using System.Data.SqlClient;
using System.Text;
using RMG;
using eschool.Classes;
# endregion

namespace eschool.Library.FORMS
{
	/// <summary>
	/// Summary description for ReturnIssueBook.
	/// </summary>
	public class ReturnIssueBook : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox lblIssueCardNo;
		protected System.Web.UI.WebControls.TextBox lblBookName;
		protected System.Web.UI.WebControls.TextBox TxtDateofissue;
		protected System.Web.UI.WebControls.TextBox TxtBookID;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.CompareValidator cvCandidateId;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ValidationSummary vsReturnbook;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList ddbook;
		protected System.Web.UI.WebControls.DropDownList DropBookID;
		protected System.Web.UI.WebControls.TextBox TxtReturnDate;
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
				CreateLogFiles.ErrorLog (" Form : Return_IssueBook.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Return_IssueBook.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page .IsPostBack)
				{
					# region Dropdown
					bookID();
					# endregion
				}
				CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  Page_Load, Userid:  "+ pass   );						 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  Page_Load,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="6";
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
					btnSave.Enabled=false;
				}
				#endregion
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
			this.ddbook.SelectedIndexChanged += new System.EventHandler(this.ddbook_SelectedIndexChanged);
			this.DropBookID.SelectedIndexChanged += new System.EventHandler(this.DropBookID_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method use to add Issued bookid with member name into the ddbook dropdownBox from issue_book,staff_information and student_record table.
		/// </summary>
		public  void bookID()
		{
			ddbook.Items.Clear();
			InventoryClass obj=new InventoryClass();
			SqlDataReader sdred;
			string sql="select memberid,case when type='staff' then (select staff_name from staff_information where staff_id=issue_book.memberid) else (select student_fname from student_record where student_id=issue_book.memberid) end Name,type from issue_book";
			sdred=obj.GetRecordSet(sql);
			ddbook.Items.Add("--Select--");
			while(sdred.Read())
			{
				ddbook.Items .Add (sdred.GetValue (0).ToString ()+":"+sdred.GetValue (1).ToString ()+":"+sdred.GetValue(2).ToString());
			}
		}

		/// <summary>
		/// this Method use to fetch issue book information from issue_book table for particular member.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblIssueCardNo.Text="";
			TxtBookID.Text="";
			lblBookName.Text ="";
			TxtDateofissue.Text="";
			TxtReturnDate.Text="";
			LibraryClass.IssueBook obj= new LibraryClass.IssueBook();
			obj.memberID   =ddbook.SelectedItem .Value .ToString();
			SqlDataReader sdred;
			try
			{	 
				string sql="select Book_ID from  issue_Book  where memberID='"+ddbook.SelectedItem .Value .ToString()+"'";
				sdred=obj.ReturnBookID(sql);
				DropBookID.Items.Clear();
				DropBookID.Items.Add("--Select--");
				while(sdred.Read())
				{
					DropBookID.Items.Add(sdred.GetValue(0).ToString());
				}
				if(DropBookID.Items.Count > 1) 
				{
					ddbook.Visible=false;
					sdred.Close();
					sdred=obj.ReturnBookSearch(DropBookID.SelectedItem.Text,ddbook.SelectedItem .Value .ToString()); 
					while(sdred.Read())
					{	
						TxtBookID.Text=sdred.GetValue(0).ToString();
						lblBookName.Text =sdred.GetValue(1).ToString();
						TxtDateofissue.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(2).ToString()));
						TxtReturnDate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(3).ToString()));
					}  
				}
				else
				{
					TxtBookID.Visible=true;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  DropDownList1_SelectedIndexChanged,  Exception : "+ex.Message+"    Userid:  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void clear()
		{
			TxtBookID.Text="";
			lblBookName.Text ="";
			TxtDateofissue.Text="";
			TxtReturnDate.Text="";
			ddbook.SelectedIndex=0;
			DropBookID.Visible=false;
			TxtBookID.Visible=true;
    	}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			clear();
		}

		/// <summary>
		/// this method use to delete information with the help of DeleteissueBooks() function. and also use 'DeleteReturnBook' procedure.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				LibraryClass .IssueBook obj=new LibraryClass .IssueBook();
				string cand_id=ddbook.SelectedItem.Value.ToString();
				cand_id=cand_id.Substring(0,cand_id.IndexOf(":"));
				obj.CandidateID  =cand_id.ToString();
				if(ddbook.Visible==true)
				{
					obj.memberID=cand_id.ToString();
					if(ddbook.SelectedItem.Text=="--Select--")
					{
						MessageBox.Show(" Please Select BookID");
						return;
					}
		     	}
				obj.Book_ID=TxtBookID.Text.ToString();
				obj.DeleteissueBooks();
				CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  btnSave_Click,  CandidateID "+ddbook.SelectedItem .Value .ToString()+"  Returns Book of  BookId "+TxtBookID.Text.ToString()+  "   is saved,    Userid:  "+ pass   );
				MessageBox.Show("Issued Book Successfully Return");
				clear();
				bookID();
             }
			catch(Exception ex)
			{
			     CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  btnSave_Click,  Exception : "+ex.Message+"    Userid:  "+ pass   );				
 			}
		}

		/// <summary>
		/// If candidate issued more than one book then visible this dropdownbox,which contain bookid and on selecting bookid it gives  Book information to the control on the frame.
		/// </summary>
		private void ddbook_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TxtBookID.Text="";
			lblBookName.Text ="";
			TxtDateofissue.Text="";
			TxtReturnDate.Text="";
			try
			{
				string id=ddbook.SelectedItem.Value;
				string[] id1=id.Split(new char[] {':'});
				
				LibraryClass.IssueBook obj= new LibraryClass.IssueBook();
				obj.memberID   =ddbook.SelectedItem.Text.ToString();
				SqlDataReader sdred;
				string sql="select Book_ID from  issue_Book  where memberID='"+id1[0].ToString().Trim()+"' and type='"+id1[2].ToString().Trim()+"'";
 				sdred=obj.ReturnBookID(sql);
				DropBookID.Items.Clear();
				while(sdred.Read())
				{
					DropBookID.Items.Add(sdred.GetValue(0).ToString());
				}
				sdred.Close();
				sql= "select distinct ib.Book_ID,st.bookname,ib.Date_Of_Issue,ib.Return_Date from Issue_Book ib , Stock_table st where ib.book_id=st.book_id and ib.memberID='" + id1[0].ToString().Trim() + "' ";
				sdred=obj.ReturnBookID(sql);
				if(sdred.Read())
				{				
					TxtBookID.Text=sdred.GetValue(0).ToString();
					lblBookName.Text =sdred.GetValue(1).ToString();
					TxtDateofissue.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(2).ToString()));
					TxtReturnDate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(3).ToString()));
				}
				if(DropBookID.Items.Count>1)
				{
					DropBookID.Visible=true;
					TxtBookID.Visible=false;
				}
				else
				{
					DropBookID.Visible=false;
					TxtBookID.Visible=true;
				}
				sdred.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  Page_Load,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 
				
			}
		}

		/// <summary>
		/// this method use to fetch book information from issue_book table when we select book id.
		/// </summary>
		private void DropBookID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				LibraryClass.IssueBook obj= new LibraryClass.IssueBook();
				SqlDataReader sdred;
				if(DropBookID.Items.Count >1)
				{
					DropBookID.Visible=true;
					TxtBookID.Visible=false;
					sdred=obj.ReturnBookSearch(DropBookID.SelectedItem.Text,ddbook.SelectedItem .Value .ToString()); 
					while(sdred.Read())
					{	
						TxtBookID.Text=sdred.GetValue(0).ToString();
						lblBookName.Text =sdred.GetValue(1).ToString();
						TxtDateofissue.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(2).ToString()));
						TxtReturnDate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdred.GetValue(3).ToString()));
					}  
				}
				else
				{
					TxtBookID.Visible=true;
				}
			}
			catch(Exception ex)
			{
                    CreateLogFiles.ErrorLog(" Form : ReturnIssueBook.aspx,Method  Page_Load,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 
			}
		}
	}
}
