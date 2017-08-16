<%@ Page language="c#" Codebehind="Staffleaverpt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.Staffleaverpt" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Staff Leave Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Staffleaverpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><b>STAFF LEAVE REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="75%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center">Employee ID<asp:dropdownlist id="Dropempid" runat="server" CssClass="ComboBox" AutoPostBack="False">
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist><BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
										<U>S</U>earch</BUTTON>&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Button1" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">&nbsp; <U>P</U>rint</BUTTON>&nbsp;&nbsp;<BUTTON class="FormButtonStyle" id="Btnexcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">&nbsp; <u>E</u>xcel</BUTTON></TD>
							</TR>
							<asp:panel id="pandata" Runat="server" Visible="False">
								<TR>
									<TD colSpan="6">
										<asp:datagrid id="Datastaffleave" Runat="server" AutoGenerateColumns="False" Width="100%" Height="100%">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_ID" HeaderText="Staff ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Staff_Name" HeaderText="Name"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Leave_Type" HeaderText="Leave Type"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_leavefromdt" HeaderText="Leave From"
													DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
												<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="Staff_leavefromto" HeaderText="Leave To"
													DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:panel></TABLE>
					</td>
					<td></td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
