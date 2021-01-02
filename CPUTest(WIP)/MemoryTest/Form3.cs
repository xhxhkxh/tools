using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void Form3_MouseEnter(object sender, EventArgs e)
        {
            Random r = new Random();
            Point p = new Point(r.Next(0,500), r.Next(0,500));
            this.Location = p;
        }
    }
}
