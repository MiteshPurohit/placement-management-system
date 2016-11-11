<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reset_system.aspx.cs" Inherits="placement_management_system.admin.reset_system" %>
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
    <div id="alert" runat="server"></div>

    <nav style="position: fixed; z-index: 1000;" class="red lighten-1">
        <div class="nav-wrapper row">

            <span style="margin-left: 3%; font-size: 2em;" class="col s3">Placement Cell</span>
            <span style="align-self: center; font-size: 1.5em;" class="col s6">
                <center>
                    Hello, <asp:Label ID="name" runat="server" Text="">Admin</asp:Label>
                </center>
            </span>

            <ul id="nav" class="offset-s1 col s1">
                <li class="right"><a href="logout.aspx">Logout</a></li>
            </ul>
        </div>

    </nav>
    <ul id="nav-mobile" class="side-nav fixed" style="height: 100%; width: 24%; transform: translateX(0px); border-right: solid thin #e0e0e0; transform: translateX(0px); margin: 0px 0px 0px 0px; padding-top: 5.35%;">
        <li class="bold"><a href="#" style="padding-left: 48px;" class="waves-effect waves-teal">Deshboard</a></li>
        <li class="bold"><a href="add_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Add Student</a></li>
        <li class="bold"><a href="view_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View Students Data</a></li>        
        <li class="bold"><a href="edit_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Edit Students Data</a></li>
        <li class="bold active"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Company Data</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">Reset Whole System</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 3%;">
            <form runat="server">
                <div runat="server" id="reset_div">
                  <div class="row">
                        <div class="input-field col s4">
                            <asp:TextBox ID="reset_text" name="reset_text" class="validate" runat="server"></asp:TextBox>
                            <label for="reset_text">Type 'RESET' in capital letter and then press reset button</label>
                        </div>
                      <div class="input-field col s3">
                       <asp:Button ID="reset" class="waves-effect waves-light btn" runat="server" Text="reset" OnClick="reset_Click" />
                          </div>
                    </div>
               </div>
               </form>
        </div>

    </div>
</body>
</html>
