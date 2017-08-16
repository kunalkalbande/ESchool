
     
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
	/// Summary description for Staff_leave.
	/// </summary>
	public class Staff_leave : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtleavefrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtleaveto;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.ValidationSummary vsEmpLeave;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label tcid11;
		protected System.Web.UI.WebControls.Label slid;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.Button btneditsave;
		protected System.Web.UI.WebControls.Button btndelete;
		protected System.Web.UI.WebControls.Button btnSave;
		static int lf=0,tf=0;
		protected System.Web.UI.WebControls.TextBox txtdoa;
		protected System.Web.UI.WebControls.TextBox txtnatapp;
		protected System.Web.UI.WebControls.DropDownList DropLeaveType;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.HtmlControls.HtmlInputText Tempvalue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.DropDownList DropDesig;
		protected System.Web.UI.WebControls.CompareValidator cvStaffName;
		protected System.Web.UI.HtmlControls.HtmlInputText  txtAccName1;
		string pass;
		protected System.Web.UI.HtmlControls.HtmlInputText DropStaffName;
		protected System.Web.UI.WebControls.CompareValidator validcom1;
		protected System.Web.UI.HtmlControls.HtmlInputText Tempvalue1;

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
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog ("Form: Staff_Leave.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_Leave.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				//pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
				{
					txtleavefrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtleaveto.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					SqlConnection con;
					SqlCommand  cmdselect;
					SqlDataReader dtrstaff;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					
					/*cmdselect = new SqlCommand( "Select  Staff_ID,Staff_name From Staff_Information order by Staff_ID", con );
					dtrstaff = cmdselect.ExecuteReader();
					DropStaffname.Items.Clear();
					DropStaffname.Items.Add("Select");
					while(dtrstaff.Read())
					{
						DropStaffname.Items.Add(dtrstaff.GetValue(0).ToString()+":"+dtrstaff.GetValue(1).ToString());
					}
					dtrstaff.Close();
					cmdselect.Dispose();*/
					
					cmdselect = new SqlCommand( "select Staff_name from Staff_Type order by staff_name", con );
					dtrstaff = cmdselect.ExecuteReader();
					DropDesig.Items.Clear();
					DropDesig.Items.Add("Select");
					while(dtrstaff.Read())
					{
						DropDesig.Items.Add(dtrstaff.GetValue(0).ToString());
					}
					dtrstaff.Close();
					cmdselect.Dispose();
					con.Close ();
				}

				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			
			try
			{
				if(! IsPostBack)
				{
					nextid();
					DropEdit.Visible=false;
					slid.Visible=true;
					btnSave.Visible=true;
					btnedit.Visible=true;
					btneditsave.Visible=false;
					btndelete.Visible=true;

					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="3";
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
				
					SqlDataReader sdtr=null;
					InventoryClass obj=new InventoryClass();
					//string sql="select staff_type,staff_id,staff_name from staff_information order by staff_name";
					string sql="select staff_type,staff_id,staff_name,doj,natapp from staff_information order by staff_name";
					sdtr=obj.GetRecordSet(sql);
					while(sdtr.Read())
					{
						//Tempvalue.Value+=sdtr.GetValue(0).ToString()+":";
						//Tempvalue.Value+=sdtr.GetValue(2).ToString()+":";
						//Tempvalue.Value+=sdtr.GetValue(1).ToString()+",";
						Tempvalue.Value+=sdtr.GetValue(0).ToString()+":";
						Tempvalue.Value+=sdtr.GetValue(2).ToString()+":";
						Tempvalue.Value+=sdtr.GetValue(1).ToString()+":";
						Tempvalue.Value+=GenUtil.trimDate(GenUtil.str2DDMMYYYY(sdtr.GetValue(3).ToString()))+":";
						Tempvalue.Value+=sdtr.GetValue(4).ToString()+",";
					}
					sdtr.Close();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : Staff_leave.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			// nextid();
		}
		
		/// <summary>
		///  PWeb Form Designer generated code
		/// </summary>
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
			this.txtleavefrom.TextChanged += new System.EventHandler(this.txtleavefrom_TextChanged);
			this.txtleaveto.TextChanged += new System.EventHandler(this.txtleaveto_TextChanged);
			this.DropLeaveType.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btneditsave.Click += new System.EventHandler(this.btneditsave_Click);
			this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
			this.DropStaffName.ServerChange += new System.EventHandler(this.DropStaffName_ServerChange);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		
		
		/// <summary>
		/// This Method use to return date in to MMDDYYYY format. but first it get date as string.
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
		/// This Method use to genarate next staffleave ID.
		/// </summary>
		public void nextid()
		{
 			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				strInsert = "select max(staffleave_id)+1 from  Staff_leave ";
				cmdInsert=new SqlCommand (strInsert,con);
				SqlDataReader dr=cmdInsert.ExecuteReader();
				string st="";
				while(dr.Read())
				{
					if(dr.GetValue(0).ToString()!="" && dr.GetValue(0).ToString()!=null)
					{
						slid.Text=dr.GetValue(0).ToString();
					}
					else
					{
                         slid.Text="1";
					}
				}
				dr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: nextid. Exception: " + ex.Message + " User: " + pass );
			}
		}
      
		/// <summary>
		/// This method use to Clear all controls on page.
		/// </summary>
		public void Clear()
		{
			txtdoa.Text="";
			txtleavefrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtleaveto.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			//DropStaffname.SelectedIndex=0;
			DropStaffName.Value="Select";
			DropLeaveType.SelectedIndex=0;
			DropDesig.SelectedIndex=0;
			txtnatapp.Text="";
		}
		
		/// <summary>
		/// This method use to Reset Page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}
		

	
		private void Button1_Click(object sender, System.EventArgs e)
		{
			
		}
		
		/// <summary>
		/// This Method use to insert the staff leave Records in to staff_leave table. first it check date. after that check record also exist between particular period.
		/// if not exist then save record in staff_leave table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				
				if(DateTime.Compare(ToMMddYYYY(sSysDate),ToMMddYYYY(txtleavefrom.Text))>0)
				{
					MessageBox.Show("Leave date from must be greater than or equal to current date");
				}
				else
				{
					if(DateTime.Compare(ToMMddYYYY(txtleaveto.Text),ToMMddYYYY(txtleavefrom.Text))>=0)//check whether datefrom gretter than dateTo.
					{
						System.TimeSpan diff=ToMMddYYYY(txtleaveto.Text).Subtract(ToMMddYYYY(txtleavefrom.Text));
						int idays=diff.Days;
						string datefrom=GenUtil.str2MMDDYYYY (txtleavefrom.Text .ToString ());
						string dateto=GenUtil.str2MMDDYYYY (txtleaveto.Text .ToString ());

						//string emp=DropStaffname.SelectedItem.Text;
						string emp=DropStaffName.Value;
						string[] empname=emp.Split(new char[] {':'},emp.Length);
						int icount=0;
						SqlConnection con;
						string strInsert;
						SqlCommand cmdInsert;
						SqlDataReader sdtr=null;
						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con.Open ();
						strInsert="";
						strInsert="select count(*) from Staff_leave where Staff_ID="+empname[1].ToString()+" and (Staff_leavefromdt>='"+datefrom+"'and Staff_leavefromdt<='"+datefrom+"' or Staff_leavefromto>='"+dateto+"'and Staff_leavefromto<='"+dateto+"')";
						cmdInsert=new SqlCommand (strInsert,con);
                        sdtr=cmdInsert.ExecuteReader();
						if(sdtr.Read())
						{
                              icount=Convert.ToInt32( sdtr.GetValue(0));
						}
						sdtr.Close();
						cmdInsert.Dispose();
						if(icount>0)
						{
							MessageBox.Show("Leave Can not be Apply for Same Date");
						}
						else
						{
							strInsert = "Insert Staff_leave(staffleave_ID,Staff_ID,Staff_leavefromdt,Staff_leavefromto,Leave_Type,adjustment,Days)values (@staffleave_ID,@Staff_ID,@Staff_leavefromdt,@Staff_leavefromto,@Leave_Type,@adjust,@Days)";
							cmdInsert=new SqlCommand (strInsert,con);
							cmdInsert.Parameters .Add ("@staffleave_ID",slid.Text.Trim().ToString());
							//if(DropStaffname.SelectedIndex ==0 )
							if(DropStaffName.Value=="" )
								cmdInsert.Parameters .Add ("@Staff_ID","");
							else
								cmdInsert.Parameters .Add ("@Staff_ID",empname[1].ToString());
							cmdInsert.Parameters .Add ("@Staff_leavefromdt",GenUtil.str2MMDDYYYY (txtleavefrom.Text .ToString ()) );
							cmdInsert.Parameters .Add ("@Staff_leavefromto",GenUtil.str2MMDDYYYY (txtleaveto.Text .ToString ()));
							if(DropLeaveType.SelectedIndex==0)
								cmdInsert.Parameters .Add ("@Leave_Type","");
							else
								cmdInsert.Parameters .Add ("@Leave_Type",DropLeaveType.SelectedItem.Text);
							cmdInsert.Parameters.Add("@adjust",Convert.ToInt32(0));
							cmdInsert.Parameters.Add("@Days",idays);
							cmdInsert.ExecuteNonQuery();
							con.Close ();
							MessageBox.Show("Staff Leave Successfully Saved");
							//CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnSave_Click. Leave for the employee ID: " + DropStaffname.SelectedItem.Text + " is saved. User: " + Session["password"].ToString() );
							CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnSave_Click. Leave for the employee ID: " + DropStaffName.Value + " is saved. User: " + pass );
							Clear();
							nextid();                                                     //method call for adding the next leave id on the label.
						}
						
					}
					else
					{
						MessageBox.Show("Leave date to must be greater than or equal to leave date from");
					}
				}
				DropEdit.Visible=false;
				slid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				btndelete.Visible=true;
				//CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnSave_Click.  User: " + Session["password"].ToString() );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to add staffleave id from staff_leave table in to dropEdit.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropEdit.Visible=true;
				slid.Visible=false;
				btnSave.Visible=false;
				btnedit.Visible=false;
				btneditsave.Visible=true;
				btndelete.Visible=true;
	 			DropEdit.Items.Clear();
				DropEdit.Items.Add("--Select--");
	 			SqlConnection con;
				string strInsert;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				strInsert = "select staffleave_id from staff_leave";
				cmdInsert=new SqlCommand (strInsert,con);
				SqlDataReader dr=cmdInsert.ExecuteReader();
				while(dr.Read())
				{
					DropEdit.Items.Add(dr.GetValue(0).ToString());
				}
				dr.Close();
				//CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnReset_Click. Leave for the employee ID: " + DropStaffname.SelectedItem.Text + " is saved. User: " + Session["password"].ToString() );
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnReset_Click. Leave for the employee ID: " + DropStaffName.Value + " is saved. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btnReset_Click.  User: " + pass );
			}
		
		}

		/// <summary>
		/// this method use to fill information of the selected staffleaveid in to the controls on form.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con;
				SqlCommand cmdInsert;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				string str="select s.staff_id,s.staff_leavefromdt,s.staff_leavefromto,s.leave_type,sr.staff_name,sr.staff_type,sr.doj,sr.natapp from staff_leave s,staff_information sr where s.staffleave_id='"+DropEdit.SelectedItem.Text.ToString()+"' and s.staff_id=sr.staff_id	";		 
				cmdInsert=new SqlCommand (str,con);
				SqlDataReader dr=cmdInsert.ExecuteReader();
				while(dr.Read())
				{
					txtleavefrom.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY (dr.GetValue(1).ToString()));
					txtleaveto.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr.GetValue(2).ToString()));
					if(dr.GetValue(7).ToString().Equals("Select"))
						txtnatapp.Text="";
					else
						txtnatapp.Text=dr.GetValue(7).ToString();
					txtdoa.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dr.GetValue(6).ToString()));
					DropDesig.SelectedIndex=DropDesig.Items.IndexOf(DropDesig.Items.FindByValue(dr.GetValue(5).ToString()));
					//DropStaffname.SelectedIndex=DropStaffname.Items.IndexOf(DropStaffname.Items.FindByValue(dr.GetValue(0).ToString()+":"+dr.GetValue(4).ToString()));
					DropStaffName.Value=dr.GetValue(4).ToString()+":"+dr.GetValue(0).ToString();
					DropLeaveType.SelectedIndex=DropLeaveType.Items.IndexOf(DropLeaveType.Items.FindByValue(dr.GetValue(3).ToString()));
				}
				dr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: DropEdit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to Update the staff leave  records in to staff_leave table.
		/// </summary>
		private void btneditsave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			SqlDataReader sdtr=null;
			int icount=0;
			string datefrom=GenUtil.str2MMDDYYYY (txtleavefrom.Text .ToString ());
			string dateto=GenUtil.str2MMDDYYYY (txtleaveto.Text .ToString ());
			try
			{

				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				
				if(DateTime.Compare(ToMMddYYYY(sSysDate),ToMMddYYYY(txtleavefrom.Text))>0)
				{
					MessageBox.Show("Leave date from must be greater than or equal to current date");
				}
				else
				{
					if(DateTime.Compare(ToMMddYYYY(txtleaveto.Text),ToMMddYYYY(txtleavefrom.Text))>=0)//check whether datefrom gretter than dateTo.
					{
						System.TimeSpan diff=ToMMddYYYY(txtleaveto.Text).Subtract(ToMMddYYYY(txtleavefrom.Text));
						int idays=diff.Days;
					
						//string emp=DropStaffname.SelectedItem.Text;
						string emp=DropStaffName.Value;
						string[] empname=emp.Split(new char[] {':'},emp.Length); 

						con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con.Open ();

						/*strInsert="select count(*) from Staff_leave where Staff_ID="+empname[1].ToString()+" and (Staff_leavefromdt>='"+datefrom+"'and Staff_leavefromdt<='"+datefrom+"' or Staff_leavefromto>='"+dateto+"'and Staff_leavefromto<='"+dateto+"')";
						cmdInsert=new SqlCommand (strInsert,con);
						sdtr=cmdInsert.ExecuteReader();
						if(sdtr.Read())
						{
							icount=Convert.ToInt32( sdtr.GetValue(0));
						}
						sdtr.Close();
						cmdInsert.Dispose();
						if(icount>0)
						{
							MessageBox.Show("Leave Can not Update for Same Date");
						}
						else
						{*/
						
						string emp1=DropEdit.SelectedItem.Text;
						//strInsert = "update Staff_leave set Staff_leavefromdt=@Staff_leavefromdt,Staff_leavefromto=@Staff_leavefromto,Leave_Type=@Leave_Type,Days=@Days where staff_ID=" +empname[0] + "";
						strInsert = "update Staff_leave set staff_id=@Staff_ID,Staff_leavefromdt=@Staff_leavefromdt,Staff_leavefromto=@Staff_leavefromto,Leave_Type=@Leave_Type,Days=@Days where staffleave_ID=" +emp1.ToString().Trim()+ "";
						cmdInsert=new SqlCommand (strInsert,con);
					
						//if(DropStaffname.SelectedIndex ==0)
						if(DropStaffName.Value=="")
							cmdInsert.Parameters .Add ("@Staff_ID","");
						else
							cmdInsert.Parameters .Add ("@Staff_ID",empname[1]);
						if(lf==1)
							cmdInsert.Parameters .Add ("@Staff_leavefromdt",GenUtil.str2MMDDYYYY (txtleavefrom.Text .ToString ()) );
						else
							cmdInsert.Parameters .Add ("@Staff_leavefromdt",GenUtil.str2MMDDYYYY (txtleavefrom.Text .ToString ()));
						if(tf==1)
							cmdInsert.Parameters .Add ("@Staff_leavefromto",GenUtil.str2MMDDYYYY (txtleaveto.Text .ToString ()));
						else
							cmdInsert.Parameters .Add ("@Staff_leavefromto",GenUtil.str2MMDDYYYY (txtleaveto.Text .ToString ()));
					
						if(DropLeaveType.SelectedIndex==0)
							cmdInsert.Parameters .Add ("@Leave_Type","");
						else
							cmdInsert.Parameters .Add ("@Leave_Type",DropLeaveType.SelectedItem.Text);
					
						cmdInsert.Parameters.Add("@Days",idays);
						cmdInsert.ExecuteNonQuery();
						con.Close ();
						MessageBox.Show("Staff Leave Successfully Updated");
						//CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btneditsave_Click. Leave for the employee ID: " + DropStaffname.SelectedItem.Text + " is Updated. User: " + Session["password"].ToString() );
						CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btneditsave_Click. Leave for the employee ID: " + DropStaffName.Value + " is Updated. User: " + pass );
						nextid();
						Clear();                                                          //call function to clear the form.
						DropEdit.Visible=false;
						slid.Visible=true;
						btnSave.Visible=true;
						btnedit.Visible=true;
						btneditsave.Visible=false;
						btndelete.Visible=true;
						//}
					}
					else
					{
						MessageBox.Show("Leave date from must be greater than or equal to current date");
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btneditsave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// check whether leavefrom date has been changed.
		/// </summary>
		private void txtleavefrom_TextChanged(object sender, System.EventArgs e)
		{
			lf=1;
		}

		/// <summary>
		/// check whether leaveto date has been changed.
		/// </summary>
		private void txtleaveto_TextChanged(object sender, System.EventArgs e)
		{
			tf=1;
		}

		/// <summary>
		/// This Method for deleting the staff leave records staff_leave table.
		/// </summary>
		private void btndelete_Click(object sender, System.EventArgs e)
		{
			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				strInsert = "DELETE  Staff_leave where staffleave_id='"+DropEdit.SelectedItem.Text.ToString()+"'";
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.ExecuteNonQuery();
				MessageBox.Show("Staff Leave Information Deleted");
		        CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btndelete_Click. Staff leave record deleted for Staffleaveid"+DropEdit.SelectedItem.Text.ToString()+"  User: " + pass );				
				nextid();
				Clear();
				DropEdit.Visible=false;
				slid.Visible=true;
				btnSave.Visible=true;
				btnedit.Visible=true;
				btneditsave.Visible=false;
				btndelete.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: btndelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		/// <summary>
		/// this method no in use.
		/// </summary>
		private void DropDesig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*try
			{
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				string str="select staff_id,staff_name from staff_information where staff_type='"+DropDesig.SelectedItem.Text+"'";
				SqlDtr=obj.GetRecordSet(str);
				DropStaffname.Items.Clear();
				DropStaffname.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropStaffname.Items.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: DropDesig_SelectedIndexChanged. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}*/
		}

		/// <summary>
		/// this method no in use..
		/// </summary>
		private void DropStaffname_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				
				EmployeeClass obj=new EmployeeClass();
				SqlDataReader SqlDtr;
				//string emp=DropStaffname.SelectedItem.Text;
				string emp=DropStaffName.Value;
				//string[] empname=emp.Split(new char[] {':'},emp.Length); 
				//string str="select doj,natapp from staff_information where staff_id='"+empname[0]+"'";
				//SqlDtr=obj.GetRecordSet(str);
				
				//while(SqlDtr.Read())
				//{
					//if(SqlDtr.GetValue(1).ToString().Trim()!=null && SqlDtr.GetValue(1).ToString().Trim()!="Select")
				//		txtnatapp.Text=SqlDtr.GetValue(1).ToString();
				//	else
				//	    txtnatapp.Text="";

				//	txtdoa.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(SqlDtr.GetValue(0).ToString()));
				//}
				//SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staff_leave.aspx.cs, Method: Dropstaffname_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void DropStaffName_ServerChange(object sender, System.EventArgs e)
		{
		
		}

		
	}
}

