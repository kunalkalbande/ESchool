<%@ Register TagPrefix=uc1 TagName=Header Src="../../HeaderFooter/usercontrol/header.ascx"%>
<%@ Register TagPrefix=uc1 TagName=Footer Src="../../HeaderFooter/usercontrol/Footer.ascx"%>
<%@ Page language="c#" Codebehind="BooksInformationReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Library.BooksInformationReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Book Information Report</title> <!--
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
		<form id="BooksInformationReport" runat="server">
			<uc1:Header id="header" runat="server"></uc1:Header>
			<table height="290" class="border" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><b>BOOK INFORMATION REPORT</b>
						<table align="center" width="100%" bordercolorlight="#663300" border="5">
							<TR height="10">
								<TD align="center">Search Option&nbsp;<asp:dropdownlist id="Dropsearchopt" runat="server" Width="80" AutoPostBack="True" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
										<asp:ListItem Value="All">All</asp:ListItem>
										<asp:ListItem Value="Book Wise">Book Wise</asp:ListItem>
										<asp:ListItem Value="Rack Wise">Rack Wise</asp:ListItem>
										<asp:ListItem Value="Subject Wise">Subject Wise</asp:ListItem>
										<asp:ListItem Value="Remark Wise">Remark Wise</asp:ListItem>
									</asp:dropdownlist>&nbsp;Value&nbsp;<asp:dropdownlist id="Dropvalue" Width="65px" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:textbox id="txtbookid" Width="65px" BorderStyle="Groove" Visible="False" CssClass="FontStyle"
										Runat="server"></asp:textbox>&nbsp;From&nbsp;
									<asp:textbox id="Txtfdate" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.BooksInformationReport.Txtfdate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;To&nbsp;<asp:textbox id="Txttodate" BorderStyle="Groove" runat="server" CssClass="FontStyle" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.BooksInformationReport.Txttodate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<tr>
								<td align="center">
									<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #c0c0c0"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON>&nbsp;&nbsp; <INPUT class="FormButtonStyle" id="Button1" type="button" value="Print" name="btnPrint"
										runat="server" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #c0c0c0">&nbsp;&nbsp;&nbsp;
									<BUTTON id="Button3" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #c0c0c0"
										accessKey="S" type="button" runat="server">Excel</BUTTON></td>
							</tr>
							<asp:Panel ID="pangrid" Runat="server" Visible="False">
								<TR>
									<TD colSpan="2">
										<asp:datagrid id="BookReportGrid" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White"
											Runat="server"  AllowPaging="True" Font-Size="Smaller" Font-Names="Arial" ForeColor="Black"
											HorizontalAlign="Center" CellPadding="4" HeaderStyle-BackColor="#000000" AutoGenerateColumns="False"
											OnPageIndexChanged="BookReportGrid_PageIndexChanged">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#ff9900"></SelectedItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#663300"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="Black"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="SNo">
													<ItemTemplate>
														<%=i++%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Book_ID" HeaderText="Book ID" ItemStyle-Width="41"></asp:BoundColumn>
												<asp:BoundColumn DataField="bookname" HeaderText="Book Name" ItemStyle-Width="50"></asp:BoundColumn>
												<asp:BoundColumn DataField="subname" HeaderText="Subject Name" ItemStyle-Width="50"></asp:BoundColumn>
												<asp:BoundColumn DataField="aname" HeaderText="Author Name" ></asp:BoundColumn>
												<asp:BoundColumn DataField="pname" HeaderText="Publisher Name"></asp:BoundColumn>
												<asp:BoundColumn DataField="price" HeaderText="Book Cost"></asp:BoundColumn>
												<asp:BoundColumn DataField="pdate" HeaderText="Purchase Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
												<asp:BoundColumn DataField="rackno" HeaderText="Rack No"></asp:BoundColumn>
												<asp:BoundColumn DataField="qty" HeaderText="Qty"></asp:BoundColumn>
												<asp:BoundColumn DataField="remark" HeaderText="Remark"></asp:BoundColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" ForeColor="Black"
												Position="TopAndBottom" BackColor="White"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</asp:Panel>
							<!--tr>
								<TD align="center"><INPUT class="FormButtonStyle" id="btnPrint" type="button" value="Print" name="btnPrint"
										runat="server" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1">&nbsp;&nbsp;&nbsp;
									<BUTTON id="Button2" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 90px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 22px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server">Excel</BUTTON></TD>
							</tr-->
						</table>
					</td>
				</tr>
			</table>
			<uc1:Footer id="footer" runat="server"></uc1:Footer>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
		</form>
	</body>
</HTML>
