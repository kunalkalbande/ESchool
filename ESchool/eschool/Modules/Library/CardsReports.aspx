<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="CardsReports.aspx.cs" AutoEventWireup="false" Inherits="eschool.Library.FORMS.CardsReports" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>CardsReports</title> <!--
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
		<SCRIPT src="../../shareables/jsfiles/coolmenus3.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="../../shareables/jsfiles/menubar.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="../../shareables/jsfiles/stMainLinks.js" type="text/javascript"></SCRIPT>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="CardsReports" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table align=center>
			<tr>
			<td align=center><B>CARD GENERATION REPORT</B>
			<table align="center" borderColorLight="#663300" border="5">
				<tr>
					<td vAlign="top" align="center"><STRONG></STRONG>
						<asp:datagrid id="CardReportGrid" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None"
							BorderColor="#CC9966" AutoGenerateColumns="False" HeaderStyle-BackColor="#663300" Runat="server"
							Font-Names="Arial" Font-Size="Smaller">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#000000" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#ffffff" BackColor="#000000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="memberID" HeaderText="CandidateID"></asp:BoundColumn>
								<asp:BoundColumn DataField="desig" HeaderText="Designation"></asp:BoundColumn>
								<asp:BoundColumn DataField="class" HeaderText="class"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name_Of_Librarian" HeaderText="Member Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="Card_NO" HeaderText="Card Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="No_Of_Card" HeaderText="Issue Card "></asp:BoundColumn>
								<asp:BoundColumn DataField="Date_Of_CardGen" HeaderText="Card Gen Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Validity_Of_Card" HeaderText="Card Period"></asp:BoundColumn>
								<asp:BoundColumn DataField="Remark" HeaderText="Remark"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Center" ForeColor="#330099"
								BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="center"><asp:button id="Print" Runat="server" Text="Print  " Width="83px" Height="28px" CssClass="formbuttonstyle"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="BtnPrint" Runat="server" Text="Print preview" Width="83px" Height="28px" CssClass="formbuttonstyle"
							Visible="False"></asp:button></td>
				</tr>
			</table>
			</td></tr></table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
