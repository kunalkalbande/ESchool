<%@ Page language="c#" Codebehind="Server.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.chat_Server.Server1" %>
<%@ Register TagPrefix=uc1 TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx"%>
<%@ Register TagPrefix=uc1 TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : e-Chatting</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../../HeaderFooter/shareables/Style/Styles.css" type=text/css rel=stylesheet >
		<script language="javascript">
		// this method use to make disable and enable of message window.
		function holdvalue()
		{
			var index=document.Form1.LisLogin.selectedIndex
			var name=document.Form1.LisLogin.options[index].value;
			if(name==document.Form1.lblName.value)
			{
				document.Form1.txtmessagwin.disabled=true;
			}
			else
			{
				document.Form1.txtmessagwin.disabled=false;
				document.Form1.Selectedvalue.value=document.Form1.LisLogin.options[index].value;
			}
		}
		//this method use to make disable and enable of Send Button.
		function allowsend()
		{
			if(document.Form1.txtmessagwin.value=="" || document.Form1.txtmessagwin.value==null)
				document.Form1.btnSend.disabled=true;
			else
				document.Form1.btnSend.disabled=false;
		}
		// this message use to concate the message string.
		function Msg()
		{
			document.Form1.listChatwin.value+="<%=Session["User_Name"].ToString()%>"+document.Form1.txtmessagwin.value
		}
		
		// this method not in use.
		function Check(t)
		{
			var str=t.value
			var ext=str.substring(str.lastIndexOf('.'),str.length)
			if(t.value!="" && str.indexOf(".")>0)
			{
				str=str.substring(0,str.lastIndexOf("."));
				if(t.value.toLowerCase().indexOf(".txt")>0)
				{
					document.Form1.tempPath.value=str;
					document.Form1.tempext.value=ext;
				}
				else if(t.value.toLowerCase().indexOf(".doc")>0)
				{
					document.Form1.tempPath.value=str;
					document.Form1.tempext.value=ext;
				}
				else
				{
					alert("Please Select The .txt or .Word File");
					return;
				}
			}
			else
			{
				alert("Please Select The .txt or .Word File");
			    return;
			}
		}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			
			<table height="250" width="778" align="center">
				<tr>
					<td align="center"><b>E-CHATTING</b>
					<input id="tempPath" type="hidden" style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px" name="tempPath" runat="server">
					<input id="tempext" type="hidden" style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px" name="tempext" runat="server">
					<INPUT id="Selectedvalue" style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px" type="text" size="2" name="Selectedvalue" runat="server">
						<table align="center" borderColorLight="#663300" border="5">
							<TBODY>
								<tr>
									<td colSpan="2">&nbsp;User Name&nbsp;&nbsp;&nbsp;<asp:textbox CssClass="TextBoxForms"  id="lblName" BorderStyle="None" ForeColor="#cc0000" Font-Bold="True" Runat="server"></asp:textbox></td>
									<td>&nbsp;User Type&nbsp;&nbsp;&nbsp;<asp:label id="lblSub" ForeColor="#cc0000" Font-Bold="True" Runat="server"></asp:label></td>
									<td align="right"><asp:linkbutton id="lblogout" Runat="server"><font color="#cc0000">Logout</font></asp:linkbutton></td>
								</tr>
								<tr>
									<td colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
									<td align="center" colSpan="2"><font color="#cc0000">Logged Member List</font></td>
								</tr>
								<tr>
									<td colSpan="4"><asp:textbox CssClass="TextBoxForms" id="listChatwin" Runat="server" Height="200px" Width="350px" TextMode="MultiLine"
											></asp:textbox><asp:listbox CssClass="ComboBox" id="LisLogin" onclick="holdvalue()" Runat="server" Height="200px" Width="180px"></asp:listbox></td>
								</tr>
								<tr>
									<td colSpan="4"><asp:textbox id="txtmessagwin" onkeyup="allowsend()" Runat="server" Width="400px" TextMode="MultiLine"></asp:textbox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:button id="btnSend" Runat="server" CssClass="formbuttonstyle" Text="Send"></asp:button></td>
								</tr>
							</TBODY>
						</table>
					</td>
				</tr>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
