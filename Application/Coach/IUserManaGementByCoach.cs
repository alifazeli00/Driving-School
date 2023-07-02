using Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Coach
{
    // har bar ke karamoz mibare ye list dashte bashe ka admin bedone in key tamom mikone(jadval 12 rozas)
    // vaghti  tamom kard statusesh ro tru kone
  public  interface  IUserManaGementByCoach
    {
        void FinishLerning(FinishLerningDto Req);


    }
    public class UserManaGementByCoach : IUserManaGementByCoach
    {
        private readonly IDataBaceContext context;
        public UserManaGementByCoach(IDataBaceContext context)
        {
            this.context = context;

        }
        // coachid bara in ke to tabel dates biaad begi tamom shode
        public void FinishLerning(FinishLerningDto Req)
        {
         var res= context.BisnesUsers.Where(p=>p.UsersId==Req.UserId).FirstOrDefault();
            var statusforEnddates=context.DatesDrivigs.Where(p=>p.CoachsId==Req.CoachId).FirstOrDefault();
            res.StatusLerningAmali = Req.StatusLerningAmali;
            context.SaveChanges();
        }
    }



    public class FinishLerningDto
    {
      public   bool StatusLerningAmali { get; set; }=false;
     public    int CoachId { get; set; }
      public      int UserId { get; set; }
       

    }
}
