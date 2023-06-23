using Application.Context;
using Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Commands
{
 public class    RejesterUserDto
    {

        public string Name { get; set; }
       public string Family { get; set; }
        public string Phone { get; set; }
      

    }

    // prop haii ke bayad daryaft koni

    //in class reqest mas 
    public class RejesterUserCommand:IRequest<RejesterUserResponseDto> //inchiziebargashtmidi
    {
        public RejesterUserCommand(RejesterUserDto RejesterUserDto)
        {
            this.RejesterUserDto = RejesterUserDto;
            //barainke nemone nasazi

        }
      public RejesterUserDto RejesterUserDto { get; set; }

    }

    // in yek requset migire
    public class RejesterUserHandler : IRequestHandler<RejesterUserCommand, RejesterUserResponseDto>
    {
        private readonly IDataBaceContext context;

        public RejesterUserHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<RejesterUserResponseDto> Handle(RejesterUserCommand request, CancellationToken cancellationToken)
        {
            // bisnes ma injas 
            Users x= new Users()
            {
                Name = request.RejesterUserDto.Name,
                Family = request.RejesterUserDto.Family,
                Phone = request.RejesterUserDto.Phone,
                UserName= request.RejesterUserDto.Phone
            };
        var res=    context.Users.Add(x);context.SaveChanges();

            return Task.FromResult(new RejesterUserResponseDto() { Phone=res.Entity.Phone,UserName=res.Entity.UserName});
          


        }
    }






    //Response // chi bargasht bedim
    public class RejesterUserResponseDto
    {
        public string  Phone { get; set; }
        public string UserName { get; set; }
    }

}
