/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/

   # region DIRECTIVES
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
using RMG;
using System.Text;
using eschool.Classes;
# endregion

namespace eschool.Roles
{
	/// <summary>
	/// Summary description for RoleMaster.
	/// </summary>
	public class RoleMaster : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox txtRole;
		protected System.Web.UI.WebControls.Button brnaddNew;
		protected System.Web.UI.WebControls.RegularExpressionValidator revRole;
		protected System.Web.UI.WebControls.Label lblRoleName;
		protected System.Web.UI.WebControls.Label lblNewRoleName;
		protected System.Web.UI.WebControls.ValidationSummary vsRole;
		protected System.Web.UI.WebControls.Button btnEditSave;
		protected System.Web.UI.WebControls.Button buttonDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiValidation1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRole;
	
		
		string pass;
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+pass);		
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					# region 
 
					btnEditSave.Visible=false;
					//btnEdit.Visible=true;
					buttonDelete.Visible=true;
				    brnaddNew.Visible=true;
                    getRollID();                                       ///Call method getting the  roll name into dropdownbox.
 
					# endregion
					fillID();
				}
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  PageLoad,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 			} 
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="1";
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
				
				if(View_flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(Add_Flag=="False")
					brnaddNew.Enabled=false;
				if(Edit_Flag=="False")
				{
					//btnEdit.Enabled=false;
					btnEditSave.Enabled=false;
				}
				if(Del_Flag=="False")
					buttonDelete.Enabled=false;
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
			this.brnaddNew.Click += new System.EventHandler(this.brnaddNew_Click);
			this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to add role name in dropdown from Roles table.
		/// </summary>
		public void getRollID()
		{
			try
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader dtrdrive;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select Role_Name From Roles", con );
				dtrdrive = cmdselect.ExecuteReader();
				DropDownList1.Items.Clear();
				DropDownList1.Items.Add("---Select---");
				while (dtrdrive.Read()) 
				{
					DropDownList1.Items.Add(dtrdrive.GetString(0));
				}
				dtrdrive.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  getRollID(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
  			} 
		}

		string i="";
		/// <summary>
		/// This method is used to fatch the next Role ID from Roles table and stored in textbox.
		/// </summary>
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(Role_ID)+1 from Roles",con);
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
		/// this Method use to saveinformation of new Role in to Roles table.
		/// </summary>
		private void brnaddNew_Click(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedIndex==0)
			{
				try
				{
					if(txtRole.Text=="")
					{
						MessageBox.Show("Blank record may not be entered");
					}
					else
					{
						SqlConnection con;
						SqlCommand cmdselect;
						SqlDataReader dtrdrive;
						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con.Open ();
						fillID();
						string sRole=txtRole.Text;
						cmdselect = new SqlCommand( "Select Count(Role_Name)  From Roles where Role_Name='" + sRole + "'", con );
						dtrdrive = cmdselect.ExecuteReader();
						int iCount=0;
						while(dtrdrive.Read())
						{
							iCount=Convert.ToInt32(dtrdrive.GetSqlValue(0).ToString());
						}
						if(iCount==0)                                                         ///Checked whether entering roll name is existing or not.
						{
							SqlConnection con4;
							string strInsert4;
							SqlCommand cmdInsert4;
							con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							con4.Open ();
							strInsert4 = "Insert Roles(Role_ID,Role_Name)values (@Role_ID,@Role_Name)";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters .Add ("@Role_ID",i.Trim().ToString());
							if(txtRole.Text=="")
								cmdInsert4.Parameters .Add ("@Role_Name","");
							else
								cmdInsert4.Parameters .Add ("@Role_Name",txtRole.Text.ToString().Trim());
							cmdInsert4.ExecuteNonQuery();
							con4.Close ();
							MessageBox.Show("New Role Saved");
							CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  PageLoad,  Role Name :"+txtRole.Text.ToString().Trim()+" Saved, Userid :  "+ Session["Password"].ToString()   );		
							clear();
							getRollID();                                                       ///call method to add existing roll name into the dropdownbox.
						}
						else
						{
							MessageBox.Show("This Role Name Already Exists");
 					     
						}
					}
					CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnAddNew_Click,  Userid :  "+ Session["Password"].ToString()   );		
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnAddNew_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
				 
				}
			}
			else
			{
				SqlConnection con2;
				SqlCommand cmdselect2;
				SqlDataReader dtredit2;
				string strUpdate;
				try
				{
					brnaddNew.Visible=true;
					buttonDelete.Visible=true;
					btnEditSave.Visible=false;
					if(tempRole.Value=="")
					{
						MessageBox.Show("Blank record may not be entered");
					}
					else
					{
						lblNewRoleName.Text="Add New Role";
						brnaddNew.Visible=true;
						buttonDelete.Visible=true;
						btnEditSave.Visible=false;
						con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con2.Open ();
						strUpdate = "Update Roles set Role_Name=@Role_Name where Role_Name=@Role_Name2";
						cmdselect2 = new SqlCommand( strUpdate, con2);
						if(txtRole.Text=="")
							cmdselect2.Parameters .Add ("@Role_Name","");
						else
							cmdselect2.Parameters .Add ("@Role_Name",tempRole.Value.ToString().Trim());
						if(DropDownList1.SelectedIndex==0)
							cmdselect2.Parameters .Add ("@Role_Name2","");
						else
							cmdselect2.Parameters .Add ("@Role_Name2",DropDownList1.SelectedItem.ToString ());
						dtredit2 = cmdselect2.ExecuteReader();
						MessageBox.Show("Role Updated");
						CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnUpdate_Click,  RoleName :"+DropDownList1.SelectedItem.ToString () +" Updated , Userid :  "+ Session["Password"].ToString()   );	
						clear();
						getRollID();                                                         ///calling the method for getting the existing roll name into the dropdownbox.
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
				}
			}
		}
		
		/// <summary>
		/// this Method use to update Roles information in to roles table.
		/// </summary>
		private void btnEditSave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con2;
			SqlCommand cmdselect2;
			SqlDataReader dtredit2;
			string strUpdate;
			try
			{
				brnaddNew.Visible=true;
				buttonDelete.Visible=true;
				btnEditSave.Visible=false;
				if(txtRole.Text=="")
				{
 					MessageBox.Show("Blank record may not be entered");
				}
				else
				{
					lblNewRoleName.Text="Add New Role";
					brnaddNew.Visible=true;
					buttonDelete.Visible=true;
					btnEditSave.Visible=false;
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
                    strUpdate = "Update Roles set Role_Name=@Role_Name where Role_Name=@Role_Name2";
				    cmdselect2 = new SqlCommand( strUpdate, con2);
				    if(txtRole.Text=="")
						cmdselect2.Parameters .Add ("@Role_Name","");
					else
						 cmdselect2.Parameters .Add ("@Role_Name",txtRole.Text.ToString().Trim());
					if(DropDownList1.SelectedIndex==0)
						 cmdselect2.Parameters .Add ("@Role_Name2","");
					else
						 cmdselect2.Parameters .Add ("@Role_Name2",DropDownList1.SelectedItem.ToString ());
			       dtredit2 = cmdselect2.ExecuteReader();
				   MessageBox.Show("Role Updated");
				   CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnUpdate_Click,  RoleName :"+DropDownList1.SelectedItem.ToString () +" Updated , Userid :  "+ Session["Password"].ToString()   );	
				   clear();
				   getRollID();                                                          ///calling the method for getting the existing roll name into the dropdownbox.
  				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
 			}
		}
           
		/// <summary>
		/// this Method use to Delete record from Roles table.
		/// </summary>
		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con10;
			SqlCommand cmdselect10;
			SqlDataReader dtredit10;
			string strdelete10;
			try
			{
           		if(DropDownList1.SelectedIndex==0)
				{
 					MessageBox.Show("Please select the Role name to be deleted");
				}
				else
				{
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open ();
					strdelete10 = "Delete from Roles where Role_Name =@Role_Name";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					cmdselect10.Parameters .Add ("@Role_Name",DropDownList1.SelectedItem.ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					MessageBox.Show("Role successfully deleted");
                    CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnDelete_Click,  RoleName :"+DropDownList1.SelectedItem.ToString () +" Deleted , Userid :  "+ Session["Password"].ToString()   );						
					clear();                                                         /// call method for clear the form.
				    getRollID();                                                     ///call method for adding the existing roll name into the dropdownbox.
					brnaddNew.Visible=true;
					buttonDelete.Visible=true;
					btnEditSave.Visible=false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  btnDelete_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );		
			}
		}

		/// <summary>
		/// this Method for clear the form.
		/// </summary>
		public void clear()
		{
			txtRole.Text="";
			DropDownList1.SelectedIndex=0;
		}

		/// <summary>
		/// Add the selected Roll name into the TextBox.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropDownList1.SelectedIndex==0)
				{
					MessageBox.Show("Please select the Role name");
					return;
				}
				else
				{
					txtRole.Text=DropDownList1.SelectedItem.Text.ToString();
				}
				brnaddNew.Visible=false;
				buttonDelete.Visible=true;
				btnEditSave.Visible=true;
				lblNewRoleName.Text="   Edit Name";
				CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method : DropEdit_SelectedIndexChanged,  Userid :  "+ Session["Password"].ToString()   );		
			}
			catch(Exception ex)
			{
                CreateLogFiles.ErrorLog(" Form : RoleMaster.aspx,Method  DropEdit_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ Session["Password"].ToString()   );	
			}
		}
	}
}
