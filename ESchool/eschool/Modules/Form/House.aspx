<%@ Page language="c#" Codebehind="House.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Form.House" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : House Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to show data from hidden textbox value.
		function Showval(t,t1)
		{
			var ind=t.selectedIndex
			var val=t.options[ind].value
			if(ind > 0)
			{
				val=val.substring(0,val.indexOf(':'))
				t1.value=val
				document.Form1.tempval.value=val
				document.Form1.btnsave.value="Update"
			}
			else
			{
				t1.value=""
				document.Form1.btnsave.value="Save"
			}
		}
		// this method use to assign value from another textbox.
		function insertvalue(t,t1)
		{
			t1.value=t.value
			//alert(t1.value)
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="header1" runat="server"></uc1:header><input id="temphouse" type="hidden" name="temphouse" runat="server">
			<input id="tempval" type="hidden" name="tempval" runat="server">
			<table height="250" width="778" align="center">
				<tr>
				<td align="center"><b>HOUSE MASTER</b>
						<table cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<tr>
								<td>&nbsp;House Name</td>
								<td><asp:dropdownlist id="dropname" CssClass="ComboBox" Runat="server" Width="130" onchange="Showval(this,document.Form1.txtname)">
										<asp:ListItem Value="Select">Select</asp:ListItem>
									</asp:dropdownlist><!--<asp:label id="lablid" Visible="False" Width="1" Height="1" Runat="server" ForeColor="blue"></asp:label>--></td>
							</tr>
							<tr>
								<td>&nbsp;House&nbsp;<font color="red" size="1">*</font></td>
								<td><asp:textbox id="txtname" onblur="insertvalue(this,document.Form1.tempval)" CssClass="TextBoxForms"
										Runat="server"></asp:textbox><asp:requiredfieldvalidator id="validtion1" Runat="server" ErrorMessage="Please Enter House" ControlToValidate="txtname">&nbsp;*</asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:button id="btnsave" CssClass="formbuttonstyle" Runat="server" Text="Save"></asp:button>&nbsp;<asp:button id="btnedit" CssClass="formbuttonstyle" Runat="server" Text="Delete"></asp:button>
									<asp:validationsummary id="summary1" Runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer></form>
	</body>
</HTML>
