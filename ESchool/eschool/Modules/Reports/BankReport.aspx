<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Page language="c#" Codebehind="BankReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.BankReport" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Bank Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Payslip" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label2" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center"><b>BANK REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="70%" borderColorLight="#663300"
							border="5">
							<TR>
								<td colSpan="6" align="center">&nbsp;&nbsp;Bank&nbsp;&nbsp;<asp:dropdownlist id="DropBank" CssClass="ComboBox" Runat="server"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;<asp:textbox id="txtFrom" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Payslip.txtFrom);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtTo" BorderStyle="Groove" Runat="server" Width="70px" CssClass="FontStyle"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Payslip.txtTo);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
								</td>
							</TR>
							<tr>
								<TD align="center" colSpan="6"><BUTTON class="FormButtonStyle" id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 120px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; BACKGROUND-COLOR: #e1e1e1"
										accessKey="S" type="button" runat="server"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16">
										<U>S</U>earch</BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="Button1" BorderColor="Black" BorderStyle="Groove" 
										runat="server" Width="94px" CssClass="FormButtonStyle" Text="Print" ></asp:button>
									&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="Exel" BorderColor="Black" BorderStyle="Groove" 
										runat="server" Width="94px" CssClass="FormButtonStyle" Text="Excel" ></asp:button></TD>
							</tr>
							<!--<TR>
								<TD colSpan="5"><asp:datagrid id="grdBank" Width="100%" Runat="server" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="DatagridAlternatingStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItem"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeader"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="feesubdt" HeaderText="Receive Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="RecuringID" HeaderText="Receipt No"></asp:BoundColumn>
											<asp:BoundColumn DataField="chno" HeaderText="Cheque No"></asp:BoundColumn>
											<asp:BoundColumn DataField="draftno" HeaderText="Draft No"></asp:BoundColumn>
											<asp:BoundColumn DataField="chdate" HeaderText="Check Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Fees_Amount" HeaderText="Amount"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>-->
							<%
					if(flage==1)
					{		
					%>
							<TR bgColor="#663300">
								<TD align="center"><b><font color="#ffffff">SNo</font></b></TD>
								<TD align="center"><b><font color="#ffffff">Receive Date</font></b></TD>
								<TD align="center"><b><font color="#ffffff">Receipt No</font></b></TD>
								<TD align="center"><b><font color="#ffffff">Cheque No</font></b></TD>
								<TD align="center"><b><font color="#ffffff">Cheque Date</font></b></TD>
								<TD align="center"><b><font color="#ffffff">Amount</font></b></TD>
							</TR>
							<%
			try
			{
				InventoryClass obj=new InventoryClass();
				double gtotal=0;
				SqlDataReader rdr,rdr1;
				int i=1;
				string info = "",str="";
				double gamount=0,tamount=0;
				if(DropBank.SelectedIndex==0)
				{
					SqlConnection cn;
					SqlCommand cmd;
                    cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					cn.Open();
					cmd=new SqlCommand("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null",cn);
					rdr1=cmd.ExecuteReader();
					//**str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where chdate>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and chdate<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
					//rdr1 = obj.GetRecordSet("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null");
				
					if(rdr1.HasRows)
					{
						while(rdr1.Read())
						{
							str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+rdr1["chbank"].ToString()+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
							rdr = obj.GetRecordSet(str);
							gamount=0;
							if(rdr.HasRows)
							{
								string s="Name Of Bank : "+rdr1["chbank"].ToString().Trim();
								%>
							<tr>
								<td colSpan="6"><b><%=s%></b></td>
							</tr>
							<%
								while(rdr.Read())
								{	
									gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
									if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
									{
								%>
							<tr class="DataGridItem">
								<td align="center"><%=i.ToString()%></td>
								<td align="right"><%=GenUtil.trimDate(rdr["Feesubdt"].ToString())%></td>
								<td align="right"><%=rdr["RecuringID"].ToString()%></td>
								<td><%=rdr["draftno"].ToString()%></td>
								<td align="right"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))%></td>
								<td align="right"><%=rdr["fees_amount"].ToString()%></td>
							</tr>
							<%
									}
									else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
									{
																					
					
		%>
							<tr class="DataGridItem">
								<td align="center"><%=i.ToString()%></td>
								<td align="right"><%=GenUtil.trimDate(rdr["Feesubdt"].ToString())%></td>
								<td align="right"><%=rdr["RecuringID"].ToString()%></td>
								<td><%=rdr["chno"].ToString()%></td>
								<td align="right"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))%></td>
								<td align="right"><%=rdr["fees_amount"].ToString()%></td>
							</tr>
							<%
									}
									i++;
								}
							%>
							<tr>
								<td colSpan="5"><b>Bank Total:</b></td>
								<td align="right"><b><%=gamount.ToString()%></b></td>
							</tr>
							<%
								//sw.WriteLine(info1,"","-----------------------------");
								//sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
								//sw.WriteLine(info1,"","-----------------------------");
							}
							rdr.Close();
							tamount=tamount+gamount;
						}
							
						//str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
						}//end if
					}
						
				else
				{
					/*SqlConnection cn;
					SqlCommand cmd;
                    cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					cn.Open();
					cmd=new SqlCommand("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null",cn);
					rdr1=cmd.ExecuteReader();
					//**str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where chdate>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and chdate<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
					//rdr1 = obj.GetRecordSet("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null");
				
					if(rdr1.HasRows)
					{*/
						//while(rdr1.Read())
						//{
							//str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+rdr1["chbank"].ToString()+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
							str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+DropBank.SelectedItem.Text+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
							rdr = obj.GetRecordSet(str);
							gamount=0;
							if(rdr.HasRows)
							{
								string s="Name Of Bank : "+DropBank.SelectedItem.Text.Trim();
								%>
							<tr>
								<td colSpan="6"><b><%=s%></b></td>
							</tr>
							<%
								while(rdr.Read())
								{	
									gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
									if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
									{
								%>
							<tr class="DataGridItem">
								<td align="center"><%=i.ToString()%></td>
								<td align="center"><%=GenUtil.trimDate(rdr["Feesubdt"].ToString())%></td>
								<td align="center"><%=rdr["RecuringID"].ToString()%></td>
								<td><%=rdr["draftno"].ToString()%></td>
								<td align="center"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))%></td>
								<td align="right"><%=rdr["fees_amount"].ToString()%></td>
							</tr>
							<%
									}
									else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
									{
																					
					
		%>
							<tr class="DataGridItem">
								<td align="center"><%=i.ToString()%></td>
								<td align="center"><%=GenUtil.trimDate(rdr["Feesubdt"].ToString())%></td>
								<td align="center"><%=rdr["RecuringID"].ToString()%></td>
								<td><%=rdr["chno"].ToString()%></td>
								<td align="center"><%=GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))%></td>
								<td align="right"><%=rdr["fees_amount"].ToString()%></td>
							</tr>
							<%
									}
									i++;
								}
							%>
							<tr>
								<td colSpan="5"><b>Bank Total:</b></td>
								<td align="right"><b><%=gamount.ToString()%></b></td>
							</tr>
							<%
								//sw.WriteLine(info1,"","-----------------------------");
								//sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
								//sw.WriteLine(info1,"","-----------------------------");
							}
							rdr.Close();
							tamount=tamount+gamount;
						//}
							
						//str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
						//}//end if
					}
						
							%>
							<tr>
								<td colSpan="5"><b>Grand Total</b></td>
								<td align="right"><b><%=tamount.ToString()%></b></td>
							</tr>
							<%
							//i++;
				//}
			//}
			//	rdr.Close();
			}
			catch(Exception ex)
			{
				//CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method ASPX,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
			}
							%>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"><asp:validationsummary id="vsPaySlip" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</table>
			<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
			</iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
	</body>
</HTML>
