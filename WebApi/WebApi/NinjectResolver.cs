using BussinesLayer;
using DataLayer;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebApi
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            // Ovde se dodaju binding klase između interfejsa i njegovih implementatora
            kernel.Bind<ICityRepository>().To<CityRepository>().InSingletonScope();
            kernel.Bind<ICityBusiness>().To<CityBusiness>().InSingletonScope();
            kernel.Bind<ITypeRepository>().To<TypeRepository>().InSingletonScope();
            kernel.Bind<ITypeBusiness>().To<TypeBusiness>().InSingletonScope();
            kernel.Bind<IPersonRepository>().To<PersonRepository>().InSingletonScope();
            kernel.Bind<IPersonBusiness>().To<PersonBusiness>().InSingletonScope();
            kernel.Bind<IApartmentRepository>().To<ApartmentRepository>().InSingletonScope();
            kernel.Bind<IApartmentBusiness>().To<ApartmentBusiness>().InSingletonScope();
            kernel.Bind<IRecordRepository>().To<RecordRepository>().InSingletonScope();
            kernel.Bind<IRecordBusiness>().To<RecordBusiness>().InSingletonScope();
            return kernel;
        }
    }
}