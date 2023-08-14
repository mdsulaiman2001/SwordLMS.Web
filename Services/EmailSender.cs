using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using NuGet.Common;
using NuGet.Protocol;

using SwordLMS.Web.Models;
using SwordLMS.Web.Request;
using System.Security.Policy;

namespace SwordLMS.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IPasswordReset _passwordReset;
        private readonly SwordLmstwoContext _context;
       
        public EmailSender(IPasswordReset passwordReset, SwordLmstwoContext context)
        {
            _passwordReset = passwordReset;
            _context = context;
           
        }

       


    public void SignUpConfirmEmail(RegisterRequest Request)
    {

       var client = new SmtpClient();
         client.Connect("smtp.gmail.com");
        //client.Connect("server33.somewebhosting.com", 465);
        client.Authenticate("mdsulaiman2k00@gmail.com", "xzxgxqquzzgrgmcz");
     
        var FullName = Request.FirstName + " " + Request.LastName;

        var bodybuilder = new BodyBuilder
        {
            HtmlBody = $"<p>Welcome {FullName},</p> Thank you for registering with us.",
            TextBody = "{user.Name} \r\n"
        };
        var message = new MimeMessage
        {
            Body = bodybuilder.ToMessageBody(),
        };
        message.From.Add(new MailboxAddress("SwordLMS", "mdsulaiman2k00@gmail.com"));
        message.To.Add(new MailboxAddress(FullName, Request.Email));
        message.Subject = "Registration Successful";
        client.Send(message);

        client.Disconnect(true);
    }


        public void ForgetPasswordEmail(ForgetPassword model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user != null)
            {
                var client = new SmtpClient();

                client.Connect("smtp.gmail.com");

                client.Authenticate("mdsulaiman2k00@gmail.com", "xeqidskmouhovsni");

                var FullName = user.FirstName + " " + user.LastName;

                var bodybuilder = new BodyBuilder
                {
                    HtmlBody = $"<p>Hello, {FullName},</p> <p>Here is a link to ResetPassword</p> {model.Token}",
                    TextBody = "{user.Name} \r\n"
                };
                var message = new MimeMessage
                {
                    Body = bodybuilder.ToMessageBody(),
                };
                message.From.Add(new MailboxAddress("SwordLMS", "mdsulaiman2k00@gmail.com"));
                message.To.Add(new MailboxAddress(FullName, user.Email));
                message.Subject = "Reset Password!";
                client.Send(message);
            }

        }
    }
}