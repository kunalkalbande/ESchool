
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
using eschool.Classes ;
using RMG;
# endregion

namespace eschool.Logistics
{
	/// <summary>
	/// Summary description for Routeedit.
	/// </summary>
	public class Routeedit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtrname;
		protected System.Web.UI.WebControls.TextBox txtrkm;
		protected System.Web.UI.WebControls.TextBox txttrfee;
		protected System.Web.UI.WebControls.Button btnsave;
    	protected System.Web.UI.WebControls.Button btndelete;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqvali1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ValidationSummary vsRoute;
		protected System.Web.UI.HtmlControls.HtmlInputHidden temproutdata;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempval;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempold;
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
				CreateLogFiles.ErrorLog(" Form : Ledger_Creation.aspx,Method : Page_Load  User: "+ pass);     
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Ledger_Creation,Method : Page_Load  Exception: "+ex.Message+"  User: "+ pass);     
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				//uid=(Session["password"].ToString());
			
				if(!Page.IsPostBack)
				{
					checkPrevileges();
					
					# region Dropdown Route Name
					Button1.Visible=true;
					fillID();
					btnDel.Visible=true;
					btnsave.Visible=false;
					btnEdit.Visible=false;
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrdrive;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					//13.11.08 cmdselect = new SqlCommand("Select route_id,Route_name  From Route", con );
					cmdselect = new SqlCommand("Select route_id,Route_name  From Route order by route_name", con );
					dtrdrive = cmdselect.ExecuteReader();
					DropDownList1.Items.Add("-----------Select-----------");
					while (dtrdrive.Read()) 
					{
						DropDownList1.Items.Add(dtrdrive.GetValue(1)+":"+dtrdrive.GetValue(0).ToString());
						
					}   
					dtrdrive.Close();
					#endregion

					#region fill hidden text
					cmdselect = new SqlCommand("Select * From Route order by route_id", con );
					dtrdrive = cmdselect.ExecuteReader();
					while (dtrdrive.Read()) 
					{
						//temproutdata.Value+=dtrdrive.GetValue(0)+";"+dtrdrive.GetValue(1).ToString()+";"+dtrdrive.GetValue(2).ToString()+";"+dtrdrive.GetValue(3).ToString()+";"+dtrdrive.GetValue(4).ToString()+";"+dtrdrive.GetValue(5).ToString()+",";
						temproutdata.Value+=dtrdrive.GetValue(0)+";"+dtrdrive.GetValue(1).ToString()+";"+dtrdrive.GetValue(2).ToString()+";"+dtrdrive.GetValue(3).ToString()+";"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive.GetValue(4).ToString()))+";"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive.GetValue(5).ToString()))+",";
					}   
					dtrdrive.Close();


					con.Close ();
					# endregion
				}
				if(!Page.IsPostBack)
				{
					Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
				}
				CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : Page_Load  userid "+pass );
			}
			catch(Exception ex)
			{
				 CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : Page_Load "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
               	 Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
                 return;
			}
		}

		/// <summary>
		/// this method use to Check Privileges of user.
		/// </summary>
		public void checkPrevileges()
		{
			try
			{	
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
				string SubModule="8";
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
				if(Add_Flag=="False" && Edit_Flag=="False" && Del_Flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(Add_Flag=="False")
					Button1.Enabled=false;
				if(Edit_Flag=="False")
				{				
					btnEdit.Enabled=false;
					btnsave.Enabled = false;  
				}
				if(Del_Flag=="False")
				{				
					btnDel.Enabled=false;
				}
				#endregion
			}
			catch(Exception ex)
			{
                  CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
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
			this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		///  this method not in use.
		/// </summary>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				string Routeid=DropDownList1.SelectedItem.Text.ToString();
				string[] route1=Routeid.Split(new char[]{':'});

			
				if(DropDownList1.SelectedItem.Text=="-----------Select-----------")
				{
					MessageBox.Show("Please select the Route name to Update");
				}
				else
				{
					SqlConnection con44;
					SqlCommand cmdselect44;
					SqlDataReader dtrdrive44;
					con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con44.Open ();
					//cmdselect44 = new SqlCommand( "Select Route_name,Route_km,trfee,fromdate,todate  From Route where Route_name=@Route_name", con44 );
					cmdselect44 = new SqlCommand( "Select Route_name,Route_km,trfee,fromdate,todate  From Route where Route_id=@Route_name", con44 );
					//cmdselect44.Parameters .Add ("@Route_name",DropDownList1.SelectedItem .Text.ToString());
					cmdselect44.Parameters .Add ("@Route_name",route1[0]);
					dtrdrive44 = cmdselect44.ExecuteReader();
					while (dtrdrive44.Read()) 
					{
						txtrname.Text=dtrdrive44.GetString(0);
						txtrkm.Text =dtrdrive44.GetString(1);
						txttrfee.Text=dtrdrive44.GetString(2);
						Txtfromdate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive44.GetValue(3).ToString()));
						Txttodate.Text=GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive44.GetValue(4).ToString()));
					}
					dtrdrive44.Close();
					con44.Close ();
					btnsave.Visible=true;
					Button1.Visible=false;
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:DropDownList1_SelectedIndexChanged "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}

		/// <summary>
		/// this method use to update the route informationin Route table.
		/// </summary>
		private void btnsave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string Routeid=DropDownList1.SelectedItem.Text.ToString();
				string[] route1=Routeid.Split(new char[]{':'});

				if(txtrname.Text=="")
				{
					MessageBox.Show("Please enter the Route Name");
				}
				else if(txtrkm.Text=="")
				{
					MessageBox.Show("Please enter Route No");				
				}
				else if(txttrfee.Text =="")
				{
					MessageBox.Show("Please enter the Transport Fee");
				}
				else
				{
					Button1.Visible=true;
					btnDel.Visible=true;
					btnsave.Visible=false;
					btnEdit.Visible=false;
					SqlConnection con2;
					SqlCommand cmdselect2;
					SqlDataReader dtredit2;
					string strUpdate;
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					//strUpdate = "Update Route set Route_name=@Route_name,Route_km=@Route_km ,trfee=@TRFee,fromdate=@fromdate,todate=@todate where Route_id=@Route2 and fromdate='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString().Trim())+"'";
					strUpdate = "Update Route set Route_name=@Route_name,Route_km=@Route_km ,trfee=@TRFee,fromdate=@fromdate,todate=@todate where Route_id=@Route2" ;
					cmdselect2 = new SqlCommand( strUpdate, con2);
					if(txtrname.Text=="")
						cmdselect2.Parameters .Add ("@Route_name","");
					else
						cmdselect2.Parameters .Add ("@Route_name",txtrname.Text.Trim());
					if(txtrkm.Text  =="")
						cmdselect2.Parameters .Add ("@Route_km","");
					else
						cmdselect2.Parameters .Add ("@Route_km",txtrkm.Text.Trim());
					
					if(txttrfee.Text =="")
						cmdselect2.Parameters .Add("@TRFee","");
					else
						cmdselect2.Parameters .Add("@TRFee",txttrfee.Text .Trim ());
					if(DropDownList1.SelectedIndex==0)
						cmdselect2.Parameters .Add ("@Route2","");
					else
						//cmdselect2.Parameters .Add ("@Route2",DropDownList1.SelectedItem.Text.ToString());
						cmdselect2.Parameters .Add ("@Route2",route1[0]);

					if(Txtfromdate.Text=="")
					{
						MessageBox.Show("Please Enter The Start date");
						return;
					}
					else
						cmdselect2.Parameters .Add ("@fromdate",GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString()));
					if(Txttodate.Text=="")
					{
						MessageBox.Show("Please Enter The End Date");
						return;
					}
					else
						cmdselect2.Parameters .Add ("@todate",GenUtil.str2MMDDYYYY(Txttodate.Text.Trim().ToString()));
					dtredit2 = cmdselect2.ExecuteReader();
					MessageBox.Show("Route Successfully Updated");
					CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnUpdate_Click "+ " Route Name  "+txtrname.Text.Trim().ToString ()+" updated. userid "+ pass );
					Clear();
					fill();
					checkPrevileges();
				}
    		}
			catch(Exception ex)
			{
					CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnUpdate_Click "+ " EXCEPTION "+ex.Message +"  userid  "+ pass );
			}
		}

		/// <summary>
		///  this method use to Generete Next Id of Route table.
		///  not in use.
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
				cmd=new SqlCommand("select max(Route_id)+1 from Route",con);
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
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}

		/// <summary>
		/// this method use to get date as string and return in MMDDYYYY formate.
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
		/// this method use to save and update information of Route in Route table.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(DateTime.Compare(ToMMddYYYY(Txtfromdate.Text),ToMMddYYYY(Txttodate.Text))>0)
			{
				MessageBox.Show("Fromdate must be greater than or equal to Todate");
				return;
			}
			else
			{
				string sRName=txtrname.Text.ToString().Trim();
				SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon.Open();
				SqlCommand scom;
			
				if(DropDownList1.SelectedIndex==0)
				{
					try
					{
						if(txtrname.Text=="")
						{
							MessageBox.Show("Please Enter the Route Name");
						}
						else if(txtrkm.Text=="")
						{
							MessageBox.Show("Please Enter Route No");
						}
						else if(txttrfee.Text =="")
						{
							MessageBox.Show("Please Enter Transport Fee");
						}
						else
						{
							//string sRName=txtrname.Text.ToString().Trim();
							//string sRNo=txtrkm.Text.ToString().Trim();
							//SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							//scon.Open();
							fillID();
							scom=new SqlCommand("Select Count(Route_name) from Route where Route_name='" + sRName +"'",scon);
							//SqlCommand scom=new SqlCommand("Select Count(Route_name) from Route where Route_name='" + sRName +"' and route_km='"+sRNo+"'",scon);
							SqlDataReader sdtr=scom.ExecuteReader(); 
							int iCount=0;
							while(sdtr.Read())
							{
								iCount=Convert.ToInt32(sdtr.GetSqlValue(0).ToString());
							}
							sdtr.Close();
							scom.Dispose();
							if(iCount>0)
							{
								MessageBox.Show("Route Name Can Not be Duplicate");
							}
							else
							{
								//SqlConnection con4;
								string strInsert4;
								//SqlCommand cmdInsert4;
								//con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
								//con4.Open ();
								strInsert4 = "Insert Route(Route_id,Route_name,Route_km,trfee,fromdate,todate)values (@Route_id,@Route_name,@Route_km,@TRFee,@fromdate,@todate)";
								//cmdInsert4=new SqlCommand (strInsert4,con4);
								scom=new SqlCommand(strInsert4,scon);
								scom.Parameters .Add ("@Route_id",i.Trim().ToString () );
								scom.Parameters .Add ("@Route_name",txtrname.Text.Trim().ToString () );
								scom.Parameters .Add ("@Route_km",txtrkm.Text.Trim().ToString () );
								scom.Parameters .Add ("@TRFee",txttrfee.Text.Trim().ToString());
				
								if(Txtfromdate.Text=="")
								{
									MessageBox.Show("Please Enter The Start date");
									return;
								}
								else
									scom.Parameters .Add ("@fromdate",GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString()));

								if(Txttodate.Text=="")
								{
									MessageBox.Show("Please Enter The End Date");
									return;
								}
								else
									scom.Parameters .Add ("@todate",GenUtil.str2MMDDYYYY(Txttodate.Text.Trim().ToString()));

								scom.ExecuteNonQuery();
								scom.Dispose();
								scon.Close();
								MessageBox.Show("Route Successfully Saved");
								CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnAdd_Click "+ " New Route Name  "+txtrname.Text.Trim().ToString ()+" saved   userid "+ pass );
								Clear();
								fill();
								checkPrevileges();
							}
						}
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnAdd_Click "+ " EXCEPTION  "+ex.Message+"     userid  "+ pass );
					}
				}
				else
				{
					try
					{
						if(tempold.Value!=txtrname.Text)
						{
							scom=new SqlCommand("Select distinct Route_name from Route order by Route_name",scon);
							SqlDataReader sdtr=scom.ExecuteReader(); 
							while(sdtr.Read())
							{
								if(txtrname.Text==sdtr.GetValue(0).ToString())
								{
									MessageBox.Show("Route name can not be Duplicate");
									return;
								}
							}
							sdtr.Close();
						}

						string Routeid=DropDownList1.SelectedItem.Text.ToString();
						string[] route1=Routeid.Split(new char[]{':'});

						if(txtrname.Text=="")
						{
							MessageBox.Show("Please enter the Route Name");
						}
						else if(txtrkm.Text=="")
						{
					
							MessageBox.Show("Please enter Route No");				
						}
						else if(txttrfee.Text =="")
						{
							MessageBox.Show("Please enter the Transport Fee");
						}
						else
						{
							
							string strUpdate;
							//strUpdate = "Update Route set Route_name=@Route_name,Route_km=@Route_km ,trfee=@TRFee,fromdate=@fromdate,todate=@todate where Route_id=@Route2 and fromdate='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString().Trim())+"'";
							strUpdate = "Update Route set Route_name=@Route_name,Route_km=@Route_km ,trfee=@TRFee,fromdate=@fromdate,todate=@todate where Route_id=@Route2" ;
							//cmdselect2 = new SqlCommand( strUpdate, con2);
							scom=new SqlCommand(strUpdate,scon);
							if(txtrname.Text=="")
								scom.Parameters .Add ("@Route_name","");
							else
								scom.Parameters .Add ("@Route_name",txtrname.Text.Trim());
							if(txtrkm.Text  =="")
								scom.Parameters .Add ("@Route_km","");
							else
								scom.Parameters .Add ("@Route_km",txtrkm.Text.Trim());
					
							if(txttrfee.Text =="")
								scom.Parameters .Add("@TRFee","");
							else
								scom.Parameters .Add("@TRFee",txttrfee.Text .Trim ());
					
							if(DropDownList1.SelectedIndex==0)
								scom.Parameters .Add ("@Route2","");
							else
								//cmdselect2.Parameters .Add ("@Route2",DropDownList1.SelectedItem.Text.ToString());
								scom.Parameters .Add ("@Route2",route1[1]);

							if(Txtfromdate.Text=="")
							{
								MessageBox.Show("Please Enter The Start date");
								return;
							}
							else
								scom.Parameters .Add ("@fromdate",GenUtil.str2MMDDYYYY(Txtfromdate.Text.Trim().ToString()));

							if(Txttodate.Text=="")
							{
								MessageBox.Show("Please Enter The End Date");
								return;
							}
							else
								scom.Parameters .Add ("@todate",GenUtil.str2MMDDYYYY(Txttodate.Text.Trim().ToString()));
							//dtredit2 = scom.ExecuteReader();
							scom.ExecuteNonQuery();
							scom.Dispose();
							scon.Close();
							MessageBox.Show("Route Successfully Updated");
							CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnUpdate_Click "+ " Route Name  "+txtrname.Text.Trim().ToString ()+" updated. userid "+ pass );
							Clear();
							fill();
							checkPrevileges();
						}
					}
					catch(Exception ex)
					{
						CreateLogFiles.ErrorLog(" Form : Routeedit.aspx,Method : btnUpdate_Click "+ " EXCEPTION "+ex.Message +"  userid  "+ pass );
					}
				}
			}
						
		}
			
		/// <summary>
		///  This method use to Clear controls.
		/// </summary>
		public void Clear()
		{
			txtrname.Text="";
			txttrfee.Text="";
			txtrkm .Text="";
			DropDownList1.SelectedIndex=0;
			Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
		}

		/// <summary>
		/// this method use to fill dropdown from Route table. and also save information in to hidden textbox. 
		/// </summary>
		public void fill()
		{
			try
			{
				SqlConnection con;
				SqlCommand SqlCmd;
				SqlDataReader dtrdrive;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				DropDownList1.Items.Clear();
				//SqlCmd = new SqlCommand( "Select route_name  From route", con );
				//13.11.08 SqlCmd = new SqlCommand( "Select route_id,Route_name  From Route", con );
				SqlCmd = new SqlCommand("Select route_id,Route_name  From Route order by route_name", con );
				dtrdrive = SqlCmd.ExecuteReader();
				DropDownList1.Items.Add("-----------Select-----------");
				while (dtrdrive.Read()) 
				{
					//DropDownList1.Items.Add(dtrdrive.GetString(0));
					DropDownList1.Items.Add(dtrdrive.GetValue(1)+":"+dtrdrive.GetValue(0).ToString());
				}
				dtrdrive.Close();
				temproutdata.Value="";
				SqlCmd = new SqlCommand("Select * From Route order by route_id", con );
				dtrdrive = SqlCmd.ExecuteReader();
				while(dtrdrive.Read()) 
				{
					//temproutdata.Value+=dtrdrive.GetValue(0)+";"+dtrdrive.GetValue(1).ToString()+";"+dtrdrive.GetValue(2).ToString()+";"+dtrdrive.GetValue(3).ToString()+";"+dtrdrive.GetValue(4).ToString()+";"+dtrdrive.GetValue(5).ToString()+",";
					temproutdata.Value+=dtrdrive.GetValue(0)+";"+dtrdrive.GetValue(1).ToString()+";"+dtrdrive.GetValue(2).ToString()+";"+dtrdrive.GetValue(3).ToString()+";"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive.GetValue(4).ToString()))+";"+GenUtil.str2DDMMYYYY(GenUtil.trimDate(dtrdrive.GetValue(5).ToString()))+",";
				}   
				dtrdrive.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
               CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:fill().  EXCEPTION : "+ex.Message+"     userid  "+ pass );
			}
		}

		/// <summary>
		/// this method use to Reset page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// this method not in use.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				Button1.Enabled=false;
				btnDel.Enabled=false;
				btnsave.Visible=true;
				btnEdit.Visible=false;
				DropDownList1.Enabled=true;
				if(DropDownList1.SelectedItem.Text=="-----------Select-----------")
				{
					MessageBox.Show("Please select the Route Name to Update");
				}
				else
				{
					
				}
				checkPrevileges();
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:btnEdit_Click     userid  "+ pass );	
			}
			catch(Exception ex )
			{
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:btnEdit_Click"+ " EXCEPTION  "+ex.Message+"     userid  "+ pass );
			}
		}

		/// <summary>
		/// this method use to Delete record from Route table.
		/// </summary>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				string Routeid=DropDownList1.SelectedItem.Value;
				Routeid=Routeid.Substring(Routeid.IndexOf(':')+1);
				if(DropDownList1.SelectedItem.Text=="-----------Select-----------")
				{
					MessageBox.Show("Please select the Route name to Delete");
				}
				else
				{
              		SqlConnection con10;
					SqlCommand cmdselect10;
					SqlDataReader dtredit10;
					string strdelete10;
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open ();
					//14.11.08 strdelete10 = "Delete Route where Route_name =@Route_name";
					strdelete10 = "Delete Route where Route_id =@Route_name";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					//cmdselect10.Parameters .Add ("@Route_name",txtrname.Text .ToString ());
					cmdselect10.Parameters .Add ("@Route_name",Routeid .ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					MessageBox.Show("Route Successfully Deleted");
					CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:btn_Delete "+ " Route Name  "+txtrname.Text.Trim().ToString ()+" deleted   userid "+ pass );
					Clear();
					fill();
					Button1.Visible=true;
					btnDel.Visible=true;
					btnsave.Visible=false;
					btnEdit.Visible=false;
					checkPrevileges();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:btn_Delete "+ " EXCEPTION  "+ex.Message +"  userid  "+ pass );
			}
		}
			
	}
}
