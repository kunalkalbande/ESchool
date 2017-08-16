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
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for SubjectWiseReport.
	/// </summary>
	public class SubjectWiseReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnsearch;
		protected System.Web.UI.WebControls.Button btnprint;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.DropDownList DropExamType;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		public static int [,]grade=new int [25,10];
		public static string[] sname=new string[25];
		public  static string[] tname=new string[25];
		public static double[]passPer=new double[25];
		protected System.Web.UI.WebControls.Button Btnexcel;
		public static double[]avgMarks=new double[25];
		protected System.Web.UI.WebControls.DropDownList DropSession;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog ("Form: AttendanceReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{ 
				if(!Page .IsPostBack)
				{
					SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					scon.Open();
					SqlDataReader sdtr;
					//SqlCommand scom2=new SqlCommand("Select distinct class_Name from class order by class_id ",scon); 
					SqlCommand scom2=new SqlCommand("Select class_Name from class order by class_id ",scon); 
					sdtr=scom2.ExecuteReader();
					while(sdtr.Read())
					{
						DropClass.Items.Add(sdtr.GetValue(0).ToString().Trim());
					}
					sdtr.Close();
					scon.Close();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="31";
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
					if(View_flag=="False")
					{
						
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :AttendanceReport.aspx.cs,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  ");//+Session["password"].ToString()   );		
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
			this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
			this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		/// <summary>
		/// this method use to show report. in this method first get subject from classwisesubject table. after that save all marks in an array. find category of marks.
		/// </summary>
		private void btnsearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				int gradeAp=0;
				int gradeA=0;
				int gradeBp=0;
				int	gradeB=0;
				int gradeCp=0;
				int gradeC=0;
				int gradeD=0;
				int gradeE=0;
				int maxMarks=0;
				int Total=0;
				double per=0;
				bool Flag=false;
				for(int i=0;i<25;i++)
				{
					for(int j=0;j<10;j++)
					      grade[i,j]=0;
					passPer[i]=0;
					avgMarks[i]=0;
				}
				//20.02.09if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropExamType.SelectedIndex!=0&& DropStream.SelectedIndex!=0)
				if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropExamType.SelectedIndex!=0)
				{
					InventoryClass obj1=new InventoryClass();
					InventoryClass obj2=new InventoryClass();
					SqlDataReader SqlDtr,SqlDtr1;
    				string cls="";
					/*if(DropClass.SelectedItem.Text.Equals("I"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="12";*/

					if(DropClass.SelectedItem.Text.Equals("Nursery"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("LKG"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("UKG"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("I"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="12";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="13";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="14";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="15";

					//string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"' ) order by subject_name ";
					string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"' ) and status=1 order by subject_name ";
					SqlDtr=obj1.GetRecordSet(str1);
					string []col=new string[30];
					double max=0;
					string name="";
					int sub=0;
					while(SqlDtr.Read())
					{
						name=SqlDtr.GetValue(0).ToString().Trim();
						if(name.IndexOf(" ")>0)
							name=name.Replace(" ","_");
						if(name.IndexOf("&")>0)
							name=name.Replace("&","and");
						//if((name.Equals("COMPUTER"))&&(!DropClass.SelectedItem.Text.Equals("I")&&!DropClass.SelectedItem.Text.Equals("II")))
						if((name.Equals("COMPUTER"))&&(!DropClass.SelectedItem.Text.Equals("I")&&!DropClass.SelectedItem.Text.Equals("II")&&!DropClass.SelectedItem.Text.Equals("Nursery")&&!DropClass.SelectedItem.Text.Equals("LKG")&&!DropClass.SelectedItem.Text.Equals("UKG")))
							name = name+"_tot";
						if(name.Equals("PHYSICS"))
							name =name+ "_tot";
						if(name.Equals("BIOLOGY"))
							name =name+ "_tot";
						if(name.Equals("CHEMISTRY"))
							name =name+ "_tot";
						//if((name=="COMPUTER"||name=="ENGLISH"||name=="HINDI"||name=="MATHEMATICS"||name=="EVS")&&(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")))
						if((name=="COMPUTER"||name=="ENGLISH"||name=="HINDI"||name=="MATHEMATICS"||name=="EVS")&&(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("UKG")||DropClass.SelectedItem.Text.Equals("LKG")))
						{
							 if(name=="ENGLISH")
							{
								 col[sub]="Eng_Read";
								 sub++;
								 col[sub]="Eng_Writing";
								 sub++;
								 col[sub]="Eng_Con";
								 sub++;
								 col[sub]="Eng_Spelling";
								 sub++;
								 name="Eng_Compre";
    						}
							else if(name=="HINDI")
							{
								 col[sub]="Hindi_Read";
								 sub++;
								 col[sub]="Hindi_Writing";
								 sub++;
								 col[sub]="Hindi_Con";
								 sub++;
								 col[sub]="Hindi_Spelling";
								 sub++;
								 name="Hindi_Com";
								
							}
							else if(name=="MATHEMATICS")
							{
								 col[sub]="Math_FNumber";
								 sub++;
								 col[sub]="Math_BConcept";
								 sub++;
								 name="Math_Computation";
								
							}
							else if(name=="EVS")
							{
								 col[sub]="evs_observation";
								 sub++;
								 col[sub]="evs_Identification";
								 sub++;
								 name="Evs_know";
								
							}
							if(name=="COMPUTER")
							{
								name="COMPUTER_tot";
							}
						}

						col[sub]=name;
						sub++;
					}	
					SqlDtr.Close();
					for(int i=0;i<sub;i++)
					{
						Flag=false;
						gradeAp=0;
						gradeA=0;
						gradeBp=0;
						gradeB=0;
						gradeCp=0;
						gradeC=0;
						gradeD=0;
						gradeE=0;
						maxMarks=0;
						Total=0;
						per=0;
						sname[i]="";
						tname[i]="";
						///08.10.08 string str3="select "+col[i] + " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+DropExamType.SelectedItem.Text+"'";
						string str3="select "+col[i] + " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+DropExamType.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
						SqlDtr=obj1.GetRecordSet(str3);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals(""))
							max=System.Convert.ToDouble(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						string str="";
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*95.0)/100.0+" and  cast ("+col[i] +" as float) <= "+ max +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///08.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*95.0)/100.0+" and  cast ("+col[i] +" as float) <= "+ max +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*95.0)/100+" and  cast ("+col[i] +" as float) <= "+ max +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///08.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*95.0)/100+" and  cast ("+col[i] +" as float) <= "+ max +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeAp=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*85.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*95.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*85.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*95.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*85.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*95.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*85.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*95.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 
							
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeA=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*75.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*85.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*75.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*85.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*75)/100+" and  cast ("+col[i] +" as float) < "+ (max*85.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*75)/100+" and  cast ("+col[i] +" as float) < "+ (max*85.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeBp=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
		
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*65.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*75.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///08.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*65.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*75.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*65.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*75.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*65.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*75.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeB=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
					
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*55.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*65.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*55.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*65.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*55.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*65.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*55.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*65.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeCp=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();

											
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*45.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*55.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*45.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*55.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*45.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*55.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*45.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*55.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 
						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeC=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*40.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*45.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) >= "+(max*40.0)/100.0+" and  cast ("+col[i] +" as float) < "+ (max*45.0)/100 +" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*40.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*45.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as float) >= " +(max*40.0)/100+" and  cast ("+col[i] +" as float) < "+ (max*45.0)/100 +" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 

						SqlDtr=obj1.GetRecordSet(str);

						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeD=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) < "+(max*40.0)/100.0+" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and  cast(" +col[i]+" as float) < "+(max*40.0)/100.0+" and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as int) < " +(max*40)/100+" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'" +" and  cast(" + col[i] + " as int) < " +(max*40)/100+" and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								gradeE=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select max(cast("+ col[i] + " as float)) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and "+col[i]+"!='A' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select max(cast("+ col[i] + " as float)) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and "+col[i]+"!='A'";
						else
							str =" select max(cast("+ col[i] + " as float)) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and "+col[i]+"!='A' and year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str =" select max(cast("+ col[i] + " as float)) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and "+col[i]+"!='A'";

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								maxMarks=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select avg(cast("+ col[i] + " as int)) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'  and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							/// 08.10.08 str="select avg(cast("+ col[i] + " as int)) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A'  and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str =" select avg(cast("+ col[i] + " as int)) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and "+col[i]+"!='A' and year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str =" select avg(cast("+ col[i] + " as int)) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and "+col[i]+"!='A'";

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								avgMarks[i]=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select sr.sname from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and "+ col[i] +"= '"+maxMarks+"' and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select sr.sname from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"!='A' and "+ col[i] +"= '"+maxMarks+"' and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select student_name from studentmarks where "+ col[i] +"= '"+maxMarks+"' and exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
							///8.10.08 str="select student_name from studentmarks where "+ col[i] +"= '"+maxMarks+"' and exam_type='"+DropExamType.SelectedItem.Text +"' and class='" +DropClass.SelectedItem.Text+"' and stream='" +DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals(""))
								sname[i]=SqlDtr.GetValue(0).ToString();
						
						}
						SqlDtr.Close();

						int E=0;
						//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
						if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))	
							str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"='A'  and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							///08.10.08 str="select count(*) from studentmarksentryIandII st,student_roll sr where st.Rollno=sr.studentid and exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"='A'  and sr.classid='" +DropClass.SelectedItem.Text+"' and sr.st_section='"+DropSection.SelectedItem.Text+"' and sr.stream='"+DropStream.SelectedItem.Text+"'";
						else
							str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"='A' and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'"; 
							///8.10.08 str="select count(*) from studentmarks where exam_type='"+DropExamType.SelectedItem.Text + "' and " +col[i]+"='A' and class='" +DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"'"; 

						SqlDtr=obj1.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(!SqlDtr.GetValue(0).ToString().Equals("")&&!SqlDtr.GetValue(0).ToString().Equals("A"))
								E=System.Convert.ToInt32(SqlDtr.GetValue(0).ToString());
						}
						SqlDtr.Close();
						
						grade[i,0]=gradeAp;
						grade[i,1]=gradeA;
						grade[i,2]=gradeBp;
						grade[i,3]=gradeB;
						grade[i,4]=gradeCp;
						grade[i,5]=gradeC;
						grade[i,6]=gradeD;
						grade[i,7]=gradeE;
						grade[i,8]=maxMarks;
						grade[i,9]=E;

						Total=gradeAp+gradeA+gradeBp+gradeB+gradeCp+gradeC+gradeD+gradeE;
						
						if(Total!=0)
						{
							per=(System.Convert.ToDouble(gradeE)/System.Convert.ToDouble(Total))*100;
							per=100-per;
							passPer[i]=System.Convert.ToDouble(GenUtil.strNumericFormat(per.ToString()));
							Flag=true;
						}
						else
						{
							Flag=false;
							
						}

						str=" select * from TeacherTimeTable "; 
						SqlDtr=obj1.GetRecordSet(str);

						string cname="",cname1="",id="",stra="";

						if(SqlDtr.Read())
						{
							for(int j=2;j<SqlDtr.FieldCount-2;j++)
							{
								cname1=cls+DropSection.SelectedItem.Text+col[i];
								if(!SqlDtr.GetName(j).ToString().Equals(""))
									cname=SqlDtr.GetName(j).ToString();
							
								stra="select employee_id from teachertimetable where "+ cname +" Like '%"+cname1+"%'";
								SqlDtr1=obj2.GetRecordSet(stra);
								if(SqlDtr1.Read())
								{
									if(!SqlDtr1.GetValue(0).ToString().Equals(""))
									{
										id=SqlDtr1.GetValue(0).ToString();
									}
								}
								SqlDtr1.Close();
							}
						
							stra="select staff_name from staff_information where staff_id='"+id+"'";
							SqlDtr1=obj2.GetRecordSet(stra);
							if(SqlDtr1.Read())
							{
								if(!SqlDtr1.GetValue(0).ToString().Equals(""))
								{
									tname[i]=SqlDtr1.GetValue(0).ToString();
								}
							}
							SqlDtr1.Close();
							
						}

						SqlDtr.Close();

					}
					if(Flag==false)
					{
						MessageBox.Show("Insufficient Data or Related Data not available");
						return ;
					}	
				}
				else
					MessageBox.Show("Please Select The Class, Section & Exam Type");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Problem in data or data type");
				CreateLogFiles.ErrorLog ("Form: SubjectWiseReport.aspx.cs, Method: btnsearch_Click. Exception: " + ex.Message + " User: " + pass );
				return;
			}
		}

		/// <summary>
		/// this method use to print report. in this method first get subject from classwisesubject table. after that save all marks in an array. find category of marks.
		/// </summary>
		private void btnprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SubjectWiseReport.txt";
				StreamWriter sw = new StreamWriter(path);
				//20.02.09 if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropStream.SelectedIndex!=0 && DropExamType.SelectedIndex!=0)
				if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropExamType.SelectedIndex!=0)
				{
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr=null;
					string cls="";
					/*if(DropClass.SelectedItem.Text=="I")
						cls="1";
					else if(DropClass.SelectedItem.Text=="II")
						cls="2";
					else if(DropClass.SelectedItem.Text=="III")
						cls="3";
					else if(DropClass.SelectedItem.Text=="IV")
						cls="4";
					else if(DropClass.SelectedItem.Text=="V")
						cls="5";
					else if(DropClass.SelectedItem.Text=="VI")
						cls="6";
					else if(DropClass.SelectedItem.Text=="VII")
						cls="7";
					else if(DropClass.SelectedItem.Text=="VIII")
						cls="8";
					else if(DropClass.SelectedItem.Text=="IX")
						cls="9";
					else if(DropClass.SelectedItem.Text=="X")
						cls="10";
					else if(DropClass.SelectedItem.Text=="XI")
						cls="11";
					else if(DropClass.SelectedItem.Text=="XII")
						cls="12";*/

					if(DropClass.SelectedItem.Text.Equals("Nursery"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("LKG"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("UKG"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("I"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="12";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="13";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="14";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="15";
						
					sw.Write((char)27);
					sw.Write((char)67);
					sw.Write((char)0);
					sw.Write((char)12);			
					sw.Write((char)27);
					sw.Write((char)78);
					sw.Write((char)5);							
					sw.Write((char)27);
					sw.Write((char)15);
    				string info="";
					string des="+--------------+-----+------+------+------+------+------+------+-----+----+-------+--------------------+--------+----+---------------+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("RESULT AT GLANCE",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------------------",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("SUBJECT WISE REPORT For Class:"+DropClass.SelectedItem.Text.Trim()+" Section:"+DropSection.SelectedItem.Text.Trim(),des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------------------",des.Length));
					sw.WriteLine("") ;
					sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
					sw.WriteLine("|Subject Name  |  A+ |  A   |  B+  |  B   |  C+  |  C   |  D   | E  |    |    |     |                  |        |     |               |");
					sw.WriteLine("|              |95%>=|85-94%|75-84%|65-74%|55-64%|45-54%|40-44%|<40%|Abse|Fail|High.|Student Name      |Avg Mark|Pass%|Subject Teacher|");
					sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
					//             12345678901234 12345 123456 123456 123456 123456 123456 123456 1234 1234 1234 12345 123456789012345678 12345678 12345 123456789012345
					info = " {0,-14:S} {1,5:S} {2,6:S} {3,6:S} {4,6:S} {5,6:S} {6,6:S} {7,6:S} {8,4:S} {9,4:S} {10,4:S} {11,5:S} {12,-18:S} {13,8:S} {14,5:S} {15,-15:S}";
					string str="select subject_name from subject s,classwisesubjects c where s.subject_id=c.subject_id and class_id='"+cls+"' and stream = '"+DropStream.SelectedItem.Text+"' order by subject_name";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						int i=0;
						while(SqlDtr.Read())
						{
							//if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II"))
							if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II")||(DropClass.SelectedItem.Text=="Nursery")||(DropClass.SelectedItem.Text=="LKG")||(DropClass.SelectedItem.Text=="UKG"))
									{
									if(SqlDtr["Subject_Name"].ToString()=="ENGLISH")
									{
									   string[] sub={"Eng.Reading","Eng.Writing","Eng.Conversation","Eng.Spelling","E.Comprehension"};
									   for(int j=0;j<5;j++)
									   {
										   sw.WriteLine(info,GenUtil.TrimLength(sub[j].ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
										   i++;	
										}
							}
							else if(SqlDtr["Subject_Name"].ToString()=="HINDI")
							{
									string[] sub={"H.Reading","H.Writing","H.Conversation","H.Spelling","H.Comprehension"};
									for(int j=0;j<5;j++)
									{
										sw.WriteLine(info,GenUtil.TrimLength(sub[j].ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;			
									}							  }
							else if(SqlDtr["Subject_Name"].ToString()=="MATHEMATICS")
							{
									string[] sub={"MATHS F N","MATHS UBC","MATHS CA"};
									for(int j=0;j<3;j++)
									{
										sw.WriteLine(info,GenUtil.TrimLength(sub[j].ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;
									}
							  }
							 else if(SqlDtr["Subject_Name"].ToString()=="EVS")
							{
									string[] sub={"EVS OBS","EVS ID","EVS KL"};
									for(int j=0;j<3;j++)
									{
										sw.WriteLine(info,GenUtil.TrimLength(sub[j].ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;
									}
							 }
							 else
							 {
								sw.WriteLine(info,GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
								i++;    
							 }
							}

							else
							{
								sw.WriteLine(info,GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),14),grade[i,0].ToString(),grade[i,1].ToString(),grade[i,2].ToString(),grade[i,3].ToString(),grade[i,4].ToString(),grade[i,5].ToString(),grade[i,6].ToString(),grade[i,7].ToString(),grade[i,9].ToString(),grade[i,7].ToString(),grade[i,8].ToString(),GenUtil.TrimLength(sname[i].ToString(),18),avgMarks[i].ToString(),passPer[i].ToString(),GenUtil.TrimLength(tname[i].ToString(),15));	
								i++;
							}
						}
						sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
						SqlDtr.Close();
					}
					else
					{
						MessageBox.Show("Subject Not Available");
						return;
					}
					SqlDtr.Close();
					sw.Close ();
					Print();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click,SubjectWise Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

		/// <summary>
		/// this method use to create connection between remot device.
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
					///CreateLogFiles.ErrorLog("Form:GreenSheetReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  userid  ");
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive+"\\Inetpub\\wwwroot\\eschool\\eschoolprintservice\\SubjectWiseReport.txt<EOF>");
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
					CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click, EXCEPTION   "+ane.Message+"  userid  ");
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click, EXCEPTION   "+se.Message+"  userid  ");
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click, EXCEPTION   "+es.Message+"  userid  ");
				}

			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click,Class:PetrolPumpClass "+" Customerwise Sales Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Btnexcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this method use to excel report. in this method first get subject from classwisesubject table. after that save all marks in an array. find category of marks.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\SubjectWiseReport.xls";
				
				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SubjectWiseReport.txt";
				StreamWriter sw = new StreamWriter(path);
				//20.02.09 if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropStream.SelectedIndex!=0 && DropExamType.SelectedIndex!=0)
				if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0 && DropExamType.SelectedIndex!=0)
				{
					InventoryClass obj=new InventoryClass();
					SqlDataReader SqlDtr=null;
					string cls="";
					/*if(DropClass.SelectedItem.Text=="I")
						cls="1";
					else if(DropClass.SelectedItem.Text=="II")
						cls="2";
					else if(DropClass.SelectedItem.Text=="III")
						cls="3";
					else if(DropClass.SelectedItem.Text=="IV")
						cls="4";
					else if(DropClass.SelectedItem.Text=="V")
						cls="5";
					else if(DropClass.SelectedItem.Text=="VI")
						cls="6";
					else if(DropClass.SelectedItem.Text=="VII")
						cls="7";
					else if(DropClass.SelectedItem.Text=="VIII")
						cls="8";
					else if(DropClass.SelectedItem.Text=="IX")
						cls="9";
					else if(DropClass.SelectedItem.Text=="X")
						cls="10";
					else if(DropClass.SelectedItem.Text=="XI")
						cls="11";
					else if(DropClass.SelectedItem.Text=="XII")
						cls="12";*/

					if(DropClass.SelectedItem.Text.Equals("Nursery"))
						cls="1";
					else if(DropClass.SelectedItem.Text.Equals("LKG"))
						cls="2";
					else if(DropClass.SelectedItem.Text.Equals("UKG"))
						cls="3";
					else if(DropClass.SelectedItem.Text.Equals("I"))
						cls="4";
					else if(DropClass.SelectedItem.Text.Equals("II"))
						cls="5";
					else if(DropClass.SelectedItem.Text.Equals("III"))
						cls="6";
					else if(DropClass.SelectedItem.Text.Equals("IV"))
						cls="7";
					else if(DropClass.SelectedItem.Text.Equals("V"))
						cls="8";
					else if(DropClass.SelectedItem.Text.Equals("VI"))
						cls="9";
					else if(DropClass.SelectedItem.Text.Equals("VII"))
						cls="10";
					else if(DropClass.SelectedItem.Text.Equals("VIII"))
						cls="11";
					else if(DropClass.SelectedItem.Text.Equals("IX"))
						cls="12";
					else if(DropClass.SelectedItem.Text.Equals("X"))
						cls="13";
					else if(DropClass.SelectedItem.Text.Equals("XI"))
						cls="14";
					else if(DropClass.SelectedItem.Text.Equals("XII"))
						cls="15";
						
					string info="";
					string des="+--------------+-----+------+------+------+------+------+------+-----+----+-------+--------------------+--------+----+---------------+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("RESULT AT GLANCE",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------------------",des.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("SUBJECT WISE REPORT For Class:"+DropClass.SelectedItem.Text.Trim()+" Section:"+DropSection.SelectedItem.Text.Trim(),des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------------------------",des.Length));
					sw.WriteLine("") ;
					//sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
					sw.WriteLine("Subject Name  \t  A+ \t  A   \t  B+ \t  B   \t  C+  \t  C   \t  D   \t E  \t    \t    \t     \t                  \t        \t     \t               ");
					sw.WriteLine("              \t95%>=\t85-94%\t75-84%\t65-74%\t55-64%\t45-54%\t40-44%\t<40%\tAbse\tFail\tHigh.\tStudent Name      \tAvg Mark\tPass%\tSubject Teacher");
					//sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
					//             12345678901234 12345 123456 123456 123456 123456 123456 123456 1234 1234 1234 12345 123456789012345678 12345678 12345 123456789012345
					info = " {0,-14:S} {1,5:S} {2,6:S} {3,6:S} {4,6:S} {5,6:S} {6,6:S} {7,6:S} {8,4:S} {9,4:S} {10,4:S} {11,5:S} {12,-18:S} {13,8:S} {14,5:S} {15,-15:S}";
					string str="select subject_name from subject s,classwisesubjects c where s.subject_id=c.subject_id and class_id='"+cls+"' and stream = '"+DropStream.SelectedItem.Text+"' order by subject_name";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.HasRows)
					{
						int i=0;
						while(SqlDtr.Read())
						{
							//if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II"))
							if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II")||(DropClass.SelectedItem.Text=="Nursery")||(DropClass.SelectedItem.Text=="LKG")||(DropClass.SelectedItem.Text=="UKG"))
							{
								if(SqlDtr["Subject_Name"].ToString()=="ENGLISH")
								{
									string[] sub={"Eng.Reading","Eng.Writing","Eng.Conversation","Eng.Spelling","E.Comprehension"};
									for(int j=0;j<5;j++)
									{
										sw.WriteLine(GenUtil.TrimLength(sub[j].ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;	
									}
								}
								else if(SqlDtr["Subject_Name"].ToString()=="HINDI")
								{
									string[] sub={"H.Reading","H.Writing","H.Conversation","H.Spelling","H.Comprehension"};
									for(int j=0;j<5;j++)
									{
										sw.WriteLine(GenUtil.TrimLength(sub[j].ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;			
									}							  
								}
								else if(SqlDtr["Subject_Name"].ToString()=="MATHEMATICS")
								{
									string[] sub={"MATHS F N","MATHS UBC","MATHS CA"};
									for(int j=0;j<3;j++)
									{
										sw.WriteLine(GenUtil.TrimLength(sub[j].ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;
									}
								}
								else if(SqlDtr["Subject_Name"].ToString()=="EVS")
								{
									string[] sub={"EVS OBS","EVS ID","EVS KL"};
									for(int j=0;j<3;j++)
									{
										sw.WriteLine(GenUtil.TrimLength(sub[j].ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
										i++;
									}
								}
								else
								{
									sw.WriteLine(GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
									i++;    
								}
							}
							else
							{
								sw.WriteLine(GenUtil.TrimLength(SqlDtr.GetValue(0).ToString(),14)+"\t"+grade[i,0].ToString()+"\t"+grade[i,1].ToString()+"\t"+grade[i,2].ToString()+"\t"+grade[i,3].ToString()+"\t"+grade[i,4].ToString()+"\t"+grade[i,5].ToString()+"\t"+grade[i,6].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,9].ToString()+"\t"+grade[i,7].ToString()+"\t"+grade[i,8].ToString()+"\t"+GenUtil.TrimLength(sname[i].ToString(),18)+"\t"+avgMarks[i].ToString()+"\t"+passPer[i].ToString()+"\t"+GenUtil.TrimLength(tname[i].ToString(),15));	
								i++;
							}
						}
						//sw.WriteLine("+--------------+-----+------+------+------+------+------+------+----+----+----+-----+------------------+--------+-----+---------------+");
						SqlDtr.Close();
					}
					else
					{
						MessageBox.Show("Subject Not Available");
						return;
					}
					SqlDtr.Close();
					sw.Close ();
					//Print();
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog("Form:SubjectWiseReport,Method: btnprint_Click,SubjectWise Report Printed "+"  EXCEPTION   "+ex.Message+"  userid  ");
			}
		}

	}
}
