<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Page language="c#" Codebehind="ResultGlance.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.ResultGlance" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Result At A Glance</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method not in use
		function FillIandII(t,d)
		{
			var index=t.selectedIndex
			var val=t.options[index].value
			//alert(index);
			//alert(d.name);
			if(val=="I" || val=="II")
			{
				d.clear
				d.length=1
				//alert(val+" I  II");
				//d.options[0].text="Select";
				d.add(new Option)  
				d.options[1].text="Ist Unit Test"
				d.add(new Option)
				d.options[2].text="IInd Unit Test"
				d.add(new Option)
				d.options[3].text="IIIrd Unit Test"
				d.add(new Option)
				d.options[4].text="IVth Unit Test"
				d.add(new Option)
				d.options[5].text="Vth Unit Test"
				d.add(new Option)
				d.options[6].text="Assign & Project"                                                
			}
			else
			{
				d.clear
				d.length=1
				d.add(new Option)  
				d.options[1].text="Ist Term"
				d.add(new Option)
				d.options[2].text="IInd Term"
				d.add(new Option)
				d.options[3].text="IIIrd Term"
			}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ResultGlance" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<TBODY>
					<TR>
						<td align="center"><b>RESULT AT A GLANCE</b>
							<TABLE cellSpacing="1" cellPadding="1" width="95%" align="center" borderColorLight="#663300"
								border="5">
							<!--TR>
								<td align="center" colSpan="13"-->
							<!--<H2><FONT color="black">NO.1 AIR FORCE SCHOOL GWALIOR</FONT></H2>
								<H2><FONT color="black">RESULT AT A GLANCE </FONT>
								</H2>
								<FONT color="black">ANNUAL EXAMINATION</FONT></td> comment by vikas sharma date on 15/09/07--></td>
					<TR>
						<TD colSpan="13" align="center">Class&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="DropClass" CssClass="ComboBox" runat="server" Width="65">
								<asp:ListItem Value="Select">Select</asp:ListItem>
							</asp:dropdownlist>&nbsp;&nbsp;&nbsp;Section&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="DropSec" runat="server" CssClass="ComboBox" Width="65">
								<asp:ListItem Value="Select">Select</asp:ListItem>
								<asp:ListItem Value="A">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
								<asp:ListItem Value="D">D</asp:ListItem>
								<asp:ListItem Value="E">E</asp:ListItem>
								<asp:ListItem Value="F">F</asp:ListItem>
								<asp:ListItem Value="G">G</asp:ListItem>
								<asp:ListItem Value="H">H</asp:ListItem>
								<asp:ListItem Value="I">I</asp:ListItem>
								<asp:ListItem Value="J">J</asp:ListItem>
							</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp; Stream&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="DropStream" CssClass="ComboBox" Runat="server">
								<asp:ListItem Value="None">None</asp:ListItem>
								<asp:ListItem Value="Bio Group">Bio Group</asp:ListItem>
								<asp:ListItem Value="Math Group">Math Group</asp:ListItem>
								<asp:ListItem Value="Commerce Group">Commerce Group</asp:ListItem>
							</asp:dropdownlist>
							&nbsp;&nbsp;&nbsp;Exam Type&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="Dropexamtype" CssClass="ComboBox" runat="server">
								<asp:ListItem Value="Select">Select</asp:ListItem>
								<asp:ListItem Value="Ist Unit Test">Ist Unit Test</asp:ListItem>
								<asp:ListItem Value="IInd Unit Test">IInd Unit Test</asp:ListItem>
								<asp:ListItem Value="IIIrd Unit Test">IIIrd Unit Test</asp:ListItem>
								<asp:ListItem Value="IVth Unit Test">IVth Unit Test</asp:ListItem>
								<asp:ListItem Value="Vth Unit Test">Vth Unit Test</asp:ListItem>
								<asp:ListItem Value="Assign & Project">Assign & Project</asp:ListItem>
								<asp:ListItem Value="Ist Term">Ist Term</asp:ListItem>
								<asp:ListItem Value="IInd Term">IInd Term</asp:ListItem>
								<asp:ListItem Value="IIIrd Term">IIIrd Term</asp:ListItem>
							</asp:dropdownlist>
							Session&nbsp;&nbsp;<asp:dropdownlist CssClass="ComboBox" id="DropSession" Runat="server" AutoPostBack="False">
								<asp:ListItem Value="Select">Select</asp:ListItem>
								<asp:ListItem Value="2006:2007">2006:2007</asp:ListItem>
								<asp:ListItem Value="2007:2008">2007:2008</asp:ListItem>
								<asp:ListItem Value="2008:2009">2008:2009</asp:ListItem>
								<asp:ListItem Value="2009:2010">2009:2010</asp:ListItem>
								<asp:ListItem Value="2010:2011">2010:2011</asp:ListItem>
								<asp:ListItem Value="2011:2012">2011:2012</asp:ListItem>
								<asp:ListItem Value="2012:2013">2012:2013</asp:ListItem>
								<asp:ListItem Value="2013:2014">2013:2014</asp:ListItem>
								<asp:ListItem Value="2014:2015">2014:2015</asp:ListItem>
								<asp:ListItem Value="2015:2016">2015:2016</asp:ListItem>
								<asp:ListItem Value="2016:2017">2016:2017</asp:ListItem>
								<asp:ListItem Value="2017:2018">2017:2018</asp:ListItem>
								<asp:ListItem Value="2018:2019">2018:2019</asp:ListItem>
								<asp:ListItem Value="2019:2020">2019:2020</asp:ListItem>
								<asp:ListItem Value="2020:2021">2020:2021</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<tr>
						<TD colspan="13" align="center">
							<asp:button id="btnShow" BorderColor="Black" Width="100px"
								Height="22" Runat="server" CssClass="formbuttonstyle"  Text="Show"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnPrint" BorderColor="Black"  Width="85px"
								Height="22" Runat="server" CssClass="formbuttonstyle" Text="Print"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="Btnexcel" BorderColor="Black"  Width="85px"
								Height="22" Runat="server" CssClass="formbuttonstyle" Text="Excel"></asp:button>
						</TD>
					</tr>
					<asp:Panel ID="panglsnce" Runat="server" Visible="False">
						<TR>
							<TD colSpan="13">
								<TABLE width="100%" border="1">
									<TR bgColor="#663300">
										<TH width="10%" rowSpan="2">
											<B><FONT color="#ffffff">No Of<BR>
													Student In<BR>
													The Class </FONT></B>
										</TH>
										<TH width="10%" rowSpan="2">
											<B><FONT color="#ffffff">No Of<BR>
													Student<BR>
													Absent </FONT></B>
										</TH>
										<TH width="10%" rowSpan="2">
											<B><FONT color="#ffffff">No Of<BR>
													Student<BR>
													Appeared</FONT></B></TH>
										<TH width="10%" rowSpan="2">
											<B><FONT color="#ffffff">No Of<BR>
													Student<BR>
													Passed</FONT></B></TH>
										<TH width="10%" rowSpan="2">
											<B><FONT color="#ffffff">Pass<BR>
													Percentage</FONT></B></TH>
										<TH width="50%" colSpan="8">
											<B><FONT color="#ffffff">RECORD OF GRADES</FONT></B></TH></TR>
									<TR bgColor="#663300">
										<TH width="6%">
											<B><FONT color="#ffffff">A+</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">A</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">B+</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">B</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">C+</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">C</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">D</FONT></B></TH>
										<TH width="6%">
											<B><FONT color="#ffffff">E</FONT></B></TH></TR>
									<TR>
										<TD align="center"><%=NoofStudent%></TD>
										<TD align="center"><%=StudentAbsent%></TD>
										<TD align="center"><%=AppearedStudent%></TD>
										<TD align="center"><%=PassedStudent%></TD>
										<TD align="center"><%=passPercentage%></TD>
										<TD align="center"><%=gradeAp%></TD>
										<TD align="center"><%=gradeA%></TD>
										<TD align="center"><%=gradeBp%></TD>
										<TD align="center"><%=gradeB%></TD>
										<TD align="center"><%=gradeCp%></TD>
										<TD align="center"><%=gradeC%></TD>
										<TD align="center"><%=gradeD%></TD>
										<TD align="center"><%=gradeE%></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</asp:Panel>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe></TD></TR></TBODY></TABLE><uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
