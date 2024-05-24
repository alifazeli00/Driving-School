using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Dto
{
    public class BaseDto
    {
       public string Mess { get; set; }
        public bool suc { get; set; }   

    }
   public class BaseDto<T>
    {

        public string Mess { get; set; }
        public bool suc { get; set; }
        public T User { get; set; }
    }
}
