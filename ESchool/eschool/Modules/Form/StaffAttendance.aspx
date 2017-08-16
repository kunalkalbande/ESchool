<%@ Page language="c#" Codebehind="StaffAttendance.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.EmployeeAttendance" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StaffAttendance</title><!--
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
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table id="Table1" height="228" width="778" align="center">
				<tr>
					<td></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">STAFF ATTENDANCE</asp:label>
						<table id="Table2" align="center" borderColorLight="#663300" border="4">
							<TR> <!--Name : Mahesh and Bhalchand,Modify Date :- 08/08/06
							Replace the Checkbox by Radiobutton-->
								<TD align="center">Staff Type</TD>
								<TD>
									<asp:RadioButton id="chkTeaching" runat="server" Text="Teaching" AutoPostBack="True" GroupName="attendance"></asp:RadioButton></TD>
								<TD>
									<asp:RadioButton id="chkNonTeaching" runat="server" Text="Non Teaching" AutoPostBack="True" GroupName="attendance"></asp:RadioButton></TD>
								<TD>
									<asp:RadioButton id="chkGroupD" runat="server" Text="Group D" AutoPostBack="True" GroupName="attendance"></asp:RadioButton></TD>
							</TR>
							<TR>
								<td>Attendance Date</td>
								<TD align="left" colSpan="3">
									<!--Name : Mahesh & Bhalchand, Modify Date : 08/08/06
								Remove the Datepicker,We fetch Date from System Date-->
									<asp:TextBox id="txtDate" runat="server" ReadOnly="True" Width="80px" BorderStyle="Groove" style="align: center"></asp:TextBox>
									<asp:RequiredFieldValidator id="rfvAttendance" runat="server" ErrorMessage="Please select the date" ControlToValidate="txtDate">*</asp:RequiredFieldValidator></TD>
							</TR>
							<tr>
								<td align="center" style="HEIGHT: 16px">Designation</td>
								<td style="HEIGHT: 16px">
									<asp:dropdownlist id="dropDesignation" runat="server" CssClass="ComboBox">
										<asp:ListItem Value="---Select---">---Select---</asp:ListItem>
									</asp:dropdownlist></td>
								<TD colSpan="3" align="center" style="HEIGHT: 16px"><asp:button id="btnShow" runat="server" CssClass="FormButtonStyle" Text="Show"></asp:button></TD>
							</tr>
							<TR>
								<TD colSpan="3"><asp:datagrid id="dgrdStaffName" runat="server" AutoGenerateColumns="False" AllowPaging="True"
										AllowCustomPaging="True" Height="100%" Width="100%">
										<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Center" CssClass="DataGridItem"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="DataGridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="Staff_ID" HeaderText="Staff ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="Staff_Name" HeaderText="Staff Name"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Attendance">
												<ItemTemplate>
													<asp:CheckBox id="Chk1" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" CssClass="DatagridPagerstyle"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<tr>
								<td align="center" colSpan="4">
									<asp:button id="btnSave" CssClass="FormButtonStyle" Runat="server" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnReset" CssClass="FormButtonStyle" Runat="server" Text="Reset" CausesValidation="False"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="3"><asp:validationsummary id="vsStuMarks" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</table>
		</form> <!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
