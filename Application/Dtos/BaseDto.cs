using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseDto
    {

        public string Messeges { get; set; }

        public bool IsSuccess { get; set; }
    }

    public class BaseDto<T>
    {
        // khoroji mes int
        public T Exist { get; set; }
        public  IEnumerable<T> Deta { get; set; }
        public string Messeges { get; set; }

        public bool IsSuccess { get; set; }
    }
    // bara khodorji hai mes int
  
}
