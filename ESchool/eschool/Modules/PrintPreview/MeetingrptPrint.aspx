
<%@ Page language="c#" Codebehind="MeetingrptPrint.aspx.cs" AutoEventWireup="false" Inherits="eschool.PrintPreview.MeetingrptPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>MeetingrptPrint</title>
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
			<!--<HR style="Z-INDEX: 100; LEFT: 8px; WIDTH: 798px; POSITION: absolute; TOP: 80px; HEIGHT: 2px"
				color="#660066" SIZE="2">-->
			<asp:datagrid id="dgrdcomp" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 112px; Design_Time_Lock: True"
				Width="406px" Font-Size="Smaller" HeaderStyle-BackColor="#ff99ff" AutoGenerateColumns="False"
				PageSize="5" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" BackColor="White" CellPadding="3"
				GridLines="None" Font-Names="Arial" Runat="server" CellSpacing="1" Design_Time_Lock="True">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE">
</SelectedItemStyle>

<ItemStyle ForeColor="Black" BackColor="#DEDFDE">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C">
</HeaderStyle>

<FooterStyle ForeColor="Black" BackColor="#C6C3C6">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="meetingdt" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
<asp:BoundColumn DataField="agenda" HeaderText="Agenda"></asp:BoundColumn>
<asp:BoundColumn DataField="min1" HeaderText="Min"></asp:BoundColumn>
<asp:BoundColumn DataField="min2" HeaderText="Min"></asp:BoundColumn>
<asp:BoundColumn DataField="min3" HeaderText="Min"></asp:BoundColumn>
<asp:BoundColumn DataField="min4" HeaderText="Min"></asp:BoundColumn>
<asp:BoundColumn DataField="min5" HeaderText="Min"></asp:BoundColumn>
<asp:BoundColumn DataField="min6" HeaderText="Min"></asp:BoundColumn>
</Columns>

<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6">
</PagerStyle>
			</asp:datagrid>
			<!--<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 296px; POSITION: absolute; TOP: 48px" runat="server"
				Width="104px" Height="16px" ForeColor="Blue" Font-Size="X-Small" Font-Bold="True" >Meeting Report</asp:Label>
			<HR style="Z-INDEX: 103; LEFT: 8px; WIDTH: 802px; POSITION: absolute; TOP: 32px; HEIGHT: 2px"
				color="#660066" SIZE="2">-->
		</form>
	</body>
</HTML>
