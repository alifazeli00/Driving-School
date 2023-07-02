using Application.Context;
using Domain.Dates;
using Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DatesTeorys.Commands
{
 public class   CreateTeoryCommadRequestDto
    {
        public List<DatesTeoryDto> DatesTeoryDto { get; set; }

    }
    public class DatesTeoryDto
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string NameTeacher { get; set; }
        public Subject Subject { get; set; }
    }
    public class CreateTeoryCommnad:IRequest<int>
    {
        public CreateTeoryCommadRequestDto CreateTeoryCommadRequestDto { get; set; }
        public CreateTeoryCommnad(CreateTeoryCommadRequestDto CreateTeoryCommadRequestDto)
        {
            this.CreateTeoryCommadRequestDto = CreateTeoryCommadRequestDto;

        }
    }
    public class CreateTeoryCommnadHandler :IRequestHandler<CreateTeoryCommnad, int>
    {
        private readonly IDataBaceContext context;

        public CreateTeoryCommnadHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<int> Handle(CreateTeoryCommnad request, CancellationToken cancellationToken)
        {

            List<ListDatesTeory> xd = new List<ListDatesTeory>();

            foreach (var c in  request.CreateTeoryCommadRequestDto.DatesTeoryDto)
                 {
                var s = new ListDatesTeory
                {
                    Date = c.Date,
                    End = c.End,
                    NameTeacher = c.NameTeacher,
                    Start = c.Start,
                    Subject = c.Subject,
                };
                xd.Add(s);
                context.ListDatesTeory.Add(s);
                context.SaveChanges();
            }
            //   x.ChildDatesTeory=xd;
            DatesTeory jj = new DatesTeory()
            {
                ListDatesTeory = xd
            };
     
            context.DatesTeory.Add(jj);
            context.SaveChanges();
            return Task.FromResult(jj.Id);

        }
    }

}
