<%@ Page language="c#" Codebehind="ClassWiseReport.aspx.cs" AutoEventWireup="false" Inherits="eschool.Reports.ClassWiseReport" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<%@ Import namespace="System.IO"%>
<%@ Import namespace="System.Collections.Specialized"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Class Wise Time Table</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table width="778" height="250" align="center">
				<tr height="200">
					<td align="center"><B>CLASS WISE TIME TABLE</B>
						<table width="100%" borderColorLight="#663300" border="5">
							<tr>
								<td colspan="9" align="center">Class&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
									<asp:DropDownList id="DropClass" CssClass=ComboBox runat="server" Width="88px">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										
									</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									Section&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:DropDownList CssClass=ComboBox id="DropSec" runat="server" Width="88px">
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
									</asp:DropDownList>&nbsp;
									<asp:Button id="Button1" runat="server" Height=21 Width="100px" Text="Search" BorderStyle="Groove" BorderColor="Black" BackColor="#E0E0E0" CssClass="FormButtonStyle" Font-Size="X-Small" BorderWidth="2px"></asp:Button>&nbsp;
									<asp:Button id="Button2" runat="server" Height=21 Width="85px" Text="Print" BorderStyle="Groove"  BackColor="#E0E0E0" CssClass="FormButtonStyle" BorderColor="Black" Font-Size="X-Small" BorderWidth="2px"></asp:Button>
									<asp:Button id="Btnexcel" runat="server" Height=21 Width="85px" Text="Excel" BorderStyle="Groove"  BackColor="#E0E0E0" CssClass="FormButtonStyle" BorderColor="Black" Font-Size="X-Small" BorderWidth="2px"></asp:Button></td>
							</tr>
							<!--tr height=150>
					<td align="center"-->
							<%
		InventoryClass obj=new InventoryClass();
		InventoryClass obj2=new InventoryClass();
		SqlDataReader sql,dr;
		string cls="";
		if(DropClass.SelectedIndex!=0)
		{
			/*if(DropClass.SelectedItem.Text=="I")
				cls="1";
			else if(DropClass.SelectedItem.Text=="II")
				cls="2";
			else if(DropClass.SelectedItem.Text=="III")
				cls="3";
			else if(DropClass.SelectedItem.Text=="IV")
				cls="4";
			else if(DropClass.SelectedItem.Text=="V")
				cls="5";
			else if(DropClass.SelectedItem.Text=="VI")
				cls="6";
			else if(DropClass.SelectedItem.Text=="VII")
				cls="7";
			else if(DropClass.SelectedItem.Text=="VIII")
				cls="8";
			else if(DropClass.SelectedItem.Text=="IX")
				cls="9";
			else if(DropClass.SelectedItem.Text=="X")
				cls="10";
			else if(DropClass.SelectedItem.Text=="XI")
				cls="11";
			else if(DropClass.SelectedItem.Text=="XII")
				cls="12";*/
				
			if(DropClass.SelectedItem.Text=="Nursery")
				cls="1";
			else if(DropClass.SelectedItem.Text=="LKG")
				cls="2";
			else if(DropClass.SelectedItem.Text=="UKG")
				cls="3";
			else if(DropClass.SelectedItem.Text=="I")
				cls="4";
			else if(DropClass.SelectedItem.Text=="II")
				cls="5";
			else if(DropClass.SelectedItem.Text=="III")
				cls="6";
			else if(DropClass.SelectedItem.Text=="IV")
				cls="7";
			else if(DropClass.SelectedItem.Text=="V")
				cls="8";
			else if(DropClass.SelectedItem.Text=="VI")
				cls="9";
			else if(DropClass.SelectedItem.Text=="VII")
				cls="10";
			else if(DropClass.SelectedItem.Text=="VIII")
				cls="11";
			else if(DropClass.SelectedItem.Text=="IX")
				cls="12";
			else if(DropClass.SelectedItem.Text=="X")
				cls="13";
			else if(DropClass.SelectedItem.Text=="XI")
				cls="14";
			else if(DropClass.SelectedItem.Text=="XII")
				cls="15";
		}
			string[] Mon=new string[48]; 
			string[] tcode=new string[48]; 
			String mon1="";
			string str1="",period="";
			string str="select * from teachertimetable";
			sql=obj.GetRecordSet(str);
			bool flag=false;
			if(sql.Read())
			{
				for(int j=2;j<sql.FieldCount-2;j++)
				{
					//str1="select "+sql.GetName(j).ToString()+",shortname from teachertimetable where "+sql.GetName(j).ToString()+" like '"+cls+DropSec+"%'";
					str1="select "+sql.GetName(j).ToString()+",shortname from teachertimetable where "+sql.GetName(j).ToString()+" like '"+cls+DropSec.SelectedItem.Text+"%'";
					dr=obj2.GetRecordSet(str1);
					while(dr.Read())
					{
						flag=true;
						period=dr.GetValue(0).ToString();
						if(period.IndexOf("A")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("A")+1,period.Length-period.IndexOf("A")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("B")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("B")+1,period.Length-period.IndexOf("B")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("C")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("C")+1,period.Length-period.IndexOf("C")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else if(period.IndexOf("D")>0)
						{
							Mon[j-2]=period.Substring(period.IndexOf("D")+1,period.Length-period.IndexOf("D")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
						else
						{
							Mon[j-2]=period;//.Substring(period.IndexOf("D")+1,period.Length-period.IndexOf("D")-1);
							tcode[j-2]=dr.GetValue(1).ToString();
						}
										
					}
					dr.Close();
				}
				
			}
			/*if(flag==false)
			  MessageBox.Show("No such record avilable in the database");*/
			sql.Close();
			
		%>
							<%if(DropClass.SelectedIndex!=0){%>
							<tr>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>D \ P</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>I</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>II </b>
								</td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>III</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>IV</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>V</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>VI</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>VII</b></td>
								<td align="center" width="11%" style="COLOR: white; BACKGROUND-COLOR: #663300"><b>VIII</b></td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>MON</b></td>
								<td><%=tcode[0]%>&nbsp;<%=Mon[0]%>&nbsp;</td>
								<td><%=tcode[1]%>&nbsp;<%=Mon[1]%>&nbsp;</td>
								<td><%=tcode[2]%>&nbsp;<%=Mon[2]%>&nbsp;</td>
								<td><%=tcode[3]%>&nbsp;<%=Mon[3]%>&nbsp;</td>
								<td><%=tcode[4]%>&nbsp;<%=Mon[4]%>&nbsp;</td>
								<td><%=tcode[5]%>&nbsp;<%=Mon[5]%>&nbsp;</td>
								<td><%=tcode[6]%>&nbsp;<%=Mon[6]%>&nbsp;</td>
								<td><%=tcode[7]%>&nbsp;<%=Mon[7]%>&nbsp;</td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>TUES</b></td>
								<td><%=tcode[8]%>&nbsp;&nbsp;<%=Mon[8]%>&nbsp;</td>
								<td><%=tcode[9]%>&nbsp;&nbsp;<%=Mon[9]%>&nbsp;</td>
								<td><%=tcode[10]%>&nbsp;&nbsp;<%=Mon[10]%>&nbsp;</td>
								<td><%=tcode[11]%>&nbsp;&nbsp;<%=Mon[11]%>&nbsp;</td>
								<td><%=tcode[12]%>&nbsp;&nbsp;<%=Mon[12]%>&nbsp;</td>
								<td><%=tcode[13]%>&nbsp;&nbsp;<%=Mon[13]%>&nbsp;</td>
								<td><%=tcode[14]%>&nbsp;&nbsp;<%=Mon[14]%>&nbsp;</td>
								<td><%=tcode[15]%>&nbsp;&nbsp;<%=Mon[15]%>&nbsp;</td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>WED</b></td>
								<td><%=tcode[16]%>&nbsp;&nbsp;<%=Mon[16]%>&nbsp;</td>
								<td><%=tcode[17]%>&nbsp;&nbsp;<%=Mon[17]%>&nbsp;</td>
								<td><%=tcode[18]%>&nbsp;&nbsp;<%=Mon[18]%>&nbsp;</td>
								<td><%=tcode[19]%>&nbsp;&nbsp;<%=Mon[19]%>&nbsp;</td>
								<td><%=tcode[20]%>&nbsp;&nbsp;<%=Mon[20]%>&nbsp;</td>
								<td><%=tcode[21]%>&nbsp;&nbsp;<%=Mon[21]%>&nbsp;</td>
								<td><%=tcode[22]%>&nbsp;&nbsp;<%=Mon[22]%>&nbsp;</td>
								<td><%=tcode[23]%>&nbsp;&nbsp;<%=Mon[23]%>&nbsp;</td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>THURS</b></td>
								<td><%=tcode[24]%>&nbsp;&nbsp;<%=Mon[24]%>&nbsp;</td>
								<td><%=tcode[25]%>&nbsp;&nbsp;<%=Mon[25]%>&nbsp;</td>
								<td><%=tcode[26]%>&nbsp;&nbsp;<%=Mon[26]%>&nbsp;</td>
								<td><%=tcode[27]%>&nbsp;&nbsp;<%=Mon[27]%>&nbsp;</td>
								<td><%=tcode[28]%>&nbsp;&nbsp;<%=Mon[28]%>&nbsp;</td>
								<td><%=tcode[29]%>&nbsp;&nbsp;<%=Mon[29]%>&nbsp;</td>
								<td><%=tcode[30] %>&nbsp;&nbsp;<%= Mon[30]%>&nbsp;</td>
								<td><%=tcode[31] %>&nbsp;&nbsp;<%=Mon[31]%>&nbsp;</td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>FRI</b></td>
								<td><%=tcode[32] %>&nbsp;&nbsp;<%=Mon[32]%>&nbsp;</td>
								<td><%=tcode[33] %>&nbsp;&nbsp;<%=Mon[33]%>&nbsp;</td>
								<td><%=tcode[34] %>&nbsp;&nbsp;<%=Mon[34]%>&nbsp;</td>
								<td><%=tcode[35] %>&nbsp;&nbsp;<%=Mon[35]%>&nbsp;</td>
								<td><%=tcode[36] %>&nbsp;&nbsp;<%=Mon[36]%>&nbsp;</td>
								<td><%=tcode[37] %>&nbsp;&nbsp;<%=Mon[37]%>&nbsp;</td>
								<td><%=tcode[38] %>&nbsp;&nbsp;<%=Mon[38]%>&nbsp;</td>
								<td><%=tcode[39] %>&nbsp;&nbsp;<%=Mon[39]%>&nbsp;</td>
							</tr>
							<tr>
								<td style="COLOR: white; BACKGROUND-COLOR: #663300"><b>SAT</b></td>
								<td><%=tcode[40] %>&nbsp;&nbsp;<%=Mon[40]%>&nbsp;</td>
								<td><%=tcode[41]%>&nbsp;&nbsp;<%=Mon[41]%>&nbsp;</td>
								<td><%=tcode[42] %>&nbsp;&nbsp;<%=Mon[42]%>&nbsp;</td>
								<td><%=tcode[43] %>&nbsp;&nbsp;<%=Mon[43]%>&nbsp;</td>
								<td><%=tcode[44] %>&nbsp;&nbsp;<%=Mon[44]%>&nbsp;</td>
								<td><%=tcode[45] %>&nbsp;&nbsp;<%=Mon[45]%>&nbsp;</td>
								<td><%=tcode[46] %>&nbsp;&nbsp;<%=Mon[46]%>&nbsp;</td>
								<td><%=tcode[47] %>&nbsp;&nbsp;<%=Mon[47]%>&nbsp;
								</td>
							</tr>
							<%}%>
						</table>
					</td>
				</tr></TD>
			</table>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
