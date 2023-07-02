using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class GetListNullTeoryQuerieDto
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public int CodeMeli { get; set; }
        public int Id { get; set; }


    }
    public class GetListNullTeoryQuerie:IRequest<List<GetListNullTeoryQuerieDto>>
    {
    }
    public class GetListNullTeoryQuerieHandler : IRequestHandler<GetListNullTeoryQuerie, List<GetListNullTeoryQuerieDto>>
    {
        private readonly IDataBaceContext context;

        public GetListNullTeoryQuerieHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<List<GetListNullTeoryQuerieDto>> Handle(GetListNullTeoryQuerie request, CancellationToken cancellationToken)
        {

            var res = context.Users.Include(p => p.BisnesUsers).Where(p =>p.DatesTeoryId==null).
                Select(d=> new GetListNullTeoryQuerieDto
                {

                    CodeMeli=d.CodeMeli,
                    Id=d.Id,Family=d.Family,Name=d.Name,Phone=d.Phone,UserName=d.UserName
                }).ToList();
            return Task.FromResult(res);
        }
    }


}
