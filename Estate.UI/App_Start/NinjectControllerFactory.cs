using Estate.Business;
using Estate.Business.Contracts;
using Estate.Data;
using Estate.Data.Contacts;
using Estate.Data.DataRepositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Estate.UI.App_Start
{
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
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<ICategoryEngine>().To<CategoryEngine>();
            ninjectKernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            ninjectKernel.Bind<IPropertyEngine>().To<PropertyEngine>();
            ninjectKernel.Bind<IPropertyRepository>().To<PropertyRepository>();
            ninjectKernel.Bind<IUserEngine>().To<UserEngine>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IPhotoEngine>().To<PhotoEngine>();
            ninjectKernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            ninjectKernel.Bind<IGeoLocationEngine>().To<GeoLocationEngine>();
            ninjectKernel.Bind<IGeoLocationRepository>().To<GeoLocationRepository>();








            ninjectKernel.Bind<DbContext>().To<EstateDbContext>().InSingletonScope();


            // add your bindings here as required    
        }

    }
}