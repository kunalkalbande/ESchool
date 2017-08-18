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
using System.Data.SqlClient;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;
using eschool.Classes;
using RMG;

# endregion

namespace eschool.certificate
{
	/// <summary>
	/// Summary description for Tc.
	/// </summary>
	
	public class Stuck_Off : System.Web.UI.Page
	{
    	protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.ValidationSummary vsTC;
		protected System.Web.UI.WebControls.CompareValidator cvStudentid;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label tcid11;
		protected System.Web.UI.WebControls.Label tcid;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Button BtnDelete;
		protected System.Web.UI.WebControls.Button BtnEdit;
		protected System.Web.UI.WebControls.Button BtnEditSave;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.TextBox txtdob;
		protected System.Web.UI.WebControls.TextBox txtduefee;
		protected System.Web.UI.WebControls.TextBox txttcdt;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtadddt;
		protected System.Web.UI.WebControls.TextBox txtfaname;
		protected System.Web.UI.WebControls.Button btnprint;
		protected System.Web.UI.WebControls.Button btnreset;
		protected System.Web.UI.WebControls.CompareValidator compvalid1;
		static int a=0;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txttcdt.Attributes.Add("readonly", "readonly");


            try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog("Form : Stuck_Off.aspx,Method: Page_Load. User_ID : "+ Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : Stuck_Off.aspx,Method: Page_Load.   EXCEPTION " +ex.Message +"  User_ID : "+ Session["User_Name"].ToString());
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}

			try
			{
				//string pass;
				//pass=(Session["password"].ToString());
				if(!Page.IsPostBack)
				{
				    txttcdt.Text =DateTime .Now .Day +"/"+DateTime .Now.Month+"/"+DateTime .Now .Year ;  
					tcid.Visible=true;
					DropEdit.Visible=false;
					BtnEdit.Visible=true;
					BtnEditSave.Visible=false;
					btnSave.Visible=true;
					Dropstudentid.Visible=true;
					btnprint.Visible =true;
					BtnDelete.Visible=true;  
					NextTcid();
					Dropclass.Items .Clear (); 
					Dropclass.Items .Add ("---Select---");
					SqlConnection con11;
					SqlCommand  cmdselect11;
					SqlDataReader dtrclass11;
					con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con11.Open ();
					cmdselect11 = new SqlCommand( "Select class_name from class order by class_id", con11 );
					dtrclass11 = cmdselect11.ExecuteReader();
					while (dtrclass11.Read()) 
					{
						Dropclass.Items.Add(dtrclass11.GetValue(0).ToString());
					}
					dtrclass11.Close();
					con11.Close ();
				}
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			try
			{
				if(!IsPostBack)
				{				
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="4";
					string SubModule="5";
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
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Dropclass.SelectedIndexChanged += new System.EventHandler(this.Dropclass_SelectedIndexChanged);
			this.Dropstudentid.SelectedIndexChanged += new System.EventHandler(this.Dropstudentid_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			this.BtnEditSave.Click += new System.EventHandler(this.BtnEditSave_Click);
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This Method use to show StudentID from student_record by passing the seq_student_id.
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
				cmdselect3 = new SqlCommand( "Select Student_ID From Student_record where seq_student_id='"+seq_studentid+"'", con3 );
				dtredit3 = cmdselect3.ExecuteReader();
				while (dtredit3.Read()) 
				{
					student_id = dtredit3.GetValue(0).ToString();
				}
				return student_id;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: ShowStudentID. Exception: " + ex.Message + " User: " + pass );
				return("0");
			}
		}
		
		/// <summary>
		/// This method is used for filling student_id into the dropdownbox.
		/// </summary>
		public void fillid()
		{
			try
			{
				Dropstudentid.Items.Clear();
				Dropstudentid.Items.Add("---Select--");
				SqlConnection con11;
				SqlCommand  cmdselect11;
				SqlDataReader dtrclass11;
				
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				
				cmdselect11 = new SqlCommand( "Select Distinct Stuck_Off.tcid, student_record.Student_ID  From Student_Record,Stuck_Off where student_record.seq_student_id=Stuck_Off.student_id  order by seq_Student_ID", con11 );
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
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: fillid. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This Method use to Generate Next stuck off ID.
		/// </summary>
		public void NextTcid()
		{
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
				{
					con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con11.Open ();
					cmdselect11 = new SqlCommand( "Select  max (TcID)+1  From Stuck_Off  ", con11 );
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

		/// <summary>
		/// This Method use to fill all the information of those students which are take Tc. and al the informationsave in Hidden textbox. this type of work use to remove the flicring. also use to update the information.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{

				EmployeeClass obj=new EmployeeClass();
				SqlDataReader dtrdrive44;
              
				 
				if(Dropstudentid.SelectedIndex!=0)
				{
					 string student=Dropstudentid.SelectedItem.Text;
					string[] studentid=student.Split(new char[]{':'});

					//string str= "Select Student_FName,Student_FatherName,Student_AdmissionDate,Student_Birthdate,Student_Category,scategory  From Student_Record where Student_ID="+Dropstudentid.SelectedItem.Text+"";
					string str= "Select Student_FName,Student_FatherName,Student_AdmissionDate,Student_Birthdate,Student_Category,scategory  From Student_Record where Student_ID="+studentid[1].ToString()+"";
					dtrdrive44 = obj.GetRecordSet(str);
					while (dtrdrive44.Read()) 
					{
						txtstudentname.Text=dtrdrive44.GetValue(0).ToString();
						txtfaname.Text=dtrdrive44.GetValue(1).ToString();
						txtadddt.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive44["Student_AdmissionDate"].ToString()));
						txtdob.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive44["Student_Birthdate"].ToString()));
					}
					dtrdrive44.Close();
					//str="select Fees_type,remarks from recuringreceipt where Student_id='"+Dropstudentid.SelectedItem.Text+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+Dropstudentid.SelectedItem.Text+"')";
					str="select Fees_type,remarks from recuringreceipt where Student_id='"+studentid[1].ToString()+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+studentid[1].ToString()+"')";
					dtrdrive44 = obj.GetRecordSet(str);
					while (dtrdrive44.Read())
					{
						
						string s=dtrdrive44.GetValue(0).ToString().Trim();
						string[] feesdue=s.Split(new char[] {':'},s.Length);
						txtduefee.Text=feesdue[1]; 
					}
					dtrdrive44.Close();
				}
				else
				{
					MessageBox.Show ("First select the Student ID");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: Dropstudentid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method take one string with date and time and split the time from the string and return only date.
		/// </summary>
		public string trimDate(string str)
		{
			if(str.IndexOf(" ") > -1)
			{
				str = str.Substring(0,str.IndexOf(" "));
 
			}
			return str;
		}

		/// <summary>
		/// This method get date as string and return date as MMDDYYYY format.
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
		/// Clear Function...for clearing the information from the controls.
		/// </summary>
		public void clear()
		{
			txttcdt.Text =DateTime .Now .Day +"/"+DateTime .Now.Month+"/"+DateTime .Now .Year ;  
		    txtstudentname.Text ="";
		    Dropstudentid.SelectedIndex =0;
			Dropclass.SelectedIndex =0;
			txtfaname.Text ="";
		    txtadddt.Text ="";
			txtdob.Text ="";
			txtduefee.Text ="";
		}

		/// <summary>
		/// This Method use to Reset The form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			clear();
		}

		/// <summary>
		/// This Method use to save the TC Record in tc1 table. brfore Saving the information check tc also Take or not.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(Dropclass.SelectedIndex!=0)
			{
				try
				{
					DateTime d1 = Convert.ToDateTime(ToMMddYYYY(txttcdt.Text.Trim().ToString()));
					DateTime d2 = Convert.ToDateTime(ToMMddYYYY(txtadddt.Text.Trim().ToString()));
					if(DateTime.Compare(d1,d2)>0)
					{
						string student=Dropstudentid.SelectedItem.Text;
						string[] studentid=student.Split(new char[]{':'});

						SqlConnection con111;
						SqlCommand cmdInsert111;
						SqlDataReader sdr;
						string strInsert111;
						con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con111.Open ();
						//cmdInsert111=new SqlCommand ("select * from Stuck_Off where student_id='" + Dropstudentid.SelectedItem .Value.ToString () + "'",con111);
						cmdInsert111=new SqlCommand ("select * from Stuck_Off where student_id='" + studentid[1].ToString () + "'",con111);
						sdr=cmdInsert111.ExecuteReader ();
						if(sdr.HasRows )
						{
							while(sdr.Read())
							{
								MessageBox.Show ("Student Already Exist");
								clear ();
								return;
							}
						}
						sdr.Close ();
						if(Dropstudentid.SelectedIndex ==0)
						{
							MessageBox.Show ("First select the student ID");
							return;
						}
						strInsert111 = "Insert Stuck_Off(tcid,student_id,tcdate,Fee_paid)values (@tcid,@student_id,@tcdate,@Fee_paid)";
						cmdInsert111=new SqlCommand (strInsert111,con111);
						cmdInsert111.Parameters .Add ("@tcid",tcid.Text.Trim().ToString());
						if(Dropstudentid .SelectedIndex==0)
							cmdInsert111.Parameters .Add ("@student_id","");
						else
							//cmdInsert111.Parameters .Add ("@student_id", Dropstudentid.SelectedItem .Value.ToString ());
							cmdInsert111.Parameters .Add ("@student_id", studentid[1].ToString());
							studentid[1].ToString ();
						if(txtduefee.Text=="")
							cmdInsert111.Parameters .Add ("@Fee_paid","");
						else
							cmdInsert111.Parameters .Add ("@Fee_paid", txtduefee.Text.ToString ());
						if(txttcdt.Text.Equals(""))
							cmdInsert111.Parameters .Add("@tcdate","");
						else
							cmdInsert111.Parameters .Add("@tcdate",GenUtil.str2MMDDYYYY(txttcdt.Text .ToString().Trim ()));
						cmdInsert111.Parameters .Add ("@Tcdt", GenUtil.str2MMDDYYYY(txttcdt.Text));
						cmdInsert111.ExecuteNonQuery();
						con111.Close ();
						MessageBox.Show("Student Successfully Saved");
						CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: btnSave_Click. TC for student ID: " + Dropstudentid.SelectedItem .Value.ToString () + " saved. User: " + pass );
						clear();
						NextTcid();
					}
					else
					{
						MessageBox.Show("TC date must be greater than admission date");
					}
					tcid.Visible=true;
					DropEdit.Visible=false;
					BtnEdit.Visible=true;
					BtnEditSave.Visible=false;
					Dropclass.SelectedIndex=0;
					btnSave.Visible=true;
					a=0;
					clear();
					CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: btnSave_Click.  User: " + pass );
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
				}
			}
			else
			{
				MessageBox.Show("Please Select the class" );
			}
		 }

		/// <summary>
		/// This Method use to fetch the TC ID from tc1 table.also mentain the visibility of controls.
		/// </summary>
		private void BtnEdit_Click(object sender, System.EventArgs e)
		{
			a=0;
			tcid.Visible=true;
			DropEdit.Visible=true;
			BtnEdit.Visible=false;
			BtnEditSave.Visible=true;
			BtnDelete.Visible=true;
			btnSave.Visible=false;
			tcid.Visible=false;
			SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dtrclass11;
			try
			{
				DropEdit.Items.Clear();
				DropEdit.Items.Add("---Select---");
				con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con11.Open ();
				cmdselect11 = new SqlCommand( "Select  tcid from Stuck_Off ", con11 );
				dtrclass11 = cmdselect11.ExecuteReader();
				while (dtrclass11.Read()) 
				{
					DropEdit.Items.Add(dtrclass11.GetValue(0).ToString());
				}
				dtrclass11.Close();
				con11.Close ();
				CreateLogFiles.ErrorLog ("Form : Stuck_Off.aspx.cs, Method: BtnEdit_Click. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form : Stuck_Off.aspx.cs, Method: BtnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method is used to get the record of the selected TCID and show into Specific Controls.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    SqlConnection con11;
			SqlCommand  cmdselect11;
			SqlDataReader dr;
			try
			{
				if(DropEdit.SelectedIndex >0)
				{
					con11=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con11.Open ();
					string str="Select t.student_id,sr.student_fname,sr.student_fathername,sr.student_birthdate,sr.student_class,sr.student_admissiondate,t.Fee_paid,t.tcdate From Stuck_Off t,  student_record sr where tcid='"+DropEdit.SelectedItem.Text.ToString()+"' and sr.Student_ID=t.Student_ID ";
					cmdselect11 = new SqlCommand(  str, con11 );
					dr = cmdselect11.ExecuteReader();
					string aa="";
					while (dr.Read()) 
					{
						aa=dr.GetValue (0).ToString ();
						Dropclass.SelectedIndex=Dropclass.Items.IndexOf (Dropclass.Items.FindByValue(dr["student_class"].ToString()));
						Dropstudentid.Items.Add(dr["student_id"].ToString());
						txtstudentname.Text=dr["student_fname"].ToString();
						txtfaname.Text=dr["Student_FatherName"].ToString();
						txtduefee.Text=dr["Fee_paid"].ToString();
						txtdob.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr["Student_Birthdate"].ToString()));
						txtadddt.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr["Student_AdmissionDate"].ToString()));
						txttcdt.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr["tcdate"].ToString()));
					}
					dr.Close();
                	//str="Select  Student_ID from Student_Record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "'";
					str="Select  Student_ID,student_fname from Student_Record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "'";
					cmdselect11 = new SqlCommand(  str, con11 );
					dr = cmdselect11.ExecuteReader(); 
					Dropstudentid.Items .Clear ();
					Dropstudentid.Items .Add ("---Select---"); 
					while(dr.Read ())
					{
						Dropstudentid.Items .Add (dr.GetValue (1).ToString ()+":"+dr.GetValue (0).ToString ());
					}
					dr.Close ();
					str="Select  Student_ID,student_fname from Student_Record where Student_ID='" + aa + "'";
					cmdselect11 = new SqlCommand(  str, con11 );
					dr = cmdselect11.ExecuteReader(); 
					while(dr.Read ())
                        Dropstudentid.SelectedIndex=Dropstudentid.Items.IndexOf(Dropstudentid.Items.FindByValue(dr.GetValue (1).ToString ()+":"+dr.GetValue (0).ToString ()));
					dr.Close ();
					con11.Close ();
					
					CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: DropEdit_SelectedIndexChanged. User: " + pass );
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: DropEdit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// This method is used for update records.
		/// </summary>
		private void BtnEditSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				DateTime d1;
				if(a==1)
				{
					d1 = Convert.ToDateTime(ToMMddYYYY( txttcdt.Text.Trim().ToString()) );
				}
				else
				{
					 d1 = Convert.ToDateTime(ToMMddYYYY(txttcdt.Text.Trim().ToString()));
				}
				
				DateTime d2 = Convert.ToDateTime(ToMMddYYYY(txtadddt.Text.Trim().ToString()));
				if(DateTime.Compare(d1,d2)>0)
				{
					string student=Dropstudentid.SelectedItem.Text;
					string[] studentid=student.Split(new char[]{':'});

					SqlConnection con111;
					SqlCommand cmdInsert111;
					string strInsert111;
					con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con111.Open ();

					strInsert111="update Stuck_Off set student_id=@Student_ID ,tcdate=@tcdate,Fee_paid=@Fee_paid where tcid =@tcid";
					
					cmdInsert111=new SqlCommand (strInsert111,con111);
					
					if(txtduefee.Text=="")
						cmdInsert111.Parameters .Add ("@Fee_paid","");
					else
						cmdInsert111.Parameters .Add ("@Fee_paid", txtduefee.Text.ToString ());
					if(Dropstudentid .SelectedIndex==0)
						cmdInsert111.Parameters .Add ("@student_id","");
					else
						//cmdInsert111.Parameters .Add ("@student_id", Dropstudentid.SelectedItem .Value.ToString ());
						cmdInsert111.Parameters .Add ("@student_id", studentid[1].ToString ());
					if(txttcdt.Text.Equals(""))
						cmdInsert111.Parameters .Add("@tcdate","");
					else
						cmdInsert111.Parameters .Add("@tcdate",GenUtil.str2MMDDYYYY(txttcdt.Text .ToString().Trim ()));
					
					cmdInsert111.Parameters .Add ("@tcid", DropEdit.SelectedItem.Text.ToString());
					cmdInsert111.ExecuteNonQuery();
					con111.Close ();
					MessageBox.Show("Student Record Successfully Updated");
					CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: BtnEditSave_Click. TC for student ID: " + Dropstudentid.SelectedItem .Value.ToString () + " saved. User: " + pass );
					clear();
					Dropclass.SelectedIndex=0;
					a=0;
				}
				else
				{
					MessageBox.Show("TC date must be greater than admission date");
					return;
				}
				tcid.Visible=true;
				DropEdit.Visible=false;
				BtnEdit.Visible=true;
				BtnEditSave.Visible=false;
		        btnSave.Visible=true;
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: BtnEditSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// This method is used for deleting the Records from tc1 table.
		/// </summary>
		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con111;
			SqlCommand cmdInsert111;
			string strInsert111;
			try
			{
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				strInsert111 = " Delete from Stuck_Off where Tcid=@tcid";
				cmdInsert111=new SqlCommand (strInsert111,con111);
				cmdInsert111.Parameters .Add ("@tcid",DropEdit.SelectedItem.Text.ToString());
				cmdInsert111.ExecuteNonQuery();
				MessageBox.Show("Student Record of Stuck_Off "+ DropEdit.SelectedItem.Text.ToString()+" is Deleted");
				tcid.Visible=true;
				DropEdit.Visible=false;
				BtnEdit.Visible=true;
				BtnEditSave.Visible=false;
				btnSave.Visible=true;
				Dropclass.SelectedIndex=0;
				clear();
				NextTcid();
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: BtnDelete_Click. TC Record Deleted User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Stuck_Off.aspx.cs, Method: BtnDelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
			
		/// <summary>
		/// This method is used for checking whether tcdate changed.
		/// </summary>
		private void txttcdt_TextChanged(object sender, System.EventArgs e)
		{
			a=1;
		}

		/// <summary>
		/// This method use to save the information of selected tc ID in Hidden textbox.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
				SqlDataReader SqlDtr;
				//string str="select Student_ID from Student_record where Student_class='"+Dropclass.SelectedItem.Text+"'";
				string str="select Student_ID,student_fname from Student_record where Student_class='"+Dropclass.SelectedItem.Text+"'";
				SqlDtr=obj.GetRecordSet(str);
				Dropstudentid.Items.Clear();
				Dropstudentid.Items.Add("Select");
				while(SqlDtr.Read())
				{
					Dropstudentid.Items.Add(SqlDtr["Student_fname"].ToString()+":"+SqlDtr["Student_ID"].ToString());
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Tc.aspx.cs, Method: DropEdit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method is not used.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
				SocketType.Stream, ProtocolType.Tcp );
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
					sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TCReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  Button1_ServerClick,  Employee Payslip information  Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  Button1_ServerClick,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  Button1_ServerClick,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  Button1_ServerClick,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This Method use to create the TC.txt file in eSchoolPrintService. all the value fetch from Stuck off table.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\Stuck_OffReport.txt";
				StreamWriter sw = new StreamWriter(path);
				string str="select t.student_id s1,s.rank rank,s.student_fname s2,s.Student_FatherName s3,t.pramotion s8,s.Student_AdmissionDate s6,t.nationality s4,s.student_BirthDate s7,s.student_category s5,t.result s9,t.twd twd,t.tpd tpd,t.ncc ncc,t.curract  curract,t.appdate appdate,t.tcdate tcdate,t.reason reason,s.student_class,t.fee_concession,t.remark,t.gconduct  from tc1 t,student_record s where t.student_id=s.student_id and t.student_id='"+Dropstudentid.SelectedItem.Text+"'";
				SqlDtr=obj.GetRecordSet(str);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)11);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)65);
				sw.Write((char)11);				
				sw.Write((char)27);
				sw.Write((char)87);
				sw.Write((char)1);
				string info="{0,35:S} {1,-50:S}";
				string info1="{0,43:S} {1,-50:S}";
				string info2="{0,30:S} {1,-50:S}";
				string info3="{0,21:S} {1,-15:S} {2,8:S} {3,-20:S}";
				string info4="{0,50:S} {1,-20:S}";
				string info5="{0,15:S} {1,-20:S}";
				string info6="{0,1:S} {1,-20:S}";
				if(SqlDtr.Read())
				{
					for(int i=0;i<8;i++)
					{
						sw.WriteLine();
					}
					sw.WriteLine(info4,"",SqlDtr["s1"].ToString());
					sw.Write((char)27);
					sw.Write((char)65);
					sw.Write((char)13);		
					sw.WriteLine(info,"",SqlDtr["s2"].ToString());
					sw.Write((char)27);
					sw.Write((char)65);
					sw.Write((char)11);		
					sw.WriteLine(info,"",SqlDtr["rank"].ToString()+" "+SqlDtr["s3"].ToString());
					sw.WriteLine(info,"",SqlDtr["s4"].ToString());
					if(SqlDtr["s5"].ToString()=="SC" || SqlDtr["s5"].ToString()=="ST")
						sw.WriteLine(info,"","Yes");
					else
						sw.WriteLine(info,"","No");
					sw.WriteLine(info,"",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["s6"].ToString()))+" - "+SqlDtr["student_class"].ToString());
					sw.WriteLine(info1,"",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["s7"].ToString())));
					sw.Write((char)27);
					sw.Write((char)65);
					sw.Write((char)10);	
					sw.WriteLine(info2,"",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["s7"].ToString())));
					sw.WriteLine(info3,"",SqlDtr["student_class"].ToString(),"",getClassName(SqlDtr["student_class"].ToString()));
					sw.Write((char)27);
					sw.Write((char)65);
					sw.WriteLine((char)10);				
					sw.WriteLine(info,"",SqlDtr["s9"].ToString());
					sw.WriteLine(info,"","No");
					sw.Write(info5,"","English");
					sw.WriteLine(info6,"","Hindi");
					sw.Write((char)27);
					sw.Write((char)65);
					sw.WriteLine((char)7);		
					sw.Write(info5,"","Math");
					sw.WriteLine(info6,"","Chemistry");
					sw.Write((char)27);
					sw.Write((char)65);
					sw.WriteLine((char)7);		
					sw.Write(info5,"","Physics");
					sw.WriteLine();
					sw.Write((char)27);
					sw.Write((char)65);
					sw.WriteLine((char)12);		
					sw.WriteLine();
					sw.WriteLine(info3,"",SqlDtr["s8"].ToString(),"",getClassName(SqlDtr["s8"].ToString()));
					sw.Write((char)27);
					sw.Write((char)65);
					sw.WriteLine((char)11);		
					sw.WriteLine(info,"","No Dues");
					sw.WriteLine(info,"",SqlDtr["Fee_Concession"].ToString());
					sw.WriteLine(info,"",SqlDtr["twd"].ToString());
					sw.WriteLine(info,"",SqlDtr["tpd"].ToString());
					sw.WriteLine(info,"",SqlDtr["ncc"].ToString());
					sw.Write((char)27);
					sw.Write((char)65);
					sw.Write((char)10);
					sw.WriteLine(info,"",SqlDtr["curract"].ToString());
					sw.WriteLine(info,"",SqlDtr["gconduct"].ToString());
					sw.WriteLine(info,"",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["appdate"].ToString())));
					sw.WriteLine(info,"",GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["tcdate"].ToString())));
					sw.WriteLine(info,"",SqlDtr["reason"].ToString());
					sw.WriteLine(info,"",SqlDtr["remark"].ToString());
				}
				sw.Write((char)27);
				sw.Write((char)87);
				sw.Write((char)0);
				sw.Close();
				SqlDtr.Close();
				Print();
			}
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :TC.aspx,Method  btnprint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This Method use to Get Class Name.
		/// </summary>
		public string getClassName(string cs)
		{
			string Name="";
			if(cs.Equals("I"))
				Name="First";
			else if(cs.Equals("II"))
				Name="Second";
			else if(cs.Equals("III"))
				Name="Third";
			else if(cs.Equals("IV"))
				Name="Fourth";
			else if(cs.Equals("V"))
				Name="Fifth";
			else if(cs.Equals("VI"))
				Name="Six";
			else if(cs.Equals("VII"))
				Name="Seven";
			else if(cs.Equals("VIII"))
				Name="Eight";
			else if(cs.Equals("IX"))
				Name="Nine";
			else if(cs.Equals("X"))
				Name="Tenth";
			else if(cs.Equals("XI"))
				Name="Eleven";
			else if(cs.Equals("XII"))
				Name="Twelve";
			return Name;
		}

		/// <summary>
		/// This Method use to Reset controls in this form.
		/// </summary>
		private void btnreset_Click(object sender, System.EventArgs e)
		{
			BtnEdit.Visible=true;
			tcid.Visible=true;
			btnSave.Visible=true;
			BtnEditSave.Visible=false;
			DropEdit.Visible=false;
			clear ();
		}
	}
}
