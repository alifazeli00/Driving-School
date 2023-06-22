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
    public interface IChekAmali
    {
        BaseDto<GetUserForAmaliDto> GetUserForAmali();
   

    }

    public class ChekAmali : IChekAmali
    {
        private readonly IDataBaceContext context;
        public ChekAmali(IDataBaceContext context)
        {
            this.context=  context;

        }
      

        public BaseDto<GetUserForAmaliDto> GetUserForAmali()
        {
            
                var res = context.BisnesUsers.Where(p => p.StatusAiname == true && p.StatusAmali == false).Include(p => p.Users).Select(p => new GetUserForAmaliDto
                {
                    CodeMeli = p.Users.CodeMeli,
                    Family = p.Users.Family,
                    Name = p.Users.Name,

                }).ToList();


            return new BaseDto<GetUserForAmaliDto> { Deta = res, IsSuccess = true, Messeges = "" };

        }

     
    }

    public class GetUserForAmaliDto
    {
        public int CodeMeli { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

    }
}
