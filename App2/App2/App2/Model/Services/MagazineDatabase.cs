using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinExam.Storage.Interfaces;

namespace XamarinExam.Model.Entities
{
    public class MagazineDatabase
    {
        private SQLiteConnection conn;

        public MagazineDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Magazine>();
        }

        public IEnumerable<Magazine> GetMagazines()
        {
            return (from t in conn.Table<Magazine>() select t).ToList();
        }

        public Magazine GetMagazine(string magazineId)
        {
            return conn.Table<Magazine>().FirstOrDefault(t => t.id == magazineId);
        }

        public void DeleteMagazine(string id)
        {
            conn.Delete<Magazine>(id);
        }

        public void AddMagazine(Magazine magazine)
        {
            conn.Insert(magazine);
        }
    }
}
