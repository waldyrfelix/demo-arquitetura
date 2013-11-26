using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace Demo.Infra.IoC
{
    public class DemoDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public DemoDependencyResolver()
        {
            var ioc = new Demo.Infra.IoC.IoC();
            kernel = ioc.Kernel;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        #endregion
    }
}