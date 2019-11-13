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
    public partial class PicturePicker : UserControl
    {
        public PicturePicker()
        {
            InitializeComponent();
            option = 0;
        }

        private int option;
        public int Option 
        {
            get { return option; }
            set 
            { 
                if (value > 0 && value <= 3) 
                {//to also invoke propertyChange 
                    changeOption(value); 
                } 
            }
        }

        public event Action<int> propertyChange;

        private void changeOption(int newOption) 
        {
            if (option != newOption) 
            {
                option = newOption;
                propertyChange?.Invoke(newOption);
            }
        }

        private void Option1_Click(object sender, EventArgs e)
        {
            changeOption(1);
        }

        private void Option2_Click(object sender, EventArgs e)
        {
            changeOption(2);
        }

        private void Option3_Click(object sender, EventArgs e)
        {
            changeOption(3);
        }
        public Image Option1_Image
        {
            get { return Option1.BackgroundImage; }
            set { Option1.BackgroundImage = value; }
        }
        public Image Option2_Image
        {
            get { return Option2.BackgroundImage; }
            set { Option2.BackgroundImage = value; }
        }
        public Image Option3_Image
        {
            get { return Option3.BackgroundImage; }
            set { Option3.BackgroundImage = value; }
        }

        public string DisplayedText 
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }        
        }
    }
}
