using Application.Coach;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManaGementByCoachController : ControllerBase
    {
        private readonly IUserManaGementByCoach UserManaGementByCoach;
        public UserManaGementByCoachController(IUserManaGementByCoach UserManaGementByCoach)
        {
            this.UserManaGementByCoach = UserManaGementByCoach;
        }




        // tamom hsodan amali
        [HttpPost]
        public void FinishLerningAmali([FromBody] FinishLerningDto Req)
        {
            UserManaGementByCoach.FinishLerning(Req);

            //   string url = Url.Action(nameof(GetCoach), "Coach", new { Id = res.Exist }, Request.Scheme);

            //  return Created(url, );
        }
    }
}
