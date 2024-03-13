using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LoginASP.NET.Models;
using LoginASP.NET.App_Start.Services;
using System.Threading.Tasks;

namespace LoginASP.NET.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(string username, string password)
        {
            try
            {
                var tokenViewModel = await _userService.LoginAsync(username, password);

                // Redirige a la nueva vista con el modelo TokenViewModel
                return View("Login", tokenViewModel);
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return View("Index");
            }
        }
    }
}