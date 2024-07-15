<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final.Views.Login" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>   
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />
    <style>
        .custom-input {
            width: 100%;
            height: 40px; 
        }
        .mt-5 { 
            margin-top: 50px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid mt-5">
           <div class="row">
    
           </div>
           <div class="row">
               <div class="col-md-4 offset-md-4 text-center">
                
                   <img src="../Assets/Images/images.png" style="height: 157px; width: 170px;" class="mt-3" />

                 
                   <div class="mt-3 text-left">
                       <label for="UnameTb" class="form-label">User Name</label>
                       <asp:TextBox ID="UnameTb" runat="server" CssClass="form-control custom-input" placeholder="User Name" autocomplete="off"></asp:TextBox>
                   </div>
                       
                   <div class="mt-3 text-left">
                       <label for="passwordTb" class="form-label">Password</label>
                       <asp:TextBox ID="passwordTb" runat="server" CssClass="form-control custom-input" TextMode="Password" placeholder="Password" autocomplete="off"></asp:TextBox>
                   </div>

                   <div class="mt-3 d-grid">
                       <asp:Button Text="Login" runat="server" CssClass="btn-success btn" ID="LoginBtn" Width="269px" OnClick="LoginBtn_Click" />
                   </div>
                   <div class="mt-3 d-grid">
                  
                   </div>
               </div>
           </div>
       </div>
   </form>
</body>
</html>
