﻿using Application.Context;
using Application.Dtos;
using Application.Notification.Command;
using MediatR;
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
        //jaba ainame
        BaseDto AddUserForAiname(List<int> UserId, bool javab);
        BaseDto<GetUserForInameDto> GetUserGhabolShodeha();

    }
    public class chekAiname : IchekAiname
    {
        private readonly IDataBaceContext context;
        private readonly IPublisher publisher; 
        public chekAiname(IDataBaceContext context, IPublisher publisher)
        {
            this .context = context;    
            this.publisher = publisher;

        }
        // jabe ainame
        //faghat oanii ke ghbol shodn
        public BaseDto AddUserForAiname(List<int> UserId, bool javab)
        {
        // inja az mediatr estefade nashod chon az ghabl service haro neveshtam

           
            //masan inja lazeme ke  chek koni bebini id ke mide eshtb nabashe yani false bashe
            foreach(int  item in UserId)
            {
                var user = context.BisnesUsers.Where(p => p.UsersId == item).SingleOrDefault();
                if(user.StatusAiname==false)
                {
                    user.StatusAiname = javab;
                    publisher.Publish(new SmsStatusAinameEvent { userId = item });

                }
            
                context.SaveChanges();
             
                // kare dorostie  kho agar 100 ta bod hamash request mire bara server??



            }

           // var res=context.BisnesUsers.Where(p => p.UsersId == UserId).FirstOrDefault();
            //res.StatusAiname = javab;
            
            return  new BaseDto { IsSuccess=true,Messeges="" };
        }

        public BaseDto<GetUserForInameDto> GetUserForAiname()
        {
       
   var res = context.BisnesUsers.Include(p=>p.DatesDrivigs).Where(p => p.StatusAiname == false && p.StatusLerningAmali == true /*&&p.DatesDrivigs.Status==false*/).Include(p=>p.Users).Select(p=>new GetUserForInameDto
            {
       CodeMeli=p.Users.CodeMeli,
       Family=p.Users.Family,
       Name=p.Users.Name,
       Id=p.UsersId

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
        public int Id { get; set; }
    }
}
