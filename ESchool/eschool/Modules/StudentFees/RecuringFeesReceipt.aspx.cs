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
using eschool.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using RMG;

# endregion

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for RecuringFeesReceipt.
	/// </summary>
	public class RecuringFeesReceipt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Txtcategory;
		protected System.Web.UI.WebControls.TextBox TxtRemarks;
		protected System.Web.UI.WebControls.TextBox TxtPeriod;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.CompareValidator cvDate;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lbl;
		protected System.Web.UI.WebControls.RegularExpressionValidator revRemarks;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox DropClass;
		protected System.Web.UI.WebControls.TextBox TxtFname;
		protected System.Web.UI.WebControls.TextBox txtdf;
		protected System.Web.UI.WebControls.TextBox txttf;
		protected System.Web.UI.WebControls.TextBox txtcf;
		protected System.Web.UI.WebControls.TextBox txtsf;
		protected System.Web.UI.WebControls.TextBox txtaf;
		protected System.Web.UI.WebControls.TextBox txtgf;
		protected System.Web.UI.WebControls.TextBox txtlf;
		protected System.Web.UI.WebControls.TextBox txttrf;
		protected System.Web.UI.WebControls.TextBox txtadf;
		protected System.Web.UI.WebControls.TextBox txtcmf;
		protected System.Web.UI.WebControls.TextBox txtanf;
		protected System.Web.UI.WebControls.TextBox DropStudentID;
		protected System.Web.UI.WebControls.TextBox txtef;
		protected System.Web.UI.WebControls.TextBox txthf;
		protected System.Web.UI.WebControls.TextBox txtFathername;
		//protected System.Web.UI.WebControls.TextBox txtAmt;
		protected System.Web.UI.WebControls.DropDownList dropmop;
		protected System.Web.UI.WebControls.TextBox txtamt;
		protected System.Web.UI.WebControls.TextBox txtchno;
		protected System.Web.UI.WebControls.TextBox txtchDate;
		protected System.Web.UI.WebControls.Panel PanCheque;
		protected System.Web.UI.WebControls.TextBox txtdraftno;
		protected System.Web.UI.WebControls.TextBox txtdraftDate;
		protected System.Web.UI.WebControls.Panel PanDraft;
		//protected System.Web.UI.WebControls.TextBox txtAmount;
		protected System.Web.UI.WebControls.Button btnprint;
		protected System.Web.UI.WebControls.Label lblFeeID;
		protected System.Web.UI.WebControls.DropDownList DropFeeID;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.Button btnupdate;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.TextBox TextStream;
		protected System.Web.UI.WebControls.DropDownList DropFeesType;
		protected System.Web.UI.WebControls.DropDownList dropselect;
		protected System.Web.UI.WebControls.TextBox txtscat;
		protected System.Web.UI.WebControls.TextBox txtrank;
		protected System.Web.UI.WebControls.DropDownList Dropyearfrom;
		protected System.Web.UI.WebControls.DropDownList Dropyearto;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempSection;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempCaution;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempYearly;
		protected System.Web.UI.WebControls.DropDownList DropTo;
		static double admissionfee=0;
		protected System.Web.UI.WebControls.DropDownList Dropbankch;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtBankname;
		protected System.Web.UI.WebControls.TextBox TextComputer;
		protected System.Web.UI.WebControls.TextBox TxtAmount;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		static int flag=0;
		protected System.Web.UI.WebControls.TextBox txtSection;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.TextBox TxtcurDate;
		protected System.Web.UI.WebControls.TextBox TxtcurDate1;
		static string section="";
		public double anualfee;
		public double diaryfee;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Tempdiary;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempDevlop;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempLate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Tempanual;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempTuti;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempCompu;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempHouse;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempScie;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempActi;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempTrans;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempGemes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TempAdmiss;
		protected System.Web.UI.HtmlControls.HtmlInputHidden texthidden;
		public double devlopfee;
		public double Latefee;
		public double tutionfee;
		public double addmissfee;
		public double gamesfee;
		public double sciencefee;
		public double compfee;
		public double transfee;
		public double housfee;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.DropDownList Dropbankdrft;
		protected System.Web.UI.WebControls.DropDownList DropBankChque;
		protected System.Web.UI.WebControls.DropDownList Dropbankdr;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		public double actifee;
		SqlConnection con3;
		static ArrayList LedgerID= new ArrayList();
		static string Receipt_no="";
		static string Invoice_Date = "";
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
				CreateLogFiles.ErrorLog (" Form : Recuring_FeesReceipt.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Recuring_FeesReceipt.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{				
				//string pass;
				//pass=(Session["password"].ToString ());
				PanCheque.Visible=true;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				NextFeeID();
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  PageLoad, Userid :  "+ pass   );		
				if(!Page.IsPostBack)
				{
					Cache["FromMonth"]="";
					Cache["FromYear"]="";
					
					PanDraft.Visible=false;
					txtamt.Enabled=false;
					DropTo.Enabled=false;
					TxtPeriod.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtdraftDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtchDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtcurDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtcurDate1.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;

					# region Dropdown ClassID
					SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
					btnupdate.Visible=false;
					DropFeeID.Visible=false;
					lblFeeID.Visible=true;
					DropTo.Items.Clear ();
					DropTo.Items.Add("Select"); 
					dropselect.Visible =true;
					dropselect.Items.Add("Select");
					dropselect.Items.Add("Jan");
					DropTo.Items.Add("Jan"); 
					dropselect.Items .Add ("Feb");
					DropTo.Items .Add("Feb"); 
					dropselect.Items.Add("Mar");
					DropTo.Items.Add("Mar"); 
					dropselect.Items .Add ("Apr"); 
					DropTo.Items.Add("Apr"); 
					dropselect.Items.Add("May");
					DropTo.Items.Add("May"); 
					dropselect.Items .Add ("Jun");
					DropTo.Items.Add("Jun"); 
					dropselect.Items.Add("Jul");
					DropTo.Items.Add("Jul"); 
					dropselect.Items .Add ("Aug");
					DropTo.Items.Add("Aug"); 
					dropselect.Items.Add("Sep");
					DropTo.Items.Add("Sep"); 
					dropselect.Items .Add ("Oct");
					DropTo.Items.Add("Oct"); 
					dropselect.Items.Add("Nov");
					DropTo.Items.Add("Nov"); 
					dropselect.Items .Add ("Dec");
					DropTo.Items.Add("Dec"); 
					Dropyearfrom.Items.Add("Select");
					Dropyearto.Items.Add("Select");
					for(int i=2000;i<=2030;i++)
					{
						Dropyearfrom.Items.Add(i.ToString());
						Dropyearto.Items.Add(i.ToString());
					}
					# endregion 
					
					SqlDataReader rdr,rdr1;;
					//rdr=obj.GetRecordSet("Select distinct bankid, bankname  From Bankinfo order by bankid asc");
					rdr=obj.GetRecordSet("Select Ledger_Name,Ledger_ID from Ledger_Master lm,Ledger_master_sub_grp lmsg  where  lm.sub_grp_id = lmsg.sub_grp_id and (lmsg.sub_grp_name  like 'Bank%')  Order by Ledger_Name");
					//Dropbankch.Items.Clear ();  
					DropBankChque.Items.Clear();
					Dropbankdrft.Items.Clear();
					Dropbankdrft.Items.Add("Select");
					DropBankChque.Items.Add("Select");
					//Dropbankch.Items .Add ("Select"); 
					while(rdr.Read()) 
					{
						//Dropbankch.Items.Add(rdr.GetString(1).Trim()+":"+rdr.GetValue(0).ToString().Trim());
						//Dropbankdr.Items.Add(rdr.GetString(1).Trim()+":"+rdr.GetValue(0).ToString().Trim());
						//Dropbankch.Items.Add(rdr.GetValue(0).ToString().Trim());
						//Dropbankdr.Items.Add(rdr.GetValue(0).ToString().Trim());
						DropBankChque.Items.Add(rdr.GetValue(0).ToString().Trim()+":"+rdr.GetValue(1).ToString().Trim());
						Dropbankdrft.Items.Add(rdr.GetValue(0).ToString().Trim()+":"+rdr.GetValue(1).ToString().Trim());
					}
					rdr.Close();
					
					FillBank();
					Cache["Start"]="";

					
					rdr1=obj.GetRecordSet("Select Student_fname,Student_id from Student_record");
					while(rdr1.Read()) 
					{
						//MessageBox.Show(texthidden.Value+":"+rdr1.GetString(0).Trim()+" :"+rdr1.GetValue(1).ToString().Trim());
						//texthidden.Value+=rdr1.GetString(0).Trim()+":"+rdr1.GetValue(1).ToString().Trim()+",";
						texthidden.Value+=rdr1.GetValue(1).ToString()+",";
					}
					//MessageBox.Show(texthidden.Value);
					rdr1.Close();
				}
			 
				if(!IsPostBack)
				{
                    TxtFname.Attributes.Add("readonly", "readonly");
                    TextStream.Attributes.Add("readonly", "readonly");
                    TextComputer.Attributes.Add("readonly", "readonly");
                    txtFathername.Attributes.Add("readonly", "readonly");
                    txtdf.Attributes.Add("readonly", "readonly");
                    txttf.Attributes.Add("readonly", "readonly");
                    txtcf.Attributes.Add("readonly", "readonly");
                    txtsf.Attributes.Add("readonly", "readonly");

                    txtaf.Attributes.Add("readonly", "readonly");
                    txtgf.Attributes.Add("readonly", "readonly");
                    txttrf.Attributes.Add("readonly", "readonly");
                    txtadf.Attributes.Add("readonly", "readonly");

                    txtcmf.Attributes.Add("readonly", "readonly");
                    txtanf.Attributes.Add("readonly", "readonly");
                    txtef.Attributes.Add("readonly", "readonly");
                    txthf.Attributes.Add("readonly", "readonly");

                    TxtAmount.Attributes.Add("readonly", "readonly");
                    TxtPeriod.Attributes.Add("readonly", "readonly");
                    txtchDate.Attributes.Add("readonly", "readonly");
                    TxtcurDate.Attributes.Add("readonly", "readonly");

                    txtdraftDate.Attributes.Add("readonly", "readonly");
                    TxtcurDate1.Attributes.Add("readonly", "readonly");
                    TxtcurDate.Attributes.Add("readonly", "readonly");

                    #region Check Privileges
                    int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="7";
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
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				//return;
			}	
			
		}
		
		/// <summary>
		/// this method use to fill data in dropdown from recuringreceipt table.   
		/// </summary>
		public void FillBank()
		{
			SqlDataReader rdr=null;
			SchoolClass .SchoolMgs obj1= new SchoolClass .SchoolMgs ();
			rdr=obj1.GetRecordSet("Select distinct chbank from RecuringReceipt");
			Dropbankch.Items.Clear();
			Dropbankdr.Items.Clear();
			Dropbankch.Items.Add("Select");
			Dropbankdr.Items.Add("Select");
			while(rdr.Read())
			{
				if(rdr.GetValue(0).ToString().Trim()!="" && rdr.GetValue(0).ToString().Trim()!=null)
				{
					Dropbankch.Items.Add(rdr.GetValue(0).ToString().Trim());
					Dropbankdr.Items.Add(rdr.GetValue(0).ToString().Trim());
				}
			}
			rdr.Close();
			Dropbankch.Items.Add("Other");
			Dropbankdr.Items.Add("Other");
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
			this.DropFeeID.SelectedIndexChanged += new System.EventHandler(this.DropFeeID_SelectedIndexChanged);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.DropStudentID.TextChanged += new System.EventHandler(this.DropStudentID_TextChanged);
			this.txtFathername.TextChanged += new System.EventHandler(this.txtFathername_TextChanged);
			this.dropselect.SelectedIndexChanged += new System.EventHandler(this.dropselect_SelectedIndexChanged);
			this.Dropyearfrom.SelectedIndexChanged += new System.EventHandler(this.Dropyearfrom_SelectedIndexChanged);
			this.DropTo.SelectedIndexChanged += new System.EventHandler(this.DropTo_SelectedIndexChanged);
			this.Dropyearto.SelectedIndexChanged += new System.EventHandler(this.Dropyearto_SelectedIndexChanged);
			this.txtdf.TextChanged += new System.EventHandler(this.txtdf_TextChanged);
			this.txttf.TextChanged += new System.EventHandler(this.txttf_TextChanged);
			this.txtcf.TextChanged += new System.EventHandler(this.txtcf_TextChanged);
			this.txtsf.TextChanged += new System.EventHandler(this.txtsf_TextChanged);
			this.txtaf.TextChanged += new System.EventHandler(this.txtaf_TextChanged);
			this.txtgf.TextChanged += new System.EventHandler(this.txtgf_TextChanged);
			this.txtlf.TextChanged += new System.EventHandler(this.txtlf_TextChanged);
			this.txttrf.TextChanged += new System.EventHandler(this.txttrf_TextChanged);
			this.txtadf.TextChanged += new System.EventHandler(this.txtadf_TextChanged);
			this.txtcmf.TextChanged += new System.EventHandler(this.txtcmf_TextChanged);
			this.txtanf.TextChanged += new System.EventHandler(this.txtanf_TextChanged);
			this.txtanf.PreRender += new System.EventHandler(this.txtanf_PreRender);
			this.txtef.TextChanged += new System.EventHandler(this.txtef_TextChanged);
			this.txthf.TextChanged += new System.EventHandler(this.txthf_TextChanged);
			this.TxtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
			this.txtamt.TextChanged += new System.EventHandler(this.txtamt_TextChanged);
			this.dropmop.SelectedIndexChanged += new System.EventHandler(this.dropmop_SelectedIndexChanged);
			this.TxtPeriod.TextChanged += new System.EventHandler(this.TxtPeriod_TextChanged);
			this.txtchDate.TextChanged += new System.EventHandler(this.txtchDate_TextChanged);
			this.Dropbankdrft.SelectedIndexChanged += new System.EventHandler(this.Dropbankdr_SelectedIndexChanged);
			this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this Method use to fetch student_id from student_record table and return student id.
		/// </summary>
		public string ShowStudentID(string seq_studentid)
		{
			string student_id="";
			try
			{
				
				SqlCommand cmdselect3;
				SqlDataReader dtredit3;
			
				cmdselect3 = new SqlCommand( "Select Student_ID From Student_record where seq_student_id='"+seq_studentid+"'", con3 );
				dtredit3 = cmdselect3.ExecuteReader();
				while (dtredit3.Read()) 
				{
					student_id = dtredit3.GetValue(0).ToString();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
			return student_id;
		}
		
		/// <summary>
		/// DateTime Function for returning the date in DD/MM/YYYY
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
		/// Method for getting the student fees in to controls..
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj=new SchoolClass .SchoolMgs ();
				obj.Student_ID=ShowStudentID(DropStudentID.Text.ToString());
				//obj.Student_ID=ShowStudentID(Request.Params.Get(DropStudentID.Value));
				SqlDataReader sdred;
				sdred=obj.ShowStudentInformationForFeesPaid(); 
				while(sdred.Read())
				{				
					TxtFname.Text =sdred.GetValue(0).ToString();
					TextStream .Text =sdred.GetValue(4).ToString();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  DropDownList1_SelectedIndexChanged,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void clear()
		{
			txtdraftDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtchDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtPeriod.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtFname.Text = "";
			TxtAmount.Text="";
			DropClass.Text="";
			DropStudentID.Text="";
			txtSection.Text="";
			dropmop .SelectedIndex =0;
			TextStream .Text = "";
			TextComputer.Text="";
			txtFathername.Text ="";
			txtamt.Text ="";
			txtscat .Text ="";
			TxtRemarks.Text="";
			TempSection.Value="";
			DropBankChque.SelectedIndex=0;
			Dropbankdrft.SelectedIndex=0;
			if(Cache["Start"].ToString()!="")
			{
				TxtPeriod.Text=Cache["Start"].ToString();
			}
			if(Cache["FromMonth"].ToString()!="" || Cache["FromYear"].ToString()!="")
			{
				dropselect.SelectedIndex=dropselect.Items.IndexOf(dropselect.Items.FindByValue(Cache["FromMonth"].ToString()));
				Dropyearfrom.SelectedIndex=Dropyearfrom.Items.IndexOf(Dropyearfrom.Items.FindByValue(Cache["FromYear"].ToString()));
			}
			PanDraft.Visible=false;
			txtrank.Text="";
			txtamt.Enabled=false;
			section="";
			txtchno.Text="";
			txtdraftno.Text="";
			Dropbankch.SelectedIndex=0;
			Dropbankdr.SelectedIndex=0;
			FeesClear();	
		}

		/// <summary>
		/// this method use to Clear the fees controls on the form.
		/// </summary>
		public void FeesClear()
		{
			TempSection.Value="";
			TempYearly.Value="0";
			TempCaution.Value="0";
			admissionfee=0;
			txtdf.Text ="";
			txttf .Text ="";
			txtcf .Text ="";
			txtsf .Text ="";
			txtaf .Text ="";																														
			txtgf .Text ="";
			txtlf .Text ="";
			txttrf .Text ="";
			txtadf .Text ="";
			txtanf .Text ="";
			txtcmf .Text ="";
			txtef .Text ="";
			txthf .Text ="";
			TxtAmount.Text="";
			txtamt.Text="";
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			TxtcurDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			TxtcurDate1.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			DropFeeID.Visible=false;
			btnEdit.Visible=true;
			lblFeeID.Visible=true;
			btnSave.Text="Save";
			clear();
			FeesClear();
		}
			
		string i="";
		public void PrePrintReceipt()
		{

		}

		/// <summary>
		/// this Method use to save the Recuring Fees Receipt information in recuring receipt table. in edit time record delete from recuring receipt.
		/// after that check record allready exist or not.if not then save record in to recuringreceipt table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection cn;
				SqlCommand cmd;
				SqlDataReader dr;
				cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
				
				if(DropFeeID.Visible==true)
				{
					string id=DropFeeID.SelectedItem.Text;
					id=id.Substring(0,id.IndexOf(":"));
					cmd=new SqlCommand("Delete from RecuringReceipt where Recuringid='"+id+"'",cn);
					int n=cmd.ExecuteNonQuery();
					cmd.Dispose();
					cmd=new SqlCommand("Delete from accountsledgertable where particulars='RecuringReceipt("+id+")'",cn);
					n=cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				int m=0,dropval=0;
				dropval=dropval+DropTo.SelectedIndex;
				m=dropval+1-dropselect.SelectedIndex;
				string period=addMonthMMDDYYYY(TxtPeriod.Text,0);
				string periodto=addMonthMMDDYYYY(TxtPeriod.Text,m);
				string str="select count(*) from recuringreceipt where student_id="+DropStudentID.Text+" and (period>='"+period+"'and period<=dateadd(day,-1,'"+periodto+"') or periodto>='"+period+"'and periodto<=dateadd(day,-1,'"+periodto+"'))";
				//string str="select count(*) from recuringreceipt where student_id="+Request.Params.Get(DropStudentID.Value)+" and (period>='"+period+"'and period<=dateadd(day,-1,'"+periodto+"') or periodto>='"+period+"'and periodto<=dateadd(day,-1,'"+periodto+"'))";
				cmd=new SqlCommand(str,cn);
				int icount=0;
				dr=cmd.ExecuteReader();
				if(dr.Read())
				{
					icount=Convert.ToInt32(dr.GetValue(0).ToString().Trim());
				}
				dr.Close();
				if(icount>0)
				{
					MessageBox.Show(" Fees Allready Submited ");
				}
				else
				{
					int Flag=0;
					Flag=SaveMonth();
					if(MNS==1)
					{
						MNS=0;
						return;
					}
					flag=1;
					
					FillBank();
					clear();
					NextFeeID();
				}
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click, Userid :  "+ pass   );		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to update closing balance of AccountsLedgerTable from selected date.
		/// </summary>
		public void AccountledgerUpdate()
		{
			SqlDataReader rdr=null;
			SqlCommand cmd;
			InventoryClass obj =new InventoryClass();
			SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			double Bal=0;
			string BalType="",str="";
			int i=0;
			//*************************
			string[] CheckDate = Invoice_Date.Split(new char[] {' '},Invoice_Date.Length);
			if(DateTime.Compare(System.Convert.ToDateTime(CheckDate[0].ToString()),System.Convert.ToDateTime(GenUtil.str2MMDDYYYY(TxtcurDate.Text)))>0)
				Invoice_Date=GenUtil.str2MMDDYYYY(TxtcurDate.Text);
			for(int k=0;k<LedgerID.Count;k++)
			{
				rdr = obj.GetRecordSet("select top 1 Entry_Date from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date<='"+Invoice_Date+"' order by entry_date desc");
				if(rdr.Read())
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' and Entry_Date>='"+rdr.GetValue(0).ToString()+"' order by entry_date";
				else
					str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID[k].ToString()+"' order by entry_date";
				rdr.Close();
				//*************************
				//string str="select * from AccountsLedgerTable where Ledger_ID='"+LedgerID+"' order by entry_date";
				rdr=obj.GetRecordSet(str);
				Bal=0;
				BalType="";
				i=0;
				while(rdr.Read())
				{
					if(i==0)
					{
						BalType=rdr["Bal_Type"].ToString();
						Bal=double.Parse(rdr["Balance"].ToString());
						i++;
					}
					else
					{
						if(double.Parse(rdr["Credit_Amount"].ToString())!=0)
						{
							if(BalType=="Cr")
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal+=double.Parse(rdr["Credit_Amount"].ToString());
								BalType="Cr";
							}
							else
							{
								string ss=rdr["Credit_Amount"].ToString();
								Bal-=double.Parse(rdr["Credit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Cr";
								}
								else
									BalType="Dr";
							}
						}
						else if(double.Parse(rdr["Debit_Amount"].ToString())!=0)
						{
							if(BalType=="Dr")
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal+=double.Parse(rdr["Debit_Amount"].ToString());
							}
							else
							{
								string ss=rdr["Debit_Amount"].ToString();
								Bal-=double.Parse(rdr["Debit_Amount"].ToString());
								if(Bal<0)
								{
									Bal=double.Parse(Bal.ToString().Substring(1));
									BalType="Dr";
								}
								else
									BalType="Cr";
							}
						}
						Con.Open();
						string str11="update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'";
						cmd = new SqlCommand("update AccountsLedgerTable set Balance='"+Bal.ToString()+"',Bal_Type='"+BalType+"' where Ledger_ID='"+rdr["Ledger_ID"].ToString()+"' and Particulars='"+rdr["Particulars"].ToString()+"'",Con);
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						Con.Close();
					}		
				}
				rdr.Close();
			}
		}

		/// <summary>
		/// Method for update the Recuring Fees Receipt information in torecuringreceipt table.
		/// </summary>
		private void btnupdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Update();
				flag=1;
				clear();
				NextFeeID();
											 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
			}

		}
		private void DropClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method use to check if Studentid Not in Tc And Stuck off table Then Fetch All record of student from student_record table.
		/// </summary>
		string msg="";
		private void DropStudentID_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
				SqlDataReader SqlDtr;
				SqlDataReader SqlD;
				if(DropStudentID.Text!="")
					//if(Request.Params.Get(DropStudentID.Value)!="")
				{
					string str5="select count(*) from tc1 where Student_id='"+DropStudentID.Text+"'";
					//string str5="select count(*) from tc1 where Student_id='"+Request.Params.Get(DropStudentID.Value)+"'";
					SqlD=obj.GetRecordSet(str5);
					int icount=0;
					while(SqlD.Read())
					{
						icount=Convert.ToInt32(SqlD.GetSqlValue(0).ToString().Trim());
					}
					SqlD.Close();
                    
					string str6="select count(*) from Stuck_Off where Student_id='"+DropStudentID.Text+"'";
					//string str6="select count(*) from Stuck_Off where Student_id='"+Request.Params.Get(DropStudentID.Value)+"'";
					SqlD=obj.GetRecordSet(str6);
					int icount1=0;
					while(SqlD.Read())
					{
						icount1=Convert.ToInt32(SqlD.GetSqlValue(0).ToString().Trim());
					}
					SqlD.Close();
					if(icount>0 || icount1>0)
					{
						MessageBox.Show("Student Has Been TC Or Stuck Off");
						clear();
						return;
					}
					else
					{
						string str="select Student_ID,Student_FName,Student_FatherName,Student_Stream,rank,scategory,seq_student_id,computer,Student_Class,Seq_Student_ID from Student_record where Student_id='"+DropStudentID.Text+"'";
						//string str="select Student_ID,Student_FName,Student_FatherName,Student_Stream,rank,scategory,seq_student_id,computer,Student_Class,Seq_Student_ID from Student_record where Student_id='"+Request.Params.Get(DropStudentID.Value)+"'";
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.HasRows)
						{
							while(SqlDtr.Read())
							{
								DropStudentID.Text=SqlDtr["Student_ID"].ToString();
								DropClass.Text=SqlDtr["Student_Class"].ToString();
								txtSection.Text=SqlDtr["Seq_Student_ID"].ToString();
								TxtFname.Text=SqlDtr.GetValue(1).ToString();
								TextStream.Text=SqlDtr["Student_Stream"].ToString();
								txtscat.Text =SqlDtr["scategory"].ToString ();
								txtrank.Text=SqlDtr["rank"].ToString ();
								TempSection.Value=SqlDtr["seq_student_id"].ToString ();
								section=SqlDtr["seq_student_id"].ToString ();
								txtFathername.Text=SqlDtr["Student_FatherName"].ToString();
								if(SqlDtr["Computer"].ToString().Trim().Equals("Yes"))
									TextComputer.Text="Computer";
								else if(SqlDtr["Computer"].ToString().Trim().Equals("No"))
									TextComputer.Text="Non Computer";
								else
									TextComputer.Text="";
							}
							SqlDtr.Close();
						}
					
						else
						{
							MessageBox.Show("Please Enter Valid Student ID");
							clear();
							return;
						}
					
						string str1="select Fees_type,remarks from recuringreceipt where Student_id='"+DropStudentID.Text+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+DropStudentID.Text+"')";
						SqlDtr=obj.GetRecordSet(str1);                                    
						if(SqlDtr.Read())                                                   
						{
							msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim(); 
							while(SqlDtr.Read())                                              
							{
								msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim();  
								
							}
							MessageBox.Show(msg);                                            
						}
						else
						{
							MessageBox.Show("Fees Not paid");                                
						}
						SqlDtr.Close();                                                      
						flag=0;
						
						if(dropselect.SelectedIndex!=0 && DropTo.SelectedIndex!=0 && Dropyearto.SelectedIndex!=0 && Dropyearfrom.SelectedIndex!=0)
						{
							FeesClear();
							if(Dropyearfrom.SelectedIndex<=Dropyearto.SelectedIndex)
								feesdecisionmonthly();
							else
							{
								MessageBox.Show("Please Select from year less than or equal to to year");
								return;
							}
						}

					}
				}
				else
				{
					MessageBox.Show("Please Enter Valid Student ID");
					clear();
				}				
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}

		}

		/// <summary>
		/// this method use to show or hide controls on the form.
		/// </summary>
		private void dropmop_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtamt.Enabled=true;
				if(dropmop.SelectedItem.Text.Equals("By Cash"))
				{
					PanCheque.Visible=false;
					PanDraft.Visible=false;
				}
				else if(dropmop.SelectedItem.Text.Equals("By Cheque"))
				{
					PanCheque.Visible=true;
					PanDraft.Visible=false;
				}
				else if(dropmop.SelectedItem.Text.Equals("By Draft"))
				{
					PanCheque.Visible=false;
					PanDraft.Visible=true;
				}
				else
				{
					PanCheque.Visible=false;
					PanDraft.Visible=false;
					txtamt.Enabled=false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: RecuringFeesReceipt.aspx.cs, Method: dropmop_SelectedIndexChanged . Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// Fetch Information about bank.
		/// this method not in use.
		/// </summary>
		public void Bankinfo()
		{
			try
			{
				string Bankinf=" ";
				SqlConnection cn;
				SqlCommand cmd;
				SqlDataReader dr;
				cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
				cmd=new SqlCommand("Select distinct bankid, bankname  From Bankinfo order by bankid asc",cn);
				dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					Bankinf=Bankinf+","+dr.GetString(1).ToString().Trim()+":"+dr.GetValue(0).ToString().Trim();
				}
				txtBankname.Value=Bankinf;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void txtdbname_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		/// <summary>
		/// this method use to check textbox blank or not.
		/// </summary>
		private void txtamt_TextChanged(object sender, System.EventArgs e)
		{
			if(txtamt.Text=="")
				txtamt.Text="0";
			if(double.Parse(txtamt.Text)!=double.Parse(TxtAmount.Text))
			{
				txtamt.Text="0";
				MessageBox.Show("Please Enter the same value as Fees Amount");
				return;
			}
		}

		/// <summary>
		/// check the start period of querter
		/// </summary>
		private void dropselect_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropStudentID.Text=="")
				//if(Request.Params.Get(DropStudentID.Value)=="")
			{
				MessageBox.Show("Please Enter the Student Id");
				return;
			}
			if(dropselect.SelectedIndex!=0 && DropTo.SelectedIndex!=0 && Dropyearto.SelectedIndex!=0 && Dropyearfrom.SelectedIndex!=0)
			{
				FeesClear();
				if(dropselect.SelectedIndex<10)
				{
					TxtPeriod.Text="01"+"/0"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
					Cache["Start"]=TxtPeriod.Text;
				}
				else
				{
					TxtPeriod.Text="01"+"/"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
					Cache["Start"]=TxtPeriod.Text;
				}
				if(Dropyearfrom.SelectedIndex<=Dropyearto.SelectedIndex)
					feesdecisionmonthly();
				else if(dropselect.Visible==true)
				{
					MessageBox.Show("Please Select from year less than or equal to to year");
					return;
				}
			}
		}

		/// <summary>
		/// this Method Use To Save the Information with the help of InsertStudentRecuringReceipt() function.and also use 'ProInsertStudentRecuring' procedure.
		/// record save in to recuringreceipt table.
		/// </summary>
		public void save()
		{
			try
			{
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				if(DateTime.Compare(ToMMddYYYY(TxtPeriod.Text),ToMMddYYYY(sSysDate))<0)
				{
					MessageBox.Show("From date must be greater than or equal to current date");
				}
				else
				{
					string ToDate=TxtPeriod.Text;
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					MakingReport();
					obj.RecuringID=lblFeeID.Text;
					obj.Fees_Type ="";
					if(dropselect.SelectedIndex==0)
						obj.Fees_Type ="";
					else
						obj.Fees_Type =dropselect.SelectedItem.Text.Trim();
					if(DropStudentID.Text =="")
						//if(Request.Params.Get("DropStudentID").ToString()=="")
						obj.Student_ID ="";
					else
						obj.Student_ID =DropStudentID.Text;
					//obj.Student_ID =Request.Params.Get(DropStudentID.Value);
					if(TxtPeriod .Text=="")
						obj.Period ="";
					else
						obj.Period =ToMMddYYYY(TxtPeriod.Text.Trim().ToUpper()).ToShortDateString();
					if(txtchno.Text=="")
						obj.Cheque_No="";
					else
						obj.Cheque_No =txtchno.Text.Trim();
					if(txtdraftno.Text=="")
						obj.draftno="";
					else
						obj.draftno =txtdraftno.Text.Trim().ToUpper();
					if(txtamt.Text=="")
						obj.Fees_Amount="";
					else
						obj.Fees_Amount=txtamt.Text.Trim().ToUpper();
					
					if(TxtRemarks .Text=="")
						obj.Remarks="";
					else
						obj.Remarks =TxtRemarks.Text.Trim().ToUpper(); 
					
					if(Dropbankch.SelectedItem.Text=="")
						obj.Bank_Name="";
					else
						obj.Bank_Name=Dropbankch.SelectedItem.Text.Trim().ToUpper(); 

					if(Dropbankdr.SelectedItem.Text=="")
						obj.BankName="";
					else
						obj.BankName=Dropbankch.SelectedItem.Text.Trim().ToUpper();

					if(dropmop.SelectedItem.Text.Trim().Equals("By Cheque"))
					{
						
						obj.Cheque_Date="";
						
						obj.Cheque_Date=GenUtil.str2MMDDYYYY(txtchDate.Text.Trim().ToString()); 
					}
					else
						obj.Cheque_Date="";
					if(dropmop.SelectedItem.Text.Trim().Equals("By Draft"))
					{
						obj.ChequeDate =GenUtil.str2MMDDYYYY(txtdraftDate.Text.Trim().ToString()); 
					}
					else
						obj.ChequeDate="";
					if(dropmop.SelectedIndex==0)
						obj.PaymentMode="";
					else
						obj.PaymentMode=dropmop.SelectedItem.Text; 
						
					obj.InsertStudentRecuringReceipt();
						
					MessageBox.Show("Record Successfully Saved");
					CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Record save for studentID :"+ DropStudentID.Text.ToString()+", Userid :  "+ pass);
					
				}
				 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
			}
		}
		
		/// <summary>
		/// this Method Use To Create fees receipt in a particular format.and data fetch from controls.
		/// </summary>
		public void MakingReport()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\FeesReport.txt";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eschoolprintservice\FeesReport.txt";
				StreamWriter sw = new StreamWriter(path);
				sw.Write((char)27);
				sw.Write((char)64);
				sw.Write((char)27);
				sw.Write((char)67); 
				sw.Write((char)0); 
				sw.Write((char)4); 		
				sw.Write((char)27);
				sw.Write((char)107);
				sw.Write((char)1);
				sw.WriteLine();
				sw.WriteLine();
				sw.Write((char)27); 
				sw.Write((char)51); 
				sw.Write((char)25); 				
				string info="{0,-4:S}  {1,-22:S} {2,-5:S} {3,-6:S} {4,-5:S} {5,-10:S}";//vi
				string info1="{0,-12:S}  {1,-60:S}";//vi
				string info2="{0,-1:S} {1,-14:S} {2,-10:S} {3,-14:S} {4,-12:S}";
				string info3="{0,-6:S} {1,-15:S} {2,-8:S} {3,-10:S} {4,-5:S}{5,-10:S}";
				string info4="{0,-1:S}{1,-57:S}";
				sw.WriteLine();
				sw.WriteLine();
				if(lblFeeID.Visible==true)		
					sw.WriteLine(info3,"",DropStudentID.Text,"",lblFeeID.Text,"",GenUtil.str2DDMMYYYY(DateTime.Now.ToShortDateString()));
					//sw.WriteLine(info3,"",Request.Params.Get(DropStudentID.Value),"",lblFeeID.Text,"",GenUtil.str2DDMMYYYY(DateTime.Now.ToShortDateString()));
				else
					sw.WriteLine(info3,"",DropStudentID.Text,"",DropFeeID.SelectedItem.Text.Substring(0,DropFeeID.SelectedItem.Text.IndexOf(":")),"",TxtcurDate1.Text);
				//sw.WriteLine(info3,"",Request.Params.Get(DropStudentID.Value),"",DropFeeID.SelectedItem.Text.Substring(0,DropFeeID.SelectedItem.Text.IndexOf(":")),"",TxtcurDate1.Text);
				sw.WriteLine();
				sw.WriteLine(info,"",TxtFname.Text.ToString().ToUpper(),"",DropClass.Text,"",txtSection.Text);
				sw.WriteLine();
				sw.WriteLine(info1,"",txtFathername.Text.ToUpper());
				sw.WriteLine();
				if(txtadf.Text.Equals(""))
					txtadf.Text="0";
				if(txtsf.Text.Equals(""))
					txtsf.Text="0";
				sw.WriteLine(info2,"","ADMISSION FEE",txtadf.Text,"SCIENCE FEE",txtsf.Text);
				if(txtcmf.Text.Equals(""))
					txtcmf.Text="0";
				if(txttrf.Text.Equals(""))
					txttrf.Text="0";

				sw.WriteLine(info2,"","SECURITY FEE",txtcmf.Text,"TRANSPORT FEE",txttrf.Text);
				if(txtanf.Text.Equals(""))
					txtanf.Text="0";
				if(txtdf.Text.Equals(""))
					txtdf.Text="0";

				sw.WriteLine(info2,"","DIARY FEE",txtdf.Text,"ANNUAL FEE",txtanf.Text);
				if(txttf.Text.Equals(""))
					txttf.Text="0";
				if(txtcf.Text.Equals(""))
					txtcf.Text="0";

				sw.WriteLine(info2,"","TUTION FEE",txttf.Text,"COMPUTER FEE",txtcf.Text);
				if(txtlf.Text.Equals(""))
					txtlf.Text="0";
				if(txthf.Text.Equals(""))
					txthf.Text="0";

				sw.WriteLine(info2,"","LATE FEE",txtlf.Text,"HOUSE FEE",txthf.Text);
				if(txtaf.Text.Equals(""))
					txtaf.Text="0";
				if(txtgf.Text.Equals(""))
					txtgf.Text="0";
							
				sw.WriteLine(info2,"","GAME FEE",txtgf.Text,"Env FEE",txtef.Text);
				sw.WriteLine();
				
				sw.WriteLine(info4,"","Fees Paid For "+GenUtil.ConvertMonthName(TxtPeriod.Text)+" To "+DropTo.SelectedItem.Text.Trim()+" "+Dropyearto.SelectedItem.Text.Trim() );
				if(dropmop.SelectedIndex==1)
				{
					string str="Vide Draft no "+txtdraftno.Text.Trim()+" Dated "+txtdraftDate.Text.Trim()+" of "+Dropbankdr.SelectedItem.Text.Trim();
					if(str.Length>57)
					{
						
						sw.WriteLine(info4,"","Vide Draft no "+txtdraftno.Text.Trim()+" Dated "+txtdraftDate.Text.Trim());
						sw.WriteLine(info4,"","of "+Dropbankdr.SelectedItem.Text.Trim());
					}
					else
						
						sw.WriteLine(info4,"","Vide Draft no "+txtdraftno.Text.Trim()+" Dated "+txtdraftDate.Text.Trim()+" of "+Dropbankdr.SelectedItem.Text.Trim());
				}
				else if(dropmop.SelectedIndex==0)
				{
					string str="Vide Cheque no "+txtchno.Text.Trim()+" Dated "+txtchDate.Text.Trim()+" of "+Dropbankch.SelectedItem.Text.Trim();
					if(str.Length>57)
					{
						
						sw.WriteLine(info4,"","Vide Cheque no "+txtchno.Text.Trim()+" Dated "+txtchDate.Text.Trim());	
						sw.WriteLine(info4,"","of "+Dropbankch.SelectedItem.Text.Trim());
					}
					else
						
						sw.WriteLine(info4,"","Vide Cheque no "+txtchno.Text.Trim()+" Dated "+txtchDate.Text.Trim()+" of "+Dropbankch.SelectedItem.Text.Trim());
				}
				else 
				{
					sw.WriteLine(info4,"","Fees Paid by cash");
				}
				
				sw.WriteLine(info4,"",TxtRemarks.Text.Trim());
				sw.WriteLine();
				sw.WriteLine();
				sw.WriteLine(info1,"",GenUtil.strNumericFormat(TxtAmount.Text));
				sw.WriteLine();
				sw.WriteLine(info1,"",ConvertNoToWord(TxtAmount.Text));
				sw.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  MakingReport,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}

		}

		/// <summary>
		/// this Method use to update the record in recuringreceipt table.
		/// this method not in use.
		/// </summary>
		public void Update()
		{
		
			try
			{
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				if(DateTime.Compare(ToMMddYYYY(TxtPeriod.Text),ToMMddYYYY(sSysDate))<0)
				{
					MessageBox.Show("From date must be greater than or equal to current date");
				}
				else
				{
					SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
					MakingReport();
					obj.RecuringID=DropFeeID.SelectedItem.Text;
					if(DropFeesType.SelectedIndex ==0)
						obj.Fees_Type ="";
					else
					{
						obj.Fees_Type =DropFeesType .SelectedItem .Text .Trim ().ToString ()+":"+dropselect.SelectedItem.Text.Trim();
					}
					obj.Student_ID =DropStudentID.Text.ToString();
					//obj.Student_ID =Request.Params.Get(DropStudentID.Value).ToString();
					if(TxtPeriod .Text=="")
						obj.Period ="";
					else
						obj.Period =ToMMddYYYY(TxtPeriod.Text.Trim().ToUpper()).ToShortDateString();
					obj.PeriodTo ="";
					
					if(txtchno.Text=="")
						obj.Cheque_No="";
					else
						obj.Cheque_No =txtchno.Text.Trim();
					if(txtdraftno.Text=="")
						obj.draftno="";
					else
						obj.draftno =txtdraftno.Text.Trim().ToUpper();
					if(txtamt.Text=="")
						obj.Fees_Amount="";
					else
						obj.Fees_Amount=txtamt.Text.Trim().ToUpper();
					obj.AmountDue="";
					obj.EnteredBy="";
					if(TxtRemarks .Text=="")
						obj.Remarks="";
					else
						obj.Remarks =TxtRemarks.Text.Trim().ToUpper(); 
					if(dropmop .SelectedItem .Text .Equals ("By Cheque"))
					{
						obj.Cheque_Date="";
						obj.Cheque_Date=GenUtil.str2MMDDYYYY(txtchDate.Text.Trim().ToString()); 
					}
					else
						obj.Cheque_Date="";
					if(dropmop .SelectedItem .Text .Equals ("By Draft"))
					{
						obj.DrDate ="";
						obj.DrDate=GenUtil.str2MMDDYYYY(txtdraftDate.Text.Trim().ToString()); 
					}
					else
						obj.DrDate ="";
					if(dropmop.SelectedIndex==0)
						obj.PaymentMode="";
					else
						obj.PaymentMode=dropmop.SelectedItem.Text; 
					MessageBox.Show("Record Updated Successfully ");
					CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Record save for studentID :"+ DropStudentID.Text.ToString()+", Userid :  "+ pass);
					lblFeeID.Visible=true;
					DropFeeID.Visible=false;
					btnEdit.Visible=true;
					btnSave.Visible=true;
					btnupdate.Visible=false;
					dropselect.Visible=false;
				}
				 
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		
		/// <summary>
		/// this method use to create connection between remote device.
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
					CreateLogFiles.ErrorLog("Form:CustomerWiseSalseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  userid  ");
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					//byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\eschool\\eschoolprintservice\\FeesReport.txt<EOF>");
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\eschool\\Sysitem\\eschoolprintservice\\FeesReport.txt<EOF>");
					/// Send the data through the socket.http://localhost/eRetail/Forms/Reports/NozzleReport.aspx
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+ane.Message+"  userid  ");
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+se.Message+"  userid  ");
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+es.Message+"  userid  ");
				}
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection cn;
				SqlCommand cmd;
				SqlDataReader dr;
				cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				cn.Open();
				
				if(DropFeeID.Visible==true)
				{
					string id=DropFeeID.SelectedItem.Text;
					id=id.Substring(0,id.IndexOf(":"));
					cmd=new SqlCommand("Delete from RecuringReceipt where Recuringid='"+id+"'",cn);
					int n=cmd.ExecuteNonQuery();
					cmd.Dispose();

					cmd=new SqlCommand("Delete from accountsledgertable where particulars='RecuringReceipt("+id+")'",cn);
					n=cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				int m=0,dropval=0;
				dropval=dropval+DropTo.SelectedIndex;
				m=dropval+1-dropselect.SelectedIndex;
				string period=addMonthMMDDYYYY(TxtPeriod.Text,0);
				string periodto=addMonthMMDDYYYY(TxtPeriod.Text,m);
				int icount=0;
				string str="select count(*) from recuringreceipt where student_id="+DropStudentID.Text+" and (period>='"+period+"'and period<=dateadd(day,-1,'"+periodto+"') or periodto>='"+period+"'and periodto<=dateadd(day,-1,'"+periodto+"'))";
				//string str="select count(*) from recuringreceipt where student_id="+Request.Params.Get(DropStudentID.Value)+" and (period>='"+period+"'and period<=dateadd(day,-1,'"+periodto+"') or periodto>='"+period+"'and periodto<=dateadd(day,-1,'"+periodto+"'))";
				cmd=new SqlCommand(str,cn);
				dr=cmd.ExecuteReader();
				if(dr.Read())
				{
					icount=Convert.ToInt32(dr.GetValue(0).ToString().Trim());
				}
				dr.Close();
				if(icount>0)
				{
					MessageBox.Show("Fees Allready Submited");
				}
				else
				{
					int Flag=0;
					if(lblFeeID.Visible==true)
					{
						if(flag==0)
						{
							Flag=SaveMonth();
						}
					}
					else  
					{
						if(DropFeeID.Visible==true)
						{
							string id=DropFeeID.SelectedItem.Text;
							id=id.Substring(0,id.IndexOf(":"));
							cmd=new SqlCommand("Delete from RecuringReceipt where Recuringid='"+id+"'",cn);
							int n=cmd.ExecuteNonQuery();
							Flag=0;
							Flag=SaveMonth();
							if(MNS==1)
							{
								MNS=0;
								return;
							}
							flag=1;
							clear();
							NextFeeID();
						}
					}
					if(Flag==0)
						Print();
					else
						return;
					clear();
					NextFeeID();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

		/// <summary>
		/// this method use to fill dropdown drom recuringreceipt table.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
				SqlDataReader sdred;
				lblFeeID.Visible=false;
				DropFeeID.Visible=true;
				btnEdit.Visible=false;
				btnupdate.Visible=false;
				btnSave.Visible=true;
				btnSave.Text="Update";
				string str="select distinct RecuringID,Student_ID from RecuringReceipt where Student_ID<>0 order by RecuringID";
				sdred=obj.GetRecordSet(str);
				DropFeeID.Items.Clear();
				DropFeeID.Items.Add("Select");
				while(sdred.Read())
				{
					DropFeeID.Items .Add (sdred.GetValue(0).ToString()+":"+sdred.GetValue(1).ToString());
				}
				sdred.Close();
				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:RecuringFeesReceipt,Method: btnprint_Click,Class:PetrolPumpClass "+" RecuringFeesReceipt Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}	

		/// <summary>
		/// this method use to Generate Next Id of Recuring Receipt table.
		/// </summary>
		public void NextFeeID()
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="Select  max(RecuringID)+1  From RecuringReceipt";
				SqlDtr=obj.GetRecordSet(str);
				if (SqlDtr.Read()) 
				{
					lblFeeID.Text=SqlDtr.GetValue(0).ToString();
					if(lblFeeID.Text.Trim().Equals(""))
						lblFeeID.Text="1";
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: RecuringFeesReceipt.aspx.cs, Method: NextFeeID. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// When We Select FeesId Then fetch All Information From recuringreceipt table.
		/// </summary>
		private void DropFeeID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				DropBankChque.SelectedIndex=0;
				Dropbankdrft.SelectedIndex=0;
				EmployeeClass obj=new EmployeeClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null,sdtr=null;
				string id=DropFeeID.SelectedItem.Text;
				string[] sid=id.Split(new char[] {':'},id.Length);
				
				string sql="select * from student_record where student_id='"+sid[1].ToString()+"'";
				rdr=obj1.GetRecordSet(sql);
				if(rdr.Read())
				{
					
					txtFathername.Text=rdr["Student_FatherName"].ToString();
					TextStream.Text=rdr["Student_stream"].ToString();
					TxtFname.Text=rdr["Student_FName"].ToString();
					txtscat.Text=rdr["scategory"].ToString();
					txtrank.Text=rdr["rank"].ToString();
					section=rdr["seq_student_id"].ToString();
					txtSection.Text=rdr["seq_student_id"].ToString();
					DropClass.Text=rdr["Student_Class"].ToString();
					//Request.Params.Get(DropStudentID.Value)=rdr["Student_ID"].ToString();
					DropStudentID.Text=rdr["Student_ID"].ToString();
					if(rdr["computer"].ToString().Trim()=="No")
						TextComputer.Text="Non Computer";
					else
						TextComputer.Text="Computer";
				}
				rdr.Close();


				string str1="select lm.ledger_id,lm.Ledger_name,lm.sub_grp_id from ledger_master lm,ledger_master_sub_grp lmsg where lm.sub_grp_id=lmsg.sub_grp_id and lmsg.sub_grp_name like 'Bank%' and lm.Ledger_id in(select ledger_id from accountsledgertable where particulars='RecuringReceipt("+sid[0].ToString()+")')";
				sdtr=obj.GetRecordSet(str1);
				while(sdtr.Read())
				{
					DropBankChque.SelectedIndex=DropBankChque.Items.IndexOf(DropBankChque.Items.FindByValue(sdtr.GetValue(1).ToString().Trim()+":"+sdtr.GetValue(0).ToString().Trim()));
					Dropbankdrft.SelectedIndex=Dropbankdrft.Items.IndexOf(Dropbankdrft.Items.FindByValue(sdtr.GetValue(1).ToString().Trim()+":"+sdtr.GetValue(0).ToString().Trim()));
				}	
				sdtr.Close();	 
				

				string str2="select ledger_id from accountsledgertable where particulars='RecuringReceipt("+sid[0].ToString()+")'";
				sdtr=obj.GetRecordSet(str2);
				while(sdtr.Read())
				{
					LedgerID.Add(sdtr.GetValue(0));
					//MessageBox.Show(sdtr.GetValue(0).ToString());
				}	
				sdtr.Close();
				
				string str="select * from recuringreceipt where recuringid='"+sid[0].ToString()+"'";
				SqlDtr=obj.GetRecordSet(str);
				string ft="",ft1="",ft2="",ft3="";
				int flag=0;
				if(SqlDtr.Read())
				{
					ft=SqlDtr["Fees_Type"].ToString().Trim();
					string[] arrft=new string[2];
					if(ft.IndexOf(":")>0)
					{
						arrft=ft.Split(new char[] {':'},ft.Length);
						ft1=arrft[0].Substring(3);
						ft=arrft[0].Substring(0,3);
						ft3=arrft[1].Substring(3);
						ft2=arrft[1].Substring(0,3);
						flag=1;
					}
					else
					{
						ft1=ft.Substring(3);
						ft=ft.Substring(0,3);
						flag=0;
					}
					dropselect.SelectedIndex=dropselect.Items.IndexOf(dropselect.Items.FindByValue(ft));
					Dropyearfrom.SelectedIndex=Dropyearfrom.Items.IndexOf(Dropyearfrom.Items.FindByValue(ft1));
					TxtPeriod.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["Period"].ToString().Trim()));
					TxtcurDate1.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["FeeSubdt"].ToString().Trim()));
					TxtcurDate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["FeeSubdt"].ToString().Trim()));
					Invoice_Date=SqlDtr["FeeSubdt"].ToString();
					TxtRemarks.Text=SqlDtr["Remarks"].ToString().Trim();
					dropmop.SelectedIndex=dropmop.Items.IndexOf(dropmop.Items.FindByValue(SqlDtr["Paymode"].ToString().Trim()));
					if(dropmop.SelectedIndex==2)
					{
						PanCheque.Visible=false;
						PanDraft.Visible=false;
					}
					else if(dropmop.SelectedIndex==1)
					{
						PanDraft.Visible=true;
						PanCheque.Visible=false;
						txtdraftno.Text=SqlDtr["draftno"].ToString().Trim();
						txtdraftDate .Text =GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["chdate"].ToString().Trim()));
						Dropbankdr.SelectedIndex=Dropbankdr.Items.IndexOf(Dropbankdr.Items.FindByValue(SqlDtr["chbank"].ToString()));
					}
					else if(dropmop.SelectedIndex==0)
					{
						PanDraft.Visible=false;
						PanCheque.Visible=true;
						txtchDate .Text =GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr["chdate"].ToString().Trim()));
						txtchno.Text=SqlDtr["chno"].ToString().Trim();
						Dropbankch.SelectedIndex=Dropbankch.Items.IndexOf(Dropbankch.Items.FindByValue(SqlDtr["chbank"].ToString()));
					}
				}
				SqlDtr.Close();
				if(flag==0)
				{
					str="select * from recuringreceipt where recuringid='"+sid[0].ToString()+"'";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						ft=SqlDtr["Fees_Type"].ToString().Trim();
					}
					ft1=ft.Substring(3);
					ft=ft.Substring(0,3);
					DropTo.SelectedIndex=DropTo.Items.IndexOf(DropTo.Items.FindByValue(ft));
					Dropyearto.SelectedIndex=Dropyearto.Items.IndexOf(Dropyearto.Items.FindByValue(ft1));
				}
				else
				{
					DropTo.SelectedIndex=DropTo.Items.IndexOf(DropTo.Items.FindByValue(ft2));
					Dropyearto.SelectedIndex=Dropyearto.Items.IndexOf(Dropyearto.Items.FindByValue(ft3));
				}
				if(DropTo.SelectedIndex!=0 && Dropyearto.SelectedIndex!=0 && dropselect.SelectedIndex!=0 && Dropyearfrom.SelectedIndex!=0)
				{
					
					str="select * from recuringreceipt where recuringid='"+sid[0].ToString()+"'";
					SqlDtr=obj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						txtdf.Text=GenUtil.strNumericFormat(SqlDtr["diary_fee"].ToString());
						txttf.Text=GenUtil.strNumericFormat(SqlDtr["tution_fee"].ToString());
						txtcf.Text=GenUtil.strNumericFormat(SqlDtr["computer_fee"].ToString());
						txtsf.Text=GenUtil.strNumericFormat(SqlDtr["science_fee"].ToString());
						txtaf.Text=GenUtil.strNumericFormat(SqlDtr["activity_fee"].ToString());
						txtgf.Text=GenUtil.strNumericFormat(SqlDtr["game_fee"].ToString());
						txtlf.Text=GenUtil.strNumericFormat(SqlDtr["latefee"].ToString());
						txttrf.Text=GenUtil.strNumericFormat(SqlDtr["transport_fee"].ToString());
						txtadf.Text=GenUtil.strNumericFormat(SqlDtr["admission_fee"].ToString());
						txtcmf.Text=GenUtil.strNumericFormat(SqlDtr["securityfee"].ToString());
						txtanf.Text=GenUtil.strNumericFormat(SqlDtr["annual_fee"].ToString());
						txtef.Text=GenUtil.strNumericFormat(SqlDtr["envp_fee"].ToString());
						txthf.Text=GenUtil.strNumericFormat(SqlDtr["hostel_fee"].ToString());
						txtamt.Text=GenUtil.strNumericFormat(SqlDtr["fees_amount"].ToString());
						TxtAmount.Text=GenUtil.strNumericFormat(SqlDtr["fees_amount"].ToString());
					}
				}
				DropTo.Enabled=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}
		}

		/// <summary>
		/// this method use Convert number in string.
		/// </summary>
		public string ConvertNoToWord(string number)
		{
			string[] num=new string[2];
			int count=0,div=0;
			if(number.IndexOf(".")>0)
			{
				num=number.Split(new char[] {'.'},number.Length);
				div=System.Convert.ToInt32(num[0]);
			}
			else
				div=System.Convert.ToInt32(number);
			int[] arr1=new int[12];
			int[] arr2=new int[12];
			String[] digit1={"ZERO","ONE","TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE","TEN","ELEVAN","TWELVE","THRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN","TWENTY","THIRTY","FOURTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINTY"};
			String[] digit2 ={"","hundred","thousand","lakh","crore"};   
			String[] array=new String[20];
			while(div>0)
			{
				arr1[count]=div%10;
				div=div/10;
				count++;
			}
			if(count>=10)
			{
				MessageBox.Show("please Enter Nine Digit Number");
				
			}
			if(count==0)
			{
				array[0]="ZERO";
			}
			div=System.Convert.ToInt32(num[0]);
			for(int i=count-1;i>=0;--i)
			{
				if(i==1||i==4||i==6||i==8)
				{
					arr2[i]=arr1[i]*10;
				}
				else
				{
					arr2[i]=arr1[i];
				}
			}
			for(int i=count-1,j=0;i>=0;++j,--i)
			{
				if(i==8&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[4];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[4];
						--i;
						++j;
					}
			  		 
				}
				else if(i==7)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[4];
						++j;
					}
				}
				else if(i==6&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[3];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[3];
						--i;
						++j;
					}
			  		 
				}
				else if(i==5)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[3];
						++j;
					}
				}
				else if(i==4&&arr2[i]!=0)
				{
					int dig=arr2[i];
			  
					if(dig>=20&&arr2[i-1]==0)
					{
						array[j]=digit1[dig/10+18];
						array[j+1]=digit2[2];
						--i;
						++j;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						array[j+1]=digit2[2];
						--i;
						++j;
					}
			  
				}
				else if(i==3)
				{
					if(arr2[i]!=0)
					{			
						int dig=arr2[i]; 
						array[j]=digit1[dig];
						array[j+1]=digit2[2];
						++j;
					}
			
				}
				else if(i==2)
				{
					if(arr2[i]!=0)
					{
						int dig=arr2[i];
						array[j]=digit1[dig];
						array[j+1]=digit2[1];
						++j;
					}
			 			  
				}
				else if(i==1)
				{
					int dig=arr2[i];
					if(dig>=20&&arr2[i]!=0&&arr2[i-1]==0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
						--i;
					}
					else if(dig>=20&&arr2[i-1]!=0)
					{
						dig=arr2[i];
						array[j]=digit1[dig/10+18];
					}
					else if(dig>9)
					{
						dig=arr2[i]+arr2[i-1];
						array[j]=digit1[dig];
						--i;
					}
			  
				}
				else if(i==0)
				{
					int dig=arr2[i];
					if(arr2[i]!=0)
					{
						array[j]=digit1[dig];
					}
				}
			}    
			string no="";
			for(int i=0;i<array.Length;i++)
			{
				if(array[i]!=null)

					no=no+StringUtil.FirstCharUpper(array[i])+" ";
			}
			
			return (no);
		
		}

		/// <summary>
		/// this method use to Check fees paid or not for a perticular period.
		/// </summary>
		private void DropTo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();  
			SqlDataReader SqlDtr=null;
			string str1="select Fees_type,remarks from recuringreceipt where Student_id='"+DropStudentID.Text+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+DropStudentID.Text+"')"; 
			//string str1="select Fees_type,remarks from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"')"; 
			SqlDtr=obj.GetRecordSet(str1);                                       
			if(SqlDtr.Read())                                                     
			{
				msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim(); 
				while(SqlDtr.Read())                                              
				{
					msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim(); 
				}
			}
			else
			{
				MessageBox.Show("Fees Not paid");                                 
			}
			SqlDtr.Close();                                                       
			// FeesClear();
			if(Dropyearfrom.SelectedIndex<=Dropyearto.SelectedIndex)
				feesdecisionmonthly();
			else
			{
				MessageBox.Show("Please Select from year less than or equal to to year");
				return;
			}
		}

		/// <summary>
		/// this method use to save Fees in to recuringreceipt table. first in this method also check fees all ready paid or not of a perticular period. 
		/// this method use InsertStudentRecuringReceipt() function and also use 'ProInsertStudentRecuring' procedure.
		/// </summary>
		double MNS=0;
		public int SaveMonth()
		{
			try
			{
				Cache["FromMonth"]=dropselect.SelectedItem.Text;
				Cache["FromYear"]=Dropyearfrom.SelectedItem.Text;

                if (txtamt.Text != "")
                {
                    if (double.Parse(txtamt.Text) == 0)
                    {
                        MNS = 1;
                        MessageBox.Show("Please Enter the Paid Amount");
                        return 1;
                    }
                }
			
				if(!TxtPeriod.Text.Equals(""))
				{
					string m=GenUtil.str2MMDDYYYY(TxtPeriod.Text);
					m=m.Substring(0,m.IndexOf("/"));
					int m1=System.Convert.ToInt32(m);
					if(m1>=1&&m1<=12)
					{
						if(m1==dropselect.SelectedIndex)
						{
							
						}
						else
						{
							MNS=1;
							MessageBox.Show("Please Select Same Month In Start Period Date Which Is Select In Fees Start From Month");
							return 1;
						}
					}
				}
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				string ToDate=TxtPeriod.Text;
				int dropval=0;
				SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
				if(DropFeeID.Visible==true)
				{
					string id=DropFeeID.SelectedItem.Text;
					id=id.Substring(0,id.IndexOf(":"));
					obj.RecuringID=id.ToString();
				}
				else
					obj.RecuringID=lblFeeID.Text;
				if(Dropyearfrom.SelectedIndex ==0)
					obj.Fees_Type ="";
				else
				{
					if(Dropyearfrom.SelectedIndex==0)
						obj.Fees_Type =Dropyearfrom.SelectedItem .Text .Trim ().ToString ();
					else
						obj.Fees_Type =Dropyearfrom .SelectedItem .Text .Trim ().ToString ();//+":"+dropselect.SelectedItem.Text.Trim();
				}
				if(DropStudentID.Text=="")
					//if(Request.Params.Get(DropStudentID.Value)=="")
					obj.Student_ID ="";
				else
					obj.Student_ID =DropStudentID.Text;
				//obj.Student_ID =Request.Params.Get(DropStudentID.Value);
				if(TxtPeriod .Text=="")
					obj.Period ="";
				else
					obj.Period =ToMMddYYYY(TxtPeriod.Text.Trim().ToUpper()).ToShortDateString();
				obj.Cheque_Date="";
				if(dropmop.SelectedItem.Text.Trim().Equals("By Cheque"))
				{
					obj.Cheque_Date=GenUtil.str2MMDDYYYY(txtchDate.Text.Trim().ToString()); 
					obj.Cheque_No =txtchno.Text.Trim();
					//obj.Bank_Name=Dropbankch.SelectedItem.Text.Trim().ToUpper(); 
					if(Dropbankch.SelectedItem.Text.Trim().Equals("Other"))
					{
						obj.Bank_Name=Request.Params.Get("txtBankchqOther");
					}
					else
					{
						obj.Bank_Name=Dropbankch.SelectedItem.Text.Trim();
					}
				}
				else
				{
					obj.Bank_Name="";
					obj.Cheque_No ="";
				}
				
				if(dropmop.SelectedItem.Text.Trim().Equals("By Draft"))
				{
					obj.draftno =txtdraftno.Text.Trim().ToUpper();
					obj.Cheque_Date =GenUtil.str2MMDDYYYY(txtdraftDate.Text.Trim().ToString()); 
					//obj.BankName=Dropbankdr.SelectedItem.Text.Trim().ToUpper(); 

					if(Dropbankdr.SelectedItem.Text.Trim().Equals("Other"))
					{
						obj.Bank_Name=Request.Params.Get("txtBankdrftOther");
					}
					else
					{
						obj.Bank_Name=Dropbankdr.SelectedItem.Text.Trim();
					}
				}
				else
				{
					obj.BankName="";
					obj.draftno = "";
				}

                if (txtamt.Text == "")
                {
                    obj.Fees_Amount = "";
                    obj.Securityfee = "0.0";
                }
                else
                {
                    if (TempCaution.Value != "0")
                    {
                        obj.Fees_Amount = txtamt.Text;
                        obj.Securityfee = System.Convert.ToString(double.Parse(TempCaution.Value));
                    }
                    else
                    {
                        obj.Fees_Amount = txtamt.Text;
                        if (txtcmf.Text == "")
                        {
                            obj.Securityfee = "0.0";
                        }
                        else
                        {
                            obj.Securityfee = txtcmf.Text;
                        }
                    }
                    if (TempYearly.Value != "0")
                    {
                        obj.Fees_Amount = txtamt.Text;
                    }
                    else
                    {
                        obj.Fees_Amount = txtamt.Text;

                    }
                }
				if(txtlf.Text=="")
					obj.Latefee="";
				else
				{
					obj.Latefee=txtlf.Text.Trim();
					obj.Fees_Amount=txtamt.Text;
				}
				
				obj.AmountDue="";
				obj.EnteredBy=Session["password"].ToString();
				if(TxtRemarks .Text=="")
					obj.Remarks="";
				else
					obj.Remarks =TxtRemarks.Text.Trim().ToUpper(); 
				if(dropmop.SelectedIndex==0)
					obj.PaymentMode="";
				else
					obj.PaymentMode=dropmop.SelectedItem.Text; 
				obj.FeeSubdt=GenUtil.str2MMDDYYYY(TxtcurDate.Text); 

				if(Dropyearfrom.SelectedIndex!=0)
				{
					if(Dropyearfrom.SelectedIndex<Dropyearto.SelectedIndex)
					{
						dropval=Dropyearto.SelectedIndex-Dropyearfrom.SelectedIndex;
						dropval=dropval*12;
					}
					else if(Dropyearfrom.SelectedIndex>Dropyearto.SelectedIndex)
					{
						MessageBox.Show("From Year is not allowed greater than To Year ");
						MNS=1;
						return 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select valid year");
					return 1;
				}
				dropval=dropval+DropTo.SelectedIndex;
				if(dropselect.SelectedIndex>0 && dropval< dropselect.SelectedIndex)
				{
					MessageBox.Show("Please Select Valid Month Duration");
					return 1;
				}
				if(dropselect.SelectedIndex>0 && dropval>=dropselect.SelectedIndex)
				{
					int n=0;
					n=dropval+1-dropselect.SelectedIndex;
					if(dropselect.SelectedItem.Text+Dropyearfrom.SelectedItem.Text==DropTo.SelectedItem.Text+Dropyearto.SelectedItem.Text)
						obj.Fees_Type=dropselect.SelectedItem.Text+Dropyearfrom.SelectedItem.Text+":";
					else
						obj.Fees_Type=dropselect.SelectedItem.Text+Dropyearfrom.SelectedItem.Text+":"+DropTo.SelectedItem.Text+Dropyearto.SelectedItem.Text;
					obj.Period=addMonthMMDDYYYY(TxtPeriod.Text,0);
					obj.PeriodTo=addMonthMMDDYYYY(TxtPeriod.Text,n);
					obj.Fees_Amount=txtamt.Text;
					obj.Tution_Fees=txttf.Text;
					obj.Transportation_Fees=txttrf.Text;
					obj.Hostal_Fees=txthf.Text;
					obj.Diary_Fee=txtdf.Text;
					obj.Annual_Fee=txtanf.Text;
					obj.Envp_Fee=txtef.Text;
					obj.Science_Fee=txtsf.Text;
					obj.Game_Fee=txtgf.Text;
					obj.Activity_Fee=txtaf.Text;
					obj.Computer_Fee=txtcf.Text;
					obj.Admission_Fee=txtadf.Text;
					obj.Class=DropClass.Text;
					obj.InsertStudentRecuringReceipt();
					insertaccountledger();
					//insert in to accountsledgertable
					if(btnEdit.Visible==false)
					{
						AccountledgerUpdate();
					}

					//
				}
				MakingReport();
				//MessageBox.Show("Record Successfully Saved");
				MessageBox.Show("Fees Successfully Saved");
				if(DropFeeID.Visible==true)
				{
					DropFeeID.Visible=false;
					btnSave.Text="Save";	
					lblFeeID.Visible=true;
					btnEdit.Visible=true;
				}
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Record save for studentID :"+ DropStudentID.Text.ToString()+", Userid :  "+ pass);
				clear();
				NextFeeID();
							 
				return 0;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
 
			}
			return 0;
		}

		/// <summary>
		/// ths method use to insert record in AccountsLedgerTable with the help of 'ProInsertAccountsLedger' procedure.
		/// </summary>
		public void insertaccountledger()
		{

			SchoolClass.SchoolMgs obj=new SchoolClass.SchoolMgs();
			

			string Ledgerid="",cashledid="",receipid="";
			
			SqlDataReader rdr=null;
			SqlCommand cmd;
			string str="Select Ledger_id from ledger_Master where Ledger_Name='"+TxtFname.Text+"'";
			rdr=obj.GetRecordSet(str);
			if(rdr.HasRows)
			{
				if(rdr.Read())
				{
					Ledgerid=rdr.GetValue(0).ToString();
				}
			}
			rdr.Close();
		    
			if(dropmop.SelectedItem.Value=="By Cash")
			{
				str="select ledger_id from ledger_master where sub_grp_id=(select sub_grp_id from ledger_master_sub_grp where sub_grp_name='cash in hand')";
				rdr=obj.GetRecordSet(str);
				if(rdr.HasRows)
				{
					if(rdr.Read())
					{
						cashledid=rdr.GetValue(0).ToString();
					}
				}
				rdr.Close();
			} 
			else if(dropmop.SelectedItem.Value=="By Cheque")
			{
				string bankname=DropBankChque.SelectedItem.Value;
				string[] bankid=bankname.Split(new char[]{':'});
				cashledid=bankid[1].ToString();
			}
			else if(dropmop.SelectedItem.Value=="By Draft")
			{
				string bankname=Dropbankdrft.SelectedItem.Value;
				string[] bankid=bankname.Split(new char[]{':'});
				cashledid=bankid[1].ToString();
			}
		
			cmd=new SqlCommand("ProInsertAccountsLedger",con3);
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Parameters.Add("@Ledger_Id",Ledgerid.ToString());

			if(btnEdit.Visible==false)
			{
				receipid=DropFeeID.SelectedItem.Value.ToString();
				receipid=receipid.Substring(0,receipid.IndexOf(':'));
			}

			if(btnEdit.Visible==true)
			{
				cmd.Parameters.Add("@Particulars","RecuringReceipt("+lblFeeID.Text.ToString()+")");
			}
			else
			{
				cmd.Parameters.Add("@Particulars","RecuringReceipt("+receipid.ToString()+")");
			}
			cmd.Parameters.Add("@Debit_Amount",txtamt.Text.Trim());
			cmd.Parameters.Add("@Credit_Amount",txtamt.Text.Trim());
			cmd.Parameters.Add("@type","Cr");
			cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtcurDate1.Text+" "+DateTime.Now.TimeOfDay.ToString())));
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			
			cmd=new SqlCommand("ProInsertAccountsLedger",con3);
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Parameters.Add("@Ledger_Id",cashledid.Trim().ToString());
			if(btnEdit.Visible==true)
			{
				cmd.Parameters.Add("@Particulars","RecuringReceipt("+lblFeeID.Text.ToString()+")");
			}
			else
			{
				cmd.Parameters.Add("@Particulars","RecuringReceipt("+receipid.ToString()+")");
			}
			cmd.Parameters.Add("@Debit_Amount",txtamt.Text.Trim());
			cmd.Parameters.Add("@Credit_Amount",txtamt.Text.Trim());
			cmd.Parameters.Add("@type","Dr");
			cmd.Parameters.Add("@Invoice_Date",System.Convert.ToDateTime(GenUtil.str2DDMMYYYY(TxtcurDate1.Text+" "+DateTime.Now.TimeOfDay.ToString())));
			cmd.ExecuteNonQuery();
			cmd.Dispose();
		}

		/// <summary>
		/// this method use to fetch fees from feesdecision table.this fees based on service category and rank. 
		/// </summary>
		public void feesdecisionmonthly()
		{
			FeesClear();
			try
			{
				string sSysDate=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
				sSysDate=GenUtil.str2MMDDYYYY(sSysDate);
				if(!txtrank.Text.Equals("")&&!txtscat.Text.Equals(""))
				{
					if(Dropyearfrom.SelectedIndex!=0&&Dropyearto.SelectedIndex!=0)
					{
						if(dropselect.SelectedIndex<10)
						{
							TxtPeriod.Text="01"+"/0"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
							Cache["Start"]=TxtPeriod.Text;
						}
						else
						{
							TxtPeriod.Text="01"+"/"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
							Cache["Start"]=TxtPeriod.Text;
						}
						InventoryClass obj=new InventoryClass();
						InventoryClass obj1=new InventoryClass();
						SqlDataReader SqlDtr=null,rdr=null;
						string str="",str1="";
						int count=0,Flag=0;
						double Caution=0;
						double computer=0;
						int dropval=0;
						if(Dropyearfrom.SelectedIndex<Dropyearto.SelectedIndex)
						{
							dropval=Dropyearto.SelectedIndex-Dropyearfrom.SelectedIndex;
							dropval=dropval*12;
						}
						dropval=dropval+DropTo.SelectedIndex;
						if(dropselect.SelectedIndex>0 && dropval< dropselect.SelectedIndex)
						{
							MessageBox.Show("Please Select Valid Month Duration");
							return;
						}
						str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.Text+"') and Student_Stream='"+TextStream.Text+"' and feemode='Monthly' and srank='"+txtrank.Text+"' and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							///16.10.08 if(dropselect.SelectedItem.Text.Equals("Apr") || msg =="" )    //this condition for if new student admit in after first quarter then all fees have to be payed by student 
							if(dropselect.SelectedItem.Text.Equals("Apr"))
							{
								str1="select count(*) from recuringreceipt where student_id='"+DropStudentID.Text+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									count=int.Parse(rdr.GetValue(0).ToString());
								}
								rdr.Close();
								if(count>0)
								{
									txtcmf.Text="0";
									if(DropClass.Text.Equals("XI"))
									{
										str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.Text+"') and Student_Stream='"+TextStream.Text+"' and feemode='One Time' and srank='"+txtrank.Text+"' and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"' and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";//added by vi
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											txtadf.Text=rdr["admission_fee"].ToString();
											Caution=double.Parse(rdr["admission_fee"].ToString());
											Flag++;
										}
									}
									rdr.Close();
								}
								///17.10.08else
								///17.10.08{
								str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.Text+"') and Student_Stream='"+TextStream.Text+"' and feemode='One Time' and srank='"+txtrank.Text+"' and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									txtcmf.Text=rdr["caution_fee"].ToString();
									txtadf.Text=rdr["admission_fee"].ToString();
									TempCaution.Value=rdr["caution_fee"].ToString();
									admissionfee=double.Parse(rdr["admission_fee"].ToString());
									Caution=double.Parse(rdr["caution_fee"].ToString())+double.Parse(rdr["admission_fee"].ToString());
									Flag++;
								}
								else
								{
									MessageBox.Show("Please enter one time fees in Fees Decision table");
									return;
								}
								rdr.Close();
								///17.10.08}
								str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.Text+"') and Student_Stream='"+TextStream.Text+"' and feemode='Yearly' and srank='"+txtrank.Text+"' and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";//added by vi
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									txtanf.Text=rdr["annual_fee"].ToString();
									txtef.Text=rdr["envp_fee"].ToString();
									txtdf.Text=rdr["diary_fee"].ToString();
									TempYearly.Value=rdr["Total"].ToString();
									Caution+=double.Parse(rdr["Total"].ToString());
									Flag++;
								}
								else
								{
									MessageBox.Show("Please enter the yearly fees in Fees Decision table");
									return;
								}
								rdr.Close();
							}
							if(dropselect.SelectedIndex>0  && dropselect.SelectedIndex<=3 &&DropTo.SelectedIndex>=4)
							{
								MessageBox.Show("Invalid Month selection");
								dropselect.SelectedIndex=0;
								Dropyearfrom.SelectedIndex=0;
								Dropyearto.SelectedIndex=0;
								DropTo.SelectedIndex=0;
								return;
							}
							if(dropselect.SelectedIndex>0 && dropval>=dropselect.SelectedIndex)
							{
								int n=0;
								n=dropval+1-dropselect.SelectedIndex;
								txttf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(SqlDtr["tution_fee"].ToString())));
								if((DropClass.Text.Equals("XI")||DropClass.Text.Equals("XII"))&&(TextComputer.Text.Trim().Equals("Non Computer")||TextComputer.Text.Trim().Equals("")))//added by Vi
								{
									txtcf.Text="0.00"; 
									computer=n*double.Parse(SqlDtr["computer_fee"].ToString());
								}
								else
								{
									txtcf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(SqlDtr["computer_fee"].ToString())));//only this is old line 
									computer=0;
								}
								txtsf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(SqlDtr["science_fee"].ToString())));
								
								if((dropselect.SelectedIndex==4 || dropselect.SelectedIndex==5 || dropselect.SelectedIndex==6) && DropClass.Text.Equals("XI"))
								{
									str1="select trfee from route where route_name=(select routename from student_record where student_id='"+DropStudentID.Text+"' and service_bus='Yes') and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";
									rdr=obj1.GetRecordSet(str1);
									if(rdr.Read())
									{
										txttrf.Text=GenUtil.strNumericFormat(System.Convert.ToString((n-3)*double.Parse(rdr["trfee"].ToString())));
										if(double.Parse(txttrf.Text)<0)
										txttrf.Text="0";
									}
									else
									{
										txttrf.Text="0";
									}
									rdr.Close();
								}
								else if(dropselect.SelectedIndex==4)
								{
									str1="select trfee from route where route_name=(select routename from student_record where student_id='"+DropStudentID.Text+"' and service_bus='Yes') and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";
									rdr=obj1.GetRecordSet(str1);
									if(rdr.Read())
									{
										txttrf.Text=GenUtil.strNumericFormat(System.Convert.ToString((n-1)*double.Parse(rdr["trfee"].ToString())));
									}
									else
									{
										txttrf.Text="0";
									}
									rdr.Close();
								}
								else
								{
									str1="select trfee from route where route_name=(select routename from student_record where student_id='"+DropStudentID.Text+"' and service_bus='Yes') and fromdate<='"+sSysDate+"' and todate>='"+sSysDate+"'";
									rdr=obj1.GetRecordSet(str1);
									if(rdr.Read())
									{
										txttrf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(rdr["trfee"].ToString())));
									}
									else
									{
										txttrf.Text="0";
									}
									rdr.Close();
								}
								txtgf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(SqlDtr["games_fee"].ToString())));
								txthf.Text=GenUtil.strNumericFormat(System.Convert.ToString(n*double.Parse(SqlDtr["hostel_fee"].ToString())));
								TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString((n*double.Parse(SqlDtr["Total"].ToString()))));
								if(Flag==2)
								{
									Caution+=double.Parse(TxtAmount.Text);
									TxtAmount.Text=System.Convert.ToString(Caution + double.Parse(txttrf.Text)-computer);
								}
								else
								{
									Caution+=double.Parse(TxtAmount.Text);
									TxtAmount.Text=System.Convert.ToString(Caution+double.Parse(txttrf.Text)-computer);
								}
								txtamt.Text=TxtAmount.Text;
							}
						}
						SqlDtr.Close();
					}
					else
					{
						MessageBox.Show("Please select year");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please Enter appropriate category and rank");
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}
		}

		/// <summary>
		/// this method use to get date in DDMMYYYY format. in this function pass date and month.
		/// </summary>
		string addMonthMMDDYYYY(string strDate,int month)
		{
			if(!strDate.Equals(""))
			{
				string y=GenUtil.str2MMDDYYYY(strDate);
				
				int y1=System.Convert.ToInt32(y.Substring(y.LastIndexOf("/")+1,4));
				
				string m=GenUtil.str2MMDDYYYY(strDate);
				m=m.Substring(0,m.IndexOf("/"));
				int m1=System.Convert.ToInt32(m);
				if(m1>=1&&m1<=12)
				{
					m1=m1+month;
					if(m1>12)
					{
						int a=m1/12;
						m1=m1%12;
						y1=y1+a;
					}
				}
				else
				{
					MessageBox.Show("Please enter date in correct formate");
					return "";
				}

				string d=GenUtil.str2MMDDYYYY(strDate);
				
				d=d.Substring(d.IndexOf("/")+1,d.LastIndexOf("/")-d.IndexOf("/")-1);
				return m1+"/"+d+"/"+y1;
			}
			else
			{
				MessageBox.Show("Empty String");
				return "";
			}
		}

		
		private void TxtPeriod_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtlf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtlf.Text.Equals("")&&!TxtAmount.Text.Equals("")) 
			{ 
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtlf.Text.ToString())));//added by vikas sharma on 02/11/07
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropyearto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DropTo.Enabled=true;
		}

		/// <summary>
		/// this method use to fetch fees from feesdecision table.as well as we select date.
		/// </summary>
		private void Dropyearfrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				string fee_type="";
				SchoolClass .SchoolMgs obj= new SchoolClass .SchoolMgs ();
				SqlDataReader SqlDtr;
				if(DropStudentID.Text!=""&&Dropyearfrom.SelectedIndex!=0&&dropselect.SelectedIndex!=0)	
					//if(Request.Params.Get(DropStudentID.Value)!=""&&Dropyearfrom.SelectedIndex!=0&&dropselect.SelectedIndex!=0)	
				{
					if(dropselect.SelectedIndex<10)
					{
						TxtPeriod.Text="01"+"/0"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
						Cache["Start"]=TxtPeriod.Text;
					}
					else
					{
						TxtPeriod.Text="01"+"/"+dropselect.SelectedIndex.ToString().Trim()+"/"+Dropyearfrom.SelectedItem.ToString().Trim();
						Cache["Start"]=TxtPeriod.Text;
					}
					string id=DropStudentID.Text;
					string str1="select Fees_type from recuringreceipt where Student_id='"+id+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+id+"')";
					//string str1="select Fees_type from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"')";
					SqlDtr=obj.GetRecordSet(str1);
					if(SqlDtr.Read())
					{
						while(SqlDtr.Read())
						{
							fee_type=SqlDtr.GetValue(0).ToString().Trim();
						}
					}
					else
					{
						MessageBox.Show("Fees Not paid");
					}
					SqlDtr.Close();
					if(fee_type.Equals(dropselect.SelectedItem.Text.Trim()+ Dropyearfrom.SelectedItem.Text.Trim()))
					{
						MessageBox.Show(dropselect.SelectedItem.Text.Trim()+" fees is already paid");
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}
		}

		private void txtchDate_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtcmf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtcmf.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtcmf.Text.ToString())));
				
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtanf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtanf.Text.Equals("")&&!TxtAmount.Text.Equals(""))//added by vikas sharma on 02/11/07
			{   
				double currnt=Convert.ToDouble(txtanf.Text);
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void txtadf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtadf.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtadf.Text.ToString())));  //add by vikas sharma 2.11.07
				
				txtamt.Text=TxtAmount.Text;
				
			}

		}

		private void Dropbankdr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtFathername_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// When We Write Student Id in text box then information of student fetch from student_record table.
		/// </summary>
		private void TxtStudentID_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				SchoolClass .SchoolMgs objj= new SchoolClass .SchoolMgs ();
				SqlDataReader SqlDtr;
				if(DropStudentID.Text!="")
					//if(Request.Params.Get(DropStudentID.Value)!="")
				{
					string str="select Student_ID,Student_FName,Student_FatherName,Student_Stream,rank,scategory,seq_student_id,computer from Student_record where Student_id='"+DropStudentID.Text+"'";
					//string str="select Student_ID,Student_FName,Student_FatherName,Student_Stream,rank,scategory,seq_student_id,computer from Student_record where Student_id='"+Request.Params.Get(DropStudentID.Value)+"'";
					SqlDtr=objj.GetRecordSet(str);
					while(SqlDtr.Read())
					{
						TxtFname.Text=SqlDtr.GetValue(1).ToString();
						TextStream.Text=SqlDtr["Student_Stream"].ToString();
						txtscat.Text =SqlDtr["scategory"].ToString ();
						txtrank.Text=SqlDtr["rank"].ToString ();
						TempSection.Value=SqlDtr["seq_student_id"].ToString ();
						section=SqlDtr["seq_student_id"].ToString ();
						txtFathername.Text=SqlDtr["Student_FatherName"].ToString();
						if(SqlDtr["Computer"].ToString().Trim().Equals("Yes"))
							TextComputer.Text="Computer";
						else if(SqlDtr["Computer"].ToString().Trim().Equals("No"))
							TextComputer.Text="Non Computer";
						else
							TextComputer.Text="";
					}
					SqlDtr.Close();
					string str1="select Fees_type,remarks from recuringreceipt where Student_id='"+DropStudentID.Text+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+DropStudentID.Text+"')";
					//string str1="select Fees_type,remarks from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"' and Recuringid=(select max(RecuringId) from recuringreceipt where Student_id='"+Request.Params.Get(DropStudentID.Value)+"')";
					SqlDtr=objj.GetRecordSet(str1);
					string msg="";
					if(SqlDtr.Read())
					{
						msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim();
						while(SqlDtr.Read())
						{
							msg=SqlDtr.GetValue(0).ToString().Trim()+" "+SqlDtr.GetValue(1).ToString().Trim();
						}
						MessageBox.Show(msg);
					}
					else
					{
						MessageBox.Show("Fees Not paid");
					}
					SqlDtr.Close();
					flag=0;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : RecuringFeesReceipt.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtdf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtdf.Text.Equals("")&&!TxtAmount.Text.Equals("")) 
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtdf.Text.ToString()))); 
				txtamt.Text=TxtAmount.Text;         
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txttf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txttf.Text.Equals("")&&!TxtAmount.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txttf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;          
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtcf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtcf.Text.Equals("")&&!TxtAmount.Text.Equals("")) 
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtcf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtsf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtsf.Text.Equals("")&&!TxtAmount.Text.Equals("")) 
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtsf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtaf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtaf.Text.Equals("")&&!TxtAmount.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtaf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtgf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtgf.Text.Equals("")&&!TxtAmount.Text.Equals("")) 
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtgf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txttrf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txttrf.Text.Equals("")&&!TxtAmount.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txttrf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtef_TextChanged(object sender, System.EventArgs e)
		{
			if(!txtef.Text.Equals("")&&!TxtAmount.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txtef.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txthf_TextChanged(object sender, System.EventArgs e)
		{
			if(!txthf.Text.Equals("")&&!TxtAmount.Text.Equals(""))
			{
				TxtAmount.Text=GenUtil.strNumericFormat(System.Convert.ToString(System.Convert.ToDouble(TxtAmount.Text.ToString())+System.Convert.ToDouble(txthf.Text.ToString())));
				txtamt.Text=TxtAmount.Text;
			}
		}

		private void TxtAmount_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// It Use to Adjustment Fees Amount
		/// not in use
		/// </summary>
		private void txtanf_PreRender(object sender, System.EventArgs e)
		{
			
			if(!txtanf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				anualfee=Convert.ToDouble(txtanf.Text);
				Tempanual.Value=anualfee.ToString();
               
			}
			if(!txtdf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				diaryfee=Convert.ToDouble(txtdf.Text);
				Tempdiary.Value=diaryfee.ToString();
				
			}
			if(!txtef.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				devlopfee=Convert.ToDouble(txtef.Text);
				TempDevlop.Value=devlopfee.ToString();
				
			}
			if(!txttf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				tutionfee=Convert.ToDouble(txttf.Text);
				TempTuti.Value=tutionfee.ToString();
				
			}
			if(!txtcf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				compfee=Convert.ToDouble(txtcf.Text);
				TempCompu.Value=compfee.ToString();
				
			}
			if(!txtsf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				sciencefee=Convert.ToDouble(txtsf.Text);
				TempScie.Value=sciencefee.ToString();
				
			}
			if(!txtaf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				actifee=Convert.ToDouble(txtaf.Text);
				TempActi.Value=actifee.ToString();
				
			}
			if(!txtgf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				gamesfee=Convert.ToDouble(txtgf.Text);
				TempGemes.Value=gamesfee.ToString();
				
			}
			if(!txttrf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				transfee=Convert.ToDouble(txttrf.Text);
				TempTrans.Value=transfee.ToString();
				
			}
			if(!txtadf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				admissionfee=Convert.ToDouble(txtadf.Text);
				TempAdmiss.Value=admissionfee.ToString();
				
			}
			if(!txthf.Text.Equals("") &&!TxtAmount.Text.Equals(""))
			{
				housfee=Convert.ToDouble(txthf.Text);
				TempHouse.Value=housfee.ToString();
				
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropStudentID_ServerChange(object sender, System.EventArgs e)
		{
		
			MessageBox.Show("Hello");
		}
	}
}


