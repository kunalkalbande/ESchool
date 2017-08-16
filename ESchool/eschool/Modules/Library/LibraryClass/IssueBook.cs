
/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/
using System;
using System.Data .SqlClient;
using System.Data;

namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for IssueBook.
	/// </summary>
	public class IssueBook
	{
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqred;
		SqlDataAdapter sqdr;
        DataSet ds;

		#region vars & Prop
		string _CandidateID;
		string _IssueBookID;
		string _Card_No;
		string _Book_ID;
		string _Book_Name;
		string _Date_Of_Issue;
		string _Return_Date;
		string _quantity;
		string _Book_ID1;
		string _PurID;
		string _memberID;
		string _MemType;
		
		public string memberID
		{
			get
			{
				return _memberID;
			}
			set
			{
				_memberID=value;
			}

		}
		
		
		
		
		
		
		public string PurID
		{
			get
			{
				return _PurID;
			}
			set
			{
				_PurID=value;
			}

		}

		public string MemType
		{
			get
			{
				return _MemType;
			}
			set
			{
				_MemType=value;
			}
		}

		public string Book_ID1
		{
			get
			{
				return _Book_ID1;
			}
			set
			{
				_Book_ID1=value;
			}
		}

        
		public string CandidateID
		{
			get
			{
				return _CandidateID;
			}
			set
			{
				_CandidateID=value;
			}
		}

		public string IssueBookID
		{
			get
			{
				return _IssueBookID;
			}
			set
			{
				_IssueBookID=value;
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

		public string Card_No
		{
			get
			{
				return _Card_No;
			}
			set
			{
				_Card_No=value;
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

		public string Date_Of_Issue
		{
			get
			{
				return _Date_Of_Issue;
			}
			set
			{
				_Date_Of_Issue=value;
			}
		}

		public string Return_Date
		{
			get
			{
				return _Return_Date;
			}
			set
			{
				_Return_Date=value;
			}
		}

		public string quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				_quantity=value;
			}
		}
		#endregion

		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public IssueBook()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to select book id from stock_table.
		/// </summary>
		public SqlDataReader  showBookID()
		{
			sqcom=new SqlCommand ("select Book_ID,Bookname from Stock_table",sqcon);
			//sqcom=new SqlCommand ("select Book_ID,Bookname from Stock_table where subname='SST'",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// this method use to fetch some data from uniqebook.
		/// </summary>
		/// <returns></returns>
		public SqlDataReader  showUBookID()
		{
	
			sqcom=new SqlCommand ("select distinct  UBook_ID from uniqueBook where candidate_ID!='0'",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	
		/// <summary>
		/// this method use to insert book information in to stock_table with the help of 'proInsertIssueBook' procedure.
		/// </summary>
		public void InsertItemIssueBook()
		{ 
		
			sqcom=new SqlCommand("proInsertIssueBook",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@IssueBookID",IssueBookID);
			//sqcom.Parameters .Add("@CandidateID",CandidateID);
			sqcom.Parameters .Add("@memberID",memberID);
			sqcom.Parameters .Add("@Book_ID",Book_ID);
		    sqcom.Parameters .Add("@MemType",MemType);
			sqcom.Parameters .Add("@Date_Of_Issue",Date_Of_Issue);
			sqcom.Parameters .Add("@Return_Date",Return_Date);
		 
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// Method for getting the Book information.
		/// </summary>
		public DataSet ShowIssueBookInformation()
		{
			sqdr=new SqlDataAdapter("ProShowIssBookInformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;

		}

		/// <summary>
		/// Method for getting the maximum candidate id from membership table.
		/// </summary>
		public SqlDataReader  getCandidateIDIssueBook()
		{
		
			sqcom=new SqlCommand ("select max(candidateID) from membership",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the book information.
		/// </summary>
		public SqlDataReader  ShowBookonBookID(string str)
		{
			sqcom=new SqlCommand ("select Book_ID from Stock_table",sqcon);
			sqcom=new SqlCommand (str,sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to fetch from card_generation.
		/// </summary>
		public SqlDataReader  getCardNumber()
		{
			sqcom=new SqlCommand ("select max(Card_NO) from Card_Generation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the quentity of selected book id from stock.
		/// </summary>
		public SqlDataReader  getQuantity(string sql)
		{
			sqcom=new SqlCommand (sql,sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to show book name.
		/// </summary>
		public SqlDataReader  selectedBookname()
		{
			sqcom=new SqlCommand ("select Book_Name from Stock_table",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to getting the book name.
		/// </summary>
		public SqlDataReader  Bname()
		{
			sqcom=new SqlCommand ("proshowName",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Book_ID",Book_ID);
          	sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Search For book Where Selected Book ID. 
		/// </summary>
		public void SearchInfo()
		{
			sqcom=new SqlCommand ("procsearchB",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure;
			sqcom.Parameters .Add("@Book_ID",Book_ID);
            sqcom.ExecuteReader();
		}

		/// <summary>
		/// Search For Card Number Where Selected CandidateID
		/// </summary>
		public SqlDataReader  SearchCardNo()
		{
		
			sqcom=new SqlCommand ("procCardNo",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@memberID",memberID);
			//sqcom.Parameters .Add ("@Card_No",Card_No); 
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
//getting the issued Book information while returning the book.
//		public SqlDataReader  ReturnBookSearch(string sql)
//		{
//		
//
//			sqcom=new SqlCommand (sql,sqcon);
//			 
//			 
//			 
// 			sqred=sqcom.ExecuteReader();
//			return sqred;
//		}
	
		/// <summary>
		/// getting the issued Book information while returning the book.		
		/// </summary>
		public SqlDataReader  ReturnBookSearch(string bid,string mid)
		{
			sqcom=new SqlCommand ("SelectReturnBook",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@BookID",bid);
			//sqcom.Parameters .Add ("@MemberID",mid);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	
		/// <summary>
		/// this method use to Getting the no.of candidate.	
		/// </summary>
		public SqlDataReader  CandidateCount(string sql)
		{
			sqcom=new SqlCommand (sql,sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the no of card consumed by selected candidate id.		
		/// </summary>
		public SqlDataReader CardCount(string sql)
		{
			sqcom=new SqlCommand (sql,sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// Method for getting the issued book id for returning the book.
		/// </summary>
		public SqlDataReader  ReturnBookID(string sql)
		{
			sqcom=new SqlCommand (sql,sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the issued book id for returning the book.
		/// </summary>
		public SqlDataReader  ReturnBook()
		{
			sqcom=new SqlCommand ("ProSelectReturnBookCandidate",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for deleting the issued book after returning the book by candidate.
		/// </summary>
		public void  DeleteissueBooks()
		{
			sqcom=new SqlCommand ("DeleteReturnBook",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@memberID",memberID );
			sqcom.Parameters .Add ("@Book_ID",Book_ID);
			sqred=sqcom.ExecuteReader();
			 
		}
		/// <summary>
		/// Check whether candidate registered previsly.
		/// </summary>
		public int CheckPurid()
		{
			//sqcom=new SqlCommand("select CandidateID from  membership where CandidateID ='"+ CandidateID+"'",sqcon);
			sqcom=new SqlCommand("select CandidateID from  Card_Generation where memberID ='"+ memberID+"'",sqcon);
			sqred=sqcom.ExecuteReader();
			if(sqred.Read())
			{
				CandidateID=sqred.GetValue(0).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
			
		}
		
	}
}
