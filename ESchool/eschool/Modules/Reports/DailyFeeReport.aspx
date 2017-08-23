<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="DailyFeeReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.DailyFeeReport" %>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="System.Data.SqlClient"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Daily Fees Receipt Report</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<meta content="JavaScript" name="vs_defaultClientScript">
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
					<td align="center"><b>DAILY FEES RECIEPT REPORT</b>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="80%" borderColorLight="#663300"
							border="5">
							<TR>
								<TD align="center" colSpan="20">Date&nbsp;&nbsp;&nbsp;<asp:textbox id="txtDob" BorderStyle="Groove" CssClass="FontStyle" Runat="server" Width="70px"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Payslip.txtDob);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle" border="0"></A>&nbsp;&nbsp;&nbsp;
								<BUTTON id="Search" style="BORDER-RIGHT: #404040 thin outset; BORDER-TOP: #404040 thin outset; FONT-SIZE: 10pt; BORDER-LEFT: #404040 thin outset; WIDTH: 100px; BORDER-BOTTOM: #404040 thin outset; FONT-FAMILY: MS Sans Serif; HEIGHT: 21px; BACKGROUND-COLOR: #e1e1e1" accessKey="S" type="button" runat="server" class="FormButtonStyle"><IMG id="txtsearch" height="7" src="../../HeaderFooter/images/search.gif" width="16"> <U>S</U>earch</BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="Button1" BorderColor="Black" BorderStyle="Groove"  runat="server" Width="85px" Height=21 CssClass="FormButtonStyle" Text="Print"  Font-Size="X-Small"></asp:button>&nbsp;
								<asp:button id="btnExcel" BorderColor="Black" BorderStyle="Groove" runat="server" Width="85px" Height=21 CssClass="FormButtonStyle" Text="Excel"  Font-Size="X-Small"></asp:button>&nbsp;&nbsp;</TD>
							</TR>
							<%
							if(flage==1)
							{
				try
				{
					InventoryClass obj=new InventoryClass();
					InventoryClass obj1=new InventoryClass();
					double gtutionfee=0,gcomputerfee=0,ghousefee=0,ggamefee=0,gsciencefee=0,gregistrationfee=0,glatefee=0,gadmissionfee=0,gtransportfee=0,gdevelopmentfee=0,gdiaryfee=0,gannualfee=0,gsecurity=0,gtotal=0;
					SqlDataReader rdr;
					int i=1;
					string info = "",str="",str1="";
					if(txtDob.Text!="")
					{
						//**str = "select distinct(RecuringID) from recuringreceipt where  FeeSubdt='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"'";
						//str = "select * from recuringreceipt rr,Student_Record sr where FeeSubdt='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.Student_ID order by rr.recuringid";
						
						
						str = "	select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.seq_student_id,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Record sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.Student_ID UNION select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.student_stream,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Registration sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.RegID";
						///str = "	select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.seq_student_id,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Record sr where cast(FeeSubdt as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.Student_ID UNION select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.student_stream,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Registration sr where cast(FeeSubdt as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.RegID";
					}
					else
					{
						MessageBox.Show("Please select date");
						return;
					}
					rdr = obj.GetRecordSet(str);
					
					if(rdr.HasRows)
					{
						
						%>
							<TR bgcolor="#663300">
								<TD><b><font color="#ffffff">SNo</font></b></TD>
								<TD><b><font color="#ffffff">Rec No</font></b></TD>
								<TD><b><font color="#ffffff">SID</font></b></TD>
								<TD><b><font color="#ffffff">Student Name</font></b></TD>
								<TD><b><font color="#ffffff">Class</font></b></TD>
								<TD><b><font color="#ffffff">Section</font></b></TD>
								<TD><b><font color="#ffffff">Tution</font></b></TD>
								<TD><b><font color="#ffffff">Computer</font></b></TD>
								<TD><b><font color="#ffffff">House</font></b></TD>
								<TD><b><font color="#ffffff">Game</font></b></TD>
								<TD><b><font color="#ffffff">Science</font></b></TD>
								<TD><b><font color="#ffffff">Registration</font></b></TD>
								<TD><b><font color="#ffffff">Late</font></b></TD>
								<TD><b><font color="#ffffff">Admission</font></b></TD>
								<TD><b><font color="#ffffff">Transport</font></b></TD>
								<TD><b><font color="#ffffff">Env</font></b></TD>
								<TD><b><font color="#ffffff">Diary</font></b></TD>
								<TD><b><font color="#ffffff">Annual</font></b></TD>
								<td><b><font color="#ffffff">Security</font></b></td>
								<TD><b><font color="#ffffff">Total</font></b></TD>
							</TR>
							<%
				while(rdr.Read())
						{	
				
						//**feesdecisionmonthly(rdr["RecuringID"].ToString());
				%>
							<tr class="DataGridItem">
								<td align=center><%=i.ToString()%></td>
								<td align=center><%=rdr["RecuringID"].ToString()%></td>
								<td align=center><%=rdr["Student_ID"].ToString()%></td>
								<td><%=rdr["Student_FName"].ToString()%></td>
								<%if(rdr["Student_Class"].ToString()!=null||rdr["Student_Class"].ToString()!=""){%>
								<td align="center"><%=rdr["Student_Class"].ToString()%></td>
								<%}else{%>
								<td><%=""%></td>
								<%}if(rdr["Seq_Student_ID"].ToString()!=null||rdr["Seq_Student_ID"].ToString()!=""){%>
								<td align="center"><%=rdr["Seq_Student_ID"].ToString()%></td>
								<%}else{%>
								<td><%=""%></td>
								<%}if(rdr["tution_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["Tution_Fee"].ToString()%><%gtutionfee+=double.Parse(rdr["tution_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["computer_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["computer_fee"].ToString()%><%gcomputerfee+=double.Parse(rdr["computer_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["Hostel_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["Hostel_Fee"].ToString()%><%ghousefee+=double.Parse(rdr["Hostel_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["game_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["Game_Fee"].ToString()%><%ggamefee+=double.Parse(rdr["Game_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["Science_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["science_fee"].ToString()%><%gsciencefee+=double.Parse(rdr["Science_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["Regfee"].ToString()!=""){%>
								<td align="right"><%=rdr["RegFee"].ToString()%><%gregistrationfee+=double.Parse(rdr["RegFee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["latefee"].ToString()!=""){%>
								<td align="right"><%=rdr["LateFee"].ToString()%><%glatefee+=double.Parse(rdr["LateFee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["admission_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["admission_fee"].ToString()%><%gadmissionfee+=double.Parse(rdr["admission_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["transport_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["transport_fee"].ToString()%><%gtransportfee+=double.Parse(rdr["transport_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["envp_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["Envp_fee"].ToString()%><%gdevelopmentfee+=double.Parse(rdr["Envp_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["diary_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["diary_fee"].ToString()%><%gdiaryfee+=double.Parse(rdr["Diary_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["annual_fee"].ToString()!=""){%>
								<td align="right"><%=rdr["annual_fee"].ToString()%><%gannualfee+=double.Parse(rdr["annual_fee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["securityfee"].ToString()!=""){%>
								<td align="right"><%=rdr["securityFee"].ToString()%><%gsecurity+=double.Parse(rdr["securityfee"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}if(rdr["Fees_Amount"].ToString()!=""){%>
								<td align="right"><%=rdr["Fees_Amount"].ToString()%><%gtotal+=double.Parse(rdr["Fees_Amount"].ToString());%></td>
								<%}else{%>
								<td>0</td>
								<%}%>
							</tr>
							<%
							i++;
				}
							%>
							<tr bgcolor="#663300">
								<td colSpan="3"><b><font color="#ffffff">Grand Total</font></b></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td align="right"><b><font color="#ffffff"><%=gtutionfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gcomputerfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=ghousefee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=ggamefee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gsciencefee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gregistrationfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=glatefee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gadmissionfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gtransportfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gdevelopmentfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gdiaryfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gannualfee.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gsecurity.ToString()%></font></b></td>
								<td align="right"><b><font color="#ffffff"><%=gtotal.ToString()%></font></b></td>
							</tr>
							<%}
					else
					{
						MessageBox.Show("Data Not Available");
						
					}
				rdr.Close();
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog(" Form : Login.aspx,Method  btnLogin_Click,  Exception: "+ex.Message+" , Userid :  "+ Session["password"]   );
				}
				}
				%>
						</TABLE>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="3"><asp:validationsummary id="vsPaySlip" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
	
		<!--PopCalendar(tag name and id must match) Tags should sit at the page bottom --><iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
			name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0" width="174" scrolling="no" height="189">
		</iframe>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>	</form>
	</body>
</HTML>
