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
using DBOperations;
# endregion

namespace eschool.Reports
{
	/// <summary>
	/// Summary description for CategoryRankWise.
	/// </summary>
	public class CategoryRankWise : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tempTotal4;
		protected System.Web.UI.WebControls.Button btnexcel;
		DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
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
				pass=(Session["password"].ToString());
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form: Strength_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			if(!Page.IsPostBack)
			{
				#region Check Privileges
				int i;
				string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
				string Module="11";
				string SubModule="28";
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
					///CreateLogFiles.ErrorLog("Form:VehicleLogReport.aspx,Method:Print"+uid);
					Console.WriteLine("Socket connected to {0}",
					sender1.RemoteEndPoint.ToString());
					/// Encode the data string into a byte array.
					string home_drive = Environment.SystemDirectory;
					home_drive = home_drive.Substring(0,2);
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentStrengthReport1.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form : CategoryRankWise.aspx,Method  Print,  Exception: "+ane.Message+" , Userid :  "+ pass   );
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form : CategoryRankWise.aspx,Method  Print,  Exception: "+se.Message+" , Userid :  "+ pass   );
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
				}		
			
			} 
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : CategoryRankWise.aspx,Method  Print,  Exception: "+ex.Message+" , Userid :  "+ pass   );			
			}
		}

		double gcomputer,gtransport,gTotal;
		string s1,s2,s4,s5,s6,s7,s8;
		string str;
		string str1;
		double tt,Tot,Total,gt;
		/// <summary>
		/// This Method use to create report in  text format.in this Report data fetch from Student_Record. and also check this student belong in to tc1 table or stuck_off table.
		/// if it belong then in this report not show these student. in this methos also save information about transport and computer.
		/// </summary>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				DBUtil dbobj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
				InventoryClass obj=new InventoryClass();
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\StudentStrengthReport1.txt";
				StreamWriter sw = new StreamWriter(path);
				SqlDataReader  rdr=null,rdr1=null,rdr12=null,rdr3=null,rdr4=null,rdr5=null,rdrcat=null,rdr11=null;
				string strr="select distinct catname from category";
				rdrcat = obj.GetRecordSet(strr);
				string catname="";
				while(rdrcat.Read())
				{
					catname+=","+rdrcat.GetValue(0).ToString().Trim();
				}
				rdrcat.Close();
				string[] cat=catname.Split(new char[] {','},catname.Length);
				string[] catgory=catname.Split(new char[] {','},catname.Length);
				string Header="|SNO  |CLASS|SEC ";
				string desdes="+-----+-----+----";
				string des  = "~~~~~~~~~~~~~~~~~";
				int a=cat.Length;
				int ii;
				int j;
				ArrayList arrLen=new ArrayList();
				for(ii=1;ii<cat.Length;ii++)
				{	
					desdes+="+";
					des+="~";
					if(catgory[ii].Length<=3)
					{
						Header+="|"+cat[ii].ToString().ToUpper().Trim()+" ";
						for(j=0;j<catgory[ii].Length+1;j++)
						{
							desdes+="-";
							des+="~";
						}
					}
					else
					{
						Header+="|"+cat[ii].ToString().ToUpper().Trim();
						for(j=0;j<catgory[ii].Length;j++)
						{
							desdes+="-";
							des+="~";
						}
					}
					arrLen.Add(j.ToString());
				}
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)0);
				sw.Write((char)12);
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)5);
				sw.Write((char)27);
				sw.Write((char)15);
				desdes+="+";
				des+="~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 AIR FORCE SCHOOL",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("STRENGTH OF VARIOUS CLASSES CATEGORY WISE ON "+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year,des.Length));
				sw.WriteLine(des);
				sw.WriteLine(Header+"|TOTAL |G.T.|TRANSPORT  |T.T |COMPUTER |");
				sw.WriteLine(des);
				str="";
				str="select class_name from class";
				rdr = obj.GetRecordSet(str);
				int i=0;
				int l=0;
				ArrayList arr=null;
				while(rdr.Read())
				{
					tt=0;Tot=0;
					arr=new ArrayList();
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						string str1="";
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("|"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						//sw.Write("|"+s1);
						sw.Write("|"+GenUtil.TrimLength(s1,5));
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("|"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("|"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							sw.WriteLine(des);
						}
					}
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
							
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("|"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("|"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("|"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							sw.WriteLine(des);
						}
					}
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and routeno<> 0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						sw.Write("|"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("|"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("|"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							sw.WriteLine(des);
						}
					}
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						sw.Write("|"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("|"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("|"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							sw.WriteLine(des);
						}		
					}
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and scategory='"+rdr3.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							        
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("|"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("|"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("|"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("|");
						sw.WriteLine();
						sw.WriteLine(des);
					}
					
				}

				try
				{
					DBUtil dbobjj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
					InventoryClass obj1=new InventoryClass();
					sw.Write("|     Total      |");
					SqlDataReader rdr14=null;
					dbobj.SelectQuery("select distinct catname from category",ref rdr14);
					int n=0;
					
					while(rdr14.Read())
					{
						dbobj.SelectQuery("select count(*) from student_record where scategory='"+rdr14.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr);
						if(rdr.Read())
						{
							sw.Write(rdr.GetValue(0).ToString());
							for(int k=rdr.GetValue(0).ToString().Length;k<int.Parse(arrLen[n].ToString());k++)
							{
								sw.Write(" ");
							}
							sw.Write("|");
							n++;
						}
					}
					sw.Write(gTotal);
					for(int k=gTotal.ToString().Length;k<6;k++)
					{
						sw.Write(" ");
					}
					sw.Write("|"+gTotal);
					for(int k=gTotal.ToString().Length;k<4;k++)
					{
						sw.Write(" ");
					}
					sw.Write("|"+gtransport);
					for(int k=gtransport.ToString().Length;k<11;k++)
					{
						sw.Write(" ");
					}
					sw.Write("|"+gtransport);
					for(int k=gtransport.ToString().Length;k<4;k++)
					{
						sw.Write(" ");
					}
					sw.Write("|"+gcomputer);
					for(int k=gcomputer.ToString().Length;k<9;k++)
					{
						sw.Write(" ");
					}
					sw.Write("|");
					sw.WriteLine();
					
					sw.WriteLine(des);
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: CategoryRankWise.aspx, Method: ASP/HTML CODING. Exception: " + ex.Message + " User: " + pass );
				}
				sw.Close();
				Print();
				CreateLogFiles.ErrorLog(" Form : CategoryRankWise.aspx,Method  Button1_Click, Student Parent Information View , Userid :  "+ pass);
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				
			}
		}

		/// <summary>
		/// this method call ConvertIntoExcel() function.
		/// </summary>
		private void btnexcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method: btnExcel_Click, Advance Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:AdvanceFeesReport.aspx,Method:btnExcel_Click   Advance Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}

		/// <summary>
		/// This Method use to create report in  excel format.in this Report data fetch from Student_Record. and also check this student belong in to tc1 table or stuck_off table.
		/// if it belong then in this report not show these student. in this methos also save information about transport and computer.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				int i=0;
				SqlDataReader SqlDtr=null;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\StudentStrengthReport1.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				SqlDataReader  rdr=null,rdr1=null,rdr12=null,rdr3=null,rdr4=null,rdr5=null,rdrcat=null,rdr11=null;
				string strr="select distinct catname from category";
				rdrcat = obj.GetRecordSet(strr);
				string catname="";
				while(rdrcat.Read())
				{
					catname+=","+rdrcat.GetValue(0).ToString().Trim();
				}
				rdrcat.Close();
				string[] cat=catname.Split(new char[] {','},catname.Length);
				string[] catgory=catname.Split(new char[] {','},catname.Length);
				string Header="\tSNO\tCLASS\tSEC ";
				int a=cat.Length;
				int ii;
				int j;
				ArrayList arrLen=new ArrayList();
				for(ii=1;ii<cat.Length;ii++)
				{	
					
					if(catgory[ii].Length<=3)
					{
						Header+="\t"+cat[ii].ToString().ToUpper().Trim()+" ";
						for(j=0;j<catgory[ii].Length+1;j++)
						{
							
						}
					}
					else
					{
						Header+="\t"+cat[ii].ToString().ToUpper().Trim();
						for(j=0;j<catgory[ii].Length;j++)
						{
							
						}
					}
					arrLen.Add(j.ToString());
				}
				
				//sw.WriteLine("\t\t\tNo.1 AIR FORCE SCHOOL");
				sw.WriteLine("STRENGTH OF VARIOUS CLASSES CATEGORY WISE ON "+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
				sw.WriteLine(Header+"\tTOTAL\tG.T.\tTRANSPORT\tT.T\tCOMPUTER");
				str="";
				str="select class_name from class";
				rdr = obj.GetRecordSet(str);
				ArrayList arr=null;
				while(rdr.Read())
				{
					tt=0;Tot=0;
					arr=new ArrayList();
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='A' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
							
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							s7=tt.ToString();
						}
						else
						{
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						string str1="";
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						sw.Write("\t"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("\t"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("\t"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='B' or seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
						}
					}

					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='B' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								arr.Add("0");
							}
							
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							
							s5=Tot.ToString();
						}
						else
						{
							
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
							s7=tt.ToString();
						}
						else
						{
							
							s7="";
							
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("\t"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("\t"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("\t"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='C' or seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
						
						}
					}



					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and routeno<> 0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					
					if(rdr1.Read())
					{
						arr=new ArrayList();
						
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='C' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
								    
							}
							else
							{
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
							s7=tt.ToString();
						}
						else
						{
							
							s7="";
							
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("\t"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("\t"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("\t"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and (seq_student_id='D' or seq_student_id='E')",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
						}
					}

					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and computer='Yes'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='D' and scategory='"+rdr3.GetValue(0).ToString()+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							}
							else
							{
								
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.Read()==false)
						{
							s5=Tot.ToString();
						}
						else
						{
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
							s7=tt.ToString();
						}
						else
						{
							
							s7="";
							
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("\t"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("\t"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("\t"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t");
						sw.WriteLine();
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
						}		
					}
					s1="";s2="";s4="";s5="";s6="";s7="";s8="";
					dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E'",ref rdr1);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and routeno<>0 and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr11);
					dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and computer='Yes' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr12);
					if(rdr1.Read())
					{
						arr=new ArrayList();
						s1=rdr1["Student_Class"].ToString();
						s2=rdr1["seq_student_id"].ToString();
						Total=0;
						gt=0;
						dbobj.SelectQuery("select distinct catname from category",ref rdr3);
						while(rdr3.Read())
						{
							dbobj.SelectQuery("select count(*) from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='E' and scategory='"+rdr3.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr4);
							if(rdr4.Read())
							{
								arr.Add(rdr4.GetValue(0).ToString());
								if(rdr4.GetValue(0).ToString()!="")
									Total+=double.Parse(rdr4.GetValue(0).ToString());
							        
							}
							else
							{
								
								arr.Add("0");
							}
						}
						gt+=Total;
						s4=Total.ToString();
						Tot+=Total;
						gTotal+=Total;
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
						if(rdr5.Read()==false)
						{
							
							s5=Tot.ToString();
						}
						else
						{
							
							s5="";
						}
						if(rdr11.Read())
						{
							tt+=double.Parse(rdr11.GetValue(0).ToString());
							gtransport+=double.Parse(rdr11.GetValue(0).ToString());
							s6=rdr11.GetValue(0).ToString();
						}
						else
						{
							
							s6="0";
						}
						dbobj.SelectQuery("select student_class,seq_student_id from student_record where student_class='"+rdr["Class_Name"].ToString()+"' and seq_student_id='F'",ref rdr5);
						if(rdr5.HasRows==false)
						{
							
							s7=tt.ToString();
						}
						else
						{
							
							s7="";
						}
						if(rdr12.Read())
						{
							s8=rdr12.GetValue(0).ToString();
							gcomputer+=double.Parse(rdr12.GetValue(0).ToString());
						}
						else
						{
							s8="0";
						}
						
						for(int z=0;z<arr.Count;z++)
						{
							str1+=arr[z].ToString()+",";
						}
						str1=str1.Substring(0,str1.Length-1);
						
						sw.Write("\t"+System.Convert.ToString(++i));
						for(int k=i.ToString().Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s1);
						for(int k=s1.Length;k<5;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s2);
						for(int k=s2.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						for(int m=0;m<arr.Count;m++)
						{
							sw.Write("\t"+arr[m].ToString());
							for(int k=arr[m].ToString().Length;k<int.Parse(arrLen[m].ToString());k++)
							{
								sw.Write(" ");
							}
						}
						sw.Write("\t"+s4);
						for(int k=s4.Length;k<6;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s5);
						for(int k=s5.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s6);
						for(int k=s6.Length;k<11;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s7);
						for(int k=s7.Length;k<4;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t"+s8);
						for(int k=s8.Length;k<9;k++)
						{
							sw.Write(" ");
						}
						sw.Write("\t");
						sw.WriteLine();
						
					}
					
				}

				try
				{
					DBUtil dbobjj=new DBUtil(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"],true);
					InventoryClass obj1=new InventoryClass();
					sw.Write("\tTotal\t\t\t");
					SqlDataReader rdr14=null;
					dbobj.SelectQuery("select distinct catname from category",ref rdr14);
					int n=0;
					
					while(rdr14.Read())
					{
						
						
						dbobj.SelectQuery("select count(*) from student_record where scategory='"+rdr14.GetValue(0).ToString()+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off)",ref rdr);
						if(rdr.Read())
						{
							
							sw.Write(rdr.GetValue(0).ToString());
							for(int k=rdr.GetValue(0).ToString().Length;k<int.Parse(arrLen[n].ToString());k++)
							{
								sw.Write(" ");
							}
							sw.Write("\t");
							n++;
						}
					}
					sw.Write(gTotal);
					for(int k=gTotal.ToString().Length;k<6;k++)
					{
						sw.Write(" ");
					}
					sw.Write("\t"+gTotal);
					for(int k=gTotal.ToString().Length;k<4;k++)
					{
						sw.Write(" ");
					}
					sw.Write("\t"+gtransport);
					for(int k=gtransport.ToString().Length;k<11;k++)
					{
						sw.Write(" ");
					}
					sw.Write("\t"+gtransport);
					for(int k=gtransport.ToString().Length;k<4;k++)
					{
						sw.Write(" ");
					}
					sw.Write("\t"+gcomputer);
					for(int k=gcomputer.ToString().Length;k<9;k++)
					{
						sw.Write(" ");
					}
					sw.Write("\t");
					sw.WriteLine();
					
				}
				catch(Exception ex)
				{
					CreateLogFiles.ErrorLog ("Form: CategoryRankWise.aspx, Method: ASP/HTML CODING. Exception: " + ex.Message + " User: " + pass );
				}
				
				sw.Close();
				Print();
				CreateLogFiles.ErrorLog(" Form : CategoryRankWise.aspx,Method  Button1_Click, Student Parent Information View , Userid :  "+ pass);
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				
			}
		}
	}
}
