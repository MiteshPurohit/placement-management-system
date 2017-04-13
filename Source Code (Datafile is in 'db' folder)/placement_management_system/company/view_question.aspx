<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_question.aspx.cs" Inherits="placement_management_system.company.view_question" %>


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
        <li class="bold active"><a href="view_question.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & Edit Question</a></li>
        <li class="bold"><a href="edit_details.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & edit details</a></li>
         <li class="bold"><a href="start_test.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Start Test</a></li>    
         <li class="bold"><a href="set_min_marks.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set minimum marks</a></li>
        <li class="bold"><a href="set_schedule.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Set Schedule</a></li>
        <li class="bold"><a href="view_students.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View Students</a></li>
        <li class="bold"><a href="change_password.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Change Password</a></li>
        <li class="bold"><a href="logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>



    <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">
        <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
            <h4 class="center-align">Select Intrested Companies</h4>
        </div>
        <div class="container" style="margin-top: 1%; margin-left: 0%;">
            <form runat="server">

                <asp:GridView ID="GridView1" CssClass="bordered highlight" runat="server" AutoGenerateColumns="False" DataKeyNames="question_id" DataSourceID="question_data" AllowPaging="True">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                        <asp:BoundField DataField="question_id" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="question_id"></asp:BoundField>

                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Question" SortExpression="question">
                            <EditItemTemplate>
                                <div style="width: 192px;">
                                    <asp:TextBox runat="server" ID="question" Text='<%# Bind("question") %>' TextMode="MultiLine" class="materialize-textarea"></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <div style="max-width: 294px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("question") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option A" SortExpression="option_a">
                            <EditItemTemplate>
                                <div style="width: 108px;">
                                    <asp:TextBox runat="server" ID="option_a" Text='<%# Bind("option_a") %>' TextMode="MultiLine" class="materialize-textarea"></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <div style="max-width: 194px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("option_a") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option B" SortExpression="option_b">
                            <EditItemTemplate>
                                <div style="width: 108px;">
                                    <asp:TextBox runat="server" ID="option_b" Text='<%# Bind("option_b") %>' TextMode="MultiLine" class="materialize-textarea"></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <div style="max-width: 194px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("option_b") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option C" SortExpression="option_c">
                            <EditItemTemplate>
                                <div style="width: 108px;">
                                    <asp:TextBox runat="server" ID="option_c" Text='<%# Bind("option_c") %>' TextMode="MultiLine" class="materialize-textarea"></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <div style="max-width: 194px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("option_c") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option D" SortExpression="option_d">
                            <EditItemTemplate>
                                <div style="width: 108px;">
                                    <asp:TextBox runat="server" ID="option_d" Text='<%# Bind("option_d") %>' TextMode="MultiLine" class="materialize-textarea"></asp:TextBox>
                                </div>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <div style="max-width: 194px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("option_d") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="choice_ans" HeaderText="Answer" SortExpression="choice_ans"></asp:BoundField>
                        
                    </Columns>
                </asp:GridView>





                <asp:SqlDataSource runat="server" ID="question_data" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' DeleteCommand="DELETE FROM [question_table] WHERE [question_id] = @question_id" InsertCommand="INSERT INTO [question_table] ([question], [option_a], [option_c], [option_b], [choice_ans], [option_d]) VALUES (@question, @option_a, @option_c, @option_b, @choice_ans, @option_d)" SelectCommand="SELECT [question_id], [question], [option_a], [option_c], [option_b], [choice_ans], [option_d] FROM [question_table] WHERE ([company_id] = @company_id)" UpdateCommand="UPDATE [question_table] SET [question] = @question, [option_a] = @option_a, [option_c] = @option_c, [option_b] = @option_b, [choice_ans] = @choice_ans, [option_d] = @option_d WHERE [question_id] = @question_id">
                    <DeleteParameters>
                        <asp:Parameter Name="question_id" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="question" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_a" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_c" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_b" Type="String"></asp:Parameter>
                        <asp:Parameter Name="choice_ans" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_d" Type="String"></asp:Parameter>
                       
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter SessionField="company_id" DefaultValue="1" Name="company_id" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="question" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_a" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_c" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_b" Type="String"></asp:Parameter>
                        <asp:Parameter Name="choice_ans" Type="String"></asp:Parameter>
                        <asp:Parameter Name="option_d" Type="String"></asp:Parameter>
                        
                        <asp:Parameter Name="question_id" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>



            </form>
        </div>

    </div>
</body>
</html>
