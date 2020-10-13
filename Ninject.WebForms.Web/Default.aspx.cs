using Ninject.WebForms.Services.Interfaces;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ninject.WebForms.Web
{
    public partial class _Default : Page
    {
        private readonly IBlogService _blogService;
        private readonly ITodoItemsService _todoItemsService;
        private readonly ICombinedService _combinedService;
        private readonly ISingletonObject _singleton;

        public _Default(IBlogService blogService, ITodoItemsService todoItemsService, ICombinedService combinedService, ISingletonObject singleton)
        {
            _blogService = blogService;
            _todoItemsService = todoItemsService;
            _combinedService = combinedService;
            _singleton = singleton;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var blogPosts = await _blogService.GetBlogPosts();

                ddl_BlogPosts.DataSource = blogPosts;
                ddl_BlogPosts.DataValueField = "Id";
                ddl_BlogPosts.DataTextField = "Title";
                ddl_BlogPosts.DataBind();
            }

            var todoItem = await _todoItemsService.GetToDoItem();
            ToDoItem_Title.Text = todoItem.Title;

            ScopedBlogService.Text = _blogService.GetDependencyGuid().ToString();
            ScopedToDoItemsService.Text = _todoItemsService.GetDependencyGuid().ToString();

            BlogServiceId.Text = _blogService.Id.ToString();
            TodoItemsServiceId.Text = _todoItemsService.Id.ToString();

            CombinedServiceId.Text = _combinedService.Id.ToString();

            CombinedServiceGetBlogServiceGuid.Text = _combinedService.GetBlogServiceGuid().ToString();
            CombinedServiceGetTodoItemsServiceGuid.Text = _combinedService.GetTodoItemsServiceGuid().ToString();

            CombinedServiceBlogServiceGetDependencyGuid.Text = _combinedService.BlogService.GetDependencyGuid().ToString();
            CombinedServiceTodoItemsServiceGetDependencyGuid.Text = _combinedService.TodoItemsService.GetDependencyGuid().ToString();

            singletonObjectId.Text = _singleton.Id.ToString();
        }

        protected void OnBlogPostSelectedItemChange(object sender, EventArgs e)
        {
            var dropdown = sender as DropDownList;
            selectedBlogPostText.Text = $"Value: {dropdown?.SelectedItem.Value}, Text: {dropdown?.SelectedItem.Text}";
        }
    }
}