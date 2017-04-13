<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="placement_management_system.error" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
        <link type="text/css" rel="stylesheet" href="../materialize/css/materialize.min.css"  media="screen,projection"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
       <script type="text/javascript" src="../materialize/jquery-2.1.1.min.js"></script>
        <script type="text/javascript" src="../materialize/js/materialize.min.js"></script>
        <title></title>
    </head>
<body>
    <nav class="red lighten-1">
    <div class="nav-wrapper">
         
      <span style="margin-left:3%; font-size:2em;">Placement Cell</span>
             
                
      <ul id="nav" style="margin-right:3%;" class="right">
        <li><a href="../student/student_login.aspx">Student</a></li>
        <li><a href="../company/company_login.aspx">Company</a></li>
        <li><a href="admin_login.aspx">Admin</a></li>
      </ul>
    </div>

    </nav>
    <div class="container">
        
        <div class="row" style="margin-top:30px;">
            <div class="offset-s3 col s6">
            <form runat="server">
                <h3>Probably Invalid Input</h3>
                <h6>Go back and change inputs</h6>
            </form>
                </div>
        </div>
    </div>
</body>
</html>

