using Domain.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Coach
{

    public class Coachs
    {
    public int Id { get; set; }
    public string Name { get; set; }
   // public  int  History { get; set; } 
   
   public Image Image { get; set; }
  // public ICollection<DatesDrivigs> DatesDrivigs { get; set; }
  // public DatesDrivigs DatesDrivigs { get; set; }
    public bool IsRemoved { get; set; }= false;
    public  BisnesCoachs BisnesCoachs { get; set; }
    }
}
