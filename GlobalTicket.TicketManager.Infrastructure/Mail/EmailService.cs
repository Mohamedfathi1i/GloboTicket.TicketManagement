using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManager.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _mailSettings { get; }
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }


        public async Task<bool> SendEmail(Email email)
        {

            var client = new SendGridClient(_mailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To); 
            var emailBody = email.Body;

            var from = new EmailAddress { Email = _mailSettings.FromAddress, Name = _mailSettings.FromName };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
           
            return false;

        }
    }
}
