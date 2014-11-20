using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using UrbanProjectNameGenerator.Service;

namespace UrbanProjectNameGenerator.Startup
{
    public class Bootstrapper:DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            var configuration = new HostConfiguration() {UrlReservations = {CreateAutomatically = true}};

            container.Register(configuration);
            container.Register<IUrbanDictionaryThesaurusService>(new UrbanDictionaryThesaurusService());

            base.ApplicationStartup(container, pipelines);
        }
    }
}
