using Application.Context;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public interface IReporUser
    {
        BaseDto<GetDateDrivig> GetDateDrivig(int UserId);
        bool ChekForAiname(int UserId);
        BaseDto<coachNullDto> coachNull();


    }
    public class ReporUser : IReporUser
    {
        private readonly IDataBaceContext context;
        public ReporUser(IDataBaceContext context)
        {
            this.context = context;

        }

        public bool ChekForAiname(int UserId)
        {
            var res = context.BisnesUsers.Where(p => p.Id == UserId).Select(p => p.StatusAiname).FirstOrDefault();
            return res;


        }

        public BaseDto<coachNullDto> coachNull()
        {

            var res = context.BisnesUsers.Include(p=>p.Users).Where(p => p.StatusLerningAmali == false && p.StatusLerningAiname == true && p.StatusAiname==false)
             .Select(p=>new coachNullDto()
             {
                 Family=p.Users.Family,
                 Name=p.Users.Name,
                 Id=p.UsersId

             }).ToList();
            return new BaseDto<coachNullDto> { Deta = res, IsSuccess = true, Messeges = "" };

        }

        public BaseDto<GetDateDrivig> GetDateDrivig(int UserId)
        {
            var res = context.BisnesUsers.Where(p => p.Id == UserId)
            .Include(p => p.DatesDrivigs).ThenInclude(p => p.Coachs).Include(p => p.Users).Select(p => new GetDateDrivig
            {
                CoachName = p.DatesDrivigs.Coachs.Name,
                Start = p.DatesDrivigs.Start,
                End = p.DatesDrivigs.End,
                Id = p.Id

            });
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
    public class coachNullDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}

