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
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for StudentMarksReport.
	/// </summary>
	public class StudentMarksReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.DropDownList DropStream;
		protected System.Web.UI.WebControls.DropDownList DropExamType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button Btnexcel;
		protected System.Web.UI.WebControls.Button btnShow;
		public int count1=0;
		public static double[] gtotal=new double[100] ;
		public static string[] rank=new string[100] ;
		public static string[] Subject=null;
		public static double total=0;
		public bool flage=false;
		protected System.Web.UI.WebControls.Button btnEdit;
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
				//Response.Redirect("/eschool/form/HolidayEntryForm.aspx",false); 
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					EmployeeClass obj=new EmployeeClass();
					SqlDataReader SqlDtr;
					string str="Select class_name from class order by class_Id";
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
					string SubModule="34";
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

		/// <summary>
		/// this method use to generate a report in text format. first get marks from exammarksdecision table. and save in array. after that fetch marks from studentmarksentryIandII table. and check grade and save another array. and calculate rank and persentage.
		/// </summary>
		public void btnSubmit_Click(object sender, System.EventArgs e)
		{
			flage=true;
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string sql;
				int Prod_No=0,Group=1,Count=0,pp=0;
				string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentMarksReport.txt";
				StreamWriter sw = new StreamWriter(path);
				
				if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))
				{
				
					sw.Write((char)27);//added by vishnu
					sw.Write((char)67);//added by vishnu
					sw.Write((char)0);//added by vishnu
					sw.Write((char)12);//added by vishnu
					sw.Write((char)27);//added by vishnu
					sw.Write((char)78);//added by vishnu
					sw.Write((char)5);//added by vishnu
					sw.Write((char)27);//added by vishnu
					sw.Write((char)15);
					
					string info="";
					string des="+-------+--------+--------+------------------+----------------+----------------+---------+---------+-------------------------------+";
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("STUDENT MARKS REPORT",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSection.SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text+",  ExamType : "+DropExamType.SelectedItem.Text);
					sw.WriteLine("") ;
				
					sw.WriteLine("+-------+--------+--------+------------------+----------------+----------------+---------+---------+-------------------------------+");
					sw.WriteLine("|Roll No|Category|Adm. No.|Student Name      |    ENGLISH     |     HINDI      |  MATHS  |   EVS   |        NON SCHOLASTIC         |");
					sw.WriteLine("|                                            |RR|WR|CON|SP|COM|RR|WR|CON|SP|COM|FN|UBC|CA|OBS|ID|KL|Ph.Edu|Music|Art|Craft|Dance|CS|");
					sw.WriteLine("+-------+--------+--------+------------------+--+--+---+--+---+--+--+---+--+---+--+---+--+---+--+--+------+-----+---+-----+-----+--+");
					//             1234567 12345678 12345678 123456789012345678 12 12 123 12 123 12 12 123 12 123 12 123 12 123 12 12 123456 12345 123 12345 12345 12
			
					//info = " {0,-7:S} {1,-8:S} {2,-8:S} {3,-14:S} {4,-2:S} {5,-2:S} {6,-3:S} {7,-2:S} {8,-3:S} {9,-2:S} {10,-2:S} {11,-3:S} {12,-2:S} {13,-3:S} {14,-2:S} {15,-3:S} {16,-2:S} {17,-3:S} {18,-2:S} {19,-2:S} {20,-6:S} {21,-5:S} {22,-3:S} {23,-5:S} {24,-5:S} {25,-2:S}";
					info = "{0,-8:S}{1,-9:S}{2,-9:S}{3,-19:S}{4,-3:S}{5,-3:S}{6,-4:S}{7,-3:S}{8,-4:S}{9,-3:S}{10,-3:S}{11,-4:S}{12,-3:S}{13,-4:S}{14,-3:S}{15,-4:S}{16,-3:S}{17,-4:S}{18,-3:S}{19,-3:S}{20,-7:S}{21,-6:S}{22,-4:S}{23,-6:S}{24,-6:S}{25,-3:S}";
								
					double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
					string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
						
					sql="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						int j=0;
						while(SqlDtr.Read())
						{
							for(int i=0;i<22;i++)
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									//MessageBox.Show("Max:"+max_marks[j]);
									j++;
								}
						}
					}
					SqlDtr.Close();
					sql="select sr.RollNo,s.scategory,st.Rollno,sr.sName,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+DropStream.SelectedItem.Text+"' and st.exam_type='"+DropExamType.SelectedItem.Text+"'  and sr.st_section = '"+DropSection.SelectedItem.Text+"'";
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							for(int i=4;i<=25;i++)
							{
								double marks=0;
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									if(SqlDtr.GetValue(i).ToString().Equals("A"))
									{
										grade[i-4]="Ab";
									}
									else
									{
										marks=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
										marks=(marks*100)/max_marks[i-4];
										if(marks>=95)
										{
											grade[i-4]="A+";
										}
										else if(marks>=85&&marks<95)
										{
											grade[i-4]="A";
										}
										else if(marks>=75&&marks<85)
										{
											grade[i-4]="B+";
										}
										else if(marks>=65&&marks<75)
										{
											grade[i-4]="B";
										}	 
										else if(marks>=55&&marks<65)
										{
											grade[i-4]="C+";
										}	 
										else if(marks>=45&&marks<55)
										{
											grade[i-4]="C";
										}	 
										else if(marks>=40&&marks<45)
										{
											grade[i-4]="D";
										}	 
										else
										{
											grade[i-4]="E";
										}
									}
								}
							}
							sw.WriteLine(info,"|"+SqlDtr.GetValue(0).ToString(),"|"+GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),8),"|"+SqlDtr.GetValue(2).ToString(),"|"+GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),14),"|"+grade[0].ToString(),"|"+grade[1].ToString(),"|"+grade[2].ToString(),"|"+grade[3].ToString(),"|"+grade[4].ToString(),"|"+grade[5].ToString(),"|"+grade[6].ToString(),"|"+grade[7].ToString(),"|"+grade[8].ToString(),"|"+grade[9].ToString(),"|"+grade[10].ToString(),"|"+grade[11].ToString(),"|"+grade[12].ToString(),"|"+grade[13].ToString(),"|"+grade[14].ToString(),"|"+grade[15].ToString(),"|"+grade[16].ToString(),"|"+grade[17].ToString(),"|"+grade[18].ToString(),"|"+grade[19].ToString(),"|"+grade[20].ToString(),"|"+grade[21].ToString(),"|"+grade[21].ToString()+"|");	
						}
					}	
					SqlDtr.Close();	
					sw.WriteLine("+-------+--------+--------+------------------+--+--+---+--+---+--+--+---+--+---+--+---+--+---+--+--+------+-----+---+-----+-----+--+");
					sw.WriteLine("RR=Reading/Recitation, WR=Writing, CON=Conversation, SP=Spelling, COM=Comprehension, FN=Forming Numbers Correctly");
					sw.WriteLine("UBC=Understanding Basic Concept, CA=Computation Ability, OBS=Observation, ID=Identification, KL=Knowledge, CS=Computer, Ab=Absent");										
							
				}
					//this Code for  other than 3 and above
				else
				{
					int no_sub=0;
					string Subj=Request.Params.Get("subject");
					string Subj1="";
					string[] sub=Subj.Split(new char[] {','},Subj.Length);
					for(int ii=0;ii<sub.Length;ii++)
					{
						if(sub[ii]=="PHYSICS")
							Subj=Subj.Replace("PHYSICS","physics_th,physics_pr,physics_tot");
						if(sub[ii]=="CHEMISTRY")
							Subj=Subj.Replace("CHEMISTRY","chemistry_th,chemistry_pr,chemistry_tot");
						if(sub[ii]=="BIOLOGY")
							Subj=Subj.Replace("BIOLOGY","biology_th,biology_pr,biology_tot");
						if((sub[ii]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							Subj=Subj.Replace("COMPUTER","computer_th,computer_pr,computer_tot");
						if(sub[ii]=="COMPUTER" && (!DropClass.SelectedItem.Text.Equals("XI")||!DropClass.SelectedItem.Text.Equals("XII")))
							Subj=Subj.Replace("COMPUTER","computer_TOT");

						//********** Add by Vikas sharma 27.09.08***************************************
						if(sub[ii]=="PHYSICS")
							no_sub+=3;
						else if(sub[ii]=="CHEMISTRY")
							no_sub+=3;
						else if(sub[ii]=="BIOLOGY")
							no_sub+=3;
						else if((sub[ii]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							no_sub+=3;
						else if(sub[ii]=="COMPUTER" && (!DropClass.SelectedItem.Text.Equals("XI")||!DropClass.SelectedItem.Text.Equals("XII")))
							no_sub++;
						else 
							no_sub++;
						//******************************************************************************
					}
					Subj=Subj.Replace(" ","_");
					Subj=Subj.Replace("&","and");
					Subj=Subj.ToLower();
					Subj1=Subj.Substring(1,Subj.Length-1);
					double Max_mark=0;
					double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
					string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
					sql="select "+Subj.Substring(1,Subj.Length-1)+" FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
					string[] sub1=Subj.Split(new char[] {','},Subj.Length);
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						int j=0;
						while(SqlDtr.Read())
						{
							for(int i=0;i<sub1.Length-1;i++)
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									double vv=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									j++;
									//3.11.08 if(!(SqlDtr.GetName(i).ToString()=="computer_tot" ||SqlDtr.GetName(i).ToString()=="physics_tot"||SqlDtr.GetName(i).ToString()=="chemistry_tot"||SqlDtr.GetName(i).ToString()=="biology_tot"))
									if(!(SqlDtr.GetName(i).ToString()=="physics_tot"||SqlDtr.GetName(i).ToString()=="chemistry_tot"||SqlDtr.GetName(i).ToString()=="biology_tot"))
									{
										Max_mark+=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									}
								}
						}
					}
					SqlDtr.Close();
				
					string[] subject=Subj.Split(new char[] {','},Subj.Length);
					//string str="select RoleNo,student_Name"+Subj.ToLower()+" from studentmarks where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
					string str="select RollNo,Student_Name"+Subj.ToLower()+" from StudentMarks sm,student_roll sr where sm.roleno=sr.studentid and sm.Class='"+DropClass.SelectedItem.Text+"' and sm.Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'  and sm.st_section = '"+DropSection.SelectedItem.Text+"' order by rollno";//added by vi 23/11
					SqlDtr=obj.GetRecordSet(str);
					string SubjectDic=Request.Params.Get("subjectdic");
			    
					sw.Write((char)27);   //added by vishnu
					sw.Write((char)67);   //added by vishnu
					sw.Write((char)0);    //added by vishnu
					sw.Write((char)12);   //added by vishnu
					sw.Write((char)27);   //added by vishnu
					sw.Write((char)78);   //added by vishnu
					sw.Write((char)5);    //added by vishnu
					sw.Write((char)27);   //added by vishnu
					sw.Write((char)15);
					sw.WriteLine();
					string Header=" Roll No ";
					Header+="  Student Name    ";
					string desdes="+-------+-----------------";
					for(int i=1;i<subject.Length;i++)
					{	
						desdes+="+";
						//if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot")      // add by vikas sharma 27.09.08
						if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot" || subject[i]=="biology_th" ||subject[i]=="biology_pr" ||subject[i]=="biology_tot")
						{
						  
							if(subject[i]=="chemistry_th")	Header+="Chem_Th ";
							else if(subject[i]=="chemistry_pr")	Header+="Chem_Pr ";
							else if(subject[i]=="chemistry_tot")	Header+="Chem_To ";
							else if(subject[i]=="computer_th")	Header+="Comp_Th ";
							else if(subject[i]=="computer_pr")	Header+="Comp_Pr ";
							else if(subject[i]=="computer_tot")	Header+="Comp_To ";
							else if(subject[i]=="physics_th")	Header+="Phys_Th ";
							else if(subject[i]=="physics_pr")	Header+="Phys_Pr ";
							else if(subject[i]=="physics_tot")	Header+="Phys_To ";
                            //add by vikas sharma 27.09.08
							else if(subject[i]=="biology_th")	Header+="Biol_Th ";
							else if(subject[i]=="biology_pr")	Header+="Biol_Pr ";
							else if(subject[i]=="biology_tot")	Header+="Biol_To ";
						
							for(int j=0;j<7;j++)
							{
								desdes+="-";
							}
						}
						else
						{
							if(subject[i].Length<=3)
							{
								Header+=subject[i].ToString().ToLower().Trim()+"   ";
								for(int j=0;j<subject[i].Length+2;j++)
								{
									desdes+="-";
								}
							}
							else 
							{
								Header+=subject[i].ToString().ToLower().Trim()+" ";
								for(int j=0;j<subject[i].Length;j++)
								{
									desdes+="-";
								}
							}
						}
						//MessageBox.Show(subject[i].ToString());
					}
					Header+="%age";
					desdes+="+----+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",desdes.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("---------------------",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("STUDENT MARKS REPORT",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("---------------------",desdes.Length));
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSection.SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text+",  ExamType : "+DropExamType.SelectedItem.Text);
					sw.WriteLine(desdes);
					sw.WriteLine(Header);
					sw.WriteLine(desdes);
					while(SqlDtr.Read())
					{
						//string s1=SqlDtr["RoleNo"].ToString();
						//sw.Write(" "+SqlDtr["RoleNo"].ToString());
						string s1=SqlDtr["RollNo"].ToString();
						sw.Write(" "+SqlDtr["RollNo"].ToString());
						for(int i1=0;i1<7-s1.Length;i1++)
						{
							sw.Write(" ");
						}
						string s2=SqlDtr["Student_Name"].ToString();
						sw.Write(" "+SqlDtr["Student_Name"].ToString());
						//for(int i1=0;i1<=22-s2.Length;i1++)
						for(int i1=0;i1<=17-s2.Length;i1++)
						{
							sw.Write(" ");
						}
						double marks=0;
						for(int i2=1;i2<subject.Length;i2++)
						{
							string ss=SqlDtr[subject[i2]].ToString();
							string grad="";
							if(	SqlDtr[subject[i2]].ToString()!="A"&&SqlDtr[subject[i2]].ToString()!=null&&SqlDtr[subject[i2]].ToString()!="")
							{			
								marks=System.Convert.ToDouble(SqlDtr[subject[i2]].ToString());
						
								marks=(marks*100)/max_marks[i2-1];
								if(marks>=95)
								{
									grad="A+";
								}
								else if(marks>=85&&marks<95)
								{
									grad="A";
								}
								else if(marks>=75&&marks<85)
								{
									grad="B+";
								}
								else if(marks>=65&&marks<75)
								{
									grad="B";
								}	 
								else if(marks>=55&&marks<65)
								{
									grad="C+";
								}	 
								else if(marks>=45&&marks<55)
								{
									grad="C";
								}	 
								else if(marks>=40&&marks<45)
								{
									grad="D";
								}	 
								else
								{
									grad="E";
								}
							}
							else if(SqlDtr[subject[i2]].ToString()=="A")
							{
								grad="Ab";
							}
						
						
							if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
							{
								grad="  ";
								sw.Write(grad+" "+SqlDtr[subject[i2].ToLower()].ToString());
								//sw.Write(SqlDtr[subject[i2].ToLower()].ToString());
							}
							else
							{
								sw.Write(grad+","+SqlDtr[subject[i2].ToLower()].ToString());
							}
						
						
							//if(subject[i2]=="physics_th"||subject[i2]=="physics_pr"||subject[i2]=="physics_tot"||subject[i2]=="chemistry_th"||subject[i2]=="chemistry_pr"||subject[i2]=="chemistry_tot"||subject[i2]=="computer_pr"||subject[i2]=="computer_th"||subject[i2]=="computer_tot")
							if(subject[i2]=="physics_th"||subject[i2]=="physics_pr"||subject[i2]=="physics_tot"||subject[i2]=="chemistry_th"||subject[i2]=="chemistry_pr"||subject[i2]=="chemistry_tot"||subject[i2]=="computer_pr"||subject[i2]=="computer_th"||subject[i2]=="computer_tot" || subject[i2]=="biology_th" ||subject[i2]=="biology_pr" ||subject[i2]=="biology_tot")
							{
								for(int j=0;j<7-ss.Length-grad.Length;j++)
								{
									sw.Write(" ");
								}
							}
							else
							{
								if(subject[i2].Length<=3)
								{
									for(int i3=0;i3<subject[i2].Length+2-ss.Length-grad.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									for(int i3=0;i3<subject[i2].Length-ss.Length-grad.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}	
						}
						
						//*******add by vikas sharma27.09.08************************


						SqlDataReader dtr1=null,dtr2=null;
						InventoryClass obj5=new InventoryClass();
						InventoryClass obj6=new InventoryClass();
						string student_id="";
						double total_mark=0;
						//string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString();
						string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString()+" and classid='"+DropClass.SelectedItem.Text+"'";
						dtr1=obj6.GetRecordSet(sql4);
						while(dtr1.Read())
						{
							student_id=dtr1.GetValue(0).ToString();
							sql4="select "+Subj1+" from studentmarks where roleno="+student_id.ToString()+"and Class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
							dtr2=obj5.GetRecordSet(sql4);
							int count3=0;
							//double total_mark=0;
							while(dtr2.Read())
							{
								if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
								{
									for(int ii=0;ii<no_sub-1;ii++)
									{
										if(!(dtr2.GetName(ii).ToString()=="computer_tot" ||dtr2.GetName(ii).ToString()=="physics_tot"||dtr2.GetName(ii).ToString()=="chemistry_tot"||dtr2.GetName(ii).ToString()=="biology_tot"))
										{
											if(dtr2.GetValue(ii).ToString()!="" && dtr2.GetValue(ii).ToString()!=null && dtr2.GetValue(ii).ToString()!="A")
											{
												total_mark+=System.Convert.ToDouble(dtr2.GetValue(ii));
											}
										}
									}
								}
								else
								{
									for(int ii=0;ii<Subject.Length;ii++)
									{
										if(dtr2.GetValue(ii).ToString()!="" && dtr2.GetValue(ii).ToString()!=null && dtr2.GetValue(ii).ToString()!="A")
										{
											total_mark+=System.Convert.ToDouble(dtr2.GetValue(ii));
										}
									}
								}
								count3++;
							}
							dtr2.Close();
						}
						dtr1.Close();

						double per=(total_mark/Max_mark)*100;
						//***********End*****************************

						//sw.Write(" "+GenUtil.TrimLength(marks.ToString(),4));
						sw.Write(GenUtil.TrimLength(per.ToString(),4)+"%");
						sw.WriteLine();
					}
					sw.WriteLine(desdes);
					sw.WriteLine();
					SqlDtr.Close();
					
					string[] no_of_subject=obj.GetSubject(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
					//MessageBox.Show("number:"+no_of_subject.Length);
					string strstr="";
								
					sw.Write(" "+"Highest");
					for(int i1=0;i1<=17;i1++)
					{
						sw.Write(" ");
					}
								
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and  "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Roleno"].ToString();						
												
										
							//if(subject[i2]=="physics_th"||subject[i2]=="physics_pr"||subject[i2]=="physics_tot"||subject[i2]=="chemistry_th"||subject[i2]=="chemistry_pr"||subject[i2]=="chemistry_tot"||subject[i2]=="computer_pr"||subject[i2]=="computer_th"||subject[i2]=="computer_tot")
							//if((subject[p]=="physics_th"||subject[p]=="physics_pr"||subject[p]=="physics_tot"||subject[p]=="chemistry_th"||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot"))&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							//if((subject[p]=="physics_th"||subject[p]=="physics_pr"||subject[p]=="physics_tot"||subject[p]=="chemistry_th"||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							//if(subject[p]=="physics_th"||subject[p]=="physics_pr"||subject[p]=="physics_tot"||subject[p]=="chemistry_th"||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{	
								sw.Write(" "+SqlDtr["Roleno"].ToString());
								if(strstr.Length<=3)
								{
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
								
					//name
								
					sw.WriteLine(" ");
					for(int i1=0;i1<=25;i1++)
					{
						sw.Write(" ");
					}
								
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
						//MessageBox.Show("Test:"+strstr);
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Student_Name"].ToString();						
										
										
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{	
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+3));			
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+1));			
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
								
					//marks
								
					sw.WriteLine(" ");
					for(int i1=0;i1<=25;i1++)
					{
						sw.Write(" ");
					}
								
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr[strstr].ToString();	
										
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr[strstr].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr[strstr].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{						
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+3));			
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+1));			
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine();
					sw.WriteLine(desdes);
					sw.WriteLine();
								
					//used this code for lowest 
								
					sw.Write(" "+"Lowest ");
					for(int i1=0;i1<=17;i1++)
					{
						sw.Write(" ");
					}
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Roleno"].ToString();						
							//sw.Write(" "+SqlDtr["Roleno"].ToString());		
										
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{	
								sw.Write(" "+SqlDtr["Roleno"].ToString());
								if(strstr.Length<=3)
								{
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
								
					//name
					sw.WriteLine(" ");
					for(int i1=0;i1<=25;i1++)
					{
						sw.Write(" ");
					}
								
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						 strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Student_Name"].ToString();						
							//sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+1));			
										
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+3));			
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+1));			
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
								
					//marks
								
					sw.WriteLine(" ");
					for(int i1=0;i1<=25;i1++)
					{
						sw.Write(" ");
					}
								
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
								
								
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
				
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr[strstr].ToString();						
							//sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+1));			
										
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									for(int j=0;j<16;j++)
									{
										sw.Write(" ");
									}
									sw.Write(" "+SqlDtr[strstr].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(" "+SqlDtr[strstr].ToString());
									for(int j=0;j<7-ss.Length;j++)
									{
										sw.Write(" ");
									}
								}
							}
							else
							{		
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+3));			
									for(int i3=0;i3<strstr.Length+2-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+1));			
									for(int i3=0;i3<strstr.Length-ss.Length;i3++)
									{
										sw.Write(" ");
									}
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine();
					sw.WriteLine(desdes);
											
				}
					
				sw.WriteLine();
				sw.Close();
				PrePrint();
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
				CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}	
		}

		/// <summary>
		/// this method use to create connection between remote device.
		/// </summary>
		public void PrePrint()
		{		
			byte[] bytes = new byte[1024];
			// Connect to a remote device.
			try 
			{
				// Establish the remote endpoint for the socket.
				// The name of the
				// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);

				// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );

				// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
						sender1.RemoteEndPoint.ToString());

					// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentMarksReport1.txt<EOF>");

					// Send the data through the socket.
					int bytesSent = sender1.Send(msg);

					// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));

					// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();					
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass );	 
					
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
					
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+es.Message+" , Userid :  "+ pass   );					
				}						
			} 			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				//CreateLogFiles.ErrorLog("Form:StudentMarksReport.aspx,Method:print"+ " EXCEPTION "  +ex.Message+"  userid  "+uid);
			
			}
		}
		
		/// <summary>
		/// this method use to get rank. first in this method calculate total marks of each student and save in array. after that take another array and all the value of first arry assign in two second array. after that check marks.
		/// </summary>
		public void  getRank()
		{
			try
			{
				string cls="",strstr="";
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

					strstr=GenUtil.AddColumnNames(cls,DropStream.SelectedItem.Text);
				if(strstr=="")
				{
					MessageBox.Show("Subject Not Available");
					return;
				}
				Subject=strstr.Split(new char[]{','},strstr.Length);
				//strstr=strstr.Replace(",","+");
      
				int i,j,k=0;
				SqlConnection scon1;
				SqlCommand cmd1;
				SqlDataReader dr1;
				scon1=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				scon1.Open();
				string sql="";
				
				//sql="select total from studentmarks where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
				sql="select "+strstr+" from studentmarks where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
				cmd1=new SqlCommand(sql,scon1);
				dr1=cmd1.ExecuteReader();
				while(dr1.Read())
				{
						total=0;
						for(int ii=0;ii<Subject.Length;ii++)
						{
							if(dr1.GetValue(ii).ToString()!="" && dr1.GetValue(ii).ToString()!=null && dr1.GetValue(ii).ToString()!="A")
							{
								total=total+System.Convert.ToDouble(dr1.GetValue(ii));
							}
						}
						gtotal[count1]=total;
						rank[count1+1]="N/A";
					/*if(dr1.GetValue(0).ToString()!="" && dr1.GetValue(0).ToString()!=null && dr1.GetValue(0).ToString()!="A")
					{
						gtotal[count1]=Convert.ToDouble( dr1.GetValue(0));
					}
					else
					{
						gtotal[count1]=0;
						rank[count1+1]="N/A";
					}*/
					count1++;
				}
				double[] a =new double [100];
				double m;
				for( k=0;k<count1;k++)
				{
					a[k]=gtotal[k];
				}
				for(j=1;j<count1;j++)
				{
					m=a[j];
					i=j-1;
					while(i>=0&&a[i]>m)
					{
						a[i+1]=a[i];
						i--;
					}
					a[i+1]=m;
				}
			
				for(i=count1-1,k=0;i>=0;i--,k++)
				{
					for(j=0;j<count1;j++)
					{
						if(gtotal[j]==a[i])
						{
							if(rank[k+1]!="N/A")
								rank[j]=Convert.ToString(j+1);
								break;
						}
					}
				}
			}
			catch(Exception exe)
			{
				MessageBox.Show(exe.Message);
			}
		}

		/// <summary>
		/// this method use to show report. assign value in flage true.
		/// </summary>
		public void btnShow_Click(object sender, System.EventArgs e)
		{
			flage=true;
		}

		/// <summary>
		/// this method use to generate a report in excel format. first get marks from exammarksdecision table. and save in array. after that fetch marks from studentmarksentryIandII table. and check grade and save another array. and calculate rank and persentage.
		/// </summary>
		public void Btnexcel_Click(object sender, System.EventArgs e)
		{
			flage=true;
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string sql;
				int Prod_No=0,Group=1,Count=0,pp=0;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\StudentMarksReport1.xls";
				StreamWriter sw = new StreamWriter(path);
				
				if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))
				{
				
					sw.Write((char)27);     //added by vishnu
					sw.Write((char)67);     //added by vishnu
					sw.Write((char)0);      //added by vishnu
					sw.Write((char)12);     //added by vishnu
					sw.Write((char)27);     //added by vishnu
					sw.Write((char)78);     //added by vishnu
					sw.Write((char)5);      //added by vishnu
					sw.Write((char)27);     //added by vishnu
					sw.Write((char)15);
					// For Class I AND 2
					string info="";
					string des="+-------+--------+--------+------------------+----------------+----------------+---------+---------+-------------------------------+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("STUDENT MARKS REPORT",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSection.SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text+",  ExamType : "+DropExamType.SelectedItem.Text);
					sw.WriteLine("") ;
				
					
					sw.WriteLine("Roll No\tCategory\tAdm. No.\tStudent Name\t\t\tENGLISH\t\t\t\t\tHINDI\t\t\t\tMATHS\t\t\tEVS\t\t\t\tNON SCHOLASTIC\t\t");
					sw.WriteLine("\t\t\t\tRR\tWR\tCON\tSP\tCOM\tRR\tWR\tCON\tSP\tCOM\tFN\tUBC\tCA\tOBS\tID\tKL\tPh.Edu\tMusic\tArt\tCraft\tDance\tCS");
					//             1234567 12345678 12345678 123456789012345678 12 12 123 12 123 12 12 123 12 123 12 123 12 123 12 12 123456 12345 123 12345 12345 12
					info = "{0,-8:S}{1,-9:S}{2,-9:S}{3,-19:S}{4,-3:S}{5,-3:S}{6,-4:S}{7,-3:S}{8,-4:S}{9,-3:S}{10,-3:S}{11,-4:S}{12,-3:S}{13,-4:S}{14,-3:S}{15,-4:S}{16,-3:S}{17,-4:S}{18,-3:S}{19,-3:S}{20,-7:S}{21,-6:S}{22,-4:S}{23,-6:S}{24,-6:S}{25,-3:S}";
					double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
					string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
					sql="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						int j=0;
						while(SqlDtr.Read())
						{
							for(int i=0;i<22;i++)
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									j++;
								}
						}
					}
					SqlDtr.Close();
					sql="select sr.RollNo,s.scategory,st.Rollno,sr.sName,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+DropStream.SelectedItem.Text+"' and st.exam_type='"+DropExamType.SelectedItem.Text+"'  and sr.st_section = '"+DropSection.SelectedItem.Text+"'";
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						while(SqlDtr.Read())
						{
							for(int i=4;i<=25;i++)
							{
								double marks=0;
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									if(SqlDtr.GetValue(i).ToString().Equals("A"))
									{
										grade[i-4]="Ab";
									}
									else
									{
										marks=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
										marks=(marks*100)/max_marks[i-4];
										if(marks>=95)
										{
											grade[i-4]="A+";
										}
										else if(marks>=85&&marks<95)
										{
											grade[i-4]="A";
										}
										else if(marks>=75&&marks<85)
										{
											grade[i-4]="B+";
										}
										else if(marks>=65&&marks<75)
										{
											grade[i-4]="B";
										}	 
										else if(marks>=55&&marks<65)
										{
											grade[i-4]="C+";
										}	 
										else if(marks>=45&&marks<55)
										{
											grade[i-4]="C";
										}	 
										else if(marks>=40&&marks<45)
										{
											grade[i-4]="D";
										}	 
										else
										{
											grade[i-4]="E";
										}
									}
								}
							}
							sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+SqlDtr.GetValue(1).ToString()+"\t"+SqlDtr.GetValue(2).ToString()+"\t"+SqlDtr.GetValue(3).ToString()+"\t"+grade[0].ToString()+"\t"+grade[1].ToString()+"\t"+grade[2].ToString()+"\t"+grade[3].ToString()+"\t"+grade[4].ToString()+"\t"+grade[5].ToString()+"\t"+grade[6].ToString()+"\t"+grade[7].ToString()+"\t"+grade[8].ToString()+"\t"+grade[9].ToString()+"\t"+grade[10].ToString()+"\t"+grade[11].ToString()+"\t"+grade[12].ToString()+"\t"+grade[13].ToString()+"\t"+grade[14].ToString()+"\t"+grade[15].ToString()+"\t"+grade[16].ToString()+"\t"+grade[17].ToString()+"\t"+grade[18].ToString()+"\t"+grade[19].ToString()+"\t"+grade[20].ToString()+"\t"+grade[21].ToString());	
						}
					}	
					SqlDtr.Close();	
					sw.WriteLine("RR=Reading/Recitation, WR=Writing, CON=Conversation, SP=Spelling, COM=Comprehension, FN=Forming Numbers Correctly");
					sw.WriteLine("UBC=Understanding Basic Concept, CA=Computation Ability, OBS=Observation, ID=Identification, KL=Knowledge, CS=Computer, Ab=Absent");										
				}
				else
				{
					int no_sub=0;
					//this Code for  other than 3 and above	
					string Subj1="";
					string Subj=Request.Params.Get("subject");
					string[] sub=Subj.Split(new char[] {','},Subj.Length);
					for(int ii=0;ii<sub.Length;ii++)
					{
						if(sub[ii]=="PHYSICS")
							Subj=Subj.Replace("PHYSICS","physics_th,physics_pr,physics_tot");
						if(sub[ii]=="CHEMISTRY")
							Subj=Subj.Replace("CHEMISTRY","chemistry_th,chemistry_pr,chemistry_tot");
						if(sub[ii]=="BIOLOGY")
							Subj=Subj.Replace("BIOLOGY","biology_th,biology_pr,biology_tot");
						if((sub[ii]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							Subj=Subj.Replace("COMPUTER","computer_th,computer_pr,computer_tot");
						if(sub[ii]=="COMPUTER" && (!DropClass.SelectedItem.Text.Equals("XI")||!DropClass.SelectedItem.Text.Equals("XII")))
							Subj=Subj.Replace("COMPUTER","computer_TOT");

						//********** Add by Vikas sharma 27.09.08***************************************
						if(sub[ii]=="PHYSICS")
							no_sub+=3;
						else if(sub[ii]=="CHEMISTRY")
							no_sub+=3;
						else if(sub[ii]=="BIOLOGY")
							no_sub+=3;
						else if((sub[ii]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
							no_sub+=3;
						else if(sub[ii]=="COMPUTER" && (!DropClass.SelectedItem.Text.Equals("XI")||!DropClass.SelectedItem.Text.Equals("XII")))
							no_sub++;
						else 
							no_sub++;
						//******************************************************************************

					}
					Subj=Subj.Replace(" ","_");
					Subj=Subj.Replace("&","and");
					Subj=Subj.ToLower();
					Subj1=Subj.Substring(1,Subj.Length-1);
					double Max_mark=0;
					double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
					string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
					sql="select "+Subj.Substring(1,Subj.Length-1)+" FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
					string[] sub1=Subj.Split(new char[] {','},Subj.Length);
					SqlDtr=obj.GetRecordSet(sql);
					if(SqlDtr.HasRows)
					{
						int j=0;
						while(SqlDtr.Read())
						{
							for(int i=0;i<sub1.Length-1;i++)
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
									max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
									
									//3.11.08 if(!(SqlDtr.GetName(j).ToString()=="computer_tot" ||SqlDtr.GetName(j).ToString()=="physics_tot"||SqlDtr.GetName(j).ToString()=="chemistry_tot"||SqlDtr.GetName(j).ToString()=="biology_tot"))
									if(!(SqlDtr.GetName(j).ToString()=="physics_tot"||SqlDtr.GetName(j).ToString()=="chemistry_tot"||SqlDtr.GetName(j).ToString()=="biology_tot"))
									{
										Max_mark+=System.Convert.ToDouble(SqlDtr.GetValue(j).ToString());
									}
									j++;
								}
						}
					}
					SqlDtr.Close();
					string[] subject=Subj.Split(new char[] {','},Subj.Length);
					string str="select RollNo,Student_Name"+Subj.ToLower()+" from StudentMarks sm,student_roll sr where sm.roleno=sr.studentid and sm.Class='"+DropClass.SelectedItem.Text+"' and sm.Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'  and sm.st_section = '"+DropSection.SelectedItem.Text+"' order by rollno";//added by vi 23/11
					SqlDtr=obj.GetRecordSet(str);
					string SubjectDic=Request.Params.Get("subjectdic");
					sw.Write((char)27);//added by vishnu
					sw.Write((char)67);//added by vishnu
					sw.Write((char)0);//added by vishnu
					sw.Write((char)12);//added by vishnu
					sw.Write((char)27);//added by vishnu
					sw.Write((char)78);//added by vishnu
					sw.Write((char)5);//added by vishnu
					sw.Write((char)27);//added by vishnu
					sw.Write((char)15);
					sw.WriteLine();
					string Header="Roll No\tStudent Name\t";
					string desdes="+-------+-----------------";
					for(int i=1;i<subject.Length;i++)
					{	
						desdes+="+";
						//if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot") add by vikas sharma 27.09.08
						if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot" || subject[i]=="biology_th" ||subject[i]=="biology_pr" ||subject[i]=="biology_tot")
						{
							if(subject[i]=="chemistry_th")	
								Header+="Chem_Th\t";
							else if(subject[i]=="chemistry_pr")	
								Header+="Chem_Pr\t";
							else if(subject[i]=="chemistry_tot")	
								Header+="Chem_To\t";
							else if(subject[i]=="computer_th")	
								Header+="Comp_Th\t";
							else if(subject[i]=="computer_pr")	
								Header+="Comp_Pr\t";
							else if(subject[i]=="computer_tot")	
								Header+="Comp_To\t";
							else if(subject[i]=="physics_th")	
								Header+="Phys_Th\t";
							else if(subject[i]=="physics_pr")	
								Header+="Phys_Pr\t";
							else if(subject[i]=="physics_tot")	
								Header+="Phys_To\t";
							else if(subject[i]=="biology_th")	
								Header+="Bio_Th\t";
							else if(subject[i]=="biology_pr")	
								Header+="Bio_Pr\t";
							else if(subject[i]=="biology_tot")	
								Header+="Bio_To\t";
							for(int j=0;j<7;j++)
							{
								desdes+="-";
							}
						}
						else
						{
							if(subject[i].Length<=3)
							{
								Header+=subject[i].ToString().ToLower().Trim()+"\t";
								for(int j=0;j<subject[i].Length+2;j++)
								{
									desdes+="-";
								}
							}
							else 
							{
								Header+=subject[i].ToString().ToLower().Trim()+"\t";
								for(int j=0;j<subject[i].Length;j++)
								{
									desdes+="-";
								}
							}
						}
					}
					Header+="%age";
					desdes+="+----+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",desdes.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("---------------------",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("STUDENT MARKS REPORT",desdes.Length));
					sw.WriteLine(GenUtil.GetCenterAddr("---------------------",desdes.Length));
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSection.SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text+",  ExamType : "+DropExamType.SelectedItem.Text);
					sw.WriteLine(Header);
					while(SqlDtr.Read())
					{
						string s1=SqlDtr["RollNo"].ToString();
						sw.Write(" "+SqlDtr["RollNo"].ToString());
						sw.Write("\t");
						string s2=SqlDtr["Student_Name"].ToString();
						sw.Write(" "+SqlDtr["Student_Name"].ToString());
						sw.Write("\t");
						double marks=0;
						for(int	i2=1;i2<subject.Length;i2++)
						{
							string ss=SqlDtr[subject[i2]].ToString();
							string grad="";
							if(	SqlDtr[subject[i2]].ToString()!="A"&&SqlDtr[subject[i2]].ToString()!=null&&SqlDtr[subject[i2]].ToString()!="")
							{			
								marks=System.Convert.ToDouble(SqlDtr[subject[i2]].ToString());
								marks=(marks*100)/max_marks[i2-1];
								if(marks>=95)
								{
									grad="A+";
								}
								else if(marks>=85&&marks<95)
								{
									grad="A";
								}
								else if(marks>=75&&marks<85)
								{
									grad="B+";
								}
								else if(marks>=65&&marks<75)
								{
									grad="B";
								}	 
								else if(marks>=55&&marks<65)
								{
									grad="C+";
								}	 
								else if(marks>=45&&marks<55)
								{		
									grad="C";
								}	 
								else if(marks>=40&&marks<45)
								{
									grad="D";
								}	 
								else
								{
									grad="E";
								}
							}
							else if(SqlDtr[subject[i2]].ToString()=="A")
							{
								grad="Ab";
							}
							if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
							{
								grad="  ";
								sw.Write(grad+" "+SqlDtr[subject[i2].ToLower()].ToString());
							}
							else
							{
								sw.Write(grad+","+SqlDtr[subject[i2].ToLower()].ToString());
							}
							sw.Write("\t");
								
						}

						//*******add by vikas sharma27.09.08************************


						SqlDataReader dtr1=null,dtr2=null;
						InventoryClass obj5=new InventoryClass();
						InventoryClass obj6=new InventoryClass();
						string student_id="";
						double total_mark=0;
						//string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString();
						string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString()+" and classid='"+DropClass.SelectedItem.Text+"'";
						dtr1=obj6.GetRecordSet(sql4);
						while(dtr1.Read())
						{
							student_id=dtr1.GetValue(0).ToString();
							sql4="select "+Subj1+" from studentmarks where roleno="+student_id.ToString()+"and Class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
							dtr2=obj5.GetRecordSet(sql4);
							int count3=0;
							//double total_mark=0;
							while(dtr2.Read())
							{
								if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
								{
									for(int ii=0;ii<no_sub-1;ii++)
									{
										if(!(dtr2.GetName(ii).ToString()=="computer_tot" ||dtr2.GetName(ii).ToString()=="physics_tot"||dtr2.GetName(ii).ToString()=="chemistry_tot"||dtr2.GetName(ii).ToString()=="biology_tot"))
										{
											if(dtr2.GetValue(ii).ToString()!="" && dtr2.GetValue(ii).ToString()!=null && dtr2.GetValue(ii).ToString()!="A")
											{
												total_mark+=System.Convert.ToDouble(dtr2.GetValue(ii));
											}
										}
									}
								}
								else
								{
									for(int ii=0;ii<Subject.Length;ii++)
									{
										if(dtr2.GetValue(ii).ToString()!="" && dtr2.GetValue(ii).ToString()!=null && dtr2.GetValue(ii).ToString()!="A")
										{
											total_mark+=System.Convert.ToDouble(dtr2.GetValue(ii));
										}
									}
								}
								count3++;
							}
							dtr2.Close();
						}
						dtr1.Close();

						double per=(total_mark/Max_mark)*100;
						//***********End*****************************
						//sw.Write(" "+GenUtil.TrimLength(marks.ToString(),4));
						//3.11.08 sw.Write(" "+GenUtil.TrimLength(per.ToString(),4));
						sw.Write(" "+GenUtil.TrimLength(per.ToString(),4)+"%");
						sw.WriteLine();
					}
					sw.WriteLine();
					SqlDtr.Close();
					string[] no_of_subject=obj.GetSubject(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
					string strstr="";
					sw.Write("Highest");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and  "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Roleno"].ToString();						
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									sw.Write(" \t");
								}
							}
							else
							{	
								sw.Write(" "+SqlDtr["Roleno"].ToString());
								sw.Write("\t");
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine(" ");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Student_Name"].ToString();						
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									sw.Write("\t");
								}
							}
							else
							{	
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+3));			
									sw.Write("\t");
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+1));			
									sw.Write("\t");
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine(" ");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr[strstr].ToString();	
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr[strstr].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr[strstr].ToString());
									sw.Write("\t");
								}
							}
							else
							{						
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+3));			
									sw.Write("\t");
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+1));			
									sw.Write("\t");
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine();
					sw.WriteLine();
					//used this code for lowest 
					sw.Write("Lowest ");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Roleno"].ToString();						
							//sw.Write(" "+SqlDtr["Roleno"].ToString());		
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr["Roleno"].ToString());
									sw.Write("\t");
								}
							}
							else
							{	
								sw.Write(" "+SqlDtr["Roleno"].ToString());
								if(strstr.Length<=3)
								{
									sw.Write("\t");
								}
								else
								{
									sw.Write("\t");
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine(" ");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr["Student_Name"].ToString();						
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr["Student_Name"].ToString());
									sw.Write("\t");
								}
							}
							else
							{
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+3));			
									sw.Write("\t");
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr["Student_Name"].ToString(),strstr.Length+1));			
									sw.Write("\t");
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine(" ");
					sw.Write("\t\t");
					for(int p=0;p<no_of_subject.Length;p++)
					{
						if(no_of_subject[p]=="PHYSICS")
						{
							strstr="PHYSICS_TOT";
						}
						else if(no_of_subject[p]=="CHEMISTRY")
						{
							strstr="chemistry_TOT";
						}	
						else if(no_of_subject[p]=="BIOLOGY")
						{
							strstr="biology_TOT";
						}
						else if(no_of_subject[p]=="COMPUTER")
						{
							strstr="computer_TOT";
						}
						else
						{
							strstr=no_of_subject[p];
						}
						strstr=strstr.Replace(" ","_");
						strstr=strstr.Replace("&","and");	
						str="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
						SqlDtr=obj.GetRecordSet(str);																
						if(SqlDtr.Read())
						{
							string ss=SqlDtr[strstr].ToString();						
							if(strstr=="PHYSICS_TOT"||strstr=="chemistry_TOT"||strstr=="computer_TOT"||strstr=="biology_TOT")//||subject[p]=="chemistry_pr"||subject[p]=="chemistry_tot"||subject[p]=="computer_pr"||subject[p]=="computer_th"||subject[p]=="computer_tot")
							{
								if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
								{
									sw.Write("\t");
									sw.Write("\t");
									sw.Write(" "+SqlDtr[strstr].ToString());
									sw.Write("\t");
								}
								else
								{
									sw.Write(" "+SqlDtr[strstr].ToString());
									sw.Write("\t");
								}
							}
							else
							{		
								if(strstr.Length<=3)
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+3));			
									sw.Write("\t");
								}
								else
								{
									sw.Write(GenUtil.TrimLength(" "+SqlDtr[strstr].ToString(),strstr.Length+1));			
									sw.Write("\t");
								}
							}
						}
						SqlDtr.Close();
					}
					sw.WriteLine();
				}
				sw.WriteLine();
				sw.Close();
				MessageBox.Show("Successfully Convert File into Excel Format");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Btnexcel.Click += new System.EventHandler(this.Btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
