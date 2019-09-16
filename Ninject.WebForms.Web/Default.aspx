<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ninject.WebForms.Web._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register src="ViewSwitcher.ascx" tagName="Switcher" tagPrefix="TSwitcher" %>
    <TSwitcher:Switcher ID="Thing" runat="server"></TSwitcher:Switcher>
    <div class="row">
        <div class="col-md-12">
            <div class="page-header">
                <h2>Testing DI in Web Forms with <a href="https://github.com/ninject/Ninject" target="_blank">Ninject</a></h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">InRequestScope</h3>
                </div>
                <div class="panel-body">

                    <ul>
                        <li>
                            <p>
                                Guid of <span style="color: red;">IFirstService</span>:<br />
                                <asp:Label runat="server" ID="firstServiceId" ForeColor="red"></asp:Label>
                                <ul>
                                    <li>
                                        <p>
                                            Guid of <span style="color: gray;">IScopedObject</span> used in <span style="color: red;">IFirstService</span>:<br />
                                            <asp:Label runat="server" ID="ScopedObjectIdInFirstService" ForeColor="gray"></asp:Label>
                                        </p>
                                    </li>
                                </ul>
                            </p>
                        </li>
                        <li>
                            <p>
                                Guid of <span style="color: blue;">ISecondService</span><br />

                                <asp:Label runat="server" ID="secondServiceId" ForeColor="blue"></asp:Label>
                                <ul>
                                    <li>
                                        <p>
                                            Guid of <span style="color: gray;">IScopedObject</span> used in <span style="color: blue;">ISecondService</span>:<br />
                                            <asp:Label runat="server" ID="ScopedObjectIdInSecondService" ForeColor="gray"></asp:Label>
                                        </p>
                                    </li>
                                </ul>

                            </p>
                        </li>
                        <li>
                            <p>
                                Guid of <span style="color: green;">IThirdService</span><br />
                                <asp:Label runat="server" ID="thirdServiceId" ForeColor="green"></asp:Label>
                            </p>
                            <ul>
                                <li>Guid of <span style="color: red;">IFirstService</span> injected into <span style="color: green;">IThirdService</span><br />
                                    <asp:Label runat="server" ID="thirdServiceGetFirstServiceId" ForeColor="red"></asp:Label>
                                    <ul>
                                        <li>
                                            <p>
                                                Guid of IScopedObject used in <span style="color: red;">IFirstService</span> of <span style="color: green;">IThirdService</span>:<br />
                                                <asp:Label runat="server" ID="thirdServiceFirstServiceDependencyGuid" ForeColor="gray"></asp:Label>
                                            </p>
                                        </li>
                                    </ul>
                                </li>
                                <li>Guid of <span style="color: blue;">ISecondService</span> injected into <span style="color: green;">IThirdService</span><br />
                                    <asp:Label runat="server" ID="thirdServiceGetSecondServiceId" ForeColor="blue"></asp:Label>
                                    <ul>
                                        <li>
                                            <p>
                                                Guid of IScopedObject used in <span style="color: blue;">ISecondService</span> of <span style="color: green;">IThirdService</span>:<br />
                                                <asp:Label runat="server" ID="thirdServiceSecondServiceDependencyGuid" ForeColor="gray"></asp:Label>
                                            </p>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>

                    </ul>
                </div>
            </div>

        </div>

        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">InSingletonScope</h3>
                </div>
                <div class="panel-body">
                    <p>
                        Guid of <span style="color: red;">ISingletonObject</span><br />
                        <asp:Label runat="server" ID="singletonObjectId"></asp:Label>
                    </p>
                </div>

            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">HttpClient conditional binding</h3>
                </div>
                <div class="panel-body">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p>Dropdown list populated from <a href="https://my-json-server.typicode.com/typicode/demo/posts">https://my-json-server.typicode.com/typicode/demo/posts</a></p>
                            <asp:DropDownList runat="server" ID="ddl_BlogPosts" />
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p>Todo title from <a href="https://jsonplaceholder.typicode.com/todos/1">https://jsonplaceholder.typicode.com/todos/1</a></p>
                            <p>
                                <asp:Label runat="server" ID="ToDoItem_Title"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
