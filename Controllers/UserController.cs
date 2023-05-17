using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwordLMS.Web.Models;
using System.Diagnostics;
using System.Security.Claims;
using SwordLMS.Web.Repository;
using SwordLMS.Web.Request;
using SwordLMS.Web.Services;

namespace SwordLMS.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly SwordLmsContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPasswordReset _passwordReset;
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly IUserService _userService;

        public UserController(SwordLmsContext context,
         IPasswordHasher passwordHasher, IPasswordReset passwordResetRepo, IUserRepository userRepository, IEmailSender emailSender, IUserService userService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _passwordReset = passwordResetRepo;
            _userRepository = userRepository;
            _emailSender = emailSender;
            _userService = userService;

        }

        public IActionResult SignUp()
        {
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SaveSignUp(RegisterRequest registerRequest)
        {

            string strDDLValue = Request.Form["ddlRole"].ToString();

            registerRequest.RoleId = Convert.ToInt32(strDDLValue);

            _userRepository.SaveSignUp(registerRequest);

            _emailSender.SignUpConfirmEmail(registerRequest);

            return RedirectToAction("Login");
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }


        public IActionResult DoForgetPassword(ForgetPassword model)
        {


            var user = _userService.GetUserByEmail(model.Email);

            if (user != null)
            {

                var token = _passwordReset.GeneratePasswordToken(user);

                var passwordResetlink = Url.Action("ResetPassword", "User", new { email = user.Email, token }, Request.Scheme);

                if (passwordResetlink != null)
                {
                    model.Token = passwordResetlink;

                    _emailSender.ForgetPasswordEmail(model);

                    ModelState.Clear();

                    TempData["MailMessage"] = "We Have Sent Reset Password Link To The Registered Email Address, Kindly Reset The Password Using The Link";
                }
            }
            else
                TempData["EmailErr"] = "Sorry, This Email Address Not Registered With Us, Enter Valid Email Address";
            return View("ForgetPassword");

        }

        public async Task<IActionResult> DoLoginAsync(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return BadRequest();


            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(m => m.UserName == loginRequest.UserName);


            if (user == null)
                return NotFound(new { Message = "User not found" });



            if (!_passwordHasher.verify(user.Password, loginRequest.Password))
            {
                if (user.IsActive == true)
                {

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                   new Claim("userid", user.Id.ToString()),
                 
                    new Claim("FullName", user.FirstName +" "+ user.LastName),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    //new Claim("Role", user.RoleId.);

               };
                    var claimsIdentity = new ClaimsIdentity(
                       claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    //--------------------------------------------------------
                    TempData["UserName"] = user.UserName;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }


            {
                TempData["LoginErr"] = "Wrong credentials. Please, try again!";
                return View("Login");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword(string email, string token)
        {
            ResetPassword resetPasswordModel = new ResetPassword
            {
                Token = token,
                Email = email
            };
            return View();
        }

        public IActionResult DoResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                _passwordReset.ResetPassword(model);

                TempData["PasswordChanged"] = "you have successfully changed the password, you can login with New Password";
                return View("ResetPassword");
            }
            TempData["PasswordErr"] = "password does not matches";
            return View("ResetPassword");
        }

        [Authorize]
        public IActionResult HomePage()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}