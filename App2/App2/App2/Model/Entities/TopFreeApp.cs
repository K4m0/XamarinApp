using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.ViewModels;

namespace XamarinExam.Model.Entities
{
   public  class TopFreeApp : ObservableItem
   {
       private string title;

       public string Title
       {
           get { return title; }
           set { title = value; OnPropertyChanged();}
       }
        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; OnPropertyChanged(); }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(); }
        }

        private string releaseDate;

        public string ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; OnPropertyChanged(); }
        }

    }
}
