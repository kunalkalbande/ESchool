/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
  
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.

*/
# region Directry
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

#endregion
namespace eschool.Module.Form
{
	/// <summary>
	/// Summary description for Category.
	/// </summary>
	public class Category : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnsave;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.DropDownList dropcatid;
		protected System.Web.UI.WebControls.TextBox txtcategory;
		protected System.Web.UI.WebControls.TextBox txtRank;
		protected System.Web.UI.WebControls.ValidationSummary vsRoute;
		protected System.Web.UI.WebControls.Button btnadd;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiValidation1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequValidation2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempCatRank;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempCat;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempRank;
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
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: Category.aspx, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					checkPrevileges();
					# region Dropdown category ID
					fillID();
					fill();
					btnDel.Enabled=true;
					btnsave.Visible=false;
					btnEdit.Visible=true;
					# endregion
				}
				btnadd.Visible=true;
				btnDel .Visible=true;
				btnEdit.Visible=false;
				btnsave .Visible=false;
				CreateLogFiles.ErrorLog(" Form : Category.aspx,Method : Page_Load,  userid "+ pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Category.aspx,Method : Page_Load "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
				
				return;
			}
		}
		
		/// <summary>
		/// This method use to Check the privileges.
		/// </summary>
		public void checkPrevileges()
		{
			try
			{	
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="2";
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
				
				if(Add_Flag=="False" && Edit_Flag=="False" && Del_Flag=="False")
				{
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				
				if(Edit_Flag=="0")
				{				
					
					btnsave.Enabled = false;  
				}
				if(Del_Flag=="0")
				{				
					btnDel.Enabled=false;
				}
				#endregion
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Category.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}
		

		#region Web Form Designer generated code
		/// <summary>
		/// Web Form Designer generated code.
		/// </summary>
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
			this.dropcatid.SelectedIndexChanged += new System.EventHandler(this.dropcatid_SelectedIndexChanged);
			this.btnadd.Click += new System.EventHandler(this.Button1_Click);
			this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// This Method use to fetch the Category and rank from catagory table selectd catgory id.
		/// </summary>
		private void Dropcatid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dropcatid.SelectedItem.Text=="-----------Select-----------")
				{
					MessageBox.Show("Please select the category id to Update");
				}
				else
				{
					SqlConnection con44;
					SqlCommand cmdselect44;
					SqlDataReader dtrdrive44;
					con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con44.Open ();
					cmdselect44 = new SqlCommand( "Select catname  From category where catname=@ catname", con44 );
					cmdselect44.Parameters .Add ("@ catname",dropcatid.SelectedItem .Text.ToString());
					dtrdrive44 = cmdselect44.ExecuteReader();
					while (dtrdrive44.Read()) 
					{
						txtcategory.Text=dtrdrive44.GetString(0);
						txtRank.Text =dtrdrive44.GetString(1);
					}
					dtrdrive44.Close();
					con44.Close ();
				}
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog("Form:Category.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass.ToString() );
			}
		}
		
		/// <summary>
		/// This Method use to update the record update the category.
		/// </summary>
		private void btnsave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtcategory.Text=="")
				{
					MessageBox.Show("Please enter the Category Name");
				}
				else if(txtRank.Text=="")
				{
					MessageBox.Show("Please enter Rank");				
				}
				else
				{
					//btnadd.Enabled =true;
					//btnDel.Enabled=true;
					//btnsave.Visible=false;
					//btnEdit.Visible=true;

					btnadd.Visible =true;
					btnDel.Visible=true;
					btnsave.Visible=false;
					btnEdit.Visible=false;

					SqlConnection con2;
					SqlCommand cmdselect2;
					
					string strUpdate;
					string cat=dropcatid.SelectedItem.Text;
					string[] catid=cat.Split(new char[] {':'},cat.Length);
					con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con2.Open ();
					strUpdate = "Update category set catname=@Catname,rank=@Rank  where catid=@catid";
					cmdselect2 = new SqlCommand( strUpdate, con2);
					if(txtcategory.Text=="")
						cmdselect2.Parameters .Add ("@Catname","");
					else
						cmdselect2.Parameters .Add ("@Catname",txtcategory.Text);
					cmdselect2.Parameters .Add ("@catid",catid[0]);
					//****************gyanandra**********20.04.07***********	
						
					if(txtRank.Text  =="")
						cmdselect2.Parameters .Add ("@Rank","");
					else
						cmdselect2.Parameters .Add ("@Rank",txtRank.Text.Trim());
				
					cmdselect2.ExecuteNonQuery();
					
					MessageBox.Show("Categery Successfully Updated");
					//MessageBox.Show("Record successfully Updated");
					CreateLogFiles.ErrorLog(" Form : category.aspx, Method : btnUpdate_Click "+ " Route Name  "+txtcategory.Text.Trim().ToString ()+" updated. userid "+ pass.ToString() );
					Clear();
					fill();
					checkPrevileges();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Routeedit.aspx, Method : btnUpdate_Click "+ " EXCEPTION "+ex.Message +"  userid  "+ pass.ToString() );
			}
		}

		/// <summary>
		/// This method use to Generated Next Catagory Id.
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
				cmd=new SqlCommand("select max(catid)+1 from category",con);
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
				CreateLogFiles.ErrorLog("Form:Category.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}
			

		/// <summary>
		/// This Method usew to Save information of category.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(dropcatid.SelectedIndex==0)
			{
				try
				{
					if(txtcategory.Text=="")
					{
						MessageBox.Show("Please enter the category Name");
						
					}
					else
					{
						string sCName=txtcategory.Text.ToString().Trim();
						string sRName=txtRank.Text.ToString().Trim();
						SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						scon.Open();
						fillID();
						//11.11.08 SqlCommand scom=new SqlCommand("Select catname from category where catname='" + sCName +"'",scon);
						SqlCommand scom=new SqlCommand("Select Count(*) from category where catname='" + sCName +"' and rank='"+sRName+"'",scon);
						SqlDataReader sdtr=scom.ExecuteReader(); 
						int iCount=0;
						if(sdtr.Read())
						{
							iCount=Convert.ToInt32(sdtr.GetValue(0));
						}
						sdtr.Close();
						if(iCount==0)
						{
							SqlConnection con4;
							string strInsert4;
							SqlCommand cmdInsert4;
							con4=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
							con4.Open ();
							fillID();
							strInsert4 = "Insert category(catid,catname,rank)values (@Catid,@Catname,@Rank)";
							cmdInsert4=new SqlCommand (strInsert4,con4);
							cmdInsert4.Parameters .Add ("@Catid",i);
							cmdInsert4.Parameters .Add ("@Catname",txtcategory.Text.Trim().ToString () );
							cmdInsert4.Parameters .Add ("@Rank",txtRank.Text.Trim().ToString () );
							cmdInsert4.ExecuteNonQuery();
							con4.Close ();
							MessageBox.Show("Category Successfully Saved");
							//MessageBox.Show("Record successfully Saved");
							//CreateLogFiles.ErrorLog(" Form : category.aspx, Method : Button1_Click "+ " New category Name  "+txtcategory.Text.Trim().ToString ()+" saved   userid "+ uid );
							
							//checkPrevileges();
						}
						else
						{
							MessageBox.Show("This Category Already Exists");
						}
						Clear();
						fill();
					}
					CreateLogFiles.ErrorLog(" Form : Category.aspx, Method : btnAdd_Click  userid "+ pass.ToString() );
				}
				catch(Exception ex)
				{
				
					CreateLogFiles.ErrorLog(" Form : Category.aspx, Method : btnAdd_Click "+ " EXCEPTION  "+ex.Message+"   userid "+ pass.ToString() );
				}
			}
			else
			{
				try
				{
					//10.11.08 if(txtcategory.Text=="")
					if(tempCat.Value=="")
					{
						MessageBox.Show("Please enter the Category Name");
					}
						//10.11.08 else if(txtRank.Text=="")
					else if(tempRank.Value=="")
					{
					
						MessageBox.Show("Please enter Rank");				
					}
				
					else
					{
					
						//btnadd.Enabled =true;
						//btnDel.Enabled=true;
						//btnsave.Visible=false;
						//btnEdit.Visible=true;

						btnadd.Visible =true;
						btnDel.Visible=true;
						btnsave.Visible=false;
						btnEdit.Visible=false;

						SqlConnection con2;
						SqlCommand cmdselect2;
					
						string strUpdate;
						string cat=dropcatid.SelectedItem.Text;
						string[] catid=cat.Split(new char[] {':'},cat.Length);
						con2=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
						con2.Open ();
						strUpdate = "Update category set catname=@Catname,rank=@Rank  where catid=@catid";
						cmdselect2 = new SqlCommand( strUpdate, con2);
						//10.11.08 if(txtcategory.Text=="")
						if(tempCat.Value=="")
							cmdselect2.Parameters .Add ("@Catname","");
						else
							//10.11.08 cmdselect2.Parameters .Add ("@Catname",txtcategory.Text);
							cmdselect2.Parameters .Add ("@Catname",tempCat.Value);
						cmdselect2.Parameters .Add ("@catid",catid[0]);
						//****************gyanandra**********20.04.07***********	
						
						//10.11.08 if(txtRank.Text  =="")
						if(tempRank.Value=="")
							cmdselect2.Parameters .Add ("@Rank","");
						else
							//10.11.08 cmdselect2.Parameters .Add ("@Rank",txtRank.Text.Trim());
							cmdselect2.Parameters .Add ("@Rank",tempRank.Value.Trim());
				
						cmdselect2.ExecuteNonQuery();
					
						MessageBox.Show("Categery Successfully Updated");
						//MessageBox.Show("Record successfully Updated");
						CreateLogFiles.ErrorLog(" Form : category.aspx, Method : btnUpdate_Click "+ " Route Name  "+txtcategory.Text.Trim().ToString ()+" updated. userid "+ pass.ToString() );
						Clear();
						fill();
						//checkPrevileges();
					}
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : Routeedit.aspx, Method : btnUpdate_Click "+ " EXCEPTION "+ex.Message +"  userid  "+ pass.ToString() );
				}
			}
		}
	
		/// <summary>
		/// This method use to Clear Function.
		/// </summary>
		public void Clear()
		{
			txtcategory.Text="";
			txtRank .Text="";
			dropcatid.SelectedIndex=0;
		}
	
		/// <summary>
		/// This method use to Fill dropcatid dropdown fetch data from catagory table. and also save in hidden textbox.
		/// </summary>
		public void fill()
		{
			try
			{
				SqlConnection con;
				SqlCommand cmdselect;
				SqlDataReader sdtr;
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				//10.11.08 cmdselect = new SqlCommand("Select catid,catname  From category order by catid", con );
				cmdselect = new SqlCommand("Select catid,catname,rank  From category order by catid", con );
				sdtr = cmdselect.ExecuteReader();
				dropcatid.Items.Clear();
				dropcatid.Items.Add("---------Select---------");
				while (sdtr.Read()) 
				{
					dropcatid.Items.Add(sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString());
					tempCatRank.Value+=sdtr.GetValue(0).ToString()+":"+sdtr.GetValue(1).ToString()+":"+sdtr.GetValue(2).ToString()+",";
				}
				sdtr.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:Category.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass.ToString() );
			}
		}

		/// <summary>
		/// This method use to Reset the form.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// This Method show the selected index value in textbox.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dropcatid.SelectedItem.Text=="---------Select---------")
				{
					MessageBox.Show("Please select the catid to Update");
				}
				
				btnDel.Enabled=false;
				btnsave.Visible=true;
				btnEdit.Visible=false;
				dropcatid.Enabled=true;
				checkPrevileges();
				CreateLogFiles.ErrorLog("Form:Routeedit.aspx,Method:btnEdit_Click     userid  "+ pass.ToString() );	
			}
			catch(Exception ex )
			{
				
				CreateLogFiles.ErrorLog("Form:Category.aspx,Method:pageload "+ " EXCEPTION  "+ex.Message+"   userid "+ pass.ToString() );
			}
		}

		/// <summary>
		/// This Method use to Delete Selected Record.
		/// </summary>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dropcatid .SelectedItem.Text=="---------Select---------")
				{
					MessageBox.Show("Please select the Category name to Delete");
				}
				else
				{
					string Catid=dropcatid.SelectedItem.Text.ToString();
					Catid=Catid.Substring(0,Catid.IndexOf(":"));
					SqlConnection con10;
					SqlCommand cmdselect10;
					SqlDataReader dtredit10;
					string strdelete10;
					con10=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con10.Open();
					//11.11.08 strdelete10 = "Delete category where catname =@Catname";
					strdelete10 = "Delete category where catid =@Catname";
					cmdselect10 = new SqlCommand( strdelete10, con10);
					//11.11.08 cmdselect10.Parameters .Add ("@Catname",txtcategory.Text .ToString ());
					cmdselect10.Parameters .Add ("@Catname",Catid.ToString ());
					dtredit10 = cmdselect10.ExecuteReader();
					MessageBox.Show("Category Successfully Deleted");
					//MessageBox.Show("Record successfully Deleted");
					CreateLogFiles.ErrorLog(" Form : Category.aspx, Method : btnDelete_Click "+ " category  "+txtcategory.Text.Trim().ToString ()+" deleted   userid "+ pass.ToString() );
					Clear();
					fill();
					//btnadd.Enabled =true;
					//btnDel.Enabled=true;
					//btnsave.Enabled=false;
					//btnEdit.Enabled=true;
					btnadd.Visible =true;
					btnDel.Visible=true;
					btnsave.Visible=false;
					btnEdit.Visible=false;
					checkPrevileges();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : Category.aspx, Method : btnDelete_Click "+ " EXCEPTION  "+ex.Message +"  userid  "+ pass.ToString() );
			}
		}

		/// <summary>
		/// This Method use to Update the category.
		/// </summary>
		private void dropcatid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dropcatid.SelectedItem.Text=="---------Select---------")
				{
					MessageBox.Show("Please select the Category to Update");
					txtcategory.Text="";
					txtRank.Text="";
				}
				else
				{
					SqlConnection con44;
					SqlCommand cmdselect44;
					SqlDataReader dtrdrive44;
					string cat=dropcatid.SelectedItem.Text;
					string[] catid=cat.Split(new char[] {':'},cat.Length);
					con44=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con44.Open ();
					cmdselect44 = new SqlCommand( "Select catname,rank  From category where catid=@Catid", con44 );
					cmdselect44.Parameters .Add ("@Catid",catid[0].ToString());
					dtrdrive44 = cmdselect44.ExecuteReader();
					while (dtrdrive44.Read()) 
					{
						txtcategory.Text=dtrdrive44.GetString(0);
						txtRank.Text =dtrdrive44.GetString(1);
					}
					dtrdrive44.Close();
					con44.Close ();
					//btnEdit.Enabled=true;
					//btnDel.Enabled=true;
					//btnsave.Enabled=true;
					//btnadd.Enabled=false;
					btnadd.Visible=false;
					btnsave.Visible=true;
					btnEdit.Visible=false;
					btnDel.Visible=true;
				}
				CreateLogFiles.ErrorLog(" Form : category.aspx, Method : dropEdit_SelectedIndexChanged   userid "+ pass );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : category.aspx, Method : dropEdit_SelectedIndexChanged "+ " EXCEPTION  "+ex.Message+"   userid "+ pass );
			}
		}

		/// <summary>
		/// This method use to Fill Catagory Id in dropcatid fromcategory table.
		/// </summary>
		public void Fillcatname()
		{
			SqlConnection con;
			SqlCommand cmdselect;
			SqlDataReader sdtr;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				cmdselect = new SqlCommand( "Select distinct catname,catid  From category order by catname asc", con );
				sdtr = cmdselect.ExecuteReader();
				dropcatid .Items.Clear ();  
				dropcatid.Items .Add ("---------Select---------"); 
				while (sdtr.Read()) 
				{
					dropcatid.Items.Add(sdtr.GetString(0));
				}

				sdtr.Close();
				con.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: category.aspx.cs, Method: FillSubject. Exception: " + ex.Message + " User: " + pass );
			}
		}
	
	}


}