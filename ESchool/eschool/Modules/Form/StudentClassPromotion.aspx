<%@ Page language="c#" Codebehind="StudentClassPromotion.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.StudentClassPromotion" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Import namespace="System.Net"%>
<%@ Import namespace="System.Net.Sockets"%> 
<%@ Import namespace="System.IO"%> 
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx"%>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx"%>  
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Class Promotion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../Validations.js"></script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language=javascript>
		// This method use to assgin the dropdown selected value to textbox.
		function Check(t,temp)
		{
			var index=t.selectedIndex;
			var tempvalue=t.options[index].value;
			temp.value=tempvalue;
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr>
						<td align="center"><b>STUDENT CLASS PROMOTION</b>
							<table align="center" width=100% borderColorLight="#663300" border="5">
								<tr>
									<td vAlign="middle" align="center" colSpan="28">&nbsp;Class&nbsp;
										<asp:dropdownlist CssClass=ComboBox id="DropClass" Runat="server"></asp:dropdownlist>&nbsp; 
										Section &nbsp;
										<asp:dropdownlist id="DropSection" CssClass=ComboBox Runat="server">
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
										</asp:dropdownlist>&nbsp;Stream&nbsp;<asp:dropdownlist CssClass=ComboBox id="DropStream" Runat="server">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Biology">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Mathematics">Math Group</asp:ListItem>
										</asp:dropdownlist>&nbsp;Session&nbsp;<asp:dropdownlist id="DropSession" CssClass=ComboBox Runat="server" AutoPostBack=False>
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
										&nbsp;<asp:button id="btnShow" Runat="server" CssClass="FormButtonStyle" BorderColor=black Height=21 BorderStyle=Groove Width=100  Text="Show"></asp:button>&nbsp;
										<asp:Button ID=btSave Runat=server CssClass="FormButtonStyle" BorderColor=black BorderStyle=Groove Height=21 Width=85  OnClick="updateclass" Text=Submit></asp:Button>&nbsp;&nbsp;</td>
								</tr>
								<%
									if(flage==true)
									{
									
									  try
									  {
										if(!(DropClass.SelectedItem.Text=="I"||DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG"||DropClass.SelectedItem.Text=="Nursery"))
										{
											
											double marks=0,per=0;
											double[]max=new double[25];
											double grandTotal1=0;
											int c=0;
											bool flag=true;
											InventoryClass obj1=new InventoryClass();
											InventoryClass obj2=new InventoryClass();
											SqlDataReader SqlDtr,SqlDtr1;
											string cls="";
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
												
												
												string[] no_of_subject=obj1.GetSubject1(DropClass.SelectedItem.Text,DropStream.SelectedItem.Text);
												if(no_of_subject.Length==0)
												{
													//MessageBox.Show("Subject Not Available");
													//return;
												}
												
											string str1="";
											string str2="",str3="";
											string col="",col1="";
											string name="",name1="";
											int count=0;
											
											str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"')";
											SqlDtr=obj1.GetRecordSet(str1);
											while(SqlDtr.Read())
											{
											   if(count==0)
											   {
													%>
													<tr bgColor="#663300">
													<td align="center"><b><font color="#ffffff">Student ID</font></b></td>
													<td align="center"><b><font color="#ffffff">Student Name</font></b></td>
													<%
											   }
												name=SqlDtr.GetValue(0).ToString().Trim();
												name1=SqlDtr.GetValue(0).ToString().Trim();
												//MessageBox.Show(name.ToString());
												
													if(name.ToUpper()=="PHYSICS")
													{
														%>
														
																<td align=center><b><font color=#ffffff>Physics_th.</font></b></td>
																<td align=center><b><font color=#ffffff>Physics_Pr.</font></b></td>
																<td align=center><b><font color=#ffffff>Physics_Tot.</font></b></td>
															
														<%
													}
													else if(name.ToUpper()=="CHEMISTRY" )
													{
														%>
														
																<td align=center><b><font color=#ffffff>Chemistry_th.</font></b></td>
																<td align=center><b><font color=#ffffff>Chemistry_Pr.</font></b></td>
																<td align=center><b><font color=#ffffff>Chemistry_Tot.</font></b></td>
															
														<%
													}
													else if( name.ToUpper()=="BIOLOGY")
													{
														%>
														
																<td align=center><b><font color=#ffffff>Biology_th.</font></b></td>
																<td align=center><b><font color=#ffffff>Biology_Pr.</font></b></td>
																<td align=center><b><font color=#ffffff>Biology_Tot.</font></b></td>
															
														<%
													}
													else if((name.ToUpper()=="COMPUTER")|| (DropClass.SelectedItem.Text=="XI" &&DropClass.SelectedItem.Text=="XII"))
													{
														%>
														
																<td align=center><b><font color=#ffffff>Computer_th.</font></b></td>
																<td align=center><b><font color=#ffffff>Computer_Pr.</font></b></td>
																<td align=center><b><font color=#ffffff>Computer_Tot.</font></b></td>
															
														<%
													}
													else
													{
														%>
														<td align="center"><b><font color="#ffffff"><%=name.ToString()%></font></b><br>
														<%
													}%>
													</td>
												<%
												/*if(name.IndexOf(" ")>0)
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
													name=name+"_th, " + name + "_pr " ;*/
													
												if(name.IndexOf(" ")>0)
													name1=name1.Replace(" ","_");
													name=name.Replace(" ","_");
												if(name.IndexOf("&")>0)
													name1=name1.Replace("&","and");
													name=name.Replace("&","and");
												if(((name.Equals("COMPUTER"))||(DropClass.SelectedItem.Text=="XI" && DropClass.SelectedItem.Text=="XII")))
												{
													name1=name1 + "_th , " + name1 + "_pr , "+ name1+ "_tot";
													name=name + "_th as float)), " + name + "_pr as float)), "+ name+ "_tot";
												}
												if(name.Equals("PHYSICS"))
												{
													name1=name1 + "_th ,  " + name1 + "_pr, "+ name1+ "_tot";
													name=name + "_th as float)),sum(cast( " + name + "_pr as float)),sum(cast( "+ name+ "_tot";
												}
												if(name.Equals("BIOLOGY"))
												{
													name1=name1 + "_th , " + name1 + "_pr, "+ name1+ "_tot";
													name=name + "_th as float)),sum(cast( " + name + "_pr as float)),sum(cast( "+ name+ "_tot";
												}
												if(name.Equals("CHEMISTRY"))
												{
													name1=name1 + "_th," + name1 + "_pr,"+ name1+ "_tot";
													name=name + "_th as float)),sum(cast( " + name + "_pr as float)),sum(cast( "+ name+ "_tot";
												}
												
												/*col=col+"sum(cast("+name;
												col=col+" as float)),";
												col1=col1+name;
												col1=col1+",";*/
												
												col=col+"sum(cast("+name;
												col=col+" as float)),";
												col1=col1+name1;
												col1=col1+",";
												count++;
												
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
											}
												SqlDtr.Close();
												
												 if(col1=="")
													{
												         MessageBox.Show("Subject Not Available");
												         //return;
													}
													else
													{
														str3="select "+ col1+ " from Exammarksdecision where class='"+DropClass.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
													}
													SqlDtr=obj1.GetRecordSet(str3);
													int n=0;
													int i=0;
													while(SqlDtr.Read())
													{
														n=SqlDtr.FieldCount;
														for(i=0;i<n;i++)
														{
															if(!SqlDtr.GetValue(i).ToString().Equals(""))///&&!SqlDtr.GetValue(i).ToString().Equals("A"))
															max[i]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
															grandTotal1=grandTotal1+max[i];
														}
													}
													SqlDtr.Close();
													if(n==0)
													{
														AppearedStudent=0;
														PassedStudent=0;
														passPercentage=0;
													}
									  				%>
													<td align="center" ><b><font color="#ffffff">Tot_Marks</font></b></td>
													<td align="center" ><b><font color="#ffffff">Percent</font></b></td>
													<td align="center" ><b><font color="#ffffff">Result</font></b></td>
												</tr>
												<%
												SqlConnection con;
								  				SqlCommand cmd,cmd1;
												SqlDataReader dr=null,dr1=null;
												con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
												con.Open();
												string str="select sum(total) from exammarksdecision where class='"+DropClass.SelectedItem.Text+"'";
												cmd=new SqlCommand(str,con);
												dr=cmd.ExecuteReader();
												int Totalmarks=0;
												while(dr.Read())
												{
													Totalmarks=Convert.ToInt32(dr.GetValue(0).ToString());
												}
												dr.Close();
												str="select Student_id,Student_fname,Year from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
												cmd=new SqlCommand(str,con);
												dr=cmd.ExecuteReader();
												int l=1,m=1;
												
												while(dr.Read())
												{
													%>
													<tr>
														<td align="right"><%=dr.GetValue(0).ToString()%></td>
														<td align="left">&nbsp;<%=dr.GetValue(1).ToString()%></td>
														<%
														str2="select "+ col +" from studentmarks where Roleno="+dr.GetValue(0).ToString()+" and year='"+DropSession.SelectedItem.Text+"'";
														SqlDtr1=obj2.GetRecordSet(str2);
														SqlDtr=obj1.GetRecordSet(str3);
														double test=0;
														int a=0;
														double total=0;
														marks=0;
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
																	total=total+marks;
																	max[j]=(max[j]*40)/100;
																	%>
																	<td align="right">&nbsp;<%=marks.ToString()%></td>
																	<%
														
																	if(marks<max[j])
											          				{
													        			flag=false;
																	}
									    							else
										        					{
												        				test=test+marks;
												        				//MessageBox.Show(test.ToString()+"  "+marks.ToString());
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
															%>
																<td align="center">&nbsp;<%=total.ToString()+" / "+grandTotal1.ToString()%></td>
															<%	
															per=(total*100)/grandTotal1;
														%>
														<td align="center">&nbsp;<%=Math.Round(per).ToString()+" % "%></td>
														<%
														if(per>=40)
														{
															%>
															<td align=center><select id=DropResult0 class=ComboBox onchange="Check(this,document.Form1.Tempresult<%=m%>)"  name=DropResult<%=l%>>
																<option value=1>Pass</option>
																<option value=2>Pass WG</option>
																<option value=0>Fail</option>
																</select>
																<input type=hidden name=Tempresult<%=m%> value=1>
															</td>
															<%
														}
														else
														{ 
															%>
															<td align=center><select id=DropResult2 class=ComboBox onchange="Check(this,document.Form1.Tempresult<%=m%>)" name=DropResult<%=l%>>
																<option value=0>Fail</option>
																<option value=1>Pass</option>
																<option value=2>Pass WG</option>									
																</select>
																<input type=hidden name=Tempresult<%=m%> value=0 >
															</td>
															<%
														}
													}
													if(flag1==false)
													   MessageBox.Show("Data may be not available");
													SqlDtr1.Close();
													SqlDtr.Close();
			                                        m++;
												}
											}
											else
											{
												string cls="";
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
												
												double marks=0,per=0;
												double[]max=new double[25];
												double grandTotal1=0;
												int c=0;
												bool flag=true;
												InventoryClass obj1=new InventoryClass();
												InventoryClass obj2=new InventoryClass();
												InventoryClass obj3=new InventoryClass();
												SqlDataReader SqlDtr=null,SqlDtr1=null,SqlDtr2=null;
												string str1="";
												string str2="",str3="";
												string col="",col1="";
												string name="";
												bool flage1=false,flage2=false,flage3=false;
												
												str1="select subject_name from subject where subject_id in (select subject_id from classwisesubjects where class_id='"+ cls + "' and stream='"+DropStream.SelectedItem.Text+"')";
												SqlDtr2=obj3.GetRecordSet(str1);
												if(!(SqlDtr2.HasRows))
												{
													//MessageBox.Show("Subject not Assigned");
													flage1=true;
												}
												SqlDtr2.Close();
												
												str2="select *  FROM Exammarksdecision where class='"+DropClass.SelectedItem.Text+"' and stream='"+DropStream.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
												SqlDtr2=obj3.GetRecordSet(str1);
												if(!(SqlDtr2.HasRows))
												{
													//MessageBox.Show("Please take Exam marks Decision");
													flage2=true;
												}
												SqlDtr2.Close();
												
												if(flage1==true || flage2==true)
												{
													MessageBox.Show("Data may not be available");
												}
												
												str3="select Eng_Read,Eng_Writing,Eng_Con,Eng_Spelling,Eng_Compre,Hindi_Read,Hindi_Writing,Hindi_Con,Hindi_spelling,Hindi_Com,Math_FNumber,Math_BConcept,Math_Computation,evs_observation,evs_Identification,Evs_know,Phy_edu,Music,Art,Craft,Dance,Computer_tot  from Exammarksdecision where class='"+DropClass.SelectedItem.Text+"' and Year='"+DropSession.SelectedItem.Text+"'";
												SqlDtr=obj1.GetRecordSet(str3);
												int n=0;
												int i=0;
												if((SqlDtr.HasRows))
												{
													while(SqlDtr.Read())
													{
														n=SqlDtr.FieldCount;
														for(i=0;i<n;i++)
														{
															if(!SqlDtr.GetValue(i).ToString().Equals(""))///&&!SqlDtr.GetValue(i).ToString().Equals("A"))
															max[i]=System.Convert.ToDouble(SqlDtr.GetValue(i).ToString());
															grandTotal1=grandTotal1+max[i];
															//MessageBox.Show(grandTotal1+" : "+max[i]);
														}
													}
												}
												
												SqlDtr.Close();
												if(n==0)
												{
													AppearedStudent=0;
													PassedStudent=0;
													passPercentage=0;
												}
												
												if(flage1==false)
												{
												%>
												<tr bgColor="#663300">
													<th rowspan=2><font color="#ffffff">Stud_ID</font></th>
													<th rowspan=2><font color="#ffffff">Student_Name</font></th>
													<td align="center" colspan=5><b><font color="#ffffff">English</font></b></td>
													<td align="center" colspan=5><b><font color="#ffffff">Hindi</font></b></td>
													<td align="center" colspan=3><b><font color="#ffffff">Math</font></b></td>
													<td align="center" colspan=3><b><font color="#ffffff">EVS</font></b></td>
													<td align="center" colspan=6><b><font color="#ffffff">Non Scholastic</font></b></td>
													<th rowspan=2><font color="#ffffff">Tot_Marks</font></th>
													<th rowspan=2><font color="#ffffff">Percent</font></th>
													<th rowspan=2><font color="#ffffff">Result</font></th>
												</tr>
												<tr bgColor="#663300">
													<td align="center" ><b><font color="#ffffff">Eng_Read</font></b></td>
													<td align="center" ><b><font color="#ffffff">Eng_Writing</font></b></td>
													<td align="center" ><b><font color="#ffffff">Eng_Con</font></b></td>
													<td align="center" ><b><font color="#ffffff">Eng_Spelling</font></b></td>
													<td align="center" ><b><font color="#ffffff">Eng_Compre</font></b></td>
													<td align="center" ><b><font color="#ffffff">Hindi_Read</font></b></td>
													<td align="center" ><b><font color="#ffffff">Hindi_Writing</font></b></td>
													<td align="center" ><b><font color="#ffffff">Hindi_Con</font></b></td>
													<td align="center" ><b><font color="#ffffff">Hindi_Spelling</font></b></td>
													<td align="center" ><b><font color="#ffffff">Hindi_Compre</font></b></td>
													<td align="center" ><b><font color="#ffffff">Math_FNumber</font></b></td>
													<td align="center" ><b><font color="#ffffff">Math_BConcept</font></b></td>
													<td align="center" ><b><font color="#ffffff">Math_Computation</font></b></td>
													<td align="center" ><b><font color="#ffffff">evs_observation</font></b></td>
													<td align="center" ><b><font color="#ffffff">evs_Identification</font></b></td>
													<td align="center" ><b><font color="#ffffff">evs_know</font></b></td>
													<td align="center" ><b><font color="#ffffff">Phy.edu</font></b></td>
													<td align="center" ><b><font color="#ffffff">Music</font></b></td>
													<td align="center" ><b><font color="#ffffff">Art</font></b></td>
													<td align="center" ><b><font color="#ffffff">Craft</font></b></td>
													<td align="center" ><b><font color="#ffffff">Dance</font></b></td>
													<td align="center" ><b><font color="#ffffff">Computer</font></b></td>
												</tr>
												
												<%
											
												SqlConnection con;
								  				SqlCommand cmd,cmd1;
												SqlDataReader dr=null,dr1=null;
												con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
												con.Open();
												string str="select Student_id,Student_fname,Year from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"' order by student_fname";
												cmd=new SqlCommand(str,con);
												dr=cmd.ExecuteReader();
												int l=1,m=1;
												if(!(dr.HasRows))
												{
													MessageBox.Show("Student Not available");
												}
												while(dr.Read())
												{
													%>
													<tr>
														<td align=center><%=dr.GetValue(0).ToString()%></td>
														<td align="left">&nbsp;<%=dr.GetValue(1).ToString()%></td>
														<%
														str2="select sum(cast(Eng_Read as float)),sum(cast(Eng_Writing as float)),sum(cast(Eng_Con as float)),sum(cast(Eng_Spelling as float)),sum(cast(Eng_Compre as float)),sum(cast(Hindi_Read as float)),sum(cast(Hindi_Writing as float)),sum(cast(Hindi_Con as float)),sum(cast(Hindi_spelling as float)),sum(cast(Hindi_Com as float)),sum(cast(Math_FNumber as float)),sum(cast(Math_BConcept as float)),sum(cast(Math_Computation as float)),sum(cast(evs_observation as float)),sum(cast(evs_Identification as float)),sum(cast(Evs_know as float)),sum(cast(Phy_edu as float)),sum(cast(Music as float)),sum(cast(Art as float)),sum(cast(Craft as float)),sum(cast(Dance as float)),sum(cast(Computer_tot as float))  FROM STUDENTMARKSENTRYIANDII where Rollno="+dr.GetValue(0).ToString()+" and year='"+DropSession.SelectedItem.Text+"'"; //for class I and II
        												SqlDtr1=obj2.GetRecordSet(str2);
														SqlDtr=obj1.GetRecordSet(str3);//max marks
														double test=0;
														int a=0;
														double total=0;
														marks=0;
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
																	total=total+marks;
																	max[j]=(max[j]*40)/100;
																	%>
																	<td align=center>&nbsp;<%=marks.ToString()%></td>
																	<%
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
																else if(SqlDtr1.GetValue(j).ToString().Equals("A"))
																{
																    %>														   
																	<td align=center>A</td>
																	<%
																}
																else
																{
																	%>
																	<td align=center>&nbsp;<%=marks.ToString()%></td>
																	<%
																}
															}
				                                            if(c>=2)
															{
																FailStudent++;
																c=0;
															}
															%>
															<td align="center">&nbsp;<%=total.ToString()+" / "+grandTotal1.ToString()%></td>
															<%	
															per=(total*100)/grandTotal1;
															%>
															<td align="center">&nbsp;<%=Math.Round(per).ToString()+" % "%></td>
															<%
															if(per>=40)
															{
																%>
																<td align=center><select class=ComboBox onchange="Check(this,document.Form1.Tempresult<%=m%>)" id=DropResult name=DropResult<%=l%>>
																<option value=1>Pass</option>
																<option value=2>Pass WG</option>
																<option value=0>Fail</option>
																</select><input type=hidden name=Tempresult<%=m%> value=1 ></td>
																<%
															}
															else
															{ 
																%>
																<td align=center><select class=ComboBox id=DropResult1 onchange="Check(this,document.Form1.Tempresult<%=m%>)" name=DropResult<%=l%>>
																<option value=0>Fail</option>
																<option value=1>Pass</option>
																<option value=2>Pass WG</option>									
																</select><input type=hidden name=Tempresult<%=m%> value=0 ></td>
																<%
															}
														}
														if(flag1==false)
															MessageBox.Show("Data may be not available");
														SqlDtr1.Close();
														SqlDtr.Close();
			                                            m++;
													}
												  }
												}
											}
											catch(Exception ex)
											{
											    CreateLogFiles.ErrorLog ("Form: AdvanceFeesReport.aspx.cs, Method: btnSearch_Click. Exception: " + ex.Message + " User: " + Session["password"] );
											}
									}
								
								 %>
								</tr>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
			<script language=C# runat=server>
			
			/// <Summary>
			/// This method use to class updation. first it check hiddentextbox value if it is 1 then update the class else class not update.
			/// </Summary>
			public void updateclass(Object sender, EventArgs e)
			{
			 try
			 {
			    EmployeeClass obj=new EmployeeClass();
			    EmployeeClass obj2=new EmployeeClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,SqlDtr1=null;
				string str="",str1="",str2="",newsession="";
				string sess="";
				string[] session=new string[15]{"2006:2007","2007:2008","2008:2009","2009:2010","2010:2011","2011:2012","2012:2013","2013:2014","2014:2015","2015:2016","2016:2017","2017:2018","2018:2019","2019:2020","2020:2021"};
				
				for(int s=0;s<session.Length;s++)
				{
				    if(session[s]==DropSession.SelectedItem.Text)
				    {
				         sess=session[s+1];
				         //MessageBox.Show(sess); 
				    }
				}
				
				str="select Student_id,Student_fname,Year from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"' and year='"+DropSession.SelectedItem.Text+"'";
				SqlDtr=obj1.GetRecordSet(str);
				int l=1;
				if(SqlDtr.HasRows)
				{
				while(SqlDtr.Read())
					{
					    if(SqlDtr.GetValue(0).ToString()!="" && SqlDtr.GetValue(0).ToString()!=null)
					    {    
                                 
					            if(Request.Params.Get("Tempresult"+l)!="" && Request.Params.Get("Tempresult"+l)!=null)
					            { 
					          if(Request.Params.Get("Tempresult"+l)=="1")
								{   
									if(DropClass.SelectedItem.Text=="Nursery")
								    {
									   str1="Update Student_Record set Student_class='LKG',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
									   str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
									}
									if(DropClass.SelectedItem.Text=="LKG")
								    {
									   str1="Update Student_Record set Student_class='UKG',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
									   str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
									}
									if(DropClass.SelectedItem.Text=="UKG")
								    {
									   str1="Update Student_Record set Student_class='I',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
									   str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
									}
								    if(DropClass.SelectedItem.Text=="I")
								    {
									   str1="Update Student_Record set Student_class='II',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
									   str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
									}
									else if(DropClass.SelectedItem.Text=="II")
								    {
									   str1="Update Student_Record set Student_class='III',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();  
									    str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();      
									}
									else if(DropClass.SelectedItem.Text=="III")
								    {
									   str1="Update Student_Record set Student_class='IV',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();     
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();   
									}
									else if(DropClass.SelectedItem.Text=="IV")
								    {
									   str1="Update Student_Record set Student_class='V',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();     
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();   
									}
									else if(DropClass.SelectedItem.Text=="V")
								    {
									   str1="Update Student_Record set Student_class='VI',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();    
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();    
									}
									else if(DropClass.SelectedItem.Text=="VI")
								    {
									   str1="Update Student_Record set Student_class='VII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();   
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();     
									}
									else if(DropClass.SelectedItem.Text=="VII")
								    {
									   str1="Update Student_Record set Student_class='VIII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();  
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();      
									}
									else if(DropClass.SelectedItem.Text=="VIII")
								    {
									   str1="Update Student_Record set Student_class='IX',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();    
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();    
									}
									else if(DropClass.SelectedItem.Text=="IX")
								    {
									   str1="Update Student_Record set Student_class='X',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();     
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();   
									}
									else if(DropClass.SelectedItem.Text=="X")
								    {
									   str1="Update Student_Record set Student_class='XI',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();    
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();    
									}
									else if(DropClass.SelectedItem.Text=="XI")
								    {
									   str1="Update Student_Record set Student_class='XII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();   
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();     
									}
									else if(DropClass.SelectedItem.Text=="XII")
								    {
									   str1="Update Student_Record set Student_class='XIII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();  
									    str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();      
									}
									
									obj.ExecRecord(str1);
									obj2.ExecRecord(str2);
									
								}
								else
									 {
									 
										if(DropClass.SelectedItem.Text=="Nursery")
											{
												str1="Update Student_Record set Student_class='Nursery',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
											}
										if(DropClass.SelectedItem.Text=="LKG")
											{
												str1="Update Student_Record set Student_class='LKG',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
											}
										if(DropClass.SelectedItem.Text=="UKG")
											{
												str1="Update Student_Record set Student_class='UKG',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
											}
										if(DropClass.SelectedItem.Text=="I")
											{
												str1="Update Student_Record set Student_class='I',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="II")
											{
												str1="Update Student_Record set Student_class='II',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarksentryIandII set result='"+Request.Params.Get("Tempresult"+l)+"' where rollno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="III")
											{
												str1="Update Student_Record set Student_class='III',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="IV")
											{
												str1="Update Student_Record set Student_class='IV',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="V")
											{
												str1="Update Student_Record set Student_class='V',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="VI")
											{
												str1="Update Student_Record set Student_class='VI',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="VII")
											{
												str1="Update Student_Record set Student_class='VII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="VIII")
											{
												str1="Update Student_Record set Student_class='VIII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="IX")
											{
												str1="Update Student_Record set Student_class='IX',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="X")
											{
												str1="Update Student_Record set Student_class='X',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="XI")
											{
												str1="Update Student_Record set Student_class='XI',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
										else if(DropClass.SelectedItem.Text=="XII")
											{
												str1="Update Student_Record set Student_class='XII',Year='"+sess+"' where Student_id="+SqlDtr.GetValue(0).ToString();        
												str2="update studentmarks set result='"+Request.Params.Get("Tempresult"+l)+"' where roleno="+SqlDtr.GetValue(0).ToString();
											}
					                    //MessageBox.Show(SqlDtr.GetValue(0).ToString());    
					                    obj.ExecRecord(str1);
					                    obj2.ExecRecord(str2);
									  //  MessageBox.Show("Update");

					                 }
					                 }
					               l++;
					    
					        }
					       
					}
					 MessageBox.Show(" Class Updated");
					 DropClass.SelectedIndex=0;
					 DropSection.SelectedIndex=0;
					 DropSession.SelectedIndex=0;
					 DropStream.SelectedIndex=0;
				 }
				 else
				 {
				      MessageBox.Show(" Record Not Found");
				 }
				}
				catch(Exception ex)
				{
				      CreateLogFiles.ErrorLog ("Form: StudentClassPromotion.aspx.cs, Method: HTML . Exception: " + ex.Message + " User: " + Session["password"] );
				}
			}
			</script>
		</TBODY></TABLE></TR></TBODY></TABLE>
	</body>
</HTML>

