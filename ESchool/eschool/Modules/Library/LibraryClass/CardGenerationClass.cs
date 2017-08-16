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
	/// Summary description for CardGenerationClass.
	/// </summary>
	/// 
	public class CardGenerationClass
	{
		// var declare
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlDataReader sqred;
		SqlDataAdapter sqdr;
		DataSet ds;


		#region Vars& Prop

		string _Card_NO;
		string _No_Of_Card;
		string _Validity_Of_Card;
		string _CandidateID;
        string _Date_Of_CardGen;
		string _Name_Of_Librarian;
		string _Remark;
		string _memberID;
		string _Student_Class;
		string _Design;
		
		
		public string Design
		{
			get
			{
				return _Design;
			}
			set
			{
				_Design=value;
			}
		}
		
		
		
		public string Student_Class
		{
			get
			{
				return _Student_Class;
			}
			set
			{
				_Student_Class=value;
			}
		}
		
		
		
		
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





		public string Card_NO
		{
			get
			{
				return _Card_NO;
			}
			set
			{
				_Card_NO=value;
			}
		}
		
	   public string No_Of_Card
		{
			get
			{
				return _No_Of_Card;
			}
			set
			{
				_No_Of_Card=value;
			}
		}
		
		public string Validity_Of_Card
		{
			get
			{
				return _Validity_Of_Card;
			}
			set
			{
				_Validity_Of_Card=value;
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

		public string Date_Of_CardGen
		{
			get
			{
				return _Date_Of_CardGen;
			}
			set
			{
				_Date_Of_CardGen=value;
			}
		}

		public string Name_Of_Librarian
		{
			get
			{
				return _Name_Of_Librarian;
			}
			set
			{
				_Name_Of_Librarian=value;
			}
		}

		public string Remark
		{
			get
			{
				return _Remark;
			}
			set
			{
				_Remark=value;
			}
		}

		

		#endregion 


		#region for connection string
	
		public CardGenerationClass()
		{
			sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
			sqcon.Open();
		}
		#endregion


		#region For select candidateId 

		/// <summary>
		/// this method use to get member id from card_generation.
		/// </summary>
		public SqlDataReader  getCandidateID()
		{
			sqcom=new SqlCommand ("select memberID from Card_Generation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// method for getting the student Information.		
		/// </summary>
		public SqlDataReader  ShowCandidateName()
		{
			sqcom=new SqlCommand ("ProcShowName",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@CandidateID",CandidateID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// For inserting  card information in the data base 
		/// </summary>
		public void InsCardInformation()
		{
			sqcom=new SqlCommand("proCardGeneration",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			//sqcom.Parameters .Add ("@CandidateID",CandidateID);
			sqcom.Parameters .Add ("@memberID",memberID );
			sqcom.Parameters.Add ("@Card_No",Card_NO);
			sqcom.Parameters .Add ("@No_Of_Card",No_Of_Card);
			sqcom.Parameters .Add ("@Validity_Of_Card",Validity_Of_Card);
			sqcom.Parameters .Add("@Date_Of_CardGen",Date_Of_CardGen);
			sqcom.Parameters .Add ("@Name_Of_Librarian",Name_Of_Librarian);
			sqcom.Parameters .Add ("@Remark",Remark);
			sqcom.Parameters .Add ("@Design",Design);
			sqcom.Parameters.Add ("@class",Student_Class);
			sqcom.ExecuteNonQuery();
      

			
//			sqcom=new SqlCommand("proCardGeneration",sqcon);
//			sqcom.CommandType=CommandType .StoredProcedure;
//			//sqcom.Parameters .Add ("@CandidateID",CandidateID);
//			sqcom.Parameters.Add ("@Card_No",Card_NO);
//			sqcom.Parameters .Add ("@No_Of_Card",No_Of_Card);
//			sqcom.Parameters .Add ("@Validity_Of_Card",Validity_Of_Card);
//		    sqcom.Parameters .Add("@Date_Of_CardGen",Date_Of_CardGen);
//			sqcom.Parameters .Add ("@Name_Of_Librarian",Name_Of_Librarian);
//			sqcom.Parameters .Add ("@Remark",Remark);
//			sqcom.Parameters .Add ("@memberID",memberID );
//			sqcom.ExecuteNonQuery();
//      
            			
		}

		/// <summary>
		/// Method for getting the next candidate id for allocation of card.
		/// </summary>
		/// <returns></returns>
		public SqlDataReader  getCardGen()
		{
		
			sqcom=new SqlCommand ("select max(candidateID+1) from Card_Generation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the Counting of student from membership.
		/// </summary>
		/// <returns></returns>
		public SqlDataReader  getCandidateCountM()
		{
			sqcom=new SqlCommand (" select  count(candidateID) from membership",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the Counting of student from Card_Generation.
		/// </summary>
		/// <returns></returns>
		public SqlDataReader  getCandidateCountCG()
		{
		
			sqcom=new SqlCommand (" select  count(candidateID) from Card_Generation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// Method for getting the maximum card nofrom card_genration table.
		/// </summary>
		/// <returns></returns>
		public SqlDataReader  getCardNo()
		{
			sqcom=new SqlCommand ("select max(Card_NO)+1 from Card_Generation",sqcon);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// For Show Card information  
		/// </summary>
		/// <returns></returns>
		public DataSet ShowCardInformation()
		{
			
			sqdr=new SqlDataAdapter(" proShowCardInformation",sqcon);
			ds=new DataSet();
			sqdr.Fill(ds);
			sqcon.Close();
			sqcon.Dispose();
			return ds;

		}
		#endregion
	}
}
