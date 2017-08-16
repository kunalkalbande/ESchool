     
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
	/// Summary description for Leaveallowed.
	/// </summary>
	public class Leaveallowed : System.Web.UI.Page
	{
		
		protected System.Web.UI.WebControls.DropDownList dropEmpName;
		protected System.Web.UI.WebControls.CompareValidator cvEmpName;
		protected System.Web.UI.WebControls.TextBox txtEmpID;
		protected System.Web.UI.WebControls.TextBox txtcl;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtmed;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox txtearn;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtother;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtwithoutpay;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.Button Btnsave;
		protected System.Web.UI.WebControls.Button Reset1;
		protected System.Web.UI.WebControls.ValidationSummary vsEmpLeaveAllowed;
		protected System.Web.UI.WebControls.Label Label2;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			
				try
				{
            	 	pass=(Session["password"].ToString ());
					CreateLogFiles.ErrorLog ("Form: Leave_Assignment.aspx.cs, Method: Page_Load.  User: " + pass );
				}  
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Leave_Assignment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				    Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
					return;
 				}
			try
			{
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="3";
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
						return;
					}
					if(Add_Flag=="False")
					{
						Btnsave.Enabled=false;
					}
					#endregion
				
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Leave_Assignment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			//this.dropEmpName.SelectedIndexChanged += new System.EventHandler(this.dropEmpName_SelectedIndexChanged);
			//this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		string i="";
		private void fillID()
		{
			
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
		}

		private void dropEmpName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void Reset1_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
