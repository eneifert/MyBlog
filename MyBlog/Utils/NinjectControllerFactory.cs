using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using MyBlog.Models;
using Ninject.Modules;

namespace MyBlog.Utils
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel = new StandardKernel(new MyDependencies());

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }

        private class MyDependencies : NinjectModule
        {
            public override void Load()
            {
                Bind<IBlogDataContext>().To<EricBlogDataContext>();
            }
        }
    }
}