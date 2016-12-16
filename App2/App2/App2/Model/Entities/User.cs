using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinExam.ViewModels;

namespace XamarinExam.Model.Entities
{
    public class User : ObservableItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string fullName;
        public string FullName {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged(); } }

        private string userName;
        public string UserName {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); } }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        public User()
        {
        }
    }
}
