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
# endregion

namespace eschool
{
	/// <summary>
	/// Summary description for Classwisesujects.
	/// </summary>
	public class Classwisesubjects : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.CompareValidator cvShiftName;
		protected System.Web.UI.WebControls.Button btnIn;
		protected System.Web.UI.WebControls.Button btnout;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.ValidationSummary vsShiftAssignment;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.ListBox ListSubjectAvailable;
		protected System.Web.UI.WebControls.ListBox ListSubjestAssigned;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.Button btnedit;
		protected System.Web.UI.WebControls.DropDownList dropClassWiseSubject;
		protected System.Web.UI.WebControls.Panel panclswiseid;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		string i="";
	
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// also Generated Next LedgerID.
		/// </summary>
		string pass;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
				CreateLogFiles.ErrorLog (" Form : Classwisesubjects.aspx.cs, Method : Page_Load. User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"/eschool/Form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Classwisesubjects.aspx.cs, Method : Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					RetInfo();
					panclswiseid.Visible=false;
					# region Populate comboboxes
                    SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrclass;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select Distinct Class_name,Class_id  From Class order by Class_id", con );
					dtrclass = cmdselect.ExecuteReader();
					while (dtrclass.Read()) 
					{
						DropClass.Items.Add(dtrclass["Class_name"].ToString());
					}
					dtrclass.Close();
					con.Close ();
					# endregion
				}
				
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog ("Form: Classwisesubjects.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
			if(! IsPostBack)
			{
				SubjectAvl();
				#region Check Privileges
								int i;
								string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
								string Module="2";
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
			this.dropClassWiseSubject.SelectedIndexChanged += new System.EventHandler(this.dropClassWiseSubject_SelectedIndexChanged);
			this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
			this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
			this.btnout.Click += new System.EventHandler(this.btnout_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// This Method use to Clear the all control of page.
		/// </summary>
		public void Clear()
		{
			DropClass.SelectedIndex=0;
			DropStream.SelectedIndex=0;
			ListSubjestAssigned.Items.Clear();
			SubjectAvl();
		}

		/// <summary>
		/// This Method use to save subject in Listbox fetch from Subject table. but status must be true. other wise subject not show in listbox.
		/// </summary>
		public void SubjectAvl()
		{
			try
			{
				SqlConnection con1;
				SqlCommand cmdselect1;
				SqlDataReader dtrclass1;
				con1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con1.Open ();
				//cmdselect1 = new SqlCommand( "Select Subject_name  From Subject", con1 );  
				cmdselect1 = new SqlCommand("Select Subject_name  From Subject where Status=1", con1 );
				dtrclass1 =  cmdselect1.ExecuteReader();
				ListSubjectAvailable.Items.Clear();
				while (dtrclass1.Read()) 
				{
					ListSubjectAvailable.Items.Add(dtrclass1["Subject_name"].ToString());
				}
				dtrclass1.Close();
				con1.Close ();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:ClassWiseSubjects.aspx,Method:SubjectAvl"+" EXCEPTION  "+ex.Message+" userid ");	
			}

		}
		
		
		/// <summary>
		/// this Method use to fill dropdown with Class and Classwisesubjectid from classwisesubject table.
		/// </summary>
		public void RetInfo()
		{
			try
			{
				EmployeeClass obj = new EmployeeClass();
				SqlDataReader SqlDtr;
				//string str = "Select distinct c.class_name cn,cw.stream st From Class c,Classwisesubjects cw where c.class_name in (select distinct class_name from class where class_id=cw.class_id)";
				string str = "Select distinct c.class_name cn,cw.stream st From Class c,Classwisesubjects cw where c.class_name in (select distinct class_name from class where class_id=cw.class_id)";
				SqlDtr = obj.GetRecordSet(str);
				dropClassWiseSubject.Items.Clear();
				dropClassWiseSubject.Items.Add("Select");
				while(SqlDtr.Read())
				{
					dropClassWiseSubject.Items.Add(SqlDtr.GetValue(0).ToString()+" : "+SqlDtr.GetValue(1).ToString());
				}
				SqlDtr.Close();
			}
			catch(Exception ex)
			{
				 CreateLogFiles.ErrorLog("Form:ClassWiseSubjects.aspx,Method:RetInfo"+" EXCEPTION  "+ex.Message+" userid ");	
			}
		}
	
		/// <summary>
		/// This method use to Reset Page.
		/// </summary>
		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// This method use to Genrate Next ClasswiseSubjectID.
		/// </summary>
		private void fillID()
		{
			SqlConnection con;
			SqlCommand cmd;
			try
			{
				con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con.Open ();
				SqlDataReader SqlDtr; 
				cmd=new SqlCommand("select max(classSubject_id)+1 from ClasswiseSubjects",con);
				SqlDtr=cmd.ExecuteReader();
				if(SqlDtr.HasRows )
				{
					while(SqlDtr.Read())
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
				
				CreateLogFiles.ErrorLog("Form:ClassWiseSubjects.aspx,Method:RetInfo"+" EXCEPTION  "+ex.Message+" userid ");	
			}
		}

		/// <summary>
		/// not in use.
		/// </summary>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void Dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	
		/// <summary>
		/// This Method use to Use To Assign Subject For Class.
		/// </summary>
		private void btnIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				ListSubjestAssigned.Items.Add(ListSubjectAvailable.SelectedItem.Value);  
				ListSubjectAvailable.Items.Remove(ListSubjectAvailable.SelectedItem.Value);
				CreateLogFiles.ErrorLog("Form:Shift_assignment.aspx,Method:btnIn_Click"+"  userid "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please Select Subject");
				CreateLogFiles.ErrorLog("Form:Classwisesubjects.aspx,Method:btnIn_Click"+"  EXCCEPTION "+ex.Message+"  userid  "+pass);
			}

		}
		
		/// <summary>
		/// This method use To Remove Assigned Subject
		/// </summary>
		private void btnout_Click(object sender, System.EventArgs e)
		{
			try
			{
				ListSubjectAvailable.Items.Add(ListSubjestAssigned.SelectedItem.Value);  
				ListSubjestAssigned.Items.Remove(ListSubjestAssigned.SelectedItem.Value);
				CreateLogFiles.ErrorLog("Form:Classwisesubjects.aspx,Method:btnOut_Click"+"  userid "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Please Select Subject");
				CreateLogFiles.ErrorLog("Form:Classwisesubjects.aspx,Method:btnIn_Click"+"  EXCCEPTION "+ex.Message+"  userid  "+pass);
			}

		}

		/// <summary>
		/// This method use to Save And Update Class Wise Subject
		/// </summary>
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(DropClass.SelectedItem.Text.Equals("Select"))
				{
					MessageBox.Show("Please Select the class name");
					return;
				}
				if((DropClass.SelectedItem.Text.Equals("XI") ||DropClass.SelectedItem.Text.Equals("XII"))&&DropStream.SelectedIndex==0)//added by vishnu
				{
					MessageBox.Show("Please Select the valid stream");
					return;
				}
				string clsid="0",str="",k="0";
				int count=0;
				EmployeeClass obj = new EmployeeClass();
				SqlDataReader SqlDtr;
				
					str = "Select Class_id From Class where class_name='"+DropClass.SelectedItem.Text+"'";
					SqlDtr = obj.GetRecordSet(str);
					while (SqlDtr.Read()) 
					{
						clsid=SqlDtr["Class_id"].ToString();
					}
					SqlDtr.Close();
				if(panclswiseid.Visible==false)
				{
					str= "Select count(*) From Classwisesubjects where class_id="+clsid+" and Stream='"+DropStream.SelectedItem.Text+"'";
					SqlDtr = obj.GetRecordSet(str);
					while (SqlDtr.Read()) 
					{
						count=int.Parse(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
					if(count>0)
					{
						MessageBox.Show("Class "+DropClass.SelectedItem.Text+" allready exist");
						return;
					}
				}
				else
				{
					str= "Select classsubject_id From Classwisesubjects where class_id="+clsid+" and Stream='"+DropStream.SelectedItem.Text+"'";
					SqlDtr = obj.GetRecordSet(str);
					if(SqlDtr.Read()) 
					{
						k=SqlDtr.GetValue(0).ToString();
					}
					SqlDtr.Close();
				}
				fillID();
				
				obj.Stream=DropStream.SelectedItem.Text;
				obj.Class_Name=DropClass.SelectedItem.Text;
				for(int j=0;j<ListSubjestAssigned.Items.Count;++j)
				{
					ListSubjestAssigned.SelectedIndex = j;
					obj.assignsubject = ListSubjestAssigned.SelectedItem.Value; 
					obj.Edit="";
					if(panclswiseid.Visible==false)
					{
						obj.clwsid=System.Convert.ToInt32(i);
						obj.InsertSubjectAssignment();
					}
					else
					{
						if(j==0)
							obj.Edit="Edit";
						obj.clwsid=System.Convert.ToInt32(k);
						obj.InsertSubjectAssignment();
					}
				} 
				if(panclswiseid.Visible==false)
					MessageBox.Show("Subject Successfully Assigned"); 
				else
					MessageBox.Show("Subject Assigned Update"); 
				RetInfo();
				btnSubmit.Text="Submit";
				panclswiseid.Visible=false;
				Clear();
				CreateLogFiles.ErrorLog(" Form : Classwisesubject.aspx, Method : btnSubmit_Click "+" userid "+pass);
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ClassWiseSubjects.aspx, Method : btnSubmit_Click "+" EXCEPTION  "+ex.Message+" userid "+pass);	
			}

		}

		/// <summary>
		/// This method use to upadte the information.
		/// </summary>
		private void btnedit_Click(object sender, System.EventArgs e)
		{
			panclswiseid.Visible=true;
			btnSubmit.Text = "Update";
        }
		
		/// <summary>
		/// this method Use To fetch Assigned Subject from classwisesubject table.
		/// </summary>
		private void dropClassWiseSubject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(dropClassWiseSubject.SelectedIndex!=0)
				{
					SqlDataReader SqlDtr;
					EmployeeClass stdobj=new EmployeeClass();
					string nmst1=dropClassWiseSubject.SelectedItem.Text.ToString();
					string[] nmst=nmst1.Split(new char[] {':'},nmst1.Length);
					DropClass.SelectedIndex=DropClass.Items.IndexOf(DropClass.Items.FindByValue(nmst[0].Trim()));
					DropStream.SelectedIndex=DropStream.Items.IndexOf(DropStream.Items.FindByValue(nmst[1].Trim()));
					string strcmd="select subject_name from subject where subject_id in (select distinct subject_id from classwisesubjects where class_id in(select class_id from class where class_name='"+nmst[0].Trim()+"') and stream='"+nmst[1].Trim()+"') and status=1";
					//string strcmd="select subject_name from subject where subject_id in (select distinct subject_id from classwisesubjects where class_id in(select class_id from class where class_name='"+nmst[0].Trim()+"') and stream='"+nmst[1].Trim()+"')";  04.09.08
					SqlDtr=stdobj.GetRecordSet(strcmd);
					ListSubjestAssigned.Items.Clear();
					while(SqlDtr.Read())
					{
						ListSubjestAssigned.Items.Add(SqlDtr.GetValue(0).ToString());
						ListSubjectAvailable.Items.Remove(SqlDtr.GetValue(0).ToString());
					}
					SqlDtr.Close();
				}
				CreateLogFiles.ErrorLog(" Form : ClassWiseSubjects.aspx, Method : dropEdit_SelectedIndexChanged userid "+pass);	
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : ClassWiseSubjects.aspx, Method : dropEdit_SelectedIndexChanged "+" EXCEPTION  "+ex.Message+" userid "+pass);	
			}

		}
	}
}
		
		 


