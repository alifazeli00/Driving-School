using Application.Context;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ChekEmtehan
{
   public interface  IchekAiname
    {
        // hame ro neshon midi bad kenaresh ye chek mizari bad yani ghabol shode
        BaseDto<GetUserForInameDto> GetUserForAiname();
        BaseDto AddUserForAiname(int UserId, bool javab);
        BaseDto<GetUserForInameDto> GetUserGhabolShodeha();

    }
    public class chekAiname : IchekAiname
    {
        private readonly IDataBaceContext context;
        public chekAiname(IDataBaceContext context)
        {
            this .context = context;    

        }
        // jabe ainame
        public BaseDto AddUserForAiname(int UserId, bool javab)
        {
            var res=context.BisnesUsers.Where(p => p.UsersId == UserId).FirstOrDefault();
            res.StatusAiname = javab;
            context.SaveChanges();
            return  new BaseDto { IsSuccess=true,Messeges="" };
        }

        public BaseDto<GetUserForInameDto> GetUserForAiname()
        {
       
   var res = context.BisnesUsers.Where(p => p.StatusAiname == false && p.StatusLerningAmali == true).Include(p=>p.Users).Select(p=>new GetUserForInameDto
            {
       CodeMeli=p.Users.CodeMeli,
       Family=p.Users.Family,
       Name=p.Users.Name,

            } ).ToList();
            return new BaseDto<GetUserForInameDto> { IsSuccess = true, Messeges = "", Deta = res };

        }

        public BaseDto<GetUserForInameDto> GetUserGhabolShodeha()
        {
      var res = context.BisnesUsers.Where(p => p.StatusAiname == true && p.StatusAmali == false).Include(p => p.Users).Select(p => new GetUserForInameDto
            {
              
                Family = p.Users.Family,
                Name = p.Users.Name,
                CodeMeli=p.Users.CodeMeli
            }).ToList();
           return new BaseDto<GetUserForInameDto> { Deta=res,IsSuccess=true,Messeges="" };
        
        }
    }

    public class GetUserForInameDto
    {
        public int CodeMeli { get; set; }
        public  string Name { get; set; }
        public string Family { get; set; }

    }
}
