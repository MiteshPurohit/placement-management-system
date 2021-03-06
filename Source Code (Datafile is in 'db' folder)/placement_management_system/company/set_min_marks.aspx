﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set_min_marks.aspx.cs" Inherits="placement_management_system.company.set_max_marks" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../materialize/css/ghpages-materialize.css" type="text/css" rel="stylesheet" media="screen,projection">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script type="text/javascript" src="../materialize/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.3/js/materialize.min.js"></script>
    <title></title>
</head>
<body>

    <nav style="position: fixed; z-index: 1000;" class="red lighten-1">
        <div class="nav-wrapper row">

            <span style="margin-left: 3%; font-size: 2em;" class="col s3">Placement Cell</span>
            <span style="align-self: center; font-size: 1.5em;" class="col s6">
                <center>
                    Hello, <asp:Label ID="name" runat="server" Text=""></asp:Label>
                </center>
            </span>

            <ul id="nav" class="offset-s1 col s1">
                <li class="right"><a href="logout.aspx">Logout</a></li>
            </ul>
        </div>

    </nav>
    <ul id="nav-mobile" class="side-nav fixed" style="height: 100%; width: 24%; transform: translateX(0px); border-right: solid thin #e0e0e0; transform: translateX(0px); margin: 0px 0px 0px 0px; padding-top: 5.35%;">
        <li class="bold"><a href="dashboard.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Dashboard</a></li>
        <li class="bold"><a href="add_question.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Add Question</a></li>
        <li class="bold"><a href="view_question.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Question</a></li>
        <li class="bold"><a href="edit_details.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & edit details</a></li>
         <li class="bold"><a href="start_test.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Start Test</a></li>
         <li class="bold active"><a href="set_min_marks.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set minimum marks</a></li>
        <li class="bold"><a href="set_schedule.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set Schedule</a></li>
        <li class="bold"><a href="view_students.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View Students</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">Set Minimum Marks to appear for interview</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 9%; width: 90%;">
            <form runat="server">
                 <div class="row">
                                <div class="input-field col s6">
                                     <asp:TextBox ID="min_marks" name="min_marks" class="validate" runat="server" ></asp:TextBox>
                                    <label for="min_marks">Mimimum marks for written test</label>
                                </div>
                     <div class="input-field col s6">
                                      <asp:Button ID="set_marks" runat="server" class="waves-effect waves-light btn" Text="set" OnClick="set_marks_Click" />
                                </div>
                            </div>
            </form>
        </div>
    </div>


</body>
</html>
