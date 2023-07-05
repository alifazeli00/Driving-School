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
    public class SmsStatusAinameEvent:INotification
    {
        public int userId { get; set; }
    }

    public class SmsStatusAinameEventHandler : INotificationHandler<SmsStatusAinameEvent>
    {
        private IDataBaceContext context;

        public SmsStatusAinameEventHandler(IDataBaceContext context)
        {
            this.context = context;
        }

        public Task Handle(SmsStatusAinameEvent notification, CancellationToken cancellationToken)
        {
            var user=context.Users.Where(p=>p.Id==notification.userId).SingleOrDefault();
           
            string Name_LastName = user.Name + "_" + user.Family;
            SendSms(Name_LastName,user.Phone);
            return Task.CompletedTask;
        }
        private void SendSms(string Name_LastName,string Phone)
        {
            var client = new WebClient();
            string url = $"https://api.kavenegar.com/v1/70556C674A69485875344D706661445233672B50576970796D69524A6B33354563393959664470753876673D/verify/lookup.json?receptor={Phone}&token={Name_LastName}&template=lerningTeory";
            var content = client.DownloadString(url);

        }
    }
}
