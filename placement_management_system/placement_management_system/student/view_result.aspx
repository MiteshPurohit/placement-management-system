<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_result.aspx.cs" Inherits="placement_management_system.student.view_result" %>

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
        <li class="bold"><a href="dashboard.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Deshboard</a></li>
        <li class="bold"><a href="select_company_for_test.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Written test</a></li>
        <li class="bold"><a href="student_add_details.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View & edit details</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View companies</a></li>
        <li class="bold"><a href="select_company.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Select intrested companies</a></li>
        <li class="bold active"><a href="view_result.aspx" style="padding-left:48px;" class="waves-effect waves-teal">View result</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left:48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>

   <form runat="server">
     <div style="margin-top:6%; width:100%; padding: 0px; position:absolute; padding-left:24%;">
        <div class="grey lighten-4" style="width:100%; padding-top:4px; padding-bottom:6px;">
            <h4 class="center-align">View Companies</h4>
        </div>
         <div class="container" style=" margin-top:1%; max-width:1200px;">
        <blockquote>
            If you are not selected for PI then wait for some days 
            <br />because it may possible that company may not have updated.
            </blockquote>
             
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="result_data">
                 <Columns>
                     <asp:BoundField DataField="company_id" HeaderText="company id" SortExpression="company_id"></asp:BoundField>
                     <asp:BoundField DataField="company_name" HeaderText="company name" SortExpression="company_name"></asp:BoundField>
                     <asp:BoundField DataField="selected" HeaderText="selected for PI" SortExpression="selected"></asp:BoundField>
                     <asp:BoundField DataField="written_test_given" HeaderText="written test given" SortExpression="written_test_given"></asp:BoundField>
                     <asp:BoundField DataField="written_test_marks" HeaderText="written test marks" SortExpression="written_test_marks"></asp:BoundField>
                 </Columns>
             </asp:GridView>


             <asp:SqlDataSource runat="server" ID="result_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' SelectCommand="SELECT company_choice.company_id, company_table.company_name, company_choice.selected, company_choice.written_test_given, company_choice.written_test_marks FROM company_choice INNER JOIN company_table ON company_choice.company_id = company_table.company_id where student_id=@student_id">
                  <SelectParameters>
                        <asp:SessionParameter SessionField="student_id" DefaultValue="1" Name="student_id" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
             </asp:SqlDataSource>
         </div>
            
    </div>
       </form>
 </body>
</html>