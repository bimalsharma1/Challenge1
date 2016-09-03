using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Dominos.OLO.Vouchers.Controllers;
/*
 * Unity is used for dependency injection
 * */
namespace Dominos.OLO.Vouchers
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IVoucherRepository, VoucherRepository>(new InjectionConstructor(new SearchPathProvider()));
            container.Resolve<VoucherController>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}