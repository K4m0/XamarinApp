using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Model.Entities.Prueba
{
    public class Attributes
    {
        public class Name
        {
            public string label { get; set; }
        }

        public class Uri
        {
            public string label { get; set; }
        }

        public class Author
        {
            public Name name { get; set; }
            public Uri uri { get; set; }
        }

        public class ImName
        {
            public string label { get; set; }
        }


        public string height { get; set; }


        public class ImImage
        {
            public string label { get; set; }
            public Attributes attributes { get; set; }
        }

        public class Summary
        {
            public string label { get; set; }
        }

        public class Attributes2
        {
            public string amount { get; set; }
            public string currency { get; set; }
        }

        public class ImPrice
        {
            public string label { get; set; }
            public Attributes2 attributes { get; set; }
        }

        public class Attributes3
        {
            public string term { get; set; }
            public string label { get; set; }
        }

        public class ImContentType
        {
            public Attributes3 attributes { get; set; }
        }

        public class Rights
        {
            public string label { get; set; }
        }

        public class Title
        {
            public string label { get; set; }
        }

        public class Attributes4
        {
            public string rel { get; set; }
            public string type { get; set; }
            public string href { get; set; }
        }

        public class Link
        {
            public Attributes4 attributes { get; set; }
        }

        public class Attributes5
        {
            public string id { get; set; }
            public string bundleId { get; set; }
        }

        public class Id
        {
            public string label { get; set; }
            public Attributes5 attributes { get; set; }
        }

        public class Attributes6
        {
            public string href { get; set; }
        }

        public class ImArtist
        {
            public string label { get; set; }
            public Attributes6 attributes { get; set; }
        }

        public class Attributes7
        {
            public string id { get; set; }
            public string term { get; set; }
            public string scheme { get; set; }
            public string label { get; set; }
        }

        public class Category
        {
            public Attributes7 attributes { get; set; }
        }

        public class Attributes8
        {
            public string label { get; set; }
        }

        public class ImReleaseDate
        {
            public string label { get; set; }
            public Attributes8 attributes { get; set; }
        }

        public class Updated
        {
            public string label { get; set; }
        }

        public class Rights2
        {
            public string label { get; set; }
        }

        public class Title2
        {
            public string label { get; set; }
        }

        public class Icon
        {
            public string label { get; set; }
        }

        public class Attributes9
        {
            public string rel { get; set; }
            public string type { get; set; }
            public string href { get; set; }
        }

        public class Link2
        {
            public Attributes9 attributes { get; set; }
        }

        public class Id2
        {
            public string label { get; set; }
        }
    }
}
