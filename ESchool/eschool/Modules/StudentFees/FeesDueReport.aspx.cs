/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
    # region Directives...
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
using System.IO ;
using System.Text;
using System.Net ;
using System.Net.Sockets;
# endregion

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for FeesDueReport.
	/// </summary>
	public class FeesDueReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlButton print;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSec;
		protected System.Web.UI.WebControls.TextBox Txtfromdate;
		protected System.Web.UI.WebControls.TextBox Txttodate;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		public string rank="";
		public string student_id="";
		public string category="";
		public string section="";
		public string classid="";
		public string sname="";
		public string stream="";
		public double tutionfee=0;
		public double computerfee=0;
		public double housefee=0;
		public double gamefee=0;
		public double sciencefee=0;
		public double annualfee=0;
		public double registraionfee=0;
		public double latefee=0;
		public double admissionfee=0;
		public double transportfee=0;
		public double developmentfee=0;
		public double dairyfee=0;
		public double security=0;
		public double total=0;
		public double Caution=0;
		public double TempCaution=0;
		public double gtutionfee=0;
		public double gcomputerfee=0;
		public double ghousefee=0;
		public double ggamefee=0;
		public double gsciencefee=0;
		public double gannualfee=0;
		public double gregistraionfee=0;
		public double glatefee=0;
		public double gadmissionfee=0;
		public double gtransportfee=0;
		public double gdevelopmentfee=0;
		public double gdairyfee=0;
		public double gsecurity=0;
		public double gtotal=0;
		public double gCaution=0;
		protected System.Web.UI.HtmlControls.HtmlButton Exel;
		public double gTempCaution=0;
	    string pass;

		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : FeesDue_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
		   try
		   {
			    //string pass;
			    //pass=(Session["password"].ToString ());
				if(!Page .IsPostBack)
				{
                	Txtfromdate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					Txttodate.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					InventoryClass obj=new InventoryClass();
					SqlDataReader sdred=null;
					//string str="select distinct student_class from student_record sr,recuringreceipt rr where rr.student_id=sr.student_id";
					string str="select class_name from class order by class_id";
					sdred=obj.GetRecordSet(str);
					DropClass.Items.Clear();
					DropClass.Items.Add("Select");
					DropClass.Items.Add("All");
					while(sdred.Read())
					{
						DropClass.Items .Add (sdred.GetValue(0).ToString());
					}		
					sdred.Close();
				}
			           
			if(! IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="6";
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
				}
				#endregion
			}
			
		   }

		   catch(Exception ex)
		   {
			   CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			   Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
			   return;
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
		/// 
		
		private void InitializeComponent()
		{    
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.print.ServerClick += new System.EventHandler(this.print_ServerClick);
			this.Exel.ServerClick += new System.EventHandler(this.Exel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// function to convert DDMMYY to MM/DD/YYYY
		/// </summary>
		public DateTime ToMMddYYYY(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}
		
		/// <summary>
		/// Method for viewing the report on the datagrid. data fetch from feesdecision and also check from recuringrecipt table.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			gtotal=0;
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";// add by vikas sharma date on 22.02.08
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthly(student_id);
							}
							SqlDtr.Close();
						}
						else
						{
							if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
							{
								MessageBox.Show("Please select The Information ");
								
							}
							else
							{
								strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";  // add by vikas sharma date on 22.02.08
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthly(student_id);
								}
								SqlDtr.Close();
							}
						}
					}
					else
					{
						MessageBox.Show("Please enter the date");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select the class");
					return;
				}
					
				}
	
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Search_ServerClick,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}	
			
		}
		
		/// <summary>
		/// this method not in use.
		/// </summary>
		private void BtnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				Response .Redirect("../PrintPreview/feesduerptPrint.aspx");
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				 
			}	
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel file.
		/// </summary>
		private void Exel_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:FeesDueReport.aspx,Method: btnExcel_Click, Fees Due Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:FeesDueReport.aspx,Method:btnExcel_Click Fees Due Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// Method for viewing the report in excel format. data fetch from feesdecision and also check from recuringrecipt table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				SqlDataReader SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\DueFeesReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				string strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
						if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";// add by vikas sharma date on 22.02.08
							SqlDtr=obj.GetRecordSet(strSelect);
						}
						else
						{
							if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
							{
								MessageBox.Show("Please select The Information ");
							}
							else
							{
								strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";  // add by vikas sharma date on 22.02.08
								SqlDtr=obj.GetRecordSet(strSelect);
							}
						}
					}
					else
					{
						MessageBox.Show("Please enter the date");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select the class");
					return;
				}
	
				int i=1;
				int c=1,d=5;

				string des="+----+----------+-------------------------+-----+-------+----------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("   DUE FEES REPORT From "+ Txtfromdate.Text.Trim() + " To "+Txttodate.Text.Trim(),des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine();
				sw.WriteLine("S.No\tStudent ID\tStudent Name             \tClass\tSection\tAmount Due");
				int x=60, y=1;
				double ptotal=0;
				while(SqlDtr.Read())
				{
					student_id=SqlDtr.GetValue(0).ToString().Trim();
					feesdecisionmonthly(student_id);
					sw.WriteLine(i.ToString()+"\t"+student_id.ToString()+"\t"+
					sname.ToString()+"\t"+
					classid.ToString()+"\t"+section.ToString()+"\t"+
					total.ToString()
					);
					d++;
					ptotal+=total;
					if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
					{
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						sw.WriteLine("PageTotal\t\t\t\t"+ptotal.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						c++;
						x=60;
						sw.WriteLine();
						sw.WriteLine("\t\t\t\t\tPage No:"+c.ToString());
						sw.WriteLine("S.No\tStudent ID\tStudent Name             \tClass\tSection\tAmount Due");
						d+=3;
						ptotal=0;
						y++;
					}
					else if(d%59==1&&c==1)
					{
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						sw.WriteLine("PageTotal\t\t\t\t\t"+ptotal.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");	
						c++;
						sw.WriteLine("\t\t\t\t\tPage No:"+c.ToString());
						sw.WriteLine("S.No\tStudent ID\tStudent Name             \tClass\tSection\tAmount Due");
						d+=3;
						ptotal=0;
					}
					i++;
				}
				SqlDtr.Close();
				sw.WriteLine("PageTotal\t\t\t\t\t"+ptotal.ToString());
				sw.WriteLine("Grand Total\t\t\t\t\t"+ptotal.ToString());
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  ConvertIntoExcel,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Method for viewing the report in text format. data fetch from feesdecision and also check from recuringrecipt table.
		/// </summary>
		private void print_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory ;
				string info = "";
				home_drive = home_drive.Substring (0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DueFeesReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				gtotal=0;
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0)
				{
					if(!Txtfromdate.Text.Equals("")&&!Txttodate.Text.Equals(""))
					{
					  if(DropClass.SelectedItem.Value.ToString().Equals("All"))
						{
							strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";// add by vikas sharma date on 22.02.08
							SqlDtr=obj.GetRecordSet(strSelect);
						}
						else
						{
							if(DropClass.SelectedIndex==0 && DropSec.SelectedIndex ==0)
							{
								MessageBox.Show("Please select The Information ");
							}
							else
							{
								strSelect = "select * from student_record where student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(Txttodate.Text.ToString())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSec.SelectedItem .Value .ToString()+"' and student_admissiondate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text.ToString())+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,student_fname";  // add by vikas sharma date on 22.02.08
								SqlDtr=obj.GetRecordSet(strSelect);
							}
						}
					}
					else
					{
						MessageBox.Show("Please enter the date");
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select the class");
					return;
				}

				int n=12*6;
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)n);				
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)6);
				sw.Write((char)27);
				sw.Write((char)15);
				int i=1;
				int c=1,d=5;
				string des="+----+----------+-------------------------+-----+-------+----------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr(" DUE FEES REPORT From "+ Txtfromdate.Text.Trim() + " To "+Txttodate.Text.Trim(),des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------------",des.Length));
				string info5="{0,-20:S} {1,40:S}";
				sw.WriteLine(info5,"","Page No:"+c.ToString());
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				sw.WriteLine("+S.No|Student ID|Student Name             |Class|Section|Amount Due|");
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				info =" {0,-4:S} {1,-10:S} {2,-25:S} {3,5:S} {4,-7:S} {5,10:S} ";
				int x=60, y=1;
				double ptotal=0;
				while(SqlDtr.Read())
				{
					student_id=SqlDtr.GetValue(0).ToString().Trim();
					feesdecisionmonthly(student_id);
					sw.WriteLine(info,i.ToString(),student_id.ToString(),
					sname.ToString(),
					GenUtil.TrimLength(classid.ToString(),4),section.ToString(),
					total.ToString()
					);
					d++;
					ptotal+=total;
					if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
					{
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						string info3="Page Total                                              {0,10:S} ";
						sw.WriteLine(info3,ptotal.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						c++;
						x=60;
						sw.WriteLine();
						sw.WriteLine(info5,"","Page No:"+c.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						sw.WriteLine("+S.No|Student ID|Student Name             |Class|Section|Amount Due|");
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						d+=3;
						ptotal=0;
						y++;
						
					}
					else if(d%59==1&&c==1)
					{
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						string info3="Page Total                                               {0,10:S} ";
						sw.WriteLine(info3,ptotal.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");	
						c++;
						sw.WriteLine(info5,"","Page No:"+c.ToString());
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						sw.WriteLine("+S.No|Student ID|Student Name             |Class|Section|Amount Due|");
						sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
						d+=3;
						ptotal=0;
					}
					i++;
				}
				SqlDtr.Close();
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				string info4="Page Total                                               {0,10:S} ";
				sw.WriteLine(info4,gtotal.ToString());
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				string info1="Grand Total                                              {0,10:S}";
				sw.WriteLine(info1,gtotal.ToString());
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				
				sw.Close(); 
				Print();
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  BtnPrint_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method use to create connection between remote device.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DueFeesReport.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DueFeesReport.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Print_Click, Fees Due Report Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Print_Click, Exception"+ ane.Message+",  Fees Due Report Printed, Userid :  "+ pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Print_Click, Exception"+ se.Message+",  Fees Due Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{	
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Print_Click, Exception"+ es.Message+",  Fees Due Report Printed, Userid :  "+ pass);
				}
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesDueReport.aspx,Method  Print_Click,Esception:"+ex.Message +", Fees Decision Report Printed, Userid :  "+ pass);
			}
		}
			
		/// <summary>
		/// this Method use to take data from feesdecision table. 
		/// </summary>
		public void feesdecisionmonthly(string student_id1)
		{
			rank="";
			category="";
			section="";
			classid="";
			sname="";
			stream="";
			tutionfee=0;
			computerfee=0;
			housefee=0;
			gamefee=0;
			sciencefee=0;
			annualfee=0;
			registraionfee=0;
			latefee=0;
			admissionfee=0;
			transportfee=0;
			developmentfee=0;
			dairyfee=0;
			security=0;
			total=0;
			Caution=0;
			TempCaution=0;
			double TempYearly=0;
			double tempcomp=0;
			string computer="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string str="",str1="";
				string str2="";
				if(!student_id.Equals("0"))
					{
						str2="select student_fname,seq_student_id,student_class,rank,scategory,student_stream,computer from student_record where student_id='"+student_id1+"'";
						SqlDtr1=obj.GetRecordSet(str2);
						if(SqlDtr1.Read())
							{
								sname=SqlDtr1.GetString(0).ToString();
								section=SqlDtr1.GetString(1).ToString();
								classid=SqlDtr1.GetString(2).ToString();
								rank=SqlDtr1.GetString(3).ToString();
								category=SqlDtr1.GetString(4).ToString();
								stream=SqlDtr1.GetString(5).ToString();
								computer=SqlDtr1.GetString(6).ToString();
							}
					SqlDtr1.Close();
					string startfrom=""; 
					string endto="";
					int count=0;
					int Flag=0;
					if(!rank.Equals("")&&!category.Equals(""))
					{
						count=0;
						str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
						startfrom=GenUtil.ConvertMonthName(Txtfromdate.Text);
						startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
						endto=GenUtil.ConvertMonthName(Txttodate.Text);
    					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
						System.TimeSpan diff=ToMMddYYYY(Txttodate.Text).Subtract(ToMMddYYYY(Txtfromdate.Text));
						int idays=diff.Days;
						count=(idays+1)/30;
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{
						 if(startfrom.Equals("April"))
							{
								str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
								rdr=obj1.GetRecordSet(str);
								if(rdr.Read())
								{
									annualfee=double.Parse(rdr["annual_fee"].ToString());
									developmentfee=double.Parse(rdr["envp_fee"].ToString());
									dairyfee=double.Parse(rdr["diary_fee"].ToString());
									TempYearly=double.Parse(rdr["Total"].ToString());
									Caution+=double.Parse(rdr["Total"].ToString());
									gannualfee+=annualfee;
									gdevelopmentfee+=developmentfee;
									gdairyfee+=dairyfee;
									Flag++;
								}
								else
								{
									MessageBox.Show("Please enter the yearly fees in Fees Decision table");
									return;
								}
								rdr.Close();
							}
							else
							{
								annualfee=0;
								developmentfee=0;
								dairyfee=0;
								TempYearly=0;
								Caution+=0;
								Flag++;
							}

							if(count>=0)
							{
								if(classid.Trim().Equals("XI") || classid.Trim().Equals("XII"))     //Add by vikas sharma date on 8.1.08
								{
									if(computer.Trim().Equals("No"))
									{
										computerfee=0;
										tempcomp=count*double.Parse(SqlDtr["computer_fee"].ToString());
									}
									else 
									{
										computerfee=count*double.Parse(SqlDtr["computer_fee"].ToString());
										tempcomp=0;
									}
								}
								else
								{
									computerfee=count*double.Parse(SqlDtr["computer_fee"].ToString());
									tempcomp=0;
								}
								tutionfee=count*double.Parse(SqlDtr["tution_fee"].ToString());
								sciencefee=count*double.Parse(SqlDtr["science_fee"].ToString());
							if(!startfrom.Equals("")&&!endto.Equals(""))
								{
								  if(startfrom.Equals("April") &&classid.Equals("XI"))
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=0;
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
								else if(startfrom.Equals("April"))
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=(count-1)*double.Parse(rdr["trfee"].ToString());
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
									else
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(Txtfromdate.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(Txttodate.Text)+"'";
										rdr=obj1.GetRecordSet(str1);
										if(rdr.Read())
										{
											transportfee=count*double.Parse(rdr["trfee"].ToString());
										}
										else
										{
											transportfee=0;
										}
										rdr.Close();
									}
								}
								else
								{
									transportfee=0;
								}
								gamefee=count*double.Parse(SqlDtr["games_fee"].ToString());
								housefee=count*double.Parse(SqlDtr["hostel_fee"].ToString());
								total=count*double.Parse(SqlDtr["Total"].ToString());
								
								if(computer.Trim().Equals("No"))
								{
									total=total-tempcomp;
								}

								total=total+transportfee;
								gtutionfee+=tutionfee;
								gcomputerfee+=computerfee;
								gsciencefee+=sciencefee;
								gtransportfee+=transportfee;
								ggamefee+=gamefee;
								ghousefee+=housefee;
								Caution+=total;
								total=Caution+latefee;
								gtotal+=total;					
								
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : FeesDueReport.aspx,Method  feesdecisionmonthly,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}
		}
	}
}