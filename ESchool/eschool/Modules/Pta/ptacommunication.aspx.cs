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
using RMG;
using System.Text;
using eschool.Classes;
# endregion

namespace eschool.Pta
{
	/// <summary>
	/// Summary description for ptacommunication.
	/// </summary>
	public class ptacommunication : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropmember;
		protected System.Web.UI.WebControls.DropDownList Dropcomm;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox txtmname;
		protected System.Web.UI.WebControls.TextBox txtadd;
		protected System.Web.UI.WebControls.TextBox txtcity;
		protected System.Web.UI.WebControls.TextBox txtstate;
		protected System.Web.UI.WebControls.TextBox txtcountry;
		protected System.Web.UI.WebControls.TextBox txtphone;
		protected System.Web.UI.WebControls.TextBox txtemail;
		protected System.Web.UI.WebControls.TextBox txtmdate;
		protected System.Web.UI.WebControls.TextBox txtsdate;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.ValidationSummary vsPtaCommunication;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList DropAgenda;
		protected System.Web.UI.WebControls.CompareValidator vialid1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.Label Label1;
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
				// string pass;
				//  pass=(Session["password"].ToString ());
				if(!IsPostBack)
				{
					txtmdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtsdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					# region Dropdown Staff Name
					SqlConnection con33;
					SqlCommand cmdselect33;
					SqlDataReader dtrall33;
					con33=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con33.Open ();
					cmdselect33 = new SqlCommand( "Select  Staff_Name  From Staff_Information order by Staff_Name", con33 );
					dtrall33 = cmdselect33.ExecuteReader();
						
					while (dtrall33.Read()) 
					{
					
						Dropdownlist1.Items.Add(dtrall33.GetString(0));
					}
					dtrall33.Close();
					con33.Close ();
					# endregion
					fillID();

					# region Dropdown PtaMember
					SqlConnection con44;
					SqlCommand cmdselect44;
					SqlDataReader dtrall44;
					con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con44.Open ();
					cmdselect44 = new SqlCommand( "Select ptamem  From ptamembership order by ptamem", con44 );
					dtrall44 = cmdselect44.ExecuteReader();
					while(dtrall44.Read())
					{
						Dropmember.Items.Add(dtrall44.GetValue(0).ToString());
					}
					dtrall44.Close();
					# endregion
					# region Dropdown Agenda
					cmdselect44 = new SqlCommand( "Select agenda from ptameetingagenda order by meetingdt", con44 );
					dtrall44 = cmdselect44.ExecuteReader();
					while(dtrall44.Read())
					{
						DropAgenda.Items.Add(dtrall44.GetValue(0).ToString());
					}
					dtrall44.Close();
					con44.Close ();
					# endregion
				}
				CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click, Userid :  " + pass   );				
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
				Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				return;	
			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="8";
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
			this.Dropmember.SelectedIndexChanged += new System.EventHandler(this.Dropmember_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to Fetch Data ptamembership table for a selected member.
		/// </summary>
		private void Dropmember_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				SqlConnection con222;
				SqlCommand cmdselect222;
				SqlDataReader dtrdrive222;
				con222=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con222.Open ();
				cmdselect222 = new SqlCommand( "Select name,address,teleno,Pcity,state,Country,email  From ptamembership where ptamem=@ptamem", con222 );
				cmdselect222.Parameters .Add ("@ptamem",Dropmember.SelectedItem .Text.ToString());
				dtrdrive222 = cmdselect222.ExecuteReader();
				while (dtrdrive222.Read()) 
				{
    				txtmname.Text =dtrdrive222.GetString(0);
					txtadd.Text =dtrdrive222.GetString(1);
					txtphone.Text =dtrdrive222.GetString(2);
					txtcity.Text =dtrdrive222.GetString(3);
					txtstate.Text =dtrdrive222.GetString(4);
					txtcountry.Text =dtrdrive222.GetString(5);
					txtemail.Text =dtrdrive222.GetString(6);	
				}
				dtrdrive222.Close();
				con222.Close ();
			}
			catch(Exception ex)
			{
			   CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
	    }

		/// <summary>
		/// this method use to DateTime To MMddyy
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
		/// this method use to Clear controls.
		/// </summary>
		public void clear()
		{
			txtmdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtsdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtmname.Text="";
			txtadd.Text="";
			txtcity.Text="";
			txtstate.Text="";
			txtcountry.Text="";
			txtphone.Text="";
			txtemail.Text="";
			DropAgenda.SelectedIndex =0;
			Dropcomm.SelectedIndex=0;
      		Dropdownlist1.SelectedIndex=0;
			Dropmember .SelectedIndex =0;
		}
		
		/// <summary>
		///	this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			clear();
		}
		

		# region Get Next ptacommunicationID
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
				cmd=new SqlCommand("select max(ptacommunicationid)+1 from ptacommunication",con);
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
				CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + Session["Password"].ToString()   );				
			}
		}
		# endregion

		/// <summary>
		/// this method use to Save infrmation in to ptacommunication table. before the inserting value in to table also check record is exist or not.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DateTime.Compare(ToMMddYYYY(txtmdate.Text),ToMMddYYYY(txtsdate.Text))>0)
				{
					SqlCommand cmdInsert111;
					string strInsert111;
					SqlConnection con111;
					SqlDataReader sdr;
					con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con111.Open ();
					fillID();
					cmdInsert111=new SqlCommand ("select * from ptacommunication where memberid=" + Dropmember.SelectedItem.Value + " and agenda='" + DropAgenda.SelectedItem.Value.ToString () + "' and meetingdate='" + GenUtil.str2MMDDYYYY (txtmdate.Text) + "'",con111);      
					sdr=cmdInsert111.ExecuteReader ();
					if(sdr.HasRows )
					{
						MessageBox.Show ("Record Already Exists");
						clear ();
						return;
					}
					sdr.Close ();
					strInsert111 = "Insert ptacommunication(ptacommunicationid,memberid,meetingdate,agenda,sendername,communicationtype,sendingdate)values (@ptacommunicationid,@memberid,@meetingdate,@agenda,@sendername,@communicationtype,@sendingdate)";
					cmdInsert111=new SqlCommand (strInsert111,con111);
					cmdInsert111.Parameters .Add ("@ptacommunicationid",i.Trim().ToString());
					if(Dropmember.SelectedIndex==0)
						cmdInsert111.Parameters .Add ("@memberid","");
					else
						cmdInsert111.Parameters .Add ("@memberid",Dropmember.SelectedItem.Value.ToString().Trim());
					if(txtmdate.Text=="")
						cmdInsert111.Parameters .Add ("@meetingdate","");
					else
						cmdInsert111.Parameters .Add ("@meetingdate",GenUtil.str2MMDDYYYY (txtmdate.Text));
					if(DropAgenda.SelectedIndex ==0)
						cmdInsert111.Parameters .Add ("@agenda","");
					else
						cmdInsert111.Parameters .Add ("@agenda",DropAgenda.SelectedItem.Value.ToString ());
					if(Dropcomm.SelectedIndex==0)
						cmdInsert111.Parameters .Add ("@communicationtype","0");
					else
						cmdInsert111.Parameters .Add ("@communicationtype",Dropcomm.SelectedItem .Value.ToString ());
					if(txtsdate.Text=="")
						cmdInsert111.Parameters .Add ("@sendingdate","");
					else
						cmdInsert111.Parameters .Add ("@sendingdate",ToMMddYYYY(txtsdate.Text));
					if(Dropdownlist1.SelectedIndex==0)
						cmdInsert111.Parameters .Add ("@sendername","0");
					else
						cmdInsert111.Parameters .Add ("@sendername",Dropdownlist1.SelectedItem .Value.ToString ());
					cmdInsert111.ExecuteNonQuery();
					con111.Close ();
					MessageBox.Show("Communication Details Saved");
					CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click, Userid :  " + pass);				
					clear();
				}
				else
				{
					MessageBox.Show("Meeting date must be greater than sending date"); 
				}

			}
			catch(Exception ex)
			{
			  CreateLogFiles.ErrorLog(" Form : ptacommunication.aspx.cs,Method : btnSave_Click  , Exception : "+ex.Message+",      Userid :  " + pass   );				
			}
		}
	}
}
