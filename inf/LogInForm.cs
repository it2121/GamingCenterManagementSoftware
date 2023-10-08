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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            this.AcceptButton = button1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = BAL.GetPasswords().Rows[0][1].ToString();

            if (textBox1.Text.Equals(password))
            {

                if (BAL.PasswordFormSelector == 1)
                {

                    Filters filter = new Filters();

                    filter.Show();

                }
                else if (BAL.PasswordFormSelector == 2) {

                    EmpFrom emp = new EmpFrom();

                    emp.Show();

                }
                else if (BAL.PasswordFormSelector == 3)
                {

                    Expenses expenses = new Expenses();

                    expenses.Show();

                }
                this.Close();

            }
            else {

                MessageBox.Show("Password is incorrect");
            }

        }
    }
}
