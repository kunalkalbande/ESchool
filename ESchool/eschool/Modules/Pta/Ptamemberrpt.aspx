<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Ptamemberrpt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Pta.Ptamemberrpt1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : PTA Member Report</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Ptamemberrpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<TR>
					<td vAlign="top" align="center"><B>PTA MEMBER REPORT</B>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD align="center">Member ID&nbsp; &nbsp;<asp:dropdownlist id="Dropstudentid" runat="server" CssClass="ComboBox" AutoPostBack="False">
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist>&nbsp; &nbsp;<asp:textbox id="txtstudentname" Visible="False" runat="server" CssClass="FontStyle" BorderStyle="Groove"
										Height="20px" Width="142px" ></asp:textbox>&nbsp; &nbsp; <BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp;
									<asp:button id="BtnPrint" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" CssClass="FormButtonStyle"
										Width="85px" Font-Size="X-Small" Height="21" Text="Excel" Runat="server"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnPrintD" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" CssClass="FormButtonStyle"
										Width="85px" Font-Size="X-Small" Height="21" Text="Print" Runat="server"></asp:button>&nbsp;&nbsp;</TD>
							</TR>
							<asp:Panel ID="pangrid" Runat="server" Visible="False">
								<TR>
									<TD>
										<asp:datagrid id="dgrdcomp" Width="100%" Height="100%" Runat="server" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="Designation" HeaderText="Designation"></asp:BoundColumn>
												<asp:BoundColumn DataField="membertype" HeaderText="Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
												<asp:BoundColumn DataField="teleno" HeaderText="Phone"></asp:BoundColumn>
												<asp:BoundColumn DataField="mobileno" HeaderText="Mobile No"></asp:BoundColumn>
												<asp:BoundColumn DataField="Student_ID" HeaderText="Student ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Staffid" HeaderText="Staff Id"></asp:BoundColumn>
												<asp:BoundColumn DataField="address" HeaderText="Address"></asp:BoundColumn>
												<asp:BoundColumn DataField="Pcity" HeaderText="City"></asp:BoundColumn>
												<asp:BoundColumn DataField="state" HeaderText="State"></asp:BoundColumn>
												<asp:BoundColumn DataField="Country" HeaderText="Country"></asp:BoundColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:Panel>
						</TABLE>
					</td>
				</TR>
			</table>
			</TABLE><uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
