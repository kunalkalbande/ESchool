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

namespace eschool.Modules.Reports
{
	/// <summary>
	/// Summary description for Update_Studentinfo.
	/// </summary>
	public class Update_Studentinfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList Dropstype;
		protected System.Web.UI.WebControls.Label lblOption;
		protected System.Web.UI.WebControls.DropDownList Dropsopt;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.TextBox txtStudentid;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.HtmlControls.HtmlButton Print1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Search_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	}
}
