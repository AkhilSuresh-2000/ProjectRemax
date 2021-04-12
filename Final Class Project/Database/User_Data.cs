using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Class_Project.Database
{
    public static class User_Data
    {
        public static bool Login(string username, string password)
        {
            var entity = new remax_Entities();

            var result = (from c in entity.Users
                          where c.username == username || c.password == password
                          select c.id).Count();
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public static bool Register(User user)
        {
            var entity = new remax_Entities();

            var result = (from c in entity.Users
                          where c.username == user.username
                          select c);

            if (result.Count() > 0)
            {
                return false;
            }

            entity.Users.Add(user);
            //entity.Database.ExecuteSqlCommand(string.Format(@"insert into Users(first_name, last_name, middle_name, username, password, role) values('{0}', '{1}', '{2}', '{3}', '{4}', {5})", user.first_name, user.middle_name, user.last_name, user.username, user.password, user.role));

            entity.SaveChanges();

            return true;
        }

        //public static bool Register(User user)
        //{
        //    return User_Data.Register(user);
        //}

        //public static bool Login(string username, string password)
        //{
        //    return User_Data.Login(username, password);
        //}
    }
}
