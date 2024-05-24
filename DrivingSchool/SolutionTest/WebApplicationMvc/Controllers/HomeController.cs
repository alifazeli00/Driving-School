
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            this.mediator=mediator;
            _logger = logger;
        }

        //public IActionResult Index(UserDtoRejester c)
        //{

        //    RejesterUserCommand a = new RejesterUserCommand(c);
        //    var res = mediator.Send(a).Result;

        //    List<Claim> claims = new List<Claim>()
        //    {
        //        new Claim("Test","Test"),
        //        new Claim(ClaimTypes.NameIdentifier,res.Message.ToString()),
        //        new Claim(ClaimTypes.Name,res.Message),
        //    };

        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claimPrincipal = new ClaimsPrincipal(identity);
        //    var properties = new AuthenticationProperties()
        //    {
        //        IsPersistent = true
        //    };
        //    HttpContext.SignInAsync(claimPrincipal, properties);

        //    return View();

        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
