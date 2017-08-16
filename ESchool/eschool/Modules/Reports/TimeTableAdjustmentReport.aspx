<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="TimeTableAdjustmentReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.TimeTableAdjustmentReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Time Table Adjustment Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="TimeTableAdjustment" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>TIME TABLE ADJUSTMENT REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="85%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center">Teacher ID&nbsp;<asp:dropdownlist id="Dropstaffid" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist>&nbsp; &nbsp;Adjust Date&nbsp; &nbsp;<asp:textbox id="txtadjustdate" BorderStyle="Groove" CssClass="FontStyle" Width="70px" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.TimeTableAdjustment.txtadjustdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp; &nbsp;<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON>&nbsp; &nbsp;<BUTTON class="FormButtonStyle" id="btnPrint" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><U>P</U>rint</BUTTON>&nbsp; 
									&nbsp;<BUTTON class="FormButtonStyle" id="Btn" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><U>E</U>xcel</BUTTON></TD>
							</TR>
							<asp:panel id="pangrid" Runat="server" Visible="False">
								<TR>
									<TD align="center">
										<asp:datagrid id="Datastafftype" Width="100%" Runat="server" AutoGenerateColumns="False" Height="100%">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="ActiveCaptionText" CssClass="DataGridHeader"
												BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Adjustid" HeaderText="Adjustid"></asp:BoundColumn>
												<asp:BoundColumn DataField="Staff_Name" HeaderText="Staff Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="adjustteacherid" HeaderText="Adjust TeacherID and Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="Class_name" HeaderText="Class"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:panel></TABLE>
					</td>
					<td></td>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
