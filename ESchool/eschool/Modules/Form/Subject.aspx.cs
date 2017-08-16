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
using RMG;
using System.Data.SqlClient;

namespace eschool.Modules.Form
{
	/// <summary>
	/// Summary description for Subject.
	/// </summary>
	
	public class Subject : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputText tempvalue;
		public static ArrayList AList=new ArrayList();
		public static int flage=0;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog ("Form: Subject.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subject.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					AList=new ArrayList();
					SqlDataReader sdtr=null;
					InventoryClass obj=new InventoryClass();
					string str="Select * from subject";
					sdtr=obj.GetRecordSet(str);
					AList.Clear();
					while(sdtr.Read())
					{
						//tempvalue.Value+=sdtr.GetValue(0)+":"+sdtr.GetValue(1)+":"+sdtr.GetValue(2)+",";
						AList.Add(sdtr.GetValue(2));
				
					}
					sdtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Subject.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
