using Domain.Coach;
using Domain.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public  string Name { get; set; }
        public string Family { get; set; }
    
        public int CodeMeli { get; set; }

      //  public bool StatosCoachs { get; set; }= false; //malom she ke morabi dare ya na
        public bool IsRemoved { get; set; }= false;


      public int? DatesTeoryId { get; set; }
       public DatesTeory DatesTeory { get; set; }

        public BisnesUsers BisnesUsers { get; set; }


    }

}
