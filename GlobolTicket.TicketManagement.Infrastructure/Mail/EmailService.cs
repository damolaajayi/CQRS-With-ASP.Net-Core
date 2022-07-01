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

namespace GlobolTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings? _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }
        public async Task<bool> SendEmail(Email mail)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = mail.Subject;
            var to = new EmailAddress(mail.To);
            var emailBody = mail.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
