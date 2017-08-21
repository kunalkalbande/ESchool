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
using System.Data .SqlClient;
using eschool.Classes;
using System.Text;
using RMG;
# endregion

namespace eschool.Library.FORMS
{
	/// <summary>
	/// Summary description for IssueBookDuplicate.
	/// </summary>
	public class IssueBookDuplicate : System.Web.UI.Page
	{
		//protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		//protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
	    protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtIssue;
		protected System.Web.UI.WebControls.TextBox txtReturn;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.ValidationSummary vsBookIssue;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox txtbname;
		static int status=0;
		protected System.Web.UI.WebControls.RadioButton rediteaching;
		protected System.Web.UI.WebControls.RadioButton redistudent;
		protected System.Web.UI.WebControls.DropDownList droptype;
		protected System.Web.UI.WebControls.Panel panemployee;
		protected System.Web.UI.WebControls.Panel PaneStudent;
        protected System.Web.UI.HtmlControls.HtmlInputHidden texthidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden texthidden1;
		protected System.Web.UI.WebControls.TextBox TxtEmpid;
		protected System.Web.UI.WebControls.TextBox TxtEmpName;
		protected System.Web.UI.WebControls.TextBox TxtStudid;
		protected System.Web.UI.WebControls.TextBox TxtStudName;
	
		SqlDataReader sdred,sdtr;
		protected System.Web.UI.WebControls.Panel PanEmpid;
		protected System.Web.UI.HtmlControls.HtmlInputText DropIssueBookID;
		protected System.Web.UI.WebControls.Panel PanStudid;
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
				CreateLogFiles.ErrorLog (" Form : Book_issue.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Book_Issue.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
                    txtIssue.Attributes.Add("readonly", "readonly");
                    txtReturn.Attributes.Add("readonly", "readonly");
                    txtIssue.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtReturn.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					LibraryClass .CardGenerationClass obj=new LibraryClass.CardGenerationClass();
					showBooKID();

					LibraryClass.IssueBook obj1=new LibraryClass.IssueBook();
                    sdtr=obj1.showBookID();
					while(sdtr.Read())
					{
                           texthidden1.Value+=sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString()+","; 
					}
					sdtr.Close();
					texthidden1.Value="Select,"+texthidden1.Value;
					
                }
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="6";
					string SubModule="2";
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
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : Page_load  , Exception: " + ex.Message + " User: " + pass );
			}			
		}
		
		/// <summary>
		/// Method for adding avilable book_id to the Dropdownbox.
		/// </summary>
		public void showBooKID()
		{
			LibraryClass.IssueBook obj=new LibraryClass.IssueBook();
			SqlDataReader sdred;
			try
			{
				sdred=obj.showBookID();
				while(sdred.Read())
				{
					texthidden.Value+=sdred.GetValue(0).ToString()+",";
				}
				sdred.Close();
			}
			catch(Exception ex)
			{
			
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : ShowBookID  , Exception :  "+ex.Message+"   Userid :  "+ pass   );									
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
			this.rediteaching.CheckedChanged += new System.EventHandler(this.rediteaching_CheckedChanged);
			this.redistudent.CheckedChanged += new System.EventHandler(this.redistudent_CheckedChanged);
			this.TxtEmpid.TextChanged += new System.EventHandler(this.TxtEmpid_TextChanged);
			this.TxtStudid.TextChanged += new System.EventHandler(this.TxtStudid_TextChanged);
			this.txtbname.TextChanged += new System.EventHandler(this.txtbname_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Method for getting the Book name of selected bookid and avilable stok of selected bookid.
		/// this method not in use.
		/// </summary>
		private void DropIssueBookID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				
			}
			catch(Exception ex)
			{
	    		  CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : ShowBookID  , Exception :  "+ex.Message+"   Userid :  "+ pass   );									
			} 
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
        private void dropCandidateID_SelectedIndexChanged(object sender, System.EventArgs e)
		{   
			
				
		}

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
		/// this method use to clear the form.
		/// </summary>
		public void Clear()
		{
			txtIssue.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtReturn.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		   	txtbname.Text="";
			TxtEmpid.Text="";
			TxtEmpName.Text="";
			TxtStudid.Text="";
			TxtStudName.Text="";
			PanStudid.Visible=false;
			PanEmpid.Visible=false;
			rediteaching.Checked=false;
			redistudent.Checked=false;
			DropIssueBookID.Value="Select";
		}

		/// <summary>
		/// this method use to Reset form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// This Method use to check one book can not issue same candidate
		/// </summary>	
		public bool checkbook()
		{
			string bookid=DropIssueBookID.Value;
			bookid=bookid.Substring(0,bookid.IndexOf(":"));
			string sql="";
 			LibraryClass .IssueBook obj=new LibraryClass.IssueBook();
			if(rediteaching.Checked==true)
			{
				sql="select memberID from issue_book where Book_ID='"+bookid.ToString()+"' and memberID='"+TxtEmpid.Text.ToString()+"'";
			}
			else if(redistudent.Checked==true)
			{
				sql="select memberID from issue_book where Book_ID='"+bookid.ToString()+"' and memberID='"+TxtEmpid.Text.ToString()+"'";
			}
     		sdred=obj.CandidateCount(sql);
			int candidate=0;
			while(sdred.Read())
			{				
				candidate=int.Parse(sdred.GetValue(0).ToString()); 
			}
			sdred.Close();
			
			if(candidate!=0)
			{
				MessageBox.Show("can not issue book to same candidate");
				return false;
			}
			else
			{
				return true;
			}
		}

 		/// <summary>
		/// this method use to Get IssueBookID.
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
				cmd=new SqlCommand("select max(IssueBookID)+1 from Issue_Book",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						i=SqlDtr.GetValue(0).ToString ();
						if(i.Trim().Equals(""))
						i="1";
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}	

		/// <summary>
		/// Method for saving the Issue Book Information. this method use to InsertItemIssueBook() function.and also use 'proInsertIssueBook' procedure.
		/// </summary>	
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(redistudent.Checked!=true && rediteaching.Checked!=true)
				{
					MessageBox.Show("Please Select Member Type");
					return;
				}
				else
				{
					if(TxtEmpid.Text!="" || TxtStudid.Text!="")
					{
						if(!checkbook())
						{
							return;
						}
						DateTime dt=System.DateTime.Now;
						DateTime dIssue=Convert.ToDateTime(ToMMddYYYY(txtIssue.Text));
						System.TimeSpan diff=dIssue.Subtract(dt);
						int iDays=diff.Days;
						fillID();
						string bookid=DropIssueBookID.Value;
						bookid=bookid.Substring(0,bookid.IndexOf(":"));
						if(iDays == 0)
						{
							if(DateTime.Compare(ToMMddYYYY(Request.Form["txtReturn"]),ToMMddYYYY(txtIssue.Text))>0)
							{
								LibraryClass .IssueBook obj=new LibraryClass.IssueBook ();
								
								if(PanEmpid.Visible==true)
								{
								obj.memberID=TxtEmpid.Text.ToString();
								}
								else if(PanStudid.Visible==true)
								{
									obj.memberID=TxtStudid.Text.ToString();
								}
								if(status==1)
								{
									MessageBox.Show("Candidate used all card");
									status=0;
									return;
								}
						    	if(DropIssueBookID.Value.ToString()=="")
									obj.Book_ID="0";
								else
									obj.Book_ID =bookid.ToString();

     							if(txtIssue.Text=="")
									obj.Date_Of_Issue ="0";
								else
									//obj.Date_Of_Issue =ToMMddYYYY(txtIssue.Text.Trim()).ToShortDateString();
                                obj.Date_Of_Issue = GenUtil.str2MMDDYYYY(txtIssue.Text);
                                if (txtReturn.Text == "")
                                    obj.Return_Date = "0";
                                else
                                    //obj.Return_Date =ToMMddYYYY(txtReturn.Text.Trim()).ToShortDateString();
                                    obj.Return_Date = GenUtil.str2MMDDYYYY(txtReturn.Text);
								obj.IssueBookID =i.Trim().ToString();
								if(rediteaching.Checked==true)
									obj.MemType=rediteaching.Text;
								else if(redistudent.Checked==true)
									obj.MemType=redistudent.Text;
                        		obj.InsertItemIssueBook();
								DropIssueBookID.Value="Select";
								if(TxtEmpid.Text=="")
								{
									CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method  btnSave_Click, BookId    "+DropIssueBookID.Value+"   Issued for CandidateId "+TxtStudid.Text+"     Userid:  "+ pass   );
								}
								else
								{
									CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method  btnSave_Click, BookId    "+DropIssueBookID.Value+"   Issued for CandidateId "+TxtEmpid.Text+"     Userid:  "+ pass   );
								}
								MessageBox.Show("Book Successfully Issued");
    						}
							else
							{
								MessageBox.Show("Return date must be greater than issue date");
							}
						}
						else
						{
							MessageBox.Show(" Issue date must be equal to current date"); 
						}
					}
					else
					{
						MessageBox.Show("Please Enter Member ID");
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : btnSave_Click  , Exception : "+ex.Message + "   Userid :  "+ pass   );						 
			}
           Clear();
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtbname_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void rediteaching_CheckedChanged(object sender, System.EventArgs e)
		{
		    PanEmpid.Visible=true;
			PanStudid.Visible=false;
		}

		/// <summary>
		/// this Method use to fill the dropdown with Staff Name.
		/// </summary>	
		public void stafftype()
		{
			try
			{ 
				SqlConnection con1;
				SqlCommand cmd1;
				SqlDataReader dr1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open();
				cmd1=new SqlCommand("select distinct staff_name from staff_type where teaching=1 order by staff_name",con1);
				dr1=cmd1.ExecuteReader();
				droptype.Items.Clear();
				droptype.Items.Add("Select");
				while(dr1.Read())
				{
					droptype.Items.Add(dr1.GetValue(0).ToString());
				}
				dr1.Close();
			}
			catch(Exception ex)
            {
               	CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : btnSave_Click  , Exception : "+ex.Message + "   Userid :  "+ pass   );						 
			}
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void redistudent_CheckedChanged(object sender, System.EventArgs e)
		{
			PanEmpid.Visible=false;
			PanStudid.Visible=true;
			
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void droptype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this Method use to fill the Staff Name in textbox.
		/// </summary>	
		private void TxtEmpid_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				cmd1=new SqlCommand("select staff_name from staff_information where staff_id='"+TxtEmpid.Text+"'",scon1);
				dr1=cmd1.ExecuteReader();
				if(dr1.HasRows)
				{
					while(dr1.Read())
					{
					    TxtEmpName.Text=dr1.GetValue(0).ToString();
					}
				}
				else
				{
					    MessageBox.Show("In Valid Id");
					    TxtEmpName.Text="";
					    TxtEmpid.Text="";
				}
				dr1.Close();
			}
			catch(Exception ex)
         	{
              
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : btnSave_Click  , Exception : "+ex.Message + "   Userid :  "+ pass   );						 
			}
		}

		/// <summary>
		/// this Method use to fill the dropdown with Student Name from student_record table.
		/// </summary>	
		private void TxtStudid_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				cmd1=new SqlCommand("select student_fname from student_record where student_id='"+TxtStudid.Text+"'",scon1);
				dr1=cmd1.ExecuteReader();
				if(dr1.HasRows)
				{
					while(dr1.Read())
					{
						TxtStudName.Text=dr1.GetValue(0).ToString();
					}
				}
				else
				{
					MessageBox.Show("In Valid Id");
					TxtStudName.Text="";
					TxtStudid.Text="";
				}
				dr1.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : IssueBookDuplicate.aspx,Method : btnSave_Click  , Exception : "+ex.Message + "   Userid :  "+ pass   );						 
			}
		}
	}
}

