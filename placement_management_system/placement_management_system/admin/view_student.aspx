<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_student.aspx.cs" Inherits="placement_management_system.admin.view_student" %>



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
        <li class="bold"><a href="dashboard.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Dashboard</a></li>
        <li class="bold"><a href="add_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Add Student</a></li>
        <li class="bold active"><a href="view_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Selected Students For PI</a></li>
        <li class="bold"><a href="edit_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Students Data</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Company Data</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="reset_system.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Reset System</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">Selected Students For PI</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <form runat="server">

                <asp:GridView CssClass="bordered highlight" ID="GridView2" runat="server" Style="min-width: 1500px;" AutoGenerateColumns="False" DataSourceID="student_data" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="collage_id" HeaderText="collage id" SortExpression="collage_id"></asp:BoundField>
                        <asp:BoundField DataField="email_id" HeaderText="email id" SortExpression="email_id"></asp:BoundField>
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password"></asp:BoundField>
                        <asp:BoundField DataField="mobile_no" HeaderText="mobile no" SortExpression="mobile_no"></asp:BoundField>
                        <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch"></asp:BoundField>
                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob"></asp:BoundField>
                        <asp:BoundField DataField="cpi" HeaderText="cpi" SortExpression="cpi"></asp:BoundField>
                        <asp:BoundField DataField="full_name" HeaderText="full name" SortExpression="full_name"></asp:BoundField>
                        <asp:BoundField DataField="selected" HeaderText="selected" SortExpression="selected"></asp:BoundField>
                        <asp:BoundField DataField="written_test_given" HeaderText="written test given" SortExpression="written_test_given"></asp:BoundField>
                        <asp:BoundField DataField="written_test_marks" HeaderText="written test marks" SortExpression="written_test_marks"></asp:BoundField>
                        <asp:BoundField DataField="company_name" HeaderText="company name" SortExpression="company_name"></asp:BoundField>
                         <asp:BoundField DataField="achievement" HeaderText="achievement" SortExpression="achievement"></asp:BoundField>
                        <asp:BoundField DataField="skills" HeaderText="skills" SortExpression="skills"></asp:BoundField>
                    </Columns>
                </asp:GridView>


                <asp:SqlDataSource runat="server" ID="student_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>'  SelectCommand="SELECT student_table.collage_id, student_table.email_id, student_table.password, student_table.mobile_no, student_table.branch, student_table.dob, student_table.cpi, student_table.full_name, student_table.achievement, student_table.skills, company_choice.selected, company_choice.written_test_given, company_choice.written_test_marks, company_table.company_name FROM student_table INNER JOIN company_choice ON student_table.student_id = company_choice.student_id INNER JOIN company_table ON company_choice.company_id = company_table.company_id">
                    
                    
                </asp:SqlDataSource>





            </form>
        </div>

    </div>
</body>
</html>
