<%@ Page language="c#" Codebehind="TimeTableAdjustmentPeriodWiseReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Reports.TimeTableAdjustmentPeriodWise" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : TimeTableAdjustmentPeriodWise</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr align="center">
						<td align="center"><B>TIME TABLE ADJUSTMENT PERIOD WISE</B>
							<table cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
								<TBODY>
									<tr>
										<td align="center">&nbsp;Date&nbsp;
											<asp:textbox id="Txtdate" CssClass="fontstyle" BorderStyle="Groove" Runat="server" Width="70"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.Txtdate);return false;"><IMG class="PopcalTrigger" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"></A>
											&nbsp;Day&nbsp;
											<asp:dropdownlist CssClass="ComboBox" id="Dropday" Runat="server">
												<asp:ListItem Value="Select"></asp:ListItem>
												<asp:ListItem Value="Monday"></asp:ListItem>
												<asp:ListItem Value="Tuesday"></asp:ListItem>
												<asp:ListItem Value="Wednesday"></asp:ListItem>
												<asp:ListItem Value="Thursday"></asp:ListItem>
												<asp:ListItem Value="Friday"></asp:ListItem>
												<asp:ListItem Value="Saturday"></asp:ListItem>
											</asp:dropdownlist>&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 120px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; BACKGROUND-COLOR: #e1e1e1"
												accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
												<U>S</U>earch</BUTTON>&nbsp;<asp:button id="Button1" BorderColor="Black" BorderStyle="Groove" BackColor="#E0E0E0" runat="server"
												Width="94px" CssClass="FormButtonStyle" Text="Print" BorderWidth="2px" Font-Size="X-Small"></asp:button>&nbsp;<asp:button id="Btnexcel" BorderColor="Black" BorderStyle="Groove" BackColor="#E0E0E0" runat="server"
												Width="94px" CssClass="FormButtonStyle" Text="Excel" BorderWidth="2px" Font-Size="X-Small"></asp:button>
										</td>
									</tr>
									<asp:Panel id="pangrid" Runat="server" Visible="False">
										<TR>
											<TD>
												<asp:DataGrid id="GridAdjustment" Width="100%" Runat="server" AutoGenerateColumns="False" height="100%">
													<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
													<ItemStyle CssClass="DataGridItem"></ItemStyle>
													<HeaderStyle Font-Size="Larger" HorizontalAlign="Center" ForeColor="ActiveCaptionText" CssClass="DataGridHeader"
														BackColor="#663300"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
													<Columns>
														<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Period" HeaderText="Period"></asp:BoundColumn>
														<asp:BoundColumn DataField="Staff_Name" HeaderText="Staff Name"></asp:BoundColumn>
														<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Teacher_Id" HeaderText="TeacherID"></asp:BoundColumn>
														<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Class" HeaderText="Class"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
												</asp:DataGrid></TD>
										</TR>
									</asp:Panel>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
