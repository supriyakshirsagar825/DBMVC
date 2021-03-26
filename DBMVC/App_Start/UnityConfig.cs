using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using CLModelLayer;
using CLDataBaseLayer;
using CLDataBaseLayer.DBOperations;

namespace DBMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IEmployeeExperience, EmployeeExperience>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}