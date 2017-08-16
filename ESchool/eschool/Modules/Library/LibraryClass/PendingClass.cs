/*
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
*/


using System;
using System.Data.SqlClient;
using System.Data;


namespace eschool.LibraryClass
{
	/// <summary>
	/// Summary description for PendingClass.
	/// </summary>
	public class PendingClass
	{
		SqlConnection sqcon;
		SqlDataReader sqred;
		SqlCommand sqcom;

		#region vars & Prop 
		string _PurchaseID;
		int _pendingID;
		string _Name_Of_Book;
		string _Author_Name;
		string _Company_Name;
		string _Date_Of_Pending;
		string _No_Of_Book;
		string _Cost_Of_Book;
		string _Total_Cost_Of_Book;
		

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
		public int pendingID
		{
			get{ return _pendingID;}
			set{_pendingID=value;}
		}

		public string Name_Of_Book
		{
			get
			{
				return _Name_Of_Book;
			}
			set
			{
				_Name_Of_Book=value;
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
		public string Company_Name
		{
			get
			{
				return _Company_Name;
			}
			set
			{
				_Company_Name=value;
			}
		}
		public string Date_Of_Pending
		{
			get
			{
				return _Date_Of_Pending ;
			}
			set
			{
				_Date_Of_Pending =value;
			}
		}
		public string No_Of_Book
		{
			get
			{
				return _No_Of_Book;
			}
			set
			{
				_No_Of_Book=value;
			}
		}
		public string Cost_Of_Book
		{
			get
			{
				return _Cost_Of_Book;
			}
			set
			{
				_Cost_Of_Book=value;
			}
		}
		public string Total_Cost_Of_Book
		{
			get
			{
				return _Total_Cost_Of_Book;
			}
			set
			{
				_Total_Cost_Of_Book=value;
			}
		}

		#endregion 
   
		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public  PendingClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}
		
		/// <summary>
		/// this method use to fetch data from purcheseOrder table.
		/// </summary>
		public SqlDataReader  getPuchaseID()
		{
			
			sqcom=new SqlCommand ("select PurchaseID,Book_Name,Author_Name,Publisher_Name from PurchaseOrder",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	}
}
