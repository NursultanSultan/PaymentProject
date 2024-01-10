using EasyPay.DTO.Dtos.AppUserDtos;
using EasyPay.Entity.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyPay.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View();

            Random rand = new Random();
            int confirmCode;
            confirmCode = rand.Next(100000, 1000000);

            AppUser newUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.Username,
                Email = registerDto.Email,
                City = "Warsaw",
                District="Nowoursynowska",
                ImageUrl="dkjsdc",
                ConfirmCode = confirmCode
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if(!identityResult.Succeeded)
            {
                foreach(var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("EasyPay Admin", "tu201906251@code.edu.az");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", newUser.Email);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Your Confirmation Code : " + confirmCode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "EasyPay Confirmation";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("tu201906251@code.edu.az", "xjcgdvirdmdjnbnu");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            //return RedirectToAction("Index","ConfirmMail");
            return View();

            

        }
    }
}
