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
using RMG;
using eschool.Classes;
# endregion

namespace eschool.Lab
{
	/// <summary>
	/// Summary description for Labmast.
	/// </summary>
	public class Labmast : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtlabhallno;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator cmppin;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary vsLabMaster;
		protected System.Web.UI.WebControls.RegularExpressionValidator revLabType;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.Button btneditsave;
		protected System.Web.UI.WebControls.Button btndelete;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Label Labid;
		protected System.Web.UI.WebControls.TextBox txtlabtype;
		protected System.Web.UI.WebControls.Label Label1;
	
		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Lab_Master.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Lab_Master.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}

			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
			
				if(! IsPostBack)
				{
				    DropEdit.Visible=false;
					Labid.Visible=true;
					btnSave.Visible=true;
					btnedit.Visible=true;
					btneditsave.Visible=false;
					GetNextLABID();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
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
						//Response.Redirect("../../AccessDeny.aspx");
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					if(Add_Flag=="False")
					{
						btnSave.Enabled=false;
					}
					GetNextLABID();//Call method to get Next LabId on lebel.
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : Page_Load,  Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}

		}
		
		
		/// <summary>
		/// this method use to generate next id from lab_mast table.
		/// </summary>
		public void GetNextLABID()
		{
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr;
			string sql;
			try
			{
				sql="select max(LAB_ID)+1 from Lab_mast";
				SqlDtr =obj.GetRecordSet(sql);
				if(SqlDtr.Read())
				{
				 Labid.Text=SqlDtr.GetSqlValue(0).ToString ();
					if ( Labid.Text=="Null")
						 Labid.Text ="1";
				}		
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Room_mast.aspx,Method  GetNextBEDID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			 
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
			this.DropEdit.SelectedIndexChanged += new System.EventHandler(this.DropEdit_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btneditsave.Click += new System.EventHandler(this.btneditsave_Click);
			this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method Clear the form.
		/// </summary>
		public void Clear()
		{
		    Labid.Text="";
			txtlabtype.Text="";
			txtlabtype.Text="";
			txtlabhallno.Text="";
		}
		
		/// <summary>
		/// this method reset the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}
		

		/// <summary>
		/// Method for saving the Lab Master Records in lab_mast table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (txtlabtype.Text == string.Empty)
                {
                    errorMessage.Append("- You Must Enter Lab Name");
                    errorMessage.Append("\n");
                }
                if (txtlabhallno.Text == string.Empty)
                {
                    errorMessage.Append("- You Must Enter Lab No.");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }
                string sLabName=txtlabtype.Text;
				SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				strInsert = "Insert Lab_mast(lab_id,labname,Hall_no)values (@lab_id,@labname,@Hall_no)";
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.Parameters .Add ("@lab_id",Labid.Text.Trim().ToString());
				if(txtlabtype.Text=="")
					cmdInsert.Parameters .Add ("@labname","");
				else
					cmdInsert.Parameters .Add ("@labname",txtlabtype.Text.Trim().ToUpper());
				if(txtlabhallno.Text=="")
					cmdInsert.Parameters .Add ("@Hall_no","");
				else
					cmdInsert.Parameters .Add ("@Hall_no",txtlabhallno.Text.Trim().ToUpper());
				cmdInsert.ExecuteNonQuery();
				
				con.Close ();
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnSave_Click  , labID:"+ Labid.Text.Trim().ToUpper()+",LabType: "+txtlabtype.Text.Trim().ToUpper() +",Hall No :"+ txtlabhallno.Text.Trim().ToUpper() +" is saved,     Userid :  " + pass   );
				MessageBox.Show("Lab Information Successfully Saved");
				Clear();
				GetNextLABID();                                                      //call to get the next labid.
				DropEdit.Visible=false;
				Labid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this Method use to Add the labid into the EditDrop for edit.
		/// </summary>
		public void labid()
		{
			try
			{
				DropEdit.Items.Clear();
				DropEdit.Items.Add("--Select--");
				SqlConnection con;
				string str;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//str = "Select Lab_id from lab_mast";
				str = "Select Lab_id,labname from lab_mast";
				cmd=new SqlCommand (str,con);
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					//DropEdit.Items.Add(dr.GetValue(0).ToString());
					DropEdit.Items.Add(dr.GetValue(0).ToString()+":"+dr.GetValue(1).ToString());
				}
				dr.Close();
			}
			catch(Exception ex)
			{

			}

		}
		/// <summary>
		/// Method for visible control and  adding the labid into the dropdownbox for edit.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropEdit.Visible=true;
				Labid.Visible=false;
				btnSave.Visible=false;
				btnedit.Visible=false;
				btneditsave.Visible=true;
				labid();                                    //call to add the lab_id  into the DropEdit.
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnEdit_Click  , Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnEdit_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// Mehtod use to show all the information of selected id from lab_mast table.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				string lab_Id=DropEdit.SelectedItem.Value;
				string[] lab_name=lab_Id.Split(new char[]{':'});
				SqlConnection con;
				string str;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//str = "Select labname,hall_no from lab_mast where lab_id='" + DropEdit.SelectedItem.Value.ToString () + "'";
				str = "Select labname,hall_no from lab_mast where lab_id='" + lab_name[0].ToString () + "'";
				cmd=new SqlCommand (str,con);
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					txtlabhallno.Text=dr.GetValue(1).ToString();
					txtlabtype.Text=dr.GetValue(0).ToString();
				}
				dr.Close();
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : dropEdit_SelectedIndexChanged  , Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : dropEdit_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this Method use to save and update information in to lab_mast table.
		/// </summary>
		private void btneditsave_Click(object sender, System.EventArgs e)
		{
			try
			{

				string lab_Id=DropEdit.SelectedItem.Value;
				string[] lab_name=lab_Id.Split(new char[]{':'});

				string sLabName=txtlabtype.Text;
				SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//strInsert = "update Lab_mast set labname=@labname,Hall_no=@Hall_no where lab_id='"+DropEdit.SelectedItem.Text.ToString()+"'";
				strInsert = "update Lab_mast set labname=@labname,Hall_no=@Hall_no where lab_id='"+lab_name[0].ToString()+"'";
				cmdInsert=new SqlCommand (strInsert,con);
				if(txtlabtype.Text=="")
					cmdInsert.Parameters .Add ("@labname","");
				else
					cmdInsert.Parameters .Add ("@labname",txtlabtype.Text.Trim().ToUpper());
				if(txtlabhallno.Text=="")
					cmdInsert.Parameters .Add ("@Hall_no","");
				else
					cmdInsert.Parameters .Add ("@Hall_no",txtlabhallno.Text.Trim().ToUpper());
				cmdInsert.ExecuteNonQuery();
				con.Close ();
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnUpdate_Click , labID:"+ Labid.Text.Trim().ToUpper()+",LabType: "+txtlabtype.Text.Trim().ToUpper() +",Hall No :"+ txtlabhallno.Text.Trim().ToUpper() +" is Updated,     Userid :  " + pass   );
				MessageBox.Show("Lab Information Successfully Updated");
				Clear();
				GetNextLABID();                                                       //call for getting the  next labid.
				DropEdit.Visible=false;
				Labid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btnUpdate_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this Method use to delete the Records from lab_mast table.
		/// </summary>
		private void btndelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string str;
			SqlCommand cmd;
			try
			{

				string lab_Id=DropEdit.SelectedItem.Value;
				string[] lab_name=lab_Id.Split(new char[]{':'});

				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//str = "delete lab_mast where lab_id='"+DropEdit.SelectedItem.Text.ToString()+"'";
				str = "delete lab_mast where lab_id='"+lab_name[0].ToString()+"'";
				cmd=new SqlCommand (str,con);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Lab Information Successfully Deleted");
				Clear();                                                              //call method for clear the form.
				GetNextLABID();
				DropEdit.Visible=false;
				Labid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btndelete_Click  ,Lab information Deleted for Lab_id "+DropEdit.SelectedItem.Text.ToString()+"  Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labmast.aspx.cs,Method : btndelete_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
	}
}	 


