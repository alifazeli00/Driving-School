using Application.Context;
using Application.Dtos;
using Domain.Coach;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coach
{
    public interface ISetCoachForUsers
    {
        // in <int> ro bara api gozashtam shayad bekaremon nayad
        BaseDto<int> Set(BisnesCoachsDto Req);

       List< GetBisnesUsersDto> Get();
        GetBisnesUsersDto GetById(int UserId);

    }
    public class SetCoachForUsers : ISetCoachForUsers
    {
        private readonly IDataBaceContext context;
        public SetCoachForUsers(IDataBaceContext context)
        {
            this.context = context;

        }

       
        public List<GetBisnesUsersDto> Get()
        {
            var res = context.BisnesUsers.Include(p => p.DatesDrivigs).ThenInclude(p => p.Coachs).Include(p => p.Users).
                Select(p => new GetBisnesUsersDto
                {

                    NameCoaches = p.DatesDrivigs.Coachs.Name,
                    UserId = p.UsersId,
                    DatesDrivigId = p.DatesDrivigsId,
                    NameUser = p.Users.Name
                }).ToList();
            return res;
        }

        public GetBisnesUsersDto GetById(int UserId)
        {
            var res = context.BisnesUsers.Include(p => p.DatesDrivigs).ThenInclude(p => p.Coachs).Include(p => p.Users).
                  Where(p=>p.UsersId==UserId).  Select(p => new GetBisnesUsersDto
                    {

                        NameCoaches = p.DatesDrivigs.Coachs.Name,
                        UserId = p.UsersId,
                        DatesDrivigId = p.DatesDrivigsId,
                        NameUser = p.Users.Name
                    }).FirstOrDefault();
            return res;
        }
    

        public BaseDto<int> Set(BisnesCoachsDto Req)
        {
            BisnesCoachs x = new BisnesCoachs()
            {
                CoachsId=Req.coachId,
            //    DatesDrivigsId=Req.DatesDrivigId,
                UsersId=Req.UserId,
             
            };
            BisnesUsers c = new BisnesUsers()
            {
                DatesDrivigsId = Req.DatesDrivigId,
                UsersId = Req.UserId,

            };
            context.BisnesCoachs.Add(x);
            context.BisnesUsers.Add(c);
            context.SaveChanges();
            var res = context.Users.Where(p => p.Id == Req.UserId).SingleOrDefault();
            var StatusDates = context.DatesDrivigs.Where(p => p.Id == Req.DatesDrivigId).SingleOrDefault();
            StatusDates.Status = true; //rezerv shode bara user  ya na bara report bekaret mid bad tedad karamoza m igiri
            res.StatosCoachs = true; // yani badan molaom she ke in morabi dare
            context.SaveChanges();

            return new BaseDto<int>
            {

                IsSuccess = true,
                Messeges = "sabt hsosd",Exist=res.Id
            };
        }
    }

    public class BisnesCoachsDto
    {
        public int UserId { get; set; }
        public int DatesDrivigId { get; set; }
        public int coachId { get; set; }

    }
        public class GetBisnesUsersDto
    {
        public int UserId { get; set; }
        public  string NameUser { get; set; }
        public int DatesDrivigId { get; set; }
        public string NameCoaches { get; set; }

    }
}
