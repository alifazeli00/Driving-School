using Application.Context;
using Application.Notification.Command;
using Domain.Sms.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Commands
{
    public   class SaveSmsCodeCommand:IRequest<string>
    {
        public string Phone { get; set; }

        public SaveSmsCodeCommand(string phone)
        {
            Phone = phone;
        }
    }
    public class SaveSmsCodeCommandHandler : IRequestHandler<SaveSmsCodeCommand, string>
    {
        private readonly IDataBaceContext context;
        private readonly IPublisher publisher;


        public SaveSmsCodeCommandHandler(IDataBaceContext context, IPublisher publisher)
        {   
            this.publisher=publisher;
            this.context = context;
        }

        public Task<string> Handle(SaveSmsCodeCommand request, CancellationToken cancellationToken)
        {
           

            Random random = new Random();
            string code= random.Next(1000,9999).ToString();
           
            
            SmsCode x = new SmsCode()
            {
                Code = code,
                Phone = request.Phone, ReqCount = 0, Time = DateTime.UtcNow, Used = false
            };
            context.SmsCode.Add(x);
            context.SaveChanges();

            publisher.Publish(new SmsAccountEvent { Phone = request.Phone,Code=x.Code });
            return Task.FromResult(code);

        }
    }
}
