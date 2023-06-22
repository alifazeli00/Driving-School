using Domain.Coach;
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
        public  string Name { get; set; }
        public string Family { get; set; }
        public int CodeMeli { get; set; }

        public bool StatosCoachs { get; set; }= false; //malom she ke morabi dare ya na
        public bool IsRemoved { get; set; }= false;

    
        

        public BisnesUsers BisnesUsers { get; set; }


    }

}
