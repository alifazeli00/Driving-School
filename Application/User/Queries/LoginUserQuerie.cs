using Application.Context;
using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Phone { get; set; } 

    }
    public class LoginUserQuerie:IRequest<BaseDto<UserDto>>
    {
        public LoginUserDto LoginUserDto;// masan jain mishe begi  dootaasho  properti darnazar begiri
        public LoginUserQuerie(LoginUserDto LoginUserDto)
        {
            this.LoginUserDto = LoginUserDto;

        }


    }


    public class LoginUserQuerieHandler : IRequestHandler<LoginUserQuerie, BaseDto<UserDto>>
    {
        private readonly IDataBaceContext context;

        public LoginUserQuerieHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<BaseDto<UserDto>> Handle(LoginUserQuerie request, CancellationToken cancellationToken)
        {
            var res = context.Users.Where(p => p.UserName == request.LoginUserDto.UserName).Select(p=>new UserDto
            {
                UserName = p.UserName,
                Phone= p.Phone
            }).FirstOrDefault();
            if(res == null)
            {
                return Task.FromResult(new BaseDto<UserDto> { IsSuccess = false, Messeges = "SABT NAM KONID" });
            }
            else
            {
                return Task.FromResult(new BaseDto<UserDto> { IsSuccess = true, Messeges = "" ,Exist=res});
            }

        }
    }
    public class UserDto

    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Messeges { get; set; }

        public bool IsSuccess { get; set; }
    }



}
