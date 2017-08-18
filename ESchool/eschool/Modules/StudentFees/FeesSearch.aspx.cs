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
using System.IO;
using System.Text;  
using System.Net;
using System.Net.Sockets; 

# endregion

namespace eschool.StudentFees
{
	/// <summary>
	/// Summary description for FeesSearch.
	/// </summary>
	public class FeesSearch : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlButton Search;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlButton BtnPrint;
		protected System.Web.UI.WebControls.DropDownList DropCurrent;
		protected System.Web.UI.WebControls.TextBox TxtFrom;
		protected System.Web.UI.WebControls.TextBox TxtTo;
		protected System.Web.UI.WebControls.TextBox txtLastQtrDue;
		protected System.Web.UI.WebControls.TextBox txtCurrQtrDue;
		protected System.Web.UI.WebControls.TextBox txtTotalDue;
		protected System.Web.UI.WebControls.TextBox txtPrevAdv;
		protected System.Web.UI.WebControls.TextBox txtAdvColNextQtr;
		protected System.Web.UI.WebControls.TextBox txtColCurrQtr;
		protected System.Web.UI.WebControls.TextBox txtDueQtr;
		static double TotalCollection=0;
		static double AdvanceNext=0;
		static double AmountDue=0;
		static double LastDue=0;
		static double PreviousAdvance=0;
		static double DTotal=0;
		static double GrandDue=0;
		protected System.Web.UI.WebControls.TextBox TextPrevto;
		protected System.Web.UI.WebControls.TextBox TextNextfrom;
		protected System.Web.UI.WebControls.TextBox TextPrevfrom;
		protected System.Web.UI.WebControls.TextBox TextNextto;
		string [] scategory=new string[4];
    	public string routename="";
		public string routeid="";
		public int count=0;
		public string category="";
		public string section="";
		public string classid="";
		public string sname="";
     	public string rank="";
		public string student_id="";
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
		public double advance=0;
		public double gadvance=0;
		protected System.Web.UI.WebControls.DropDownList DropClass;
		protected System.Web.UI.WebControls.DropDownList DropSection;
		public double gTempCaution=0;
		public string[] feetype={"TUTION_FEE","COMPUTER_FEE","SCIENCE_FEE","GAMES_FEE","HOSTEL_FEE","DIARY_FEE","ANNUAL_FEE","ENVP_FEE","ADMISSION_FEE","CAUTION_FEE"};
		public string[] feetypeT={"TUTION FEE","COMPUTER FEE","SCIENCE FEE","GAMES FEE","HOUSE FEE","DIARY FEE","ANNUAL FEE","ENV. FEE","ADMISSION_FEE","CAUTION_FEE"};
		public string recdate="";
		public double feeamount=0;
		public double gTotal=0;
		protected System.Web.UI.WebControls.TextBox remark;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.TextBox amount;
		protected System.Web.UI.WebControls.TextBox gamount1;
		protected System.Web.UI.WebControls.TextBox gamount;
		protected System.Web.UI.WebControls.TextBox txtRemothers;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.TextBox txtOthers;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.HtmlControls.HtmlButton Btnexcel;
		public double Total=0;
		string pass;
		 
		/// <summary>
		/// This method is used for setting the Session variable for userId and 
		/// after that filling the required dropdowns with database values 
		/// and also check accessing priviledges for perticular user
		///</summary>
		private void Page_Load(object sender, System.EventArgs e)
		{
            txtLastQtrDue.Attributes.Add("readonly", "readonly");
            txtCurrQtrDue.Attributes.Add("readonly", "readonly");
            txtTotalDue.Attributes.Add("readonly", "readonly");
            txtPrevAdv.Attributes.Add("readonly", "readonly");
            txtAdvColNextQtr.Attributes.Add("readonly", "readonly");
            txtColCurrQtr.Attributes.Add("readonly", "readonly");
            txtDueQtr.Attributes.Add("readonly", "readonly");


            try
			{
				pass=(Session["password"].ToString ());
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form : FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				//Response.Redirect(@"../form/HolidayEntryForm.aspx",false);
				Response.Redirect(@"/eschool/Modules/Form/HolidayEntryForm.aspx",false);
				return;
			}
			try
			{
			
				if(!Page.IsPostBack)
				{
					TextPrevfrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TextPrevto.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TextNextfrom.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TextNextto.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
					TxtFrom.Text=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
					TxtTo.Text=System.DateTime.Now.Day.ToString()+ "/" + System.DateTime.Now.Month.ToString()+ "/" + System.DateTime.Now.Year.ToString();
					
					SqlConnection con;
					SqlCommand cmdselect;
					SqlDataReader dtrall;
					con=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
					con.Open ();
					cmdselect = new SqlCommand( "Select Class_name from class order by class_id", con );
					dtrall = cmdselect.ExecuteReader();
					while(dtrall.Read ())
					{
						DropClass .Items.Add(dtrall.GetValue(0).ToString());
					}
					dtrall.Close();
					con.Close ();      
				}
				if(! IsPostBack)
				{
					#region Check Privileges
					int i;
					string View_flag="0", Add_Flag="0", Edit_Flag="0", Del_Flag="0";
					string Module="11";
					string SubModule="10";
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
				CreateLogFiles.ErrorLog(" Form : FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
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
			this.Search.ServerClick += new System.EventHandler(this.Search_ServerClick);
			this.BtnPrint.ServerClick += new System.EventHandler(this.BtnPrint_ServerClick);
			this.Btnexcel.ServerClick += new System.EventHandler(this.Btnexcel_ServerClick);
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
		/// this Method use to first call collectionfees() to get total collection of a particular period. after that get data from recuringreceipt table.
		/// after that call feesdecisionmonthly() function.
		/// </summary>
		private void Search_ServerClick(object sender, System.EventArgs e)
		{
			TotalCollection=0;
			AdvanceNext=0;
			AmountDue=0;
			LastDue=0;
			PreviousAdvance=0;
			DTotal=0;
			GrandDue=0;
			gtotal=0;
			try
			{
				gTotal=0;
				collectionfees();
				InventoryClass obj1=new InventoryClass();		
				if(DropClass.SelectedItem.Text.Equals("All"))
				{
					if(TxtFrom.Text.Equals("")||TextNextfrom.Text.Equals("")||TextNextto.Text.Equals("")||TextPrevfrom.Text.Equals("")||TextPrevto.Text.Equals(""))
					{
						MessageBox.Show("Please enter the date");
					}
					else
					{
						if(!TxtFrom.Text.Equals("") && !TxtTo.Text.Equals(""))
						{
							AmountDue=0;	
							InventoryClass obj=new InventoryClass();
							SqlDataReader SqlDtr;
							string str="";
							string dtFrom=TxtFrom.Text;
							string dtTo=TxtTo.Text;
							str="select sum(AmountDue) from  recuringreceipt where period between '"+GenUtil.str2MMDDYYYY(dtFrom)+ "' and '"+GenUtil.str2MMDDYYYY(dtTo)+"'";
							SqlDtr=obj.GetRecordSet(str);
							if(SqlDtr.HasRows)
							{
								if(SqlDtr.Read())
								{	
									string v=SqlDtr.GetValue(0).ToString();
									if(!SqlDtr.GetValue(0).ToString().Equals(""))
										AmountDue=System.Convert.ToDouble(SqlDtr.GetValue(0).ToString());
								}
							}
							SqlDtr.Close();
							AmountDue=gTotal;
							str="select sum(AmountDue) from  recuringreceipt where period between '"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+ "' and '"+GenUtil.str2MMDDYYYY(TextPrevto.Text.ToString())+"'";
							SqlDtr=obj.GetRecordSet(str);
							if(SqlDtr.HasRows)
							{
								if(SqlDtr.Read())
								{	
									string v=SqlDtr.GetValue(0).ToString();
									if(!SqlDtr.GetValue(0).ToString().Equals(""))
										LastDue=System.Convert.ToDouble(SqlDtr.GetValue(0).ToString());
								}
							}
							SqlDtr.Close();
    						str = "select * from student_record where  student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(TextPrevto.Text.ToString())+"')) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+"' order by student_class,seq_student_id,student_fname";  //added by vishnu on 21/11
							SqlDtr=obj.GetRecordSet(str);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthly(student_id,TextPrevfrom.Text.ToString(),TextPrevto.Text.ToString());
							}
							SqlDtr.Close();
							LastDue=LastDue+gtotal;
							gtotal=0;
							str = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (TextPrevfrom.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TextPrevto.Text.Trim())+"'))";//added by vishnu 21/11
    						SqlDtr=obj.GetRecordSet(str);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthlyadv(student_id,TextPrevfrom.Text.ToString(),TextPrevto.Text.ToString(),TxtFrom.Text.ToString(),TxtTo.Text.ToString());
							}
							SqlDtr.Close();
							PreviousAdvance=PreviousAdvance+gtotal;
							gtotal=0;
							str = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TextNextfrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(TextNextto.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (TxtFrom.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TxtTo.Text.Trim())+"'))";
							SqlDtr=obj.GetRecordSet(str);
							while(SqlDtr.Read())
							{
								student_id=SqlDtr.GetValue(0).ToString().Trim();
								feesdecisionmonthlyadv(student_id,TxtFrom.Text.ToString(),TxtTo.Text.ToString(),TextNextfrom.Text.ToString(),TextNextto.Text.ToString());
							}
							SqlDtr.Close();
							AdvanceNext=gtotal;
							gtotal=0;
							feesdecisionmonthly();
							TotalCollection=gtotal;
							gtotal=0;
						}
					}
				}
				else 
				{
					if(DropClass.SelectedIndex!=0&&DropSection.SelectedIndex!=0)
					{
						if(TxtFrom.Text.Equals("")||TextNextfrom.Text.Equals("")||TextNextto.Text.Equals("")||TextPrevfrom.Text.Equals("")||TextPrevto.Text.Equals(""))
						{
							MessageBox.Show("Please enter the date");
						}
						else
						{
							if(!TxtFrom.Text.Equals("") && !TxtTo.Text.Equals(""))
							{
								AmountDue=0;	
								InventoryClass obj=new InventoryClass();
								SqlDataReader SqlDtr;
								string str="";
								string dtFrom=TxtFrom.Text;
								string dtTo=TxtTo.Text;
					            double late=0;
								/*string strSelect="select sum(latefee) from recuringreceipt where student_id in(select student_id from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"') and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"'";      
								SqlDtr=obj.GetRecordSet(strSelect);
								while(SqlDtr.Read())
								{
									if(SqlDtr.GetValue(0)!=null && SqlDtr.GetValue(0).ToString()!="")
									{
										late=Convert.ToDouble(SqlDtr.GetValue(0));
									}
									else
									{
										late=0;
									}
								}
								SqlDtr.Close();*/
                                gTotal=gTotal+late;
								AmountDue=gTotal;
					            gtotal=0;
								str="select sum(AmountDue) from  recuringreceipt where period  between '"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+ "' and '"+GenUtil.str2MMDDYYYY(TextPrevto.Text.ToString())+"'";
								SqlDtr=obj.GetRecordSet(str);
								if(SqlDtr.HasRows)
								{
									if(SqlDtr.Read())
									{	
										string v=SqlDtr.GetValue(0).ToString();
										if(!SqlDtr.GetValue(0).ToString().Equals(""))
											LastDue=System.Convert.ToDouble(SqlDtr.GetValue(0).ToString());
									}
								}
								SqlDtr.Close();
								str = "select * from student_record where Student_Class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_id not in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto>='"+GenUtil.str2MMDDYYYY(TextPrevto.Text.ToString())+"')) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TextPrevfrom.Text.ToString())+"' order by student_class,seq_student_id,student_fname";  //added by vishnu on 20/11
    							SqlDtr=obj.GetRecordSet(str);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthly(student_id,TextPrevfrom.Text.ToString(),TextPrevto.Text.ToString());
								}
								SqlDtr.Close();
								LastDue=LastDue+gtotal;
								gtotal=0;
     							str = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (TextPrevfrom.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TextPrevto.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSection.SelectedItem .Value .ToString()+"' order by student_class,seq_student_id,student_fname";
								SqlDtr=obj.GetRecordSet(str);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthlyadv(student_id,TextPrevfrom.Text.ToString(),TextPrevto.Text.ToString(),TxtFrom.Text.ToString(),TxtTo.Text.ToString());
								}
								SqlDtr.Close();
								PreviousAdvance=PreviousAdvance+gtotal;
								gtotal=0;
								str = "select * from student_record where student_id in (select student_id from recuringreceipt where period<='"+GenUtil.str2MMDDYYYY(TextNextfrom.Text.ToString())+"' and student_id in (select student_id from recuringreceipt where periodto='"+GenUtil.str2MMDDYYYY(TextNextto.Text.ToString())+"' and feesubdt between '"+GenUtil.str2MMDDYYYY (TxtFrom.Text.Trim()) +"' and '"+GenUtil.str2MMDDYYYY (TxtTo.Text.Trim())+"')) and student_class='"+DropClass.SelectedItem.Value.ToString()+"' and seq_student_id='"+DropSection.SelectedItem .Value .ToString()+"' order by student_class,seq_student_id,student_fname";
								SqlDtr=obj.GetRecordSet(str);
								while(SqlDtr.Read())
								{
									student_id=SqlDtr.GetValue(0).ToString().Trim();
									feesdecisionmonthlyadv(student_id,TxtFrom.Text.ToString(),TxtTo.Text.ToString(),TextNextfrom.Text.ToString(),TextNextto.Text.ToString());
								}
								SqlDtr.Close();
								AdvanceNext=gtotal;
								gtotal=0;
								feesdecisionmonthly();
								TotalCollection=gtotal;
								gtotal=0;
							}
						}
					}
					else
					{
						MessageBox.Show("Please select Class and section");
						return;
					}
				}
				txtCurrQtrDue.Text=AmountDue.ToString();
				txtLastQtrDue.Text=LastDue.ToString();
				DTotal=LastDue+AmountDue;
				txtTotalDue.Text=DTotal.ToString();
				txtPrevAdv.Text=PreviousAdvance.ToString();
				txtAdvColNextQtr.Text=AdvanceNext.ToString();
				txtColCurrQtr.Text=TotalCollection.ToString();
				GrandDue=(DTotal-PreviousAdvance+AdvanceNext)-TotalCollection;
				txtDueQtr.Text=GrandDue.ToString();		
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// this Method use to first call collectionfees() to get total collection of a particular period. after that get data from recuringreceipt table.
		/// after that call feesdecisionmonthly() function.
		/// </summary>
		private void BtnPrint_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);
				string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ReconcilationReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				conNorthwind.Open();
				string  strSelect="";
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				if(DropClass.SelectedIndex!=0||DropSection.SelectedIndex!=0)
				{
					if(!TxtFrom.Text.Equals("")&&!TxtTo.Text.Equals(""))
					{
						sw.Write((char)27);
						sw.Write((char)67);
						sw.Write((char)0);
						sw.Write((char)12);
						sw.Write((char)27);
						sw.Write((char)78);
						sw.Write((char)5);
						sw.Write((char)27);
						sw.Write((char)15);
						string des="+---------------+-----------+-------------+-------------+------------+";
						//	sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("COLLECTION DETAILS OF FEES",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS WISE QUARTERLY FEES FOR THE MONTH   "+ TxtFrom.Text.Trim() + " TO "+TxtTo.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS "+ DropClass.SelectedItem.Text.Trim()+" "+DropSection.SelectedItem.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						//info = " {0,-5:S} {1,-6:S} {2,-5:S} {3,-15:S} {4,-5:S} {5,-4:S} {6,-5:S} {7,-5:S} {8,-5:S} {9,-4:S} {10,-5:S} {11,-5:S} {12,-4:S} {13,-5:S} {14,-5:S} {15,-5:S} {16,-5:S} {17,-5:S} {18,-6:S}";
						string info = " {0,-15:S} {1,-11:S} {2,10:S} {3,13:S} {4,12:S}";
						string info4=" {0,-26:S}     {1,10:S} {2,13:S} {3,12:S}" ;
						string info2=" Grand Total                                             {0,12:S}" ;
						string info5="Less:-{0,-49:S} {1,12:S}";
						sw.WriteLine("+---------------+-----------+-------------+-------------+------------+");
						sw.WriteLine("| RANK          | STREAM    | FEE RATE    | STRENGTH    | AMOUNT     ");
						sw.WriteLine("+---------------+-----------+-------------+-------------+------------+");
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"'  group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)1);
							//sw.WriteLine(feetypeT[i]);
							sw.WriteLine(GenUtil.GetCenterAddr(feetypeT[i],des.Length));
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)0);
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= collectionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
								}
							}
							SqlDtr.Close();
						}
						for(int i=feetype.Length;i<feetype.Length;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt)  and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)1);
							//sw.WriteLine(feetypeT[i]);
							sw.WriteLine(GenUtil.GetCenterAddr(feetypeT[i],des.Length));
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)0);
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= collectionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(info,rank.ToString(),stream.ToString(),feeamount.ToString(),count.ToString(),Total.ToString());
								}
							}
							SqlDtr.Close();
						}
						/*strSelect="select (select trfee from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSection.SelectedItem.Text+"' and (s.service_bus='Yes' and s.routeno!=0) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by s.routeno";// add by vikas sharma 03.03.08
						SqlDtr=obj.GetRecordSet(strSelect);
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)1);
						//sw.WriteLine("TRANSPORT FEE");
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)0);
						double []fees=new double[100];
						double []count1=new double[100];
						double []feesamount1=new double[100];
						int c=0,n=0;
						while(SqlDtr.Read())
						{
							routename=SqlDtr.GetValue(0).ToString();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=collectionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
							if(c==0)
							{
								fees[c]=System.Convert.ToDouble(routename);
								c++;
							}
							for(int j=0;j<c;j++)
							{						
								if(fees[j]==System.Convert.ToDouble(routename))
								{
									fees[j]=System.Convert.ToDouble(routename);
									count1[j]+=System.Convert.ToDouble(count);
									feesamount1[j]=System.Convert.ToDouble(feeamount);
								}
								else
								{
									fees[c]=System.Convert.ToDouble(routename);
									count1[c]=System.Convert.ToDouble(count);
									feesamount1[c]=System.Convert.ToDouble(feeamount);
									c++;
								}
							}
							n++;	
						}
						for(int j=0;j<c;j++)
						{
							sw.WriteLine(info,fees[j].ToString(),stream.ToString(),feesamount1[j].ToString(),count1[j].ToString(),(count1[j]*feesamount1[j]).ToString());			
						}
						SqlDtr.Close();
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)1);
						sw.WriteLine("LATE FEE");
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)0);
						double late=0;
						strSelect="select sum(latefee) from recuringreceipt where student_id in(select student_id from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"') and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"'";      
						SqlDtr=obj.GetRecordSet(strSelect);
						while(SqlDtr.Read())
						{
							if(SqlDtr.GetValue(0)!=null && SqlDtr.GetValue(0).ToString()!="")
							{
								late=Convert.ToDouble(SqlDtr.GetValue(0));
							}
							else
							{
								late=0;
							}
							sw.WriteLine(info,"","","","",late.ToString());
						}
						SqlDtr.Close();*/
						//gTotal=gTotal+late;
						gTotal=gTotal;
						SqlDtr.Close();
						sw.WriteLine("                                                         ------------");
						sw.WriteLine(info2,gTotal.ToString());
						sw.WriteLine("                                                         ------------");
						sw.WriteLine(info5,GenUtil.TrimLength(remark.Text.Trim(),49),amount.Text.Trim().ToString());
						sw.WriteLine("+---------------+-----------+-------------+-------------+------------+");
						sw.WriteLine(info2,gTotal.ToString());
						sw.WriteLine("+---------------+-----------+-------------+-------------+------------+");

					}
				}			
				sw.WriteLine("    --------------------------------------------------");
				sw.WriteLine("    Reconcilation Report From "+TxtFrom.Text.Trim()+ " To " +TxtTo.Text.Trim());
				sw.WriteLine("    --------------------------------------------------");
				sw.WriteLine("");
				sw.WriteLine("");
				string info1=" Due Of Last Quarter                            {0,10:S} ";
				sw.WriteLine(info1,GenUtil.strNumericFormat(LastDue.ToString()));
				sw.WriteLine("");
				string info6=" {0,-45:S}{1,12:S}";
				sw.WriteLine(info6,GenUtil.TrimLength(txtRemothers.Text.ToString(),45),GenUtil.strNumericFormat(txtOthers.Text.ToString()));
				info1=" Due Of Current Quarter			        {0,10:S} ";
				sw.WriteLine(info1,GenUtil.strNumericFormat(AmountDue.ToString()));
				sw.WriteLine("");
				info1=" Total Due        			        {0,10:S} ";
				sw.WriteLine(" ---------------------------------------------------------");
				sw.WriteLine(info1,GenUtil.strNumericFormat(DTotal.ToString()));
				sw.WriteLine(" ---------------------------------------------------------");
				sw.WriteLine("");
				info1=" Previous Advance         			{0,10:S} ";
				sw.WriteLine(info1,GenUtil.strNumericFormat(PreviousAdvance.ToString()));
				sw.WriteLine("");
				info1=" Advance Collect For Next Quarter	        {0,10:S} ";
				sw.WriteLine(info1,GenUtil.strNumericFormat(AdvanceNext.ToString()));
				sw.WriteLine("");
				info1=" Total Collection In This Quarter	        {0,10:S} ";
				sw.WriteLine(info1,GenUtil.strNumericFormat(TotalCollection.ToString()));
				info1=" Due For The Quarter                            {0,10:S} ";
				sw.WriteLine("");
				sw.WriteLine(" ---------------------------------------------------------");
				sw.WriteLine(info1,GenUtil.strNumericFormat(GrandDue.ToString()));
				sw.WriteLine(" ---------------------------------------------------------");
				sw.Close(); 
				Print();
			}
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	
		}

		/// <summary>
		/// Method for sending the text file to the printer and issuing the command to printer for printing the report.
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
					byte[] msg = Encoding.ASCII.GetBytes(home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ReconcilationReport.txt<EOF>");
					//													\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ReconcilationReport.txt								
					/// Send the data through the socket.
					int bytesSent = sender1.Send(msg);
					/// Receive the response from the remote device.
					int bytesRec = sender1.Receive(bytes);
					Console.WriteLine("Echoed test = {0}",
						Encoding.ASCII.GetString(bytes,0,bytesRec));
					/// Release the socket.
					sender1.Shutdown(SocketShutdown.Both);
					sender1.Close();
					CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  BtnPrint_Click, Reconcilation Report Printed, Userid :  "+ pass);
				} 
				catch (ArgumentNullException ane) 
				{
					Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  BtnPrint_Click, Exception"+ ane.Message+",  Reconcilation Report Printed, Userid :  "+ pass);
				} 
				catch (SocketException se) 
				{
					Console.WriteLine("SocketException : {0}",se.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  BtnPrint_Click, Exception"+ se.Message+",  Reconcilation Report Printed, Userid :  "+ pass);
				} 
				catch (Exception es) 
				{
					Console.WriteLine("Unexpected exception : {0}", es.ToString());
					CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  BtnPrint_Click, Exception"+ es.Message+",  Reconcilation Report Printed, Userid :  "+ pass);
				}
			
			} 
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  BtnPrint_Click, Exception:"+ex.Message +", Reconcilation Report Printed, Userid :  "+ pass);
								
			}
		}

		/// <summary>
		/// this method use to Calculate monthly Fees use data from recuringreceipt table.
		/// </summary>
		public void feesdecisionmonthly()
		{
			string str2="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				bool f=false;
				if(DropClass.SelectedItem.Text.Equals("All"))
				{
					str2="select sum(fees_amount) from recuringreceipt where feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"'";//added by vishnu on 21/11
					f=true;
				}
				else if(DropClass.SelectedIndex>=1&&DropSection.SelectedIndex>0)
				{
					str2="select sum(fees_amount) from recuringreceipt where student_id in (select student_id from student_Record where student_class='I' and seq_student_id='A') and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' union select sum(fees_amount) from recuringreceipt where Regid in (select student_id from student_Registration where student_class='I') and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"'";
					f=true;
				}
				if(f==true)
				{
					SqlDtr1=obj.GetRecordSet(str2);
					while(SqlDtr1.Read())
					{
						if( SqlDtr1.GetValue(0).ToString()!=null &&!SqlDtr1.GetValue(0).ToString().Equals(""))
						{
							total=double.Parse(SqlDtr1.GetValue(0).ToString());
							gtotal+=total;
							advance=total;
							gadvance+=advance;
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database Problem");
				CreateLogFiles.ErrorLog(" Form :FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}

		/// <summary>
		/// Calculate monthly Fees Based on Student id data use from student_record table and recuringreceipt table,from date and todate
		/// </summary>
		public void feesdecisionmonthly(string student_id1,string fromdate,string todate)
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
					str2="select student_fname,seq_student_id,student_class,rank,scategory,student_stream from student_record where student_id='"+student_id1+"'";
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						sname=SqlDtr1.GetString(0).ToString();
						section=SqlDtr1.GetString(1).ToString();
						classid=SqlDtr1.GetString(2).ToString();
						rank=SqlDtr1.GetString(3).ToString();
						category=SqlDtr1.GetString(4).ToString();
						stream=SqlDtr1.GetString(5).ToString();
					}

					SqlDtr1.Close();

					string startfrom=""; 
					string endto="";
				
					int count=0;
					int Flag=0;

					if(!rank.Equals("")&&!category.Equals(""))
					{
						count=0;
					
						str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(fromdate)+"' and todate>='"+GenUtil.str2MMDDYYYY(todate)+"'";
     					startfrom=GenUtil.ConvertMonthName(fromdate.ToString());
						startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
						endto=GenUtil.ConvertMonthName(todate.ToString());
						endto=endto.Substring(0,endto.Trim().Length-4).Trim();
						System.TimeSpan diff=ToMMddYYYY(todate.ToString()).Subtract(ToMMddYYYY(fromdate.ToString()));
						int idays=diff.Days;
						count=(idays+1)/30;
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{				
							if(startfrom.Equals("April"))
							{
								str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(fromdate.ToString())+"' and todate>='"+GenUtil.str2MMDDYYYY(todate.ToString())+"'";
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
								
								if(SqlDtr["tution_fee"].ToString()==null ||SqlDtr["tution_fee"].ToString().Equals(""))
									return;
								tutionfee=count*double.Parse(SqlDtr["tution_fee"].ToString());
								computerfee=count*double.Parse(SqlDtr["computer_fee"].ToString());
								sciencefee=count*double.Parse(SqlDtr["science_fee"].ToString());
								if(!startfrom.Equals("")&&!endto.Equals(""))
								{
									if(startfrom.Equals("April") &&classid.Equals("XI"))
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(fromdate.ToString())+"' and todate>='"+GenUtil.str2MMDDYYYY(todate.ToString())+"'";
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
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(fromdate.ToString())+"' and todate>='"+GenUtil.str2MMDDYYYY(todate.ToString())+"'";
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
																			
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(fromdate.ToString())+"' and todate>='"+GenUtil.str2MMDDYYYY(todate.ToString())+"'";

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
				CreateLogFiles.ErrorLog(" Form :FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				
			}
		
		}

		/// <summary>
		/// this method use to Calculate monthly Fees based on recuring id
		/// </summary>
		public  void feesdecisionmonthly(string recuringid1)
		{
			string recdate="";
			string duration="";
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
			student_id="";
			string recuringid="";
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
				str2="select student_id from recuringreceipt where recuringid='"+recuringid1+"'";
				SqlDtr1=obj.GetRecordSet(str2);
				if(SqlDtr1.Read())
				{
					student_id=SqlDtr1.GetValue(0).ToString();
				}
				SqlDtr1.Close();
				if(!student_id.Equals("0"))
				{
					str2="select student_fname,seq_student_id,student_class,rank,scategory,student_stream,computer from student_record where student_id='"+student_id+"'";
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
					
						str2="select RecuringID,fees_type,securityfee,Latefee,RegFee,feesubdt from recuringreceipt where student_id='"+student_id+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and '"+GenUtil.str2MMDDYYYY(TxtTo .Text) +"' and recuringid='"+recuringid1+"'" ;

						SqlDtr1=obj.GetRecordSet(str2);
						if(SqlDtr1.Read())
						{
							recuringid=SqlDtr1.GetValue(0).ToString();
							startfrom=SqlDtr1.GetString(1).ToString();
							security=double.Parse(SqlDtr1.GetValue(2).ToString());
							latefee=double.Parse(SqlDtr1.GetValue(3).ToString());
							registraionfee=double.Parse(SqlDtr1.GetValue(4).ToString());
							recdate=GenUtil.trimDate(SqlDtr1.GetDateTime(5).ToString());
							glatefee+=latefee;
						}
						
						if(registraionfee!=0)
						{
							tutionfee=0;
							computerfee=0;
							housefee=0;
							gamefee=0;
							sciencefee=0;
							annualfee=0;
							latefee=0;
							admissionfee=0;
							transportfee=0;
							developmentfee=0;
							dairyfee=0;
							security=0;
							total=0;
							Caution=0;
							TempCaution=0;
						}
						else
						{

							startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
							SqlDtr1.Close();
							str2="select fees_type, recuringid from recuringreceipt where student_id='"+student_id+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and '"+GenUtil.str2MMDDYYYY(TxtTo .Text)+"' and recuringid='"+recuringid+"'";
							SqlDtr1=obj.GetRecordSet(str2);
							while(SqlDtr1.Read())
							{
								endto=SqlDtr1.GetString(0).ToString().Trim();
								count++;
							}
							SqlDtr1.Close();
							endto=endto.Substring(0,endto.Trim().Length-4).Trim();
						}

						duration =startfrom+"-"+endto;
						str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
						SqlDtr=obj.GetRecordSet(str);
						if(SqlDtr.Read())
						{
							if(security!=0)
							{
								str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='One Time' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									admissionfee=double.Parse(rdr["admission_fee"].ToString());
									Caution=security+admissionfee;
									gsecurity+=security;
									gadmissionfee+=admissionfee;
									Flag++;
								}
								else
								{
									MessageBox.Show("Please enter one time fees in Fees Decision table");
									return;
								}
								rdr.Close();
							}
							
							if(startfrom.Equals("Apr"))
							{
								str="select * from feesdecision where class_id=(select class_id from class where class_name='"+classid+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
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
								tutionfee=count*double.Parse(SqlDtr["tution_fee"].ToString());
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
								sciencefee=count*double.Parse(SqlDtr["science_fee"].ToString());
								if(!startfrom.Equals("")&&!endto.Equals(""))
								{
									if(startfrom.Equals("Apr") && endto.Equals("June")&&classid.Equals("XI"))
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo .Text)+"'";
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
									else if(startfrom.Equals("Apr") && endto.Equals("June") )
									{
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
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
										str1="select trfee from route where route_id=(select routeno from student_record where student_id='"+student_id+"' and service_bus='Yes') and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo .Text)+"'";
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
								if(Flag==2)
								{
									Caution+=total;
									total=Caution+latefee;
									gtotal+=total;					
								}
								else
								{
									Caution+=total;
									total=Caution+latefee;
									gtotal+=total;
									
								}
							}
						}
					}
				}
				else
				{
					string regid="";
					str2="select RecuringID,RegID,RegFee from recuringreceipt where recuringid='"+recuringid1+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and '"+ GenUtil.str2MMDDYYYY(TxtTo .Text)+"'and recuringid='"+recuringid1+"'" ;

					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						recuringid=SqlDtr1.GetValue(0).ToString();
						regid=SqlDtr1.GetValue(1).ToString();
						registraionfee=double.Parse(SqlDtr1.GetValue(2).ToString());
					}
					SqlDtr1.Close();
					str2="select student_fname from student_Registration where student_id='"+regid+"'";
					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						sname=SqlDtr1.GetString(0).ToString();
					}
					SqlDtr1.Close();
					if(registraionfee!=0)
					{
						tutionfee=0;
						computerfee=0;
						housefee=0;
						gamefee=0;
						sciencefee=0;
						annualfee=0;
						latefee=0;
						admissionfee=0;
						transportfee=0;
						developmentfee=0;
						dairyfee=0;
						security=0;
						total=registraionfee;
						Caution=0;
						TempCaution=0;
						gregistraionfee+=registraionfee;
						gtotal+=total;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : FeesSearch.aspx,Method  btnSave_Click,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}
		}
		/// <summary>
		/// this method use to Calculate advance monthly Fees based on Student id
		/// </summary>
		public void feesdecisionmonthlyadv(string student_id1,string cf,string ct,string nf,string nt)
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
			advance=0;
			TempCaution=0;
			string recid="";
			string computer="";
			try
			{
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr1=null;
				InventoryClass obj1=new InventoryClass();
				string str2="";
				str2="select recuringid,FeeSubDt from recuringreceipt where student_id='"+student_id1+"'";
				SqlDtr1=obj.GetRecordSet(str2);
				if(SqlDtr1.Read())
				{
					recid=SqlDtr1.GetValue(0).ToString();
				}
				SqlDtr1.Close();
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
					str2="select RecuringID,fees_type,securityfee,Latefee,RegFee,feesubdt,diary_fee,tution_fee,computer_fee,science_fee,game_fee,transport_fee,admission_fee,annual_fee,envp_fee,hostel_fee,fees_amount,period,periodto from recuringreceipt where student_id='"+student_id+"' and feesubdt between '"+GenUtil.str2MMDDYYYY(cf)+"' and '"+GenUtil.str2MMDDYYYY(ct)+"' and period<='"+GenUtil.str2MMDDYYYY(nf)+"' and periodto='"+GenUtil.str2MMDDYYYY(nt)+"'" ;

					SqlDtr1=obj.GetRecordSet(str2);
					if(SqlDtr1.Read())
					{
						if(SqlDtr1.GetValue(16).ToString()==null||SqlDtr1.GetValue(16).ToString().Equals(""))
						return;
						security=double.Parse(SqlDtr1.GetValue(2).ToString());
						latefee=double.Parse(SqlDtr1.GetValue(3).ToString());
						registraionfee=double.Parse(SqlDtr1.GetValue(4).ToString());
						dairyfee=double.Parse(SqlDtr1.GetValue(6).ToString());
						tutionfee=double.Parse(SqlDtr1.GetValue(7).ToString());
						computerfee=double.Parse(SqlDtr1.GetValue(8).ToString());
						sciencefee=double.Parse(SqlDtr1.GetValue(9).ToString());
						housefee=double.Parse(SqlDtr1.GetValue(15).ToString());
						gamefee=double.Parse(SqlDtr1.GetValue(10).ToString());
						annualfee=double.Parse(SqlDtr1.GetValue(13).ToString());
						admissionfee=double.Parse(SqlDtr1.GetValue(12).ToString());
						transportfee=double.Parse(SqlDtr1.GetValue(11).ToString());
						developmentfee=double.Parse(SqlDtr1.GetValue(14).ToString());
						total=double.Parse(SqlDtr1.GetValue(16).ToString());
						DateTime period=System.Convert.ToDateTime(ToMMddYYYY(GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr1.GetDateTime(17).ToString()))));
						DateTime periodto=System.Convert.ToDateTime(ToMMddYYYY(GenUtil.str2DDMMYYYY(GenUtil.trimDate(SqlDtr1.GetDateTime(18).ToString()))));
						System.TimeSpan diff=periodto.Subtract(period);
						int idays=diff.Days;
						DateTime period1=System.Convert.ToDateTime(ToMMddYYYY(cf));
						DateTime periodto1=System.Convert.ToDateTime(ToMMddYYYY(ct));
						DateTime period2=System.Convert.ToDateTime(ToMMddYYYY(nf));
						DateTime periodto2=System.Convert.ToDateTime(ToMMddYYYY(nt));
						System.TimeSpan diff2=period2.Subtract(period1);
						int idays2=diff2.Days;
						System.TimeSpan diff1=periodto1.Subtract(period1);
						int idays1=diff1.Days;
						int mon=0;
						if((idays/idays1)>0)
							mon=idays/idays1;
						
						if(mon>1)
						{
							annualfee=annualfee/mon;
							developmentfee=developmentfee/mon;
							dairyfee=dairyfee/mon;
							latefee=latefee/mon;
							dairyfee=dairyfee/mon;
							admissionfee=admissionfee/mon;
							transportfee=transportfee/mon;
							tutionfee=tutionfee/mon;
							computerfee=computerfee/mon;
							sciencefee=sciencefee/mon;
							gamefee=gamefee/mon;
							housefee=housefee/mon;
							total=total/mon;
						}
						gtotal+=total;
						advance=total;
						gadvance+=advance;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database Problem");
				CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  feesdecisionmonthlyadv,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return ;
			}
		}
		/// <summary>
		/// this method use to Calculation of Colection Fees data fetch from Recuringreceipt table,Route Table.
		/// </summary>
		public void collectionfees()
		{
			try
			{
				
				gTotal=0;
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr;
				string  strSelect="";
				if(DropClass.SelectedIndex!=0||DropSection.SelectedIndex!=0)
				{
					if(!TxtFrom.Text.Equals("")&&!TxtTo.Text.Equals(""))
					{
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect ="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by rank,student_stream";//added by vishnu
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								rank=SqlDtr.GetString(0).ToString().Trim();
								count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
								stream=SqlDtr.GetString(2).ToString().Trim();
								feeamount=collectionmonthly(rank,stream,feetype[i]);
								Total=count*feeamount;
								gTotal=gTotal+Total;
							}
							SqlDtr.Close();
						}
						for(int i=feetype.Length-2;i<feetype.Length;i++)
						{
							
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							while(SqlDtr.Read())
							{
								rank=SqlDtr.GetString(0).ToString().Trim();
								count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
								stream=SqlDtr.GetString(2).ToString().Trim();
								feeamount=collectionmonthly(rank,stream,feetype[i]);
								Total=count*feeamount;
								gTotal=gTotal+Total;

							}
							SqlDtr.Close();
						}
						strSelect="select (select trfee from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSection.SelectedItem.Text+"' and s.service_bus='Yes' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by s.routeno";
						SqlDtr=obj.GetRecordSet(strSelect);
					
						while(SqlDtr.Read())
						{
							routename=SqlDtr.GetValue(0).ToString().Trim();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=collectionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
						}
						SqlDtr.Close();
					}
				}
			}
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesSearch.aspx,Method  collectionfees,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return;
			}	
		}
		/// <summary>
		/// Calculate monthly Collection Fees based on Rank Stream and fees type
		/// </summary>
		public  double collectionmonthly(string rank,string stream,string fees_type)
		{
			category="";
			double feeamount=0;
			try
			{
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader SqlDtr=null,rdr=null;
				string str="",str1="";
				string startfrom=""; 
				string endto="";
				if(!rank.Equals(""))
				{
					startfrom=GenUtil.ConvertMonthName(TxtFrom.Text);
					startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
					endto=GenUtil.ConvertMonthName(TxtTo.Text);
					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
					System.TimeSpan diff=ToMMddYYYY(TxtTo.Text).Subtract(ToMMddYYYY(TxtFrom.Text));
					int idays=diff.Days;
					int month=(idays+1)/30;
					string duration =startfrom+"-"+endto;
					str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Monthly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
					SqlDtr=obj.GetRecordSet(str);
					if(SqlDtr.Read())
					{
						str1="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='One Time' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
						rdr=obj1.GetRecordSet(str1);
						if(rdr.Read())
						{
							feeamount=double.Parse(rdr[fees_type].ToString());
							if(feeamount!=0)
							{
								rdr.Close();
								SqlDtr.Close();
								return feeamount;
							}
						}
						else
						{
							MessageBox.Show("Please enter one time fees in Fees Decision table");
							return 0;
						}
						rdr.Close();
												
						if(startfrom.Equals("April"))
						{
							str="select * from feesdecision where class_id=(select class_id from class where class_name='"+DropClass.SelectedItem.Text+"') and Student_Stream='"+stream+"' and feemode='Yearly' and srank='"+rank+"' and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
							rdr=obj1.GetRecordSet(str);
							if(rdr.Read())
							{
								feeamount=double.Parse(rdr[fees_type].ToString());
								if(feeamount!=0)
								{
									rdr.Close();
									SqlDtr.Close();
									return feeamount;
								}
							}
							else
							{
								MessageBox.Show("Please enter the yearly fees in Fees Decision table");
								rdr.Close();
								SqlDtr.Close();
								return 0;
							}
							rdr.Close();
						}
						if(month>=0)
						{
							feeamount=month*double.Parse(SqlDtr[fees_type].ToString());
							SqlDtr.Close();	
							rdr.Close();	
							return feeamount;	
						}
					}
					
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : FeesSearch.aspx,Method  collectionmonthly,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return 0;
			}
			return feeamount;
		}
		
		/// <summary>
		/// this method use to call ConvertIntoExcel() function.
		/// </summary>
		private void Btnexcel_ServerClick(object sender, System.EventArgs e)
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
 		/// this Method use to first call collectionfees() to get total collection of a particular period. after that get data from recuringreceipt table.
		/// after that call feesdecisionmonthly() function.
		/// </summary>
		public void ConvertIntoExcel()
		{

			try
			{
				string home_drive = Environment.SystemDirectory;
				home_drive = home_drive.Substring(0,2);

				string strExcelPath  = home_drive+"\\eSchool_ExcelFile\\";
				Directory.CreateDirectory(strExcelPath);
				string path = home_drive+@"\eSchool_ExcelFile\ReconcilationReport.xls";

				//string path = home_drive + @"\Inetpub\wwwroot\eschool\Sysitem\eSchoolPrintService\ReconcilationReport.txt";
				StreamWriter sw = new StreamWriter(path); 
				SqlConnection conNorthwind;
				conNorthwind =new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				conNorthwind.Open();
				string  strSelect="";
				InventoryClass obj=new InventoryClass();
				SqlDataReader SqlDtr=null;
				if(DropClass.SelectedIndex!=0||DropSection.SelectedIndex!=0)
				{
					if(!TxtFrom.Text.Equals("")&&!TxtTo.Text.Equals(""))
					{
						
						string des="|---------------+-----------+-------------+-------------+------------|";
						//sw.WriteLine(GenUtil.GetCenterAddr("No.1 Air Force School",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("COLLECTION DETAILS OF FEES",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS WISE QUARTERLY FEES FOR THE MONTH   "+ TxtFrom.Text.Trim() + " TO "+TxtTo.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("CLASS "+ DropClass.SelectedItem.Text.Trim()+" "+DropSection.SelectedItem.Text.Trim(),des.Length));
						sw.WriteLine(GenUtil.GetCenterAddr("------------------------------------------------------------------",des.Length));
						//info = " {0,-5:S} {1,-6:S} {2,-5:S} {3,-15:S} {4,-5:S} {5,-4:S} {6,-5:S} {7,-5:S} {8,-5:S} {9,-4:S} {10,-5:S} {11,-5:S} {12,-4:S} {13,-5:S} {14,-5:S} {15,-5:S} {16,-5:S} {17,-5:S} {18,-6:S}";
						string info = " {0,-15:S}    {1,-11:S} {2,10:S} {3,13:S} {4,12:S}";
						string info4=" {0,-26:S}     {1,10:S} {2,13:S} {3,12:S}" ;
						string info2=" Grand Total                                             {0,12:S}" ;
						string info5="Less:-{0,-49:S} {1,12:S}";
						//sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						sw.WriteLine("RANK\tSTREAM\tFEE RATE\tSTRENGTH\tAMOUNT");
						//sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						for(int i=0;i<feetype.Length-2;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"' and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"'  group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)1);
							//sw.WriteLine(feetypeT[i]);
							sw.WriteLine("\t\t"+feetypeT[i]+"\t\t");
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)0);
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= collectionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(rank.ToString()+"\t"+stream.ToString()+"\t"+feeamount.ToString()+"\t"+count.ToString()+"\t"+Total.ToString());
								}
							}
							SqlDtr.Close();
						}
						for(int i=feetype.Length;i<feetype.Length;i++)
						{
							strSelect="select rank,count(rank),student_stream from student_record where student_class='"+DropClass.SelectedItem.Text+"' and Seq_Student_id='"+DropSection.SelectedItem.Text+"'  and student_id not in (select student_id from recuringreceipt)  and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' group by rank,student_stream";
							SqlDtr=obj.GetRecordSet(strSelect);
							
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)1);
							sw.WriteLine("\t\t"+feetypeT[i]+"\t\t");
							sw.Write((char)27);
							sw.Write((char)45);
							sw.Write((char)0);
							if(SqlDtr.HasRows)
							{
								while(SqlDtr.Read())
								{
									rank=SqlDtr.GetString(0).ToString().Trim();
									count=System.Convert.ToInt32(SqlDtr.GetValue(1).ToString().Trim());
									stream=SqlDtr.GetString(2).ToString().Trim();
									feeamount= collectionmonthly(rank,stream,feetype[i]);
									Total=count*feeamount;
									gTotal=gTotal+Total;
									sw.WriteLine(rank.ToString()+"\t"+stream.ToString()+"\t"+feeamount.ToString()+"\t"+count.ToString()+"\t"+Total.ToString());
								}
							}
							SqlDtr.Close();
						}
						/*strSelect="select (select trfee from route r where r.route_id= s.routeno),  s.routeno,count(s.routeno) from student_record s where s.student_class='"+DropClass.SelectedItem.Text+"' and s.Seq_Student_id='"+DropSection.SelectedItem.Text+"' and (s.service_bus='Yes' and s.routeno!=0) and student_admissiondate <='"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"' group by s.routeno";// add by vikas sharma 03.03.08
						SqlDtr=obj.GetRecordSet(strSelect);
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)1);
						sw.WriteLine("TRANSPORT FEE");
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)0);
						double []fees=new double[100];
						double []count1=new double[100];
						double []feesamount1=new double[100];
						int c=0,n=0;
						while(SqlDtr.Read())
						{
							routename=SqlDtr.GetValue(0).ToString();
							routeid=SqlDtr.GetValue(1).ToString().Trim();
							count=System.Convert.ToInt32(SqlDtr.GetValue(2).ToString().Trim());
							feeamount=collectionmonthly(routeid);
							Total=count*feeamount;
							gTotal=gTotal+Total;
							if(c==0)
							{
								fees[c]=System.Convert.ToDouble(routename);
								c++;
							}
							for(int j=0;j<c;j++)
							{						
								if(fees[j]==System.Convert.ToDouble(routename))
								{
									fees[j]=System.Convert.ToDouble(routename);
									count1[j]+=System.Convert.ToDouble(count);
									feesamount1[j]=System.Convert.ToDouble(feeamount);
								}
								else
								{
									fees[c]=System.Convert.ToDouble(routename);
									count1[c]=System.Convert.ToDouble(count);
									feesamount1[c]=System.Convert.ToDouble(feeamount);
									c++;
								}
							}
							n++;	
						}
						for(int j=0;j<c;j++)
						{
							sw.WriteLine(fees[j].ToString()+"\t"+stream.ToString()+"\t"+feesamount1[j].ToString()+"\t"+count1[j].ToString()+"\t"+(count1[j]*feesamount1[j]).ToString());			
						}
						SqlDtr.Close();
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)1);
						sw.WriteLine("LATE FEE");
						sw.Write((char)27);
						sw.Write((char)45);
						sw.Write((char)0);
						double late=0;
						strSelect="select sum(latefee) from recuringreceipt where student_id in(select student_id from student_record where student_class='"+DropClass.SelectedItem.Text+"' and seq_student_id='"+DropSection.SelectedItem.Text+"') and feesubdt between '"+GenUtil.str2MMDDYYYY(TxtFrom.Text.ToString())+"' and '"+GenUtil.str2MMDDYYYY(TxtTo.Text.ToString())+"'";      
						SqlDtr=obj.GetRecordSet(strSelect);
						while(SqlDtr.Read())
						{
							if(SqlDtr.GetValue(0)!=null && SqlDtr.GetValue(0).ToString()!="")
							{
								late=Convert.ToDouble(SqlDtr.GetValue(0));
							}
							else
							{
								late=0;
							}
							sw.WriteLine("\t\t\t\t"+late.ToString());
						}
						SqlDtr.Close();
						gTotal=gTotal+late;*/
						gTotal=gTotal;
						SqlDtr.Close();
						sw.WriteLine("                                                         ------------");
						//sw.WriteLine(info2,gTotal.ToString());
						sw.WriteLine("Grand Total\t\t\t\t"+gTotal.ToString());
						sw.WriteLine("                                                         ------------");
						sw.WriteLine(GenUtil.TrimLength(remark.Text.Trim(),49)+"\t"+amount.Text.Trim().ToString());
						//sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");
						//sw.WriteLine(info2,gTotal.ToString());
						sw.WriteLine("Grand Total\t\t\t\t"+gTotal.ToString());
						//sw.WriteLine("|---------------+-----------+-------------+-------------+------------|");

					}
				}			
				sw.WriteLine("    --------------------------------------------------");
				sw.WriteLine("    Reconcilation Report From "+TxtFrom.Text.Trim()+ " To " +TxtTo.Text.Trim());
				sw.WriteLine("    --------------------------------------------------");
				sw.WriteLine("");
				sw.WriteLine("");
				string info1=" Due Of Last Quarter                            {0,10:S} ";
				//sw.WriteLine(info1,GenUtil.strNumericFormat(LastDue.ToString()));
				sw.WriteLine("Due Of Last Quarter\t\t\t\t"+GenUtil.strNumericFormat(LastDue.ToString()));
				sw.WriteLine("");
				string info6=" {0,-45:S}{1,12:S}";
				sw.WriteLine(GenUtil.TrimLength(txtRemothers.Text.ToString(),45)+"\t"+GenUtil.strNumericFormat(txtOthers.Text.ToString()));
				info1=" Due Of Current Quarter			        {0,10:S} ";
				//sw.WriteLine(info1,GenUtil.strNumericFormat(AmountDue.ToString()));
				sw.WriteLine("Due Of Last Quarter\t\t\t\t"+GenUtil.strNumericFormat(AmountDue.ToString()));
				sw.WriteLine("");
				info1=" Total Due        			        {0,10:S} ";
				sw.WriteLine(" ---------------------------------------------------------");
				//sw.WriteLine(info1,GenUtil.strNumericFormat(DTotal.ToString()));
				sw.WriteLine("Total Due \t\t\t\t"+GenUtil.strNumericFormat(DTotal.ToString()));
				sw.WriteLine(" ---------------------------------------------------------");
				sw.WriteLine("");
				info1=" Previous Advance         			{0,10:S} ";
				//sw.WriteLine(info1,GenUtil.strNumericFormat(PreviousAdvance.ToString()));
				sw.WriteLine("Previous Advance \t\t\t\t"+GenUtil.strNumericFormat(PreviousAdvance.ToString()));
				sw.WriteLine("");
				info1=" Advance Collect For Next Quarter	        {0,10:S} ";
				//sw.WriteLine(info1,GenUtil.strNumericFormat(AdvanceNext.ToString()));
				sw.WriteLine("Advance Collect For Next Quarter\t\t\t\t"+GenUtil.strNumericFormat(AdvanceNext.ToString()));
				sw.WriteLine("");
				info1=" Total Collection In This Quarter	        {0,10:S} ";
				//sw.WriteLine(info1,GenUtil.strNumericFormat(TotalCollection.ToString()));
				sw.WriteLine("Total Collection In This Quarter\t\t\t\t"+GenUtil.strNumericFormat(TotalCollection.ToString()));
				info1=" Due For The Quarter                            {0,10:S} ";
				sw.WriteLine("");
				sw.WriteLine(" ---------------------------------------------------------");
				//sw.WriteLine(info1,GenUtil.strNumericFormat(GrandDue.ToString()));
				sw.WriteLine("Due For The Quarter\t\t\t\t"+GenUtil.strNumericFormat(GrandDue.ToString()));
				sw.WriteLine(" ---------------------------------------------------------");
				sw.Close(); 
				//Print();
			}
			
			catch(Exception ex)
			{
				CreateLogFiles.ErrorLog(" Form :FeesSerch.aspx,Method  PageLoad,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
			}	

		}
		private void amount_TextChanged(object sender, System.EventArgs e)
		{
		
		}


		/// <summary>
		/// this method use to Calculate monthly Collection Fees based on logistic root wise
		/// </summary>
		public  double collectionmonthly(string rootid)
		{
			category="";
			double feeamount=0;
			
			try
			{
				InventoryClass obj=new InventoryClass();
				InventoryClass obj1=new InventoryClass();
				SqlDataReader rdr=null;
				string str1="";
				string startfrom=""; 
				string endto="";
				
				if(!rank.Equals(""))
				{
					startfrom=GenUtil.ConvertMonthName(TxtFrom.Text);
					startfrom=startfrom.Substring(0,startfrom.Trim().Length-4).Trim();
					endto=GenUtil.ConvertMonthName(TxtTo.Text);
					endto=endto.Substring(0,endto.Trim().Length-4).Trim();
					System.TimeSpan diff=ToMMddYYYY(TxtTo.Text).Subtract(ToMMddYYYY(TxtFrom.Text));
					int idays=diff.Days;
					int month=(idays+1)/30;
					string duration =startfrom+"-"+endto;
					if(month>=0)
					{
						if(!startfrom.Equals("")&&!endto.Equals(""))
						{
							if(startfrom.Equals("April") &&(DropClass.SelectedItem.Text.Trim().Equals("XI")))
							{
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=(month-3)*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
							else if(startfrom.Equals("April"))
							{
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";
								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=(month-1)*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
							else
							{
								str1="select trfee from route where route_id="+rootid+" and fromdate<='"+GenUtil.str2MMDDYYYY(TxtFrom.Text)+"' and todate>='"+GenUtil.str2MMDDYYYY(TxtTo.Text)+"'";

								rdr=obj1.GetRecordSet(str1);
								if(rdr.Read())
								{
									feeamount=month*double.Parse(rdr["trfee"].ToString());
								}
								else
								{
									feeamount=0;
								}
								rdr.Close();
							}
						}
						else
						{
							feeamount=0;
						}
								
						return feeamount;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Some Database problem");
				CreateLogFiles.ErrorLog(" Form : FeesSearch.aspx,Method  collectionmonthly,  Exception: "+ex.Message+" , Userid :  "+ pass   );		
				return 0;
			}
			return feeamount;
		}
	}
}

