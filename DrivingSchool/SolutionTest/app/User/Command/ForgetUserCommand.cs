using app.Dto;
using CodeYad_Blog.CoreLayer.Utilities;
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
    public class ForgetpassDto
    {
        [Required]
        public string phone { get; set; }
        [Required]
        public string password { get; set; }
    }
    public class ForgetUserCommand:IRequest<BaseDto>
    {
        public ForgetpassDto ForgetpassDto { get; set; }
        public ForgetUserCommand(ForgetpassDto ForgetpassDto)
        {
            this.ForgetpassDto = ForgetpassDto;

        }
    }

    public class ForgetUserCommandHandler : IRequestHandler<ForgetUserCommand, BaseDto>
    {
        private readonly IDataBaceContext context;

        public ForgetUserCommandHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<BaseDto> Handle(ForgetUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = context.Users.Where(p => p.phone == request.ForgetpassDto.phone).FirstOrDefault();
                if (res == null)
                {
                    return Task.FromResult(new BaseDto { suc = false, Mess = "NotFound" });
                }
                else
                {
                    res.Pass = request.ForgetpassDto.password.EncodeToMd5();
                    context.SaveChanges();
                    return Task.FromResult(new BaseDto { suc = true, Mess = "sabtShod" });

                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BaseDto { suc = false, Mess = "Eroor" });
            }
            throw new NotImplementedException();
        }
    }
}
