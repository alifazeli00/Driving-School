using Application.User.Commands;
using Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // shomare teleohone va username  migire agar  doros bod token mide 
        // felan serice  payamc ro nazadam hamin jor shomare ro gereftam
    
        [HttpPost]
        public IActionResult Post(LoginUserDto Req)
        {
            LoginUserQuerie Login=  new LoginUserQuerie(Req);
            var res = mediator.Send(Login).Result;
            if (res.IsSuccess==false)

            {
                return Unauthorized(res.Messeges);
            }

          else
            {
                var claims = new List<Claim>
                {

                    //haminjori inaro gereftam
                    new Claim("UserPhone",res.Exist.Phone.ToString()),
                    new Claim ("Name",res.Exist.UserName),

                };
                var Key = "{57971982-D114-4E43-9FE5-B34BF4E1DCE9}";
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                var creadential = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256); // emza

                var token = new JwtSecurityToken(issuer: "ShowroomAmetis",
                    audience: "ShowroomAmetis",
                    expires: DateTime.Now.AddMinutes(60),
                    notBefore: DateTime.Now,
                    claims: claims,
                    signingCredentials: creadential
                    );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(jwtToken);
            }



        }


        [HttpPost]
        [Route("Rejester")]
        public IActionResult Rejester(RejesterUserDto Req)
        {
            RejesterUserCommand Rejester = new RejesterUserCommand(Req);
         var res=   mediator.Send(Rejester).Result;
            //ham chin chizi mishe to application yani b redirect!
            //   return RedirectToAction(nameof(Post),new LoginUserDto { UserName=res.UserName,Phone=res.Phone});

            return Ok(res);
        }






    }
}
