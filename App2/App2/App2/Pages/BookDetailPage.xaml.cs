using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinExam.Model.Entities;

namespace XamarinExam.Pages
{
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage(Book selectedBook)
        {
            InitializeComponent();
            this.BindingContext = selectedBook;
        }
    }
}
