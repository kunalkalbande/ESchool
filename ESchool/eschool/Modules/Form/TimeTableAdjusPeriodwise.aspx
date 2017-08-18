<%@ Import namespace="System.Collections"%>
<%@ Import namespace="RMG"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="DBOperations"%>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Page language="c#" Codebehind="TimeTableAdjusPeriodwise.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Form.TimeTaleAdjusPeriodwise" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Time Table Adjustment Periodwise</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../shareables/Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		// this method use to take value from hidden textbox. add value in dropdowns.
		function period(t,v,v1)
		{
			var val=document.Form1.Txtstaffid.value 
			var val1=document.Form1.Txtstaffid1.value 
			var arr=val.split(",");
			var arr1=val1.split(",");
			var j=0,l=0;
			v1.length=1;
			for(var k=0;k<arr1.length;k++)
			{
				var index1=arr1[k].lastIndexOf(":")
				var p1=arr1[k].substring(index1+1)
				if(p1==t.selectedIndex)
				{
					var id1=arr1[k].substring(0,arr1[k].lastIndexOf(":"))
					v1.add(new Option)
					v1.options[l+1].text=id1
					l++;
				}
			}
			v.length=1;
			for(var i=0;i<arr.length;i++)
			{
				var index=arr[i].lastIndexOf(":")
				var p=arr[i].substring(index+1)
				var vv=arr[i].substring(arr[i].lastIndexOf(":"),arr[i].lastIndexOf(":")-1)
				if(p==t.selectedIndex && p>=1 && p<=4 && vv==1)
				{
					var id=arr[i].substring(0,arr[i].lastIndexOf(":")-2)
					v.add(new Option)
					v.options[j+1].text=id
					j++;
				}
				else if(p==t.selectedIndex && p>=5 && p<=8 && vv==2)
				{
		  			var id=arr[i].substring(0,arr[i].lastIndexOf(":")-2)
					v.add(new Option)
					v.options[j+1].text=id
					j++;
				}
			    else if(p==t.selectedIndex && vv==3)
				{
		  			var id=arr[i].substring(0,arr[i].lastIndexOf(":")-2)
					v.add(new Option)
					v.options[j+1].text=id
					j++;
				}
			}	
		}
		
		// this method use to assign hidden textboxs value in to texbox
		function Check(t,temp)
		{
			var index=t.selectedIndex;
			var tempvalue=t.options[index].text;
			temp.value=tempvalue;
		}

		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:header id="Header1" runat="server"></uc1:header>
			<table height="250" width="778" align="center">
				<tr>
					<td vAlign="top" align="center"><B>TIME TABLE ADJUSTMENT PERIODWISE</B>
						<table id="table1" cellSpacing="1" cellPadding="1" borderColorLight="#663300" border="5">
							<tr align="center">
								<td colSpan="3">&nbsp;&nbsp;Day&nbsp;<font color="#ff0000" size="1">*</font>&nbsp;<asp:dropdownlist CssClass="ComboBox" id="Dropday" AutoPostBack="True" Runat="server">
										<asp:ListItem Value="Select">Select</asp:ListItem>
										<asp:ListItem Value="Monday">Monday</asp:ListItem>
										<asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
										<asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
										<asp:ListItem Value="Thursday">Thursday</asp:ListItem>
										<asp:ListItem Value="Friday">Friday</asp:ListItem>
										<asp:ListItem Value="Saturday">Saturday</asp:ListItem>
									</asp:dropdownlist><asp:comparevalidator id="Compare1" Runat="server" ControlToValidate="Dropday" ValueToCompare="Select"
										Operator="NotEqual" ErrorMessage="Select Day">*</asp:comparevalidator>&nbsp;&nbsp;Today 
									Date&nbsp;&nbsp;&nbsp;
									<asp:textbox id="TxtTodyDate" CssClass="Fontstyle"  Width="70px" BorderStyle="Groove"
										Runat="server"></asp:textbox><A onclick="if(self.gfPop)gfPop.fPopCalendar(document.Form1.TxtTodyDate);return false;"><IMG class="PopcalTrigger" alt="" src="../../HeaderFooter/images/calendar_icon.gif" align="absMiddle"
											border="0"></A>
									<asp:button id="BttonSave" onclick="save" Runat="server" CssClass="formbuttonstyle" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="BttonPrint" BorderWidth="2" onclick="save" Runat="server" CssClass="formbuttonstyle"
										Text="Print"></asp:button>&nbsp;&nbsp;&nbsp;</td>
							</tr>
							<%
							if(flage==1)
							{
							%>
							<tr bgColor="#663300">
								<td align="center"><font color="#ffffff"><b>Period</b></font></td>
								<td align="center"><font color="#ffffff"><b>Teacher ID</b></font></td>
								<td align="center"><font color="#ffffff"><b>Class</b></font></td>
							</tr>
							<%
			                        int i=0;
			                        while(i<=59 )
			                          {
			                 %>
							<tr>
								<td align="center"><input style="WIDTH: 10px; HEIGHT: 10px" type=hidden name="txtperiod<%=i%>">
									<select class="ComboBox" onchange="period(this,DropTeacID<%=i%>,DropClass<%=i%>),Check(this,document.Form1.txtperiod<%=i%>)" name="Droperiod<%=i%>">
										<OPTION value="Select" selected>Select</OPTION>
										<option value="1">1</option>
										<option value="2">2</option>
										<option value="3">3</option>
										<option value="4">4</option>
										<option value="5">5</option>
										<option value="6">6</option>
										<option value="7">7</option>
										<option value="8">8</option>
									</select></td>
								<td align="center"><input type=hidden style="WIDTH: 10px; HEIGHT: 10px" name="txtTeacID<%=i%>"><SELECT  class="ComboBox" style="WIDTH: 150px" onchange="Check(this,document.Form1.txtTeacID<%=i%>)" name="DropTeacID<%=i%>">
										<OPTION value="Select" selected>Select</OPTION>
									</SELECT></td>
								<td align="center"><input type=hidden style="WIDTH: 10px; HEIGHT: 10px" name="txtClass<%=i%>" 
            ><SELECT class="ComboBox" style="WIDTH: 80px" 
            onchange="Check(this,document.Form1.txtClass<%=i%>)" 
            name="DropClass<%=i%>">
										<OPTION value="Select" selected>Select</OPTION>
									</SELECT></td>
							</tr>
							<%
			                                   i++;
			                             }
		                        	}
			                      %>
						</table>
				<tr>
					<td><input id="Txtstaffid" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
							size="2" name="Txtstaffid" runat="server"><input id="Txtstaffid1" style="VISIBILITY: hidden; WIDTH: 48px; HEIGHT: 10px" type="text"
							size="2" name="Txtstaffid1" runat="server"></td>
				</tr>
				</td></tr>
				<tr>
					<asp:ValidationSummary ID="Summary1" Runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
				</tr>
			</table>
			<iframe id="gToday:contrast:agenda.js" style="Z-INDEX: 101; LEFT: -500px; VISIBILITY: visible; POSITION: absolute; TOP: 0px"
				name="gToday:contrast:agenda.js" src="../../HeaderFooter/shareables/Style/ipopeng.htm" frameBorder="0"
				width="174" scrolling="no" height="189"></iframe>
			<uc1:footer id="Footer1" runat="server"></uc1:footer></form>
		<script language="C#" runat="server">

public void save(Object sender, EventArgs e)
{
     try
     {
	
        SqlConnection SqlCon =new SqlConnection(System .Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		SqlCon.Open();
		SqlCommand Cmd;
		InventoryClass obj=new InventoryClass();
		SqlDataReader SqlDtr;
		//string msg="";
		
		
		        //string strr="select count(*) from TimeTableAdjustmentPeriodWise where ToDate='"+GenUtil.str2MMDDYYYY(TxtTodyDate.Text.ToString())+"' and Class='"+Request.Params.Get("txtClass"+i)+"' and Period='"+Request.Params.Get("txtperiod"+i)+"' and Sections='"+Request.Params.Get("txtSect"+i)+"'";
				string strr="select count(*) from TimeTableAdjustmentPeriodWise where ToDate='"+GenUtil.str2MMDDYYYY(TxtTodyDate.Text.ToString())+"' and days='"+Dropday.SelectedItem.Value+"'";
				Cmd=new SqlCommand(strr,SqlCon);
				SqlDtr=Cmd.ExecuteReader();
				int icount=0;
				if(SqlDtr.Read())
				{
				         icount=Convert.ToInt32(SqlDtr.GetValue(0));
				}
				Cmd.Dispose();
				SqlDtr.Close();
				
				 if(icount>0)
				 {
				    //str="Update TimeTableAdjustmentPeriodWise set Teacher_ID=@Teacher_ID where Period=@Period and ToDate=@Date and Days=@Day and Class=@Class and Sections=@Section"; 
				    //  str="Update TimeTableAdjustmentPeriodWise set Teacher_ID=@Teacher_ID,Class=@Class where ToDate=@Date and Days=@Day and Period=@Period"; 
				     //msg="Updated";
				     
				      strr="delete from TimeTableAdjustmentPeriodWise where ToDate='"+GenUtil.str2MMDDYYYY(TxtTodyDate.Text.ToString())+"' and days='"+Dropday.SelectedItem.Value+"'";
				     Cmd=new SqlCommand(strr,SqlCon);
				     Cmd.ExecuteNonQuery();
				     Cmd.Dispose();
				     
				 }
		
		int Count=System.Convert.ToInt32(Request.Params.Get("Count"));
		for(int i=0;i<59;i++)
		{
		   // if(Request.Params.Get("txtperiod"+i)!="" && Request.Params.Get("txtTeacID"+i)!="" && Request.Params.Get("txtClass"+i)!="" && Request.Params.Get("txtSect"+i)!="")
		    if(Request.Params.Get("txtperiod"+i)!="" && Request.Params.Get("txtTeacID"+i)!="" && Request.Params.Get("txtClass"+i)!="")
			{
				
				string s=Request.Params.Get("txtTeacID"+i);
				string[] Staffinfo=s.Split(new char[] {':'});
				string str="";
				
				
				 
				
				// else
				// {
				    // str="insert TimeTableAdjustmentPeriodWise (ToDate,Days,Period,Teacher_ID,Class,Sections) values(@Date,@Day,@Period,@Teacher_ID,@Class,@Section)"; 
				     str="insert TimeTableAdjustmentPeriodWise (ToDate,Days,Period,Teacher_ID,Class) values(@Date,@Day,@Period,@Teacher_ID,@Class)"; 
				     //msg="Saved";
				 //}
				
			   // MessageBox.Show(Staffinfo[0].ToString());
			   // MessageBox.Show(Staffinfo[1].ToString());
			   // MessageBox.Show(Staffinfo[2].ToString());
			   // MessageBox.Show(Staffinfo[2].ToString());
			    
				Cmd=new SqlCommand(str,SqlCon);
				Cmd.Parameters.Add("@Date",GenUtil.str2MMDDYYYY(TxtTodyDate.Text.ToString()));
				Cmd.Parameters.Add("@Period",Request.Params.Get("txtperiod"+i));
				Cmd.Parameters.Add("@Teacher_ID",Staffinfo[2].ToString());
				Cmd.Parameters.Add("@Class",Request.Params.Get("txtClass"+i));
				//Cmd.Parameters.Add("@Section",Request.Params.Get("txtSect"+i));
				Cmd.Parameters.Add("@Day",Dropday.SelectedItem.Value);
				Cmd.ExecuteNonQuery();
				Cmd.Dispose();
				
				
			}
		 }
		        SqlCon.Close();
		        MessageBox.Show("TimeTable Adjustment Successfully Saved");
	  }
	  catch(Exception ex)
	  {
	          CreateLogFiles.ErrorLog ("Form: TimeTableAdjustmentWise.aspx.htm, Method: Page_Load. Exception: " + ex.Message + " User: "  );
	  }
	
}

		</script>
	</body>
</HTML>
