using Application.Context;
using Application.Notification.Command;
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
        private readonly IPublisher publisher;

      


        public UserAddTeoryCommandHandler(IDataBaceContext context,IPublisher publisher)
        {
            this.context = context;
            this.publisher = publisher;
        }

        public Task<int> Handle(UserAddTeoryCommand request, CancellationToken cancellationToken)
        {
          var res = context.ListDatesTeory.Include(p => p.DatesTeory).ThenInclude(p => p.users).Where(p => p.DatesTeoryId == request.DatesTeoryId).FirstOrDefault();

            //yani onaii ke ad shodan ro  trye mikonim ham add mikon

            //  var a = context.Users.Where(p => p.Id.Equals(request.Userr)).ToList();
            List<Users> Users = new List<Users>();

            foreach (var c in request.Userr)
            {
                var User= context.Users.Where(p => p.Id == c).Include(d => d.BisnesUsers).SingleOrDefault();
          
                if(User.BisnesUsers==null)
                {

                    BisnesUsers f = new BisnesUsers()
                    {
                        UsersId = User.Id,
                  
                        

                    };
                    context.BisnesUsers.Add(f);
                    context.SaveChanges();
                }

                User.BisnesUsers.StatusLerningAiname = true;
              //  c.BisnesUsers.StatusLerningAiname = true;
                //  var a = context.Users.Where(p => p.Id.Equals(request.Userr)).ToList();
                context.SaveChanges();  
                Users.Add(User);
               // braye time : bayad  sata shoro va tarikh ro bedim ke payam bere vasash
                publisher.Publish(new SmsLerningTeoryEvent { UserId = User.Id,Time=res.Date });
            };
           // var Users = context.Users.Include(p => p.BisnesUsers).Where(p => p.Id.Equals(request.Userr)  ).ToList();
            //beja in id DatesTeoryId in ro bas bezari
           
            res.DatesTeory.users = Users;
        
            context.SaveChanges();
            return Task.FromResult(1);
        }
    }
}
