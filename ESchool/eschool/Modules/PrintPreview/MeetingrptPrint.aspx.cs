
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
using eschool.Classes ;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace eschool.PrintPreview
{
	/// <summary>
	/// Summary description for MeetingrptPrint.
	/// </summary>
	public class MeetingrptPrint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrdcomp;
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{

//				if(Session["view"]!=null)
//				{
//					try
//					{
//						if(Session["password"].ToString().Length<=0&&(bool)Session["view"]==false)
//						{
//							Session.Abandon();
//							Session.RemoveAll();
//						 	Response.Redirect(@"./HolidayEntryForm.aspx");
//						}
//						else
//						{
//							Response.Buffer=false;
//							Response.CacheControl="no-cache";
//							Response.Expires=System.DateTime.Now.Minute-1;	
//							Session["view"]=false;
//						}
//					}
//					catch(System.NullReferenceException)
//					{
//						Session.Abandon();
//						Response.Redirect(@".\HolidayEntryForm.aspx");
//					}
//				
//				}
//				else
//				{
//					Response.Buffer=false;
//					Response.CacheControl="no-cache";
//					Response.Expires=System.DateTime.Now.Minute-1;
//					Session["view"]=false;
//				}
			
			pass=(Session["password"].ToString ());

			SqlConnection con1 ;
			string strInsert1;
			SqlCommand cmdInsert1;
              			
			con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con1.Open ();
						
			strInsert1 ="Select *  From ptameetingagenda ";
			cmdInsert1=new SqlCommand (strInsert1,con1);
			dgrdcomp.DataSource =cmdInsert1.ExecuteReader();
			dgrdcomp.DataBind ();
			con1.Close();    
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :MeetingrptPrint.aspx,Method  Page_Load,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
