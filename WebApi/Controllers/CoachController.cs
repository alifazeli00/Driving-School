using Application.Coach;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        // GET: api/<CoachController>
        private readonly ICreateCoachs CreateCoachs;
     
        public CoachController(ICreateCoachs CreateCoachs)
        {
          
            this.CreateCoachs=CreateCoachs;
 
        }
        [HttpGet]
        public IActionResult GetCoach()
        {
           var res= CreateCoachs.Get();
            return Ok(res);
        }

        // GET api/<CoachController>/5
        [HttpGet("{Id}")]
        public  IActionResult GetCoachById(int Id)
        {
            var res=CreateCoachs.GetById(Id);
            return Ok(res);
        }

        // POST api/<CoachController>
        [HttpPost]
        public IActionResult AddCoach([FromBody] AddDto Req)
        {
            var res = CreateCoachs.Add(Req);

            string url = Url.Action(nameof(GetCoach), "Coach", new { Id = res.Exist }, Request.Scheme);

            return Created(url,res);    
        }

        // PUT api/<CoachController>/5
        [HttpPut()]
        public IActionResult EditCoach(EditDto Req)
        {

            var res = CreateCoachs.Edit(Req);
            return Ok(res);
        }

        // DELETE api/<CoachController>/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteCoach(int Id)
        {
            var res = CreateCoachs.Remove(Id);
            return Ok(res);
        }
       


    }

}
