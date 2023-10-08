using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();

        


            dataGridView1.DataSource = BAL.Log;
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = (textBox1.Text);

           // (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID='{0}'", textBox1.Text);

         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
