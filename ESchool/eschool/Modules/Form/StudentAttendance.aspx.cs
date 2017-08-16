/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
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
	/// Summary description for StudentAttendance.
	/// </summary>
	public class StudentAttendance : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgrdStudentAttendance;
		protected System.Web.UI.WebControls.DropDownList dropSection;
		protected System.Web.UI.WebControls.DropDownList dropStream;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		protected System.Web.UI.WebControls.Panel panatted;
		protected System.Web.UI.WebControls.ValidationSummary vsStuMarks;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.ValidationSummary Summary;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			
			try
			{
				if(!Page .IsPostBack)
				{
					try
					{
                      	SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
 						SqlDataReader sdtr;
						SqlCommand scom2=new SqlCommand("Select class_Name from class order by class_id ",scon); 
						sdtr=scom2.ExecuteReader();
						while(sdtr.Read())
						{
							Dropclass.Items.Add(sdtr.GetValue(0).ToString().Trim());
						}
						sdtr.Close();
						scon.Close();
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
					}
				}
				if(! IsPostBack)
				{
					#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="4";
				string SubModule="7";
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
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.dropSection.SelectedIndexChanged += new System.EventHandler(this.dropClass_SelectedIndexChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		 
		private void dgrdStudentAttendance_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DropteacherName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
 			
		}

		/// <summary>
		/// this method Show the student name class wise.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			
			shown();
		}

		/// <summary>
		/// this method Show the student name class wise.
		/// </summary>
		public void shown()
		{
			try
			{
				InventoryClass obj1=new InventoryClass();
				SqlDataReader sdtr1=null;
				string att;
				int i=0;
				String dt = DateTime.Now.ToString();
				int pos = dt.IndexOf(" ");
				String strDate;
				strDate = dt.Substring(0, pos);            
				if (strDate.StartsWith("0"))
				{
					strDate = strDate.Substring(1);
				}
				//11.12.08 string str="Select distinct RollNo,SName from Student_Roll where ClassID='"+Dropclass .SelectedItem.Text.ToString()+"'  and st_Section ='"+ dropSection .SelectedItem.Text+"' and Stream ='" + dropStream .SelectedItem .Text+"'"; 
				string str="Select distinct RollNo,SName,studentid from Student_Roll where ClassID='"+Dropclass .SelectedItem.Text.ToString()+"'  and st_Section ='"+ dropSection .SelectedItem.Text+"' and Stream ='" + dropStream .SelectedItem .Text+"'"; 
				SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
			 	SqlCommand scom=new SqlCommand(str,scon);
				SqlDataReader sdtr=scom.ExecuteReader();
				if(sdtr.HasRows)
				{

					//*********11.12.08**********
					/*while(sdtr.Read())
					{

						att="No";
						string str1="Select * from Attendance_Sheet where student_id="+sdtr.GetValue(2).ToString().Trim()+" and today_date='"+GenUtil.trimDate(dt.ToString())+"'"; 
						sdtr1=obj1.GetRecordSet(str1);
						if(sdtr1.Read())
						{
							att=sdtr1.GetValue(1).ToString();		
						}
						sdtr1.Close();


						if(!(att.Equals("No")))
						{
							CheckBox chk=(CheckBox)dgrdStudentAttendance.Items[i].Cells[2].Controls[1];
							chk.Checked=false;
							//CheckBox chk=(CheckBox)dgrdStudentAttendance.Items[i].Cells[2].Controls[1];
						}
						i++;
					}*/
					//***************************

					

					dgrdStudentAttendance.DataSource=sdtr;
					dgrdStudentAttendance.DataBind();
					sdtr.Close();	
					panatted.Visible=true;
				}
				else
				{
					dgrdStudentAttendance.DataSource=sdtr;
					dgrdStudentAttendance.DataBind();
					sdtr.Close();
					panatted.Visible=false;
					MessageBox.Show("Data Not Available");
					return;
				}
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: btnshow_Click, User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: btnshow_Click, Exception: " + ex.Message + " User: " + pass );
			}
		}
		private void dropClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		 /// <summary>
		 /// This method use to clear the value of controls.
		 /// </summary>
		public void clear()
		{
			dropSection.SelectedIndex=0;
			dropStream.SelectedIndex=0;
			Dropclass.SelectedIndex=0;
			//dgrdStudentAttendance.Visible=false;
		}

		/// <summary>
		/// this method use to concrate the first name with last name.
		/// </summary>
		public string  studentName(string fname,string lname)
		{
			if(lname.Trim().Equals("")||lname==null)
				return fname;
			else
				return fname+" "+lname;
		}
		
		/// <summary>
		/// this method use to save attendance of student in student_attendance table. 
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			bool flag=false;
			string date=DateTime.Now.ToShortDateString();
			try
			{
				int no= dgrdStudentAttendance.Items.Count;
				int x=0;
				for(int i=0;i<no;i++)
				{
					CheckBox chk=(CheckBox)dgrdStudentAttendance.Items[i].Cells[2].Controls[1];
					if(chk.Checked==true)
					{
						x++;
					}
				}
				if(x==0)
				{
					MessageBox.Show("Please Select Student For Attedance");
					return;
				}
				for(int i=0; i<no;i++)
				{
					
					 flag=false;
					CheckBox chk=(CheckBox)dgrdStudentAttendance.Items[i].Cells[2].Controls[1];
					
					string rollno=dgrdStudentAttendance.Items[i].Cells[0].Text.ToString();
					string iid="";

					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr;
					string str="Select StudentId from student_Roll where classId='"+Dropclass.SelectedItem.Text+"' and st_section='"+dropSection.SelectedItem.Text+"' and stream='"+dropStream.SelectedItem.Text+"' and RollNo='"+rollno+"'";
					SqlDtr=obj.GetRecordSet(str);
					
						while(SqlDtr.Read())
						{
							flag=true;
							iid=SqlDtr.GetValue(0).ToString();
						}
						SqlDtr.Close();
						if(flag==false)
						{
							MessageBox.Show("This Roll No is not present in Attandance Sheet");//add by vishnu
						}
						SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
						SqlCommand scom=new SqlCommand ("select * from Attendance_Sheet where Student_Id='" + iid + "' and Today_Date='" + date + "'",scon);
						
						SqlDataReader sdr=scom.ExecuteReader ();
						if(sdr.HasRows )
						{
							MessageBox.Show ("Attendance already entered!!!");
							dgrdStudentAttendance.Controls.Clear (); 
							clear();
							panatted.Visible=false;
							return;
						}
						
						sdr.Close ();
						string sql="insert Attendance_Sheet(Student_ID,Today_Date,Attendance_Status)values(@Student_ID,@Today_Date,@Attendance_Status)";
						
						scom=new SqlCommand(sql,scon);
						scom.Parameters .Add("@Student_ID",iid);
						scom.Parameters .Add("@Today_Date",date);
						if(chk.Checked==true)
							scom.Parameters .Add ("@Attendance_Status","Yes");
						else
							scom.Parameters .Add ("@Attendance_Status","No");
						scom.ExecuteNonQuery();
					
				}
				clear();
				panatted.Visible=false;
				MessageBox.Show("Attendance Successfully Saved for Date:"+date);
		    	CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: btnSave_Click, Student Attendance save for Date :"+date+", User: " + pass );
 			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentAttendance.aspx.cs, Method: save, Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method is fetch the value from student_roll and attendance_sheet table and check the status of every student.
		/// </summary>
		public void ItemDataBound(object sender,DataGridItemEventArgs e)
		{
			try
			{
				if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem ) || (e.Item.ItemType == ListItemType.SelectedItem))
				{
					string SID = e.Item.Cells[0].Text;
					string att ="No";
					String dt = DateTime.Now.ToString();
					string str1 ="select Attendance_Status from student_roll,attendance_sheet where studentid=student_id and RollNo='"+SID+"' and today_date='"+GenUtil.trimDate(dt.ToString())+"'"; 
					InventoryClass obj = new InventoryClass();
					SqlDataReader sdtr1 = obj.GetRecordSet(str1);
					if(sdtr1.Read())
					{
						att=sdtr1.GetValue(0).ToString();		
					}
					sdtr1.Close();
					if(att!="No")
					{
						CheckBox chk=(CheckBox)e.Item.Cells[2].Controls[1];
						chk.Checked=true;
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:CustomerLedger.aspx,Method:ItemTotal()  EXCEPTION  "+ex.Message+".  User_ID:"+ pass );
			}
		}
	}
}
