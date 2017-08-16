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
using System.Data.SqlClient;
using System.Text;
using RMG;
using eschool.Classes;
# endregion

namespace eschool.Library.FORMS
{
	/// <summary>
	/// Summary description for CardGeneration.
	/// </summary>
	public class CardGeneration : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtstaffname;
		protected System.Web.UI.WebControls.TextBox TxtCardNo;
		protected System.Web.UI.WebControls.TextBox TxtNumberOFCard;
		protected System.Web.UI.WebControls.RequiredFieldValidator ReqNumOFCard;
		protected System.Web.UI.WebControls.DropDownList dropValiOfCard;
		protected System.Web.UI.WebControls.CompareValidator cvValidity;
		protected System.Web.UI.WebControls.TextBox TxtRemark;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputButton Reset1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNameOFEmployee;
		protected System.Web.UI.WebControls.ValidationSummary vsCardGen;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TxtCandidateId;
		protected System.Web.UI.WebControls.Panel panemployee;
		//SqlDataReader sdtr;
		# region Page Load...
		static string candiCountM="";
		protected System.Web.UI.WebControls.RadioButton chkTeaching;
		protected System.Web.UI.WebControls.RadioButton chkNonTeaching;
		protected System.Web.UI.WebControls.RadioButton chkStudent;
		protected System.Web.UI.WebControls.DropDownList DropType;
		protected System.Web.UI.WebControls.Label lblDesignation;
		protected System.Web.UI.WebControls.CompareValidator cvStaffType;
		protected System.Web.UI.WebControls.Label lblEmployeeID;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropEmpID;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btndel;
		protected System.Web.UI.WebControls.Panel pansclass;
		protected System.Web.UI.WebControls.DropDownList DropStudID;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Lblmemid;
		protected System.Web.UI.WebControls.TextBox TxtStname;
		string pass;
		//protected System.Web.UI.WebControls.Panel panemployee;
		static string candiCountCG="";
		//		static int  CandidateID=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pansclass .Visible =false;
				//panemployee .Visible =false;
				//***********************gyanandra******************
				if(chkTeaching.Checked==true)
				{
					//					int iCount=lstSubject.Items.Count;
					//					for(int i=0;i<iCount;i++)
					//					{		
					//						if(lstSubject.Items[i].Selected==true && chkTeaching.Checked==true)
					//						{
					//							j++;
					//						}
					//					}
				}
				//*****************************end****************************
				if(Session["view"]!=null)
				{
					try
					{
						if(Session["password"].ToString().Length<=0&&(bool)Session["view"]==false)
						{
							Session.Abandon();
							Session.RemoveAll();
				 
							Response.Redirect(@"./HolidayEntryForm.aspx");
						}
						else
						{
							Response.Buffer=false;
							Response.CacheControl="no-cache";
							Response.Expires=System.DateTime.Now.Minute-1;	
							Session["view"]=false;
						}
					}
					catch(System.NullReferenceException)
					{
				
								
						//CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  Page_Load,  Exception : system.NullReferenceException    Userid:  "+ Session["password"].ToString()   );								
						Session.Abandon();
						Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
					}
								
				}
				else
				{
					Response.Buffer=false;
					Response.CacheControl="no-cache";
					Response.Expires=System.DateTime.Now.Minute-1;
					Session["view"]=false;
				}
				
				pass=(Session["password"].ToString());
					
				if(!IsPostBack)
				{
					txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					//increaseCandidateID();//Method call to add the candidate id on lable.
					increaseCardNO();//Method call to add the cardno.
					//checkMembership();//call method to check whther need to genrete card for candidate.	 
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="5";
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
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  Page_Load,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 
				Response.Redirect("../../Form/HolidayEntryForm.aspx"); 
					return;
			}			
		}
		# endregion

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
			this.chkTeaching.CheckedChanged += new System.EventHandler(this.chkTeaching_CheckedChanged);
			this.chkNonTeaching.CheckedChanged += new System.EventHandler(this.chkNonTeaching_CheckedChanged);
			this.chkStudent.CheckedChanged += new System.EventHandler(this.chkStudent_CheckedChanged);
			this.DropType.SelectedIndexChanged += new System.EventHandler(this.DropType_SelectedIndexChanged);
			this.DropEmpID.SelectedIndexChanged += new System.EventHandler(this.DropEmpID_SelectedIndexChanged);
			this.DropClass.SelectedIndexChanged += new System.EventHandler(this.dropclass_SelectedIndexChanged);
			this.DropStudID.SelectedIndexChanged += new System.EventHandler(this.DropStudID_SelectedIndexChanged);
			this.TxtNumberOFCard.TextChanged += new System.EventHandler(this.TxtNumberOFCard_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region DateTime Function for returning the date in DD/MM/YYYY.
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
		#endregion

		# region  Method for Saving the card genration information.
		private void btnSave_Click(object sender, System.EventArgs e)

		{
			try
			{
				SchoolClass.regis obj=new SchoolClass.regis();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="select count(*) from Card_Generation where Memberid='"+Lblmemid.Value+"'";
				
				SqlDtr=obj1.GetRecordSet(str);
				if(SqlDtr.Read())
				{
					if(!SqlDtr.GetValue(0).ToString().Equals("0"))
					{
						MessageBox.Show("Card Allready Issue");
						return;
					}
				}
				DateTime dt=System.DateTime.Now;
				DateTime dToday=Convert.ToDateTime(ToMMddYYYY(txtDate.Text));
				System.TimeSpan diff=dToday.Subtract(dt);
				//*************************gyanandra*******************
				
				
				string Emp=DropEmpID.SelectedItem.Text;
				string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
				obj.Staff_ID=EmpName[0].ToString();
				if(DropType.SelectedIndex==0)
					obj.Staff_Type="";
				else
					obj.Staff_Type=DropType .SelectedItem.Value.ToString();
				if(txtNameOFEmployee.Value=="")
					obj.Staff_Name="";
				else
					obj.Staff_Name=txtNameOFEmployee.Value.Trim();
				
				if(txtDate.Text=="")
					obj.Date_Of_CardGen ="0";
				else
					obj.Date_Of_CardGen =GenUtil.str2MMDDYYYY(txtDate.Text);
				//sqcom.Parameters .Add ("@Date_Of_CardGen",GenUtil.str2MMDDYYYY (txtDate.Text.ToString ()));			
				
				//**************************end*****************
				//int iDays=diff.Days;
				//if(int.Parse(candiCountCG)<= int.Parse(candiCountM))
				//{
				//if(iDays == 0)
				//{
				//LibraryClass.CardGenerationClass obj1=new LibraryClass .CardGenerationClass (); 
				//**************gyanandra*******************
												
				//****************************end*************
				//						if(LblCardCid.Text=="")
				//							obj.CandidateID="";
				//						else
				//							obj.CandidateID=LblCardCid .Text.Trim().ToUpper();
						
				//*****************gyanandra************
						
				if(Lblmemid.Value=="")
					obj.memberID ="";
				else
					obj.memberID =Lblmemid.Value.Trim ();
					//obj.memberID =Lblmemid.Text .Trim ().ToUpper ();
						
				//************************************
						
				if(TxtCardNo.Text=="")
					obj.Card_NO="";
				else
					obj.Card_NO=TxtCardNo.Text.Trim();
					//obj.Card_NO=TxtCardNo.Text.Trim().ToUpper();
				if(TxtNumberOFCard.Text=="")
					obj.No_Of_Card="";
				else
					obj.No_Of_Card =TxtNumberOFCard .Text.Trim();
					//obj.No_Of_Card =TxtNumberOFCard .Text.Trim().ToUpper();
				if(dropValiOfCard.SelectedIndex==0)
					obj.Validity_Of_Card="0";
				else
					obj.Validity_Of_Card =dropValiOfCard .SelectedItem .Value .ToString();
				if(txtDate.Text=="")
					obj.Date_Of_CardGen="0";
				else
					obj.Date_Of_CardGen =GenUtil.str2MMDDYYYY(txtDate.Text.Trim());
				if(txtNameOFEmployee.Value=="")
					obj.Name_Of_Librarian ="";
				else
					obj.Name_Of_Librarian=txtNameOFEmployee.Value.Trim().ToUpper() ;
				if(TxtRemark.Text=="")
					obj.Remark ="";
				else
					obj.Remark =TxtRemark .Text.Trim().ToUpper();
				if(DropType.SelectedIndex==0)
					obj.Design="";
				else
					obj.Design=DropType.SelectedItem.Text;
				
				if(DropClass .SelectedIndex==0)
				        obj.Student_Class ="";
				else
						obj.Student_Class=DropClass .SelectedItem.Text;
				//*******************gyanandra***********23.04.07*****************
				//checkMembership();//before saving check whether any need for card generation.
				obj.InsCardInformation();//Insert the card information for perticular candidate id to the database.
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  btnCont_Click,  CardNo :"+TxtCardNo.Text.Trim().ToUpper()+" Genreted for memberID   "+ Lblmemid.Value.Trim().ToUpper()+  "    Userid  :  "+ Session["Password"].ToString()   );						 				
				Clear();
				MessageBox.Show("Card Generate Sucessfully");
						 
				increaseCardNO();//call method for getting next card no.
				//increaseCandidateID();//call method for getting next candidate id
				//checkMembership();//check whether member is remins for card allocation.
				//}
										 
				//else
				//{
				//	MessageBox.Show(" You must be enter the current date");
				//}
										
				//}
									 
				//else
				//{
				//	MessageBox.Show("No need for card Genration,cards already alloted to all members");
				//	return ;
				//}
			}
			catch(Exception ex)
			{
						
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  btnCont_Click,  Exception : "+ex.Message+"    Userid:  "+ Session["Password"].ToString()   );						 								
				//Response.Write(ex.Message);
									
			}
		}
								
		//*******************************************end**********************
		# endregion

 
		
		
		//Method for checking whether any need for card genretion if any candidate remain then only genrete card otherwise show massege.		
		public void checkMembership()
		{
			LibraryClass.CardGenerationClass obj=new LibraryClass .CardGenerationClass (); 
						             
						
			SqlDataReader sdred;
			sdred=obj.getCandidateCountM();
						 
								
			try
			{
				while(sdred.Read())
				{
					candiCountM=sdred.GetValue(0).ToString();
				}			
							
				sdred.Close();
				sdred=obj.getCandidateCountCG();
						 
				while(sdred.Read())
				{
					candiCountCG=sdred.GetValue(0).ToString();
									
				}			
							
				sdred.Close();
									 
								
				//				if(int.Parse(candiCountCG)>= int.Parse(candiCountM))
				//				{
				//					MessageBox.Show("No need for card Genration,cards already alloted to all members");
				//					return ;
				//									
				//						  
				//				}
						
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  checkMembership,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 								
			}
									
								
		}
								
								
								
		
		//Method for incresing the candidateID and add to the lable.		
		public void increaseCandidateID()
		{
			LibraryClass .CardGenerationClass obj=new LibraryClass.CardGenerationClass();
			SqlDataReader sdred;
			sdred=obj.getCardGen();
			string candi="";
			try
			{
						
									
				while(sdred.Read())
				{
					candi=sdred.GetValue(0).ToString();
				}			
							
								
				if(candi.Equals("")||candi==null)
				{
					candi="101";
								
				}
									 
				Lblmemid.Value=candi;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  increaseCandidateID,  Exception : "+ex.Message+"    Userid:  "+ pass   );						 								
			}
						
								
		}
										

		# region increaseCardNO() Function...for adding the next cardno to the lable.
		public void increaseCardNO()
		{
			LibraryClass .CardGenerationClass obj=new LibraryClass.CardGenerationClass();
			SqlDataReader sdred;
			sdred=obj.getCardNo();
			string card="";
			try
			{
			
				while(sdred.Read())
				{
					 
					card=sdred .GetValue(0).ToString();
				}			
		
				if(card.Equals("")||card==null)//check if first entry then start from 1001.
				{
					card="1001";
				}

				TxtCardNo .Text=card;
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : CardGenration.aspx,Method  increaseCardNO,  Exception : "+ex.Message+"    Userid:  "+ Session["Password"].ToString()   );						 								
			}
		}
		# endregion

		# region Clear Function...To clear the form.
		public void Clear()
		{   
			txtDate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
			DropType .SelectedIndex=0;
			DropEmpID .SelectedIndex=0;
			chkNonTeaching.Checked=false;
			chkTeaching .Checked=false;
			chkStudent.Checked =false;
			TxtCardNo.Text="";
			TxtNumberOFCard.Text="";
			// txtDate.Text="";
			dropValiOfCard.SelectedIndex=0;
			txtNameOFEmployee.Value="";
			TxtRemark.Text="";
			Lblmemid.Value="";
		}
		# endregion

		# region Reset Button...call to clear function for clearing the form.
		private void Reset1_ServerClick(object sender, System.EventArgs e)
		{
			Clear();
		}
		# endregion

		
		public void staffType()
		{
			try
			{
				SqlConnection con3;
				SqlCommand cmdselect3;
				SqlDataReader dtrclass3;
				con3=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				con3.Open ();

				# region CASE-1(TRUE,FALSE)
				if(chkTeaching.Checked==true)// && chkNonteaching.Checked==false)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where teaching=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					//lblSub.Visible =true;
					//lstSubject.Visible =true;
					//lblExp.Visible =true;
					//Dropstaffexp.Visible =true; 
				}
				if(chkNonTeaching.Checked==true)// && chkTeaching.Checked==false)
				{
					cmdselect3 = new SqlCommand( "Select distinct staff_name  From Staff_Type  where nonteaching=1 order by staff_name", con3 );
					dtrclass3 =  cmdselect3.ExecuteReader();
					DropType.Items.Clear();
					DropType.Items.Add("---Select---");
					while(dtrclass3.Read())
					{
						DropType.Items.Add(dtrclass3.GetString(0));
					}
					dtrclass3.Close();
					//lblSub.Visible =false;
					//lstSubject.Visible =false;
					//lblExp.Visible =true;
					//Dropstaffexp.Visible =true; 
				}
			}


			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: Staffname.aspx.cs, Method: DropCity_SelectedIndexChanged. Exception: " + ex.Message + " User: " + Session["password"].ToString() );
			}
			#endregion
		}

		private void chkTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
			//pansclass.Visible =false;
			panemployee .Visible =true;
		}


		private void DropEmpID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			
			string Emp=DropEmpID.SelectedItem.Text;
			string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
			string str="select Staff_Name from staff_information where staff_id="+EmpName[0]+" and staff_name='"+EmpName[1]+"'";
			SqlDtr=obj.GetRecordSet(str);
			if(SqlDtr.Read())
			{
				txtNameOFEmployee.Value=SqlDtr["Staff_Name"].ToString();
			}
			Lblmemid.Value=EmpName[0].ToString();
			
	
		}

		

		private void DropType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		     if(DropType.SelectedIndex ==0)
			{
				MessageBox.Show ("Select Staff Designation");
				return;
			}
			
			
			DropEmpID.Visible=true;
			SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con.Open ();
			SqlDataReader SqlDtr; 
			SqlCommand cmd=new SqlCommand("select staff_id,staff_name from staff_information where staff_type='"+DropType.SelectedItem.Text+"'",con);
			SqlDtr=cmd.ExecuteReader();
			DropEmpID.Items.Clear();
			DropEmpID.Items.Add("Select");
			while(SqlDtr.Read())
			{
				DropEmpID.Items.Add(SqlDtr.GetValue(0).ToString()+":"+SqlDtr.GetValue(1).ToString());
			}
			SqlDtr.Close();
			con.Close();
			//			}
		}

		private void chkNonTeaching_CheckedChanged(object sender, System.EventArgs e)
		{
			staffType();
			//pansclass.Visible =false;
			panemployee .Visible =true;
		}

		private void btndel_Click(object sender, System.EventArgs e)
		{
			SqlConnection con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			con.Open ();
			//string Emp=DropEmpID.SelectedItem.Text;
			string Emp=DropEmpID.SelectedItem.Text;
			string[] EmpName=Emp.Split(new char[] {':'},Emp.Length);
			//SqlDataReader SqlDtr; 
			SqlCommand cmd=new SqlCommand("delete from Card_Generation where staff_id="+EmpName[0],con);
			cmd.ExecuteNonQuery();
			MessageBox.Show("Record Deleted Successfully");
			//fillID();
			//clear();
			btnSave.Enabled=true;
			DropEmpID.Visible=false;
			//lblEmpID.Visible=true;
		}

		private void chkStudent_CheckedChanged(object sender, System.EventArgs e)
		{
			pansclass.Visible =true;
			panemployee .Visible =false;
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string str="select class_name from class order by class_name";
			SqlDtr=obj.GetRecordSet(str);
			DropClass.Items.Clear();
			DropClass.Items.Add("Select");
			while(SqlDtr.Read())
			{
				DropClass.Items.Add(SqlDtr.GetValue(0).ToString());
			}
			SqlDtr.Close();
		}
		//string sname="";
		private void dropclass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pansclass.Visible =true;
			panemployee .Visible =false;
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string str="select student_id ,Student_FName from student_record where student_class='"+DropClass.SelectedItem.Text+"' order by student_id";
			SqlDtr=obj.GetRecordSet(str);
			DropStudID.Items.Clear();
			DropStudID.Items.Add("Select");
			while(SqlDtr.Read())
			{
				DropStudID.Items.Add(SqlDtr.GetValue(0).ToString());
				//sname=SqlDtr.GetValue(1).ToString();
				
			}
			SqlDtr.Close();	
		
		}

		private void DropStudID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pansclass.Visible =true;
			panemployee .Visible =false;
			EmployeeClass obj=new EmployeeClass();
			SqlDataReader SqlDtr;
			string str="select Student_FName from student_record where student_id='"+DropStudID.SelectedItem.Text+"'";//add by vikas sharma 23.11.07
			SqlDtr=obj.GetRecordSet(str);
			if(chkStudent.Checked)
			{
				Lblmemid.Value=DropStudID.SelectedItem.Text.ToString();
				if(SqlDtr.Read())
					txtNameOFEmployee.Value=SqlDtr.GetValue(0).ToString();
				    TxtStname.Text=SqlDtr.GetValue(0).ToString();
				SqlDtr.Close();	
			}
		}

		private void TxtNumberOFCard_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}

			