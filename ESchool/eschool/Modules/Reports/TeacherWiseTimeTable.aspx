<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Page language="c#" Codebehind="TeacherWiseTimeTable.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.TeacherWiseTimeTable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Teacher Wise Time Table</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<script language="javascript" id="Validations" src="../../HeaderFooter/shareables/jsfiles/Validations.js"></script>
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		// this method use to hide and visible print button.
		function HidePrint()
		{
			if(document.Form1.DropTCode.selectedIndex!=0)
			{
				document.all.btnPrint.style.visibility="visible"
				alert("Hello")
			}
			else
			{
				document.all.btnPrint.style.visibility="hidden"
				alert("buy"+val)
			}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<tr>
						<td align="center"></td>
					</tr>
					<tr>
						<td align="center"><B>TEACHER WISE TIME TABLE</B>
							<table align="center" borderColorLight="#663300" border="5" width="500">
								<tr>
									<td>
										<table>
											<tr>
												<td colspan="9">Teacher Code&nbsp; &nbsp;<asp:dropdownlist id="DropTCode" CssClass="ComboBox" Runat="server"></asp:dropdownlist>
													&nbsp;
													<asp:button id="btnShow" Width="100px" Runat="server" Text="Show" CssClass="FormButtonStyle"
														Height="21" BorderColor="Black" ></asp:button>&nbsp;
													<asp:button id="btnPrint" Width="85px" Runat="server" Text="Print" Visible="False" CssClass="FormButtonStyle"
														Height="21" BorderColor="Black" ></asp:button>&nbsp; 
													&nbsp;<asp:button id="Btnexcel" Width="85px" Runat="server" Text="Excel" CssClass="FormButtonStyle"
														Height="21" BorderColor="Black" ></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<%
								if(DropTCode.SelectedIndex != 0)
								{
									%>
								<tr>
									<td colspan="9">
										<table width="100%" border="1">
											<%
									InventoryClass obj=new InventoryClass();
									SqlDataReader SqlDtr=null,rdr=null;
									string str="";
									str="select * from TeacherTimeTable where shortname='"+DropTCode.SelectedItem.Text+"'";
									SqlDtr=obj.GetRecordSet(str);
									if(SqlDtr.Read())
									{
										%>
											<tr>
												<td width="11%" align="center"><b>D \ P</b></td>
												<td width="11%" align="center"><b>I</b></td>
												<td width="11%" align="center"><b>II </b>
												</td>
												<td width="11%" align="center"><b>III</b></td>
												<td width="11%" align="center"><b>IV</b></td>
												<td width="11%" align="center"><b>V</b></td>
												<td width="11%" align="center"><b>VI</b></td>
												<td width="11%" align="center"><b>VII</b></td>
												<td width="11%" align="center"><b>VIII</b></td>
											</tr>
											<tr>
												<td><b>MON</b></td>
												<td><%=SqlDtr["mon1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["mon8"].ToString()%>&nbsp;</td>
											</tr>
											<tr>
												<td><b>TUES</b></td>
												<td><%=SqlDtr["tue1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["tue8"].ToString()%>&nbsp;</td>
											</tr>
											<tr>
												<td><b>WED</b></td>
												<td><%=SqlDtr["wed1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["wed8"].ToString()%>&nbsp;</td>
											</tr>
											<tr>
												<td><b>THURS</b></td>
												<td><%=SqlDtr["thu1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["thu8"].ToString()%>&nbsp;</td>
											</tr>
											<tr>
												<td><b>FRI</b></td>
												<td><%=SqlDtr["fri1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["fri8"].ToString()%>&nbsp;</td>
											</tr>
											<tr>
												<td><b>SAT</b></td>
												<td><%=SqlDtr["sat1"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat2"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat3"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat4"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat5"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat6"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat7"].ToString()%>&nbsp;</td>
												<td><%=SqlDtr["sat8"].ToString()%>&nbsp;</td>
											</tr>
											<%
									}
								}
								else
								{
								%>
											<asp:Panel ID="pangrid" Runat="server" Visible="False">
												<TR>
													<TD colSpan="9">
														<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
															<HeaderStyle CssClass="DataGridHeader" BackColor="#663300"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="employee_id" HeaderText="Employee_ID"></asp:BoundColumn>
																<asp:BoundColumn DataField="shortname" HeaderText="Teacher_Code"></asp:BoundColumn>
																<asp:BoundColumn DataField="mon1" HeaderText="Mon1"></asp:BoundColumn>
																<asp:BoundColumn DataField="mon2" HeaderText="Mon2"></asp:BoundColumn>
																<asp:BoundColumn DataField="mon3" HeaderText="Mon3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Mon4" HeaderText="Mon4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Mon5" HeaderText="Mon5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Mon6" HeaderText="Mon6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Mon7" HeaderText="Mon7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Mon8" HeaderText="Mon8"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue1" HeaderText="Tue1"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue2" HeaderText="Tue2"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue3" HeaderText="Tue3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue4" HeaderText="Tue4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue5" HeaderText="Tue5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue6" HeaderText="Tue6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue7" HeaderText="Tue7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Tue8" HeaderText="Tue8"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed1" HeaderText="Wed1"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed2" HeaderText="Wed2"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed3" HeaderText="Wed3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed4" HeaderText="Wed4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed5" HeaderText="Wed5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed6" HeaderText="Wed6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed7" HeaderText="Wed7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Wed8" HeaderText="Wed8"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu1" HeaderText="Thu1"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu2" HeaderText="Thu2"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu3" HeaderText="Thu3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu4" HeaderText="Thu4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu5" HeaderText="Thu5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu6" HeaderText="Thu6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu7" HeaderText="Thu7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Thu8" HeaderText="Thu8"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri1" HeaderText="Fri1"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri2" HeaderText="Fri2"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri3" HeaderText="Fri3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri4" HeaderText="Fri4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri5" HeaderText="Fri5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri6" HeaderText="Fri6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri7" HeaderText="Fri7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Fri8" HeaderText="Fri8"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat1" HeaderText="Sat1"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat2" HeaderText="Sat2"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat3" HeaderText="Sat3"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat4" HeaderText="Sat4"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat5" HeaderText="Sat5"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat6" HeaderText="Sat6"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat7" HeaderText="Sat7"></asp:BoundColumn>
																<asp:BoundColumn DataField="Sat8" HeaderText="Sat8"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid></TD>
												</TR>
											</asp:Panel>
											<%
										}
										%>
										</table>
									</td>
								</tr>
							</table>
							<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
								name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
								width="174" scrolling="no" height="189"></iframe>
						</td>
					</tr>
				</TBODY>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
