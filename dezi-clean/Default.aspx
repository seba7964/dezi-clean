<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dezi_clean._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <style>
            body {
                background-image: url(../Images/linear-gradient.png);
                font-family: Arial, Helvetica, sans-serif;
            }

            .buttonLogin {
                background-color: #4CAF50;
                color: white;
                padding: 14px 20px;
                margin: 8px 0;
                border: none;
                cursor: pointer;
                width: 100%;
            }

            .buttonRedirect {
                background-color: #313dc4;
                color: white;
                padding: 14px 20px;
                margin: 8px 0;
                border: none;
                cursor: pointer;
                width: 100%;
            }

            .buttonRedirect {
                opacity: 0.8;
            }
            .buttonLogin:hover {
                opacity: 0.8;
            }

            .inputs {
                  width: 100%;
                    padding: 12px 20px;
                    margin: 8px 0;
                    display: inline-block;
                    border: 1px solid #ccc;
                        box-sizing: border-box;
            }
        </style>
       
            <div>
            <table style="margin: auto; border: 5px red;">
                <%--Prvi--%>
                <tr>
                    <td>
                        <b><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></b>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" CssClass="inputs" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%--Drugi--%>
                <tr>
                    <td>
                        <b><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" CssClass="inputs" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%--Treci--%>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="buttonLogin" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblErrorMessage" runat="server" Text="Neispravni korisnički podaci, pokušajte ponovno!" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="btnRedirect_Click" CssClass="buttonRedirect" Text="Nastavi kao gost" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>

