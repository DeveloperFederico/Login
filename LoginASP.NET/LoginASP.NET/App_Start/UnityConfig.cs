using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using LoginASP.NET.App_Start.Services;
using System;

namespace LoginASP.NET
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}