[assembly: WebActivator.PostApplicationStartMethod(typeof(PackageDelivery.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace PackageDelivery.GUI.App_Start
{
    using PackageDelivery.Application.Contracts.Interfaces.Core;
    using PackageDelivery.Application.Contracts.Interfaces.Parameters;
    using PackageDelivery.Application.Implementation.Implementation.Core;
    using PackageDelivery.Application.Implementation.Implementation.Parameters;
    using PackageDelivery.Repository.Contracts.Interfaces.Core;
    using PackageDelivery.Repository.Contracts.Interfaces.Parameters;
    using PackageDelivery.Repository.Implementation.Core;
    using PackageDelivery.Repository.Implementation.Parameters;
    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System;
    using System.Web.Mvc;
    using System.Linq;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.ConstructorResolutionBehavior = new LeastParametersConstructorBehavior();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IDeliveryRepository, DeliveryImpRepository>(Lifestyle.Scoped);
            container.Register<IDeliveryStatusRepository, DeliveryStatusImpRepository>(Lifestyle.Scoped);
            container.Register<IPackageHistoryRepository, PackageHistoryImpRepository>(Lifestyle.Scoped);
            container.Register<IAddressRepository, AddressImpRepository>(Lifestyle.Scoped);
            container.Register<ICityRepository, CityImpRepository>(Lifestyle.Scoped);
            container.Register<IDepartmentRepository, DepartmentImpRepository>(Lifestyle.Scoped);
            container.Register<IDocumentTypeRepository, DocumentTypeImpRepository>(Lifestyle.Scoped);
            container.Register<IOfficeRepository, OfficeImpRepository>(Lifestyle.Scoped);
            container.Register<IPackageRepository, PackageImpRepository>(Lifestyle.Scoped);
            container.Register<IPersonRepository, PersonImpRepository>(Lifestyle.Scoped); 
            container.Register<ITransportTypeRepository, TransportTypeImpRepository>(Lifestyle.Scoped);
            container.Register<IVehicleRepository, VehicleImpRepository>(Lifestyle.Scoped);
            container.Register<IWarehouseRepository, WarehouseImpRepository>(Lifestyle.Scoped);

            container.Register<IDeliveryApplication, DeliveryImpApplication>(Lifestyle.Scoped);
            container.Register<IDeliveryStatusApplication, DeliveryStatusImpApplication>(Lifestyle.Scoped);
            container.Register<IPackageHistoryApplication, PackageHistoryImpApplication>(Lifestyle.Scoped);
            container.Register<IAddressApplication, AddressImpApplication>(Lifestyle.Scoped);
            container.Register<ICityApplication, CityImpApplication>(Lifestyle.Scoped);
            container.Register<IDepartmentApplication, DepartmentImpApplication>(Lifestyle.Scoped);
            container.Register<IDocumentTypeApplication, DocumentTypeImpApplication>(Lifestyle.Scoped);
            container.Register<IOfficeApplication, OfficeImpApplication>(Lifestyle.Scoped);
            container.Register<IPackageApplication, PackageImpApplication>(Lifestyle.Scoped);
            container.Register<IPersonApplication, PersonImpApplication>(Lifestyle.Scoped);
            container.Register<ITransportTypeApplication, TransportTypeImpApplication>(Lifestyle.Scoped);
            container.Register<IVehicleApplication, VehicleImpApplication>(Lifestyle.Scoped);
            container.Register<IWarehouseApplication, WarehouseImpApplication>(Lifestyle.Scoped);
        }



    }



    public class LeastParametersConstructorBehavior : IConstructorResolutionBehavior
    {

        public ConstructorInfo TryGetConstructor(Type implementationType, out string errorMessage)
        {
            errorMessage = null;
            return (
            from ctor in implementationType.GetConstructors()
            orderby ctor.GetParameters().Length ascending
            select ctor).First();
        }
    }
}