/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using RMG;
using eschool.Classes;
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets;

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for SecurityReport.
	/// </summary>
	public class SecurityReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.ValidationSummary vsPaySlip;
		protected System.Web.UI.WebControls.DataGrid grdSecurity;
		protected System.Web.UI.WebControls.Button Exel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Panel pansecu;
		string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values and also fill some 
		/// additional information and also check accessing priviledges for perticular user.
		/// </summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : SecurityFees_Report.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
				{
					InventoryClass obj =new InventoryClass();
					SqlDataReader rdr;
					string str="select class_name from class order by class_id";
					rdr=obj.GetRecordSet(str);
					DropClass.Items.Clear();
					DropClass.Items.Add("All");
					while(rdr.Read())
					{
						DropClass.Items.Add(rdr.GetValue(0).ToString());
					}
					rdr.Close();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="11";
					string[,] Priv=(string[,]) Session["Privileges"];
					for(i=0;i<Priv.GetLength(0);i++)
					{
						if(Priv[i,0]== Module &&  Priv[i,1]==SubModule)
						{						
							View_flag=Priv[i,2];
							Add_Flag=Priv[i,3];
							Edit_Flag=Priv[i,4];
							Del_Flag=Priv[i,5];
							break;
						}
					}	
					if(View_flag=="False")
					{
						Response.Redirect("/eschool/AccessDeny.aspx",false);
						return;
					}
					#endregion
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				//return;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Exel.Click += new System.EventHandler(this.Exel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method use to show report in datagrid. data fetch from recuringreceipt and student_record tables.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				InventoryClass obj =new InventoryClass();
				SqlDataReader rdr;
				string str="";
				if(DropClass.SelectedIndex==0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"'";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"'";
				else
				{
					MessageBox.Show("Please Select Class");
					return;
				}
				rdr=obj.GetRecordSet(str);
				if(rdr.HasRows)
				{
					grdSecurity.DataSource=rdr;
					grdSecurity.DataBind();
					grdSecurity.Visible=true;
					pansecu.Visible=true;
				}
				else
				{
					MessageBox.Show("Data Not Available");
					grdSecurity.Visible=false;
					pansecu.Visible=false;
					return;
				}
				rdr.Close();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to show report in text format. data fetch from recuringreceipt and student_record tables.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SecurityFeesReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str="";
				if(DropClass.SelectedIndex==0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"'";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"'";
				else
				{
					MessageBox.Show("Please Select Class");
					return;
				}
				rdr = obj.GetRecordSet(str);
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				sw.WriteLine();
				string des="+----------+-----+-------+-------------------------------+---------------+";
                //sw.WriteLine(GenUtil.GetCenterAddr("NO.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("Security Fees Report",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				info = " {0,-10:S} {1,5:S} {2,-7:S} {3,-31:S} {4,15:S}";
				sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+" , Section : "+DropSection.SelectedItem.Text);
				sw.WriteLine("+----------+-----+-------+-------------------------------+---------------+");
				sw.WriteLine("|Student ID|Class|Section|         Student Name          |Security Amount|");
				sw.WriteLine("+----------+-----+-------+-------------------------------+---------------+");
				//             1234567890 12345 1234567 1234567890123456789012345678901 123456789012345 
				
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{	
						sw.WriteLine (info,
							rdr["Student_ID"].ToString(),
							//rdr["Student_Class"].ToString(),
						GenUtil.TrimLength(rdr["Student_Class"].ToString(),4),
							rdr["Seq_Student_ID"].ToString(),
							rdr["Student_FName"].ToString(),
							rdr["securityfee"].ToString()
							);
					}
				}
				rdr.Close();
				sw.WriteLine("+----------+-----+-------+-------------------------------+---------------+");
				sw.WriteLine(info,"Total","","","",Cache["amt"].ToString());
				sw.WriteLine("+----------+-----+-------+-------------------------------+---------------+");
				sw.Close();
				Print();
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click, SecurityFeesReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this method use to show report in excel format. data fetch from recuringreceipt and student_record tables.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				int i=1;
				SqlDataReader rdr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\SecurityReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				string strSelect="";
				string str="";
				if(DropClass.SelectedIndex==0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex==0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"'";
				else if(DropClass.SelectedIndex!=0 && DropSection.SelectedIndex!=0)
					str="select distinct rr.student_id,sr.student_class,sr.seq_student_id,sr.student_fname,rr.securityfee from recuringreceipt rr,student_record sr where rr.student_id=sr.student_id and rr.securityfee<>0 and sr.student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"'";
				else
				{
					MessageBox.Show("Please Select Class");
					return;
				}
				rdr = obj.GetRecordSet(str);
				
				string des="+----------+-----+-------+-------------------------------+---------------+";
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("SECURITY FEES REPORT",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("----------------------",des.Length));
				sw.WriteLine(" Class : "+DropClass.SelectedItem.Text+" ,\t Section : "+DropSection.SelectedItem.Text);
				sw.WriteLine("S.No.\tStudent ID\tClass\tSection\t         Student Name          \tSecurity Amount");
						
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{	
         					sw.WriteLine (i.ToString()+"\t"+rdr["Student_ID"].ToString()+"\t"+
							rdr["Student_Class"].ToString()+"\t"+
							rdr["Seq_Student_ID"].ToString()+"\t"+
							rdr["Student_FName"].ToString()+"\t"+
							rdr["securityfee"].ToString()
							);
					}
				}
				sw.WriteLine("Total\t\t\t\t\t"+Cache["amt"].ToString());
				rdr.Close();
				sw.Close();
				Print();
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click, SecurityFeesReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// Method for issueing the print command to the printer for printing the text file.
		/// </summary>
		public void Print()
		{
			byte[] bytes = new byte[1024];
			/// Connect to a remote device.
			try 
			{
				/// Establish the remote endpoint for the socket.
				/// The name of the
				/// remote device is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve("127.0.0.1");
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress,63000);
				/// Create a TCP/IP  socket.
				Socket sender1 = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, ProtocolType.Tcp );
				/// Connect the socket to the remote endpoint. Catch any errors.
				try 
				{
					sender1.Connect(remoteEP);
					Console.WriteLine("Socket connected to {0}",
					sender1.RemoteEndPoint.ToString());
 					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\SecurityFeesReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
			        /// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method :  Print(),  SecurityFeesReport Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :SecurityReport.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Exel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:SecurityReport.aspx,Method: btnExcel_Click, Security Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:SecurityReport.aspx,Method:btnExcel_Click   Security Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// this method use to get total secrity amount. 
		/// </summary>
		double Tot=0;
		public string	GetSecurityAmount(string amt)
		{
			Tot+=double.Parse(amt);
			Cache["amt"]=Tot.ToString();
			return amt;
		}
	}
}
