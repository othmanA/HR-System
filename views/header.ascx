<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="HR_SYSTEM.views.header" %>


<link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../assets/css/ui-lightness/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
<div class="container">
<br />
<div class="navbar">
  <div class="navbar-inner">
    <a class="brand" href="Default.aspx">Human Resources</a>
    <ul class="nav">
      
        
        <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-user"></i> Employees <b class="caret"></b></a>
                  <ul class="dropdown-menu">
                    <li><a href="Employees.aspx"><i class="icon-eye-open"></i> Employees</a></li>
                    <li><a href="EmployeeCreate.aspx"><i class="icon-plus"></i> Create a New Employee</a></li>
                  </ul>
         </li>
         <% if(admin) { %>
         <li><a href="positions.aspx"><i class="icon-certificate"></i> Positions</a></li>
         <li><a href="departments.aspx"><i class="icon-tasks"></i> Departments</a></li>
         <% } %>
         

         


    </ul>

    <p class="navbar-text pull-right">
              Logged in as <asp:Label ID="UserFullNameLabel" runat="server" Text="Label"></asp:Label><a href="logout.aspx" class="navbar-link">(Logout)</a>
    </p>
  </div>
</div>

    <asp:Panel ID="AlertErrorPanel" runat="server" ClientIDMode="Static">
    <div class="alert alert-danger"> <h4>Error:</h4>
        <asp:Label ID="AlertErrorLabel" runat="server" Text="Label"></asp:Label>
    </div>
    </asp:Panel>


        <asp:Panel ID="AlertSuccessPanel" runat="server" ClientIDMode="Static">
    <div class="alert alert-success"> 
        <asp:Label ID="AlertSuccessLabel" runat="server" Text="Label"></asp:Label>
    </div>
    </asp:Panel>



</div>


<script src="../assets/js/jquery.js" type="text/javascript"></script>
<script src="../assets/js/bootstrap.js" type="text/javascript"></script>
<script src="../assets/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>

    



    



    



    
