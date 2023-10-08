using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf
{
    public partial class EmpFrom : Form
    {
        public EmpFrom()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;

            dateTB.Text = now.ToString("d");

            addPanel.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (BAL.InsertEmpTbl(nameTB.Text, dateTB.Text,Convert.ToInt32(salaryTB.Value), Convert.ToInt32(BonusTB.Value), Convert.ToInt32(PenaltyTB.Value)))
            {

                MessageBox.Show("inserted");
                button3.PerformClick();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addPanel.Visible = false;
            GridPanel.Visible = true;
            button5.Enabled = true;
            DataTable dt = BAL.GetEmpTbl();


            dataGridView1.DataSource = dt;


        }
        public void clear() {

            BonusTB.Value = 0;
            PenaltyTB.Value = 0;
            nameTB.Text = "";   
            salaryTB.Value= 0;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            addPanel.Visible = true;
            GridPanel.Visible = false;
            button5.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string message = "سوف يتم حذف هذا السجل";
            string title = "تحذير!! ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            if (!selected.Equals(""))
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        BAL.DelEmpTbl(Convert.ToInt16(selected));
                        button3.PerformClick();
                        selected = "";
                        dataGridView1.SelectedRows.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("يجب اختيار احد السجلات");
                    }
                }
                else
                {

                }
        }
    }
}
