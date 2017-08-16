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

namespace eschool.SchoolClass
{
	/// <summary>
	/// Summary description for AccountClass.
	/// </summary>
	public class AccountClass
	{
      
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqred;
		//DataSet ds;
		# region Var & Prop	
			
		string _Account_Type;
		string _Name;
		string _VoucherType;
		string _PerticularLedger1;

		public string PerticularLedger1
		{
			get
			{
				return _PerticularLedger1;
			}
			set
			{
				_PerticularLedger1=value;
			}
		}		
			

		public string VoucherType
		{
			get
			{
				return _VoucherType;
			}
			set
			{
				_VoucherType=value;
			}
		}		
			
		

		public string Account_Type
		{
			get
			{
				return _Account_Type;
			}
			set
			{
				_Account_Type=value;
			}
		}


	

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name=value;
			}
		}
		#endregion
	
		/// <summary>
		/// this method use to create Connection.
		/// </summary>
		public AccountClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}

		/// <summary>
		/// this method Show Group Name
		/// </summary>
		public SqlDataReader   ShowGroupName()
		{
			
			sqcom=new SqlCommand("select Account_Type from Account_Table",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show data from froupItemCreation.
		/// </summary>
		public SqlDataReader ShowUnder()
		{
			
			sqcom=new SqlCommand ("Select Under from GroupItemCreation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show A/c type.
		/// </summary>
		public SqlDataReader   ShowAccount()
		{
			sqcom=new SqlCommand ("Select Account_Type from Account_Table",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Voucher Type
		/// </summary>
		public SqlDataReader ShowVoucherType()
		{
				
			sqcom=new SqlCommand("Select VoucherType from Create_Voucher",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Account Type.
		/// </summary>
		public SqlDataReader  showAccounttype()
		{
				
			sqcom=new SqlCommand ("select VoucherType from VoucherEntry",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show Name Of Voucher.
		/// </summary>
		public SqlDataReader  ShowNameForVoucher()
		{
			sqcom=new SqlCommand ("Select Name from Ledger",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Name Of Voucher Entry
		/// </summary>
		public SqlDataReader  ShowNameForVouentry()
		{
			sqcom=new SqlCommand ("Select Name from Vouchertable",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Grand Total
		/// </summary>
		public SqlDataReader ShowGrandTotal()
		{
			
			sqcom=new SqlCommand ("ProShowGrandTotal",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}


		/// <summary>
		/// this method use to Show display Group
		/// </summary>
		public SqlDataReader  ShowDisplayGroup()
		{
				
			sqcom=new SqlCommand ("showName",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Account_Type",Account_Type);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show display Ledger
		/// </summary>
		public SqlDataReader  ShowDisplayLedger()
		{
				
			sqcom=new SqlCommand ("showNameledger",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Name",Name);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show A/c Type
		/// </summary>
		public SqlDataReader  ShowAccounttype()
		{
			
			sqcom=new SqlCommand ("proAccounttype",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@PerticularLedger1",PerticularLedger1);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Name of A/c Type
		/// </summary>
		public SqlDataReader  ShowNameAccountType()
		{
				
			sqcom=new SqlCommand ("select Distinct(PerticularLedger1) from VoucherEntry",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Total In P & L
		/// </summary>
		public SqlDataReader  ShowtotalInPL()
		{
			
			sqcom=new SqlCommand ("select sum(totaldr) from VoucherEntry",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}


		/// <summary>
		/// this method use to Show Total Trading P & L	
		/// </summary>
		public SqlDataReader  ShowtotalTradingPL()
		{
				
			sqcom=new SqlCommand ("select VoucherType,sum(totaldr) as totaldr1 from VoucherEntry where VoucherType='Purchase' group by VoucherType",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Total Trading Cr
		/// </summary>
		public SqlDataReader  ShowtotalTradingCr()
		{
			sqcom=new SqlCommand ("select VoucherType,sum(Totalcr) as totaldr1 from VoucherEntry where VoucherType='Sales' group by VoucherType",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Opening Balance
		/// </summary>
		public SqlDataReader  ShowOpeningBalance()
		{
			
			sqcom=new SqlCommand ("select max(Opening_Bal) from Ledger",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Total Dr Total
		/// </summary>
		public SqlDataReader  ShowTotalDrTotal()
		{
		
			sqcom=new SqlCommand ("proShowTotalDr",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@PerticularLedger1",PerticularLedger1);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	}
}
