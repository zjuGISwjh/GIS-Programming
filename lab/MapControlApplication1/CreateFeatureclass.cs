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
    public partial class CreateFeatureclass : Form
    {
        public MainForm m_frmMain;
        public CreateFeatureclass()
        {
            InitializeComponent();
        }

        public CreateFeatureclass(MainForm frm) {
            InitializeComponent();
            if (frm != null) {
                m_frmMain = frm;
            }
        }
        public static string sname;
        public static string sshape;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sname = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sshape = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
    }
}
