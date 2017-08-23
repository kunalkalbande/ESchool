<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Page language="c#" Codebehind="WeightageReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.WeightageReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Weightage Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" align="center">
				<tr>
					<td align="center"><B>WEIGHTAGE REPORT</B>
						<table cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<tr>
								<td colSpan="29">Class&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropClass" Runat="server" Width="80" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;Section&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropSec" Runat="server" Width="80" CssClass="ComboBox">
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
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropStream" Runat="server" Width="150px" CssClass="ComboBox">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
										<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
									</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnShow" BorderColor="Black" Runat="server"
										Width="100px" CssClass="formbuttonstyle" Height="21" Text="Show"></asp:button>&nbsp;&nbsp;<asp:button id="btnPrint" BorderColor="Black"  Runat="server"
										Width="85px" CssClass="formbuttonstyle"  Height="21" Text="Print"></asp:button>&nbsp;&nbsp;<asp:button id="Btnexcel" BorderColor="Black" Runat="server"
										Width="85px" CssClass="formbuttonstyle" Height="21" Text="Excel"></asp:button></td>
							</tr>
							<%					
								try
								{
									if(View!=0)
									{
									if((DropClass.SelectedItem.Text=="I" || DropClass.SelectedItem.Text=="II"||DropClass.SelectedItem.Text=="Nursery" ||DropClass.SelectedItem.Text=="LKG"||DropClass.SelectedItem.Text=="UKG")&& DropSec.SelectedIndex!=0)// && DropStream.SelectedIndex!=0)
									{
										%>
							<asp:panel id="PanFirstToSecond" Runat="server">
								<TR>
									<TD>
										<TABLE cellSpacing="0" cellPadding="0" borderColorLight="#663300" border="1">
											<TR bgColor="#663300">
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Roll No</FONT></B></TH>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Name of Student</FONT></B></TH><%
														if(Subject.Length>0)
														{
															for(int ii=0;ii<Subject.Length;ii++)
															{
																if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE"&&Subject[ii].ToUpper()!="COMPUTER")//THIS FOR NON SCHOLASTIC
																{
																	%>
												<TH colSpan="5">
													<B><FONT color="#ffffff">
															<%=Subject[ii].ToString().ToUpper()%>
														</FONT></B>
												</TH>
												<%
																}
															}
															for(int ii=0;ii<Subject.Length;ii++)
															{
																if(Subject[ii].ToUpper()=="MUSIC"||Subject[ii].ToUpper()=="ART"||Subject[ii].ToUpper()=="CRAFT"||Subject[ii].ToUpper()=="PHY_EDU"||Subject[ii].ToUpper()=="DANCE"||Subject[ii].ToUpper()=="GK"||Subject[ii].ToUpper()=="GSTUDIES"||Subject[ii].ToUpper()=="ART_AND_CRAFT"||Subject[ii].ToUpper()=="WORK_EXP"||Subject[ii].ToUpper()=="MORAL_SCIENCE"||Subject[ii].ToUpper()=="MUSIC_AND_DANCE"||Subject[ii].ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
																{
																	%>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">
															<%=Subject[ii].ToString().ToUpper()%>
														</FONT></B>
												</TH>
												<%
																}
															}
															%>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Grand Total</FONT></B></TH>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Overall Grade</FONT></B></TH>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Rank</FONT></B></TH>
												<TH rowSpan="2">
													<B><FONT color="#ffffff">Remark</FONT></B></TH><%
														}
														else
														{
															MessageBox.Show("Subject Not Available");
															DropClass.SelectedIndex=0;DropSec.SelectedIndex=0;
															DropStream.SelectedIndex=0;return;
														}
														%></TR>
											<TR bgColor="#663300">
												<%
														for(int ii=0;ii<Subject.Length;ii++)
														{
															if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE"&&Subject[ii].ToUpper()!="COMPUTER")//THIS FOR NON SCHOLASTIC
															{
																%>
												<TH>
													<B><FONT color="#ffffff">Unit Test</FONT></B></TH>
												<TH>
													<B><FONT color="#ffffff">Assgn. &amp; Proj. work</FONT></B></TH>
												<TH>
													<B><FONT color="#ffffff">I Term</FONT></B></TH>
												<TH>
													<B><FONT color="#ffffff">II Term</FONT></B></TH><!--TH><B><FONT color="#ffffff">Annual</FONT></B></TH-->
												<TH>
													<B><FONT color="#ffffff">Overall</FONT></B></TH><%
															}
														}
														%></TR>
											<%
														if(i>0)	
														{
															for(int p=0;p<i;p++)
															{
																string s=".";
																STotal=0;
																%>
											<TR>
												<TD align="center"><%=Ist[p,0].ToString()%></TD>
												<TD><%=Ist[p,1].ToString()%></TD>
												<%
																		for(int j=0;j<count;j++)
																		{
																			if(Subject[j].ToUpper()!="MUSIC"&&Subject[j].ToUpper()!="ART"&&Subject[j].ToUpper()!="CRAFT"&&Subject[j].ToUpper()!="PHY_EDU"&&Subject[j].ToUpper()!="DANCE"&&Subject[j].ToUpper()!="GK"&&Subject[j].ToUpper()!="GSTUDIES"&&Subject[j].ToUpper()!="ART_AND_CRAFT"&&Subject[j].ToUpper()!="WORK_EXP"&&Subject[j].ToUpper()!="MORAL_SCIENCE"&&Subject[j].ToUpper()!="MUSIC_AND_DANCE"&&Subject[j].ToUpper()!="COMPUTER")//THIS FOR NON SCHOLASTIC					
																			{
																				%>
												<TD align="center"><%=unit[p,j].ToString()%></TD>
												<TD align="center"><%=Assgn[p,j].ToString()%></TD>
												<TD align="center"><%=Test1[p,j+2].ToString()%></TD>
												<TD align="center"><%=Test2[p,j].ToString()%></TD>
												<TD align="center"><%=grade[p,j].ToString()%></TD>
												<%			
																				STotal+=System.Convert.ToDouble(unit[p,j])+System.Convert.ToDouble(Assgn[p,j])+System.Convert.ToDouble(Test1[p,j+2])+System.Convert.ToDouble(Test2[p,j]);
																			}
																		}
																		int k=0;
																		for(int ii=0;ii<Subject.Length;ii++)
																		{
																			if(Subject[ii].ToUpper()=="MUSIC"||Subject[ii].ToUpper()=="ART"||Subject[ii].ToUpper()=="CRAFT"||Subject[ii].ToUpper()=="PHY_EDU"||Subject[ii].ToUpper()=="DANCE"||Subject[ii].ToUpper()=="GK"||Subject[ii].ToUpper()=="GSTUDIES"||Subject[ii].ToUpper()=="ART_AND_CRAFT"||Subject[ii].ToUpper()=="WORK_EXP"||Subject[ii].ToUpper()=="MORAL_SCIENCE"||Subject[ii].ToUpper()=="MUSIC_AND_DANCE"||Subject[ii].ToUpper()=="COMPUTER")//THIS FOR NON SCHOLASTIC
																			{
																				%>
												<TD align="center"><%=NIst[p,k].ToString()%></TD>
												<%STotal+=System.Convert.ToDouble(NIst[p,k]);
																				k++;
																			}
																		}
																		%>
												<TD align="center"><%=STotal.ToString()%></TD>
												<TD align="center"><%=ggrade[p].ToString()%></TD>
												<TD align="center"><%=rank[p].ToString()%></TD>
												<TD align="center"><INPUT type=text size=10 
                name="txtrem<%=p%>"></TD>
											</TR>
											<%
																	}
																}
																else
																{
																	MessageBox.Show("Numbers Not Available");
																}
																%>
										</TABLE>
									</TD>
								</TR>
							</asp:panel>
							<%
											}
											else if(DropClass.SelectedIndex >= 5 && DropSec.SelectedIndex!=0) //&& DropStream.SelectedIndex!=0)
											{
												%>
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" borderColorLight="#663300" border="1">
										<TR bgColor="#663300">
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Roll No</FONT></B></TH>
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Name of Student </FONT></B>
											</TH>
											<%
																if(Subject.Length>0)
																{
																	for(int ii=0;ii<Subject.Length;ii++)
																	{
                 														if(Subject[ii].ToUpper()!="MUSIC"&&Subject[ii].ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToUpper()!="PHY_EDU"&&Subject[ii].ToUpper()!="DANCE"&&Subject[ii].ToUpper()!="GK"&&Subject[ii].ToUpper()!="GSTUDIES"&&Subject[ii].ToUpper()!="ART_AND_CRAFT"&&Subject[ii].ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE")//THIS FOR NON SCHOLASTIC
																		{
																			%>
											<TH colSpan="4">
												<B><FONT color="#ffffff">
														<%=Subject[ii].ToString().ToUpper()%>
													</FONT></B>
											</TH>
											<%
																		}
																	}
																}
																else
																{
																	MessageBox.Show("Subject Not Available");
																	DropClass.SelectedIndex=0;
																	DropSec.SelectedIndex=0;
																	DropStream.SelectedIndex=0;
																	return;
																}
																%>
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Grand Total</FONT></B></TH>
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Overall</FONT></B></TH>
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Rank</FONT></B></TH>
											<TH rowSpan="2">
												<B><FONT color="#ffffff">Remark</FONT></B></TH></TR>
										<TR bgColor="#663300">
											<%
																for(int ii=0;ii<Subject.Length;ii++)
																{
																	if(Subject[ii].ToString().ToUpper()!="MUSIC"&&Subject[ii].ToString().ToUpper()!="ART"&&Subject[ii].ToUpper()!="CRAFT"&&Subject[ii].ToString().ToUpper()!="PHY_EDU"&&Subject[ii].ToString().ToUpper()!="DANCE"&&Subject[ii].ToString().ToUpper()!="GK"&&Subject[ii].ToString().ToUpper()!="GSTUDIES"&&Subject[ii].ToString().ToUpper()!="ART & CRAFT"&&Subject[ii].ToString().ToUpper()!="WORK_EXP"&&Subject[ii].ToUpper()!="MORAL_SCIENCE"&&Subject[ii].ToUpper()!="MUSIC_AND_DANCE")//THIS FOR NON SCHOLASTIC
																	{
																		%>
											<TH>
												<B><FONT color="#ffffff">Assgn. &amp; Proj. work</FONT></B></TH>
											<TH>
												<B><FONT color="#ffffff">I Term</FONT></B></TH>
											<TH>
												<B><FONT color="#ffffff">II Term</FONT></B></TH>
											<TH>
												<B><FONT color="#ffffff">Overall</FONT></B></TH>
											<%
																	}
																}
																%>
										</TR>
										<%
															if(i>0)
															{
																for(int p=0;p<i;p++)
																{
																	%>
										<TR>
											<TD align="center"><%=Test1[p,0].ToString()%></TD>
											<TD><%=Test1[p,1].ToString()%></TD>
											<%
																			for(int j=0;j<count;j++)
																			{
																				%>
											<TD align="center"><%=Assgn[p,j].ToString()%></TD>
											<TD align="center"><%=Test1[p,j+2].ToString()%></TD>
											<TD align="center"><%=Test2[p,j].ToString()%></TD>
											<TD align="center"><%=grade[p,j].ToString()%></TD>
											<%
																			}
																			%>
											<TD align="center"><%=gtotal[p].ToString()%></TD>
											<TD align="center"><%=ggrade[p].ToString()%></TD>
											<TD align="center"><%=rank[p].ToString()%></TD>
											<TD align="center"><INPUT type=text size=10 
                  name="txtrem<%=p%>"></TD>
										</TR>
										<%	
																}	
															}
															else
															{
																MessageBox.Show("Numbers Not Available");
															}
														%>
									</TABLE>
								</TD>
							</TR>
							<%
										}
										}
									}
									catch(Exception ex)
									{
										MessageBox.Show(ex.Message);
										CreateLogFiles.ErrorLog("Form:GreenSheet,Method: HTML Part,Show GreenSheet "+"  EXCEPTION "+ex.Message+"  userid  ");
										return;
									}
									%>
						</table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
