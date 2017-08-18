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
using System.Data .SqlClient;
using System.IO;
using System.Drawing.Imaging ;
using RMG;
using System.Text;
using eschool.Classes ;
using System.Net.Sockets;
using System.Net;

# endregion
namespace eschool.Form
{
	/// <summary>
	/// Summary description for Student_Admission.
	/// </summary>
	public class Student_Admission : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.DropDownList dropStream;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtMiddleName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMiddleName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revLastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.TextBox TxtFathernm;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox TxtMothernm;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMotherName;
		protected System.Web.UI.WebControls.TextBox txtFMobileno;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFatherMob;
		protected System.Web.UI.WebControls.TextBox txtMMobileno;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMotherMob;
		protected System.Web.UI.WebControls.TextBox txtFoccp;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFatherOccp;
		protected System.Web.UI.WebControls.TextBox txtMoccp;
		protected System.Web.UI.WebControls.TextBox txtFannualin;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.TextBox txtMannualin;
		protected System.Web.UI.WebControls.TextBox txtFemail;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFEmail;
		protected System.Web.UI.WebControls.TextBox txtMemail;
		protected System.Web.UI.WebControls.DropDownList DropCategory;
		protected System.Web.UI.WebControls.DropDownList DropGender;
		protected System.Web.UI.WebControls.TextBox TxtEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegExpEid;
		protected System.Web.UI.WebControls.TextBox txtDoa;
		protected System.Web.UI.WebControls.TextBox TxtLAdd;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.TextBox TxtPincode;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.TextBox TxtMoNo;
		protected System.Web.UI.WebControls.RegularExpressionValidator revStuMobNo;
		protected System.Web.UI.WebControls.TextBox TextPerAdd;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPAddress;
		protected System.Web.UI.WebControls.DropDownList DropCity1;
		protected System.Web.UI.WebControls.DropDownList DropState1;
		protected System.Web.UI.WebControls.DropDownList DropCountry1;
		protected System.Web.UI.WebControls.TextBox TxtPerPincode;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.TextBox TxtPhNo;
		protected System.Web.UI.WebControls.TextBox txtReg_Id;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		SqlDataReader sdtr;
		static string Status="Pending";
		static string seq_student_id="";
		static string Student_ID="";
		protected System.Web.UI.WebControls.ValidationSummary vsRegistration;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList DropStudentID;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Label lblStudentID;
		protected System.Web.UI.WebControls.TextBox txtclass;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.CompareValidator camparevalidator2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText tempstudentcount;
		protected System.Web.UI.WebControls.TextBox txtRouteNo;
		protected System.Web.UI.WebControls.TextBox txtDob;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMotherOccp;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMEmail;
		protected System.Web.UI.WebControls.DropDownList DropScat;
		protected System.Web.UI.WebControls.DropDownList DropBG;
		protected System.Web.UI.WebControls.DropDownList Drophouse;
		protected System.Web.UI.HtmlControls.HtmlSelect DropRank;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.HtmlControls.HtmlInputFile SPhoto;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.DropDownList DropAdmissionID1;
		protected System.Web.UI.WebControls.TextBox DropAdmissionID;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPhoto;
		protected System.Web.UI.WebControls.DropDownList Dropcomputer;
		protected System.Web.UI.HtmlControls.HtmlInputText TxtLogst;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry1;
		protected System.Web.UI.WebControls.DropDownList DropRoueName;
		protected System.Web.UI.HtmlControls.HtmlInputText tempRouteNo;
		protected System.Web.UI.WebControls.DropDownList Droplogistic;
		protected System.Web.UI.HtmlControls.HtmlInputText TempCatRank;
		protected System.Web.UI.WebControls.CompareValidator valid1;
		protected System.Web.UI.HtmlControls.HtmlInputText Temprank;
		string pass;
				
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtReg_Id.Attributes.Add("readonly", "readonly");
            txtDob.Attributes.Add("readonly", "readonly");
            txtDoa.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog("Form : Student_Admission.aspx,Method: Page_Load. User_ID : "+ pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : Student_Admission.aspx,Method: Page_Load.   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}

			try
			{
    			scon.Open();
				//pass=(Session["password"].ToString());
				DropAdmissionID1.Visible=false;
				if(!Page.IsPostBack)
				{
					txtDob.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtDoa.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					GetNextStudentID();
					GetStudentRecordID();
					DropAdmissionID.Visible=false;

					#region Fill Local Country DropDown
					scom=new SqlCommand("Select distinct Country from Country order by Country asc",scon);
					sdtr=scom.ExecuteReader();
					DropCountry.Items.Add("---Select---");
					DropCountry1.Items.Add("---Select---");
					while(sdtr.Read())
					{
						DropCountry.Items.Add(sdtr.GetString(0));
						DropCountry1.Items.Add(sdtr.GetString(0));
					}
					sdtr.Close();
					scom=new SqlCommand("Select distinct state from Country order by state asc",scon);
					sdtr=scom.ExecuteReader();
					DropState.Items.Add ("---Select---");
					DropState1.Items.Add ("---Select---");
					while(sdtr.Read())
					{
						DropState.Items .Add (sdtr.GetString (0));
						DropState1.Items .Add (sdtr.GetString (0));
					}
					sdtr.Close ();
					scom=new SqlCommand("Select distinct City from Country order by City asc",scon);
					sdtr=scom.ExecuteReader();
					DropCity.Items.Add ("---Select---");
					DropCity1.Items.Add ("---Select---");
					while(sdtr.Read())
					{
						DropCity.Items.Add (sdtr.GetString (0));
						DropCity1.Items.Add (sdtr.GetString (0));
					}
					sdtr.Close ();
					#endregion
					
					# region SCategory Fill in Combo
				    scom=new SqlCommand("Select distinct catname from category order by Catname",scon);
					sdtr=scom.ExecuteReader();
					DropScat.Items.Clear();
					DropScat.Items.Add("Select");
					
					while(sdtr.Read())
					{
						DropScat.Items.Add(sdtr.GetValue(0).ToString());
						
					}
					sdtr.Close();
					# endregion

					# region Fill catrankText
					scom=new SqlCommand("select Catname,rank from category order by catname,rank",scon);
					sdtr=scom.ExecuteReader();
					while(sdtr.Read())
					{
						//DropScat.Items.Add(sdtr.GetValue(0).ToString());
						TempCatRank.Value+=sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString()+",";
					}
					sdtr.Close();
					# endregion


					#region Fill Text

					scom=new SqlCommand("Select Country,State,City from Country order by Country,State,City",scon);
					sdtr= scom.ExecuteReader();
					while(sdtr.Read())
					{
						txtName.Value=txtName.Value+sdtr.GetString(0).ToString().Trim()+ ":" +sdtr.GetString(1).ToString().Trim()+ ":" +sdtr.GetString(2).ToString().Trim()+ ",";
					}
					
					sdtr.Close();
					#endregion
					
					#region Fill Route
					scom=new SqlCommand("Select Route_name from Route order by Route_name",scon);
					sdtr= scom.ExecuteReader();
					DropRoueName.Items.Clear();
					DropRoueName.Items.Add("Select");
					while(sdtr.Read())
					{
						DropRoueName.Items.Add(sdtr.GetValue(0).ToString());
					}
					sdtr.Close();
					#endregion
    				
					#region Fill Txtroutno
					scom=new SqlCommand("select Route_km,Route_name from Route",scon);
					sdtr=scom.ExecuteReader();
					while(sdtr.Read())
					{
						tempRouteNo.Value+=sdtr.GetValue(0).ToString().Trim()+":"+sdtr.GetValue(1).ToString().Trim()+",";
					}
					
					sdtr.Close();
					#endregion
					fillhouse();
				}
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="4";
				string SubModule="3";
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
		}

		/// <summary>
		/// this function use to fill house in dropdown from house_master table.
		/// </summary>
		public void fillhouse()
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
				Drophouse.Items.Clear();
				Drophouse.Items.Add("Select");
				while(SqlDtr.Read ())
				{
					Drophouse.Items.Add(SqlDtr.GetValue(1).ToString());
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
			this.DropAdmissionID.TextChanged += new System.EventHandler(this.DropAdmissionID_TextChanged);
			this.DropAdmissionID1.SelectedIndexChanged += new System.EventHandler(this.DropAdmissionID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropStudentID.SelectedIndexChanged += new System.EventHandler(this.DropStudentID_SelectedIndexChanged);
			this.txtclass.TextChanged += new System.EventHandler(this.txtclass_TextChanged);
			this.DropScat.SelectedIndexChanged += new System.EventHandler(this.DropScat_SelectedIndexChanged);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.DropState.SelectedIndexChanged += new System.EventHandler(this.DropState_SelectedIndexChanged);
			this.DropCity1.SelectedIndexChanged += new System.EventHandler(this.DropCity1_SelectedIndexChanged);
			this.DropRoueName.SelectedIndexChanged += new System.EventHandler(this.DropRoueName_SelectedIndexChanged);
			this.txtRouteNo.TextChanged += new System.EventHandler(this.txtRouteNo_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.txtPhoto.ServerChange += new System.EventHandler(this.txtPhoto_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		/// <summary>
		/// this function use to convert date DDMMYYYY to MMDDYYYY formate.
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
		/// This method use to Clear controls.
		/// </summary>
		public void Clear()
		{	
			txtReg_Id.Text="";
			txtFirstName.Text="";
			TxtFathernm.Text="";
			TxtMothernm.Text="";
			txtFMobileno.Text="";
			txtMMobileno.Text="";
			txtFoccp.Text="";
			txtMoccp.Text="";
			txtPhoto.Value="";
			txtMemail.Text="";
			txtFannualin.Text="";
			txtMannualin.Text="";
			txtFemail.Text="";
			Dropclass.SelectedIndex=0;
			dropStream.SelectedIndex=0;
			txtDoa.Text="";
			txtDob.Text="";
			DropGender .SelectedIndex=0;
			DropState .SelectedIndex=0;
			TxtPincode.Text="";
			TextPerAdd.Text="";
			TxtPerPincode.Text="";
			TxtEmail.Text="";
			TxtPhNo.Text="";
			TxtMoNo.Text="";
			DropCategory .SelectedIndex=0;
			Droplogistic.SelectedIndex=0;
			TxtLAdd.Text="";
			DropCity.SelectedIndex=0;
			DropCity1.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			DropCountry1.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropState1.SelectedIndex=0;
			DropStudentID.SelectedIndex=0;
			txtclass.Text="";
			DropRoueName.SelectedIndex=0;
			txtRouteNo.Text="";
			Drophouse.SelectedIndex=0;
			//DropRank.SelectedIndex=0;
			DropRank.Items.Clear();
			DropRank.Items.Add("Select");
			DropScat.SelectedIndex=0;
			DropBG.SelectedIndex=0;
			Dropcomputer.SelectedIndex=0;
			tempstudentcount.Value="";
			//SPhoto.Value="";
			Image1.ImageUrl="";
			txtPhoto.Value="";
			
			
		}
		
		/// <summary>
		/// This method use to Reset form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit.Visible=true;
				lblStudentID.Visible=true;
				DropAdmissionID.Visible=false;
				DropStudentID.Visible=true;
				btnSave.Text="Save";
				txtReg_Id.Visible=false;
				Clear();
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Page_Load.  User: " + pass );
			}
			catch(Exception ex)
			{
                 CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// this method use to save all the information of the student in to student_record.and some information save in to Student_Admission table.
		/// and some in to ledger_master table to create the ledger of student. and also update student_Registration table. al the information save after check the record also exist in student_record table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int year=DateTime.Now.Year;
				int curr=year;
				int next=++year;
				string years=curr+":"+next;
				Status="OK";
				if(DropAdmissionID.Visible==true)
					Status="OK";
				if(Status=="OK")
				{
					if(txtclass.Text=="XI" ||txtclass.Text=="XII")
					{
						if(dropStream.SelectedIndex==0)
						{
							MessageBox.Show("Please Select Valid Stream");
							return;
						}
					}
					
					SchoolClass.SchoolMgs obj1=new SchoolClass.SchoolMgs();
					SqlDataReader SqlDtr;
					string sql;
					string sRegId = "";
					string sAddDate="";
					string sStudName="";
					string smessage="";
					int Reg_Id=0;
					
					DateTime dt=System.DateTime.Now;
					DateTime dt1=dt.Add(System.TimeSpan.FromDays(30));
					DateTime doa=Convert.ToDateTime(ToMMddYYYY(txtDoa.Text));
					DateTime dob=Convert.ToDateTime(ToMMddYYYY(txtDob.Text));
					System.TimeSpan minTime=doa.Subtract(dt);
					int iTotal=minTime.Days;
					System.TimeSpan maxTime=dt1.Subtract(doa);
					int iDayDiff=maxTime.Days;
					string phone = TxtPhNo.Text.ToString ();
					
					string[] ss=new string[2];
					if(lblStudentID.Visible==true)
					{
						sql="select Student_PHNo,Student_fname from student_record where student_fname='"+txtFirstName.Text +"' and student_phno='" + phone + "'";
						SqlDtr =obj1.GetRecordSet(sql);
						if(SqlDtr.HasRows)
						{
							MessageBox.Show ("Record Already Exists");
							Clear();
							return;						
						} 
						SqlDtr.Close ();
					}
					else
					{
						
					}
					System.TimeSpan diff=ToMMddYYYY(txtDoa.Text).Subtract(ToMMddYYYY( txtDob.Text));
					int idays=diff.Days;

					if(idays>=1460)
					{
						string seq_student_id;
						SchoolClass.regis obj=new SchoolClass.regis();
						if(lblStudentID.Visible==true)
						{
							GetNextStudentrecID();                                                     // function call to Get Next Student ID
							
							seq_student_id = Dropclass.SelectedItem.Text.Trim();
						}
						else
							
							seq_student_id = Dropclass.SelectedItem.Text.Trim();
						
						obj.seq_student_id=seq_student_id;
						if(txtFirstName.Text=="")
							obj.Student_FName="";
						else
							obj.Student_FName=txtFirstName.Text.Trim();
						

						if(btnEdit.Visible==true)
						{
							string Drop_Id=DropStudentID.SelectedItem.Value;                                // Add By Vikas Sharma Date 04.04.09
							Reg_Id=Convert.ToInt32(Drop_Id.Substring(0,Drop_Id.IndexOf(':')));
							obj.Reg_Id=Reg_Id;
						}
						else
						{
							obj.Reg_Id=Convert.ToInt32(txtReg_Id.Text.ToString());
						}

						
						if(TxtFathernm.Text=="")
							obj.Student_FatherName="";
						else
							obj.Student_FatherName=TxtFathernm.Text.Trim();  
						if(TxtMothernm.Text=="")
							obj.Student_MotherName="";
						else
							obj.Student_MotherName=TxtMothernm.Text.Trim();
						if(txtFMobileno.Text=="")
							obj.Student_FatherMobileno="";
						else
							obj.Student_FatherMobileno =txtFMobileno.Text.Trim();

						obj.Year=years;
						if(txtMMobileno.Text=="")
							obj.Student_MotherMobileno="";
						else
							obj.Student_MotherMobileno=txtMMobileno.Text.Trim(); 
						if(txtFoccp.Text=="")
							obj.Student_FatherOccp="";
						else
							obj.Student_FatherOccp =txtFoccp .Text.Trim();
						if(txtMoccp.Text=="")
							obj.Student_MotherOccp="";
						else
							obj.Student_MotherOccp=txtMoccp.Text.Trim();
						if(txtFannualin.Text=="")
							obj.Student_FatherAnnualIncome=0.0F;
						else
							obj.Student_FatherAnnualIncome=float.Parse(txtFannualin.Text.Trim());
						if(txtMannualin.Text=="")
							obj.Student_MotherAnnualIncome=0.0F;
						else
							obj.Student_MotherAnnualIncome=float.Parse(txtMannualin.Text.Trim());
						if(txtFemail.Text=="")
							obj.Student_FatherEmailID="";
						else
							obj.Student_FatherEmailID =txtFemail.Text.Trim();
						if(txtMemail.Text=="")
							obj.Student_MotherEmailID="";
						else
							obj.Student_MotherEmailID =txtMemail.Text.Trim();
						if(txtclass.Text=="")
							obj.Student_Class="";
						else
							obj.Student_Class =txtclass.Text.ToString().Trim();
						
						obj.Student_Stream=dropStream.SelectedItem.Value.ToString().Trim();
						
						obj.Student_AdmissionDate=doa;
						obj.Student_Birthdate=dob;
						if(DropGender .SelectedIndex==0)
							obj.Student_Gender="";
						else
							obj.Student_Gender=DropGender.SelectedItem.Value.ToString().Trim();

						if(TextPerAdd.Text=="")
							obj.Student_PAddress="";
						else
							obj.Student_PAddress =TextPerAdd .Text.Trim();
							
						if(DropCity.SelectedIndex==0)
							obj.Student_PCity="";
						else
							obj.Student_PCity=DropCity.SelectedItem.Value.ToString().Trim();
						if(DropState.SelectedIndex==0)
							obj.Student_PState="";
						else
							obj.Student_PState=DropState.SelectedItem.Value.ToString().Trim();
							
						if(DropCountry.SelectedIndex==0)
							obj.Student_PCountry="";
						else
							obj.Student_PCountry=DropCountry.SelectedItem.Value.ToString().Trim();
						if(TxtPerPincode.Text=="")
							obj.Student_PPincode=0;
						else
							obj.Student_PPincode=Convert.ToInt32(TxtPerPincode.Text.Trim());
						
						if(TxtLAdd.Text=="")
							obj.Student_LAddress="";
						else
							obj.Student_LAddress =TxtLAdd .Text.Trim();
						if(DropCity1.SelectedIndex ==0 )
							obj.Student_LCity="";
						else
							obj.Student_LCity=DropCity1.SelectedItem.Value.ToString().Trim();
						if(DropState1.SelectedIndex ==0)
							obj.Student_LState="";
						else
							obj.Student_LState=DropState1.SelectedItem.Value.ToString().Trim();
						   
						if(DropCountry1.SelectedIndex ==0)
							obj.Student_LCountry="";
						else
							obj.Student_LCountry=DropCountry1.SelectedItem.Value.ToString().Trim();
						if(TxtPincode.Text=="")
							obj.Student_LPincode=0;
						else
							obj.Student_LPincode =Convert.ToInt32(TxtPincode .Text.Trim());
							
						if(TxtEmail.Text=="")
							obj.Student_EmailID="";
						else
							obj.Student_EmailID =TxtEmail.Text.Trim();
						if(TxtPhNo.Text=="")
							obj.Student_PHNo="";
						else
							obj.Student_PHNo=TxtPhNo .Text.Trim();
						if(TxtMoNo.Text=="")
							obj.Student_MONo="";
						else
							obj.Student_MONo=TxtMoNo.Text.Trim(); 
						if(DropCategory .SelectedIndex==0)
							obj.Student_Category="";
						else
							obj.Student_Category =DropCategory.SelectedItem.Value.Trim().ToString(); 
					
						obj.Admission_Status="";
						
						obj.Service_Hostal="No";       
						
						if(Droplogistic .SelectedIndex==0)
							
							obj.Service_Bus="No";
						else
							obj.Service_Bus =Droplogistic.SelectedItem.Value.Trim().ToString();
						if(Drophouse.SelectedItem.Text.Equals("Select"))
							obj.House="";
						else
							obj.House=Drophouse.SelectedItem.Text;
						if(DropScat.SelectedItem.Text.Equals("Select"))
							obj.sCategory="";
						else
							obj.sCategory=DropScat.SelectedItem.Text;
						
						if(Temprank.Value=="Select" || Temprank.Value=="")  //6.11.08
							obj.Rank="";									//6.11.08
						else												//6.11.08
							obj.Rank=Temprank.Value;						//6.11.08

						//6.11.08 if(DropRank.SelectedItem.Text.Equals("Select"))
						//6.11.08 obj.Rank="";
						//else
						//6.11.08 obj.Rank=DropRank.SelectedItem.Text;

						if(DropBG.SelectedItem.Text.Equals("Select"))
							obj.BG="";
						else
							obj.BG=DropBG.SelectedItem.Text;
						if(obj.Service_Bus=="No")                                       
						{                                                              
							obj.RouteName="";                                            
							obj.RouteNo="0";                                            
						}                                                               
						else                                                             
						{                                                                
							if(DropRoueName.SelectedItem.Text.Equals("Select"))         
								obj.RouteName="";                                       
							else                                                        
								obj.RouteName=DropRoueName.SelectedItem.Text;           
							if(txtRouteNo.Text.Equals(""))                               
								obj.RouteNo="";                                          
							else                                                         
								obj.RouteNo=txtRouteNo.Text;                             
						}                                                                
						if(SPhoto.Value=="")
							obj.studentphoto=txtPhoto.Value;
						else
							obj.studentphoto=SPhoto.Value;

						//11.02.09 if(Dropcomputer.SelectedIndex==0)
						//11.02.09	obj.Computer="";
						//11.02.09 else
							obj.Computer=Dropcomputer.SelectedItem.Text;

						if(lblStudentID.Visible==true)
						{
							obj.Student_ID=Student_ID;
							obj.Insertstudent();                                                  ///call function to insert the student Registration.
							sRegId = Dropclass.SelectedItem.Value.ToString() +"-"+Student_ID;
							sAddDate=txtDoa.Text;
							sStudName=txtFirstName.Text.Trim();
							string str="insert into student_admission(Student_id,class,section,stream) values('"+Student_ID+"','"+txtclass.Text.ToString().Trim()+"','"+Dropclass.SelectedItem.Text.Trim()+"','"+dropStream .SelectedItem.Value.ToString().Trim()+"')";
							scom=new SqlCommand(str,scon);
							scom.ExecuteNonQuery();
							smessage="Student Admited!" + " " +"your Admission ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
						}
						else
						{
							obj.Student_ID=DropAdmissionID.Text;
							obj.Updatestudent();
							DropAdmissionID.Visible=false;
							lblStudentID.Visible=true;
							btnEdit.Visible=true;
							DropStudentID.Visible=true;
							sRegId = DropAdmissionID.Text;
							sAddDate=txtDoa.Text;
							sStudName=txtFirstName.Text.Trim();
							string str="update student_admission set class='"+txtclass.Text.ToString().Trim()+"',section='"+Dropclass.SelectedItem.Text.Trim()+"',stream='"+dropStream .SelectedItem.Value.ToString().Trim()+"' where student_id='"+DropAdmissionID.Text+"'";
							scom=new SqlCommand(str,scon);
							scom.ExecuteNonQuery();
							smessage="Student Update!" + " " +"your Admission ID is- " + " " + sRegId + " " + "& Admission Date is- " + " " + sAddDate;
						}
						# region message 
						
						MessageBox.Show(smessage);
						CreateLogFiles.ErrorLog ("Form: StudentRegistration.aspx.cs, Method: btnSave_Click. New Student " + sStudName + " with ID " + sRegId + " saved. User: " + Session["password"].ToString() );
						
						# endregion
						
						Image1.ImageUrl="";
						Clear(); 
						GetNextStudentID();
						GetStudentRecordID();
						btnSave.Text="Save";
						txtReg_Id.Visible=false;
					}
					else
					{
						MessageBox.Show("Your age must be greater than or equal to 4 years");
					}
					
				}
				else
				{
					MessageBox.Show ("First take the photo of the student");
				}
				Status="Pending";
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: btnSave_Click.  User: " + pass );
			}
							
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method ues to fill the student id in to dropstudentid from Student_Registration table.
		/// </summary>
		public void GetStudentRecordID()
		{
			try
			{
				//17.10.08 scom=new SqlCommand("Select Student_ID,Student_FName from Student_Registration where Admission_Status='Cleared'",scon);
				scom=new SqlCommand("Select Student_ID,Student_FName from Student_Registration where Admission_Status='Cleared' order by student_id ",scon);
				sdtr=scom.ExecuteReader();
				DropStudentID.Items.Clear();
				DropStudentID.Items.Add("Select");
				while(sdtr.Read())
				{
					DropStudentID.Items.Add(sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString());
				}		
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Get next Student Id from student_record table.
		/// </summary>
		string counter="";
		public void GetNextStudentrecID()
		{
			try
			{
				scom=new SqlCommand("Select count(Student_ID)+1 from Student_record where Student_class='"+txtclass.Text.Trim()+"'",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					counter=sdtr.GetValue(0).ToString();
				}		
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Get next Student Id from student_record table.
		/// </summary>
		public void GetNextStudentID()
		{
			try
			{
				scom=new SqlCommand("Select max(Student_ID)+1 from Student_Record",scon);
				sdtr=scom.ExecuteReader();
				
				while(sdtr.Read())
				{
					
					Student_ID=sdtr.GetValue(0).ToString();
					if(Student_ID=="")
						
						Student_ID="1";
					
				}	
				lblStudentID.Text=Student_ID;
				sdtr.Close();
			}
	
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		/// <summary>
		/// This method not in use. 
		/// </summary>
		private void BtnPhoto_Click(object sender, System.EventArgs e)
		{
			/// Data buffer for incoming data.
			byte[] bytes = new byte[1024];
			Status ="OK";
			Socket sender1;
			/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				///Console.WriteLine("Testing WebCAMService...");
				///Console.WriteLine("Establishing connection with WebCAMService...");
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				sender1 = new Socket(AddressFamily.InterNetwork, 
				SocketType.Stream, ProtocolType.Tcp );
				///MessageBox.Show ("Object Created");

				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					///MessageBox.Show ("Connection established with WebCAMService @ {0}" + sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					byte[] msg = Encoding.ASCII.GetBytes(seq_student_id + ".<EOF>");
					///MessageBox.Show ("Byte array created");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					///MessageBox.Show ("Data send");
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					///MessageBox.Show ("\nWebCAMService Server Echo = {0}" + Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				}
				catch (ArgumentNullException ane) 
				{
					CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ane.Message + " User: " + pass );
				}
				catch (SocketException se)
				{
					/// No connection could be made because the target machine actively refused it
					CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + se.Message + " User: " + pass );
				} 
				catch (Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
				}
			} 
			catch (Exception ex1)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex1.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// This method not in use.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				scom=new SqlCommand("Select country, state from Country where city='" + DropCity.SelectedItem.Value.ToString () + "' order by state",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState1.Items.FindByValue(sdtr.GetValue(1).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry1.Items.FindByValue(sdtr.GetValue(0).ToString()))));
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				
				 CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void DropCity1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				scom=new SqlCommand("Select country, state from Country where city='" + DropCity1.SelectedItem.Value.ToString () + "' order by state",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					DropState1.SelectedIndex=(DropState1.Items.IndexOf((DropState1.Items.FindByValue(sdtr.GetValue(1).ToString()))));
					DropCountry1.SelectedIndex=(DropCountry1 .Items.IndexOf((DropCountry1.Items.FindByValue(sdtr.GetValue(0).ToString()))));
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				
			    	CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		/// <summary>
		/// This method use to fetch Registred student information from Student_Registration table. 
		/// </summary>
		private void DropStudentID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropStudentID.SelectedIndex==0)
			{
				Clear();
				return;
			}
			string str=DropStudentID.SelectedItem.Text.Trim();
			string[] SID=str.Split(new char[] {':'},str.Length);
			scom=new SqlCommand("Select * from Student_Registration where Student_ID="+SID[0]+"",scon);
			sdtr=scom.ExecuteReader();
			while(sdtr.Read())
			{
				txtclass.Text=sdtr["Student_Class"].ToString();
				dropStream.SelectedIndex=dropStream.Items.IndexOf(dropStream.Items.FindByValue(sdtr["Student_Stream"].ToString()));
				txtFirstName.Text=sdtr["Student_FName"].ToString();
				txtDob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Student_Birthdate"].ToString()));
				TxtFathernm.Text=sdtr["Student_FatherName"].ToString();
				TxtMothernm.Text=sdtr["Student_MotherName"].ToString();
				DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(sdtr["Student_Category"].ToString()));
				DropGender.SelectedIndex=DropGender.Items.IndexOf(DropGender.Items.FindByValue(sdtr["Student_Gender"].ToString().Trim()));
				txtDoa.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdtr["Student_AdmissionDate"].ToString()));
				TextPerAdd.Text=sdtr["Student_Address"].ToString();
				DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(sdtr["Student_City"].ToString()));
				DropState1.SelectedIndex=DropState1.Items.IndexOf(DropState1.Items.FindByValue(sdtr["Student_PState"].ToString()));
				DropCountry1.SelectedIndex=DropCountry1.Items.IndexOf(DropCountry1.Items.FindByValue(sdtr["Student_PCountry"].ToString()));
				TxtPhNo.Text=sdtr["Student_PHNo"].ToString();
			}
			sdtr.Close();
		}

		/// <summary>
		/// This method use to fetch those students information which is saved in student_record table. this use to update the information.
		/// </summary>
		private void DropAdmissionID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropAdmissionID.Text=="")
				{
					MessageBox.Show("Please Select The Student ID");
					return;
				}
    			scom=new SqlCommand("Select * from Student_record where Student_ID="+DropAdmissionID.Text+"",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					string ss=sdtr["Seq_Student_id"].ToString();
					Image1.ImageUrl=sdtr["studentphoto"].ToString();
					Dropclass.SelectedIndex=Dropclass.Items.IndexOf(Dropclass.Items.FindByValue(sdtr["Seq_Student_id"].ToString()));
					txtclass.Text=sdtr["Student_Class"].ToString();
					dropStream.SelectedIndex=dropStream.Items.IndexOf(dropStream.Items.FindByValue(sdtr["Student_Stream"].ToString()));
					txtFirstName.Text=sdtr["Student_FName"].ToString();
					txtDob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Student_Birthdate"].ToString()));
					TxtFathernm.Text=sdtr["Student_FatherName"].ToString();
					TxtMothernm.Text=sdtr["Student_MotherName"].ToString();
					txtFMobileno.Text=sdtr["Student_FatherMobileno"].ToString();
					txtMMobileno.Text=sdtr["Student_MotherMobileno"].ToString();
					txtFoccp.Text=sdtr["Student_FatherOccp"].ToString();
					txtMoccp.Text=sdtr["Student_MotherOccp"].ToString();
					txtFannualin.Text=sdtr["Student_FatherAnnualIncome"].ToString();
					txtMannualin.Text=sdtr["Student_MotherAnnualIncome"].ToString();
					txtFemail.Text=sdtr["Student_FatherEmailID"].ToString();
					txtMemail.Text=sdtr["Student_MotherEmailID"].ToString();
					DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(sdtr["Student_Category"].ToString()));
					DropGender.SelectedIndex=DropGender.Items.IndexOf(DropGender.Items.FindByValue(sdtr["Student_Gender"].ToString().Trim()));
					TxtEmail.Text=sdtr["Student_EmailID"].ToString();
					txtDoa.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdtr["Student_AdmissionDate"].ToString()));
					TxtLAdd.Text=sdtr["Student_LAdderss"].ToString();
					DropCity.SelectedIndex=DropCity.Items.IndexOf(DropCity.Items.FindByValue(sdtr["Student_PCity"].ToString()));
					DropState.SelectedIndex=DropState.Items.IndexOf(DropState.Items.FindByValue(sdtr["Student_PState"].ToString()));
					DropCountry.SelectedIndex=DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(sdtr["Student_PCountry"].ToString()));
					TxtPincode.Text=sdtr["Student_LPincode"].ToString();
					TxtMoNo.Text=sdtr["Student_MONo"].ToString();
					TextPerAdd.Text=sdtr["Student_PAddress"].ToString();
					DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(sdtr["Student_LCity"].ToString()));
					DropState1.SelectedIndex=DropState1.Items.IndexOf(DropState1.Items.FindByValue(sdtr["Student_LState"].ToString()));
					DropCountry1.SelectedIndex=DropCountry1.Items.IndexOf(DropCountry1.Items.FindByValue(sdtr["Student_LCountry"].ToString()));
					TxtPerPincode.Text=sdtr["Student_PPincode"].ToString();
					TxtPhNo.Text=sdtr["Student_PHNo"].ToString();
					Droplogistic.SelectedIndex=Droplogistic.Items.IndexOf(Droplogistic.Items.FindByValue(sdtr["Service_Bus"].ToString()));
					Drophouse.SelectedIndex=Drophouse.Items.IndexOf(Drophouse.Items.FindByValue(sdtr["house"].ToString()));
					DropScat.SelectedIndex=DropScat.Items.IndexOf(DropScat.Items.FindByValue(sdtr["scategory"].ToString()));
					DropRank.Items.Clear();
					DropRank.Items.Add(sdtr["rank"].ToString());
					DropBG.SelectedIndex=DropBG.Items.IndexOf(DropBG.Items.FindByValue(sdtr["bg"].ToString()));
					DropRoueName.SelectedIndex=DropRoueName.Items.IndexOf(DropRoueName.Items.FindByValue(sdtr["routename"].ToString()));
					Dropcomputer.SelectedIndex=Dropcomputer.Items.IndexOf(Dropcomputer.Items.FindByValue(sdtr["computer"].ToString()));
					txtRouteNo.Text=sdtr["routeno"].ToString();
				}
				sdtr.Close();
					CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Dropedit_SelectedIndexChanged. User: " + pass );
			}
			catch(Exception ex)
			{
				  CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: Dropedit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to make this page in edit condition.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			btnEdit.Visible=false;
			DropAdmissionID.Visible=true;
			lblStudentID.Visible=false;
			DropStudentID.Visible=false;
			txtReg_Id.Visible=true;
			DropAdmissionID.Text="";
			btnSave.Text="Update";
		}

		/// <summary>
		/// This method is not in use.
		/// </summary>
		private void Droplogistic_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(Droplogistic.SelectedItem.Text.Equals("Yes"))
				
				DropRoueName.Enabled=true;
			else
				
				DropRoueName.Enabled=false;
		}

		private void DropState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtclass_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void DropScat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				scom=new SqlCommand("Select rank from category where catname='"+DropScat.SelectedItem.Text+"'",scon);
				sdtr=scom.ExecuteReader();
				DropRank.Items.Clear();
				DropRank.Items.Add("Select");
				while(sdtr.Read())
				{
					DropRank.Items.Add(sdtr.GetValue(0).ToString());
				}		
				sdtr.Close();
			}
			catch(Exception ex)
			{
				
				  CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void DropRank_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DropRoueName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				
			}
			catch(Exception ex)
			{
				
				  CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
			}

		}

		private void txtRouteNo_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This method Fetch Data From student_record table When Student Id Write in textBox. to update the record.
		/// </summary>
		private void DropAdmissionID_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropAdmissionID.Text=="")
				{
					MessageBox.Show("Please Select The Student ID");
					return;
				}
    			scom=new SqlCommand("Select * from Student_record where Student_ID="+DropAdmissionID.Text+"",scon);
				sdtr=scom.ExecuteReader();
				if(sdtr.Read())
				{
					string ss=sdtr["Seq_Student_id"].ToString();
					Image1.ImageUrl=sdtr["studentphoto"].ToString();
					txtPhoto.Value=sdtr["studentphoto"].ToString();
					Dropclass.SelectedIndex=Dropclass.Items.IndexOf(Dropclass.Items.FindByValue(sdtr["Seq_Student_id"].ToString()));
					txtclass.Text=sdtr["Student_Class"].ToString();
					dropStream.SelectedIndex=dropStream.Items.IndexOf(dropStream.Items.FindByValue(sdtr["Student_Stream"].ToString()));
					txtFirstName.Text=sdtr["Student_FName"].ToString();
					txtDob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["Student_Birthdate"].ToString()));
					TxtFathernm.Text=sdtr["Student_FatherName"].ToString();
					TxtMothernm.Text=sdtr["Student_MotherName"].ToString();
					txtFMobileno.Text=sdtr["Student_FatherMobileno"].ToString();
					txtMMobileno.Text=sdtr["Student_MotherMobileno"].ToString();
					txtFoccp.Text=sdtr["Student_FatherOccp"].ToString();
					txtMoccp.Text=sdtr["Student_MotherOccp"].ToString();
					txtFannualin.Text=sdtr["Student_FatherAnnualIncome"].ToString();
					txtMannualin.Text=sdtr["Student_MotherAnnualIncome"].ToString();
					txtFemail.Text=sdtr["Student_FatherEmailID"].ToString();
					txtMemail.Text=sdtr["Student_MotherEmailID"].ToString();
					DropCategory.SelectedIndex=DropCategory.Items.IndexOf(DropCategory.Items.FindByValue(sdtr["Student_Category"].ToString()));
					DropGender.SelectedIndex=DropGender.Items.IndexOf(DropGender.Items.FindByValue(sdtr["Student_Gender"].ToString().Trim()));
					TxtEmail.Text=sdtr["Student_EmailID"].ToString();
					txtDoa.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdtr["Student_AdmissionDate"].ToString()));
					TxtLAdd.Text=sdtr["Student_LAdderss"].ToString();
					DropCity.SelectedIndex=DropCity.Items.IndexOf(DropCity.Items.FindByValue(sdtr["Student_PCity"].ToString()));
					DropState.SelectedIndex=DropState.Items.IndexOf(DropState.Items.FindByValue(sdtr["Student_PState"].ToString()));
					DropCountry.SelectedIndex=DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(sdtr["Student_PCountry"].ToString()));
					if(sdtr["Student_LPincode"].ToString()!="0")
					   TxtPincode.Text=sdtr["Student_LPincode"].ToString();
					else
						TxtPincode.Text="";
					TxtMoNo.Text=sdtr["Student_MONo"].ToString();
					TextPerAdd.Text=sdtr["Student_PAddress"].ToString();
					DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(sdtr["Student_LCity"].ToString()));
					DropState1.SelectedIndex=DropState1.Items.IndexOf(DropState1.Items.FindByValue(sdtr["Student_LState"].ToString()));
					DropCountry1.SelectedIndex=DropCountry1.Items.IndexOf(DropCountry1.Items.FindByValue(sdtr["Student_LCountry"].ToString()));
					if(sdtr["Student_PPincode"].ToString()!="0")
					   TxtPerPincode.Text=sdtr["Student_PPincode"].ToString();
					else
						TxtPerPincode.Text="";
					TxtPhNo.Text=sdtr["Student_PHNo"].ToString();
					Droplogistic.SelectedIndex=Droplogistic.Items.IndexOf(Droplogistic.Items.FindByValue(sdtr["Service_Bus"].ToString()));
					if(Droplogistic.SelectedItem.Text.Equals("Yes"))
						DropRoueName.SelectedIndex=DropRoueName.Items.IndexOf(DropRoueName.Items.FindByValue(sdtr["routename"].ToString()));
					else
						DropRoueName.SelectedIndex=DropRoueName.Items.IndexOf(DropRoueName.Items.FindByValue(sdtr["routename"].ToString()));
					txtRouteNo.Text=sdtr["routeno"].ToString();
					Drophouse.SelectedIndex=Drophouse.Items.IndexOf(Drophouse.Items.FindByValue(sdtr["house"].ToString()));
					DropScat.SelectedIndex=DropScat.Items.IndexOf(DropScat.Items.FindByValue(sdtr["scategory"].ToString()));
					Dropcomputer.SelectedIndex=Dropcomputer.Items.IndexOf(Dropcomputer.Items.FindByValue(sdtr["computer"].ToString().Trim()));
					//DropRank.Items.Clear();
					Temprank.Value=sdtr["rank"].ToString();
					DropRank.Items.Add(sdtr["rank"].ToString());
					DropRank.SelectedIndex=DropRank.Items.IndexOf(DropRank.Items.FindByValue(sdtr["rank"].ToString()));
					DropBG.SelectedIndex=DropBG.Items.IndexOf(DropBG.Items.FindByValue(sdtr["bg"].ToString()));
					txtReg_Id.Text=sdtr["Reg_Id"].ToString().Trim();
				}
				else
				{
					MessageBox.Show("Student ID Not Found");
					Clear();
					return;
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Student_Admission.aspx.cs, Method: BtnPhoto_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void txtPhoto_ServerChange(object sender, System.EventArgs e)
		{
		
		}
	}
}
