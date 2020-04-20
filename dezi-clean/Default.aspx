<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dezi_clean._Default" %>

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
                        <i class="fa fa-calendar"><%# DataBinder.Eval(Container.DataItem, "Date") %></i>
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



    <style>
        .content {
            width: 90%;
            margin: 30px auto 30px;
            border: 1px solid red;
        }

        .recent-post-title1 {
            margin-left:40px;
        }

            .content .main-content {
                width: 100%;
                float: left;
                border: 1px solid blue;
            }

            .content .main-content .post {
                width: 95%;
                height: 270px;
                margin: 10px auto;
                border-radius: 5px;
                background:white;

            }

            .content .main-content .post .post-image {
                width: 40%;
                height:100%;
                float:left;
            }

            .content .main-content .post .post-preview {
                padding: 10px;
                width: 60%;
                float: right;
            }

            .content .main-content .recent-post-title {
                margin: 20px;

            }

            .content .siderbar {
                width: 30%;
                float: left;
                border: 1px dashed green;
                height: 300px;
            }

        .clearfix:after {
            content: '';
            display: block;
            clear: both;
        }
    </style>

</asp:Content>

