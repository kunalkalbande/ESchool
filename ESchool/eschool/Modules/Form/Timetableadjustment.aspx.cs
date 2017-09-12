  
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
     # region  Directives...
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
using System.IO;
//using System.Text;  
using System.Net;
using System.Net.Sockets;

# endregion

namespace eschool.Form
{
	/// <summary>
	/// Summary description for Timetableadjustment.
	/// </summary>
	public class Timetableadjustment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.ValidationSummary svTmeTableAdjust;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDoa;
		protected System.Web.UI.WebControls.TextBox txtadjustdate;
		protected System.Web.UI.WebControls.DropDownList Dropempid;
		protected System.Web.UI.WebControls.DropDownList Dropday;
		protected System.Web.UI.WebControls.Panel PanStaff;
		protected System.Web.UI.WebControls.DropDownList Drop1;
		protected System.Web.UI.WebControls.DropDownList Drop2;
		protected System.Web.UI.WebControls.DropDownList Drop3;
		protected System.Web.UI.WebControls.DropDownList Drop4;
		protected System.Web.UI.WebControls.DropDownList Drop5;
		protected System.Web.UI.WebControls.DropDownList Drop6;
		protected System.Web.UI.WebControls.DropDownList Drop7;
		protected System.Web.UI.WebControls.DropDownList Drop8;
		protected System.Web.UI.WebControls.TextBox txtdesig;
		protected System.Web.UI.WebControls.DropDownList Dropdesig;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.CompareValidator validationIdName;
		protected System.Web.UI.WebControls.CompareValidator compvaliDesgi;
		protected System.Web.UI.WebControls.CompareValidator comvaliday;
		string[] period={"","","","","","","",""};
		protected System.Web.UI.WebControls.Label Label4;
	    string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtadjustdate.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Time Tableadjustment.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Time Tableadjustment.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				txtadjustdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year; 
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader dtratt=null,sdtr=null;
				string str="",str1="",str2="",str3="",str4="",str5="",str6="",str7="";
				if(!Page.IsPostBack)
				{
                    string str12="select distinct staff_name from staff_type where teaching=1";
                    sdtr=obj.GetRecordSet(str12);
					Dropdesig.Items.Clear();
					Dropdesig.Items.Add("Select");
					Dropdesig.Items.Add("All");
					while(sdtr.Read())
					{
                       Dropdesig.Items.Add(sdtr.GetValue(0).ToString().Trim());
					}
					sdtr.Close();
					string strstr="Select distinct s.staff_id, s.staff_name from staff_information s,staff_attandance a where s.staff_id=a.staff_id and a.attandance_status=0 and a.attendance_date='"+GenUtil.str2MMDDYYYY(txtadjustdate.Text)+"'";
					dtratt=obj.GetRecordSet(strstr);
					Dropempid.Items.Clear();
					Dropempid.Items.Add("Select");
					while(dtratt.Read())
					{
						Dropempid.Items.Add(dtratt.GetValue(0).ToString()+":"+dtratt.GetValue(1).ToString());
					}
					dtratt.Close();
				
					if(Dropday.SelectedIndex!=0)
					{
						if(Dropday.SelectedItem.Text.Equals("Monday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and mon8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="mon"+j;
							}
											
						}
						else if(Dropday.SelectedItem.Text.Equals("Tuesday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="tue"+j;
							}
						}
						else if(Dropday.SelectedItem.Text.Equals("Wednesday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and tue8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="wed"+j;
							}
						}
						else if(Dropday.SelectedItem.Text.Equals("Thrusday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and thu8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="thu"+j;
							}
						}
						else if(Dropday.SelectedItem.Text.Equals("Friday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and fri8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="fri"+j;
							}
						}
						else if(Dropday.SelectedItem.Text.Equals("Satarday"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+txtdesig.Text+"' and sat8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="sat"+j;
							}
						}
						dtratt=obj.GetRecordSet(str);
						Drop1.Items.Clear();
						Drop2.Items.Clear();
						Drop3.Items.Clear();
						Drop4.Items.Clear();
						Drop5.Items.Clear();
						Drop6.Items.Clear();
						Drop7.Items.Clear();
						Drop8.Items.Clear();
						Drop1.Items.Add("Select");
						Drop2.Items.Add("Select");
						Drop3.Items.Add("Select");
						Drop4.Items.Add("Select");
						Drop5.Items.Add("Select");
						Drop6.Items.Add("Select");
						Drop7.Items.Add("Select");
						Drop8.Items.Add("Select");
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop1.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str1);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop2.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str2);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop3.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str3);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop4.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str4);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop5.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str5);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop6.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str6);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop7.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						dtratt=obj.GetRecordSet(str7);
						while(dtratt.Read())
						{
							string id=dtratt.GetValue(1).ToString();
							Drop8.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
						}
						dtratt.Close();
						
					}
				}
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Page_Load, User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false); 
			     return;
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="5";
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
				#endregion
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
			this.Dropempid.SelectedIndexChanged += new System.EventHandler(this.Dropempid_SelectedIndexChanged);
			this.Dropdesig.SelectedIndexChanged += new System.EventHandler(this.Dropdesig_SelectedIndexChanged);
			this.Dropday.SelectedIndexChanged += new System.EventHandler(this.Dropday_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method Fill The teacher's information into the textbox from staff_information table.
		/// </summary>
		private void Dropempid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con33;
			SqlCommand cmdselect33;
			SqlDataReader dtredit33;
			try
			{
				con33=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con33.Open ();
				cmdselect33 = new SqlCommand( "Select  staff_type From staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"'", con33);// added by v
				dtredit33=cmdselect33.ExecuteReader();
             	while (dtredit33.Read()) 
				{  
					txtdesig.Text=dtredit33["Staff_type"].ToString ();
				}
				dtredit33.Close ();
				con33.Close ();
				//Clear();

			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Dropempid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropadjust_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con222;
			SqlCommand cmdselect222;
			SqlDataReader dtredit222;
			try
			{
				con222=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con222.Open ();
				return;
				con222.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: Dropadjust_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Clear page.
		/// </summary>
		public void Clear()
		{
			txtdesig.Text="";
			Drop1.SelectedIndex=0;
			Drop2.SelectedIndex=0;
			Drop3.SelectedIndex=0;
			Drop4.SelectedIndex=0;
			Drop5.SelectedIndex=0;
     		Drop6.SelectedIndex=0;
			Drop7.SelectedIndex=0;
			Drop8.SelectedIndex=0;
			Dropday.SelectedIndex=0;
			Dropdesig.SelectedIndex=0;
			Dropempid.SelectedIndex=0;
		}

		/// <summary>
		/// This method use to Reset form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// this method use to Get Next ID from Timetableadjustment table.
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
				cmd=new SqlCommand("select max(adjustid)+1 from timetableadjust",con);
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
		/// this method use to Count and Check Period are Free or Not
		/// </summary>
		public int countID(string id)
		{
			int count=0,gcount=0;
			try
			{
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[0]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
    			
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[1]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[2]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[3]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[4]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[5]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[6]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}
				gcount+=count;
				SqlDtr.Close();
				
				strSql="select count(*) from teachertimetable where employee_id="+id+" and "+ period[7]+"=''";
				SqlDtr=obj1.GetRecordSet(strSql);
				if(SqlDtr.Read())
				{
					count=Int32.Parse(SqlDtr.GetValue(0).ToString());
				}	
				SqlDtr.Close();
				gcount+=count;
				return (8-gcount);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: countID. Exception: " + ex.Message + " User: " + pass );
				return 0;
			}
			
		}

    	/// <summary>
		/// this Method use to save the timetable adjustment Records.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
            StringBuilder errorMessage = new StringBuilder();
            if (Dropempid.SelectedIndex == 0)
            {
                errorMessage.Append("- Please Select Teacher name");
                errorMessage.Append("\n");
            }
            if (Dropdesig.SelectedIndex == 0)
            {
                errorMessage.Append("- Please Select Designation");
                errorMessage.Append("\n");
            }            
            if (Dropday.SelectedIndex == 0)
            {
                errorMessage.Append("- Please Select Day");
                errorMessage.Append("\n");
            }            
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString());
                return;
            }

            SqlConnection conin;
			string strInsertin="",strDelete="";
			SqlCommand cmdInsertin=null,cmdDelete=null;
			string p1="";
			string p2="";
			string p3="";
			string p4="";
			string p5="";
			string p6="";
			string p7="";
			string p8="";
			try
			{
				conin=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				conin.Open ();
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string str="";
				if(Dropday.SelectedIndex!=0)
				{
					if(Dropday.SelectedItem.Text=="Monday")
						str="select mon1,mon2,mon3,mon4,mon5,mon6,mon7,mon8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Tuesday")
						str="select tue1,tue2,tue3,tue4,tue5,tue6,tue7,tue8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Wednesday")
						str="select wed1,wed2,wed3,wed4,wed5,wed6,wed7,wed8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Thrusday")
						str="select thu1,thu2,thu3,thu4,thu5,thu6,thu7,thu8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Friday")
						str="select fri1,fri2,fri3,fri4,fri5,fri6,fri7,fri8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					else if(Dropday.SelectedItem.Text=="Saturday")
						str="select sat1,sat2,sat3,sat4,sat5,sat6,sat7,sat8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						if(Dropday.SelectedItem.Text=="Monday")
						{
							p1=SqlDtr["mon1"].ToString();
							p2=SqlDtr["mon2"].ToString();
							p3=SqlDtr["mon3"].ToString();
							p4=SqlDtr["mon4"].ToString();	
							p5=SqlDtr["mon5"].ToString();
							p6=SqlDtr["mon6"].ToString();
							p7=SqlDtr["mon7"].ToString();
							p8=SqlDtr["mon8"].ToString();
						}
						else if(Dropday.SelectedItem.Text=="Tuesday")	
						{
							p1=SqlDtr["tue1"].ToString();
							p2=SqlDtr["tue2"].ToString();
							p3=SqlDtr["tue3"].ToString();
							p4=SqlDtr["tue4"].ToString();	
							p5=SqlDtr["tue5"].ToString();
							p6=SqlDtr["tue6"].ToString();
							p7=SqlDtr["tue7"].ToString();
							p8=SqlDtr["tue8"].ToString();
						}
						else if(Dropday.SelectedItem.Text=="Wednesday")	
						{
							p1=SqlDtr["Wed1"].ToString();
							p2=SqlDtr["Wed2"].ToString();
							p3=SqlDtr["Wed3"].ToString();
							p4=SqlDtr["Wed4"].ToString();	
							p5=SqlDtr["Wed5"].ToString();
							p6=SqlDtr["Wed6"].ToString();
							p7=SqlDtr["Wed7"].ToString();
							p8=SqlDtr["Wed8"].ToString();
						}
						else if(Dropday.SelectedItem.Text=="Thrusday")								
						{
							p1=SqlDtr["thu1"].ToString();
							p2=SqlDtr["thu2"].ToString();
							p3=SqlDtr["thu3"].ToString();
							p4=SqlDtr["thu4"].ToString();	
							p5=SqlDtr["thu5"].ToString();
							p6=SqlDtr["thu6"].ToString();
							p7=SqlDtr["thu7"].ToString();
							p8=SqlDtr["thu8"].ToString();
						}
						else if(Dropday.SelectedItem.Text=="Friday")								
						{
							p1=SqlDtr["fri1"].ToString();
							p2=SqlDtr["fri2"].ToString();
							p3=SqlDtr["fri3"].ToString();
							p4=SqlDtr["fri4"].ToString();	
							p5=SqlDtr["fri5"].ToString();
							p6=SqlDtr["fri6"].ToString();
							p7=SqlDtr["fri7"].ToString();
							p8=SqlDtr["fri8"].ToString();
						}
						else if(Dropday.SelectedItem.Text=="Saturday")								
						{
							p1=SqlDtr["sat1"].ToString();
							p2=SqlDtr["sat2"].ToString();
							p3=SqlDtr["sat3"].ToString();
							p4=SqlDtr["sat4"].ToString();	
							p5=SqlDtr["sat5"].ToString();
							p6=SqlDtr["sat6"].ToString();
							p7=SqlDtr["sat7"].ToString();
							p8=SqlDtr["sat8"].ToString();
						}
					}
				}
				if(!p1.Equals(""))
				{
					if(Drop1.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p1);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}
				if(!p2.Equals(""))
				{
					if(Drop2.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p2);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}
				if(!p3.Equals(""))
				{
					if(Drop3.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p3);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}				
				if(!p4.Equals(""))
				{
					if(Drop4.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p4);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}
				if(!p5.Equals(""))
				{
					if(Drop5.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p5);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();			
					}
				}
				if(!p6.Equals(""))
				{
					if(Drop6.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p6);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();

					}
				}
				if(!p7.Equals(""))
				{
					if(Drop7.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p7);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}
				if(!p8.Equals(""))
				{
					if(Drop8.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p8);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
					}
				}
				if(!p1.Equals(""))
				{
					if(Drop1.SelectedIndex!=0)
					{
						fillID();
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p1);   //++
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop1.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdInsertin.Parameters .Add ("@Class_name",p1);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}
				if(!p2.Equals(""))
				{
					if(Drop2.SelectedIndex!=0)
					{
						fillID();
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p2);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop2.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdInsertin.Parameters .Add ("@Class_name",p2);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}
				if(!p3.Equals(""))
				{
					if(Drop3.SelectedIndex!=0)
					{
						fillID();
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p3); //++
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop3.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdInsertin.Parameters .Add ("@Class_name",p3);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}				
				if(!p4.Equals(""))
				{
					if(Drop4.SelectedIndex!=0)
					{
						fillID();

						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p4); //++
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop4.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdInsertin.Parameters .Add ("@Class_name",p4);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}
				if(!p5.Equals(""))
				{
					if(Drop5.SelectedIndex!=0)
					{
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p5);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						fillID();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop5.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdInsertin.Parameters .Add ("@Class_name",p5);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}
				if(!p6.Equals(""))
				{
					if(Drop6.SelectedIndex!=0)
					{
						fillID();
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p6);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop6.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						
						cmdInsertin.Parameters .Add ("@Class_name",p6);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}

				if(!p7.Equals(""))
				{
					if(Drop7.SelectedIndex!=0)
					{
						fillID();              
						
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p7);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop7.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						
						cmdInsertin.Parameters .Add ("@Class_name",p7);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
					}
				}
				
				if(!p8.Equals(""))
				{
					if(Drop8.SelectedIndex!=0)
					{
						fillID();          
						strDelete="Delete from timetableadjust where staff_id=@staff_id1 and class_name=@class_name1 and ttime=@Ttime1";
						cmdDelete=new SqlCommand (strDelete,conin);
						cmdDelete.Parameters .Add("@staff_id1",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						cmdDelete.Parameters .Add ("@Class_name1",p8);
						cmdDelete.Parameters .Add ("@Ttime1",GenUtil.ToMMddYYYY(txtadjustdate.Text));
						cmdDelete.ExecuteNonQuery();
						strInsertin = "Insert timetableadjust(Adjustid,staff_id,adjustteacherid,class_name,ttime,subject)values (@adjustid,@staff_id,@adjustteacherid1,@class_name,@ttime,@subject)";
						cmdInsertin=new SqlCommand (strInsertin,conin);
						cmdInsertin.Parameters .Add ("@adjustteacherid1",Drop8.SelectedItem .Value.ToString().Trim());
						cmdInsertin.Parameters .Add ("@adjustid",i.Trim().ToString());
						if(Dropempid.SelectedIndex ==0)
						{
							MessageBox.Show("Emoloyee Id did not defined");
							return;
						}
						else
							cmdInsertin.Parameters .Add ("@Staff_ID",Dropempid.SelectedItem .Value.ToString().Trim().Substring(0,Dropempid.SelectedItem .Value.ToString().Trim().IndexOf(":")));
						
						cmdInsertin.Parameters .Add ("@Class_name",p8);
						cmdInsertin.Parameters .Add ("@Ttime",GenUtil.ToMMddYYYY(txtadjustdate.Text));						
						cmdInsertin.Parameters .Add ("@subject","");
						cmdInsertin.ExecuteNonQuery();
						
					}
				}
				conin.Close ();
				MessageBox.Show("TimeTable Adjustment Successfully Saved");
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: btnSave_Click. Teacher time table adjusted for the teacher: " + Dropempid.SelectedItem.Text.ToString () + " is saved. User: " + pass );
				Clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		

		/// <summary>
		/// this Method use to create connection between remot device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustment.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method :  Print(),  TimeTableAdjustment Printed , Userid :  "+ pass   );							 
			    } 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to create report of adjusted timetable.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string p1="";
			string p2="";
			string p3="";
			string p4="";
			string p5="";
			string p6="";
			string p7="";
			string p8="";
			try
				{
					btnSave_Click(sender,e);
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					string info = "";
					string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\TimeTableAdjustment.txt";
					StreamWriter sw = new StreamWriter(path); 
					try
					{
						InventoryClass obj=new InventoryClass();
						SqlDataReader SqlDtr=null;
						string str="";
						if(Dropday.SelectedIndex!=0)
						{
							if(Dropday.SelectedItem.Text=="Monday")
								str="select mon1,mon2,mon3,mon4,mon5,mon6,mon7,mon8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							else if(Dropday.SelectedItem.Text=="Tuesday")
								str="select tue1,tue2,tue3,tue4,tue5,tue6,tue7,tue8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							else if(Dropday.SelectedItem.Text=="Wednesday")
								str="select wed1,wed2,wed3,wed4,wed5,wed6,wed7,wed8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							else if(Dropday.SelectedItem.Text=="Thruesday")
								str="select thu1,thu2,thu3,thu4,thu5,thu6,thu7,thu8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							else if(Dropday.SelectedItem.Text=="Friday")
								str="select fri1,fri2,fri3,fri4,fri5,fri6,fri7,fri8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							else if(Dropday.SelectedItem.Text=="Saturday")
								str="select sat1,sat2,sat3,sat4,sat5,sat6,sat7,sat8 from teachertimetable where employee_id=(select staff_id from staff_information where staff_name='"+Dropempid.SelectedItem.Text.Trim().Substring((Dropempid.SelectedItem.Text.Trim().IndexOf(":")+1),(Dropempid.SelectedItem.Text.Trim().Length-Dropempid.SelectedItem.Text.Trim().IndexOf(":")-1))+"')";
							SqlDtr=obj.GetRecordSet(str);
							if(SqlDtr.Read())
							{
								if(Dropday.SelectedItem.Text=="Monday")
								{
									p1=SqlDtr["mon1"].ToString();
									p2=SqlDtr["mon2"].ToString();
									p3=SqlDtr["mon3"].ToString();
									p4=SqlDtr["mon4"].ToString();	
									p5=SqlDtr["mon5"].ToString();
									p6=SqlDtr["mon6"].ToString();
									p7=SqlDtr["mon7"].ToString();
									p8=SqlDtr["mon8"].ToString();
								}
								else if(Dropday.SelectedItem.Text=="Tuesday")	
								{
									p1=SqlDtr["tue1"].ToString();
									p2=SqlDtr["tue2"].ToString();
									p3=SqlDtr["tue3"].ToString();
									p4=SqlDtr["tue4"].ToString();	
									p5=SqlDtr["tue5"].ToString();
									p6=SqlDtr["tue6"].ToString();
									p7=SqlDtr["tue7"].ToString();
									p8=SqlDtr["tue8"].ToString();
								}
								else if(Dropday.SelectedItem.Text=="Wednesday")	
								{
									p1=SqlDtr["Wed1"].ToString();
									p2=SqlDtr["Wed2"].ToString();
									p3=SqlDtr["Wed3"].ToString();
									p4=SqlDtr["Wed4"].ToString();	
									p5=SqlDtr["Wed5"].ToString();
									p6=SqlDtr["Wed6"].ToString();
									p7=SqlDtr["Wed7"].ToString();
									p8=SqlDtr["Wed8"].ToString();
								}
								else if(Dropday.SelectedItem.Text=="Thrusday")								
								{
									p1=SqlDtr["thu1"].ToString();
									p2=SqlDtr["thu2"].ToString();
									p3=SqlDtr["thu3"].ToString();
									p4=SqlDtr["thu4"].ToString();	
									p5=SqlDtr["thu5"].ToString();
									p6=SqlDtr["thu6"].ToString();
									p7=SqlDtr["thu7"].ToString();
									p8=SqlDtr["thu8"].ToString();
								}
								else if(Dropday.SelectedItem.Text=="Friday")								
								{
									p1=SqlDtr["fri1"].ToString();
									p2=SqlDtr["fri2"].ToString();
									p3=SqlDtr["fri3"].ToString();
									p4=SqlDtr["fri4"].ToString();	
									p5=SqlDtr["fri5"].ToString();
									p6=SqlDtr["fri6"].ToString();
									p7=SqlDtr["fri7"].ToString();
									p8=SqlDtr["fri8"].ToString();
								}
								else if(Dropday.SelectedItem.Text=="Saturday")								
								{
									p1=SqlDtr["sat1"].ToString();
									p2=SqlDtr["sat2"].ToString();
									p3=SqlDtr["sat3"].ToString();
									p4=SqlDtr["sat4"].ToString();	
									p5=SqlDtr["sat5"].ToString();
									p6=SqlDtr["sat6"].ToString();
									p7=SqlDtr["sat7"].ToString();
									p8=SqlDtr["sat8"].ToString();
								}
							}
						}
					}
					catch(Exception ex)
    				{
						CreateLogFiles.ErrorLog ("Form: Timetableadjustment.aspx.cs, Method: HTMLPart. Exception: " + ex.Message + " User: " + pass );
					}
					sw.Write((char)27);
					sw.Write((char)67);
					sw.Write((char)0);
					sw.Write((char)12);
					sw.Write((char)27);
					sw.Write((char)78);
					sw.Write((char)5);
					sw.Write((char)27);
					sw.Write((char)15);
					sw.WriteLine();
					string des="+------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+";
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("TimeTableAdjustment For "+GenUtil.ToMMddYYYY(GenUtil.trimDate(txtadjustdate.Text)),des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------",des.Length));
					info = " {0,-12:S} {1,-14:S} {2,-14:S} {3,-14:S} {4,-14:S} {5,-14:S} {6,-14:S} {7,-14:S} {8,-14:S}";
					sw.WriteLine ("Absent Teacher :- "+Dropempid.SelectedItem.Text);
					sw.WriteLine("+------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+");
					sw.WriteLine("| Day/Period |     I        |      II      |      III     |     IV       |      V       |      VI      |     VII      |     VIII     |");
					sw.WriteLine("+------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+");
					//             123456789012 123456789012 123456789012 123456789012 123456789012 123456789012 123456789012 123456789012  123456789012
    				sw.WriteLine (info,Dropday.SelectedItem.Text.Trim(),p1.ToString(),p2.ToString(),
						p3.ToString(),p4.ToString(),p5.ToString(),p6.ToString(),p7.ToString(),
						p8.ToString()
						);
					string t1="",t2="",t3="",t4="",t5="",t6="",t7="",t8="";
					if(Drop1.SelectedIndex!=0)
						t1=Drop1.SelectedItem.Text.Trim();
					if(Drop2.SelectedIndex!=0)
						t2=Drop2.SelectedItem.Text.Trim();
					if(Drop3.SelectedIndex!=0)
						t3=Drop3.SelectedItem.Text.Trim();
					if(Drop4.SelectedIndex!=0)
						t4=Drop4.SelectedItem.Text.Trim();
					if(Drop5.SelectedIndex!=0)
						t5=Drop5.SelectedItem.Text.Trim();
					if(Drop6.SelectedIndex!=0)
						t6=Drop6.SelectedItem.Text.Trim();
					if(Drop7.SelectedIndex!=0)
						t7=Drop7.SelectedItem.Text.Trim();
					if(Drop8.SelectedIndex!=0)
						t8=Drop8.SelectedItem.Text.Trim();
					sw.WriteLine (info,"Teacher",t1.ToString(),t2.ToString(),t3.ToString(),
						t4.ToString(),t5.ToString(),t6.ToString(),t7.ToString(),t8.ToString());
					sw.WriteLine("+------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+--------------+");
					sw.Close();
					Print();
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method  btnPrint_Click, TimeTableAdjustment View , Userid :  "+ pass   );
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method  btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				}
			}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropday_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			adjuctemp();
		}
		public void  adjuctemp()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader dtratt;
				string str="",str1="",str2="",str3="",str4="",str5="",str6="",str7="";
				if(Dropday.SelectedIndex!=0)
				{
					if(Dropday.SelectedItem.Text.Equals("Monday"))
					{
						if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and  mon1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and mon8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="mon"+j;
							}
						}
						else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and mon8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="mon"+j;
							}
						}
											
					}
					else if(Dropday.SelectedItem.Text.Equals("Tuesday"))
					{
						if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="tue"+j;
							}
						}
						else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue8='' order by t.tpd";
     						for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="tue"+j;
							}
						}
					}
					else if(Dropday.SelectedItem.Text.Equals("Wednesday"))
					{
						if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and tue8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="wed"+j;
							}
						}
    					else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and tue8='' order by t.tpd";
	    					for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="wed"+j;
							}
						}
					}
					else if(Dropday.SelectedItem.Text.Equals("Thrusday"))
					{
						if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and thu1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and thu8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="thu"+j;
							}
						}
						else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and thu8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="thu"+j;
							}
						}
					}
					else if(Dropday.SelectedItem.Text.Equals("Friday"))
					{
		    			if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and fri1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and fri2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and fri3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and fri4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and fri5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and fri6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and fri7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"'))  and fri8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="fri"+j;
							}
						}
						else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and fri8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="fri"+j;
							}
						}
					}
					else if(Dropday.SelectedItem.Text.Equals("Satarday"))
					{
						if(Dropdesig.SelectedItem.Text.Equals("All"))
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and sat8='' order by t.tpd";
    						for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="sat"+j;
							}
						}
						else if(Dropdesig.SelectedIndex!=0)
						{
							str="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat1='' order by t.tpd";
							str1="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat2='' order by t.tpd";
							str2="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat3='' order by t.tpd";
							str3="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat4='' order by t.tpd";
							str4="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat5='' order by t.tpd";
							str5="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat6='' order by t.tpd";
							str6="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat7='' order by t.tpd";
							str7="select t.shortname+':'+s.staff_type+':',t.employee_id from teachertimetable t,staff_information s where t.employee_id in (select s.staff_id from staff_information where s.staff_id in (select staff_id from  staff_attandance st where st.Attandance_Status!='0' and st.Attendance_Date='"+GenUtil.ToMMddYYYY(txtadjustdate.Text) +"')) and s.staff_type='"+Dropdesig.SelectedItem.Text+"' and sat8='' order by t.tpd";
							for(int i=0;i<8;i++)
							{
								int j=i+1;
								period[i]="sat"+j;
							}
						}
					}
					dtratt=obj.GetRecordSet(str);
					Drop1.Items.Clear();
					Drop2.Items.Clear();
					Drop3.Items.Clear();
					Drop4.Items.Clear();
					Drop5.Items.Clear();
					Drop6.Items.Clear();
					Drop7.Items.Clear();
					Drop8.Items.Clear();
					Drop1.Items.Add("Select");
					Drop2.Items.Add("Select");
					Drop3.Items.Add("Select");
					Drop4.Items.Add("Select");
					Drop5.Items.Add("Select");
					Drop6.Items.Add("Select");
					Drop7.Items.Add("Select");
					Drop8.Items.Add("Select");
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop1.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str1);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop2.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str2);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop3.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str3);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop4.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str4);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop5.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str5);
    				while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop6.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str6);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop7.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
					dtratt=obj.GetRecordSet(str7);
					while(dtratt.Read())
					{
						string id=dtratt.GetValue(1).ToString();
						Drop8.Items.Add(id+":"+dtratt.GetValue(0).ToString()+countID(id));
					}
					dtratt.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :TimeTableAdjustment.aspx,Method  btnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		private void Dropdesig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			adjuctemp();
		}
	}
}
