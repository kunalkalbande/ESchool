
<%@ Page language="c#" Codebehind="PtaMeetingrptPrint.aspx.cs" AutoEventWireup="false" Inherits="eschool.PrintPreview.PtaMeetingrptPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PtaMeetingrptPrint</title>
<!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		
  			<asp:datagrid id="dgrdcomp" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 120px; Design_Time_Lock: True"
				Runat="server" HeaderStyle-BackColor="#ff99ff" AutoGenerateColumns="False" PageSize="5" BorderColor="White"
				BorderStyle="Ridge" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None" Font-Size="Smaller"
				Font-Names="Arial" Width="722px" CellSpacing="1" Design_Time_Lock="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="Designation" HeaderText="Designation"></asp:BoundColumn>
					<asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="teleno" HeaderText="Phone"></asp:BoundColumn>
					<asp:BoundColumn DataField="Student_ID" HeaderText="Student ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="Staffid" HeaderText="Staff Id"></asp:BoundColumn>
					<asp:BoundColumn DataField="address" HeaderText="Address"></asp:BoundColumn>
					<asp:BoundColumn DataField="Pcity" HeaderText="City"></asp:BoundColumn>
					<asp:BoundColumn DataField="Country" HeaderText="Country"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" ForeColor="Black"
					BackColor="#C6C3C6"></PagerStyle>
			</asp:datagrid>
			<!--<HR style="Z-INDEX: 101; LEFT: 8px; WIDTH: 738px; POSITION: absolute; TOP: 72px; HEIGHT: 2px"
				color="#660066" SIZE="2">
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 40px" runat="server"
				ForeColor="Blue" Font-Size="X-Small" Width="369px" Font-Bold="True" Height="16px">PTA Meeting Report</asp:Label>
			<HR style="Z-INDEX: 104; LEFT: 8px; WIDTH: 738px; POSITION: absolute; TOP: 24px; HEIGHT: 2px"
				color="#660066" SIZE="2">-->
		</form>
	</body>
</HTML>
