using FifaShop.DataContext;
using FifaShop.MyRepository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifaShop.App_Start
{
    public class MyDependencyResolver : IDependencyResolver
    {
       private IKernel KK = new StandardKernel();

       public MyDependencyResolver(IKernel KerParameter) 
        {
            KK = KerParameter;
            AddBinding();
        }

        private void AddBinding()
        {
            EmailSetting em_set = new EmailSetting
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            KK.Bind<IRepository>().To<RepositoryForProduct>();
            KK.Bind<IOrderToProduct>().To<OrderProccessorEmail>().WithConstructorArgument("Em",em_set);
        }
        public object GetService(Type serviceType)
        {
            return KK.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return KK.GetAll(serviceType);
        }
    }
}