using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;
using WebServiceHost.Config;

namespace WebServiceHost
{
    class Startup
    {
        void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }
}
