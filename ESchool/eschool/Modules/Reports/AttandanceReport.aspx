<%@ Page language="c#" Codebehind="AttandanceReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.AttandanceReport" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Student Attandance Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="AttandanceReport" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>STUDENT ATTENDANCE REPORT</b>
						<TABLE width="90%" borderColorLight="#663300" border="5">
							<TBODY>
								<TR>
									<TD>&nbsp;Class&nbsp;
										<asp:dropdownlist id="DropClass" runat="server" CssClass="ComboBox">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										</asp:dropdownlist>
										&nbsp;Section&nbsp;<asp:dropdownlist id="DropSection" runat="server" CssClass="ComboBox">
											<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
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
										&nbsp;Stream&nbsp;<asp:dropdownlist id="DropdStream" runat="server" CssClass="ComboBox">
											<asp:ListItem Value="None">None</asp:ListItem>
											<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
											<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
											<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
										</asp:dropdownlist>&nbsp; From Date&nbsp;<asp:TextBox ID="txtfromdate" Width="65" BorderStyle="Groove" CssClass="FontStyle" Runat="server"></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AttandanceReport.txtfromdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>&nbsp; To Date&nbsp;<asp:TextBox ID="txttodate" Width="65" BorderStyle="Groove" CssClass="FontStyle" Runat="server"></asp:TextBox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.AttandanceReport.txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
												border="0"></A>&nbsp;
									</TD>
								</TR>
								<tr>
									<td align="center">
										<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
												width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp; <BUTTON id="Button1" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server" class="FormButtonStyle"><U>P</U>rint</BUTTON>&nbsp;&nbsp;
										<BUTTON id="Btn" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
											accessKey="S" type="button" runat="server" class="FormButtonStyle"><U>E</U>xcel</BUTTON></td>
								</tr>
								<asp:Panel ID="pangrid" Runat="server" Visible="False">
									<TR>
										<TD>
											<asp:datagrid id="dgrdStudentLeaveInfo" Runat="server" Width="100%" PageSize="50" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItem"></ItemStyle>
												<HeaderStyle HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
												<Columns>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="StudentId" HeaderText="Student Id">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="RollNO" HeaderText="Roll No">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SName" HeaderText="Student Name">
														<HeaderStyle Width="50%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Total Attendance">
														<HeaderStyle Width="20%"></HeaderStyle>
														<ItemTemplate>
															<%#Total_Attendance(DataBinder.Eval(Container.DataItem, "StudentID").ToString())%>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</asp:Panel>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
