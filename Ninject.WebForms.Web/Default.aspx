<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ninject.WebForms.Web._Default" Async="true" %>

<%@ Register Src="ViewSwitcher.ascx" TagName="Switcher" TagPrefix="TSwitcher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <TSwitcher:Switcher ID="Thing" runat="server"></TSwitcher:Switcher><small>This switcher is a UserControl (ascx) with DI</small></div>
    <div class="row">
        <div class="col-md-12">
            <div class="page-header">
                <h3>Testing DI in Web Forms with <a href="https://github.com/ninject/Ninject" target="_blank">Ninject</a></h3>
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
                                Guid of <span class="blogService">IBlogService</span>:<br />
                                <asp:Label runat="server" ID="BlogServiceId" CssClass="blogService"></asp:Label>
                                <ul>
                                    <li>
                                        <p>
                                            Guid of <span class="scopedObject">IScopedObject</span> used in <span class="blogService">IBlogService</span>:<br />
                                            <asp:Label runat="server" ID="ScopedBlogService" CssClass="scopedObject"></asp:Label>
                                        </p>
                                    </li>
                                </ul>
                            </p>
                        </li>
                        <li>
                            <p>
                                Guid of <span class="todoItemsService">ITodoItemsService</span><br />

                                <asp:Label runat="server" ID="TodoItemsServiceId" CssClass="todoItemsService"></asp:Label>
                                <ul>
                                    <li>
                                        <p>
                                            Guid of <span class="scopedObject">IScopedObject</span> used in <span class="todoItemsService">ITodoItemsService</span>:<br />
                                            <asp:Label runat="server" ID="ScopedToDoItemsService" CssClass="scopedObject"></asp:Label>
                                        </p>
                                    </li>
                                </ul>

                            </p>
                        </li>
                        <li>
                            <p>
                                Guid of <span class="combinedService">ICombinedService</span><br />
                                <asp:Label runat="server" ID="CombinedServiceId" CssClass="thirdService"></asp:Label>
                            </p>
                            <ul>
                                <li>Guid of <span class="blogService">IBlogService</span> injected into <span class="combinedService">ICombinedService</span><br />
                                    <asp:Label runat="server" ID="CombinedServiceGetBlogServiceGuid" CssClass="blogService"></asp:Label>
                                    <ul>
                                        <li>
                                            <p>
                                                GuGuid of <span class="scopedObject">IScopedObject</span> used in <span class="blogService">IBlogService</span> of <span class="combinedService">ICombinedService</span>:<br />
                                                <asp:Label runat="server" ID="CombinedServiceBlogServiceGetDependencyGuid" CssClass="scopedObject"></asp:Label>
                                            </p>
                                        </li>
                                    </ul>
                                </li>
                                <li>Guid of <span class="todoItemsService">ITodoItemsService</span> injected into <span class="combinedService">ICombinedService</span><br />
                                    <asp:Label runat="server" ID="CombinedServiceGetTodoItemsServiceGuid" CssClass="todoItemsService"></asp:Label>
                                    <ul>
                                        <li>
                                            <p>
                                                Guid of <span class="scopedObject">IScopedObject</span> used in <span class="todoItemsService">ITodoItemsService</span> of <span class="combinedService">ICombinedService</span>:<br />
                                                <asp:Label runat="server" ID="CombinedServiceTodoItemsServiceGetDependencyGuid" CssClass="scopedObject"></asp:Label>
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
                        Guid of <span class="blogService">ISingletonObject</span><br />
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
                            <p>Dropdown list populated from <a href="https://my-json-server.typicode.com/typicode/demo/posts" target="_blank">https://my-json-server.typicode.com/typicode/demo/posts</a> via async call.</p>

                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddl_BlogPosts" ClientIDMode="Static" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="OnBlogPostSelectedItemChange" />
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="selectedBlogPostText"></asp:Label>
                            </div>

                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p>Todo title from <a href="https://jsonplaceholder.typicode.com/todos/1" target="_blank">https://jsonplaceholder.typicode.com/todos/1</a></p>
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
