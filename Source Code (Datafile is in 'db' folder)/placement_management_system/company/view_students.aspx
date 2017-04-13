<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_students.aspx.cs" Inherits="placement_management_system.company.view_students" %>


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
         <li class="bold"><a href="set_min_marks.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set minimum marks</a></li>
        <li class="bold"><a href="set_schedule.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set Schedule</a></li>
        <li class="bold active"><a href="view_students.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View Students</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">View students details and result</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <form runat="server">

                <asp:GridView ID="GridView1"  CssClass="bordered highlight" runat="server" DataSourceID="student_data" style="min-width:1500px;" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="collage_id" HeaderText="collage id" SortExpression="collage_id"></asp:BoundField>
                        <asp:BoundField DataField="full_name" HeaderText="full name" SortExpression="full_name"></asp:BoundField>
                        <asp:BoundField DataField="selected" HeaderText="selected" SortExpression="selected"></asp:BoundField>
                        <asp:BoundField DataField="written_test_marks" HeaderText="written test marks" SortExpression="written_test_marks"></asp:BoundField>
                        <asp:BoundField DataField="cpi" HeaderText="cpi" SortExpression="cpi"></asp:BoundField>
                        <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch"></asp:BoundField>
                        <asp:BoundField DataField="skills" HeaderText="skills" SortExpression="skills"></asp:BoundField>
                        <asp:BoundField DataField="achievement" HeaderText="achievement" SortExpression="achievement"></asp:BoundField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Question" SortExpression="question">
                            <ItemTemplate>
                                 <asp:LinkButton ID="lnkDownload" Text = "refrance documents" CommandArgument = '<%# Eval("student_id") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="birthdate"></asp:BoundField>
                        <asp:BoundField DataField="email_id" HeaderText="email id" SortExpression="email_id"></asp:BoundField>
                        <asp:BoundField DataField="mobile_no" HeaderText="mobile no" SortExpression="mobile_no"></asp:BoundField>
                    </Columns>
                </asp:GridView>



                <asp:SqlDataSource runat="server" ID="student_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' SelectCommand="SELECT student_table.student_id, student_table.collage_id, student_table.full_name, company_choice.selected, company_choice.written_test_marks, student_table.cpi, student_table.branch, student_table.skills, student_table.achievement, student_table.refrance_documents, student_table.dob, student_table.email_id, student_table.mobile_no FROM company_choice INNER JOIN student_table ON company_choice.student_id = student_table.student_id where company_choice.company_id = @company_id">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="company_id" DefaultValue="1" Name="company_id" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </form>
        </div>

    </div>
</body>
</html>
