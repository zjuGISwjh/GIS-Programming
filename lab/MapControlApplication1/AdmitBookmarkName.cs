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

    public partial class AdmitBookmarkName : Form
    {
        //save the MainForm
        public MainForm m_frmMain;
        
        public AdmitBookmarkName(MainForm  frm)
        {
            InitializeComponent();
            if (frm != null) {
                m_frmMain = frm;
            }
        }

        private void AdmitBookmarkName_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdimit_Click(object sender, EventArgs e)
        {
            if (m_frmMain != null || tbBookmarkname.Text == "") {

                m_frmMain.CreateBookmark(tbBookmarkname.Text);
            }
            this.Close();
        }
    }
}
