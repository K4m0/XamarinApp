using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.ViewModels;

namespace XamarinExam.Model.Entities
{
    public class Magazine : ObservableItem, IMaterial
    {

        public string id { get; set; }

        public string Name { get; set; }

        public string PublishDate { get; set; }

        public string Publisher { get; set; }

        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}
