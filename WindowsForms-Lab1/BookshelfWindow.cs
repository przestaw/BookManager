using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab1
{
    public partial class BookshelfWindow : Form
    {
        private Database database;

        public BookshelfWindow(Database database)
        {
            InitializeComponent();
            this.database = database;
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(null, database.books);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                Book newBook = new Book(bookForm.Title, bookForm.Author, bookForm.PublishDate, bookForm.BookGenere);

                database.addBook(newBook);
            }
        }

        private void editContextMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Book book = (Book)listView1.SelectedItems[0].Tag;
                BookForm bookForm = new BookForm(book, database.books);
                if (bookForm.ShowDialog() == DialogResult.OK)
                {
                    book.Author = bookForm.Author;
                    book.Title = bookForm.Title;
                    book.PublishDate = bookForm.PublishDate;
                    book.Genere = bookForm.BookGenere;

                    database.updateBook(book);
                }
            }
        }

        private void deleteContextMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem iter in listView1.SelectedItems)
                    database.deleteBook((Book)iter.Tag);
            }
        }

        private void Database_EditBookEvent(Book obj)
        {
            foreach (ListViewItem iter in listView1.Items)
            {
                if (ReferenceEquals(iter.Tag, obj)) 
                {
                    UpdateItem(iter);
                    break;
                }
            }
        }

        private void Database_DeleteBookEvent(Book obj)
        {
            foreach (ListViewItem iter in listView1.Items)
            {
                if (ReferenceEquals(iter.Tag, obj))
                {
                    listView1.Items.Remove(iter);
                    break;
                }
            }
        }

        private void Database_AddBookEvent(Book book)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = book;
            UpdateItem(item);
            listView1.Items.Add(item);
        }

        private void UpdateItem(ListViewItem item)
        {
            Book book = (Book)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = book.Title;
            item.SubItems[1].Text = book.Author;
            item.SubItems[2].Text = book.PublishDate.ToShortDateString();
            item.SubItems[3].Text = book.StringGenere;
        }

        private void UpdateItems()
        {
            listView1.Items.Clear();
            foreach (Book iter in database.books)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = iter;
                UpdateItem(item);
                listView1.Items.Add(item);
            }
        }

        private void BookshelfWindow_Load(object sender, EventArgs e)
        {
            UpdateItems();
            database.AddBookEvent += Database_AddBookEvent;
            database.DeleteBookEvent += Database_DeleteBookEvent;
            database.EditBookEvent += Database_EditBookEvent;
        }
    }

        
}
