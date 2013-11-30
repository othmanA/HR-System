<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HR_SYSTEM.views.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../assets/js/jquery.js"></script>
    <script src="../assets/js/bootstrap.js"></script>
    <style type="text/css">
      body {
        padding-top: 40px;
        padding-bottom: 40px;
        background-color: #f5f5f5;
      }

      .form1 {
        max-width: 300px;
        padding: 19px 29px 29px;
        margin: 0 auto 20px;
        background-color: #fff;
        border: 1px solid #e5e5e5;
        -webkit-border-radius: 5px;
           -moz-border-radius: 5px;
                border-radius: 5px;
        -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
           -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
                box-shadow: 0 1px 2px rgba(0,0,0,.05);
      }
      .form1 .form-signin-heading,
      .form1 .checkbox {
        margin-bottom: 10px;
        text-align: center;
      }
      .form1 input[type="text"],
      .form1 input[type="password"] {
        font-size: 16px;
        height: auto;
        margin-bottom: 15px;
        padding: 7px 9px;
      }

    </style>

  </head>
<body>
<div class="container">
    <center><asp:Label ID="Label1" runat="server" 
            style="font-weight: 700;text-align:center; font-size: 36px; color: #0033CC"
            Text="Human Resources Software Program"></asp:Label></center>
            <hr />


            <asp:Panel ID="Panel1" runat="server">
            <div class="alert alert-danger">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
    </asp:Panel>
    <br />


    
    <br /><br /><br />
    <form id="form1" runat="server" class="form1">

    <div class="container">
        <h4>Sign in</h4>
        <hr />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox><br />
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="password"></asp:TextBox><Br /> <hr />
        <asp:Button ID="Button1" runat="server" Text="Login" 
            CssClass="btn btn-primary" onclick="Button1_Click" />
    </div> <!-- /container -->
      </form>
  </body>

    

</html>
