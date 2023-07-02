using Application.Context;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coach
{
    public interface IReportCoach
    {
        BaseDto<GetDateDrivig> Get(int CoachId);
        int CountLerning(int CoachId);


    }

    public class ReportCoach : IReportCoach
    {
        private readonly IDataBaceContext context;
        public ReportCoach(IDataBaceContext context)
        {
            this.context = context;

        }

        public int CountLerning(int CoachId)
        {
            var res = context.DatesDrivigs.Where(p => p.CoachsId == CoachId&&p.Status==false).Count();

            return res;
        }

        public BaseDto<GetDateDrivig> Get(int CoachId)
        {
            var res = context.DatesDrivigs.Where(p => p.CoachsId == CoachId &&p.Status==false)
            .Include(p => p.Coachs).ThenInclude(p => p.BisnesCoachs).Include(p => p.Coachs).
            ThenInclude(p=>p.BisnesCoachs).ThenInclude(p=>p.Users).Select(p => new GetDateDrivig
            {
                CoachName = p.Coachs.Name,
                Start = p.Start,
                End = p.End,
                Id = p.Id

            }).ToList();
            return new BaseDto<GetDateDrivig>
            {
                IsSuccess = true,
                Messeges = "",
                Deta = res
            };
        }
    }



    public class GetDateDrivig
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string CoachName { get; set; }


    }

}

