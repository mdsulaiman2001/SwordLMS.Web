//using MailKit.Net.Smtp;
//using Microsoft.AspNetCore.Identity;
//using MimeKit;
//using SwordLMS.Web.Models;

//namespace SwordLMS.Web.Repository
//{
//    public class AccountRespository : IAccountRepository
//    {
        //private readonly UserManager<User> _userManager;
    

//      private readonly UserManager<User> _userManager;

//        private readonly SwordLmsContext _context;
//      public AccountRespository(UserManager<User> userManager , SwordLmsContext context)
//        {
//           _userManager = userManager;
//           _context= context;


//        }
//        public async Task<User> GetUserByEmailAsync(string email)
//        {
//            return await _userManager.FindByEmailAsync(email);
//        }

//        public async Task  GenerateForgetPasswordTokenAsync(User user)
//        {
//            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//            if (!string.IsNullOrEmpty(token))
//            {
//                ForgetPasswordEmail(user, token);
//            }
//        }

    

//        public void ForgetPasswordEmail(User user, string token)
//        {
//            using (var client = new SmtpClient())
//            {
//                client.Connect("smtp.gmail.com");
//                //client.Connect("server33.somewebhosting.com", 465);
//                client.Authenticate("mdsulaiman2k00@gmail.com", "xeqidskmouhovsni");

//                var FullName = user.FirstName + " " + user.LastName;

//                var bodybuilder = new BodyBuilder
//                {
//                    HtmlBody = $"<p>Hello {FullName},</p>  Thank you for registering with us.",
//                    // TextBody = "{user.Name} \r\n"
//                };
//                var message = new MimeMessage
//                {

//                    Body = bodybuilder.ToMessageBody(),
//                };
//                message.From.Add(new MailboxAddress("SwordLMS", "mdsulaiman2k00@gmail.com"));
//                message.To.Add(new MailboxAddress(FullName, user.Email));
//                message.Subject = "Registration Successful";
//                client.Send(message);

//                client.Disconnect(true);
//            }


//        }

//        internal static Task GeneratePasswordResetTokenAsync(User user)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}