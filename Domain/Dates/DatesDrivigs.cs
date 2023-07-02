using Domain.Coach;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dates
{
    // bara morabi ha  karamoz mide 
    public class DatesDrivigs
    {

        public int Id { get; set; }
        public DateTime Start { get; set; } 
        public DateTime End { get; set; } 
       

          public int CoachsId { get; set; }
         public  Coachs Coachs { get; set; }

        
        public BisnesUsers BisnesUsers { get; set; }


        // yelist migiri migi onaii ke stats false  ro neshon bede ta  badan karamoz bedim
        public bool Status { get; set; } = false; // rezerv shode bara user  ya na bara report bekaret mid bad tedad karamoza m igiri.. VAGHTI 12 JALASASH TAMOM BAYAD IN RO FALSE KONE
        public  bool IsRemoved { get; set; }



    }
}
