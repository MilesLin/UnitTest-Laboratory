using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Repositories;
using Lab_MVC.Services;
using RestSharp;
using System;

using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace Lab_MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            //// TODO: Register your type's mappings here.
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve);


            // 預設，每次都會 New
            // 後面註冊的會取代前面註冊的
            //container.RegisterType<IPaymentTransactionRepository, PaymentTransactionRepository>(new TransientLifetimeManager());
            container.RegisterType<IPaymentTransactionRepository, PaymentTransactionRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IPayPalService, PayPalService>(new PerResolveLifetimeManager());
            container.RegisterType<IInvoiceService, InvoiceService>(new PerResolveLifetimeManager());
            //container.RegisterType<IRestClient, RestClient>(new PerResolveLifetimeManager());
            container.RegisterType<IRestClient, RestClient>(new PerResolveLifetimeManager(), new InjectionConstructor());
            // 同一個生命週期不會重新 new
            //container.RegisterType<IPaymentTransactionRepository, PaymentTransactionRepository>(new PerResolveLifetimeManager());

            //// Singleton
            //container.RegisterType<IPaymentTransactionRepository, PaymentTransactionRepository>(new ContainerControlledLifetimeManager());
        }
    }
}