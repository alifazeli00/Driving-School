using Application.Context;
using Application.DatesTeorys.Commands;
using Domain.Dates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DatesTeorys.Queries
{
public class GetListTeoryQueriesRequestDto
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string NameTeacher { get; set; }
        public Subject Subject { get; set; }
        public int? DatesTeoryId { get; set; }
    }

    public class GetListTeoryQueries : IRequest<IEnumerable<IGrouping<int?, GetListTeoryQueriesRequestDto>>>
    {
    }

    public class GetListTeoryQueriesHandler : IRequestHandler<GetListTeoryQueries, IEnumerable<IGrouping<int?, GetListTeoryQueriesRequestDto>>>
    {
        private readonly IDataBaceContext context;

        public GetListTeoryQueriesHandler(IDataBaceContext context)
        {
            this.context = context;
        }
        //takmil nashode hanoz 
        public Task<IEnumerable<IGrouping<int?, GetListTeoryQueriesRequestDto>>> Handle(GetListTeoryQueries request, CancellationToken cancellationToken)
        {
            var ress = context.ListDatesTeory.Select(p=> new GetListTeoryQueriesRequestDto
            {Date=p.Date,End=p.End,NameTeacher=p.NameTeacher,Subject=p.Subject,
            DatesTeoryId=p.DatesTeoryId,Start=p.Start
            }).ToList().GroupBy(p=>p.DatesTeoryId);
            











        //    var ressq = context.DatesTeory.ToList().GroupBy(p => p.ChildDatesTeory);

            return Task.FromResult(ress);
        }
    }
}
