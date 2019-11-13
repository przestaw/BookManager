using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_Lab1
{
    public class Book
    {
        public Book(string title, string author, DateTime publicationDate, BookGenere genere)
        {
            Title = title;
            Author = author;
            PublishDate = publicationDate;
            Genere = genere;
        }

        public string Title
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public DateTime PublishDate
        {
            get;
            set;
        }

        public enum BookGenere { Criminal = 1, Fantasy = 2, Romance = 3};

        public BookGenere Genere
        {
            get;
            set;
        }

        public string StringGenere
        {
            get { return Book.genereToString(this.Genere); }
        }

        public static string genereToString(BookGenere genere)
        {
            switch (genere)
            {
                case BookGenere.Criminal:
                    return "Criminal";
                case BookGenere.Fantasy:
                    return "Fantasy";
                case BookGenere.Romance:
                    return "Romance";
                default:
                    throw new Exception("Invalid Book Genre");
            }
        }
    }
}