using SwordLMS.Web.Models;
using SwordLMS.Web.Request;

namespace SwordLMS.Web.Services
{
    public interface IEmailSender
    {

        void SignUpConfirmEmail(RegisterRequest Request);

        void ForgetPasswordEmail(ForgetPassword model);

    }
}
