<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="studentrpt.aspx.cs" AutoEventWireup="false" Inherits="eschool.Health.studentrpt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Student Health Report</title> 
		<!--
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
		<form id="studentrpt" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<TABLE height="250" width="778" align="center">
				<tr>
					<td align="center"><asp:label id="Label1" runat="server"><b>STUDENT HEALTH REPORT</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD align="center">Student ID &nbsp; &nbsp;<asp:dropdownlist id="Dropstudentid" runat="server" CssClass="ComboBox" AutoPostBack="False"></asp:dropdownlist>&nbsp; 
									&nbsp;<asp:textbox id="txtstudentname" Visible="False" runat="server" BorderStyle="Groove" CssClass="FontStyle"
										Width="180px"></asp:textbox>&nbsp; &nbsp;<BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" style="WIDTH: 16px; HEIGHT: 7px" height="7" src="../../HeaderFooter/images/search.gif"
											width="16"> <U>S</U>earch</BUTTON>&nbsp; &nbsp;<button class="FormButtonStyle" id="btnExcel" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 85px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1"
										type="button" runat="server">Excel</button>&nbsp; &nbsp;<asp:button id="BtnPrint" CssClass="FormButtonStyle" Height="21px" Width="85px" BackColor="#e1e1e1"
										Runat="server" BorderStyle="Groove" Font-Size="X-Small" Text="Print"></asp:button></TD>
							</TR>
							<asp:Panel ID="panal1" Runat="server" Visible="false">
        <TR>
          <TD>
<asp:datagrid id=dgrdhealth Width="100%" Runat="server" Height="100%" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItem"></ItemStyle>
											<HeaderStyle Font-Bold="True" CssClass="DataGridHeader" ForeColor="#ffffff" BackColor="#663300"
												HorizontalAlign="Center"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Student_Fname">
													<ItemTemplate>
														<%#fname(DataBinder.Eval(Container.DataItem, "Student_ID").ToString())%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Ears" HeaderText="Ear"></asp:BoundColumn>
												<asp:BoundColumn DataField="Noise" HeaderText="Noise"></asp:BoundColumn>
												<asp:BoundColumn DataField="hands" HeaderText="Hands"></asp:BoundColumn>
												<asp:BoundColumn DataField="Legs" HeaderText="Leg"></asp:BoundColumn>
												<asp:BoundColumn DataField="Teeth" HeaderText="Teeth"></asp:BoundColumn>
												<asp:BoundColumn DataField="Bp" HeaderText="BP"></asp:BoundColumn>
												<asp:BoundColumn DataField="Heartbeat" HeaderText="Heart"></asp:BoundColumn>
												<asp:BoundColumn DataField="Skin" HeaderText="Skin"></asp:BoundColumn>
												<asp:BoundColumn DataField="Mental" HeaderText="Mental"></asp:BoundColumn>
												<asp:BoundColumn DataField="chdate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											</Columns>
											<PagerStyle NextPageText="Next" PrevPageText="Previous"></PagerStyle>
										</asp:datagrid></TD></TR>
							</asp:Panel>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
