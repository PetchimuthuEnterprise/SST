using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core.IService;

namespace WebApplication.Web.Controllers
{
    public class UserController : Controller
    {
        #region Declaration
        private readonly IUserService _userService;
        #endregion

        #region construction
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        public IActionResult Welcome()
        {
            return View(_userService.Welcome());
        }
    }
}
