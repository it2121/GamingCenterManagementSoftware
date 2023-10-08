using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class MenuManager : Form
    {
        public MenuManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        DataTable dt;
        public void clear()
        {

            argyNameTB.Text = "";
            argyPriceTB.Text = "";
            argyColorTB.Text = "";

        }
        public void setupDrink()
        {

            dt = BAL.GetDrinks();
            argyDataGrid.DataSource = dt;
            clear();

        }
        public void setupFood()
        {

            dt = BAL.GetFood();
            argyDataGrid.DataSource = dt;
            clear();
        }
        public void setupArgy()
        {
            dt = BAL.GetArgy();
            argyDataGrid.DataSource = dt;
            clear();
        }
        private void drinkCB_CheckedChanged(object sender, EventArgs e)
        {
            if (drinkCB.Checked)
            {
                foodCB.Checked = false;
                argyCB.Checked = false;
                setupDrink();
            }
            else
            {




            }
        }

        private void foodCB_CheckedChanged(object sender, EventArgs e)
        {
            if (foodCB.Checked)
            {
                drinkCB.Checked = false;
                argyCB.Checked = false;
                setupFood();
            }
            else
            {




            }
        }

        private void argyCB_CheckedChanged(object sender, EventArgs e)
        {
            if (argyCB.Checked)
            {
                foodCB.Checked = false;
                drinkCB.Checked = false;
                setupArgy();
            }
            else
            {




            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (drinkCB.Checked)
            {
                if (BAL.InsertDrink(argyNameTB.Text, Convert.ToInt32(argyPriceTB.Text), argyColorTB.Text))
                {

                    MessageBox.Show("inserted");
                    setupDrink();
                }

            }
            else if (foodCB.Checked)
            {
                if (BAL.InsertFood(argyNameTB.Text, Convert.ToInt32(argyPriceTB.Text), argyColorTB.Text))
                {

                    MessageBox.Show("inserted");
                    setupFood();
                }

            }
            else if (argyCB.Checked)
            {

                if (BAL.InsertArgylah(argyNameTB.Text, Convert.ToInt32(argyPriceTB.Text), argyColorTB.Text))
                {

                    MessageBox.Show("inserted");
                    setupArgy();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (drinkCB.Checked)
            {
                string message = "سوف يتم حذف هذا السجل";
                string title = "تحذير!! ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                string selected = argyDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                if (!selected.Equals(""))
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            BAL.DelDrink(Convert.ToInt16(selected));
                            setupDrink();
                            selected = "";
                            argyDataGrid.SelectedRows.Clear();
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
            else if (foodCB.Checked)
            {
                string message = "سوف يتم حذف هذا السجل";
                string title = "تحذير!! ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                string selected = argyDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                if (!selected.Equals(""))
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            BAL.DelFood(Convert.ToInt16(selected));
                            setupFood();
                            selected = "";
                            argyDataGrid.SelectedRows.Clear();
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
            else if (argyCB.Checked)
            {
                string message = "سوف يتم حذف هذا السجل";
                string title = "تحذير!! ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                string selected = argyDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                if (!selected.Equals(""))
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            BAL.DelArgy(Convert.ToInt16(selected));
                            setupArgy();
                            selected = "";
                            argyDataGrid.SelectedRows.Clear();
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
}
