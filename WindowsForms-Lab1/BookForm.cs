using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab1
{
    public partial class BookForm : Form
    {
        private Book book;
        private List<Book> bookList;

        public BookForm(Book book, List<Book> bookList)
        {
            InitializeComponent();
            this.book = book;
            this.bookList = bookList;
            picturePicker1.propertyChange += GenerePrinter;
        }

        public string Title
        {
            get { return titleTextBox.Text; }
        }

        public string Author
        {
            get { return authorTextBox.Text; }
        }

        public DateTime PublishDate
        {
            get { return dateTimePicker.Value; }
        }

        public Book.BookGenere BookGenere
        {
            get 
            {//already validated
                return (Book.BookGenere)picturePicker1.Option;
            }
        }

        private void GenerePrinter(int option) 
        {
            switch(option)
            {
                case 0:
                    picturePicker1.DisplayedText = "Pick a Genre !";
                    break;
                case 1:
                    picturePicker1.DisplayedText = "Criminal";
                    break;
                case 2:
                    picturePicker1.DisplayedText = "Fantasy";
                    break;
                case 3:
                    picturePicker1.DisplayedText = "Romance";
                    break;
            }
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (book != null)
            {
                titleTextBox.Text = book.Title;
                authorTextBox.Text = book.Author;
                dateTimePicker.Value = book.PublishDate;
                picturePicker1.Option = (int)book.Genere;
            }
            else 
            {
                authorTextBox.Text = "Anonim";
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void titleTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(titleTextBox, "");
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string currentTitle = titleTextBox.Text;
                if (!Regex.IsMatch(currentTitle, ".*?[a-zA-Z].*?"))
                    throw new Exception("Book must have a title");
                foreach (Book iter in bookList)
                    if (iter.Title == currentTitle && !ReferenceEquals(book, iter))
                        throw new Exception("Book with this title exists");
            }
            catch (Exception except)
            {
                e.Cancel = true;
                errorProvider1.SetError(titleTextBox, except.Message);
            }
        }

        private void picturePicker1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(picturePicker1, "");
        }

        private void picturePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (picturePicker1.Option == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(picturePicker1, "You must pick a Genere");
            }
        }
    }
}
