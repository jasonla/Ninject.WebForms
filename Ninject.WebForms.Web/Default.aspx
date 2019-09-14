<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ninject.WebForms.Web._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <h1>Web Forms DI testing</h1>
        </div>
    </div>

    <div class="row">

        <div class="col-md-4">
            <h2>Singleton</h2>

        </div>

        <div class="col-md-4">
            <h2>InRequestScope</h2>

            <h3>FirstService</h3>
            <p>
                <asp:Label runat="server" ID="firstServiceId"></asp:Label>
            </p>

            <h3>SecondService</h3>
            <p>
                <asp:Label runat="server" ID="secondServiceId"></asp:Label>
            </p>

            <h3>ScopedObject</h3>
            <p>
                This is in request scope. The values should match, but also change on each request.
            </p>
            <p>
                ID of IScopedObject used in FirstService:<br />
                <asp:Label runat="server" ID="ScopedObjectIdInFirstService"></asp:Label>
            </p>
            <p>
                ID of IScopedObject used in SecondService:<br />
                <asp:Label runat="server" ID="ScopedObjectIdInSecondService"></asp:Label>
            </p>
        </div>

        <div class="col-md-4">
            <h2>HttpClient requests and binding</h2>

            <div>
                <p>Dropdown list populated from <a href="https://my-json-server.typicode.com/typicode/demo/posts">https://my-json-server.typicode.com/typicode/demo/posts</a></p>
                <asp:DropDownList runat="server" ID="ddl_BlogPosts" />
            </div>
            <div>
                <p>
                    Todo from <a href="https://jsonplaceholder.typicode.com/todos/1">https://jsonplaceholder.typicode.com/todos/1</a>
                    <asp:Label runat="server" ID="ToDoItem_Title"></asp:Label>
                </p>
            </div>

        </div>
    </div>

</asp:Content>
