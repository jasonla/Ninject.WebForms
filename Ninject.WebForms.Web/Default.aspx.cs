using Ninject.WebForms.Services.Interfaces;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ninject.WebForms.Web
{
    public partial class _Default : Page
    {
        private readonly IFirstService _firstService;
        private readonly ISecondService _secondService;
        private readonly IThirdService _thirdService;
        private readonly ISingletonObject _singleton;

        public _Default(IFirstService firstService, ISecondService secondService, IThirdService thirdService, ISingletonObject singleton)
        {
            _firstService = firstService;
            _secondService = secondService;
            _thirdService = thirdService;
            _singleton = singleton;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var blogPosts = await _firstService.GetBlogPosts();

                ddl_BlogPosts.DataSource = blogPosts;
                ddl_BlogPosts.DataValueField = "Id";
                ddl_BlogPosts.DataTextField = "Title";
                ddl_BlogPosts.DataBind();
            }

            var todoItem = await _secondService.GetToDoItem();
            ToDoItem_Title.Text = todoItem.Title;

            ScopedObjectIdInFirstService.Text = _firstService.GetDependencyGuid().ToString();
            ScopedObjectIdInSecondService.Text = _secondService.GetDependencyGuid().ToString();

            firstServiceId.Text = _firstService.Id.ToString();
            secondServiceId.Text = _secondService.Id.ToString();

            thirdServiceId.Text = _thirdService.Id.ToString();
            thirdServiceGetFirstServiceId.Text = _thirdService.GetFirstServiceGuid().ToString();
            thirdServiceGetSecondServiceId.Text = _thirdService.GetSecondServiceGuid().ToString();

            thirdServiceFirstServiceDependencyGuid.Text = _thirdService.FirstService.GetDependencyGuid().ToString();
            thirdServiceSecondServiceDependencyGuid.Text = _thirdService.SecondService.GetDependencyGuid().ToString();

            singletonObjectId.Text = _singleton.Id.ToString();
        }

        protected void OnBlogPostSelectedItemChange(object sender, EventArgs e)
        {
            var dropdown = sender as DropDownList;
            selectedBlogPostText.Text = $"Value: {dropdown?.SelectedItem.Value}, Text: {dropdown?.SelectedItem.Text}";
        }
    }
}