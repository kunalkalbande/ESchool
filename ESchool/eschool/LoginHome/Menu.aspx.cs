using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using eschool.Classes;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace eschool.LoginHome
{
	/// <summary>
	/// Summary description for Menu.
	/// </summary>
	public class Menu : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.Label lblUserlogin;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			if(Session["view"]!=null)
//			{
//				try
//				{
//					if(pass.Length<=0&&(bool)Session["view"]==false)
//					{
//						Session.Abandon();
//						Session.RemoveAll();
//						//Cache.Remove("view");
//						Response.Redirect(@"./HolidayEntryForm.aspx");
//					}
//					else
//					{
//						Response.Buffer=false;
//						Response.CacheControl="no-cache";
//						Response.Expires=System.DateTime.Now.Minute-1;	
//						Session["view"]=false;
//					}
//				}
//				catch(System.NullReferenceException)
//				{
//					Session.Abandon();
//					Response.Redirect(@".\HolidayEntryForm.aspx");
//				}
//				
//			}
//			else
//			{
//				Response.Buffer=false;
//				Response.CacheControl="no-cache";
//				Response.Expires=System.DateTime.Now.Minute-1;
//				Session["view"]=false;
//			}
			try
			{
				string pass;
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :Menu.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  ");		
				//Response.Redirect(@".\HolidayEntryForm.aspx");
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
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void TextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void TextBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("/eschool/LoginHome/Login.aspx");
		}

		
		}

}
