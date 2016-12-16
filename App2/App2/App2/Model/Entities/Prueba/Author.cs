using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XamarinExam.Model.Entities.Prueba.Attributes;

namespace XamarinExam.Model.Entities.Prueba
{
    public class Author
    {
        public Name name { get; set; }
        public Attributes.Uri uri { get; set; }
    }
}
