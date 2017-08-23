<%@ Page language="c#" Codebehind="Payslip.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.Payslip" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Pay Slip Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Payslip" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><b>PAY SLIP REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="80%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center">Employee Name &nbsp;<asp:dropdownlist id="dropEmpName" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist>
									<asp:comparevalidator id="cvEmpID" runat="server" ErrorMessage="You must select the employee name" ControlToValidate="dropEmpName"
										Operator="NotEqual" ValueToCompare="---Select---">*</asp:comparevalidator>
									<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server" class="FormButtonStyle"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
										<U>S</U>earch</BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="Button1" BorderColor="Black" BorderStyle="Groove"  runat="server"  Width="85px" Text="Print" Height=21 Font-Size="X-Small" CssClass="FormButtonStyle" ></asp:button>
									&nbsp;&nbsp;&nbsp;<asp:button id="Btnexcel" BorderColor="Black" BorderStyle="Groove"  runat="server" Height=21 Width="85px" Text="Excel" CssClass="FormButtonStyle" Font-Size="X-Small" ></asp:button></TD>
							</TR>
							<asp:Panel ID="panal1" Runat="server" Visible="False">
								<TR>
									<TD>
										<asp:datagrid id="Datapayslip" Runat="server" Width="100%" Height="100%" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeader" HorizontalAlign="Center" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_ID" HeaderText="Staff ID"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_Type" HeaderText="Designation"></asp:BoundColumn>
												<asp:BoundColumn DataField="Staff_Name" HeaderText="Staff Name"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="Basic_salary" HeaderText="Basic Salary"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="allowances_total" HeaderText="Total All."></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="G_total" HeaderText="Gross Salary"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="Deduction_total" HeaderText="Total Ded."></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="Net_Sal" HeaderText="Net Salary"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:Panel>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"><asp:validationsummary id="vsPaySlip" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
		
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
