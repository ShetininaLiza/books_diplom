using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class User
    {
        //Id может быть null, при регистрации нового пользователя
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        //Фамилия
        public string LastName { get; set; } = null!;
        //Имя
        public string Name { get; set; } = null!;
        //Отчество
        public string Otch { get; set; } = null!;
        //Место работы
        public string Work { get; set; } = null!;
        public string Role { get; set; } = null!;

        public bool IsBlock { get; set; }
    }
}
