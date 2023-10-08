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
    public partial class printerSettingForm : Form
    {
        string casherPName = "";
        string kitchenPName = "";

        string casherPState = "";
        string kitchenPState = "";



        public printerSettingForm()
        {
            InitializeComponent();

            /*  string createText = "Hello and Welcome" + Environment.NewLine;
              File.WriteAllText("printer1.txt", createText);*/


            readFromAll();

        }
        public void readFromAll()
        {



            using (StreamReader readtext = new StreamReader("p1.txt"))
            {
                casherPState = readtext.ReadLine();
            }
            using (StreamReader readtext = new StreamReader("p11.txt"))
            {
                casherPName = readtext.ReadLine();
            }

            using (StreamReader readtext = new StreamReader("p2.txt"))
            {
                kitchenPState = readtext.ReadLine();
            }
            using (StreamReader readtext = new StreamReader("p22.txt"))
            {
                kitchenPName = readtext.ReadLine();
            }


            if (casherPState.Equals("1"))
            {

                casherCB.Checked = true;
                CCB();

            }
            if (kitchenPState.Equals("1"))
            {

                kitchenCB.Checked = true;
                KCB();

            }


            if (casherPState.Equals("0"))
            {

                casherCB.Checked = false;
                CCB();

            }
            if (kitchenPState.Equals("0"))
            {

                kitchenCB.Checked = false;
                KCB();

            }

            casherPrinterTB.Text = casherPName;
            printerCasherNameLbl.Text = casherPName;
            kitchenPrinterTB.Text = kitchenPName;
            printerrkitchenNameLbl.Text = kitchenPName;


        }
        public void writeToFile(string txt, string textFile, int line)
        {


            using (StreamWriter writetext = new StreamWriter(textFile))
            {
                writetext.WriteLine(txt);
            }



        }
        public void CCB()
        {
            if (casherCB.Checked)
            {

                casherCB.ForeColor = Color.Lime;


                casherCB.Parent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));


                casherPrinterTB.Enabled = true;
                casherPrinterBtn.Enabled = true;

                WriterToFile("p1.txt","1");




            }
            else
            {
                casherCB.ForeColor = Color.Black;
                casherCB.Parent.BackColor = Color.Gray;
                casherPrinterTB.Enabled = false;
                casherPrinterBtn.Enabled = false;

                WriterToFile("p1.txt", "0");
            }
        }
        public void KCB()
        {
            if (kitchenCB.Checked)
            {

                kitchenCB.ForeColor = Color.Lime;


                kitchenCB.Parent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));


                kitchenPrinterTB.Enabled = true;
                kitchenPrinterBtn.Enabled = true;

                WriterToFile("p2.txt", "1");



            }
            else
            {
                kitchenCB.ForeColor = Color.Black;
                kitchenCB.Parent.BackColor = Color.Gray;
                kitchenPrinterTB.Enabled = false;
                kitchenPrinterBtn.Enabled = false;

                WriterToFile("p2.txt", "0");
            }
        }
        private void kitechnCB_CheckedChanged(object sender, EventArgs e)
        {
            CCB();
        }

        private void kitchenCB_CheckedChanged(object sender, EventArgs e)
        {
            KCB();
         

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void WriterToFile(string file,string txt) {

            using (StreamWriter writetext = new StreamWriter(file))
            {
                writetext.WriteLine(txt);
            }
         

        }
        private void casherPrinterBtn_Click(object sender, EventArgs e)
        {
            WriterToFile("p11.txt",casherPrinterTB.Text) ;
            readFromAll();
        }


        private void kitchenPrinterBtn_Click(object sender, EventArgs e)
        {
            WriterToFile("p22.txt", kitchenPrinterTB.Text);
            readFromAll();
        }
    }
}
