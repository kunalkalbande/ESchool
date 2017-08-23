<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="meetingrpt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Pta.meetingrpt1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : PTA Meeting Report</title><!--
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
		<form id="meetingrpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><B>PTA MEETING REPORT</B>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD align="center">&nbsp;Meeting From Date
									<asp:textbox id="txtdt" BorderStyle="Groove" runat="server" Width="70" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.meetingrpt.txtdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A><asp:requiredfieldvalidator id="rfvDate" runat="server" ErrorMessage="Please enter date" ControlToValidate="txtdt">*</asp:requiredfieldvalidator>
									&nbsp;&nbsp;To Date
									<asp:textbox id="txtToDate" BorderStyle="Groove" runat="server" Width="70" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.meetingrpt.txtToDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Please enter date" ControlToValidate="txtToDate">*</asp:requiredfieldvalidator><BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp;
									<asp:button id="BtnPrint" BorderColor="Black"  CssClass="FormButtonStyle"
										 width="85px" CausesValidation="False" Text="Excel" Runat="server" Height="21"></asp:button>&nbsp;&nbsp;<asp:button id="ButtonPrint" BorderColor="Black"  Width="85px"
										CssClass="FormButtonStyle"  CausesValidation="False" Text="Print " Runat="server" Height="21"></asp:button></TD>
							</TR>
							<asp:panel id="pangrid" Runat="server" Visible="False">
        <TR>
          <TD>
<asp:datagrid id=dgrdcomp Width="100%" Height="100%" Runat="server" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="meetingdt" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
												<asp:BoundColumn DataField="agenda" HeaderText="Agenda"></asp:BoundColumn>
												<asp:BoundColumn DataField="min1" HeaderText="Discussion1"></asp:BoundColumn>
												<asp:BoundColumn DataField="min2" HeaderText="Discussion2"></asp:BoundColumn>
												<asp:BoundColumn DataField="min3" HeaderText="Discussion3"></asp:BoundColumn>
												<asp:BoundColumn DataField="min4" HeaderText="Discussion4"></asp:BoundColumn>
												<asp:BoundColumn DataField="min5" HeaderText="Discussion5"></asp:BoundColumn>
												<asp:BoundColumn DataField="min6" HeaderText="Discussion6"></asp:BoundColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></TD></TR>
							</asp:panel></TABLE>
					</td>
				</tr>
			</table>
	
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
