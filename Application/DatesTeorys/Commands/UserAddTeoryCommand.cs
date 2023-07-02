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

namespace Application.DatesTeorys.Commands
{
    //public class UserAddTeoryDto
    //{
    //    public string UserName { get; set; }
    //    public string Name { get; set; }
    //    public string Family { get; set; }
    //    public int CodeMeli { get; set; }


    //}
    // hamin jori int zadam
    public class UserAddTeoryCommand:IRequest<int>
    {
        public  List<int> Userr{ get; set; }    
        public int DatesTeoryId { get; set; }
        public UserAddTeoryCommand(int DatesTeoryId,List<int> Userr )
        {
            this.DatesTeoryId = DatesTeoryId;
            this.Userr = Userr;

        }
    }

    public class UserAddTeoryCommandHandler : IRequestHandler<UserAddTeoryCommand, int>
    {
        private readonly IDataBaceContext context;

        public UserAddTeoryCommandHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<int> Handle(UserAddTeoryCommand request, CancellationToken cancellationToken)
        {
            //yani onaii ke ad shodan ro  trye mikonim ham add mikon

            //  var a = context.Users.Where(p => p.Id.Equals(request.Userr)).ToList();
            List<Users> User = new List<Users>();

            foreach (var c in request.Userr)
            {
                var status=       context.Users.Where(p => p.Id == c).Include(d => d.BisnesUsers).SingleOrDefault();
          
                if(status.BisnesUsers==null)
                {

                    BisnesUsers f = new BisnesUsers()
                    {
                        UsersId = status.Id,
                  
                        

                    };
                    context.BisnesUsers.Add(f);
                    context.SaveChanges();
                }
                
                status.BisnesUsers.StatusLerningAiname = true;
              //  c.BisnesUsers.StatusLerningAiname = true;
                //  var a = context.Users.Where(p => p.Id.Equals(request.Userr)).ToList();
                context.SaveChanges();  
                User.Add(status);
            };
           // var Users = context.Users.Include(p => p.BisnesUsers).Where(p => p.Id.Equals(request.Userr)  ).ToList();
            //beja in id DatesTeoryId in ro bas bezari
            var res = context.ListDatesTeory.Include(p=>p.DatesTeory).ThenInclude(p=>p.users).Where(p => p.DatesTeoryId == request.DatesTeoryId   ).FirstOrDefault();
            res.DatesTeory.users = User;
            context.SaveChanges();
            return Task.FromResult(1);
        }
    }
}
