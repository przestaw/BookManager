using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab1
{
    public class Book
    {
        public string Title
        {
            get;
            set;
        }

        public long Author
        {
            get;
            set;
        }

        public DateTime PublicationDate
        {
            get;
            set;
        }

        public enum Genere { criminal, fantasy, romance};

        public Genere genere
        {
            get;
            set;
        }
    }
}