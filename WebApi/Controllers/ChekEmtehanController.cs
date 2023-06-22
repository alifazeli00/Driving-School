using Application.ChekEmtehan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChekEmtehanController : ControllerBase
    {
        private readonly IchekAiname chekAiname;
        private readonly IChekAmali ChekAmali;
        public ChekEmtehanController(IchekAiname chekAiname, IChekAmali ChekAmali)
        {
            this.chekAiname = chekAiname;
            this .ChekAmali = ChekAmali;

        }



        [HttpGet]
        public IActionResult GetUserForAiname()
        {
            var res = chekAiname.GetUserForAiname();
            return Ok(res);
        }

        
        [HttpPost]
        //jab ainame
        // masan  admin ye list dashte  az user  bad harki ke ghabol shode bod ro  faghat tik bezae ta lazem nabaseh
        // esmeshon ro benvise
        public IActionResult AddUserainame(int UserId, bool javab)
        {
            var res = chekAiname.AddUserForAiname(UserId,javab);
            string uri = "";
            return Created(uri, res);
        }

       
     

    }
}
