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
using eschool.Classes;
# endregion

namespace eschool.Hostel
{
	/// <summar>
	/// Summary description for Room_booking.
	/// </summary>
	public class Room_booking : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtdate;
		protected System.Web.UI.WebControls.TextBox txtfees;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.CompareValidator cvRoomNo;
		protected System.Web.UI.WebControls.ValidationSummary vsRoomBooking;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropBed1;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.DropDownList Dropclass;
		SqlCommand cmdInsert111;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		static string bedno="";
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
            txtstudentname.Attributes.Add("readonly", "readonly");
            txtfees.Attributes.Add("readonly", "readonly");
            txtdate.Attributes.Add("readonly", "readonly");
            try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Room_Booking.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
     			//string pass;
				//pass=(Session["password"].ToString ());
				
				if(!Page.IsPostBack)
				{
					txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					# region Fill Class into the Dropdownbox.
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select class_name from class order by class_Id", con );
					dtrclass = cmdselect.ExecuteReader();
					Dropclass.Items .Clear ();
					Dropclass.Items .Add ("---Select---");
					while(dtrclass.Read())
					{
						Dropclass.Items.Add(dtrclass.GetValue(0).ToString());
					}
					dtrclass.Close();
					con.Close ();
					# endregion

					
				}
			 	if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="9";
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
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_booking.aspx.cs,Method : Page_Load  , Exception : "+ex.Message+",      Userid :  " + pass   );
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
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.DropBed1.SelectedIndexChanged += new System.EventHandler(this.DropBed1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method return the student_id.
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
		/// this method add the student information into the controls as per studentid selected form Dropdownbox.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con44;
				SqlCommand cmdselect44;
				SqlDataReader dtrdrive44;
 				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open();
				cmdselect44=new SqlCommand("Select  Student_Record.Student_FName, Student_Record.Student_Class ,feesdecision.hostal_fees,feesdecision.Mess_fees From feesdecision, Student_Record where Student_ID=@Student_ID and  feesdecision.class_id= (select class_ID from class where class_name=Student_Record.Student_Class)", con44 );
				cmdselect44.Parameters .Add ("@Student_ID",ShowStudentID(Dropstudentid.SelectedItem .Text.ToString()));
				dtrdrive44=cmdselect44.ExecuteReader();
				while (dtrdrive44.Read()) 
				{
					txtstudentname.Text=dtrdrive44.GetString(0);
		     		
					txtfees.Text =dtrdrive44.GetValue(2).ToString();
				}
				dtrdrive44.Close();
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_booking.aspx.cs,Method : DropDownList1_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
		
		/// <summary>
		/// this method use to gnerate the bed no and also add in listbox.
		/// </summary>
		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DropBed1.Items.Clear();
			DropBed1.Items .Add ("---Select---");
			SqlConnection con5;
			SqlCommand cmdselect5=null;
			SqlDataReader dtrdrive5;
			try
			{
				con5=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con5.Open ();
			 
				//if(btnSave.Text.Equals ("Save"))																								//18.09.08
				cmdselect5 = new SqlCommand("Select bed_no from tbed where roomno='" + DropDownList2.SelectedItem.Value .ToString () + "' and allocated='N' order by bed_no", con5);
				//else																																	//18.08.09
				//	cmdselect5 = new SqlCommand("Select bed_no from tbed where roomno='" + DropDownList2.SelectedItem.Value .ToString () + "'", con5);  //18.09.08
				
				dtrdrive5 = cmdselect5.ExecuteReader();
				while (dtrdrive5.Read()) 
				{ 
					DropBed1.Items.Add(dtrdrive5.GetValue(0).ToString());
				}
				dtrdrive5.Close();
				//18.09.08 by vikas sharma 
				//cmdselect5 = new SqlCommand("Select bed_no from tbed where student_id='" + Dropstudentid.SelectedItem.Value .ToString () + "' and allocated='Y'", con5);
				//dtrdrive5 = cmdselect5.ExecuteReader();
				//while (dtrdrive5.Read()) 
				//{ 
				//	DropBed1.Items.Add(dtrdrive5.GetValue(0).ToString());
				//}
				//dtrdrive5.Close();

				con5.Close ();    
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_booking.aspx.cs,Method : DropDownList2_SelectedIndexChanged  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
 	
		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void Clear()
		{
			DropDownList2.SelectedIndex=0;
			DropBed1.SelectedIndex =0;
			txtstudentname.Text="";
			txtfees.Text="";
			txtdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}	
		
		/// <summary>
		/// this mrthod use to Reset form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
		  Clear();
			Dropclass.SelectedIndex=0;
			Dropstudentid.SelectedIndex=0;
			btnSave.Text="Save";
		 
		}
		
		/// <summary>
		/// Method for return the date into MM/DD/YYYY format.
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
		/// Method for saving the Room booking the information in tbed table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con111;
			string strInsert111;
			try
			{				
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				strInsert111 = "update tbed set date_and_time='"+GenUtil.str2MMDDYYYY(txtdate.Text)+"',Student_ID=@studentid,allocated='Y' where roomno=@roomno and bed_no=@bedno";			
				cmdInsert111=new SqlCommand (strInsert111,con111);
				cmdInsert111.Parameters .Add ("@dt",GenUtil.str2MMDDYYYY(txtdate.Text));
				cmdInsert111.Parameters .Add ("@studentid",Dropstudentid.SelectedItem .Value.ToString ());
				cmdInsert111.Parameters .Add ("@roomno",DropDownList2.SelectedItem.Value.ToString());
				cmdInsert111.Parameters .Add ("@bedno",DropBed1.SelectedItem.Value.ToString());
				cmdInsert111.ExecuteNonQuery();
				if(btnSave.Text.Equals("Update"))
				{
					if((!DropBed1.SelectedItem.Value.ToString().Equals(bedno)))
					{
						strInsert111 = "update tbed set allocated='N', student_id=null, date_and_time=null where roomno='" + DropDownList2.SelectedItem.Value .ToString () + "' and bed_no='" + bedno + "'";			
						cmdInsert111=new SqlCommand (strInsert111,con111);
						cmdInsert111.ExecuteNonQuery ();
					}
				}
				con111.Close ();
				CreateLogFiles.ErrorLog(" Form : Room_booking.aspx.cs,Method : btnSave_Click  , Room Booking Saved For StudentID: "+ Dropstudentid.SelectedItem .Value.ToString ()+" in Room no  "+DropDownList2.SelectedItem .Value.ToString ()  +",     Userid :  " + pass   );				
				if(btnSave.Text.Equals("Save"))
					MessageBox.Show("Room Successfully Booked" );
					//MessageBox.Show("Room Booked" );
				else
					MessageBox.Show("Room Booking Successfully Updated" );
					//MessageBox.Show("Room Update" );
				Clear();
				Dropclass.SelectedIndex=0;
				Dropstudentid.SelectedIndex=0;
				btnSave.Text="Save";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Room_booking.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to Fill StudentID into the Dropdownbox.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string a=Dropclass.SelectedItem.Value .ToString ();  
			bedno="";
			Dropclass.SelectedIndex =Dropclass.Items.IndexOf (Dropclass.Items.FindByValue (a));  
			btnSave.Text="Save";
			SqlConnection con;
			SqlCommand  cmdselect;
			SqlDataReader dtrclass;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//cmdselect = new SqlCommand( "Select seq_student_id From Student_Record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "' and Service_Hostal='Yes' order by seq_student_id", con );
				cmdselect = new SqlCommand( "Select student_id From Student_Record where student_class='" + Dropclass.SelectedItem.Value.ToString () + "'order by seq_student_id", con ); // add by vikas sharma date on 13.03.08
				dtrclass = cmdselect.ExecuteReader();
				Dropstudentid.Items.Clear ();
				Dropstudentid.Items .Add ("---Select---");
				while(dtrclass.Read())
				{
					Dropstudentid.Items.Add(dtrclass.GetValue(0).ToString());
				}
				dtrclass.Close();
				con.Close ();
				DropBed1.SelectedIndex=0;
				DropDownList2.SelectedIndex=0;
				txtfees.Text="";
				txtstudentname.Text="";
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : Room_booking.aspx.cs, Method : Dropclass_SelectedIndexChanged, Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// This method use to Fill textboxes from student_record,hostel_fees and tbed table.
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ArrayList bedid=new ArrayList();
			SqlConnection con;
			SqlCommand  cmdselect;
			SqlDataReader dtrclass;
			Clear();
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select student_fname From Student_Record where student_id='" + Dropstudentid.SelectedItem.Value.ToString () + "'",con);
				dtrclass = cmdselect.ExecuteReader();
				while(dtrclass.Read())
				{
					txtstudentname.Text=dtrclass.GetValue(0).ToString() ;
				}
				dtrclass.Close();
				cmdselect = new SqlCommand( "Select Fees From Hostel_fees where class_id='" + Dropclass.SelectedItem.Value.ToString () + "'",con);
				dtrclass = cmdselect.ExecuteReader();
				while(dtrclass.Read())
				{
					txtfees.Text=dtrclass.GetValue(0).ToString() ;
				}
				dtrclass.Close();
				btnSave.Text="Save";
				DropBed1.Items .Clear ();
				DropBed1.Items .Add ("---Select---");

				# region Fill RoomNo  into the Dropdownbox.
				cmdselect = new SqlCommand( "Select distinct Roomno From Room_mast order by roomno", con );
				dtrclass = cmdselect.ExecuteReader();
				DropDownList2.Items.Clear();
				DropDownList2.Items.Add("---Select---");
				while(dtrclass.Read())
				{
					DropDownList2.Items.Add(dtrclass.GetValue(0).ToString());
				}
				dtrclass.Close();
				# endregion

				string x="";
				cmdselect = new SqlCommand( "Select * from tbed where student_id=(select student_id from student_record where student_id='" + Dropstudentid.SelectedItem.Value.ToString () + "')",con);
				dtrclass = cmdselect.ExecuteReader();
				if(dtrclass.HasRows )
				{
					if(dtrclass.Read())
					{
						DropDownList2.SelectedIndex =DropDownList2.Items .IndexOf (DropDownList2.Items .FindByValue (dtrclass.GetValue (2).ToString ()));   
						x=dtrclass.GetValue (1).ToString ();
						txtdate.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY (dtrclass.GetValue (3).ToString ())); 
					}
					btnSave.Text="Update";
					dtrclass.Close ();
					//cmdselect = new SqlCommand( "Select bed_no from tbed where roomno='" + DropDownList2.SelectedItem.Value.ToString () + "' and allocated!='Defective'",con);
					cmdselect = new SqlCommand( "Select bed_no from tbed where roomno='" + DropDownList2.SelectedItem.Value.ToString () + "' and allocated='N'",con);
					dtrclass = cmdselect.ExecuteReader();
					DropBed1.Items .Clear ();
					DropBed1.Items .Add ("---Select---");
					if(dtrclass.HasRows )
					{
						while(dtrclass.Read())
						{
							//DropBed1.Items .Add (dtrclass.GetValue (0).ToString ());
							bedid.Add(dtrclass.GetValue (0).ToString ());
						}
					}
					dtrclass.Close();
					//***********************add by vikas sharma date on 19.09.08
					cmdselect = new SqlCommand( "Select bed_no from tbed where roomno='" + DropDownList2.SelectedItem.Value.ToString () + "' and student_id='"+Dropstudentid.SelectedItem.Value.ToString()+"'",con);
					dtrclass = cmdselect.ExecuteReader();
					if(dtrclass.HasRows )
					{
						while(dtrclass.Read())
						{
							//DropBed1.Items .Add (dtrclass.GetValue (0).ToString ());
							bedid.Add(dtrclass.GetValue (0).ToString ());
						}
					}
					//***********************************************************
					bedid.Sort();
					for(int i=0;i<bedid.Count;i++)
					{
						DropBed1.Items.Add(bedid[i].ToString());
					}
					bedid.Clear();
					DropBed1.SelectedIndex = DropBed1.Items .IndexOf (DropBed1.Items .FindByValue (x)); 
					bedno=DropBed1.SelectedItem.Value.ToString ();  
				}
				dtrclass.Close ();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : Room_booking.aspx.cs, Method : Dropstudentid_SelectedIndexChanged, Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}

		/// <summary>
		/// this method use to check a particular bed is allocated or not.
		/// </summary>
		private void DropBed1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SqlConnection con;
			SqlCommand  cmdselect;
			SqlDataReader dtrclass;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select allocated from tbed where bed_no='" + DropBed1.SelectedItem.Value.ToString () + "' and roomno='" + DropDownList2.SelectedItem.Value.ToString () + "'",con);
				dtrclass = cmdselect.ExecuteReader();
				if(dtrclass.HasRows )
				{
					if(dtrclass.Read())
					{
						if(dtrclass.GetValue (0).ToString ().Equals ("Y"))
						{
							MessageBox.Show ("Bed already alloted, select another.");
						}
					}
				}
				dtrclass.Close ();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form : Room_booking.aspx.cs, Method : DropBed1_SelectedIndexChanged, Exception : "+ex.Message+",      Userid :  " + pass   );
			}
		}
	}
}

