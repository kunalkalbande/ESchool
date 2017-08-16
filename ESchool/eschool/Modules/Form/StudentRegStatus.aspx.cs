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

namespace eschool.Form
{
	/// <summary>
	/// Summary description for StudentRegStatus.
	/// </summary>
	public class StudentRegStatus : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSubmit;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog("Form : StudentRegStatus.aspx,Method: Page_Load. User_ID : "+ pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : StudentRegStatus.aspx,Method: Page_Load.   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
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
					string Module="4";
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
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					if(Add_Flag=="False")
					{
						btnSubmit.Enabled=false;
					}
				
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:StudentRegStatus.aspx,Method: Page_Load.   EXCEPTION " +ex.Message +"  User_ID : "+ Session["User_Name"].ToString());
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
