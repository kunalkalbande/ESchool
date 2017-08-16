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
using eschool.Classes ;
# endregion


namespace eschool.Form
{
	/// <summary>
	/// Summary description for classedit.
	/// </summary>
	public class classedit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CompareValidator cvClass;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label lblAddNewClass;
		protected System.Web.UI.WebControls.Button btnadd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.HtmlControls.HtmlSelect DropClass;
		protected System.Web.UI.WebControls.TextBox txtclass;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOther;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempclass;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempeditclass;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOth;
	
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
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Class.aspx, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				
				# region Dropdown ClassName
				if(!Page.IsPostBack)
				{	
					//11.11.08txtOther.Visible=false;
					btnadd.Visible=true;
					btnDelete.Visible=true;
					btnSEdit.Visible=false;
					lblAddNewClass.Visible=true;
					DropClass.Visible=true;
					txtclass.Visible=false;					
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrdrive;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select distinct Class_name,Class_id  From Class order by Class_ID", con );
					dtrdrive = cmdselect.ExecuteReader();
					
					while (dtrdrive.Read()) 
					{
						DropDownList1.Items.Add(dtrdrive.GetString(0));
					}
					dtrdrive.Close();
					con.Close ();
					fillID();
				}
				# endregion

				CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : Page_Load.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			
			#region Check Privileges
			if(! IsPostBack)
			{
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
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
				if(Add_Flag=="False" && Edit_Flag=="False" && Del_Flag=="False" && View_flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
					return;
				}
				if(Add_Flag=="False")
					btnadd.Enabled=false;
				if(Edit_Flag=="False")
				{
					btnEdit.Enabled=false;
					btnSEdit.Enabled=false;
				}
				if(Del_Flag=="False")
					btnDelete.Enabled=false;
				
			}
			#endregion
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
			this.txtclass.TextChanged += new System.EventHandler(this.txtclass_TextChanged);
			this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSEdit.Click += new System.EventHandler(this.btnSEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This Method used for populeting the classname in the DropdownBox.
		/// </summary>
		public void fillClassName()
		{
			DropDownList1.Items.Clear();
			DropDownList1.Items.Add("--Select--");
			btnadd.Visible=true;
			btnDelete.Visible=true;
			btnSEdit.Visible=false;
			lblAddNewClass.Visible=true;
			DropClass.Visible=true;
			SqlConnection con;
			SqlCommand cmdselect;
			SqlDataReader dtrdrive;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select distinct Class_name,Class_id  From Class order by Class_ID", con );
				dtrdrive = cmdselect.ExecuteReader();
					
				while (dtrdrive.Read()) 
				{
					DropDownList1.Items.Add(dtrdrive.GetString(0));
				}
				dtrdrive.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: classedit.aspx.cs, Method: fillClassName, Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedIndex==0)
			{
			}
			else
			{
				txtclass.Text=DropDownList1.SelectedItem.Text.ToString();
			}
		}
		
		
		/// <summary>
		/// This Method use to Generated Next Class Id.
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
				cmd=new SqlCommand("select max(Class_id)+1 from Class",con);
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
				
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog ("Form: classedit.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Save new class in class table. and also use to update the record.
		/// </summary>
		private void btnadd_Click(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedIndex==0)
			{
				try
				{
				
					if(DropClass.SelectedIndex==0)
					{
						MessageBox.Show("Please Select Class");
						return;
					}
					string classname="";
					if(tempclass.Value!="" && tempclass.Value!="Other")
						classname=tempclass.Value.ToString();
					else
						classname=txtOth.Value.ToString();
					//11.11.08 if(DropClass.SelectedItem.Text.Equals("Other"))
					//11.11.08	classname=txtOther.Text.Trim();
					//else
					//11.11.08 classname=DropClass.SelectedItem.Text.ToString();//+"-"+DropDivision.SelectedItem.Text.ToString();
					

					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlCommand scom=new SqlCommand("Select Count(Class_name) from Class where Class_name='" + classname +"'",scon);
					SqlDataReader sdtr=scom.ExecuteReader();
					int iCount=0;
					while(sdtr.Read())
					{
						iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
					}
					if(iCount==0)
					{
						SqlConnection con4;
						string strInsert4;
						SqlCommand cmdInsert4;
						fillID();
						con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con4.Open ();
						strInsert4 = "Insert Class(Class_id,Class_name)values (@Class_id,@Class_name)";
						cmdInsert4=new SqlCommand (strInsert4,con4);
						cmdInsert4.Parameters .Add ("@Class_id",i.Trim().ToString());	
						cmdInsert4.Parameters .Add ("@Class_name",classname.Trim());
						cmdInsert4.ExecuteNonQuery();
						con4.Close ();
						//MessageBox.Show(" New Class Saved ");
						MessageBox.Show("New Class Successfully Saved");
						CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method: btnadd_Click. New Class: " + txtclass.Text.Trim().ToUpper() + " is saved. User: " + Session["password"].ToString() );
						clear();
						fillClassName();												//Call method to fill the class name into the combobox.
					}
					else
					{
						MessageBox.Show("This class already exist");
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnadd_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				}
			}
			else
			{
				SqlConnection con2;
				SqlCommand cmdselect2;
				SqlDataReader dtredit2;
				string strUpdate="",Class_Id="";
				try
				{
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					strUpdate="select Class_Id from class where class_name='"+DropDownList1.SelectedItem.Value.ToString().Trim()+"'";
					cmdselect2=new SqlCommand(strUpdate,con2);
					dtredit2=cmdselect2.ExecuteReader();
					if(dtredit2.Read())
					{
						Class_Id=dtredit2.GetValue(0).ToString();
					}
					dtredit2.Close();


					//11.11.08 if(txtclass.Text.Trim()=="")
					if(tempeditclass.Value.ToString().Trim()=="")
					{
						MessageBox.Show("Blank record can not be inserted");
						return;
					}
					else
					{
						string className=txtclass.Text.ToUpper().ToString();
						//03.09.08--strUpdate = "Update  Class set Class_name=@class  where Class_name=@class1";
						strUpdate = "Update  Class set Class_name=@class  where Class_id=@class1";
						cmdselect2 = new SqlCommand( strUpdate, con2);
						//11.11.08 if (txtclass.Text=="")
						if(tempeditclass.Value=="")
							cmdselect2.Parameters .Add ("@class","");
						else
							//11.11.08 cmdselect2.Parameters .Add ("@class",txtclass.Text.Trim());
							cmdselect2.Parameters .Add ("@class",tempeditclass.Value.Trim());
						if (DropDownList1.SelectedIndex==0)
							cmdselect2.Parameters .Add ("@class1","");
						else
							cmdselect2.Parameters .Add ("@class1",Class_Id.ToString().Trim());
						//cmdselect2.Parameters .Add ("@class1",DropDownList1.SelectedItem.Text.ToString ());

						dtredit2 = cmdselect2.ExecuteReader();
						con2.Close();
						MessageBox.Show("Class Successfully Updated");
						btnadd.Visible=true;
						btnDelete.Visible=true;
						//btnSEdit.Visible=false;
						lblAddNewClass.Visible=true;
						DropClass.Visible=true;
						txtclass.Visible=false;
						CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnUpdate_Click. Class: " + DropDownList1.SelectedItem.ToString () + " updated. User: " + Session["password"].ToString() ); 
						clear();
						fillClassName();                                                 //Call method ,so After updating the records fill the class name into the dropdownbox.
					
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnUpadte_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
				}
			}
		}
		
		/// <summary>
		/// This Method use to Reset the page.
		/// </summary>
		public void clear()
		{
			txtclass.Text="";
			DropDownList1.SelectedIndex=0;
			//11.11.08 txtOther.Text="";
			//11.11.08 txtOther.Visible=false;
			DropClass.SelectedIndex=0;
		}

		/// <summary>
		/// This Method use to delete a particular record from class table.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con10;
			SqlCommand cmdselect10;
			SqlDataReader dtredit10;
			string strdelete10;
			try
			{
				DropDownList1.Enabled=true;
				if(DropDownList1.SelectedIndex==0)
				{
					MessageBox.Show("Please select the class name to be deleted");
				}
				else
				{
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open ();
					strdelete10 = "Delete from Class where Class_name =@Class_name";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					cmdselect10.Parameters .Add ("@Class_name",DropDownList1.SelectedItem.ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					con10.Close();
					MessageBox.Show("Class Successfully Deleted");
					CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnDelete_Click. Class: " + DropDownList1.SelectedItem.ToString () + " deleted. User: " + Session["password"].ToString() ); 
					clear();
					fillClassName();                                                  //after deleting the class name fill the remaining class names into the combobox.
				}
				btnadd.Visible=true;
				btnDelete.Visible=true;
				btnSEdit.Visible=false;
				lblAddNewClass.Visible=true;
				DropClass.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnDelete_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}

		/// <summary>
		/// This method use to show dropdown selected value in to textbox.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			DropDownList1.Enabled=true;
			if(DropDownList1.SelectedItem.Text=="---Select---")
			{
				MessageBox.Show("Please select the class name");
				return;
			}
			else
			{
				txtclass.Text=DropDownList1.SelectedItem.Text.ToString();
			}
			btnEdit.Visible=false;
			btnadd.Visible=false;
			btnDelete.Visible=true;
			btnSEdit.Visible=true;
			lblAddNewClass.Visible=false;
			DropClass.Visible=false;
			txtclass.Visible=true;
			CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method: btnEdit_Click. " + Session["password"].ToString() );
		}

		/// <summary>
		/// This method use to update the Record.
		/// </summary>
		private void btnSEdit_Click(object sender, System.EventArgs e)
		{
			SqlConnection con2;
			SqlCommand cmdselect2;
			SqlDataReader dtredit2;
			string strUpdate="",Class_Id="";
			try
			{
				con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con2.Open ();
                strUpdate="select Class_Id from class where class_name='"+DropDownList1.SelectedItem.Value.ToString().Trim()+"'";
				cmdselect2=new SqlCommand(strUpdate,con2);
                dtredit2=cmdselect2.ExecuteReader();
				if(dtredit2.Read())
				{
                   Class_Id=dtredit2.GetValue(0).ToString();
				}
				dtredit2.Close();


				if(txtclass.Text.Trim()=="")
				{
					MessageBox.Show("Blank record can not be inserted");
					return;
				}
				else
				{
					string className=txtclass.Text.ToUpper().ToString();
					//03.09.08--strUpdate = "Update  Class set Class_name=@class  where Class_name=@class1";
					strUpdate = "Update  Class set Class_name=@class  where Class_id=@class1";
					cmdselect2 = new SqlCommand( strUpdate, con2);
					if (txtclass.Text=="")
						cmdselect2.Parameters .Add ("@class","");
					else
						cmdselect2.Parameters .Add ("@class",txtclass.Text.Trim());
					if (DropDownList1.SelectedIndex==0)
						cmdselect2.Parameters .Add ("@class1","");
					else
						cmdselect2.Parameters .Add ("@class1",Class_Id.ToString().Trim());
						//cmdselect2.Parameters .Add ("@class1",DropDownList1.SelectedItem.Text.ToString ());

					dtredit2 = cmdselect2.ExecuteReader();
					con2.Close();
					MessageBox.Show("Class Successfully Updated");
					btnadd.Visible=true;
					btnDelete.Visible=true;
					btnSEdit.Visible=false;
					lblAddNewClass.Visible=true;
					DropClass.Visible=true;
					btnEdit.Visible=true;
					txtclass.Visible=false;
					CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnUpdate_Click. Class: " + DropDownList1.SelectedItem.ToString () + " updated. User: " + Session["password"].ToString() ); 
					clear();
					fillClassName();                                                 //Call method ,so After updating the records fill the class name into the dropdownbox.
					
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : Classedit.aspx.cs, Method : btnUpadte_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		
		/// <summary>
		/// not in use.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DropClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//11.11.08 if(DropClass.SelectedItem.Text.Equals("Other"))
				//11.11.08 txtOther.Visible=true;
			//11.11.08 else
				//11.11.08 txtOther.Visible=false;
		}
/// <summary>
/// not in use.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
		private void txtclass_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
