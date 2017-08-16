<%@ Page language="c#" Codebehind="Subject.aspx.cs" AutoEventWireup="false" Inherits="eschool.Modules.Form.Subject" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../../HeaderFooter/usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="eschool.Classes"%>
<%@ Import namespace="RMG"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eSchool : Subject</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="../../HeaderFooter/shareables/Style/Styles.css">
		<script language=javascript>
		// This method use to Set value hidden textbox. if checkbox checked is true then value is 1 else 0.
		function getvalue(chk,txt)
		{
			if(chk.checked==true)
			{
				txt.value=1
			}
			else
			{
				txt.value=0
			}
			//alert(txt.value)
		}
		// this function use to select all subject.
		function selectall(chk)
		{
			
		    var val=document.Form1.txtemp.value
		    if(chk.checked==true)
			{
				for(var i=1;i<=val*2;i++)
				{
					document.Form1.elements[i].checked=true
					document.Form1.elements[i].value=1
				}
			}
			else
			{
				for(var i=1;i<=val*2;i++)
				{
					document.Form1.elements[i].checked=false
					document.Form1.elements[i].value=0
				}
			}
		}
		
		// this method not in use.
		function View()
		{
			alert("value")
			//var value=document.Form1.tempvalue.value
			
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="View();">
		<form id="Form1" method="post" runat="server">
		
			<uc1:header id="Header1" runat="server"></uc1:header>
			
			<table width="778" height="258" align="center">
				<tr align="center">
					<td><b>SUBJECT</b>
						<table cellpadding="1" cellspacing="1" border="5" bordercolorlight="#663300">
						<tr align="center" bgColor="#663300">
								<td align="center"><font color="#ffffff"><b>Subject Code</b></font></td>
								<td align="center"><font color="#ffffff"><b>Subject Name</b></font></td>
								<td align="center"><font color="#ffffff"><b>Select Subject</b></font></td>
							</tr>
							<% 
							int i=0,j=0;
							//if(flage==0)
							//{
																		
								try
									{
										
										InventoryClass obj=new InventoryClass();
										SqlDataReader sdtr=null;
										string str="Select * from Subject";
										sdtr=obj.GetRecordSet(str);
										while(sdtr.Read())
										{
											i++;
											%>
											<tr>
												<td>&nbsp;<%=sdtr.GetValue(0).ToString()%></td><td>&nbsp;<%=sdtr.GetValue(1).ToString()%></td>
												<%
												if(AList[j++].ToString()=="1")
												{											
												%>
													<td align=center><input type=checkbox value=1 checked onclick="getvalue(this,document.Form1.temp<%=i%>);" name=check<%=i%>>
													<input value=1 style="VISIBILITY:  hidden; WIDTH: 1px; HEIGHT: 1px" name=temp<%=i%> type=text></td>
												<%
												}
												else
												{%>
													<td align=center><input type=checkbox value=0 onclick="getvalue(this,document.Form1.temp<%=i%>);" name=check<%=i%>>
													<input value=0  style="VISIBILITY: hidden; WIDTH: 1px; HEIGHT: 1px" name=temp<%=i%> type=text></td>
												<%
												}
												%>
											</tr>
											<%
										}
										sdtr.Close();
									}
									catch(Exception ex)
									{
										CreateLogFiles.ErrorLog(" Form : Subject.aspx,Method HTML part,  Exception: "+ex.Message);
									}
							 //}
							    %>
							    <tr bgColor="#663300"><td colspan=3 align=right><font color=#ffffff><b>Select All</b></font><input name=chkall type=checkbox onclick="selectall(this);"></td></tr>
							    <tr><td colspan=3 align=center><input type=text style="VISIBILITY: hidden; WIDTH: 10px; HEIGHT: 10px" name=txtemp value=<%=i%>><asp:Button id=btnupdate Runat=server Text=Submit OnClick="update" CssClass="formbuttonstyle"></asp:Button><input name=tempvalue id=tempvalue runat=server style="VISIBILITY: visible; WIDTH: 1px; HEIGHT: 1px"></td></tr>
							</table>
					</td>
				</tr>
			</table>
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</form>
	</body>
</HTML>
<script language=C# runat=server>
/// <Summary>
/// this method use to update the status of subject in subject table.
/// </Summary>
public void update(Object sender, EventArgs e)
{
	try
	{
		
	    int Total_sub=System.Convert.ToInt32(Request.Params.Get("txtemp"));
	    SqlConnection scon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
		scon.Open();
		SqlCommand scom;
		for(int i=1;i<=Total_sub;i++)
		{
			string str="update Subject set Status=@Status where subject_id="+i;
			scom=new SqlCommand(str,scon);
			scom.Parameters.Add("@Status",Request.Params.Get("temp"+i));
			scom.ExecuteNonQuery();
		}
		MessageBox.Show("Subject Successfully Update");
		addlist();
	}
    catch(Exception ex)
    {
      CreateLogFiles.ErrorLog(" Form : Subject.aspx,Method HTML part,  Exception: "+ex.Message);
    }
}

/// <Summary>
/// This method use to add subject in Arraylist from subject table.
/// </Summary>
public void addlist()
{

				AList=new ArrayList();
				SqlDataReader sdtr=null;
                InventoryClass obj=new InventoryClass();
				string str="Select * from subject";
				sdtr=obj.GetRecordSet(str);
				AList.Clear();
				while(sdtr.Read())
				{
					//tempvalue.Value+=sdtr.GetValue(0)+":"+sdtr.GetValue(1)+":"+sdtr.GetValue(2)+",";
					AList.Add(sdtr.GetValue(2));
				
				}
				sdtr.Close();
}
</script>
