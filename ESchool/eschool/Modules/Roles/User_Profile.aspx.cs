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
using eschool.SchoolClass;
using RMG;
using System.Text;
using eschool.Classes;
# endregion

namespace eschool.Roles
{
	/// <summary>
	/// Summary description for User_Profile.
	/// </summary>
	
	public class User_Profile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFName;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox txtLName;
		protected System.Web.UI.WebControls.Label lblUserID;
		protected System.Web.UI.WebControls.DropDownList DropRole;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnSaveProfile;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassward;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvName;
		protected System.Web.UI.WebControls.ValidationSummary vsUserProfile;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDesc;
		protected System.Web.UI.WebControls.CompareValidator cvRole;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvLoginName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMiddleName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revLastName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.Button btneditsave;
		protected System.Web.UI.WebControls.Button btndelete;
		protected System.Web.UI.WebControls.TextBox txtLoginName;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtHidden1;
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
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  PageLoad,  Exception: "+ex.Message+" User : "+pass);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
			
				if(!IsPostBack)
				{
                    btnSaveProfile.Visible=true;
					btndelete.Visible=true;
					btnedit.Visible=true;
					btneditsave.Visible=false;
					DropEdit.Visible=false;

					# region Add Roll_Name into the Dropdown box.
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string sql;
 					sql="select Role_Name from Roles";
					SqlDtr=obj.GetRecordSet(sql);
					DropRole.Items.Add("---Select---");
					while(SqlDtr.Read())
					{
						DropRole.Items.Add(SqlDtr.GetValue(0).ToString()); 
					}
					SqlDtr.Close();
					GetNextUserID();											//call method for getting the next userid.
				# endregion

					# region 
					/// <summary>
					/// Add Login_Name and Passward into hidden text box.
					/// </summary>
					SchoolClass.SchoolMgs obj1=new SchoolClass.SchoolMgs();
					//SqlDataReader SqlDtr;
					//string sql;
					sql="select Loginname,password from user_master";
					SqlDtr=obj1.GetRecordSet(sql);
					while(SqlDtr.Read())
					{
						TxtHidden1.Value+=(SqlDtr.GetValue(0).ToString().Trim()+":"+SqlDtr.GetValue(1).ToString().Trim()+","); 
					}
					SqlDtr.Close();
					
					# endregion
				}
			 
				if(! IsPostBack)
				{
					#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="1";
				string SubModule="5";
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
						btnSaveProfile.Enabled=false;
					}
				#endregion
				}
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  PageLoad,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 	
		}
		
		/// <summary>
		/// this Method use to saving the user profile into the user_master table. before save the information first check record all ready exist or not.
		/// </summary>
		private void btnSaveProfile_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand scmd;
			SqlDataReader dtrdrive;
			try
			{
				if(txtLoginName.Text=="" || txtPassword.Text=="" || txtFName.Text=="" || DropRole.SelectedIndex==0)
				{ 	
					return;
				}
				else
				{	
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					string sLoginName=txtLoginName.Text;
					scmd = new SqlCommand( "Select Count(LoginName)  From User_Master where LoginName='" + sLoginName + "'", con );
					dtrdrive = scmd.ExecuteReader();
					int iCount=0;
					while(dtrdrive.Read())
					{
						iCount=Convert.ToInt32(dtrdrive.GetSqlValue(0).ToString());
					}
					dtrdrive.Close ();
					if(iCount==0)                                                    ///Checked whether login name already exists or not.
					{
						string sName=txtFName.Text.ToString()+" "+txtMName.Text.ToString()+" "+txtLName.Text.ToString();
						string strInsert1 = "Insert User_Master(UserID,LoginName,Password,UserFName,UserMName,UserLName,Role_Name,Description)values (@UserID,@LoginName,@Password,@UserFName,@UserMName,@UserLName,@Role_Name,@Description)";
						scmd=new SqlCommand (strInsert1,con);
						scmd.Parameters .Add ("@UserID",lblUserID.Text.ToString());
						if(txtLoginName.Text=="")
							scmd.Parameters .Add ("@LoginName","");
						else
							scmd.Parameters .Add ("@LoginName",txtLoginName.Text.ToString().Trim());
						if(txtPassword.Text=="")
							scmd.Parameters .Add ("@Password","");
						else
							scmd.Parameters .Add ("@Password",txtPassword.Text.ToString().Trim());
						if(txtFName.Text=="")
							scmd.Parameters .Add ("@UserFName","");
						else
							scmd.Parameters .Add ("@UserFName",txtFName.Text.ToString().Trim());
						if(txtMName.Text=="")
							scmd.Parameters .Add ("@UserMName","");
						else
							scmd.Parameters .Add ("@UserMName",txtMName.Text.ToString().Trim());
						if(txtLName.Text=="")
							scmd.Parameters .Add ("@UserLName","");
						else
							scmd.Parameters .Add ("@UserLName",txtLName.Text.ToString().Trim());
						if(DropRole.SelectedIndex==0)
							scmd.Parameters .Add ("@Role_Name","");
						else
							scmd.Parameters .Add ("@Role_Name",DropRole.SelectedItem.Text.ToString());
						if(txtDescription.Text=="")
							scmd.Parameters .Add ("@Description","");
						else
							scmd.Parameters .Add ("@Description",txtDescription.Text.ToString().Trim());
						scmd.ExecuteNonQuery();
						con.Close ();
						CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnSaveProfile_Click, User_Profile saved for UserID:"+lblUserID.Text.ToString()+", Userid :  "+ pass   );		
						MessageBox.Show("User Profile Saved");
						Clear("User Profile Created");
						GetNextUserID();                                              ///Mehtod call for getting the next userid.
						btnSaveProfile.Visible=true;
						btndelete.Visible=true;
						btnedit.Visible=true;
						btneditsave.Visible=false;
						DropEdit.Visible=false;
					}
					else
					{
						MessageBox.Show("This login name already exists");
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnSaveProfile_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
//		
//		/// <summary>
//		/// Required method for Designer support - do not modify
//		/// the contents of this method with the code editor.
//		/// </summary>
		private void InitializeComponent()
		{    
			this.DropEdit.SelectedIndexChanged += new System.EventHandler(this.DropEdit_SelectedIndexChanged);
			this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btneditsave.Click += new System.EventHandler(this.btneditsave_Click);
			this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void Clear(string Message)
		{
            lblUserID.Text="";
			txtLoginName.Text="";
			txtPassword.Text="";
			txtFName.Text="";
			txtMName.Text="";
			txtLName.Text="";
			DropRole.SelectedIndex=0;
			txtDescription.Text="";
		}

 		/// <summary>
		/// this Method for getting the next userid.
		/// </summary>
		public void GetNextUserID()
		{
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr;
			string sql;
			try
			{
				sql="select max(UserID)+1 from User_Master";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					lblUserID.Text=SqlDtr.GetSqlValue(0).ToString ();
					if (lblUserID.Text=="Null")
						lblUserID.Text ="1";
				}		
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  GetNextUserID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 	
		}

 		/// <summary>
		/// Method used for adding the user information to the controls on the page as per the userid selected.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			Clear("User Profile Created");
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr;
			
			string sql;
			try
			{				 
				sql="select * from User_Master where userid='"+DropEdit.SelectedItem.Text.ToString()+"'";
				SqlDtr =obj.GetRecordSet(sql);
				while(SqlDtr.Read())
				{
					txtLoginName.Text=SqlDtr.GetValue(1).ToString();
                    txtPassword.Text=SqlDtr.GetValue(2).ToString();
					txtDescription.Text=SqlDtr.GetValue(7).ToString();
					txtFName.Text=SqlDtr.GetValue(3).ToString();
					txtMName.Text=SqlDtr.GetValue(4).ToString();
					txtLName.Text=SqlDtr.GetValue(5).ToString();
                    DropRole.SelectedIndex=DropRole.Items.IndexOf(DropRole.Items.FindByValue(SqlDtr.GetValue(6).ToString()));
				}		
				SqlDtr.Close();
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  DropEdit_SelectedIndexChanged  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  DropEdit_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 			} 	
		 }


		/// <summary>
		/// Mehod for returning the date in MM/DD/YYYY format.
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
		/// Method for visible control and adding the exists userid into the dropdownbox for edit.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			SqlDataReader SqlDtr;
			string sql;
			try
			{				 
				sql="select UserID from User_Master";
				SqlDtr =obj.GetRecordSet(sql);
				DropEdit.Items.Clear ();
				DropEdit.Items .Add ("---Select---"); 
				while(SqlDtr.Read())
				{
					DropEdit.Items.Add(SqlDtr.GetValue(0).ToString());
				}		
				SqlDtr.Close();
				btnSaveProfile.Visible=false;
				btndelete.Visible=true;
				btnedit.Visible=false;
				btneditsave.Visible=true;
				lblUserID.Visible=false;
				DropEdit.Visible=true;
				DropEdit.SelectedIndex =0;
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnEdit_Click  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnEdit_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 			} 	
		}

		/// <summary>
		/// this Method use to delete the user information from user_master table.
		/// </summary>
		private void btndelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con3;
			SqlCommand cmdselect3;
			try
			{
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				string str="Delete user_master where userid='"+DropEdit.SelectedItem.Text.ToString()+"'";
				cmdselect3=new SqlCommand(str,con3);
				cmdselect3.ExecuteNonQuery();
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btndelete_Click, User_Profile delete for userid="+DropEdit.SelectedItem.Text.ToString()+"    Userid :  "+ pass   );						
				Clear("User Profile Created");
				//MessageBox.Show("Record Deleted");
				MessageBox.Show("User Profile Deleted");
				btnSaveProfile.Visible=true;
				btndelete.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				DropEdit.Visible=false;
				lblUserID.Visible=true;
				GetNextUserID ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btndelete_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 			}
		}

		/// <summary>
		/// Method for Save the user information in to user_master table.
		/// </summary>
		private void btneditsave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand scmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string sLoginName=txtLoginName.Text;
				if(txtLoginName.Equals ("") || txtFName.Equals ("")||txtLName.Equals ("")|| DropRole.SelectedIndex ==0 )
				{
					MessageBox.Show ("- Login Name or \n - User Name or \n - Role is blank");
					return;
				}
				string sName=txtFName.Text.ToString()+" "+txtMName.Text.ToString()+" "+txtLName.Text.ToString();
				string strInsert1 = "Update User_Master set LoginName=@LoginName,UserFName=@UserFName,UserMName=@UserMName,UserLName=@UserLName,Role_Name=@Role_Name,Description=@Description,password=@password  where userid='"+DropEdit.SelectedItem.Text.ToString()+"'";
				scmd=new SqlCommand (strInsert1,con);
				scmd.Parameters .Add ("@UserID",lblUserID.Text.ToString());
				if(txtLoginName.Text=="")
					scmd.Parameters .Add ("@LoginName","");
				else
					scmd.Parameters .Add ("@LoginName",txtLoginName.Text.ToString().Trim());
				if(txtPassword.Text=="")
					scmd.Parameters .Add ("@Password","");
				else
					scmd.Parameters .Add ("@Password",txtPassword.Text.ToString().Trim());
				if(txtFName.Text=="")
					scmd.Parameters .Add ("@UserFName","");
				else
					scmd.Parameters .Add ("@UserFName",txtFName.Text.ToString().Trim());
				if(txtMName.Text=="")
					scmd.Parameters .Add ("@UserMName","");
				else
					scmd.Parameters .Add ("@UserMName",txtMName.Text.ToString().Trim());
				if(txtLName.Text=="")
					scmd.Parameters .Add ("@UserLName","");
				else
					scmd.Parameters .Add ("@UserLName",txtLName.Text.ToString().Trim());
				if(DropRole.SelectedIndex==0)
					scmd.Parameters .Add ("@Role_Name","");
				else
					scmd.Parameters .Add ("@Role_Name",DropRole.SelectedItem.Text.ToString());
				if(txtDescription.Text=="")
					scmd.Parameters .Add ("@Description","");
				else
					scmd.Parameters .Add ("@Description",txtDescription.Text.ToString().Trim());
				scmd.ExecuteNonQuery();
				con.Close ();
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnUpdate_Click, User_Profile updated for UserID:"+lblUserID.Text.ToString()+", Userid :  "+ pass   );		
				MessageBox.Show("User Profile Updated");
				Clear("User Profile Created");
				GetNextUserID();													//Call method for clear the form.
				btnSaveProfile.Visible=true;
				btndelete.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				DropEdit.Visible=false;
				lblUserID.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : User_Profile.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 			}
		} 
	}
}
