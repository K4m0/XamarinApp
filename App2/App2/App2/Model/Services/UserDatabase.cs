using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinExam.Model.Entities;
using XamarinExam.Storage.Interfaces;

namespace XamarinExam.Model.Services
{
    public class UserDatabase
    {
        private SQLiteConnection conn;

        public UserDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return (from t in conn.Table<User>() select t).ToList();
        }

        public User GetUser(string userName)
        {
            return conn.Table<User>().FirstOrDefault(t => t.UserName == userName);
        }

        public void DeleteUser(int id)
        {
            conn.Delete<User>(id);
        }

        public void AddUser(string fullName , string username, string password)
        {
            var newUser = new User { FullName = fullName, UserName = username, Password = password};
            conn.Insert(newUser);
        }

    }
}
