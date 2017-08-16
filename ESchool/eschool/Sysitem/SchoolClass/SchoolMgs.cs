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
using System .Data;
using RMG;

namespace eschool.SchoolClass
{
	/// <summary>
	/// Summary description for SchoolMgs.
	/// </summary>
	public class SchoolMgs
	{
		
		SqlConnection sqcon;
		SqlCommand sqcom;
		SqlCommand sqcomm;
		SqlDataReader sqdr;
		SqlDataReader sqred;
		
			
		#region Vars & Prop
		
		string u_name,u_pass;
		int _Student_ID1;
		string _UserName;
	    string _Vehicle;
		string _UserPassword;
		string _seq_student_id;
		string _Users_Name;
		string _Users_Password;
		string _First_Name;
		string _Middle_Name;
		string _Last_Name;
		string _Per_Address;
		string _Local_Address;
		string _City;
		string _PinCode; 
		string _Phone_Number;
		string _EMail_ID;
		string _Date_OF_Birth;
		string _Age;
		string _Gender;
		string _Father_Name;
		string _Mother_Name;
		string _marital_Status;
		string _Student_ID;
		string _FeesPaidID;
		string _Student_FName;
		string _Student_MName;
		string _Student_LName;
		string _Student_FatherName; 
		string _Student_MotherName;
		string _Student_FatherMobileno;
		string _Student_MotherMobileno;
		string _Student_FatherOccp;
		string _Student_MotherOccp;
		string _Student_FatherAnnualIncome;
		string _Student_MotherAnnualIncome;
		string _Student_FatherEmailID;
		string _Student_MotherEmailID;
		string _Student_Class;
		string _Student_Stream;
		string _Student_AdmissionDate;
		string _Student_Birthdate; 
		string _Student_Gender;
		string _Student_LAdderss;
		string _Student_LCity;
		string _Student_LState;
		string _Student_LPincode;
		string _Student_PAddress;
		string _Student_PCity;
		string _Student_PState;
		string _Student_PPincode;
		string _Student_EmailID;
		string _Student_PHNo;
		string _Student_MONo;
		string _Student_Category;
		string _Student_Photo;
		string _Permonth_Fees;
		string _Class;
		string _Student_Calss;
		string _Subject1;
		string _Subject2;
		string _Subject3;
		string _Subject4;
		string _Subject5;
		string _Subject6;
		string _Subject7;
		string _Subject;
		string _Today_Date;
		string _Attendance_Status;
		string _Test;
		string _Name_Subject;
		string _Marks;
		string _PerMonth_Fees;
		string _Due_Fees;
        string _Staff_Name;
		string _Date_OF_Assign;
		string _Assignment_Status;
		string _Assignment_Number;
        string _StudentID;
		string _LeaveType;
		string _Leave_DateTo;
		string _Leave_DateFrom;
		string _Total_Days;
		string _Stream;
		string _Sports_Fees;
		string _Lab_Fees;
		string _Hostal_Fees;
		string _Mess_Fees;
		string _Exam_Fees;
		string _Donation_Fees ;
		string _Transportation_Fees;
		string _Uniform_Fees;
		string _Stationary_Fees;
		string _Library_Fees ;
		string _Development_Fees;
		string _Employee_Name;
		string _Remarks;
		
		string _RecuringID;
		string _Tution_Fees;
		string _Admission_Status;
		string _Service_Hostal;
		string _Service_Lab ;
		string _Service_Library;
		string _Service_Bus;
		string _FeesPaid;
		string _Amount;
		string _Fees_Mode;
		string _Cheque_No;
		string _Cheque_Date;
		string _Bank_Name;
		string _Card_No;
		string _Card_Date;
		string _Receipt_From;
		string _NameoFPayer;
		string _Address;
		string _MiscID;
		string _Sate;
		string _Country;
		string _Place;
		string _Purpose;
		string _Duration;
		string _Rupees;
		string _Categoryofpayble;
		string _OutsiderPayment;
		string _PaybleMode;
		string _BillNo;
		string _BillDate;
		string _Nameofpayee;
		string _State;
		string _Location;
		string _PaymentMode;
		string _FeeSubdt;
		string _ChequeNo;
		string _BankName;
		string _ChequeDate;
		string _draftno;
		string _CreatedBy;
	    string _Latefee;
		string _Securityfee;
		string _TotalRupees;
	    string _Fees_Type;
		//string _Class; //add by vikas sharma date on 11.03.08 
		string _Period;
		string _PeriodTo;
		string _Penalty;
		string _Interest;
		string _Fees_Amount;
		string _AmountDue;
		string _EnteredBy;
		string _TeacherID;
		string _Name;
		string _Qualification;
		string _SubjectTeach;
		string _EmailID;
		string _DateOFBirth;
		string _PerAddress;
		string _Pincode;
		string _MobileNo;
		string _PhoneNo;
        string _ClassID;
	    string _ClassName;
		string _HoursID;
		string _Times;
		string _TodayDay;
		string _SubjectName;
	    string _SubjectID;
		string _Investment_id;
		string _HolidayID;
		string _HolidayDate;
		string _Days;
		string _NewTeacher;

		string _LoginName;
		string _RoleName;
		string _Description;
		string _Module_id;
		string _SubModule_id;
		string _View_flg;
		string _Add_flg;
		string _Edit_flg;
		string _Delete_flg;
		string _Fee_id;
		string _privileges_Id;
		//*******************************Created by Gyanandra 
		string _Itemname;
		string _Qty;
		string _Particulars;
		string _Desig;
		string _EmpID;
		string _Empname;
		string _ItemCategory;
		string _Issuedate;
		string _IssueID;
		string _DrDate;
		//string _Remarks;
		string _Designation;
		string _Diary_Fee;
		string _Computer_Fee;
		string _Science_Fee;
		string _Activity_Fee;
		string _Game_Fee;
		string _Admission_Fee;
		string _Annual_Fee;
		string _Envp_Fee;
		string _ST_ID;
		string _Tran_Type;
		string _Tran_No;
		string _Tran_Date;
		DateTime _Trans_Date;
		string _Vendor_Name;
		string _Stock_Location;
		
		string _Rate;
	
		//*******************************

		public string ST_ID
		{
			get
			{
				return _ST_ID;
			}
			set
			{
				_ST_ID=value;
			}
		}

		public string Tran_Type
		{
			get
			{
				return _Tran_Type;
			}
			set
			{
				_Tran_Type=value;
			}
		}

		public string Tran_No
		{
			get
			{
				return _Tran_No;
			}
			set
			{
				_Tran_No=value;
			}
		}
		
		public string Tran_Date
		{
			get
			{
				return _Tran_Date;
			}
			set
			{
				_Tran_Date=value;
			}
		}
		public DateTime Trans_Date
		{
			get
			{
				return _Trans_Date;
			}
			set
			{
				_Trans_Date=value;
			}
		}
		public string Vendor_Name
		{
			get
			{
				return _Vendor_Name;
			}
			set
			{
				_Vendor_Name=value;
			}
		}
		
		public string Place
		{
			get
			{
				return _Place;
			}
			set
			{
				_Place=value;
			}
		}

		
		public string Stock_Location
		{
			get
			{
				return _Stock_Location;
			}
			set
			{
				_Stock_Location=value;
			}
		}
		public string Rate
		{
			get
			{
				return _Rate;
			}
			set
			{
				_Rate=value;
			}
		}
		
		public string Remarks
		{
			get
			{
				return _Remarks;
			}
			set
			{
				_Remarks=value;
			}
		}
		public string Admission_Fee
		{
			get
			{
				return _Admission_Fee;
			}
			set
			{
				_Admission_Fee=value;
			}
		}
		public string Diary_Fee
		{
			get
			{
				return _Diary_Fee;
			}
			set
			{
				_Diary_Fee=value;
			}
		}
		public string Annual_Fee
		{
			get
			{
				return _Annual_Fee;
			}
			set
			{
				_Annual_Fee=value;
			}
		}
		public string Activity_Fee
		{
			get
			{
				return _Activity_Fee;
			}
			set
			{
				_Activity_Fee=value;
			}
		}
		public string Game_Fee
		{
			get
			{
				return _Game_Fee;
			}
			set
			{
				_Game_Fee=value;
			}
		}
		public string Science_Fee
		{
			get
			{
				return _Science_Fee;
			}
			set
			{
				_Science_Fee=value;
			}
		}
		public string Computer_Fee
		{
			get
			{
				return _Computer_Fee;
			}
			set
			{
				_Computer_Fee=value;
			}
		}
		public string Envp_Fee
		{
			get
			{
				return _Envp_Fee;
			}
			set
			{
				_Envp_Fee=value;
			}
		}
		public string Designation
		{
			get
			{
				return _Designation;
			}
			set
			{
				_Designation=value;
			}
		}
		
		public string DrDate
		{
			get
			{
				return _DrDate;
			}
			set
			{
				_DrDate=value;
			}
		}
		
		public string IssueID
		{
			get
			{
				return _IssueID;
			}
			set
			{
				_IssueID=value;
			}
		}
		
		
		public string Issuedate
		{
			get
			{
				return _Issuedate;
			}
			set
			{
				_Issuedate=value;
			}
		}
		
		
		public string Desig
		{
			get
			{
				return _Desig;
			}
			set
			{
				_Desig=value;
			}
		}
	
		public string EmpID
		{
			get
			{
				return _EmpID;
			}
			set
			{
				_EmpID=value;
			}
		}
		
		public string Empname
		{
			get
			{
				return _Empname;
			}
			set
			{
				_Empname=value;
			}
		}
		public string ItemCategory
		{
			get
			{
				return _ItemCategory;
			}
			set
			{
				_ItemCategory=value;
			}
		}




		public string Itemname
		{
			get
			{
				return _Itemname;
			}
			set
			{
				_Itemname=value;
			}
		}
		public string Vehicle
		{
			get
			{
				return _Vehicle;
			}
			set
			{
				_Vehicle=value;
			}
		}
		
		public string Qty
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
		
		public string Particulars
		{
			get
			{
				return _Particulars;
			}
			set
			{
				_Particulars=value;
			}
		}
				
		public string LoginName
		{
			get
			{
				return _LoginName;
			}
			set
			{
				_LoginName=value;
			}
		}
		
		public string seq_student_id
		{
			get
			{
				return _seq_student_id;
			}
			set
			{
				_seq_student_id=value;
			}
		}
		public int Student_ID1
		{
			get
			{
				return _Student_ID1;
			}
			set
			{
				_Student_ID1=value;
			}
		}
		public string RoleName
		{
			get
			{
				return _RoleName;
			}
			set
			{
				_RoleName=value;
			}
		}

		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description=value;
			}
		}

		public string Module_id
		{
			get
			{
				return _Module_id;
			}
			set
			{
				_Module_id=value;
			}
		}

		public string SubModule_id
		{
			get
			{
				return _SubModule_id;
			}
			set
			{
				_SubModule_id=value;
			}
		}

		public string View_flg
		{
			get
			{
				return _View_flg;
			}
			set
			{
				_View_flg=value;
			}
		}

		public string privileges_Id
		{
			get
			{
				return _privileges_Id;
			}
			set
			{
				_privileges_Id=value;
			}
		}

		public string Add_flg
		{
			get
			{
				return _Add_flg;
			}
			set
			{
				_Add_flg=value;
			}
		}

		public string Edit_flg
		{
			get
			{
				return _Edit_flg;
			}
			set
			{
				_Edit_flg=value;
			}
		}

		public string Delete_flg
		{
			get
			{
				return _Delete_flg;
			}
			set
			{
				_Delete_flg=value;
			}
		}


		public string NewTeacher
		{
			get
			{
				return _NewTeacher;
			}
			set
			{
				_NewTeacher=value;
			}

		}
		
		public string HolidayID
		{
			get
			{
				return _HolidayID;
			}
			set
			{
				_HolidayID=value;
			}

		}
		public string HolidayDate
		{
			get
			{
				return _HolidayDate;
			}
			set
			{
				_HolidayDate=value;
			}

		}
		public string Days
		{
			get
			{
				return _Days;
			}
			set
			{
				_Days=value;
			}

		}
		

		public string SubjectID
		{
			get
			{
				return _SubjectID;
			}
			set
			{
				_SubjectID=value;
			}

		}
		
		public string SubjectName
		{
			get
			{
				return _SubjectName;
			}
			set
			{
				_SubjectName=value;
			}

		}

		public string HoursID
		{
			get
			{
				return _HoursID;
			}
			set
			{
				_HoursID=value;
			}

		}
		
		
		public string Times
		{
			get
			{
				return _Times;
			}
			set
			{
				_Times=value;
			}

		}
		public string TodayDay
		{
			get
			{
				return _TodayDay;
			}
			set
			{
				_TodayDay=value;
			}

		}

     
		public string ClassName
		{
			get
			{
				return _ClassName;
			}
			set
			{
				_ClassName=value;
			}

		}

		public string ClassID
		{
			get
			{
				return _ClassID;
			}
			set
			{
				_ClassID=value;
			}

		}

    
			public string TeacherID
			{
				get
				{
					return _TeacherID;
				}
				set
				{
					_TeacherID=value;
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
		
		public string Qualification
		{
			get
			{
				return _Qualification;
			}
			set
			{
				_Qualification=value;
			}

		}
		
		public string SubjectTeach
		{
			get
			{
				return _SubjectTeach;
			}
			set
			{
				_SubjectTeach=value;
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
		
		public string DateOFBirth
		{
			get
			{
				return _DateOFBirth;
			}
			set
			{
				_DateOFBirth=value;
			}

		}
		
		public string PerAddress
		{
			get
			{
				return _PerAddress;
			}
			set
			{
				_PerAddress=value;
			}

		}
		
		
		
		public string Pincode
		{
			get
			{
				return _Pincode;
			}
			set
			{
				_Pincode=value;
			}

		}
		
	

		
		
		public string MobileNo
		{
			get
			{
				return _MobileNo;
			}
			set
			{
				_MobileNo=value;
			}

		}
		public string PhoneNo
		{
			get
			{
				return _PhoneNo;
			}
			set
			{
				_PhoneNo=value;
			}

		}


		

		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
			 _UserName=value;
			}

		}
		public string UserPassword
		{
			get
			{
				return _UserPassword;
			}
			set
			{
				_UserPassword=value;
			}

		}
		public string Student_Calss
		{
			get
			{
				return _Student_Calss;
			}
			set
			{
				_Student_Calss=value;
			}

		} 
		
		public string Fees_Type
		{
			get
			{
				return _Fees_Type;
			}
			set
			{
				_Fees_Type=value;
			}

		}
        // add by vikas sharma date 11.03.08
		public string Class
		{
			get
			{
				return _Class;
			}
			set
			{
				_Class=value;
			}

		}
		// add by vikas sharma date 11.03.08

		public string Period
		{
			get
			{
				return _Period;
			}
			set
			{
				_Period=value;
			}

		}

		public string PeriodTo
		{
			get
			{
				return _PeriodTo;
			}
			set
			{
				_PeriodTo=value;
			}

		}

		public string Penalty
		{
			get
			{
				return _Penalty;
			}
			set
			{
				_Penalty=value;
			}

		}

		public string Interest
		{
			get
			{
				return _Interest;
			}
			set
			{
				_Interest=value;
			}

		}

		public string Fees_Amount
		{
			get
			{
				return _Fees_Amount;
			}
			set
			{
				_Fees_Amount=value;
			}

		}

		public string Securityfee
		{
			get
			{
				return _Securityfee;
			}
			set
			{
				_Securityfee=value;
			}

		}

		public string Latefee
		{
			get
			{
				return _Latefee;
			}
			set
			{
				_Latefee=value;
			}

		}



		public string AmountDue
		{
			get
			{
				return _AmountDue;
			}
			set
			{
				_AmountDue=value;
			}

		}
		public string EnteredBy
		{
			get
			{
				return _EnteredBy;
			}
			set
			{
				_EnteredBy=value;
			}

		}
	
		public string TotalRupees
		{
			get
			{
				return _TotalRupees;
			}
			set
			{
				_TotalRupees=value;
			}

		}

		

		public string Categoryofpayble
		{
			get
			{
				return _Categoryofpayble;
			}
			set
			{
				_Categoryofpayble=value;
			}

		}
		public string OutsiderPayment
		{
			get
			{
				return _OutsiderPayment;
			}
			set
			{
				_OutsiderPayment=value;
			}

		}
		
		public string PaybleMode
		{
			get
			{
				return _PaybleMode;
			}
			set
			{
				_PaybleMode=value;
			}

		}
		public string BillNo
		{
			get
			{
				return _BillNo;
			}
			set
			{
				_BillNo=value;
			}

		}
		public string BillDate
		{
			get
			{
				return _BillDate;
			}
			set
			{
				_BillDate=value;
			}


		}

		public string Nameofpayee
		{
			get
			{
				return _Nameofpayee;
			}
			set
			{
				_Nameofpayee=value;
			}

		}
		

	
		public string State
		{
			get
			{
				return _State;
			}
			set
			{
				_State=value;
			}

		}

		

		public string Location
		{
			get
			{
				return _Location;
			}
			set
			{
				_Location=value;
			}

		}

		public string PaymentMode
		{
			get
			{
				return _PaymentMode;
			}
			set
			{
				_PaymentMode=value;
			}

		}
		public string FeeSubdt
		{
			get
			{
				return _FeeSubdt;
			}
			set
			{
				_FeeSubdt=value;
			}

		}
		public string ChequeNo
		{
			get
			{
				return _ChequeNo;
			}
			set
			{
				_ChequeNo=value;
			}


		}

		public string BankName
		{
			get
			{
				return _BankName;
			}
			set
			{
				_BankName=value;
			}

		}

		public string ChequeDate
		{
			get
			{
				return _ChequeDate;
			}
			set
			{
				_ChequeDate=value;
			}

		}
		public string draftno
		{
			get
			{
				return _draftno;
			}
			set
			{
				_draftno=value;
			}

		}

		public string CreatedBy
		{
			get
			{
				return _CreatedBy;
			}
			set
			{
				_CreatedBy=value;
			}

		}




		public string Receipt_From
		{
			get
			{
				return _Receipt_From;
			}
			set
			{
				_Receipt_From=value;
			}

		}
		
		public string NameoFPayer
		{
			get
			{
				return _NameoFPayer;
			}
			set
			{
				_NameoFPayer=value;
			}

		}
		
		public string Address
		{
			get
			{
				return _Address;
			}
			set
			{
				_Address=value;
			}

		}
		
		public string MiscID
		{
			get
			{
				return _MiscID;
			}
			set
			{
				_MiscID=value;
			}

		}
		
		public string Sate
		{
			get
			{
				return _Sate;
			}
			set
			{
				_Sate=value;
			}

		}
		
		public string Country
		{
			get
			{
				return _Country;
			}
			set
			{
				_Country=value;
			}

		}

		public string Investment_id
		{
			get
			{
				return _Investment_id;
			}
			set
			{
				_Investment_id=value;
			}

		}
		
		public string Purpose
		{
			get
			{
				return _Purpose;
			}
			set
			{
				_Purpose=value;
			}
	
		}


		public string Duration
		{
			get
			{
				return _Duration;
			}
			set
			{
				_Duration=value;
			}
	
		}


		public string Rupees
		{
			get
			{
				return _Rupees;
			}
			set
			{
				_Rupees=value;
			}
	
		}



		



		public string FeesPaid
		{
			get
			{
				return _FeesPaid;
			}
			set
			{
				_FeesPaid=value;
			}

		}
		public string Amount
		{
			get
			{
				return _Amount;
			}
			set
			{
				_Amount=value;
			}

		}
		public string Fees_Mode
		{
			get
			{
				return _Fees_Mode;
			}
			set
			{
				_Fees_Mode=value;
			}

		}
	
		public string Cheque_No
		{
			get
			{
				return _Cheque_No;
			}
			set
			{
				_Cheque_No=value;
			}

		}
		public string Cheque_Date
		{
			get
			{
				return _Cheque_Date;
			}
			set
			{
				_Cheque_Date=value;
			}


		}
		public string Bank_Name
		{
			get
			{
				return _Bank_Name;
			}
			set
			{
				_Bank_Name=value;
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

		public string Card_Date
		{
			get
			{
				return _Card_Date;
			}
			set
			{
				_Card_Date=value;
			}

		}
		
		


		public string Admission_Status
		{
			get
			{
				return _Admission_Status;
			}
			set
			{
				_Admission_Status=value;
			}

		}

	 
		public string Service_Hostal
		{
			get
			{
				return _Service_Hostal;
			}
			set
			{
				_Service_Hostal=value;
			}
		}
		
		public string Service_Lab 
		{
			get
			{
				return _Service_Lab ;
			}
			set
			{
				_Service_Lab =value;
			}
		}
		
		public string Service_Library
		{
			get
			{
				return _Service_Library;
			}
			set
			{
				_Service_Library=value;
			}
		}
		
		public string Service_Bus
		{
			get
			{
				return _Service_Bus;
			}
			set
			{
				_Service_Bus=value;
			}
		}


		
		
		

		public string Tution_Fees
		{
			get
			{
				return _Tution_Fees;
			}
			set
			{
				_Tution_Fees=value;
			}
		}

		

		

		public string Sports_Fees
		{
			get
			{
				return _Sports_Fees;
			}
			set
			{
				_Sports_Fees=value;
			}
		}

		public string Lab_Fees
		{
			get
			{
				return _Lab_Fees;
			}
			set
			{
				_Lab_Fees=value;
			}
		}

		public string Hostal_Fees
		{
			get
			{
				return _Hostal_Fees;
			}
			set
			{
				_Hostal_Fees=value;
			}
		}

		public string Mess_Fees
		{
			get
			{
				return _Mess_Fees;
			}
			set
			{
				_Mess_Fees=value;
			}
		}

		public string Exam_Fees
		{
			get
			{
				return _Exam_Fees;
			}
			set
			{
				_Exam_Fees=value;
			}
		}

		public string Donation_Fees
		{
			get
			{
				return _Donation_Fees;
			}
			set
			{
				_Donation_Fees=value;
			}
		}

		public string Transportation_Fees
		{
			get
			{
				return _Transportation_Fees;
			}
			set
			{
				_Transportation_Fees=value;
			}
		}

		public string Uniform_Fees
		{
			get
			{
				return _Uniform_Fees;
			}
			set
			{
				_Uniform_Fees=value;
			}
		}
		public string Stationary_Fees
		{
			get
			{
				return _Stationary_Fees;
			}
			set
			{
				_Stationary_Fees=value;
			}
		}
		public string Library_Fees 
		{
			get
			{
				return _Library_Fees;
			}
			set
			{
				_Library_Fees =value;
			}
		}

		public string Development_Fees
		{
			get
			{
				return _Development_Fees;
			}
			set
			{
				_Development_Fees=value;
			}
		}

		public string Employee_Name
		{
			get
			{
				return _Employee_Name;
			}
			set
			{
				_Employee_Name=value;
			}
		}
//		public string Remarks
//		{
//			get
//			{
//				return _Remarks;
//			}
//			set
//			{
//				_Remarks=value;
//			}
//		}
	
		public string RecuringID
		{
			get
			{
				return _RecuringID;
			}
			set
			{
				_RecuringID=value;
			}
		}





		public string Total_Days
		{
			get
			{
				return _Total_Days;
			}
			set
			{
				_Total_Days=value;
			}
		}

				public string LeaveType
				{
    					get
					{
						return _LeaveType;
					}
					set
					{
						_LeaveType=value;
					}
				}

				public string Leave_DateTo
				{
					get
				{
					return _Leave_DateTo;
				}
					set
				{
				_Leave_DateTo=value;
				}
				}
				public string Leave_DateFrom
				{
					get
				{
				return _Leave_DateFrom;
				}
				set
				{
				_Leave_DateFrom=value;
				}
			}
	
           
		public string StudentID
		{
			get
			{
				return _StudentID;
			}
			set
			{
				_StudentID=value;
			}
		}
   
		public string Date_OF_Assign
		{
			get
			{
				return _Date_OF_Assign;
			}
			set
			{
				_Date_OF_Assign=value;
			}
		}
		
		public string Assignment_Status
		{
			get
			{
				return _Assignment_Status;
			}
			set
			{
				_Assignment_Status=value;
			}
		}
		
		public string Assignment_Number
		{
			get
			{
				return _Assignment_Number;
			}
			set
			{
				_Assignment_Number=value;
			}
		}


	
		public string Staff_Name
		{
			get
			{
				return _Staff_Name;
			}
			set
			{
				_Staff_Name=value;
			}
		}



		public string PerMonth_Fees
		{
			get
			{
				return _PerMonth_Fees;
			}
			set
			{
				_PerMonth_Fees=value;
			}
		}

		public string Due_Fees
		{
			get
			{
				return _Due_Fees;
			}
			set
			{
				_Due_Fees=value;
			}
		}
        

		public string Test
		{
			get
			{
				return _Test;
			}
			set
			{
				_Test=value;
			}
		}

		public string Name_Subject
		{
			get
			{
				return _Name_Subject;
			}
			set
			{
				_Name_Subject=value;
			}
		}
		public string Marks
		{
			get
			{
				return _Marks;
			}
			set
			{
				_Marks=value;
			}
		}

		public string Subject
		{
			get
			{
				return _Subject;
			}
			set
			{
				_Subject=value;
			}
		}
		public string Today_Date
		{
			get
			{
				return _Today_Date;
			}
			set
			{
				_Today_Date=value;
			}
		}

						public string Attendance_Status
					   {
					   get
					   {
						   return _Attendance_Status;
					   }
					   set
					   {
						   _Attendance_Status=value;
					   }
				   }

		
		//public string Class
		//{
		//	get
		//	{
		//		return _Class;
		//	}
		//	set
		//	{
		//		_Class=value;
		//	}
		//}
		public string Stream
		{
			get
			{
				return _Stream;
			}
			set
			{
				_Stream=value;
			}
		}
		public string Subject1
		 {
			 get
			 {
				 return  _Subject1;
			 }
			 set
			 {
				  _Subject1=value;
			 }
		 }
		public string  Subject2
		  {
			  get
			  {
				  return  _Subject2;
			  }
			  set
			  {
				   _Subject2=value;
			  }
		  }
		public string  Subject3
		   {
			   get
			   {
				   return  _Subject3;
			   }
			   set
			   {
				    _Subject3=value;
			   }
		   }
		public string Subject4
			{
				get
				{
					return _Subject4;
				}
				set
				{
					_Subject4=value;
				}
			}
		public string Subject5
			 {
				 get
				 {
					 return _Subject5;
				 }
				 set
				 {
					 _Subject5=value;
				 }
			 }
		public string Subject6
			  {
				  get
				  {
					  return _Subject6;
				  }
				  set
				  {
					  _Subject6=value;
				  }
			  }
		public string Subject7
			   {
				   get
				   {
					   return _Subject7;
				   }
				   set
				   {
					   _Subject7=value;
				   }
			   }
		public string Fee_id
		{
			get
			{
				return _Fee_id;
			}
			set
			{
				_Fee_id=value;
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
		public string Permonth_Fees
		{
			get
			{
				return _Permonth_Fees;
			}
			set
			{
				_Permonth_Fees=value;
			}
		}
		
		public string Student_ID
		{
			get
			{
				return _Student_ID;
			}
			set
			{
				_Student_ID=value;
			}
		}
		public string FeesPaidID
		{
			get
			{
				return _FeesPaidID;
			}
			set
			{
				_FeesPaidID=value;
			}
		}
		public string Student_FName
		{
			get
			{
				return _Student_FName;
			}
			set
			{
				_Student_FName=value;
			}
		}
	
		public string Student_MName
		{
			get
			{
				return _Student_MName;
			}
			set
			{
				_Student_MName=value;
			}
		}

		public string Student_LName
		{
			get
			{
				return _Student_LName;
			}
			set
			{
				_Student_LName=value;
			}
		}
		
		public string Student_FatherName
		{
			get
			{
				return _Student_FatherName;
			}
			set
			{
				_Student_FatherName=value;
			}
		}
		public string Student_MotherName
		{
			get
			{
				return _Student_MotherName;
			}
			set
			{
				_Student_MotherName=value;
			}
		}
		public string Student_FatherMobileno
		{
			get
			{
				return _Student_FatherMobileno;
			}
			set
			{
				_Student_FatherMobileno=value;
			}
		}
		public string Student_MotherMobileno
		{
			get
			{
				return _Student_MotherMobileno;
			}
			set
			{
				_Student_MotherMobileno=value;
			}
		}
		public string Student_FatherOccp
		{
			get
			{
				return _Student_FatherOccp;
			}
			set
			{
				_Student_FatherOccp=value;
			}
		}
		public string Student_MotherOccp
		{
			get
			{
				return _Student_MotherOccp;
			}
			set
			{
				_Student_MotherOccp=value;
			}
		}

		public string Student_FatherAnnualIncome
		{
			get
			{
				return _Student_FatherAnnualIncome;
			}
			set
			{
				_Student_FatherAnnualIncome=value;
			}
		}

		public string Student_MotherAnnualIncome
		{
			get
			{
				return _Student_MotherAnnualIncome;
			}
			set
			{
				_Student_MotherAnnualIncome=value;
			}
		}


		public string Student_FatherEmailID
		{
			get
			{
				return _Student_FatherEmailID;
			}
			set
			{
				_Student_FatherEmailID=value;
			}
		}

		public string Student_MotherEmailID
		{
			get
			{
				return _Student_MotherEmailID;
			}
			set
			{
				_Student_MotherEmailID=value;
			}
		}
		

		
		public string Student_Stream
		{
			get
			{
				return _Student_Stream;
			}
			set
			{
				_Student_Stream=value;
			}
		}
		public string Student_AdmissionDate
		{
			get
			{
				return _Student_AdmissionDate;
			}
			set
			{
				_Student_AdmissionDate=value;
			}
		}

		public string Student_Birthdate
		{
			get
			{
				return _Student_Birthdate;
			}
			set
			{
				_Student_Birthdate=value;
			}
		}

		public string Student_Gender
		{
			get
			{
				return _Student_Gender;
			}
			set
			{
				_Student_Gender=value;
			}
		}





		public string Student_LAdderss
		{
			get
			{
				return _Student_LAdderss;
			}
			set
			{
				_Student_LAdderss=value;
			}
		}



		public string Student_LCity
		{
			get
			{
				return _Student_LCity;
			}
			set
			{
				_Student_LCity=value;
			}
		}

		public string Student_LState
		{
			get
			{
				return _Student_LState;
			}
			set
			{
				_Student_LState=value;
			}
		}

		public string Student_LPincode
		{
			get
			{
				return _Student_LPincode;
			}
			set
			{
				_Student_LPincode=value;
			}
		}

		public string Student_PAddress
		{
			get
			{
				return _Student_PAddress;
			}
			set
			{
				_Student_PAddress=value;
			}
		}

		public string Student_PCity
		{
			get
			{
				return _Student_PCity;
			}
			set
			{
				_Student_PCity=value;
			}
		}

		public string Student_PState
		{
			get
			{
				return _Student_PState;
			}
			set
			{
				_Student_PState=value;
			}
		}

		public string Student_PPincode
		{
			get
			{
				return _Student_PPincode;
			}
			set
			{
				_Student_PPincode=value;
			}
		}

		public string Student_EmailID
		{
			get
			{
				return _Student_EmailID;
			}
			set
			{
				_Student_EmailID=value;
			}
		}

		public string Student_PHNo
		{
			get
			{
				return _Student_PHNo;
			}
			set
			{
				_Student_PHNo=value;
			}
		}

		public string Student_MONo
		{
			get
			{
				return _Student_MONo;
			}
			set
			{
				_Student_MONo=value;
			}
		}

		public string Student_Category
		{
			get
			{
				return _Student_Category;
			}
			set
			{
				_Student_Category=value;
			}
		}

		public string Student_Photo
		{
			get
			{
				return _Student_Photo;
			}
			set
			{
				_Student_Photo=value;
			}
		}

		public string username
		{
			get
			{
				return u_name;
			}
			set
			{
				u_name=value;
			}
		}
		public string userpass
		{
			get
			{
				return u_pass;
			}
			set
			{
				u_pass=value;
			}
		}
	
		public string Users_Name
		{
			get
			{
				return _Users_Name;
			}
			set
			{
				_Users_Name=value;
			}
		}

		public string Users_Password
		{
			get
			{
				return _Users_Password;
			}
			set
			{
				_Users_Password=value;
			}
		}
		
		public string First_Name
		{
			get
			{
				return _First_Name;
			}
			set
			{
				_First_Name=value;
			}
		}
		public string Middle_Name
		{
			get
			{
				return _Middle_Name;
			}
			set
			{
				_Middle_Name=value;
			}
		}
		public string Last_Name
		{
			get
			{
				return _Last_Name;
			}
			set
			{
				_Last_Name=value;
			}
		}
		public string Per_Address
		{
			get
			{
				return _Per_Address;
			}
			set
			{
				_Per_Address=value;
			}
		}
		public string Local_Address
		{
			get
			{
				return _Local_Address;
			}
			set
			{
				_Local_Address=value;
			}
		}
		public string City
		{
			get
			{
				return _City;
			}
			set
			{
				_City=value;
			}
		}

		public string PinCode
		{
			get
			{
				return _PinCode;
			}
			set
			{
				_PinCode=value;
			}
		}

		public string Phone_Number
		{
			get
			{
				return _Phone_Number;
			}
			set
			{
				_Phone_Number=value;
			}
		}
		public string EMail_ID
		{
			get
			{
				return _EMail_ID;
			}
			set
			{
				_EMail_ID=value;
			}
		}

		public string Date_OF_Birth
		{
			get
			{
				return _Date_OF_Birth;
			}
			set
			{
				_Date_OF_Birth=value;
			}
		}
		

		public string Age
		{
			get
			{
				return _Age;
			}
			set
			{
				_Age=value;
			}
		}
		public string Gender
		{
			get
			{
				return _Gender;
			}
			set
			{
				_Gender=value;
			}
		}
		public string Father_Name
		{
			get
			{
				return _Father_Name;
			}
			set
			{
				_Father_Name=value;
			}
		}

		public string Mother_Name
		{
			get
			{
				return _Mother_Name;
			}
			set
			{
				_Mother_Name=value;
			}
		}

		public string marital_Status
		{
			get
			{
				return _marital_Status;
			}
			set
			{
				_marital_Status=value;
			}
		}


		#endregion


		/// <summary>
		/// Making connection
		/// </summary>
		public SchoolMgs()
		{   
				sqcon=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["bbnschool"]);
				sqcon.Open();
		}

		/// <summary>
		/// this method use to Insert Previleges For user access management
		/// </summary>
		public void InsertPrevileges()
		{ 
			sqcomm=new SqlCommand("ProInsertPrevileges",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@privileges_Id",privileges_Id);
			sqcomm.Parameters .Add("@LoginName",LoginName );
			sqcomm.Parameters .Add("@RoleName",RoleName );
			sqcomm.Parameters.Add("@Description",Description );
			sqcomm.Parameters .Add("@Module_id",Module_id );
			sqcomm.Parameters .Add("@SubModule_id",SubModule_id);
			sqcomm.Parameters .Add("@View_flg",View_flg);
			sqcomm.Parameters .Add("@Add_flg",Add_flg);
			sqcomm.Parameters .Add("@Edit_flg",Edit_flg);
			sqcomm.Parameters .Add("@Delete_flg",Delete_flg);
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Update Previleges For user access management
		/// </summary>
		public void UpdatePrevileges()
		{ 
			sqcomm=new SqlCommand("ProUpdatePrevileges",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@LoginName",LoginName );
			sqcomm.Parameters .Add("@RoleName",RoleName );
			sqcomm.Parameters.Add("@Description",Description );
			sqcomm.Parameters .Add("@Module_id",Module_id );
			sqcomm.Parameters .Add("@SubModule_id",SubModule_id);
			sqcomm.Parameters .Add("@View_flg",View_flg);
			sqcomm.Parameters .Add("@Add_flg",Add_flg);
			sqcomm.Parameters .Add("@Edit_flg",Edit_flg);
			sqcomm.Parameters .Add("@Delete_flg",Delete_flg);
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		///  this method use to Check Student User for user Login 
		/// </summary>
		public int CheckStudentUser()
		{
				
			sqcomm=new SqlCommand("select UserName,UserPassword from StudentUser where UserName='"+username+"' and UserPassword='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// This function use to getrecordset
		/// </summary>
		public SqlDataReader GetRecordSet(string sql)
		{
		    sqcom =new SqlCommand(sql,sqcon);
			 sqdr=sqcom.ExecuteReader();
			return sqdr;
		}

		/// <summary>
		/// this method use to Check Indivisible User for user Login 
		/// </summary>
		public int CheckIndivisibleUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Password from IndivisibleUser where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
			
		
		}

		/// <summary>
		/// this method use to Check Employee User for user Login 
		/// </summary>
		public int CheckEmployeeUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Password from EmployeeUser where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// this method use to Check Driver User for user Login 
		/// </summary>
		public int CheckDriverUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Password from DriverUser where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// this method use to Check Other User for user Login 
		/// </summary>
		public int CheckOtherUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Password from OtherUser where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// this method use to Check  User for user Login 
		/// </summary>
		public int CheckUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Password from userspwd where Users_Name='"+username+"' and Users_Password='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
			
		
		}

		/// <summary>
		/// this method use to Check ControlPanel User for user Login 
		/// </summary>
		public int CheckControlPanelUser()
		{
				
			sqcomm=new SqlCommand("select Users_Name,Users_Passwords from ControlUser where Users_Name='"+username+"' and Users_Passwords='"+userpass+"'",sqcon);
			sqdr=sqcomm.ExecuteReader();
			if(sqdr.Read())
			{
				
				username=sqdr.GetValue(0).ToString().Trim();
				userpass=sqdr.GetValue(1).ToString().Trim();
				return 0;
			}
			else
			{
				return 1;
			}
			
		
		}

		/// <summary>
		/// this method use to Insert New User For Maintaining Record of User.
		/// </summary>
		public void InsertNewUser()
		{ 
				
			sqcomm=new SqlCommand("ProInsertNewUser",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@First_Name",First_Name );
			sqcomm.Parameters .Add("@Middle_Name",Middle_Name );
			sqcomm.Parameters.Add("@Last_Name",Last_Name );
			sqcomm.Parameters .Add("@Per_Address",Per_Address );
			sqcomm.Parameters .Add("@Local_Address",Local_Address);
			sqcomm.Parameters .Add("@City",City );
			sqcomm.Parameters .Add("@PinCode",PinCode );
			sqcomm.Parameters .Add("@Phone_Number",Phone_Number);
			sqcomm.Parameters .Add("@EMail_ID",EMail_ID);
			sqcomm.Parameters .Add("@Date_OF_Birth",Date_OF_Birth);
			sqcomm.Parameters .Add("@Age",Age);
			sqcomm.Parameters .Add("@Gender",Gender );
			sqcomm.Parameters.Add("@Father_Name",Father_Name);
			sqcomm.Parameters .Add("@Mother_Name",Mother_Name);
			sqcomm.Parameters .Add("@marital_Status",marital_Status);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Student User 
		/// </summary>
		public void InsertStudentUser()
		{ 

			sqcom=new SqlCommand("proInsertStudentUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@UserName",UserName);
			sqcom.Parameters.Add("@UserPassword",UserPassword);
			sqcom.ExecuteNonQuery();

		}


		/// <summary>
		/// this method use to Insert New Teacher User 
		/// </summary>
		public void InsertNewTeacher()
		{ 

			sqcom=new SqlCommand("ProInsertTeacherNew",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@NewTeacher",NewTeacher);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert Class Information 
		/// </summary>
		public void InsertClassInfo()
		{ 
			sqcom=new SqlCommand("ProInsertClassinfo",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@ClassID",ClassID);
			sqcom.Parameters.Add("@TeacherID",TeacherID);
			sqcom.Parameters.Add("@Stream",Stream);
			sqcom.Parameters.Add("@ClassName",ClassName);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert indivisible User  
		/// </summary>
		public void InsertindivisibleUser()
		{ 
			sqcom=new SqlCommand("proInsertIndivisUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@Users_Name",Users_Name);
			sqcom.Parameters.Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert Driver User  
		/// </summary>
		public void InsertDriverUser()
		{ 

			sqcom=new SqlCommand("proInsertDriverUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@Users_Name",Users_Name);
			sqcom.Parameters.Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert Employee User  
		/// </summary>
		public void InsertEmployeeUser()
		{ 

			sqcom=new SqlCommand("proInsertEmployeeUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@Users_Name",Users_Name);
			sqcom.Parameters.Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert Other User  	
		/// </summary>
		public void InsertOtherUser()
		{ 

			sqcom=new SqlCommand("proInsertOtherUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters.Add("@Users_Name",Users_Name);
			sqcom.Parameters.Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}
			
		/// <summary>
		/// this method use to Insert Administrator User
		/// </summary>
		public void InsertAdministratorUser()
		{ 
		
			sqcom=new SqlCommand("proInsertUser",sqcon);
			sqcom.CommandType =CommandType .StoredProcedure ;
			sqcom.Parameters .Add("@Users_Name",Users_Name);
			sqcom.Parameters .Add("@Users_Password",Users_Password);
			sqcom.ExecuteNonQuery();

		}

		/// <summary>
		/// this method use to Insert Fees Decision For Student 
		/// </summary>
		public void InsertFeesDecesion()
		{ 
			sqcomm=new SqlCommand("ProInsertDecesionFees",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@Fee_id",Fee_id);
			sqcomm.Parameters .Add("@Student_Class",Student_Class);
			sqcomm.Parameters .Add("@StudentID",StudentID);
			sqcomm.Parameters .Add("@Permonth_Fees",Permonth_Fees );
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Insert Student Attandance    
		/// </summary>
		public void InsertStudentAttandance()
		{ 
				
			sqcomm=new SqlCommand("ProInsertStudentAttandance",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@StudentID",Student_ID);
			sqcomm.Parameters .Add("@Today_Date",Today_Date);
			sqcomm.Parameters .Add ("@Attendance_Status",Attendance_Status);
			sqcomm.Parameters .Add ("@Subject ",Subject);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Student Marks for One Subject
		/// </summary>
		public void InsertStudentMarks()
		{ 
		
			sqcomm=new SqlCommand("ProInsertStudentMarks",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID);
			sqcomm.Parameters .Add("@seq_student_id",seq_student_id);
			sqcomm.Parameters .Add("@Test",Test);
			sqcomm.Parameters .Add("@Name_Subject",Name_Subject);
			sqcomm.Parameters .Add("@Marks",Marks);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Monthly Student Fees.
		/// </summary>
		public void InsertStudentFees()
		{ 
			
			sqcomm=new SqlCommand("ProInsertStudentFeesEntry",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID);
			sqcomm.Parameters .Add("@PerMonth_Fees",PerMonth_Fees);
			sqcomm.Parameters .Add("@Due_Fees",Due_Fees);
			sqcomm.ExecuteNonQuery();
		
          
		}

		/// <summary>
		/// this method use to Insert Update Record
		/// </summary>
		public void UpdateProcChangePass()
		{ 
			
			sqcomm=new SqlCommand("UpdateProcforPasswordChange",sqcon);
			sqcomm.CommandType =CommandType  .StoredProcedure;
			sqcomm.Parameters .Add("@UserName",UserName);
			sqcomm.Parameters .Add("@UserPassword",UserPassword);
			sqcomm.ExecuteNonQuery();
		
			
		}

		/// <summary>
		/// this method use to Insert Subject Decesion For Student
		/// </summary>
		public void InsertSubjectDecesion()
		{ 
			sqcomm=new SqlCommand("ProInsertDecesionSubject",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@StudentID",Student_ID1);
			sqcomm.Parameters .Add("@Subject1",Subject1);
			sqcomm.Parameters .Add("@Subject2",Subject2);
			sqcomm.Parameters .Add("@Subject3",Subject3);
			sqcomm.Parameters .Add("@Subject4",Subject4);
			sqcomm.Parameters .Add("@Subject5",Subject5);
			sqcomm.Parameters .Add("@Subject6",Subject6);
			sqcomm.Parameters .Add("@Subject7",Subject7);
			sqcomm.ExecuteNonQuery();
		}

		/// <summary>
		/// this method use to Insert Student Assignment Information.
		/// </summary>
		public void  InsertStudentAssignmentInfo()
		{ 
			sqcomm=new SqlCommand("ProInsertStudentAssignmentInfo",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID);
			//sqcomm.Parameters .Add("@seq_student_id",seq_student_id);
			sqcomm.Parameters .Add("@Subject",Subject );
			sqcomm.Parameters .Add("@Date_OF_Assign",Date_OF_Assign);
			sqcomm.Parameters .Add("@Assignment_Status",Assignment_Status);
			sqcomm.Parameters .Add("@Assignment_Number",Assignment_Number);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Student Leave Information
		/// </summary>
		public void  InsertStudentLeaveInfo()
		{ 
				
			sqcomm=new SqlCommand("ProInsertStudentLeave",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@Student_ID",Student_ID);
			sqcomm.Parameters .Add("@LeaveType",LeaveType );
			sqcomm.Parameters .Add("@Leave_DateTo",Leave_DateTo);
			sqcomm.Parameters .Add("@Leave_DateFrom",Leave_DateFrom);
			//sqcomm.Parameters .Add ("@Total_Days",Total_Days);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Student  Hour Information
		/// </summary>
		public void  InsertHourInfo()
		{ 
		
			sqcomm=new SqlCommand("ProInsertHour",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@HoursID",HoursID);
			sqcomm.Parameters .Add("@ClassID",ClassID );
			sqcomm.Parameters .Add("@TeacherID",TeacherID);
			sqcomm.Parameters .Add("@Times",Times);
			sqcomm.Parameters .Add ("@TodayDay",TodayDay);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Subject Information	
		/// </summary>
		public void  InsertSubjectInfo()
		{ 
	
			sqcomm=new SqlCommand("ProInsertsubject",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@SubjectID",SubjectID);
			sqcomm.Parameters .Add("@TeacherID",TeacherID );
			sqcomm.Parameters .Add("@SubjectName",SubjectName);
			sqcomm.Parameters .Add("@ClassID",ClassID);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Insert Holiday Information.
		/// </summary>
		public void  InsertHoliday()
		{ 
	        sqcomm=new SqlCommand("ProInsertHoliday",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@HolidayId",HolidayID );
			sqcomm.Parameters .Add("@HolidayDate",HolidayDate );
			sqcomm.Parameters .Add("@Remarks",Remarks);
			sqcomm.ExecuteNonQuery();
     	}

		/// <summary>
		/// this method use to Insert Teacher Information
		/// </summary>
		public void  InsertTeacherInfo()
		{ 
	
			sqcomm=new SqlCommand("ProInsertTeacherinfo",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters .Add("@TeacherID",TeacherID);
			sqcomm.Parameters .Add("@Name",Name );
			sqcomm.Parameters .Add("@Qualification",Qualification);
			sqcomm.Parameters .Add("@SubjectTeach",SubjectTeach);
			sqcomm.Parameters .Add ("@EmailID",EmailID);
			sqcomm.Parameters .Add("@DateOFBirth",DateOFBirth );
			sqcomm.Parameters .Add("@PerAddress",PerAddress);
			sqcomm.Parameters .Add("@City",City);
			sqcomm.Parameters .Add ("@Gender",Gender);
			sqcomm.Parameters .Add("@State",State );
			sqcomm.Parameters .Add("@Country",Country);
			sqcomm.Parameters .Add("@MobileNo",MobileNo);
			sqcomm.Parameters .Add ("@PhoneNo",PhoneNo);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Getting Student Id for Auto Increments
		/// </summary>
		public SqlDataReader  getStudentID()
		{
			
			sqcomm=new SqlCommand ("select max(Student_ID)+1 from Student_Record",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Getting Teacher ID for Auto Increments
		/// </summary>
		public SqlDataReader getteacherID()
		{
		   sqcomm=new SqlCommand ("select max(TeacherID)+1 from Teacher",sqcon); 
           sqred=sqcomm.ExecuteReader();
		   return sqred;
		
		}

		/// <summary>
		/// this method use toGetting Staff ID for Auto Increments
		/// </summary>
		public SqlDataReader  getStaffID()
		{
			
			sqcomm=new SqlCommand ("select max(Staff_ID)+1 from Staff_Information",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Getting TeacherID for  Hour's
		/// </summary>
		public SqlDataReader  getTeacherID1()
		{
			
			sqcomm=new SqlCommand ("select staff_id from  staff_information where teaching=1",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}
 
		/// <summary>
		/// this method use to Getting Holiday ID for  Auto Increments
		/// </summary>
		public SqlDataReader  getHolidayID()
		{
			sqcomm=new SqlCommand ("select max(HolidayID)+1 from Holiday",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Teacher ID for Fill ComboBox
		/// </summary>
		public SqlDataReader showTeacherID()
		{
		
			sqcomm=new SqlCommand ("select TeacherID from  Teacher",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Getting Class Id For Auto Increments
		/// </summary>
		public SqlDataReader showclassID()
		{
		
		    sqcomm=new SqlCommand ("Select max(ClassID)+1 from ClassInfo",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show ClassID for fill  Combo box 
		/// </summary>
		
		public SqlDataReader showclassIDIncombo()
		{
		
			sqcomm=new SqlCommand ("Select ClassID from ClassInfo",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Getting Hour's Id For Auto Increments
		/// </summary>

		public SqlDataReader showHourIDInlbl()
		{
		
			sqcomm=new SqlCommand ("Select Max(HoursID)+1 from Hours",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Getting Subject ID  For Auto Increments
		/// </summary>
		public SqlDataReader ShowSubjectinfo()
		{
		
			sqcomm=new SqlCommand ("Select Max(SubjectID)+1 from SubjectInfo",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Staff Name For staff Type = Teacher 
		/// </summary>
		public SqlDataReader  getStaffName()
		{
				
			sqcomm=new SqlCommand ("select Staff_Name from Staff_Information where Teaching='1'",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// This Function is use in image Control so this is no Working  
		/// </summary>
		public SqlDataReader  getId()
		{
				
			sqcomm=new SqlCommand ("select u_id from Uploads1",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// this method use to Show Student Id in combo box for Fetch Student Record
		/// </summary>
		public SqlDataReader  showStudentIDInCombo()
		{
			
			//sqcomm=new SqlCommand ("select seq_Student_ID from Student_Record order by seq_Student_ID",sqcon);
			sqcomm=new SqlCommand ("select Student_ID from Student_Record order by Student_ID",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show Student class in combo box for Fetch Student Record
		/// </summary>
		public SqlDataReader  showStudentclassInCombo()
		{
			
			//sqcomm=new SqlCommand ("select seq_Student_ID from Student_Record order by seq_Student_ID",sqcon);
			sqcomm=new SqlCommand ("select Student_Class from Student_Record order by Student_Class",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show Student class in combo box for Fetch Student Record
		/// </summary>
		public SqlDataReader  showStudentIDInCombo1(string c)
		{
			//sqcomm=new SqlCommand ("select seq_Student_ID from Student_Record where student_class='" + c + "' order by seq_Student_ID",sqcon);
			sqcomm=new SqlCommand ("select Student_ID from Student_Record where student_class='" + c + "' order by Student_ID",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// this method use to Show Student Id  for Fetch Student Record  of Fees Paid   
		/// </summary>
		public SqlDataReader  showStudentIDForFeesPaid()
		{
			
			sqcomm=new SqlCommand ("select sr.seq_Student_ID from student_record sr where sr.student_id in(select student_id from StudentPaidFees)",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show  Student Class For fees Decision
		/// </summary>
		public SqlDataReader  showStudentClassforReport()
		{
			
			//sqcomm=new SqlCommand ("select class_name from class where class_id in(select Class_id from FeesDecision) order by class_id",sqcon);
			//sqcomm=new SqlCommand ("select distinct class_id from feesdecision where class_id in(select Class_id from FeesDecision) order by class_id",sqcon);
			//sqcomm=new SqlCommand ("select class_name from class where class_id in(select distinct class_id from feesdecision) order by class_id",sqcon);
			sqcomm=new SqlCommand ("select class_name from class order by class_id",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// this method use to Show  StudentId for fetching Record
		/// </summary>
		public SqlDataReader  showSubjectID()
		{
			
			//sqcomm=new SqlCommand ("select distinct Subject from  teacher_Timetable",sqcon);
			sqcomm=new SqlCommand ("select distinct Subject_name from  subject",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// ProShowStudentInfo for fetching Record of selected Student_ID 
		/// </summary>
 		public SqlDataReader  ShowStudentInfo()
		{
				
			sqcom=new SqlCommand ("ProShowStudentInfo",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters.Add("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
       
		/// <summary>
		/// ProSelectStudentCategory   for fetching Record of selected Student_Class And Student_Category 
		/// </summary>
		public SqlDataReader  ShowStudentCategory()
		{   
			sqcom=new SqlCommand ("ProSelectStudentCategory",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_Class",Student_Class);
			sqcom.Parameters .Add ("@Student_Category",Student_Category);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
 
		/// <summary>
		/// ProShowStudentInfoForGatePass  for fetching Record of  Student for selected Student_ID 
		/// </summary>
		public SqlDataReader  ShowStudentInfoForGatePass()
		{			
			sqcom=new SqlCommand ("ProShowStudentInfoForGatePass",sqcon);
			sqcom.CommandType=CommandType.StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
		//	sqcom.Parameters .Add ("@Student_ID",15);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// ShowAttandanceCount  for fetching Record of  Student for selected Student_ID 
		/// </summary>
		public SqlDataReader  ShowStudentAttandance()
		{
		
			sqcom=new SqlCommand ("ShowAttandanceCount",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@StudentID",StudentID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// ProShowStudentparentsInformation  for fetching Record of  Parents for selected Student_ID 
		/// </summary>
		public SqlDataReader  ShowStudentParnetsInfo()
		{
				
			sqcom=new SqlCommand ("ProShowStudentparentsInformation",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// proSelectedStudentIDfees  for fetching Record of  Student fees  for selected Student_ID 
		/// </summary>
		public SqlDataReader  ShowStudentInformationForFeesEntry()
		{
			
			sqcom=new SqlCommand ("proSelectedStudentIDfees",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
	
		/// <summary>
		/// proSelectedStudentIDfees  for fetching Record of  Student fees  for selected Student_ID 		
		/// </summary>
		public SqlDataReader  Showentryfees()
		{
			
			sqcom=new SqlCommand ("proSelectedStudentIDfees",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// proSelectStudentAssignment  for fetching Record of  Student Assignment  for selected Student_ID 	
		/// </summary>
		public SqlDataReader  ShowStudentInformationForAssignmentEntry()
		{
			
			sqcom=new SqlCommand ("proSelectStudentAssignment",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// proSelectStudentFeesPaid  for fetching Record of  Student Fees Paid for selected Student_ID 	
		/// </summary>
		public SqlDataReader  ShowStudentInformationForFeesPaid()
		{
			
			sqcom=new SqlCommand ("proSelectStudentFeesPaid",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}
		
		/// <summary>
		/// ShowProfit and Loss  for Show Record of  Student  for selected Student_ID 	
		/// </summary>
		public SqlDataReader  ShowPandLReport()
		{
			
			sqcom=new SqlCommand ("ShowPandL",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// proSelectedStaffName  for Show Record of the Staff  for selected Staff_Name 
		/// </summary>
		public SqlDataReader  ShowSubjectNameForAssignmentEntry()
		{
				
			sqcom=new SqlCommand ("proSelectedStaffName",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Staff_Name",Staff_Name);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// ProupdateFeesDecision  for Update Record of the Student  for selected Student Calss
		/// </summary>
		public SqlDataReader  insertUpdateValueFornewColumn()
		{
			sqcom=new SqlCommand ("ProupdateFeesDecision",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_Calss",Student_Calss);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// ProInsertStudentDecisionforstudent  for Insert Student Decision  
		/// </summary>
		public void InsertFeesDecisionforstudent()
		{ 
    		sqcomm=new SqlCommand("ProInsertFeesDecisionforstudent",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Student_Calss",Student_Calss);
			sqcomm.Parameters.Add("@Stream",Stream);
			sqcomm.Parameters.Add("@Tution_Fees",Tution_Fees);
			sqcomm.Parameters.Add("@Sports_Fees",Sports_Fees);
			sqcomm.Parameters.Add("@Lab_Fees",Lab_Fees);
			sqcomm.Parameters.Add("@Hostal_Fees",Hostal_Fees);
			sqcomm.Parameters.Add("@Mess_Fees",Mess_Fees);
			sqcomm.Parameters.Add("@Exam_Fees",Exam_Fees);
			sqcomm.Parameters.Add("@Donation_Fees",Donation_Fees);
			sqcomm.Parameters.Add("@Transportation_Fees",Transportation_Fees);
			sqcomm.Parameters.Add("@Uniform_Fees",Uniform_Fees);
			sqcomm.Parameters.Add("@Stationary_Fees",Stationary_Fees);
			sqcomm.Parameters.Add("@Library_Fees",Library_Fees);
			sqcomm.Parameters.Add("@Development_Fees",Development_Fees);
			sqcomm.Parameters.Add("@Employee_Name",Employee_Name);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// ProInsertStudentAddmission  for Insert Student Addmission .
		/// </summary>
		public void InsertStudentFacility()
		{ 
		
			sqcomm=new SqlCommand("ProInsertStudentAddmission",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Student_ID",Student_ID);
			sqcomm.Parameters.Add("@Admission_Status",Admission_Status );
			sqcomm.Parameters.Add("@Service_Hostal",Service_Hostal);
			sqcomm.Parameters.Add("@Service_Lab",Service_Lab);
			sqcomm.Parameters.Add("@Service_Library",Service_Library);
			sqcomm.Parameters.Add("@Service_Bus",Service_Bus);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// ProInsertStudentFeesPaid  for Insert Student Record For fees Paid
		/// </summary>
		public void InsertStudentFeesPaid()
		{ 
	    	sqcomm=new SqlCommand("ProInsertStudentFeesPaid",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@FeesPaidID",FeesPaidID);
			sqcomm.Parameters.Add("@Student_ID",Student_ID);
			sqcomm.Parameters.Add("@FeesPaid ",FeesPaid );
			sqcomm.Parameters.Add("@Amount",Amount);
			sqcomm.Parameters.Add("@Fees_Mode",Fees_Mode);
			sqcomm.Parameters.Add("@Employee_Name",Employee_Name);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.Parameters.Add("@Cheque_No",Cheque_No);
			sqcomm.Parameters.Add("@Cheque_Date",Cheque_Date);
			sqcomm.Parameters.Add("@Bank_Name",Bank_Name);
			sqcomm.Parameters.Add("@Card_No",Card_No);
			sqcomm.Parameters.Add("@Card_Date",Card_Date);
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// ProInsertMics  for Insert Mics Record.
		/// </summary>
		public void InsertStudentMics()
		{ 

			sqcomm=new SqlCommand("ProInsertMics",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@MiscID",MiscID);
			sqcomm.Parameters.Add("@Receipt_From",Receipt_From);
			sqcomm.Parameters.Add("@NameoFPayer ",NameoFPayer );
			sqcomm.Parameters.Add("@Address",Address);
			sqcomm.Parameters.Add("@City",City);
			sqcomm.Parameters.Add("@Sate",Sate);
			sqcomm.Parameters.Add("@Country",Country);
			sqcomm.Parameters.Add("@Place",Place);
			sqcomm.Parameters.Add("@Purpose",Purpose);
			sqcomm.Parameters.Add("@Duration",Duration);
			sqcomm.Parameters.Add("@Rupees",Rupees);

		}
 
     
		/// <summary>
		/// insert the value of Issue item
		/// </summary>
		public void InsertIssueItem()
		{ 
			sqcomm=new SqlCommand("ProInsertIssueItem",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@IssueID",IssueID);
			sqcomm.Parameters.Add("@Designation",Designation);
			sqcomm.Parameters.Add("@EmpID",EmpID);
			sqcomm.Parameters.Add("@EmpName",Empname);
			sqcomm.Parameters.Add("@ItemCategory",ItemCategory);
			sqcomm.Parameters.Add("@ItemName",Itemname);
			sqcomm.Parameters.Add("@Qty",Qty);
			sqcomm.Parameters.Add("@IssueDate",Issuedate);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.ExecuteNonQuery();
		}
		
		/// <summary>
		/// this method use to Update the value of Issue item
		/// </summary>
		public void UpdateIssueItem()
		{ 
			sqcomm=new SqlCommand("ProUpdateIssueItem",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@IssueID",IssueID);
			sqcomm.Parameters.Add("@Designation",Designation);
			sqcomm.Parameters.Add("@EmpID",EmpID);
			sqcomm.Parameters.Add("@EmpName",Empname);
			sqcomm.Parameters.Add("@ItemCategory",ItemCategory);
			sqcomm.Parameters.Add("@ItemName",Itemname);
			sqcomm.Parameters.Add("@Qty",Qty);
			sqcomm.Parameters.Add("@IssueDate",Issuedate);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.ExecuteNonQuery();
		}
		
		////ProInsertPaymentAuthentication for Payment Mode.
//		public void InsertPaymentAuthentication()
//		{ 
//
//			sqcomm=new SqlCommand("ProInsertPaymentAuthentication",sqcon);
//			sqcomm.CommandType =CommandType.StoredProcedure;
//			sqcomm.Parameters.Add("@Investment_id",Investment_id);
//			sqcomm.Parameters.Add("@Categoryofpayble",Categoryofpayble);
//			sqcomm.Parameters.Add("@OutsiderPayment ",OutsiderPayment );
//			sqcomm.Parameters.Add("@Amount",Amount);
//			sqcomm.Parameters.Add("@PaybleMode",PaybleMode);
//			sqcomm.Parameters.Add("@BillNo",BillNo);
//			sqcomm.Parameters.Add("@BillDate",BillDate);
//			sqcomm.Parameters.Add("@Nameofpayee",Nameofpayee);
//			sqcomm.Parameters.Add("@Address",Address);
//			sqcomm.Parameters.Add("@City",City);
//			sqcomm.Parameters.Add("@State",State);
//			sqcomm.Parameters.Add("@Country",Country);
//			sqcomm.Parameters.Add("@Location",Location);
//			sqcomm.Parameters.Add("@PaymentMode",PaymentMode);
//			sqcomm.Parameters.Add("@ChequeNo",ChequeNo);
//			sqcomm.Parameters.Add("@BankName",BankName);
//			sqcomm.Parameters.Add("@ChequeDate",ChequeDate);
//			sqcomm.Parameters.Add("@CreatedBy",CreatedBy);
//			sqcomm.Parameters.Add("@TotalRupees",TotalRupees);
//			sqcomm.Parameters.Add("@Remarks",Remarks);
//			sqcomm.ExecuteNonQuery();
//          
//		}

		/// <summary>
		/// ProInsertStudentRecuring for  Student Recuring Report.
		/// </summary>
		public void InsertStudentRecuringReceipt()
		{ 
	
			sqcomm=new SqlCommand("ProInsertStudentRecuring",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@RecuringID",RecuringID);
			sqcomm.Parameters.Add("@Student_ID",Student_ID);
			sqcomm.Parameters.Add("@Fees_Type",Fees_Type );
			sqcomm.Parameters.Add("@Period",Period);
			sqcomm.Parameters.Add("@Paymode",PaymentMode);
			sqcomm.Parameters.Add("@ChequeNo",Cheque_No);
			sqcomm.Parameters.Add("@ChequeDate",Cheque_Date);
			sqcomm.Parameters.Add("@ChBank",Bank_Name);
			sqcomm.Parameters.Add("@FeeSubDate",FeeSubdt);
			sqcomm.Parameters.Add("@DraftNo",draftno);
			sqcomm.Parameters.Add("@Class",Class);      // add by vikas sharma date on 11.03.08
			sqcomm.Parameters.Add("@DrBank",BankName);
			sqcomm.Parameters.Add("@PeriodTo",PeriodTo);
			//sqcomm.Parameters.Add("@Penalty",Penalty);
			//sqcomm.Parameters.Add("@Interest",Interest);
			sqcomm.Parameters.Add("@Fees_Amount",Fees_Amount);
			sqcomm.Parameters.Add("@AmountDue",AmountDue);
			sqcomm.Parameters.Add("@EnteredBy",EnteredBy);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.Parameters.Add("@Securityfee",Securityfee);
			sqcomm.Parameters.Add("@Latefee",Latefee);
			//****************
			sqcomm.Parameters.Add("@Diary_Fee",Diary_Fee);
			sqcomm.Parameters.Add("@Activity_Fee",Activity_Fee);
			sqcomm.Parameters.Add("@Science_Fee",Science_Fee);
			sqcomm.Parameters.Add("@Game_Fee",Game_Fee);
			sqcomm.Parameters.Add("@Transportation_Fee",Transportation_Fees);
			sqcomm.Parameters.Add("@Envp_Fee",Envp_Fee);
			sqcomm.Parameters.Add("@Annual_Fee",Annual_Fee);
			sqcomm.Parameters.Add("@Computer_Fee",Computer_Fee);
			sqcomm.Parameters.Add("@Admission_Fee",Admission_Fee);
			sqcomm.Parameters.Add("@Tution_Fee",Tution_Fees);
			sqcomm.Parameters.Add("@Hostal_Fee",Hostal_Fees);
			//****************
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// this method use to Select Receipt From Misc Table
		/// </summary>
		public SqlDataReader  ShowReceiptFrom()
		{
			
			sqcomm=new SqlCommand ("select  distinct Receipt_From from MiscTable",sqcon);
			sqred=sqcomm.ExecuteReader();
			return sqred;
			
		}

		/// <summary>
		/// ProEditStudentRecord Receipt From Misc Table
		/// </summary>
		public SqlDataReader  ShowStudentRecordForEdit()
		{
				
			sqcom=new SqlCommand ("ProEditStudentRecord",sqcon);
			sqcom.CommandType=CommandType .StoredProcedure;
			sqcom.Parameters .Add ("@Student_ID",Student_ID);
			sqred=sqcom.ExecuteReader();
			return sqred;
		}

		/// <summary>
		/// ProInsertPaymentAuthentication for Payment Mode.
		/// </summary>
		public void InsertPaymentAuthentication()
		{ 

			sqcomm=new SqlCommand("ProInsertPaymentAuthentication",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Investment_id",Investment_id);
			//sqcomm.Parameters.Add("@Categoryofpayble",Categoryofpayble);
			sqcomm.Parameters.Add("@OutsiderPayment ",OutsiderPayment );
			sqcomm.Parameters.Add("@Amount",Amount);
			sqcomm.Parameters.Add("@PaybleMode",PaybleMode);
			sqcomm.Parameters.Add("@BillNo",BillNo);
			sqcomm.Parameters.Add("@BillDate",BillDate);
			sqcomm.Parameters.Add("@Nameofpayee",Nameofpayee);
			sqcomm.Parameters.Add("@Address",Address);
			sqcomm.Parameters.Add("@City",City);
			sqcomm.Parameters.Add("@State",State);
			sqcomm.Parameters.Add("@Country",Country);
			//sqcomm.Parameters.Add("@Location",Location);
			sqcomm.Parameters.Add("@PaymentMode",PaymentMode);
			sqcomm.Parameters.Add("@ChequeNo",ChequeNo);
			sqcomm.Parameters.Add("@BankName",BankName);
			sqcomm.Parameters.Add("@ChequeDate",ChequeDate);
			sqcomm.Parameters.Add("@CreatedBy",CreatedBy);
			sqcomm.Parameters.Add("@TotalRupees",TotalRupees);
			sqcomm.Parameters.Add("@Itemnm",Itemname);
			sqcomm.Parameters.Add("@qty1",Qty);
			sqcomm.Parameters.Add("@parti",Particulars);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			
			sqcomm.ExecuteNonQuery();
          
		}

		/// <summary>
		/// ProInsertStockTransaction for StockTransaction.
		/// </summary>
		public void ProInsertStockTransaction()
		{ 

			sqcomm=new SqlCommand("ProInsertStockTransaction",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@ST_ID",ST_ID);
			sqcomm.Parameters.Add("@Tran_Type",Tran_Type);
			sqcomm.Parameters.Add("@Tran_No",Tran_No);
			sqcomm.Parameters.Add("@Tran_Date",Trans_Date);
			sqcomm.Parameters.Add("@Vendor_Name",Vendor_Name);
			sqcomm.Parameters.Add("@Place",Place);
			sqcomm.Parameters.Add("@Stock_Loc",Stock_Location);
			sqcomm.Parameters.Add("@Item_ID",Itemname);
			sqcomm.Parameters.Add("@Item_Qty",Qty);
			sqcomm.Parameters.Add("@Rate",Rate);
			sqcomm.Parameters.Add("@BillNo",BillNo);
			sqcomm.Parameters.Add("@BillDate",BillDate);
			sqcomm.Parameters.Add("@Remark",Remarks);
			sqcomm.Parameters.Add("@Vehicle",Vehicle);
			sqcomm.ExecuteNonQuery();
        }

		/// <summary>
		/// ProInsertPaymentAuthentication for Payment Mode.
		/// </summary>
		public void UpdateStock()
		{ 
            sqcomm=new SqlCommand("ProUpdateStock",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@Investment_id",Investment_id);
			//sqcomm.Parameters.Add("@Categoryofpayble",Categoryofpayble);
			sqcomm.Parameters.Add("@OutsiderPayment ",OutsiderPayment );
			sqcomm.Parameters.Add("@Amount",Amount);
			sqcomm.Parameters.Add("@PaybleMode",PaybleMode);
			sqcomm.Parameters.Add("@BillNo",BillNo);
			sqcomm.Parameters.Add("@BillDate",BillDate);
			sqcomm.Parameters.Add("@Nameofpayee",Nameofpayee);
			sqcomm.Parameters.Add("@Address",Address);
			sqcomm.Parameters.Add("@City",City);
			sqcomm.Parameters.Add("@State",State);
			sqcomm.Parameters.Add("@Country",Country);
			//sqcomm.Parameters.Add("@Location",Location);
			sqcomm.Parameters.Add("@PaymentMode",PaymentMode);
			sqcomm.Parameters.Add("@ChequeNo",ChequeNo);
			sqcomm.Parameters.Add("@BankName",BankName);
			sqcomm.Parameters.Add("@ChequeDate",ChequeDate);
			sqcomm.Parameters.Add("@CreatedBy",CreatedBy);
			sqcomm.Parameters.Add("@TotalRupees",TotalRupees);
			sqcomm.Parameters.Add("@Itemname",Itemname);
			sqcomm.Parameters.Add("@Qty",Qty);
			sqcomm.Parameters.Add("@Particulars",Particulars);
			sqcomm.Parameters.Add("@Remarks",Remarks);
			sqcomm.ExecuteNonQuery();
          }
		
		/// <summary>
		/// ProUpdateStockTransaction for Payment Mode.
		/// </summary>
		public void UpdateStockTransaction()
		{ 
			sqcomm=new SqlCommand("ProUpdateStockTransaction",sqcon);
			sqcomm.CommandType =CommandType.StoredProcedure;
			sqcomm.Parameters.Add("@ST_ID",ST_ID);
			//sqcomm.Parameters.Add("@Tran_Type",Tran_Type);
			sqcomm.Parameters.Add("@Tran_No",Tran_No);
			//sqcomm.Parameters.Add("@Tran_Date",Trans_Date);
			sqcomm.Parameters.Add("@Vendor_Name",Vendor_Name);
			sqcomm.Parameters.Add("@Place",Place);
			sqcomm.Parameters.Add("@Stock_Loc",Stock_Location);
			sqcomm.Parameters.Add("@Item_ID",Itemname);
			sqcomm.Parameters.Add("@Item_Qty",Qty);
			sqcomm.Parameters.Add("@Rate",Rate);
			sqcomm.Parameters.Add("@BillNo",BillNo);
			sqcomm.Parameters.Add("@BillDate",Trans_Date);
			sqcomm.Parameters.Add("@Remark",Remarks);
			sqcomm.Parameters.Add("@Vehicle",Vehicle);
			sqcomm.ExecuteNonQuery();
						          
		}
     }
   }









