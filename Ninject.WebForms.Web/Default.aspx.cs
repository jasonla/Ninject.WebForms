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


            var blogPosts = await _firstService.GetBlogPosts();

            ddl_BlogPosts.Items.Clear();
            foreach (var blogpost in blogPosts)
            {
                ddl_BlogPosts.Items.Add(new ListItem(blogpost.Title, blogpost.Id.ToString()));
            }

            var todoItem = await _secondService.GetToDoItem();
            ToDoItem_Title.Text = todoItem.Title;
        }
    }
}