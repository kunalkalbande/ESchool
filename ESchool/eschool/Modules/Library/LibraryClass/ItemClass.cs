/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/

using System;
using System.Data .SqlClient ;
using System.Data;
using RMG;

namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for ItemClass.
	/// </summary>
	public class ItemClass
	{
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqred;
		SqlDataAdapter sqdr;
		DataSet ds;

		#region vars&Prop
		string _Book_ID;
		string _Book_Name;
		string _Author_Name;
		string _Publisher_Name;
		string  _bprice;
		string _PurchaseID;
		string _bookname;
		string _aname;
		string _pname;
		string _rackno;
		string _remark;
		string _pdate;
		int _Qty;
		string _subname;
	
		
		public string subname
		{
			get
			{
				return _subname;
			}
			set
			{
				_subname=value;
			}
		}
		
		
		public int Qty
		{
			get
			{
				return _Qty;
			}
			set
			{
				_Qty=value;
			}
		}
		public string remark
		{
			get
			{
				return _remark;
			}
			set
			{
				_remark=value;
			}
		}
		
		public string pdate
		{
			get
			{
				return _pdate;
			}
			set
			{
				_pdate=value;
			}
		}
		
		
		public string rackno
		{
			get
			{
				return _rackno;
			}
			set
			{
				_rackno=value;
			}
		}
		public string bookname
		{
			get
			{
				return _bookname;
			}
			set
			{
				_bookname=value;
			}
		}

		public string aname
		{
			get
			{
				return _aname;
			}
			set
			{
				_aname=value;
			}
		}
		
		public string pname
		{
			get
			{
				return _pname;
			}
			set
			{
				_pname=value;
			}
		}
		
		
		public string Book_ID
		{
			get
			{
				return _Book_ID;
			}
			set
			{
				_Book_ID=value;
			}
		}


		public string PurchaseID
		{
			get
			{
				return _PurchaseID;
			}
			set
			{
				_PurchaseID=value;
			}
		}

		public string Book_Name
		{
			get
			{
				return _Book_Name;
			}
			set
			{
				_Book_Name=value;
			}
		}
		public string Author_Name
		{
			get
			{
				return _Author_Name;
			}
			set
			{
				_Author_Name=value;
			}
		}

		public string Publisher_Name
		{
			get
			{
				return _Publisher_Name;
			}
			set
			{
				_Publisher_Name=value;
			}
		}

		public string bprice
		{
			get
			{
				return _bprice;
			}
			set
			{
				_bprice=value;
			}
		}

		#endregion 

		#region For Connecting string
		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public ItemClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}
		#endregion

		#region 
		/// <summary>
		/// this method use to insert book information
		/// </summary>
		public void InsertItem()
		{ 
		
			sqcom=new SqlCommand("proInsertItem",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add ("@Book_ID",Book_ID);
			sqcom.Parameters .Add("@bprice",bprice);
			//sqcom.Parameters.Add("@PurchaseID",PurchaseID);
			sqcom.Parameters.Add("@bookname",bookname);
			sqcom.Parameters.Add("@aname",aname);
			sqcom.Parameters.Add("@pname",pname);
			sqcom.Parameters .Add("@rackno",rackno);
			sqcom.Parameters .Add("@remark",remark);
			sqcom.Parameters .Add("@pdate",pdate);
			sqcom.Parameters .Add("@Qty",Qty);
			sqcom.Parameters .Add("@Subname",subname);
			sqcom.ExecuteNonQuery();

		}
		#endregion

		#region 
		
		/// <summary>
		/// Funtion for save information in to dataset. 
		/// </summary>
		public DataSet ShowBookInformation()
		{
			sqdr=new SqlDataAdapter("proShowBookinformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}

		/// <summary>
		/// this method use to fetch data from stock_table and save in dataview and return dataview.
		/// </summary>
		// 03.10.08 public DataSet ShowBookInfo(string search,string str)
		public DataView ShowBookInfo(string search,string str)
		{
			//sqdr=new SqlDataAdapter("proShowBookinformation",sqcon);
			string sql="";
			if(search=="Book Wise")
				//sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where bookname='"+str+"'";
				sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where book_id='"+str+"'";
			else if(search=="Rack Wise")
				sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where rackno='"+str+"'";
			else if(search=="Subject Wise")
				sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where subname='"+str+"'";
			else if(search=="Remark Wise")
				sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where remark='"+str+"'";
			else
				sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table order by bookname";
			sqdr = new SqlDataAdapter(sql,sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			DataTable dt=ds.Tables[0];                  //add by vikas sharma 03.10.08
			DataView dv=new DataView(dt);				//add by vikas sharma 03.10.08
			sqcon.Close();
			sqcon.Dispose();
			//return ds;
			return dv;                                  //add by vikas sharma 03.10.08
		}
		#endregion
			
		/// <summary>
		/// this method use to fetch data from stock_table and save in dataset and return dataset.
		/// </summary>
		public DataSet ShowIssueBookInfo(string search,string str)
		{
			//sqdr=new SqlDataAdapter("proShowBookinformation",sqcon);
			string sql="";
			if(search=="Staff Wise")
			{
				if(str=="All")
				{
					sql="select distinct ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig ,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No,cg.class from Stock_table st,Card_Generation cg,Issue_Book ib,staff_information s where ib.Book_ID=st.Book_ID and ib.memberid=cg.memberid and cg.desig=s.staff_type";		 
				}
				//sql="select distinct ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig ,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No from Stock_table st,Card_Generation cg,Issue_Book ib where ib.Book_ID=st.Book_ID and cg.memberid=ib.memberid and cg.desig='"+str+"'";
				sql="select distinct ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig ,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No from Stock_table st,Card_Generation cg,Issue_Book ib where ib.Book_ID=st.Book_ID and cg.memberid=ib.memberid and cg.desig='"+str+"'";
				//sql="select book_id,bookname,aname,pname, pdate,remark,rackno , price,subname ,qty from Stock_table where bookname='"+str+"'";
			}
			else if(search=="Student Wise")
				sql="select distinct ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No,cg.class from Stock_table st,Card_Generation cg,Issue_Book ib where ib.Book_ID=st.Book_ID and cg.memberid=ib.memberid and cg.class='"+str+"'";
			else 
				//sql="select distinct ib.Book_ID,st.bookname,ib.memberID,cg.Name_Of_Librarian,cg.desig ,ib.Date_Of_Issue,ib.Return_Date,cg.Card_No,cg.class from Stock_table st,Card_Generation cg,Issue_Book ib where ib.Book_ID=st.Book_ID and cg.memberid=ib.memberid";
				sql="select distinct ib.Book_ID,st.bookname,ib.memberID,ib.Date_Of_Issue,ib.Return_Date from Stock_table st,Issue_Book ib where ib.Book_ID=st.Book_ID ";
			sqdr = new SqlDataAdapter(sql,sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}

		/// <summary>
		/// this method use to get some information after that return a sql query.
		/// </summary>
		//public DataSet ShowIssuestudentInfo(string search,string str)
		public string ShowIssuestudentInfo(string search,string str)
		{
			//ds=new DataSet();
			string sql="";
			if(search=="Category Wise")
			{
				if(str=="All")
					//21.02.09 sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where Student_Category!='' order by student_class,seq_student_id,Student_fname";  //add by vikas sharma date 6.11.2007
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where Student_Category!='' order by student_class,seq_student_id,Student_fname";  //add by vikas sharma date 6.11.2007
						
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record where Student_Category!=''";
				else
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record  where Student_Category='"+str+"' ";
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Category='"+str+"' order by student_class,seq_student_id,Student_fname";  //add by vikas sharma date on 6.11.2007
						
			}
			else if(search=="Rank Wise")
			{
				if(str=="All")
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record";
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
				else
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record  where rank='"+str+"' ";
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where rank='"+str+"' order by student_class,seq_student_id,Student_fname";   //add by vikas sharma date on 6.11.2007
			}
			else if(search=="SCategory Wise")
			{
				if(str=="All")
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record";
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record order by student_class,seq_student_id,Student_fname";    //add by vikas sharma date on 6.11.2007
				else
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record  where scategory='"+str+"' ";
					sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where scategory='"+str+"' order by student_class,seq_student_id,Student_fname ";     //add by vikas sharma date on 6.11.2007
			}
			else if(search=="StudentID Wise")
			{
				//21.02.09 if(str.ToUpper()=="ALL")
					//21.02.09 sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName,Student_LCity,Student_LState from  Student_Record";
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record order by student_class,seq_student_id,Student_fname";
				//21.02.09 else
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record  where Student_ID='"+str+"' ";
					//sql="select distinct Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_ID='"+str+"' order by student_class,seq_student_id,Student_fname";   //add by vikas sharma date 22.02.08
					//23.02.08--sql="select distinct Student_ID,Seq_Student_id,Student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_ID='"+str+"' order by student_class,seq_student_id,Student_fname";
					sql="select distinct Student_ID,Seq_Student_id,Student_pcity,student_pstate, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName,Student_LCity,Student_LState  from  Student_Record  where Student_ID='"+str+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname";
			}
			//sqdr = new SqlDataAdapter(sql,sqcon);
				
			//sqdr.Fill(ds);
			//sqcon.Close();
			//sqcon.Dispose();
			return sql;
		}

		/// <summary>
		/// this method use to get some information after that return a sql query.
		/// </summary>
		public string ShowIssuestudentInfo(string search,string str,string Sec)
		{
			string sql="";
		
			if(search=="Class Wise")
			{
				if(str=="All")
					//02.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
					//23.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where  student_id not in (select student_id from tc1) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where  student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
					//sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record";
				else
				{   
					
					if(Sec=="All")
						//sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record where student_class='"+str+"'";
						//02.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where student_class='"+str+"'order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
						//23.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where student_class='"+str+"' and student_id not in (select student_id from tc1) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 6.11.2007
						sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record where student_class='"+str+"' and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname"; //add by vikas sharma date on 22.02.2008
					else
						//sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo from  Student_Record  where Student_Class='"+str+"' and seq_student_id='"+Sec+"'";
						//02.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Class='"+str+"' and seq_student_id='"+Sec+"'order by student_class,seq_student_id,Student_fname";     //add by vikas sharma date on 6.11.2007
						//23.02.08--sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Class='"+str+"' and seq_student_id='"+Sec+"'and student_id not in (select student_id from tc1) order by student_class,seq_student_id,Student_fname";     //add by vikas sharma date on 6.11.2007
						sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Category,Student_FatherMobileno,Student_Class,Student_Stream,house,Student_AdmissionDate,Student_BirthDate,Student_PAddress,Student_PHNo,Student_FatherName from  Student_Record  where Student_Class='"+str+"' and seq_student_id='"+Sec+"'and student_id not in (select student_id from tc1 union  select student_id from  Stuck_Off) order by student_class,seq_student_id,Student_fname";     //add by vikas sharma date on 22.02.2008
				}
			}
			//sqdr = new SqlDataAdapter(sql,sqcon);
			//ds=new DataSet();
			//sqdr.Fill(ds);
			//sqcon.Close();
			//sqcon.Dispose();
			return sql;
		}

		#region for show student route info

		/// <summary>
		/// this method use to get some information after that return a sql query.
		/// </summary>
		//public DataSet ShowstudentrouteInfo(string search,string str)
		public string ShowstudentrouteInfo(string search,string str)
		{
			string sql="";
			//			if(search.Equals("Class Wise"))
			//			{
			//				if(str=="All")
			//					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record  where service_bus='Yes'";
			//					//sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record";
			//
			//				else
			//					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record   where service_bus='Yes' and Student_Class='"+str+"'";
			//			}
			if(search=="Route Name Wise")
			{
				if(str=="All")
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record  where service_bus='Yes'";
					//sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record";

				else
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record   where routename='"+str+"'";
			}
			else if(search=="Route No Wise")
			{
				if(str=="All")
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record where service_bus='Yes'";
				else
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record   where routeno='"+str+"'";
			}
			
			else if(search=="StudentID Wise")
			{
				if(str=="All")
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record where service_bus='Yes'";
				else
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record   where Student_ID='"+str+"'";
			}
			//			sqdr = new SqlDataAdapter(sql,sqcon);
			//			ds=new DataSet();
			//			sqdr.Fill(ds);
			//			sqcon.Close();
			//			sqcon.Dispose();
			//			return ds;
			return sql;
		}

		//public DataSet ShowstudentrouteInfo(string search,string str,string Sec)
		/// <summary>
		/// this method use to get some information after that return a sql query.
		/// </summary>
		public string ShowstudentrouteInfo(string search,string str,string Sec)
		{
			string sql="";
		
			if(search=="Class Wise")
			{
				if(str=="All")
					sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record where service_bus='Yes'";
				else
				{   
					if(Sec=="All")
						sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record  where  service_bus='Yes' and student_class='"+str+"'";
					else
						sql="select Student_ID,Seq_Student_id, Student_FName,scategory,rank,Student_Class,Student_Stream,Student_PAddress,Student_PHNo,routename,routeno,bg from  Student_Record where service_bus='Yes' and Student_Class='"+str+"' and seq_student_id='"+Sec+"'";
				}
			}
			
			//			sqdr = new SqlDataAdapter(sql,sqcon);
			//			ds=new DataSet();
			//			sqdr.Fill(ds);
			//			sqcon.Close();
			//			sqcon.Dispose();
			//			return ds;
			return sql;
		}
		#endregion 

		#region for show employee info
		/// <summary>
		/// this method use to get some information after that return a sql query.
		/// </summary>
		public DataSet ShowstaffInfo(string search,string str)
		{
			string sql="";
			if(search=="Group D")
			{
				if(str=="All")
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where groupd='1'";
				else
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+str+"' ";
			}
			else if(search=="Teaching")
			{
				if(str=="All")
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where teaching='1'";
				else
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+str+"' ";
			}
			else if(search=="Non Teaching")
			{
				if(str=="All")
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information where nonteaching='1'";
				else
					sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information  where staff_type='"+str+"' ";
			}
		
			else if(search=="All")
			{
				sql="select staff_ID,Staff_Type,Staff_Name,Staff_LocalAddress,Staff_EmailID,Phone_No,Mobile_No,Subject_Take,Staff_education,Staff_exp,prof_qui,sex,maritial_status,doj,age,father_name,natapp from  staff_information ";
			
			}
			sqdr = new SqlDataAdapter(sql,sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}
		//
		//
		#endregion
		/// <summary>
		/// Select Auto Increment Book Id And Auto Generated
		/// </summary>
		public SqlDataReader  getBookID()
		{
			sqcom=new SqlCommand ("select max(Book_ID)+1 from Stock_table",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		//Method for getting the Detail of book.
		//		public SqlDataReader  ShowBookInformationPrint()
		//		{
		//		
		//			sqcom=new SqlCommand ("select st.book_id, p.book_name,p.author_name,p.publisher_name, p.no_of_book   quantity  from Stock_table st , purchaseorder p where st.purchaseid=p.purchaseid",sqcon);
		//			sqred=sqcom.ExecuteReader();
		//			return sqred;
		//		}

		/// <summary>
		/// Method for generating the unique bookid for every copy of perticular book.
		/// </summary>
		public void unique()
		{
			try
			{
				sqcom=new SqlCommand ("select max(LongBook_ID)+1 from uniquebook",sqcon);
				sqred=sqcom.ExecuteReader();
			 
				string str1="";
				while(sqred.Read())
				{
					str1=sqred.GetValue(0).ToString();
				}
				sqred.Close();
				if(str1.Equals("")||str1==null)
				{
					str1="0";
				}
				int longBookid=int.Parse(str1);

				int no=int.Parse(bprice);
				// Mahesh :- This loop returns more then one book. 
				//for(int i=0;i<=no;i++)
				for(int i=0;i<no;i++)
				{
					string str=Book_ID+"-"+i;
				
				
					sqcom=new SqlCommand("insert uniquebook (book_ID,ubook_ID,LongBook_Id,Candidate_id) values(@bookid1 ,@ubookid,@LongBookID,'0')",sqcon);
					sqcom.Parameters.Add("@bookid1",Book_ID);
					sqcom.Parameters.Add("@ubookid",str);
					sqcom.Parameters.Add("@LongBookID",longBookid);
					sqcom.ExecuteNonQuery();
 
					longBookid=longBookid+1;
				}

	
			}
	 
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
	
	
		}
	}
}


