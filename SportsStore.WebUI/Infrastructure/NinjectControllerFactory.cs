using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;


namespace SportsStore.WebUI.Infrastructure
{
    //реализация пользовательской фабрики контроллеров
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //получение контроллера из контейнера, используя его тип
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings() 
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}

/*
 * 
 * 	<connectionStrings>
		<add name="EFDbContext" connectionString="data source=(localdb)\MSSQLLocalDB;initial catalog=SportsStore;integrated security=True" providerName="System.Data.SqlClient"/>
	</connectionStrings>
*/