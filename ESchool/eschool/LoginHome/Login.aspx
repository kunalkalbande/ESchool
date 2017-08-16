<%@ Register TagPrefix="uc1" TagName="header" Src="../HeaderFooter/usercontrol/header2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="eschool.LoginHome.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : User Login</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Login" method="post" runat="server">
			<uc1:header id="Header2" runat="server"></uc1:header>
			<table height="278" width="778" align="center">
				<tr>
					<td></td>
					<td align="center">
						<asp:Label id="lblMessage" runat="server" ForeColor="Maroon" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
				</tr>
				<TR>
					<TD></TD>
					<TD align="center">
						<asp:Label id="Label1" runat="server"></asp:Label></TD>
				</TR>
				<tr>
					<td></td>
					<td align="center"><b>USER LOGIN</b>
						<TABLE id="tablepassword" borderColorLight="#663300" border="7" align="center">
							<TR>
								<TD>&nbsp;User Type</TD>
								<TD><asp:dropdownlist id="DropUser" CssClass="ComboBox" Runat="server"></asp:dropdownlist>
									<asp:CompareValidator ID="Valicomp" Runat="server" ControlToValidate="DropUser" ValueToCompare="---Select---"
										Operator="NotEqual" ErrorMessage="Please Select User Type">*</asp:CompareValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;User Login</TD>
								<TD><asp:textbox id="TxtUserName" CssClass="TextBoxForms" Runat="server"></asp:textbox>
									<asp:RequiredFieldValidator ID="ValiReq" Runat="server" ControlToValidate="TxtUserName" ErrorMessage="Please Enter Login Name">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Password</TD>
								<TD><asp:textbox id="TxtPassword" CssClass="TextBoxForms" Runat="server" TextMode="Password"></asp:textbox>
									<asp:RequiredFieldValidator ID="ValiReq1" Runat="server" ControlToValidate="TxtPassword" ErrorMessage="Please Enter PassWord">*</asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>&nbsp;Set Date</TD>
								<TD><asp:textbox id="txtDate" Runat="server" CssClass="Fontstyle" ReadOnly="True" Width="70px" BorderStyle="Groove"></asp:textbox>
									<A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Login.txtDate);return false;">
										<IMG class="PopcalTrigger" alt="" src="../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A></TD>
							</TR>
							<!--<TR>
								<TD colSpan="2"><A href="Form/CreateNewUsers.aspx">New User</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <A href="Form/ChangePassword.aspx">Change Password</A></TD>
							</TR>-->
							<TR>
								<TD align="center" colSpan="6">
									<asp:Button id="btnLogin" runat="server" Text="Login" CssClass="formbuttonstyle"></asp:Button>
									<asp:ValidationSummary ID="Summary1" Runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
								</TD>
							</TR>
						</TABLE>
					</td>
				<tr>
					<td colspan="2" align="center">
						<asp:textbox id="txt1" Runat="server" Visible="False" Enabled="False"></asp:textbox>
					</td>
				</tr>
				<TR>
					<TD colSpan="2" align="center"></TD>
				</TR>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../HeaderFooter/shareables/Style/ipopeng.htm"
				frameBorder="0" width="174" scrolling="no" height="189"></iframe>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
