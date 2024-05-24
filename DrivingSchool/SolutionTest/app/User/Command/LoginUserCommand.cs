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
    public class LoginUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string pass { get; set; }
     
    }
    public class LoginUserCommand:IRequest<BaseDto>
    {
        public LoginUserDto LoginUserDto { get; set; }
        public LoginUserCommand(LoginUserDto LoginUserDto)
        {
            this.LoginUserDto = LoginUserDto;

        }

    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseDto>
    {
        private readonly IDataBaceContext _dbaceContext;

        public LoginUserCommandHandler(IDataBaceContext dbaceContext)
        {
            _dbaceContext = dbaceContext;
        }

        public Task<BaseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var passwordHashed = request.LoginUserDto.pass.EncodeToMd5();
                var res = _dbaceContext.Users.
                Where(p => p.Pass == passwordHashed && p.Name == request.LoginUserDto.Name).FirstOrDefault();

                if (res != null)
                {
                    return Task.FromResult(new BaseDto { suc = true });
                }

                return Task.FromResult(new BaseDto { suc = false, Mess = "anjam nashod" });
            }
            catch (Exception ex)
            {
              
                // save ex for Log
                return Task.FromResult(new BaseDto { suc = false, Mess = "Ertebat ghat shod" });
            }
        }
    }

}
