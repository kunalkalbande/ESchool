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
using System.Data.SqlClient;
using RMG;
using eschool.Classes ;

namespace eschool.Form
{
	/// <summary>
	/// Summary description for EmployeeAttendance.
	/// </summary>
	public class EmployeeAttendance : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.DataGrid dgrdStaffName;
		protected System.Web.UI.WebControls.ValidationSummary vsStuMarks;

		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		protected System.Web.UI.WebControls.DropDownList dropDesignation;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox Textbox;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAttendance;
		protected System.Web.UI.WebControls.RadioButton chkTeaching;
		protected System.Web.UI.WebControls.RadioButton chkNonTeaching;
		protected System.Web.UI.WebControls.RadioButton chkGroupD;
		SqlDataReader sdtr;
		string pass;

		#region Page Load...
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			try
			{
				
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: staffAttendance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			
			scon.Open();
			txtDate.Text=GenUtil.str2DDMMYYYY(System.DateTime.Now.ToShortDateString());
//			scom=new SqlCommand("Select staff_type from Staff_Type",scon);
//			sdtr=scom.ExecuteReader();
//			while(sdtr.Read())
//			{
//				DropStaffType.Items.Add(sdtr.GetString(0));
//			}
//			sdtr.Close();
			
		}
		#endregion

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
			this.chkTeaching.CheckedChanged += new System.EventHandler(this.chkTeaching_CheckedChanged);
			this.chkNonTeaching.CheckedChanged += new System.EventHandler(this.chkNonTeaching_CheckedChanged);
			this.chkGroupD.CheckedChanged += new System.EventHandler(this.chkGroupD_CheckedChanged);
			this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		# region staffType Function
		public void staffType()
		{
			

			# region CASE-1(TRUE,FALSE)
			if(chkTeaching.Checked==true)// && chkNonTeaching.Checked==false)
			{
				dgrdStaffName.Visible=false;
				scom = new SqlCommand( "Select distinct staff_type  From Staff_information  where teaching=1 and nonteaching=0 order by staff_type", scon );
				sdtr =  scom.ExecuteReader();
				dropDesignation.Items.Clear();
				dropDesignation.Items.Add("---Select---");
				dropDesignation.Items.Add("All");
				while(sdtr.Read())
				{
					dropDesignation.Items.Add(sdtr.GetString(0));
				}
				sdtr.Close();
			}
			# endregion

			# region CASE-2(FALSE,TRUE)
			if(chkTeaching.Checked==false && chkNonTeaching.Checked==true)
			{
				dgrdStaffName.Visible=false;
				scom = new SqlCommand( "Select distinct staff_type  From staff_information  where nonteaching=1 and teaching=0 order by staff_type", scon );
				sdtr =  scom.ExecuteReader();
				dropDesignation.Items.Clear();
				dropDesignation.Items.Add("---Select---");

				dropDesignation.Items.Add("All");

				while(sdtr.Read())
				{
					dropDesignation.Items.Add(sdtr.GetString(0));
				}
				sdtr.Close();
			}

			# endregion

			# region CASE-3(TRUE)
			if(chkGroupD.Checked ==true && chkTeaching.Checked==false && chkNonTeaching.Checked==false)
			{
				dgrdStaffName.Visible=false;
				scom = new SqlCommand( "Select distinct staff_type  From staff_information  where groupd=1  order by staff_type", scon );
				sdtr =  scom.ExecuteReader();
				dropDesignation.Items.Clear();
				dropDesignation.Items.Add("---Select---");
				dropDesignation.Items.Add("All");
				while(sdtr.Read())
				{
					dropDesignation.Items.Add(sdtr.GetString(0));
				}
				sdtr.Close();
			}
//			if(chkTeaching.Checked==true && chkNonTeaching.Checked==true)
//			{
//				scom= new SqlCommand( "Select distinct staff_type  From Staff_information  where teaching=1 and nonteaching=1 order by staff_type", scon );
//				sdtr =  scom.ExecuteReader();
//				dropDesignation.Items.Clear();
//				dropDesignation.Items.Add("---Select---");
//				while(sdtr.Read())
//				{
//					dropDesignation.Items.Add(sdtr.GetString(0));
//				}
//				sdtr.Close();
//			}
			# endregion

			# region CASE-4(FALSE,FALSE)
//			if(chkTeaching.Checked==false && chkNonTeaching.Checked==false)
//			{
//				dropDesignation.Items.Clear();
//				dropDesignation.Items.Add("---Select---");
//			}
			# endregion
				
		}
		# endregion
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}
		#region CheckBox Teaching...
		private void chkTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
		
		}
# endregion

		#region CheckBox NonTeaching...

		private void chkNonTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
		}
		# endregion


		#region Show Button...

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				string sDesignation="";
				if(dropDesignation.SelectedIndex==0)
				{
					RMG.MessageBox.Show("Please select the designation");
				}
				else
				{
					sDesignation=dropDesignation.SelectedItem.Text.ToString().Trim();
				}
			
				if( sDesignation.Equals("All"))
				{
					dgrdStaffName.Visible=true;
					string cmdselect="";
					if(chkTeaching.Checked==true)
					{
						cmdselect="Select Staff_ID,Staff_Name from Staff_Information where staff_id not in(select distinct staff_id from staff_attandance where Attendance_date ='"+ToMMddYYYY(txtDate.Text)+"') and teaching='1'";
					}
					else if(chkNonTeaching.Checked==true)
					{
						cmdselect="Select Staff_ID,Staff_Name from Staff_Information where staff_id not in(select distinct staff_id from staff_attandance where Attendance_date ='"+ToMMddYYYY(txtDate.Text)+"') and nonteaching='1' ";
					}
					else if(chkGroupD.Checked==true)
					{
						cmdselect="Select Staff_ID,Staff_Name from Staff_Information where staff_id not in(select distinct staff_id from staff_attandance where Attendance_date ='"+ToMMddYYYY(txtDate.Text)+"') and groupd='1'";
					}
					else
					{
						MessageBox.Show("Please Select Appropriate Staff Type");
						return;
					}
					//string cmdselect="Select Staff_ID,Staff_Name from Staff_Information where staff_id not in(select distinct staff_id from staff_attandance where Attendance_date ='"+ToMMddYYYY(txtDate.Text)+"')";
			
					//string cmdselect="Select Staff_ID,Staff_Name from Staff_Information where upper(Staff_Type)like '" + sDesignation + "%'";				
					SqlDataAdapter objAdapter =new SqlDataAdapter(cmdselect,scon);
					DataSet obj=new DataSet();
					objAdapter.Fill(obj);
					dgrdStaffName.DataSource=obj;
					dgrdStaffName.DataBind();
					if(dgrdStaffName.Items.Count==0)
					{
						clear();
						RMG.MessageBox.Show("Attendance already done for this Designation or May be no Such record available");
						dgrdStaffName.Visible=false;
						clear();
					}
					 
				}

				else if( sDesignation!="")
				{
					dgrdStaffName.Visible=true;
					string cmdselect="Select Staff_ID,Staff_Name from Staff_Information where upper(Staff_Type)like '" + sDesignation + "%'and staff_id not in(select distinct staff_id from staff_attandance where Attendance_date ='"+ToMMddYYYY(txtDate.Text)+"')";
			
					//string cmdselect="Select Staff_ID,Staff_Name from Staff_Information where upper(Staff_Type)like '" + sDesignation + "%'";				
					SqlDataAdapter objAdapter =new SqlDataAdapter(cmdselect,scon);
					DataSet obj=new DataSet();
					objAdapter.Fill(obj);
					dgrdStaffName.DataSource=obj;
					dgrdStaffName.DataBind();
					if(dgrdStaffName.Items.Count==0)
					{
						clear();
						RMG.MessageBox.Show("Attendance already done for this Designation");
						dgrdStaffName.Visible=false;
						clear();
					}
					 
				}
	
			}
			catch(Exception ex)
			{

				CreateLogFiles.ErrorLog ("Form: staffAttendance.aspx.cs, Method: btnShow_Click, Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		
		}
						
	# endregion

		#region Clear Function...

		public void clear()
		{
			chkNonTeaching.Checked=false;
			chkTeaching.Checked=false;
			chkGroupD.Checked=false; 
			dropDesignation.SelectedIndex=0;
			txtDate.Text="";
			dgrdStaffName.DataSource=null;
			dgrdStaffName.DataBind();

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int x=0;
				int no= dgrdStaffName.Items.Count;
				for(int i=0;i<no;i++)
				{
					CheckBox chk=(CheckBox)dgrdStaffName.Items[i].Cells[2].Controls[1];
					{
						x++;
					}
				}
				if(x==0)
				{
					MessageBox.Show("Please Select Staff ID For Attedance");
					return;
				}
				for(int i=0; i<no;i++)
				{
					CheckBox chk=(CheckBox)dgrdStaffName.Items[i].Cells[2].Controls[1];
					if(chk.Checked==true)
					{
						string  iid= dgrdStaffName.Items[i].Cells[0].Text.ToString();
						string date=DateTime.Now.ToShortDateString();
                       	SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
						string sql="insert staff_Attandance (staff_ID,Attendance_date,Attandance_status)values(@staffID,@Today_Date,1)";
						SqlCommand scom=new SqlCommand(sql,scon);
 					 	scom.Parameters .Add("@staffID",iid);
						scom.Parameters .Add("@Today_Date",ToMMddYYYY(txtDate.Text));
		 				scom.ExecuteNonQuery();
						
					}
					//********
					else
					{
						string  iid= dgrdStaffName.Items[i].Cells[0].Text.ToString();
						string date=DateTime.Now.ToShortDateString();
						SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
						string sql="insert staff_Attandance (staff_ID,Attendance_date,Attandance_status)values(@staffID,@Today_Date,0)";
						SqlCommand scom=new SqlCommand(sql,scon);
						scom.Parameters .Add("@staffID",iid);
						scom.Parameters .Add("@Today_Date",ToMMddYYYY(txtDate.Text));
						scom.ExecuteNonQuery();
						
					}
					//***********
				}
				MessageBox.Show("Attendance Saved");
				clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: staffAttendance.aspx.cs, Method: btnSave_Click, Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void txtDate_TextChanged(object sender, System.EventArgs e)
		{
		   

		}

		private void chkGroupD_CheckedChanged(object sender, System.EventArgs e)
		{
				staffType();
		}
	}
}
