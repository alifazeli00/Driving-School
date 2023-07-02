using Application.DatesTeorys.Commands;
using Application.DatesTeorys.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesTeorysController : ControllerBase
    {
        private readonly IMediator mediator;

        public DatesTeorysController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// List tarikh Teory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       public IActionResult Get()
        {
            GetListTeoryQueries x = new GetListTeoryQueries();
            var res = mediator.Send(x).Result;
            return Ok(res);
        }
        /// <summary>
        /// sakht list tarikh teory
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult post([FromBody] CreateTeoryCommadRequestDto Req)
        {
            CreateTeoryCommnad x = new CreateTeoryCommnad(Req);
            var res = mediator.Send(x).Result;
            string uri = "";
        return Created(uri,res);
        }
        /// <summary>
        /// add kardan karamoz be teory
        /// </summary>
        /// <param name="DatesTeoryId"> shenase tarikh teory</param>
        /// <param name="Users"> list Id user ha</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserAddTeory")]
        public IActionResult UserAddTeory(int DatesTeoryId,List<int>Users)
        {
            UserAddTeoryCommand z =new UserAddTeoryCommand(DatesTeoryId,Users);
            var res= mediator.Send(z).Result;
            string uri = "";
            return Created(uri, res);

        }
    }
}
