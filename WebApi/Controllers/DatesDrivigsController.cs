using Application.DatesDrivig;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesDrivigsController : ControllerBase
    {
        private readonly IDatesDrivigs DatesDrivig;
        public DatesDrivigsController(IDatesDrivigs DatesDrivig)
        {
            this.DatesDrivig = DatesDrivig;

        }
        // GET: api/<DatesDrivigsController>
        [HttpGet]
        public IActionResult GetDatesDrivigs()
        {
           var res=DatesDrivig.Get();return Ok(res);
        }

       

        // POST api/<DatesDrivigsController>
        [HttpPost]
        public IActionResult CreateDatesDrivigs([FromBody] CreateDatesDrivigsDto Req)
        {
            var res = DatesDrivig.Create(Req);
        string uri = "";

            return Created(uri, res);
        }

        // PUT api/<DatesDrivigsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DatesDrivigsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res=DatesDrivig.Remove(id);
            return Ok(res);
        }
    }
}
