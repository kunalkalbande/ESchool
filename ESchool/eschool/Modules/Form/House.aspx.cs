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

namespace eschool.Modules.Form
{
	/// <summary>
	/// Summary description for House.
	/// </summary>
	public class House : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.TextBox txtname;
		protected System.Web.UI.WebControls.DropDownList dropname;
		protected System.Web.UI.WebControls.Button btnsave;
		protected System.Web.UI.WebControls.Label lablid;
		protected System.Web.UI.WebControls.RequiredFieldValidator validtion1;
		protected System.Web.UI.WebControls.ValidationSummary summary1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temphouse;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempval;
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
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: House.aspx, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					fillID();
					filldrop();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
					string SubModule="12";
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
				
					if(Add_Flag=="False" && Edit_Flag=="False" && Del_Flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
				
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: House.aspx, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}
		string i="";

		/// <summary>
		/// This Method use to generate next id.
		/// </summary>
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;

			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(House_Id)+1 from House_Master",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						i=SqlDtr.GetValue(0).ToString ();
						lablid.Text=SqlDtr.GetValue(0).ToString ();
						if(i.Trim().Equals(""))
						{
							i="1";
							lablid.Text="1";
						}
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog("Form : House.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ uid );
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
			this.dropname.SelectedIndexChanged += new System.EventHandler(this.dropname_SelectedIndexChanged);
			this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method use to clear all the controls.
		/// </summary>
		public void clear()
		{
			txtname.Text="";
			dropname.SelectedIndex=0;
		}

		/// <summary>
		/// This Method use to fetch house name from house_master table and add in the dropname.
		/// </summary>
		public void filldrop()
		{
			SqlConnection con;
			SqlCommand cmd;

			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select * from House_Master order by House_Name",con);
				SqlDtr=cmd.ExecuteReader();
				dropname.Items.Clear();
				dropname.Items.Add("Select");
				while(SqlDtr.Read ())
				{
					dropname.Items.Add(SqlDtr.GetValue(1).ToString()+":"+SqlDtr.GetValue(0).ToString());
					temphouse.Value+=SqlDtr.GetValue(1).ToString()+":"+SqlDtr.GetValue(0).ToString()+",";
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog("Form : House.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ uid );
			}
		}

		/// <summary>
		/// This method use to save and update informaton in to house_master table. and also check record exist or not.
		/// </summary>
		private void btnsave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand cmd;
			SqlDataReader sdtr=null;
			string str="",msg="";
			int icount=0;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				
				str="select count(*) from house_master where house_name='"+tempval.Value+"'";
				cmd=new SqlCommand(str,con);
				sdtr=cmd.ExecuteReader();
				while(sdtr.Read())
				{
					icount=Convert.ToInt32(sdtr.GetValue(0));	
				}
				sdtr.Close();
				cmd.Dispose();
				if(icount>0)
				{
					MessageBox.Show("Record Allready Exists");
					return;
				}
				else
				{
					//13.11.08 if(btnsave.Text!="Update")
					if(dropname.SelectedIndex==0)
					{
					
					
						str="insert into house_master(House_id,house_Name) values(@House_id,@House_Name)";
						msg="Saved";
					
					}
					else
					{
						str="update house_master set house_Name=@House_Name where House_id=@House_id";
						msg="Updated";
					}
				
					cmd=new SqlCommand(str,con);
					//13.11.08 if(btnsave.Text!="Update")
					if(dropname.SelectedIndex==0)
					{
						cmd.Parameters.Add("@House_id",lablid.Text.Trim());
					}
					else
					{
						string house=dropname.SelectedItem.Value;
						string[] house1=house.Split(new char[]{':'});
						cmd.Parameters.Add("@House_id",house1[1]);
					}
					//13.11.08 cmd.Parameters.Add("@House_Name",txtname.Text.Trim().ToString());
					cmd.Parameters.Add("@House_Name",tempval.Value.Trim().ToString());
					cmd.ExecuteNonQuery();
					cmd.Dispose();
					con.Close();
					MessageBox.Show("House Successfully "+msg);
					fillID();
					clear();
					filldrop();
					btnsave.Text="Save";
				}
							
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : House.aspx, Method : btnsave_Click "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}

		/// <summary>
		/// This method use to show selcted value of dropdown in to textbox.
		/// </summary>
		private void dropname_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string house=dropname.SelectedItem.Value;
			house=house.Substring(0,house.IndexOf(":"));
			txtname.Text=house;
			btnsave.Text="Update";
			btnedit.Visible=true;
		}

		/// <summary>
		/// this Method use to delete the information from house_master.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{

			SqlConnection con;
			SqlCommand cmd;
			string str="";
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				
				str="delete from house_master where House_id=@House_id";
				cmd=new SqlCommand(str,con);
				string house=dropname.SelectedItem.Value;
				string[] house1=house.Split(new char[]{':'});
				cmd.Parameters.Add("@House_id",house1[1]);
				cmd.Parameters.Add("@House_Name",txtname.Text.Trim().ToString());
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				con.Close();
				MessageBox.Show("House Successfully Deleted");
				fillID();
				clear();
				filldrop();
				
				btnsave.Text="Save";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : House.aspx, Method : btnsave_Click "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
			
		}
	}
}
