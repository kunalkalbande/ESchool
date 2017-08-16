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
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using eschool.Classes;

namespace eschool
{
	/// <summary>
	/// Summary description for AboutUs.
	/// </summary>
	public class AboutUs : System.Web.UI.Page
	{
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog(" Form : AboutUs.aspx,Method: Page_Load. User_ID : "+ pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : AboutUs.aspx,Method: Page_Load.   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
