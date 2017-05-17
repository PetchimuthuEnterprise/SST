using Microsoft.Extensions.DependencyInjection;
using WebApplication.Core.IService;
using WebApplication.Core.IRepository;
using WebApplication.Service;
using WebApplication.Repository;

namespace WebApplication.Utilities.BootStrappers
{
    public static class DependencyResolver
    {
        public static void RegisterInterfaces(IServiceCollection services)
        {
            #region Register Service
            services.AddSingleton<IUserService, UserService>();
            #endregion

            #region Register Repository
            services.AddSingleton<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
