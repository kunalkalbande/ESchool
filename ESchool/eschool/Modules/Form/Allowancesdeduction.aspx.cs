
     
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
using DBOperations;
# endregion

namespace eschool.Form
{
	/// <summary>
	/// Summary description for Allowancesdeduction.
	/// </summary>
	public class Allowancesdeduction : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox txthra;
		protected System.Web.UI.WebControls.TextBox txtpf;
		protected System.Web.UI.WebControls.TextBox txtta;
		protected System.Web.UI.WebControls.TextBox txttax;
		protected System.Web.UI.WebControls.TextBox txtda;
		protected System.Web.UI.WebControls.TextBox txtothertax;
		protected System.Web.UI.WebControls.TextBox txtcca;
		protected System.Web.UI.WebControls.TextBox txtMedical;
		protected System.Web.UI.WebControls.TextBox txtincrement;
		protected System.Web.UI.WebControls.TextBox txtbenefits;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ValidationSummary vsEmpAllowancesDeduction;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtSalary;
		protected System.Web.UI.WebControls.TextBox txtsec;
		protected System.Web.UI.WebControls.TextBox txtpenDeduction;
		protected System.Web.UI.WebControls.TextBox txtArrears;
		protected System.Web.UI.WebControls.TextBox TxtDtFrom;
		protected System.Web.UI.WebControls.TextBox TxtDtTo;
		protected System.Web.UI.WebControls.DropDownList DropEdit;
		protected System.Web.UI.WebControls.Panel Panaledit;
		protected System.Web.UI.WebControls.Button ButtnEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.CompareValidator comvalid1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnSave;
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
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: Page_Load.  User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"./HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					TxtDtFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtDtTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				}

				# region Fill all the staff ID and Name into the dropdownBox.
				if(!Page.IsPostBack)
				{					 
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrall;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					//15.10.08cmdselect = new SqlCommand( "Select staff_ID,staff_name from Staff_Information", con );
					cmdselect = new SqlCommand( "Select staff_ID,staff_name from Staff_Information order by staff_name", con );
					dtrall = cmdselect.ExecuteReader();
					while(dtrall.Read())
					{
						//15.10.08Dropdownlist1.Items.Add(dtrall.GetValue(0).ToString()+":"+dtrall.GetValue(1).ToString());
						Dropdownlist1.Items.Add(dtrall.GetValue(1).ToString()+":"+dtrall.GetValue(0).ToString());
					}
					dtrall.Close();
					con.Close ();
					     
				}
				# endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
			#region Check Privileges
			if(! IsPostBack)
			{
				
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="3";
				string SubModule="4";
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
			this.Dropdownlist1.SelectedIndexChanged += new System.EventHandler(this.Dropdownlist1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.ButtnEdit.Click += new System.EventHandler(this.ButtnEdit_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		# region Dropdownlist1_SelectedIndexChanged...Method for filling the staff name into the textbox.
		/// <summary>
		/// not in use.
		/// </summary>
		private void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
    	}
		# endregion

		
		/// <summary>
		/// This Method get date as a string and return date into the MMDDYYYY format.
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
		/// This Method calculate total of all allowances and return. value take from textboxes.
		/// </summary>
		public double totalAllowances()
		{
			 	double ihra=0,iarr=0,icca=0,idda=0,ita=0;
				if(!txthra.Text.Trim().Equals(""))
					ihra=Convert.ToDouble(txthra.Text.Trim().ToString());
				if(!txtArrears.Text.Trim().Equals(""))
					iarr=Convert.ToDouble(txtArrears.Text.Trim().ToString());
				if(!txtcca.Text.Trim().Equals(""))
					icca=Convert.ToDouble(txtcca.Text.Trim().ToString());
			    if(!txtda.Text.Trim().Equals(""))
					idda=Convert.ToDouble(txtda.Text.Trim().ToString());
			    double Bas_Sal=Convert.ToDouble(txtSalary.Text);
		     	double Da=(Bas_Sal*idda)/100;
			    if(!txtta.Text.Trim().Equals(""))
				ita=Convert.ToDouble(txtta.Text.Trim().ToString());
				double iMedical;
				if(txtMedical.Text=="")
				{
					iMedical=0;
				}
				else
				{	
					iMedical=Convert.ToDouble(txtMedical.Text.Trim().ToString());
				}
				
			      double iTotalAllowances=(ihra+icca+Da+ita+iMedical+iarr);
              
				return iTotalAllowances;		
			
		}

		/// <summary>
		/// This Method calculate total of all deduction and return. value take from textboxes.
		/// </summary>
		public double totalDeduction()
		{
			double ipf=0,itax=0,iothertax=0,isec=0,ipenDeduction=0;
			
			if(txtpf.Text.Trim().Equals(""))
				ipf=0;
			else
				ipf=Convert.ToDouble(txtpf.Text.Trim().ToString());
           
			double basic=0;
			
			if(txtSalary.Text!="" && txtda.Text!="")
				basic=((double.Parse(txtSalary.Text)+double.Parse(txtda.Text))*ipf)/100;
			ipf=basic;
			
			if(txttax.Text.Trim().Equals(""))
				itax=0;
			else
				itax=Convert.ToDouble(txttax.Text.Trim().ToString());
			
			if(txtothertax.Text.Equals(""))
				iothertax=0;
			else
				iothertax=Convert.ToDouble(txtothertax.Text.Trim().ToString());
			if(!txtsec.Text.Equals(""))
				isec=Convert.ToDouble(txtsec.Text.Trim().ToString());
			if(!txtpenDeduction.Text.Equals(""))
				ipenDeduction=Convert.ToDouble(txtpenDeduction.Text.Trim().ToString());
			
			double ibenefits;
			if(txtbenefits.Text=="")
			{
				ibenefits=0;
			}
			else
			{	
				ibenefits=Convert.ToDouble(txtbenefits.Text.Trim().ToString());
			}
			
			if(txtothertax.Text=="")
			{
				iothertax=0;
			}
			else
			{
				iothertax=Convert.ToDouble(txtothertax.Text.Trim().ToString());
			}
			double iTotalDeduction=(ipf+itax+iothertax+isec+ipenDeduction+ibenefits);
			return iTotalDeduction;
		}
	
		/// <summary>
		/// This Method calculate total of all Increments and return. value take from textboxes.
		/// </summary>
		public double totalIncrements()
		{
			double iIncrements;
			if(txtincrement.Text=="")
			{
				iIncrements=0;
			}
			else
			{
				iIncrements=Convert.ToDouble(txtincrement.Text.Trim().ToString());
			}
			
			
			double iTotalIncrements=(iIncrements);
			return iTotalIncrements;
		}
      
		
		/// <summary>
		/// This Method use to Clear all the controls value.
		/// </summary>
		public void Clear()
		{	
			txtSalary.Text="";
			txthra.Text="";
			txtArrears.Text="";
			txtta.Text="";
			txtda.Text="";
			txtcca.Text="";
			txtMedical.Text="";
			txtbenefits.Text="";
			txtpf.Text="";
			txttax.Text="";
			txtothertax.Text="";
			txtpenDeduction .Text ="";
			txtsec.Text ="";
			txtincrement.Text="";
			TxtDtFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtDtTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}
		
		/// <summary>
		/// This Method use to Reset the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panaledit.Visible=false;
				Dropdownlist1.SelectedIndex=0;
				btnSave.Visible=true;
				btnUpdate.Visible=false;
				Clear();
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: ButnReset_Click.  User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: ButnReset_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// This method use to generate Next Salary_ID from Allowancesdeduction table.
		/// </summary>
		string i="";
		public void getSalary_ID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(Salary_ID)+1 from Allowancesdeduction",con);
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
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
    	/// <summary>
		/// Method used for saving the salary Records in Allowancesdeduction table for a particular record.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SqlConnection con1;
			SqlDataReader dtr=null,sdtr=null;
			string strInsert1="";
			SqlCommand cmdInsert1;
			int icount=0;

			//string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
			//if(DateTime.Compare(ToMMddYYYY(sSysDate),ToMMddYYYY(TxtDtFrom.Text))>0)
			//{
			//	MessageBox.Show("'Date From' must be greater than or equal to current date");
			//}
			//else
			//{
				if(DateTime.Compare(ToMMddYYYY(TxtDtTo.Text),ToMMddYYYY(TxtDtFrom.Text))>=0)
				{
					try
					{
						if(Dropdownlist1.SelectedIndex!=0 && txtSalary.Text!="")
						{
							string datefrom=ToMMddYYYY(TxtDtFrom.Text).ToString();
							string dateto=ToMMddYYYY(TxtDtTo.Text).ToString();
							string sid=Dropdownlist1.SelectedItem.Text;
							string[] staff=sid.Split(new char[] {':'},sid.Length);
							con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							con1.Open ();
							//15.10.08strInsert1="select count(*) from Allowancesdeduction where Staff_ID="+staff[0].ToString()+" and (fromdt>='"+datefrom+"'and fromdt<='"+datefrom+"' or todt>='"+dateto+"'and todt<='"+dateto+"')";
							strInsert1="select count(*) from Allowancesdeduction where Staff_ID="+staff[1].ToString()+" and (fromdt>='"+datefrom+"'and fromdt<='"+datefrom+"' or todt>='"+dateto+"'and todt<='"+dateto+"')";
							cmdInsert1=new SqlCommand (strInsert1,con1);
							sdtr=cmdInsert1.ExecuteReader();
							if(sdtr.Read())
							{
								icount=Convert.ToInt32( sdtr.GetValue(0));
							}
							sdtr.Close();
							cmdInsert1.Dispose();
							if(icount>0)
							{
								MessageBox.Show("Salary Allready Exist for this Period");
							}
							else
							{
								double iBasic,iAllowances,iDeduction,iIncrements;
								getSalary_ID();
								if(txtSalary.Text!="")
								{
									iBasic=Convert.ToDouble(txtSalary.Text);
								}
								else
								{
									iBasic=0;
								}
								iAllowances=totalAllowances();
								iDeduction=totalDeduction();
								iIncrements=totalIncrements();
								double iGrossTotal=iBasic+iAllowances+iIncrements;
								double iNetSal=iGrossTotal-iDeduction;
								string msg="";
								strInsert1 = "Insert Allowancesdeduction(Salary_ID,Staff_ID,Basic_salary,allowances_hra,allowances_ta,allowances_da,allowances_cca,allowances_medical, allowances_benefits,allowances_total,Deduction_pf,Deduction_tax,Deduction_other,Deduction_total,Increment,G_total,Net_Sal,fromdt,todt,security,pendedu,arrears)values (@Salary_ID,@Staff_ID,@Basic_salary,@allowances_hra,@allowances_ta,@allowances_da,@allowances_cca,@allowances_medical,@allowances_benefits," + iAllowances + ",@Deduction_pf,@Deduction_tax,@Deduction_other," + iDeduction + ",@Increment," + iGrossTotal + "," + iNetSal + ",@fromdt,@todt,@security,@pendedu,@Arrears)";
								msg="Saved";
								cmdInsert1=new SqlCommand (strInsert1,con1);
								cmdInsert1.Parameters .Add ("@Salary_ID",i.Trim().ToString());
								if(Dropdownlist1.SelectedIndex ==0)
									cmdInsert1.Parameters .Add ("@Staff_ID","");
								else
									cmdInsert1.Parameters .Add("@Staff_ID",staff[1]);
									//cmdInsert1.Parameters .Add("@Staff_ID",staff[0]);
								if(txtSalary .Text=="")
									cmdInsert1.Parameters .Add ("@Basic_salary","");
								else
									cmdInsert1.Parameters .Add("@Basic_salary",int .Parse (txtSalary.Text.Trim().ToUpper()));
								if(txthra .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_hra","");
								else
									cmdInsert1.Parameters .Add ("@allowances_hra",txthra.Text.Trim().ToUpper());
								if(txtta .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_ta","");
								else
									cmdInsert1.Parameters .Add ("@allowances_ta",txtta.Text.Trim().ToUpper());
								if(txtda .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_da","");
								else
									cmdInsert1.Parameters .Add ("@allowances_da",txtda.Text.Trim().ToUpper());
								if(txtcca .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_cca","");
								else
									cmdInsert1.Parameters .Add ("@allowances_cca",txtcca.Text.Trim().ToUpper());
								if(txtMedical .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_medical","");
								else
									cmdInsert1.Parameters .Add ("@allowances_medical",txtMedical.Text.Trim().ToUpper());
								if(txtbenefits .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_benefits","");
								else
									cmdInsert1.Parameters .Add ("@allowances_benefits",txtbenefits.Text.Trim().ToUpper());
								if(txtpf .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_pf","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_pf",txtpf.Text.Trim().ToUpper());
								if(txttax .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_tax","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_tax",txttax.Text.Trim().ToUpper());
								if(txtothertax .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_other","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_other",txtothertax.Text.Trim().ToUpper());
								if(txtsec .Text=="")
									cmdInsert1.Parameters .Add ("@security","");
								else
									cmdInsert1.Parameters .Add ("@security",txtsec.Text.Trim().ToUpper());

								if(txtpenDeduction .Text=="")
									cmdInsert1.Parameters .Add ("@pendedu","");
								else
									cmdInsert1.Parameters .Add ("@pendedu",txtpenDeduction.Text.Trim().ToUpper());
								if(txtArrears.Text=="")
									cmdInsert1.Parameters .Add ("@Arrears","");
								else
									cmdInsert1.Parameters .Add ("@Arrears",txtArrears.Text.Trim().ToUpper());

								if(txtincrement .Text=="")
									cmdInsert1.Parameters .Add ("@Increment","");
								else
									cmdInsert1.Parameters .Add ("@Increment",txtincrement.Text.Trim().ToUpper());
								cmdInsert1.Parameters .Add ("@iAllowances",iAllowances);
								cmdInsert1.Parameters .Add ("@iDeduction",iDeduction);
								cmdInsert1.Parameters .Add ("@iGrossTotal",iGrossTotal);
								cmdInsert1.Parameters .Add ("@iNetSal",iNetSal);
								cmdInsert1.Parameters .Add ("@fromdt",GenUtil.str2MMDDYYYY(TxtDtFrom.Text.Trim().ToString()));
								cmdInsert1.Parameters .Add ("@todt",GenUtil.str2MMDDYYYY(TxtDtTo.Text.Trim().ToString()));
								cmdInsert1.ExecuteNonQuery();
								con1.Close ();
								MessageBox.Show("Allowances Deduction " + msg ); 
								CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: btnSave_Click.  User: " + pass );
								Clear();
								Dropdownlist1.SelectedIndex =0; 
							}
						}
						else
						{
							MessageBox.Show("You must be select the Employee Name and Enter The Basic Salary   ");
						}
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
					}
				}
				else
				{
					MessageBox.Show("'Date To' must be greater than or equal to 'Date From'");
				}
			//}
		}

		private void txtMedical_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txttodt_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// This Method use to fetch the salary id from Allowancesdeduction table. and fill in drop down.
		/// </summary>
		private void ButtnEdit_Click(object sender, System.EventArgs e)
		{
			Panaledit.Visible=true;
			btnUpdate.Visible=true;
			btnSave.Visible=false;
			try
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader dtrall;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select Salary_ID,Staff_ID from Allowancesdeduction", con );
				dtrall = cmdselect.ExecuteReader();
				DropEdit.Items.Clear();
				DropEdit.Items.Add("Select");
				while(dtrall.Read())
				{
					DropEdit.Items.Add(dtrall.GetValue(0).ToString()+":"+dtrall.GetValue(1).ToString());
				}
				dtrall.Close();
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: ButnEdit_Click.  User: " + pass );
			}
			catch(Exception ex)
			{
                CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: ButnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// Fetch Data From Database Based on Salary id.show all data with help of controls.
		/// </summary>
		private void DropEdit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				btnSave.Text ="Save"; 
				SqlConnection con3;
				SqlCommand cmdselect3;
				string Staff_name="";
				SqlDataReader dtredit3=null,dtredit4=null;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				Clear ();
				string sid=DropEdit.SelectedItem.Text;
				string[] staff=sid.Split(new char[] {':'},sid.Length); 
				cmdselect3 = new SqlCommand( "Select * from allowancesdeduction where Salary_id='" + staff[0] + "'" , con3 );
				dtredit3=cmdselect3.ExecuteReader ();
				if(dtredit3.HasRows )
				{
					if(dtredit3.Read ())
					{
						dtredit4=obj.GetRecordSet("select staff_name from Staff_Information where staff_id="+dtredit3.GetValue(1).ToString());
						if(dtredit4.Read())
						{
							Staff_name=dtredit4.GetValue(0).ToString();
						}
						dtredit4.Close();
						Dropdownlist1.SelectedIndex=Dropdownlist1.Items.IndexOf(Dropdownlist1.Items.FindByValue(Staff_name+":"+dtredit3.GetValue(1).ToString()));
						//Dropdownlist1.SelectedIndex=Convert.ToInt32(dtredit3.GetValue(1).ToString());
						//MessageBox.Show(dtredit3.GetValue(1).ToString());
						txtSalary .Text=dtredit3.GetValue (2).ToString ();
						txthra .Text=dtredit3.GetValue (3).ToString ();
						txtta .Text=dtredit3.GetValue (4).ToString ();
						txtda .Text=dtredit3.GetValue (5).ToString ();
						txtcca .Text=dtredit3.GetValue (6).ToString ();
						txtMedical .Text=dtredit3.GetValue (7).ToString ();
						txtbenefits .Text=dtredit3.GetValue (8).ToString ();
						txtpf .Text=dtredit3.GetValue (10).ToString ();
						txttax .Text=dtredit3.GetValue (11).ToString ();
						txtothertax .Text=dtredit3.GetValue (12).ToString ();
						txtincrement .Text=dtredit3.GetValue (14).ToString ();
						txtArrears.Text=dtredit3["arrears"].ToString();
						TxtDtFrom.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dtredit3.GetValue (17).ToString ()));
						TxtDtTo.Text=GenUtil.trimDate(GenUtil.str2DDMMYYYY(dtredit3.GetValue (18).ToString ()));
						txtpenDeduction .Text =dtredit3["pendedu"].ToString ();
						txtsec.Text=dtredit3["security"].ToString ();
					}
					//btnSave.Text ="Update"; 
				}
				else
				{
					//btnSave .Text ="Save";
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: Dropdownlist1_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// This Method use to update the information of Allowancesdeduction table.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
			//if(DateTime.Compare(ToMMddYYYY(sSysDate),ToMMddYYYY(TxtDtFrom.Text))>0)
			//{
			//	MessageBox.Show("'Date From' must be greater than or equal to current date");
			//}
			//else
			//{
				if(DateTime.Compare(ToMMddYYYY(TxtDtTo.Text),ToMMddYYYY(TxtDtFrom.Text))>=0)
				{
					
					SqlConnection con1;
					SqlDataReader dtr=null,sdtr=null;
					int icount=0;
					string strInsert1="";
					SqlCommand cmdInsert1;
					con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					
					string sid=DropEdit.SelectedItem.Text;
					string[] staff=sid.Split(new char[] {':'},sid.Length);
					string empid=Dropdownlist1.SelectedValue.ToString().Trim();
					string[] employee=empid.Split(new char[] {':'},empid.Length);
					//MessageBox.Show(employee[0].ToString()+" : "+employee[1].ToString());
					//return;


					string datefrom=ToMMddYYYY(TxtDtFrom.Text).ToString();
					string dateto=ToMMddYYYY(TxtDtTo.Text).ToString();
					try
					{
						con1.Open ();
						if(DropEdit.SelectedIndex!=0)
						{
							/*strInsert1="select count(*) from Allowancesdeduction where Staff_ID="+staff[1].ToString()+" and (fromdt>='"+datefrom+"'and fromdt<='"+datefrom+"' or todt>='"+dateto+"'and todt<='"+dateto+"')";
							cmdInsert1=new SqlCommand (strInsert1,con1);
							sdtr=cmdInsert1.ExecuteReader();
							if(sdtr.Read())
							{
								icount=Convert.ToInt32( sdtr.GetValue(0));
							}
							sdtr.Close();
							cmdInsert1.Dispose();
							if(icount>0)
							{
								MessageBox.Show("Salary Can not Update for this Period");
							}
							else
							{*/
								double iAllowances=totalAllowances();
								double iDeduction=totalDeduction();
								double iIncrements=totalIncrements();
								double iBasic=Convert.ToDouble(txtSalary.Text);
								double iGrossTotal=iBasic+iAllowances+iIncrements;
								double iNetSal=iGrossTotal-iDeduction;
								string msg="";
							
								
								strInsert1 = "update Allowancesdeduction set Staff_ID=@Staff_ID,Basic_salary=@Basic_salary,allowances_hra=@allowances_hra,allowances_ta=@allowances_ta,allowances_da=@allowances_da,allowances_cca=@allowances_cca,allowances_medical=@allowances_medical, allowances_benefits=@allowances_benefits,allowances_total=@iAllowances,Deduction_pf=@Deduction_pf,Deduction_tax=@Deduction_tax,Deduction_other=@Deduction_other,Deduction_total=@iDeduction,Increment=@Increment,G_total=@iGrossTotal,Net_Sal=@iNetSal,fromdt=@fromdt,todt=@todt,security=@security,pendedu=@pendedu,arrears=@Arrears where Salary_id='" + staff[0] + "'";
								msg="Updated";
								cmdInsert1=new SqlCommand (strInsert1,con1);
								//cmdInsert1.Parameters .Add ("@Salary_ID",staff[0]);
								cmdInsert1.Parameters .Add ("@Salary_ID",staff[1]);	
								if(Dropdownlist1.SelectedIndex ==0)
									cmdInsert1.Parameters .Add ("@Staff_ID","");
								else
									//cmdInsert1.Parameters .Add("@Staff_ID",staff[0]);
									cmdInsert1.Parameters .Add("@Staff_ID",employee[1]);
									//cmdInsert1.Parameters .Add("@Staff_ID",staff[1]);
								if(txtSalary .Text=="")
									cmdInsert1.Parameters .Add ("@Basic_salary","");
								else
									cmdInsert1.Parameters .Add("@Basic_salary",int .Parse (txtSalary.Text.Trim().ToUpper()));
								if(txthra .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_hra","");
								else
									cmdInsert1.Parameters .Add ("@allowances_hra",txthra.Text.Trim().ToUpper());
								if(txtta .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_ta","");
								else
									cmdInsert1.Parameters .Add ("@allowances_ta",txtta.Text.Trim().ToUpper());
								if(txtda .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_da","");
								else
									cmdInsert1.Parameters .Add ("@allowances_da",txtda.Text.Trim().ToUpper());
								if(txtcca .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_cca","");
								else
									cmdInsert1.Parameters .Add ("@allowances_cca",txtcca.Text.Trim().ToUpper());
								if(txtMedical .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_medical","");
								else
									cmdInsert1.Parameters .Add ("@allowances_medical",txtMedical.Text.Trim().ToUpper());
								if(txtbenefits .Text=="")
									cmdInsert1.Parameters .Add ("@allowances_benefits","");
								else
									cmdInsert1.Parameters .Add ("@allowances_benefits",txtbenefits.Text.Trim().ToUpper());
								if(txtpf .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_pf","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_pf",txtpf.Text.Trim().ToUpper());
								if(txttax .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_tax","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_tax",txttax.Text.Trim().ToUpper());
								if(txtothertax .Text=="")
									cmdInsert1.Parameters .Add ("@Deduction_other","");
								else
									cmdInsert1.Parameters .Add ("@Deduction_other",txtothertax.Text.Trim().ToUpper());
								if(txtsec .Text=="")
									cmdInsert1.Parameters .Add ("@security","");
								else
									cmdInsert1.Parameters .Add ("@security",txtsec.Text.Trim().ToUpper());
								if(txtpenDeduction .Text=="")
									cmdInsert1.Parameters .Add ("@pendedu","");
								else
									cmdInsert1.Parameters .Add ("@pendedu",txtpenDeduction.Text.Trim().ToUpper());
								if(txtArrears.Text=="")
									cmdInsert1.Parameters .Add ("@Arrears","");
								else
									cmdInsert1.Parameters .Add ("@Arrears",txtArrears.Text.Trim().ToUpper());
								if(txtincrement .Text=="")
									cmdInsert1.Parameters .Add ("@Increment","");
								else
									cmdInsert1.Parameters .Add ("@Increment",txtincrement.Text.Trim().ToUpper());
								cmdInsert1.Parameters .Add ("@iAllowances",iAllowances);
								cmdInsert1.Parameters .Add ("@iDeduction",iDeduction);
								cmdInsert1.Parameters .Add ("@iGrossTotal",iGrossTotal);
								cmdInsert1.Parameters .Add ("@iNetSal",iNetSal);
								cmdInsert1.Parameters .Add ("@fromdt",GenUtil.str2MMDDYYYY(TxtDtFrom.Text.Trim().ToString()));
								cmdInsert1.Parameters .Add ("@todt",GenUtil.str2MMDDYYYY(TxtDtTo.Text.Trim().ToString()));
								cmdInsert1.ExecuteNonQuery();
								con1.Close ();
								MessageBox.Show("Allowances Deduction " + msg ); 
								CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: btnUpdate_Click.  User: " + pass );
								Clear();
								Dropdownlist1.SelectedIndex =0;
								Panaledit.Visible=false;
								btnSave.Visible=true;
								btnUpdate.Visible=false;
							//}
						}
						else
						{
							MessageBox.Show("Please Select Salary ID");
						}
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog ("Form: Allowancesdeduction.aspx.cs, Method: btnUpdate_Click. Exception: " + ex.Message + " User: " + pass );
					}
				}
				else
				{
					MessageBox.Show("'Date To' must be greater than or equal to 'Date From'");
				}
			//}
		}

}
}
