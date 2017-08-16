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
	/// Summary description for TimeTable.
	/// </summary>
	public class TimeTable : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDesign;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label tcid;
		string pass;

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
				CreateLogFiles.ErrorLog (" Form : Time Table.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Time Table.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
		  try
			{
				//string pass;
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string str="Select distinct staff_type from staff_information where teaching=1 or activity=1 order by staff_type"; //add vikas sharma date on 21.02.08
					SqlDtr= obj.GetRecordSet(str);
					DropDesign.Items.Clear();
					DropDesign.Items.Add("Select");
					DropDesign.Items.Add("All");
    				while(SqlDtr.Read())
					{
						DropDesign.Items.Add(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
					#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="5";
				string SubModule="1";
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
			  CreateLogFiles.ErrorLog ("Form: TimeTable.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: TimeTable.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}	
		}
		/// <summary>
		/// This method use to Generate Next id TeacherTimeTable table.
		/// </summary>
		public void NextID()
		{
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
			{
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				cmdselect11 = new SqlCommand( "Select  max (sno)+1  From TeacherTimeTable ", con11 );
				dtrclass11 = cmdselect11.ExecuteReader();
				string st="";
				while (dtrclass11.Read()) 
				{
					st=dtrclass11.GetValue(0).ToString();
				}
				if(st.Equals("")  || st==null)
				{
					tcid.Text="1";
				}
				else
				{
					tcid.Text=st.ToString();
				}
				dtrclass11.Close();
				con11.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: NextTcid. Exception: " + ex.Message + " User: " + pass );
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
