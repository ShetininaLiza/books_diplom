using BusinessLogic.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Database.Logic;
using BusinessLogic.Models;

namespace books.Controllers
{
    public class AdminController : Controller
    {
        MailLogic mLogic;
        
        private IDbConnection database;//Program.database;
        List<User> list;
        public AdminController()
        {
            //Database_.OpenDatabase();
            database = (IDbConnection?)Database_.context;
            list = UserLogic.GetAllUser(Database_.context);
            mLogic = new MailLogic();
        }
        // GET: /Admin/Enter/
        // Вход админа
        [HttpGet]
        public IActionResult Enter()
        {
            return View(new string[] { });
        }

        [HttpPost]
        [ActionName("Enter")]
        public IActionResult Enter(string login, string pass)
        {
            var cheak = list.FirstOrDefault(rec => rec.Login == login && rec.Password == pass);
            //Если нет такого логина
            if (cheak == null)
                return View(new string[] { "Ошибка!", "В системе нет пользователя с такими данными." });
            else
            {
                //Если введен неправильный пароль
                if (cheak.Password != pass)
                    return View(new string[] { "Ошибка!", "Неправильно введен пароль." });
                else
                    return View("../Home/Main");
            }
        }
        
        [HttpGet]
        public IActionResult BlockUser()
        {
            list = UserLogic.GetAllUser(Database_.context);
            var users = list.ToList();//.Where(rec => rec.Role != Role.Администратор.ToString()).ToList();
            List<int> ids = new List<int>();
            for (int i = 0; i < users.Count; i++)
            {
                ViewData[users.ElementAt(i).Id.ToString()] = i + 1;
                //ViewData[users.ElementAt(i).Id.Value.ToString()] = i + 1;
            }
            IEnumerable<User> data = users;

            return View("BlockUser", data);
        }

        [HttpGet]
        public PartialViewResult Update()
        {
            list = UserLogic.GetAllUser(Database_.context);
            var users = list.ToList();//.Where(rec => rec.Role != Role.Администратор.ToString()).ToList();
            List<int> ids = new List<int>();
            for (int i = 0; i < users.Count; i++)
            {
                ViewData[users.ElementAt(i).Id.ToString()] = i + 1;
            }
            IEnumerable<User> data = users;
            return PartialView(data);
        }
        public IActionResult AddBlock(string login)
        {
            var user = list.FirstOrDefault(rec => rec.Login == login);
            bool zn = false;
            //Если пользователь не заблокирован, то метку переводим в значение блока
            /*if (!user.IsBlock)
                zn = true;
            */
            try
            {
                User buf = new User
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    //Phone = user.Phone,
                    Email = user.Email,
                    /*LastName = user.LastName,
                    Name = user.Name,
                    Otch = user.Otch,
                    Work = user.Work,
                    Role = user.Role,
                    IsBlock = zn*/
                };

                UserLogic.UpdateUser(database, buf);

                list = UserLogic.GetAllUser(Database_.context);
                var users = list.ToList();//.Where(rec => rec.Role != Role.Администратор.ToString()).ToList();
                List<int> ids = new List<int>();
                for (int i = 0; i < users.Count; i++)
                {
                    ViewData[users.ElementAt(i).Id.ToString()] = i + 1;
                }
                IEnumerable<User> data = users;
                return //PartialView(users);
                    View("BlockUser", data);
            }
            catch (Exception)
            {
                return PartialView(list);
            }

        }
    }
}
