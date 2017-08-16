<%@ Page language="c#" Codebehind="Stuck_Off_Report.aspx.cs" AutoEventWireup="false" Inherits="eschool.certificate.Stuck_Off_Report" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Stuck Off Report</title> <!--
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
		<form id="Tcrpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label1" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><B>STUCK OFF REPORT</B>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="90%" borderColorLight="#663300"
							border="5">
							<tr>
								<td align=center>From&nbsp;&nbsp;<asp:textbox id="TxtFromdt" CssClass="FontStyle" BorderStyle=Groove Width="70px" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tcrpt.TxtFromdt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;
								&nbsp;To&nbsp;
								&nbsp;<asp:textbox id="TxtTodt" CssClass="FontStyle" BorderStyle=Groove Width="70px" Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Tcrpt.TxtTodt);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;
								&nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"><U>S</U>earch</BUTTON>&nbsp;&nbsp;
									  <asp:button id="BtnPrint" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" CssClass="FormButtonStyle" Width="85px" Font-Size="X-Small" Height=21 Runat="server" Text="Excel"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnPrintD" BorderColor="Black" BorderWidth="2px" BackColor="#E0E0E0" CssClass="FormButtonStyle"	Width="85px" Font-Size="X-Small" Height=21 Runat="server" Text="Print"></asp:button></td></tr>
							<asp:Panel ID=pangrid Runat=server Visible=False>
							<TR>
								<%i=1;%>
								<TD> <asp:datagrid id="dgrdsuspend" Width="700" Height="100%" Runat="server" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Center" CssClass="DataGridItem"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
										<FooterStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="SNO">
												<ItemTemplate>
													<%=i++%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Student_id" HeaderText="Addm. No."></asp:BoundColumn>
											<asp:BoundColumn DataField="Student_FName" HeaderText="First Name">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Student_Class" HeaderText="Class"></asp:BoundColumn>
											<asp:BoundColumn DataField="Seq_Student_id" HeaderText="Section"></asp:BoundColumn>
											<asp:BoundColumn DataField="Fee_paid" HeaderText="Fee Paid"></asp:BoundColumn>
											<asp:BoundColumn DataField="tcdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle></asp:DataGrid></TD>
							</TR>
							</asp:Panel>
						</TABLE>
					</td>
					<td></td>
				</tr>
			</table>
			<IFRAME id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></IFRAME>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
