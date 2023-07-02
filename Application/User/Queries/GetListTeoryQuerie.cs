using Application.Context;
using Domain.User;
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
    public class UserAddTeoryDto
    {
    //  public  List<Users> UserDto { get; set; }
      public List<UserssDto> UserssDto { get; set; }

    }
  public class UserssDto
    {

        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public int CodeMeli { get; set; }

    }

    public class GetListTeoryQuerie:IRequest<List<UserAddTeoryDto>>
    {
        public int DatesTeoryId { get; set; }
        public GetListTeoryQuerie(int DatesTeoryId)
        {
            this.DatesTeoryId = DatesTeoryId;

        }
    }
    public class GetListTeoryQuerieHandler : IRequestHandler<GetListTeoryQuerie, List<UserAddTeoryDto>>
    {
        private readonly IDataBaceContext context;

        public GetListTeoryQuerieHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<List<UserAddTeoryDto>> Handle(GetListTeoryQuerie request, CancellationToken cancellationToken)
        {
            var res = context.ListDatesTeory.Include(p=>p.DatesTeory).ThenInclude(p=>p.users).Where(p => p.DatesTeoryId == request.DatesTeoryId).Select(p => new UserAddTeoryDto
            {

                UserssDto = p.DatesTeory.users.Select(p=> new UserssDto { CodeMeli = p.CodeMeli,
                Family=p.Family,Name=p.Name,Phone=p.Phone,UserName=p.UserName
                }).ToList()
            }).ToList();
            return Task.FromResult(res);

           
        }
    }
}
