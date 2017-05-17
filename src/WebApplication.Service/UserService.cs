using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core.IService;

namespace WebApplication.Service
{
    public class UserService : IUserService
    {
        public string Welcome()
        {
            return "Hai";
        }

    }
}
