<%@ Register TagPrefix="uc1" TagName="header" Src="../../usercontrol/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../../usercontrol/Footer.ascx" %>
<%@ Page CodeBehind="Help.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="EPetro.Help.Help" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>eSchool : User Manual</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">.t {
	FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #000000; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"; TEXT-DECORATION: none
}
.h {
	FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #006600; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"; TEXT-DECORATION: underline
}
.f {
	FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #009900; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"; TEXT-DECORATION: underline
}
.uh {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #009900; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"
}
.uhCopy {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #000000; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"
}
.head {
	FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #009900; FONT-FAMILY: Arial, Helvetica, sans-serif, "Arial Black"
}
</style>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<uc1:header id="Header1" runat="server"></uc1:header>
		<table cellSpacing="1" cellPadding="0" width="90%" align="center" border="0">
			<tr>
				<td>
					<div class="h" align="center">
						<p class="h">School Management System : eSchool</p>
					</div>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>
					<div class="f" align="center">User Manual
					</div>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="uh"><a name="toc"></a>Table Of Contents</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">1.0 <A href="#log">INTRODUCTION</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">2.0 <A href="#log">GETTING STARTED</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">3.0 <A href="#gettingstarted">MODULE IN e-SCHOOL</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
			<tr>
				<td class="uhCopy">4.0 <A href="#admin">FOLDER HIRARCHY DETAILS</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
			<tr>
				<td class="uhCopy">5.0 <A href="#petrolpump">TECHNICAL DESCRIPTION</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
			<tr>
				<td class="uhCopy">6.0 <A href="#shift">DATABASE SCHEMA</A></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<td class="head"><font color="#000000"><a name="intro"></a>1.0</font> INTRODUCTION</td>
			</TR>
			<tr>
				<td class="head">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">
						<p style>We are glad to announce the launch of e-School (School Management System), 
							a Web based application to handle the entire school system. 
							During&nbsp;the&nbsp;implementation&nbsp;of e-School as&nbsp;a full ERP for 
							school administration and&nbsp;interaction, we strongly realized&nbsp;the 
							need&nbsp;of a&nbsp;simple&nbsp;yet effective&nbsp;version&nbsp;of e-School, 
							which should preferably run on MS SQL server without losing&nbsp;the 
							scalability,&nbsp;flexibility&nbsp;and&nbsp;its&nbsp;core strength&nbsp;of 
							user&nbsp;friendliness with strong security of your valued database.
							<o:p></o:p></span></p>
						<span style>e-School&nbsp;is&nbsp;a&nbsp;powerful,&nbsp;fully&nbsp;browser
based&nbsp; School&nbsp; Management&nbsp; System that&nbsp; is easy to use,
fast to implement and effective&nbsp; to&nbsp; mobilize the&nbsp; school
management&nbsp; system&nbsp; in&nbsp; a great&nbsp; way</span></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="log"></a>2.0</font>GETTING 
					STARTED</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="337" src="helpfiles/Forms/login.jpg" width="575"></div>
				</td>
			</tr>
			<td class="uhCopy">
				<div class="uh" align="center">Figure 1.</div>
			</td>
			</TR>
			<tr>
				<td class="t"><div align="justify">Now user has to select user type(Administrator,Teacher,Staff....)
				and then enter login name and password To login in to software.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">
				</td>
			</tr>
			<tr>
				<td class="d">
				</td>
			</tr>
			<tr>
				<td class="f">
				</td>
			</tr>
			
			<tr>
				<td class="t"><div align="justify">After entering correct user name and password, main screen appears
				as show in figur 2.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="337" src="helpfiles/Forms/login.jpg" width="575"></div>
				</td>
			</tr>
			<td class="uhCopy">
				<div class="uh" align="center">Figure 2.</div>
			</td>
			</TR>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="gettingstarted"></a>3.0</font>MODULE IN E-SCHOOL </td>
			</tr>
			<tr>
				<td class="head">&nbsp; 
				</td>
			</tr>
			<tr>
				<td class="head">&nbsp; 
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000">The Following School Management System Moduls are Provided in e-School:- 
				</td>
			</tr>
			<tr>
				<td class="head">&nbsp; 
				</td>
			</tr>
			
			<tr>
				<td class="head">&nbsp; 
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 1&nbsp;&nbsp;</font>Student Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 2&nbsp;&nbsp;</font>Employee Management
				</td>
			</tr><tr>
				<td class="head"><font color="#000000"><a name="start"></a> 3&nbsp;&nbsp;</font>Intrective Time Table Management
				</td>
			</tr><tr>
				<td class="head"><font color="#000000"><a name="start"></a> 4&nbsp;&nbsp;</font>Logistic(TransPortation) Management
				</td>
			</tr><tr>
				<td class="head"><font color="#000000"><a name="start"></a> 5&nbsp;&nbsp;</font>Library Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 6&nbsp;&nbsp;</font>Account Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 7&nbsp;&nbsp;</font>Lab Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 8&nbsp;&nbsp;</font>Hostal Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a> 9&nbsp;&nbsp;</font>Advance e-Coaching Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a>10&nbsp;</font>Administrator Management
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="start"></a>11&nbsp;</font>Report
				</td>
			</tr>
			
			<tr>
				<td class="uhCopy"></td>
			</tr>
			
			<tr>
				<td class="uhCopy">
					<div align="right"></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="loginscreen">1</a></font>STUDENT MANAGEMENT MODULE
				</td>
			</tr>
			<tr>
				<td class="uhCopy">In This Module There Are 8 Sub Module. These Are</td>
			</tr>
			
			
			<tr>
				<td class="uhCopy">1.1 <A href="#log">Admission</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.1 <A href="#log">Ragistration</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.2 <A href="#log">Gate Pass</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.3 <A href="#log">Subject Decision</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.4 <A href="#log">Fees Decision</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.2 <A href="#log">Daily Activity</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.2.1 <A href="#log">Attendance</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.2.2 <A href="#log">Leave</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.3 <A href="#log">Examination</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.3.1 <A href="#log">Assignment</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.3.2 <A href="#log">Marks Entry</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.4 <A href="#log">Health CheckUp</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.5 <A href="#log">Sports</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.6 <A href="#log">Computer Education</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.7 <A href="#log">Certificate</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.7.1 <A href="#log">TC</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.7.2 <A href="#log">No Dues</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.7.3 <A href="#log">Suspend</A></td>
			</tr>
			<tr>
				<td class="uhCopy">1.8 <A href="#log">PTA</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.8.1 <A href="#log">Member</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.8.2 <A href="#log">Member Meeting</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.8.3 <A href="#log">Communication</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="home"></a>1.1</font>Admission</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.1 <A href="#log"> Student Ragistration</A></td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
			<td class="uhcopy"><div align=justify>In this module user can enter details of new student getting ragistered in this school.
			The information needed of student ragistration is show in figure 3. After entring all the details of student, user has to click SAVE button
			to save the record. If user want to clear the inputted values, user has to click RESET button.
			</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="337" src="helpfiles/Forms/login.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 3.</div>
				</td>
			</tr>
			<tr>
			<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.2 <A href="#log"> GATE PASS</A></td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">in this module you can view a gate pass report of student. The information
					needed for gate pass entry is show in figure 4. After filling all the information, user has to click
					the print preview button to view the gete pass report.
			</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="337" src="helpfiles/Forms/login.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
			<td class="uhCopy">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.1.3 <A href="#log"> SUBJECT DECISION</A></td>
			</tr>
			<tr>
				<td class="t">in this module user can define subject in various classes. The information needed for subject decision is show in
				in figur 5. After entring subject for class, user has to SAVE button to save the record. If user wants to clear the inputted values,
				user has to click RESET button. 
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="admin"></a>4.0</font> Administrative 
					Module</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The <strong>Administrative Module</strong> can be<strong> only 
							accessed</strong> by the <strong>Administrator</strong> and is used to 
						perform the following task.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="roles"></a>4.1</font> Roles</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Different users play different<strong> roles</strong> in using 
						the ePetro System like an <strong>administrator</strong>, <strong>accountant</strong>,
						<strong>sales manager</strong> etc.<br>
						These roles help to <strong>delineate</strong> the users to access only those 
						modules for which they have a right, thereby safe guarding the overall security 
						of the <strong>ePetro</strong> System.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newrole"></a>4.1.1</font> Create a 
					new Role</td>
			</tr>
			<tr>
				<td class="t">To create a new Role click on the link <strong>Roles</strong> in the 
					Home Page. The screen will display the screen as shown below in figure 5.</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="335" src="helpfiles/Forms/Roles.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 5.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter a Role Name for e.g. Accountant in the text box against <strong>
							Role Name</strong> and a short description about this role in the text area 
						against <strong>Description</strong> for e.g. Can access only accounts module. 
						Press the <strong>Save</strong> button to save this role. You can create as 
						much roles as required for different users.
					</div>
					<p>Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deleterole"></a>4.1.2</font> Update 
					or Delete a Role</td>
			</tr>
			<tr>
				<td class="t">To update or delete an existing Role, press the Button besides the <strong>
						Role ID</strong>, the screen will look as shown in Figure 6.</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditRoles.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 6.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<p align="justify">To update an existing role select the Role from the dropdown, 
						its details like the Role Name and Description, appears, do the necessary 
						modification and press the <strong>Save</strong> button. Similarly to delete an 
						existing role select the role from the dropdown and press the <strong>Delete</strong>
						button.</p>
					<p align="justify">Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="userprofile"></a>4.2</font> User 
					Profile
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The User Profile contains information like the <strong>User Name</strong>,
						<strong>Login Name</strong>, <strong>Full Name</strong> and the<strong> Role</strong>
						played. Without a valid profile <strong>no</strong> user can access the <strong>ePetro</strong>
						System.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createprofile"></a>4.2.1</font> Create 
					a new Profile
				</td>
			</tr>
			<tr>
				<td class="t">To create a new<strong> User Profile</strong> click on the <strong>User 
						Profile link</strong> on the Home Page.
					<p>The following page appears as shown below in figure 7.
					</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="335" src="helpfiles/Forms/UserProfile.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 7.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the <strong>Login Name</strong>, <strong>Password</strong>,
						<strong>user's full name</strong> and select an appropriate <strong>Role</strong>
						from the dropdown and press the <strong>Save</strong> <strong>Profile</strong> button.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deleteprofile"></a>4.2.2</font> Update 
					or Delete a Profile</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To update or delete an existing User Profile press the <strong>Update</strong>
						button besides the <strong>User ID</strong>. The following screen appears as 
						shown in figure 8.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditUserProfile.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 8.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>User ID</strong> from the dropdown, its 
						details appear on the screen, do the necessary updating and press the <strong>Save 
							Profile</strong> button to update. To delete an existing User profile 
						select an existing profile and simply press the <strong>Delete</strong> button.
					</div>
					<p align="justify">Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="privileges"></a>4.3</font> Privileges</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The <strong>privileges</strong> decides what level of 
						operation an user can perform in the <strong>ePetro</strong> System. Different 
						modules provide the means to access different aspect of the entire <strong>ePetro</strong>
						System, not all user should have the rights to gain easy access in its 
						entirety, and pose a danger to the security of confidential data the <strong>ePetro</strong>
						System is maintaining. The privileges of a user decides which of the following 
						operations namely<strong> Add</strong>, <strong>View</strong>, <strong>Update</strong>,
						<strong>Delete</strong> can a user perform once logged successfully into the <strong>
							ePetro</strong> System.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="allocateprivileges"></a>4.3.1</font>
					Allocate Privileges to a User
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">An administrator can allocate privileges to a user by clicking <strong>
							privileges link</strong> in the Home Page. The following screen appears as 
						shown in figure 9.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="335" src="helpfiles/Forms/Previledges.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 9.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select a <strong>User ID</strong> from the drop down, its <strong>User 
							Name</strong> appears in the Text box besides.
					</div>
					<p align="justify">The initial screen lists the following modules which are 
						governed by privileges because they provide the facility to Add, View Edit and 
						Delete, unlike modules like Reports which are only Viewed or Printed.</p>
					<p align="justify">To allocate the privileges for <strong>Account Module</strong>, 
						simply click the checkbox beside.</p>
					<p align="justify">The initial screen is expanded and appears as shown below in 
						figure 10.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center">
						<p><IMG height="393" src="helpfiles/Forms/Previledgesaccount.jpg" width="575"></p>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 10.</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Depending on the rights of the user the Administrator can now 
						click the checkboxes to select or deselect the View, Add, Edit and Delete 
						options. If the checkbox is selected then that operation can be performed by 
						that particular user.
					</div>
					<p align="justify">This step should be <strong>repeated</strong> for all the <strong>modules</strong>
						listed above; so that the entire range of modular operations of ePetro are 
						governed by safety and devoid of misuse by unauthorized users.</p>
					<p align="justify">After allocation the privileges of all modules press <strong>Save</strong>
						button.
					</p>
					<p align="justify">Click the<strong> Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="updateprivileges"></a>4.3.2</font> Update 
					Privileges of a User</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To update the privileges simply perform the above steps, 
						change the necessary settings of the checkboxes and resave the modified 
						privileges by pressing <strong>Save</strong> button.
					</div>
					<p align="justify">Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="organizationdetail"></a>4.4 </font>Organization 
					Details</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This section is meant to input one time details of the 
						organization i.e. the Petrol Station. This is a very important one time step 
						because details like Dealer Name, address, city etc. entered during this 
						process are used subsequently in Report printing, and as headers on some pages 
						like Credit Bill.
					</div>
					<p align="justify">To enter the organization details click the link <strong>Organization 
							Details</strong> on the Home Page.</p>
					<p align="justify">The following screen appears as shown in figure 11.</p>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="center"><IMG height="478" src="helpfiles/Forms/OrganizationDetail.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 11.
					</div>
				</td>
			</tr>
			<tr>
				<td class="uhCopy">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Dealership from<strong> Dealership drop down</strong>. 
						If the dealer name is not given in drop down then select the <strong>Other</strong>
						option, the <strong>Organization Details</strong> page will change and a text 
						box appears to enter the Dealership as shown in following figure 12</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="478" src="helpfiles/Forms/OrganizationDetail.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 12.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Enter the organization details. Press <strong>Browse</strong> button 
					to select an image, this image is used on the Credit Bill page. Enter the VAT 
					Rate and Message to apply and display in all invoices and specify the Accounts 
					Period. Once all the information is inputted press the <strong>Save Profile</strong>
					button.
					<p>Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="backup"></a>4.5</font> Backup &amp; 
					Restore
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The mere existence of any system is data, hence it is very 
						import to take periodical backups of your important data failing which could 
						lead to loss of several days/months of efforts. The backup process copies your 
						data into a safe location and maintains three different copies, in a folder 
						termed as GrandFather, Father and Son, the Son contains the latest version of 
						your data in the database. Hence you should periodically take backups. In case 
						of any catastrophe like database being corrupt or lost we can restore the data 
						back through the Restore process.
					</div>
					<p align="justify"><strong>Note</strong>: You should not unnecessarily start a 
						Restore process, that can accidentally corrupt your valuable data. Restore 
						should be done only after a catastrophic loss of your original database.</p>
					<p align="justify">To backup and restore the <strong>ePetro</strong> database click 
						on <strong>Backup &amp; Restore</strong> from <strong>Administration</strong> menu.</p>
					<p align="justify">The following screen appears as shown in figure 13.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/BackUp&amp;Restore.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 13 .</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">You must stop the <strong>MS-SQL Server</strong> before taking 
						a Backup or Restore. Press <strong>Backup</strong> button to backup your 
						database and to restore the database press Restore button.
					</div>
					<p align="justify">Note: This User manual assumes that the <strong>Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with backup or 
						restore) refer to the Installation Guide for the topic <A href="#how">How to start 
							the Print_WindowService</A> for <strong>DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="petrolpump"></a>5.0</font> Petrol 
					Pump Module</td>
			</tr>
			<tr>
				<td class="t">The <strong>Petrol Pump</strong> module provides the following 
					sections.</td>
			</tr>
			<tr>
				<td class="uhCopy">Tank Entry<br>
					Machine Entry<br>
					Nozzle Entry<br>
					Daily Entries</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="tankentry"></a>5.1</font> Tank 
					Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This page allows to enter <strong>Tank</strong> related 
						details. This information needs to be entered very carefully and correctly. 
						When the user clicks the link <strong>Tank Entry</strong> on the Home Page, the 
						following page is displayed as shown in figure 14.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/TankEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 14.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="addtank"></a>5.1.1</font> Add a 
					Tank</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The <strong>Tank Name</strong> is automatically generated, 
						select the <strong>Product Name</strong> from the dropdown, for example <strong>Petrol(MS)</strong>. 
						Next input a <strong>Short Name</strong> e.g. <strong>T-1/MS/20K</strong>, this 
						short name signifies that it is tank number 1, contains product <strong>MS</strong>
						and has a capacity of <strong>20000</strong> <strong>liters</strong>. This 
						short name helps to easily identify the tank. Next enter the <strong>Capacity</strong>
						for e.g. <strong>20000</strong> followed by the<strong> Water Stock</strong> and<strong>
							Opening Balance</strong>. Press the <strong>Add</strong> button to save the 
						Tank details.
					</div>
					<p align="justify">The user can then enter the Tank details for the remaining 
						Tanks. A <strong>maximum</strong> of <strong>four</strong> Tanks are allowed 
						per Product.</p>
					<p align="justify">Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="edittank"></a>5.1.2</font> Edit a 
					Tank</td>
			</tr>
			<tr>
				<td class="t">To <strong>Edit</strong> the Tank details click on the <strong>Edit</strong>
					button. The edit screen is displayed as shown below in the Figure 15.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditTankEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 15.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the necessary <strong>Tank ID</strong> to be edited, 
						the details of that Tank appears, do the necessary modification and press the <strong>
							Edit</strong> button. In case of deleting the Tank details press the <strong>Delete</strong>
						button after selecting the tank ID. Click the Home Link to return to the Home 
						Page.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="machineentry"></a>5.2</font> Machine 
					Entry</td>
			</tr>
			<tr>
				<td class="t">To enter the <strong>Machine</strong> details click on the link <strong>Machine 
						Entry </strong>on the Home Page, the following Machine Entry screen appears 
					as shown below in figure 16.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/MachineEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 16.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The Machine Name is automatically generated,. Simply select 
						the Machine Type from the dropdown list, and press the Save button. Click the 
						Home Link to return to the Home Page.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="nozzleentry"></a>5.3</font> Nozzle 
					Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To enter the <strong>Nozzle</strong> details click on the link <strong>
							Nozzle Entry</strong> on the Home Page, the following Nozzle Entry screen 
						appears as shown below in figure 17.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/NozzleEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 17.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="addnozzle"></a>5.3.1</font> Add a 
					Nozzle</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To enter the <strong>Nozzle</strong> details, first select a <strong>
							Machine Name</strong>, a <strong>Nozzle Name</strong> is automatically
					</div>
					<p align="justify">generated for example <strong>Nozzle-1</strong>. Next select the <strong>
							Tank Name</strong> to which the <strong>Machine</strong> is attached. Press <strong>
							Add</strong> button to save the Nozzle details. A <strong>maximum</strong> of
						<strong>four</strong> Nozzles are allowed per Machine.</p>
					<p align="justify">Click the <strong>Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="updatenozzle"></a>5.3.2</font> Update 
					a Nozzle</td>
			</tr>
			<tr>
				<td class="t">To <strong>Edit</strong> the <strong>Nozzle</strong> details click on 
					the <strong>Edit</strong> button. The edit screen is displayed as shown below 
					in the Figure 18.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditNozzleEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 18.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the necessary <strong>Nozzle ID</strong> to be edited, 
						the details of that <strong>Nozzle</strong> appears, do the necessary 
						modification and press the <strong>Add </strong>button. In case of deleting the <strong>
							Nozzle</strong> details press the Delete button after selecting the tank 
						ID. Click the Home Link to return to the Home Page.
					</div>
					<p align="justify"><strong>Note</strong>: The above three sections though very 
						simple to operate are very critical to the ePetro System, and depicts the 
						complete Petrol Station logically on the screen in terms of the Tanks, the 
						Machines and the Nozzles, improper updating of these entities could spoil the 
						relationship between the nozzle and the product. Utmost care should be taken by 
						the <strong>administrator</strong> himself to apply the updation 
						whenever/wherever necessary without breaking the relationship which is 
						critical.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="dailyentry"></a>5.4</font> Daily 
					Entries</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This page allows the user to enter daily readings for Tanks 
						like Density, Temperature, Opening Stock etc. and Meter readings for Nozzles. 
						This page is dynamically displayed depending upon the available Tanks, Machines 
						and their Nozzles.
					</div>
					<p align="justify">To enter the <strong>Daily Entries</strong>, click on the <strong>Daily 
							Entries link</strong>, the screen look as shown in figure 19 below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="565" src="helpfiles/Forms/DailyOperationEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 19.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the Density, Temperature, Converted-Density, Opening 
						Stock, Water-Dip and Testing value for each Tank. Next enter the Meter-Readings 
						for each Nozzle for every Machine. A textbox is provided to enter any<strong> Remarks</strong>. 
						Press the <strong>Submit</strong> button to save the daily entries.
					</div>
					<p align="justify">Click the<strong> Home Link</strong> to return to the Home Page.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="shift"></a>6.0</font> Shift And 
					Employees</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This module provides the facility to create Employees, create 
						and manage their Shifts, take daily attendance, assign or sanction leave, 
						assign overtime and print salary statements.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="employeeentry"></a>6.1</font> Employee 
					Entry
				</td>
			</tr>
			<tr>
				<td class="t">To Enter the details of a new Employee, click on the Employee Entry 
					link on the Home Page.
					<p>The Employee Entry page appears as shown in the Figure 20 below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EmployeeEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 20.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Field marked as <font color="#ff0000">* </font>are mandatory. 
						Enter the Name, address, select the city from the dropdown, enter the phone 
						numbers, and email address if any. Select the<strong> Designation</strong> from 
						the dropdown, if the designation is <strong>Driver</strong> then the <strong>Employee 
							Entry</strong> form will change, and the fields regarding driver's license 
						and insurance appears as shown in following figure 21.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="379" src="helpfiles/Forms/EmployeeEntry(Driver).jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 21.
						<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the Driver License No., LIC No. and validity dates. Next 
						enter the salary and OverTime compensation. Press the <strong>Save</strong> <strong>
							Profile</strong> button to save the Employee details. To return back to the 
						Home Page click the <strong>link Home Page</strong>.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="emplist"></a>6.2</font> Employee 
					List</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view a List of all employees click on the Employee List 
						link on the Home Page, the screen appears as shown in figure 22 below</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="searchemp"></a>6.2.1</font> Search 
					Employees</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EmployeeList.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 22.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Press the <strong>Search</strong> button to view all the employees as 
					shown below in figure 23.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EmployeeList(Search).jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 23.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">If there are more employees than use the <strong>Prev</strong> or <strong>
						Next</strong> button to navigate backward or forward.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editemp"></a>6.2.2</font> Edit an 
					Employee</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To Edit an Employee press the<strong> Edit link</strong> in 
						the above figure. For example if the Employee with ID 1001 is clicked, the 
						following screen appears as shown in figure 24.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EmployeeUpdate.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 24.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Do the necessary updation, for the designation of <strong>Driver</strong>
						the screen will change as given in above figure 21. Press the Update Profile 
						button to save the updation.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deleteemp"></a>6.2.3</font> Delete 
					an Employee</td>
			</tr>
			<tr>
				<td class="t">To Delete an Employee clink on the appropriate Delete link after the 
					search is over.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="shiftentry"></a>6.3</font> Shift 
					Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This section allows the user to create a new Shift, edit or 
						delete an existing shift.Shift Entry requires the user to input the <strong>Time 
							From</strong> and <strong>Time To</strong>, the Time To should be always 
						later than Time From.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createshift"></a>6.3.1</font> Create 
					a new Shift</td>
			</tr>
			<tr>
				<td class="t">To create a new Shift press the link Shift Entry on the Home Page, 
					the screen appears as shown in figure 25.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/ShiftEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 25.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Type a Shift name in the text-box for example <strong>General</strong>. 
						Next select the <strong>Time From</strong> and <strong>Time To</strong> from 
						the dropdown. Enter a Remark if any and press the <strong>Add</strong> button 
						to save.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editshift"></a>6.3.2</font> Edit a 
					Shift</td>
			</tr>
			<tr>
				<td class="t">To Edit an existing Shift press the <strong>Edit</strong> button, the 
					following screen appears as shown in the figure 26 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditShiftEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 26.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Shift ID from the dropdown, the details appears on the 
					screen, do the necessary modification and press the Edit button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deleteshift"></a>6.3.3</font> Delete 
					a Shift</td>
			</tr>
			<tr>
				<td class="t">After selecting a Shift ID, its details appear on the screen, simply 
					press the Delete Key to Delete the Shift.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="shiftassign"></a>6.4</font> Shift 
					Assignment</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To assign a Shift to an Employee, click the link <strong>Shift 
							Assignment</strong> in the Home Page. The following screen appears as shown 
						in figure 27 below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center">
						<p><IMG height="335" src="helpfiles/Forms/ShiftAssignment.jpg" width="575"></p>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 27.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Shift from the dropdown, the available Employees 
						are populated in the list box on the left hand side. The Shift timing is shown 
						in the text box besides. Select an employee and press the button marked &gt;. 
						The employee will be populated in the list box on the right hand side. Continue 
						selecting the employees one by one and press the &gt; button to assign the 
						shift and press the <strong>Submit</strong> button to complete the Shift 
						assignment.
					</div>
					<p align="justify">To remove an employee from the Employee Assigned list box, 
						simply select the employee and press the &lt; button, the employee will 
						reappear in the Available Employees list box. To select all the employee use 
						the &gt;&gt; button, or to deselect all employees use the &lt; button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="attendance"></a>6.5</font> Attendance 
					Register</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The Attendance Register is used to mark the attendance of an 
						employee, click the link<strong> Attendance Register</strong> on the Home Page, 
						the following screen appears as shown in figure 28 below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/AttendanceRegister.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 28.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">The <strong>Attendance Register</strong> displays the list of 
						all the employees whose attendance has <strong>not</strong> yet been marked. To<strong>
							mark </strong>the attendance select the check box for all those employees 
						who are present. To mark all the employees select the check box <strong>Select All</strong>, 
						and press <strong>Submit</strong>.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="leaveapp"></a>6.6</font> Leave 
					Application</td>
			</tr>
			<tr>
				<td class="t">To apply for a Leave Application, click the link <strong>Leave 
						Application</strong>, the following screen appears as shown below in figure 
					29.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/LeaveApplication.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 29.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Employee from the dropdown, click the datepicker 
						button, a calendar appears, select the Date From, similarly select the Date To 
						by pressing the datepicker besides. Type the <strong>Reason</strong>, for the 
						leave, and press the <strong>Apply</strong> button.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uhCopy">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="leavesanc"></a>6.7</font> Leave 
					Sanction
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">When employees apply for a leave, these leave have to be 
						sanctioned, click the link<strong> Leave Sanction</strong> on the Home Page, 
						the leave sanction page appears on the screen as shown below in figure 30.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/LeaveSanction.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 30.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">A list of all employees who have applied for leave appear, 
						select the check box under the label Accept to sanction the leave, once all the 
						leave have been sanction press the<strong> Submit</strong> button.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="overtime"></a>6.8</font> Overtime 
					Register</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To give Overtime to employees, click Overtime Register on the 
						Home Page, the following screen appears as shown below in the figure 31.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/OverTimeRegister.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 31.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Employee</strong> from the dropdown list. 
						Only employees present for the day appear in the dropdown list. Next select the 
						Date by clicking the datepicker. Select the<strong> Time From</strong> and <strong>To</strong>, 
						and press the <strong>Save</strong> button.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="salary"></a>6.9</font> Salary 
					Statement</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To generate the <strong>Salary Statement</strong>, click the 
						link <strong>Salary Statement</strong> on the Home Page, the following screen 
						appears as shown below in figure 32.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/SalaryStatement.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 32.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Month</strong> from the drop-down, the 
						current <strong>year</strong> appears in the textbox besides. Press the <strong>Show
						</strong>button to display the Salary Statement on the <strong>screen</strong>, 
						or Press the <strong>Print</strong> button to print the Salary Statement on the <strong>
							printer</strong>.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="parties"></a>7.0</font> Parties</td>
			</tr>
			<tr>
				<td class="t">This module deals with Place, Customer, Vendor and Slip information.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="beatentry"></a>7.1</font> Beat 
					Entry</td>
			</tr>
			<tr>
				<td class="t">The Beat Entry deal with Place information like City, State and 
					Country, City is mandatory.
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createbeat"></a>7.1.1</font> Create 
					a new Beat</td>
			</tr>
			<tr>
				<td class="t">To enter a new Beat, click on the <strong>Beat Entry link </strong>on 
					the Home Page, the screen will look as shown in figure 33.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/BeatEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 33.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Entry the City, followed by the State and Country. Press <strong>Add</strong>
					button to save the Beat information.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editbeat"></a>7.1.2</font> Edit a 
					Beat</td>
			</tr>
			<tr>
				<td class="t">To edit a Beat information press the<strong> Edit </strong>button, 
					the edit screen will appear as shown in figure 34.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditBeatEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 34.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Beat No. the details appear on the screen, do the 
						necessary modification and press the Edit button again to save the changes.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deletebeat"></a>7.1.3</font> Delete 
					a Beat</td>
			</tr>
			<tr>
				<td class="t">Select the <strong>Beat No.</strong> the details appear on the 
					screen, press the <strong>Delete</strong> button to delete the Beat entry.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="customerentry"></a>7.2</font> Customer 
					Entry</td>
			</tr>
			<tr>
				<td class="t">To enter Customer details, click <strong>Customer Entry</strong> link 
					on the Home Page, the following screen appears as shown in figure 35.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CustomerEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 35.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the Customer Name, then select the Customer Type from 
						the dropdown list, enter the Address of the customer, select the City, the 
						State and Country are automatically populated. City is mandatory. Enter the 
						Contact numbers and the Email address if any.<br>
						<br>
						Next enter the Credit Limit, and select the Credit Days from the dropdown list. 
						Finally enter the Opening Balance of the Customer. Press the <strong>Save Profile</strong>
						button to Save the customer information.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="slipentry"></a>7.3</font> Slip 
					Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This section is used to add and update a Book and its Slips. 
						Books can be numbered <strong>1, 2, 3</strong>.or a Book can be split into two 
						or more parts with numbering like <strong>1A</strong>, <strong>1B</strong> etc. 
						Slips are numbered sequentially from 1 to N, overlapped sequence are not 
						allowed, for example if slip numbers 1 to 100 have been already issued, then a 
						sequence like 25 to 50 cannot be repeated.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newslip"></a>7.3.1</font> Add a new 
					Slip Entry</td>
			</tr>
			<tr>
				<td class="t">To add a new Slip, click the <strong>Slip Entry</strong> link on the 
					Home Page, the following screen appears as shown in figure 36.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/SlipEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 36.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the <strong>Book Number</strong>, the <strong>Slip No.</strong>
						<strong>From</strong> is automatically populated from the earlier book, enter 
						the <strong>To</strong> slip number, this number should be greater than the 
						from number. The number of slips in this book is displayed automatically. 
						Select the <strong>Customer Name</strong> from the dropdown. Press <strong>Save</strong>
						button to create the Slip entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editslip"></a>7.3.2</font> Edit an 
					existing Slip Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To edit an already existing Slip number, press the button 
						besides the Slip ID. The following screen appears as shown below in figure 37.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditSlipEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 37.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Book ID from the dropdown list, the details are 
						automatically populated. Do the necessary updation and press <strong>Update</strong>
						button to save the changes. While updating a Slip Entry, you cannot overlap 
						slip number ranges, the system will display a error message box stating Invalid 
						Slip Entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vendorentry"></a>7.4</font> Vendor 
					Entry</td>
			</tr>
			<tr>
				<td class="t">To enter Vendor information, click <strong>Vendor Entry</strong> link 
					on the Home Page, the following screen appears as shown in figure 38.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/VenderEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 38.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter the full <strong>Name</strong> of the Vendor, then 
						select the <strong>Type</strong> of Vendor from the dropdown list. Type the 
						vendor's <strong>Address</strong> in the text-area , and select the <strong>City</strong>, 
						the State and Country are automatically populated. Enter the <strong>Contact</strong>
						numbers, and <strong>Email</strong> address if any. Enter the <strong>Opening 
							Balance</strong> and select the<strong> Balance type</strong> Cr./Dr. and 
						select the <strong>Credit Days</strong> from the drop-down list. Press the <strong>Save 
							Profile</strong> button to save the vendor information.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="customerlist"></a>7.5</font> Customer 
					List</td>
			</tr>
			<tr>
				<td class="t">Allows the user to list all Customers, and edit or delete a Customer.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="listcustomer"></a>7.5.1</font> List 
					all Customer</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To search and view all Customers click on the <strong>Customer 
							List</strong> link on the Home page. The following screen appears as shown 
						in figure 39.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CustomerList.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 39.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Press the <strong>Search</strong> button, the Customer list will be 
					displayed as shown in figure 40.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CustomerList(Search).jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 40.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">If there are more customers than can fit the screen, use the<strong> Prev/Next</strong>
					buttons to navigate.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editcustomer"></a>7.5.2</font> Edit 
					a Customer</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To Edit a particular Customer click its <strong>Edit link</strong>
						in figure 40. The following screen appears as shown in figure 41, populated 
						with the customer details.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="500" src="helpfiles/Forms/image083.jpg" width="635"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 41.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Do the necessary updation and press the <strong>Update</strong> button 
					to save the changes.
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deletecustomer"></a>7.5.2</font> Delete 
					a Customer</td>
			</tr>
			<tr>
				<td class="t">To Delete a particular customer, click the <strong>Delete</strong> link 
					in figure 40, for that Customer.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vendorlist"></a>7.6</font> Vendor 
					List</td>
			</tr>
			<tr>
				<td class="t">To list all vendors click the<strong> Vendor List</strong> link on 
					the Home Page, the following screen appears as shown in figure 42.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center">
						<p><IMG height="335" src="helpfiles/Forms/VenderList.jpg" width="575"></p>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 42.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Click the <strong>Search</strong> button, to view a list of all 
					vendors as shown in figure 43.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/VenderList(Search).jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 43.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editvendor"></a>7.6.1</font> Edit a 
					Vendor</td>
			</tr>
			<tr>
				<td class="t">To edit information of a Vendor click the <strong>Edit</strong> link 
					of that particular Vendor in figure 42.<br>
					<br>
					The following screen appears with the Vendor details as shown in figure 44.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/VenderListUpdate.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 44.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Do the necessary modification and press the<strong> Update</strong> button 
					to save your changes.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="deletevendor"></a>7.6.2</font> Delete 
					a Vendor</td>
			</tr>
			<tr>
				<td class="t">To delete a particular Vendor click on the appropriate Delete link in 
					figure 43 above.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="customerdatamining"></a>7.7</font> Customer 
					Data Mining</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view the details of all the customers, click on <strong>Customer 
							Data Mining</strong> link on the Home Page. The following screen appears as 
						shown in figure 45 below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="415" src="helpfiles/Reports/CustomerDataMining.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 45.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view the customer details select an option from <strong>Order 
							By</strong>. drop down. This drop down contains the order like, Customer 
						Name, Customer Type and Customer City. Select your choice to see the data 
						mining report.
					</div>
					<p align="justify">Press <strong>Print </strong>button to print the details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="purchase"></a>8.0</font> Purchase / 
					Sales / Inventory</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This section allows the user to enter a new product, update 
						its price, generate purchase, sales invoice, credit bills and enter tax details 
						of the fuel products.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="product"></a>8.1</font> Product 
					Entry</td>
			</tr>
			<tr>
				<td class="t">Allows the user to enter a new product or update the product.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newproduct"></a>8.1.1</font> Enter 
					a new Product</td>
			</tr>
			<tr>
				<td class="t">To enter a new Product click the <strong>Product Entry </strong>link 
					on the Home Page, the following screen appears as shown in figure 46.
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/ProductEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 46.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter a Product Name in the text box. Select a Product Type 
						from the drop-down, if the Type is not available in the drop-down then specify 
						another in the textbox. When another Category Type is specified in the textbox, 
						it is automatically populated during subsequent product entry.
					</div>
					<p align="justify">Select a Package Type from the drop-down, if the Type is not 
						available in the drop-down then specify another in the textbox. When another 
						Package Type is specified in the textbox, it is automatically populated during 
						subsequent product entry. The Package Qty. field is automatically calculated 
						and displayed.
					</p>
					<p align="justify">Enter the Opening Stock, and select the Package Qty. units from 
						the drop-down besides.</p>
					<p align="justify">Select the Units from the drop-down, if it not available specify 
						another in the text field besides, this unit will automatically be available 
						during subsequent product entries.</p>
					<p align="justify">Finally select the Store In from the drop-down and press <strong>Save</strong>
						button to save the product details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editproduct"></a>8.1.2</font> Edit 
					an existing Product</td>
			</tr>
			<tr>
				<td class="t">To edit an existing Product click the button besides the Product ID. 
					The screen will appear as shown in figure 47 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditProductEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 47.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Product from the drop-down the product details are 
						populated on the screen. Do the necessary updation and press the <strong>Save</strong>
						button to update the Product details.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="priceupdate"></a>8.2</font> Price 
					Updation</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Allows the user to enter the price of newly created product or 
						update the price of an existing product. Click on the <strong>Price Updation</strong>
						link on the Home Page. The following screen appears as shown in figure 48.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="468" src="helpfiles/Forms/PriceUpdation.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 48.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">A list of all Products are displayed on the screen. <strong>Note</strong>
						that Products of <strong>Category Fuel</strong> do <strong>not </strong>have a 
						Package Type, and their <strong>Purchase Rate</strong> is in <strong>KL</strong>, 
						however their <strong>Sales Rate</strong> is in <strong>liters</strong>.
					</div>
					<p align="justify">To enter a new price or update an existing one, first click on 
						the check-box and enter the Purchase Rate and Sales Rate and press <strong>Submit</strong>
						button.</p>
					<p align="justify">Note that for non-fuel products the Sales Rate should be greater 
						than the Purchase Rate.</p>
					<p align="justify">If <strong>all</strong> the prices are to be entered or updated, 
						you can conveniently press the <strong>Select All</strong> check-box to select 
						all the products instead of selecting the check-boxes one-by-one.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="purchaseinvoice"></a>8.3</font> Purchase 
					Invoice</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To generate a new <strong>Purchase Invoice</strong> or edit an 
						existing one. This section handles <strong>Fuel Products</strong> and <strong>Non-Fuel 
							Products</strong> <strong>(Others) separately</strong>.
					</div>
					<p align="justify"><strong>Note</strong>: Before a new Purchase Invoice is created, 
						it is necessary to do the following steps to ensure that the Price and Tax 
						related information are available.</p>
					<p align="justify"><strong>Fuel Purchase</strong>:<br>
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="5" src="helpfiles/Forms/b.gif" width="5">
						<strong>Price Updation</strong> SHOULD be done to enter the <strong>Purchase Rate</strong>
						and <strong>Sales Rate</strong><br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="5" src="helpfiles/Forms/b.gif" width="5">
						<strong>Tax Entry</strong> SHOULD be done to enter the<strong> Tax</strong> related 
						entries</p>
					<p align="justify"><strong>Other Purchase</strong>: (Non-Fuel Products)<br>
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <IMG height="5" src="helpfiles/Forms/b.gif" width="5">
						<strong>Price Updation</strong> SHOULD be done to enter the<strong> Purchase Rate</strong>
						and <strong>Sales Rate</strong></p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createpi"></a>8.3.1</font> Create a 
					new Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">To create a new Purchase Invoice click on the<strong> Purchase Invoice</strong>
					link on the Home Page.
					<p>The following screen appears as shown in figure 49.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/PurchaseBill.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 49.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To make a Fuel purchase click on the<strong> Fuel Purchase link</strong>, 
					or to make Other purchase click on<strong> Other Purchase link</strong>.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="fpi"></a>8.3.1</font> Fuel Purchase 
					Invoice</td>
			</tr>
			<tr>
				<td class="t">If the Fuel Purchase link was clicked the screen appears as shown in 
					figure 50 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createfpi"></a>8.3.1.1</font> Create 
					Fuel Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="777" src="helpfiles/Forms/FuelPurchaseInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 50.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the<strong> Vendor Name</strong> from the drop-down 
						list. The <strong>Place</strong> is displayed automatically. Enter the<strong> Vehicle 
							No.</strong>,<strong> Invoice No.</strong> and select the <strong>Invoice Date</strong>
						by clicking the datepicker.
					</div>
					<p align="justify">Select the <strong>Mode Of Payment</strong> from the drop-down 
						list. Select the <strong>Product Name</strong> from the drop-down list, the <strong>
							Rate/Liter</strong> is displayed automatically. Enter the <strong>Quantity</strong>, 
						then enter <strong>all </strong>the fields for <strong>Density</strong> and <strong>
							Temperature</strong>, the <strong>Density Variation</strong> is computed 
						and displayed automatically .
					</p>
					<p align="justify">All the <strong>Tax </strong>related fields are populated 
						automatically, and the<strong> Amount</strong> is computed and displayed.
					</p>
					<p align="justify">This step can be repeated for all the <strong>Compartments</strong>.</p>
					<div align="justify">Next enter<strong> Promo Scheme</strong>, <strong>Remarks</strong>
						and <strong>Message</strong>. Click on the <strong>Grand Total</strong> textbox, 
						the amount is computed and displayed, if there is any <strong>Discount</strong> 
						select the type either Rs. or %, and enter the value. Click on <strong>Net Amount</strong>
						textbox to compute and display the Net Amount. Press the <strong>Save &amp; Print</strong>
						button to save the invoice details and generate the printed invoice report.
					</div>
					<p align="justify">Note: This User manual assumes that the<strong> Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with printing) 
						refer to the Installation Guide for the topic<A href="#how"> How to start the 
							Print_WindowService</A> for <strong>DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editfpi"></a>8.3.1.2</font> Edit 
					Fuel Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">To edit a<strong> Fuel Purchase Invoice</strong> click on the button 
					besides the Invoice No. in figure 48.
					<p>The following screen appears as shown in figure 51 below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="777" src="helpfiles/Forms/FuelPurchaseInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 51.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the<strong> Invoice No.</strong> from the drop-down, 
						all the invoice details are populated automatically. Do the necessary 
						modification and press the <strong>Save &amp; Print</strong> button to save the 
						changes, and generate a printed invoice report.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="otherpi"></a>8.3.2</font> Other 
					Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">If the Other Purchase link was clicked the screen would appear as 
					shown in figure 52.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createopi"></a>8.3.2.1</font> Create 
					Other Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="544" src="helpfiles/Forms/OtherPurchaseInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 52.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Vendor Name</strong>, the<strong> Place</strong>
						is displayed automatically, enter the <strong>Vehicle No.</strong> and <strong>Invoice 
							No.</strong>, and select the <strong>Invoice Date</strong> by clicking the 
						datepicker. Select the <strong>Mode Of Payment</strong> from the drop-down. 
						Select the <strong>Product Type</strong> from the drop-down, based on this type 
						the products are available in the next drop-down, select the <strong>Product Name</strong>
						and the <strong>Package</strong>, the <strong>Rate</strong> is displayed 
						automatically. Enter the <strong>Quantity</strong>, the <strong>Amount</strong> 
						is computed and displayed automatically.
					</div>
					<p align="justify">A maximum of <strong>eight </strong>products can be entered in 
						one invoice. Enter the <strong>Promo Scheme</strong>, <strong>Remarks</strong> and
						<strong>Message</strong>, and click the <strong>Grand Total</strong> textbox, 
						the amount is computed and displayed. Next select the <strong>Cash Discount</strong>
						type and enter the value, click on green radio button to apply the VAT or click 
						red button to remove the applied VAT from amount, select the <strong>Discount</strong>
						type and enter the amount and click the <strong>Net Amount</strong> textbox, 
						the amount is computed and displayed. Press Save &amp; Print button to save the 
						invoice details and generate a printed invoice report.</p>
					<p align="justify">Note: This User manual assumes that the <strong>Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with printing) 
						refer to the Installation Guide for the topic <A href="#how">How to start the 
							Print_WindowService</A> for <strong>DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editopi"></a>8.3.2.2</font> Edit 
					Other Purchase Invoice</td>
			</tr>
			<tr>
				<td class="t">To edit a Other Purchase Invoice click on the button besides the 
					Invoice No. in figure 52.
					<p>The following screen appears as shown in figure 53 below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="544" src="helpfiles/Forms/OtherPurchaseInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 53.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Invoice No.</strong> from the drop-down, 
						all the invoice details are populated automatically. Do the necessary 
						modification and press the <strong>Save &amp; Print </strong>button to save the 
						changes, and generate a printed invoice report.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="salesin"></a>8.4</font> Sales 
					Invoice</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To create and edit a <strong>Sales Invoice</strong> Click the <strong>
							Sales Invoice</strong> link on the Home Page. The following screen appears 
						as shown in figure 54 below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="createsi"></a>8.4.1</font> Create a 
					new Sales Invoice</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="551" src="helpfiles/Forms/SalesInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 54.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select a Customer Name from the drop-down list, The Place 
						Due-Date and Current Balance are populated automatically. Enter the Vehicle No. 
						and select the Sales Type from the drop-down list.
					</div>
					<p align="justify">If the Sales Type is <strong>Credit</strong> , then the <strong>Slip 
							No.</strong> is displayed below the Sales Type as shown in figure 55.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="172" src="helpfiles/Forms/image110.jpg" width="286"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 55.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter a valid Slip No. for the Customer. The <strong>Slip No.</strong>
						entered must be in the<strong> valid range</strong> for that <strong>customer</strong>, 
						and also it should <strong>not </strong>be an already<strong> issued </strong>Slip 
						No. Otherwise the <strong>ePetro</strong> system will popup a message as shown 
						below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="119" src="helpfiles/Forms/image111.jpg" width="197"></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Press <strong>OK </strong>button and proceed to input the 
						right<strong> Slip No.</strong>
					</div>
					<p align="justify">Select the<strong> Under Sales Man</strong> from the drop-down 
						list.</p>
					<p align="justify">Next select the <strong>Product Type</strong>, based on this 
						type the Product Names will appear in the drop-down list, when the Product is 
						selected the<strong> Available Stock</strong> and <strong>Rate</strong> are 
						automatically populated.
					</p>
					<p align="justify"><strong>Note</strong>: If the Product Type is <strong>Fuel </strong>
						the <strong>Package</strong> is not displayed.</p>
					<p align="justify">If the Product Type is <strong>not Fuel </strong>then select the <strong>
							Product Type</strong>. Next enter the <strong>Quantity</strong> and click 
						the amount textbox to compute and display the <strong>Amount</strong>. A 
						maximum of<strong> eight</strong> products can be entered in one sales invoice.</p>
					<p align="justify">Enter the <strong>Promo Scheme</strong>, <strong>Remarks</strong>
						and<strong> Message</strong>, and click the <strong>Grand Total</strong> textbox, 
						the amount is computed and displayed. Next select the <strong>Cash Discount</strong>
						type and enter the value, click on green radio button to apply the VAT or click 
						red button to remove the applied VAT from amount, select the<strong> Discount type</strong>
						and enter the amount and click the <strong>Net Amount</strong> textbox, the 
						amount is computed and displayed. Press <strong>Save &amp; Print</strong> button 
						to save the invoice details and generate a printed invoice report.</p>
					<p align="justify">Note: This User manual assumes that the <strong>Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with printing) 
						refer to the Installation Guide for the topic <A href="#how">How to start the 
							Print_WindowService</A> for <strong>DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editsi"></a>8.4.2</font> Edit an 
					existing Sales Invoice</td>
			</tr>
			<tr>
				<td class="t">To edit a Sales Invoice click on the button besides the Invoice No. 
					in figure 54.
					<p>The following screen appears as shown in figure 56 below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="551" src="helpfiles/Forms/EditSalesInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 56.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the<strong> Invoice No.</strong> from the drop-down 
						list, the invoice details are automatically populated. Do the necessary 
						modification and press <strong>Save &amp; Print</strong> button to save the 
						changes and generate the printed Sales Invoice report.
					</div>
					<p align="justify">The <strong>Quantity </strong>entered should be less than<strong> Available 
							Stock</strong> or an error message will popup as shown below.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="119" src="helpfiles/Forms/image114.jpg" width="197"></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Press <strong>OK </strong>button and proceed to enter the right 
					Quantity.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="cb"></a>8.5</font> Credit Bill</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To generate a Credit Bill, click on the Credit Bill link on 
						the Home Page. The following screen appears as shown below in figure 57.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CreditBill11.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select <strong>From</strong> date by clicking the datepicker, 
						and the <strong>To</strong> date by clicking the datepicker. Select <strong>M/s.</strong>
						from the drop-down the details are displayed in a tabular form as shown below 
						in figure 58.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CreditBill.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 58.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Press <strong>Save &amp; Print</strong> button to save and 
						print the credit bill details.
					</div>
					<p align="justify">Note: This User manual assumes that the <strong>Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with printing) 
						refer to the Installation Guide for the topic <A href="#how">How to start the 
							Print_WindowService</A> for<strong> DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="taxentry"></a>8.6</font> Tax Entry</td>
			</tr>
			<tr>
				<td class="t">To enter or edit Tax Entry click on the <strong>Tax Entry </strong>link 
					on the Home Page, the following screen appears as shown in figure 59.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="405" src="helpfiles/Forms/TaxEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 59.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Product Name</strong> from the drop-down 
						list, If the Tax Entry for this product has not been <strong>entered</strong> earlier, 
						all the fields will appear <strong>blank</strong>, <strong>select</strong> the 
						check-box against the field and enter the value, use <strong>Select All</strong>
						to conveniently enter all values without selecting the check-box one-by-one. 
						Fields whose check-box are not selected will <strong>not</strong> be saved. 
						Press<strong> Add </strong>button to save the Tax Entry details.
					</div>
					<p align="justify">If the <strong>Tax Entry</strong> for this product has been 
						entered earlier, then the details are populated automatically, do the 
						modification as necessary and press the <strong>Edit </strong>button to update 
						the Tax Entry details. Only fields which are <strong>selected</strong> are 
						updated.</p>
					<p align="justify">To <strong>Delete</strong> a Tax Entry, simply press the <strong>Delete</strong>
						button after <strong>confirming</strong> the product details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="salesreturn"></a>8.7</font> Sales 
					Return
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To create the Sales Return credit note click on <strong>Sales 
							Return</strong> link on Home Page. The following screen appears as shown in 
						figure 60.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="532" src="helpfiles/Forms/SalesReturnCreditNote11.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 60.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the <strong>Invoice no.</strong> from Invoice No drop down, 
					the invoice details appears as shown in figure 61 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="532" src="helpfiles/Forms/SalesReturnCreditNote.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 61.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To return a particular product, click on corresponding check 
						box and enter the return quantity in <strong>Qty text </strong>box. The <strong>Net 
							Amount </strong>shows the calculated amount of return products (Including 
						the <strong>Cash Discount</strong>, <strong>VAT</strong> and <strong>Discount</strong>
						if applied in selected sales invoice).
					</div>
					<p align="justify">The<strong> Return Quantity</strong> entered of a selected 
						product should be less than or equal to <strong>Sales Quantity</strong> otherwise 
						an error message will popup.</p>
					<p align="justify">Press the <strong>Save &amp; Print</strong> to save and print 
						the sales return details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="pr"></a>8.8</font> Purchase Return</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To create the purchase return credit note click on <strong>Purchase 
							Return</strong> on Home Page. The following screen appears as shown in 
						Figure 62.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="523" src="helpfiles/Forms/PurchaseReturnCreditNote11.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 62.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Invoice no. from <strong>Invoice No.</strong> drop down, 
					the invoice details appears as shown in figure 63 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="523" src="helpfiles/Forms/PurchaseReturnCreditNote.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 63.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To return a particular product, click on corresponding check 
						box and enter the return quantity in<strong> Qty </strong>text box. The<strong> Net 
							Amount </strong>shows the calculated amount of return products (Including 
						the<strong> Cash Discount</strong>, <strong>VAT</strong> and <strong>Discount</strong>
						if applied in selected purchase invoice).
					</div>
					<p align="justify">The Return Quantity entered of selected product should be less 
						than or equal to Purchase Quantity otherwise an error message will popup.</p>
					<p align="justify">Press the<strong> Save &amp; Print</strong> to save and print 
						the purchase return details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="stock"></a>8.9</font> Stock 
					Adjustment</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This is used to shift the stock of a product from one location 
						to another. Click on <strong>Stock Adjustment </strong>link, the following 
						screen appears as shown in figure 64.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="373" src="helpfiles/Forms/StockAdustmentVoucher.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 64.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This contains two sections<strong> OUT</strong> and<strong> IN</strong>. 
						Select the out products from <strong>OUT</strong> section and in products from<strong>
							IN</strong> section.
					</div>
					<p align="justify">Select the product from<strong> Product Name &amp; Package </strong>
						drop down, the location of the selected product will automatically appears in <strong>
							Store In</strong> text box then enter the quantity in <strong>Qty. in Ltr</strong>
						text box for products of <strong>Fuel</strong> category or<strong> Loose Oil </strong>
						and enter quantity in<strong> Qty. in Pack</strong> for other type products.</p>
					<p align="justify">The out &amp; in quantity of a product should be same or an 
						error message popup will appear.</p>
					<p align="justify">Press the <strong>Save &amp; Print</strong> to save and print 
						the stock adjustment details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="account"></a>9.0</font> Accounts</td>
			</tr>
			<tr>
				<td class="t">The Accounts module provides <strong>Ledger Creation</strong>, <strong>Payment 
						Receipt</strong>, <strong>Sub_Group</strong>, <strong>Cash Payment </strong>
					and <strong>Voucher Type</strong>.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="ledger"></a>9.1</font> Ledger 
					Creation</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newledger"></a>9.1.1</font> Create 
					a new Ledger</td>
			</tr>
			<tr>
				<td class="t">To create a Ledger click on the <strong>Ledger Creation</strong> link 
					on the Home Page. The following screen appears as shown in figure 65.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/LedgerCreation.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 65.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Enter a Ledger name in the textbox. Then select SubGroup Name 
						from the dropdown, the related Group names will be populated in the dropdown 
						below. In case the SubGroup name is not available in the dropdown then select 
						the option Other in the dropdown, the text box besides is enabled to enter the 
						SubGroup name, similarly if the Group Name is not available then select the 
						option Other and enter a new Group name.
					</div>
					<p align="justify">The Nature of Group is automatically selected in the list of 
						radiobuttons when the SubGroup is selected, the user can however select a 
						different Nature of Group by selecting the radio buttons.</p>
					<p align="justify">Enter the Opening Balance, and select Dr. or Cr. From the 
						dropdown beside and press <strong>Add</strong> button to save the Ledger entry.</p>
					<p align="justify"><strong>Note</strong>: The Ledger Name should not be same as a 
						Customer or Vendor name. And Ledger Name cannot be repeated for the same 
						SubGroup.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editledger"></a>9.1.2</font> Edit 
					or Delete an existing Ledger</td>
			</tr>
			<tr>
				<td class="t">To Edit or Delete a Ledger entry click on the button besides the 
					textbox Ledger Name as shown above in figure 65.
					<p>The following screen appears as shown below in figure 66.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center">
						<p><IMG height="335" src="helpfiles/Forms/EditLedgerCreation.jpg" width="575"></p>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 66.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Ledger Name from the dropdown (the dropdown also 
						displays the ID), the Ledger name is displayed in the tex tbox besides, the 
						user can now modify the Ledger Name. To modify the SubGroup select the 
						appropriate SubGroup Name, to modify the Group Name select the appropriate 
						Group Name from the dropdown. Select the Nature of Group from the list of radio 
						buttons. The Opening Balance can be modified in the tex tbox. Press the <strong>Edit</strong>
						button to save the modifications.
					</div>
					<p align="justify">To Delete a particular Ledger entry simply select the 
						appropriate Ledger Name from the dropdown and press the Delete button.</p>
					<p align="justify"><strong>Note</strong>: The Ledger Name should not be same as a 
						Customer or Vendor name. And Ledger Name cannot be repeated for the same 
						SubGroup.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="receipt"></a>9.2</font> Receipt</td>
			</tr>
			<tr>
				<td class="t">To make a Receipt click on the<strong> Receipt</strong> link on the 
					Home Page. The following screen appears as shown in figure 67 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="409" src="helpfiles/Forms/Receipt.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 67.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Customer</strong> from the drop-down list, 
						the <strong>Place</strong> is displayed in the textbox. Details of Payment Due 
						are populated automatically. Enter the amount in words in the textbox below. 
						Select the payment<strong> Mode</strong> from the drop-down and enter the <strong>Amount</strong>
						in numeric form, click on the textbox under <strong>Final Dues After Payment</strong>, 
						the <strong>Amount</strong> is computed and displayed. Press <strong>Save</strong>
						button to save the Payment Receipt details. To generate a printed report press<strong>
							Print </strong>button.
					</div>
					<p align="justify"><strong>Note</strong>: The Cash and bank account must be 
						available before a Receipt can be made.
					</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="pay"></a>9.3</font> Payment</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="makepay"></a>9.3.1</font> Make a 
					Payment</td>
			</tr>
			<tr>
				<td class="t">To make a Payment click on the<strong> Payment</strong> link on the 
					Home Page, the following screen appears as shown in figure 68.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/Payment.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 68.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select a Ledger Name from the dropdown list. This dropdown 
						display all Ledgers except 'Cash in Hand' and 'Bank' types. The dropdown By 
						displays all the Ledgers of type 'Cash in Hand' and 'Bank', select the 
						appropriate ledger. Enter the Bank Name, Cheque No. and Date only if the By 
						Ledger Name is of type Bank. Next enter the Amount and Narrations. Press the <strong>
							Add</strong> button to save the Payment entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editpay"></a>9.3.2</font> Edit or 
					Delete an existing Payment</td>
			</tr>
			<tr>
				<td class="t">To Edit or Delete an existing Payment entry press the button besides 
					the dropdown of Ledger Name in the above figure 68. The following screen 
					appears as shown in figure 69.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditPayment.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 69.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Ledger Name from the first dropdown, the details of 
						Payment is automatically populated on the screen,to modify the Ledger Name 
						select the appropriate Ledger Name from the dropdown besides.To modify By 
						select the Ledger Name from the dropdown.To modify Bank details enter the Bank 
						Name Cheque No and Date.To modify the Amount type the new Amount in the tex 
						box.To modify the Narrations type the narrations in the text area.To save the 
						modification press the<strong> Edit </strong>button.
					</div>
					<p align="justify">To Delete a Payment select the appropriate Ledger Name from the 
						dropdown and Press the <strong>Delete</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="voucher"></a>9.4</font> Voucher 
					Entry</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newvoucher"></a>9.4.1</font> Create 
					a New Voucher</td>
			</tr>
			<tr>
				<td class="t">To create a new Voucher press the <strong>Voucher</strong> link on 
					the Home Page. The Following screen appears as shown in figure 70.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="357" src="helpfiles/Forms/VoucherEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 70.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select a Voucher Type from the dropdown, the Voucher ID is 
						populated automatically. All the dropdowns under Account Name are populated 
						with Ledger Names, according to Voucher type. Next select an Account Name, and 
						enter the Amount, select DR. or Cr. The Dr./Cr. On the right hand side is 
						automatically selected. Select the Account Name and enter the Amount. Repeat 
						this step for all Account Names. Enter a Narration if any in the text area. And 
						press the Add button to save the Voucher entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editvoucher"></a>9.4.2</font> Edit 
					or Delete an existing Voucher</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To Edit an existing Voucher entry press the button besides the 
						Voucher ID. The following screen appears as shown in figure 71.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center">
						<p><IMG height="354" src="helpfiles/Forms/editVoucherEntry.jpg" width="575"></p>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 71.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select a Voucher Type, and a Voucher ID, the details are 
						populated for one entry, the rest of the entries are disabled. Select an 
						Account Name, enter the Amount and select Dr. or Cr.. The Dr. or Cr. On the 
						right hand side are automatically selected. Select the Account Name and Amount, 
						Modify the Narration if required. And press the<strong> Edit b</strong>utton to 
						save the modifications.
					</div>
					<p align="justify">To Delete a Voucher entry simply select the appropriate Voucher 
						ID and press the Delete button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="ci"></a>9.5</font> Cash Invoice</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newci"></a>9.5.1</font> Create a 
					new Cash Invoice</td>
			</tr>
			<tr>
				<td class="t">To create a new cash invoice press the Cash Invoice link in the Home 
					Page. The Following screen appears as shown in figure 72.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CashInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 72.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="right"></div>
				</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editci"></a>9.5.2</font> Edit or 
					Delete an existing Cash Invoice
				</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To Edit an existing Cash Invoice entry press the button 
						besides the Cash Invoice ID. The following screen appears as shown in figure 
						73.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/EditCashInvoice.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 73.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="logistic"></a>10.0</font> Logistics</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="rm"></a>10.1</font> Route Master</td>
			</tr>
			<tr>
				<td class="t">To enter a route click the <strong>Route Master</strong> link on the 
					Home Page. The following screen appears as shown below in figure 74.
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/RouteInsertion.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 74.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To add a route enter the Route Name in the text box, Next 
						enter Route KM in the tex t box and press<strong> Add </strong>button.
					</div>
					<p align="justify">To edit en existing route select a Route Name from the dropdown 
						and press the Edit button. Modify the route details and press the <strong>Edit</strong>
						button again.</p>
					<p align="justify">To delete the route details simply select the route name from 
						dropdown and press the<strong> Delete</strong> Button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vehicle"></a>10.2</font> Vehicle 
					Entry</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="newvehicle"></a>10.2.1</font> Add a 
					New Vehicle Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To enter a new vehicle click on Vehicle Entry link on the Home 
						Page. The following screen appears as shown below in Figure 75.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="507" src="helpfiles/Forms/VehicleEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 75.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To add a new Vehicle select the Vehicle Type from the dropdown 
						then fill the vehicle and insurance related information in the corresponding 
						tex tbox, select the Vehicle route from the dropdown then select the Fuel Used 
						from dropdown and enter the quantity in the textbox beside the dropdown and 
						enter the Fuel Starting Quantity in textbox. In Fuel/ Lubricants Uses section 
						select the Oil and Lubricants from all the dropdowns, enter the used quantity 
						in the tex tbox besides the dropdowns, select the entry Date and enter the 
						total KM. Enter Vehicle Ave rage and press the <strong>Save</strong> button to 
						save the new Vehicle Entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editvehicle"></a>10.2.2</font> Edit 
					or Delete an existing Vehicle Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To Edit or Delete an existing Vehicle Entry press the button 
						beside the Vehicle ID as shown in above Figure 75. The following screen appears 
						as shown in Figure 76.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="505" src="helpfiles/Forms/EditVehicleEntry.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 76.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To edit the Vehicle Entry select the Vehicle ID from dropdown, 
						the Vehicle details appears on the screen for the selected Vehicle ID. Modify 
						the required fields and press the <strong>Edit</strong> button to save the 
						modification.
					</div>
					<p align="justify">To delete the Vehicle Entry select the Vehicle ID from the 
						dropdown and press the <strong>Delete</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vdlb"></a>10.3</font> Vehicle Daily 
					Log Book</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="nvdlb"></a>10.3.1</font> Add a new 
					Vehicle Daily Log Book Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To add a new Vehicle Daily Log Book Entry click on Vehicle 
						Daily Log Book link on the Home Page. The following screen appears as shown in 
						figure 77.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/VehicleDailyLogBook.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 77.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To add a new Vehicle Log Entry select the Vehicle No from the 
						dropdown the Vehicle Name, Driver's Name and Meter Reading (Previous Day) 
						appears automatically, enter the Current Day Meter Reading in tex tbox, select 
						the Vehicle Route from dropdown then select the Fuel, Oil and Lubricants used 
						from dropdowns and enter the used Quantity in the textbox. Finally fills the 
						Other Expenses and press the Save button to save the Vehicle Daily Log Book 
						entry.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="editvdlb"></a>10.3.2</font> Edit or 
					Delete an existing Vehicle Log Book Entry</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To edit or delete the Vehicle Log Entry press the Button 
						beside the VDLB ID as shown in above Figure 77. The following screen appears as 
						shown as Figure 78.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/VehicleDailyLogBook.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 78.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To edit the Vehicle Log Book entry select a VDLB ID from the 
						dropdown the details appears on the screen for the selected VDLB ID. Modify the 
						required fields and press the<strong> Edit</strong> button to save the 
						modifications.
					</div>
					<p align="justify">To delete the Vehicle Log Book Entry simply select the VDLB ID 
						from the dropdown and press the <strong>Delete</strong> button.</p>
					<p align="justify">To print the Vehicle Log Book Details fill all the fields for a 
						new entry or select the VDLB ID for the existing entry then press the <strong>Print</strong>
						Button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="report"></a>11.0</font> Reports / 
					MIS</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">One of the most intriguing aspect of <strong>ePetro</strong> System 
						is that even today, in the age of <strong>Web-based Application</strong>, it 
						supports<strong> DOS-based Printing</strong>, which is by far the most<strong> economical
						</strong>means in terms of <strong>cost</strong>, <strong>time</strong> and <strong>
							maintenance</strong>.
						<br>
						<strong>ePetro</strong> achieves <strong>DOS-based printing</strong> through 
						its own propriety based<strong> Windows Service</strong>.
					</div>
					<p align="justify">This service is provided by <strong>Print_WindowService</strong> 
						which should normally start when your computer boots. Refer to the Installation 
						Guide for the topic <A href="#how">How to start the Print_WindowService</A> for <strong>
							DOS</strong>-based printing.</p>
					<p align="justify">This User-Manual assumes that a <strong>Printer</strong> is 
						connected to your computer system, is powered <strong>ON</strong> and in<strong> online</strong>
						mode, with adequate <strong>stationary</strong> available.</p>
					<p align="justify">Some of the reports in this module requires you to put the 
						printer in the <strong>condensed mode</strong>, wherever applicable a foot-note 
						is provided to indicate the change of mode.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="tankreport"></a>11.1</font> Tank 
					Report</td>
			</tr>
			<tr>
				<td class="t">To generate a <strong>Tank Report </strong>click on its link on the 
					Home Page. The screen appears as shown below in figure 79.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="391" src="helpfiles/Reports/TankReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 79.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view the <strong>Tank Report</strong> on the screen press 
						the <strong>View </strong>button. The report is displayed on the screen as 
						shown in figure 80 below.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="391" src="helpfiles/Reports/TankReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 80.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To generate a report on the<strong> printer</strong> make sure that 
					the printer is<strong> online</strong> and simply press the <strong>Print</strong>
					button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="machinerepo"></a>11.2</font> Machine 
					Report</td>
			</tr>
			<tr>
				<td class="t">To generate a <strong>Machine Report</strong> click on its link on 
					the Home Page. The screen appears as shown below in figure 81.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/MachineReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 81.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To view the<strong> Machine Report</strong> press <strong>View </strong>
					button, to generate a printout press <strong>Print</strong> button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="nozzlerepo"></a>11.3</font> Nozzle 
					Report</td>
			</tr>
			<tr>
				<td class="t">To generate a <strong>Nozzle Report</strong> click on its link on the 
					Home Page. The screen appears as shown below in figure 82.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="328" src="helpfiles/Reports/NozzleReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 82.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To view the <strong>Machine Report</strong> press <strong>View</strong>
					button, to generate a printout press <strong>Print</strong> button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="meterreading"></a>11.4</font> Meter 
					Reading
				</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Meter Reading</strong> link, the screen appears 
					as shown in figure 83 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/MeterReadingReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 83.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the<strong> Date</strong> by clicking the datepicker, 
						press <strong>View </strong>button to see the report on the screen, or press 
						the <strong>Print</strong> button to send the report on the printer.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="tdr"></a>11.5</font> Tank Dip 
					Reading
				</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Tank Dip Reading </strong>link, the screen 
					appears as shown in figure 84 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="391" src="helpfiles/Reports/TankReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 84.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To view the <strong>Tank Dip Reading</strong> Report press<strong> View</strong>
					button, to generate a printout press<strong> Print</strong> button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="pricelist"></a>11.6</font> Price 
					List</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Price List</strong> link, the screen appears as 
					shown in figure 85 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="344" src="helpfiles/Reports/PriceListReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 85.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To view the<strong> Price List Report</strong> press <strong>View</strong>
					button, to generate a printout press <strong>Print</strong> button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="density"></a>11.7</font> Density 
					Register</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Density Register </strong>link, the screen 
					appears as shown in figure 86 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="718" src="helpfiles/Reports/DensityRegister.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 86.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Product</strong> from the drop-down list, 
						select the <strong>Tank ID</strong> from the drop-down list and the <strong>Month</strong>
						from the drop-down list.
					</div>
					<p align="justify">To view the<strong> Density Register</strong> press <strong>View </strong>
						button, to generate a printout press <strong>Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="gsr"></a>11.8</font> Govt. Stock 
					Register</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Govt. Stock Register </strong>link, the screen 
					appears as shown in figure 87 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="698" src="helpfiles/Reports/Govt.StockRegister.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 87.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Product from the drop-down list, next select Month from 
					the drop-down list.
					<p>To view the Govt. Stock Register press View button, to generate a printout press 
						Print button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="dsr"></a>11.9</font> Daily Sales 
					Register</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Daily Sales Register</strong> link, the screen 
					appears as shown in figure 88 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="665" src="helpfiles/Reports/DailySalesRegister.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 88.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Product from the drop-down, and Month from the drop-down.
					<p>To view the<strong> Daily Sales Register</strong> press <strong>View</strong> button, 
						to generate a printout press <strong>Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="cws"></a>11.10</font> Customer Wise 
					Sales</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Customer Wise Sales</strong> link, the screen 
					appears as shown in figure 89 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="586" src="helpfiles/Reports/CustomerWiseSalesReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 89.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>Date From</strong> by clicking the 
						datepicker. Select the <strong>Date To</strong> by clicking the datepicker 
						Select the <strong>Product Group</strong> from the drop-down. Select the <strong>Customer 
							Category</strong> from the drop-down.
					</div>
					<p align="justify">The various Customer categories supported are: <strong>All</strong>,
						<strong>General</strong>, <strong>Fleet</strong>, <strong>Key Customers</strong>,
						<strong>Government</strong> and <strong>Contractor</strong>.</p>
					<p align="justify">To view the<strong> Customer Wise Sales</strong> press <strong>View</strong>
						button, to generate a printout press<strong> Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="sm"></a>11.11</font> Stock Movement</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Stock Movement</strong> link, the screen appears 
					as shown in figure 90 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="401" src="helpfiles/Reports/StockMovementReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 90.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the Date From by clicking the datepicker. Select the 
						Date To by clicking the datepicker. Select the Stock Location from the 
						drop-down list.
					</div>
					<p align="justify">To view the <strong>Stock Movement</strong> press<strong> View</strong>
						button, to generate a printout press<strong> Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="sr"></a>11.12</font> Stock Report</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Stock Report</strong> link, the screen appears 
					as shown in figure 91 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="401" src="helpfiles/Reports/StockReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 91.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Date by clicking the datepicker. Select the Location from 
					the drop-down list.
					<p>To view the <strong>Stock Report </strong>press<strong> View</strong> button, to 
						generate a printout press <strong>Print </strong>button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="sb"></a>11.13</font> Sales Book</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Sales Book</strong> link, the screen appears as 
					shown in figure 92 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="868" src="helpfiles/Reports/SalesBookReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 92.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Date From and Date To by clicking the datepickers.
					<p>To view the <strong>Sale Book Report</strong> press <strong>View</strong> button, 
						to generate a printout press<strong> Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="pb"></a>11.14</font> Purchase Book</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Purchase Book</strong> link, the screen appears 
					as shown in figure 93 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/PurchaseBookReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 93.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the<strong> Date From</strong> and<strong> Date To</strong> by 
					clicking the datepickers
					<p>To view the Purchase Book Report press View button, to generate a printout press 
						Print button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="pws"></a>11.15</font> Product Wise 
					Sales</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Product Wise Sales</strong> link, the screen 
					appears as shown in figure 94 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="340" src="helpfiles/Reports/ProductWiseSales.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 94.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the Date From and Date To by clicking the datepicker.
					<p>To view the <strong>Product Wise Sales Report </strong>press<strong> View</strong>
						button, to generate a printout press <strong>Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="co"></a>11.16</font> Customer 
					Outstanding</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Customer Outstanding</strong> link, the screen 
					appears as shown in figure 95 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="426" src="helpfiles/Reports/CustomerWiseOutStandingReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 95.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the <strong>Date From </strong>and <strong>Date To</strong> by 
					clicking the datepickers. Select the Customer Category from the drop-down list. 
					Select the Balance Type from the drop-down.
					<p>To view the <strong>Customer Wise Outstanding Report</strong> press<strong> View</strong>
						button, to generate a printout press <strong>Print </strong>button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="cba"></a>11.17</font> Customer Bill 
					Ageing</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Customer Bill Ageing</strong> link, the screen 
					appears as shown in figure 96 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="420" src="helpfiles/Reports/CustomerBillAgeingReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 96.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the<strong> Date From</strong> and <strong>Date To</strong> by 
					clicking the datepickers.
					<p>To view the <strong>Customer Bill Ageing Report </strong>press <strong>View</strong>
						button, to generate a printout press <strong>Print </strong>button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="smr"></a>11.18</font> Slip Master 
					Report</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Slip Master Report</strong> link, the screen 
					appears as shown in figure 97 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/SlipMasterReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 97.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">To view the<strong> Slip Master Report</strong> press <strong>View</strong>
					button, to generate a printout press<strong> Print</strong> button.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="cws"></a>11.19</font> Customer Wise 
					Slip</td>
			</tr>
			<tr>
				<td class="t">Click on the<strong> Customer Wise Slip Report</strong> link, the 
					screen appears as shown in figure 98 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/CustomerWiseReconciliation.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 98.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the <strong>Date From</strong> and<strong> Date To</strong> by 
					clicking the datepickers.
					<p>To view the <strong>Customer Wise Slip Report</strong> press <strong>View</strong>
						button, to generate a printout press <strong>Print </strong>button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vlbr"></a>11.20</font> Vehicle Log 
					Book Report</td>
			</tr>
			<tr>
				<td class="t">Click on the <strong>Vehicle Log Book Report</strong> link, the 
					screen appears as shown in figure 99 below.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Reports/VehicleLogBookReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 99.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select the<strong> Vehicle No.</strong>, <strong>From Date</strong> and
					<strong>To Date</strong>.
					<p>To view the report press the <strong>View</strong> button and to generate the 
						printout press the <strong>Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="slr"></a>11.21</font> Stock Ledger 
					Report</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This report displays all the transaction details of a product. 
						Click on <strong>Stock Ledger Report</strong> link on the Home Page, the 
						following screen appears as shown in figure 100.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="371" src="helpfiles/Reports/StockLedgerReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 100.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the <strong>From Date</strong> and <strong>To Date</strong>
						then select product name from <strong>Product Name</strong> drop down and 
						select the transaction type from <strong>Transaction Type</strong>. Press the <strong>
							View</strong> button to view the report with transaction details between 
						selected<strong> From Date</strong> and <strong>To Date</strong> of a selected 
						product.
					</div>
					<p align="justify">Press the<strong> Print</strong> button to take the printout of 
						generated report.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="vr"></a>11.22</font> VAT Report</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">This report shows the details of VAT applied to <strong>Sales</strong>
						and <strong>Purchase</strong> invoices. Click on<strong> VAT Report</strong> link 
						on Home Page, the following screen appears as shown in figure 101.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="642" src="helpfiles/Reports/VatReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 101.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select the<strong> Report Type </strong>(i.e. Sales Report, 
						Purchase Report and Both) then select the<strong> Date From</strong> &amp; <strong>To</strong>
						from corresponding date pickers.
					</div>
					<p align="justify">Press<strong> View </strong>button to view the report and to 
						generate the printout press the <strong>Print</strong> button.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="tr"></a>11.23</font> Trading 
					Account</td>
			</tr>
			<tr>
				<td class="t">Click on<strong> Trading Account</strong> link on a Home Page. The 
					following screen appears as shown in figure 102.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="463" src="helpfiles/Reports/TradingAccount.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 102.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select <strong>Date From</strong> and<strong> Date To</strong> 
						dates from date pickers.
					</div>
					<p align="justify">Press the<strong> View </strong>button to view the<strong> Trading 
							Account </strong>and <strong>Profit &amp; Loss Account</strong> details 
						between selected <strong>From</strong> and <strong>To</strong> dates.</p>
					<p align="justify">Press the <strong>Print </strong>button to take the printout.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="bs"></a>11.24</font> Balance Sheet</td>
			</tr>
			<tr>
				<td class="t">Click on <strong>Balance Sheet</strong> link on Home Page , the 
					following screen appears as shown in figure 103.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="377" src="helpfiles/Reports/BalanceSheet.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 103.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Select <strong>Date From</strong> and<strong> Date To</strong> dates 
					from date pickers and press the<strong> View</strong> button to view the<strong> Balance 
						Sheet</strong>.
					<p>To take print out of a <strong>Balance Sheet</strong> click the <strong>Print</strong>
						button.
					</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="dc"></a>11.25 </font>Density Chart</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <STRONG>Density Chart </STRONG>link on Home Page, the 
					following screen appears as shown in figure 104.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="328" src="helpfiles/Reports/DensityChartReport.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 104.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t" height="80">
					<P>&nbsp;Press the<STRONG> View</STRONG> button to view the<STRONG>&nbsp;Density Chart</STRONG>.</P>
					<P>To fetch the <STRONG>Converted Density</STRONG> according to input values of <STRONG>
							Density</STRONG> and&nbsp;<STRONG>Temperature</STRONG>.</P>
					<P>This will be effected on <STRONG>Fuel Purchase</STRONG> and <STRONG>Daily Entry</STRONG>
						forms.&nbsp;&nbsp;</P>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"></div>
				</td>
			</tr>
			<tr>
				<td class="uh"><div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="uh">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="customer_data_mining" id="customer_data_mining"></a>11.26</font>
					Customer Data Mining</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view the details of all the customers, click on <strong>Customer 
							Data Mining</strong> link on the Home Page. The following screen appears as 
						shown in figure 45 below.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="415" src="helpfiles/Reports/CustomerDataMining.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 105.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To view the customer details select an option from <strong>Order 
							By</strong>. drop down. This drop down contains the order like, Customer 
						Name, Customer Type and Customer City. Select your choice to see the data 
						mining report.
					</div>
					<p align="justify">Press <strong>Print </strong>button to print the details.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="cashbillingreport" id="cashbillingreport"></a>11.27</font>
					Cash Billing Report</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <strong>Cash Billing Report </strong>link on Home 
					Page, the following screen appears as shown in figure 106.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t"><div align="center"><img src="helpfiles/Reports/Cashbillingreport.jpg" width="575" height="384"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 106.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="bankreconcilreport"></a>11.28</font>
					Bank Reconcillation Report</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <strong>Bank Reconcillation Report </strong>link on 
					Home Page, the following screen appears as shown in figure 107.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t"><div align="center"><img src="helpfiles/Reports/BankReconcillation.jpg" width="575" height="328"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 107.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="creditbill"></a>11.29</font> Credit 
					Bill</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">To generate a Credit Bill, click on the <strong>Credit Bill link</strong>
						on the Home Page. The following screen appears as shown below in figure 108.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CreditBill11.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Select <strong>From</strong> date by clicking the datepicker, 
						and the <strong>To</strong> date by clicking the datepicker. Select <strong>M/s.</strong>
						from the drop-down the details are displayed in a tabular form as shown below 
						in figure 108.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="335" src="helpfiles/Forms/CreditBill.jpg" width="575"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 108.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Press <strong>Save &amp; Print</strong> button to save and 
						print the credit bill details.
					</div>
					<p align="justify">Note: This User manual assumes that the <strong>Print_WindowService</strong>
						is up and running as a Windows Service, if not (or any problem with printing) 
						refer to the Installation Guide for the topic <A href="#how">How to start the 
							Print_WindowService</A> for<strong> DOS</strong> based printing.</p>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="taxreport"></a>11.30 </font>Tax 
					Report</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <strong>Tax Report </strong>link on Home Page, the 
					following screen appears as shown in figure 109.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t"><div align="center"><img src="helpfiles/Reports/TaxReport.jpg" width="575" height="335"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 109.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="ledgerreport"></a>11.31</font> Ledger 
					Report</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <strong>Ledger Report </strong>link on Home Page, the 
					following screen appears as shown in figure 110.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t"><div align="center"><img src="helpfiles/Reports/LedgerReport.jpg" width="575" height="335"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 110.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="ROI"></a>11.32</font> ROI &amp; 
					Analysis Report</td>
			</tr>
			<tr>
				<td class="t">&nbsp;Click on <strong>ROI &amp; Analysis Report </strong>link on 
					Home Page, the following screen appears as shown in figure 111.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t"><div align="center"><img src="helpfiles/Reports/ROI.jpg" width="575" height="328"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 111.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="how"></a>12</font> How to Start the 
					Print_WindowsService</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Incase the <strong>Print_WindowsService</strong> is stopped 
						then to start the <strong>Print_WindowsService</strong> as a windows service, 
						right click on <strong>My Computer</strong> then the following popup menu 
						appears as shown in figure 104.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="186" src="helpfiles/Forms/image205.jpg" width="178"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 105.<br>
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Click on<strong> Manage </strong>to open the <strong>Computer Management</strong>
					window as shown in following figure 105.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="425" src="helpfiles/Forms/image207.jpg" width="638"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 106.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">Double click on <strong>Services and</strong> <strong>Applications</strong>
					to expand as shown in following figure 106.</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="385" src="helpfiles/Forms/image209.jpg" width="638"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 107.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Click on<strong> Services</strong>, you will see the list of 
						all the window services on right side of the<strong> Computer Management</strong>
						window. Find the <strong>Print_WindowsServices</strong> and right click on it, 
						as shown in following figure 107.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="424" src="helpfiles/Forms/image211.jpg" width="638"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 108.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Click on <strong>Start</strong> to start the<strong> Print_WindowsService</strong>. 
						After starting the service the status of <strong>Print_WindowsService</strong> will 
						change to <strong>Started</strong> as shown following figure 108.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="center"><IMG height="385" src="helpfiles/Forms/image213.jpg" width="638"></div>
				</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="center">Figure 109.
					</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="t">
					<div align="justify">Close the <strong>Computer Management</strong> and check the <strong>
							Print_WindowsService</strong> is started or not from the <strong>ePetro</strong>
						application, if not started then again <strong>restart</strong> the service.</div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="uh">
					<div align="right"><A href="#toc">Back</A></div>
				</td>
			</tr>
			<tr>
				<td class="t">&nbsp;</td>
			</tr>
			<tr>
				<td class="head"><font color="#000000"><a name="logout"></a>13</font> Logout</td>
			</tr>
			<tr>
				<td class="t">After you are finished using the <strong>ePetro</strong> system, you 
					have to <strong>Log-Out</strong>. To keep away malicious users from misusing 
					your confidential data it is mandatory to Log-Out from the ePetro system.
					<br>
					<br>
					To Log Out click the image <IMG height="33" src="helpfiles/Forms/image214.jpg" width="24">on 
					Home Page.<br>
					<br>
					When you logout the<strong> Login</strong> screen appears.<br>
					<br>
					<strong>Thank you</strong> for using <strong>ePetro</strong> system. For any <strong>
						queries</strong> please feel free to contact <strong>bbnisys Technologies</strong>. 
					The<strong> Help</strong> menu has <strong>Contact Details</strong> which will 
					help<strong> you</strong> to reach<strong> us</strong>.
				</td>
			</tr>
		</table>
		<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</HTML>
