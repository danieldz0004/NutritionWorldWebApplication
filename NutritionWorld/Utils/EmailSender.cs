using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// sendGrid api
namespace NutritionWorld.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}