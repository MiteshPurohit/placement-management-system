<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_details.aspx.cs" Inherits="placement_management_system.company.edit_details" %>

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
                    Hello, <asp:Label ID="name" runat="server" Text=""></asp:Label>
                </center>
            </span>

            <ul id="nav" class="offset-s1 col s1">
                <li class="right"><a href="student_logout.aspx">Logout</a></li>
            </ul>
        </div>

    </nav>
    <ul id="nav-mobile" class="side-nav fixed" style="height: 100%; width: 24%; transform: translateX(0px); border-right: solid thin #e0e0e0; transform: translateX(0px); margin: 0px 0px 0px 0px; padding-top: 5.35%;">
        <li class="bold"><a href="#" style="padding-left: 48px;" class="waves-effect waves-teal">Deshboard</a></li>
        <li class="bold"><a href="add_question.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Add Question</a></li>
        <li class="bold"><a href="view_question.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Question</a></li>
        <li class="bold"><a href="edit_details.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & edit details</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set Shcedule</a></li>
        <li class="bold"><a href="#" style="padding-left: 48px;" class="waves-effect waves-teal">View test result</a></li>
        <li class="bold"><a href="student_logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">Select Intrested Companies</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <div class="row">

                <div class="grey lighten-4 col s6" style="margin-top: 1%; margin-left: 9%; width: 90%; max-width: 600px; padding-top: 1%;">
                    <div id="form_after_pass_verification" runat="server">
                        <form runat="server">
                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="text" runat="server" id="cname" name="cname" class="validate" />
                                    <label for="cname">Company Name</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <textarea id="description" name="description" class="materialize-textarea" runat="server"></textarea>
                                    <label for="description">Company Description</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="text" runat="server" name="job_post" id="job_post" class="validate" />
                                    <label for="job_post">Job Post</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="text" runat="server" name="job_salary" id="job_salary" class="validate" />
                                    <label for="job_salary">Tentative Annual Salary</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="text" runat="server" name="job_location" id="job_location" class="validate" />
                                    <label for="job_location">Tentative Job Location</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <textarea id="other_details" name="other_details" class="materialize-textarea" runat="server"></textarea>
                                    <label for="other_details">Other Job Details</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="email" runat="server" name="email" id="email" class="validate" />
                                    <label for="email">Company E-mail Id</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="tel" runat="server" name="phone" id="phone" class="validate" />
                                    <label for="phone">Company Contact Number</label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-field col s12">
                                    <input type="text" runat="server" name="min_cpi" id="min_cpi" class="validate" />
                                    <label for="min_cpi">Minimum CPI Required</label>
                                </div>
                            </div>


                            <div class="row">

                                <div class="input-field col s12">
                              
                                  <input type="text" runat="server" name="branch" id="branch" class="validate" />
                                    <label for="branch">Required Branches(branch short name saperated by ',')</label>
                                    
                                </div>
                                <script>
                                    $(document).ready(function () {
                                        $('select').material_select();
                                    });
                                </script>

                            </div>

                           


                            <div class="row">
                                <div class="input-field col s12">
                                    <asp:Button runat="server" ID="reg_btn" class="btn waves-effect waves-light" Text="save" OnClick="submit_Click" />

                                </div>
                            </div>
                        </form>
                    </div>

                </div>

            </div>
        </div>

    </div>
</body>
</html>
