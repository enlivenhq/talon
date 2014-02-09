<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Talon.Web.Login" Async="true" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section class="v-center login">
        <div class="alert alert-danger" runat="server" ID="ErrorMessageDiv" Visible="False">
            Sorry! Looks like your username or password were incorrect.
        </div>
        <div>
            <div class="container">

                <div class="form-signin" role="form">
                    <div class="textCenter marginBottomM">
                        <img src="/flat-icons/logo.svg" alt="">  
                    </div>
                    <asp:Label runat="server" ID="UsernameLabel" AssociatedControlID="UsernameTextBox">Username</asp:Label>
                    <asp:TextBox runat="server" ID="UsernameTextBox" CssClass="form-control"></asp:TextBox>
                    <asp:Label runat="server" ID="PasswordLabel" AssociatedControlID="PasswordTextBox">Password</asp:Label>
                    <asp:TextBox runat="server" ID="PasswordTextBox" CssClass="form-control" TextMode="Password"></asp:TextBox>

                    <asp:Button runat="server" OnClick="AttemptLogin" Text="Sign in" CssClass="btn btn-lg btn-primary btn-block" />
                </div>

            </div>
        </div>
    </section>

</asp:Content>