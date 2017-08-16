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
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;



namespace eschool.Reports
{
	/// <summary>
	/// Summary description for salarysheet.
	/// </summary>
	public class Completesalarydata : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.DataGrid Datapayslip;
		protected System.Web.UI.HtmlControls.HtmlButton BtnPrint;
		protected System.Web.UI.WebControls.ValidationSummary vsStaffSalary;
		protected System.Web.UI.WebControls.DropDownList Dropmonth;
		public double pBas_Salary=0;
		public double pDA=0;
		public double pTA=0;
		public double pEPF=0;
		public double pNet_Salary=0;
		public int flag=0;
		public double gLwp=0;
		public double gDa_Rs=0;
		public double gTot_Atta=0;
		public double gGros_Sal=0;
		public double gTot_Dedu=0;
		public double gNet_Sal=0;
		public double gepf_Amo=0;
		public double gBas_sal=0;
		public double gBasic_sal=0;
		public double gDa=0;
		public double gTa=0;
		public double gHra=0;
		public double gArears=0;
		public double gCca=0;
		public double gSpe_All=0;
		public double gIncre=0;
		public double gAllow=0;
		public double gdeduc=0;
		public double gEpf=0;
		public double gPanl=0;
		public double gLoan=0;
		public double gP_tex=0;
		public double gBenefit=0;
		protected System.Web.UI.WebControls.Button BtnSave;
		protected System.Web.UI.WebControls.Panel Panlsal1;
		protected System.Web.UI.WebControls.Panel panlsal2;
		protected System.Web.UI.WebControls.DropDownList Dropyear;
		protected System.Web.UI.HtmlControls.HtmlButton Button1;
		public double gSecurity=0;
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
				string pass;
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Complitesalarydata.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="23";
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
					if(View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.BtnPrint.ServerClick += new System.EventHandler(this.BtnPrint_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
    	
		/// <summary>
		/// this method use to show Report in datagrid and record fetch from Staff_Information and Allowancesdeduction table.
		/// this method not in use.
		/// </summary>
		private void Datapayslip_SelectedIndexChanged(object sender, System.EventArgs e)
		{ 
			SqlConnection con3;
			SqlCommand cmdInsert1;
			string strInsert1;
			try
			{
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				strInsert1 ="Select si.Staff_ID, si.Staff_Name, si.PerMonth_Salary,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.allowances_benefits,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.Increment,Allow.Increment_due,Allow.G_total,Allow.fromdt,Allow.todt,(si.PerMonth_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca+Allow.allowances_benefits+Allow.Increment) as total From Staff_Information si,Allowancesdeduction  Allow where si.Staff_ID=Allow.Staff_ID and Allow.fromdt=@fromdt and Allow.todt=@todt";
				cmdInsert1=new SqlCommand (strInsert1,con3);
				Datapayslip.DataSource =cmdInsert1.ExecuteReader();
				Datapayslip.DataBind ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Datapayslip_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}
			
		}

		/// <summary>
		/// this method use to get DateTime as string but return Date in MM/DD/YYYY format.
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
		/// this Method use to create Complete Salary Report and data fetch from Staff_Information and Allowancesdeduction table. if hidden textbox has 1 value then first data fetch from
		/// staff_attendance table and get total number of present day. after that calculate basic salary and DA calculate on basic salary. and in basic salary add DA,add total deduction,
		/// total allowances and also add increament. after that show net salary of a particular month. that salary we can also save in staff_salary.  
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			BtnSave.Visible=true;
			flag=1;
			if(Request.Params.Get("hidden1")!=null && Request.Params.Get("hidden1")!="")
			{
				if(Convert.ToInt32(Request.Params.Get("hidden1"))==1)
				{
					try
					{         
						Panlsal1.Visible=true;  
						panlsal2.Visible=false;
						int day=DateTime.DaysInMonth(int.Parse(Dropyear.SelectedItem.Text),Dropmonth.SelectedIndex);
						string fromdate=Dropmonth.SelectedIndex+"/1/"+Dropyear.SelectedItem.Text;
						string todate=Dropmonth.SelectedIndex+"/"+day+"/"+Dropyear.SelectedItem.Text;
						double Lwp=0,Da_Rs=0,Tot_Atta=0,Gros_Sal=0,Tot_Dedu=0,Net_Sal=0,epf_Amo=0,Bas_sal=0,Basic_sal=0,Da=0,Ta=0,Hra=0,Arears=0,Cca=0,Spe_All=0,Incre=0,Allow=0,deduc=0,Epf=0,Panl=0,Loan=0,P_tex=0,Benefit=0,Security=0;
						int i=1,j=0;
						SqlConnection con3;
						SqlCommand cmdInsert1;
						string strInsert="",strInsert1="";
						SqlDataReader dr1=null,dr=null;
						con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con3.Open ();
						strInsert1="select staff_id,sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1)  and datename(month,attendance_date)='"+Dropmonth.SelectedItem.Text+"' and datename(year,attendance_date)='"+Dropyear.SelectedItem.Text+"' group by staff_id";
						cmdInsert1=new SqlCommand (strInsert1,con3);
						dr1=cmdInsert1.ExecuteReader();
						while(dr1.Read())
						{
							Tot_Atta=Convert.ToDouble(dr1.GetValue(1));
							InventoryClass obj=new InventoryClass();
							SqlDataReader SqlDtr=null;
							strInsert="Select Days from staff_leave where staff_id="+dr1.GetValue(0)+" and  Leave_Type='LWP' and cast(floor(cast(cast(Staff_leavefromdt as datetime) as float)) as datetime)>='"+fromdate+"' and cast(floor(cast(cast( Staff_leavefromto as datetime) as float)) as datetime)<='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							if(SqlDtr.Read())
							{    
								if(SqlDtr["Days"]!="" && SqlDtr["Days"]!=null)
								{
									Lwp=Convert.ToDouble(SqlDtr["Days"]);
								}
								else
								{
									Lwp=0;
								}
								
							}
							else
							{
								Lwp=0;
							}
							SqlDtr.Close();
							strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.allowances_benefits,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and si.staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							while(SqlDtr.Read())
							{
								Basic_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								Bas_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								if(Lwp>0)
								{
									Tot_Atta=Tot_Atta-Lwp;
								}
								Bas_sal=(Bas_sal*Tot_Atta)/day;
								gBas_sal=gBas_sal+Bas_sal;
								Da=Convert.ToDouble(SqlDtr["allowances_da"]);
								Da_Rs=( Bas_sal*Da)/100;
								gDa_Rs=gDa_Rs+Da_Rs;
								Ta=Convert.ToDouble(SqlDtr["allowances_ta"]);
								gTa=gTa+Ta;
								Hra=Convert.ToDouble(SqlDtr["allowances_hra"]);
								gHra=gHra+Hra;
								Arears=Convert.ToDouble(SqlDtr["arrears"]);
								gArears=gArears+Arears;
								Cca=Convert.ToDouble(SqlDtr["allowances_cca"]);
								gCca=gCca+Cca;
								Spe_All=Convert.ToDouble(SqlDtr["allowances_Medical"]);
								gSpe_All=gSpe_All+Spe_All;
								Incre=Convert.ToDouble(SqlDtr["Increment"]);
								gIncre=gIncre+Incre;
								Epf=Convert.ToDouble(SqlDtr["Deduction_pf"]);
								Panl=Convert.ToDouble(SqlDtr["pendedu"]);
								gPanl=gPanl+Panl;
								Loan=Convert.ToDouble(SqlDtr["Deduction_other"]);
								gLoan=gLoan+Loan;
								P_tex=Convert.ToDouble(SqlDtr["Deduction_tax"]);
								gP_tex=gP_tex+P_tex;
								Benefit=Convert.ToDouble(SqlDtr["allowances_benefits"]);
								gBenefit=gBenefit+Benefit;
								Security=Convert.ToDouble(SqlDtr["security"]);
								gSecurity=gSecurity+Security;
								Gros_Sal=Bas_sal+Da_Rs;
								if(Basic_sal>=6500)
								{
									epf_Amo=(Gros_Sal*Epf)/100;
								}
								else
								{
									epf_Amo=0;
								}
								gEpf=gEpf+epf_Amo;
								Gros_Sal=Gros_Sal+Ta+Hra+Cca+Spe_All+Arears;
								gGros_Sal=gGros_Sal+Gros_Sal;
								Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit;
								gTot_Dedu=gTot_Dedu+Tot_Dedu;
								Net_Sal=(Gros_Sal+Incre)-Tot_Dedu;
								gNet_Sal=gNet_Sal+Net_Sal;
								i++;
							}
							SqlDtr.Close();
						}
						dr1.Close();
					    
					  
						CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Search_ServerClick, Complite Salary Report Viewed , Userid :  "+ pass   );		
			
					}	
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
					}
				}
				else if(Convert.ToInt32(Request.Params.Get("hidden1"))==2)
				{
					try 
					{
						panlsal2.Visible=true;  
						Panlsal1.Visible=false;
						BtnSave.Visible=false;
						SqlConnection con4;
						SqlCommand cmdInsert2;
						SqlDataReader dr2=null;
						string strInsert2="";
						con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con4.Open ();
						if(Request.Params.Get("hidden2")!=null&&Request.Params.Get("hidden2")!=""&&Request.Params.Get("hidden2")!="ALL")
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where si.staff_id=ss.emp_id and Emp_ID="+Request.Params.Get("hidden2")+" and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}
						else
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where  si.staff_id=ss.emp_id and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}

						cmdInsert2=new SqlCommand (strInsert2,con4);
						dr2=cmdInsert2.ExecuteReader();
						while(dr2.Read())
						{
							pBas_Salary=pBas_Salary+Convert.ToDouble(dr2["Bas_Sal"].ToString());
							pDA=pDA+Convert.ToDouble(dr2["DA"].ToString());
							pTA=pTA+Convert.ToDouble(dr2["TA"].ToString());
							pEPF=pEPF+Convert.ToDouble(dr2["EPF"].ToString());
							pNet_Salary=pNet_Salary+Convert.ToDouble(dr2["Net_Sal"].ToString());
								
						}
						con4.Close();
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
					}
				}
				else
				{
					return;
				}
			}
			else
			{
				return;
			}
		}

		///<summary>
		/// this Method use to create Complete Salary Report in excel format and data fetch from Staff_Information and Allowancesdeduction table. if hidden textbox has 1 value then first data fetch from
		/// staff_attendance table and get total number of present day. after that calculate basic salary and DA calculate on basic salary. and in basic salary add DA,add total deduction,
		/// total allowances and also add increament. after that show net salary of a particular month.
		///</summary>
		public void ConvertIntoExcel()
		{
			if(Request.Params.Get("hidden1")!=null&&Request.Params.Get("hidden1")!="")
			{
				if(Convert.ToInt32(Request.Params.Get("hidden1"))==1)
				{
					BtnSave.Visible=true;
					try
					{
						SqlDataReader rdr1,rdr;
						string home_drive = Environment.SystemDirectory;
						home_drive = home_drive.Substring(0,2); 
						string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
						Directory.CreateDirectory(strExcelPath);
						string path = home_drive+@"\eSchool_ExcelFile\Complete_Salary.xls";
						StreamWriter sw = new StreamWriter(path);
						int day=DateTime.DaysInMonth(int.Parse(Dropyear.SelectedItem.Text),Dropmonth.SelectedIndex);
						string fromdate=Dropmonth.SelectedIndex+"/1/"+Dropyear.SelectedItem.Text;
						string todate=Dropmonth.SelectedIndex+"/"+day+"/"+Dropyear.SelectedItem.Text;
						double  Lwp=0,Da_Rs=0,Tot_Atta=0,Gros_Sal=0,Tot_Dedu=0,Basic_sal=0,Net_Sal=0,epf_Amo=0,Bas_sal=0,Da=0,Ta=0,Hra=0,Arears=0,Cca=0,Spe_All=0,Incre=0,Allow=0,deduc=0,Epf=0,Panl=0,Loan=0,P_tex=0,Benefit=0,Security=0;
						int i=1,j=0;
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("		               COMPLETE SALARY INFORMATION REPORT           ") ;
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("                                   MONTH "+Dropmonth.SelectedItem.Text+" YEAR "+Dropyear.SelectedItem.Text);
						sw.WriteLine("") ;
						sw.WriteLine(" |SN\tEmployee Name\tDesi.\tBSalary\tDA\tHRA\tTA\tCCA\tArr\tSp.A\tG.Sal\tEPF\tLoan\tPanl\tP.Tx\tBen\tSec.\tTo.De\tIncr\tNet.Sal|");
						SqlConnection con3;
						SqlCommand cmdInsert1;
						string strInsert1="",strInsert="";
						SqlDataReader dr=null,dr1=null;
						con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con3.Open ();
						strInsert1="select staff_id,sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1)  and datename(month,attendance_date)='"+Dropmonth.SelectedItem.Text+"' and datename(year,attendance_date)='"+Dropyear.SelectedItem.Text+"' group by staff_id";
						cmdInsert1=new SqlCommand (strInsert1,con3);
						dr1=cmdInsert1.ExecuteReader();
						while(dr1.Read())
						{
							Tot_Atta=Convert.ToDouble(dr1.GetValue(1));
							InventoryClass obj=new InventoryClass();
							SqlDataReader SqlDtr=null;
							strInsert="Select adjustment from staff_leave where staff_id="+dr1.GetValue(0)+" and  Leave_Type='LWP' and cast(floor(cast(cast(Staff_leavefromdt as datetime) as float)) as datetime)>='"+fromdate+"' and cast(floor(cast(cast( Staff_leavefromto as datetime) as float)) as datetime)<='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							if(SqlDtr.Read())
							{    
								if(SqlDtr["adjustment"].ToString().Trim()!="" && SqlDtr["adjustment"]!=null)
								{
									Lwp=Convert.ToDouble(SqlDtr["adjustment"]);
								}
								else
								{
									Lwp=0;
								}
							}
							else
							{
								Lwp=0;
							}
							SqlDtr.Close();
							strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.allowances_benefits,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and si.staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							while(SqlDtr.Read())
							{
								Basic_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								Bas_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								if(Lwp>0)
								{
									Tot_Atta=Tot_Atta-Lwp;
								}
								Bas_sal=(Bas_sal*Tot_Atta)/day;
								gBas_sal=gBas_sal+Bas_sal;
								Da=Convert.ToDouble(SqlDtr["allowances_da"]);
								Da_Rs=( Bas_sal*Da)/100;
								gDa_Rs=gDa_Rs+Da_Rs;
								Ta=Convert.ToDouble(SqlDtr["allowances_ta"]);
								gTa=gTa+Ta;
								Hra=Convert.ToDouble(SqlDtr["allowances_hra"]);
								gHra=gHra+Hra;
								Arears=Convert.ToDouble(SqlDtr["arrears"]);
								gArears=gArears+Arears;
								Cca=Convert.ToDouble(SqlDtr["allowances_cca"]);
								gCca=gCca+Cca;
								Spe_All=Convert.ToDouble(SqlDtr["allowances_Medical"]);
								gSpe_All=gSpe_All+Spe_All;
								Incre=Convert.ToDouble(SqlDtr["Increment"]);
								gIncre=gIncre+Incre;
								Epf=Convert.ToDouble(SqlDtr["Deduction_pf"]);
								Panl=Convert.ToDouble(SqlDtr["pendedu"]);
								gPanl=gPanl+Panl;
								Loan=Convert.ToDouble(SqlDtr["Deduction_other"]);
								gLoan=gLoan+Loan;
								P_tex=Convert.ToDouble(SqlDtr["Deduction_tax"]);
								gP_tex=gP_tex+P_tex;
								Benefit=Convert.ToDouble(SqlDtr["allowances_benefits"]);
								gBenefit=gBenefit+Benefit;
								Security=Convert.ToDouble(SqlDtr["security"]);
								gSecurity=gSecurity+Security;
								Gros_Sal=Bas_sal+Da_Rs;
								if(Basic_sal>=6500)
								{
									epf_Amo=(Gros_Sal*Epf)/100;
								}
								else
								{
									epf_Amo=0;
								}
								gEpf=gEpf+epf_Amo;
								Gros_Sal=Gros_Sal+Ta+Hra+Cca+Spe_All+Arears;
								gGros_Sal=gGros_Sal+Gros_Sal;
								// 22.09.08 Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit;
								Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit+Security;
								gTot_Dedu=gTot_Dedu+Tot_Dedu;
								Net_Sal=(Gros_Sal+Incre)-Tot_Dedu;
								gNet_Sal=gNet_Sal+Net_Sal;
								i++;

								sw.WriteLine(i.ToString()+"\t"+
									GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),15)+"\t"+SqlDtr["Staff_Type"].ToString()+"\t"+Math.Round(Bas_sal).ToString()+"\t"+Math.Round(Da_Rs).ToString()+"\t"+
									Hra.ToString()+"\t"+Ta.ToString()+"\t"+Cca.ToString()+"\t"+Arears.ToString()+"\t"+Spe_All.ToString()+"\t"+
									Math.Round(Gros_Sal).ToString()+"\t"+
									Math.Round(epf_Amo).ToString()+"\t"+
									Loan.ToString()+"\t"+
									Panl.ToString()+"\t"+
									P_tex.ToString()+"\t"+
									Benefit.ToString()+"\t"+
									Security.ToString()+"\t"+
									Math.Round(Tot_Dedu).ToString()+"\t"+
									Incre.ToString()+"\t"+
									Math.Round(Net_Sal).ToString());
								i++;
							}
							SqlDtr.Close();
						}
						dr1.Close();
						sw.WriteLine();
				
						sw.WriteLine("\t"+"Grand Total"+"\t\t"+Math.Round(gBas_sal).ToString()+"\t"+Math.Round(gDa_Rs).ToString()+"\t"+gHra.ToString()+"\t"+
							gTa.ToString()+"\t"+gCca.ToString()+"\t"+gArears.ToString()+"\t"+gSpe_All.ToString()+"\t"+Math.Round(gGros_Sal).ToString()+"\t"+
							Math.Round(gEpf).ToString()+"\t"+
							gLoan.ToString()+"\t"+
							gPanl.ToString()+"\t"+
							gP_tex.ToString()+"\t"+
							gBenefit.ToString()+"\t"+
							gSecurity.ToString()+"\t"+
							Math.Round(gTot_Dedu).ToString()+"\t"+
							gIncre.ToString()+"\t"+
							Math.Round(gNet_Sal).ToString());
						sw.Close();
						flag=1;  
						CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Search_ServerClick, Complite Salary Report Viewed , Userid :  "+ pass   );		
			
					}	
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
					}
				}
				else if(Convert.ToInt32(Request.Params.Get("hidden1"))==2)
				{
					try 
					{
						string home_drive = Environment.SystemDirectory;
						home_drive = home_drive.Substring(0,2); 
						string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
						Directory.CreateDirectory(strExcelPath);
						string path = home_drive+@"\eSchool_ExcelFile\Complete_Salary.xls";
						StreamWriter sw = new StreamWriter(path);
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("		               COMPLETE SALARY INFORMATION REPORT-2           ") ;
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("                                   MONTH "+Dropmonth.SelectedItem.Text+" YEAR "+Dropyear.SelectedItem.Text);
						sw.WriteLine("") ;
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						sw.WriteLine("SN \tEmployee Name\tBasic Salary\tDA\tTA\tEPF\tNet.Sal");
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						//             123 12345678901234567890 123456789012 123456789 12345678 12345678 12345678901
						panlsal2.Visible=true;  
						Panlsal1.Visible=false;
						BtnSave.Visible=false;
						SqlConnection con4;
						SqlCommand cmdInsert2;
						SqlDataReader dr2=null;
						string strInsert2="";
						con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con4.Open ();
						if(Request.Params.Get("hidden2")!=null&&Request.Params.Get("hidden2")!=""&&Request.Params.Get("hidden2")!="ALL")
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where si.staff_id=ss.emp_id and Emp_ID="+Request.Params.Get("hidden2")+" and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}
						else
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where  si.staff_id=ss.emp_id and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}
						int k=1;
						string s="",name="";
						cmdInsert2=new SqlCommand (strInsert2,con4);
						dr2=cmdInsert2.ExecuteReader();
						while(dr2.Read())
						{
							if(s=="")
							{ 
								name=dr2["Staff_name"].ToString();
								s=dr2["Staff_name"].ToString();
							}
							else if(s==dr2["Staff_name"].ToString())
							{
								name="  --' --' --'       ";
							}
							else
							{
								name=dr2["Staff_name"].ToString();
								s=dr2["Staff_name"].ToString();
							}	
							sw.WriteLine(k.ToString()+"\t"+GenUtil.TrimLength(name.ToString(),20)+"\t"+dr2["Bas_Sal"].ToString()+"\t"+Math.Round(Convert.ToDouble(dr2["DA"])).ToString()+"\t"+Math.Round(Convert.ToDouble(dr2["TA"])).ToString()+"\t"+Math.Round(Convert.ToDouble(dr2["EPF"])).ToString()+"\t"+Math.Round(Convert.ToDouble(dr2["Net_Sal"])).ToString());
							pBas_Salary=pBas_Salary+Convert.ToDouble(dr2["Bas_Sal"].ToString());
							pDA=pDA+Convert.ToDouble(dr2["DA"].ToString());
							pTA=pTA+Convert.ToDouble(dr2["TA"].ToString());
							pEPF=pEPF+Convert.ToDouble(dr2["EPF"].ToString());
							pNet_Salary=pNet_Salary+Convert.ToDouble(dr2["Net_Sal"].ToString());
							k++;
						}
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						sw.WriteLine("Grand Total"+"\t\t"+pBas_Salary.ToString()+"\t"+Math.Round(pDA).ToString()+"\t"+Math.Round(pTA).ToString()+"\t"+Math.Round(pEPF).ToString()+"\t"+Math.Round(pNet_Salary).ToString());
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						con4.Close();
						sw.Close();
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
					}
				}
				else
				{
					return;

				}
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel function.
		/// </summary>
		private void BtnPrint_ServerClick(object sender, System.EventArgs e)
		{
			
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method: btnExcel_Click, Bank Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method:btnExcel_Click   Bank Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this method use to create connection between Remote device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteSalarydata.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :CompleteSalarydata.aspx,Method  Button1_ServerClick,  Issue Book Report  Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteSalarydata.aspx,Method  Button1_ServerClick,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteSalarydata.aspx,Method  Button1_ServerClick,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :CompleteSalarydata.aspx,Method  Button1_ServerClick,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :CompleteSalarydata.aspx,Method  Button1_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		///<summary>
		/// this Method use to create Complete Salary Report in text format and data fetch from Staff_Information and Allowancesdeduction table. if hidden textbox has 1 value then first data fetch from
		/// staff_attendance table and get total number of present day. after that calculate basic salary and DA calculate on basic salary. and in basic salary add DA,add total deduction,
		/// total allowances and also add increament. after that show net salary of a particular month.
		///</summary>
		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			if(Request.Params.Get("hidden1")!=null&&Request.Params.Get("hidden1")!="")
			{
				if(Convert.ToInt32(Request.Params.Get("hidden1"))==1)
				{
					BtnSave.Visible=true;
					try
					{
						string home_drive = Environment.SystemDirectory;
						home_drive = home_drive.Substring(0,2);
						string info = "";//info1="";
						string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteSalarydata.txt";
						StreamWriter sw = new StreamWriter(path); 
						int day=DateTime.DaysInMonth(int.Parse(Dropyear.SelectedItem.Text),Dropmonth.SelectedIndex);
						string fromdate=Dropmonth.SelectedIndex+"/1/"+Dropyear.SelectedItem.Text;
						string todate=Dropmonth.SelectedIndex+"/"+day+"/"+Dropyear.SelectedItem.Text;
						double Lwp=0,Da_Rs=0,Tot_Atta=0,Gros_Sal=0,Tot_Dedu=0,Net_Sal=0,epf_Amo=0,Bas_sal=0,Basic_sal=0,Da=0,Ta=0,Hra=0,Arears=0,Cca=0,Spe_All=0,Incre=0,Allow=0,deduc=0,Epf=0,Panl=0,Loan=0,P_tex=0,Benefit=0,Security=0;
						int i=1,j=0;
						sw.Write((char)27);
						sw.Write((char)67);
						sw.Write((char)0);
						sw.Write((char)12);
						sw.Write((char)27);
						sw.Write((char)78);
						sw.Write((char)5);
						sw.Write((char)27);
						sw.Write((char)15);	
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("		                COMPLETE SALARY INFORMATION REPORT           ") ;
						sw.WriteLine("                     -------------------------------------") ;
						//sw.WriteLine("                                   YEAR "+Dropyear.SelectedItem.Text);
						sw.WriteLine("                                   MONTH "+Dropmonth.SelectedItem.Text+" YEAR "+Dropyear.SelectedItem.Text);
						sw.WriteLine("") ;
						sw.WriteLine("+--+---------------+-----+--------+-----+-----+-----+----+----+-----+-------+-----+-----+-----+----+----+-----+------+-----+---------+");
						sw.WriteLine("|SN| Employee Name |Desi.|BSalary |  DA | HRA |  TA |CCA |Arr |Sp.A | G.Sal | EPF |Loan |Panl |P.Tx|Ben | Sec.|To.De |Incr | Net.Sal |");
						sw.WriteLine("+--+---------------+-----+--------+-----+-----+-----+----+----+-----+-------+-----+-----+-----+----+----+-----+------+-----+---------+");
						//   123 123456789012345 12345 1234567 1234 1234 1234 1234 1234 1234 123456 1234 1234 1234 1234 1234 1234 12345 1234 1234567
						info="{0,2:S} {1,-15:S} {2,5:S} {3,8:S} {4,5:S} {5,5:S} {6,5:S} {7,4:S} {8,4:S} {9,5:S} {10,7:S} {11,5:S} {12,5:S} {13,5:S} {14,4:S} {15,4:S} {16,5:S} {17,6:S} {18,5:S} {19,9:S}";
						string info1="   Grand Total            {0,8:S} {1,5:S} {2,5:S} {3,5:S} {4,4:S} {5,4:S} {6,5:S} {7,7:S} {8,5:S} {9,5:S} {10,5:S} {11,4:S} {12,4:S} {13,5:S} {14,6:S} {15,5:S} {16,9:S}";
						SqlConnection con3;
						SqlCommand cmdInsert1;
						string strInsert1="",strInsert="";
						SqlDataReader dr1=null,dr=null;
						con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con3.Open ();
						strInsert1="select staff_id,sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1)  and datename(month,attendance_date)='"+Dropmonth.SelectedItem.Text+"' and datename(year,attendance_date)='"+Dropyear.SelectedItem.Text+"' group by staff_id";
						cmdInsert1=new SqlCommand (strInsert1,con3);
						dr1=cmdInsert1.ExecuteReader();
						while(dr1.Read())
						{
							Tot_Atta=Convert.ToDouble(dr1.GetValue(1));
							InventoryClass obj=new InventoryClass();
							SqlDataReader SqlDtr=null;
							strInsert="Select adjustment from staff_leave where staff_id="+dr1.GetValue(0)+" and  Leave_Type='LWP' and cast(floor(cast(cast(Staff_leavefromdt as datetime) as float)) as datetime)>='"+fromdate+"' and cast(floor(cast(cast( Staff_leavefromto as datetime) as float)) as datetime)<='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							if(SqlDtr.Read())
							{    
								if(SqlDtr["adjustment"].ToString().Trim()!="" && SqlDtr["adjustment"]!=null)
								{
									Lwp=Convert.ToDouble(SqlDtr["adjustment"]);
								}
								else
								{
									Lwp=0;
								}
							}
							else
							{
								Lwp=0;
							}
							SqlDtr.Close();
							strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.allowances_benefits,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and si.staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
							SqlDtr=obj.GetRecordSet(strInsert);
							while(SqlDtr.Read())
							{
								Basic_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								Bas_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
								if(Lwp>0)
								{
									Tot_Atta=Tot_Atta-Lwp;
								}
								Bas_sal=(Bas_sal*Tot_Atta)/day;
								gBas_sal=gBas_sal+Bas_sal;
								Da=Convert.ToDouble(SqlDtr["allowances_da"]);
								Da_Rs=( Bas_sal*Da)/100;
								gDa_Rs=gDa_Rs+Da_Rs;
								Ta=Convert.ToDouble(SqlDtr["allowances_ta"]);
								gTa=gTa+Ta;
								Hra=Convert.ToDouble(SqlDtr["allowances_hra"]);
								gHra=gHra+Hra;
								Arears=Convert.ToDouble(SqlDtr["arrears"]);
								gArears=gArears+Arears;
								Cca=Convert.ToDouble(SqlDtr["allowances_cca"]);
								gCca=gCca+Cca;
								Spe_All=Convert.ToDouble(SqlDtr["allowances_Medical"]);
								gSpe_All=gSpe_All+Spe_All;
								Incre=Convert.ToDouble(SqlDtr["Increment"]);
								gIncre=gIncre+Incre;
								Epf=Convert.ToDouble(SqlDtr["Deduction_pf"]);
								Panl=Convert.ToDouble(SqlDtr["pendedu"]);
								gPanl=gPanl+Panl;
								Loan=Convert.ToDouble(SqlDtr["Deduction_other"]);
								gLoan=gLoan+Loan;
								P_tex=Convert.ToDouble(SqlDtr["Deduction_tax"]);
								gP_tex=gP_tex+P_tex;
								Benefit=Convert.ToDouble(SqlDtr["allowances_benefits"]);
								gBenefit=gBenefit+Benefit;
								Security=Convert.ToDouble(SqlDtr["security"]);
								gSecurity=gSecurity+Security;
								Gros_Sal=Bas_sal+Da_Rs;
								if(Basic_sal>=6500)
								{
									epf_Amo=(Gros_Sal*Epf)/100;
								}
								else
								{
									epf_Amo=0;
								}
								gEpf=gEpf+epf_Amo;
								Gros_Sal=Gros_Sal+Ta+Hra+Cca+Spe_All+Arears;
								gGros_Sal=gGros_Sal+Gros_Sal;
								//Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit;
								Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit+Security;
								gTot_Dedu=gTot_Dedu+Tot_Dedu;
								Net_Sal=(Gros_Sal+Incre)-Tot_Dedu;
								gNet_Sal=gNet_Sal+Net_Sal;
								i++;
								sw.WriteLine(info,i.ToString(),
									GenUtil.TrimLength(SqlDtr["Staff_Name"].ToString(),15),GenUtil.TrimLength(SqlDtr["Staff_Type"].ToString(),5),Math.Round(Bas_sal).ToString(),Math.Round(Da_Rs).ToString(),
									Hra.ToString(),Ta.ToString(),Cca.ToString(),Arears.ToString(),Spe_All.ToString(),
									Math.Round(Gros_Sal).ToString(),
									Math.Round(epf_Amo).ToString(),
									Loan.ToString(),
									Panl.ToString(),
									P_tex.ToString(),
									Benefit.ToString(),
									Security.ToString(),
									Math.Round(Tot_Dedu).ToString(),
									Incre.ToString(),
									Math.Round(Net_Sal).ToString());
								i++;
							}
							SqlDtr.Close();
						}
						dr1.Close();
						sw.WriteLine("+--+---------------+-----+--------+-----+-----+-----+----+----+-----+-------+-----+-----+-----+----+----+-----+------+-----+---------+");
						sw.WriteLine(info1,Math.Round(gBas_sal).ToString(),Math.Round(gDa_Rs).ToString(),gHra.ToString(),
							gTa.ToString(),gCca.ToString(),gArears.ToString(),gSpe_All.ToString(),Math.Round(gGros_Sal).ToString(),
							Math.Round(gEpf).ToString(),
							gLoan.ToString(),
							gPanl.ToString(),
							gP_tex.ToString(),
							gBenefit.ToString(),
							gSecurity.ToString(),
							Math.Round(gTot_Dedu).ToString(),
							gIncre.ToString(),
							Math.Round(gNet_Sal).ToString());
						sw.WriteLine("+--+---------------+-----+--------+-----+-----+-----+----+----+-----+-------+-----+-----+-----+----+----+-----+------+-----+---------+");
						sw.Close();
						flag=1;  
						CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Search_ServerClick, Complite Salary Report Viewed , Userid :  "+ pass   );		
					}	
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
					}
				}
				else if(Convert.ToInt32(Request.Params.Get("hidden1"))==2)
				{
					try 
					{
						string home_drive = Environment.SystemDirectory;
						home_drive = home_drive.Substring(0,2);
						string info = "";
						string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\CompleteSalarydata.txt";
						StreamWriter sw = new StreamWriter(path);
						sw.Write((char)27);
						sw.Write((char)67);
						sw.Write((char)0);
						sw.Write((char)12);
						sw.Write((char)27);
						sw.Write((char)78);
						sw.Write((char)5);							
						sw.Write((char)27);
						sw.Write((char)15);
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("		               COMPLETE SALARY INFORMATION REPORT-2           ") ;
						sw.WriteLine("                     -------------------------------------") ;
						sw.WriteLine("                                   MONTH "+Dropmonth.SelectedItem.Text+" YEAR "+Dropyear.SelectedItem.Text);
						sw.WriteLine("") ;
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						sw.WriteLine("|SN |   Employee Name    |Basic Salary|    DA   |   TA   |   EPF  |   Net.Sal |");
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						//             123 12345678901234567890 123456789012 123456789 12345678 12345678 12345678901
						info="{0,4:S} {1,-20:S} {2,12:S} {3,9:S} {4,8:S} {5,8:S} {6,11:S}";
						string info1="   Grand Total            {0,12:S} {1,9:S} {2,8:S} {3,8:S} {4,11:S}";
						panlsal2.Visible=true;  
						Panlsal1.Visible=false;
						BtnSave.Visible=false;
						SqlConnection con4;
						SqlCommand cmdInsert2;
						SqlDataReader dr2=null;
						string strInsert2="";
						con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con4.Open ();
						if(Request.Params.Get("hidden2")!=null&&Request.Params.Get("hidden2")!=""&&Request.Params.Get("hidden2")!="ALL")
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where si.staff_id=ss.emp_id and Emp_ID="+Request.Params.Get("hidden2")+" and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}
						else
						{
							strInsert2="Select si.staff_name,ss.emp_id,ss.Bas_sal,ss.da,ss.ta,ss.epf,ss.net_sal from Staff_Salary ss,staff_information si where  si.staff_id=ss.emp_id and dateof like '%"+Dropyear.SelectedItem.Text+"'";
						}
						int k=1;
						string s="",name="";
						cmdInsert2=new SqlCommand (strInsert2,con4);
						dr2=cmdInsert2.ExecuteReader();
						while(dr2.Read())
						{
							if(s=="")
							{ 
								name=dr2["Staff_name"].ToString();
								s=dr2["Staff_name"].ToString();
							}
							else if(s==dr2["Staff_name"].ToString())
							{
								name="  --' --' --'       ";
							}
							else
							{
								name=dr2["Staff_name"].ToString();
								s=dr2["Staff_name"].ToString();
							}	
							sw.WriteLine(info,k.ToString(),GenUtil.TrimLength(name.ToString(),20),dr2["Bas_Sal"].ToString(),Math.Round(Convert.ToDouble(dr2["DA"])).ToString(),Math.Round(Convert.ToDouble(dr2["TA"])).ToString(),Math.Round(Convert.ToDouble(dr2["EPF"])).ToString(),Math.Round(Convert.ToDouble(dr2["Net_Sal"])).ToString());
							pBas_Salary=pBas_Salary+Convert.ToDouble(dr2["Bas_Sal"].ToString());
							pDA=pDA+Convert.ToDouble(dr2["DA"].ToString());
							pTA=pTA+Convert.ToDouble(dr2["TA"].ToString());
							pEPF=pEPF+Convert.ToDouble(dr2["EPF"].ToString());
							pNet_Salary=pNet_Salary+Convert.ToDouble(dr2["Net_Sal"].ToString());
							k++;
						}
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						sw.WriteLine(info1,pBas_Salary.ToString(),Math.Round(pDA).ToString(),Math.Round(pTA).ToString(),Math.Round(pEPF).ToString(),Math.Round(pNet_Salary).ToString());
						sw.WriteLine("+---+--------------------+------------+---------+--------+--------+-----------+");
						sw.Close();
						con4.Close();
						
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
					}
				}
				else
				{
					return;
				}
			}
			else
			{
				return;
			}
		}
			
		///<summary>
		/// this Method use to create Complete Salary Report and data fetch from Staff_Information and Allowancesdeduction table. if hidden textbox has 1 value then first data fetch from
		/// staff_attendance table and get total number of present day. after that calculate basic salary and DA calculate on basic salary. and in basic salary add DA,add total deduction,
		/// total allowances and also add increament. after that show net salary of a particular month. we save and update this record in to staff_salary table.
		///</summary>
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				int day=DateTime.DaysInMonth(int.Parse(Dropyear.SelectedItem.Text),Dropmonth.SelectedIndex);
				string fromdate=Dropmonth.SelectedIndex+"/1/"+Dropyear.SelectedItem.Text;
				string todate=Dropmonth.SelectedIndex+"/"+day+"/"+Dropyear.SelectedItem.Text;
				string MonthYear=Dropmonth.SelectedItem.Value+":"+Dropyear.SelectedItem.Value;         			   
				double Lwp=0,Da_Rs=0,Tot_Atta=0,Gros_Sal=0,Tot_Dedu=0,Net_Sal=0,epf_Amo=0,Bas_sal=0,Basic_sal=0,Da=0,Ta=0,Hra=0,Arears=0,Cca=0,Spe_All=0,Incre=0,Allow=0,deduc=0,Epf=0,Panl=0,Loan=0,P_tex=0,Benefit=0,Security=0;
				int i=1,j=0;
				SqlConnection con3;
				SqlCommand cmdInsert1;
				string strInsert="",strInsert1="";
				SqlDataReader dr1=null,dr=null;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				strInsert1="select staff_id,sum(attandance_status)  from staff_attandance where (attandance_status=0.5 or attandance_status=1)  and datename(month,attendance_date)='"+Dropmonth.SelectedItem.Text+"' and datename(year,attendance_date)='"+Dropyear.SelectedItem.Text+"' group by staff_id";
				cmdInsert1=new SqlCommand (strInsert1,con3);
				dr1=cmdInsert1.ExecuteReader();
				while(dr1.Read())
				{
					Tot_Atta=Convert.ToDouble(dr1.GetValue(1));
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr=null;
					strInsert="Select Days from staff_leave where staff_id="+dr1.GetValue(0)+" and  Leave_Type='LWP' and cast(floor(cast(cast(Staff_leavefromdt as datetime) as float)) as datetime)>='"+fromdate+"' and cast(floor(cast(cast( Staff_leavefromto as datetime) as float)) as datetime)<='"+todate+"'";
					SqlDtr=obj.GetRecordSet(strInsert);
					if(SqlDtr.Read())
					{    
						if(SqlDtr["Days"].ToString().Trim()!="" && SqlDtr["Days"]!=null)
						{
							Lwp=Convert.ToDouble(SqlDtr["Days"]);
						}
						else
						{
							Lwp=0;
						}
					}
					else
					{
						Lwp=0;
					}
					SqlDtr.Close();
					
					strInsert ="select si.Staff_ID, si.Staff_Name, si.doj,si.Staff_Type,Allow.basic_Salary,Allow.allowances_benefits,Allow.arrears,Allow.allowances_Medical,Allow.allowances_hra,Allow.allowances_ta,Allow.allowances_da,Allow.allowances_cca,Allow.Deduction_pf,Allow.Deduction_tax,Allow.Deduction_other,Allow.pendedu,Allow.lwp,Allow.security,Allow.Increment,Allow.G_total,Allow.fromdt,Allow.todt,(Allow.basic_Salary+Allow.allowances_hra+Allow.allowances_ta+Allow.allowances_da+Allow.allowances_cca) total from staff_information si ,allowancesdeduction Allow where si.staff_id=Allow.staff_id and si.staff_id="+dr1.GetValue(0)+"  and cast(floor(cast(cast(Allow.fromdt as datetime) as float)) as datetime)<='"+fromdate+"' and cast(floor(cast(cast(Allow.todt as datetime) as float)) as datetime)>='"+todate+"'";
					SqlDtr=obj.GetRecordSet(strInsert);
					while(SqlDtr.Read())
					{
						Basic_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
						Bas_sal=Convert.ToDouble(SqlDtr["basic_Salary"]);
						if(Lwp>0)
						{
							Tot_Atta=Tot_Atta-Lwp;
						}
						Bas_sal=(Bas_sal*Tot_Atta)/day;
						Da=Convert.ToDouble(SqlDtr["allowances_da"]);
						Da_Rs=( Bas_sal*Da)/100;
						Ta=Convert.ToDouble(SqlDtr["allowances_ta"]);
						Hra=Convert.ToDouble(SqlDtr["allowances_hra"]);
						Arears=Convert.ToDouble(SqlDtr["arrears"]);
						Cca=Convert.ToDouble(SqlDtr["allowances_cca"]);
						Spe_All=Convert.ToDouble(SqlDtr["allowances_Medical"]);
						Incre=Convert.ToDouble(SqlDtr["Increment"]);
						Epf=Convert.ToDouble(SqlDtr["Deduction_pf"]);
						Panl=Convert.ToDouble(SqlDtr["pendedu"]);
						Loan=Convert.ToDouble(SqlDtr["Deduction_other"]);
						P_tex=Convert.ToDouble(SqlDtr["Deduction_tax"]);
						Benefit=Convert.ToDouble(SqlDtr["allowances_benefits"]);
						Security=Convert.ToDouble(SqlDtr["security"]);
						Gros_Sal=Bas_sal+Da_Rs;
						if(Basic_sal>=6500)
						{
							epf_Amo=(Gros_Sal*Epf)/100;
						}
						else
						{
							epf_Amo=0;
						}
						Gros_Sal=Gros_Sal+Ta+Hra+Cca+Spe_All+Arears;
						//22.09.08 Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit;
						Tot_Dedu=epf_Amo+Panl+Loan+P_tex+Benefit+Security;
						Net_Sal=(Gros_Sal+Incre)-Tot_Dedu;
						EmployeeClass obj1=new EmployeeClass();
						SqlDataReader Sql1=null;
						string str1="select count(*) from staff_salary where dateof='"+MonthYear+"' and emp_id="+Convert.ToInt32(SqlDtr["Staff_ID"]);
						Sql1=obj1.GetRecordSet(str1);
						int count2=0;
						if(Sql1.Read())
						{
							count2=Convert.ToInt32(Sql1.GetValue(0));
						}
						Sql1.Close();
						if(count2>0)
						{   
							str1="update staff_salary set Bas_Sal="+Math.Round(Bas_sal)+",DA="+Math.Round(Da_Rs)+",HRA="+Hra+",TA="+Ta+",CCA="+Cca+",Arrear="+Arears+",Spe_All="+Spe_All+",Gross_Sal="+Math.Round(Gros_Sal)+",EPF="+Math.Round(epf_Amo)+",Loan="+Loan+",Panal="+Panl+",P_Tax="+P_tex+",Benefit="+Benefit+",Security="+Security+",Incr="+Incre+",Net_Sal="+Math.Round(Net_Sal)+" where DateOf='"+MonthYear+"' and Emp_ID="+Convert.ToInt32(SqlDtr["Staff_ID"]);                                                                                                                                                                                                             
							
						}
						else
						{
							str1="insert into Staff_Salary (DateOf,Emp_ID,Bas_Sal,DA,HRA,TA,CCA,Arrear,Spe_All,Gross_Sal,EPF,Loan,Panal,P_Tax,Benefit,Security,Incr,Net_Sal) values ('"+MonthYear+"',"+Convert.ToInt32(SqlDtr["Staff_ID"])+","+Math.Round(Bas_sal)+","+Math.Round(Da_Rs)+","+Hra+","+Ta+","+Cca+","+Arears+","+Spe_All+","+Math.Round(Gros_Sal)+","+Math.Round(epf_Amo)+","+Loan+","+Panl+","+P_tex+","+Benefit+","+Security+","+Incre+","+Net_Sal+")";
						}
						obj1.ExecRecord(str1);
						i++;
					}
					SqlDtr.Close();
				}
				dr1.Close();
				MessageBox.Show("Salary Saved for "+Dropmonth.SelectedItem.Value+" "+Dropyear.SelectedValue);
				Dropmonth.SelectedIndex=0;
				Dropyear.SelectedIndex=0;
				CreateLogFiles.ErrorLog(" Form : Complitesalarydata.aspx,Method  Search_ServerClick, Complite Salary Report Viewed , Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : CompleteSalary_Report.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
	}
}