namespace eschool.usercontrol
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using eschool.Classes;

	/// <summary>
	///		Summary description for header.
	/// </summary>
	public abstract class header : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label  Labusertype1;
		protected System.Web.UI.WebControls.Label Labusertype;
		protected System.Web.UI.WebControls.Label Labelloginby;
		protected System.Web.UI.WebControls.Label Labelloginby3;
        string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				lblDate.Text=GenUtil.str2DDMMYYYY(System.DateTime.Now.ToString());
				Labusertype1.Text=Session["Login_By"].ToString();
				Labelloginby3.Text=Session["User_Type"].ToString();
				//lblTime.Text=Convert.ToString( System.DateTime.Now.);
				pass=Session["password"].ToString();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Header.ascx,Method : Page_Load  Exception: "+ex.Message+"  User: "+ pass);     
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
