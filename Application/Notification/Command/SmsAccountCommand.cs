using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notification.Command
{
    public  class SmsAccountEvent:INotification
    {
        public string Phone { get; set; }
        public string Code { get; set; }
    } 

    public class SmsAccountEventHandler:INotificationHandler<SmsAccountEvent>
    {
        
        public Task Handle(SmsAccountEvent notification, CancellationToken cancellationToken)
        {
         Smscode(notification.Phone,notification.Code);
            return Task.CompletedTask;
        }
        private void Smscode(string Phone,string code)
        {
            //70556C674A69485875344D706661445233672B50576970796D69524A6B33354563393959664470753876673D
            var client = new WebClient();
            string url = $"https://api.kavenegar.com/v1/70556C674A69485875344D706661445233672B50576970796D69524A6B33354563393959664470753876673D/verify/lookup.json?receptor={Phone}&token={code}&template=VerifyAccount";
            var content = client.DownloadString(url);
        }

    }


}
