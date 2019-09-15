using System;
using System.Web.UI;
using Serilog;

namespace Ninject.WebForms.Web
{
    public partial class About : Page
    {
        private readonly ILogger _logger;

        public About(ILogger logger)
        {
            _logger = logger;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Information("Logging from About page using injected logger.");
        }
    }
}