using Application.Coach;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/reportCoach/{CoachId}/count")]
    [ApiController]
    public class reportCoachCountController : ControllerBase
    {
        private readonly IReportCoach ReportCoach;
        public reportCoachCountController(IReportCoach ReportCoach)
        {
            this.ReportCoach = ReportCoach; 

        }
        [HttpGet]
        public IActionResult CountLerningForCoach(int CoachId)
        {
            var res = ReportCoach.CountLerning(CoachId);
            return Ok(res);
        }
    }
}
