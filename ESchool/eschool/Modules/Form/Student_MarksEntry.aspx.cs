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
using RMG;
using System.Text ;
using eschool.Classes ;

# endregion

namespace eschool.Forms
{
	/// <summary>
	/// Summary description for Student_MarksEntry.
	/// </summary>
	public class Student_MarksEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropStudID;
		protected System.Web.UI.WebControls.DropDownList Droptest;
		protected System.Web.UI.WebControls.TextBox Txtclass;
		protected System.Web.UI.WebControls.TextBox txtStream;
		protected System.Web.UI.WebControls.TextBox TxtFname;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.CompareValidator cvStudentId;
		protected System.Web.UI.WebControls.CompareValidator cvExam;
		protected System.Web.UI.WebControls.DropDownList DropteacherName;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.TextBox TxtSubject;
		protected System.Web.UI.WebControls.TextBox TxtMarks;
		protected System.Web.UI.WebControls.RequiredFieldValidator Refpinco;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.ValidationSummary vsStuMarks;
		protected System.Web.UI.WebControls.Button btnSave;
		string pass;
		# region Page Load...
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
//				if(Session["view"]!=null)
//				{
//					try
//					{
//						if(Session["password"].ToString().Length<=0&&(bool)Session["view"]==false)
//						{
//							Session.Abandon();
//							Session.RemoveAll();
//							//Cache.Remove("view");
//							Response.Redirect(@"./HolidayEntryForm.aspx",false);
//						}
//						else
//						{
//							Response.Buffer=false;
//							Response.CacheControl="no-cache";
//							Response.Expires=System.DateTime.Now.Minute-1;	
//							Session["view"]=false;
//						}
//					}
//					catch(Exception ex)
//					{
//						CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
//						Session.Abandon();
//						Response.Redirect(@".\HolidayEntryForm.aspx");
//					}
//				
//				}
//				else
//				{
//					Response.Buffer=false;
//					Response.CacheControl="no-cache";
//					Response.Expires=System.DateTime.Now.Minute-1;
//					Session["view"]=false;
//				}
				try
				{
					pass=(Session["password"].ToString());
				}
				catch(Exception ex)
				{
					Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
					CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
					return;
				}
				
				
				
				//string pass;
			//pass=(Session["password"].ToString ());
			if(!Page .IsPostBack)
				{
				  # region Dropdown SrudentID
					SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
					SqlDataReader sdred;
					sdred=obj.showStudentIDInCombo();
					while(sdred.Read())
					{
						DropStudID.Items .Add (sdred.GetValue(0).ToString());
				
					}
				# endregion
				}
				StaffName();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="1";
				string SubModule="8";
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
					Response.Redirect("../AccessDeny.aspx");
				}
				if(Add_Flag=="False")
				{
					btnSave.Enabled=false;
				}
				#endregion
			}
		}
		# endregion

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
			this.DropStudID.SelectedIndexChanged += new System.EventHandler(this.DropStudID_SelectedIndexChanged);
			this.DropteacherName.SelectedIndexChanged += new System.EventHandler(this.DropteacherName_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		# region DropStudID_SelectedIndexChanged...
		private void DropStudID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		 try
		   {
			   SchoolClass .SchoolMgs obj=new SchoolClass .SchoolMgs ();
			   obj.Student_ID=DropStudID.SelectedItem .Value .ToString();
			   SqlDataReader sdred;
			   sdred=obj.ShowStudentInfo();
			   while(sdred.Read())
			   {
				   TxtFname.Text=sdred.GetString(0) + " " + sdred.GetString(1) + " " + sdred.GetString(2);
				   txtStream .Text =sdred.GetValue(4).ToString();
				   Txtclass .Text=sdred.GetValue(3).ToString();
			   }
		   }
		catch(Exception ex)
		{
			 CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: DropStudID_SelectedIndexChanged. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
		}
		}
		# endregion

		# region StaffName Function...
		public void StaffName()
		{
			try
			{
				if(!Page .IsPostBack)
				{
					SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
					SqlDataReader sdred;
					sdred=obj.getStaffName(); 
					while(sdred.Read())
					{
						DropteacherName.Items .Add (sdred.GetValue(0).ToString());
				
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: StaffName. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		# endregion

		# region DropteacherName_SelectedIndexChanged...
		private void DropteacherName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj=new SchoolClass .SchoolMgs ();
				obj.Staff_Name=DropteacherName .SelectedItem .Value .ToString();
				SqlDataReader sdred;
				sdred=obj.ShowSubjectNameForAssignmentEntry ();
				while(sdred.Read())
				{				
					TxtSubject .Text =sdred.GetValue(0).ToString();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: DropteacherName_SelectedIndexChanged. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		# endregion

//		# region Save Button...
//		private void Save_ServerClick(object sender, System.EventArgs e)
//		{
//			try
//			{
//				SchoolClass .SchoolMgs obj=new SchoolClass .SchoolMgs ();
//				obj.Student_ID =DropStudID .SelectedItem .Value .ToString();
//				if(Droptest.SelectedIndex==0)
//                obj.Test="0";
//				else
//				obj.Test =Droptest .SelectedItem .Value .ToString();
//				if(TxtSubject.Text=="")
//				obj.Name_Subject="";
//				else
//				obj.Name_Subject =TxtSubject.Text.Trim();
//				if(TxtMarks.Text=="")
//					obj.Marks="";
//				else
//				obj.Marks =TxtMarks.Text.Trim();
//				obj.InsertStudentMarks();
//				Clear();
//				MessageBox.Show("Marks Sucessfully Insert");
//				
//			}
//			catch
//			{
//
//			}
//		}
//		# endregion

		# region Clear Function...
		public void Clear()
		{
			Droptest.SelectedIndex=0;
			TxtSubject.Text="";
			TxtMarks.Text="";
			TxtFname.Text="";
           	Txtclass.Text="";
			txtStream.Text="";
			DropStudID.SelectedIndex=0;
			DropteacherName.SelectedIndex=0;
		}
		# endregion

		# region Reset button...
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			 Clear();
			Response.Redirect("StudentMarksEntry.aspx");
			 
		}
		# endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj=new SchoolClass .SchoolMgs ();
				obj.Student_ID =DropStudID .SelectedItem .Value .ToString();
				if(Droptest.SelectedIndex==0)
					obj.Test="0";
				else
					obj.Test =Droptest .SelectedItem .Value .ToString();
				if(TxtSubject.Text=="")
					obj.Name_Subject="";
				else
					obj.Name_Subject =TxtSubject.Text.Trim();
				if(TxtMarks.Text=="")
					obj.Marks="";
				else
					obj.Marks =TxtMarks.Text.Trim();
				obj.InsertStudentMarks();
				MessageBox.Show("Student marks saved");
				CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: btnSave_Click. New Marks for student ID " + DropStudID .SelectedItem .Value .ToString() + " of subject " + TxtSubject.Text + " saved. User: " + pass );
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_MarksEntry.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		
		}
	}
}
