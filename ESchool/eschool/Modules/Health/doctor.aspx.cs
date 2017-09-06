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
using eschool.Classes;
using System.Text;

namespace eschool.Health
{
	/// <summary>
	/// Summary description for doctor.
	/// </summary>
	public class Doctor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textadd;
		protected System.Web.UI.WebControls.TextBox txtphoneoff;
		protected System.Web.UI.WebControls.TextBox txtphoneres;
		protected System.Web.UI.WebControls.TextBox txtmobile;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.ValidationSummary vsDoctor;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.WebControls.TextBox txtregno;
		protected System.Web.UI.WebControls.DropDownList DropSpecial;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.DropDownList Dropedit;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText tempdoctorname;
		protected System.Web.UI.WebControls.Panel pan1;
		protected System.Web.UI.WebControls.Panel pan2;
		protected System.Web.UI.WebControls.Button btnedit1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.TextBox txtdoctor;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiValidation1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.Label lbldocid;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label Label4;

		
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Doctor.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Doctor.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				fillID();
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!IsPostBack)
				{
					btnEdit.Visible=false;
					SqlConnection scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon1.Open();
					//doc();
					SqlDataReader sdtr1;
					SqlCommand scom=new SqlCommand("Select distinct City from Country  order by City asc",scon1);
					sdtr1=scom.ExecuteReader();
					while(sdtr1.Read())
					{
						DropCity.Items.Add(sdtr1.GetString(0));
					}
					sdtr1.Close();
					scon1.Close();
					scon1.Open();
					scom=new SqlCommand("Select distinct state from Country  order by state asc",scon1);
					sdtr1=scom.ExecuteReader();
					while(sdtr1.Read())
					{
						DropState.Items.Add(sdtr1.GetString(0));
					}
					sdtr1.Close();
					scon1.Close();
					scon1.Open();
					scom=new SqlCommand("Select distinct Country from Country  order by Country asc",scon1);
					sdtr1=scom.ExecuteReader();
					while(sdtr1.Read())
					{
						DropCountry.Items.Add(sdtr1.GetString(0));
					}
					sdtr1.Close();
					scom=new SqlCommand("Select Country,State,City from Country order by Country,State,City",scon1);
					sdtr1=scom.ExecuteReader();
					while(sdtr1.Read())
					{
						txtName.Value=txtName.Value+sdtr1.GetValue(0).ToString().Trim()+":"+sdtr1.GetValue(1).ToString().Trim()+":"+sdtr1.GetValue(2).ToString().Trim()+",";
					}
					sdtr1.Close();
					scon1.Close();
					
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="2";
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
				
					#endregion
				}
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  Page_Load, Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  Page_Load,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		
		/// <summary>
		/// Add Existing Roll Name to the dropdownBox.
		/// </summary>
		/*public void doc()
		{
			SqlConnection scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			scon1.Open();
				SqlCommand scom1=new SqlCommand("Select distinct doctor_name from doctor  order by doctor_name",scon1);
				SqlDataReader sdtr1=scom1.ExecuteReader();
				dropDoctor.Items.Clear();
				dropDoctor.Items.Add("---Select---");
						while(sdtr1.Read())
						{
							dropDoctor.Items.Add(sdtr1.GetString(0));
						}
						dropDoctor.Items.Add("Other");
						sdtr1.Close();
						scon1.Close();
		}*/
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
			this.btnedit1.Click += new System.EventHandler(this.btnedit1_Click);
			this.Dropedit.SelectedIndexChanged += new System.EventHandler(this.Dropedit_SelectedIndexChanged);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.ID = "Form1";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		/// <summary>
		/// This method use to Clear the form.
		/// </summary>
		public void Clear()
		{
			//dropDoctor.SelectedIndex=0;
			txtdoctor.Text="";
			Dropedit.SelectedIndex=0;
			Textadd.Text="";
			DropCountry.SelectedIndex=0;
			txtregno.Text="";
			DropState.SelectedIndex=0;
			DropCity.SelectedIndex=0;
			DropSpecial.SelectedIndex=0;
			txtphoneoff.Text="";
			txtphoneres.Text="";
			txtmobile.Text="";
		}
		

	
		/// <summary>
		/// This method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			//Clear();
			//btnSave.Visible=true;
			//btnEdit.Visible = true;
			try
			{
				string sDoctor=Dropedit.SelectedItem.Text.ToString();
				string[] sdocidname=sDoctor.Split(new char[]{':'});
				string sdocid=sdocidname[0].ToString();
				SqlConnection scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				SqlCommand scom1=new SqlCommand("Delete from doctor where docid=@docid",scon1);
				scom1.Parameters.Add("@docid",sdocid.Trim().ToString());
				scom1.ExecuteNonQuery();
				
				scon1.Close();
				//MessageBox.Show("Record Deleted");
				MessageBox.Show("Doctor's Profile Successfully Deleted");
				lbldocid.Visible=true;
				btnedit1.Visible=true;
				btnEdit.Visible=false;
				btnSave.Visible=true;
				Dropedit.Visible=false;
				Clear();
				fillID();	
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  btnDelete_Click, Userid :  "+ pass   );		
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  btnDelete_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}

		}
		

		
		/// <summary>
		/// This method use to  Get Next ID from doctor table
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
				cmd=new SqlCommand("select max(docid)+1 from doctor",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						i=SqlDtr.GetValue(0).ToString ();
						lbldocid.Text=SqlDtr.GetValue(0).ToString ();
						if(i.Trim().Equals(""))
						{
							i="1";
							lbldocid.Text=i.ToString ();
						}
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
		/// this Method Use to save the doctors information in to doctor table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			
			SqlConnection con;
			string strInsert;
			SqlCommand cmdInsert;
			try
			{
                StringBuilder errorMessage = new StringBuilder();
                if (txtdoctor.Text == string.Empty)
                {
                    errorMessage.Append("- Please Enter Docter Name");
                    errorMessage.Append("\n");
                }
                if (DropSpecial.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select Specialization");
                    errorMessage.Append("\n");
                }               
                if (DropCity.SelectedIndex == 0)
                {
                    errorMessage.Append("- Please Select City");
                    errorMessage.Append("\n");
                }
                if (txtmobile.Text != string.Empty)
                {
                    if (txtmobile.Text.Length < 10)
                    {
                        errorMessage.Append("- Mobile No. Between 10 to 12 Digits");
                        errorMessage.Append("\n");
                    }
                }
                if (txtphoneoff.Text != string.Empty)
                {
                    if (txtphoneoff.Text.Length < 6)
                    {
                        errorMessage.Append("- Phone(Off) Must be Between 6-12 Digits");
                        errorMessage.Append("\n");
                    }
                }
                if (txtphoneres.Text != string.Empty)
                {
                    if (txtphoneres.Text.Length < 6)
                    {
                        errorMessage.Append("- Phone(res) Must be Between 6-12 Digits");
                        errorMessage.Append("\n");
                    }
                }
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString());                
                    return;
                }
                con =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				fillID();
				strInsert = "Insert doctor(docid,doctor_name,add1,city,state,country,phone1_off,phone1_res,mobile,regno,specialisation)values (@docid,@doctor_name,@add1,@city,@state,@country,@phone1_off,@phone1_res,@mobile,@regno,@special)";
				cmdInsert=new SqlCommand (strInsert,con);
				cmdInsert.Parameters .Add ("@docid",i.Trim().ToString());
				if(txtdoctor.Text.ToString()=="")
					cmdInsert.Parameters .Add ("@doctor_name","");
				else
					cmdInsert.Parameters .Add ("@doctor_name",txtdoctor.Text.ToString());
				if(Textadd .Text=="")
					cmdInsert.Parameters .Add ("@add1","");
				else
					cmdInsert.Parameters .Add ("@add1",Textadd.Text);
				if(DropCity.SelectedIndex ==0 )
					cmdInsert.Parameters.Add("@city","");
				else
					cmdInsert.Parameters.Add("@city",DropCity.SelectedItem.Value .ToString ());
				if(DropState.SelectedIndex ==0 )
					cmdInsert.Parameters.Add("@state","");
				else
					cmdInsert.Parameters.Add("@state",DropState.SelectedItem.Value .ToString ());
				if(DropCountry.SelectedIndex ==0 )
					cmdInsert.Parameters.Add("@country","");
				else
					cmdInsert.Parameters.Add("@country",DropCountry.SelectedItem.Value .ToString ());
				if(txtregno.Text=="")
					cmdInsert.Parameters .Add ("@regno","");
				else
					cmdInsert.Parameters .Add ("@regno",txtregno.Text);
				if(txtphoneoff.Text=="")
					cmdInsert.Parameters .Add ("@phone1_off","");
				else
					cmdInsert.Parameters .Add ("@phone1_off",txtphoneoff.Text.ToUpper());
				if(txtphoneres.Text=="")
					cmdInsert.Parameters .Add ("@phone1_res","");
				else
					cmdInsert.Parameters .Add ("@phone1_res",txtphoneres.Text.ToUpper());
				if(txtmobile.Text=="")
					cmdInsert.Parameters .Add ("@mobile","");
				else
					cmdInsert.Parameters .Add ("@mobile",txtmobile.Text.ToUpper());
				if(DropSpecial.SelectedIndex ==0)
					cmdInsert.Parameters .Add ("@special","");
				else
					cmdInsert.Parameters .Add ("@special",DropSpecial.SelectedItem.Text.ToString());
				cmdInsert.ExecuteNonQuery();
				//doc();
				CreateLogFiles.ErrorLog(" Form : doctor.aspx, Method  btnSave_Click, doctor_Profile saved for UserID: "+ pass   );
				MessageBox.Show("Doctor's Profile Successfully Saved");
				Clear();
				fillID();
			}	
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
			
		}
		
		/// <summary>
		/// This method use to fill the dropedit by doctorid from doctor table.
		/// </summary>
		private void btnedit1_Click(object sender, System.EventArgs e)
		{
			//pan1.Visible=true;
			//pan2.Visible=false;
			lbldocid.Visible=false;
			Dropedit.Visible=true;
			btnedit1.Visible=false;
			btnEdit.Visible=true;
			btnSave.Visible=false;
			SqlConnection scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			scon1.Open();
			//SqlCommand scom1=new SqlCommand("Select distinct docid,doctor_name from doctor  order by doctor_name",scon1);
			SqlCommand scom1=new SqlCommand("Select distinct docid,doctor_name from doctor  order by docid",scon1);
			SqlDataReader sdtr1=scom1.ExecuteReader();
			Dropedit.Items.Clear();
			Dropedit.Items.Add("---Select---");
			while(sdtr1.Read())
			{
				Dropedit.Items.Add(sdtr1.GetValue(0).ToString()+":"+sdtr1.GetValue(1));
			}
			sdtr1.Close();
			scon1.Close();
		}

		/// <summary>
		/// this Method use to Update Doctor's Information in to doctor table.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{		
			try
			{
				string sDoctor=Dropedit.SelectedItem.Text.ToString();
				string[] sdocidname=sDoctor.Split(new char[]{':'});
				string sdocid=sdocidname[0].ToString();
				string sDoctorName=sdocidname[1].ToString();
				if(sDoctor.Equals("---Select---"))
				{
					MessageBox.Show("Please Select A Dcotor");
				}
				else
				{	
					string DName=txtdoctor.Text.ToString().Trim();
					string sAddr=Textadd.Text.ToString().Trim();
					string sregno=txtregno.Text.ToString().Trim();
					string sResPhone=txtphoneres.Text.ToString().Trim();
					string sOffPhone=txtphoneoff.Text.ToString().Trim();
					string sMobile=txtmobile.Text.ToString().Trim();
					string country = DropCountry.SelectedItem.Value.ToString();
					string state   = DropState.SelectedItem.Value.ToString();
					string city    = DropCity.SelectedItem.Value .ToString ();
					string special = DropSpecial.SelectedItem.Text.ToString ();
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					//SqlCommand scom=new SqlCommand("Update doctor set add1='"+sAddr+"',phone1_off='"+sOffPhone+"',phone1_res='"+sResPhone+"',mobile='"+sMobile+"',country='"+country+"' ,state='"+state+"',city ='"+city+"',regno='"+sregno+"',specialisation='"+special+ "' where doctor_name='"+sDoctor+"'",scon); 
					SqlCommand scom=new SqlCommand("Update doctor set add1='"+sAddr+"',phone1_off='"+sOffPhone+"',phone1_res='"+sResPhone+"',mobile='"+sMobile+"',country='"+country+"' ,state='"+state+"',city ='"+city+"',regno='"+sregno+"',specialisation='"+special+ "',doctor_name='"+DName+"' where docid="+sdocid,scon); 
					scom.ExecuteNonQuery();
					CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  btnUpdate_Click, doctor_Profile Update for UserID: "+ pass   );
					MessageBox.Show("Doctor's Profile Successfully Updated");
					Clear();
					Dropedit.Visible=false;
					btnedit1.Visible=true;
					lbldocid.Visible=true;
					btnEdit.Visible=false;
					btnSave.Visible=true;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  btnUpdate_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void dropDoctor_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		/// <summary>
		/// This method use to Fetch The Doctor's Information From doctor table. 
		/// </summary>
		private void Dropedit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtredit3;
				string dname = Dropedit.SelectedItem.Value;
				
				if(dname.Equals("Other"))
				{
					Textadd.Text="";
					DropCountry.SelectedIndex =0;
					txtregno.Text="";
					DropState.SelectedIndex =0;
					DropCity.SelectedIndex=0;
					DropSpecial.SelectedIndex =0;
					txtphoneoff.Text="";
					txtphoneres.Text="";
					txtmobile.Text="";
					btnEdit.Visible =false;
					btnSave.Visible =true;
				}
				else
				{
					btnSave.Visible =false;
					btnEdit.Visible = true;
				}

				string doctname=Dropedit.SelectedItem.Text.ToString ();
				string[] doctid=doctname.Split(new char[]{':'});
				//MessageBox.Show(doctid[0].ToString());
				//return;

				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				//cmdselect3 = new SqlCommand( "Select add1,phone1_off,phone1_res,mobile,city,state,country,regno,specialisation From doctor where doctor_name=@doctor_name", con3 );
				cmdselect3 = new SqlCommand( "Select add1,phone1_off,phone1_res,mobile,city,state,country,regno,specialisation,doctor_name From doctor where docid=@doctor_id", con3 );
				//cmdselect3.Parameters .Add ("@doctor_name",Dropedit.SelectedItem.Text.ToString ());
				cmdselect3.Parameters .Add ("@doctor_id",doctid[0].ToString());
				dtredit3 = cmdselect3.ExecuteReader();
				while (dtredit3.Read()) 
				{
					txtdoctor.Text=dtredit3.GetValue(9).ToString();
					Textadd.Text=dtredit3.GetValue(0).ToString();
					txtphoneoff.Text=dtredit3.GetValue(1).ToString();
					txtphoneres.Text=dtredit3.GetValue (2).ToString();
					txtmobile.Text=dtredit3.GetValue (3).ToString();
					DropCity.SelectedIndex  = DropCity.Items.IndexOf (DropCity.Items.FindByText(dtredit3.GetValue(4).ToString())); 
					setState(dtredit3.GetValue (4).ToString());
					txtregno.Text = dtredit3.GetValue (7).ToString();
					DropSpecial.SelectedIndex = DropSpecial.Items.IndexOf(DropSpecial.Items.FindByText(dtredit3.GetValue (8).ToString()));  
				}
				dtredit3.Close();
				con3.Close();

				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  dropEdit_SelectedIndexChanged,  Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  dropEdit_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			} 
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		public void setState(string city)
		{
			try
			{
				SqlDataReader SqlDtr = null;
				SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open(); 
				SqlCommand cmd = new SqlCommand("Select State,country from Country where City = '"+city+"'",con);
				SqlDtr = cmd.ExecuteReader();
				while(SqlDtr.Read())
				{
					DropState.SelectedIndex= DropState.Items.IndexOf(DropState.Items.FindByText (SqlDtr.GetValue (0).ToString ()));
					DropCountry.SelectedIndex= DropCountry.Items.IndexOf(DropCountry.Items.FindByText (SqlDtr.GetValue (1).ToString ()));
				}
				SqlDtr.Close();
				con.Close(); 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : doctor.aspx,Method  SetState,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// This method not in use.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setState(DropCity.SelectedItem.Value.ToString());
		}
	}
}


