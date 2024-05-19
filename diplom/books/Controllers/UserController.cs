using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Database;
using System.Text.RegularExpressions;
using BusinessLogic.Models;
using Database.Logic;
using System.Data;

namespace books.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext md = Database_.context;
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Admin/Enter/
        // Вход админа
        [HttpGet]
        //[ActionName("Enter")]
        public IActionResult Enter()
        {
            return View(new string[] { });
        }

        [HttpPost]
        [ActionName("Enter")]
        public IActionResult Enter(string login, string pass)
        {
            var users = Database.Logic.UserLogic.GetAllUser(md);
            var user = users.FirstOrDefault(rec => rec.Login == login && rec.Password == pass);
            if (user == null) {
                return View(new string[] { "Ошибка!", "В системе нет пользователя с такими данными." });
            }
            else
            {
                if (!user.IsAdmin)
                {
                    return View(new string[] { "УРА!", "USER" });
                }
                else {
                    return View(new string[] { "УРА!", "ADMIN" });
                }
                
            }
            
        }

        [HttpGet]
        public IActionResult Register() {
            return View(new string[] { });
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register(string Login, string Email, string Pass, string Tel) 
        {
            /*
            var check = ValidateEmail(Email);
            if (!check)
            {
                return View(new string[] { "Ошибка!",
                    "Email введен неправильно." });
            }
            else {*/
                var user = new User
                {
                    Login = Login,
                    Email = Email,
                    Password = Pass,
                    PhoneNumber = Tel,
                    IsAdmin = false
                };
                //try
                //{
                    UserLogic.AddUser(md, user);
                    //await SendMailNewAutor(user);
                    return View(new string[] { "Поздравляем!", "Регистрация в системе прошла успешно." });
                //}
                //catch (Exception) { return View(new string[] { "Ошибка!", "Пользователь с такими данными уже есть в системе." }); }
            //}
        }

        private bool ValidateEmail(string email)
        {
            var pattern = @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
