using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Model.Entities.Prueba
{
    public class Entry
    {
        public Attributes.ImName imname { get; set; }
        public List<Attributes.ImImage> imimage { get; set; }
        public Attributes.Summary summary { get; set; }
        public Attributes.ImPrice imprice { get; set; }
        public Attributes.ImContentType imcontentType { get; set; }
        public Attributes.Rights rights { get; set; }
        public Attributes.Title title { get; set; }
        public Attributes.Link link { get; set; }
        public Attributes.Id id { get; set; }
        public Attributes.ImArtist imartist { get; set; }
        public Attributes.Category category { get; set; }
        public Attributes.ImReleaseDate imreleaseDate { get; set; }
    }
}
