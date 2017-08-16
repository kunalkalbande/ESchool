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
using System.Text;
using RMG;
using eschool.Classes ;
# endregion

namespace eschool.Form
{
	/// <summary>
	/// Summary description for Attendance.
	/// </summary>
	public class Attendance : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropempid;
		protected System.Web.UI.WebControls.TextBox txtempnm;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.CompareValidator cvAttd;
		protected System.Web.UI.WebControls.ValidationSummary vsEmpAttendance;
		protected System.Web.UI.WebControls.CompareValidator cvEmpID;
		//protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnSave;
	     string pass;
		# region Page Load...
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			  {

//				if(Session["view"]!=null)
//				{
//					try
//					{
//						if(Session["password"].ToString().Length<=0&&(bool)Session["view"]==false)
//						{
//							Session.Abandon();
//							Session.RemoveAll();
//					 
//							Response.Redirect(@"./HolidayEntryForm.aspx",false);
//						}
//						else
//						{
//							Response.Buffer=false;
//							Response.CacheControl="no-cache";
//							Response.Expires=System.DateTime.Now.Minute-1;	
//							Session["view"]=false;
//						}
//					}
//					catch(Exception ex)
//					{
//						CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
//						Session.Abandon();
//						Response.Redirect(@".\HolidayEntryForm.aspx",false);
//					}
//				
//				}
//				else
//				{
//					Response.Buffer=false;
//					Response.CacheControl="no-cache";
//					Response.Expires=System.DateTime.Now.Minute-1;
//					Session["view"]=false;
//				}
				try
				{
					
					pass=(Session["password"].ToString());
				}
				catch(Exception ex)
				{
					Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
					CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
					return;
				}

				//string pass;
			   // pass=(Session["password"].ToString());

				# region Add StaffID into the DropDownBox.
				if(!Page.IsPostBack)
			     {					
				   SqlConnection con;
				   SqlCommand cmdselect;
				   SqlDataReader dtratt;
				   con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]); 
				   con.Open ();
				   cmdselect = new SqlCommand( "Select distinct Staff_ID  From Staff_Information order by Staff_ID", con );
				   dtratt = cmdselect.ExecuteReader();
					while(dtratt.Read())
					{
					   Dropempid.Items.Add(dtratt.GetValue(0).ToString());
					}

				   dtratt.Close();
				   con.Close ();
				 }

				# endregion
             }
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				}
			#region Check Privileges
			if(! IsPostBack)
			{
				
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
				string SubModule="2";
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
			}
			#endregion
		}
		# endregion

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
			this.Dropempid.SelectedIndexChanged += new System.EventHandler(this.Dropempid_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
//Method for filling the staff name into the textbox , of selected staffID from Dropdownbox.
		# region Dropempid_SelectedIndexChanged...
		private void Dropempid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtredit3;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				cmdselect3 = new SqlCommand( "Select Staff_Name From Staff_Information where Staff_ID=@Staff_ID", con3 );
				cmdselect3.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value  .ToString ());
				dtredit3 = cmdselect3.ExecuteReader();
             	while (dtredit3.Read()) 
				{
					txtempnm.Text  =dtredit3.GetString (0);
		        }
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: Dropempid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		# endregion

 
		# region Clear Function...Method for clearing the form.
		public void Clear()
		{		
			Dropempid.SelectedIndex=0;
			txtempnm.Text="";
			DropDownList1.SelectedIndex=0;
 
		}
		# endregion

		# region Reset Button...
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
		Clear();
		}
		# endregion
//Method for saving the attendance records.
		private void btnSave_Click(object sender, System.EventArgs e)
		{
				/* Name :- Mahesh & Bhalchand, Date :- 14/08/2006.
				 * Add System Date to Compare Attendance Date
				 * */
				string dt1=System.DateTime.Now.ToShortDateString();
				SqlConnection con1;
				//string strInsert1;
			    string st=Dropempid.SelectedItem.Text;
				SqlCommand cmdInsert1;
			try
			{
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				
				/* Name :- Mahesh & Bhalchand, Date :- 14/08/2006.
				 * To Check The Attendence If it is Already Exist Or Not. 
				 * * * * * Start* * * * * */
				
				/*string strcheck1="select * from Staff_Attandance where Attandance_Status!=0 and Staff_ID='"+st.ToString()+"'";
				SqlCommand cmdcheck1=new SqlCommand(strcheck1,con1);
				SqlDataReader dtr=cmdcheck1.ExecuteReader();
				
				string dd="";
				while(dtr.Read())
				{
					dd=(GenUtil.trimDate(dtr.GetValue(2).ToString()));
					if(dd.Equals(dt1))
					{
						MessageBox.Show("Attendance Already Saved");
						return;
					}
				}
				dtr.Close();
				con1.Close();*/
				/* * * * * * End * * * * */
				/* Name :- vikas sharma, Date :- 07/02/2008.
				 * To save The Attendence but if it is  Already Exist then update.
				/**********Start*************/
				string msg="";
				string strInsert1="";
                string strcheck1="select count(*) from Staff_Attandance where Staff_ID='"+st.ToString()+"' and Attendance_Date='"+dt1+"'";
				SqlCommand cmdcheck1=new SqlCommand(strcheck1,con1);
				SqlDataReader dtr=cmdcheck1.ExecuteReader();
				int icount=0;
				while(dtr.Read())
				{
                     icount=Convert.ToInt32(dtr.GetValue(0));
				}
                dtr.Close();
				if(icount>0)
				{
                     //strInsert1 ="update staff_attandance set Attandance_Status=@Attandance_Status where Staff_ID=@Staff_ID and Attendance_Date='"+dt1+"'";
					   strInsert1 ="update staff_attandance set Half_Day=@half_day, Attandance_Status=@Attandance_Status where Staff_ID=@Staff_ID and Attendance_Date='"+dt1+"'";
					msg="Updated";
				}
				else
				{
                    // strInsert1 = "Insert Staff_Attandance(Staff_ID,Attandance_Status,Attendance_Date)values (@Staff_ID,@Attandance_Status,@Attendance_Date)";
					   strInsert1 = "Insert Staff_Attandance(Staff_ID,Attandance_Status,Attendance_Date,Half_Day)values (@Staff_ID,@Attandance_Status,@Attendance_Date,@half_day)";
					msg="Saved";
				}
				/**********End*************/
				//con1.Open();
			
				//strInsert1 = "Insert Staff_Attandance(Staff_ID,Attandance_Status,Attendance_Date)values (@Staff_ID,@Attandance_Status,@Attendance_Date)"; comment by vikas sharma date on 07.02.08
				cmdInsert1=new SqlCommand (strInsert1,con1);
				
				if(Dropempid.SelectedIndex==0)
					cmdInsert1.Parameters .Add ("@Staff_ID","");
				else
					cmdInsert1.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem.Text.ToString());
				cmdInsert1.Parameters .Add ("@Attendance_Date",dt1.ToString());
				/*if(DropDownList1.SelectedItem.Value =="Yes")                comment by vikas sharma date on 31.01.08
					cmdInsert1.Parameters .Add ("@Attandance_Status","1");
				else
					cmdInsert1.Parameters .Add ("@Attandance_Status","0");*/
				if(DropDownList1.SelectedItem.Value.Trim()=="Yes")
				     {
					     cmdInsert1.Parameters .Add ("@Attandance_Status","1");
					     cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(3));
				     }
				else if(DropDownList1.SelectedItem.Value =="HoliDay")
				     {
					     cmdInsert1.Parameters .Add ("@Attandance_Status","1");
					     cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(0));
				     }
				else if(DropDownList1.SelectedItem.Value.Trim()=="No")
				     {
					     cmdInsert1.Parameters .Add ("@Attandance_Status","0");
					     cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(0));
				     }
				else if(DropDownList1.SelectedItem.Value.Trim()=="Ist Half")
				     {
					     cmdInsert1.Parameters .Add ("@Attandance_Status","0.5");
					     cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(1));
				     }
				else if(DropDownList1.SelectedItem.Value.Trim()=="IInd Half")
				{
					cmdInsert1.Parameters .Add ("@Attandance_Status","0.5");
					cmdInsert1.Parameters .Add ("@half_day",Convert.ToInt16(2));      
				}
				cmdInsert1.ExecuteNonQuery();
				MessageBox.Show("Attendance "+msg);
				con1.Close (); 
				CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: btnSave_Click. Attendance for the employee ID: " + Dropempid.SelectedItem.Text.ToString() + " is saved. User: " + pass );
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Attendance.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
       
		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
		         Response.Redirect("StaffAttendance.aspx");
		}
	}
}
