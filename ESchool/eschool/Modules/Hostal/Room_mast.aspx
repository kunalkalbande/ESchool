<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="Room_mast.aspx.cs" AutoEventWireup="false" Inherits="eschool.Hostel.Room_mast" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Room Master</title> <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Room_mast" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="232" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><asp:label id="Label3" runat="server" Font-Bold="True">ROOM MASTER</asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="279" borderColorLight="#663300"
							border="5">
							<TBODY>
								<TR>
									<TD colSpan="3"><asp:label id="Label4" runat="server" ForeColor="Red">asterisk (*) fields are mandatory</asp:label></TD>
								</TR>
								<TR>
									<TD>&nbsp;Bed ID</TD>
									<TD colSpan="3"><asp:dropdownlist id="DropEdit" runat="server" CssClass="ComboBox" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="lblbedid" ForeColor="blue" runat="server" Width="8px"></asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>&nbsp;Room No<FONT color="#ff0033" size="1">*</FONT></TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											MaxLength="6" id="txtroomno" runat="server" Width="112px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Room Incharge</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxforms" onkeypress="return GetOnlyChars(this, event);" MaxLength="30"
											id="txtincharge" runat="server" Width="112px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;Total No of Beds</TD>
									<TD colSpan="3"><asp:textbox CssClass="TextBoxforms" MaxLength="4" id="txtnobeds" onkeypress="return GetOnlyNumbers(this, event, false,false);"
											runat="server" Width="51px" AutoPostBack="True"></asp:textbox>&nbsp;<asp:button id="btnBedID" runat="server" Width="83px" Text="Get Bed IDs" CssClass="formbuttonstyle"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center">Total Beds</TD>
									<td>&nbsp;</td>
									<TD align="center">&nbsp;Defective&nbsp;&nbsp;Beds&nbsp;
									</TD>
								</TR>
								<TR>
									<TD align="center"><asp:listbox CssClass="ComboBox" id="listtotal" runat="server" Width="73px" Height="123px"></asp:listbox></TD>
									<TD vAlign="middle" align="center">
										<asp:button id="btntodef" runat="server" Width="34px" Text=" >" CssClass="formbuttonstyle"></asp:button><br>
										<br>
										<asp:button id="btntotoal" runat="server" Width="34px" Text="<" CssClass="formbuttonstyle"></asp:button><br>
										&nbsp;<br>
										&nbsp;<br>
									</TD>
									<TD align="center"><asp:listbox CssClass="ComboBox" id="Listdefective" runat="server" Width="71px" Height="123px"></asp:listbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="5">
										<asp:button id="btnSave" runat="server" Text="Save" CssClass="FormButtonStyle"></asp:button>
										&nbsp;<asp:button id="btnEdit" runat="server" Text="Edit" CssClass="FormButtonStyle"></asp:button>
										&nbsp;<asp:button id="btnDelete" runat="server" Text="Delete" CssClass="FormButtonStyle"></asp:button>
										<asp:validationsummary id="vsRoomMaster" runat="server" Width="160px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
