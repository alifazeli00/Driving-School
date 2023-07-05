using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sms.Account
{
    public class SmsCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public int ReqCount { get; set; }
        public DateTime Time { get; set; }
        public bool Used=false; 
    }
}
