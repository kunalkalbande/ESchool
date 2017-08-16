
 var SecondLineVertical=0;	
	var NoOffFirstLineMenus=11;			// Number of first level items
	var LowBgColor='#d3d3d3';			// Background color when mouse is not over
	var HighBgColor='#FDFBAA';			// Background color when mouse is over
	var FontLowColor='#9900CC';			// Font color when mouse is not over
	var FontHighColor='#242729';			// Font color when mouse is over
	var BorderColor='#FDFBAA';			// Border color
	var BorderWidth=1;				// Border width
	var BorderBtwnElmnts=1;			// Border between elements 1 or 0
	var FontFamily="Arial"			// Font family menu items
	var FontSize=7;				// Font size menu items
	var FontBold=1;				// Bold menu items 1 or 0
	var FontItalic=0;				// Italic menu items 1 or 0
	var MenuTextCentered='center';			// Item text position 'left', 'center' or 'right'
	var MenuCentered='center';			// Menu horizontal position 'left', 'center', 'right' or justify
	var MenuVerticalCentered='top';		// Menu vertical position 'top', 'middle','bottom' or static
	var ChildOverlap=.2;				// horizontal overlap child/ parent
	var ChildVerticalOverlap=.2;			// vertical overlap child/ parent
	var StartTop=131;				// Menu offset x coordinate
	var StartLeft=0;				// Menu offset y coordinate
	var VerCorrect=1;				// Multiple frames y correction
	var HorCorrect=1;				// Multiple frames x correction
	var LeftPaddng=5;				// Left padding
	var TopPaddng=2;				// Top padding
	var FirstLineHorizontal=1;			// First level items layout horizontal 1 or 0
	var MenuFramesVertical=0;			// Frames in cols or rows 1 or 0
	var DissapearDelay=1000;			// delay before menu folds in
	var TakeOverBgColor=1;			// Menu frame takes over background color subitem frame
	var FirstLineFrame='navig';			// Frame where first level appears
	var SecLineFrame='space';			// Frame where sub levels appear
	var DocTargetFrame='space';			// Frame where target documents appear
	var TargetLoc='';				// span id for relative positioning
	var MenuWrap=1;				// enables/ disables menu wrap 1 or 0
	var RightToLeft=0;				// enables/ disables right to left unfold 1 or 0
	var BottomUp=0;				// enables/ disables Bottom up unfold 1 or 0
	var UnfoldsOnClick=0;			// Level 1 unfolds onclick/ onmouseover
	var WebMasterCheck=1;			// menu tree checking on or off 1 or 0
	var KeepHilite=1;				// Keep selected path highligthed
	var BaseHref="";				// base href for relative liks
	var Arrws=[BaseHref+"tri.gif",5,10,BaseHref+"tridown.gif",10,5,BaseHref+"trileft.gif",5,10,BaseHref+"triup.gif",10,5];
						// Arrow source, width and height
						// If arrow images are not needed keep source ""
	var MenuUsesFrames=1;			// frames or single page 1 or 0
	var RememberStatus=0;			// When set to 1, menu unfold can be preset  by body onload of target document.
						// In frame setup body onload is:
						// onload="if(parent.frames[0]&&parent.frames['navig'].SetMenu)parent.frames['navig'].SetMenu='x_x';"
						// In singel page setup body onload is:
						// onload="if(window.SetMenu)window.SetMenu='x_x'"
						// x_x represents the menu item MenuX_X=new Array(.......

function BeforeStart(){return}
function AfterBuild(){return}
function BeforeFirstOpen(){return}
function AfterCloseAll(){return}

// Menu tree
//	MenuX=new Array(ItemText, Link, background image, number of sub elements, height, width, bgcolor, bghighcolor, fontcolor, fonthighcolor,bordercolor,
//			fontfamily,fontsize,fontbold,fontitalic,textalign,statustext);
// 	color and font variables take precedence over the globals when used
// 	fontsize, fontbold and fontitalic are ignored when -1
//	For rollover images ItemText format is:  "rollover:Image1.jpg:Image2.jpg"


Menu1=new Array("Student Management","","",8,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_1=new Array("Admission","","",4,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_1_1=new Array("Registration ","../../../Form/StudentRegistration.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");

Menu1_1_2=new Array("Gate Pass ","../../../Form/Gate_Pass.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_1_3=new Array("Subject Decision  ","../../../Form/Student_SubjectDecesion.aspx","",0,30,100,"","","","","","",-1,-1,-1,"","");
Menu1_1_4=new Array("Fees Decision","../../../Form/FeesChange.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_2=new Array("Daily Activity","","",2,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_2_1=new Array("Attandance ","../../../Form/AttendanceSheet.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_2_2=new Array("Leave ","../../../Form/Student_LeaveForm.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_3=new Array("Examination","","",2,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_3_1=new Array("Assignment ","../../../Form/Student_AssignmentForm.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_3_2=new Array("Marks Entry ","../../../Form/Student_MarksEntry.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_4=new Array("Health","","",1,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_4_1=new Array("Health Chekup ","","",4,30,70,"","","","","","",-1,-1,-1,"","");
Menu1_4_1_1=new Array("Monthly ","../../../Health/studenthealthcheck.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_4_1_2=new Array("Quarterly ","../../../Health/studenthealthcheck.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_4_1_3=new Array("Half yearly ","../../../Health/studenthealthcheck.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_4_1_4=new Array("Yearly ","../../../Health/studenthealthcheck.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_5=new Array("Sports ","../../../Games/Studentsports.aspx","",0,20,70,"","","","","","",-1,-1,-1,"","");
Menu1_6=new Array("Computer Education ","../../../Computer/Computereducation.aspx","",0,30,70,"","","","","","",-1,-1,-1,"","");
Menu1_7=new Array("Certificate's","","",3,30,50,"","","","","","",-1,-1,-1,"","");
Menu1_7_1=new Array("TC","../../certificate/Tc.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");
Menu1_7_2=new Array("No Dues","../../../certificate/Nodues.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");
Menu1_7_3=new Array("Suspend","../../../certificate/Suspend.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");

Menu1_8=new Array("PTA","","",3,25,70,"","","","","","",-1,-1,-1,"","");
Menu1_8_1=new Array("Member ","../../../Pta/Ptamember.aspx","",0,30,70,"","","","","","",-1,-1,-1,"","");
Menu1_8_2=new Array("Member Meeting ","../../../Pta/ptameeting.aspx","",0,30,70,"","","","","","",-1,-1,-1,"","");
Menu1_8_3=new Array("Communication ","../../../Pta/ptacommunication.aspx","",0,30,70,"","","","","","",-1,-1,-1,"","");


Menu2=new Array("Personal Management","","",7,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_1=new Array("Employee Detail","../../../../Form/Staffname.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_2=new Array("Daily Attendance","../../../Form/Attendance.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_3=new Array("Staff leave","../../../Form/Staff_leave.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_4=new Array("Allowances & Deduction","../../../Form/Allowancesdeduction.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_5=new Array("Leave Allowed","../../../Form/Leaveallowed.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_6=new Array("Staff Type Insertion","../../../Form/Staff_typeinsertion.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu2_7=new Array("Doctor Insertion","../../../Health/doctor.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");

Menu3=new Array("Time Table","","",11,20,60,"","","","","","",-1,-1,-1,"","");
Menu3_1=new Array("Class Master","../../../Form/classedit.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_2=new Array("Class Wise Subject Master","../../../Form/Classwisesubjects.aspx","",0,40,60,"","","","","","",-1,-1,-1,"left","");
Menu3_3=new Array("Subject Master","../../../Form/Subjectinsertion.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_4=new Array("Teacher Time Table","../../../Form/Teachertimetable.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_5=new Array("Time Table Adjustment","../../../Form/Timetableadjustment.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_6=new Array("Computer Course ","../../../Computer/Computercourse.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_7=new Array("Teacher Registration","../TimeTable/Teacher.aspx","",0,40,60,"","","","","","",-1,-1,-1,"left","");
Menu3_8=new Array("Class ","../TimeTable/Class.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_9=new Array("Holiday","../TimeTable/Holiday.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_10=new Array("Hours ","../TimeTable/Hours.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu3_11=new Array("Subject ","../../TimeTable/subject.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");

Menu4=new Array("Logistic Management","","",8,20,80,"","","","","","",-1,-1,-1,"","");
Menu4_1=new Array("Oil Master","../../../Form/Oiledit.aspx","",0,20,80,"","","","","","",-1,-1,-1,"left","");
Menu4_2=new Array("Oil detail Master","../../../Form/Oildetail.aspx","",0,20,80,"","","","","","",-1,-1,-1,"left","");
Menu4_3=new Array("Route Master","../../../Form/Routeedit.aspx","",0,20,80,"","","","","","",-1,-1,-1,"left","");
Menu4_4=new Array("Vehicle Category Master ","../../../Form/Vehicle.aspx","",0,30,80,"","","","","","",-1,-1,-1,"left","");
Menu4_5=new Array("Vechile Entry","../../../Form/Vechile_entryform.aspx","",0,20,80,"","","","","","",-1,-1,-1,"left","");
Menu4_6=new Array("Driver Record","../../../Form/Driver_entryform.aspx","",0,20,80,"","","","","","",-1,-1,-1,"left","");
Menu4_7=new Array("Driver ICard Creation","../../../Form/drivericard.aspx","",0,30,80,"","","","","","",-1,-1,-1,"left","");
Menu4_8=new Array("Driver ICard Issue","../../../Form/Drivericardissue.aspx","",0,30,80,"","","","","","",-1,-1,-1,"left","");


Menu5=new Array("Library Management ","","",8,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_1=new Array("Issue Budget","../../../Library/FORMS/BudgetIssueForm.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_2=new Array("Purchase Order","../../../Library/FORMS/PurchaseOrder.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_3=new Array("Supplier's Order Form","../../../Library/FORMS/SupplierForm.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_4=new Array("Book Entry","../../../Library/FORMS/Itemform.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_5=new Array("MemberShip","../../../Library/FORMS/MemberShipForm.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_6=new Array("Card Generation ","../../../Library/FORMS/CardGeneration.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_7=new Array("Issue Books ","../../Library/FORMS/IssueBookDuplicate.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");
Menu5_8=new Array("Return Issue Book ","../../../Library/FORMS/ReturnIssueBook.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");


Menu6=new Array("Accounts Management ","","",8,25,80,"","","","","","",-1,-1,-1,"","");
Menu6_1=new Array("Fees Decision","../../../StudentFees/FessDecision.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_2=new Array("Investment","../../../StudentFees/Investments.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_3=new Array("Miscellanies","../../../StudentFees/Misc.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_4=new Array("Fees Paid","../../../StudentFees/StudentFeesPaid.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_5=new Array("Pay Slip","../../../StudentFees/PaySlip.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_6=new Array("Fees Receipt","../../../StudentFees/RecuringFeesReceipt.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_7=new Array("Profit & Loss","../../../StudentFees/Profitloss.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu6_8=new Array("Balance Sheet","../../../StudentFees/BalanceSheet.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");


Menu7=new Array("Lab Management ","","",2,25,80,"","","","","","",-1,-1,-1,"","");
Menu7_1=new Array("Lab Booking","../../../Lab/Labbooking.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu7_2=new Array("Lab Master","../../../Lab/Labmast.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");


Menu8=new Array("Hostel Management","","",4,20,60,"","","","","","",-1,-1,-1,"","");
Menu8_1=new Array("Registration","../../../Hostel/Room_booking.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu8_2=new Array("Room Master","../../../Hostel/Room_mast.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu8_3=new Array("Menu Creation","../../../Hostel/Dinner.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");
Menu8_4=new Array("Hostel Fess","../../../Hostel/Hostel_fees.aspx","",0,20,80,"","","","","","",-1,-1,-1,"","");


Menu9=new Array("E-Coaching ","","",3,20,60,"","","","","","",-1,-1,-1,"","");
Menu9_1=new Array("Registration","../../../e-Coaching/Form/Registration.aspx","",0,25,60,"","","","","","",-1,-1,-1,"","");
Menu9_2=new Array("Teacher Record","../../../e-Coaching/Form/Teacher.aspx","",0,25,60,"","","","","","",-1,-1,-1,"","");
Menu9_3=new Array("Teaching Schedule","../../e-Coaching/Form/TeachingSchedule.aspx","",0,25,60,"","","","","","",-1,-1,-1,"","");



Menu10=new Array("Reports ","","",11,20,50,"","","","","","",-1,-1,-1,"","");

Menu10_1=new Array("Student Reports ","","",8,35,50,"","","","","","",-1,-1,-1,"","");
Menu10_1_1=new Array("Student Information ","../../../Reports/Student_Information.aspx","",0,20,130,"","","","","","",-1,-1,-1,"","");
Menu10_1_2=new Array("Student Category ","../../../Reports/DetailsOFCaste.aspx","",0,20,130,"","","","","","",-1,-1,-1,"","");
Menu10_1_3=new Array("Student Attandance ","../../../Reports/AttandanceReport.aspx","",0,20,130,"","","","","","",-1,-1,-1,"","");
Menu10_1_4=new Array("Parents Information ","../../../Reports/ParentsInformation.aspx","",0,20,130,"","","","","","",-1,-1,-1,"","");
Menu10_1_5=new Array("Result ","../../../Reports/ResultReport.aspx","",0,20,100,"","","","","","",-1,-1,-1,"","");
Menu10_1_6=new Array("Computer Student","../../../Computer/Copmuterrpt.aspx","",0,20,100,"","","","","","",-1,-1,-1,"","");
Menu10_1_7=new Array("Student Health","../../../Health/studentrpt.aspx","",0,20,100,"","","","","","",-1,-1,-1,"","");
Menu10_1_8=new Array("Student Games","../../../Games/gamereport.aspx","",0,20,100,"","","","","","",-1,-1,-1,"","");



Menu10_2=new Array("Salary Reports","","",6,35,50,"","","","","","",-1,-1,-1,"","");
Menu10_2_1=new Array("Complete Salary Of Staff","../../../Reports/Completesalarydata.aspx","",0,35,50,"","","","","","",-1,-1,-1,"","");
Menu10_2_2=new Array("Pay Slip","../../../Reports/Payslip.aspx","",0,30,50,"","","","","","",-1,-1,-1,"","");
Menu10_2_3=new Array("Salary Sheet ","../../../../Reports/salarysheet.aspx","",0,30,50,"","","","","","",-1,-1,-1,"","");
Menu10_2_4=new Array("Tax Calcution","../../../Reports/Taxcalcution.aspx","",0,30,50,"","","","","","",-1,-1,-1,"","");
Menu10_2_5=new Array("Staff Performance Subject Wise","../../../Reports/Staffperformancesubjectwise.aspx","",0,45,100,"","","","","","",-1,-1,-1,"","");
Menu10_2_6=new Array("Staff Leave","../../../Reports/Staffleaverpt.aspx","",0,45,100,"","","","","","",-1,-1,-1,"","");

Menu10_3=new Array("Time Table ","","",10,35,70,"","","","","","",-1,-1,-1,"","");
Menu10_3_1=new Array("Class wise subject","../../../Reports/Classwisesubjectreport.aspx","",0,40,40,"","","","","","",-1,-1,-1,"","");
Menu10_3_2=new Array("Teachers In Staff Room","../../../Reports/allstaff.aspx","",0,40,40,"","","","","","",-1,-1,-1,"","");
Menu10_3_3=new Array("Teachers In Class Room  ","../../../Reports/TeachersinClassroomrpt.aspx","",0,45,40,"","","","","","",-1,-1,-1,"","");
Menu10_3_4=new Array("Teachers Time Table","../../../Reports/Teachertimetable.aspx","",0,40,40,"","","","","","",-1,-1,-1,"","");
Menu10_3_5=new Array("Class Time Table","../../../Reports/Classwisesubjectreport.aspx","",0,40,45,"","","","","","",-1,-1,-1,"","");
Menu10_3_6=new Array("Holiday List","../TimeTable/HolidayList.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu10_3_7=new Array("Hour List ","../TimeTable/HourList.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu10_3_8=new Array("Subject Teacher Lsit","../TimeTable/SubjectTeacherList.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu10_3_9=new Array("Teacher List ","../TimeTable/TeacherList.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");
Menu10_3_10=new Array("Teacher Select ","../TimeTable/TeacherSelected.aspx","",0,30,60,"","","","","","",-1,-1,-1,"left","");

Menu10_4=new Array("Logistic ","","",3,20,50,"","","","","","",-1,-1,-1,"","");
Menu10_4_1=new Array("Vechile Report","../../../Reports/Vechile_report.aspx","",0,40,40,"","","","","","",-1,-1,-1,"","");
Menu10_4_2=new Array("Rout Search","../../../Reports/Rout_search.aspx","",0,40,45,"","","","","","",-1,-1,-1,"","");
Menu10_4_3=new Array("Driver Icard Issue","../../../Reports/drivericardissuerpt.aspx","",0,40,45,"","","","","","",-1,-1,-1,"","");

Menu10_5=new Array("Library ","","",0,20,50,"","","","","","",-1,-1,-1,"","");
Menu10_6=new Array("Accounts","","",5,20,50,"","","","","","",-1,-1,-1,"","");
Menu10_6_1=new Array("Fees Decision","../../../StudentFees/FeesDecisionReport.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_6_2=new Array("Fees Receipt","../../../StudentFees/FeesReceipt.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_6_3=new Array("Due Report","../../../StudentFees/FeesDueReport.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_6_4=new Array("Fees Search","../../../StudentFees/FeesSearch.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_6_5=new Array("Report For donar","../../../StudentFees/ReportFordonar.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");



Menu10_7=new Array("Lab","","",1,20,40,"","","","","","",-1,-1,-1,"","");
Menu10_7_1=new Array("Lab Status","../../../Reports/Lab.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");

Menu10_8=new Array("Hostel","","",3,20,40,"","","","","","",-1,-1,-1,"","");
Menu10_8_1=new Array("Room Status","../../../Reports/Roomstatus.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_8_2=new Array("Room Wise Student","../../../Reports/Roomwisestudent.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_8_3=new Array("Menu Search","../../../Reports/daywisefood.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");

Menu10_9=new Array("E-Caching","","",2,30,50,"","","","","","",-1,-1,-1,"","");
Menu10_9_1=new Array("Faculty Infomation","../../../Reports/FacultyInfo.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_9_2=new Array("Member Report","../../../Reports/MemberReport.aspx","",0,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_10=new Array("Email & SMS","../../../Reports/FacultyInfo.aspx","",2,40,50,"","","","","","",-1,-1,-1,"","");
Menu10_10_1=new Array("SMS","../../../mobile/SmsTest.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");
Menu10_10_2=new Array("Email","../../../Reports/mailnewcourse.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");

Menu10_11=new Array("Certificate's","","",3,30,50,"","","","","","",-1,-1,-1,"","");
Menu10_11_1=new Array("TC","../../../certificate/Tcrpt.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");
Menu10_11_2=new Array("No Dues","../../../certificate/Noduesrpt.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");
Menu10_11_3=new Array("Suspend","../../../certificate/Suspendrpt.aspx","",0,20,40,"","","","","","",-1,-1,-1,"","");



Menu11=new Array("Logout","../../../Form/Logout.aspx","",0,25,80,"","","","","","",-1,-1,-1,"","");

