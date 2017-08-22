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
  
namespace eschool.StudentFees
{	/// <summary>
	/// Summary description for FessDecision.
	/// </summary>
	public class FessDecision : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.CompareValidator cmppin;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator8;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator9;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button btnSave;
        SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator12;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.TextBox txtdf;
		protected System.Web.UI.WebControls.TextBox txtgf;
		protected System.Web.UI.WebControls.TextBox txtadf;
		protected System.Web.UI.WebControls.TextBox txtcmf;
		protected System.Web.UI.WebControls.TextBox txthf;
		protected System.Web.UI.WebControls.DropDownList Dropfeetype;
		protected System.Web.UI.WebControls.TextBox txtremark;
		protected System.Web.UI.WebControls.DropDownList dropscategory;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator13;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator14;
		protected System.Web.UI.WebControls.Label lblFeeID;
		protected System.Web.UI.WebControls.DropDownList DropFeeID;
		protected System.Web.UI.WebControls.Button btnEdtt;
		//protected System.Web.UI.WebControls.DropDownList Droprank;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator15;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.TextBox txttf;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator10;
		protected System.Web.UI.WebControls.TextBox txtanf;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.TextBox txtcf;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator11;
		protected System.Web.UI.WebControls.TextBox txtef;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.TextBox txtsf;
		protected System.Web.UI.WebControls.Panel panOneTime;
		protected System.Web.UI.WebControls.Panel panYearly;
		protected System.Web.UI.WebControls.Panel panMonthly;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.WebControls.ListBox DropClass;
		//string[] LstClassName=new string[12];
		string[] LstClassName=new string[15];
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label4;
		SqlDataReader sdtr;
		protected System.Web.UI.WebControls.ValidationSummary svFeesDecision;
		protected System.Web.UI.WebControls.TextBox txttrf;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		protected System.Web.UI.WebControls.TextBox txtlf;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.HtmlControls.HtmlInputText tempcatrank;
		protected System.Web.UI.HtmlControls.HtmlInputText temprank;
		protected System.Web.UI.HtmlControls.HtmlSelect DropRank;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Fees_Decision.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Fees_Decision.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass);
				return;
			}
			try
			{
				scon.Open();
    			if(!IsPostBack)
				{
                    Txtfromdate.Attributes.Add("readonly", "readonly");
                    Txttodate.Attributes.Add("readonly", "readonly");
                    txttrf.Attributes.Add("readonly", "readonly");
                    txtlf.Attributes.Add("readonly", "readonly");

                    panMonthly.Visible=false;
					panOneTime.Visible=false;
					panYearly.Visible=false;
					InventoryClass obj=new InventoryClass();
					SqlDataReader sdtr;
					//string str="Select distinct class_name from Class order by class_id";
					string str="Select class_name from Class order by class_id";
					sdtr=obj.GetRecordSet(str);
					DropFeeID.Visible=false;
					lblFeeID.Visible=true;
					btnEdit.Visible=false;
					btnSave.Visible=true;
					Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					while(sdtr.Read())
					{
						DropClass.Items.Add(sdtr.GetValue(0).ToString().Trim());
					}
					sdtr.Close();
					dropscategory.Items.Add("Select");
					str="Select distinct catname from category";
					sdtr=obj.GetRecordSet(str);
					fillID();
					while(sdtr.Read())
					{
					    dropscategory.Items.Add(sdtr.GetValue (0).ToString ().Trim ());
					}
					sdtr.Close();
					#region Fill catrank
					str="select Catname,rank from category order by catname,rank";
					sdtr=obj.GetRecordSet(str);
					while(sdtr.Read())
					{
						//dropscategory.Items.Add(sdtr.GetValue (0).ToString ().Trim ());
						tempcatrank.Value+=sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString()+",";
					}
					sdtr.Close();
					#endregion  
				}
				if(! IsPostBack)
				{
					#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="7";
				string SubModule="1";
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
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				//return;
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
			this.DropFeeID.SelectedIndexChanged += new System.EventHandler(this.DropFeeID_SelectedIndexChanged);
			this.btnEdtt.Click += new System.EventHandler(this.btnEdtt_Click);
			this.Dropfeetype.SelectedIndexChanged += new System.EventHandler(this.Dropfeetype_SelectedIndexChanged);
			this.dropscategory.SelectedIndexChanged += new System.EventHandler(this.dropscategory_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to calcualte total of feeses  and return.
		/// </summary>
		public float total()
		{
			try
			{
				float DF,TF,CF,SF,GF,TRF,ADF,CMF,ANF,ENVPF,HF;//LF,
				if(txtdf.Text.Trim()=="")
					DF=0;
				else
					DF=float.Parse(txtdf.Text.Trim().ToString());
				if(txttf.Text.Trim()=="")
					TF=0;
					else
					TF=float.Parse(txttf.Text.Trim().ToString());
				if(txtcf.Text.Trim()=="")
					CF=0;
				else
					CF=float.Parse(txtcf.Text.Trim().ToString());
				if(txtsf.Text.Trim()=="")
					SF=0;
				else
					SF=float.Parse(txtsf.Text.Trim().ToString());
				
				if(txtgf.Text.Trim()=="")
					GF=0;
				else
					GF=float.Parse(txtgf.Text.Trim().ToString());
				if(txttrf.Text.Trim()=="")
					TRF=0;
				else
					TRF=float.Parse(txttrf.Text.Trim().ToString());
				if(txtadf.Text.Trim()=="")
					ADF=0;
				else
					ADF=float.Parse(txtadf.Text.Trim().ToString());
				if(txtcmf.Text.Trim()=="")
					CMF=0;
				else
					CMF=float.Parse(txtcmf.Text.Trim().ToString());
				if(txtanf.Text.Trim()=="")
					ANF=0;
				else
					ANF=float.Parse(txtanf.Text.Trim().ToString());
				if(txthf.Text.Trim()=="")
					HF=0;
				else
					HF=float.Parse(txthf.Text.Trim().ToString());
				if(txtef.Text.Trim()=="")
					ENVPF=0;
				else
					ENVPF=float.Parse(txtef.Text.Trim().ToString());
				
				float fTotal=DF+TF+CF+SF+GF+TRF+ADF+CMF+ANF+ENVPF+HF;
				return fTotal;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  total(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return 0;
			}
		}

		/// <summary>
		/// this method use to Clear the form.
		/// </summary>
		public void clear()
		{
			DropClass.SelectedIndex=0;
			DropStream.SelectedIndex=0;
			Dropfeetype.SelectedIndex =0;
			txtdf.Text ="";
			txttf .Text ="";
			txtcf .Text ="";
			txtsf .Text ="";
			txtgf .Text ="";
			txtlf .Text ="";
			txttrf .Text ="";
			txtadf .Text ="";
			txtanf .Text ="";
			txtcmf .Text ="";
			txtef .Text ="";
			txthf .Text ="";
			txtremark.Text ="";
			dropscategory .SelectedIndex =0;
			DropRank.Items.Clear();
			DropRank.Items.Add("Select");
			DropRank.SelectedIndex=0;
			//8.11.08 Droprank.SelectedIndex=0;
			Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			panMonthly.Visible=false;
			panOneTime.Visible=false;
			panYearly.Visible=false;

			for(int j=0;j<LstClassName.Length;j++)
			{
				if(LstClassName[j]!=null)
					LstClassName[j]="";
			}
		}

		/// <summary>
		/// this method use Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			lblFeeID.Visible=true;
			btnEdtt.Visible=true;
			DropFeeID.Visible=false;
			btnEdit.Visible=false;
			btnSave.Visible=true;
			clear();
		}

		/// <summary>
		/// this Method use to fetch data from class table. return the class_id.
		/// </summary>
		public int getClassID(string cls)
		{
              int classid=0;
			try
			{
				string str="Select  class_Id from class where class_name='"+cls+"'";
				scom=new SqlCommand(str,scon);
				sdtr=scom.ExecuteReader();
				while(sdtr.Read())
				{
					classid=int.Parse(sdtr.GetValue(0).ToString());
				}
				sdtr.Close();
				scon.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  getClassID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
			return classid;
		}

		/// <summary>
		/// this method use to Get Next FeesDecisionID from feesdecision table.
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
				cmd=new SqlCommand("select max(FeedecisionID)+1 from FeesDecision",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read ())
					{
						lblFeeID.Text=SqlDtr.GetValue(0).ToString ();
						if(lblFeeID.Text.Trim().Equals(""))
							lblFeeID.Text="1";
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
		/// this method use to save selected class in to array.
		/// </summary>
		public void trans()
		{
			try
			{
				int i=0;
				while(DropClass.SelectedItem.Selected)
				{
					LstClassName[i]=DropClass.SelectedItem.Value;
                   	DropClass.SelectedItem.Selected=false;
					i++;
				}
			}
			catch(Exception ex)
			{
				
			}
		}

		/// <summary>
		/// this Method for save the Feesdecision information with service category and rank in to feesdecision table.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				trans();
				int sClass=0;
				for(int j=0;j<LstClassName.Length;j++)
				{
					if(LstClassName[j]!=null)
					{
						float fTotal=total();
						sClass= getClassID(LstClassName[j]);
						scon.Open();
						//8.11.08 scom=new SqlCommand("Select count(Class_id) from FeesDecision where class_id='"+sClass+"' and feemode='"+Dropfeetype.SelectedItem .Text +"' and scategory='"+dropscategory.SelectedItem.Text+"' and srank='"+Droprank.SelectedItem.Text+"' and student_stream='" +DropStream.SelectedItem.Text+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString())+"' and todate > '"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString())+"'",scon);
						scom=new SqlCommand("Select count(Class_id) from FeesDecision where class_id='"+sClass+"' and feemode='"+Dropfeetype.SelectedItem .Text +"' and scategory='"+dropscategory.SelectedItem.Text+"' and srank='"+temprank.Value+"' and student_stream='" +DropStream.SelectedItem.Text+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString())+"' and todate > '"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString())+"'",scon);
						sdtr=scom.ExecuteReader();
						int iCount=0;
						while(sdtr.Read())
						{
							iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString().Trim());
						}
						sdtr.Close();
						if(iCount>0)
						{		
							MessageBox.Show("Fees for this class already inserted");
							return;
						}
						string str="Insert  FeesDecision(FeeDecisionID,Class_ID,Student_Stream,feemode,diary_fee,tution_fee,computer_fee,science_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,Total,remarks,scategory,srank,fromdate,todate) Values (@FeeDecisionID,@Class_ID,@Student_Stream,@FeeMode,@diary_fee,@tution_fee,@computer_fee,@science_fee,@games_fee,@late_fee,@transport_fee,@admission_fee,@caution_fee,@annual_fee,@envp_fee,@hostel_fee,@Total,@remarks,@scategory,@srank,@fromdate,@todate)";
						scom=new SqlCommand( str,scon);
						scom.Parameters .Add ("@FeeDecisionID",lblFeeID.Text.Trim().ToString());
						scom.Parameters .Add ("@Total",fTotal);
				
						if(dropscategory.SelectedIndex==0)
							scom.Parameters .Add ("@scategory","");
						else
							scom.Parameters .Add ("@scategory",dropscategory .SelectedItem .Text.ToString ().Trim ());

                        if(temprank.Value=="Select" || temprank.Value=="")
							scom.Parameters.Add("@srank","");
						else
							scom.Parameters.Add("@srank",temprank.Value.ToString());
						/*8.11.08 if(Droprank.SelectedIndex==0)
							scom.Parameters .Add ("@srank","");
						else
							scom.Parameters .Add ("@srank",Droprank .SelectedItem .Text.ToString ().Trim ());*/
				
						if(DropClass.SelectedIndex==0)
							scom.Parameters .Add ("@Class_ID","");
						else
							scom.Parameters .Add ("@Class_ID",sClass);
				
						//06.02.09 if(DropStream.SelectedIndex==0)
						//06.02.09 	scom.Parameters .Add ("@Student_Stream","");
						//06.02.09 else
							scom.Parameters .Add ("@Student_Stream",DropStream.SelectedItem.Text.ToString().Trim());
				
						if(txtdf.Text=="")
							scom.Parameters .Add ("@diary_fee","0");
						else
							scom.Parameters .Add ("@diary_fee",float.Parse(txtdf.Text.ToString().Trim()));

						if(Dropfeetype.SelectedItem.Text.Equals(""))
							scom.Parameters .Add ("@FeeMode","");
						else
							scom.Parameters .Add ("@FeeMode",Dropfeetype.SelectedItem.Text.ToString().Trim());
						if(txttf.Text=="")
							scom.Parameters .Add ("@tution_fee","0");
						else
							scom.Parameters .Add ("@tution_fee",float.Parse(txttf.Text.Trim().ToString()));
						
						if(txtcf.Text=="")
							scom.Parameters .Add ("@computer_fee","0");
						else
							scom.Parameters .Add ("@computer_fee",float.Parse(txtcf.Text.Trim().ToString()));
						
						if(txtsf.Text=="")
							scom.Parameters .Add ("@science_fee","0");
						else
							scom.Parameters .Add ("@science_fee",float.Parse(txtsf.Text.Trim().ToString()));
						
						if(txtgf.Text=="")
							scom.Parameters .Add ("@games_fee","0");
						else
							scom.Parameters .Add ("@games_fee",float.Parse(txtgf.Text.Trim().ToString()));
						
						if(txtlf.Text=="")
							scom.Parameters .Add ("@late_fee","0");
						else
							scom.Parameters .Add ("@late_fee",float.Parse(txtlf.Text.Trim().ToString()));
						
						if(txttrf.Text=="")
							scom.Parameters .Add ("@transport_fee","0");
						else
							scom.Parameters .Add ("@transport_fee",float.Parse(txttrf.Text.Trim().ToString()));
						
						if(txtadf.Text=="")
							scom.Parameters .Add ("@admission_fee","0");
						else
							scom.Parameters .Add ("@admission_fee",float.Parse(txtadf.Text.Trim().ToString()));
						
						if(txtcmf.Text=="")
							scom.Parameters .Add ("@caution_fee","0");
						else
							scom.Parameters .Add ("@caution_fee",float.Parse(txtcmf.Text.Trim().ToString()));
						
						if(txtanf.Text=="")
							scom.Parameters .Add ("@annual_fee","0");
						else
							scom.Parameters .Add ("@annual_fee",float.Parse(txtanf.Text.Trim().ToString()));
						
						if(txtef.Text=="")
							scom.Parameters .Add ("@envp_fee","0");
						else
							scom.Parameters .Add ("@envp_fee",float.Parse(txtef.Text.Trim().ToString()));
						
						if(txthf.Text=="")
							scom.Parameters .Add ("@hostel_fee","0");
						else
							scom.Parameters .Add ("@hostel_fee",txthf.Text.Trim().ToString());
						
						if(txtremark.Text=="")
							scom.Parameters .Add ("@remarks","");
						else
							scom.Parameters .Add ("@remarks",txtremark.Text.Trim().ToString());
				
						if(Txtfromdate.Text=="")
						{
							MessageBox.Show("Please enter the start date");
							return;
						}
						else
							scom.Parameters .Add ("@fromdate",GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString()));

						if(Txttodate.Text=="")
						{
							MessageBox.Show("Please enter the end date");
							return;
						}
						else
							scom.Parameters .Add ("@todate",GenUtil.str2MMDDYYYY(Txttodate.Text.Trim().ToString()));
						scom.ExecuteNonQuery();
						fillID();
					}
				}
				MessageBox.Show("Fees Details Successfully Saved");
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  btnSave_Click, Record save for ClassID:  "+sClass+", Userid :  "+ pass   );							
				clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
		 	}
		}

		/// <summary>
		/// this Method us to update fees information in to feesdecision table of the selected class.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				trans();
				int cls=0;
				
				string Fees_id=DropFeeID.SelectedItem.Text;
				Fees_id=Fees_id.Substring(0,Fees_id.IndexOf(":"));

				for(int j=0;j<LstClassName.Length;j++)
				{
					if(LstClassName[j]!=null)
					{
						float fTotal=total();
						cls= getClassID(LstClassName[j]);
						scon.Open();
						//string str="delete from FeesDecision where class_id="+cls+" and feedecisionid='"+DropFeeID.SelectedItem.Text.Trim() +"'" ;
						string str="delete from FeesDecision where class_id="+cls+" and feedecisionid='"+Fees_id.ToString().Trim() +"'" ;
						scom=new SqlCommand( str,scon);
						scom.ExecuteNonQuery();
						scom.Dispose();
						scon.Close();
						scon.Open();
						str="Insert  FeesDecision(FeeDecisionID,Class_ID,Student_Stream,feemode,diary_fee,tution_fee,computer_fee,science_fee,games_fee,late_fee,transport_fee,admission_fee,caution_fee,annual_fee,envp_fee,hostel_fee,Total,remarks,scategory,srank,fromdate,todate) Values (@FeeDecisionID,@Class_ID,@Student_Stream,@FeeMode,@diary_fee,@tution_fee,@computer_fee,@science_fee,@games_fee,@late_fee,@transport_fee,@admission_fee,@caution_fee,@annual_fee,@envp_fee,@hostel_fee,@Total,@remarks,@scategory,@srank,@fromdate,@todate)";
						scom=new SqlCommand( str,scon);
						//scom.Parameters .Add ("@FeeDecisionID",DropFeeID.SelectedItem.Text.Trim().ToString());
						scom.Parameters .Add ("@FeeDecisionID",Fees_id.Trim().ToString());
						scom.Parameters .Add ("@Total",fTotal);
						if(dropscategory.SelectedIndex==0)
							scom.Parameters .Add ("@scategory","");
						else
							scom.Parameters .Add ("@scategory",dropscategory .SelectedItem .Text.ToString ().Trim ());

						if(temprank.Value=="Select" || temprank.Value=="")
							scom.Parameters.Add("@srank","");
						else
							scom.Parameters.Add("@srank",temprank.Value.ToString());

						/*8.1.08 if(Droprank.SelectedIndex==0)
							scom.Parameters .Add ("@srank","");
						else
							scom.Parameters .Add ("@srank",Droprank .SelectedItem .Text.ToString ().Trim ());*/
						scom.Parameters .Add ("@Class_ID",cls);
						//06.02.09 if(DropStream.SelectedIndex==0)
						//06.02.09 	scom.Parameters .Add ("@Student_Stream","");
						//06.02.09 else
							scom.Parameters .Add ("@Student_Stream",DropStream.SelectedItem.Text.ToString().Trim());
				
						if(txtdf.Text=="")
							scom.Parameters .Add ("@diary_fee","0");
						else
							scom.Parameters .Add ("@diary_fee",float.Parse(txtdf.Text.ToString().Trim()));

						if(Dropfeetype.SelectedItem.Text.Equals(""))
							scom.Parameters .Add ("@FeeMode","");
						else
							scom.Parameters .Add ("@FeeMode",Dropfeetype.SelectedItem.Text.ToString().Trim());
						if(txttf.Text=="")
							scom.Parameters .Add ("@tution_fee","0");
						else
							scom.Parameters .Add ("@tution_fee",float.Parse(txttf.Text.Trim().ToString()));
						
						if(txtcf.Text=="")
							scom.Parameters .Add ("@computer_fee","0");
						else
							scom.Parameters .Add ("@computer_fee",float.Parse(txtcf.Text.Trim().ToString()));
						
						if(txtsf.Text=="")
							scom.Parameters .Add ("@science_fee","0");
						else
							scom.Parameters .Add ("@science_fee",float.Parse(txtsf.Text.Trim().ToString()));
						
						if(txtgf.Text=="")
							scom.Parameters .Add ("@games_fee","0");
						else
							scom.Parameters .Add ("@games_fee",float.Parse(txtgf.Text.Trim().ToString()));
						
						if(txtlf.Text=="")
							scom.Parameters .Add ("@late_fee","0");
						else
							scom.Parameters .Add ("@late_fee",float.Parse(txtlf.Text.Trim().ToString()));
						
						if(txttrf.Text=="")
							scom.Parameters .Add ("@transport_fee","0");
						else
							scom.Parameters .Add ("@transport_fee",float.Parse(txttrf.Text.Trim().ToString()));
						
						if(txtadf.Text=="")
							scom.Parameters .Add ("@admission_fee","0");
						else
							scom.Parameters .Add ("@admission_fee",float.Parse(txtadf.Text.Trim().ToString()));
						
						if(txtcmf.Text=="")
							scom.Parameters .Add ("@caution_fee","0");
						else
							scom.Parameters .Add ("@caution_fee",float.Parse(txtcmf.Text.Trim().ToString()));
						
						if(txtanf.Text=="")
							scom.Parameters .Add ("@annual_fee","0");
						else
							scom.Parameters .Add ("@annual_fee",float.Parse(txtanf.Text.Trim().ToString()));
						
						if(txtef.Text=="")
							scom.Parameters .Add ("@envp_fee","0");
						else
							scom.Parameters .Add ("@envp_fee",float.Parse(txtef.Text.Trim().ToString()));
						
						if(txthf.Text=="")
							scom.Parameters .Add ("@hostel_fee","0");
						else
							scom.Parameters .Add ("@hostel_fee",txthf.Text.Trim().ToString());
						
						if(txtremark.Text=="")
							scom.Parameters .Add ("@remarks","");
						else
							scom.Parameters .Add ("@remarks",txtremark.Text.Trim().ToString());
				
						if(Txtfromdate.Text=="")
						{
							MessageBox.Show("Please enter the start date");
							return;
						}
						else
							scom.Parameters .Add ("@fromdate",GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString()));

						if(Txttodate.Text=="")
						{
							MessageBox.Show("Please enter the end date");
							return;
						}
						else
							scom.Parameters .Add ("@todate",GenUtil.str2MMDDYYYY(Txttodate.Text.Trim().ToString()));
						scom.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Fees Details Updated");
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  btnSave_Click, Record save for ClassID:  "+cls+", Userid :  "+ pass   );							
				clear();
				fillID();
				btnEdtt.Visible=true;
				lblFeeID.Visible=true;
				DropFeeID.Visible=false;
				btnSave.Visible=true;
				btnEdit.Visible=false;
				scon.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  btnEdit_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DropDownList13_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txttotal_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// this method use to saved feesdecision information in to feesdecision table add in dropdown.
		/// </summary>
		private void btnEdtt_Click(object sender, System.EventArgs e)
		{
			try
			{
				string cls="";
				InventoryClass obj=new InventoryClass();
				SqlDataReader sdtr;
				DropFeeID.Visible=true;
				lblFeeID.Visible=false;
				btnEdit.Visible=true;
				btnEdtt.Visible=false;
				btnSave.Visible=false;
				//string str="Select FeeDecisionID from FeesDecision order by FeeDecisionID";
				string str="Select FeeDecisionID,class_id from FeesDecision order by FeeDecisionID";
				sdtr=obj.GetRecordSet(str);
				DropFeeID.Items.Clear();
				DropFeeID.Items.Add("Select");
				while(sdtr.Read())
				{

					if(sdtr.GetValue(1).ToString().Equals("1"))
						cls="Nursery";
					else if(sdtr.GetValue(1).ToString().Equals("2"))
						cls="LKG";
					else if(sdtr.GetValue(1).ToString().Equals("3"))
						cls="UKG";
					else if(sdtr.GetValue(1).ToString().Equals("4"))
						cls="I";
					else if(sdtr.GetValue(1).ToString().Equals("5"))
						cls="II";
					else if(sdtr.GetValue(1).ToString().Equals("6"))
						cls="III";
					else if(sdtr.GetValue(1).ToString().Equals("7"))
						cls="IV";
					else if(sdtr.GetValue(1).ToString().Equals("8"))
						cls="V";
					else if(sdtr.GetValue(1).ToString().Equals("9"))
						cls="VI";
					else if(sdtr.GetValue(1).ToString().Equals("10"))
						cls="VII";
					else if(sdtr.GetValue(1).ToString().Equals("11"))
						cls="VIII";
					else if(sdtr.GetValue(1).ToString().Equals("12"))
						cls="IX";
					else if(sdtr.GetValue(1).ToString().Equals("13"))
						cls="X";
					else if(sdtr.GetValue(1).ToString().Equals("14"))
						cls="XI";
					else if(sdtr.GetValue(1).ToString().Equals("15"))
						cls="XII";
					//DropFeeID.Items.Add(sdtr.GetValue(0).ToString().Trim());
					DropFeeID.Items.Add(sdtr.GetValue(0).ToString().Trim()+":"+cls.ToString());
				}
				sdtr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  getClassID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method for Fetch Fees Details For A selected Class
		/// </summary>
		private void DropFeeID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				string sStream=DropStream.SelectedItem.Text;
				string Fees_id=DropFeeID.SelectedItem.Text;
                Fees_id=Fees_id.Substring(0,Fees_id.IndexOf(":"));

				//string str="Select * from FeesDecision where FeeDecisionID='"+DropFeeID.SelectedItem.Text+"'";
				string str="Select * from FeesDecision where FeeDecisionID='"+Fees_id.ToString().Trim()+"'";
				scom=new SqlCommand(str,scon);
				sdtr=scom.ExecuteReader();
				string cls="";
				if(sdtr.Read())
				{
					panMonthly.Visible=false;
					panYearly.Visible=false;
					panOneTime.Visible=false;
					/*if(sdtr.GetValue(1).ToString().Equals("1"))
						cls="I";
					else if(sdtr.GetValue(1).ToString().Equals("2"))
						cls="II";
					else if(sdtr.GetValue(1).ToString().Equals("3"))
						cls="III";
					else if(sdtr.GetValue(1).ToString().Equals("4"))
						cls="IV";
					else if(sdtr.GetValue(1).ToString().Equals("5"))
						cls="V";
					else if(sdtr.GetValue(1).ToString().Equals("6"))
						cls="VI";
					else if(sdtr.GetValue(1).ToString().Equals("7"))
						cls="VII";
					else if(sdtr.GetValue(1).ToString().Equals("8"))
						cls="VIII";
					else if(sdtr.GetValue(1).ToString().Equals("9"))
						cls="IX";
					else if(sdtr.GetValue(1).ToString().Equals("10"))
						cls="X";
					else if(sdtr.GetValue(1).ToString().Equals("11"))
						cls="XI";
					else if(sdtr.GetValue(1).ToString().Equals("12"))
						cls="XII";*/

					if(sdtr.GetValue(1).ToString().Equals("1"))
						cls="Nursery";
					else if(sdtr.GetValue(1).ToString().Equals("2"))
						cls="LKG";
					else if(sdtr.GetValue(1).ToString().Equals("3"))
						cls="UKG";
					else if(sdtr.GetValue(1).ToString().Equals("4"))
						cls="I";
					else if(sdtr.GetValue(1).ToString().Equals("5"))
						cls="II";
					else if(sdtr.GetValue(1).ToString().Equals("6"))
						cls="III";
					else if(sdtr.GetValue(1).ToString().Equals("7"))
						cls="IV";
					else if(sdtr.GetValue(1).ToString().Equals("8"))
						cls="V";
					else if(sdtr.GetValue(1).ToString().Equals("9"))
						cls="VI";
					else if(sdtr.GetValue(1).ToString().Equals("10"))
						cls="VII";
					else if(sdtr.GetValue(1).ToString().Equals("11"))
						cls="VIII";
					else if(sdtr.GetValue(1).ToString().Equals("12"))
						cls="IX";
					else if(sdtr.GetValue(1).ToString().Equals("13"))
						cls="X";
					else if(sdtr.GetValue(1).ToString().Equals("14"))
						cls="XI";
					else if(sdtr.GetValue(1).ToString().Equals("15"))
						cls="XII";
					DropClass.SelectedIndex=DropClass.Items.IndexOf(DropClass.Items.FindByValue(cls.ToString()));
					Dropfeetype.SelectedIndex=Dropfeetype.Items.IndexOf(Dropfeetype.Items.FindByValue(sdtr.GetValue(3).ToString()));
					dropscategory.SelectedIndex=dropscategory.Items.IndexOf(dropscategory.Items.FindByValue(sdtr["scategory"].ToString()));
					string s=sdtr["srank"].ToString();
					//8.11.08 Droprank.Items.Add(sdtr["srank"].ToString());
					//8.11.08 Droprank.SelectedIndex=Droprank.Items.IndexOf(Droprank.Items.FindByValue(sdtr["srank"].ToString()));
                    temprank.Value=sdtr["srank"].ToString();
					DropRank.Items.Add(sdtr["srank"].ToString());
					DropRank.SelectedIndex=DropRank.Items.IndexOf(DropRank.Items.FindByValue(sdtr["srank"].ToString()));

					DropStream.SelectedIndex=DropStream.Items.IndexOf(DropStream.Items.FindByValue(sdtr.GetValue(2).ToString()));
					if(sdtr["feemode"].Equals("One Time"))
					{
						panOneTime.Visible=true;
						txtadf.Text=GenUtil.strNumericFormat(sdtr["admission_fee"].ToString());
						txtcmf.Text=GenUtil.strNumericFormat(sdtr["caution_fee"].ToString());
					}
					else if(sdtr["feemode"].Equals("Monthly"))
					{
						panMonthly.Visible=true;
						txttf.Text=GenUtil.strNumericFormat(sdtr["tution_fee"].ToString());
						txtgf.Text=GenUtil.strNumericFormat(sdtr["games_fee"].ToString());
						txtlf.Text=GenUtil.strNumericFormat(sdtr["late_fee"].ToString());
						txttrf.Text=GenUtil.strNumericFormat(sdtr["transport_fee"].ToString());
						txtcf.Text=GenUtil.strNumericFormat(sdtr["computer_fee"].ToString());
						txtsf.Text=GenUtil.strNumericFormat(sdtr["science_fee"].ToString());
						txthf.Text=GenUtil.strNumericFormat(sdtr["hostel_fee"].ToString());
					}
					else if(sdtr["feemode"].Equals("Yearly"))
					{
						panYearly.Visible=true;
						txtdf.Text=GenUtil.strNumericFormat(sdtr["diary_fee"].ToString());
						txtanf.Text=GenUtil.strNumericFormat(sdtr["annual_fee"].ToString());
						txtef.Text=GenUtil.strNumericFormat(sdtr["envp_fee"].ToString());
					}
					txtremark.Text=sdtr["remarks"].ToString();
					Txtfromdate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["fromdate"].ToString()));
					Txttodate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(sdtr["todate"].ToString()));
				}
				else
				{
					MessageBox.Show("Data Not Available");
				}
				sdtr.Close();
				scon.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  getClassID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void dropscategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*8.11.08 string str="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader sdtr;
				Droprank.Items.Clear();
				Droprank.Items.Add("Select");
				if(dropscategory.SelectedIndex!=0)
				{
					str="Select distinct rank from category where catname= '"+dropscategory.SelectedItem.Text+"'";
					sdtr=obj.GetRecordSet(str);
					Droprank.Items.Clear();
					Droprank.Items.Add("Select");
					while(sdtr.Read())
					{
						Droprank.Items.Add(sdtr.GetValue (0).ToString ().Trim());
					}
					sdtr.Close();
				}
				else
				{
					MessageBox.Show("Please Select Scategory");
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesDecision.aspx,Method  getClassID,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}*/
		}

		/// <summary>
		/// If dropdown Select one Time then show Only those textbox which are belong in PanOneTime.
		/// </summary>
		private void Dropfeetype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(Dropfeetype.SelectedIndex!=0)
			{
				panMonthly.Visible=false;
				panOneTime.Visible=false;
				panYearly.Visible=false;
				if(Dropfeetype.SelectedItem.Text.Equals("One Time"))
					panOneTime.Visible=true;
				else if(Dropfeetype.SelectedItem.Text.Equals("Monthly"))
					panMonthly.Visible=true;
				else if(Dropfeetype.SelectedItem.Text.Equals("Yearly"))
					panYearly.Visible=true;
			}
		}
	}
}

	
	

