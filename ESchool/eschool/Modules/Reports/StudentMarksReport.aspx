<%@ Page language="c#" Codebehind="StudentMarksReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.StudentMarksReport" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Import namespace="System.Net"%>
<%@ Import namespace="System.Net.Sockets"%>
<%@ Import namespace="System.IO"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD> 
    <title>eSchool : StudentMarksReport</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <script language="javascript" id="Validations" src="../../Validations.js"></script>
	<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet>  
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <script language=javascript>
		// this method not in use.
		function FillIandII(t,d)
		{
		    var index=t.selectedIndex
			var val=t.options[index].value
			if(val=="I" || val=="II")
			{ 
				d.clear
				d.length=1
				d.add(new Option)  
				d.options[1].text="Ist Unit Test"
				d.add(new Option)
				d.options[2].text="IInd Unit Test"
				d.add(new Option)
				d.options[3].text="IIIrd Unit Test"
				d.add(new Option)
				d.options[4].text="IVth Unit Test"
				d.add(new Option)
				d.options[5].text="Vth Unit Test"
				d.add(new Option)
				d.options[6].text="Assign & Project"
			}
			else
			{
				d.clear
				d.length=1
				d.add(new Option)  
				d.options[1].text="Ist Term"
				d.add(new Option)
				d.options[2].text="IInd Term"
				d.add(new Option)
				d.options[3].text="IIIrd Term"
			}
		}
    </script>
</HEAD>
 <body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
				<table width="778" height=250 align="center">
					<tr>
						<td align="center"><b>STUDENT MARKS REPORT</b>
							<table align="center" borderColorLight="#663300" border="5">
								<tr>
									<td align=center colspan=26>
										Student Class&nbsp;
										<asp:DropDownList CssClass=ComboBox ID=DropClass Runat=server></asp:DropDownList>
										&nbsp;Section&nbsp;
										<asp:DropDownList ID=DropSection CssClass=ComboBox Runat=server>
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="A">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
											<asp:ListItem Value="D">D</asp:ListItem>
											<asp:ListItem Value="E">E</asp:ListItem>
											<asp:ListItem Value="F">F</asp:ListItem>
											<asp:ListItem Value="G">G</asp:ListItem>
											<asp:ListItem Value="H">H</asp:ListItem>
											<asp:ListItem Value="I">I</asp:ListItem>
											<asp:ListItem Value="J">J</asp:ListItem>
										</asp:DropDownList>
										&nbsp;Stream&nbsp;
										<asp:DropDownList CssClass=ComboBox ID="DropStream" Runat=server>
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Biology">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Mathematics">Math Group</asp:ListItem>
											</asp:DropDownList>
										&nbsp;Exam Type&nbsp;
										<asp:DropDownList ID="DropExamType" CssClass=ComboBox Runat=server>
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="Ist Unit Test">Ist Unit Test</asp:ListItem>
											<asp:ListItem Value="IInd Unit Test">IInd Unit Test</asp:ListItem>
											<asp:ListItem Value="IIIrd Unit Test">IIIrd Unit Test</asp:ListItem>
											<asp:ListItem Value="IVth Unit Test">IVth Unit Test</asp:ListItem>
											<asp:ListItem Value="Vth Unit Test">Vth Unit Test</asp:ListItem>
											<asp:ListItem Value="Assign & Project">Assign & Project</asp:ListItem>
											<asp:ListItem Value="Ist Term">Ist Term</asp:ListItem>
											<asp:ListItem Value="IInd Term">IInd Term</asp:ListItem>
											<asp:ListItem Value="IIIrd Term">IIIrd Term</asp:ListItem>
										</asp:DropDownList>
										&nbsp;Session&nbsp;<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack="False">
											<asp:ListItem Value="Select">Select</asp:ListItem>
											<asp:ListItem Value="2006:2007">2006:2007</asp:ListItem>
											<asp:ListItem Value="2007:2008">2007:2008</asp:ListItem>
											<asp:ListItem Value="2008:2009">2008:2009</asp:ListItem>
											<asp:ListItem Value="2009:2010">2009:2010</asp:ListItem>
											<asp:ListItem Value="2010:2011">2010:2011</asp:ListItem>
											<asp:ListItem Value="2011:2012">2011:2012</asp:ListItem>
											<asp:ListItem Value="2012:2013">2012:2013</asp:ListItem>
											<asp:ListItem Value="2013:2014">2013:2014</asp:ListItem>
											<asp:ListItem Value="2014:2015">2014:2015</asp:ListItem>
											<asp:ListItem Value="2015:2016">2015:2016</asp:ListItem>
											<asp:ListItem Value="2016:2017">2016:2017</asp:ListItem>
											<asp:ListItem Value="2017:2018">2017:2018</asp:ListItem>
											<asp:ListItem Value="2018:2019">2018:2019</asp:ListItem>
											<asp:ListItem Value="2019:2020">2019:2020</asp:ListItem>
											<asp:ListItem Value="2020:2021">2020:2021</asp:ListItem>
										</asp:dropdownlist>
									</td>
								</tr>
								<tr>
									<td align=center colspan=26>
										<asp:Button ID=btnShow Runat=server Text="Show" CssClass="FormButtonStyle" BorderColor=black BorderStyle=Groove BorderWidth=2 BackColor="#E0E0E0" Height=21 Width=100 Font-Size="X-Small"></asp:Button>
										&nbsp;<asp:Button ID="btnSubmit" Runat=server Text="Print" CssClass="FormButtonStyle" BorderColor=black BorderStyle=Groove BorderWidth=2 BackColor="#E0E0E0" Height=21 Width=85 Font-Size="X-Small"></asp:Button>
										&nbsp;<asp:Button ID="btnEdit" Runat=server Text="Edit" CssClass="FormButtonStyle" BorderColor=black BorderStyle=Groove BorderWidth=2 BackColor="#E0E0E0" Width=85 Height=21 Font-Size="X-Small" Visible=False></asp:Button>
										&nbsp;<asp:Button ID="Btnexcel" Runat=server Text="Excel" CssClass="FormButtonStyle" BorderColor=black BorderStyle=Groove BorderWidth=2 BackColor="#E0E0E0" Width=85 Height=21 Font-Size="X-Small"></asp:Button>
									</td>
								</tr>
								<%		
								if(flage==true)
								{										   
									bool flag=false;
									bool flag1=false;
									try
									{ 
										DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
										InventoryClass obj=new InventoryClass();
										SqlDataReader SqlDtr=null,rdr=null;
										string sql;
										string strstr="";
										int Prod_No=0,Group=1,Count=0,pp=0;		
										int no=0;		
										if(DropClass.SelectedIndex!=0)
										{
											if(DropSection.SelectedIndex!=0)
											{
												if(DropExamType.SelectedIndex!=0)
												{
												   if(DropSession.SelectedIndex!=0)
												   {
														string[] no_of_subject=obj.GetSubject(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
														if(no_of_subject.Length==0)
														{
															MessageBox.Show("Subject Not Available");
															flag=true;
														}
														double Maxmark=0;
														for(int p=0;p<no_of_subject.Length;p++)
														{
															if(no_of_subject[p]=="PHYSICS")
															{
																strstr=strstr+","+"PHYSICS_TH,PHYSICS_PR,PHYSICS_TOT";
																no+=3;
															}
															else if(no_of_subject[p]=="CHEMISTRY")
															{
																strstr=strstr+","+"chemistry_TH,chemistry_PR,chemistry_TOT";
																no+=3;
															}
															else if(no_of_subject[p]=="BIOLOGY")
															{
																strstr=strstr+","+"biology_TH,biology_PR,biology_TOT";
																no+=3;
															}
															else if(no_of_subject[p]=="COMPUTER"&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
															{
																strstr=strstr+","+"computer_TH,computer_PR,computer_TOT";
																no+=3;
															}
															else if(no_of_subject[p]=="COMPUTER" && (!DropClass.SelectedItem.Text.Equals("XI")||!DropClass.SelectedItem.Text.Equals("XII")))
															{
																strstr=strstr+","+"computer_TOT";
																no+=1;
															}
															else
															{
																strstr=strstr+","+no_of_subject[p];
																no+=1;
															}
														}
														strstr=strstr.Substring(1).ToLower();
														strstr=strstr.Replace(" ","_");
														strstr=strstr.Replace("&","and");
														string[] no_of_subject1=obj.GetSubjectForDecision(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text,DropExamType.SelectedItem.Text,strstr);
														if(no_of_subject1[0]==null)
														{
															MessageBox.Show("Exam Marks Decision Data Not Available");
															flag=true;
														}
														
														if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II")||DropClass.SelectedItem.Text.Equals("Nursery")||DropClass.SelectedItem.Text.Equals("LKG")||DropClass.SelectedItem.Text.Equals("UKG"))
														{
															//1.11.08 flag=false;
															if(flag==false)
															{	
																double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
																string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
																//31.10.08 sql="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
																sql="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'" ;
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
																//31.10.08 sql="select sr.RollNo,s.scategory,st.Rollno,sr.sName,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+DropStream.SelectedItem.Text+"' and st.exam_type='"+DropExamType.SelectedItem.Text+"'  and sr.st_section = '"+DropSection.SelectedItem.Text+"'";
																sql="select sr.RollNo,s.scategory,st.Rollno,sr.sName,Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,st.Computer_tot FROM STUDENTMARKSENTRYIANDII st,student_roll sr,Student_Record s where st.Rollno=sr.studentid and st.Rollno=s.student_id and sr.classid='"+DropClass.SelectedItem.Text+"' and sr.Stream= '"+DropStream.SelectedItem.Text+"' and st.exam_type='"+DropExamType.SelectedItem.Text+"'  and sr.st_section = '"+DropSection.SelectedItem.Text+"' and s.year='"+DropSession.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	%>
																	<tr bgcolor=#663300>
																		<td  rowSpan="2" align=center><b><font color=#ffffff>Roll No</font></b></td>
																		<td rowSpan="2" align=center><b><font color=#ffffff>Category</font></b></td>
																		<td rowSpan="2" align=center><b><font color=#ffffff>Adm. No.</font></b></td>
																		<td rowSpan="2" align=center><b><font color=#ffffff>Student Name</font></b></td>
																		<td align=center colspan=5><b><font color=#ffffff>English</font></b></td>
																		<td align=center colspan=5><b><font color=#ffffff>Hindi</font></b></td>
																		<td align=center colspan=3><b><font color=#ffffff>Maths</font></b></td>
																		<td align=center colspan=3><b><font color=#ffffff>EVS</font></b></td>
																		<td align=center colspan=6><b><font color=#ffffff>NON SCHOLASTIC</font></b></td>
																	</tr>
																	<tr bgcolor=#663300>
																		<td align=center><b><font color=#ffffff>RR</font></b></td>
																		<td align=center><b><font color=#ffffff>WR</font></b></td>
																		<td align=center><b><font color=#ffffff>CON</font></b></td>
																		<td	align=center><b><font color=#ffffff>SP</font></b></td>
																		<td align=center><b><font color=#ffffff>COM</font></b></td>
																		<td align=center><b><font color=#ffffff>RR</font></b></td>
																		<td align=center><b><font color=#ffffff>WR</font></b></td>
																		<td align=center><b><font color=#ffffff>CON</font></b></td>
																		<td align=center><b><font color=#ffffff>SP</font></b></td>
																		<td align=center><b><font color=#ffffff>COM</font></b></td>
																		<td align=center><b><font color=#ffffff>FN</font></b></td>
																		<td align=center><b><font color=#ffffff>UBC</font></b></td>
																		<td align=center><b><font color=#ffffff>CA</font></b></td>
																		<td align=center><b><font color=#ffffff>OBS</font></b></td>
																		<td align=center><b><font color=#ffffff>ID</font></b></td>
																		<td align=center><b><font color=#ffffff>KL</font></b></td>
																		<td align=center><b><font color=#ffffff>Ph.Edu</font></b></td>
																		<td align=center><b><font color=#ffffff>Music</font></b></td>
																		<td align=center><b><font color=#ffffff>Art</font></b></td>
																		<td align=center><b><font color=#ffffff>Craft</font></b></td>
																		<td align=center><b><font color=#ffffff>Dance</font></b></td>
																		<td align=center><b><font color=#ffffff>CS</font></b></td>
																	</tr>
																	<%
																	while(SqlDtr.Read())
																	{
																		%>
																		<tr>
																			<td align=center><%=SqlDtr.GetValue(0).ToString()%></td>
																			<td align=center><%=SqlDtr.GetValue(1).ToString()%></td>
																			<td align=center><%=SqlDtr.GetValue(2).ToString()%></td>
																			<td align=left><%=SqlDtr.GetValue(3).ToString()%></td>
																			<%
																			for(int i=4;i<=25;i++)
																			{
																				double marks=0;
																				if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
																				{
																					if(SqlDtr.GetValue(i).ToString()=="A")
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
																					%>
																					<td align=center><%=grade[i-4]%></td>
																					<%
																				} 
																			}
																		}
																		%>
																		<tr>
																			<td colspan=26>
																				<table width="100%">
																					<tr bgcolor=#663300>
																						<td><b><font color=#ffffff>RR = Reading / Recitation , WR = Writing , CON = Conversation , SP = Spelling , COM = Comprehension , FN = Forming Numbers Correctly  </font></b></td>
																					</tr>
																					<tr bgcolor=#663300>
																						<td><b><font color=#ffffff>UBC = Understanding Basic Concept , CA = Computation Ability , OBS = Observation , ID=Identification, KL = Knowledge, CS=Computer, Ab=Absent</font></b></td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																		<%
																	}
																	else
																	{
																		MessageBox.Show(" Record Not Found ");
																	}		
																	SqlDtr.Close();
																}	
															}
															else		//III to XII Class
															{
																if(flag==false)
																{
																	double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
																	string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
																	//31.10.08 sql="select "+strstr+" FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
																	sql="select "+strstr+" FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'" ;
																	SqlDtr=obj.GetRecordSet(sql);
																	if(SqlDtr.HasRows)
																	{
																		int j=0;
																		while(SqlDtr.Read())
																		{
																			if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
																			{
																				for(int i=0;i<no;i++)
																				{
																					if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
																					{
																						max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
																						if(!(SqlDtr.GetName(i).ToString()=="computer_tot" ||SqlDtr.GetName(i).ToString()=="physics_tot"||SqlDtr.GetName(i).ToString()=="chemistry_tot"||SqlDtr.GetName(i).ToString()=="biology_tot"))
																							Maxmark=Maxmark+System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
																						j++;
																					}
																				}
																			}
																			else
																			{
																				for(int i=0;i<no_of_subject.Length;i++)
																				{
																					if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
																					{
																						max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
																						if(!(SqlDtr.GetName(i).ToString()=="physics_tot"||SqlDtr.GetName(i).ToString()=="chemistry_tot"||SqlDtr.GetName(i).ToString()=="biology_tot"))
																							Maxmark=Maxmark+System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
																						j++;
																					}
																				}
																			}
																		}
																	}
																	SqlDtr.Close();
																	double total_mark=0;
																	double per=0;
																	double marks=0;							
																	//sql="select seq_student_id,Student_FName from Student_Record where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' order by Student_FName";
																	//sql="select RoleNo,Student_Name,"+strstr+" from StudentMarks where Class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'  and st_section = '"+DropSection.SelectedItem.Text+"' order by Student_Name";
																	//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'
																	//1.11.08 sql="select RollNo,Student_Name,"+strstr+" from StudentMarks sm,student_roll sr where sm.roleno=sr.studentid and sm.Class='"+DropClass.SelectedItem.Text+"' and sm.Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'  and sm.st_section = '"+DropSection.SelectedItem.Text+"' order by rollno";//added by vi 23/11
																	sql="select RollNo,Student_Name,"+strstr+" from StudentMarks sm,student_roll sr where sm.roleno=sr.studentid and sm.Class='"+DropClass.SelectedItem.Text+"' and sm.Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'  and sm.st_section = '"+DropSection.SelectedItem.Text+"' and sm.year='"+DropSession.SelectedItem.Text+"' order by rollno";//added by vi 23/11
																	SqlDtr=obj.GetRecordSet(sql);
																	if(SqlDtr.HasRows)
																	{
																		%>
																		<tr bgcolor=#663300>
																			<td align=center><b><font color=#ffffff>Roll No</font></b></td>
																			<td align=center><b><font color=#ffffff>Student Name</font></b></td>
																			<%
																			for(int p=0,k=0;p<no_of_subject.Length;p++,k++)
																			{
																				if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																				{
																					%>
																					<td align=center><b><font color=#ffffff><%=no_of_subject[p].ToString()%></font></b></BR>
																					<%
																					if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																					{
																						%>
																						<table width=100% cellpadding=0 cellspacing=0>
																							<tr bgcolor=#663300>
																								<td align=center><b><font color=#ffffff>TH.<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
																								<%k++;%>
																								<td align=center><b><font color=#ffffff>Prac.<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
																								<%k++;%>
																								<td align=center><b><font color=#ffffff>Tot<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
																							</tr>
																						</table>
																						<%
																					}
																					%>
																					</td>
																					<%
																				}
																				else
																				{
																					%>
																					<td align=center><b><font color=#ffffff><%=no_of_subject[p].ToString()%><br>(<%=no_of_subject1[k].ToString()%>)</font></b></BR></td>
																					<%
																				}
																				Group=2;
																			}
																			%>
																			<td align=center><b><font color=#ffffff>Percentage</font></b></BR></td>
																			<%
																			if(Group==1)
																			{
																				MessageBox.Show("Student Record Not Available");
																				//return;
																			}
																			%>
																			</tr>
																			<% 
																			getRank();
																			int i=0;
																			while(SqlDtr.Read())
																			{
																				i++;
																				%>
																				<tr>
																					<td align=center><%=SqlDtr.GetValue(0).ToString()%><input type=hidden name=txtRoleNo<%=Prod_No%> value=<%=SqlDtr.GetValue(0).ToString()%>></td>
																					<td align=center><%=SqlDtr.GetValue(1).ToString()%><input type=hidden name=txtSName<%=Prod_No%> value=<%=SqlDtr.GetValue(1).ToString()%>></td>
																					<%
																					Count=2;
																					for(int p=0;p<no_of_subject.Length;p++)
																					{
																						if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																						{
																							%>
																							<td align=center>
																							<table width=100% cellpadding=0 cellspacing=0>
																								<tr>
																									<td align=center><%=SqlDtr.GetValue(Count).ToString()%></td>
																									<td align=center><%=SqlDtr.GetValue(++Count).ToString()%></td>
																									<td align=center><%=SqlDtr.GetValue(++Count).ToString()%></td>
																								</tr>
																							</table></td>
																							<%
																							if(SqlDtr.GetValue(Count).ToString()!=" "&&SqlDtr.GetValue(Count).ToString()!=null&&SqlDtr.GetValue(Count).ToString()!="A")
																							{
																								marks=System.Convert.ToDouble(SqlDtr.GetValue(Count).ToString());
																							}
																						}
																						else
																						{
																							if((no_of_subject[p]=="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("X")||DropClass.SelectedItem.Text.Equals("IX")))
																							{
																								string gradea="";
																								if(SqlDtr.GetValue(Count).ToString()!=" "&&SqlDtr.GetValue(Count).ToString()!=null&&SqlDtr.GetValue(Count).ToString()!="A")
																								{	
																									marks=System.Convert.ToDouble(SqlDtr.GetValue(Count).ToString());
																									marks=marks*100.0/max_marks[p];
																									if(marks>=95&&marks<=100)
																										gradea="A+";
																									else if(marks>=85&&marks<95)
																										gradea="A";
																									else if(marks>=75&&marks<85)
																										gradea="B+";
																									else if(marks>=65&&marks<75)
																										gradea="B";
																									else if(marks>=55&&marks<65)
																										gradea="C+";
																									else if(marks>=45&&marks<55)
																										gradea="C";
																									else if(marks>=40&&marks<45)
																										gradea="D";
																									else if(marks<40)
																										gradea="E";							   
																								}
																								else
																								{
																									gradea="Ab";
																								}
																								%><td align=center><%=gradea.ToString()%></td><%
																							}
																							else if((no_of_subject[p]!="PHYSICS" || no_of_subject[p]!="CHEMISTRY" || no_of_subject[p]!="BIOLOGY" || no_of_subject[p]!="COMPUTER")&&(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII")))
																							{
																								if(SqlDtr.GetValue(Count).ToString()!=" "&&SqlDtr.GetValue(Count).ToString()!=null&&SqlDtr.GetValue(Count).ToString()!="A")
																								{
																									marks=System.Convert.ToDouble(SqlDtr.GetValue(Count).ToString());
																								}
																								%><td align=center><%=SqlDtr.GetValue(Count).ToString()%></td><%
																							}
																							else
																							{
																								string gradea="";
																								double m=0;
																								if(SqlDtr.GetValue(Count).ToString()!=" "&&SqlDtr.GetValue(Count).ToString()!=null&&SqlDtr.GetValue(Count).ToString()!="A")
																								{
																									marks=System.Convert.ToDouble(SqlDtr.GetValue(Count).ToString());
																									marks=marks*100.0/max_marks[p];
																									if(marks>=95&&marks<=100)
																										gradea="A+";
																									else if(marks>=85&&marks<95)
																										gradea="A";
																									else if(marks>=75&&marks<85)
																										gradea="B+";
																									else if(marks>=65&&marks<75)
																										gradea="B";
																									else if(marks>=55&&marks<65)
																										gradea="C+";
																									else if(marks>=45&&marks<55)
																										gradea="C";
																									else if(marks>=40&&marks<45)
																										gradea="D";
																									else if(marks<40)
																										gradea="E";
																								}
																								else
																								{
																									gradea="Ab";
																								}
																								%>
																								<td align=center>
																								<%=gradea.ToString()+", "%>
																								<%=marks.ToString()%></td>
																								<%
																							}
																						}
																						Count++;
																						Group=3;
																						flag1=true;
																					}
																					SqlDataReader dtr1=null,dtr2=null;
																					InventoryClass obj5=new InventoryClass();
																					InventoryClass obj6=new InventoryClass();
																					string student_id="";
																					total_mark=0;
																					//string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString();
																					///1.11.08 string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString()+" and classid='"+DropClass.SelectedItem.Text+"'";
																					string sql4="select studentid from student_roll where rollno="+SqlDtr.GetValue(0).ToString()+" and classid='"+DropClass.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
																					dtr1=obj6.GetRecordSet(sql4);
																					while(dtr1.Read())
																					{
																						student_id=dtr1.GetValue(0).ToString();
																						sql4="select "+strstr+" from studentmarks where roleno="+student_id.ToString()+"and Class='"+DropClass.SelectedItem.Text+"' and Stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
																						dtr2=obj5.GetRecordSet(sql4);
																						int count3=0;
																						while(dtr2.Read())
																						{
  		    																				if(DropClass.SelectedItem.Text=="XI"||DropClass.SelectedItem.Text=="XII")
	        																				{
																								for(int ii=0;ii<no;ii++)
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
																					if(DropClass.SelectedItem.Text.Equals("XI")||DropClass.SelectedItem.Text.Equals("XII"))
																					{
																						per=(total_mark/Maxmark)*100;
																						%>
																						<td align=center><%=GenUtil.TrimLength(per.ToString(),4)%>%</td>
																						<%
																					}
																					else
																					{
																						per=(total_mark/Maxmark)*100;
																						%>
																						<td align=center><%=GenUtil.TrimLength(per.ToString(),4)%>%</td>
																						<%
																					}
																					%>
																					</tr>
																					<%Prod_No++;
																				}
																			}
																			else
																			{
																				MessageBox.Show("Student Record Not Available");
																			}
																			SqlDtr.Close();
																			string subject="";
																			for(int i=0;i<no_of_subject.Length;i++)
																			{
																				 subject=subject+","+no_of_subject[i].ToString();
																				
																			}
																			%>
																			<input type=hidden name=Total_Prod value="<%=Prod_No%>">
																			<input type=hidden name=Total_Sub value="<%=Count%>">
																			<input type=hidden name=subject value="<%=subject%>">
																			<input type=hidden name=subjectdic value="<%=no_of_subject1%>">
																			<%
																			//MessageBox.Show(subject);
																		}
																		
																	}
																}
																else
																{
																	MessageBox.Show("Please Select Session");
																}
															}
															else
															{
																MessageBox.Show("Please Select ExamType");
															}
														}
														else
														{
															MessageBox.Show("Please Select Section");
														}
													}
													else
													{
														MessageBox.Show("Please Select Class");
													}
												}
												catch(Exception ex)
												{
													//MessageBox.Show("There is some problem occures, please try again");
													CreateLogFiles.ErrorLog("Form:StudentMarksReport,HTML "+" StudentMarksReport  "+"  EXCEPTION   "+ex.Message+"  userid  ");
												}
												
												try
												{
													if(flag1==true)
													{
														DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
														InventoryClass obj=new InventoryClass();
														SqlDataReader SqlDtr=null;
														string sql,strstr="";
														%>
														<tr colspan=9>
															<th valign=center rowspan=3><font color=#663300>Highest</font></th>
															<td>&nbsp;<font color=#663300>Student Id</font></td>
															<%
															string[] no_of_subject=obj.GetSubject(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																sql="select RoleNo,Student_Name from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{	
																			%>
																			<td align=center><%=SqlDtr.GetValue(0).ToString()%></td>
																			<%
																		}
																	}
																}
																SqlDtr.Close();
															}
															%>
														</tr>
														<tr>
															<td >&nbsp;<font color=#663300>Student Name</font></td>
															<%
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																sql="select RoleNo,Student_Name from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and   exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{
																			%>
																			<td align=center><%=SqlDtr.GetValue(1).ToString()%></td>
																			<%
																		}
																	}
																}
																SqlDtr.Close();
															}
															%>
														</tr>
														<tr>
															<td >&nbsp;<font color=#663300>Marks</font></td>
															<%
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																sql="select RoleNo,Student_Name,"+strstr+" from studentmarks where "+strstr+" in( select max( cast( "+strstr+" as float )) from  studentmarks where  "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{
																			%>
																			<td align=center><%=SqlDtr.GetValue(2).ToString()%></td>
																			<%
																		}
																	}
																}
																SqlDtr.Close();
															}
															%>
														<tr>
															<th valign=center rowspan=3><font color=#663300>Lowest</font></th>
															<td>&nbsp;<font color=#663300>Student Id</font></td>
															<%
															//string[] no_of_subject=obj.GetSubject(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																//sql="select RoleNo,Student_Name from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																sql="select RoleNo,Student_Name from  studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and  "+strstr+"!='A'   and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	//while(SqlDtr.Read())
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{
																			%>
																			<td align=center><%=SqlDtr.GetValue(0).ToString()%></td>
																			<%
																		}
																	}
																}	
																SqlDtr.Close();
															}
															%>
														</tr>
														<tr>
															<td >&nbsp;<font color=#663300>Student Name</font></td>
															<%
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																sql="select RoleNo,Student_Name from studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and  "+strstr+"!='A' and  exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{
																			%>
																			<td align=center><%=SqlDtr.GetValue(1).ToString()%></td>
																			<%
																		}
																	}
																}
																SqlDtr.Close();
															}
															%>
														</tr>
														<tr>
															<td >&nbsp;<font color=#663300>Marks</font></td>
															<%
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
																//sql="select RoleNo,Student_Name,total from studentmarks where english in( select max(english) from  studentmarks where exam_type='Ist Unit Test' and class='I' and st_section='A') and exam_type='Ist Unit Test' and class='I' and st_section='A'";
																sql="select RoleNo,Student_Name,"+strstr+" from  studentmarks where "+strstr+" in( select min( cast( "+strstr+" as float )) from  studentmarks where "+strstr+"!='A' and   exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"') and  "+strstr+"!='A' and exam_type='"+DropExamType.SelectedItem.Text+"' and class='"+DropClass.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
																SqlDtr=obj.GetRecordSet(sql);
																if(SqlDtr.HasRows)
																{
																	if(SqlDtr.Read())
																	{
																		if(SqlDtr.GetValue(1).ToString()!=null ||!SqlDtr.GetValue(1).ToString().Equals(""))
																		{
																			%>
																			<td align=center><%=SqlDtr.GetValue(2).ToString()%></td>
																			<%
																		}
																	}
																}
																SqlDtr.Close();
															}
														}
													}
													catch(Exception ex)
													{
														MessageBox.Show("There is some problem occures, please try again");
														CreateLogFiles.ErrorLog("Form:StudentMarksReport,HTML "+" StudentMarksReport  "+"  EXCEPTION   "+ex.Message+"  userid  ");
													}
											}
											%>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
	<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
 <script language=C# runat =server>
//this method not in use.
/*public void Excel(Object sender, EventArgs e )
{

		try
			{
				//InventoryClass obj=new InventoryClass(); 
				//SqlDataReader SqlDtr;
				
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string sql;
				int Prod_No=0,Group=1,Count=0,pp=0;
				
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\StudentMarksReport.xls";
				
				//string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentMarksReport.txt";
				StreamWriter sw = new StreamWriter(path);
				//string Subj=Request.Params.Get("subject");
				
				//if(DropClass.SelectedItem.Text.Equals("I")||DropClass.SelectedItem.Text.Equals("II"))
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
					
					// For Class I AND 2
					
					string info="";
					string des="+-------+--------+--------+------------------+----------------+----------------+---------+---------+-------------------------------+";
					//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School,Gwalior",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("STUDENT MARKS REPORT",des.Length)) ;
					sw.WriteLine(GenUtil.GetCenterAddr("--------------------------",des.Length)) ;
					sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+",  Section : "+DropSection.SelectedItem.Text+",  Stream : "+DropStream.SelectedItem.Text+",  ExamType : "+DropExamType.SelectedItem.Text);
					sw.WriteLine("") ;
				
					//sw.WriteLine("+-------+--------+--------+------------------+----------------+----------------+---------+---------+-------------------------------+");
					sw.WriteLine("Roll No\tCategory\tAdm. No.\tStudent Name\t\t\tENGLISH\t\t\t\t\tHINDI\t\t\t\tMATHS\t\t\tEVS\t\t\t\tNON SCHOLASTIC\t\t");
					sw.WriteLine("\t\t\t\tRR\tWR\tCON\tSP\tCOM\tRR\tWR\tCON\tSP\tCOM\tFN\tUBC\tCA\tOBS\tID\tKL\tPh.Edu\tMusic\tArt\tCraft\tDance\tCS");
					//sw.WriteLine("+-------+--------+--------+------------------+--+--+---+--+---+--+--+---+--+---+--+---+--+---+--+--+------+-----+---+-----+-----+--+");
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
									  //MessageBox.Show("id"+SqlDtr.GetValue(0).ToString());
									    
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
													//MessageBox.Show("Marks"+marks);
													//MessageBox.Show("maxMarks"+max_marks[i-4]);
												
													marks=(marks*100)/max_marks[i-4];
													//MessageBox.Show("Marks"+marks);
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
										 }//end if 
										}//end for
										//sw.WriteLine(info,SqlDtr.GetValue(0).ToString(),GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),8),SqlDtr.GetValue(2).ToString(),GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),14),grade[0].ToString(),grade[1].ToString(),grade[2].ToString(),grade[3].ToString(),grade[4].ToString(),grade[5].ToString(),grade[6].ToString(),grade[7].ToString(),grade[8].ToString(),grade[9].ToString(),grade[10].ToString(),grade[11].ToString(),grade[12].ToString(),grade[13].ToString(),grade[14].ToString(),grade[15].ToString(),grade[16].ToString(),grade[17].ToString(),grade[18].ToString(),grade[19].ToString(),grade[20].ToString(),grade[21].ToString(),grade[21].ToString());	
										//sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),8)+"\t"+SqlDtr.GetValue(2).ToString()+"\t"+GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),14)+"\t"+grade[0].ToString()+"\t"+grade[1].ToString(),"|"+grade[2].ToString()+"\t"+grade[3].ToString()+"\t"+grade[4].ToString()+"\t"+grade[5].ToString()+"\t"+grade[6].ToString()+"\t"+grade[7].ToString()+"\t"+grade[8].ToString()+"\t"+grade[9].ToString()+"\t"+grade[10].ToString()+"\t"+grade[11].ToString()+"\t"+grade[12].ToString()+"\t"+grade[13].ToString()+"\t"+grade[14].ToString()+"\t"+grade[15].ToString()+"\t"+grade[16].ToString()+"\t"+grade[17].ToString()+"\t"+grade[18].ToString()+"\t"+grade[19].ToString()+"\t"+grade[20].ToString()+"\t"+grade[21].ToString()+"\t"+grade[21].ToString());	
										sw.WriteLine(SqlDtr.GetValue(0).ToString()+"\t"+SqlDtr.GetValue(1).ToString()+"\t"+SqlDtr.GetValue(2).ToString()+"\t"+SqlDtr.GetValue(3).ToString()+"\t"+grade[0].ToString()+"\t"+grade[1].ToString()+"\t"+grade[2].ToString()+"\t"+grade[3].ToString()+"\t"+grade[4].ToString()+"\t"+grade[5].ToString()+"\t"+grade[6].ToString()+"\t"+grade[7].ToString()+"\t"+grade[8].ToString()+"\t"+grade[9].ToString()+"\t"+grade[10].ToString()+"\t"+grade[11].ToString()+"\t"+grade[12].ToString()+"\t"+grade[13].ToString()+"\t"+grade[14].ToString()+"\t"+grade[15].ToString()+"\t"+grade[16].ToString()+"\t"+grade[17].ToString()+"\t"+grade[18].ToString()+"\t"+grade[19].ToString()+"\t"+grade[20].ToString()+"\t"+grade[21].ToString());	
									}
								}	
							SqlDtr.Close();	
							//sw.WriteLine("+-------+--------+--------+------------------+--+--+---+--+---+--+--+---+--+---+--+---+--+---+--+--+------+-----+---+-----+-----+--+");
							sw.WriteLine("RR=Reading/Recitation, WR=Writing, CON=Conversation, SP=Spelling, COM=Comprehension, FN=Forming Numbers Correctly");
							sw.WriteLine("UBC=Understanding Basic Concept, CA=Computation Ability, OBS=Observation, ID=Identification, KL=Knowledge, CS=Computer, Ab=Absent");										
							
			}
							//this Code for  other than 3 and above
			else
			{
						
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
						
					//MessageBox.Show("Sub :"+sub[ii]);
				}
				Subj=Subj.Replace(" ","_");
				Subj=Subj.Replace("&","and");
				Subj=Subj.ToLower();
							
				double []max_marks={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
				string []grade={"","","","","","","","","","","","","","","","","","","","","","",""};
				sql="select "+Subj.Substring(1,Subj.Length-1)+" FROM  Exammarksdecision where  class='"+DropClass.SelectedItem.Text+"' and Stream= '"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
				
				string[] sub1=Subj.Split(new char[] {','},Subj.Length);
				
				SqlDtr=obj.GetRecordSet(sql);
				if(SqlDtr.HasRows)
				{
						int j=0;
						//MessageBox.Show("Length:"+sub.Length);
						while(SqlDtr.Read())
						{
							for(int i=0;i<sub1.Length-1;i++)
								if(SqlDtr.GetValue(i).ToString()!=null ||!SqlDtr.GetValue(i).ToString().Equals(""))
								{
										max_marks[j]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
										//MessageBox.Show("Max:"+max_marks[j]);
										j++;
								}
						}
				}
				SqlDtr.Close();
				
				string[] subject=Subj.Split(new char[] {','},Subj.Length);
				//string str="select RoleNo,student_Name"+Subj.ToLower()+" from studentmarks where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
				
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
				string Header=" Roll No ";
				Header+="  Student Name    ";
				string desdes="+-------+-----------------";
				for(int i=1;i<subject.Length;i++)
				{	
					desdes+="+";
					if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot")
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
						}
						else
						{
							sw.Write(grad+","+SqlDtr[subject[i2].ToLower()].ToString());
						}
						
						
						if(subject[i2]=="physics_th"||subject[i2]=="physics_pr"||subject[i2]=="physics_tot"||subject[i2]=="chemistry_th"||subject[i2]=="chemistry_pr"||subject[i2]=="chemistry_tot"||subject[i2]=="computer_pr"||subject[i2]=="computer_th"||subject[i2]=="computer_tot")
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
					sw.Write(" "+GenUtil.TrimLength(marks.ToString(),4));
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
				MessageBox.Show("Successfully Convert File into Excel Format");
				//PrePrint();
			}//end try
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
				CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}	

}*/


		// this method not in use.
		/*public void Print(Object sender, EventArgs e )
		{
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string sql;
				int Prod_No=0,Group=1,Count=0,pp=0;
				string path = @"C:\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentMarksReport1.txt";
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
										 }//end if 
									}//end for
									//sw.WriteLine(info,SqlDtr.GetValue(0).ToString(),GenUtil.TrimLength(SqlDtr.GetValue(1).ToString(),8),SqlDtr.GetValue(2).ToString(),GenUtil.TrimLength(SqlDtr.GetValue(3).ToString(),14),grade[0].ToString(),grade[1].ToString(),grade[2].ToString(),grade[3].ToString(),grade[4].ToString(),grade[5].ToString(),grade[6].ToString(),grade[7].ToString(),grade[8].ToString(),grade[9].ToString(),grade[10].ToString(),grade[11].ToString(),grade[12].ToString(),grade[13].ToString(),grade[14].ToString(),grade[15].ToString(),grade[16].ToString(),grade[17].ToString(),grade[18].ToString(),grade[19].ToString(),grade[20].ToString(),grade[21].ToString(),grade[21].ToString());	
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
				}
				Subj=Subj.Replace(" ","_");
				Subj=Subj.Replace("&","and");
				Subj=Subj.ToLower();
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
										j++;
								}
					}
				}
				SqlDtr.Close();
				
				string[] subject=Subj.Split(new char[] {','},Subj.Length);
				//string str="select RoleNo,student_Name"+Subj.ToLower()+" from studentmarks where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
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
				string Header=" Roll No ";
				Header+="  Student Name    ";
				string desdes="+-------+-----------------";
				for(int i=1;i<subject.Length;i++)
				{	
					desdes+="+";
					if(subject[i]=="physics_th"||subject[i]=="physics_pr"||subject[i]=="physics_tot"||subject[i]=="chemistry_th"||subject[i]=="chemistry_pr"||subject[i]=="chemistry_tot"||subject[i]=="computer_pr"||subject[i]=="computer_th"||subject[i]=="computer_tot")
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
						}
						else
						{
							sw.Write(grad+","+SqlDtr[subject[i2].ToLower()].ToString());
						}
						
						
						if(subject[i2]=="physics_th"||subject[i2]=="physics_pr"||subject[i2]=="physics_tot"||subject[i2]=="chemistry_th"||subject[i2]=="chemistry_pr"||subject[i2]=="chemistry_tot"||subject[i2]=="computer_pr"||subject[i2]=="computer_th"||subject[i2]=="computer_tot")
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
					sw.Write(" "+GenUtil.TrimLength(marks.ToString(),4));
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
			}//end try
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
				CreateLogFiles.ErrorLog(" Form : StudentMarksReport.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}	
		}
		
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

		}*/
		
	
</script>
	</body>
</HTML>
