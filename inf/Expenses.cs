using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;

            dateTB.Text = now.ToString("d");

            addPanel.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {




        }
        public void clear()
        {

            nameTB.Text = "";

            priceTB.Text = "";
            countTB.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (BAL.InsertExpenses(nameTB.Text, Convert.ToInt32(countTB.Text), Convert.ToInt16(priceTB.Text), dateTB.Text))
            {

                MessageBox.Show("inserted");
                button3.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            addPanel.Visible = true;
            GridPanel.Visible = false;
            button5.Enabled = false;
        }
        DataTable dt;
        DataTable dtStaying;
        private void button3_Click_1(object sender, EventArgs e)
        {
            addPanel.Visible = false;
            GridPanel.Visible = true;
            button5.Enabled = true;
            dt = BAL.GetExpenses();

          
            dataGridView1.DataSource = dt;




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
                        BAL.DelExpenses(Convert.ToInt16(selected));
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
        int from = 0;
        private void calander_DateChanged(object sender, DateRangeEventArgs e)
        {

            if (from == 1)
            {
                fromLbl.Text = calander.SelectionRange.Start.Date + "";

                // calander.Enabled = false;
                from = 0;
            }
            else if (from == 2)
            {
                toLbl.Text = calander.SelectionRange.End.Date + "";

                //  calander.Enabled = false;
                from = 0;
            }

        }

        private void fromBtn_Click(object sender, EventArgs e)
        {
            from = 1;
        }

        private void toBtn_Click(object sender, EventArgs e)
        {
            from = 2;
        }
        int TotalPrice = 0;

        System.Data.DataTable temp ;
        System.Data.DataTable newData;
        private void button8_Click(object sender, EventArgs e)
        {




             temp = BAL.GetExpenses(); ;
            newData = temp;

            TotalPrice = 0;
            // foreach (DataRow r in temp.Rows)
            for (int i = 0; i < temp.Rows.Count; i++)
            {

                if ((System.DateTime.Parse(newData.Rows[i]["ExpDate"].ToString().Trim(), CultureInfo.InvariantCulture) < System.DateTime.Parse(fromLbl.Text, CultureInfo.InvariantCulture)) || (System.DateTime.Parse(newData.Rows[i]["ExpDate"].ToString().Trim(), CultureInfo.InvariantCulture) > System.DateTime.Parse(toLbl.Text, CultureInfo.InvariantCulture)))

                {
                    newData.Rows[i].Delete();



                }


            }
            newData.AcceptChanges();


            temp = newData;



            if (NameOfExpCB.Checked)
            {
                if ((nameOfExp.Text.Length >= 1))
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {

                        if (!newData.Rows[i]["ExpName"].ToString().Equals(nameOfExp.Text))

                        {
                            newData.Rows[i].Delete();



                        }


                    }


                }
                else
                {

                    MessageBox.Show("الرجاء عدك ترك اي حقل فارغ.");
                }

                newData.AcceptChanges();

            }



            temp = newData;
            foreach (DataRow row in newData.Rows)
            {

                TotalPrice += Convert.ToInt32(row["ExpCount"]) * Convert.ToInt32(row["ExpPrice"]);


            }

            totalLabel.Text = TotalPrice.ToString();

            dataGridView1.DataSource = newData;

        }

        private void NameOfExpCB_CheckedChanged(object sender, EventArgs e)
        {
            if (NameOfExpCB.Checked)
            {

                nameOfExp.Visible = true;
                nameOfExp.Text = "";



            }
            else
            {

                nameOfExp.Visible = false;


            }
        }
    }
}
