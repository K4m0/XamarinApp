using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using XamarinExam.ViewModels;

namespace XamarinExam.Model.Entities
{
    [DataTable("Book")]
    public class Book : ObservableItem, IMaterial
    {

        [JsonProperty]
        public string id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Publisher { get; set; }

        [JsonProperty]
        public string PublishDate { get; set; }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged(); }
        }

     
    }
}
