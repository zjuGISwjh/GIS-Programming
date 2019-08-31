using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication1
{


    public partial class Resolution : Form
    {
        public static int num;
        public Resolution() {
            InitializeComponent();
        }

        public int getnum()
        {
                  
            return num;
        }

        private void Resolution_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            num = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
