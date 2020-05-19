<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="dezi_clean.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>


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

        .buttonDeactivate {
            background-color: #de0d0d;
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


        <h1 class="recent-post-title1">Recent Posts</h1>
            <asp:Repeater runat="server" ID="myCustomRepeater">
        <ItemTemplate>
                    <div class="row">
        <div class="content clearfix">
            <div class="main-content">
                

                <div class="post">
                    <img src="<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>" alt="" class="post-image" />
                    <div style="float:right">
                        <%--<button id="seba" data-id="<%# DataBinder.Eval(Container.DataItem, "id") %>">Login</button>--%>
                        <asp:Button ID="seba1" runat="server" Text="Deaktiviraj" CssClass="buttonDeactivate" OnClick="deactivatePost" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "id")%> />
                       
                    </div>
                    <div class="post-preview">
                        <h2><%# DataBinder.Eval(Container.DataItem, "Title") %></h2>
                        <i class="fa fa-user" style="color:black"><%# DataBinder.Eval(Container.DataItem, "Name") %> <%# DataBinder.Eval(Container.DataItem, "Lastname") %></i>
                        &nbsp;
                        <i class="fa fa-calendar"><%# DataBinder.Eval(Container.DataItem, "Date") %></i>
                        <p class="preview-text"><%# DataBinder.Eval(Container.DataItem, "Problemdescription") %></p>
                    </div>
                    
                </div>
            </div>
        </div>
                </div>

        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
