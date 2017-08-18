   
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
using eschool.Classes ;
using RMG;
# endregion

namespace eschool.Pta
{
	/// <summary>
	/// Summary description for ptameeting.
	/// </summary>
	public class ptameeting : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtdt;
		protected System.Web.UI.WebControls.TextBox txtdis1;
		protected System.Web.UI.WebControls.TextBox txtagenda;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox txtdis6;
		protected System.Web.UI.WebControls.TextBox txtdis5;
		protected System.Web.UI.WebControls.TextBox txtdis4;
		protected System.Web.UI.WebControls.TextBox txtdis3;
		protected System.Web.UI.WebControls.TextBox txtdis2;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAgenda;
		protected System.Web.UI.WebControls.ValidationSummary vsPtameeting;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button BtnEdit;
		protected System.Web.UI.WebControls.Button BtnDelete;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtdt.Attributes.Add("readonly", "readonly");

            try
			{
				pass=(Session["password"].ToString ());
				CreateLogFiles.ErrorLog (" Form: Ptameeting.aspx.cs, Method: Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				//Response.Redirect("../Form/HolidayEntryForm.aspx",false); 
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(! IsPostBack)
				{
					txtdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					fillID();
					DropDownList1.Visible =false;
					BtnEdit.Visible =false;
					BtnDelete.Visible =false;
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="8";
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
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog (" Form: Ptameeting.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
  
		/// <summary>
		/// this method use to Clear controls.
		/// </summary>
		public void clear()
		{
			txtdt.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			txtagenda.Text="";
			txtdis1.Text="";
			txtdis2.Text="";
			txtdis3.Text="";
			txtdis4.Text="";
			txtdis5.Text="";
			txtdis6.Text="";
		}

		/// <summary>
		/// this Method use to update the record in to ptameetingagenda table.
		/// </summary>
		private void BtnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlCommand cmdInsert111=null;
				SqlConnection con111=null;
				if(DropDownList1.SelectedIndex ==0)
				{
					MessageBox.Show ("Please select agenda");
					return;
				}
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				cmdInsert111 = new SqlCommand ("update ptameetingagenda set meetingdt=@meetingdt,agenda=@agenda,min1=@min1,min2=@min2,min3=@min3,min4=@min4,min5=@min5,min6=@min6 where agenda='" + DropDownList1.SelectedItem.Value .ToString () + "'",con111 );
				cmdInsert111.Parameters .Add ("@meetingdt",GenUtil.str2MMDDYYYY (txtdt.Text.Trim()));
				cmdInsert111.Parameters .Add ("@agenda",DropDownList1.SelectedItem.Value.ToString ());
				if(txtdis1.Text=="")
					cmdInsert111.Parameters .Add ("@min1","");
				else
					cmdInsert111.Parameters .Add ("@min1",txtdis1.Text.Trim().ToUpper());
				if(txtdis2.Text=="")
					cmdInsert111.Parameters .Add ("@min2","");
				else
					cmdInsert111.Parameters .Add ("@min2",txtdis2.Text.Trim().ToUpper());
				if(txtdis3.Text=="")
					cmdInsert111.Parameters .Add ("@min3","");
				else
					cmdInsert111.Parameters .Add ("@min3",txtdis3.Text.Trim().ToUpper());
				if(txtdis4.Text=="")
					cmdInsert111.Parameters .Add ("@min4","");
				else
					cmdInsert111.Parameters .Add ("@min4",txtdis4.Text.Trim().ToUpper());
				if(txtdis5.Text=="")
					cmdInsert111.Parameters .Add ("@min5","");
				else
					cmdInsert111.Parameters .Add ("@min5",txtdis5.Text.Trim().ToUpper());
				if(txtdis6.Text=="")
					cmdInsert111.Parameters .Add ("@min6","");
				else
					cmdInsert111.Parameters .Add ("@min6",txtdis6.Text.Trim().ToUpper());
				cmdInsert111.ExecuteNonQuery();
				con111.Close ();
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: BtnEdit_Click. PTA meeting for agenda: " + txtagenda.Text.Trim().ToUpper() + " saved. User: " + pass );
				MessageBox.Show("Meeting Agenda Updated");
				clear();	
				DropDownList1.Visible =false;
				txtagenda.Visible =true;
				BtnEdit.Visible =false;
				BtnDelete.Visible =false;
				btnSave.Visible =true; 
				Button1.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: BtnEdit_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
	

		# region Get Next MeetingagendaID
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
				cmd=new SqlCommand("select max(meetingagenda)+1 from ptameetingagenda",con);
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
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: BtnEdit_Click. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
		}
		# endregion
		
		/// <summary>
		/// this Method use to save Information in to ptameetingagenda table. before insert the data also check this record also exist or not.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string cdate="";
				cdate=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				if(DateTime.Compare(GenUtil.ToMMddYYYY(txtdt.Text.ToString()),GenUtil.ToMMddYYYY(cdate))>0)
				{
					SqlCommand cmdInsert111;
					string strInsert111;
					SqlConnection con111;
					SqlDataReader sdr; 
					con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con111.Open ();
					fillID();
					cmdInsert111=new SqlCommand ("Select * from ptameetingagenda where meetingdt='" + GenUtil.str2MMDDYYYY (txtdt.Text.Trim()) + "' and agenda='" +  txtagenda.Text.Trim().ToUpper()+ "'",con111);
					sdr=cmdInsert111.ExecuteReader ();
					if(sdr.HasRows )
					{
						MessageBox.Show ("Record already exists");
						clear();
						return;
					}
					sdr.Close ();
					strInsert111 = "Insert ptameetingagenda(meetingagenda,meetingdt,agenda,min1,min2,min3,min4,min5,min6)values (@meetingagenda,@meetingdt,@agenda,@min1,@min2,@min3,@min4,@min5,@min6)";
					cmdInsert111=new SqlCommand (strInsert111,con111);
					cmdInsert111.Parameters .Add ("@meetingdt",GenUtil.str2MMDDYYYY (txtdt.Text.Trim()));
					cmdInsert111.Parameters .Add ("@meetingagenda",i.Trim().ToString());
					if(txtagenda.Text=="")
						cmdInsert111.Parameters .Add ("@agenda","");
					else
						cmdInsert111.Parameters .Add ("@agenda",txtagenda.Text.Trim().ToUpper());
			
					if(txtdis1.Text=="")
						cmdInsert111.Parameters .Add ("@min1","");
					else
						cmdInsert111.Parameters .Add ("@min1",txtdis1.Text.Trim().ToUpper());
			
					if(txtdis2.Text=="")
						cmdInsert111.Parameters .Add ("@min2","");
					else
						cmdInsert111.Parameters .Add ("@min2",txtdis2.Text.Trim().ToUpper());
					if(txtdis3.Text=="")
						cmdInsert111.Parameters .Add ("@min3","");
					else
						cmdInsert111.Parameters .Add ("@min3",txtdis3.Text.Trim().ToUpper());
			
					if(txtdis4.Text=="")
						cmdInsert111.Parameters .Add ("@min4","");
					else
						cmdInsert111.Parameters .Add ("@min4",txtdis4.Text.Trim().ToUpper());
					if(txtdis5.Text=="")
						cmdInsert111.Parameters .Add ("@min5","");
					else
						cmdInsert111.Parameters .Add ("@min5",txtdis5.Text.Trim().ToUpper());
					if(txtdis6.Text=="")
						cmdInsert111.Parameters .Add ("@min6","");
					else
						cmdInsert111.Parameters .Add ("@min6",txtdis6.Text.Trim().ToUpper());
					cmdInsert111.ExecuteNonQuery();
					con111.Close ();
					CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: btnSave_Click. PTA meeting for agenda: " + txtagenda.Text.Trim().ToUpper() + " saved. User: " + pass );
					MessageBox.Show("Meeting Agenda Saved");
					clear();
				}
				else
				{
					MessageBox.Show("Meeting date must be greater than current date");
					return;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: btnSave_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to fetch meeting name and id in dropdown from ptameetingagenda table.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			txtagenda.Visible =false;
			DropDownList1.Visible =true ;
			Button1.Visible=false;
			BtnEdit.Visible=true;
			BtnDelete.Visible =true;
			btnSave.Visible =false;
			SqlCommand cmdInsert111;
			SqlConnection con111;
			SqlDataReader sdr; 
			try
			{
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				cmdInsert111=new SqlCommand ("Select agenda from ptameetingagenda order by meetingdt",con111);
				sdr=cmdInsert111.ExecuteReader ();
				DropDownList1.Items .Clear ();
				DropDownList1.Items .Add ("---Select---"); 
				if(sdr.HasRows )
				{
					while(sdr.Read ())
					{
						DropDownList1.Items.Add (sdr.GetValue (0).ToString ());
					}
				
				}
				sdr.Close ();
				con111.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: Button1_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to fetch all information of selected meetingID from ptameetingagenda.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtagenda.Visible =false;
			DropDownList1.Visible =true ;
			//BtnEdit.Enabled =true;
			//BtnDelete.Enabled =true;
			//btnSave.Enabled =false; 
			SqlCommand cmdInsert111;
			SqlConnection con111;
			SqlDataReader sdr; 
			try
			{
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				cmdInsert111=new SqlCommand ("Select * from ptameetingagenda where agenda='" + DropDownList1.SelectedItem.Value.ToString () + "'",con111);
				sdr=cmdInsert111.ExecuteReader ();
				if(sdr.HasRows )
				{
					if(sdr.Read ())
					{
						txtdt.Text =GenUtil.str2DDMMYYYY( GenUtil.trimDate(sdr.GetValue (1).ToString ()));
						txtdis1.Text =sdr.GetValue (3).ToString ();
						txtdis2.Text =sdr.GetValue (4).ToString ();
						txtdis3.Text =sdr.GetValue (5).ToString ();
						txtdis4.Text =sdr.GetValue (6).ToString ();
						txtdis5.Text =sdr.GetValue (7).ToString ();
						txtdis6.Text =sdr.GetValue (8).ToString ();
					}
				}
				sdr.Close ();
				con111.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: DropDownList1_SelectedIndexChanged. Exception: " + ex.Message + " User: " + pass );
			}
		}

		/// <summary>
		/// this method use to Delete record from ptameetingagenda table of a particular meeting id.
		/// </summary>
		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				SqlCommand cmdInsert111=null;
				SqlConnection con111=null;
				if(DropDownList1.SelectedIndex ==0)
				{
					MessageBox.Show ("Please select agenda");
					return;
				}
				con111=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con111.Open ();
				cmdInsert111 = new SqlCommand ("delete ptameetingagenda where agenda='" + DropDownList1.SelectedItem.Value .ToString () + "'",con111 );
				cmdInsert111.ExecuteNonQuery();
				con111.Close ();
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: BtnDelete_Click. PTA meeting for agenda: " + txtagenda.Text.Trim().ToUpper() + " deleted. User: " + pass );
				MessageBox.Show("Meeting Agenda Deleted");
				clear();
				DropDownList1.Visible =false;
				txtagenda.Visible =true;
				BtnEdit.Visible =false;
				BtnDelete.Visible =false;
				btnSave.Visible =true; 
				Button1.Visible=true;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Ptameeting.aspx.cs, Method: BtnDelete_Click. Exception: " + ex.Message + " User: " + pass );
			}
		}
	}
}
