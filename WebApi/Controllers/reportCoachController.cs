using Application.Coach;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reportCoachController : ControllerBase
    {
        private readonly IReportCoach ReportCoach;
        public reportCoachController(IReportCoach ReportCoach)
        {
            this.ReportCoach = ReportCoach;

        }

        /// <summary>
        /// IreportCoach
        /// </summary>
        /// <returns></returns>
        [HttpGet("{CoachId}")]
        public IActionResult GetDateDrivigCoach(int CoachId)
        {
            var res = ReportCoach.Get(CoachId);
            return Ok(res);
        }

        // TEDAD KARAMOZ HAI KE MORABI DARE
      //  [Route("api/[action]")]
       
    }
}
