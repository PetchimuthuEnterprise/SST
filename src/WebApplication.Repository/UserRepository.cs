using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core.IRepository;

namespace WebApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        public string Welcome()
        {
            return "Hai";
        }

    }
}
