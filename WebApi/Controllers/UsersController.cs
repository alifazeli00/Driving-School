using Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator meddiatr;

        public UsersController(IMediator meddiatr)
        {
            this.meddiatr = meddiatr;
        }

        //[HttpPost]
      //  [Route("Rejester")]
      /// <summary>
      /// user haii ke class teori bayad bian va esmeshon sabt shode
      /// </summary>
      /// <param name="DatesTeoryId"></param>
      /// <returns></returns>
      [HttpGet("{DatesTeoryId}")]
        public IActionResult GetListTeory(int DatesTeoryId)
        {
            GetListTeoryQuerie c = new GetListTeoryQuerie(DatesTeoryId);
            var res = meddiatr.Send(c).Result;
            return Ok(res);

        }
        /// <summary>
        /// user haii ke hanoz  esmeshon to class ainme sabt nashode 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
      public IActionResult GetListNullTeory()
        {
            GetListNullTeoryQuerie x = new GetListNullTeoryQuerie();
            var res = meddiatr.Send(x).Result;
            return Ok(res);

        }

       [Route("SttusUser")]
       [HttpPost]
       public IActionResult StatusUserByCodemeli(int id)
        {
            StatusUserQuerie x = new StatusUserQuerie(id);
            var res = meddiatr.Send(x);
            string uri ="";
            return Created(uri, res);
        }

    }
}
