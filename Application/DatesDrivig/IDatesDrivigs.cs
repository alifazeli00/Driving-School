    using Application.Context;
using Application.Dtos;
using Domain.Dates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DatesDrivig
{
    //  zaman bara morai ha moshakas beshe
    public interface IDatesDrivigs
    {
        BaseDto Create(CreateDatesDrivigsDto Req);
           BaseDto<GetDatesDrivigsDto> Get();
        BaseDto Edit(EditDatesDrivigsDto Req);

        //List<GetDatesDrivigsDto> Get();
        BaseDto Remove(int Id);
    }
    public class DatesDrivig : IDatesDrivigs
    {
        private readonly IDataBaceContext context;
        public DatesDrivig(IDataBaceContext context)
        {
          this.context=context;

        }
        public BaseDto Create(CreateDatesDrivigsDto Req)
        {
            DatesDrivigs x = new DatesDrivigs()
            {
                Start=Req.Start,
                End=Req.End,
                CoachsId=Req.CoachsId,
                
                
            };
            context.DatesDrivigs.Add(x);context.SaveChanges();
            return new BaseDto { IsSuccess=true,Messeges="Sabtshod" };
        }

        public BaseDto Edit(EditDatesDrivigsDto Req)
        {
         var res= context .DatesDrivigs.Where(p=>p.Id==Req.Id && p.CoachsId==Req.CoachsId).FirstOrDefault();
            res.Start=Req.Start;
            res.End = Req.End;
             res.CoachsId= Req.CoachsId;
            context.SaveChanges();
            return new BaseDto { IsSuccess = true,Messeges="" };
        }


        // inja bayad user besh bedi  bad to ISetVoachForsers   set mikoni vasash  
        // ba Select2 (ke ketab khone js) ham mishe
        public BaseDto<GetDatesDrivigsDto> Get()
        {
            var res = context.DatesDrivigs.Where(p=>p.Status==false).Include(p=>p.Coachs).Select(p=>new GetDatesDrivigsDto
            {
                Id=p.Id,
                Start=p.Start,
                End =p.End,
                CoachsId = p.CoachsId,
              NameCoach=p.Coachs.Name
               
            }).ToList();
         
            return new BaseDto<GetDatesDrivigsDto>
            {
                Deta=res,IsSuccess=true,Messeges=""
            };
        }

        public BaseDto Remove(int Id)
        {
          var res= context.DatesDrivigs.FirstOrDefault(p=>p.Id==Id);
            res.IsRemoved=true;
            context.SaveChanges();
            return new BaseDto { IsSuccess = true, Messeges = "HazfShod" };
        }
    }


    public class CreateDatesDrivigsDto
    {

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CoachsId { get; set; }

    }
    public class GetDatesDrivigsDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CoachsId { get; set; }
        public string NameCoach { get; set; }
    }


    public class EditDatesDrivigsDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CoachsId { get; set; }

    }
}
