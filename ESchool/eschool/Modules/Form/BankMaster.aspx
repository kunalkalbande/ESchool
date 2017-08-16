<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="BankMaster.aspx.cs" AutoEventWireup="false" Inherits="eschool.Form.BankMaster" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Bank Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="BankMaster" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="top" align="center"><asp:label id="Label1" runat="server">
							<b>BANK MASTER</b></asp:label>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<TR>
								<TD>Bank Name</TD>
								<TD><asp:dropdownlist id="Dropname" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>Bank ID&nbsp;&nbsp;</TD>
								<TD><asp:label id="lblid" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Add New Bank&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtbankname" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Branch&nbsp;&nbsp;</TD>
								<TD><asp:textbox id="txtBranch" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><asp:button id="btnSave" runat="server" Text="Add" CssClass="formbuttonstyle"></asp:button><asp:button id="btnEdit" runat="server" Text="Edit" CssClass="formbuttonstyle"></asp:button>
									<!--<asp:button id="btnSEdit" runat="server" Text=" Edit Save" CssClass="formbuttonstyle"></asp:button>--><asp:button id="btnDelete" runat="server" Text="Delete" CssClass="formbuttonstyle"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
