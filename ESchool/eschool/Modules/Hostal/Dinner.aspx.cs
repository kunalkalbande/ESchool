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

namespace eschool.Hostel
{
	/// <summary>
	/// Summary description for Dinner.
	/// </summary>
	public class Dinner : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtdes1;
		protected System.Web.UI.WebControls.TextBox txtdes2;
		protected System.Web.UI.WebControls.TextBox txtdes3;
		protected System.Web.UI.WebControls.TextBox txtdes4;
		protected System.Web.UI.WebControls.TextBox txtdes5;
		protected System.Web.UI.WebControls.TextBox txtdes6;
		protected System.Web.UI.WebControls.TextBox txtdes7;
		protected System.Web.UI.WebControls.DropDownList Dropblday;
		protected System.Web.UI.WebControls.TextBox txtdes8;
		protected System.Web.UI.WebControls.DropDownList Droptime;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.CompareValidator cvTime;
		protected System.Web.UI.WebControls.CompareValidator cvDay;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish4;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish3;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish5;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish6;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish8;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDish7;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary vsMenu;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnSave;
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
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Dinner.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//pass=(Session["password"].ToString ());
			  	if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="9";
					string SubModule="1";
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

					fillID();
				}
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : Page_Load, Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );
				
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
			this.Droptime.SelectedIndexChanged += new System.EventHandler(this.Droptime_SelectedIndexChanged);
			this.Dropblday.SelectedIndexChanged += new System.EventHandler(this.Dropblday_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
 		/// <summary>
		/// this method use to Clear page.
		/// </summary>
		public void Clear()
		{
			txtdes1.Text="";
			txtdes2.Text="";
			txtdes3.Text="";
			txtdes4.Text="";
			txtdes5.Text="";
			txtdes6.Text="";
			txtdes7.Text="";
			txtdes8.Text="";
			Dropblday.SelectedIndex=0;
			Droptime.SelectedIndex=0;
			btnSave.Text = "Save" ;
		}
		
		/// <summary>
		/// This method call clear() method.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			 Clear();
		}

		/// <summary>
		/// this method use to Get Next ID of menu_creation.
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
				cmd=new SqlCommand("select max(dinner_id)+1 from menu_creation",con);
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
		/// this method use to Insert Or Update Dinner information into the menu_creation.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			string msg="";
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (Droptime.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select Time");
                    errorMessage.Append("\n");
                }
                if (Dropblday.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select Day");
                    errorMessage.Append("\n");
                }                
                if (txtdes1.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Dishes1 Name");
                    errorMessage.Append("\n");
                }
                if (txtdes2.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Dishes2 Name");
                    errorMessage.Append("\n");
                }
                if (txtdes3.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Dishes3 Name");
                    errorMessage.Append("\n");
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());
                    return;
                }
                con =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				fillID();
				if(btnSave.Text.Equals ("Save"))
				{
					strInsert="insert menu_creation(dinner_id,des1,des2,des3,des4,des5,des6,des7,des8,food_day,food_time) values(@dinner_id,@des1,@des2,@des3,@des4,@des5,@des6,@des7,@des8,@ddt,@food_time)";
					msg="Saved.";
				}
				else
				{
					strInsert = "update  menu_creation set des1=@des1,des2=@des2,des3=@des3,des4=@des4,des5=@des5,des6=@des6,des7=@des7,des8=@des8 where food_day=@ddt and food_time=@food_time";
					msg="Updated.";
				}
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.Parameters.Add("@dinner_id",i.Trim().ToString());
				if(txtdes1 .Text=="")
					 cmdInsert.Parameters .Add ("@des1","");
				else
					 cmdInsert.Parameters .Add ("@des1",txtdes1.Text.Trim().ToUpper());
				if(txtdes2 .Text=="")
					 cmdInsert.Parameters .Add ("@des2","");
				else
					 cmdInsert.Parameters .Add ("@des2",txtdes2.Text.Trim().ToUpper());
				if(txtdes3.Text=="")
					 cmdInsert.Parameters .Add ("@des3","");
				else
					 cmdInsert.Parameters .Add ("@des3",txtdes3.Text.Trim().ToUpper());
				if(txtdes4 .Text=="")
				 	 cmdInsert.Parameters .Add ("@des4","");
				else
					 cmdInsert.Parameters .Add ("@des4",txtdes4.Text.Trim().ToUpper());
				if(txtdes5 .Text=="")
					 cmdInsert.Parameters .Add ("@des5","");
				else
					 cmdInsert.Parameters .Add ("@des5",txtdes5.Text.Trim().ToUpper());
				if(txtdes6 .Text=="")
					 cmdInsert.Parameters .Add ("@des6","");
				else
					 cmdInsert.Parameters .Add ("@des6",txtdes6.Text.Trim().ToUpper());
				if(txtdes7 .Text=="")
				 	 cmdInsert.Parameters .Add ("@des7","");
				else
					 cmdInsert.Parameters .Add ("@des7",txtdes7.Text.Trim().ToUpper());
				if(txtdes8 .Text=="")
					 cmdInsert.Parameters .Add ("@des8","");
				else
					 cmdInsert.Parameters .Add ("@des8",txtdes8.Text.Trim().ToUpper());
				if(Dropblday .SelectedIndex==0)
					 cmdInsert.Parameters .Add ("@ddt","");
				else
					 cmdInsert.Parameters .Add ("@ddt",Dropblday.SelectedItem .Text .ToString ());
				if(Droptime .SelectedIndex==0)
					 cmdInsert.Parameters .Add ("@food_time","");
				else
					 cmdInsert.Parameters .Add ("@food_time",Droptime.SelectedItem .Text .ToString ());
				cmdInsert.ExecuteNonQuery();
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : btnSave_Click  , Menu set for Day :"+ Dropblday.SelectedItem .Text .ToString () +" and Time:"+ Droptime.SelectedItem .Text .ToString ()   +" is saved,      Userid :  " + pass   );
				MessageBox.Show(" Menu Successfully " + msg);
				con.Close ();
				Clear();
				btnSave.Text="Save";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to show the menu of the dinner lunch and freck fast when day selected by user.
		/// </summary>
		private void Dropblday_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string str;
			SqlCommand cmd;
			SqlDataReader SqlDtr;
			try
			{
				if(Droptime.SelectedIndex ==0)
				{
				}
				else
				{
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					str= "select * from  menu_creation where food_day='"+Dropblday.SelectedItem.Value.ToString()+"' and  food_time='"+Droptime.SelectedItem.Value.ToString()+"'";
					cmd =new SqlCommand (str ,con);
					SqlDtr=cmd.ExecuteReader();
					if(SqlDtr.HasRows )
					{
						if(SqlDtr.Read())
						{
							txtdes1.Text=SqlDtr.GetValue(1).ToString();
							txtdes2.Text=SqlDtr.GetValue(2).ToString();
							txtdes3.Text=SqlDtr.GetValue(3).ToString();
							txtdes4.Text=SqlDtr.GetValue(4).ToString();
							txtdes5.Text=SqlDtr.GetValue(5).ToString();
							txtdes6.Text=SqlDtr.GetValue(6).ToString();
							txtdes7.Text=SqlDtr.GetValue(7).ToString();
							txtdes8.Text=SqlDtr.GetValue(8).ToString();
						}
						btnSave.Text="Update"; 
					}
					else
					{
						txtdes1.Text="";
						txtdes2.Text="";
						txtdes3.Text="";
						txtdes4.Text="";
						txtdes5.Text="";
						txtdes6.Text="";
						txtdes7.Text="";
						txtdes8.Text="";
						btnSave.Text="Save";
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : Droptime_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to show the menu of the dinner lunch and freck fast when day selected by user.
		/// </summary>
		private void Droptime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string str;
			SqlCommand cmd;
			SqlDataReader SqlDtr;
			try
			{
				if(Dropblday.SelectedIndex ==0)
				{
					
				}
				else
				{
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					str= "select * from  menu_creation where food_day='"+Dropblday.SelectedItem.Value.ToString()+"' and  food_time='"+Droptime.SelectedItem.Value.ToString()+"'";
					cmd =new SqlCommand (str ,con);
					SqlDtr=cmd.ExecuteReader();
					if(SqlDtr.HasRows )
					{
						if(SqlDtr.Read())
						{
							txtdes1.Text=SqlDtr.GetValue(1).ToString();
							txtdes2.Text=SqlDtr.GetValue(2).ToString();
							txtdes3.Text=SqlDtr.GetValue(3).ToString();
							txtdes4.Text=SqlDtr.GetValue(4).ToString();
							txtdes5.Text=SqlDtr.GetValue(5).ToString();
							txtdes6.Text=SqlDtr.GetValue(6).ToString();
							txtdes7.Text=SqlDtr.GetValue(7).ToString();
							txtdes8.Text=SqlDtr.GetValue(8).ToString();
						}
						btnSave.Text="Update"; 
					}
					else
					{
						txtdes1.Text="";
						txtdes2.Text="";
						txtdes3.Text="";
						txtdes4.Text="";
						txtdes5.Text="";
						txtdes6.Text="";
						txtdes7.Text="";
						txtdes8.Text="";
						btnSave.Text="Save";
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Dinner.aspx.cs,Method : Droptime_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
	}
}
