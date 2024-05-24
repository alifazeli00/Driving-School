using app.User.Command;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApplicationMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rejester()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Rejester(UserRejesterDto Req)
        {
            if(!ModelState.IsValid)
            {

                return View(Req);
            }
            RejesterUserCommand x = new RejesterUserCommand(Req);
            var res = mediator.Send(x).Result;
            if (res.suc == true)
            {
                return RedirectToAction(nameof(Login));
            };
            if(res.suc==false)
            {

                ViewBag.eroor = res.Mess;
            }

            


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto Req)
        {
            // bekhater zaman kam az Req estefade mikonam;
            if (!ModelState.IsValid)
            {

                return View(Req);
            }
            LoginUserCommand x = new LoginUserCommand(Req);
            var res = mediator.Send(x).Result;
            if(res.suc == true)
            {
                List<Claim> claims = new List<Claim>()
                    {
                        new Claim("Test","Test"),
                        new Claim(ClaimTypes.NameIdentifier,Req.Name.ToString()),
                        new Claim("Pass",Req.pass),
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(claimPrincipal, properties);
            }



            if(res.suc==false)
            {
                ViewBag.eroor=res.Mess;
            }



            return View();
        }
        public IActionResult ForgetPass()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ForgetPass(ForgetpassDto ForgetpassDto)
        {
            if (!ModelState.IsValid)
            {

                return View(ForgetpassDto);
            }
            ForgetUserCommand x = new ForgetUserCommand(ForgetpassDto);
            var res = mediator.Send(x).Result;
            if (res.suc == true) return RedirectToAction(nameof(Login));
            ViewBag.pass = res;

            return View();
        }

    }
}
