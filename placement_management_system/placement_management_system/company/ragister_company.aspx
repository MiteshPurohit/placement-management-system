<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ragister_company.aspx.cs" Inherits="placement_management_system.company.ragister_company" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!--<link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />-->
        <link type="text/css" rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <script type="text/javascript" src="../materialize/jquery-2.1.1.min.js"></script>
        <script type="text/javascript" src="../materialize/js/materialize.min.js"></script>
        <title></title>
    </head>
<body>
     <nav style="position:fixed; z-index:1000;" class="red lighten-1">
        <div class="nav-wrapper row">

            <span style="margin-left:3%; font-size:2em; float:left;" >Placement Cell</span>
            

            <ul id="nav" style="float:right; margin-right:3%;">
                 <li><a href="../student/student_login.aspx">Student</a></li>
        <li><a href="company_login.aspx">Company</a></li>
        <li><a href="../admin/admin_login.aspx">Admin</a></li>
            </ul>
        </div>

    </nav>
    <div style="position:absolute; width:100%; padding: 10%;">
        <h3 class="center">Company Ragistration</h3>
        <div class="row">
            <div class="col s12">
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
                <div id="after_reg" runat="server" visible="false">
                     <h5>Your login Information:</h5>
                    <table class="bordered">
                  
                    <tr>
                        <td>Company ID: </td>
                        <td><b><asp:Label ID="company_id" runat="server" Text=""></asp:Label></b></td>
                    </tr>
                    <tr>
                        <td>Password: </td>
                        <td><b><asp:Label ID="company_password" runat="server" Text=""></asp:Label></b></td>
                    </tr>
                    
                    </table>
                    <div style="margin-top:1%;">These login information have been sent to your email & You can change every details after logged in into your account</div>
                     <div style="margin-top:1%;"><a href="company_login.aspx" class="waves-effect waves-light btn">Click here to login</a></div>
                       
                </div>
            <form runat="server" id="reg_form">
                <div id="pass_verification" runat="server">
                 <div class="row">
                    <div class="input-field col s12">
                        <input type="password" runat="server" id="apass" name="apass" class="validate" />
                        <label for="apass">Enter Admin Password</label>
                    </div>
                         </div>
                         <div class="row">
                     <div class="input-field col s12">
                    <asp:button runat="server" ID="go" class="btn waves-effect waves-light" text="go" OnClick="go_btn_click"/>

                     </div>
             </div>

                </div>

                <div id="form_after_pass_verification" runat="server">
                    <div id="hide_key" runat="server"></div>
                     <div class="row">
                    <div class="input-field col s12">
                        <input type="text" runat="server" id="cname" name="cname" class="validate" />
                        <label for="cname">Company Name</label>
                    </div>
                         </div>
                     <div class="row">
                        <div class="input-field col s12">
                            <textarea id="description" name="description"  class="materialize-textarea" runat="server"></textarea>
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
                            <textarea id="other_details" name="other_details"  class="materialize-textarea" runat="server"></textarea>
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
    <select name="branches" id="branches" runat="server" multiple>
      <option value="" disabled selected>Select required branches</option>
                                <option value="CE">Computer Engineering</option>
                                <option value="CH">Chemical Engineering</option>
                                <option value="EC">Electronics & Communication</option>
                                <option value="MH">Mechenical Engineering</option>
                                <option value="CL">Civil Engineering</option>
                                <option value="IT">Information Technology</option>
                                <option value="IC">Instrument & Control</option>
    </select>
    <label for="branches">Required Branches</label>
  </div>
                     <script>
                            $(document).ready(function () {
                                $('select').material_select();
                            });
                        </script>

</div>

                <div class="row">
                    <div class="input-field col s12">
                        <input type="password" runat="server" name="password" id="password" class="validate" />
                        <label for="password">Password</label>
                    </div>
                         </div>

               
                
                <div class="row">
                    <div class="input-field col s12">
                        <input type="password" runat="server" name="cpassword" id="cpassword" class="validate" />
                        <label for="cpassword">Conform Password</label>
                    </div>
                         </div>

               
                <div class="row">
                     <div class="input-field col s12">
                    <asp:button runat="server" ID="reg_btn" class="btn waves-effect waves-light" text="Ragister" OnClick="reg_btn_Click"/>

                     </div>
             </div>
                    </div>
            </form>
                </div>
        </div>
    </div>
</body>
</html>
