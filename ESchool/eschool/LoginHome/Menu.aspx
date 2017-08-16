<%@ Register TagPrefix="uc1" TagName="header" Src="../HeaderFooter/usercontrol/header1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="../HeaderFooter/usercontrol/Footer.ascx" %>
<%@ Page language="c#" Codebehind="Menu.aspx.cs" AutoEventWireup="false" Inherits="eschool.LoginHome.Menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>eSchool : Home Page</title>
   <!--
   Copyright (c) 2005 bbnisys Technologies. All Rights Reserved.
   No part of this software shall be reproduced, stored in a 
   retrieval system, or transmitted by any means, electronic 
   mechanical, photocopying, recording  or otherwise, or for
   any  purpose  without the express  written  permission of
   bbnisys Technologies.
   -->
   <script language=javascript>
		
<!--Total Java Scripts 99 - Next Step Software-->

<!-- Original:  Jan Pijnacker <Jan_P@dds.nl> -->
<!-- Website :  http://www.piaster.nl/perspicacity/js/headliner -->

<!-- Begin
typeWriterWait=120		// Typewriter delay
blinkTextWait=1000   	// Blinking delay
blinkSpacesWait=300 	// Blinking 'blank-spaces' delay
blinkMax=3         		// how many times to blink
expandWait=100  		// expanding headliner delay
scrollWait=90		// scrolling headliner delay
scrollWidth=34 		// characters in scroll display
randomLines=false		// randomly choose lines?  (true or false)
//07.04.08  lineMax=5			// how many lines you have
lineMax=4			// how many lines you have
lines=new Array(lineMax)

// Use this format for all the lines below:
// (display text, url or mailto, frame name, effect, delay time)

//07.04.08--lines[1]=new Line(" e-School ", "http://www.piaster.nl/perspicacity/js/headliner", "", Blink, 300)
lines[1]=new Line(" e-School Online School Management System ", "http://www.piaster.nl/perspicacity/js/headliner", "", Blink, 300)
//07.04.08--lines[2]=new Line(" Welcome To No-1 Air Force school Gwalior (M.P.) ", "", "", Scroll, 500)
//lines[3]=new Line("Wouldn't this be good on your site?", "", "", Static, 3500)
//lines[4]=new Line("Many ways to present information....", "", "", Expand, 2000)
lines[2]=new Line("A Complete School Management System", "", "", Scroll, 1000)
lines[3]=new Line("Developed By Bbnisys Technologies Pvt. Ltd. Gwalior (MP)", 

"mailto:Jan_P@dds.nl?subject=The Headliner", "", TypeWriter, 1000)
lines[4]=new Line("For more information please visit our website - www.bbnisys.com", 

"http://www.piaster.nl/perspicacity/js/headliner", "", TypeWriter, 1500)
//lines[6]=new Line("Or here to go back to Messages", "http://messages.javascriptsource.com", "", 

//Static, 3500)
// Don't change these variables below  :-)
lineText=""
timerID=null
timerRunning=false
spaces=""
charNo=0
charMax=0
charMiddle=0
lineNo=0
lineWait=0
function Line(text, url, frame, type, wait) {
this.text=text
this.url=url
this.frame=frame
this.Display=type
this.wait=wait
}
function StringFill(c, n) {
var s=""
while (--n >= 0) {
s+=c
}
return s
}
function getNewRandomInteger(oldnumber, max) {
var n=Math.floor(Math.random() * (max - 1) + 1)
if (n >= oldnumber) {
n++
}
return n
}
function getRandomInteger(max) {
var n=Math.floor(Math.random() * max + 1)
return n
}
function GotoUrl(url, frame) {
if (frame != '') {
if (frame == 'self') self.location.href=url
else if (frame == 'parent') parent.location.href=url
else if (frame == 'top') top.location.href=url
else {
s=eval(top.frames[frame])
if (s != null) top.eval(frame).location.href=url
else window.open(url, frame, "toolbar=yes,status=yes,scrollbars=yes")
      }
   }
else window.location.href=url
}
function Static() {
document.Menu.buttonFace.value=this.text
timerID=setTimeout("ShowNextLine()", this.wait)
}
function TypeWriter() {
lineText=this.text
lineWait=this.wait
charMax=lineText.length
spaces=StringFill(" ", charMax)
TextTypeWriter()
}
function TextTypeWriter() {
if (charNo <= charMax) {
document.Menu.buttonFace.value=lineText.substring(0, charNo)+spaces.substring(0, 

charMax-charNo)
charNo++
timerID=setTimeout("TextTypeWriter()", typeWriterWait)
}
else {
charNo=0
timerID=setTimeout("ShowNextLine()", lineWait)
   }
}
function Blink() {
lineText=this.text
charMax=lineText.length
spaces=StringFill(" ", charMax)
lineWait=this.wait
TextBlink()
}
function TextBlink() {
if (charNo <= blinkMax * 2) {
if ((charNo % 2) == 1) {
document.Menu.buttonFace.value=lineText
blinkWait=blinkTextWait
}
else {
document.Menu.buttonFace.value=spaces
blinkWait=blinkSpacesWait
}
charNo++
timerID=setTimeout("TextBlink()", blinkWait)
}
else {
charNo=0
timerID=setTimeout("ShowNextLine()", lineWait)
   }
}
function Expand() {
lineText=this.text
charMax=lineText.length
charMiddle=Math.round(charMax / 2)
lineWait=this.wait
TextExpand()
}
function TextExpand() {
if (charNo <= charMiddle) {
document.Menu.buttonFace.value=lineText.substring(charMiddle - charNo, charMiddle + 

charNo)
charNo++
timerID=setTimeout("TextExpand()", expandWait)
}
else {
charNo=0
timerID=setTimeout("ShowNextLine()", lineWait)
   }
}
function Scroll() {
spaces=StringFill(" ", scrollWidth)
lineText=spaces+this.text
charMax=lineText.length
lineText+=spaces
lineWait=this.wait
TextScroll()
}
function TextScroll() {
if (charNo <= charMax) {
document.Menu.buttonFace.value=lineText.substring(charNo, scrollWidth+charNo)
charNo++
timerID=setTimeout("TextScroll()", scrollWait)
}
else {
charNo=0
timerID=setTimeout("ShowNextLine()", lineWait)
   }
}
function StartHeadliner() {
StopHeadliner()
timerID=setTimeout("ShowNextLine()", 2000)
timerRunning=true
}
function StopHeadliner() {
if (timerRunning) { 
clearTimeout(timerID)
timerRunning=false
   }
}
function ShowNextLine() {
if (randomLines) lineNo=getNewRandomInteger(lineNo, lineMax)
else (lineNo < lineMax) ? lineNo++ : lineNo=1
lines[lineNo].Display()
}
function LineClick(lineNo) {
document.Menu.buttonFace.blur()
if (lineNo > 0) GotoUrl(lines[lineNo].url, lines[lineNo].frame)
}

// End -->

function change()
{
//document.Menu.Button1.style.font.fontColor('#White');

}
function change1()
{
/*document.Menu.Button1.style.backgroundColor=white;*/

}

</script>
<!-- Script Size:  5.69 KB  -->


		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<!--<meta content="JavaScript" name="vs_defaultClientScript">-->
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../HeaderFooter/shareables/Style/Styles.css" type="text/css" rel="stylesheet">
		<SCRIPT type="text/javascript" src='/eschool/shareables/jsfiles/coolmenus3.js'></SCRIPT>
</HEAD>
	<body onload="StartHeadliner()">
		<form id="Menu" name="Menu" method="post" runat="server">
		
<uc1:header id=Header1 runat="server"></uc1:header>
			<table height="262" width="775" align="center">
				<TBODY>
					
					<!--tr>
						<td colSpan="1">
						
						
						</td>
					</tr>
					<tr>
						<td colSpan="3">
      </td>
					</tr>
					<tr>
						<td colSpan="3"></td>
					</tr>
					<tr>
						<td colSpan="3"></td>
					</tr>
					<tr>
						<td colSpan="1"></td>
					</tr>
					<tr>
						<td colSpan="1"></td>
					</tr>
					<tr>
						<td colSpan="1"></td>
					</tr-->
					
						<!--<td colSpan="1" align=center><input type=text name="buttonFace" size="60" <td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: #a43333; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none">
						<!--DIV style="LEFT: 712px; POSITION: absolute; TOP: 138px"><input type=button value="Logout" id=Button1  onmousemove="change()"  onmouseout="change1()" name=Button1 runat="server" style="BORDER-LEFT-COLOR: white; BACKGROUND-IMAGE: none; BORDER-BOTTOM-COLOR: white; COLOR: white; BORDER-TOP-STYLE: groove; BORDER-TOP-COLOR: white; FONT-FAMILY: Arial; BORDER-RIGHT-STYLE: groove; BORDER-LEFT-STYLE: groove; BACKGROUND-COLOR: firebrick; BORDER-RIGHT-COLOR: white; BORDER-BOTTOM-STYLE: groove"></DIV></td-->
					<TR>
						<td vAlign="top" align="center">
							<TABLE  BORDER-COLLAPSE: collapse;  borderColor="#111111"
								cellSpacing="0" cellPadding="0" align="center">
								<TBODY>
									<TR>
										<TD >&nbsp;</TD>
									<tr>
										<td >
											<table class="MsoTableGrid" border="1" cellspacing="0" cellpadding="0"   style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 455.4pt; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse">
												<tr>
													<td  valign="top" style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0in; BORDER-LEFT: windowtext 1pt solid; WIDTH: 455.4pt; PADDING-TOP: 0in; BORDER-BOTTOM: windowtext 1pt solid">
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  We are glad to 
																announce the launch of e-School (School Management System), a Web base 
																application to handle the entire&nbsp; school&nbsp; system.&nbsp; During&nbsp; the&nbsp; 
																implementation&nbsp; of&nbsp; e-School &nbsp;as&nbsp; a full&nbsp; ERP&nbsp; for school&nbsp; administration&nbsp; 
																and&nbsp; interaction,<br>
																 we&nbsp; strongly&nbsp; realized&nbsp; &nbsp;the need&nbsp; of a&nbsp; 
																simple&nbsp; yet&nbsp; effective&nbsp; version&nbsp; of&nbsp;e-School which should preferably run 
																on MS SQL<br>
																 server without&nbsp;&nbsp; losing&nbsp; the 
																scalability,&nbsp; flexibility&nbsp; and&nbsp; its&nbsp; core strength&nbsp; of 
																user&nbsp; friendliness&nbsp; with&nbsp;strong security of your
																<br>
																valued database.&nbsp;
																<br>
																<br>
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e-School&nbsp; is&nbsp; a&nbsp; powerful,&nbsp; fully&nbsp; browser based&nbsp; 
																school&nbsp; Management&nbsp; System that&nbsp; is easy&nbsp; to use, fast to 
																implement and effective&nbsp; to&nbsp; mobilize the&nbsp; school l 
																management&nbsp; system&nbsp; in&nbsp; a great&nbsp; way. Following features 
																have been incorporated to enhanced both effectiveness and convenience for the 
																user.</span></p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial"></span>&nbsp;</p>
													</td>
												</tr>
											</table>
											<!--table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0"   style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 455.4pt; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse">
												<tr >
													<td  valign="top" style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0in; BORDER-LEFT: windowtext 1pt solid; WIDTH: 221.4pt; PADDING-TOP: 0in; BORDER-BOTTOM: windowtext 1pt solid; HEIGHT: 105.25pt">
														<p style="MARGIN: 1pt 0in"><b> <span style="FONT-SIZE: 8pt; COLOR: #9933ff; FONT-FAMILY: Arial">
																	The following School Management System modules are provided in e-School:-</span></b></p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">1. </span><span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">
																Student Management:</span></p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">
																 2. Time Table Management:
																<br>
																3. Logistic (Transportation) Management:</span></p>
                  <P style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">  
																  4. Library Management:
																<br>
																5. Accounts Management:
																<br> 6.</span>
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial"> Parent Teacher 
																Association </span></P>
                  <P style="MARGIN: 1pt 0in"><SPAN 
                  style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">7. 
                  Administrator</SPAN><SPAN 
                  style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">:</SPAN></P>
                  <P style="MARGIN: 1pt 0in"><SPAN 
                  style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">8. 
                  Reports:</SPAN></P>
													</td>
													<td valign="top" style="BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0in; BORDER-LEFT: medium none; WIDTH: 3.25in; PADDING-TOP: 0in; BORDER-BOTTOM: windowtext 1pt solid; HEIGHT: 105.25pt">
														<p style="MARGIN: 1pt 0in"><b> <span style="FONT-SIZE: 8pt; COLOR: #9933ff; FONT-FAMILY: Arial">
																	About bbnisys e-School:-</span></b></p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">1. Browser based 
																school administration software.
																<br>
																2. Can be installed on a windows based machine&nbsp; (Windows </span></p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">&nbsp;&nbsp;&nbsp;&nbsp; 
																9x /2000 / Me / XP/Me &amp; above).<br>
																3. Every teacher and school management have their 
																unique&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
														</p>
														<p style="MARGIN: 1pt 0in">
															<span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">&nbsp;&nbsp;&nbsp; 
																user name and password to work in the system.
																<br>
																4. Has all core school administration modules.
																<br>
																5. Other pluggable modules are also available.</span></p>
														<p style="MARGIN: 1pt 0in"><b> <span style="FONT-SIZE: 8pt; COLOR: #993300; FONT-FAMILY: Arial">
																</span></b>&nbsp;</p>
													</td>
												</tr>
											</table-->
										</td>
									</tr>
								</TBODY>
							</TABLE>
						</td>
					</TR>
				</TBODY>
			</table>
<uc1:footer id=Footer1 runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
