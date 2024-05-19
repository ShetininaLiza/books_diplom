using books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Database.Logic
{
    public static class UserLogic
    {
        public static string TextAddUser = "INSERT INTO Users(" +
                           "Login," +
                           "Email," +
                           "Phone," +
                           "Password," +
                           "LastName," +
                           "Name," +
                           "Otch," +
                           "Work," +
                           "Role," +
                           "IsBlock)" +
                       "VALUES(" +
                           "@Login," +
                           "@Email," +
                           "@Phone," +
                           "@Password," +
                           "@LastName," +
                           "@Name," +
                           "@Otch," +
                           "@Work," +
                           "@Role," +
                           "@IsBlock);";
        //public static void AddUser(IDbConnection db, User user)
        public static void AddUser(ApplicationContext db, User user)
        {
            //try
            //{
            
                //db.Execute(TextAddUser, user);
                //создали объект команды
                var cmd = db.Database.ExecuteSqlRaw("INSERT INTO \"user\"(" +
                           "login," +
                           "password," +
                           "email," +
                           "\"phoneNumber\"," +
                           "\"isAdmin\")" +
                       "VALUES(" +
                           "{0}," +
                           "{1}," +
                           "{2}," +
                           "{3}," +
                           "{4});", user.Login, user.Password, user.Email, user.PhoneNumber, user.IsAdmin);


            //}
            //catch (Exception)//SQLiteException)
            //                { throw new Exception("Пользователь с такими данными уже есть в системе."); }
        }

        public static string TextUpdateUser = "UPDATE Users SET " +
                "Id = @Id, " +
                "Login = @Login, " +
                "Email = @Email, " +
                "Phone = @Phone, " +
                "Password = @Password, " +
                "LastName = @LastName, " +
                "Name = @Name, " +
                "Otch = @Otch," +
                "Work = @Work, " +
                "Role = @Role, " +
                "IsBlock = @IsBlock " +
            "WHERE Id = @Id;";

        public static void UpdateUser(IDbConnection md, User user)
        {
            try
            {
                //md.Execute(TextUpdateUser, user);
            }
            catch (Exception) { throw; }
        }

        public static string GetUsers = "SELECT * FROM Users WHERE Id = :id OR Login = :login;";

        public static string GetFIOUser(IDbConnection db, int? id)
        {
            string result = "";
            if (id.HasValue)
            {
                string[] model = new string[3];
                string text = "SELECT  LastName, Name, Otch FROM Users WHERE Id = :id;";
                //var par = new DynamicParameters();
                //par.Add("id", id.Value);
                //var zn = db.Query<User>(text, par);
                //model[0] = zn.First().LastName;
                //model[1] = zn.First().Name;
                //model[2] = zn.First().Otch;
                result = string.Join(' ', model);
            }
            return result;
        }

        //public static List<User> GetAllUser(IDbConnection db)
        public static List<User> GetAllUser(ApplicationContext db)
        {
            string text = "SELECT * FROM \"user\";";
            //var result = new List<User>();//db.Query<User>(text, new DynamicParameters()).ToList();
            var result = db.Users.FromSqlRaw(text).ToList();
            return result;
        }
    }
}
