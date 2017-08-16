namespace eschool.usercontrol
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using eschool.Classes;
	using RMG;
	using System.Data.SqlClient;
 	/// <summary>
	///		Summary description for Header1.
	/// </summary>
	public class Header1 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Labusertype;
		protected System.Web.UI.WebControls.Label Labusertype1;
		protected System.Web.UI.WebControls.Label Labelloginby;
		protected System.Web.UI.WebControls.Label Labelloginby3;
		protected System.Web.UI.WebControls.Label Label3;
		string session_id="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
					
			lblDate.Text=Session["Login_Date"].ToString();
			Labusertype1.Text=Session["Login_By"].ToString();
			Labelloginby3.Text=Session["User_Type"].ToString();
			//string session_id
			session_id=Session["password"].ToString().Trim()+":"+Session["userpass"].ToString().Trim();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			
		}
		#endregion
	}
}
