using Application.ChekEmtehan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        /// <summary>
        /// List karamoz barai ainame
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetUserForAiname()
        {
            var res = chekAiname.GetUserForAiname();
            return Ok(res);
        }
        //jab ainame
        // masan  admin ye list dashte  az user  bad harki ke ghabol shode bod ro  faghat tik bezae ta lazem nabaseh
        // esmeshon ro benvise

        /// <summary>
        /// javab emtehan ainame
        /// </summary>
        /// <param name="UserId">Listi az User ha ro midi  </param>
        /// <param name="javab">onake ghabol shodan mishe true ona ham nashodan ke lazem nis chon false mikone</param>
        /// <returns></returns>


        [HttpPost]
        public IActionResult AddUserainame(List<int> UserId, bool javab)
        {
            var res = chekAiname.AddUserForAiname(UserId, javab);
            string uri = "";
            return Created(uri, res);
        }

       
     

    }
}
