<%@ Page language="c#" Codebehind="Roles_Privileges.aspx.cs" AutoEventWireup="false" Inherits="eschool.Roles.Roles_Privileges" smartNavigation="False" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Roles & Privileges</title><!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
-->
		<meta content="Microsoft Visual Studio .NET 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		function check(t)
		{
			//alert("hello")
			//document.Form1.divadmin.style.height=0
			//document.Form1.divadmin.style.width=0
			
			var name=t.name
			var count=document.Form1.elements.length
			//alert(count)
						
			if(name=="chkAdminSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=8;i<28;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=8;i<28;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkmastSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=29;i<73;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=29;i<73;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			
			else if(name=="chkPersonalSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=74;i<94;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=74;i<94;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkAddSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=95;i<107;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=95;i<107;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkDailySelectAll")
			{
				if(t.checked==true)
				{
					for(var i=108;i<116;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=108;i<116;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkExamSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=117;i<125;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=117;i<125;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkCertificateSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=126;i<134;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=126;i<134;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkhealthSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=135;i<139;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=135;i<139;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkLabSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=140;i<144;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=140;i<144;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="ChkTTMselectall")
			{
				if(t.checked==true)
				{
					for(var i=145;i<157;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=145;i<157;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkLibSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=158;i<170;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=158;i<170;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkAccountSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=171;i<195;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=171;i<195;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="Checkbox9")
			{
				if(t.checked==true)
				{
					for(var i=196;i<204;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=196;i<204;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkLogisticSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=205;i<217;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=205;i<217;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkhostSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=218;i<234;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=218;i<234;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkcoachSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=235;i<239;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=235;i<239;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkAccRepSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=240;i<292;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=240;i<292;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkCertiRepSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=293;i<301;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=293;i<301;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkHealthrSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=302;i<310;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=302;i<310;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chklibaSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=311;i<319;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=311;i<319;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chklogistSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=320;i<324;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=320;i<324;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkAptaSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=325;i<333;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=325;i<333;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkSalaryRepSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=334;i<354;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=334;i<354;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkStuReport")
			{
				if(t.checked==true)
				{
					for(var i=355;i<391;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=355;i<391;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkTTRepSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=392;i<408;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=392;i<408;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
			else if(name=="chkTTadjSelectAll")
			{
				if(t.checked==true)
				{
					for(var i=409;i<418;i++)
					{
						document.Form1.elements[i].checked=true
					}
				}
				else
				{
					for(var i=409;i<418;i++)
					{
						document.Form1.elements[i].checked=false
					}
				}
			}
		}
		
		function selectall()
		{
			//alert("Hello")
			var val=document.Form1.btnselctall.value
				if(val=="Select All")
				{
					for(var i=7;i<418;i++)
					{
						document.Form1.elements[i].checked=true
					}
					document.Form1.btnselctall.value="Clear All"
				}
				else
				{
					for(var i=7;i<418;i++)
					{
						document.Form1.elements[i].checked=false
					}
					document.Form1.btnselctall.value="Select All"
				}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="288" width="778" align="center" border="0">
				<TBODY>
					<TR>
						<td align="center"><b>ROLES &amp; PRIVILEGES</b>
							<TABLE cellSpacing="1" cellPadding="1" width="60%" align="center" borderColorLight="#663300"
								border="5">
								<TBODY>
									<TR>
										<TD>&nbsp;Login Name&nbsp;<font color="red" size="1">*</font></TD>
										<TD><asp:dropdownlist id="DropName" runat="server" AutoPostBack="True" CssClass="ComboBox"></asp:dropdownlist><asp:dropdownlist id="DropLogin" runat="server" AutoPostBack="True" CssClass="ComboBox" Width="120px"></asp:dropdownlist><asp:CompareValidator ID="compval1" Runat="server" ControlToValidate="DropLogin" ValueToCompare="--Select--"
												Operator="NotEqual" ErrorMessage="Please Select the Login Name">*</asp:CompareValidator><asp:textbox id="TxtName" runat="server" CssClass="TextBoxForms" Width="174px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Role Name</TD>
										<TD><asp:textbox id="txtRoleName" runat="server" CssClass="TextBoxForms" Width="294px" ></asp:textbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;Description</TD>
										<TD><asp:textbox id="txtDesc" runat="server" CssClass="TextBoxForms" Width="294px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD align="center" bgColor="#808087" colSpan="2"><STRONG><asp:label id="Label1" BackColor="Transparent" runat="server" ForeColor="FloralWhite">Select  Modules  To  Set  Privileges</asp:label></STRONG></TD>
									</TR>
									<TR>
										<td bgColor="#ffffeb" colSpan="2"><STRONG>Administrator Module</STRONG></td>
									</TR>
									<TR>
										<TD colSpan="2">
											<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
												border="1">
												<TR>
													<TD width="50"><STRONG>S.No.</STRONG></TD>
													<TD align="center"><STRONG>Privileges</STRONG></TD>
													<TD align="center" width="53"><STRONG>View</STRONG></TD>
													<TD align="center" width="43"><STRONG>Add</STRONG></TD>
													<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
													<TD align="center" width="39"><STRONG>Del</STRONG></TD>
												</TR>
												<TR>
													<TD align="right" colSpan="6"><asp:checkbox id="chkAdminSelectAll" onclick="check(this)" runat="server" ForeColor="#00006D"
															Font-Bold="True" Font-Size="Smaller"></asp:checkbox><font color="#00006d"><STRONG>Select 
																All</STRONG></font></TD>
												</TR>
												<TR>
													<TD>&nbsp;a.</TD>
													<TD>Backup &amp; Restore
													</TD>
													<TD align="center"><asp:checkbox id="chkView1" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkAdd1" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkEdit1" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkDel1" runat="server"></asp:checkbox></TD>
												</TR>
												<TR>
													<TD>&nbsp;b.</TD>
													<TD>Privileges</TD>
													<TD align="center"><asp:checkbox id="chkView2" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkAdd2" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkEdit2" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkDel2" runat="server"></asp:checkbox></TD>
												</TR>
												<TR>
													<TD>&nbsp;c.</TD>
													<TD>Role 
														Master&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD align="center"><asp:checkbox id="chkView3" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkAdd3" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkEdit3" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkDel3" runat="server"></asp:checkbox></TD>
												</TR>
												<TR>
													<TD>&nbsp;d.</TD>
													<TD>School Information</TD>
													<TD align="center"><asp:checkbox id="chkView4" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkAdd4" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkEdit4" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkDel4" runat="server"></asp:checkbox></TD>
												</TR>
												<TR>
													<TD>&nbsp;e.</TD>
													<TD>User Profile</TD>
													<TD align="center"><asp:checkbox id="chkView5" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkAdd5" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkEdit5" runat="server"></asp:checkbox></TD>
													<TD align="center"><asp:checkbox id="chkDel5" runat="server"></asp:checkbox></TD>
												</TR>
											</TABLE>
										</TD>
						</td>
					</TR>
					<TR>
						<td bgColor="#ffffeb" colSpan="2"><STRONG>Master Module</STRONG></td>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="50"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkmastSelectAll" onclick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"
											Font-Size="Smaller"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Category</TD>
									<TD align="center"><asp:checkbox id="chkView6" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd6" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit6" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel6" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Class
									</TD>
									<TD align="center"><asp:checkbox id="chkView7" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd7" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit7" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel7" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>Class Wise Subject</TD>
									<TD align="center"><asp:checkbox id="chkView8" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd8" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit8" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel8" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;d.</TD>
									<TD>City Master</TD>
									<TD align="center"><asp:checkbox id="chkView9" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd9" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit9" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel9" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;e.</TD>
									<TD>Doctor</TD>
									<TD align="center"><asp:checkbox id="chkView10" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd10" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit10" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel10" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;f.</TD>
									<TD>Lab Master</TD>
									<TD align="center"><asp:checkbox id="chkView11" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd11" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit11" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel11" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;g.</TD>
									<TD>Ledger Creation</TD>
									<TD align="center" width="53"><asp:checkbox id="chkView12" runat="server"></asp:checkbox></TD>
									<TD align="center" width="42"><asp:checkbox id="chkAdd12" runat="server"></asp:checkbox></TD>
									<TD align="center" width="39"><asp:checkbox id="chkEdit12" runat="server"></asp:checkbox></TD>
									<TD align="center" width="39"><asp:checkbox id="chkDel12" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;h.</TD>
									<TD>Route Master</TD>
									<TD align="center"><asp:checkbox id="chkView13" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd13" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit13" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel13" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;i.</TD>
									<TD>Staff Type</TD>
									<TD align="center"><asp:checkbox id="chkView14" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd14" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit14" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel14" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;j.</TD>
									<TD>Stock Master</TD>
									<TD align="center"><asp:checkbox id="chkView15" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd15" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit15" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel15" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;k.</TD>
									<TD>Subject</TD>
									<TD align="center"><asp:checkbox id="chkView16" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd16" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit16" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel16" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<TD bgColor="#ffffeb" colSpan="2"><STRONG>Personnel Module</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkPersonalSelectAll" onclick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Employee Attendance</TD>
									<TD align="center"><asp:checkbox id="chkView17" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd17" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit17" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel17" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Employee Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD align="center"><asp:checkbox id="chkView18" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd18" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit18" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel18" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>Employee Leave</TD>
									<TD align="center"><asp:checkbox id="chkView19" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd19" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit19" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel19" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;d.
									</TD>
									<TD>Employee Salary&nbsp;&nbsp;</TD>
									<TD align="center"><asp:checkbox id="chkView20" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd20" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit20" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel20" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;e.</TD>
									<TD>Leave Sanction</TD>
									<TD align="center"><asp:checkbox id="chkView21" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd21" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit21" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel21" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<tr>
						<td bgColor="#ffffeb" colSpan="2"><STRONG>Student Module</STRONG>
						</td>
					</tr>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Admission &gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkAddSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Registration</TD>
									<TD align="center"><asp:checkbox id="chkView22" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd22" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit22" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel22" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Registration Status</TD>
									<TD align="center"><asp:checkbox id="chkView23" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd23" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit23" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel23" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>Admission</TD>
									<TD align="center"><asp:checkbox id="chkView24" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd24" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit24" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel24" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Daily Activities &gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkDailySelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Attendance</TD>
									<TD align="center"><asp:checkbox id="chkView25" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd25" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit25" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel25" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.
									</TD>
									<TD>Set Student Roll No</TD>
									<TD align="center"><asp:checkbox id="chkView26" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd26" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit26" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel26" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Examination&nbsp;&gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkExamSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Exam Marks Decision</TD>
									<TD align="center"><asp:checkbox id="chkView27" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd27" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit27" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel27" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.
									</TD>
									<TD>Marks Entry</TD>
									<TD align="center"><asp:checkbox id="chkView28" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd28" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit28" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel28" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Certificate&nbsp;&gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkCertificateSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Transfer certificate</TD>
									<TD align="center"><asp:checkbox id="chkView29" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd29" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit29" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel29" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Stuck Off</TD>
									<TD align="center"><asp:checkbox id="chkView30" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd30" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit30" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel30" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Health CheckUp&nbsp;&gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkhealthSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Health CheckUp</TD>
									<TD align="center"><asp:checkbox id="chkView31" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd31" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit31" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel31" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Lab Booking&nbsp;&gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="chkLabSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></td>
								</TR>
								<TR>
									<TD><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center"><STRONG>View</STRONG></TD>
									<TD align="center"><STRONG>Add</STRONG></TD>
									<TD align="center"><STRONG>Edit</STRONG></TD>
									<TD align="center"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Lab Booking</TD>
									<TD align="center"><asp:checkbox id="chkView32" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd32" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit32" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel32" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					</TD></TR>
					<tr>
						<td bgColor="#ffffeb" colSpan="2"><STRONG>Time Table Module</STRONG></td>
					</tr>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="52"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="ChkTTMselectall" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Teacher TimeTable</TD>
									<TD align="center"><asp:checkbox id="chkView33" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd33" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit33" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel33" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>TimeTable Adjustment(Class)</TD>
									<TD align="center"><asp:checkbox id="chkView34" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd34" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit34" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel34" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>TimeTable Adjustment(Period)</TD>
									<TD align="center"><asp:checkbox id="chkView35" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd35" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit35" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel35" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<TD bgColor="#ffffeb" colSpan="2"><STRONG>Library Module</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="5">
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="52"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkLibSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.
									</TD>
									<TD>Book Entry</TD>
									<TD align="center"><asp:checkbox id="chkView36" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd36" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit36" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel36" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Book Issue
									</TD>
									<TD align="center"><asp:checkbox id="chkView37" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd37" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit37" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel37" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>Return Issue Books</TD>
									<TD align="center"><asp:checkbox id="chkView38" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd38" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit38" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel38" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<TD bgColor="#ffffeb" colSpan="2"><STRONG>Account Module</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="28"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="27"><STRONG>View</STRONG></TD>
									<TD align="center" width="23"><STRONG>Add</STRONG></TD>
									<TD align="center" width="19"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="20"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkAccountSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Fees 
										Decision&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD align="center"><asp:checkbox id="chkView39" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd39" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit39" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel39" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD style="WIDTH: 102px">Fees Receipt</TD>
									<TD align="center"><asp:checkbox id="chkView40" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd40" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit40" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel40" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD style="WIDTH: 102px">Payment</TD>
									<TD align="center"><asp:checkbox id="chkView41" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd41" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit41" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel41" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;d.</TD>
									<TD style="WIDTH: 102px">Pay Slip</TD>
									<TD align="center"><asp:checkbox id="chkView42" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd42" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit42" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel42" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;e.</TD>
									<TD style="WIDTH: 102px">Receipt</TD>
									<TD align="center"><asp:checkbox id="chkView43" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd43" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit43" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel43" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;f.</TD>
									<TD style="WIDTH: 102px">Voucher Entry</TD>
									<TD align="center"><asp:checkbox id="chkView44" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd44" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit44" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel44" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><font color="maroon"><STRONG>Stock&nbsp;&gt;&gt;</STRONG></font></TD>
									<td align="right" colSpan="4"><asp:checkbox id="Checkbox9" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></td>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD style="WIDTH: 102px">Issue Item</TD>
									<TD align="center"><asp:checkbox id="chkView45" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd45" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit45" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel45" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD style="WIDTH: 102px">Receipt Item</TD>
									<TD align="center"><asp:checkbox id="chkView46" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd46" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit46" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel46" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<TD bgColor="#ffffeb" colSpan="2"><STRONG>PTA Module</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="50"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkLogisticSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Member</TD>
									<TD align="center"><asp:checkbox id="chkView47" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd47" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit47" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel47" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Member Meeting</TD>
									<TD align="center"><asp:checkbox id="chkView48" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd48" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit48" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel48" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD rowSpan="2">Communication</TD>
									<TD align="center"><asp:checkbox id="chkView49" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd49" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit49" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel49" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<td bgColor="#ffffeb" colSpan="2"><STRONG>Hostel Module</STRONG></td>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="50"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkhostSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Size="Smaller"
											Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>Menu Creation</TD>
									<TD align="center"><asp:checkbox id="chkView50" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd50" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit50" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel50" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;b.</TD>
									<TD>Hostel Fees</TD>
									<TD align="center"><asp:checkbox id="chkView51" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd51" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit51" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel51" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;c.</TD>
									<TD>Room Booking
									</TD>
									<TD align="center"><asp:checkbox id="chkView52" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd52" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit52" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel52" runat="server"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;d.</TD>
									<TD>Room Master</TD>
									<TD align="center"><asp:checkbox id="chkView53" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd53" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit53" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel53" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<td bgColor="#ffffeb" colSpan="2"><STRONG>e-Coaching</STRONG></td>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TR>
									<TD width="50"><STRONG>S.No.</STRONG></TD>
									<TD align="center"><STRONG>Privileges</STRONG></TD>
									<TD align="center" width="53"><STRONG>View</STRONG></TD>
									<TD align="center" width="43"><STRONG>Add</STRONG></TD>
									<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
									<TD align="center" width="39"><STRONG>Del</STRONG></TD>
								</TR>
								<TR>
									<TD align="right" colSpan="6"><asp:checkbox id="chkcoachSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
											Font-Size="Smaller" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
												All</STRONG></font></TD>
								</TR>
								<TR>
									<TD>&nbsp;a.</TD>
									<TD>e-Chatting 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD align="center"><asp:checkbox id="chkView54" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkAdd54" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkEdit54" runat="server"></asp:checkbox></TD>
									<TD align="center"><asp:checkbox id="chkDel54" runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
						</TD></TR>
					<TR>
						<TD bgColor="#ffffeb" colSpan="2"><STRONG>Report Module</STRONG></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table16" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#663300"
								border="1">
								<TBODY>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Accounts Report&nbsp;&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkAccRepSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Adv.&amp; Pen. Report</TD>
										<TD align="center"><asp:checkbox id="chkView55" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd55" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit55" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel55" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Balance Sheet</TD>
										<TD align="center"><asp:checkbox id="chkView56" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd56" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit56" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel56" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;c.</TD>
										<TD>Bank Report</TD>
										<TD align="center"><asp:checkbox id="chkView57" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd57" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit57" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel57" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;d.</TD>
										<TD>Complete Fees Report</TD>
										<TD align="center"><asp:checkbox id="chkView58" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd58" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit58" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel58" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;e.</TD>
										<TD>Daily Fees Report</TD>
										<TD align="center"><asp:checkbox id="chkView59" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd59" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit59" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel59" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;f.</TD>
										<TD>Due Fees Report</TD>
										<TD align="center"><asp:checkbox id="chkView60" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd60" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit60" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel60" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;g.</TD>
										<TD>Fees Decision</TD>
										<TD align="center"><asp:checkbox id="chkView61" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd61" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit61" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel61" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;h.</TD>
										<TD>Fees Receipt</TD>
										<TD align="center"><asp:checkbox id="chkView62" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd62" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit62" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel62" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;i.</TD>
										<TD>Ledger Report</TD>
										<TD align="center"><asp:checkbox id="chkView63" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd63" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit63" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel63" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;j.</TD>
										<TD>Reconciliation Report</TD>
										<TD align="center"><asp:checkbox id="chkView64" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd64" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit64" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel64" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;k.</TD>
										<TD>Security Fees Report</TD>
										<TD align="center"><asp:checkbox id="chkView65" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd65" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit65" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel65" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;l.</TD>
										<TD>Stock Movement Report</TD>
										<TD align="center"><asp:checkbox id="chkView66" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd66" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit66" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel66" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;m.</TD>
										<TD>Trading Account</TD>
										<TD align="center"><asp:checkbox id="chkView67" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd67" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit67" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel67" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Certificate &nbsp;Report&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkCertiRepSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Transfer Certificate Report</TD>
										<TD align="center"><asp:checkbox id="chkView68" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd68" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit68" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel68" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Stuck Off Report</TD>
										<TD align="center"><asp:checkbox id="chkView69" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd69" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit69" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel69" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Health &nbsp;Report&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkHealthrSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Doctors Report</TD>
										<TD align="center"><asp:checkbox id="chkView70" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd70" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit70" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel70" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Student checkup Report</TD>
										<TD align="center"><asp:checkbox id="chkView71" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd71" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit71" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel71" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Library </STRONG></FONT>
										</TD>
										<td align="right" colSpan="4"><asp:checkbox id="chklibaSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
													All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Book Information Report</TD>
										<TD align="center"><asp:checkbox id="chkView72" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd72" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit72" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel72" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>issue Book Report</TD>
										<TD align="center"><asp:checkbox id="chkView73" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd73" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit73" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel73" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Logistic</STRONG></FONT>
										</TD>
										<td align="right" colSpan="4"><asp:checkbox id="chklogistSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Route Search</TD>
										<TD align="center"><asp:checkbox id="chkView74" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd74" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit74" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel74" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>PTA</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkAptaSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
													All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Meeting Report</TD>
										<TD align="center"><asp:checkbox id="chkView75" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd75" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit75" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel75" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Member Report</TD>
										<TD align="center"><asp:checkbox id="chkView76" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd76" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit76" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel76" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Staff Reports&nbsp;&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkSalaryRepSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Complete Salary</TD>
										<TD align="center"><asp:checkbox id="chkView77" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd77" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit77" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel77" runat="server"></asp:checkbox></TD>
									</TR-->
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Pay Slip
										</TD>
										<TD align="center"><asp:checkbox id="chkView78" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd78" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit78" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel78" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;c
										</TD>
										<TD>Salary Sheet</TD>
										<TD align="center"><asp:checkbox id="chkView79" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd79" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit79" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel79" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;d.</TD>
										<TD>Staff Information</TD>
										<TD align="center"><asp:checkbox id="chkView80" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd80" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit80" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel80" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;e.</TD>
										<TD>Staff Leave</TD>
										<TD align="center"><asp:checkbox id="chkView81" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd81" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit81" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel81" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Student Reports&nbsp;&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkStuReport" OnClick="check(this)" runat="server" ForeColor="#00006D" Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select 
													All</STRONG></font></td>
									</TR>
									<TR>
										<TD width="53"><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center" width="53"><STRONG>View</STRONG></TD>
										<TD align="center" width="43"><STRONG>Add</STRONG></TD>
										<TD align="center" width="39"><STRONG>Edit</STRONG></TD>
										<TD align="center" width="39"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Strenght Report</TD>
										<TD align="center"><asp:checkbox id="chkView82" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd82" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit82" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel82" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>Green Sheet Report</TD>
										<TD align="center"><asp:checkbox id="chkView83" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd83" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit83" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel83" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;c.</TD>
										<TD>Result At A Glance</TD>
										<TD align="center"><asp:checkbox id="chkView84" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd84" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit84" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel84" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;d.
										</TD>
										<TD>SubjectWise Report At A Glance</TD>
										<TD align="center"><asp:checkbox id="chkView85" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd85" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit85" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel85" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;e.</TD>
										<TD>Student Attendance</TD>
										<TD align="center"><asp:checkbox id="chkView86" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd86" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit86" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel86" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;f.</TD>
										<TD>Student Information</TD>
										<TD align="center"><asp:checkbox id="chkView87" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd87" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit87" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel87" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;g.</TD>
										<TD>Student Marks</TD>
										<TD align="center"><asp:checkbox id="chkView88" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd88" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit88" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel88" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;h.</TD>
										<TD>Class Promotion</TD>
										<TD align="center"><asp:checkbox id="chkView89" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd89" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit89" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel89" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;i.</TD>
										<TD>Weightage Report</TD>
										<TD align="center"><asp:checkbox id="chkView90" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd90" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit90" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel90" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Time Table Reports&nbsp;&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkTTRepSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>Class wise Subjects</TD>
										<TD align="center"><asp:checkbox id="chkView91" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd91" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit91" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel91" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>PeriodWise TimeTable</TD>
										<TD align="center"><asp:checkbox id="chkView92" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd92" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit92" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel92" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;c.</TD>
										<TD>SubjectWise TimeTable</TD>
										<TD align="center"><asp:checkbox id="chkView93" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd93" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit93" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel93" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;d.</TD>
										<TD>TeacherWise
										</TD>
										<TD align="center"><asp:checkbox id="chkView94" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd94" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit94" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel94" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD colSpan="2"><FONT color="maroon"><STRONG>Time Table Adjustment Report&nbsp;&gt;&gt;</STRONG></FONT></TD>
										<td align="right" colSpan="4"><asp:checkbox id="chkTTadjSelectAll" OnClick="check(this)" runat="server" ForeColor="#00006D"
												Font-Bold="True"></asp:checkbox><font color="#00006d"><STRONG>Select All</STRONG></font></td>
									</TR>
									<TR>
										<TD><STRONG>S.No.</STRONG></TD>
										<TD align="center"><STRONG>Privileges</STRONG></TD>
										<TD align="center"><STRONG>View</STRONG></TD>
										<TD align="center"><STRONG>Add</STRONG></TD>
										<TD align="center"><STRONG>Edit</STRONG></TD>
										<TD align="center"><STRONG>Del</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;a.</TD>
										<TD>TeacherWise Adjustment</TD>
										<TD align="center"><asp:checkbox id="chkView95" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd95" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit95" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel95" runat="server"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD>&nbsp;b.</TD>
										<TD>PeriodWise Adjustment</TD>
										<TD align="center"><asp:checkbox id="chkView96" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkAdd96" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkEdit96" runat="server"></asp:checkbox></TD>
										<TD align="center"><asp:checkbox id="chkDel96" runat="server"></asp:checkbox></TD>
									</TR>
						</TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR><TR>
				<TD align="left" colspan="2">
					<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#663300" border="1">
						<tr>
							<td align="center" colspan="2"><asp:button id="btnEditSave" runat="server" CssClass="FormWideButtonStyle" Text="Update"></asp:button>&nbsp;<asp:button id="btnSave" runat="server" CssClass="FormWideButtonStyle" Text="Save  Privileges"></asp:button>&nbsp;<input id="btnselctall" class="FormWideButtonStyle" onclick="selectall()" type="button"
									value="Select All"><asp:ValidationSummary ID="Summary1" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></td>
						</tr>
					</table>
				</TD>
			</TR>
			</TBODY></TABLE></TD></TR></TBODY></TABLE>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
			<!--/TD></TR></TBODY></TABLE></asp:panel></TD></TR></TBODY></TABLE--></form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
	</body>
</HTML>
