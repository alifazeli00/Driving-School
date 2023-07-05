using Application.Context;
using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class LoginUserDto
    {
        [Required] [MinLength(5)] [MaxLength(5)]

        public string Code { get; set; }
        [Required]
        [RegularExpression(@"(\+98|0)?9\d{9}")] // yanai ya ba +98 shoro se ya ba 0
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
            var res = context.Users.Where(p => p.Phone == request.LoginUserDto.Phone).Select(p => new UserDto
            {
                UserName = p.UserName,
                Phone = p.Phone
            }).FirstOrDefault();
            if (res == null)
            {
                return Task.FromResult(new BaseDto<UserDto> { IsSuccess = false, Messeges = "SABT NAM KONID" });
            };

            var SmsCode = context.SmsCode.Where(p => p.Code == request.LoginUserDto.Code && p.Phone == request.LoginUserDto.Phone).FirstOrDefault();

            if (SmsCode == null)
            {

                return Task.FromResult(new BaseDto<UserDto> { IsSuccess = false, Messeges = "code eshteba" }); 
            }
            else
            {
                if(SmsCode.Used==true)
                {
                    return Task.FromResult(new BaseDto<UserDto> { IsSuccess = false, Messeges = "code eshteba" }); ;
                }
                //
                //time
                //
                
                SmsCode.ReqCount++;
                SmsCode.Used = true;
                context.SaveChanges();
            };

            return Task.FromResult(new BaseDto<UserDto> { IsSuccess = true, Messeges = "", Exist = res });



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
