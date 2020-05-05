﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dezi_clean._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

        <!-- CONTENT -->
    <h1 class="recent-post-title1">Recent Posts</h1>
            <asp:Repeater runat="server" ID="myCustomRepeater">
        <ItemTemplate>
                    <div class="row">
        <div class="content clearfix">
            <div class="main-content">
                

                <div class="post">
                    <img src="<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>" alt="" class="post-image" />
                    <div class="post-preview">
                        <h2><%# DataBinder.Eval(Container.DataItem, "Title") %></h2>
                        <i class="fa fa-user" style="color:black"><%# DataBinder.Eval(Container.DataItem, "Name") %> <%# DataBinder.Eval(Container.DataItem, "Lastname") %></i>
                        &nbsp;
                        <i class="fa fa-calendar" style="font-size:unset"><%# DataBinder.Eval(Container.DataItem, "Date") %></i>
                        <p class="preview-text"><%# DataBinder.Eval(Container.DataItem, "Problemdescription") %></p>
                    </div>
                </div>
            </div>
        </div>
                </div>

        </ItemTemplate>

    </asp:Repeater>

        <%--  <div class="siderbar"></div>--%>


    <!-- CONTENTEND -->
</asp:Content>

