<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="salarysheet.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.salarysheet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Salary Sheet Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="salarysheet" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="232" width="778" align="center">
				<tr>
					<td vAlign="bottom" align="center"><b>SALARY SHEET REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="90%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center">From Date&nbsp;
									<asp:textbox id="txtfromdt" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.salarysheet.txtfromdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="ReqCompanyName" Display="Dynamic" ErrorMessage="You Must Enter From Date" ControlToValidate="txtfromdt"
										Runat="server">*</asp:requiredfieldvalidator>&nbsp; To Date&nbsp; &nbsp;<asp:textbox id="txttodt" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.salarysheet.txttodt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator1" Display="Dynamic" ErrorMessage="You Must Enter To Date"
										ControlToValidate="txttodt" Runat="server">*</asp:requiredfieldvalidator>&nbsp; 
									&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
										<U>S</U>earch</BUTTON>&nbsp; &nbsp;<asp:button id="btnPrint" BorderColor="Black"  CssClass="FormButtonStyle"
										Width="85px" Runat="server" Font-Size="X-Small" Height="21" Text="Print"></asp:button>&nbsp; 
									&nbsp;<asp:button id="BtnExcel" BorderColor="Black" CssClass="FormButtonStyle"
										Width="85px" Runat="server" Font-Size="X-Small" Height="21" Text="Excel"></asp:button></TD>
							</TR>
							<asp:panel id="panal1" Runat="server" Visible="False">
								<TR>
									<TD>
										<asp:datagrid id="Datapayslip" Width="100%" Runat="server" Height="100%" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" BackColor="#663300" CssClass="DataGridHeader"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_ID" HeaderText="Staff ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Staff_Name" HeaderText="Staff Name"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="Basic_salary" HeaderText="Salary"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="fromdt" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="todt" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:panel></TABLE>
					</td>
				</tr>
				<tr>
					<td><asp:validationsummary id="vsSalarySheet" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
		</form>
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
