<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Doctorrpt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Health.Doctorrpt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Doctor's Report</title> <!--
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
		<form id="Doctorrpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><b>DOCTOR'S REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" align="center" borderColorLight="#663300"
							border="5">
							<TR align="center">
								<TD>&nbsp;Doctor&nbsp;ID&nbsp;
									<asp:dropdownlist id="Dropstudentid" CssClass="ComboBox" runat="server" AutoPostBack="False">
										<asp:ListItem Value="All">All</asp:ListItem>
									</asp:dropdownlist>
									<asp:textbox id="txtstudentname" Visible="False" CssClass="FontStyle" BorderStyle="Groove" runat="server"
										Enabled="False"></asp:textbox>
									&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON> &nbsp;<asp:button id="BtnPrint" Width="85px" CssClass="FormButtonStyle" BackColor="#e1e1e1" Runat="server"
										Text="Print" BorderColor="black" Height="21px"></asp:button>&nbsp;<BUTTON id="BtnExcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Excel</BUTTON></TD>
							</TR>
							<asp:Panel ID="pandoc" Runat="server" Visible="False">
        <TR>
          <TD colSpan=7>
<asp:datagrid id=dgrdsuspend BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" Font-Size="Smaller" Runat="server" Width="700px" HeaderStyle-BackColor="#ff99ff" AutoGenerateColumns="False" PageSize="5" CellPadding="4" GridLines="Vertical" ForeColor="Black" Font-Names="Arial">
											<SelectedItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="White" BorderColor="#000000"
												BorderWidth="2" BackColor="#CC3333"></SelectedItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="doctor_name" HeaderText="Doctor_Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="specialisation" HeaderText="Specialty"></asp:BoundColumn>
												<asp:BoundColumn DataField="add1" HeaderText="Address"></asp:BoundColumn>
												<asp:BoundColumn DataField="city" HeaderText="City"></asp:BoundColumn>
												<asp:BoundColumn DataField="state" HeaderText="State"></asp:BoundColumn>
												<asp:BoundColumn DataField="phone1_off" HeaderText="Phone(O)"></asp:BoundColumn>
												<asp:BoundColumn DataField="phone1_res" HeaderText="Phone(R)"></asp:BoundColumn>
												<asp:BoundColumn DataField="mobile" HeaderText="Mobile"></asp:BoundColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></TD></TR>
							</asp:Panel>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
