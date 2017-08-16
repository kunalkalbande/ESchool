<%@ Page language="c#" Codebehind="TestSME.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.TestSME" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>eSchool : Student Marks Entry</title>
		<script language=javascript>
		     
	 // This method use to calculate the total of theory and practicals marks.
	function total(t,t1,t2)
	{
		var theo
		var prac
		var tot=0
		if(t.value=="" ||t.value==null)
			theo=0
		else
		    theo=t.value
		
		if(t1.value==""||t1.value==null)
			prac=0
		else    
			prac=t1.value
	    
	    tot=eval(theo)+eval(prac)
		t2.value=tot
		if(t2.value>100)
		{
			t.value=""
			t1.value=""
			t2.value=""
			alert("Tot Not More then 100")
		}
	}
	
	// This method not in use.
	function Check(t)
    {
	       //alert(t.name);
    }
    
     // This method use to fill value in dropdown daynamic.   
    function FillIandII(t,d)
	{
	    var index=t.selectedIndex
	    var val=t.options[index].value
	    //alert(index);
	    //alert(d.name);
	    if(val=="I" || val=="II")
	    {
			d.clear
			d.length=1
			//alert(val+" I  II");
			//d.options[0].text="Select";
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
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<LINK rel="stylesheet" type="text/css" href=/eschool/shareables/Style/Styles.css>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	    </HEAD>
        <body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<table height=250 align="center">
				<tr>
					<td align=center><b>STUDENT MARKS ENTRY</b>
						<table align="center" borderColorLight="#663300" border="5">
							<tr>
								<td colspan=24 align=center>
								Class&nbsp;<font color=red size=1>*</font>&nbsp;
								<asp:DropDownList CssClass="ComboBox" ID=DropClass Runat=server></asp:DropDownList>&nbsp;
								Section&nbsp;<font color=red size=1>*</font>&nbsp;
								<asp:DropDownList CssClass="ComboBox" ID=DropSection Runat=server >
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
										<asp:ListItem Value="J">j</asp:ListItem>
									</asp:DropDownList>&nbsp;
								Stream&nbsp;
								<asp:DropDownList CssClass="ComboBox" ID="DropStream" Runat=server>
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Biology">Bio Group</asp:ListItem>
										<asp:ListItem Value="Commerce">Commerce Group</asp:ListItem>
										<asp:ListItem Value="Mathematics">Math Group</asp:ListItem>
									</asp:DropDownList>&nbsp;
								Exam Type&nbsp;<font color=red size=1>*</font>&nbsp;
								<asp:DropDownList CssClass="ComboBox" ID="DropExamType" Runat=server >
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
								
									Session&nbsp;<font color=red size=1>*</font>&nbsp;<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack=False>
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
													</asp:dropdownlist></td>
												
											</tr>
											<tr align=center>						        
												<td align=center colspan=24 ><asp:Button ID=btnShow Runat=server Text="Show" Width=70 CssClass=formbuttonstyle></asp:Button>&nbsp;
												<asp:Button ID="btnSubmit" Runat=server Text="Submit" Width=70 CssClass=formbuttonstyle OnClick="update"></asp:Button>&nbsp;
												<asp:Button ID="btnEdit" Runat=server Text="Edit" Width=47 CssClass=formbuttonstyle Visible=False></asp:Button></td>
											</tr>
										<%
										if(flage==true) 
										{
											DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
											InventoryClass obj=new InventoryClass();
											InventoryClass obj2=new InventoryClass();
											EmployeeClass obj1=new EmployeeClass();
											SqlDataReader SqlDtr=null,rdr=null,rdr1=null;
											string sql;
											int Prod_No=0,Group=1,Count=0,pp=0;
											int Prod_No1=0;
											string strstr="";
											bool flag=false;
											
											if(DropClass.SelectedIndex!=0)
											{
												if(DropSection.SelectedIndex!=0 && DropExamType.SelectedIndex!=0 && DropSession.SelectedIndex!=0)
												{
													try
													{
														string[] no_of_subject=obj.GetSubject1(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
														if(no_of_subject.Length==0)
														{
															MessageBox.Show("Subject Not Available");
															flag=true;
														}
																											
															for(int p=0;p<no_of_subject.Length;p++)
															{
																if(no_of_subject[p]=="PHYSICS")														// || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="ZOLOGY" || no_of_subject[p]=="BOTNEY")
																{
																	strstr=strstr+","+"PHYSICS_TH,PHYSICS_PR,PHYSICS_TOT";
																}
																else if(no_of_subject[p]=="CHEMISTRY")												// || no_of_subject[p]=="ZOLOGY" || no_of_subject[p]=="BOTNEY")
																{
																	strstr=strstr+","+"chemistry_TH,chemistry_PR,chemistry_TOT";
																}
																else if(no_of_subject[p]=="BIOLOGY")
																{
																	strstr=strstr+","+"biology_TH,biology_PR,biology_TOT";
																}
																else if((no_of_subject[p]=="COMPUTER") && (DropClass.SelectedItem.Text=="XI" || DropClass.SelectedItem.Text=="XII"))
																{
																	strstr=strstr+","+"computer_TH,computer_PR,computer_TOT";
																}
																else if(no_of_subject[p]=="COMPUTER" && DropClass.SelectedItem.Text!="XI" && DropClass.SelectedItem.Text!="XII")
																{
																	strstr=strstr+","+"computer_TOT";
																}
																else
																{
																	strstr=strstr+","+no_of_subject[p];
																}
															}
															strstr=strstr.Substring(1).ToLower();
															strstr=strstr.Replace(" ","_");
															strstr=strstr.Replace("&","and");
																												
															string[] practical={"Physics","Chemistry","Biology"};
															string[] no_of_subject1=obj.GetSubjectForDecision(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text,DropExamType.SelectedItem.Text,strstr);
															if(no_of_subject1[0]==null)                                                      
															{                                                                                
																MessageBox.Show("Please Enter the Out of Marks In Exam marks Decision");      
																flag=true;                                                                    
															} 
														 
													
														if(DropClass.SelectedItem.Text.Equals("I") || DropClass.SelectedItem.Text.Equals("II")|| DropClass.SelectedItem.Text.Equals("Nursery")|| DropClass.SelectedItem.Text.Equals("LKG")|| DropClass.SelectedItem.Text.Equals("UKG"))
														{
														   if(flag==false)
														   {
															int Count1=0;
															Prod_No1=0;	
															//13.03.08--sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid order by rollno";  //add by vikas sharma 22.11.07
															sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid and sr.Year='"+DropSession.SelectedItem.Text+"' order by rollno";  //add by vikas sharma 22.11.07
															//sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid order by Student_FName";
															SqlDtr=obj.GetRecordSet(sql);
															if(SqlDtr.HasRows)
															{
																%> 
																<tr bgcolor=#663300>
																	<th rowSpan="2"><font color=#ffffff>Roll_No</font></th>
																	<th rowSpan="2"><font color=#ffffff>Student_Name</font></th>
																	<td align=center colspan=5><b><font color=#ffffff>English</font></b></td>
																	<td align=center colspan=5><b><font color=#ffffff>Hindi</font></b></td>
																	<td align=center colspan=3><b><font color=#ffffff>Maths</font></b></td>
																	<td align=center colspan=3><b><font color=#ffffff>EVS</font></b></td>
																	<td align=center colspan=6><b><font color=#ffffff>NON SCHOLASTIC</font></td>
																</tr>
																<tr bgcolor=#663300>
																	<td align=center><b><font color=#ffffff>RR</font></b></td>
																	<td align=center><b><font color=#ffffff>WR</font></b></td>
																	<td align=center><b><font color=#ffffff>CON</font></b></td>
																	<td align=center><b><font color=#ffffff>SP</font></b></td>
																	<td align=center><b><font color=#ffffff>COM</font></b></td>
																	<td align=center><b><font color=#ffffff>RR</font></b></td>
																	<td align=center><b><font color=#ffffff>WR</font></b></td>
																	<td align=center><b><font color=#ffffff>CON</font></b></td>
																	<td align=center><b><font color=#ffffff>SP</font></b></td>
																	<td align=center><b><font color=#ffffff>COM</font></b></td>
																	<td align=center><b><font color=#ffffff>FN</font></b></td>
																	<td align=center><b><font color=#ffffff>UBC</font></b></td>
																	<td	align=center><b><font color=#ffffff>CA</font></b></td>
																	<td align=center><b><font color=#ffffff>OBS</font></b></td>
																	<td align=center><b><font color=#ffffff>ID</font></b></td>
																	<td align=center><b><font color=#ffffff>KL</font></b></td>
																	<td align=center><b><font color=#ffffff>Ph.Edu</font></b></td>
																	<td align=center><b><font color=#ffffff>Music</font></b></td>
																	<td align=center><b><font color=#ffffff>Art</font></b></td>
																	<td	align=center><b><font color=#ffffff>Craft</font></b></td>
																	<td align=center><b><font color=#ffffff>Dance</font></b></td>
																	<td align=center><b><font color=#ffffff>CS</font></b></td>
																</tr>
																<%
																while(SqlDtr.Read())
																{
																	%>
																	<tr>
																		<td align=center><%=SqlDtr.GetValue(2).ToString()%><input type=hidden name=txtRoleNo<%=Prod_No1%> value=<%=SqlDtr.GetValue(0).ToString()%>></td>
																		<td><%=SqlDtr.GetValue(1).ToString()%><input type=hidden name=txtSName<%=Prod_No1%> value=<%=SqlDtr.GetValue(1).ToString()%>></td>
																		<%
																		///rdr1 = obj2.GetRecordSet("select * from studentmarksentryIandII where rollno='"+SqlDtr.GetValue(0).ToString()+"'");
																		//12.03.08--rdr1 = obj2.GetRecordSet("select * from studentmarksentryIandII where rollno='"+SqlDtr.GetValue(0).ToString()+"' and Exam_type='"+DropExamType.SelectedItem.Text+"'");
																		rdr1 = obj2.GetRecordSet("select * from studentmarksentryIandII where rollno='"+SqlDtr.GetValue(0).ToString()+"' and Exam_type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'");
																		int m=2;
																		if(rdr1.Read())
																		{
																			for(Count1=0;Count1<22;Count1++)
																			{
																				%>
																				<td><input type=text name="txtsub1<%=Prod_No1%>To<%=Count1%>" value="<%=rdr1.GetValue(m++).ToString()%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5  onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																				<%
																			}
																		}
																		else
																		{
																			for(Count1=0;Count1<22;Count1++)
																			{
																				%>
																				<td><input type=text name="txtsub1<%=Prod_No1%>To<%=Count1%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5  onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																				<%
																			}	
																		}
																		rdr1.Close();
																		Prod_No1++;
																}
															}
															else
															{
															  MessageBox.Show("Either Student Record Not Available Or Roll No. Not Set");
															}
															Count++;
															Prod_No++;
															%>
															<input type=hidden name=Total_Prod1 value=<%=Prod_No1%>>
															<%
															}
														}
														else
														{
															if(flag==false)   
																{
																	//12.03.08--sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid order by rollno";  //add by vikas sharma 22.11.07
																	sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid and sr.Year='"+DropSession.SelectedItem.Text+"' order by rollno";  //add by vikas sharma 12.03.08
																	//sql="select student_id,Student_FName,rollno from Student_Record sr,Student_roll s where Student_class='"+DropClass.SelectedItem.Text+"' and student_stream='"+DropStream.SelectedItem.Text+"' and seq_student_id ='"+DropSection.SelectedItem.Text+"' and sr.student_id=s.studentid order by Student_FName";
																	SqlDtr=obj.GetRecordSet(sql);
																	if(SqlDtr.HasRows)
																	{
																		%>
																		<tr bgcolor=#663300>
																			<th><font color=#ffffff>Roll_No</font></th>
																			<th><font color=#ffffff><asp:Label ID=lblsname Runat=server Width=170>Student_Name</asp:Label></font></th>
																			<%
																			for(int p=0,k=0;p<no_of_subject.Length;p++,k++)
																			{
																				if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER") && (DropClass.SelectedItem.Text=="XI" || DropClass.SelectedItem.Text=="XII"))
																				{
																					%>	
																					<td align=center><b><font color=#ffffff><%=no_of_subject[p].ToString()%></font></b></BR>
																					<%
																					if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER") && (DropClass.SelectedItem.Text=="XI" || DropClass.SelectedItem.Text=="XII"))
																					{
																						%>
																						<table width=100% cellpadding=1 cellspacing=1>
																							<tr bgcolor=#663300>
																								<td><b><font color=#ffffff>TH.<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
																								<%k++;%>
																								<td><b><font color=#ffffff>Prac.<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
																								<%k++;%>
																								<td><b><font color=#ffffff>Tot<br>(<%=no_of_subject1[k].ToString()%>)</font></b></td>
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
																					<th><font color=#ffffff><%=no_of_subject[p].ToString()%><br>(<%=no_of_subject1[k].ToString()%>)</font></BR></th>
																					<%
																				}
																				Group=2;
																			}
																		%>
																		</tr>
																		<%
																		while(SqlDtr.Read())
																		{
																			%>
																			<tr>
																				<td align=center><%=SqlDtr.GetValue(2).ToString()%><input type=hidden name=txtRoleNo<%=Prod_No%> value=<%=SqlDtr.GetValue(0).ToString()%>></td>
																				<td><%=SqlDtr.GetValue(1).ToString()%><input type=hidden name=txtSName<%=Prod_No%> value=<%=SqlDtr.GetValue(1).ToString()%>></td>
																				<%
																				Count=0;
																				//12.03.08--string str="select "+strstr+" from studentmarks where roleno='"+SqlDtr.GetValue(0).ToString()+"' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and st_section ='"+DropSection.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"'" ;
																				string str="select "+strstr+" from studentmarks where roleno='"+SqlDtr.GetValue(0).ToString()+"' and class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and st_section ='"+DropSection.SelectedItem.Text+"' and exam_type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'" ;
																				rdr=obj1.GetRecordSet(str);
																				if(rdr.Read())
																				{
																					for(int p=0;p<no_of_subject.Length;p++)
																					{
																						%>
																						<td align=center>
																						<%
																						if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER") && (DropClass.SelectedItem.Text=="XI" || DropClass.SelectedItem.Text=="XII"))
																						{
																							%>
																							<table width=100% cellpadding=1 cellspacing=1>
																								<tr>
																									<td><input type=text name="txtsub<%=Prod_No%>To<%=Count%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);" value=<%=rdr.GetValue(Count).ToString()%>></td>
																									<td><input type=text name="txtsub<%=Prod_No%>To<%=++Count%>" size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%>To<%=Count-1%>,document.Form1.txtsub<%=Prod_No%>To<%=Count+1%>)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);" value=<%=rdr.GetValue(Count).ToString()%>></td>
																									<td><input readonly=true type=text name="txtsub<%=Prod_No%>To<%=++Count%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);" value=<%=rdr.GetValue(Count).ToString()%>></td>
																								</tr>
																							</table>
																							<%
																						}
																						else
																						{
																								%>
																								<table width=100% cellpadding=1 cellspacing=1>
																									<tr>
																										<td align=center><input type=text name="txtsub<%=Prod_No%>To<%=Count%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5  onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);" value=<%=rdr.GetValue(Count).ToString()%>></td>
																									</tr>
																								</table>
																								
																								<%
																						}
																							%>
																							</td>
																							<%
																							Count++;
																							Group=3;
																						}
																						Prod_No++;
																					}
																					else
																					{
																						for(int p=0;p<no_of_subject.Length;p++)
																						{
																							%>
																							<td align=center>
																							<%
																							if((no_of_subject[p]=="PHYSICS" || no_of_subject[p]=="CHEMISTRY" || no_of_subject[p]=="BIOLOGY" || no_of_subject[p]=="COMPUTER") && (DropClass.SelectedItem.Text=="XI" || DropClass.SelectedItem.Text=="XII"))
																							{
																								%>
																								<table width=100% cellpadding=1 cellspacing=1>
																									<tr>
																										<td><input type=text  name="txtsub<%=Prod_No%>To<%=Count++%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5  onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																										<td><input type=text  name="txtsub<%=Prod_No%>To<%=Count++%>" size=1 class="TextForms" onblur="Check(this),total(this,document.Form1.txtsub<%=Prod_No%>To<%=Count-2%>,document.Form1.txtsub<%=Prod_No%>To<%=Count%>)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																										<td><input type=text readonly=true  name="txtsub<%=Prod_No%>To<%=Count%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																									</tr>
																								</table>
																								<%
																							}
																							else
																							{
																								%>
																								
																								<table width=100% cellpadding=1 cellspacing=1>
																									<tr>
																										<td align=center><input type=text name="txtsub<%=Prod_No%>To<%=Count%>" size=1 class="TextForms" onblur="Check(this)" maxlength=5 onkeypress="return GetOnlyNumbersWithA(this, event, false,true,true);"></td>
																									</tr>
																								</table>
																								
																								<%
	  																						}
																							%>
																							</td>
																							<%
																							Count++;
																							Group=3;
																						}
																						Prod_No++;
																					}
																					rdr.Close();
																				}
																				%>
																			</tr>
																			<%
																		SqlDtr.Close();
																		}
																		else
																		{
																			MessageBox.Show("Either Student Record Not Available Or Roll No. Not Set");
																		}
																	}
																}
															%>
															<input type=hidden name=Total_Prod value=<%=Prod_No%>>
															<input type=hidden name=Total_Sub value=<%=Count%>>
															<%				
														}
														catch(Exception ex)
														{
															CreateLogFiles.ErrorLog ("Form: TestSME.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
														}
														%>
													</td>	
												</tr>
												<%
											}
											else if(DropSection.SelectedIndex==0)
											{
												MessageBox.Show("Please Select Section");
											}
											else if(DropExamType.SelectedIndex==0)
											{
												MessageBox.Show("Please Select Exam Type");
											}
											else if(DropSession.SelectedIndex==0)
											{
												MessageBox.Show("Please Select Session");
											}
										}
										else 
										{
											MessageBox.Show("Please Select Class");
										}
									}
									%>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat =server >
/// <Summary>
/// This method use to insert marks in to studentmarks and studentmarksentryIandII table.
/// </Summary>

static int j=0;
public void update(Object sender, EventArgs e )
{  
	try
	{
		int Flag=0;
		//if(DropClass.SelectedItem.Text=="I" || DropClass.SelectedItem.Text=="II")
		if(DropClass.SelectedItem.Text=="I" || DropClass.SelectedItem.Text=="II" || DropClass.SelectedItem.Text=="Nursery" || DropClass.SelectedItem.Text=="LKG" || DropClass.SelectedItem.Text=="UKG")
		{	
			//insertrowIandII();
			insertrowIandII();
			Flag=1;
		}
		else
		{
			insertrow();
			Flag=1;
		}
		if(Flag==1)
			MessageBox.Show("Student Marks Saved Successfully");
		else
			MessageBox.Show("Some Problem On DataBase");
		DropClass.SelectedIndex=0;
		DropExamType.SelectedIndex=0;
		DropStream.SelectedIndex=0;
		DropSection.SelectedIndex=0;
		DropSession.SelectedIndex=0;
	}
	catch(Exception ex)
	{
		MessageBox.Show(ex.Message);
		//CreateLogFiles.ErrorLog("Form:StudentRegStatus.aspx,Method:update().   EXCEPTION " +ex.Message +"  User_ID : "+ Session["User_Name"].ToString());
		CreateLogFiles.ErrorLog("Form:TestSME.aspx,Method:insertmarks().   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
	}
}

/// <Summary>
/// This method use to save record in to studentmarks table. in this table save marks only those class student which are belongs III class to XII class.
/// </Summary>
public void insertrow()
{
	  string []subject=new string[20];
	 
	try
	{
		SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		InventoryClass obj=new InventoryClass(); 
		SqlDataReader SqlDtr;
		SqlCommand SqlCmd;
		int Total_Subject=0,Total_Sub=0;
		string prod_cat="",sql,str="",cls="",stm="";
		int flag = 0;
		int x=0;
		double total=0;
		SqlCon.Open();
			
		//str="delete from exammarksdecision where class='"+DropClass.SelectedItem.ToString()+"' and stream='"+DropStream.SelectedItem.ToString()+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
		//str="delete from StudentMarks where class='"+DropClass.SelectedItem.ToString()+"' and stream='"+DropStream.SelectedItem.ToString()+"' and exam_type='"+DropExamType.SelectedItem.Text+"'";
			
		SqlCommand scom=new SqlCommand("select class_id from class where class_name='"+DropClass.SelectedItem.ToString()+"'",SqlCon);
		SqlDataReader sdtr=scom.ExecuteReader();
		
		
		string id="",str1="";
			
		while(sdtr.Read())
		{
			str1=sdtr.GetValue(0).ToString();
		}
		sdtr.Close();
		SqlCon.Close();	
		str1=GenUtil.AddColumnNames1(str1,DropStream.SelectedItem.ToString());
		int i=0,count=0;
		while(i<str1.Length)
		{
			if(str1.Substring(i,1).Equals(","))
			{
				count++;
			}
			i++;
		}
		count++;
		
		int totalRollNo=System.Convert.ToInt32(Request.Params.Get("Total_Prod"));
		//MessageBox.Show(totalRollNo.ToString());
		for(int k=0;k<totalRollNo;k++)
		{
			
			i=0;
			string marks="";
			string rollno=Request.Params.Get("txtRoleNo"+k);
			string sname=Request.Params.Get("txtSName"+k);
			SqlCon.Open();
			//12.03.08--str="delete from StudentMarks where RoleNo='"+rollno+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"'";
			str="delete from StudentMarks where RoleNo='"+rollno+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and st_section='"+DropSection.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
			SqlCmd = new SqlCommand( str,SqlCon);
			SqlDtr = SqlCmd.ExecuteReader();
			SqlDtr.Close();
			SqlCon.Close();	
			double Total=0;
			while(i<count)
			{
				marks=marks+"'"+Request.Params.Get("txtsub"+k+"To"+i)+"'";
				i++;
				marks=marks+",";
				
			}
			//j++;
			if(marks!="")
				marks=marks.Substring(0,marks.Length-1);
			string strInsert;
			SqlCommand cmdInsert;
			SqlCon.Open();
			//strInsert = "Insert exammarksdecision(class,stream,exam_type,"+str1+") values ('"+DropClass.SelectedItem.ToString()+"','"+DropStream.SelectedItem.ToString()+"','"+DropExamType.SelectedItem.ToString()+"',"+marks+")";
			//strInsert = "insert StudentMarks(RoleNo,Student_Name,Class,Stream,Exam_Type,"+str1+",total,st_section) values('"+rollno+"','"+sname+"','"+DropClass.SelectedItem.Text+"','"+DropStream.SelectedItem.Text+"','"+DropExamType.SelectedItem.Text+"',"+marks+","+Total+",'"+DropSection.SelectedItem.Text+"')";
			//12.03.08--strInsert = "insert StudentMarks(RoleNo,Student_Name,Class,Stream,Exam_Type,"+str1+",st_section) values('"+rollno+"','"+sname+"','"+DropClass.SelectedItem.Text+"','"+DropStream.SelectedItem.Text+"','"+DropExamType.SelectedItem.Text+"',"+marks+",'"+DropSection.SelectedItem.Text+"')";
			strInsert = "insert StudentMarks(RoleNo,Student_Name,Class,Stream,Exam_Type,"+str1+",st_section,year) values('"+rollno+"','"+sname+"','"+DropClass.SelectedItem.Text+"','"+DropStream.SelectedItem.Text+"','"+DropExamType.SelectedItem.Text+"',"+marks+",'"+DropSection.SelectedItem.Text+"','"+DropSession.SelectedItem.Text+"')";
			cmdInsert=new SqlCommand (strInsert,SqlCon);			
			cmdInsert.ExecuteNonQuery();
			SqlCon.Close();	
		}
	}
	catch(Exception ex)
	{
		//MessageBox.Show(ex.Message);
		CreateLogFiles.ErrorLog("Form:TestSME.aspx,Method:insertmarks().   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
	}
}

/// <Summary>
/// This method use to save record in to studentmarksentryIandII table. in this table save marks only those class student which are belongs nursary class to II class.
/// </Summary>
public void insertrowIandII()
{
	string []subject=new string[20];
	// string []subject=new string[22];
	try
	{
		SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		InventoryClass obj=new InventoryClass(); 
		SqlDataReader SqlDtr;
		SqlCommand SqlCmd;
		int Total_Subject=0,Total_Sub=0;
		string prod_cat="",sql,str="",cls="",stm="";
		int flag = 0;
		int x=0;
		double total=0;
		SqlCon.Open();
		SqlCommand scom=new SqlCommand("select class_id from class where class_name='"+DropClass.SelectedItem.ToString()+"'",SqlCon);
		SqlDataReader sdtr=scom.ExecuteReader();
		string id="",str1="";
		while(sdtr.Read())
		{
			str1=sdtr.GetValue(0).ToString();
		}
		sdtr.Close();
		SqlCon.Close();
		
		
		str1=GenUtil.AddColumnNames2(str1,DropStream.SelectedItem.ToString());
		int i=0,count=0;
		while(i<str1.Length)
		{
			if(str1.Substring(i,1).Equals(","))
			{
				count++;
			}
			i++;
		}
		count++;
		
		int totalRollNo=System.Convert.ToInt32(Request.Params.Get("Total_Prod1"));
		//MessageBox.Show(totalRollNo.ToString());
		for(int k=0;k<totalRollNo;k++)
		{
			string rollno=Request.Params.Get("txtRoleNo"+k);
			string sname=Request.Params.Get("txtSName"+k);
			SqlCon.Open();
			//12.03.08--str="delete from StudentMarksEntryIandII where RollNo='"+rollno+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"'";
			str="delete from StudentMarksEntryIandII where RollNo='"+rollno+"' and Exam_Type='"+DropExamType.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
			SqlCmd = new SqlCommand( str,SqlCon);
			SqlDtr = SqlCmd.ExecuteReader();
			SqlDtr.Close();
			SqlCon.Close();
			double Total=0;
			i=0;
			string marks="";
			while(i<count)
			{
				if(Request.Params.Get("txtsub1"+k+"To"+i)!="")
					marks=marks+"'"+Request.Params.Get("txtsub1"+k+"To"+i)+"'";
				else
					marks=marks+"'0'";
				i++;
				marks=marks+",";
				//MessageBox.Show(marks.ToString());		
			}
			//return;
			//j++;
			if(marks!="")
				marks=marks.Substring(0,marks.Length-1);
			string strInsert;
			SqlCommand cmdInsert;
			//MessageBox.Show(rollno);
			//MessageBox.Show(str1);
			//MessageBox.Show(marks);
			
			SqlCon.Open();
			//12.03.08--strInsert = "insert StudentMarksEntryIandII (Rollno,Exam_type,Eng_Read,Eng_Writing,Eng_con,Eng_Spelling,Eng_compre,Hindi_read,Hindi_Writing,Hindi_Con,Hindi_spelling,hindi_com,Math_fnumber,Math_bconcept,math_computation,evs_observation,evs_identification,evs_know,phy_edu,music,art,craft,dance,computer_tot) values('"+rollno+"','"+DropExamType.SelectedItem.Text+"',"+marks+")";
			strInsert = "insert StudentMarksEntryIandII (Rollno,Exam_type,Eng_Read,Eng_Writing,Eng_con,Eng_Spelling,Eng_compre,Hindi_read,Hindi_Writing,Hindi_Con,Hindi_spelling,hindi_com,Math_fnumber,Math_bconcept,math_computation,evs_observation,evs_identification,evs_know,phy_edu,music,art,craft,dance,computer_tot,year) values('"+rollno+"','"+DropExamType.SelectedItem.Text+"',"+marks+",'"+DropSession.SelectedItem.Text+"')";
			//strInsert = "insert StudentMarksEntryIandII  values('"+rollno+"','"+DropExamType.SelectedItem.Text+"',"+marks+")";
			cmdInsert=new SqlCommand (strInsert,SqlCon);			
			cmdInsert.ExecuteNonQuery();
			SqlCon.Close();
		}
	}
	catch(Exception ex)
	{
		//MessageBox.Show(ex.Message);
		CreateLogFiles.ErrorLog("Form:TestSME.aspx,Method:insertmarks().   EXCEPTION " +ex.Message +"  User_ID : "+ pass);
	}
}
</script>
