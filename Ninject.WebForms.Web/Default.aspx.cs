using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject.WebForms.Services;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Web
{
    public partial class _Default : Page
    {
        private readonly IFirstService _firstService;
        private readonly ISecondService _secondService;

        public _Default(IFirstService firstService, ISecondService secondService)
        {
            _firstService = firstService;
            _secondService = secondService;
        }


        protected async void Page_Load(object sender, EventArgs e)
        {

            ScopedObjectIdInFirstService.Text = _firstService.SetUsername();
            ScopedObjectIdInSecondService.Text = _secondService.SetFirstName();

            firstServiceId.Text = _firstService.Id.ToString();
            secondServiceId.Text = _secondService.Id.ToString();

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