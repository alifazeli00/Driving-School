using Application.Context;
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
    //nam gozari event ha bara poshe ina chetore
    public class SmsLerningTeoryEvent:INotification
    {
    public int UserId{ get; set; } 
    public DateTime Time { get; set; } //inja bara  ine ke badan bigim to in roz shoro mishe
        
    }
    public class SmsLerningTeoryEventHandler : INotificationHandler<SmsLerningTeoryEvent>
    {
        private readonly IDataBaceContext context;

        public SmsLerningTeoryEventHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task Handle(SmsLerningTeoryEvent notification, CancellationToken cancellationToken)
        {
            var user=context.Users.Where(p=>p.Id==notification.UserId).FirstOrDefault();
            string Name_LastName = user.Name + "_"+user.Family;
            SendSms(Name_LastName,user.Phone,notification.Time);

            return Task.CompletedTask;
        }
        private void SendSms(string Name_LastName,string Phone,DateTime Time)
        {
            var client = new WebClient();
            string url = $"https://api.kavenegar.com/v1/70556C674A69485875344D706661445233672B50576970796D69524A6B33354563393959664470753876673D/verify/lookup.json?receptor={Phone}&token={Name_LastName}&token={Time}&template=VerifyAccount";
            var content = client.DownloadString(url);
        }
    }
}
