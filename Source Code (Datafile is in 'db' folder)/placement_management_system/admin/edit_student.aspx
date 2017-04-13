<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_student.aspx.cs" Inherits="placement_management_system.admin.WebForm1" %>


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
        <li class="bold"><a href="view_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Students Record</a></li>
        <li class="bold active"><a href="edit_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Students Data</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Company Data</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
         <li class="bold"><a href="reset_system.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Reset System</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">View & Edit Students Details</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <form runat="server">

                <asp:GridView  CssClass="bordered highlight" ID="GridView2" runat="server" Style="min-width: 1500px;" AutoGenerateColumns="False" DataSourceID="student_data" AllowPaging="True" AllowSorting="True" DataKeyNames="student_id">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                        <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="collage_id" HeaderText="College ID" SortExpression="collage_id"></asp:BoundField>
                        <asp:BoundField DataField="email_id" HeaderText="Email ID" SortExpression="email_id"></asp:BoundField>
                        <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password"></asp:BoundField>
                        <asp:BoundField DataField="mobile_no" HeaderText="Mobile no" SortExpression="mobile_no"></asp:BoundField>
                        <asp:BoundField DataField="branch" HeaderText="Branch" SortExpression="branch"></asp:BoundField>
                        <asp:BoundField DataField="dob" HeaderText="D.O.B" SortExpression="dob"></asp:BoundField>
                        <asp:BoundField DataField="cpi" HeaderText="CPI" SortExpression="cpi"></asp:BoundField>
                        <asp:BoundField DataField="full_name" HeaderText="Full name" SortExpression="full_name"></asp:BoundField>
                        <asp:BoundField DataField="achievement" HeaderText="Achievements" SortExpression="achievement"></asp:BoundField>
                        <asp:BoundField DataField="skills" HeaderText="skills" SortExpression="skills"></asp:BoundField>
                    </Columns>
                </asp:GridView>


                <asp:SqlDataSource runat="server" ID="student_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' SelectCommand="SELECT [student_id], [collage_id], [email_id], [password], [mobile_no], [branch], [dob], [cpi], [full_name], [achievement], [skills] FROM [student_table]" DeleteCommand="DELETE FROM [student_table] WHERE [student_id] = @student_id" InsertCommand="INSERT INTO [student_table] ([collage_id], [email_id], [password], [mobile_no], [branch], [dob], [cpi], [full_name], [achievement], [skills]) VALUES (@collage_id, @email_id, @password, @mobile_no, @branch, @dob, @cpi, @full_name, @achievement, @skills)" UpdateCommand="UPDATE [student_table] SET [collage_id] = @collage_id, [email_id] = @email_id, [password] = @password, [mobile_no] = @mobile_no, [branch] = @branch, [dob] = @dob, [cpi] = @cpi, [full_name] = @full_name, [achievement] = @achievement, [skills] = @skills WHERE [student_id] = @student_id">


                    <DeleteParameters>
                        <asp:Parameter Name="student_id" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="collage_id" Type="String"></asp:Parameter>
                        <asp:Parameter Name="email_id" Type="String"></asp:Parameter>
                        <asp:Parameter Name="password" Type="String"></asp:Parameter>
                        <asp:Parameter Name="mobile_no" Type="String"></asp:Parameter>
                        <asp:Parameter Name="branch" Type="String"></asp:Parameter>
                        <asp:Parameter Name="dob" Type="String"></asp:Parameter>
                        <asp:Parameter Name="cpi" Type="Decimal"></asp:Parameter>
                        <asp:Parameter Name="full_name" Type="String"></asp:Parameter>
                        <asp:Parameter Name="achievement" Type="String"></asp:Parameter>
                        <asp:Parameter Name="skills" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="collage_id" Type="String"></asp:Parameter>
                        <asp:Parameter Name="email_id" Type="String"></asp:Parameter>
                        <asp:Parameter Name="password" Type="String"></asp:Parameter>
                        <asp:Parameter Name="mobile_no" Type="String"></asp:Parameter>
                        <asp:Parameter Name="branch" Type="String"></asp:Parameter>
                        <asp:Parameter Name="dob" Type="String"></asp:Parameter>
                        <asp:Parameter Name="cpi" Type="Decimal"></asp:Parameter>
                        <asp:Parameter Name="full_name" Type="String"></asp:Parameter>
                        <asp:Parameter Name="achievement" Type="String"></asp:Parameter>
                        <asp:Parameter Name="skills" Type="String"></asp:Parameter>
                        <asp:Parameter Name="student_id" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>





            </form>
        </div>

    </div>
</body>
</html>

