﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_company.aspx.cs" Inherits="placement_management_system.student.view_company" %>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
      <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
         <link href="../materialize/css/ghpages-materialize.css" type="text/css" rel="stylesheet" media="screen,projection">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
       <script type="text/javascript" src="../materialize/jquery-2.1.1.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.3/js/materialize.min.js"></script>
        <title></title>
    </head>
<body>
   
    <nav style="position:fixed; z-index:1000;" class="red lighten-1">
        <div class="nav-wrapper row">

            <span style="margin-left:3%; font-size:2em;" class="col s3">Placement Cell</span>
            <span style="align-self:center; font-size: 1.5em;" class="col s6">
                <center>
                    Hello, <asp:Label ID="name" runat="server" Text=""></asp:Label>
                </center>
            </span>

            <ul id="nav" class="offset-s1 col s1">
                <li class="right"><a href="logout.aspx">Logout</a></li>
            </ul>
        </div>

    </nav>
    <ul id="nav-mobile" class="side-nav fixed" style="height:100%; width:24%; transform: translateX(0px); border-right:solid thin #e0e0e0; transform: translateX(0px); margin:0px 0px 0px 0px; padding-top:5.35%;">
       <li class="bold"><a href="dashboard.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Dashboard</a></li>
        <li class="bold"><a href="select_company_for_test.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Written test</a></li>
        <li class="bold"><a href="student_add_details.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View & edit details</a></li>
        <li class="bold active"><a href="view_company.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View companies</a></li>
        <li class="bold"><a href="select_company.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Select interested companies</a></li>
        <li class="bold"><a href="view_result.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View result</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>

   
     <div style="margin-top:6%; width:100%; padding: 0px; position:absolute; padding-left:24%;">
        <div class="grey lighten-4" style="width:100%; padding-top:4px; padding-bottom:6px;">
            <h4 class="center-align">View Companies</h4>
        </div>
         <div class="container" style=" margin-top:1%; margin-left:9%; width:90%; max-width:600px;">
        
        <div class="collection" runat="server" id="list">
        
      </div>


</div>
            
    </div>
 </body>
</html>