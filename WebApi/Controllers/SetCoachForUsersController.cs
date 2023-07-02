using Application.Coach;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetCoachForUsersController : ControllerBase
    {
        private readonly ISetCoachForUsers SetCoachForUsers;
        public SetCoachForUsersController(ISetCoachForUsers SetCoachForUsers)
        {
            this.SetCoachForUsers = SetCoachForUsers;

        }

        /// <summary>
        /// dadan karamoz be morabi
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult SetUserForCoach([FromBody] BisnesCoachsDto Req)
        {
            var res = SetCoachForUsers.Set(Req);

            string url = "";
            return Created(url, res);
        }
        /// <summary>
        /// list karamozaii ke talimidaran
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserForDrivig()
        {
            var res = SetCoachForUsers.Get();
            return Ok(res);
        }


        [HttpGet("{UserId}")]
        public IActionResult GetBisnesUsersById(int UserId)
        {
            var res = SetCoachForUsers.GetById(UserId);
            return Ok(res);
        }
    }
}
