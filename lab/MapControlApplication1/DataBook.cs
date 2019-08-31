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
    public partial class DataBook : Form
    {
        public DataBook()
        {
            InitializeComponent();
        }

        public DataBook(string sDataName,DataTable dataTable) { 
            //初始化
            InitializeComponent();

            //根据传入的文本框文本和数据源来初始化文本框和数据网络视图
            tbDataName.Text = sDataName;
            DataGridView1.DataSource = dataTable;
            textBox1.Text = dataTable.Rows.Count.ToString();
            
        }

        //public DataBook(string )

        private void DataBook_Load(object sender, EventArgs e)
        {
            
        }
    }
}
