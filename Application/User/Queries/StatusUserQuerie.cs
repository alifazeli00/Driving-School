using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class StatusUserQuerie:IRequest<int>
    {
        public int UserId { get; set; }
        public StatusUserQuerie(int UserId)
        {
            this.UserId = UserId;

        }
    }
    public class StatusUserQuerieHandler : IRequestHandler<StatusUserQuerie, int>
    {
        private readonly IDataBaceContext context;

        public StatusUserQuerieHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task<int> Handle(StatusUserQuerie request, CancellationToken cancellationToken)
        {

            var res = context.Users.Where(p => p.Id == request.UserId).
            Include(p => p.BisnesUsers).ThenInclude(p => p.DatesDrivigs).FirstOrDefault();
            if (res==null)
            {

            }; 
            if(res.BisnesUsers==null)
            {
                return Task.FromResult(0);
            }
            if(res.BisnesUsers.StatusLerningAiname==true && res.BisnesUsers.StatusLerningAmali == false)
            {
                return Task.FromResult(1);
            }
            if (res.BisnesUsers.DatesDrivigs.Status == true && res.BisnesUsers.StatusLerningAmali==false)
            {
                return Task.FromResult(2);
            }

            if (res.BisnesUsers.StatusLerningAmali == true &&res.BisnesUsers.StatusAiname==false ) 
            {
                return Task.FromResult(3);
            }

            if (res.BisnesUsers.StatusLerningAmali == true && res.BisnesUsers.StatusAiname == false)
            {
                return Task.FromResult(4);
            }

           return Task.FromResult(0);
        }
    }
    public enum StatusUser
    {
        /// <summary>
        /// VAred Class ainame nashode
        /// </summary>
        Sabtnam=0,

        /// <summary>
        /// در حال سپری کردن کلاس اینامه
        /// </summary>
        LerningAiname = 1,

        /// <summary>
        /// در حال سپری کردن کلاس عملی
        /// </summary>
        LerningAmali = 2,

        /// <summary>
        /// در حال امتحان دادن اینامه
        /// </summary>
        EmtehanAiname= 3,

        /// <summary>
        /// در حال امتحان دادن عملی
        /// </summary>
        EmtehanAmali = 4,


    };



}
