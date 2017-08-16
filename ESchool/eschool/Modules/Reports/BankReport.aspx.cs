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
	/// Summary description for BankReport.
	/// </summary>
	public class BankReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.ValidationSummary vsPaySlip;
		protected System.Web.UI.WebControls.TextBox txtFrom;
		protected System.Web.UI.WebControls.TextBox txtTo;
		protected System.Web.UI.WebControls.DropDownList DropBank;
		protected System.Web.UI.WebControls.Button Exel;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
	    public int flage=0; 
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
				CreateLogFiles.ErrorLog (" Form : Bank_Report.aspx.cs, Method: Page_load, User: " + pass );
			}
			catch(Exception ex)
			{
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : Bank_Report.aspx.cs, Method: Page_load, Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				//string pass;
				//pass=(Session["password"].ToString ());
				if(!Page.IsPostBack)
				{
					txtFrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					txtTo.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					InventoryClass obj =new InventoryClass();
					SqlDataReader rdr;
					string str="select distinct chbank from recuringreceipt where chbank!=''";
					rdr=obj.GetRecordSet(str);
					DropBank.Items.Clear();
					DropBank.Items.Add("All");
					while(rdr.Read())
					{
						DropBank.Items.Add(rdr.GetValue(0).ToString());
					}
					rdr.Close();
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="3";
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
                 CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
		/// When flage is 1 then HTML Part Execute 
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			flage=1;
		}

		/// <summary>
		/// this method use to create report in to text format data fetch from RecuringReceipt table.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			flage=1;
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BankReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr,rdr1;
				string str="";
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
				sw.Write((char)27);
				sw.Write((char)107); 
				sw.Write((char)1);				
				string des="+------+------------+----------+-------------+-----------+---------+";
				info = " {0,-6:F} {1,-12:S} {2,-10:S} {3,-13:S} {4,-11:S} {5,9:S}";
				string info1 = " {0,-45}{1,-31:S}";
				string info5="{0,-24:S} {1,40:S}";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));                            //25.10.07
				sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        //25.10.07
				sw.WriteLine(GenUtil.GetCenterAddr("BANK REPORT From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); //25.10.07
				sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        //25.10.07
				sw.WriteLine(info5,"","Page No:"+c.ToString());
				sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
				sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
				sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
				double gamount=0,tamount=0;
				int x=60, y=1;
				double ptotal=0;
				if(DropBank.SelectedIndex==0)
				{
					SqlConnection cn;
					SqlCommand cmd;
					cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					cn.Open();
					cmd=new SqlCommand("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null",cn);
					rdr1=cmd.ExecuteReader();
					if(rdr1.HasRows)
					{
						while(rdr1.Read())
						{
							str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+rdr1["chbank"].ToString()+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
							rdr = obj.GetRecordSet(str);
							gamount=0;
							if(rdr.HasRows)
							{
								string bank=rdr1["chbank"].ToString().Trim();
								if(bank.ToUpper()!="SELECT")
									bank=bank;
								//bank=bank.Substring(0,bank.IndexOf(":"));
								sw.WriteLine("Name Of Bank : "+bank);
								string s="Name Of Bank : "+rdr1["chbank"].ToString().Trim();
								for(int j=0;j<s.Length;j++)
									sw.Write("-");
								sw.WriteLine("");
								d+=2;
								while(rdr.Read())
								{	
									gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
									d++;
									ptotal+=double.Parse(rdr["fees_amount"].ToString());
									if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
									{
										sw.WriteLine (info,i.ToString(),
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString())),
											rdr["Recuringid"].ToString(),
											rdr["draftno"].ToString(),
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString())),
											rdr["fees_amount"].ToString()
											);
										if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											x=60;
											//	sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
											sw.WriteLine();
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
											y++;
											
										}
											
										else if(d%59==1&&c==1)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
										}
									}
									else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
									{
										sw.WriteLine (info,i.ToString(),
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString())),
											rdr["Recuringid"].ToString(),
											rdr["chno"].ToString(),
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString())),
											rdr["fees_amount"].ToString()
											);
										if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											x=60;
											//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
											sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length));
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine();//
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
											y++;
											
										}
											
										else if(d%59==1&&c==1)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
										}
									}
									i++;
								}
								sw.WriteLine(info1,"","----------------------");
								sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
								sw.WriteLine(info1,"","----------------------");
								d+=3;
							}
							tamount=tamount+gamount;
							rdr.Close();
						}
					}
				}
				else
				{
					str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+DropBank.SelectedItem.Text+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
					rdr = obj.GetRecordSet(str);
					gamount=0;
					if(rdr.HasRows)
					{
						string bank=DropBank.SelectedItem.Text.Trim();
						if(bank.ToUpper()!="SELECT")
							bank=bank;
						//bank=bank.Substring(0,bank.IndexOf(":"));
						string s="Name Of Bank : "+bank;
						sw.WriteLine(s);
						for(int j=0;j<s.Length;j++)
							sw.Write("-");
						sw.WriteLine("");
						d+=2;
						while(rdr.Read())
						{	
							gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
							d++;
							ptotal+=double.Parse(rdr["fees_amount"].ToString());
							if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
							{
								sw.WriteLine (info,i.ToString(),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString())),
									rdr["Recuringid"].ToString(),
									rdr["draftno"].ToString(),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString())),
									rdr["fees_amount"].ToString()
									);

								if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									x=60;
									//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                            
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length));
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine();//
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
									y++;
								}
									
								else if(d%59==1&&c==1)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                            
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
								}
							}
							else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
							{
								sw.WriteLine (info,i.ToString(),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString())),
									rdr["Recuringid"].ToString(),
									rdr["chno"].ToString(),
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString())),
									rdr["fees_amount"].ToString()
									);

								if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									x=60;
									sw.WriteLine();
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
									y++;
								}
									
								else if(d%59==1&&c==1)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("|SR.No.|Receive Date|Receipt No|  Cheque No  |Cheque Date| Amount  |");
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
								}
							}
							i++;
						}
						
						
						sw.WriteLine(info1,"","---------------------");
						sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
						sw.WriteLine(info1,"","---------------------");
						d+=3;
					}
					rdr.Close();
					tamount=tamount+gamount;
				}
					
				string info4="Page Total                                               {0,10:S} ";
				string info9="Gross Total                                              {0,10:S} ";
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				sw.WriteLine(info4,ptotal.ToString());
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
				//sw.WriteLine (info,"","","","","",tamount.ToString());
				sw.WriteLine(info9,tamount.ToString());
				//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
				sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				sw.Close();
				Print();
				flage=1;
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Button1_Click, BankReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}
		
		/// <summary>
		/// this method use to create report in to excel format data fetch from Recuringreceipt table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{ 
				int i=1;
				SqlDataReader rdr1,rdr;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\BankReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				string str="";
				string des="+------+------------+----------+-------------+-----------+---------+";
				//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("BANK REPORT From "+txtFrom.Text+" To "+txtTo.Text,des.Length));
				//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));
				sw.WriteLine();
				string info1 = " {0,-45}{1,-31:S}";
				string info = " {0,-6:F} {1,-12:S} {2,-10:S} {3,-13:S} {4,-11:S} {5,9:S}";
				string info5="{0,-24:S} {1,40:S}";
		 		
				sw.WriteLine(" SR.No.\tReceive Date\tReceipt No\tCheque No\tCheque Date\tAmount ");
				int c=1,d=5;
				double gamount=0,tamount=0;
				int x=60, y=1;
				double ptotal=0;
				if(DropBank.SelectedIndex==0)
				{
					SqlConnection cn;
					SqlCommand cmd;
					cn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					cn.Open();
					cmd=new SqlCommand("select distinct chbank from recuringreceipt where chbank !='' and  chbank is not null",cn);
					rdr1=cmd.ExecuteReader();
					
					if(rdr1.HasRows)
					{
						while(rdr1.Read())
						{
							str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+rdr1["chbank"].ToString()+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
							rdr = obj.GetRecordSet(str);
							gamount=0;
							if(rdr.HasRows)
							{
								string bank=rdr1["chbank"].ToString().Trim();
								if(bank.ToUpper()!="SELECT")
									bank=bank;
								//bank=bank.Substring(0,bank.IndexOf(":"));
								sw.WriteLine("Name Of Bank : "+bank);
								string s="Name Of Bank : "+rdr1["chbank"].ToString().Trim();
								/*for(int j=0;j<s.Length;j++)
									sw.Write("-");
								sw.WriteLine("");*/
								d+=2;
								while(rdr.Read())
								{	
									gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
									
									d++;
									ptotal+=double.Parse(rdr["fees_amount"].ToString());
									if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
									{
										sw.WriteLine (i.ToString()+"\t"+
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString()))+"\t"+
											rdr["Recuringid"].ToString()+"\t"+
											rdr["chno"].ToString()+"\t"+
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))+"\t"+
											rdr["fees_amount"].ToString()
									);
									
										if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											//sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("\t\t\t"+ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											x=60;
											//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
											//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));      
											//sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
											sw.WriteLine(GenUtil.GetCenterAddr("BANK REPORT From "+txtFrom.Text+" To "+txtTo.Text,des.Length));
											//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
											sw.WriteLine();
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
											y++;
										}
											
										else if(d%59==1&&c==1)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											//sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("\t\t\t"+ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
										}
									}
									else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
									{
										sw.WriteLine (i.ToString()+"\t"+
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString()))+"\t"+
											rdr["Recuringid"].ToString()+"\t"+
											rdr["chno"].ToString()+"\t"+
											GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))+"\t"+
											rdr["fees_amount"].ToString()
											);
										
										if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											x=60;
											//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
											//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
											//sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
											sw.WriteLine(GenUtil.GetCenterAddr("BANK REPORT From "+txtFrom.Text+" To "+txtTo.Text,des.Length));
											//sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
											sw.WriteLine();
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
											y++;
										}
										else if(d%59==1&&c==1)
										{
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											string info3="Page Total                                               {0,10:S} ";
											sw.WriteLine(info3,ptotal.ToString());
											sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											c++;
											//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                          
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
											sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
											sw.WriteLine(info5,"","Page No:"+c.ToString());
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
											//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
											d+=3;
											ptotal=0;
										}
									}
									i++;
								}
								sw.WriteLine(info1,"","----------------------");
								//sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
								sw.WriteLine ("\t\t\t\t"+"Bank Total:"+"\t"+gamount.ToString());
								
								sw.WriteLine(info1,"","----------------------");
								d+=3;
							}
							tamount=tamount+gamount;
							rdr.Close();
							
						}
					}
				}
				else
				{
					str="select recuringid,feesubdt,regid,chno,draftno,chdate,sum(fees_amount) fees_amount from recuringreceipt where feesubdt>='"+GenUtil.str2MMDDYYYY(txtFrom.Text)+"' and feesubdt<='"+GenUtil.str2MMDDYYYY(txtTo.Text)+"' and chbank='"+DropBank.SelectedItem.Text+"' group by recuringid,feesubdt,regid,chno,draftno,chdate";
					rdr = obj.GetRecordSet(str);
					gamount=0;
					if(rdr.HasRows)
					{
						string bank=DropBank.SelectedItem.Text.Trim();
						if(bank.ToUpper()!="SELECT")
							bank=bank;
						//bank=bank.Substring(0,bank.IndexOf(":"));
						string s="Name Of Bank : "+bank;
						sw.WriteLine(s);
						for(int j=0;j<s.Length;j++)
							sw.Write("-");
						sw.WriteLine("");
						d+=2;
						while(rdr.Read())
						{	
							gamount=gamount+double.Parse(rdr["fees_amount"].ToString());
							
							d++;
							ptotal+=double.Parse(rdr["fees_amount"].ToString());
							if(rdr["draftno"].ToString()!=""&&rdr["draftno"].ToString()!=null)
							{
								sw.WriteLine (i.ToString()+"\t"+
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString()))+"\t"+
									rdr["Recuringid"].ToString()+"\t"+
									rdr["chno"].ToString()+"\t"+
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))+"\t"+
									rdr["fees_amount"].ToString()
									);
								if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									//sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("\t\t\t"+ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									x=60;
									//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                         
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));        
									sw.WriteLine();//
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
									y++;
									
								}
									
								else if(d%59==1&&c==1)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									//sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("\t\t\t"+ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									//sw.WriteLine(GenUtil.GetCenterAddr("NO.1 AIR FORCE SCHOOL",des.Length));                           
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(GenUtil.GetCenterAddr("Bank Report From "+txtFrom.Text+" To "+txtTo.Text,des.Length)); 
									sw.WriteLine(GenUtil.GetCenterAddr("-----------------------------------------",des.Length));       
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
								}
							}
							else if(rdr["chno"].ToString()!=""&&rdr["chno"].ToString()!=null)
							{
								sw.WriteLine (i.ToString()+"\t"+
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["Feesubdt"].ToString()))+"\t"+
									rdr["Recuringid"].ToString()+"\t"+
									rdr["chno"].ToString()+"\t"+
									GenUtil.str2DDMMYYYY(GenUtil.trimDate(rdr["chdate"].ToString()))+"\t"+
									rdr["fees_amount"].ToString()
									);
								if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									//sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("\t\t\t"+ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									x=60;
									sw.WriteLine();
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
									y++;
								}
								else if(d%59==1&&c==1)
								{
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									string info3="Page Total                                               {0,10:S} ";
									//sw.WriteLine(info3,ptotal.ToString());
									sw.WriteLine("\t\t\t"+ptotal.ToString());
									sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									c++;
									sw.WriteLine(info5,"","Page No:"+c.ToString());
									
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									sw.WriteLine("SR.No.\tReceive Date\tReceipt No\t  Cheque No  \tCheque Date\t Amount ");
									//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
									d+=3;
									ptotal=0;
								}
							}
							i++;
						}
						sw.WriteLine(info1,"","---------------------");
						//sw.WriteLine (info,"","","","","Bank Total:",gamount.ToString());
						sw.WriteLine ("\t\t\t\t"+"Bank Total:"+"\t"+gamount.ToString());
						sw.WriteLine(info1,"","---------------------");
						d+=3;
					}
					rdr.Close();
					tamount=tamount+gamount;
				}
				string info4="Page Total                                               {0,10:S} ";
				//sw.WriteLine("+----+----------+-------------------------+-----+-------+----------+");
				//sw.WriteLine(info4,ptotal.ToString());
				sw.WriteLine("\t\t\t"+ptotal.ToString());

				//sw.WriteLine (info,"","","","Gross Total :","",tamount.ToString());
				sw.WriteLine ("\t\t\t\t"+"Gross Total :\t"+tamount.ToString());
				//sw.WriteLine("+------+------------+----------+-------------+-----------+---------+");
				sw.Close();
				flage=1;
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Button1_Click, BankReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BankReport.txt<EOF>");
					///													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\BankReport.txt
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method :  Print(),  BankReport Printed , Userid :  "+ pass   );							 
			                
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :BankReport.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this use to call ConvertIntoExcel() function.
		/// </summary>
		private void Exel_Click(object sender, System.EventArgs e)
		{
			flage=1;
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method: btnExcel_Click, Bank Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:BankReport.aspx,Method:btnExcel_Click   Bank Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
