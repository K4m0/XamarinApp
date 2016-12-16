using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinExam.Model.Entities;
using XamarinExam.Storage.Interfaces;

namespace XamarinExam.Model.Services
{
    public class BookDatabase
    {
        private SQLiteConnection conn;

        public BookDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Book>();
        }

        public IEnumerable<Book> GetBooks()
        {
            return (from t in conn.Table<Book>() select t).ToList();
        }

        public Book GetBook(string bookId)
        {
            return conn.Table<Book>().FirstOrDefault(t => t.id == bookId);
        }

        public void DeleteBook(string id)
        {
            conn.Delete<Book>(id);
        }

        public void AddBook(Book book)
        {
            conn.Insert(book);
        }
    }
}
