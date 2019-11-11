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
        }

        private void newBookshelfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookshelfWindow bookshelf = new BookshelfWindow();
            bookshelf.MdiParent = this;
            bookshelf.Show();
        }
    }
}
