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

        private enum Range { all, before, after}
        
        private Range range = Range.all;

        internal Func<Book, bool> rangePredicate;

        public BookshelfWindow(Database database)
        {
            InitializeComponent();
            this.database = database;
            rangePredicate = b => { return true; };
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

        private void Database_EditBookEvent(Book book)
        {
            if (rangePredicate(book))
            {
                foreach (ListViewItem iter in listView1.Items)
                {
                    if (ReferenceEquals(iter.Tag, book))
                    {
                        UpdateItem(iter);
                        return;
                    }
                }
                //Book was not displayed
                Database_AddBookEvent(book);
                //function used to avoid duplication of code
            }
            else 
            {
                //Book could be displayed and need to be removed
                Database_DeleteBookEvent(book);
            }
            
        }

        private void Database_DeleteBookEvent(Book book)
        {
            foreach (ListViewItem iter in listView1.Items)
            {
                if (ReferenceEquals(iter.Tag, book))
                {
                    listView1.Items.Remove(iter);
                    CountLabel.Text = listView1.Items.Count.ToString();
                    return;
                }
            }
        }

        private void Database_AddBookEvent(Book book)
        {
            if (rangePredicate(book)) 
            {
                ListViewItem item = new ListViewItem();
                item.Tag = book;
                UpdateItem(item);
                listView1.Items.Add(item);
                CountLabel.Text = listView1.Items.Count.ToString();
            }

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

            foreach (Book iter in database.books.Where(rangePredicate))
            {
                ListViewItem item = new ListViewItem();
                item.Tag = iter;
                UpdateItem(item);
                listView1.Items.Add(item);
            }

            CountLabel.Text = listView1.Items.Count.ToString();
        }

        private void BookshelfWindow_Load(object sender, EventArgs e)
        {
            UpdateItems();
            database.AddBookEvent += Database_AddBookEvent;
            database.DeleteBookEvent += Database_DeleteBookEvent;
            database.EditBookEvent += Database_EditBookEvent;
        }

        private void booksAfter2000ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            filterBooks(Range.after);
        }

        private void booksBefore2000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterBooks(Range.before);
        }

        private void allBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterBooks(Range.all);
        }

        private void filterBooks(Range newRange)
        {
            if (range != newRange)
            {
                range = newRange;
                switch(range)
                {
                    default:
                    case Range.all:
                        rangePredicate = b => { return true; };
                        break;
                    case Range.after:
                        rangePredicate = b => { return (b.PublishDate > new DateTime(1999, 12, 31)); };
                        break;
                    case Range.before:
                        rangePredicate = b => { return (b.PublishDate < new DateTime(2000, 1, 1)); };
                        break;
                }
                UpdateItems();
            }
        }

        private void BookshelfWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MdiParent.MdiChildren.Length < 2) && (e.CloseReason == CloseReason.UserClosing))
            {
                e.Cancel = true;
            }
        }

        private void BookshelfWindow_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(WindowStatusStrip, ((BookshelfManager)MdiParent).statusStrip1);
            ToolStripManager.Merge(toolStrip1, ((BookshelfManager)MdiParent).toolStrip1);
        }

        private void BookshelfWindow_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((BookshelfManager)MdiParent).statusStrip1, WindowStatusStrip);
            ToolStripManager.RevertMerge(((BookshelfManager)MdiParent).toolStrip1, toolStrip1);
        }
    }

        
}
