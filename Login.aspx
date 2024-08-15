<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('assets/wp4312264-website-wallpapers.jpg');
            background-size: cover;
            background-position: center;
        }
        .login-container {
            width: 300px;
            margin: 100px auto;
            background-color:black;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            color: white;
        }
        label {
            display: block;
            margin-bottom: 5px;
            color: white;
        }
        input[type="text"],
        input[type="password"] {
            width: calc(100% - 12px);
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        input[type="submit"] {
            width: 100%;
            background-color: #007bff;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 100px;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: #ff0000;
            margin-top: 10px;
            text-align: center;
        }
        h1{
            color:HighlightText
        }
    </style>
</head>
<body>
  <center><h1>Welcome to Sai Venkata Pg For Gents</h1></center>  
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <div>
    
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                </div>
           
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" AutoComplete="off"></asp:TextBox>
               </div>
           
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click1" CssClass="btn btn-primary" />
            </div>
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>

</html>
