﻿using Application.ChekEmtehan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetListUserController : ControllerBase
    {
        private readonly IchekAiname chekAiname;
        public GetListUserController(IchekAiname chekAiname)
        {
            this .chekAiname = chekAiname;

        }

        /// <summary>
        /// list ghabol shodegan ainame
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSucsesAiname()
        {

            var res = chekAiname.GetUserGhabolShodeha();
            return Ok(res);
        }
    }
}
