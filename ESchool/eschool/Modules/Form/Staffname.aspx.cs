
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
using System.Drawing.Imaging;
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



# endregion

namespace eschool.Form
{
	/// <summary>
	/// Summary description for Staffname.
	/// </summary>
	public class teacher : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink Hyperedit;
	//	protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		//protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator5;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator6;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator7;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator8;
		protected System.Web.UI.WebControls.Label lblDetails;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator9;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblType;
		protected System.Web.UI.WebControls.RadioButton chkTeaching;
		protected System.Web.UI.WebControls.RadioButton chkNonTeaching;
		protected System.Web.UI.WebControls.Label lblDesignation;
		protected System.Web.UI.WebControls.CompareValidator cvStaffType;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.TextBox txtstaffname;
		protected System.Web.UI.WebControls.Label lblPerCountry;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.Label lblPerState;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.Label lblPerCity;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.Label lblLoAddress;
		protected System.Web.UI.WebControls.Label lblLoPin;
		protected System.Web.UI.WebControls.TextBox txtlpin;
		protected System.Web.UI.WebControls.CompareValidator cvLpin;
		protected System.Web.UI.WebControls.Label lblLoCountry;
		protected System.Web.UI.WebControls.DropDownList DropCity1;
		protected System.Web.UI.WebControls.Label lblLoState;
		protected System.Web.UI.WebControls.DropDownList DropState1;
		protected System.Web.UI.WebControls.Label lblLoCity;
		protected System.Web.UI.WebControls.DropDownList DropCountry1;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.RegularExpressionValidator revEmail;
		protected System.Web.UI.WebControls.Label lblMobNo;
		protected System.Web.UI.WebControls.TextBox txtsmobile;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMob;
		protected System.Web.UI.WebControls.Label lblPhNo;
		protected System.Web.UI.WebControls.TextBox txtsphone;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPhNo;
		protected System.Web.UI.WebControls.Label lblSub;
		protected System.Web.UI.WebControls.ListBox lstSubject;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.ValidationSummary vsStaffName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.WebControls.RadioButton chkGroupD;
		protected System.Web.UI.WebControls.Label lblEmployeeID;
		protected System.Web.UI.WebControls.Label lblFatherName;
		protected System.Web.UI.WebControls.Label lblQualification;
		protected System.Web.UI.WebControls.TextBox txtFatherName;
		protected System.Web.UI.WebControls.TextBox txtprofequa;
		protected System.Web.UI.WebControls.Label lbl ;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.TextBox txtstaffeducation;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.DropDownList Dropmstatus;
		protected System.Web.UI.WebControls.TextBox txtloaddress;
		protected System.Web.UI.WebControls.TextBox txtperacno;
		protected System.Web.UI.WebControls.TextBox txtepfacno;
		protected System.Web.UI.WebControls.Label lbldojoin;
		protected System.Web.UI.WebControls.TextBox txtpaddress;
		protected System.Web.UI.WebControls.TextBox txtppin;
		protected System.Web.UI.WebControls.Label lblPerAddress;
		protected System.Web.UI.WebControls.Label lblPerPin;
		protected System.Web.UI.WebControls.CompareValidator cvPpin;
		protected System.Web.UI.WebControls.TextBox txtdojoin;
		protected System.Web.UI.WebControls.Label lblmaritialstatus;
		protected System.Web.UI.WebControls.Label lbldob;
		protected System.Web.UI.WebControls.TextBox txtage;
		protected System.Web.UI.WebControls.Label lblExp;
		protected System.Web.UI.WebControls.DropDownList Dropstaffexp;
		protected System.Web.UI.WebControls.CompareValidator cvExp;
		protected System.Web.UI.WebControls.DropDownList Dropsex;
		protected System.Web.UI.WebControls.DropDownList DropNatApp;
		protected System.Web.UI.HtmlControls.HtmlInputFile studentphoto;
		protected System.Web.UI.HtmlControls.HtmlImage imgUrl;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Label lblEmpID;
		protected System.Web.UI.WebControls.DropDownList DropEmpID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden getUrl;
		protected System.Web.UI.WebControls.Image ImgUrl1;
		protected System.Web.UI.WebControls.Label lblsex;
		protected System.Web.UI.WebControls.RadioButton chkactivity;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		SqlDataReader sdtr;
		protected System.Web.UI.WebControls.CompareValidator compairvali1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.Panel panDriver;
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
				CreateLogFiles.ErrorLog (" Form : Employee_Details.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Employee_Details.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				scon.Open ();	
				if(!IsPostBack)
				{
                    txtage.Attributes.Add("readonly", "readonly");
                    txtdojoin.Attributes.Add("readonly", "readonly");
                    txtage.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtdojoin.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					fillID();
					lblEmpID.Text=n;
					callfalse();
					FillDriverDetails();
					int i;
					for(i=0;i<=45;i++)
					{
						Dropstaffexp.Items.Add(i.ToString());
					}
				}
				
				if(!Page.IsPostBack)
				{
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

					scom = new SqlCommand( "Select distinct Subject_name  From Subject where status=1 order by Subject_name", scon );
					sdtr =  scom.ExecuteReader();
					while(sdtr.Read())
					{
						lstSubject.Items.Add(sdtr.GetString(0).ToString().Trim());
					}
					sdtr.Close();
				}

				#region Fill Text
	
				scom=new SqlCommand("Select Country,State,City from Country order by Country,State,City",scon);
				sdtr= scom.ExecuteReader();
				while(sdtr.Read())
				{
					txtName.Value=txtName.Value+sdtr.GetString(0).ToString().Trim()+ ":" +sdtr.GetString(1).ToString().Trim()+ ":" +sdtr.GetString(2).ToString().Trim()+ ",";
				}
				sdtr.Close();
				#endregion

				if(! IsPostBack)
				{
					DropEmpID.Visible=false;
					panDriver.Visible=false;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="3";
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
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return; 
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
			this.chkTeaching.CheckedChanged += new System.EventHandler(this.chkTeaching_CheckedChanged);
			this.chkNonTeaching.CheckedChanged += new System.EventHandler(this.chkNonTeaching_CheckedChanged);
			this.chkGroupD.CheckedChanged += new System.EventHandler(this.chkGroupD_CheckedChanged);
			this.chkactivity.CheckedChanged += new System.EventHandler(this.chkactivity_CheckedChanged);
			this.DropType.SelectedIndexChanged += new System.EventHandler(this.DropType_SelectedIndexChanged);
			this.DropEmpID.SelectedIndexChanged += new System.EventHandler(this.DropEmpID_SelectedIndexChanged);
			this.txtepfacno.TextChanged += new System.EventHandler(this.txtepfacno_TextChanged);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.DropCity1.SelectedIndexChanged += new System.EventHandler(this.DropCity1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.ID = "Form1";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This Method not in use.
		/// </summary>
		private void FillDriverDetails()
		{
		}

		/// <summary>
		/// This method use to hide some text box and other controls.
		/// </summary>
		private void callfalse()
		{
			Label19.Visible =false;
			Label20.Visible =false;
			Label21.Visible =false;
			Label22.Visible =false;
			Textbox1.Visible =false; 
			Textbox2.Visible =false;
			Textbox3.Visible =false;
			Textbox4.Visible =false;
			lblSub.Visible =false;
			lstSubject.Visible =false;
			lblExp.Visible =true;
			Dropstaffexp.Visible =true; 
			cvExp.Visible=true;
		}

		/// <summary>
		/// This Method use to Generated Next Id of Staff_Information table.
		/// </summary>
		string n="";
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;

			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(Staff_ID)+1 from Staff_Information",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						n=SqlDtr.GetValue(0).ToString ();
						lblEmpID.Text=SqlDtr.GetValue(0).ToString ();
						if(n.Trim().Equals(""))
						{
							n="1";
							lblEmpID.Text="1";
						}
					}
				}
				SqlDtr.Close (); 
				con.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: FillDriverDetails(). Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This Method is use to save the staff Registration.first it check listbox (lstSubject) has subect or not.
		/// After that check record all ready exist or not if not then Save the Record in staff_information. after 
		/// that also save some information in ledger_master table and create the ledger.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int j=0;
				int iCount=0;
				fillID();
				if(chkTeaching.Checked==true)
				{
					iCount=lstSubject.Items.Count;
					for(int i=0;i<iCount;i++)
					{		
						if(lstSubject.Items[i].Selected==true && chkTeaching.Checked==true)
						{
							j++;
						}
					}
				}
				if(iCount==0)
				{
					MessageBox.Show("Please Insert Subject");
					return;
				}
				SqlCommand scom;
				SqlDataReader sdtr=null;
				string str="Select count(*) from Staff_Information where staff_Name='"+txtstaffname.Text.Trim()+"' and father_name='"+txtFatherName.Text.Trim()+"' and age='"+GenUtil.str2MMDDYYYY(txtage.Text.Trim())+"'";
				scom=new SqlCommand(str,scon);
				sdtr=scom.ExecuteReader();
				int icount=0;
				if(sdtr.Read())
				{
					icount=Convert.ToInt32(sdtr.GetValue(0).ToString().Trim());
				}
				scom.Dispose();
				sdtr.Close();
				if(icount>0)
				{
					MessageBox.Show("Employee All Ready Exist");
					return;
				}
				else
				{
					SchoolClass.regis obj=new SchoolClass.regis();
					obj.Staff_ID=n.Trim().ToString();	
					if(DropType.SelectedIndex==0)
						obj.Staff_Type="";
					else
						obj.Staff_Type=DropType .SelectedItem.Value.ToString();
					
					if(txtstaffname.Text=="")
						obj.Staff_Name="";
					else
						obj.Staff_Name=txtstaffname.Text.Trim();
					
					if(txtpaddress.Text=="")
						obj.Staff_PerAddress="";
					else
						obj.Staff_PerAddress =txtpaddress.Text;
					
					if(DropCity.SelectedItem.Value=="---Select---")
						obj.Staff_PerCity="";
					else
						obj.Staff_PerCity=DropCity.SelectedItem.Value.ToString().Trim();
					
					if(DropState.SelectedItem.Value=="---Select---")
						obj.Staff_PerState="";
					else
						obj.Staff_PerState=DropState.SelectedItem.Value.ToString().Trim();
					
					if(DropCountry.SelectedItem.Value.ToString().Trim()=="---Select---")
						obj.Staff_PerCountry="";
					else
						obj.Staff_PerCountry=DropCountry.SelectedItem.Value.ToString().Trim();
					
					if(txtppin.Text=="")
						obj.Staff_PerPincode=0;
					else
						obj.Staff_PerPincode=Convert.ToInt32(txtppin.Text.ToString().Trim());
					
					if(txtloaddress.Text=="")
						obj.Staff_LocalAddress="";
					else
						obj.Staff_LocalAddress=txtloaddress.Text;
					
					if(DropCity1.SelectedItem.Value=="---Select---")
						obj.Staff_LocalCity="";
					else
						obj.Staff_LocalCity=DropCity1.SelectedItem.Value.ToString().Trim();
					
					if(DropState1.SelectedItem.Value=="---Select---")
						obj.Staff_LocalState="";
					else
						obj.Staff_LocalState=DropState1.SelectedItem.Value.ToString().Trim();
				
					if(DropCountry1.SelectedItem.Value.ToString().Trim()=="---Select---")
						obj.Staff_LocalCountry="";
					else
						obj.Staff_LocalCountry=DropCountry1.SelectedItem.Value.ToString().Trim();
				
					if(txtlpin.Text=="")
						obj.Staff_LocalPincode=0;
					else
						obj.Staff_LocalPincode=Convert.ToInt32(txtlpin.Text.ToString().Trim());
					
					if(txtemail.Text=="")
						obj.Staff_EmailID="";
					else
						obj.Staff_EmailID=txtemail.Text;
					
					if(txtsphone.Text=="")
						obj.Phone_No="";
					else
						obj.Phone_No=txtsphone.Text;
				
					if(txtsmobile.Text=="")
						obj.Mobile_No="";
					else
						obj.Mobile_No=txtsmobile.Text;
						
					# region multiselect list box items
					int iCount2=lstSubject.Items.Count; 
					string[] sSubject=new string[iCount2];
					int j2=0;
								
					for(int i=0;i<iCount2;i++)
					{		
						if(lstSubject.Items[i].Selected==true && chkTeaching.Checked==true)
						{
							sSubject[j2]=lstSubject.Items[i].Text.ToString().Trim();
							j2++;
						}
					}
					if(j2==0)
					{
						obj.Subject_Take="";
					}
					else
					{
						string sSubjectName="";
						for(int k=0;k<j2;k++)
						{
							sSubjectName=sSubjectName+","+sSubject[k];
						}
						int x=sSubjectName.IndexOf(",");
						x=x+1;
						string sTeacherSub=sSubjectName.Substring(x,sSubjectName.Length-1);
						obj.Subject_Take=sTeacherSub;
					}
								
					# endregion
					    			
					if(txtFatherName.Text=="")
						obj.Father_Name="";
					else
						obj.Father_Name=txtFatherName.Text.Trim();
  		
					if(txtprofequa.Text=="")	
						obj.Professional_Qualification="";
					else
						obj.Professional_Qualification=txtprofequa.Text;
 				
					if(txtage.Text=="")
						obj.Age="0";
					else
						obj.Age=GenUtil.str2MMDDYYYY(txtage.Text.Trim());
 				
					if(Dropsex.SelectedItem.Value=="---Select---")
						obj.Sex="";
					else
						obj.Sex=Dropsex.SelectedItem.Value.ToString().Trim();
			
					if(Dropmstatus.SelectedItem.Value=="---Select---")
						obj.Maritial_Status="";
					else
						obj.Maritial_Status=Dropmstatus.SelectedItem.Value.ToString().Trim();
								
					if(txtperacno.Text=="")
						obj.Permanent_Accountno=0;
					else
						obj.Permanent_Accountno=Convert.ToInt64(txtperacno.Text);
				
					if(txtdojoin.Text=="")
						obj.Date_of_joining="";
					else
						obj.Date_of_joining=GenUtil.str2MMDDYYYY(txtdojoin.Text);
				
					if(txtepfacno.Text=="")
						obj.EPF_Accountno="";
					else
						obj.EPF_Accountno=Convert.ToString(txtepfacno.Text);
													
					if(txtstaffeducation.Text=="")
						obj.Staff_education="";
					else
						obj.Staff_education=txtstaffeducation.Text;
					
					if(Dropstaffexp.SelectedIndex==0)
						obj.Staff_exp=0;
					else
						obj.Staff_exp=Convert.ToInt32(Dropstaffexp .SelectedItem.Value.ToString());
					# region Cases Staff type check box
					if(chkTeaching.Checked==true)
					{
						obj.teaching=true;
						obj.nonteaching=false;
						obj.groupd =false;
						obj.activity =false;
					}
					if(chkNonTeaching.Checked==true)
					{
						obj.teaching=false;
						obj.nonteaching=true;
						obj.activity =false;
						obj.groupd =false;  
					}

					if(chkGroupD.Checked==true) 
					{
						obj.groupd =true;
						obj.teaching=false;
						obj.nonteaching=false;
						obj.activity =false;
					}
					if(chkactivity.Checked==true)
					{
						obj.groupd =false;
						obj.teaching=false;
						obj.nonteaching=false;
						obj.activity =true;
					}
					# endregion
					
					if(Textbox1.Text.Equals (""))
						obj.driver_lic_no ="";
					else
						obj.driver_lic_no =Textbox1.Text.ToString ();
					
					if(Textbox2.Text.Equals (""))
						obj.validity  ="";
					else
						obj.validity =GenUtil.str2MMDDYYYY (Textbox2.Text .ToString ());
					
					if(Textbox3.Text .Equals (""))
						obj.lic_policy_no ="";
					else
						obj.lic_policy_no =Textbox3.Text .ToString ();
					
					if(Textbox4.Text .Equals (""))
						obj.lic_validity="";
					else
						obj.lic_validity =GenUtil.str2MMDDYYYY(Textbox4.Text .ToString ());
					obj.activity=chkactivity.Checked;
					
					obj.NatureApp=DropNatApp.SelectedItem.Text;
					obj.studentphoto=studentphoto.Value;
					obj.insertStaffInformation();                                                         ///Insert the Employee information into the database.
					ledgercreation();
					CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnSave_Click. New Employee: " + txtstaffname.Text + " saved. User: " + pass );
					clear();                                                                              ///Call method for clear the form.
					callfalse();
					fillID();
					MessageBox.Show("Employee Record Successfully Saved");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this Method use to save in formation in to ledger_master table and create the ledger.
		/// </summary>
		public void ledgercreation()
		{
			try
			{
				nextLedgerid();
				SqlCommand scom=new SqlCommand();
				scom.CommandType=CommandType.StoredProcedure;
				scom.CommandText="EmpLedgerCreation1";
				scom.Connection=scon;
				scom.Parameters.Add("@Ledger_name",txtstaffname.Text.Trim());
				scom.Parameters.Add("@Opbalance","0");
				scom.Parameters.Add("@BalType","Dr");
				scom.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
                MessageBox.Show(ex.Message);
			}

		}
		static string ledger_id="0";

		/// <summary>
		/// This method use to generate the next ledger id from ledger_master table.
		/// </summary>
		public string nextLedgerid()
		{
			try
			{
				string str="Select max(Ledger_id)+1 from Ledger_Master";
				SqlCommand scom=new SqlCommand(str,scon);
				SqlDataReader sdtr=scom.ExecuteReader();
				if(sdtr.HasRows)
				{
					while(sdtr.Read())
					{
						ledger_id=sdtr.GetValue(0).ToString();
						if(ledger_id.Trim().Equals(""))
						{
							ledger_id="1001";
						}
                     }
				}
				scom.Dispose();
				sdtr.Close();
				return ledger_id;
			}
			catch(Exception ex)
			{
                 return ledger_id;
			}
		}

		
		/// <summary>
		/// This method use to Clear the form.
		/// </summary>
		public void clear()
		{
				
			txtFatherName.Text="";
			txtprofequa.Text="";
			txtage.Text="";
			Dropsex.SelectedIndex=0;
			Dropmstatus.SelectedIndex=0;
			txtperacno.Text="";
			txtdojoin.Text="";
			txtepfacno.Text="";
			DropType.SelectedIndex=0;
			ImgUrl1.ImageUrl="";
			DropCountry.SelectedIndex=0;
			txtstaffname.Text="";
			txtpaddress.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry.SelectedIndex=0;
			txtppin.Text="";
			txtloaddress.Text="";
			DropCity1.SelectedIndex=0;
			DropState1.SelectedIndex=0;
			DropCountry1.SelectedIndex=0;
			txtlpin.Text="";
			txtemail.Text="";
			txtsphone.Text="";
			txtsmobile.Text="";
			txtstaffeducation.Text="";
			Dropstaffexp.SelectedIndex=0 ;
			chkTeaching.Checked=false;
			chkNonTeaching.Checked=false;
			chkGroupD .Checked =false;
			chkactivity .Checked =false;
			int iCount=lstSubject.Items.Count;
			lstSubject.SelectedIndex=0;
			lstSubject.Items[0].Selected=false;
			Textbox1.Text ="";
			Textbox2.Text ="";
			Textbox3.Text ="";
			Textbox4.Text ="";
            if (DropEmpID.SelectedIndex >= 0)
            {
                DropEmpID.SelectedIndex = 0;                
            }
            DropNatApp.SelectedIndex = 0;            
			txtage.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtdojoin.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;			
		}
		
		/// <summary>
		/// This method use to Reset form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			try
			{
				DropEmpID.Visible=false;
				panDriver.Visible=false;
				lblEmpID.Visible=true;	
				clear();
				CreateLogFiles.ErrorLog("Form: Staffname.aspx.cs, Method: BtnReset_Click. User: " + pass );
			}
			catch(Exception Ex)	
			{
			    CreateLogFiles.ErrorLog("Form: Staffname.aspx.cs, Method: BtnReset_Click. Exception: " + Ex.Message + " User: " + pass );
			}
		}
	
		/// <summary>
		/// This Method use to fill the type of staff according to selected value of redio button.
		/// </summary>
		public void staffType()
		{
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtrclass3;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();

				if(chkTeaching.Checked==true)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where teaching=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					lblSub.Visible =true;
					lstSubject.Visible =true;
					lblExp.Visible =true;
					Dropstaffexp.Visible =true; 
				}

				if(chkNonTeaching.Checked==true)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where nonteaching=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					lblSub.Visible =false;
					lstSubject.Visible =false;
					lblExp.Visible =true;
					Dropstaffexp.Visible =true; 
				}

				if(chkGroupD.Checked==true)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where groupd=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					lblSub.Visible =false;
					lstSubject.Visible =false;
					lblExp.Visible =true;
					Dropstaffexp.Visible =true; 
				}

				if(chkactivity.Checked==true)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where activity=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					lblSub.Visible =false;
					lstSubject.Visible =false;
					lblExp.Visible =true;
					Dropstaffexp.Visible =true; 
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: staffType. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		

	
		/// <summary>
		/// This method use to call the stafftype() function.
		/// </summary>
		private void chkTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType(); 
		}
		 
		/// <summary>
		/// This method use to call the stafftype() function.
		/// </summary>
		private void chkNonTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
		}
		
		/// <summary>
		/// This method use to select value of dropstate and dropcountry dropdown according to dropcity. but now this
		/// working by javascript.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				scom=new SqlCommand("Select country, state from Country where city='" + DropCity.SelectedItem.Value.ToString () + "' order by state",scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(sdtr.GetValue(1).ToString()))));
					DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(sdtr.GetValue(0).ToString()))));
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form: Staffname.aspx.cs, Method: DropCity_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to select value of dropstate1 and dropcountry1 dropdown according to dropcity.but now this
		/// working by javascript.
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
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: DropCity1_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to fill the edit dropdown with save id of staff_information.
		/// </summary>
		private void DropType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropType.SelectedIndex ==0)
			{
				MessageBox.Show ("Select Staff Designation");
				return;
			}
			else if(DropType.SelectedItem.Value .ToString ().Equals ("Driver"))
			{
				panDriver.Visible=true;
				Label19.Visible =true;
				Label20.Visible =true;
				Label21.Visible =true;
				Label22.Visible =true;
				Textbox1.Visible =true; 
				Textbox2.Visible =true;
				Textbox3.Visible =true;
				Textbox4.Visible =true;
				Textbox1.Text = "";
				Textbox2.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;    
				Textbox4.Text = System.DateTime.Now.Day+"/"+System.DateTime.Now.Month+"/"+System.DateTime.Now.Year ;   
				Textbox3.Text = "";
			}
			else
			{
				panDriver.Visible=false;
				Label19.Visible =false;
				Label20.Visible =false;
				Label21.Visible =false;
				Label22.Visible =false;
				Textbox1.Visible =false; 
				Textbox2.Visible =false;
				Textbox3.Visible =false;
				Textbox4.Visible =false;
			}
			if(btnSave.Enabled==false)
			{
				lblEmpID.Visible=false;
				DropEmpID.Visible=true;
				SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				SqlCommand cmd=new SqlCommand("select staff_id,staff_name from staff_information where staff_type='"+DropType.SelectedItem.Text+"'",con);
				SqlDtr=cmd.ExecuteReader();
				DropEmpID.Items.Clear();
				DropEmpID.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropEmpID.Items.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());
				}
				SqlDtr.Close();
				con.Close();
			}
		}
	
		/// <summary>
		/// This method use to call the stafftype() function.
		/// </summary>
		private void chkGroupD_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
		}

		private void btnedit_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This Method use to update the information of staff.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			btnSave.Enabled=false;
			if(btnEdit.Text=="Edit")
				btnEdit.Text="Update";
			else 
			{
				try
				{
					if(DropEmpID.SelectedIndex==0 || DropEmpID.SelectedIndex==-1)
						{
							MessageBox.Show("Please select The Employee Name");
							return;
						}
					btnEdit.Text="Edit";
					int j=0;
					if(chkTeaching.Checked==true)
					{
						int iCount=lstSubject.Items.Count;
						for(int i=0;i<iCount;i++)
						{		
							if(lstSubject.Items[i].Selected==true && chkTeaching.Checked==true)
							{
								j++;
							}
						}
					}
					SchoolClass.regis obj=new SchoolClass.regis();
					string Emp=DropEmpID.SelectedItem.Text;
					string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
					obj.Staff_ID=EmpName[0].ToString();
					string staff_id=EmpName[0].ToString();
					if(DropType.SelectedIndex==0)
						obj.Staff_Type="";
					else
						obj.Staff_Type=DropType .SelectedItem.Value.ToString();
					if(txtstaffname.Text=="")
						obj.Staff_Name="";
					else
						obj.Staff_Name=txtstaffname.Text.Trim();
					if(txtpaddress.Text=="")
						obj.Staff_PerAddress="";
					else
						obj.Staff_PerAddress =txtpaddress.Text;
					if(DropCity.SelectedItem.Value=="---Select---")
						obj.Staff_PerCity="";
					else
						obj.Staff_PerCity=DropCity.SelectedItem.Value.ToString().Trim();
					if(DropState.SelectedItem.Value=="---Select---")
						obj.Staff_PerState="";
					else
						obj.Staff_PerState=DropState.SelectedItem.Value.ToString().Trim();
					if(DropCountry.SelectedItem.Value.ToString().Trim()=="---Select---")
						obj.Staff_PerCountry="";
					else
						obj.Staff_PerCountry=DropCountry.SelectedItem.Value.ToString().Trim();
					if(txtppin.Text=="")
						obj.Staff_PerPincode=0;
					else
						obj.Staff_PerPincode=Convert.ToInt32(txtppin.Text.ToString().Trim());
					if(txtloaddress.Text=="")
						obj.Staff_LocalAddress="";
					else
						obj.Staff_LocalAddress=txtloaddress.Text;
					if(DropCity1.SelectedItem.Value=="---Select---")
						obj.Staff_LocalCity="";
					else
						obj.Staff_LocalCity=DropCity1.SelectedItem.Value.ToString().Trim();
					if(DropState1.SelectedItem.Value=="---Select---")
						obj.Staff_LocalState="";
					else
						obj.Staff_LocalState=DropState1.SelectedItem.Value.ToString().Trim();
					if(DropCountry1.SelectedItem.Value.ToString().Trim()=="---Select---")
						obj.Staff_LocalCountry="";
					else
						obj.Staff_LocalCountry=DropCountry1.SelectedItem.Value.ToString().Trim();
					if(txtlpin.Text=="")
						obj.Staff_LocalPincode=0;
					else
						obj.Staff_LocalPincode=Convert.ToInt32(txtlpin.Text.ToString().Trim());
					if(txtemail.Text=="")
						obj.Staff_EmailID="";
					else
						obj.Staff_EmailID=txtemail.Text;
					if(txtsphone.Text=="")
						obj.Phone_No="";
					else
						obj.Phone_No=txtsphone.Text;
					if(txtsmobile.Text=="")
						obj.Mobile_No="";
					else
						obj.Mobile_No=txtsmobile.Text;
						
					# region multiselect list box items
					int iCount2=lstSubject.Items.Count; 
					string[] sSubject=new string[iCount2];
					int j2=0;
								
					for(int i=0;i<iCount2;i++)
					{		
						if(lstSubject.Items[i].Selected==true && chkTeaching.Checked==true)
						{
							sSubject[j2]=lstSubject.Items[i].Text.ToString().Trim();
							j2++;
						}
					}
					if(j2==0)
					{
						obj.Subject_Take="";
					}
					else
					{
						string sSubjectName="";
						for(int k=0;k<j2;k++)
						{
							sSubjectName=sSubjectName+","+sSubject[k];
						}
						int x=sSubjectName.IndexOf(",");
						x=x+1;
						string sTeacherSub=sSubjectName.Substring(x,sSubjectName.Length-1);
						obj.Subject_Take=sTeacherSub;
					}
								
					# endregion
					    
					if(txtFatherName.Text=="")
						obj.Father_Name="";
					else
						obj.Father_Name=txtFatherName.Text;
  
					if(txtprofequa.Text=="")	
						obj.Professional_Qualification="";
					else
						obj.Professional_Qualification=txtprofequa.Text;		
					
					if(txtage.Text=="")
						obj.Age="0";
					else
						obj.Age=GenUtil.str2MMDDYYYY(txtage.Text);
 
					if(Dropsex.SelectedItem.Value=="---Select---")
						obj.Sex="";
					else
						obj.Sex=Dropsex.SelectedItem.Value.ToString().Trim();

					if(Dropmstatus.SelectedItem.Value=="---Select---")
						obj.Maritial_Status="";
					else
						obj.Maritial_Status=Dropmstatus.SelectedItem.Value.ToString().Trim();
					if(txtperacno.Text=="")
						obj.Permanent_Accountno=0;
					else
						obj.Permanent_Accountno=Convert.ToInt64(txtperacno.Text);
					if(txtdojoin.Text=="")
						obj.Date_of_joining="";
					else
						obj.Date_of_joining=GenUtil.str2MMDDYYYY(txtdojoin.Text);
					if(txtepfacno.Text=="")
						obj.EPF_Accountno="";
					else
						obj.EPF_Accountno=txtepfacno.Text;
					if(txtstaffeducation.Text=="")
						obj.Staff_education="";
					else
						obj.Staff_education=txtstaffeducation.Text;
					if(Dropstaffexp.SelectedIndex==0)
						obj.Staff_exp=0;
					else
						obj.Staff_exp=Convert.ToInt32(Dropstaffexp .SelectedItem.Value.ToString());
					# region Cases Staff type check box
					if(chkTeaching.Checked==true)
					{
						obj.teaching=true;
						obj.nonteaching=false;
						obj.groupd =false;  
					}

					if(chkNonTeaching.Checked==true)
					{
						obj.teaching=false;
						obj.nonteaching=true;
						obj.groupd =false;  
					}

					if(chkGroupD.Checked==true)  
					{
						obj.groupd =true;
						obj.teaching=false;
						obj.nonteaching=false;
					}
				
					# endregion
					if(Textbox1.Text.Equals (""))
						obj.driver_lic_no ="";
					else
						obj.driver_lic_no =Textbox1.Text.ToString ();
					if(Textbox2.Text.Equals (""))
						obj.validity  ="";
					else
						obj.validity =GenUtil.str2MMDDYYYY (Textbox2.Text .ToString ());
					if(Textbox3.Text .Equals (""))
						obj.lic_policy_no ="";
					else
						obj.lic_policy_no =Textbox3.Text .ToString ();
					if(Textbox4.Text .Equals (""))
						obj.lic_validity="";
					else
						obj.lic_validity =GenUtil.str2MMDDYYYY(Textbox4.Text .ToString ());
					
					obj.NatureApp=DropNatApp.SelectedItem.Text;
					if(studentphoto.Value=="")
						obj.studentphoto=getUrl.Value;
					else
						obj.studentphoto=studentphoto.Value;
					obj.activity=chkactivity.Checked;
					
					string ledger_name="";
					SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					SqlDataReader SqlDtr1; 
					SqlCommand cmd=new SqlCommand("select staff_name from staff_information where staff_ID="+staff_id,con);
					SqlDtr1=cmd.ExecuteReader();
					while(SqlDtr1.Read())
					{
						ledger_name=SqlDtr1.GetValue(0).ToString();
					}
					SqlDtr1.Close();
					cmd.Dispose();
				
					int ii=0,ledg_id=0;
					SqlDataReader SqlDtr2;
					SqlCommand cmd1=new SqlCommand("Select Ledger_id from Ledger_Master where Ledger_Name='"+ledger_name+"' and Sub_Grp_Id=115",con);
                    SqlDtr2=cmd1.ExecuteReader();
					while(SqlDtr2.Read())
					{
					   ledg_id=Convert.ToInt32(SqlDtr2.GetValue(0));
					}
					cmd1.Dispose();
					SqlDtr2.Close();
                    
					string str="Update Ledger_Master set Ledger_Name='"+txtstaffname.Text.Trim()+"' where Ledger_Id="+ledg_id;
					SqlCommand cmd2=new SqlCommand(str,con);
					ii=cmd2.ExecuteNonQuery();
					cmd2.Dispose();
					con.Close();
					if(ii>0)
					{
						obj.insertStaffInformation();                                      //Insert the Employee information into the database.
					}
					CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnSave_Click. New Employee: " + txtstaffname.Text + " saved. User: " + pass );
					clear();                                                           //Call method for clear the form.
					callfalse();
					btnSave.Enabled=true;
					DropEmpID.Visible=false;
					lblEmpID.Visible=true;
					fillID();
					MessageBox.Show("Employee Record Successfully Updated");
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnEdit_Click. Exception: " + ex.Message + " User: " + pass );
				}
			}
		}

		/// <summary>
		/// This method use to Fetch data from Staff_information table.
		/// </summary>
		private void DropEmpID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropEmpID.SelectedIndex!=0)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
			
					string Emp=DropEmpID.SelectedItem.Text;
					string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
					string str="select * from staff_information where staff_id="+EmpName[0]+" and staff_name='"+EmpName[1]+"'";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						txtstaffname.Text=SqlDtr["Staff_Name"].ToString();
						txtFatherName.Text=SqlDtr["father_name"].ToString();
						txtstaffeducation.Text=SqlDtr["Staff_education"].ToString();
						txtprofequa.Text=SqlDtr["prof_qui"].ToString();
						txtage.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["age"].ToString()));
						getUrl.Value=SqlDtr["studentphoto"].ToString(); 
						ImgUrl1.ImageUrl=SqlDtr["studentphoto"].ToString(); 
						txtperacno.Text=SqlDtr["per_acno"].ToString(); 
						txtepfacno.Text=SqlDtr["epf_acno"].ToString(); 
						Dropmstatus.SelectedIndex=Dropmstatus.Items.IndexOf(Dropmstatus.Items.FindByValue(SqlDtr["maritial_status"].ToString()));
						txtdojoin.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["doj"].ToString()));
						DropNatApp.SelectedIndex=DropNatApp.Items.IndexOf(DropNatApp.Items.FindByValue(SqlDtr["natapp"].ToString()));
						txtpaddress.Text=SqlDtr["Staff_PerAddress"].ToString();
						txtppin.Text=SqlDtr["Staff_PerPincode"].ToString();
						DropCity.SelectedIndex=DropCity.Items.IndexOf(DropCity.Items.FindByValue(SqlDtr["Staff_PerCity"].ToString()));
						DropState.SelectedIndex=DropState.Items.IndexOf(DropState.Items.FindByValue(SqlDtr["Staff_PerState"].ToString()));
						DropCountry.SelectedIndex=DropCountry.Items.IndexOf(DropCountry.Items.FindByValue(SqlDtr["Staff_PerCountry"].ToString()));
						txtloaddress.Text=SqlDtr["Staff_LocalAddress"].ToString();
						txtlpin.Text=SqlDtr["Staff_LocalPincode"].ToString();
						DropCity1.SelectedIndex=DropCity1.Items.IndexOf(DropCity1.Items.FindByValue(SqlDtr["Staff_LocalCity"].ToString()));
						DropState1.SelectedIndex=DropState1.Items.IndexOf(DropState1.Items.FindByValue(SqlDtr["Staff_LocalState"].ToString()));
						DropCountry1.SelectedIndex=DropCountry1.Items.IndexOf(DropCountry1.Items.FindByValue(SqlDtr["Staff_LocalCountry"].ToString()));
						txtemail.Text=SqlDtr["Staff_EmailID"].ToString();
						txtsmobile.Text=SqlDtr["Mobile_No"].ToString();
						txtsphone.Text=SqlDtr["Phone_No"].ToString();
						Dropstaffexp.SelectedIndex=Dropstaffexp.Items.IndexOf(Dropstaffexp.Items.FindByValue(SqlDtr["Staff_exp"].ToString()));
						Dropsex.SelectedIndex=Dropsex.Items.IndexOf(Dropsex.Items.FindByValue(SqlDtr["sex"].ToString()));
						lstSubject.SelectedIndex=lstSubject.Items.IndexOf(lstSubject.Items.FindByValue(SqlDtr["Subject_Take"].ToString()));
						Textbox1.Text=SqlDtr["driver_lic_no"].ToString();
						Textbox2.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["validity"].ToString()));
						Textbox3.Text=SqlDtr["lic_policy_no"].ToString();
						Textbox4.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["lic_validity"].ToString()));

					}
					if(DropType.SelectedItem.Text.Equals("Driver"))
						panDriver.Visible=true;
					else
						panDriver.Visible=false;
					if(chkTeaching.Checked==true)
						lstSubject.Visible=true;
					else
						lstSubject.Visible=false;
				}
			}
			catch(Exception ex)
			{
                   CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This method use to delete the record from staff_information table and ledger_master table also.
		/// </summary>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				EmployeeClass obj=new EmployeeClass();
			
				SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				if(DropEmpID.Visible==true)
				{
					string Emp=DropEmpID.SelectedItem.Text;
					string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
					string staff_id=EmpName[0].ToString();

					string ledger_name="";
					SqlDataReader SqlDtr1; 
					SqlCommand cmd4=new SqlCommand("select staff_name from staff_information where staff_ID="+staff_id,con);
					SqlDtr1=cmd4.ExecuteReader();
					while(SqlDtr1.Read())
					{
						ledger_name=SqlDtr1.GetValue(0).ToString();
					}
					SqlDtr1.Close();
					cmd4.Dispose();
					int ii=0,ledg_id=0;
					SqlDataReader SqlDtr2;
					SqlCommand cmd1=new SqlCommand("Select Ledger_id from Ledger_Master where Ledger_Name='"+ledger_name+"' and Sub_Grp_Id=115",con);
					SqlDtr2=cmd1.ExecuteReader();
					while(SqlDtr2.Read())
					{
						ledg_id=Convert.ToInt32(SqlDtr2.GetValue(0));
					}
					cmd1.Dispose();
					SqlDtr2.Close();
					string str="Delete from Ledger_Master where Ledger_Id="+ledg_id;
					SqlCommand cmd2=new SqlCommand(str,con);
					ii=cmd2.ExecuteNonQuery();
					cmd2.Dispose();
					if(ii>0)
					{
						SqlCommand cmd=new SqlCommand("delete from staff_information where staff_id="+EmpName[0],con);
						cmd.ExecuteNonQuery();
					}
					con.Close();
					MessageBox.Show("Employee Record Successfully Deleted");
					fillID();
					clear();
					btnSave.Enabled=true;
					DropEmpID.Visible=false;
					lblEmpID.Visible=true;
					btnEdit.Text="Edit";
				}
				else
				{
					MessageBox.Show("Please Select The Employee Name Form DropDown List");
				}
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnDelete_Click.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: btnDelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			
		}
		/// <summary>
		/// This method not in use. 
		/// </summary>
		private void chkactivity_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void txtepfacno_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}
	
}

