using Domain.Dates;
using Domain.User;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Coach
{
    public class BisnesCoachs
    {
        public int Id { get; set; }
       
        public  int CoachsId { get; set; }
        public Coachs Coachs { get; set; }
        public int UsersId  { get; set; }
        public Users Users { get; set; }

       // public int DatesDrivigsId { get; set; }
//        public DatesDrivigs DatesDrivigs { get; set; }
    }

    //bara in ke har bar karmoz bord jadvalesh ro por kone
    //public class JadvalCoachs
    //{
    //    public int Id { get; set; }
    //    public DateTime  
    //}
}
