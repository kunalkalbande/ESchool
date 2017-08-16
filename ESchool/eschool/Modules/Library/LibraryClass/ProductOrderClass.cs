
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
	/// Summary description for ProductOrderClass.
	/// </summary>
	public class ProductOrderClass
	{
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqred;
		SqlDataAdapter sqdr;
		DataSet ds;

		#region
        
		string _PurchaseID;
		string _Book_Name;
		string _Author_Name;
		string _Publisher_Name;
		string _Date_OF_Purchase;
		string _No_OF_Book;
		string _Cost_OF_Book;
		string _Total_Cost_OF_Book;
		string _EmailID;
		string _FromEmailID;
		string _SupplierID;
		string _LOT_No;
		string _BookName;
		string _AuthorName;
		string _Date_Of_Supplie;
		string _Number_Of_Book;
		string _Cost_Of_Book;
		string _Total_Cost_Of_Book;
		string _Company_EmailID;
		string _Status;
		string _BudgetID;
		string _Budget_Issue_Date;
		string _Department_Name;
		string _Issue_Rupees;
		string _Total_Rupees;

		
		


		public string BudgetID
		{
			get
			{
				return _BudgetID;
			}
			set
			{
				_BudgetID=value;
			}

		}
		
		public string Budget_Issue_Date
		{
			get
			{
				return _Budget_Issue_Date;
			}
			set
			{
				_Budget_Issue_Date=value;
			}
		}
		
		public string Department_Name
		{
			get
			{
				return _Department_Name;
			}
			set
			{
				_Department_Name=value;
			}
		}
		
		public string Issue_Rupees
		{
			get
			{
				return _Issue_Rupees;
			}
			set
			{
				_Issue_Rupees=value;
			}
		}
		
		public string Total_Rupees
		{
			get
			{
				return _Total_Rupees;
			}
			set
			{
				_Total_Rupees=value;
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
		public string Date_OF_Purchase
		{
			get
			{
				return _Date_OF_Purchase;
			}
			set
			{
				_Date_OF_Purchase=value;
			}
		}
		public string No_OF_Book
		{
			get
			{
				return _No_OF_Book;
			}
			set
			{
				_No_OF_Book=value;
			}
		}
		public string Cost_OF_Book
		{
			get
			{
				return _Cost_OF_Book;
			}
			set
			{
				_Cost_OF_Book=value;
			}
		}
		public string Total_Cost_OF_Book
		{
			get
			{
				return _Total_Cost_OF_Book;
			}
			set
			{
				_Total_Cost_OF_Book=value;
			}
		}
		public string EmailID
		{
			get
			{
				return _EmailID;
			}
			set
			{
				_EmailID=value;
			}
		}
		public string FromEmailID
		{
			get
			{
				return _FromEmailID;
			}
			set
			{
				_FromEmailID=value;
			}
		}


		
		public string SupplierID
		{
			get
			{
				return _SupplierID;
			}
			set
			{
				_SupplierID=value;
			}
		}

		
		public string LOT_No
		{
			get
			{
				return _LOT_No;
			}
			set
			{
				_LOT_No=value;
			}
		}

		
		public string BookName
		{
			get
			{
				return _BookName;
			}
			set
			{
				_BookName=value;
			}
		}

		
		public string AuthorName
		{
			get
			{
				return _AuthorName;
			}
			set
			{
				_AuthorName=value;
			}
		}

		
		
		
		public string Date_Of_Supplie
		{
			get
			{
				return _Date_Of_Supplie;
			}
			set
			{
				_Date_Of_Supplie=value;
			}
		}

		
		public string Number_Of_Book
		{
			get
			{
				return _Number_Of_Book;
			}
			set
			{
				_Number_Of_Book=value;
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

		
		public string Company_EmailID
		{
			get
			{
				return _Company_EmailID;
			}
			set
			{
				_Company_EmailID=value;
			}
		}
		public string Status
		{
			get
			{
				return _Status;
			}
			set
			{
				_Status=value;
			}
		}

		#endregion

		/// <summary>
		/// this method use to create connection between database.
		/// </summary>
		public  ProductOrderClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method use to Insert Purchase Order
		/// </summary>
		public void insertPurchaseOrder()
		{
			sqcom=new SqlCommand("ProInsertPurchaseOrder",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters .Add("@PurchaseID",PurchaseID);
			sqcom.Parameters.Add("@Book_Name",Book_Name);
			sqcom.Parameters.Add("@Author_Name",Author_Name);
			sqcom.Parameters.Add("@Publisher_Name",Publisher_Name);
			sqcom.Parameters.Add("@Date_OF_Purchase",Date_OF_Purchase);
			sqcom.Parameters.Add("@No_OF_Book",No_OF_Book);
			sqcom.Parameters.Add("@Cost_OF_Book",Cost_OF_Book);
			sqcom.Parameters.Add("@EmailID",EmailID);
			sqcom.Parameters .Add("@FromEmailID",FromEmailID);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to insert budget information through 'ProInsertPurchaseIDBudget' procedure.
		/// </summary>
		public void InsertpurchaseIDINBudget()
		{
			sqcom=new SqlCommand("ProInsertPurchaseIDBudget ",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters .Add("@PurchaseID",PurchaseID);
			sqcom.ExecuteNonQuery();
		}
	 
		/// <summary>
		/// this method use to insert budget from ProInsertBudget procedure.
		/// </summary>
		public void insertBudget()
		{
			sqcom=new SqlCommand("ProInsertBudget",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters .Add("@BudgetID",BudgetID);
			sqcom.Parameters.Add("@Budget_Issue_Date",Budget_Issue_Date);
			sqcom.Parameters.Add("@Department_Name",Department_Name);
			sqcom.Parameters.Add("@Issue_Rupees",Issue_Rupees);
			sqcom.Parameters.Add("@Total_Rupees",Total_Rupees);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to update budget information by 'updateTotalRupees' procedure.
		/// </summary>
		public void udateBudget()
		{
			sqcom=new SqlCommand("updateTotalRupees",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters.Add("@Total_Rupees",Total_Rupees);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to show purchese Order in datagrid.
		/// </summary>
		public DataSet ShowPurchaseOrder()
		{
			sqdr=new SqlDataAdapter("select purchaseid,book_name,author_name,publisher_name,date_of_purchase,no_of_book,cost_of_book,emailid,fromemailid ,No_Of_Book * Cost_Of_Book Total_Cost_Of_Book from purchaseorder",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}
		
		/// <summary>
		/// this method use to get information from purcheseOrder table.
		/// </summary>
		public SqlDataReader ShowPurchaseOrderPrint()
		{
			sqcom=new SqlCommand("select purchaseid,book_name,author_name,publisher_name,date_of_purchase,emailid,no_of_book,cost_of_book,No_Of_Book * Cost_Of_Book Total_Cost_Of_Book from purchaseorder",sqcon);
			sqred = sqcom.ExecuteReader ();
			return sqred;
		}
 
		/// <summary>
		/// this method use to Auto Increment Value of  Purchase ID 
		/// </summary>
		public SqlDataReader  getPurchaseID()
		{
			sqcom=new SqlCommand ("select max(PurchaseID)+1 from PurchaseOrder",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to calculate Total rupees.
		/// </summary>
		public SqlDataReader  GetTotalRupees()
		{
			sqcom=new SqlCommand ("select Total_Rupees from BudgetTable where BudgetID = ( select max(BudgetID)from BudgetTable)",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Auto Increment BudgetId
		/// </summary>
		public SqlDataReader  getBudgetID()
		{
			sqcom=new SqlCommand ("select max(BudgetID)+1 from BudgetTable",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Auto Increment PurchaseID
		/// </summary>
		public SqlDataReader  ShowPurchaseID()
		{
			sqcom=new SqlCommand ("select PurchaseID from PurchaseOrder where purchaseorder.purchaseid!=all(select purchaseid from suppliertable where status='Cleared')",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to show Purchase  Information  for Selected Purchase ID.
		/// </summary>
		public SqlDataReader  ShowPurchaseInfo()
		{
			sqcom=new SqlCommand ("ProShowSupplierInfo",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@PurchaseID",PurchaseID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to show Insert Supplier  Information  
		/// </summary>
		public void InsertSupplierInfo()
		{ 
			sqcom=new SqlCommand("ProInsertSupplierPlacedInfo",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@PurchaseID",PurchaseID);
			sqcom.Parameters .Add("@SupplierID",SupplierID);
			sqcom.Parameters .Add("@LOT_No",LOT_No);
			sqcom.Parameters .Add("@Date_Of_Supplie",Date_Of_Supplie);
			sqcom.Parameters .Add("@Status",Status);
			sqcom.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Update Purchase Order
		/// </summary>
		public void insertUpdatePurchaseOrder()
		{
			sqcom=new SqlCommand("proUpdatePurchaseOrder",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters .Add("@PurchaseID",PurchaseID);
			sqcom.Parameters.Add("@Book_Name",Book_Name);
			sqcom.Parameters.Add("@Author_Name",Author_Name);
			sqcom.Parameters.Add("@Publisher_Name",Publisher_Name);
			sqcom.Parameters.Add("@Date_OF_Purchase",Date_OF_Purchase);
			sqcom.Parameters.Add("@No_OF_Book",No_OF_Book);
			sqcom.Parameters.Add("@Cost_OF_Book",Cost_OF_Book);
			sqcom.Parameters.Add("@Total_Cost_OF_Book",Total_Cost_OF_Book);
			sqcom.Parameters.Add("@EmailID",EmailID);
			sqcom.Parameters .Add("@FromEmailID",FromEmailID);
			//sqcom.Parameters.Add("@rackno",rackno);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to show Receive Information in Data Grid	 
		/// </summary>
		public DataSet ShowReceiveInfo()
		{
			sqdr=new SqlDataAdapter("ProShowReceiveInfo",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}
		
		/// <summary>
		/// this method use to show Receive Information for printing	
		/// </summary>
		public SqlDataReader ShowReceiveInfoPrint()
		{
			sqcom=new SqlCommand("ProShowReceiveInfo",sqcon);
			sqred = sqcom.ExecuteReader ();
			//sqcon.Close ();
			return sqred;
		}

		/// <summary>
		/// this method use to show Pending Information in Data Grid			
		/// </summary>
		public DataSet ShowPendingInfo()
		{
			sqdr=new SqlDataAdapter("ProShowPendingInfo",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;
		}

		/// <summary>
		/// this method use to show pending details 
		/// </summary>
		public SqlDataReader ShowPendingInfo1()
		{
			sqcom=new SqlCommand("ProShowPendingInfo",sqcon);
			sqred = sqcom.ExecuteReader ();
			return sqred;
		}
 
		/// <summary>
		/// this method use to show PurchaseID 
		/// </summary>
		public SqlDataReader  getClearedPuchaseID()
		{
			sqcom=new SqlCommand ("proSelectPurchaseID",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// this method use to show Book Information For Selected Purchase ID
		/// </summary>
		public SqlDataReader  ShowBookToSupplier()
		{
			sqcom=new SqlCommand ("proSelectedClickPurID",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@PurchaseID",PurchaseID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Edit Purchase Order Information
		/// </summary>
		public SqlDataReader  ShowPurchaseOrderEdit()
		{
			sqcom=new SqlCommand ("ProShowEditrInfo",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@PurchaseID",PurchaseID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Delete Purchase Order Information
		/// </summary>
		public void insertDeletePurchaseOrder()
		{
			sqcom=new SqlCommand(" proDeletePurchaseOrder",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
		}
		
	}
}
