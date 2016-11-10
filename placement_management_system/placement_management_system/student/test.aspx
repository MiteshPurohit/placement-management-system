<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="placement_management_system.student.test" %>

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
        <li class="bold active"><a href="select_company_for_test.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Written test</a></li>
        <li class="bold"><a href="student_add_details.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View & edit details</a></li>
        <li class="bold"><a href="view_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">View companies</a></li>
        <li class="bold"><a href="select_company.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Select intrested companies</a></li>
        <li class="bold"><a href="#" style="padding-left: 48px;" class="waves-effect waves-teal">View test result</a></li>
        <li class="bold"><a href="student_logout.aspx" style="padding-left: 48px;" class="waves-effect waves-teal">Logout</a></li>
    </ul>


    <form runat="server" id="question_form">


        <div style="margin-top: 6%; width: 100%; padding: 0px; position: absolute; padding-left: 24%;">

            <div class="grey lighten-4" style="width: 100%; padding-top: 4px; padding-bottom: 6px;">
                <h4 class="center-align">Written Test</h4>
            </div>


            <div runat="server" id="start_test_div" style="padding: 6%;">
                <asp:Button ID="start_test_btn" runat="server" Text="Start test" class="waves-effect waves-light btn" OnClick="start_test_Click" />
            </div>

            <div runat="server" id="test_given_div" style="padding: 6%;">
                <h3>You have done with this test :)</h3>
                <h4>Your score is: <span id="score" runat="server"></span></h4>
            </div>
            <div runat="server" id="questions_div" style="padding-top: 9%; padding-left: 3%;">
                <div style="float: right; right: 1%; top: 15%; position: fixed; font-size: 3em;" id="timer">
                </div>
                <script>
                    function createCookie(name, value, days) {
                        if (days) {
                            var date = new Date();
                            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                            var expires = "; expires=" + date.toGMTString();
                        }
                        else var expires = "";
                        document.cookie = name + "=" + value + expires + "; path=/";
                    }

                    function readCookie(name) {
                        var nameEQ = name + "=";
                        var ca = document.cookie.split(';');
                        for (var i = 0; i < ca.length; i++) {
                            var c = ca[i];
                            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
                        }
                        return null;
                    }

                </script>
                <div runat="server" id="_script">
                </div>

                <asp:GridView ID="questions" runat="server" AutoGenerateColumns="False" DataSourceID="question_db" CssClass="bordered highlight">
                    <Columns>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Question" SortExpression="question">

                            <ItemTemplate>
                                <div style="max-width: 300px; min-width: 90px; word-wrap: break-word;">
                                    <%# Eval("question") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option A" SortExpression="option_a">

                            <ItemTemplate>
                                <div style="max-width: 200px; min-width: 90px; word-wrap: break-word;">
                                    <input type="radio" id="<%# Eval("question_id") %>a" style="margin-top: 1%;" name="snk<%# Eval("question_id") %>" value="1" />
                                    <label for="<%# Eval("question_id") %>a"></label>
                                    <%# Eval("option_a") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option B" SortExpression="option_b">

                            <ItemTemplate>
                                <div style="max-width: 200px; min-width: 90px; word-wrap: break-word;">
                                    <input type="radio" id="<%# Eval("question_id") %>b" style="margin-top: 1%;" name="snk<%# Eval("question_id") %>" value="2" />
                                    <label for="<%# Eval("question_id") %>b"></label>
                                    <%# Eval("option_b") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option C" SortExpression="option_c">

                            <ItemTemplate>
                                <div style="max-width: 200px; min-width: 90px; word-wrap: break-word;">
                                    <input type="radio" id="<%# Eval("question_id") %>c" style="margin-top: 1%;" name="snk<%# Eval("question_id") %>" value="3" />
                                    <label for="<%# Eval("question_id") %>c"></label>
                                    <%# Eval("option_c") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Option D" SortExpression="option_d">

                            <ItemTemplate>
                                <div style="max-width: 200px; min-width: 90px; word-wrap: break-word;">
                                    <input type="radio" id="<%# Eval("question_id") %>d" style="margin-top: 1%;" name="snk<%# Eval("question_id") %>" value="4" />

                                    <label for="<%# Eval("question_id") %>d"></label>
                                    <%# Eval("option_d") %>
                                </div>
                                <input type="radio" id="<%# Eval("question_id") %>e" style="display: none;" name="snk<%# Eval("question_id") %>" value="0" checked="checked" />


                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="weight" HeaderText="Weight" SortExpression="weight"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <input runat="server" id="company_id" type="hidden" name="id" />
                <asp:Button ID="submit_btn" runat="server" Text="submit" class="waves-effect waves-light btn" Style="margin-top: 3%; top: 0px; left: 0px;" PostBackUrl="write_question.aspx" />
                <asp:SqlDataSource runat="server" ID="question_db" ConnectionString='<%$ ConnectionStrings:pmsdbConnectionString %>' SelectCommand="SELECT [question], [option_a], [option_b], [option_c], [option_d], [weight], [question_id] FROM [question_table] WHERE ([company_id] = @company_id)">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="company_id" DefaultValue="1" Name="company_id" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
        </div>
    </form>
</body>
</html>