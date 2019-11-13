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
    public partial class BookshelfManager : Form
    {
        public Database database = new Database();

        public BookshelfManager()
        {
            InitializeComponent();
            //create first view
            BookshelfWindow bookshelf = new BookshelfWindow(database);
            bookshelf.MdiParent = this;
            bookshelf.Show();
        }

        private void newBookshelfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookshelfWindow bookshelf = new BookshelfWindow(database);
            bookshelf.MdiParent = this;
            bookshelf.Show();
        }
    }
}
