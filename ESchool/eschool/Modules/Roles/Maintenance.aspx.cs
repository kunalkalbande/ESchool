
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
 
using RMG;
using eschool.Classes;
 

namespace eschool.Roles
{
	/// <summary>
	/// Summary description for BeatMaster_Entry.
	/// </summary>
	public class BeatMaster_Entry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBeatNo;
		protected System.Web.UI.WebControls.DropDownList DropBeatNo;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button Edit1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtState;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCountry;
			 
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		/// and generate the next ID also.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : City_Master.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : City_Master.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				string pass;
				pass=(Session["password"].ToString ());
				if(!IsPostBack)
				{
					btnEdit.Visible=true;
					Edit1.Visible=false;
					btnDelete.Visible =false; 
					fillID();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
					string SubModule="4";
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
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx,Method  Page_Load  , Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx,Method  Page_Load,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;
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
			this.DropBeatNo.SelectedIndexChanged += new System.EventHandler(this.DropBeatNo_SelectedIndexChanged);
			this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
			this.DropState.SelectedIndexChanged += new System.EventHandler(this.DropState_SelectedIndexChanged);
			this.DropCountry.SelectedIndexChanged += new System.EventHandler(this.DropCountry_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Edit1.Click += new System.EventHandler(this.Edit1_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to clear the form.
		/// </summary>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			btnSave.CausesValidation=true;
			lblBeatNo.Visible=true;
			DropBeatNo.Visible=false; 
 			btnEdit.Enabled=false;
			btnSave.Enabled=true;
			btnDelete.Enabled =false;
			Clear();
		}

		/// <summary>
		/// this method use to Generated Next id For country table.
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
				cmd=new SqlCommand("select max(SNO)+1 from Country",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						lblBeatNo.Text =SqlDtr.GetValue(0).ToString ();
						if(lblBeatNo.Text.Trim().Equals(""))
						lblBeatNo.Text="1";
					}
				}
				SqlDtr.Close (); 
				cmd=new SqlCommand("select distinct Country from Country",con);
				SqlDtr = cmd.ExecuteReader();
				DropCountry.Items.Clear();
				DropCountry.Items.Add("---Select---");
				while(SqlDtr.Read ())
				{
					DropCountry.Items.Add(SqlDtr.GetValue(0).ToString ());
				}	
				DropCountry.Items.Add("Others...");
				SqlDtr.Close ();
				cmd=new SqlCommand("select distinct State from Country",con);
				SqlDtr = cmd.ExecuteReader();
				DropState.Items.Clear();
				DropState.Items.Add("---Select---");
				while(SqlDtr.Read ())
				{
					DropState.Items.Add(SqlDtr.GetValue(0).ToString ());
				}	
				DropState.Items.Add("Others...");
				SqlDtr.Close ();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method fillID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}


		/// <summary>
		/// Method for visible the controls and adding the cityno into the dropdownbox for edit.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnSave.Visible=false;
				DropBeatNo.Visible=true;
				btnEdit.Visible=false;
				btnDelete.Visible =true; 
				Edit1.Visible=true;
				btnSave.CausesValidation=false;
				lblBeatNo.Visible=false;
				Clear();
				SqlConnection con;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select sno,city from Country order by city",con);
				SqlDtr = cmd.ExecuteReader();
				DropBeatNo.Items.Clear();
				DropBeatNo.Items.Add("Select");
				while(SqlDtr.Read ())
				{
					DropBeatNo.Items.Add(SqlDtr.GetValue(1).ToString ()+":"+SqlDtr.GetValue(0).ToString ());
				}
				SqlDtr.Close();
				cmd.Dispose();
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method  btnEdit_Click,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method  btnEdit_Click,  Exception: "+ex.Message+" , Userid :  "+ pass);		
			}
		}

		/// <summary>
		/// this Method use to save the city information in to country table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try 
			{			
				string sNewCountry="";
				string sNewState="";
				if(DropCountry.SelectedValue=="Others...")
				{
					sNewCountry= StringUtil.FirstCharUpper(Request.Params.Get("txtCountry").Trim().ToString());
				}
				else
				{
					sNewCountry= DropCountry.SelectedItem.Value;
				}
				if(DropState.SelectedValue=="Others...")
				{
					sNewState= StringUtil.FirstCharUpper(Request.Params.Get("txtState").Trim().ToString());
				}
				else
				{
					sNewState= DropState.SelectedItem.Value ;
				}
				string  sNewCity= StringUtil.FirstCharUpper(txtCity.Text.Trim().ToString());
				SqlConnection con;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();

				SqlDataReader SqlDtr; 
				string sql="select City  from Country where City='"+ txtCity.Text  +"'";
				cmd=new SqlCommand(sql,con);
				SqlDtr=cmd.ExecuteReader();

				string count2="";
				while(SqlDtr.Read())
				{
					count2=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();

				if(count2.Equals("")||count2==null)
				{
					int id;
					if (lblBeatNo.Text.Trim().Equals(""))
					{
						id = 1;
					}
					else
					{
						id = System.Convert.ToInt32(lblBeatNo.Text.Trim());
					}
					if(DropState.SelectedIndex==0)
					{
						MessageBox.Show("Please Select The State");
						return;
					}
					if(DropCountry.SelectedIndex==0)
					{
						MessageBox.Show("Please Select The Country");
						return;
					}
					cmd=new SqlCommand("insert Country(Sno,Country,State,City)values("+id+",'" + sNewCountry + "','" + sNewState + "','" + sNewCity + "')",con);
					cmd.ExecuteNonQuery();
					MessageBox.Show("City Successfully Saved");
				}
				else
				{
					MessageBox.Show("City already Exists");
				}
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method  btnSave_Click,  City saved - " + sNewCity + ". Userid :  "+ pass   );		
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

			/// <summary>
			/// this Method use to delete the city information from country table.
			/// </summary>
			private void btnDelete_Click(object sender, System.EventArgs e)
				{					
 
					string city_id=DropBeatNo.SelectedItem.Value.ToString();
					string[] city_id1=city_id.Split(new char[]{':'});
					try
					{
						int  Beat_No=0;
							SqlConnection con;
							SqlCommand cmd;
							con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							con.Open ();
							string sql="delete country where sno='"+city_id1[1].ToString()+"'";
							cmd=new SqlCommand(sql,con);
							cmd.ExecuteNonQuery();
							MessageBox.Show("City Successfully Deleted");
							Clear(); 
				 			btnSave.Visible=true;
							btnEdit.Visible=true;
							Edit1.Visible=false;
							DropBeatNo.Visible=false;
							lblBeatNo.Visible=true;
							btnDelete.Visible =false; 
						CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : btnDelete_Click   , CityNo. :"+Beat_No.ToString()+" is Deleted , Userid :  "+ pass   );							
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : btnDelete_Click"+"  EXCEPTION "+ex.Message+"  , Userid :  "+ pass   );		
					}
				}

		/// <summary>
		/// Adding the city  information to the controls for the edit.
		/// </summary>
		private void DropBeatNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropBeatNo.SelectedIndex==0)
					return;
				SqlConnection con;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
                string city_id=DropBeatNo.SelectedItem.Value.ToString();
				string[] city_id1=city_id.Split(new char[]{':'});

				SqlDataReader SqlDtr; 
				string sql="Select * from country where sno='"+ city_id1[1].ToString().Trim() +"'";
				cmd=new SqlCommand(sql,con);
				SqlDtr=cmd.ExecuteReader();
				while(SqlDtr.Read())
				{
					txtCity.Text=SqlDtr.GetValue(3).ToString();
					DropState.SelectedValue  =SqlDtr.GetValue(2).ToString();
					DropCountry.SelectedValue =SqlDtr.GetValue(1).ToString();
				}
				SqlDtr.Close();
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : DropEdit_SelectedIndexChange Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : DropEdit_SelectedIndexChange"+"  EXCEPTION "+ex.Message+"  , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for clearing the form.
		/// </summary>
		public void Clear()
		{            
			//DropBeatNo.SelectedIndex=0;
			txtCity.Text="";
			DropState.SelectedIndex =0;
			DropCountry.SelectedIndex =0;
			fillID();
		}

		/// <summary>
		/// this method use to update the information in to country table.
		/// </summary>
		private void Edit1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string city_id=DropBeatNo.SelectedItem.Value.ToString();
				string[] city_id1=city_id.Split(new char[]{':'});
				string sNewCountry="";
				string sNewState="";
				if(DropCountry.SelectedValue=="Others...")
				{
					sNewCountry= StringUtil.FirstCharUpper(Request.Params.Get("txtCountry").Trim().ToString());
				}
				else
				{
					sNewCountry= DropCountry.SelectedItem.Value;
				}
				if(DropState.SelectedValue=="Others...")
				{
					sNewState= StringUtil.FirstCharUpper(Request.Params.Get("txtState").Trim().ToString());
				}
				else
				{
					sNewState= DropState.SelectedItem.Value;
				}
				string  sNewCity= StringUtil.FirstCharUpper(txtCity .Text.Trim().ToString());
				SqlConnection con;
				SqlCommand cmd;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				string sql="select City  from Country where City='"+ txtCity.Text  +"'";
				cmd=new SqlCommand(sql,con);
				SqlDtr=cmd.ExecuteReader();
				string count2="";
				while(SqlDtr.Read())
				{
					count2=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();
				cmd=new SqlCommand("Update Country set country='" + sNewCountry + "',state='" + sNewState + "',	City='" + sNewCity + "' where sno='"+city_id1[1].ToString().Trim()+"'",con);
				cmd.ExecuteNonQuery();
				MessageBox.Show("City Successfully Updated");
	 			DropBeatNo.Visible=false;
				lblBeatNo.Visible=true;
				Edit1.Visible=false;
				btnEdit.Visible=true; 
				btnSave.Visible=true;
				btnDelete.Visible =false; 
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : btnUpdate_Click City :"+sNewCity+" Updated  , Userid :  "+ pass   );		 
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Maintenance.aspx, Method : btnUpdate_Click "+"  EXCEPTION "+ex.Message+"  , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this is used to show the hidden textbox.
		/// </summary>
		private void DropState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sname = DropState.SelectedItem.Value;
			if(sname.Equals ("Others..."))
			{
			}
			else
			{
			}
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtCity_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this is used to show the hidden textbox.
		/// </summary>
		private void DropCountry_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string cname = DropCountry.SelectedItem.Value;
			if(cname.Equals ("Others..."))
			{
				
			}	
			else
			{
				
			}
		}
	}
}