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
using RMG;
using eschool.Classes;
using System.Data.SqlClient;
using DBOperations;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
# endregion

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for ResultGlance.
	/// </summary>
	public class ResultGlance : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.DropDownList Dropexamtype;
		public static string NoofStudent="0";
		public static  string StudentAbsent="0";
		public static  int FailStudent=0;
		public static  int PassedStudent=0;
		public static  int AppearedStudent=0;
		public static  double passPercentage=0;
		public static  double grandTotal=0;
		public static  int gradeAp=0;
		public static  int gradeA=0;
		public static  int gradeBp=0;
		public static  int gradeB=0;
		public static  int gradeCp=0;
		public static  int gradeC=0;
		public static  int gradeD=0;
		public static  int gradeE=0;
		public static string[] sub=new string[25];
		public static ArrayList Subject=new ArrayList();
		public static ArrayList fail=new ArrayList();
		bool flag1=false;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Button Btnexcel;
		public string StudentAppered="";
		protected System.Web.UI.WebControls.Panel panglsnce;
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
				CreateLogFiles.ErrorLog ("Form: ResultGlance.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			if(!Page.IsPostBack)
			{
				//txtheldfrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;//add by vikas sharma date on 06.10.07
				//txtheldto.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year; //add by vikas sharma date on 06.10.07
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				string str="select class_name from class order by class_id";
				SqlDtr=obj.GetRecordSet(str);
				DropClass.Items.Clear();
				DropClass.Items.Add("Select");
				while(SqlDtr.Read())
				{
					DropClass.Items.Add(SqlDtr.GetValue(0).ToString());
				}
				SqlDtr.Close();

			}
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="30";
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
					//10.05.08--Response.Redirect("../AccessDeny.aspx");
					Response.Redirect("/eschool/AccessDeny.aspx",false);
				}
				if(View_flag=="False")
				{
					btnShow.Enabled=false;
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
			this.Dropexamtype.SelectedIndexChanged += new System.EventHandler(this.Dropdownlist1_SelectedIndexChanged);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this method use to show report. first count total number of student from student_record table. after that get subject from classwisesubject table.
		/// after that get total absent student from StudentmarksentryIandII or studentmarks table. after that found total fail student with the help of result() function.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			if(DropClass.SelectedIndex!=0 && DropSec.SelectedIndex!=0 && Dropexamtype.SelectedIndex!=0 && DropSession.SelectedIndex!=0)
			{
				panglsnce.Visible=true;
				NoofStudent="0";
				StudentAbsent="0";
				FailStudent=0;
				PassedStudent=0;
				AppearedStudent=0;
				passPercentage=0;
				grandTotal=0;
				gradeAp=0;
				gradeA=0;
				gradeBp=0;
				gradeB=0;
				gradeCp=0;
				gradeC=0;
				gradeD=0;
				gradeE=0;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr;
				///07.10.08 string str="Select count(*) from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSec.SelectedItem.Text+"'";
				//05.11.08 string str="Select count(*) from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSec.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
				string str="Select count(*) from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSec.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"' and Student_Stream='"+DropStream.SelectedItem.Text+"'";
				SqlDtr=obj.GetRecordSet(str);
				if(SqlDtr.Read())
				{
					NoofStudent=SqlDtr.GetValue(0).ToString();
				}
				SqlDtr.Close();
				InventoryClass obj1=new InventoryClass();
				InventoryClass obj2=new InventoryClass();
				SqlDataReader SqlDtr1;
				string str2="";
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
				Subject.Clear();
				string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"') ";
				SqlDtr=obj1.GetRecordSet(str1);
				string col="";
				string name="";
				while(SqlDtr.Read())
				{
					name=SqlDtr.GetValue(0).ToString().Trim();
					if(name.IndexOf(" ")>0)
						name=name.Replace(" ","_");
					if(name.IndexOf("&")>0)
						name=name.Replace("&","and");
					if(name.Equals("COMPUTER"))
						//name=name + "_th='A' and " +name + "_pr='A' and " + name +  "_tot";
						name=name +  "_tot";
					if(name.Equals("PHYSICS"))
						name=name + "_th='A' and " + name + "_pr='A' and "+ name+ "_tot";
					if(name.Equals("BIOLOGY"))
						name=name+"_th='A' and " + name + "_pr='A' and "+name+ "_tot";
					if(name.Equals("CHEMISTRY"))
						name=name+"_th='A' and " + name + "_pr='A' and "+ name + "_tot" ;
					col=col+name;
					col=col+" ='A' and ";
					Subject.Add(name);
				}	
				SqlDtr.Close();
				//if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II")
				if(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")
				{
					///07.10.08 str2="select count(*) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass .SelectedItem.Text+"' and sr.Stream= '"+ DropStream .SelectedItem.Text  +"' and st.exam_type='"+Dropexamtype.SelectedItem.Text +"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and Eng_Read='A' and Eng_Writing ='A' and Eng_Con ='A' and Eng_Spelling ='A' and Eng_Compre ='A' and Hindi_Read ='A' and Hindi_Writing ='A' and Hindi_Con ='A' and Hindi_spelling ='A' and Hindi_Com ='A' and Math_FNumber ='A' and Math_BConcept ='A' and Math_Computation ='A' and evs_observation ='A' and evs_Identification ='A' and Evs_know ='A' and Phy_edu ='A' and Music='A' and Art='A' and Craft ='A' and Dance='A' and st.Computer_tot='A'";
					str2="select count(*) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass .SelectedItem.Text+"' and sr.Stream= '"+ DropStream .SelectedItem.Text  +"' and st.exam_type='"+Dropexamtype.SelectedItem.Text +"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and Eng_Read='A' and Eng_Writing ='A' and Eng_Con ='A' and Eng_Spelling ='A' and Eng_Compre ='A' and Hindi_Read ='A' and Hindi_Writing ='A' and Hindi_Con ='A' and Hindi_spelling ='A' and Hindi_Com ='A' and Math_FNumber ='A' and Math_BConcept ='A' and Math_Computation ='A' and evs_observation ='A' and evs_Identification ='A' and Evs_know ='A' and Phy_edu ='A' and Music='A' and Art='A' and Craft ='A' and Dance='A' and st.Computer_tot='A' and st.year='"+DropSession.SelectedItem.Text+"'";
					SqlDtr1=obj2.GetRecordSet(str2);
					while(SqlDtr1.Read())
					{
						StudentAbsent= SqlDtr1.GetValue(0).ToString();
					}
					SqlDtr1.Close();	
					FailStudent=result();
					if(!NoofStudent.Equals("")&&!StudentAbsent.Equals("")&& flag1==true)
					{
						AppearedStudent=System.Convert.ToInt32(NoofStudent)-System.Convert.ToInt32(StudentAbsent);
						PassedStudent=AppearedStudent-FailStudent;
						passPercentage=(PassedStudent/System.Convert.ToDouble(NoofStudent))*100;
						passPercentage=System.Convert.ToDouble(GenUtil.strNumericFormat(passPercentage.ToString()));
						studentGrade();
					}
					else
					{
						AppearedStudent=0;
						PassedStudent=0;
						passPercentage=0;
						MessageBox.Show("Insufficient data");
					}
				}
				else
				{
					///07.10.08 str2="select count(*) from studentmarks where " + col.ToLower() +" class='"+DropClass.SelectedItem.Text+"'and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";
					str2="select count(*) from studentmarks where " + col.ToLower() +" class='"+DropClass.SelectedItem.Text+"'and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
					SqlDtr1=obj2.GetRecordSet(str2);
					while(SqlDtr1.Read())
					{
						StudentAbsent= SqlDtr1.GetValue(0).ToString();
					}
					SqlDtr1.Close();	
					FailStudent=result();
					if(!NoofStudent.Equals("")&&!StudentAbsent.Equals("")&& flag1==true)
					{
						AppearedStudent=System.Convert.ToInt32(NoofStudent)-System.Convert.ToInt32(StudentAbsent);
						PassedStudent=AppearedStudent-FailStudent;
						passPercentage=(PassedStudent/System.Convert.ToDouble(NoofStudent))*100;
						passPercentage=System.Convert.ToDouble(GenUtil.strNumericFormat(passPercentage.ToString()));
						studentGrade();
					}
					else
					{
						AppearedStudent=0;
						PassedStudent=0;
						passPercentage=0;
						MessageBox.Show("Insufficient data");
					}
				}
			}
			else if(DropClass.SelectedIndex==0)
			{
				MessageBox.Show("Please Select Class");
			}
			else if(DropSec.SelectedIndex==0)
			{
				MessageBox.Show("Please Select Section");
			}
			else if(Dropexamtype.SelectedIndex==0)
			{
				MessageBox.Show("Please Select Exam Type");
			}
			else if(DropSession.SelectedIndex==0)
			{
				MessageBox.Show("Please Select Session");
			}
		}

		/// <summary>
		/// this method use to check student fail or pass. first get subject from classwisesubject table. after that get marks from exammarks table
		/// and studentmarksentryIandII or studentmarks table.and check if students marks greter then or equal to 40% of total. if true then student pass else fail. 
		/// </summary>
		int result()
		{
			double marks=0;
			double[]max=new double[25];
			double Passing_marks=0;
			int c=0;
			int i=0;
			bool flag=true;
    		InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			InventoryClass obj3=new InventoryClass();
			SqlDataReader SqlDtr=null,SqlDtr1=null,SqlDtr2=null;
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

			string str1="";
			string str2="",str3="",str4="";
			string col="";
			string name="";
			//if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"))
			if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
			{
				str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"')";
				SqlDtr=obj1.GetRecordSet(str1);
				while(SqlDtr.Read())
				{
					name=SqlDtr.GetValue(0).ToString().Trim();
					if(name.IndexOf(" ")>0)
						name=name.Replace(" ","_");
					if(name.IndexOf("&")>0)
						name=name.Replace("&","and");
					if(name.Equals("COMPUTER"))
						//name=name + "_th, " +name + "_pr ";
						name=name +  "_tot";
					if(name.Equals("PHYSICS"))
						name=name + "_th, " + name + "_pr ";
					if(name.Equals("BIOLOGY"))
						name=name+"_th, " + name + "_pr";
					if(name.Equals("CHEMISTRY"))
						name=name+"_th, " + name + "_pr " ;
					col=col+name;
					col=col+",";
					
				}
				if(col.Length>0)
					col=col.Substring(0,col.Length-1);
				else
				{
					AppearedStudent=0;
					PassedStudent=0;
					passPercentage=0;
					
					return 0;
				}
				SqlDtr.Close();

			}
			//if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"))
			if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
			{
				///07.10.08 str2="select "+ col +" from studentmarks where  class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";
				///07.10.08 str3="select "+ col+ " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";
				str2="select "+ col +" from studentmarks where  class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
				str3="select "+ col+ " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
				///str4="select roleno, "+ col +" from studentmarks where  class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";

			}
			else
			{
				str2="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'"; //for class I and II
				str3="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot  from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
				///07.10.08 str2="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //for class I and II
				///07.10.08 str3="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot  from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";
				///str4="select st.rollno, Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //for class I and II
			}
			SqlDtr1=obj2.GetRecordSet(str2);
			SqlDtr=obj1.GetRecordSet(str3);
			///SqlDtr2=obj3.GetRecordSet(str4);
			int n=0;
			while(SqlDtr.Read())
			{
				n=SqlDtr.FieldCount;
				for(i=0;i<n;i++)
				{
					sub[i]=SqlDtr1.GetName(i);
					///sub[i]=SqlDtr.GetName(i);
					if(!SqlDtr.GetValue(i).ToString().Equals(""))
					max[i]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
					grandTotal=grandTotal+max[i];
				}
			}
			if(n==0)
			{
				AppearedStudent=0;
				PassedStudent=0;
				passPercentage=0;
				return 0 ;
			}
			double test=0;
			int a=0;
			while(SqlDtr1.Read())
			{
				flag1=true;
				test=0;
				for(int j=0;j<i;j++)
				{
					flag=true;
					if(!SqlDtr1.GetValue(j).ToString().Equals("")&&!SqlDtr1.GetValue(j).ToString().Equals("A"))
					{
						marks=System.Convert.ToDouble(SqlDtr1.GetValue(j).ToString());
						//double hhhk=max[j];
						//max[j]=(max[j]*40)/100;
						Passing_marks=(max[j]*40)/100;
						//double aaaa=max[j];
						//if(marks<max[j])
						if(marks<Passing_marks)
						{
							flag=false;
							
						}
						else
						{
							test=test+marks;
						}
						if(flag==false)
						{
							c++;
							if(c>=2)break;
						}
						if(j==i-1)
							if(test>=350&& test<600)
								a++;
					}
				}
					
				if(c>=2)
				{
					FailStudent++;
					c=0;
				}	
			}

			//5.11.08 if(flag1==false)
				//5.11.08 MessageBox.Show("Data may be not available");
			SqlDtr1.Close();
			SqlDtr.Close();
			return FailStudent;
		}

		/// <summary>
		/// this method use to check student grade of student. first get subject from classwisesubject table. after that get marks from exammarks table
		/// and studentmarksentryIandII or studentmarks table.and check garde of students total marks. 
		/// </summary>
		void studentGrade()
		{	
			int no_sub=0;
			//add by vikas sharma 26.09.08
			string cls="";
			InventoryClass obj4=new InventoryClass();
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


			string name="",col="";
			SqlDataReader SqlDtr=null;
			string str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"')";
			SqlDtr=obj4.GetRecordSet(str1);
			while(SqlDtr.Read())
			{
				name=SqlDtr.GetValue(0).ToString().Trim();
				if(name.IndexOf(" ")>0)
					name=name.Replace(" ","_");
				if(name.IndexOf("&")>0)
					name=name.Replace("&","and");
				if(name.Equals("COMPUTER"))
				{
					//name=name + "_th, " +name + "_pr ";
					name=name +  "_tot";
					no_sub++;
				}
				else if(name.Equals("PHYSICS"))
				{
					name=name + "_th, " + name + "_pr ";
					no_sub+=2;
				}
				else if(name.Equals("BIOLOGY"))
				{
					name=name+"_th, " + name + "_pr";
					no_sub+=2;
				}
				else if(name.Equals("CHEMISTRY"))
				{
					name=name+"_th, " + name + "_pr " ;
					no_sub+=2;
				}
				else
				{
					no_sub++;
				}
				col=col+name;
				col=col+",";
			}
			//***************************
			InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader SqlDtr1,SqlDtr2;
			//string str1="";
			double marks=0;
			int	c1=0;
			string studentroll="";
			
			//if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"))
			if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
			{   
				
				//str1="select cast(total as float) from studentmarks where  class='"+DropClass.SelectedItem.Text+"'and st_section='"+DropSec.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "' and Exam_Type= '"+Dropexamtype.SelectedItem.Text+"'";
				///07.10.08 str1="select st.roleno from studentmarks st,student_roll sr,Student_Record s where st.Roleno=sr.studentid and st.Roleno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //
				str1="select st.roleno from studentmarks st,student_roll sr,Student_Record s where st.Roleno=sr.studentid and st.Roleno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'";
				SqlDtr1=obj1.GetRecordSet(str1);
				while(SqlDtr1.Read())
				{
					marks=0;
					studentroll=SqlDtr1.GetValue(0).ToString();
					//*****************09.09.08
					//for(int i=0;i<22 ;i++)
					//26.09.08 for(int i=0;i<Subject.Count ;i++)
					for(int i=0;i<no_sub;i++)
					{
						
						
							//string str2="select  cast("+sub[i].ToString() +" as float) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.rollno='"+SqlDtr1.GetValue(0).ToString()+"'";// and Eng_Writing !='A' and Eng_Con !='A' and Eng_Spelling !='A' and Eng_Compre !='A' and Hindi_Read !='A' and Hindi_Writing !='A' and Hindi_Con !='A' and Hindi_spelling !='A' and Hindi_Com !='A' and Math_FNumber !='A' and Math_BConcept !='A' and Math_Computation !='A' and evs_observation !='A' and evs_Identification !='A' and Evs_know !='A' and Phy_edu !='A' and Music!='A' and Art!='A' and Craft !='A' and Dance!='A' and st.Computer_tot!='A'";
							///07.10.08 string str2="select  cast("+sub[i].ToString() +" as float) from studentmarks st,student_roll sr,Student_Record s where st.Roleno=sr.studentid and st.Roleno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.roleno='"+SqlDtr1.GetValue(0).ToString()+"'";// and Eng_Writing !='A' and Eng_Con !='A' and Eng_Spelling !='A' and Eng_Compre !='A' and Hindi_Read !='A' and Hindi_Writing !='A' and Hindi_Con !='A' and Hindi_spelling !='A' and Hindi_Com !='A' and Math_FNumber !='A' and Math_BConcept !='A' and Math_Computation !='A' and evs_observation !='A' and evs_Identification !='A' and Evs_know !='A' and Phy_edu !='A' and Music!='A' and Art!='A' and Craft !='A' and Dance!='A' and st.Computer_tot!='A'";
							string str2="select  cast("+sub[i].ToString() +" as float) from studentmarks st,student_roll sr,Student_Record s where st.Roleno=sr.studentid and st.Roleno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.roleno='"+SqlDtr1.GetValue(0).ToString()+"' and st.year='"+DropSession.SelectedItem.Text+"'";
							SqlDtr2=obj2.GetRecordSet(str2);
							while(SqlDtr2.Read())
							{
								if(!SqlDtr2.GetValue(0).ToString().Equals("")||!SqlDtr2.GetValue(0).ToString().Equals("A"))
								{
									marks+=System.Convert.ToDouble(SqlDtr2.GetValue(0).ToString());
								}
							}
							SqlDtr2.Close();
						
					}
					//******************
					//if(!SqlDtr1.GetValue(0).ToString().Equals("")||!SqlDtr1.GetValue(0).ToString().Equals("A"))
					//{
						//marks=System.Convert.ToDouble(SqlDtr1.GetValue(0).ToString());
					if(!(fail.Contains(studentroll)))
					{
						if(marks>=(grandTotal*95)/100)
							gradeAp++;
						else if((marks>=(grandTotal*85)/100)&& (marks<(grandTotal*95)/100))
							gradeA++;
						else if((marks>=(grandTotal*75)/100)&& (marks<(grandTotal*85)/100))
							gradeBp++;
						else if((marks>=(grandTotal*65)/100)&& (marks<(grandTotal*75)/100))
							gradeB++;
						else if((marks>=(grandTotal*55)/100)&& (marks<(grandTotal*65)/100))
							gradeCp++;
						else if((marks>=(grandTotal*45)/100)&& (marks<(grandTotal*55)/100))
							gradeC++;
						else if((marks>=(grandTotal*40)/100)&& (marks<(grandTotal*45)/100))
							gradeD++;
						else if((marks<(grandTotal*40)/100))
							gradeE++;
					}
					else
					{
						gradeE++;
					}
					//}
							
					c1++;						
						
				}
				SqlDtr1.Close();
			}
			else
			{
				
				///07.10.08 str1="select st.rollno FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"'"; //for class I and II
				str1="select st.rollno FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and st.year='"+DropSession.SelectedItem.Text+"'"; 
				SqlDtr1=obj1.GetRecordSet(str1);
				while(SqlDtr1.Read())
				{
					marks=0;
					studentroll=SqlDtr1.GetValue(0).ToString();
					for(int i=0;i<22 ;i++)
					{
						
						///07.10.08 string str2="select  cast("+sub[i].ToString() +" as float) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.rollno='"+SqlDtr1.GetValue(0).ToString()+"'";// and Eng_Writing !='A' and Eng_Con !='A' and Eng_Spelling !='A' and Eng_Compre !='A' and Hindi_Read !='A' and Hindi_Writing !='A' and Hindi_Con !='A' and Hindi_spelling !='A' and Hindi_Com !='A' and Math_FNumber !='A' and Math_BConcept !='A' and Math_Computation !='A' and evs_observation !='A' and evs_Identification !='A' and Evs_know !='A' and Phy_edu !='A' and Music!='A' and Art!='A' and Craft !='A' and Dance!='A' and st.Computer_tot!='A'";
						string str2="select  cast("+sub[i].ToString() +" as float) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and st.exam_type='"+Dropexamtype.SelectedItem.Text+"'  and sr.st_section = '"+DropSec.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.rollno='"+SqlDtr1.GetValue(0).ToString()+"' and st.year='"+DropSession.SelectedItem.Text+"'";
						SqlDtr2=obj2.GetRecordSet(str2);
						while(SqlDtr2.Read())
						{
							if(!SqlDtr2.GetValue(0).ToString().Equals("")||!SqlDtr2.GetValue(0).ToString().Equals("A"))
							{
								marks+=System.Convert.ToDouble(SqlDtr2.GetValue(0).ToString());
							}
						}
						SqlDtr2.Close();
					}
					if(!(fail.Contains(studentroll)))
					{
						if(marks>=(grandTotal*95)/100)
							gradeAp++;
						else if((marks>=(grandTotal*85.0)/100)&& (marks<(grandTotal*95.0)/100))
							gradeA++;
						else if((marks>=(grandTotal*75.0)/100)&& (marks<(grandTotal*85.0)/100))
							gradeBp++;
						else if((marks>=(grandTotal*65.0)/100)&& (marks<(grandTotal*75.0)/100))
							gradeB++;
						else if((marks>=(grandTotal*55.0)/100)&& (marks<(grandTotal*65.0)/100))
							gradeCp++;
						else if((marks>=(grandTotal*45.0)/100)&& (marks<(grandTotal*55.0)/100))
							gradeC++;
						else if((marks>=(grandTotal*40.0)/100)&& (marks<(grandTotal*45.0)/100))
							gradeD++;
						else if((marks<(grandTotal*40.0)/100))
							gradeE++;
					}
					else
					{
						gradeE++;
					}
				c1++;
			}

				SqlDtr1.Close();
						
			}
		
		}
		
			
			
		private void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// this Method use to create the connection between remote device.
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
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2); 
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ResultGlance.txt<EOF>");
					/// Send the data through the socket.
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
					CreateLogFiles.ErrorLog(" Form :ResultGlance.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :ResultGlance.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :ResultGlance.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :ResultGlance.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
								
			}
		}

		/// <summary>
		/// this Method use to create report in text format. and in this method use globle variable which all ready has value.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ResultGlance.txt";
			StreamWriter sw = new StreamWriter(path);
			sw.WriteLine("						----------------------");
			sw.WriteLine("						  RESULT AT A GLANCE"  );
			sw.WriteLine("						----------------------");
			string info1="";
			info1 = "{0,-12:S} {1,-15:S} {2,-10:S} {3,-20:S}";
			sw.WriteLine(info1,"    Class : ",DropClass.SelectedItem.Text,"Section : ",DropSec.SelectedItem.Text);
			sw.WriteLine("");
			//sw.WriteLine(info1,"Held From : ",txtheldfrom .Text,"Held To : ",txtheldto.Text ,"Exam Type:",Dropexamtype.SelectedItem .Text);
			sw.WriteLine("+--------------+---------+---------+---------+------------+-------------------------------+");
			sw.WriteLine("|    No Of     |  No Of  |  No Of  |  No Of  |   Pass     |        Record Of Grades       |");
			sw.WriteLine("|   Student    | Student | Student | Student | Percentage |---+---+---+---+---+---+---+---+");
			sw.WriteLine("| In The Class |  Absent | Appered | Passed  |            |A+ | A |B+ | B |C+ | C | D | E |");
			sw.WriteLine("+--------------+---------+---------+---------+------------+---+---+---+---+---+---+---+---+");
			//             12345678901234 123456789 123456789 123456789 123456789012 123 123 123 123 123 123 123
			info=" {0,-14:S} {1,9:S} {2,9:S} {3,9:S} {4,12:S} {5,3:S} {6,3:S} {7,3:S} {8,3:S} {9,3:S} {10,3:S} {11,3:S} {12,3:S}";
			LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
			
			sw.WriteLine(info,NoofStudent.ToString(),StudentAbsent.ToString(),AppearedStudent.ToString(),PassedStudent.ToString(),passPercentage.ToString(),gradeAp.ToString(),gradeA.ToString(),gradeBp.ToString(),gradeB.ToString(),gradeCp.ToString(),gradeC.ToString(),gradeD.ToString(),gradeE.ToString());
			sw.WriteLine("+--------------+---------+---------+---------+------------+---+---+---+---+---+---+---+---+");
			sw.Close ();							
			Print();
			CreateLogFiles.ErrorLog(" Form :ResultGlance.aspx,Method  btnPrint_ServerClick,  Result At A Glance Report Printed , Userid :  "+ pass   );					
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
		/// this Method use to create report in text format. and in this method use globle variable which all ready has value.
		/// </summary>
		public void ConvertIntoExcel()
		{
			string home_drive = Environment.SystemDirectory;
			home_drive = home_drive.Substring(0,2);
			string info = "";
			string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
			Directory.CreateDirectory(strExcelPath);
			string path = home_drive+@"\eSchool_ExcelFile\ResultGlance.xls";

			//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ResultGlance.txt";
			StreamWriter sw = new StreamWriter(path);
			sw.WriteLine("						----------------------");
			sw.WriteLine("						  RESULT AT A GLANCE"  );
			sw.WriteLine("						----------------------");
			string info1="";
			info1 = "{0,-12:S} {1,-15:S} {2,-10:S} {3,-20:S}";
			sw.WriteLine(info1,"    Class : ",DropClass.SelectedItem.Text,"Section : ",DropSec.SelectedItem.Text);
			sw.WriteLine("");
			//sw.WriteLine(info1,"Held From : ",txtheldfrom .Text,"Held To : ",txtheldto.Text ,"Exam Type:",Dropexamtype.SelectedItem .Text);
			//sw.WriteLine("+--------------+---------+---------+---------+------------+-------------------------------+");
			sw.WriteLine(" No Of\tNo Of \tNo Of \tNo Of \tPass \t\t\tRecord Of Grades\t\t\t ");
			sw.WriteLine(" Student\tStudent\tStudent\tStudent\tPercentage \t\t\t\t\t\t\t\t");
			sw.WriteLine(" In The Class\tAbsent\tAppered\tPassed \t\tA+\t A \tB+\tB\tC+\tC\tD\tE\t");
			//sw.WriteLine("+--------------+---------+---------+---------+------------+---+---+---+---+---+---+---+---+");
			//             12345678901234 123456789 123456789 123456789 123456789012 123 123 123 123 123 123 123
			info=" {0,-14:S} {1,9:S} {2,9:S} {3,9:S} {4,12:S} {5,3:S} {6,3:S} {7,3:S} {8,3:S} {9,3:S} {10,3:S} {11,3:S} {12,3:S}";
			LibraryClass.ItemClass obj=new LibraryClass .ItemClass();
			
			sw.WriteLine(NoofStudent.ToString()+"\t"+StudentAbsent.ToString()+"\t"+AppearedStudent.ToString()+"\t"+PassedStudent.ToString()+"\t"+passPercentage.ToString()+"\t"+gradeAp.ToString()+"\t"+gradeA.ToString()+"\t"+gradeBp.ToString()+"\t"+gradeB.ToString()+"\t"+gradeCp.ToString()+"\t"+gradeC.ToString()+"\t"+gradeD.ToString()+"\t"+gradeE.ToString());
			//sw.WriteLine("+--------------+---------+---------+---------+------------+---+---+---+---+---+---+---+---+");
			sw.Close ();
		}
	}
	
}

