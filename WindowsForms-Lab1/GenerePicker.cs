using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab1
{
    public partial class GenerePicker : UserControl
    {
        public GenerePicker()
        {
            genere = Book.BookGenere.Criminal;
            InitializeComponent();
            image.BackgroundImage = Properties.Resources.crime;
            image.Invalidate();
        }
        public GenerePicker(Book.BookGenere genere)
        {
            this.genere = genere;
            InitializeComponent();
            switch (genere)
            {
                case Book.BookGenere.Fantasy:
                    image.BackgroundImage = Properties.Resources.fantasy;
                    break;
                case Book.BookGenere.Romance:
                    image.BackgroundImage = Properties.Resources.hearts;
                    break;
                case Book.BookGenere.Criminal:
                    image.BackgroundImage = Properties.Resources.crime;
                    break;
            }
            image.Invalidate();
        }

        private Book.BookGenere genere;

        public event Action<Book.BookGenere> propertyChange;
        private void image_Click(object sender, EventArgs e)
        {
            switch (genere)
            {
                case Book.BookGenere.Criminal:
                    changeGenere(Book.BookGenere.Fantasy);
                    break;
                case Book.BookGenere.Fantasy:
                    changeGenere(Book.BookGenere.Romance);
                    break;
                case Book.BookGenere.Romance:
                    changeGenere(Book.BookGenere.Criminal);
                    break;
            }
        }

        private void changeGenere(Book.BookGenere newGenere)
        { 
            if(genere != newGenere)
            {
                switch (newGenere)
                {
                    case Book.BookGenere.Fantasy:
                        genere = Book.BookGenere.Fantasy;
                        image.BackgroundImage = Properties.Resources.fantasy;
                        break;
                    case Book.BookGenere.Romance:
                        genere = Book.BookGenere.Romance;
                        image.BackgroundImage = Properties.Resources.hearts;
                        break;
                    case Book.BookGenere.Criminal:
                        genere = Book.BookGenere.Criminal;
                        image.BackgroundImage = Properties.Resources.crime;
                        break;
                }
                image.Invalidate();
                propertyChange?.Invoke(genere);
            }
        }

        public string GenereString
        {
            get { return genere.ToString(); }
        }

        [EditorAttribute(typeof(GenereEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Book Genere")]
        [BrowsableAttribute(true)]
        public Book.BookGenere Genere 
        {
            get
            {
                return genere;
            }
            set
            {
                changeGenere(value);
            }
        }
    }
}
