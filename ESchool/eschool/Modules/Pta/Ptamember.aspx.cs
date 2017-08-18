  /*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
#  region Directives...
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
using RMG;
using System.Text;
using eschool.Classes ;
# endregion

namespace eschool.Modules.Pta
{
	/// <summary>
	/// Summary description for Ptamember.
	/// </summary>
	
	public class Form1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropdesi;
		protected System.Web.UI.WebControls.TextBox Textadd;
		protected System.Web.UI.WebControls.TextBox txtmobile;
		protected System.Web.UI.WebControls.DropDownList Dropstaffid;
		protected System.Web.UI.WebControls.TextBox txtstudentname;
		protected System.Web.UI.WebControls.Label LabelClass;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox txtempnm;
		protected System.Web.UI.WebControls.Label Labelstaff;
		protected System.Web.UI.WebControls.Label Labelname;
		protected System.Web.UI.WebControls.TextBox txtclass;
		protected System.Web.UI.WebControls.Label Labelsn;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.Label labelid;
		protected System.Web.UI.WebControls.DropDownList Dropstudentid;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ValidationSummary vsPtaMember;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtState1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.HtmlControls.HtmlInputText Text;
		protected System.Web.UI.WebControls.TextBox txtname1;
		protected System.Web.UI.HtmlControls.HtmlInputText DropCountryValue;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.TextBox Texthone;
		protected System.Web.UI.WebControls.TextBox Textpin;
		protected System.Web.UI.WebControls.DropDownList DropCity;
		protected System.Web.UI.WebControls.DropDownList DropState;
		protected System.Web.UI.WebControls.DropDownList DropCountry;
		protected System.Web.UI.WebControls.Panel panoff;
		protected System.Web.UI.WebControls.Panel pannon;
		protected System.Web.UI.WebControls.Button btnSave;
		SqlConnection con;
		SqlCommand cmdselect;
		SqlDataReader dtrall;
		protected System.Web.UI.WebControls.DropDownList Droptypemem;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revName;
		protected System.Web.UI.WebControls.CompareValidator cvTypeOfMem;
		protected System.Web.UI.WebControls.CompareValidator cvDesignation;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.CompareValidator cvStuId;
		protected System.Web.UI.WebControls.CompareValidator cvStaffId;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPhNo;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator revStuMobNo;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegExpEid;
		protected System.Web.UI.WebControls.CompareValidator cvCheckedBy;
		string pass;
		SqlConnection con111;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtstudentname.Attributes.Add("readonly", "readonly");
            txtclass.Attributes.Add("readonly", "readonly");
            txtempnm.Attributes.Add("readonly", "readonly");
            try
			{
				pass=(Session["User_Name"].ToString());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : PTA_Communication.aspx,Method:PageLoad   "+" EXCEPTION "+ ex.Message+" userid "+ pass);
				//Response.Redirect("../../ErrorPage.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				//pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog (" Form : Ptamember.aspx.cs, Method: Page_Load. User: " + pass );

				#region Fill Text

				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect=new SqlCommand("Select Country,State,City from Country order by Country,State,City",con);
				dtrall= cmdselect.ExecuteReader();
				while(dtrall.Read())
				{
					txtName.Value=txtName.Value+dtrall.GetString(0).ToString().Trim()+ ":" +dtrall.GetString(1).ToString().Trim()+ ":" +dtrall.GetString(2).ToString().Trim()+ ",";
				}
				dtrall.Close();
				#endregion
 
				if(!Page.IsPostBack)
				{
					# region Fill the  Staff ID into DropdownBox.
					try
					{
						//commented by vikas sharma 26.10.07
						cmdselect = new SqlCommand( "Select Distinct Staff_ID  From Staff_Information order by Staff_ID", con );
						dtrall = cmdselect.ExecuteReader();
						while(dtrall.Read())
						{
							Dropdownlist1.Items.Add(dtrall.GetValue(0).ToString());
						}
						dtrall.Close();
						# endregion
						# region  Fill Staff Name into the  Dropdown
						cmdselect = new SqlCommand( "Select Staff_Name  From Staff_Information order by Staff_Name", con );
						dtrall = cmdselect.ExecuteReader();
						while (dtrall.Read()) 
						{
							Dropstaffid.Items.Add(dtrall.GetString(0));
						}
						dtrall.Close();
						# endregion
						# region Fill  StudentID into the  DropdownBox
						cmdselect = new SqlCommand( "Select Distinct Student_ID,Student_FName  From Student_Record order by Student_ID", con );
						dtrall = cmdselect.ExecuteReader();
						while(dtrall.Read())
						{
							Dropstudentid.Items.Add(dtrall.GetValue(0).ToString());
						}
						dtrall.Close();
						# endregion
						fillID();
						cmdselect =new SqlCommand("Select distinct Country from Country order by Country asc",con);
						dtrall=cmdselect.ExecuteReader();
					
						while(dtrall.Read())
						{
							DropCountry.Items.Add(dtrall.GetString(0));
						}
						dtrall.Close();
						cmdselect=new SqlCommand("Select distinct state from Country order by state asc",con);
						dtrall=cmdselect .ExecuteReader();
					
						while(dtrall.Read())
						{
							DropState.Items .Add (dtrall.GetString (0));
						}
						dtrall.Close ();
						cmdselect =new SqlCommand("Select distinct City from Country order by City asc",con);
						dtrall=cmdselect.ExecuteReader();
						
						while(dtrall.Read())
						{
							DropCity.Items.Add (dtrall.GetString (0));
						}
						dtrall.Close ();
					}
					catch(Exception ex)
					{
						//CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
					}
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="8";
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
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
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
			this.Droptypemem.SelectedIndexChanged += new System.EventHandler(this.Droptypemem_SelectedIndexChanged);
			this.DropCity.SelectedIndexChanged += new System.EventHandler(this.DropCity_SelectedIndexChanged);
			this.Dropstudentid.SelectedIndexChanged += new System.EventHandler(this.Dropstudentid_SelectedIndexChanged);
			this.Dropdownlist1.SelectedIndexChanged += new System.EventHandler(this.Dropdownlist1_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.ID = "Form1";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use hide and show Official Or Non Official control.
		/// </summary>
		private void Droptypemem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( Droptypemem.SelectedItem .Value.ToString()=="Official")
			{
				panoff.Visible=true;
				pannon.Visible=false;
     		}
			else if (Droptypemem.SelectedItem .Value.ToString()=="Non Official")
			{
				pannon.Visible=true;
				panoff.Visible=false;
			}
		}
	
		/// <summary>
		/// this method use for getting the Staff Name and fill into the text box.
		/// </summary>
		private void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Labelstaff.Visible =true;
			Dropdownlist1.Visible =true;
			Labelname.Visible =true;
			txtempnm.Visible =true;
			SqlConnection con3;
			SqlCommand cmdselect3;
			SqlDataReader dtredit3;
			try
			{
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();
				if(Dropdownlist1.SelectedIndex!=0)
				{
					cmdselect3 = new SqlCommand( "Select Staff_Name From Staff_Information where Staff_ID=@Staff_ID", con3 );
					cmdselect3.Parameters .Add ("@Staff_ID",Dropdownlist1.SelectedItem .Value  .ToString ());
					dtredit3 = cmdselect3.ExecuteReader();
					while (dtredit3.Read()) 
					{
						txtempnm.Text  =dtredit3.GetString (0);
					}
					dtredit3.Close();
				}
				con3.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: Dropdownlist1_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}
		
		/// <summary>
		/// for getting the student name and class name and fill into the textbox
		/// </summary>
		private void Dropstudentid_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			labelid.Visible =true;
			Dropstudentid.Visible =true;
			Labelsn.Visible =true;
			txtstudentname.Visible =true;
			LabelClass.Visible =true;
			txtclass.Visible =true;
			SqlConnection con44;
			SqlCommand cmdselect44;
			SqlDataReader dtrdrive44;
			try
			{
				con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con44.Open ();
				if(Dropstudentid.SelectedIndex!=0)
				{
					cmdselect44 = new SqlCommand( "Select Student_FName,Student_Class  From Student_Record where Student_ID=@Student_ID", con44 );
					cmdselect44.Parameters .Add ("@Student_ID",Dropstudentid.SelectedItem .Text.ToString());
					dtrdrive44 = cmdselect44.ExecuteReader();
					while (dtrdrive44.Read()) 
					{
						txtstudentname.Text  =dtrdrive44.GetString(0);
						txtclass.Text =dtrdrive44.GetString(1);
					}
					dtrdrive44.Close();
				}
				con44.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: Dropstudentid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// for clearing the data from controls
		/// </summary>
		public void clear()
		{
			txtname1.Text="";
			Dropdesi.SelectedIndex=0;
			Droptypemem.SelectedIndex=0;
			Dropdownlist1.SelectedIndex=0;
			Dropstudentid.SelectedIndex=0;
			Textadd.Text="";
			DropCountry.SelectedIndex =0; 
			Textpin.Text="";
			DropCity.SelectedIndex =0;
			DropState.SelectedIndex =0; 
			Texthone.Text="";
			txtmobile.Text="";
			txtemail.Text="";
			Dropstaffid.SelectedIndex=0;
			txtstudentname.Text="";
			txtclass.Text="";
			txtempnm.Text="";
		}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			 clear();
			pannon.Visible=false;
			panoff.Visible=false;
		}

		/// <summary>
		/// this method use to Get Next ptamembershipID
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
				cmd=new SqlCommand("select max(ptamem)+1 from ptamembership",con);
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
				
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: Dropstudentid_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
				
			}
		}

		/// <summary>
		/// this method use to Insert Ptamember record in to ptamembership table. and also check before insert record also exist or not.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlCommand cmdInsert111;
				SqlDataReader sdr; 
				string strInsert111;
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				fillID();
				cmdInsert111=new SqlCommand ("select * from ptamembership where teleno='" + Texthone.Text.ToString().Trim () + "'  and address='" + Textadd.Text.ToString ().Trim () + "'" ,con111);
				sdr=cmdInsert111.ExecuteReader ();
				if(sdr.HasRows )
				{
					MessageBox.Show ("Record Already Exists");
					clear ();
					return;
				}
				sdr.Close ();
				strInsert111 = "Insert ptamembership(ptamem,name,Designation,membertype,address,teleno,mobileno,Student_ID,Staffid,Checkedby,Pcity,pin,state,Country,email)values (@ptamem,@name,@Designation,@membertype,@address,@teleno,@mobileno,@Student_ID,@Staffid,@Checkedby,@Pcity,@pin,@state,@Country,@email)";
				cmdInsert111=new SqlCommand (strInsert111,con111);
				cmdInsert111.Parameters .Add ("@ptamem",i.Trim().ToString());
				if(txtname1.Text=="")
					cmdInsert111.Parameters .Add ("@name","");
				else
					cmdInsert111.Parameters .Add ("@name",txtname1.Text.ToUpper() );
				if(Dropdesi.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@Designation","0");
				else
					cmdInsert111.Parameters .Add ("@Designation ",Dropdesi.SelectedItem .Value.ToString ());
				if(Droptypemem.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@membertype","0");
				else
					cmdInsert111.Parameters .Add ("@membertype",Droptypemem.SelectedItem .Value.ToString ());
				if(Dropdownlist1.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@Staffid","0");
				else
					cmdInsert111.Parameters .Add ("@Staffid",Dropdownlist1.SelectedItem .Value.ToString ());
				if(Dropstudentid.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@Student_ID","0");
				else
					cmdInsert111.Parameters .Add ("@Student_ID",Dropstudentid.SelectedItem .Value.ToString ());
				if(Textadd.Text=="")
					cmdInsert111.Parameters .Add ("@address","");
				else
					cmdInsert111.Parameters .Add ("@address",Textadd.Text.ToUpper());
				if(DropCity.SelectedIndex.Equals("0"))
					cmdInsert111.Parameters .Add ("@Pcity","0");
				else
					cmdInsert111.Parameters .Add ("@Pcity",DropCity.SelectedItem.Value.ToString().Trim());
				if(Textpin.Text=="")
					cmdInsert111.Parameters .Add ("@pin","");
				else
					cmdInsert111.Parameters .Add ("@pin",Textpin.Text.ToUpper());
				if(DropState.SelectedIndex.Equals("0"))
					cmdInsert111.Parameters .Add ("@state","0");
				else
					cmdInsert111.Parameters .Add ("@state",DropState.SelectedItem.Value.ToString().Trim());
				if(DropCountry.SelectedIndex.Equals("0"))
					cmdInsert111.Parameters .Add ("@Country","0");
				else
					cmdInsert111.Parameters .Add ("@Country",DropCountry.SelectedItem.Value.ToString().Trim());
				if(Texthone.Text=="")
					cmdInsert111.Parameters .Add ("@teleno","");
				else
					cmdInsert111.Parameters .Add ("@teleno",Texthone.Text.ToUpper());
				if(txtmobile.Text=="")
					cmdInsert111.Parameters .Add ("@mobileno","");
				else
					cmdInsert111.Parameters .Add ("@mobileno",txtmobile.Text.ToUpper());
				if(txtemail.Text=="")
					cmdInsert111.Parameters .Add ("@email","");
				else
					cmdInsert111.Parameters .Add ("@email",txtemail.Text);
				if(Dropstaffid.SelectedIndex==0)
					cmdInsert111.Parameters .Add ("@Checkedby","0");
				else
					cmdInsert111.Parameters .Add ("@Checkedby",Dropstaffid.SelectedItem .Value.ToString ());
				cmdInsert111.ExecuteNonQuery();
				con111.Close ();
				MessageBox.Show("Member Registration Saved");
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: btnSave_Click. PTA Membership Registerd for member"+txtname1.Text.ToUpper()+"  User: " + pass );		
				clear();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// When Select City then State and Country Auto select
		/// this method not in use.
		/// </summary>
		private void DropCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(DropCity.SelectedIndex!=0)
				{
					SqlConnection con=null; 
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					SqlCommand scom=null;
					SqlDataReader sdtr=null; 
					scom=new SqlCommand("Select country, state from Country where city='" + DropCity.SelectedItem.Value.ToString () + "' order by state",con);
					sdtr=scom.ExecuteReader();
					while(sdtr.Read())
					{
						DropState.SelectedIndex=(DropState.Items.IndexOf((DropState.Items.FindByValue(sdtr.GetValue(1).ToString()))));
						DropCountry.SelectedIndex=(DropCountry .Items.IndexOf((DropCountry.Items.FindByValue(sdtr.GetValue(0).ToString()))));
					}
					sdtr.Close();
					if(Droptypemem.SelectedIndex !=0)
					{
						
						if (Droptypemem.SelectedItem .Value.ToString()=="Official")
						{
							Labelstaff.Visible =true;
							Dropdownlist1.Visible =true;
							Labelname.Visible =true;
							txtempnm.Visible =true;
						}
						else
						{
							labelid.Visible =true;
							Dropstudentid.Visible =true;
							Labelsn.Visible =true;
							txtstudentname.Visible =true;
							LabelClass.Visible =true;
							txtclass.Visible =true;
						}
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptamember.aspx.cs, Method: DropCity_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}
	}
}
