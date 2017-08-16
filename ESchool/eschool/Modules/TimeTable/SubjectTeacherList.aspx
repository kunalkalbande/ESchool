<%@ Page language="c#" Codebehind="SubjectTeacherList.aspx.cs" AutoEventWireup="false" Inherits="eschool.TimeTable.SubjectTeacherList" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Subject Wise Time Table</title><!--
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
	<body MS_POSITIONING="GridLayout">
		
		<!--<table>
			<SCRIPT src="../../shareables/jsfiles/coolmenus3.js" type="text/javascript"></SCRIPT>
			<SCRIPT src="../../shareables/jsfiles/menubar.js" type="text/javascript"></SCRIPT>
			<SCRIPT src="../../shareables/jsfiles/stMainLinks.js" type="text/javascript"></SCRIPT>
		</table>-->
		<form id="SubjectTeacherList" method="post" runat="server">
		<uc1:header id="Header1" runat="server"></uc1:header>
			<TABLE height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center" width="70%"><B>SUBJECT WISE TIME TABLE</B>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width=70% borderColorLight="#663300"
							border="5">
							<TR>
								<TD align=center>&nbsp;Subject&nbsp;ID :
								&nbsp;<asp:dropdownlist id="dropsubject" Runat="server" CssClass=ComboBox></asp:dropdownlist>&nbsp;
								&nbsp;<BUTTON id="Button2" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey="S" type="button" runat="server" class=FormButtonStyle><IMG id=txtsearch style="WIDTH: 16px; HEIGHT: 7px" height=7 src="../../HeaderFooter/images/search.gif" width=16> <U>S</U>earch</BUTTON>&nbsp;&nbsp;
								<BUTTON id="Button3" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey="S" type="button" runat="server" class="FormButtonStyle"><U>P</U>rint</BUTTON>&nbsp;&nbsp;
								<BUTTON id="Btnexcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey="S" type="button" runat="server" class="FormButtonStyle"><U>E</U>xcel</BUTTON></TD>
										</TR>
										<asp:Panel ID=pangrid Runat=server Visible=False>
										<tr><td>
							
						<asp:datagrid id="DataGrid1" runat="server" Width=600px  HorizontalAlign="Center" AutoGenerateColumns="False">
							<HeaderStyle HorizontalAlign=Center CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Staff_name" HeaderText="Staff Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
						</tr>
						</asp:Panel>
						</TABLE>
					</td>
				</tr>
				<!--tr height="15%">
					<td colSpan="4"></td>
				</tr--></TABLE>
				<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
		
	</body>
</HTML>
