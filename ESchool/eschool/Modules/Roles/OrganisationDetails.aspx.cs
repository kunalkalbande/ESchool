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
using System.IO;
using eschool.Classes ; 
using DBOperations;

namespace eschool
{
	/// <summary>
	/// Summary description for OrganisationDetails.
	/// </summary>
	public class OrganisationDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtEMail;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label LblCompanyID;
		protected System.Web.UI.WebControls.TextBox TxtAddress;
		protected System.Web.UI.WebControls.TextBox TxtAddress1;
		protected System.Web.UI.WebControls.TextBox TxtWebsite;
		protected System.Web.UI.HtmlControls.HtmlInputFile txtFileContents;
		protected System.Web.UI.WebControls.TextBox txtFileTitle;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCommand scom;
		SqlDataReader sdtr; 
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
		protected System.Web.UI.WebControls.TextBox txtMsg;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCountry1;
		protected System.Web.UI.WebControls.DropDownList DropID;
		protected System.Web.UI.WebControls.TextBox txtOwnerName;
		protected System.Web.UI.WebControls.TextBox TxtOrganisationName;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtPhoneOff;
		protected System.Web.UI.WebControls.TextBox TxtFaxNo;
		protected System.Web.UI.WebControls.TextBox TxtAddress2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtdumy;
		protected System.Web.UI.HtmlControls.HtmlInputText temporgdata;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		/// and generate the next ID also.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtDateFrom.Attributes.Add("readonly", "readonly");
            txtDateTo.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : OrganisationDetails.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
			}
			try
			{
				scon.Open();
				
				if(!Page.IsPostBack)
				{
					txtDateFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtDateTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					DropID.Visible =false; 
					GetNextOrgID();
					#region Fill Local Country DropDown
					scom=new SqlCommand("Select distinct Country from Country order by Country asc",scon);
					sdtr=scom.ExecuteReader();
					DropCountry.Items.Add("---Select---");
					while(sdtr.Read())
					{
						DropCountry.Items.Add(sdtr.GetString(0));
					}
					sdtr.Close();
					scom=new SqlCommand("Select distinct state from Country order by state asc",scon);
					sdtr=scom.ExecuteReader();
					DropState.Items.Add ("---Select---");
					while(sdtr.Read())
					{
						DropState.Items .Add (sdtr.GetString (0));
					}
					sdtr.Close ();
					scom=new SqlCommand("Select distinct City from Country order by City asc",scon);
					sdtr=scom.ExecuteReader();
					DropCity.Items.Add ("---Select---");
					while(sdtr.Read())
					{
						DropCity.Items.Add (sdtr.GetString (0));
					}
					sdtr.Close ();
					#endregion
					
					#region Fill Text

					scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				    scon.Open ();
					scom=new SqlCommand("Select Country,State,City from Country order by Country,State,City",scon);
					sdtr= scom.ExecuteReader();
					while(sdtr.Read())
					{
						txtName.Value=txtName.Value+sdtr.GetString(0).ToString().Trim()+ ":" +sdtr.GetString(1).ToString().Trim()+ ":" +sdtr.GetString(2).ToString().Trim()+ ",";
					}
					sdtr.Close();
					#endregion  
					clear();
				}
				CreateLogFiles.ErrorLog (" Form : OrganisationDetails.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form : OrganisationDetails.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect("HolidayEntryForm.aspx",false); 
			}
			
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="1";
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
			this.DropID.SelectedIndexChanged += new System.EventHandler(this.DropID_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.DropState.SelectedIndexChanged += new System.EventHandler(this.DropState_SelectedIndexChanged);
			this.DropCountry.SelectedIndexChanged += new System.EventHandler(this.DropCountry_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This method is used to fatch the organization id from organization table and fill the 
		/// dropdownlist on edit time.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Label1.Visible=true;
				btnUpdate.Text="Update";
				txtFileContents.EnableViewState =false;
				Button1.Visible=false;
				DropID.Visible=true;
				LblCompanyID.Visible=false;
				txtFileContents .Visible =false;
				scom=new SqlCommand("Select organisation_ID from organisation",scon);
				sdtr=scom.ExecuteReader();
				DropID.Items .Clear (); 
				DropID.Items .Add ("---Select---"); 
				while(sdtr.Read())
				{
					DropID.Items.Add(sdtr.GetValue(0).ToString());
				}
				sdtr.Close();

				#region

				InventoryClass obj=new InventoryClass();
				SqlDataReader sdtr12=null;
				string str="Select * from organisation";
				sdtr12=obj.GetRecordSet(str);
				if(sdtr12.Read())
				{
					for(int i=0;i<sdtr12.FieldCount;i++)
					{
						temporgdata.Value=temporgdata.Value+sdtr12.GetValue(i)+":";	
					}
				}
				sdtr12.Close();
				
				#endregion
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Method:savebutton. User: " + pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx,Method:saveButton. Exception: " + ex.Message + " User: " + pass);
			}
		}

		/// <summary>
		/// This method is used to Displays the Organisation details information on edit time.
		/// </summary>
		private void DropID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtdumy.Value =DropID.SelectedItem.Value.ToString();
				if(txtdumy.Value =="Select")
				{
					MessageBox.Show("Please Select Organisation ID ");
				}
				else
				{
					scom=new SqlCommand ("select * from organisation where organisation_ID='" + DropID.SelectedItem.Value + "'",scon);
					sdtr=scom.ExecuteReader ();
					while(sdtr.Read())
					{
						TxtOrganisationName.Text=sdtr.GetValue(2).ToString();  
						txtOwnerName.Text= sdtr.GetValue (1).ToString ();
						TxtAddress.Text=sdtr.GetValue(3).ToString();
						DropCity .SelectedIndex=(DropCity.Items.IndexOf((DropCity.Items.FindByValue(sdtr.GetValue(6).ToString()))));
						DropState .SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(sdtr.GetValue(5).ToString()))));
						DropCountry .SelectedIndex=(DropCountry .Items.IndexOf((DropCountry .Items.FindByValue(sdtr.GetValue(4).ToString()))));
						txtPhoneOff.Text=sdtr.GetValue(7).ToString();
						TxtFaxNo.Text=sdtr.GetValue(8).ToString(); 
						txtEMail .Text =sdtr.GetValue(9).ToString(); 
						TxtWebsite.Text= sdtr.GetValue(10).ToString(); 
						txtMsg.Text=sdtr.GetValue (12).ToString ();
						txtDateFrom.Text =GenUtil.trimDate(GenUtil.str2DDMMYYYY (sdtr.GetValue (13).ToString ())); 
						txtDateTo.Text =GenUtil.trimDate(GenUtil.str2DDMMYYYY (sdtr.GetValue (14).ToString ())); 
					}
					sdtr.Close();
					CreateLogFiles.ErrorLog("Form : OrganisationDetails.aspx, Method : DropEdit_SelectedIndexChanged "+ " User: " + pass);
				}
			}
			catch(Exception ex)
			{
				    CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx, Method : DropEdit_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass);
			}
		}

		/// <summary>
		/// This method is used to update the informatoin in organiaztion table.
		/// </summary>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				if(LblCompanyID.Text=="1002" && LblCompanyID.Visible ==true)
				{
					MessageBox.Show("School Information Already Stored ");
					clear();
					return;
				}
				else if(LblCompanyID.Visible==true)
				{
					saveimage();
					Label1.Visible=false;
				}
				else if(DropID.Visible==true)
				{
					Label1.Visible=true;
					saveimage1();
					DropID.Visible =false;
					Button1.Visible =true; 
					LblCompanyID.Visible=true;
					
				}
				btnUpdate.Text="Save Profile";
				
			}
			catch(Exception ex)
			{
			}
		}
	
		/// <summary>
		/// This method is used to Fetch the Organisation ID from Organisation table.
		/// </summary>
		public void GetNextOrgID()
		{
			scom=new SqlCommand("Select max(Organisation_ID)+1 from organisation",scon);		
			sdtr=scom.ExecuteReader();
			if(sdtr.Read())
				LblCompanyID.Text =sdtr.GetValue (0).ToString ();
			if(LblCompanyID.Text.Equals (""))
				LblCompanyID.Text="1001";
			sdtr.Close();
		}

		/// <summary>
		/// This method is used to clear the form.
		/// </summary>
		public void clear()
		{			
			txtDateFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtDateTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtOwnerName.Text="";
			TxtOrganisationName.Text="";
			TxtAddress .Text="";
			TxtAddress1.Text="";
			TxtAddress2.Text="";
			DropCity.SelectedIndex=0;
			DropState.SelectedIndex=0;
			DropCountry .SelectedIndex=0;
			txtPhoneOff.Text="";
			TxtFaxNo.Text="";
			txtEMail.Text="";
			TxtWebsite.Text="";
			txtMsg.Text="";
		}

		/// <summary>
		/// This method is used to set the image path in session variable.
		/// </summary>
		public void SaveimageinFolder()
		{
			string strpath =System.Configuration .ConfigurationSettings .AppSettings["FileUploadPath"];  
			string strExt=System.IO.Path .GetFileName (txtFileContents.PostedFile.FileName);
			string  filePath=strpath+"/"+strExt;
			txtFileContents.PostedFile.SaveAs(filePath);
			Session["rajImage"]=filePath; 
		}

		/// <summary>
		/// This method is used to Insert the Organisation details into organisation table.
		/// </summary>
		public void saveimage()
		{
			try
			{
				SqlConnection conMyData;
				string  strInsert;
				SqlCommand cmdInsert;
					string filename =  txtFileContents.PostedFile.FileName;

					conMyData=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					conMyData.Open();
					strInsert = "Insert Organisation (Organisation_ID,OwnerName,OrganisationName,Address,Country,State,City,PhoneNo,FaxNo,Email,Website,logo,message,Acc_date_from,Acc_date_to) " + "Values (@OrganisationID,@OwnerName,@OrganisationName,@Address,@Country,@State,@City,@PhoneNo,@FaxNo ,@Email,@Website,@logo,@message,@Acc_date_from,@Acc_date_to)";
					cmdInsert = new SqlCommand( strInsert, conMyData );
					cmdInsert.Parameters.Add( "@OrganisationID", LblCompanyID.Text.Trim().ToString());
					cmdInsert.Parameters.Add( "@OwnerName", txtOwnerName.Text.Trim().ToString() );
					cmdInsert.Parameters.Add("@OrganisationName", TxtOrganisationName.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@Address", TxtAddress .Text.Trim().ToString()+" "+TxtAddress1.Text.Trim().ToString()+" "+TxtAddress2.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@Country", DropCountry.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@State", DropState.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@City", DropCity.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@PhoneNo", txtPhoneOff.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@FaxNo", TxtFaxNo.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@Email", txtEMail.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@Website", TxtWebsite.Text.Trim().ToString() );
					cmdInsert.Parameters.Add( "@logo",filename.ToString());
					cmdInsert.Parameters .Add ("@message",txtMsg.Text.Trim().ToString ());
					cmdInsert.Parameters .Add ("@Acc_date_from",GenUtil.str2MMDDYYYY(txtDateFrom.Text ));
					cmdInsert.Parameters .Add ("@Acc_date_to",GenUtil.str2MMDDYYYY(txtDateTo.Text ));
					cmdInsert.ExecuteNonQuery();
					
					// This Code Use For Auto Create Cash Account Add By Vikas Sharma 06.04.09 
				    object op = null;
					dbobj.ExecProc(OprType.Insert,"ProInsertLedger",ref op,"@Ledger_Name","Cash","@SubGrp_Name","Cash in hand","@Group_Name","Current Assets","@Grp_Nature","Assets","@Op_Bal","0","@Bal_Type","Dr");

					MessageBox.Show("School Information Saved ");	
					clear();
					GetNextOrgID();
					cmdInsert.Dispose();
					conMyData.Close();
					CreateLogFiles.ErrorLog("Form : OrganisationDetails.aspx, Method : btnSave_click "+ " User: " + pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx, Method : btnSave_click. Exception: " + ex.Message + " User: " + pass);
			}
		}

		/// <summary>
		/// This method is used to update the Organisation details.
		/// </summary>
		public void saveimage1()
		{
			try
			{
				SqlConnection conMyData;
				string  strInsert;
				SqlCommand cmdInsert;
					string filename =  txtFileContents.PostedFile.FileName;

					conMyData=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					conMyData.Open();
					
					if(filename.ToString().Trim().Equals(""))
					{
						strInsert = "update Organisation set Organisation_ID=@OrganisationID,OwnerName=@OwnerName,OrganisationName=@OrganisationName,Address=@Address,Country=@Country,State=@State,City=@City,PhoneNo=@PhoneNo,FaxNo=@FaxNo ,Email=@Email,Website=@Website,message=@message,Acc_date_from=@Acc_date_from,Acc_date_to=@Acc_date_to where Organisation_ID=@OrganisationID";
					}
					else
					{
						strInsert = "update Organisation set Organisation_ID=@OrganisationID,OwnerName=@OwnerName,OrganisationName=@OrganisationName,Address=@Address,Country=@Country,State=@State,City=@City,PhoneNo=@PhoneNo ,FaxNo=@FaxNo,Email=@Email,Website=@Website,logo=@logo,message=@message,Acc_date_from=@Acc_date_from,Acc_date_to=@Acc_date_to where Organisation_ID=@OrganisationID";
					}
					cmdInsert = new SqlCommand( strInsert, conMyData );
					cmdInsert.Parameters.Add( "@OrganisationID", DropID.SelectedItem.Value.ToString());
					cmdInsert.Parameters.Add( "@OwnerName", txtOwnerName.Text );
					cmdInsert.Parameters.Add("@OrganisationName", TxtOrganisationName.Text );
					cmdInsert.Parameters.Add( "@Address", TxtAddress .Text.ToString()+" "+TxtAddress1.Text.ToString()+" "+TxtAddress2.Text.ToString() );
					cmdInsert.Parameters.Add( "@City", DropCity.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@State", DropState.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@Country", DropCountry.SelectedItem.Value.ToString() );
					cmdInsert.Parameters.Add( "@PhoneNo", txtPhoneOff.Text.ToString() );
					cmdInsert.Parameters.Add( "@FaxNo", TxtFaxNo.Text.ToString() );
					cmdInsert.Parameters.Add( "@Email", txtEMail.Text.ToString() );
					cmdInsert.Parameters.Add( "@Website", TxtWebsite .Text.ToString() );
					if(!(filename.ToString().Trim().Equals("")))
					{
						cmdInsert.Parameters.Add( "@logo",filename.ToString());
					}
				    cmdInsert.Parameters .Add ("@message",txtMsg.Text.ToString ());
					cmdInsert.Parameters .Add ("@Acc_date_from",GenUtil.str2MMDDYYYY(txtDateFrom.Text ));
					cmdInsert.Parameters .Add ("@Acc_date_to",GenUtil.str2MMDDYYYY(txtDateTo.Text ));
					cmdInsert.ExecuteNonQuery();
					// This Code Use For Update Cash Account Add By Vikas Sharma 06.04.09
					SqlDataReader rdr=null;
					object op = null;
					dbobj.SelectQuery("update Ledger_Master set Eff_From='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"', Eff_to='"+GenUtil.str2MMDDYYYY(txtDateTo.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='Cash' and Sub_Grp_Name='cash in hand')",ref rdr);
					dbobj.SelectQuery("update AccountsLedgerTable set Entry_Date='"+GenUtil.str2MMDDYYYY(txtDateFrom.Text)+"' where Ledger_ID=(select Ledger_id from Ledger_Master lm,Ledger_Master_Sub_Grp lms where lm.Sub_Grp_ID=lms.Sub_Grp_ID and Ledger_Name='Cash' and Sub_Grp_Name='cash in hand') and Particulars='Opening Balance'",ref rdr);
					//
					clear();
					MessageBox.Show("School Information Updated ");	
					CreateLogFiles.ErrorLog("Form : OrganisationDetails.aspx, Method : btnUpdate_click "+ " User: " + pass);
					conMyData.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:OrganisationDetails.aspx, Method : btnUpdate_click. Exception: " + ex.Message + " User: " + pass);
			}
		}
			
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
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
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void DropCountry_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
