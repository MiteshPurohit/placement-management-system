<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_company.aspx.cs" Inherits="placement_management_system.admin.view_company" %>


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
        <li class="bold"><a href="view_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Selected Students For PI</a></li>        
        <li class="bold"><a href="edit_student.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Students Data</a></li>
        <li class="bold active"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Company Data</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
                <li class="bold"><a href="reset_system.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Reset System</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">View & Edit Companies Details</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <form runat="server">
                
                <asp:GridView ID="GridView1"  CssClass="bordered highlight" runat="server" style="min-width:2100px;" AutoGenerateColumns="False" DataKeyNames="company_id" DataSourceID="company_data" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                        <asp:BoundField DataField="company_id" HeaderText="company id" ReadOnly="True" InsertVisible="False" SortExpression="company_id"></asp:BoundField>
                        <asp:BoundField DataField="company_name" HeaderText="company name" SortExpression="company_name"></asp:BoundField>
                         <asp:BoundField DataField="required_min_cpi" HeaderText="required min cpi" SortExpression="required_min_cpi"></asp:BoundField>
                         <asp:BoundField DataField="required_branches" HeaderText="required branches" SortExpression="required_branches"></asp:BoundField>
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password"></asp:BoundField>
                        <asp:BoundField DataField="tentative_salary" HeaderText="tentative salary" SortExpression="tentative_salary"></asp:BoundField>
                        <asp:BoundField DataField="job_post" HeaderText="job post" SortExpression="job_post"></asp:BoundField>
                        <asp:BoundField DataField="job_location" HeaderText="job location" SortExpression="job_location"></asp:BoundField>
                        <asp:BoundField DataField="description" HeaderText="description" ControlStyle-Width="180px" ItemStyle-Width="180px" SortExpression="description"></asp:BoundField>
                        <asp:BoundField DataField="other_details" HeaderText="other job details"  ControlStyle-Width="180px" ItemStyle-Width="180px" SortExpression="other_details"></asp:BoundField>
                       <asp:BoundField DataField="email" HeaderText="email" SortExpression="email"></asp:BoundField>
                        <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone"></asp:BoundField>
                      
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="company_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' DeleteCommand="DELETE FROM [company_table] WHERE [company_id] = @company_id" InsertCommand="INSERT INTO [company_table] ([password], [tentative_salary], [job_post], [job_location], [company_name], [description], [other_details], [required_min_cpi], [email], [phone], [required_branches]) VALUES (@password, @tentative_salary, @job_post, @job_location, @company_name, @description, @other_details, @required_min_cpi, @email, @phone, @required_branches)" SelectCommand="SELECT * FROM [company_table]" UpdateCommand="UPDATE [company_table] SET [password] = @password, [tentative_salary] = @tentative_salary, [job_post] = @job_post, [job_location] = @job_location, [company_name] = @company_name, [description] = @description, [other_details] = @other_details, [required_min_cpi] = @required_min_cpi, [email] = @email, [phone] = @phone, [required_branches] = @required_branches WHERE [company_id] = @company_id">
                    <DeleteParameters>
                        <asp:Parameter Name="company_id" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="password" Type="String"></asp:Parameter>
                        <asp:Parameter Name="tentative_salary" Type="String"></asp:Parameter>
                        <asp:Parameter Name="job_post" Type="String"></asp:Parameter>
                        <asp:Parameter Name="job_location" Type="String"></asp:Parameter>
                        <asp:Parameter Name="company_name" Type="String"></asp:Parameter>
                        <asp:Parameter Name="description" Type="String"></asp:Parameter>
                        <asp:Parameter Name="other_details" Type="String"></asp:Parameter>
                        <asp:Parameter Name="required_min_cpi" Type="Decimal"></asp:Parameter>
                        <asp:Parameter Name="email" Type="String"></asp:Parameter>
                        <asp:Parameter Name="phone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="required_branches" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="password" Type="String"></asp:Parameter>
                        <asp:Parameter Name="tentative_salary" Type="String"></asp:Parameter>
                        <asp:Parameter Name="job_post" Type="String"></asp:Parameter>
                        <asp:Parameter Name="job_location" Type="String"></asp:Parameter>
                        <asp:Parameter Name="company_name" Type="String"></asp:Parameter>
                        <asp:Parameter Name="description" Type="String"></asp:Parameter>
                        <asp:Parameter Name="other_details" Type="String"></asp:Parameter>
                        <asp:Parameter Name="required_min_cpi" Type="Decimal"></asp:Parameter>
                        <asp:Parameter Name="email" Type="String"></asp:Parameter>
                        <asp:Parameter Name="phone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="required_branches" Type="String"></asp:Parameter>
                        <asp:Parameter Name="company_id" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </form>
        </div>

    </div>
</body>
</html>
