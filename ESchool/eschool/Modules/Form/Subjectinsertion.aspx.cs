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
using System.Data .SqlClient ;
using System.Text;
using eschool.Classes;
using RMG;
# endregion

namespace eschool.Form
{
	/// <summary>
	/// Summary description for Subjectinsertion.
	/// </summary>

	public class Subjectinsertion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtsubject;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button btnSave;
		static string  []subject={"HINDI","ENGLISH","ART","MUSIC","ART & CRAFT","CRAFT","COMPUTER","DANCE",
		"EVS","SANSKRIT","SST","BIOLOGY","MATHEMATICS","WORK EXP",
		"PHY EDU","INFORMATICS","PSHYCHOLOGY","ECONOMICS","ACCOUNTANCY","BUSINESS STUDY","PHYSICS","CHEMISTRY",
		"GEN SCIENCE","GK","MUSIC & DANCE","GSTUDIES","MORAL SCIENCE"};
		string pass;
		/// <summary>
		/// Page Load..
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				
				pass=(Session["password"].ToString ());
				# region Dropdown ClassName
				if(!Page.IsPostBack)
				{	
					FillSubject();
				}
				# endregion
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
			    return;
			}
			if(! IsPostBack)
			{
			    btnSave.Visible=true;
				btnDelete.Visible=true;
				btnEdit.Visible=false;
				btnSEdit.Visible=false;
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
				string SubModule="11";
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSEdit.Click += new System.EventHandler(this.btnSEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// Clear Function... For clearing the records in controls.
		/// </summary>
		public void Clear()
		{
		    txtsubject.Text="";
			DropDownList1.SelectedIndex=0;
		}
		/// <summary>
		/// Reset Button...
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
		   Clear();
		}
		
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
				cmd=new SqlCommand("select max(Subject_id)+1 from Subject",con);
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
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// Save Button...for saving the new Subject.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			bool flag=false;
			try
			{
				if(txtsubject.Text=="")
				{
					MessageBox.Show("Blank record can not be intserted");
					return;
				}
				else
				{
					
					string sSubject=txtsubject.Text;
					for(int i=0;i<subject.Length;i++)
					{
						if(!subject[i].Equals(sSubject.ToUpper()))
							flag=true;
						else
						{
							flag=false;
							break;
						}
					}
					if(flag==true)
					{
						string str="";
						MessageBox.Show("Please enter the correct subject name");
						for(int i=0;i<subject.Length;i++)
						{
							if(subject[i].Substring(0,1).Equals(sSubject.ToUpper().Substring(0,1)))
							{
								 str=str + subject[i]+",";
							}
						}
							if(str.Equals(""))
							{
								MessageBox.Show("Invalid Subject Name for database" );
								
								return;
							}
							else
							{
								str=str.Substring(0,str.Length-1);
								MessageBox.Show("Subject Name may be: "+str);
								return;
							}
						}
				
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlCommand scom=new SqlCommand("Select Count(Subject_name) from Subject where Subject_name='" + sSubject +"'",scon);
					SqlDataReader sdtr=scom.ExecuteReader();
					int iCount=0;
					while(sdtr.Read())
					{
						iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
					}
					if(iCount==0)                                                    ///check whether inserted subject already in database.
					{
						SqlConnection con;
						string strInsert;
						SqlCommand cmdInsert;
						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con.Open ();
						fillID();
						strInsert = "Insert Subject(Subject_id,Subject_name)values (@Subject_id,@Subject_name)";
						cmdInsert=new SqlCommand (strInsert,con);
						cmdInsert.Parameters .Add ("@Subject_id",i.Trim().ToString());
						if(txtsubject.Text=="")
							cmdInsert.Parameters .Add ("@Subject_name","");
						else
							cmdInsert.Parameters .Add ("@Subject_name",txtsubject.Text.Trim().ToUpper());
						cmdInsert.ExecuteNonQuery();
						con.Close ();
						MessageBox.Show(" New Subject Inserted");
						CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnSave_Click. New Subject: " + txtsubject.Text.Trim().ToUpper() + " is saved. User: " + pass );
						Clear();
						btnSave.Visible=true;
						btnDelete.Visible=true;
						btnEdit.Visible=false;
						btnSEdit.Visible=false;
						FillSubject();
					}
					else
					{
						MessageBox.Show("This Subject Name Already Exists");
						return;
					}
					scon.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		 
		/// <summary>
		/// Edit Button...For editing the records.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedItem.Text=="---Select---")
			{
				MessageBox.Show("Please select the subject name");
			}
			else
			{
				txtsubject.Text=DropDownList1.SelectedItem.Text.ToString();
			}
			btnSave.Visible=false;
			btnDelete.Visible=true;
			btnEdit.Visible=false;
			btnSEdit.Visible=true;
			CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnEdit_Click.  User: " + pass );
		}
		
		/// <summary>
		/// EditSave Button...For updating the Records.
		/// </summary>
		private void btnSEdit_Click(object sender, System.EventArgs e)
		{
			SqlConnection con2;
			SqlCommand cmdselect2;
			SqlDataReader dtredit2;
			string strUpdate;
			try
			{
				if(txtsubject.Text.Trim()=="")
				{
					MessageBox.Show("Blank record can not be inserted");
				}
				else
				{
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					strUpdate = "Update  Subject set Subject_name=@subject  where Subject_name=@subject1";
					cmdselect2 = new SqlCommand( strUpdate, con2);
					if (txtsubject.Text=="")
						cmdselect2.Parameters .Add ("@subject","");
					else
						cmdselect2.Parameters .Add ("@subject",txtsubject.Text.Trim().ToUpper());
					if (DropDownList1.SelectedIndex==0)
						cmdselect2.Parameters .Add ("@subject1","");
					else
						cmdselect2.Parameters .Add ("@subject1",DropDownList1.SelectedItem.Text.ToString ());
					dtredit2 = cmdselect2.ExecuteReader();
					con2.Close();
					MessageBox.Show("Subject name Updated ");
					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnEdit.Visible=false;
					btnSEdit.Visible=false;
					CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnSEdit_Click. Class: " + DropDownList1.SelectedItem.ToString () + " updated. User: " + pass ); 
					Clear();
					FillSubject();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnSEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// Delete Button...For deleting the subject name.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con10;
			SqlCommand cmdselect10;
			SqlDataReader dtredit10;
			string strdelete10;
			try
			{
				DropDownList1.Visible=true;
				if(DropDownList1.SelectedIndex==0)
				{
					MessageBox.Show("Please select the subject name to be deleted");
				}
				else
				{
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open ();
  					strdelete10 = "Delete from Subject where Subject_name =@subject_name";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					cmdselect10.Parameters .Add ("@subject_name",DropDownList1.SelectedItem.ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					con10.Close();
					MessageBox.Show("Subject Deleted");
					CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnDelete_Click. Subject: " + DropDownList1.SelectedItem.ToString () + " deleted. User: " + pass ); 
					Clear();
					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnEdit.Visible=false;
					btnSEdit.Visible=false;
					FillSubject();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: btnDelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// DropDownList SubjectName...fill the selected subject name into the textbox.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedIndex==0)
			{
			}
			else
			{
				txtsubject.Text=DropDownList1.SelectedItem.Text.ToString();
			}
		}
		/// <summary>
		/// DropDownList SubjectName...fill subject name into the DropDownList.
		/// </summary>
		public void FillSubject()
		{
			SqlConnection con;
			SqlCommand cmdselect;
			SqlDataReader dtrdrive;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select distinct Subject_name,Subject_id  From Subject order by Subject_name asc", con );
				dtrdrive = cmdselect.ExecuteReader();
				DropDownList1.Items.Clear ();  
				DropDownList1.Items .Add ("---Select---"); 
				while (dtrdrive.Read()) 
				{
					DropDownList1.Items.Add(dtrdrive.GetString(0));
				}
				dtrdrive.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subjectinsertion.aspx.cs, Method: FillSubject. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
	}
}
