using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Biblioteca.iOS.Storage.Implementations;
using SQLite;
using Xamarin.Forms;
using XamarinExam.Storage.Interfaces;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace Biblioteca.iOS.Storage.Implementations
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {
            
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}
