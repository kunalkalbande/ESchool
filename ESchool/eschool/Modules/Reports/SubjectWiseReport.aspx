<%@ Page language="c#" Codebehind="SubjectWiseReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.SubjectWiseReport" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Result at a Glance (Subject Wise) Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method not in use.
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="780" align="center" border="0">
				<TBODY>
					<tr>
						<td align="center"><b>RESULT AT A GLANCE (SUBJECT WISE) REPORT</b>
							<table borderColorLight="#663300" border="5">
								<tr align="center">
									<td colSpan="16">
										Class&nbsp;<asp:dropdownlist id="DropClass" CssClass="ComboBox" Runat="server">
											<asp:ListItem Value="Select">Select</asp:ListItem>
										</asp:dropdownlist>&nbsp; Section&nbsp;<asp:dropdownlist id="DropSection" Width="60px" CssClass="ComboBox" Runat="server">
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
										</asp:dropdownlist>
										Stream&nbsp;
										<asp:dropdownlist id="DropStream" CssClass="ComboBox" Width="110px" Runat="server">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										</asp:dropdownlist>&nbsp; Exam Type&nbsp;
										<asp:dropdownlist id="DropExamType" CssClass="ComboBox" Width="110px" Runat="server">
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
										</asp:dropdownlist>&nbsp; Session&nbsp;&nbsp;
										<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack="False">
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
								<tr align="center">
									<td colspan="16">
										<asp:button id="btnsearch" Runat="server" CssClass="formbuttonstyle" Text="Show" Height="21"
											BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" Width="100px" Font-Size="X-Small"></asp:button>&nbsp;
										<asp:button id="btnprint" CssClass="formbuttonstyle" Runat="server" Text="Print" Width="85px"
											Height="21" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" Font-Size="X-Small"></asp:button>&nbsp;
										<asp:button id="Btnexcel" CssClass="formbuttonstyle" Runat="server" Text="Excel" Width="85px"
											Height="21" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" Font-Size="X-Small"></asp:button>
									</td>
								</tr>
								<%
								if(DropClass.SelectedIndex!=0)
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
							
									//string str="select subject_name from subject s,classwisesubjects c where s.subject_id=c.subject_id and class_id='"+cls+"' and stream = '"+DropStream.SelectedItem.Text+"' order by subject_name";
									string str="select subject_name from subject s,classwisesubjects c where s.subject_id=c.subject_id and class_id='"+cls+"' and stream = '"+DropStream.SelectedItem.Text+"' and status=1 order by subject_name";
									SqlDtr=obj.GetRecordSet(str);
									 
									if(SqlDtr.HasRows)
									{
									
										%>
								<tr bgColor="#663300">
									<td align="center"><b><font color="#ffffff">Subject Name </font></b>
									</td>
									<td align="center"><b><font color="#ffffff">A+<br>
												(95% &amp; Above)</font></b></td>
									<td align="center"><b><font color="#ffffff">A<br>
												(85% To 94%)</font></b></td>
									<td align="center"><b><font color="#ffffff">B+<br>
												(75% To 84%)</font></b></td>
									<td align="center"><b><font color="#ffffff">B<br>
												(65% To 74%)</font></b></td>
									<td align="center"><b><font color="#ffffff">C+<br>
												(55% To 64%)</font></b></td>
									<td align="center"><b><font color="#ffffff">C<br>
												(45% To 54%)</font></b></td>
									<td align="center"><b><font color="#ffffff">D<br>
												(40% To 44%)</font></b></td>
									<td align="center"><b><font color="#ffffff">E<br>
												(Below 40%)</font></b></td>
									<td align="center"><b><font color="#ffffff">Absent</font></b></td>
									<td align="center"><b><font color="#ffffff">Fail</font></b></td>
									<td align="center"><b><font color="#ffffff">Highest Score</font></b></td>
									<td align="center"><b><font color="#ffffff">Highest Scorer</font></b></td>
									<td align="center"><b><font color="#ffffff">Average Marks</font></b></td>
									<td align="center"><b><font color="#ffffff">Pass %</font></b></td>
									<td align="center"><b><font color="#ffffff">Subject Teacher</font></b></td>
								</tr>
								<%
										int i=0;
										while(SqlDtr.Read())
										{
											//if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II"))
											if((DropClass.SelectedItem.Text=="I")||(DropClass.SelectedItem.Text=="II")||(DropClass.SelectedItem.Text=="Nursery")||(DropClass.SelectedItem.Text=="LKG")||(DropClass.SelectedItem.Text=="UKG"))
											{
												if(SqlDtr["Subject_Name"].ToString()=="ENGLISH")
												{
													string[] sub={"Eng. Reading","Writing","Conversation","E Spelling","Comprehension"};
													for(int j=0;j<5;j++)
													{
														%>
								<tr>
									<td align="center"><%=sub[j].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]%>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%
														i++;	
													}
												}
												else if(SqlDtr["Subject_Name"].ToString()=="HINDI")
												{
													string[] sub={"H Reading","H Writing","H Conversation","H Spelling","H Comprehension"};
													for(int j=0;j<5;j++)
													{
														%>
								<tr>
									<td align="center"><%=sub[j].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]%>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%i++;			
													}//end for
												}
												else if(SqlDtr["Subject_Name"].ToString()=="MATHEMATICS")
												{
													string[] sub={"MATHS F N","MATHS UBC","MATHS CA"};
													for(int j=0;j<3;j++)
													{
														%>
								<tr>
									<td align="center"><%=sub[j].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]%>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%			
														i++;
													}//end for
												}
												 else if(SqlDtr["Subject_Name"].ToString()=="EVS")
												{
													string[] sub={"EVS OBS","EVS ID","EVS KL"};
													for(int j=0;j<3;j++)
													{
														%>
								<tr>
									<td align="center"><%=sub[j].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]%>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%		i++;
													}//end for
												}
												else
												{
													%>
								<tr>
									<td align="center"><%=SqlDtr["Subject_Name"].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]%>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%i++;    
												}//end else
											}//end if
											else
											{
												%>
								<tr>
									<td align="center"><%=SqlDtr["Subject_Name"].ToString()%></td>
									<td align="center"><%=grade[i,0]%>&nbsp;</td>
									<td align="center"><%=grade[i,1]%>&nbsp;</td>
									<td align="center"><%=grade[i,2]%>&nbsp;</td>
									<td align="center"><%=grade[i,3]%>&nbsp;</td>
									<td align="center"><%=grade[i,4]%>&nbsp;</td>
									<td align="center"><%=grade[i,5]%>&nbsp;</td>
									<td align="center"><%=grade[i,6]%>&nbsp;</td>
									<td align="center"><%=grade[i,7]%>&nbsp;</td>
									<td align="center"><%=grade[i,9]%>&nbsp;</td> <!--This is for absent-->
									<td align="center"><%=grade[i,7]%>&nbsp;</td> <!--This is for Fail-->
									<td align="center"><%=grade[i,8]%>&nbsp;</td>
									<td align="center"><%=sname[i]  %>&nbsp;</td>
									<td align="center"><%=avgMarks[i]%>&nbsp;</td>
									<td align="center"><%=passPer[i]%>&nbsp;</td>
									<td align="center"><%=tname[i]%>&nbsp;</td>
								</tr>
								<%i++;    
											}
										}
									}
									else
									{
										MessageBox.Show("Subject Not Available");
										return;
									}
									SqlDtr.Close();
								}%>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
