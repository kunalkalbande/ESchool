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
	/// Summary description for DailyFeeReport.
	/// </summary>
	public class DailyFeeReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDob;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid grdBank;
		protected System.Web.UI.WebControls.ValidationSummary vsPaySlip;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Button btnExcel;
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
			}
			catch(Exception ex)
			{
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				CreateLogFiles.ErrorLog (" Form : DailyFees_Report.aspx.cs, Method: Page_Load. Exception: " + ex.Message + " User: " + pass );
				return;
			}
			try
			{
				if(!Page.IsPostBack)
				{
					txtDob.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;

					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="5";
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
                CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// this method assign 1 value of flage then Html Part Execut.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			flage=1;
		}

		double Amount=0;
		/// <summary>
		/// this method get input as string and calculate Tatal Amount. and return.
		/// </summary>
		public string GetAmount(string str)
		{
			double total=0;
			total=double.Parse(str);
			Amount+=total;
			Cache["Amount"]=GenUtil.strNumericFormat(Amount.ToString());
			return str;
		}

		/// <summary>
		/// this methd use to create a report in text format. in this report data fetch from Recuringreceipt,Student_Record table.
		/// </summary>
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				double vptutionfee=0;
				double vpcomputerfee=0;
				double vphousefee=0;
				double vpgamefee=0;
				double vpsciencefee=0;
				double vpannualfee=0;
				double vpregistrationfee=0;
				double vplatefee=0;
				double vpadmissionfee=0;
				double vptransportfee=0;
				double vpdevelopmentfee=0;
				double vpdiaryfee=0;
				double vpsecurity=0;
				double vpCaution=0;
				double vptotal=0; 

				double ptutionfee=0;
				double pcomputerfee=0;
				double phousefee=0;
				double pgamefee=0;
				double psciencefee=0;
				double pannualfee=0;
				double pregistrationfee=0;
				double platefee=0;
				double padmissionfee=0;
				double ptransportfee=0;
				double pdevelopmentfee=0;
				double pdiaryfee=0;
				double psecurity=0;
				double pCaution=0;
				double ptotal=0;

				int i=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string info = "",str="";
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DailyFeesReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				if(txtDob.Text!="")
				{
					str = "	select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.seq_student_id,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Record sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.Student_ID UNION select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.student_stream,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Registration sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.RegID";
				}
				else
				{
					MessageBox.Show("Please select date");
					return;
				}
				rdr = obj.GetRecordSet(str);
				
				double gtutionfee=0,gcomputerfee=0,ghousefee=0,ggamefee=0,gsciencefee=0,gregistrationfee=0,glatefee=0,gadmissionfee=0,gtransportfee=0,gdevelopmentfee=0,gdiaryfee=0,gannualfee=0,gsecurity=0,gtotal=0;

				int n=12*6;
				sw.Write((char)27);
				sw.Write((char)67);
				sw.Write((char)n);				
				sw.Write((char)27);
				sw.Write((char)78);
				sw.Write((char)6);
				sw.Write((char)27);
				sw.Write((char)15);
				int c=1,d=5;
				int x=60,y=1;
				string des="+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+";
				sw.WriteLine(GenUtil.GetCenterAddr("------------------------------",des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("DAILY FEES REPORT for "+txtDob.Text,des.Length));
				sw.WriteLine(GenUtil.GetCenterAddr("------------------------------",des.Length));
				string info5="{0,-80:S} {1,40:S}";
				sw.WriteLine(info5,"","Page No:"+c.ToString());
				info = " {0,5:S} {1,6:S} {2,5:S} {3,-15:S} {4,5:S} {5,-2:S} {6,5:S} {7,5:S} {8,5:S} {9,4:S} {10,5:S} {11,5:S} {12,3:S} {13,5:S} {14,6:S} {15,4:S} {16,4:S} {17,4:S} {18,4:S} {19,7:S}";
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				sw.WriteLine("|S. N0|Rec ID|St.ID|Student Name   |Class|Sc|Tutio|Comp.|House|Game|Scien|Regis|Lat|Admis|Trans |Env |Diar|Annu|Secu| Total |");
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				//             12345 123456 12345 123456789012345 12345 1234 12345 12345 12345 1234 12345 12345 1234 12345 12345 12345 12345 12345 12345 123456
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{	
							/*sw.WriteLine(info,i.ToString(),
							rdr["RecuringID"].ToString(),
							rdr["student_id"].ToString(),
							GenUtil.TrimLength(rdr["Student_Fname"].ToString().Trim(),15),
							rdr["Student_Class"].ToString(),
                            GenUtil.TrimLength(rdr["Seq_Student_ID"].ToString(),2),
							rdr["tution_fee"].ToString(),
							rdr["computer_fee"].ToString(),
							rdr["hostel_fee"].ToString(),
							rdr["game_fee"].ToString(),
							rdr["science_fee"].ToString(),
							rdr["regfee"].ToString(),
							rdr["latefee"].ToString(),
							rdr["admission_fee"].ToString(),
							rdr["transport_fee"].ToString(),
							rdr["envp_fee"].ToString(),
							rdr["diary_fee"].ToString(),
							rdr["annual_fee"].ToString(),
							rdr["securityfee"].ToString(),
							rdr["Fees_Amount"].ToString());*/
							
							

						if(rdr["tution_fee"].ToString()!="")
						{
							gtutionfee+=double.Parse(rdr["tution_fee"].ToString());
							ptutionfee+=double.Parse(rdr["tution_fee"].ToString());
							vptutionfee=double.Parse(rdr["tution_fee"].ToString());
						}
						else
						{
							gtutionfee+=0;
							ptutionfee+=0;
							vptutionfee=0;
						}
						if(rdr["computer_fee"].ToString()!="")
						{

							gcomputerfee+=double.Parse(rdr["computer_fee"].ToString());
							pcomputerfee+=double.Parse(rdr["computer_fee"].ToString());
							vpcomputerfee=double.Parse(rdr["computer_fee"].ToString());
						}
						else
						{
							gcomputerfee+=0;
							pcomputerfee+=0;
							vpcomputerfee=0;
						}
						if(rdr["Hostel_fee"].ToString()!="")
						{
							ghousefee+=double.Parse(rdr["Hostel_fee"].ToString());
							phousefee+=double.Parse(rdr["Hostel_fee"].ToString());
							vphousefee=double.Parse(rdr["Hostel_fee"].ToString());
						}
						else
						{
							ghousefee+=0;
							phousefee+=0;
							vphousefee=0;
						}
						if(rdr["game_fee"].ToString()!="")
						{
							ggamefee+=double.Parse(rdr["Game_fee"].ToString());
							pgamefee+=double.Parse(rdr["Game_fee"].ToString());
							vpgamefee=double.Parse(rdr["Game_fee"].ToString());
						}
						else
						{
							ggamefee+=0;
							pgamefee+=0;
							vpgamefee=0;
						}
						if(rdr["science_fee"].ToString()!="")
						{
							gsciencefee+=double.Parse(rdr["Science_fee"].ToString());
							psciencefee+=double.Parse(rdr["Science_fee"].ToString());
							vpsciencefee=double.Parse(rdr["Science_fee"].ToString());
						}
						else
						{
							gsciencefee+=0;
							psciencefee+=0;
							vpsciencefee=0;
						}
						if(rdr["Regfee"].ToString()!="")
						{
							gregistrationfee+=double.Parse(rdr["RegFee"].ToString());
							pregistrationfee+=double.Parse(rdr["RegFee"].ToString());
							vpregistrationfee=double.Parse(rdr["RegFee"].ToString());
						}
						else
						{
							gregistrationfee+=0;
							pregistrationfee+=0;
							vpregistrationfee=0;
						}
						if(rdr["latefee"].ToString()!="")
						{
							glatefee+=double.Parse(rdr["LateFee"].ToString());
							platefee+=double.Parse(rdr["LateFee"].ToString());
							vplatefee=double.Parse(rdr["LateFee"].ToString());
						}
						else
						{
							glatefee+=0;
							platefee+=0;
							vplatefee=0;
						}
						if(rdr["admission_fee"].ToString()!="")
						{
							gadmissionfee+=double.Parse(rdr["admission_fee"].ToString());
							padmissionfee+=double.Parse(rdr["admission_fee"].ToString());
							vpadmissionfee=double.Parse(rdr["admission_fee"].ToString());
						}
						else
						{
							gadmissionfee+=0;
							padmissionfee+=0;
							vpadmissionfee=0;
						}
						if(rdr["transport_fee"].ToString()!="")
						{
							gtransportfee+=double.Parse(rdr["transport_fee"].ToString());
							ptransportfee+=double.Parse(rdr["transport_fee"].ToString());
							vptransportfee=double.Parse(rdr["transport_fee"].ToString());
						}
						else
						{
							gtransportfee+=0;
							ptransportfee+=0;
							vptransportfee=0;
						}
						if(rdr["envp_fee"].ToString()!="")
						{
							gdevelopmentfee+=double.Parse(rdr["Envp_fee"].ToString());
							pdevelopmentfee+=double.Parse(rdr["Envp_fee"].ToString());
							vpdevelopmentfee=double.Parse(rdr["Envp_fee"].ToString());
						}
						else
						{
							gdevelopmentfee+=0;
							pdevelopmentfee+=0;
							vpdevelopmentfee=0;
						}
						if(rdr["Diary_fee"].ToString()!="")
						{
							gdiaryfee+=double.Parse(rdr["Diary_fee"].ToString());
							pdiaryfee+=double.Parse(rdr["Diary_fee"].ToString());
							vpdiaryfee=double.Parse(rdr["Diary_fee"].ToString());
						}
						else
						{
							gdiaryfee+=0;
							pdiaryfee+=0;
							vpdiaryfee=0;
						}
						if(rdr["annual_fee"].ToString()!="")
						{
							gannualfee+=double.Parse(rdr["annual_fee"].ToString());
							pannualfee+=double.Parse(rdr["annual_fee"].ToString());
							vpannualfee=double.Parse(rdr["annual_fee"].ToString());
						}
						else
						{
							gannualfee+=0;
							pannualfee+=0;
							vpannualfee=0;
						}
						if(rdr["securityfee"].ToString()!="")
						{
							gsecurity+=double.Parse(rdr["securityfee"].ToString());
							psecurity+=double.Parse(rdr["securityfee"].ToString());
							vpsecurity=double.Parse(rdr["securityfee"].ToString());
						}
						else
						{
							gsecurity+=0;
							psecurity+=0;
							vpsecurity=0;
						}
						if(rdr["fees_amount"].ToString()!="")
						{
							gtotal+=double.Parse(rdr["Fees_Amount"].ToString());
							ptotal+=double.Parse(rdr["Fees_Amount"].ToString());
							vptotal=double.Parse(rdr["Fees_Amount"].ToString());
						}
						else
						{
							gtotal+=0;
							ptotal+=0;
							vptotal=0;
						}

						sw.WriteLine(info,i.ToString(),
							rdr["RecuringID"].ToString(),
							rdr["student_id"].ToString(),
							GenUtil.TrimLength(rdr["Student_Fname"].ToString().Trim(),15),
							//rdr["Student_Class"].ToString(),
							GenUtil.TrimLength(rdr["Student_Class"].ToString(),4),
							GenUtil.TrimLength(rdr["Seq_Student_ID"].ToString(),2),
							
						vptutionfee.ToString(),
						vpcomputerfee.ToString(),
						vphousefee.ToString(),
						vpgamefee.ToString(),
						vpsciencefee.ToString(),
						vpregistrationfee.ToString(),
						vplatefee.ToString(),
						vpadmissionfee.ToString(),
						vptransportfee.ToString(),
						vpdevelopmentfee.ToString(),
						vpdiaryfee.ToString(),
						vpannualfee.ToString(),
						vpsecurity.ToString(),
						vptotal.ToString());
						i++;
						

						d++;
					
						if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
						{
							sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
							//string info3="Page Total                                     {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,5:S} {5,5:S} {6,4:S} {7,5:S} {8,5:S} {9,5:S} {10,5:S} {11,5:S} {12,5:S} {13,6:S}";
							string info3="Page Total                                     {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,4:S} {5,5:S} {6,3:S} {7,5:S} {8,6:S} {9,4:S} {10,4:S} {11,4:S} {12,4:S} {13,6:S}";
							sw.WriteLine(info3,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
								pregistrationfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
								pdiaryfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());

							sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
							c++;
							x=60;
							sw.WriteLine();
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");
							sw.WriteLine("|S. N0|Rec ID|St.ID|Student Name   |Class|Sect|Tutio|Comp.|House|Game|Scien|Regis|Late|Admis|Trans| Env |Diary|Annua|Secur|Total |");
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");						
							d+=3;
							y++;
							
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistrationfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdiaryfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						
						}
						else if(d%59==1&&c==1)
						{
							sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
							
							string info3="Page Total                                   {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,5:S} {5,5:S} {6,3:S} {7,5:S} {8,6:S} {9,4:S} {10,4:S} {11,4:S} {12,4:S} {13,6:S}";
							sw.WriteLine(info3,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
							pregistrationfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
							pdiaryfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());
							sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
							
							c++;
							sw.WriteLine(info5,"","Page No:"+c.ToString());
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");
							sw.WriteLine("|S. N0|Rec ID|St.ID|Student Name   |Class|Sect|Tutio|Comp.|House|Game|Scien|Regis|Late|Admis|Trans| Env |Diary|Annua|Secur|Total |");
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");							
							d+=3;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistrationfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdiaryfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						}		
					}
				}
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				
				string info2="Page Total                                   {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,5:S} {5,5:S} {6,3:S} {7,5:S} {8,6:S} {9,4:S} {10,4:S} {11,4:S} {12,4:S} {13,6:S}";
				sw.WriteLine(info2,ptutionfee.ToString(),pcomputerfee.ToString(),phousefee.ToString(),pgamefee.ToString(),psciencefee.ToString(),
				pregistrationfee.ToString(),platefee.ToString(),padmissionfee.ToString(),ptransportfee.ToString(),pdevelopmentfee.ToString(),
				pdiaryfee.ToString(),pannualfee.ToString(),psecurity.ToString(),ptotal.ToString());
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				
				  string info1="Grand Total                                  {0,5:S} {1,5:S} {2,5:S} {3,4:S} {4,5:S} {5,5:S} {6,3:S} {7,5:S} {8,6:S} {9,4:S} {10,4:S} {11,4:S} {12,4:S} {13,6:S}";
				sw.WriteLine(info1,gtutionfee.ToString(),gcomputerfee.ToString(),ghousefee.ToString(),ggamefee.ToString(),gsciencefee.ToString(),
				gregistrationfee.ToString(),glatefee.ToString(),gadmissionfee.ToString(),gtransportfee.ToString(),gdevelopmentfee.ToString(),
				gdiaryfee.ToString(),gannualfee.ToString(),gsecurity.ToString(),gtotal.ToString());
				
				sw.WriteLine("+-----+------+-----+---------------+-----+--+-----+-----+-----+----+-----+-----+---+-----+------+----+----+----+----+-------+");
				sw.Close();
				Print();
				flage=1;
				CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  Button1_Click, DailyFeeReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  Button1_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
			}
		}

		/// <summary>
		/// this methd use to create a report in excel format. in this report data fetch from Recuringreceipt,Student_Record table.
		/// </summary>
		public void ConvertIntoExcel()
		{
			try
			{
				double vptutionfee=0;
				double vpcomputerfee=0;
				double vphousefee=0;
				double vpgamefee=0;
				double vpsciencefee=0;
				double vpannualfee=0;
				double vpregistrationfee=0;
				double vplatefee=0;
				double vpadmissionfee=0;
				double vptransportfee=0;
				double vpdevelopmentfee=0;
				double vpdiaryfee=0;
				double vpsecurity=0;
				double vpCaution=0;
				double vptotal=0; 
				double ptutionfee=0;
				double pcomputerfee=0;
				double phousefee=0;
				double pgamefee=0;
				double psciencefee=0;
				double pannualfee=0;
				double pregistrationfee=0;
				double platefee=0;
				double padmissionfee=0;
				double ptransportfee=0;
				double pdevelopmentfee=0;
				double pdiaryfee=0;
				double psecurity=0;
				double pCaution=0;
				double ptotal=0;
				int i=1;
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2); 
				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\DailyFeesReport.xls";
				StreamWriter sw = new StreamWriter(path);
				InventoryClass obj=new InventoryClass();
				SqlDataReader rdr;
				string str="";
				if(txtDob.Text!="")
				{
					str = "	select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.seq_student_id,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Record sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.Student_ID UNION select rr.recuringid,sr.student_id,sr.student_fname,sr.student_class,sr.student_stream,rr.tution_fee,rr.computer_fee,rr.hostel_fee,rr.game_fee,rr.regfee,rr.latefee,rr.science_fee,rr.admission_fee,rr.transport_fee,rr.envp_fee,rr.diary_fee,rr.annual_fee,rr.securityfee,rr.fees_amount from recuringreceipt rr,Student_Registration sr where cast(floor(cast(cast(FeeSubdt as smalldatetime) as float)) as smalldatetime)='"+GenUtil.str2MMDDYYYY(txtDob.Text)+"' and sr.Student_ID=rr.RegID";
				}
				else
				{
					MessageBox.Show("Please select date");
					return;
				}
				rdr = obj.GetRecordSet(str);
				double gtutionfee=0,gcomputerfee=0,ghousefee=0,ggamefee=0,gsciencefee=0,gregistrationfee=0,glatefee=0,gadmissionfee=0,gtransportfee=0,gdevelopmentfee=0,gdiaryfee=0,gannualfee=0,gsecurity=0,gtotal=0;
				int c=1,d=5;
				int x=60,y=1;
				//sw.WriteLine(("No.1 Air Force School"));
				sw.WriteLine(("                DAILY FEES REPORT for "+txtDob.Text));
				sw.WriteLine();
				sw.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+"Page No:\t"+c.ToString());
				sw.WriteLine("S N0\tReceipt ID\tStudentID\tStudent Name\tClass\tSection\tTution\tComputer\tHouse\tGame\tScience\tRegistration\tLate\tAdmission\tTransport\tEnv\tDiary\tAnnual\tSecurity\tTotal");
				
				if(rdr.HasRows)
				{
					while(rdr.Read())
					{	
						/*sw.WriteLine(i.ToString()+"\t"+
							rdr["RecuringID"].ToString()+"\t"+
							rdr["student_id"].ToString()+"\t"+
							GenUtil.TrimLength(rdr["Student_Fname"].ToString().Trim(),15)+"\t"+
							rdr["Student_Class"].ToString()+"\t"+
							rdr["Seq_Student_ID"].ToString()+"\t"+
							rdr["tution_fee"].ToString()+"\t"+
							rdr["computer_fee"].ToString()+"\t"+
							rdr["hostel_fee"].ToString()+"\t"+
							rdr["game_fee"].ToString()+"\t"+
							rdr["science_fee"].ToString()+"\t"+
							rdr["regfee"].ToString()+"\t"+
							rdr["latefee"].ToString()+"\t"+
							rdr["admission_fee"].ToString()+"\t"+
							rdr["transport_fee"].ToString()+"\t"+
							rdr["envp_fee"].ToString()+"\t"+
							rdr["diary_fee"].ToString()+"\t"+
							rdr["annual_fee"].ToString()+"\t"+
							rdr["securityfee"].ToString()+"\t"+
							rdr["Fees_Amount"].ToString());*/
						
						if(rdr["tution_fee"].ToString()!="")
						{
							gtutionfee+=double.Parse(rdr["tution_fee"].ToString());
							ptutionfee+=double.Parse(rdr["tution_fee"].ToString());
							vptutionfee=double.Parse(rdr["tution_fee"].ToString());
						}
						else
						{
							gtutionfee+=0;
							ptutionfee+=0;
							vptutionfee=0;
						}
						if(rdr["computer_fee"].ToString()!="")
						{

							gcomputerfee+=double.Parse(rdr["computer_fee"].ToString());
							pcomputerfee+=double.Parse(rdr["computer_fee"].ToString());
							vpcomputerfee=double.Parse(rdr["computer_fee"].ToString());
						}
						else
						{
							gcomputerfee+=0;
							pcomputerfee+=0;
							vpcomputerfee=0;
						}
						if(rdr["Hostel_fee"].ToString()!="")
						{
							ghousefee+=double.Parse(rdr["Hostel_fee"].ToString());
							phousefee+=double.Parse(rdr["Hostel_fee"].ToString());
							vphousefee=double.Parse(rdr["Hostel_fee"].ToString());
						}
						else
						{
							ghousefee+=0;
							phousefee+=0;
							vphousefee=0;
						}
						if(rdr["game_fee"].ToString()!="")
						{
							ggamefee+=double.Parse(rdr["Game_fee"].ToString());
							pgamefee+=double.Parse(rdr["Game_fee"].ToString());
							vpgamefee=double.Parse(rdr["Game_fee"].ToString());
						}
						else
						{
							ggamefee+=0;
							pgamefee+=0;
							vpgamefee=0;
						}
						if(rdr["science_fee"].ToString()!="")
						{
							gsciencefee+=double.Parse(rdr["Science_fee"].ToString());
							psciencefee+=double.Parse(rdr["Science_fee"].ToString());
							vpsciencefee=double.Parse(rdr["Science_fee"].ToString());
						}
						else
						{
							gsciencefee+=0;
							psciencefee+=0;
							psciencefee=0;
						}
						if(rdr["Regfee"].ToString()!="")
						{
							gregistrationfee+=double.Parse(rdr["RegFee"].ToString());
							pregistrationfee+=double.Parse(rdr["RegFee"].ToString());
							vpregistrationfee=double.Parse(rdr["RegFee"].ToString());
						}
						else
						{
							gregistrationfee+=0;
							pregistrationfee+=0;
							vpregistrationfee=0;
						}
						if(rdr["latefee"].ToString()!="")
						{
							glatefee+=double.Parse(rdr["LateFee"].ToString());
							platefee+=double.Parse(rdr["LateFee"].ToString());
							vplatefee=double.Parse(rdr["LateFee"].ToString());
						}
						else
						{
							glatefee+=0;
							platefee+=0;
							vplatefee=0;
						}
						if(rdr["admission_fee"].ToString()!="")
						{
							gadmissionfee+=double.Parse(rdr["admission_fee"].ToString());
							padmissionfee+=double.Parse(rdr["admission_fee"].ToString());
							vpadmissionfee=double.Parse(rdr["admission_fee"].ToString());
						}
						else
						{
							gadmissionfee+=0;
							padmissionfee+=0;
							vpadmissionfee=0;
						}
						if(rdr["transport_fee"].ToString()!="")
						{
							gtransportfee+=double.Parse(rdr["transport_fee"].ToString());
							ptransportfee+=double.Parse(rdr["transport_fee"].ToString());
							vptransportfee=double.Parse(rdr["transport_fee"].ToString());
						}
						else
						{
							gtransportfee+=0;
							ptransportfee+=0;
							vptransportfee=0;
						}
						if(rdr["envp_fee"].ToString()!="")
						{
							gdevelopmentfee+=double.Parse(rdr["Envp_fee"].ToString());
							pdevelopmentfee+=double.Parse(rdr["Envp_fee"].ToString());
							vpdevelopmentfee=double.Parse(rdr["Envp_fee"].ToString());
						}
						else
						{
							gdevelopmentfee+=0;
							pdevelopmentfee+=0;
							vpdevelopmentfee=0;
						}
						if(rdr["Diary_fee"].ToString()!="")
						{
							gdiaryfee+=double.Parse(rdr["Diary_fee"].ToString());
							pdiaryfee+=double.Parse(rdr["Diary_fee"].ToString());
							vpdiaryfee=double.Parse(rdr["Diary_fee"].ToString());
						}
						else
						{
							gdiaryfee+=0;
							pdiaryfee+=0;
							vpdiaryfee=0;
						}
						if(rdr["annual_fee"].ToString()!="")
						{
							gannualfee+=double.Parse(rdr["annual_fee"].ToString());
							pannualfee+=double.Parse(rdr["annual_fee"].ToString());
							vpannualfee=double.Parse(rdr["annual_fee"].ToString());
						}
						else
						{
							gannualfee+=0;
							pannualfee+=0;
							vpannualfee=0;
						}
						if(rdr["securityfee"].ToString()!="")
						{
							gsecurity+=double.Parse(rdr["securityfee"].ToString());
							psecurity+=double.Parse(rdr["securityfee"].ToString());
							vpsecurity=double.Parse(rdr["securityfee"].ToString());
						}
						else
						{
							gsecurity+=0;
							psecurity+=0;
							vpsecurity=0;
						}
						if(rdr["fees_amount"].ToString()!="")
						{
							gtotal+=double.Parse(rdr["Fees_Amount"].ToString());
							ptotal+=double.Parse(rdr["Fees_Amount"].ToString());
							vptotal=double.Parse(rdr["Fees_Amount"].ToString());
						}
						else
						{
							gtotal+=0;
							ptotal+=0;
							vptotal=0;
						}

						sw.WriteLine(i.ToString()+"\t"+
							rdr["RecuringID"].ToString()+"\t"+
							rdr["student_id"].ToString()+"\t"+
							GenUtil.TrimLength(rdr["Student_Fname"].ToString().Trim(),15)+"\t"+
							rdr["Student_Class"].ToString()+"\t"+
							GenUtil.TrimLength(rdr["Seq_Student_ID"].ToString(),2)+"\t"+
							vptutionfee.ToString()+"\t"+
							vpcomputerfee.ToString()+"\t"+
							vphousefee.ToString()+"\t"+
							vpgamefee.ToString()+"\t"+
							vpsciencefee.ToString()+"\t"+
							vpregistrationfee.ToString()+"\t"+
							vplatefee.ToString()+"\t"+
							vpadmissionfee.ToString()+"\t"+
							vptransportfee.ToString()+"\t"+
							vpdevelopmentfee.ToString()+"\t"+
							vpdiaryfee.ToString()+"\t"+
							vpannualfee.ToString()+"\t"+
							vpsecurity.ToString()+"\t"+
							vptotal.ToString());
						i++;
						d++;
						if(d>(x*(c-1)+(c+4))&&d%x==y&&c>=2)
						{
							sw.WriteLine(ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
								pregistrationfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
								pdiaryfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());
							c++;
							x=60;
							sw.WriteLine("Page No:"+c.ToString());
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");
							sw.WriteLine("S N0\tReceipt ID\tStudentID\tStudent Name\tClass\tSection\tTution\tComputer\tHouse\tGame\tScience\tRegistration\tLate\tAdmission\tTransport\tEnv\tDiary\tAnnual\tSecurity\tTotal");
							sw.WriteLine("+-----+------+-----+---------------+-----+----+-----+-----+-----+----+-----+-----+----+-----+-----+-----+-----+-----+-----+------+");						
							d+=3;
							y++;
							
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistrationfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdiaryfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						
						}
						else if(d%59==1&&c==1)
						{
							sw.WriteLine(ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
								pregistrationfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
								pdiaryfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());

							c++;
							sw.WriteLine("Page No:"+c.ToString());
							//sw.WriteLine("|S. N0|Rec ID|St.ID|Student Name   |Class|Sect|Tutio|Comp.|House|Game|Scien|Regis|Late|Admis|Trans|Devel|Diary|Annua|Secur|Total |");
							sw.WriteLine("S N0\tReceipt ID\tStudentID\tStudent Name\tClass\tSection\tTution\tComputer\tHouse\tGame\tScience\tRegistration\tLate\tAdmission\tTransport\tEnv\tDiary\tAnnual\tSecurity\tTotal");
							d+=3;
							ptutionfee=0;
							pcomputerfee=0;
							phousefee=0;
							pgamefee=0;
							psciencefee=0;
							pannualfee=0;
							pregistrationfee=0;
							platefee=0;
							padmissionfee=0;
							ptransportfee=0;
							pdevelopmentfee=0;
							pdiaryfee=0;
							psecurity=0;
							pCaution=0;
							ptotal=0;
						}		
					}
				}
				sw.WriteLine("Page Total  \t\t\t\t\t\t"+ptutionfee.ToString()+"\t"+pcomputerfee.ToString()+"\t"+phousefee.ToString()+"\t"+pgamefee.ToString()+"\t"+psciencefee.ToString()+"\t"+
					pregistrationfee.ToString()+"\t"+platefee.ToString()+"\t"+padmissionfee.ToString()+"\t"+ptransportfee.ToString()+"\t"+pdevelopmentfee.ToString()+"\t"+
					pdiaryfee.ToString()+"\t"+pannualfee.ToString()+"\t"+psecurity.ToString()+"\t"+ptotal.ToString());
					
				sw.WriteLine("Grand Total  \t\t\t\t\t\t"+gtutionfee.ToString()+"\t"+gcomputerfee.ToString()+"\t"+ghousefee.ToString()+"\t"+ggamefee.ToString()+"\t"+gsciencefee.ToString()+"\t"+
					gregistrationfee.ToString()+"\t"+glatefee.ToString()+"\t"+gadmissionfee.ToString()+"\t"+gtransportfee.ToString()+"\t"+gdevelopmentfee.ToString()+"\t"+
					gdiaryfee.ToString()+"\t"+gannualfee.ToString()+"\t"+gsecurity.ToString()+"\t"+gtotal.ToString());
				sw.Close();
				flage=1;
				CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  ExcelButton_Click, DailyFeeReport View , Userid :  "+ pass   );
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  ExcelButton_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\DailyFeesReport.txt<EOF>");
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
					Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method :  Print(),  DailyFeeReport Printed , Userid :  "+ pass   );							 
			          
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  Print(),  Exception: "+ane.Message+" , Userid :  "+ pass   );		
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method  Print(),  Exception: "+se.Message+" , Userid :  "+ pass   );		
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method : Print(),  Exception: "+es.Message+" , Userid :  "+ pass   );		
				}
			
			} 
			catch (Exception ex) 
			{
				CreateLogFiles.ErrorLog(" Form :DailyFeeReport.aspx,Method : Print(),  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this method use to call ConvertIntoExcel function.
		/// </summary>
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			try
			{
				ConvertIntoExcel();
				MessageBox.Show("Successfully Convert File into Excel Format");
				CreateLogFiles.ErrorLog("Form:DailyFeesReport.aspx,Method: btnExcel_Click, Daily Fees Report Convert Into Excel Format ,  userid  "+pass);
			}
			catch(Exception ex)
			{
				MessageBox.Show("First Close The Open Excel File");
				CreateLogFiles.ErrorLog("Form:DailyFeesReport.aspx,Method:btnExcel_Click   Daily Fees Report Viewed  "+ ex.Message+ "  EXCEPTION " +" userid  "+pass);
			}
		}
	}
}
