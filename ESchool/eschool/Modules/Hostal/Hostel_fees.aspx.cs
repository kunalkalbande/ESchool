		
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
using eschool.Classes;
using RMG;
# endregion

namespace eschool.Hostel
{
	/// <summary>
	/// Summary description for Hostel_fees.
	/// </summary>
	public class Hostel_fees : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.TextBox txtfees;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.CompareValidator cvClass;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary vsFees;
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
				CreateLogFiles.ErrorLog (" Form: Hostel_Fees.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				
				//pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
				{
					Dropclass.Items .Clear (); 
					Dropclass.Items .Add ("---Select---");
					fillID();
					SqlConnection con11;
					SqlCommand  cmdselect11;
					SqlDataReader dtrclass11;
					con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con11.Open ();
					cmdselect11 = new SqlCommand( "Select class_name from class order by class_Id", con11 );
					dtrclass11 = cmdselect11.ExecuteReader();
					while (dtrclass11.Read()) 
					{
						Dropclass.Items.Add(dtrclass11.GetValue(0).ToString());
					}
					dtrclass11.Close();
					con11.Close ();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="9";
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
						//10.05.08--Response.Redirect("../AccessDeny.aspx");
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					if(Add_Flag=="False")
					{
						btnSave.Enabled=false;
					}
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : Hostel_fees.aspx.cs,Method : Page_Load, Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Hostel_fees.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );
				Response.Redirect("../Form/HolidayEntryForm.aspx"); 
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
			this.Dropclass.SelectedIndexChanged += new System.EventHandler(this.Dropclass_SelectedIndexChanged);
			this.txtfees.TextChanged += new System.EventHandler(this.txtfees_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
 		/// <summary>
		/// this method use to Clear form.
		/// </summary>
		public void Clear()
		{
			txtfees.Text="";
			Dropclass.SelectedIndex=0;
		}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// this method use to Get Next HostelFeesID
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
				cmd=new SqlCommand("select max(hostel_fees)+1 from Hostel_fees",con);
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
		/// this Method use to save and update the hostel fees Records in to hostel_fees table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				fillID();
				string msg="";
				if(btnSave.Text.Equals("Update"))
				{
					strInsert = "update Hostel_fees set Class_id=@Class_id, fees=@fees where class_id='" + Dropclass.SelectedItem .Value .ToString () + "'";
					msg="Updated";
					btnSave.Text="Save";
				}
				else
				{
					strInsert = "Insert Hostel_fees(hostel_fees,Class_id,fees)values (@hostel_fees,@Class_id,@fees)";
					msg="saved";
				}
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.Parameters .Add ("@hostel_fees",i.Trim().ToString());
				if(Dropclass .SelectedIndex==0)
					cmdInsert.Parameters .Add ("@Class_id","");
				else
					cmdInsert.Parameters .Add ("@Class_id",Dropclass.SelectedItem .Text.ToString());
				if(txtfees.Text=="")
					cmdInsert.Parameters .Add ("@fees","");
				else
					cmdInsert.Parameters .Add ("@fees",txtfees.Text.Trim().ToUpper());
				cmdInsert.ExecuteNonQuery();
				con.Close();	
				MessageBox.Show("Hostel Fees Successfully " + msg + ".");
				CreateLogFiles.ErrorLog(" Form : Hostel_fees.aspx.cs,Method : btnSave_Click  ,  Hostel fees:"+ txtfees.Text.Trim().ToUpper()   +" for Class:"+ Dropclass.SelectedItem .Text.ToString() +"  is saved ,      Userid :  " + pass   );
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Hostel_fees.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this Method use to fetch the hostel fees From hostel_fees table.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string s1="";
				string ss ="";
			    ss = Dropclass.SelectedItem.Text.ToString();
				strInsert = "select * from Hostel_fees";
				cmdInsert=new SqlCommand (strInsert,con);
				SqlDataReader sdr=cmdInsert.ExecuteReader();
				txtfees.Text="";
				while(sdr.Read())
				{
					s1=sdr.GetValue (1).ToString ();
					
					if(s1.Equals(ss))
					{
						txtfees.Text=sdr.GetValue (2).ToString ();
						btnSave.Text="Update"; 
					}
					else
						btnSave.Text="Save"; 
				}
			}
			catch(Exception ex)
			{
		 		CreateLogFiles.ErrorLog(" Form : Hostel_fees.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		private void txtfees_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
