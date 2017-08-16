using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using RMG;

namespace eschool 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			if ( Application[ "SessionCount" ] == null ) 
			{
				Application[ "SessionCount" ] = 0;
			}
			Application[ "SessionCount" ] = 1;
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{
			Application[ "SessionCount" ] = 0;
			
			/*string Logname=Session["User_Name"].ToString().Trim();
			MessageBox.Show(Logname.ToString().Trim()+" Session has Been Expire");
			SqlConnection cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			cn.Open();
   
			//string str=""
			SqlCommand cmd=new SqlCommand();*/
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}

