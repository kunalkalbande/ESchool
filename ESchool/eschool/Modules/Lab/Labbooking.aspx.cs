   /*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
    # region Directives...
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
using RMG;
using System.Text;
using eschool.Classes;
# endregion

namespace eschool.Lab
{
	/// <summary>
	/// Summary description for Labbooking.
	/// </summary>
	public class Labbooking : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Droplabid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CompareValidator CvStuId;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ValidationSummary vsLabBooking;
		protected System.Web.UI.WebControls.CompareValidator cvLab;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.Button btneditsave;
		protected System.Web.UI.WebControls.Button btndelete;
		protected System.Web.UI.WebControls.Label lid;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Label lbid;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox Textday1;
		protected System.Web.UI.WebControls.TextBox txtdate;
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
				CreateLogFiles.ErrorLog (" Form : LabBooking.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : LabBooking.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
		    	//string pass;
			    //pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
			      {
					Textday1.Text=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();	
					TextBox1.Enabled =false; 
             		DropEdit.Visible=false;
					lbid.Visible=true;
					btnSave.Visible=true;
					btnedit.Visible=true;
					btneditsave.Visible=false;
					nextid();
					Dropclass.Items .Clear (); 
					Dropclass.Items .Add ("---Select---");
					SqlConnection con11;
					SqlCommand  cmdselect11;
					SqlDataReader dtrclass11;
					con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con11.Open ();
					//cmdselect11 = new SqlCommand( "Select Distinct class_name from class order by class_id", con11 );
					cmdselect11 = new SqlCommand( "Select class_name from class order by class_id", con11 );
					dtrclass11 = cmdselect11.ExecuteReader();
					while (dtrclass11.Read()) 
					{
						Dropclass.Items.Add(dtrclass11.GetValue(0).ToString());
					}
					dtrclass11.Close();
					cmdselect11 = new SqlCommand( "Select distinct Lab_id  From Lab_mast order by Lab_id", con11 );
					dtrclass11  = cmdselect11.ExecuteReader();
					while(dtrclass11.Read())
					{
						Droplabid.Items.Add(dtrclass11.GetValue(0).ToString());
					}
              		dtrclass11.Close();
					con11.Close ();
				  }
				if(! IsPostBack)
				  {
						#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="4";
				string SubModule="11";
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
					btnSave.Enabled=false;
				}
				#endregion
				  }
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : Page_Load  ,Userid :  " + pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );

				Response.Redirect("../Form/HolidayEntryForm.aspx"); 
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
			this.DropEdit.SelectedIndexChanged += new System.EventHandler(this.DropEdit_SelectedIndexChanged);
			this.Droplabid.SelectedIndexChanged += new System.EventHandler(this.Droplabid_SelectedIndexChanged);
			this.Dropclass.SelectedIndexChanged += new System.EventHandler(this.Dropclass_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btneditsave.Click += new System.EventHandler(this.btneditsave_Click);
			this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method for returning the student_id.
		/// </summary>
		public string ShowStudentID(string seq_studentid)
		{
			SqlConnection con3;
			SqlCommand cmdselect3;
			SqlDataReader dtredit3;
			con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con3.Open ();
			string student_id="";
			cmdselect3 = new SqlCommand( "Select Student_ID From Student_record where seq_student_id='"+seq_studentid+"'", con3 );
			dtredit3 = cmdselect3.ExecuteReader();
			while (dtredit3.Read()) 
			{
				student_id = dtredit3.GetValue(0).ToString();
			}
			return student_id;
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con44;
				SqlCommand cmdselect44;
				SqlDataReader dtrdrive44;
           		con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				cmdselect44 = new SqlCommand( "Select Student_FName,Student_mname,student_lname  From Student_Record where Student_ID=@Student_ID", con44 );
				
				dtrdrive44 = cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{       
					
				}
				dtrdrive44.Close();
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : Dropstudentid_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// DateTime Function for returning the date in MM/DD/YYYY format.
		/// </summary>
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

     	/// <summary>
		/// this method use to clear the form.
		/// </summary>
		public void Clear()
		{
			Dropclass.SelectedIndex =0; 
			//Textday1.Text="";
			Textday1.Text=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();	
			txtdate.Text="";
			Droplabid.SelectedIndex=0;
			TextBox1.Text=""; 
		}

		/// <summary>
		/// this method use to reset the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
		  Clear();
		}

		/// <summary>
		/// this method use to save the labbooking records in lab_booking table and also check if record all ready exist or not.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con111;
			string strInsert111;
			SqlCommand cmdInsert111;
			try
			{
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				cmdInsert111=new SqlCommand ("select * from lab_booking where lab_id='" + Droplabid.SelectedItem.Value.ToString () + "'",con111);
				SqlDataReader sdr=cmdInsert111.ExecuteReader ();
				if(sdr.HasRows)
				{
					MessageBox.Show ("Lab Already Booked");
					Clear();
					sdr.Close ();
					return;
				}
				sdr.Close ();
				string dt=Textday1.Text;
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				if(DateTime.Compare(ToMMddYYYY(dt),ToMMddYYYY(sSysDate))<0)
				{
					MessageBox.Show("Booking date  must be greater than or equal to current date");
				}
				else
				{
					int i=timecheck();
					if(i==1)
					{
						strInsert111 = "Insert Lab_booking(labbook_id,lab_id ,Lab_day,Lab_time,class)values (@labbook_id,@lab_id,@Lab_day,@Lab_time,@class)";
						cmdInsert111=new SqlCommand (strInsert111,con111);
						cmdInsert111.Parameters .Add ("@labbook_id",lbid.Text.Trim().ToString());
						if(Dropclass .SelectedIndex==0)
							cmdInsert111.Parameters .Add ("@class","0");
						else
							cmdInsert111.Parameters .Add ("@class",Dropclass.SelectedItem .Value.ToString ());
						if(Droplabid.SelectedIndex==0)
							cmdInsert111.Parameters .Add ("@lab_id","0");
						else
							cmdInsert111.Parameters .Add ("@lab_id",Droplabid.SelectedItem .Value.ToString ());
						if(Textday1.Text=="")
							cmdInsert111.Parameters .Add ("@Lab_day","");
						else
							cmdInsert111.Parameters .Add ("@Lab_day",GenUtil.str2MMDDYYYY(Textday1.Text));
						if(txtdate.Text=="")
							cmdInsert111.Parameters .Add ("@Lab_time","");
						else
							cmdInsert111.Parameters .Add ("@Lab_time",txtdate.Text.ToString());
						cmdInsert111.ExecuteNonQuery();
						con111.Close ();
						MessageBox.Show("Lab Booking Successfully Saved");
						CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnSave_Click  Userid :  " + pass   );				
						nextid();
						Clear();
						DropEdit.Visible=false;
						lbid.Visible=true;
						btnSave.Visible=true;
						btnedit.Visible=true;
						btneditsave.Visible=false;
					}
					else
					{
						MessageBox.Show("Please enter valid time");
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// this method use to check the time format.
		/// </summary>
		public int timecheck()
		{
			string sdif=txtdate.Text.ToString().Trim();
			int iH=sdif.IndexOf(":");
			if(iH<0)
				return(0);
			int idH=Convert.ToInt32(sdif.Substring(0,iH));
			int idM=Convert.ToInt32(sdif.Substring(iH+1));
			if((idH>=00 && idH<=23)&& (idM>=00 && idM<60))
				return(1);
			else
				return(0);
		}

		/// <summary>
		/// this Method Return next labbookid from lab_booking table.
		/// </summary>
		public void nextid()
		{
			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con.Open ();
			strInsert = "select max(labbook_id)+1 from  lab_booking ";
			cmdInsert=new SqlCommand (strInsert,con);
			SqlDataReader dr=cmdInsert.ExecuteReader();
			string st="";
			if(dr.Read())
			{
				st=dr.GetValue(0).ToString();
			}
			dr.Close();
			if(st.Equals("")||st==null)
				lbid.Text="1";
			else
				lbid.Text=st.ToString();
		}

		/// <summary>
		/// this Method for visible the control and add the labbookid into the DropEdit for editing.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropEdit.Visible=true;
				lbid.Visible=false;
				btnSave.Visible=false;
				btnedit.Visible=false;
				btneditsave.Visible=true;			
				SqlConnection con;
				SqlCommand cmd;
				SqlDataReader dr;
				DropEdit.Items.Clear();
				DropEdit.Items.Add("--Select--");
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();
				string str="select labbook_id from lab_booking";
				cmd=new SqlCommand(str,con);
				dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					DropEdit.Items.Add(dr["labbook_id"].ToString());
				}
				dr.Close();
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnedit_Click, Userid :  " + pass   );				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnedit_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// this Method use to update the infromation lab_booking table.
		/// </summary>
		private void btneditsave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con111;
			string strInsert111;
			SqlCommand cmdInsert111;
			try
			{
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				strInsert111 = "update Lab_booking set lab_id=@lab_id,Lab_day=@Lab_day,Lab_time=@Lab_time,class=@class where labbook_id='" + DropEdit.SelectedItem.Value.ToString () + "'";
				cmdInsert111=new SqlCommand (strInsert111,con111);
				if(Droplabid.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@lab_id","0");
				else
					cmdInsert111.Parameters .Add ("@lab_id",Droplabid.SelectedItem .Value.ToString ());
				if(Dropclass .SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@class","");
				else
					cmdInsert111.Parameters .Add ("@class",Dropclass .SelectedItem .Value.ToString ());
				if(Textday1.Text=="")
					cmdInsert111.Parameters .Add ("@Lab_day","");
				else
					cmdInsert111.Parameters .Add ("@Lab_day",GenUtil.str2MMDDYYYY(Textday1.Text.Trim()));
				if(txtdate.Text=="")
					cmdInsert111.Parameters .Add ("@Lab_time","");
				else
					cmdInsert111.Parameters .Add ("@Lab_time",txtdate.Text.Trim().ToUpper());
				cmdInsert111.ExecuteNonQuery();
				con111.Close ();
				
				MessageBox.Show("Lab Booking Successfully Updated");
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnUpdate_Click, Userid :  " + pass   );				
				Clear();
				nextid();
				DropEdit.Visible=false;
				lbid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btnUpdate_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// this Method for deleting the records from lab_booking table.
		/// </summary>
		private void btndelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();
				cmd=new SqlCommand("delete lab_booking where labbook_id='"+DropEdit.SelectedItem.Text.ToString()+"'",con);
				cmd.ExecuteNonQuery();
				MessageBox.Show("Lab Booking Successfully Deleted");
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btndelete_Click  , Labbooking  Record Deleted for LabbookingID  " +DropEdit.SelectedItem.Text.ToString()+"  Userid "+ pass   );				
				nextid();
				Clear();
				DropEdit.Visible=false;
				lbid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btndelete_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// this method use to show selected id record from lab_booking table.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand cmd;
			SqlDataReader dr;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open();
				string str="select l.labbook_id,l.lab_id,l.Lab_day,l.Lab_time,l.class from  Lab_booking l where labbook_id='"+DropEdit.SelectedItem.Text.ToString()+"' ";
				cmd=new SqlCommand(str,con);
				dr=cmd.ExecuteReader();
				string aa=" ";
				while(dr.Read())
				{
					Droplabid.SelectedIndex=Droplabid.Items.IndexOf(Droplabid.Items.FindByValue(dr.GetValue(1).ToString()));
					Dropclass.SelectedIndex =Dropclass.Items.IndexOf(Dropclass.Items.FindByValue(dr["class"].ToString()));
					txtdate.Text=dr["Lab_time"].ToString();
					Textday1.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr["Lab_day"].ToString()));
				}
				dr.Close();
				str="Select  labname from lab_mast where lab_id='" + Droplabid.SelectedItem.Value .ToString () + "'";
				cmd = new SqlCommand(  str, con );
				dr = cmd.ExecuteReader(); 
				if(dr.Read ())
				{
					TextBox1.Text=dr.GetValue (0).ToString ();
				}
				dr.Close ();
				str="Select  seq_student_id from student_record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "' and student_id in(select student_id from lab_booking)";
				cmd = new SqlCommand(  str, con );
				dr = cmd.ExecuteReader(); 
				dr.Close ();
				str="Select  seq_student_id from student_record where student_id='" + aa + "'";
				cmd = new SqlCommand(  str, con );
				dr = cmd.ExecuteReader(); 
				while(dr.Read ())
				dr.Close ();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Labbooking.aspx.cs,Method : btndelete_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
			{
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				cmdselect11 = new SqlCommand( "Select Distinct seq_student_id from student_record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "'", con11 );
				dtrclass11 = cmdselect11.ExecuteReader();
				dtrclass11.Close();
				con11.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Labbooking.aspx.cs, Method: Dropclass_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to Fetch Lab Name From lab_booking table.
		/// </summary>
		private void Droplabid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
			{
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				cmdselect11 = new SqlCommand( "Select * from lab_mast where lab_id='" + Droplabid.SelectedItem .Value .ToString () + "'", con11 );
				dtrclass11 = cmdselect11.ExecuteReader();
				if (dtrclass11.Read()) 
				{
					TextBox1.Text=dtrclass11.GetValue(1).ToString();
				}
				dtrclass11.Close();
				con11.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Labbooking.aspx.cs, Method: Droplabid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

	}
}