using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XamarinExam.Model.Entities.Prueba.Attributes;

namespace XamarinExam.Model.Entities.Prueba
{
    public class Feed
    {
        public Author author { get; set; }
        public List<Entry> entry { get; set; }
        public Updated updated { get; set; }
        public Rights2 rights { get; set; }
        public Title2 title { get; set; }
        public Icon icon { get; set; }
        public List<Link2> link { get; set; }
        public Id2 id { get; set; }
    }
}
