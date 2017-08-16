  
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
	/// Summary description for Staff_typeinsertion.
	/// </summary>
	public class Staff_typeinsertion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnadd;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button btnsearch;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox txtstafftype;
		protected System.Web.UI.WebControls.RadioButton chkTeachingType;
		protected System.Web.UI.WebControls.RadioButton chkNonTeachingType;
		protected System.Web.UI.WebControls.RadioButton chkActivityType;
		protected System.Web.UI.WebControls.RadioButton chkGroupDType;
		protected System.Web.UI.HtmlControls.HtmlSelect DropstaffType;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temptype;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempnewtype;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempdropval;
		protected System.Web.UI.WebControls.RequiredFieldValidator Reqvali1;
		protected System.Web.UI.WebControls.ValidationSummary summary1;
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
				CreateLogFiles.ErrorLog(" Form : Staff_Typeinsertion.aspx,Method : Page_Load  User: "+ pass);     
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Staff_Typeinsertion,Method : Page_Load  Exception: "+ex.Message+"  User: "+ pass);     
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnEdit.Visible=false;
					btnSEdit.Visible=false;
					getdata();
				}
				if(! IsPostBack)
				{
					 #region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
					string SubModule="9";
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
					#endregion
				}
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.chkTeachingType.CheckedChanged += new System.EventHandler(this.chkTeachingType_CheckedChanged);
			this.chkNonTeachingType.CheckedChanged += new System.EventHandler(this.chkNonTeachingType_CheckedChanged);
			this.chkGroupDType.CheckedChanged += new System.EventHandler(this.chkGroupDType_CheckedChanged);
			this.chkActivityType.CheckedChanged += new System.EventHandler(this.chkGroupD_CheckedChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSEdit.Click += new System.EventHandler(this.btnSEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		 
		/// <summary>
		/// this function use to fetch value from Staff_type table and save in to hidden text box. this textbox use in javscript function.function name is Showtype(). 
		/// </summary>
		public void getdata()
		{
			InventoryClass obj=new InventoryClass();
			SqlDataReader sdtr=null;
			temptype.Value="";
			string str="Select * from staff_type order by staff_name";
			sdtr=obj.GetRecordSet(str);
			while(sdtr.Read())
			{
               temptype.Value+=sdtr.GetValue(1)+":"+sdtr.GetValue(2)+":"+sdtr.GetValue(3)+":"+sdtr.GetValue(4)+":"+sdtr.GetValue(5)+",";
			}
			sdtr.Close();
		}

		/// <summary>
		/// This Method use to Clear value in all controls which is exist in page.
		/// </summary>
		public void clear()
		{
			txtstafftype.Text="";
			tempnewtype.Value="";
			chkNonTeachingType.Checked=false;
			chkTeachingType.Checked=false;
			chkActivityType.Checked =false;
			chkGroupDType.Checked=false;
		}
				
		/// <summary>
		/// This Method use to generate next id from staff_Type table.
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
				cmd=new SqlCommand("select max(Stafftype_ID)+1 from Staff_Type",con);
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
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: fillCombo. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This Method use to Save the information and also update the information of staff type.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(tempdropval.Value=="" || tempdropval.Value=="Select")
			{
				try
				{
					if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
					{
						MessageBox.Show("You must checked at least one checkbox");
					}
					else
					{
						if(txtstafftype.Text.Trim()=="")
						{
							MessageBox.Show("Blank Record could not be Inserted");
						}
						else
						{
							string sStaffType=txtstafftype.Text;
							SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							scon.Open();
							fillID();
							SqlCommand scom=new SqlCommand("Select Count(staff_name) from Staff_Type where staff_name='" + sStaffType +"'",scon);
							SqlDataReader sdtr=scom.ExecuteReader(); 
							int iCount=0;
							while(sdtr.Read())
							{
								iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
							}
							if(iCount==0)                                               ///checked whether entered staff name is already Exists.
							{				
								SqlConnection con;
								string strInsert;
								SqlCommand cmdInsert;
								con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
								con.Open ();
								strInsert = "Insert Staff_Type(Stafftype_ID,teaching,nonteaching,staff_name,groupd,Activity)values (@Stafftype_ID,@teaching,@nonteaching,@staff_name,@GroupD,@Activity)";
								cmdInsert=new SqlCommand (strInsert,con);
						
								cmdInsert.Parameters.Add("@Stafftype_ID",i.Trim().ToString());
								if(chkTeachingType.Checked==true && chkNonTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
								{
									cmdInsert.Parameters.Add("@teaching","1");
									cmdInsert.Parameters.Add("@nonteaching","0");
									cmdInsert.Parameters.Add("@GroupD","0");
									cmdInsert.Parameters.Add("@Activity","0");
								}
								if(chkNonTeachingType.Checked==true && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
								{
									cmdInsert.Parameters.Add("@teaching","0");
									cmdInsert.Parameters.Add("@nonteaching","1");
									cmdInsert.Parameters.Add("@GroupD","0");
									cmdInsert.Parameters.Add("@Activity","0");
								}
								if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==true && chkActivityType.Checked ==false)
								{
									cmdInsert.Parameters.Add("@teaching","0");
									cmdInsert.Parameters.Add("@nonteaching","0");
									cmdInsert.Parameters.Add("@GroupD","1");
									cmdInsert.Parameters.Add("@Activity","0");
								}
								if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==true)
								{
									cmdInsert.Parameters.Add("@teaching","0");
									cmdInsert.Parameters.Add("@nonteaching","0");
									cmdInsert.Parameters.Add("@GroupD","0");
									cmdInsert.Parameters.Add("@Activity","1");
								}
							
								if(txtstafftype.Text=="")
									cmdInsert.Parameters .Add ("@staff_name","");
								else
									cmdInsert.Parameters .Add ("@staff_name",txtstafftype.Text.Trim().ToUpper());		

								cmdInsert.ExecuteNonQuery();
								con.Close();
								MessageBox.Show("Staff Type Successfully Saved");
								CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnSave_Click. New Staff type: " + tempnewtype.Value.Trim() + "saved. User: " + pass);
								clear();
								btnSave.Visible=true;
								btnDelete.Visible=true;
								btnEdit.Visible=false;
								btnSEdit.Visible=false;
							}
							else
							{
								MessageBox.Show("This Record Already Exists");
							}
							scon.Close();
						}
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
				}
			}
			else
			{
				try
				{
					if(tempnewtype.Value.Trim()=="")
					{
						MessageBox.Show("Blank record can not be saved");
					}
					else
					{
						SqlConnection con2;
						SqlCommand cmdselect2;
						SqlDataReader dtredit2;
						string strUpdate;
						con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con2.Open ();
						strUpdate = "Update  Staff_Type set staff_name=@Staffname,teaching=@teaching,nonteaching=@nonteaching,activity=@activity  where staff_name=@StaffType1";
						cmdselect2 = new SqlCommand( strUpdate, con2);
						if (tempnewtype.Value=="")
							cmdselect2.Parameters .Add ("@Staffname","");
						else
							cmdselect2.Parameters .Add ("@Staffname",tempnewtype.Value.Trim().ToUpper());
						
						if(tempdropval.Value=="")
							cmdselect2.Parameters .Add ("@StaffType1","");
						else
							cmdselect2.Parameters .Add ("@StaffType1",tempdropval.Value);
				
						if(chkTeachingType.Checked==true && chkNonTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
						{
							cmdselect2.Parameters.Add("@teaching","1");
							cmdselect2.Parameters.Add("@nonteaching","0");
							cmdselect2.Parameters.Add("@GroupD","0");
							cmdselect2.Parameters.Add("@Activity","0");
						}
						if(chkNonTeachingType.Checked==true && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
						{
							cmdselect2.Parameters.Add("@teaching","0");
							cmdselect2.Parameters.Add("@nonteaching","1");
							cmdselect2.Parameters.Add("@GroupD","0");
							cmdselect2.Parameters.Add("@Activity","0");
						}
						if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==true && chkActivityType.Checked ==false)
						{
							cmdselect2.Parameters.Add("@teaching","0");
							cmdselect2.Parameters.Add("@nonteaching","0");
							cmdselect2.Parameters.Add("@GroupD","1");
							cmdselect2.Parameters.Add("@Activity","0");
						}
						if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==true)
						{
							cmdselect2.Parameters.Add("@teaching","0");
							cmdselect2.Parameters.Add("@nonteaching","0");
							cmdselect2.Parameters.Add("@GroupD","0");
							cmdselect2.Parameters.Add("@Activity","1");
						}
						dtredit2 = cmdselect2.ExecuteReader();
						con2.Close();
						MessageBox.Show("Staff Type Successfully Updated");
						clear();
						btnSave.Visible=true;
						btnDelete.Visible=true;
						btnSEdit.Visible=false;
						btnEdit.Visible=false;
					}
					CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnUpdate_Click. User: " + pass );
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnUpdate_Click. Exception: " + ex.Message + " User: " + pass );
				}
			}
			getdata();
		}
		
		/// <summary>
		/// This Method not in use.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{	
			try
			{
				if(DropstaffType.SelectedIndex==0)
				{
				
					MessageBox.Show("Please select the staff type ");
				}
				btnSave.Visible=false;
				btnDelete.Visible=true;
				btnEdit.Visible=false;
				btnSEdit.Visible=true;
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnEdit_Click. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void btnSEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(tempnewtype.Value.Trim()=="")
				{
					MessageBox.Show("Blank record can not be saved");
				}
				else
				{
					SqlConnection con2;
					SqlCommand cmdselect2;
					SqlDataReader dtredit2;
					string strUpdate;
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					strUpdate = "Update  Staff_Type set staff_name=@Staffname,teaching=@teaching,nonteaching=@nonteaching,activity=@activity  where staff_name=@StaffType1";
					cmdselect2 = new SqlCommand( strUpdate, con2);
					if (tempnewtype.Value=="")
						cmdselect2.Parameters .Add ("@Staffname","");
					else
						cmdselect2.Parameters .Add ("@Staffname",tempnewtype.Value.Trim().ToUpper());
					if (DropstaffType.SelectedIndex==0)
						cmdselect2.Parameters .Add ("@StaffType1","");
					else
						cmdselect2.Parameters .Add ("@StaffType1",DropstaffType.Value);
				
					if(chkTeachingType.Checked==true && chkNonTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
					{
						cmdselect2.Parameters.Add("@teaching","1");
						cmdselect2.Parameters.Add("@nonteaching","0");
						cmdselect2.Parameters.Add("@GroupD","0");
						cmdselect2.Parameters.Add("@Activity","0");
					}
					if(chkNonTeachingType.Checked==true && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==false)
					{
						cmdselect2.Parameters.Add("@teaching","0");
						cmdselect2.Parameters.Add("@nonteaching","1");
						cmdselect2.Parameters.Add("@GroupD","0");
						cmdselect2.Parameters.Add("@Activity","0");
					}
					if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==true && chkActivityType.Checked ==false)
					{
						cmdselect2.Parameters.Add("@teaching","0");
						cmdselect2.Parameters.Add("@nonteaching","0");
						cmdselect2.Parameters.Add("@GroupD","1");
						cmdselect2.Parameters.Add("@Activity","0");
					}
					if(chkNonTeachingType.Checked==false && chkTeachingType.Checked==false && chkGroupDType.Checked==false && chkActivityType.Checked ==true)
					{
						cmdselect2.Parameters.Add("@teaching","0");
						cmdselect2.Parameters.Add("@nonteaching","0");
						cmdselect2.Parameters.Add("@GroupD","0");
						cmdselect2.Parameters.Add("@Activity","1");
					}
					dtredit2 = cmdselect2.ExecuteReader();
					con2.Close();
					MessageBox.Show("Staff Type Successfully Updated");
					clear();
 					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnSEdit.Visible=false;
					btnEdit.Visible=false;
				}
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnUpdate_Click. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnUpdate_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this Method for deleting the Staff Type records from staff_type table.
		/// </summary>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(tempdropval.Value=="" || tempdropval.Value=="Select")
				{
					MessageBox.Show("Please select the staff type to be deleted");
				}
				else
				{
					SqlConnection con10;
					SqlCommand cmdselect10;
					SqlDataReader dtredit10;
					string strdelete10;
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open ();
					strdelete10 = "Delete from Staff_Type where staff_name =@Staff_name";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					cmdselect10.Parameters .Add ("@Staff_name",tempdropval.Value.ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					con10.Close();
					MessageBox.Show("Staff Type Successfully Deleted");
					clear();
					btnSave.Visible=true;
					btnDelete.Visible=true;
					btnSEdit.Visible=false;
					btnEdit.Visible=false;
					getdata();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: btnDelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void chkTeachingType_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		///  This method not in use.
		/// </summary>
		private void chkNonTeachingType_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// this Method use to filling the staff type belong to teaching into the DropdownBox.
		/// </summary>
		public void teaching()
		{
			try
			{
				SqlDataReader dtr;
				SqlCommand scom;
				SqlConnection scon;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				scom=new SqlCommand("Select distinct staff_name from   Staff_Type where teaching='1'",scon);
				dtr=scom.ExecuteReader();
				DropstaffType.Items.Add("---Select---");	
				while(dtr.Read())
				{
					DropstaffType.Items.Add(dtr.GetString(0));
				}
				scon.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: fillCombo. Exception: " + ex.Message + " User: " + pass );
			}	
		}

		/// <summary>
		/// Method for filling the staff_type belong to non_teaching into the DropDownBox.
		/// </summary>
		public void nonteaching()
		{
			DropstaffType.Items.Clear();
			try
			{
				SqlDataReader dtr;
				SqlCommand scom;
				SqlConnection scon;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				scom=new SqlCommand("Select distinct staff_name from Staff_Type where nonteaching='1'",scon);
				dtr=scom.ExecuteReader();
				DropstaffType.Items.Add("---Select---");	
				while(dtr.Read())
				{
					DropstaffType.Items.Add(dtr.GetString(0));
				}
				scon.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_typeinsertion.aspx.cs, Method: fillCombo. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// Method for filling the staff_type belong to Group D into the DropDownBox.
		/// </summary>
		public void groupd()
		{
			DropstaffType.Items.Clear();
			try
			{
				SqlDataReader dtr;
				SqlCommand scom;
				SqlConnection scon;
				scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				scom=new SqlCommand("select distinct staff_name from staff_type where groupd ='1'",scon);
				dtr=scom.ExecuteReader();
				DropstaffType.Items.Add("---Select---");
				while (dtr.Read())
				{
					DropstaffType.Items.Add(dtr.GetString(0));
				} 
				scon.Close();
			}   
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("form:staff_typeinsertion.aspx.cs,method:fillcombo.exception: " + ex.Message  + " user: " + pass);
			}
		}

		/// <summary>
		///  This method not in use.
		/// </summary>
		private void chkGroupD_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		///  This method not in use.
		/// </summary>
		private void chkGroupDType_CheckedChanged(object sender, System.EventArgs e)
		{
		}
			
		/// <summary>
		/// Method for filling the staff_type belong to Activity Staff into the DropDownBox.
		/// </summary>
			public void activity()
			{
				DropstaffType.Items.Clear();
				try
				{
					SqlDataReader dtr;
					SqlCommand scom;
					SqlConnection scon;
					scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					scom=new SqlCommand("select distinct staff_name from staff_type where activity ='1'",scon);
					dtr=scom.ExecuteReader();
					DropstaffType.Items.Add("---Select---");
					while (dtr.Read())
					{
						DropstaffType.Items.Add(dtr.GetString(0));
					} 
					scon.Close();
				}   
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog("form:staff_typeinsertion.aspx.cs,method:fillcombo.exception: " + ex.Message  + " user: " + pass);
				}
					
		}
	}

}
			
			                




		
	
		

		
	

