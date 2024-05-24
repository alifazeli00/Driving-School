using app.Dto;
using CodeYad_Blog.CoreLayer.Utilities;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace app.User.Command
{
    // bejaie viewmodel
    public class UserRejesterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string pass { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(pass))]
        public string confrimpass { get; set; }

        public string Phone { get; set; }

    }
    public  class RejesterUserCommand:IRequest<BaseDto>
    {
        public UserRejesterDto UserRejesterDto { get; set; }
        public RejesterUserCommand(UserRejesterDto UserRejesterDto)
        {
            this.UserRejesterDto= UserRejesterDto;

        }

    }
    public class RejesterUserCommandHandler : IRequestHandler<RejesterUserCommand, BaseDto>
    {
        private readonly IDataBaceContext context;

        public RejesterUserCommandHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<BaseDto> Handle(RejesterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = context.Users.Where(p => p.Pass == request.UserRejesterDto.pass ||p.phone==request.UserRejesterDto.Phone).FirstOrDefault();
                // pass ro hamon USername dar nazar gereftam bekhter in khastam uniq bashe  


                if (res != null) return Task.FromResult(new BaseDto { Mess = " Invalid" });

                var passwordHash = request.UserRejesterDto.pass.EncodeToMd5();
                Users x = new Users()
                {
                    Name = request.UserRejesterDto.Name,
                    Pass = passwordHash,phone=request.UserRejesterDto.Phone,
                };
                context.Users.Add(x); context.SaveChanges();

                return Task.FromResult(new BaseDto { suc = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BaseDto { suc = false,Mess="ertebar ghat shod" });
            };
        }
    }
}
