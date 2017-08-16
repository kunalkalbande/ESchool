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
using eschool.Classes ;
# endregion

namespace eschool.Health
{
	/// <summary>
	/// Summary description for studenthealthcheck.
	/// </summary>
	public class studenthealthcheck : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.DropDownList Dropeye;
		protected System.Web.UI.WebControls.TextBox Textdeseye1;
		protected System.Web.UI.WebControls.DropDownList Dropnoise;
		protected System.Web.UI.WebControls.TextBox Textdesnoise1;
		protected System.Web.UI.WebControls.DropDownList Drophands;
		protected System.Web.UI.WebControls.TextBox Textdeshands1;
		protected System.Web.UI.WebControls.DropDownList Droplegs;
		protected System.Web.UI.WebControls.TextBox Textdeslegs1;
		protected System.Web.UI.WebControls.DropDownList Dropteeth;
		protected System.Web.UI.WebControls.TextBox Textdesteeth1;
		protected System.Web.UI.WebControls.DropDownList Dropbp;
		protected System.Web.UI.WebControls.TextBox Textdesbp1;
		protected System.Web.UI.WebControls.DropDownList Dropheart;
		protected System.Web.UI.WebControls.TextBox Textdesheart1;
		protected System.Web.UI.WebControls.DropDownList Dropmental;
		protected System.Web.UI.WebControls.TextBox Textdesmentalt1;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CompareValidator cvStudentId;
		protected System.Web.UI.WebControls.CompareValidator cveye;
		protected System.Web.UI.WebControls.CompareValidator cvNose;
		protected System.Web.UI.WebControls.CompareValidator cvHands;
		protected System.Web.UI.WebControls.CompareValidator cvLegs;
		protected System.Web.UI.WebControls.CompareValidator cvTeeth;
		protected System.Web.UI.WebControls.CompareValidator cvBP;
		protected System.Web.UI.WebControls.CompareValidator cvHeart;
		protected System.Web.UI.WebControls.CompareValidator cvMental;
		protected System.Web.UI.WebControls.DropDownList DropSkin;
		protected System.Web.UI.WebControls.TextBox txtSkindes1;
		protected System.Web.UI.WebControls.CompareValidator cvSkin;
		protected System.Web.UI.WebControls.ValidationSummary vsHealthcheck;
		protected System.Web.UI.WebControls.DropDownList Dropdocname;
		protected System.Web.UI.WebControls.DropDownList Dropear;
		protected System.Web.UI.WebControls.TextBox Textdesear1;
		protected System.Web.UI.WebControls.DropDownList Dropchdoc;
		protected System.Web.UI.WebControls.CompareValidator cvDocCheck;
		protected System.Web.UI.WebControls.CompareValidator cvEar;
		protected System.Web.UI.WebControls.DropDownList Dropstaff;
		protected System.Web.UI.WebControls.CompareValidator cvStaff;
		protected System.Web.UI.WebControls.CompareValidator cvDuration;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList Dropbg;
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
				CreateLogFiles.ErrorLog (" Form : Student_HelthCheckUp.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Student_HelthCheckUp.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{	
					Dropclass.Items .Clear (); 
					Dropclass.Items .Add ("Select");
					fillID();
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
					con11.Close ();
					SqlConnection con22;
					SqlCommand  cmdselect22;
					SqlDataReader dtrclass22;
					con22=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con22.Open ();
					cmdselect22 = new SqlCommand( "Select Staff_Name From Staff_Information order by Staff_Name", con22 );
					dtrclass22 = cmdselect22.ExecuteReader();
					Dropstaff.Items.Add("Select");
					while (dtrclass22.Read()) 
					{					
						Dropstaff.Items.Add(dtrclass22.GetString(0));
					}
					dtrclass22.Close();
					con22.Close ();
					SqlConnection con33;
					SqlCommand  cmdselect33;
					SqlDataReader dtrclass33;
					con33=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con33.Open ();
					cmdselect33 = new SqlCommand( "Select doctor_name From doctor order by doctor_name", con33 );
					dtrclass33 = cmdselect33.ExecuteReader();
					Dropchdoc.Items.Add("Select");
					while (dtrclass33.Read()) 
					{				
						Dropchdoc.Items.Add(dtrclass33.GetString(0));
					}
					dtrclass33.Close();
					con33.Close ();
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="4";
					string SubModule="10";
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
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: Page_Load.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Dropclass.SelectedIndexChanged += new System.EventHandler(this.Dropclass_SelectedIndexChanged);
			this.Dropstudentid.SelectedIndexChanged += new System.EventHandler(this.Dropstudentid_SelectedIndexChanged);
			this.txtstudentname.TextChanged += new System.EventHandler(this.txtstudentname_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method use to save student_id in a variable by passing student_id.
		/// </summary>
		public string ShowStudentID(string seq_studentid)
		{
			SqlConnection con3;
			SqlCommand cmdselect3;
			SqlDataReader dtredit3;
			try
			{		 
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				string student_id="";
				cmdselect3 = new SqlCommand( "Select Student_ID From Student_record where student_id=@student_id'", con3 );
				dtredit3 = cmdselect3.ExecuteReader();
				while (dtredit3.Read()) 
				{
					student_id = dtredit3.GetValue(0).ToString();
				}
				return student_id;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: ShowStudentID. Exception: " + ex.Message + " User: " + pass );
				return("0");
			}
		}
		
		/// <summary>
		///  This method use to show student name and oyher information in a textbox by passing student_id.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con44;
			SqlCommand cmdselect44;
			SqlDataReader dtrdrive44;
			try
			{
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				string seqid = Dropstudentid.SelectedItem .Value.ToString ();
				cmdselect44 = new SqlCommand( "Select Student_FName,bg From Student_Record where Student_ID='"+Dropstudentid.SelectedItem .Text +"'", con44 );
				cmdselect44.Parameters .Add ("@Student_ID",Dropstudentid.SelectedItem .Text );
				dtrdrive44 = cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{
					txtstudentname.Text =dtrdrive44.GetString(0);
					Dropbg.Items.Add(dtrdrive44.GetValue(1).ToString());
					Dropbg.SelectedIndex=Dropbg.Items.IndexOf(Dropbg.Items.FindByValue(dtrdrive44.GetValue(1).ToString()));
				}
				dtrdrive44.Close();
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: Dropstudentid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Clear controls on aspx page.
		/// </summary>
		public void Clear()
		{
			Dropbg.SelectedIndex=0; 
			Dropstudentid.SelectedIndex=0;
			txtstudentname.Text="";
			Dropear.SelectedIndex=0;
			Textdesear1.Text="";
			Dropeye.SelectedIndex=0;
			Textdeseye1.Text="";
			Dropnoise.SelectedIndex=0;
			Textdesnoise1.Text="";
			Drophands.SelectedIndex=0;
			Textdeshands1.Text="";
			Textdesear1.Text="";
			Droplegs.SelectedIndex=0;
			Textdeslegs1.Text="";
			Dropteeth.SelectedIndex=0;
			Textdesteeth1.Text="";
			Dropbp.SelectedIndex=0;
			Textdesbp1.Text="";
			Dropheart.SelectedIndex=0;
			Textdesheart1.Text="";
			DropSkin.SelectedIndex=0;
			txtSkindes1.Text="";  
			Dropmental.SelectedIndex=0;
			Textdesmentalt1.Text="";
			Dropdocname.SelectedIndex=0;
			Dropstaff.SelectedIndex=0;
			Dropchdoc.SelectedIndex=0;
			Dropclass.SelectedIndex=0;
		}

		/// <summary>
		/// This method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// This method use to Get Next ID from studenthealth table.
		/// </summary>
		string i="";
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(Healthcheck)+1 from studenthealth",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						i=SqlDtr.GetValue(0).ToString ();
						if(i.Trim().Equals(""))
							i="1";
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// This method use to save information of student helth in to studenthealth table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sSysDate=System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				SqlConnection con111;
				string strInsert111;
				SqlCommand  cmdselect111;
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				fillID();
				strInsert111 = "Insert studenthealth(Healthcheck,Student_ID,Ears,Earsdesi,Eye,Eyesdesi,Noise,noisedesi,hands,handsdesi,Legs,legsdesi,Teeth,Teethdesi,Bp,Bpdesi,Heartbeat,Heartdesi,Skin,Skindesi,Mental,Mentaldesi,duration,checkedbydoc,checkedbyemp,bg,chdate )"+
					"values (@Healthcheck,@Student_ID,@Ears,@Earsdesi,@Eye,@Eyesdesi,@Noise,@noisedesi,@hands,@handsdesi,@Legs,@legsdesi,@Teeth,@Teethdesi,@Bp,@Bpdesi,@Heartbeat,@Heartdesi,@Skin,@Skindesi,@Mental,@Mentaldesi,@duration,@checkedbydoc,@checkedbyemp,@bg,@chdate)";
				cmdselect111=new SqlCommand (strInsert111,con111);
				string seqid = Dropstudentid.SelectedItem .Value.ToString ();
				cmdselect111.Parameters .Add ("@Healthcheck",i.Trim().ToString());
				cmdselect111.Parameters .Add ("@chdate",sSysDate);
				if(Dropstudentid.SelectedIndex==0)
					cmdselect111.Parameters .Add ("@Student_ID","");
				else
					cmdselect111.Parameters .Add ("@Student_ID", Dropstudentid.SelectedItem .Text.ToString ());
				if(Dropbg.SelectedIndex==0)
					cmdselect111.Parameters .Add ("@bg","");
				else
					cmdselect111.Parameters .Add ("@bg",Dropbg.SelectedItem .Value.ToString ());
				//09.02.09 if(Dropear.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Ears","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Ears",Dropear.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Earsdesi",Textdesear1.Text.Trim());
				//09.02.09if(Dropeye.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Eye","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Eye",Dropeye.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Eyesdesi",Textdeseye1.Text.Trim());
				//09.02.09if(Dropnoise.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Noise","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Noise", Dropnoise.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@noisedesi",Textdesnoise1.Text.Trim());
				//09.02.09if(Drophands.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@hands","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@hands",Drophands.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@handsdesi",Textdeshands1.Text.Trim());
				//09.02.09if(Droplegs.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Legs","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Legs",Droplegs.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@legsdesi",Textdeslegs1.Text.Trim());
				//09.02.09if(Dropteeth.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Teeth","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Teeth", Dropteeth.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Teethdesi",Textdesteeth1.Text.Trim());
				//09.02.09if(Dropbp.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@BP","");
				//09.02.09	else
				cmdselect111.Parameters .Add ("@BP",Dropbp.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Bpdesi",Textdesbp1.Text.Trim());
				//09.02.09if(Dropheart.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Heartbeat","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Heartbeat",Dropheart.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Heartdesi",Textdesheart1.Text.Trim());
				//09.02.09if(Dropmental.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Skin","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Skin", DropSkin.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Skindesi",txtSkindes1.Text.Trim());
				//09.02.09if(Dropmental.SelectedIndex==0)
				//09.02.09	cmdselect111.Parameters .Add ("@Mental","");
				//09.02.09else
				cmdselect111.Parameters .Add ("@Mental",Dropmental.SelectedItem .Value.ToString ());
				cmdselect111.Parameters .Add ("@Mentaldesi",Textdesmentalt1.Text.Trim());
				if(Dropdocname.SelectedIndex==0)
					cmdselect111.Parameters .Add ("@duration","");
				else
					cmdselect111.Parameters .Add ("@duration",Dropdocname.SelectedItem .Value.ToString ());     
				
				if(Dropstaff.SelectedIndex==0)
					cmdselect111.Parameters .Add ("@checkedbydoc","");
				else
					cmdselect111.Parameters .Add ("@checkedbydoc",Dropchdoc.SelectedItem .Value.ToString ());

				if(Dropchdoc.SelectedIndex==0)
					cmdselect111.Parameters .Add ("@checkedbyemp","");
				else
					cmdselect111.Parameters .Add ("@checkedbyemp",Dropstaff.SelectedItem .Value.ToString ());

				cmdselect111.ExecuteNonQuery();
				con111.Close ();
				//MessageBox.Show("Record Successfully Saved");
				MessageBox.Show("Health Status Successfully Saved");
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: btnSave_Click. Health details for Student ID " + Dropstudentid.SelectedItem .Value.ToString () + " by doctor " + Dropchdoc.SelectedItem .Value.ToString () + " saved. User: " + pass );
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Studenthealthcheck.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to Fetch Studentid from student_record table.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Clear(); 
			Dropstudentid.Enabled =true;
			Dropstudentid.Items.Clear();
			Dropstudentid.Items.Add("Select");
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
			{
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				cmdselect11 = new SqlCommand( "Select Distinct student_id from student_record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "'", con11 );
				dtrclass11 = cmdselect11.ExecuteReader();
				while (dtrclass11.Read()) 
				{
					Dropstudentid.Items.Add(dtrclass11.GetValue(0).ToString());
				}
				dtrclass11.Close();
				con11.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: studenthealthcheck.aspx.cs, Method: Dropclass_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void txtstudentname_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}

