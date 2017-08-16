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
using eschool.Classes ;
using RMG;

namespace eschool.Form
{
	/// <summary>
	/// Summary description for SME.
	/// </summary>
	public class TestSME : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnSubmit;
		public string pass;
		public bool flage=false;
		
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
				CreateLogFiles.ErrorLog ("Form : TestSME.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form : TestSME.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			if(!Page.IsPostBack)
			{
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string str="Select class_name from class order by class_id";
				SqlDtr= obj.GetRecordSet(str);
				DropClass.Items.Clear();
				DropClass.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropClass.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="4";
				string SubModule="9";
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
				if(View_flag=="False")
				{
					btnShow.Enabled=false;
				}
				if(Add_Flag=="False")
				{
					btnSubmit.Enabled=false;
				}
				#endregion
			}
		}	
		
		/// <summary>
		/// this method use to change the value of flage variable.becouse after chenge the value of flage variable execute HTML code.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			flage=true;
			
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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
		}
		#endregion

	}
}
