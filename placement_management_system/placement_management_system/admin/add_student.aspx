<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_student.aspx.cs" Inherits="placement_management_system.admin_home" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script type="text/javascript" src="../materialize/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="../materialize/js/materialize.min.js"></script>
    <title></title>
</head>
<body>
    <div runat="server" id="script">

    </div>
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
        <li class="bold active"><a href="add_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Add Student</a></li>
        <li class="bold"><a href="view_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View Students Data</a></li>        
        <li class="bold"><a href="edit_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Edit Students Data</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Company Data</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>


    <form runat="server"  enctype="multipart/form-data">


        <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">

            
            <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
                <h4 class="center-align">Import Student Data</h4>
            </div>


            <div  style="padding-top: 9%; width: 75%; padding-left: 3%;">
                 <div class="row">
                        <div class="input-field col s8">
                            <div class="file-field input-field">
                                <div class="btn">
                                    <span>File</span>
                                    <input name="ref_docs" type="file">
                                </div>
                                <div class="file-path-wrapper">
                                    <input class="file-path validate" placeholder="Excel file of students record " type="text">
                                </div>
                            </div>
                        </div>
                     <div class="input-field col s4">
                         <asp:Button ID="submit"  class="waves-effect waves-light btn"   runat="server" Text="submit" OnClick="submit_Click"  />
                     </div>
                    </div>
                
                </div>

                  <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
                <h4 class="center-align">Insert student menually</h4>
            </div>
            <div  style="padding-top: 9%; width: 75%; padding-left: 3%;">
                 <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="collage_id" name="collage_id" class="validate" runat="server"></asp:TextBox>
                            <label for="fname">Collage ID</label>
                        </div>

                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="fname" name="fname" class="validate" runat="server"></asp:TextBox>
                            <label for="fname">Full Name</label>
                        </div>

                    </div>
                <div class="row">
                        <div class="input-field col s12">
                            <asp:DropDownList ID="branch" name="branch" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Text="Computer Engineering" Value="CE" />
                                <asp:ListItem Text="Civil Engineering" Value="CL" />
                                <asp:ListItem Text="Chemical Engineering" Value="CH" />
                                <asp:ListItem Text="Mechenical Engineering" Value="MH" />
                                <asp:ListItem Text="Instrument & Control" Value="IC" />
                                <asp:ListItem Text="Information Technolog" Value="IT" />
                                <asp:ListItem Text="Electronics & Communication" Value="EC" />
                            </asp:DropDownList>
                           
                            <label for="branch">Your Branch</label>
                        </div>
                        <script>
                            $(document).ready(function () {
                                $('select').material_select();
                            });
                        </script>
                    </div>
                <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="cpi" name="cpi" class="validate" runat="server"></asp:TextBox>
                            <label for="cpi">CPI</label>
                        </div>
                    </div>
                 <div class="row">

                        <div class="col s12">
                            <asp:TextBox ID="birthdate" type="date" TextMode="Date" name="dob" class="datepicker" placeholder="Birthdate" runat="server"></asp:TextBox>
                            <script>
                                $('.datepicker').pickadate({
                                    selectMonths: true, // Creates a dropdown to control month
                                    selectYears: 30 // Creates a dropdown of 15 years to control year

                                });

                            </script>
                        </div>

                    </div>
                <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="password" name="password" class="validate" runat="server"></asp:TextBox>
                            <label for="fname">Password</label>
                        </div>

                    </div>
                <asp:Button ID="manual_insert" class="waves-effect waves-light btn" runat="server" Text="add" OnClick="manual_insert_Click" />
            </div>
        </div>
    </form>
</body>
</html>