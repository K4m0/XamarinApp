using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Biblioteca.Droid.Storage.Implementations;
using SQLite;
using XamarinExam.Storage.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDroid))]
namespace Biblioteca.Droid.Storage.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}