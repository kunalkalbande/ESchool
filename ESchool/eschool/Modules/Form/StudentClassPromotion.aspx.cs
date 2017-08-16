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

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for StudentMarksReport.
	/// </summary>
	public class StudentClassPromotion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.DropDownList DropSession;
		protected System.Web.UI.WebControls.Button btnShow;
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
        public bool flag1=false,flage=false;
		public string StudentAppered="";
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
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentMarksReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				Response.Redirect("/eschool/Modules/Form/HolidayEntryForm.aspx",false); 
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string str="Select class_name from class order by class_id";
					SqlDtr= obj.GetRecordSet(str);
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
					string SubModule="35";
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
						//10.05.08--Response.Redirect("../AccessDeny.aspx");
						Response.Redirect("/eschool/AccessDeny.aspx",false);
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog ("Form: StudentMarksReport.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
		}
		#endregion

		/// <summary>
		/// This method use to make true value of flage. after that html part excute.
		/// </summary>
		private void btnShow_Click(object sender, System.EventArgs e)
		{
			flage=true;
		}

		/// <summary>
		/// In this method first get total of each student marks and check greade.if student belongs class nursery to class II data fetch from studentmarksentryIandII table else from exammarks.
		/// </summary>
		void studentGrade()
		{
			InventoryClass obj1=new InventoryClass();
			InventoryClass obj2=new InventoryClass();
			SqlDataReader SqlDtr1,SqlDtr2;
			string str1="";
			double marks=0;
			int	c1=0;
			//if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"))
			if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"))
			{
				str1="select cast(total as float) from studentmarks where  class='"+DropClass.SelectedItem.Text+"'and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "'";
				SqlDtr1=obj1.GetRecordSet(str1);
				while(SqlDtr1.Read())
				{
					if(!SqlDtr1.GetValue(0).ToString().Equals("")||!SqlDtr1.GetValue(0).ToString().Equals("A"))
					{
						marks=System.Convert.ToDouble(SqlDtr1.GetValue(0).ToString());
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
					c1++;						
				}
				SqlDtr1.Close();
			}
			else
			{
				str1="select st.rollno FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and sr.st_section = '"+DropSection.SelectedItem.Text+"'"; //for class I and II
				SqlDtr1=obj1.GetRecordSet(str1);
				while(SqlDtr1.Read())
				{
					marks=0;
					for(int i=0;i<22 ;i++)
					{
						string str2="select  cast("+sub[i].ToString() +" as float) FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and sr.st_section = '"+DropSection.SelectedItem.Text+"' and "+sub[i].ToString()+"!='A' and  st.rollno='"+SqlDtr1.GetValue(0).ToString()+"'";// and Eng_Writing !='A' and Eng_Con !='A' and Eng_Spelling !='A' and Eng_Compre !='A' and Hindi_Read !='A' and Hindi_Writing !='A' and Hindi_Con !='A' and Hindi_spelling !='A' and Hindi_Com !='A' and Math_FNumber !='A' and Math_BConcept !='A' and Math_Computation !='A' and evs_observation !='A' and evs_Identification !='A' and Evs_know !='A' and Phy_edu !='A' and Music!='A' and Art!='A' and Craft !='A' and Dance!='A' and st.Computer_tot!='A'";
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
							
					c1++;
				}
				SqlDtr1.Close();
			}
		}

		/// <summary>
		/// this method use to get result if student not belongs nursary to class II then first get subjects of this class from classwisesubject table.
		/// else subject not required. after that fetch the each students marks from studentmarks or studentmarksentryIandII table and check students marks
		/// above the 40%. if condition is true then pass in a subject other wise fail.if any person fail more then one subjects then he is fail in the class. 
		/// this method return failstudent.
		/// </summary>
		int result()
		{
			double marks=0;
			double[]max=new double[25];
			int c=0;
			int i=0;
			bool flag=true;
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

			string str1="";
			string str2="",str3="";
			string col="",col1="";
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
						name=name + "_tot";
					if(name.Equals("PHYSICS"))
						name=name + "_th, " + name + "_pr ";
					if(name.Equals("BIOLOGY"))
						name=name+"_th, " + name + "_pr";
					if(name.Equals("CHEMISTRY"))
						name=name+"_th, " + name + "_pr " ;
					col=col+"sum(cast("+name;
					col=col+" as float)),";
					col1=col1+name;
					col1=col1+",";
					
				}
				
				if(col.Length>0 && col1.Length>0)
				{
					col=col.Substring(0,col.Length-1);
					col1=col1.Substring(0,col1.Length-1);
				}
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
			if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"||DropClass.SelectedItem.Text=="Nursery"))
			{
				str2="select "+ col +" from studentmarks where  class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and stream='"+ DropStream.SelectedItem.Text + "'";
				str3="select "+ col1+ " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "'";
			}
			else
			{
				str2="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot  FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+ DropStream.SelectedItem.Text + "' and sr.st_section = '"+DropSection.SelectedItem.Text+"'"; 
				str3="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot  from Exammarksdecision where class='"+DropClass.SelectedItem.Text+ "' and stream='"+ DropStream.SelectedItem.Text + "'";
			}
			SqlDtr1=obj2.GetRecordSet(str2);
			SqlDtr=obj1.GetRecordSet(str3);
			int n=0;
			while(SqlDtr.Read())
			{
				n=SqlDtr.FieldCount;
				for(i=0;i<n;i++)
				{
    				sub[i]=SqlDtr1.GetName(i);
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
						max[j]=(marks*40)/100;
						if(marks<max[j])
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
			if(flag1==false)
				MessageBox.Show("Data may be not available");
			SqlDtr1.Close();
			SqlDtr.Close();
			return FailStudent;
		}
	}
}
