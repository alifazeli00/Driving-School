using Application.ChekEmtehan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChekEmtehanStatusController : ControllerBase
    {
        private readonly IchekAiname chekAiname;
        public ChekEmtehanStatusController(IchekAiname chekAiname)
        {
            this.chekAiname=chekAiname;

        }
        [HttpGet]
        public IActionResult GetSucsesAiname()
        {
            var res = chekAiname.GetUserGhabolShodeha();
            return Ok(res);
        }
    }
}
