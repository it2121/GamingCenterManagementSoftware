using ESC_POS_USB_NET.Printer;
using ImageMagick;
using inf.Properties;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Rectangle = iTextSharp.text.Rectangle;
using Font = iTextSharp.text.Font;
using DocumentFormat.OpenXml.Bibliography;

namespace inf
{
    public partial class MainForm : Form
    {
        /*  List<Button> buttonsList = new List<Button>();X
          List<Label> labelList = new List<Label>();  */

        Printer printer;

        Printer Kprinter;
        bool firstPrint = false;
        bool secondPrint = false;
        bool thirdPrint = false;
        bool casherPState = false;
        bool kitchenPState = false;
        string casherPName = "";
        string kitchenPName = "";
        bool ordertableBOOL = false;
        bool argytableBOOL = false;
        bool MainTableBOOL = false;
        bool printFromEdit = false;


        bool drinkIsSet = false;
        bool foodISSet = false;

        List<List<int>> OrdersRow = new List<List<int>>();


        List<int> TableOrder = new List<int>();

        int numberOfRows = 0;


        List<Label> LabelsList = new List<Label>();
        List<System.Windows.Forms.TextBox> AmountsList = new List<System.Windows.Forms.TextBox>();


        List<List<int>> DrinksOrders = new List<List<int>>();
        List<int> DrinkID = new List<int>();
        List<int> DrinkAmount = new List<int>();



        List<List<int>> FoodOrders = new List<List<int>>();



        List<int> FoodID = new List<int>();
        List<int> FoodAmount = new List<int>();


        List<List<int>> FArgyOrders = new List<List<int>>();



        List<int> ArgyID = new List<int>();
        List<int> ArgyAmount = new List<int>();

        int DrinkIDint = -1;
        int DrinkAmountint = 0;

        int FoodIDint = -1;
        int FoodAmountint = 0;


        int ArgyIDint = -1;
        int ArgyAmountint = 0;

        public MainForm()
        {
            InitializeComponent();



            ReadPrintersStatsAndNames();
            printer = new Printer(casherPName);
            Kprinter = new Printer(kitchenPName);
            // printCB.Checked = true;
            // kitchenCB.Checked = true;
        }
        public void ReadPrintersStatsAndNames()
        {



            using (StreamReader readtext = new StreamReader("p1.txt"))
            {
                string casherPStateS = readtext.ReadLine();
                if (casherPStateS.Equals("1"))
                {

                    casherPState = true;
                    // MessageBox.Show("haso");

                }
            }
            using (StreamReader readtext = new StreamReader("p11.txt"))
            {
                casherPName = readtext.ReadLine();



            }

            using (StreamReader readtext = new StreamReader("p2.txt"))
            {
                string kitchenPStateS = readtext.ReadLine();

                if (kitchenPStateS.Equals("1"))
                {

                    kitchenPState = true;

                    // MessageBox.Show("haso al7low ");

                }
            }
            using (StreamReader readtext = new StreamReader("p22.txt"))
            {
                kitchenPName = readtext.ReadLine();

            }










        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FloorLayout fl = new FloorLayout();

            var dialogResult = fl.ShowDialog();




            if (BAL.TableName.Length > 0)
            {
                clearAddPanel();
                button11.Enabled = true;
                button16.Enabled = true;
                DateTime now = DateTime.Now;
                TableOrder.Add(BAL.TableID);

                TimeAndDateLabel.Text = now.ToString("d") + " - " + now.ToString("t");
                tableIdLabel.Text = BAL.TableID + "";
                if (!(BAL.TableID == 0))
                {
                    if (BAL.TableName.Equals("البلي") || BAL.TableName.Equals("VR") || BAL.TableName.Equals("الستيرن") || BAL.TableName.Equals("السينما"))
                    {

                        ResDurLbl.Text = "0:30";
                        timeInMinits = 30;
                        timeAsIntM = 30;

                        if (BAL.TableName.Equals("VR"))
                        {

                            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (3000)).ToString();

                        }
                        else if (BAL.TableName.Equals("الستيرن"))
                        {
                            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (2000)).ToString();


                        }
                        else if (BAL.TableName.Equals("السينما"))
                        {
                            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (4000)).ToString();


                        }
                        else
                        {
                            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (2000)).ToString();


                        }
                    }

                    TabelLabelName.Text = "رقم " + BAL.TableName;
                }
                else
                {
                    TabelLabelName.Text = BAL.TableName;

                }

                if (BAL.TableName.Equals("الطاولة") || BAL.TableName.Equals("الفيشة") || BAL.TableName.Equals("البليارد") || BAL.TableName.Equals("طلب خارجي"))
                {

                    button11.Enabled = false;
                    button16.Enabled = false;
                    timeInMinits = 0;

                }

                AddPanel.Visible = true;
                View.Visible = false;
                timerPanel.Visible = false;
                FinisedTimerPanel.Visible = false;
                finishedClearButtonPanel.Visible = false;


            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool isFirst = true;
        int OrderRowPanelCounter = 0;
        FlowLayoutPanel Row;
        int addedLast = 0;
        int addedFirst = 0;
        int RowRemovalCounter = 0;

        public void drinksRowGenerator()
        {

            if (isFirst)
            {

                //  DrinkID.Add(BAL.DrinkIDHolder);


                isFirst = false;
                addedFirst = 1;

            }
            else
            {
                //  DrinkAmount.Add(DrinkAmountint);


            }
            RowRemovalCounter++;
            DrinkAmountint = 0;
            Row = new FlowLayoutPanel();
            OrderRowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;

            Row.Width = OrderRowPanel.Width - 10;
            //Row.SuspendLayout();


            Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            Row.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //   Row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)));


            System.Windows.Forms.Button PickADrink = new System.Windows.Forms.Button();
            PickADrink.BackColor = Color.White;


            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            PickADrink.Location = new System.Drawing.Point(3, 3);

            PickADrink.Size = new System.Drawing.Size(84, 68);
            PickADrink.TabIndex = 1;
            PickADrink.Text = "تعديل";
            PickADrink.UseVisualStyleBackColor = true;
            PickADrink.ForeColor = Color.White;
            PickADrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            PickADrink.BackColor = System.Drawing.Color.Transparent;
            PickADrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            PickADrink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PickADrink.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PickADrink.Location = new System.Drawing.Point(3, 3);
            PickADrink.Size = new System.Drawing.Size(200, 80);

            PickADrink.UseVisualStyleBackColor = false;

            PickADrink.Click += new System.EventHandler(this.PickADrink_Click);







            /* Button DoneOrder = new Button();
             DoneOrder.Text = "Add a drink";
             DoneOrder.BackColor = Color.White;


             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

             DoneOrder.Location = new System.Drawing.Point(3, 3);

             DoneOrder.Size = new System.Drawing.Size(84, 68);
             DoneOrder.TabIndex = 1;
             DoneOrder.Text = "Done ";
             DoneOrder.UseVisualStyleBackColor = true;
             DoneOrder.ForeColor = Color.White;
             DoneOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
             DoneOrder.BackColor = System.Drawing.Color.Transparent;
             DoneOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
             DoneOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
             DoneOrder.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
             DoneOrder.Location = new System.Drawing.Point(3, 3);
             DoneOrder.Size = new System.Drawing.Size(200, 80);

             DoneOrder.UseVisualStyleBackColor = false;

             DoneOrder.Click += new System.EventHandler(this.Done_Click);*/

            Label l = new Label();
            l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            l.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(938, 0);

            l.Size = new System.Drawing.Size(272, 46);
            l.TextAlign = ContentAlignment.MiddleCenter;



            System.Windows.Forms.TextBox amount = new System.Windows.Forms.TextBox();
            amount.Text = "1";
            amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            amount.Font = new System.Drawing.Font("Lotus Linotype", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            amount.ForeColor = System.Drawing.Color.White;
            amount.BackColor = System.Drawing.Color.DarkGray;
            amount.ReadOnly = true;


            amount.TextAlign = HorizontalAlignment.Center;


            // Row.FlowDirection = FlowDirection.RightToLeft;
            System.Windows.Forms.Button add = new System.Windows.Forms.Button();
            add.Text = "+";
            add.BackColor = Color.White;


            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            add.Location = new System.Drawing.Point(3, 3);

            add.Size = new System.Drawing.Size(84, 68);
            add.TabIndex = 1;

            add.UseVisualStyleBackColor = true;
            add.ForeColor = Color.White;
            add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            add.BackColor = System.Drawing.Color.Transparent;
            add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            add.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            add.Location = new System.Drawing.Point(3, 3);
            add.Size = new System.Drawing.Size(200, 80);

            add.UseVisualStyleBackColor = false;

            add.Click += new System.EventHandler(this.add_Click);

            System.Windows.Forms.Button sub = new System.Windows.Forms.Button();
            sub.Text = "-";
            sub.BackColor = Color.White;


            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            sub.Location = new System.Drawing.Point(3, 3);

            sub.Size = new System.Drawing.Size(84, 68);
            sub.TabIndex = 1;

            sub.UseVisualStyleBackColor = true;
            sub.ForeColor = Color.White;
            sub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            sub.BackColor = System.Drawing.Color.Transparent;
            sub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            sub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sub.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            sub.Location = new System.Drawing.Point(3, 3);
            sub.Size = new System.Drawing.Size(200, 80);

            sub.UseVisualStyleBackColor = false;

            sub.Click += new System.EventHandler(this.sub_Click);




            //   Row.Dock = DockStyle.Top;


            // labelList.Add(l);
            //  buttonsList.Add(PickADrink);

            l.AutoSize = false;

            l.Text = "0";


            LabelsList.Add(l);
            AmountsList.Add(amount);




            Label pl = new Label();
            pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pl.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pl.ForeColor = System.Drawing.Color.White;
            pl.Location = new System.Drawing.Point(938, 0);

            pl.Size = new System.Drawing.Size(272, 46);
            pl.TextAlign = ContentAlignment.MiddleCenter;


            pl.AutoSize = false;

            pl.Text = "0";






            System.Windows.Forms.Button removeRow = new System.Windows.Forms.Button();
            removeRow.BackColor = Color.White;


            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            removeRow.Location = new System.Drawing.Point(3, 3);

            removeRow.Size = new System.Drawing.Size(84, 68);
            removeRow.TabIndex = 1;
            removeRow.Text = "حذف";
            removeRow.UseVisualStyleBackColor = true;
            removeRow.ForeColor = Color.White;
            removeRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            removeRow.BackColor = System.Drawing.Color.Transparent;
            removeRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            removeRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            removeRow.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeRow.Location = new System.Drawing.Point(3, 3);
            removeRow.Size = new System.Drawing.Size(200, 80);

            removeRow.UseVisualStyleBackColor = false;

            removeRow.Click += new System.EventHandler(this.removeRowF_Click);
            //  removeRow.AutoSize = true;
            removeRow.ForeColor = System.Drawing.Color.Pink;





            System.Windows.Forms.LinkLabel hiddinlabel = new System.Windows.Forms.LinkLabel();
            hiddinlabel.Text = "1";
            hiddinlabel.Visible = false;
            hiddinlabel.Size = new System.Drawing.Size(20, 20);


            Row.Controls.Add(hiddinlabel);
            Row.Controls.Add(PickADrink);
            Row.Controls.Add(LabelsList.Last());
            Row.Controls.Add(AmountsList.Last());
            Row.Controls.Add(add);
            Row.Controls.Add(sub);
            Row.Controls.Add(pl);
            Row.Controls.Add(removeRow);

            OrderRowPanel.Controls.Add(Row);



            addedLast = 1;




        }

        List<int> Prices = new List<int>();

        private void removeRowA_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;





            btn.Parent.Parent.Controls.Remove(btn.Parent);

            int amount = 0;
            bool first = true;
            int pr = 0;
            foreach (Control pp in btn.Parent.Controls)
            {
                if (pp is System.Windows.Forms.Label && !(pp is LinkLabel))
                {
                    if (first)
                    {
                        first = false;

                    }
                    else
                    {

                        pr = Convert.ToInt16(pp.Text);
                    }

                }
                if (pp is System.Windows.Forms.TextBox)
                {
                    amount = Convert.ToInt16(pp.Text);
                }
            }



            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (pr * amount)).ToString();






        }




        private void removeRowFF_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;





            btn.Parent.Parent.Controls.Remove(btn.Parent);

            int amount = 0;
            bool first = true;
            int pr = 0;
            foreach (Control pp in btn.Parent.Controls)
            {
                if (pp is System.Windows.Forms.Label && !(pp is LinkLabel))
                {
                    if (first)
                    {
                        first = false;

                    }
                    else
                    {

                        pr = Convert.ToInt16(pp.Text);
                    }

                }
                if (pp is System.Windows.Forms.TextBox)
                {
                    amount = Convert.ToInt16(pp.Text);
                }
            }



            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (pr * amount)).ToString();





        }



        private void removeRowF_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;





            btn.Parent.Parent.Controls.Remove(btn.Parent);

            int amount = 0;
            bool first = true;
            int pr = 0;
            foreach (Control pp in btn.Parent.Controls)
            {
                if (pp is System.Windows.Forms.Label && !(pp is LinkLabel))
                {
                    if (first)
                    {
                        first = false;

                    }
                    else
                    {

                        pr = Convert.ToInt16(pp.Text);
                    }

                }
                if (pp is System.Windows.Forms.TextBox)
                {
                    amount = Convert.ToInt16(pp.Text);
                }
            }



            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (pr * amount)).ToString();




        }




        private void add_Click(object sender, EventArgs e)
        {



            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;

            bool first = true;
            int pr = 0;
            foreach (Control p in btn.Parent.Controls)
                if (p is System.Windows.Forms.TextBox)
                {
                    p.Text = (Convert.ToInt16(p.Text) + 1) + "";
                }
            foreach (Control pp in btn.Parent.Controls)
                if (pp is System.Windows.Forms.Label && !(pp is LinkLabel))
                {
                    if (first)
                    {
                        first = false;

                    }
                    else
                    {

                        pr = Convert.ToInt16(pp.Text);
                    }

                }
            TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (pr)).ToString();
        }
        private void sub_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;


            bool first = true;
            int pr = 0;
            bool overzero = true;
            foreach (Control p in btn.Parent.Controls)
                if (p is System.Windows.Forms.TextBox)
                {
                    if (Convert.ToInt16(p.Text) > 0)
                    {
                        p.Text = (Convert.ToInt16(p.Text) - 1) + "";

                    }
                    else
                    {
                        overzero = false;
                    }
                }
            if (overzero)
            {
                foreach (Control pp in btn.Parent.Controls)
                    if (pp is System.Windows.Forms.Label && !(pp is LinkLabel))
                    {
                        if (first)
                        {
                            first = false;

                        }
                        else
                        {

                            pr = Convert.ToInt16(pp.Text);
                        }

                    }

                TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (pr)).ToString();
            }
        }


        public void foodRowGenerator()
        {


            if (isFirst)
            {

                //  DrinkID.Add(BAL.DrinkIDHolder);


                isFirst = false;
                addedFirst = 2;
            }
            else
            {
                //  FoodAmount.Add(FoodAmountint);


            }
            FoodAmountint = 0;
            RowRemovalCounter++;
            Row = new FlowLayoutPanel();
            OrderRowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;

            Row.Width = OrderRowPanel.Width - 10;
            //Row.SuspendLayout();


            Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            Row.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //   Row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)));


            System.Windows.Forms.Button PickADrink = new System.Windows.Forms.Button();
            PickADrink.BackColor = Color.White;


            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            PickADrink.Location = new System.Drawing.Point(3, 3);

            PickADrink.Size = new System.Drawing.Size(84, 68);
            PickADrink.TabIndex = 1;
            PickADrink.Text = "تعديل";
            PickADrink.UseVisualStyleBackColor = true;
            PickADrink.ForeColor = Color.White;
            PickADrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            PickADrink.BackColor = System.Drawing.Color.Transparent;
            PickADrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            PickADrink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PickADrink.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PickADrink.Location = new System.Drawing.Point(3, 3);
            PickADrink.Size = new System.Drawing.Size(200, 80);

            PickADrink.UseVisualStyleBackColor = false;

            PickADrink.Click += new System.EventHandler(this.PickADrink_Click);







            /* Button DoneOrder = new Button();
             DoneOrder.Text = "Add a drink";
             DoneOrder.BackColor = Color.White;


             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

             DoneOrder.Location = new System.Drawing.Point(3, 3);

             DoneOrder.Size = new System.Drawing.Size(84, 68);
             DoneOrder.TabIndex = 1;
             DoneOrder.Text = "Done ";
             DoneOrder.UseVisualStyleBackColor = true;
             DoneOrder.ForeColor = Color.White;
             DoneOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
             DoneOrder.BackColor = System.Drawing.Color.Transparent;
             DoneOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
             DoneOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
             DoneOrder.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
             DoneOrder.Location = new System.Drawing.Point(3, 3);
             DoneOrder.Size = new System.Drawing.Size(200, 80);

             DoneOrder.UseVisualStyleBackColor = false;

             DoneOrder.Click += new System.EventHandler(this.Done_Click);*/

            Label l = new Label();
            l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            l.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(938, 0);

            l.Size = new System.Drawing.Size(272, 46);
            l.TextAlign = ContentAlignment.MiddleCenter;



            System.Windows.Forms.TextBox amount = new System.Windows.Forms.TextBox();
            amount.Text = "1";
            amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            amount.Font = new System.Drawing.Font("Lotus Linotype", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            amount.ForeColor = System.Drawing.Color.White;
            amount.BackColor = System.Drawing.Color.DarkGray;
            amount.ReadOnly = true;


            amount.TextAlign = HorizontalAlignment.Center;


            // Row.FlowDirection = FlowDirection.RightToLeft;
            System.Windows.Forms.Button add = new System.Windows.Forms.Button();
            add.Text = "+";
            add.BackColor = Color.White;


            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            add.Location = new System.Drawing.Point(3, 3);

            add.Size = new System.Drawing.Size(84, 68);
            add.TabIndex = 1;

            add.UseVisualStyleBackColor = true;
            add.ForeColor = Color.White;
            add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            add.BackColor = System.Drawing.Color.Transparent;
            add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            add.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            add.Location = new System.Drawing.Point(3, 3);
            add.Size = new System.Drawing.Size(200, 80);

            add.UseVisualStyleBackColor = false;

            add.Click += new System.EventHandler(this.add_Click);

            System.Windows.Forms.Button sub = new System.Windows.Forms.Button();
            sub.Text = "-";
            sub.BackColor = Color.White;


            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            sub.Location = new System.Drawing.Point(3, 3);

            sub.Size = new System.Drawing.Size(84, 68);
            sub.TabIndex = 1;

            sub.UseVisualStyleBackColor = true;
            sub.ForeColor = Color.White;
            sub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            sub.BackColor = System.Drawing.Color.Transparent;
            sub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            sub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sub.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            sub.Location = new System.Drawing.Point(3, 3);
            sub.Size = new System.Drawing.Size(200, 80);

            sub.UseVisualStyleBackColor = false;

            sub.Click += new System.EventHandler(this.sub_Click);




            //   Row.Dock = DockStyle.Top;


            // labelList.Add(l);
            //  buttonsList.Add(PickADrink);

            l.AutoSize = false;

            l.Text = "0";

            Label pl = new Label();
            pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pl.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pl.ForeColor = System.Drawing.Color.White;
            pl.Location = new System.Drawing.Point(938, 0);

            pl.Size = new System.Drawing.Size(272, 46);
            pl.TextAlign = ContentAlignment.MiddleCenter;


            pl.AutoSize = false;

            pl.Text = "0";












            System.Windows.Forms.Button removeRow = new System.Windows.Forms.Button();
            removeRow.BackColor = Color.White;


            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            removeRow.Location = new System.Drawing.Point(3, 3);

            removeRow.Size = new System.Drawing.Size(84, 68);
            removeRow.TabIndex = 1;
            removeRow.Text = "حذف";
            removeRow.UseVisualStyleBackColor = true;
            removeRow.ForeColor = Color.White;
            removeRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            removeRow.BackColor = System.Drawing.Color.Transparent;
            removeRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            removeRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            removeRow.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeRow.Location = new System.Drawing.Point(3, 3);
            removeRow.Size = new System.Drawing.Size(200, 80);

            removeRow.UseVisualStyleBackColor = false;

            removeRow.Click += new System.EventHandler(this.removeRowFF_Click);
            //  removeRow.AutoSize = true;
            removeRow.ForeColor = System.Drawing.Color.Pink;





            LabelsList.Add(l);
            AmountsList.Add(amount);



            System.Windows.Forms.LinkLabel hiddinlabel = new System.Windows.Forms.LinkLabel();
            hiddinlabel.Text = "2";
            hiddinlabel.Visible = false;
            hiddinlabel.Size = new System.Drawing.Size(20, 20);



            Row.Controls.Add(hiddinlabel);
            Row.Controls.Add(PickADrink);
            Row.Controls.Add(LabelsList.Last());
            Row.Controls.Add(AmountsList.Last());
            Row.Controls.Add(add);
            Row.Controls.Add(sub);
            Row.Controls.Add(pl);
            Row.Controls.Add(removeRow);


            OrderRowPanel.Controls.Add(Row);



            addedLast = 2;









        }
        private void button14_Click(object sender, EventArgs e)
        {

            BAL.AddedLast = 2;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();
            if (BAL.dataEnterdByMenu)
            {

                numberOfRows++;
                foodrowcounter++;
                int u = BAL.FoodIDHolderList.Count;

                for (int i = 0; i < u; i++)
                {
                    bool first = true;

                    foodRowGenerator();

                    FoodID.Add(BAL.FoodIDHolderList.Last());

                    foreach (Control p in Row.Controls)
                    {
                        if (p is Label && !(p is LinkLabel))
                        {
                            if (first)
                            {
                                p.Text = BAL.FoodNameHolderList.Last() + "-" + BAL.FoodIDHolderList.Last();
                                first = false;
                            }
                            else
                            {
                                p.Text = BAL.FoodIDPriceList.Last() + "";
                                TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + Convert.ToInt16(BAL.FoodIDPriceList.Last()) + "";

                            }
                        }

                    }
                    BAL.FoodIDHolderList.Remove(BAL.FoodIDHolderList.Last());
                    BAL.FoodNameHolderList.Remove(BAL.FoodNameHolderList.Last());
                    BAL.FoodIDPriceList.Remove(BAL.FoodIDPriceList.Last());




                }

            }




        }
        public void argyRowGenerator()
        {




            if (isFirst)
            {

                //  DrinkID.Add(BAL.DrinkIDHolder);


                isFirst = false;
                addedFirst = 3;
            }
            else
            {
                //  ArgyAmount.Add(ArgyAmountint);


            }
            ArgyAmountint = 0;
            RowRemovalCounter++;
            Row = new FlowLayoutPanel();
            OrderRowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;

            Row.Width = OrderRowPanel.Width - 10;
            //Row.SuspendLayout();


            Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            Row.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //   Row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)));


            System.Windows.Forms.Button PickADrink = new System.Windows.Forms.Button();
            PickADrink.BackColor = Color.White;


            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            PickADrink.Location = new System.Drawing.Point(3, 3);

            PickADrink.Size = new System.Drawing.Size(84, 68);
            PickADrink.TabIndex = 1;
            PickADrink.Text = "تعديل";
            PickADrink.UseVisualStyleBackColor = true;
            PickADrink.ForeColor = Color.White;
            PickADrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            PickADrink.BackColor = System.Drawing.Color.Transparent;
            PickADrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            PickADrink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PickADrink.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PickADrink.Location = new System.Drawing.Point(3, 3);
            PickADrink.Size = new System.Drawing.Size(200, 80);

            PickADrink.UseVisualStyleBackColor = false;

            PickADrink.Click += new System.EventHandler(this.PickADrink_Click);







            /* Button DoneOrder = new Button();
             DoneOrder.Text = "Add a drink";
             DoneOrder.BackColor = Color.White;


             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

             DoneOrder.Location = new System.Drawing.Point(3, 3);

             DoneOrder.Size = new System.Drawing.Size(84, 68);
             DoneOrder.TabIndex = 1;
             DoneOrder.Text = "Done ";
             DoneOrder.UseVisualStyleBackColor = true;
             DoneOrder.ForeColor = Color.White;
             DoneOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
             DoneOrder.BackColor = System.Drawing.Color.Transparent;
             DoneOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
             DoneOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
             DoneOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
             DoneOrder.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
             DoneOrder.Location = new System.Drawing.Point(3, 3);
             DoneOrder.Size = new System.Drawing.Size(200, 80);

             DoneOrder.UseVisualStyleBackColor = false;

             DoneOrder.Click += new System.EventHandler(this.Done_Click);*/

            Label l = new Label();
            l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            l.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(938, 0);

            l.Size = new System.Drawing.Size(272, 46);
            l.TextAlign = ContentAlignment.MiddleCenter;



            System.Windows.Forms.TextBox amount = new System.Windows.Forms.TextBox();
            amount.Text = "1";
            amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            amount.Font = new System.Drawing.Font("Lotus Linotype", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            amount.ForeColor = System.Drawing.Color.White;
            amount.BackColor = System.Drawing.Color.DarkGray;
            amount.ReadOnly = true;


            amount.TextAlign = HorizontalAlignment.Center;


            // Row.FlowDirection = FlowDirection.RightToLeft;
            System.Windows.Forms.Button add = new System.Windows.Forms.Button();
            add.Text = "+";
            add.BackColor = Color.White;


            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            add.Location = new System.Drawing.Point(3, 3);

            add.Size = new System.Drawing.Size(84, 68);
            add.TabIndex = 1;

            add.UseVisualStyleBackColor = true;
            add.ForeColor = Color.White;
            add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            add.BackColor = System.Drawing.Color.Transparent;
            add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            add.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            add.Location = new System.Drawing.Point(3, 3);
            add.Size = new System.Drawing.Size(200, 80);

            add.UseVisualStyleBackColor = false;

            add.Click += new System.EventHandler(this.add_Click);

            System.Windows.Forms.Button sub = new System.Windows.Forms.Button();
            sub.Text = "-";
            sub.BackColor = Color.White;


            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            sub.Location = new System.Drawing.Point(3, 3);

            sub.Size = new System.Drawing.Size(84, 68);
            sub.TabIndex = 1;

            sub.UseVisualStyleBackColor = true;
            sub.ForeColor = Color.White;
            sub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            sub.BackColor = System.Drawing.Color.Transparent;
            sub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            sub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sub.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            sub.Location = new System.Drawing.Point(3, 3);
            sub.Size = new System.Drawing.Size(200, 80);

            sub.UseVisualStyleBackColor = false;

            sub.Click += new System.EventHandler(this.sub_Click);




            //   Row.Dock = DockStyle.Top;


            // labelList.Add(l);
            //  buttonsList.Add(PickADrink);

            l.AutoSize = false;

            l.Text = "0";
            Label pl = new Label();
            pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pl.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pl.ForeColor = System.Drawing.Color.White;
            pl.Location = new System.Drawing.Point(938, 0);

            pl.Size = new System.Drawing.Size(272, 46);
            pl.TextAlign = ContentAlignment.MiddleCenter;


            pl.AutoSize = false;

            pl.Text = "0";







            System.Windows.Forms.Button removeRow = new System.Windows.Forms.Button();
            removeRow.BackColor = Color.White;


            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            removeRow.Location = new System.Drawing.Point(3, 3);

            removeRow.Size = new System.Drawing.Size(84, 68);
            removeRow.TabIndex = 1;
            removeRow.Text = "حذف";
            removeRow.UseVisualStyleBackColor = true;
            removeRow.ForeColor = Color.White;
            removeRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            removeRow.BackColor = System.Drawing.Color.Transparent;
            removeRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            removeRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            removeRow.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeRow.Location = new System.Drawing.Point(3, 3);
            removeRow.Size = new System.Drawing.Size(200, 80);

            removeRow.UseVisualStyleBackColor = false;

            removeRow.Click += new System.EventHandler(this.removeRowA_Click);
            //  removeRow.AutoSize = true;
            removeRow.ForeColor = System.Drawing.Color.Pink;




            LabelsList.Add(l);
            AmountsList.Add(amount);



            System.Windows.Forms.LinkLabel hiddinlabel = new System.Windows.Forms.LinkLabel();
            hiddinlabel.Text = "3";
            hiddinlabel.Visible = false;
            hiddinlabel.Size = new System.Drawing.Size(20, 20);


            Row.Controls.Add(hiddinlabel);


            Row.Controls.Add(PickADrink);
            Row.Controls.Add(LabelsList.Last());
            Row.Controls.Add(AmountsList.Last());
            Row.Controls.Add(add);
            Row.Controls.Add(sub);
            Row.Controls.Add(pl);
            Row.Controls.Add(removeRow);


            OrderRowPanel.Controls.Add(Row);



            addedLast = 3;







        }
        private void button15_Click(object sender, EventArgs e)
        {




            BAL.AddedLast = 3;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();



            if (BAL.dataEnterdByMenu)
            {
                numberOfRows++;
                drinkrowcounter++;

                argyrowcounter++;

                int u = BAL.ArgyIDHolderList.Count;
                for (int i = 0; i < u; i++)
                {
                    bool first = true;
                    argyRowGenerator();
                    ArgyID.Add(BAL.ArgyIDHolderList.Last());

                    foreach (Control p in Row.Controls)
                    {
                        if (p is Label && !(p is LinkLabel))
                        {
                            if (first)
                            {
                                p.Text = BAL.ArgyNameHolderList.Last() + "-" + BAL.ArgyIDHolderList.Last();

                                first = false;
                            }
                            else
                            {
                                p.Text = BAL.ArgyIDPriceList.Last() + "";

                                TotalPricelbl.Text = Convert.ToInt32(TotalPricelbl.Text) + Convert.ToInt32(BAL.ArgyIDPriceList.Last()) + "";

                            }
                        }
                    }

                    BAL.ArgyIDHolderList.Remove(BAL.ArgyIDHolderList.Last());
                    BAL.ArgyNameHolderList.Remove(BAL.ArgyNameHolderList.Last());
                    BAL.ArgyIDPriceList.Remove(BAL.ArgyIDPriceList.Last());
                }



            }





        }

        private void button12_Click(object sender, EventArgs e)
        {
            BAL.AddedLast = 1;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {
                numberOfRows++;
                drinkrowcounter++;
                int u = BAL.DrinkIDHolderList.Count;
                for (int i = 0; i < u; i++)
                {
                    bool first = true;

                    drinksRowGenerator();

                    DrinkID.Add(BAL.DrinkIDHolderList.Last());

                    foreach (Control p in Row.Controls)
                    {
                        if (p is Label && !(p is LinkLabel))
                        {
                            if (first)
                            {
                                p.Text = BAL.DrinkNameHolderList.Last() + "-" + BAL.DrinkIDHolderList.Last();
                                first = false;
                            }
                            else
                            {
                                p.Text = BAL.DrinkIDPriceList.Last() + "";
                                TotalPricelbl.Text = Convert.ToInt32(TotalPricelbl.Text) + Convert.ToInt32(BAL.DrinkIDPriceList.Last()) + "";
                            }
                        }

                    }
                    BAL.DrinkIDHolderList.Remove(BAL.DrinkIDHolderList.Last());
                    BAL.DrinkNameHolderList.Remove(BAL.DrinkNameHolderList.Last());
                    BAL.DrinkIDPriceList.Remove(BAL.DrinkIDPriceList.Last());


                }

            }

        }

        int drinkrowcounter = 0;
        int foodrowcounter = 0;
        int argyrowcounter = 0;
        private void PickADrink_Click(object sender, EventArgs e)
        {
            Menu d = new Menu();

            var dialogResult = d.ShowDialog();
            if (BAL.dataEnterdByMenu)
            {
                System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
                bool first = true;
                foreach (Control p in btn.Parent.Controls)
                {
                    if (p is Label && !(p is LinkLabel))
                    {
                        if (first)
                        {
                            p.Text = BAL.DrinkNameHolderList.Last() + "-" + BAL.DrinkIDHolderList.Last();
                            first = false;
                        }
                        else
                        {

                            TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) - Convert.ToInt16(p.Text) + "";

                            p.Text = BAL.DrinkIDPriceList.Last() + "";

                            TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + Convert.ToInt16(BAL.DrinkIDPriceList.Last()) + "";



                        }
                    }

                }

            }
            /* BAL.AddedLast = addedLast;
             Menu d = new Menu();




             var dialogResult = d.ShowDialog();

             System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;

         

             numberOfRows++;


             if (addedLast == 1)
             {
                 drinkrowcounter++;

                 while (BAL.DrinkIDHolderList.Count > 0)
                 {




                     DrinkID.Add(BAL.DrinkIDHolderList.Last());

                     foreach (Control p in btn.Parent.Controls)
                     {
                         if (p is Label && !(p is LinkLabel))
                         {
                             if (first)
                             {
                                 p.Text = BAL.DrinkNameHolderList.Last() + "-" + BAL.DrinkIDHolderList.Last();
                                 first = false;
                             }
                             else
                             {
                                 p.Text = BAL.DrinkIDPriceList.Last() + "";

                             }
                         }

                     }
                     BAL.DrinkIDHolderList.RemoveAt(BAL.DrinkIDHolderList.Count - 1);
                     BAL.DrinkNameHolderList.RemoveAt(BAL.DrinkNameHolderList.Count - 1);
                     BAL.DrinkIDPriceList.RemoveAt(BAL.DrinkIDPriceList.Count - 1);




                 }
             }
             else if (addedLast == 2)
             {
                 foodrowcounter++;
                 while (BAL.FoodIDHolderList.Count > 0)
                 {
                     FoodID.Add(BAL.FoodIDHolderList.Last());

                     foreach (Control p in btn.Parent.Controls)
                     {
                         if (p is Label && !(p is LinkLabel))
                         {
                             if (first)
                             {
                                 p.Text = BAL.FoodNameHolderList.Last() + "-" + BAL.FoodIDHolderList.Last();
                                 first = false;
                             }
                             else
                             {
                                 p.Text = BAL.FoodIDPriceList.Last() + "";
                             }

                         }
                     }



                 }

                 BAL.FoodIDHolderList.RemoveAt(BAL.FoodIDHolderList.Count - 1);
                 BAL.FoodNameHolderList.RemoveAt(BAL.FoodNameHolderList.Count - 1);
                 BAL.FoodIDPriceList.RemoveAt(BAL.FoodIDPriceList.Count - 1);
             }
             else if (addedLast == 3)
             {
                 argyrowcounter++;
                 while (BAL.ArgyIDHolderList.Count > 0)
                 {
                     ArgyID.Add(BAL.ArgyIDHolderList.Last());

                     foreach (Control p in btn.Parent.Controls)
                     {
                         if (p is Label && !(p is LinkLabel))
                         {
                             if (first)
                             {
                                 p.Text = BAL.ArgyNameHolderList.Last() + "-" + BAL.ArgyIDHolderList.Last();

                                 first = false;
                             }
                             else
                             {
                                 p.Text = BAL.ArgyIDPriceList.Last() + "";


                             }
                         }
                     }
                 }

                 BAL.ArgyIDHolderList.RemoveAt(BAL.ArgyIDHolderList.Count - 1);
                 BAL.ArgyNameHolderList.RemoveAt(BAL.ArgyNameHolderList.Count - 1);
                 BAL.ArgyIDPriceList.RemoveAt(BAL.ArgyIDPriceList.Count - 1);


             }*/
        }
        private void button5_Click(object sender, EventArgs e)
        {

            BAL.PasswordFormSelector = 3;
            LogInForm exp = new LogInForm();

            exp.Show();



        }



        private void Done_Click(object sender, EventArgs e)
        {

        }
        List<string> DrinkListName = new List<string>();
        List<string> FoodListName = new List<string>();
        List<string> ArgyListName = new List<string>();

        List<string> DrinkListPrice = new List<string>();
        List<string> FoodListPrice = new List<string>();
        List<string> ArgyListPrice = new List<string>();


        private void button17_Click(object sender, EventArgs e)
        {


            bool haltAll = false;



            if (!haltAll)
            {

                // Row.Parent= this;
                List<int> DrinkListID = new List<int>();
                List<int> DrinkListAmount = new List<int>();


                List<int> FoodListID = new List<int>();
                List<int> FoodListAmount = new List<int>();

                List<int> ArgyListID = new List<int>();
                List<int> ArgyListAmount = new List<int>();

                int selector = 0;
                bool Done = true;



                if (OrderRowPanel.Controls.Count > 0)
                {




                    foreach (Control row in Row.Parent.Controls)
                    {
                        bool first = true;
                        foreach (Control items in row.Controls)
                        {
                            if (items is LinkLabel)
                            {

                                selector = Convert.ToInt16(items.Text);

                            }

                            if (items is Label && !(items is LinkLabel))
                            {
                                if (first)
                                {





                                    if (selector == 1)
                                    {
                                        DrinkListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                        DrinkListName.Add(items.Text.Split('-').First().Trim());
                                    }
                                    else
                                    if (selector == 2)
                                    {
                                        FoodListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                        FoodListName.Add(items.Text.Split('-').First().Trim());
                                    }
                                    else
                                    if (selector == 3)
                                    {
                                        ArgyListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                        ArgyListName.Add(items.Text.Split('-').First().Trim());
                                    }

                                    first = false;

                                }
                                else
                                {

                                    if (selector == 1)
                                    {

                                        DrinkListPrice.Add(items.Text);
                                    }
                                    else
                                    if (selector == 2)
                                    {

                                        FoodListPrice.Add(items.Text);
                                    }
                                    else
                                    if (selector == 3)
                                    {

                                        ArgyListPrice.Add(items.Text);
                                    }



                                }


                            }

                            if (items is System.Windows.Forms.TextBox)
                            {
                                if (selector == 1)
                                {
                                    DrinkListAmount.Add(Convert.ToInt32(items.Text));
                                }
                                else
                                 if (selector == 2)
                                {
                                    FoodListAmount.Add(Convert.ToInt32(items.Text));
                                }
                                else
                                 if (selector == 3)
                                {
                                    ArgyListAmount.Add(Convert.ToInt32(items.Text));
                                }
                            }

                            // System.Windows.Forms.LinkLabel

                        }

                    }

                }
                else
                {
                    Done = false;

                    DrinkID.Clear();
                    DrinkAmount.Clear();


                    FoodID.Clear();
                    FoodAmount.Clear();


                    ArgyID.Clear();

                    ArgyAmount.Clear();




                }
                DrinkID = DrinkListID;
                DrinkAmount = DrinkListAmount;

                FoodID = FoodListID; FoodAmount = FoodListAmount;

                ArgyID = ArgyListID; ArgyAmount = ArgyListAmount;


                int ii = 0;
                if (OrderRowPanel.Controls.Count > 0)
                {

                    if (BAL.InsertRes(timeInMinits, TableOrder.Last(), TimeAndDateLabel.Text))
                    {
                        int i = 0;
                        int iii = 0;
                        int iiii = 0;
                        foreach (int id in DrinkID)
                        {
                            if (BAL.InsertDrinkOrder(DrinkID.ElementAt(i), DrinkAmount.ElementAt(i), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                            {

                                i++;
                                // MessageBox.Show(i + "");
                                //  MessageBox.Show(DrinkAmount.Count()+"");


                            }
                            else
                            {
                                Done = false;

                            }
                        }
                        foreach (int id in FoodID)
                        {
                            if (BAL.InsertFoodOrder(FoodID.ElementAt(iii), FoodAmount.ElementAt(iii), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                            {

                                iii++;
                                // MessageBox.Show(i + "");
                                //  MessageBox.Show(DrinkAmount.Count()+"");


                            }
                            else
                            {
                                Done = false;

                            }
                        }
                        foreach (int id in ArgyID)
                        {
                            if (BAL.InsertArgyOrder(ArgyID.ElementAt(iiii), ArgyAmount.ElementAt(iiii), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                            {

                                iiii++;
                                // MessageBox.Show(i + "");
                                //  MessageBox.Show(DrinkAmount.Count()+"");


                            }
                            else
                            {
                                Done = false;

                            }
                        }

                    }
                    else
                    {
                        Done = false;

                    }
                }
                else
                {
                    if (tableIdLabel.Text.Length > 0)
                        if (BAL.InsertRes(timeInMinits, TableOrder.Last(), TimeAndDateLabel.Text))
                        {


                            // MessageBox.Show("inserted");

                            if (BAL.TableName.Equals("الطاولة") || BAL.TableName.Equals("الفيشة") || BAL.TableName.Equals("البليارد") || BAL.TableName.Equals("طلب خارجي"))
                            {



                            }
                            else
                            {

                                fireATimer(tableIdLabel.Text, timeInMinits * 60);
                                // fireATimer(tableIdLabel.Text, 10);

                            }
                            if (printCB.Checked || kitchenCB.Checked)
                            {
                                Print();
                            }
                            button3.PerformClick();

                        }
                    Done = false;


                }
                if (Done)
                {


                    //  MessageBox.Show("inserted");

                    // fireATimer(tableIdLabel.Text, timeInMinits);


                    if (BAL.TableName.Equals("الطاولة") || BAL.TableName.Equals("الفيشة") || BAL.TableName.Equals("البليارد") || BAL.TableName.Equals("طلب خارجي"))
                    {



                    }
                    else
                    {

                        fireATimer(tableIdLabel.Text, timeInMinits * 60);

                    }
                    if (printCB.Checked || kitchenCB.Checked)
                    {
                        Print();
                    }
                    button3.PerformClick();

                }

            }


            else
            {

                MessageBox.Show("الرجاء عدم ترك اي طلب بالكمية صفر ");
            }
        }

        public void Print()
        {








            System.IO.FileStream fs = new FileStream("rec.pdf", FileMode.Create);

            var newdock = new Rectangle(iTextSharp.text.PageSize.A5);

            newdock.BackgroundColor = new BaseColor(Color.White);





            string fontLoc = "font.ttf"; // make sure to have the correct path to the font file
            BaseFont bf = BaseFont.CreateFont(fontLoc, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font f = new Font(bf, 18);



            PdfPTable ImageTable = new PdfPTable(1);

            ImageTable.WidthPercentage = 100;

            ImageTable.HorizontalAlignment = Element.ALIGN_CENTER;
            ImageTable.SetWidths(new float[] { 600 });
            ImageTable.SpacingBefore = 0f;
            ImageTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            ImageTable.TotalWidth = 380f;
            ImageTable.LockedWidth = true;





            PdfPTable table = new PdfPTable(2);

            table.WidthPercentage = 100;

            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SetWidths(new float[] { 200f, 100f });
            table.SpacingBefore = 2f;
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table.TotalWidth = 380f;
            table.LockedWidth = true;




            PdfPTable durationTable = new PdfPTable(2);

            durationTable.WidthPercentage = 100;

            durationTable.HorizontalAlignment = Element.ALIGN_CENTER;
            durationTable.SetWidths(new float[] { 200f, 100f });
            durationTable.SpacingBefore = 0f;
            durationTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            durationTable.TotalWidth = 380f;
            durationTable.LockedWidth = true;



            PdfPTable tabhead = new PdfPTable(1);
            PdfPCell celllogo;
            tabhead.SpacingAfter = 2F;
            tabhead.TotalWidth = 380f;
            tabhead.WidthPercentage = 100;

            tabhead.LockedWidth = true;
            tabhead.SetWidths(new float[] { 1f });
            float h = tabhead.TotalHeight;

            //Company Logo
            string path = "logo.png";
            celllogo = ImageCell(path, 15f, PdfPCell.ALIGN_CENTER);
            ImageTable.AddCell(celllogo);



            int selector = 0;






            DateTime now = DateTime.Now;
            PdfPTable timeTbl = new PdfPTable(1);
            string timeofticket = now.ToString("t");

            timeTbl.WidthPercentage = 100;

            timeTbl.HorizontalAlignment = Element.ALIGN_CENTER;
            timeTbl.SetWidths(new float[] { 600 });
            timeTbl.SpacingBefore = 0f;
            timeTbl.SpacingAfter = 0f;
            timeTbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            timeTbl.TotalWidth = 380;
            timeTbl.LockedWidth = true;
            timeTbl.AddCell(CreateCell(timeofticket, PdfPCell.ALIGN_CENTER, 34, false));

            string date = now.ToString("d");
            int durationinminits = timeInMinits;
            string tableid = tableIdLabel.Text;
            bool priceIsInserted = false;
            string total = TotalPricelbl.Text;
            table.AddCell(CreateCell("الوقت : ", PdfPCell.ALIGN_CENTER, 26, true));
            table.AddCell(CreateCell(TimeAndDateLabel.Text.Split('-').Last(), PdfPCell.ALIGN_CENTER, 24));




            int tableID = Convert.ToInt16(tableIdLabel.Text);
            bool TimeIsInserted = false;
            if ((tableID >= 1 && tableID <= 19) || tableIdLabel.Text.Equals("99") || tableIdLabel.Text.Equals("100"))
            {


                string devicename = "";
                if ((tableID >= 1 && tableID <= 19))

                {
                    devicename = "بلي ستيشن " + tableID;
                }
                else if
                    (tableIdLabel.Text.Equals("99"))
                { devicename = "VR"; }

                else
                {
                    devicename = "السينما";
                }

                table.AddCell(CreateCell("اسم الجهاز : ", PdfPCell.ALIGN_CENTER, 22, true));
                table.AddCell(CreateCell(devicename, PdfPCell.ALIGN_CENTER, 23));

                int hh = durationinminits / 60;
                int mm = durationinminits % 60;
                string andAhalf = "ونصف";
                string howmanyhours;
                if (hh == 1)
                {
                    howmanyhours = "ساعة ";

                }
                else if (hh == 2)
                {
                    howmanyhours = "ساعتان ";



                }
                else if (hh == 0)
                {
                    howmanyhours = "";
                    andAhalf = "نصف ساعة";

                }
                else
                {

                    howmanyhours = hh + " ساعات ";


                }

                if (mm == 0 && hh != 0)
                {
                    andAhalf = "";
                }
                else if (hh == 0 && mm != 0)
                {

                }
                else { andAhalf = "ونصف"; }




                priceIsInserted = true;


                durationTable.AddCell(CreateCell("مدة الحجز : ", PdfPCell.ALIGN_CENTER, 24, true));
                durationTable.AddCell(CreateCell(howmanyhours + andAhalf, PdfPCell.ALIGN_CENTER, 24));





            }
            else
            {
                string tn = "";

                if
          (tableIdLabel.Text.Contains("40"))
                {
                    tn = "فيشة";
                    table.AddCell(CreateCell("الاسم : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }
                else if
               (tableIdLabel.Text.Contains("30"))
                {
                    tn = "البليارد 2";
                    table.AddCell(CreateCell("الاسم : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }
                else if
             (tableIdLabel.Text.Contains("31"))
                {
                    tn = "البليارد 1";
                    table.AddCell(CreateCell("الاسم : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }
                else if
             (Convert.ToInt32(tableIdLabel.Text) == 0)
                {
                    tn = "طلب خارجي";
                    table.AddCell(CreateCell("الاسم : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }
                else
                {

                    tn = TableOrder.Last() + "";
                    table.AddCell(CreateCell("رقم الطاولة : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }



            }



            table.AddCell(CreateCell("التاريخ : ", PdfPCell.ALIGN_CENTER, 24, true));
            table.AddCell(CreateCell(@TimeAndDateLabel.Text.Split('-').First(), PdfPCell.ALIGN_CENTER, 24));



            int ii = 0;



            PdfPTable OrderTable = new PdfPTable(3);
            PdfPTable argyTable = new PdfPTable(3);
            PdfPTable argyTableShort = new PdfPTable(3);


            // PdfWriter Kwriter = PdfWriter.GetInstance(Kdocument, Kfs);

            if (OrderRowPanel.Controls.Count > 0 || printFromEdit)
            {


                // MessageBox.Show(OrderRowPanel.Controls.Count+"");

                OrderTable.WidthPercentage = 100;

                OrderTable.HorizontalAlignment = Element.ALIGN_CENTER;
                OrderTable.SetWidths(new float[] { 200, 100, 300 });
                OrderTable.SpacingBefore = 2f;
                OrderTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                OrderTable.TotalWidth = 380f;
                OrderTable.LockedWidth = true;

                argyTable.WidthPercentage = 100;

                argyTable.HorizontalAlignment = Element.ALIGN_CENTER;
                argyTable.SetWidths(new float[] { 200, 100, 300 });
                argyTable.SpacingBefore = 0f;
                argyTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                argyTable.TotalWidth = 380f;
                argyTable.LockedWidth = true;


                argyTableShort.WidthPercentage = 100;

                argyTableShort.HorizontalAlignment = Element.ALIGN_CENTER;
                argyTableShort.SetWidths(new float[] { 200, 100, 300 });
                argyTableShort.SpacingBefore = 0f;
                argyTableShort.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                argyTableShort.TotalWidth = 380f;
                argyTableShort.LockedWidth = true;



                int i = 0;
                int iii = 0;
                int iiii = 0;
                OrderTable.AddCell(CreateCell("الاسم", PdfPCell.ALIGN_CENTER, 22, true));
                OrderTable.AddCell(CreateCell("العدد", PdfPCell.ALIGN_CENTER, 22, true));
                OrderTable.AddCell(CreateCell("السعر", PdfPCell.ALIGN_CENTER, 22, true));

                foreach (int row in DrinkID)
                {



                    OrderTable.AddCell(CreateCell(DrinkListName.ElementAt(i).ToString(), PdfPCell.ALIGN_CENTER));
                    OrderTable.AddCell(CreateCell(DrinkAmount.ElementAt(i).ToString(), PdfPCell.ALIGN_CENTER, 22));

                    int price = Convert.ToInt32(DrinkListPrice.ElementAt(i).ToString()) * Convert.ToInt32(DrinkAmount.ElementAt(i).ToString());

                    OrderTable.AddCell(CreateCell(price + "", PdfPCell.ALIGN_CENTER, 22));

                    i++;

                    drinkIsSet = true;




                }


                foreach (int row in FoodID)
                {
                    OrderTable.AddCell(CreateCell(FoodListName.ElementAt(iii).ToString(), PdfPCell.ALIGN_CENTER));
                    OrderTable.AddCell(CreateCell(FoodAmount.ElementAt(iii).ToString(), PdfPCell.ALIGN_CENTER, 22));


                    int price = Convert.ToInt32(FoodListPrice.ElementAt(iii).ToString()) * Convert.ToInt32(FoodAmount.ElementAt(iii).ToString());

                    OrderTable.AddCell(CreateCell(price + "", PdfPCell.ALIGN_CENTER, 22));


                    iii++;

                    foodISSet = true;

                }

                if (ArgyID.Count > 0)
                {

                    argyTable.AddCell(CreateCell("الاسم", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTable.AddCell(CreateCell("العدد", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTable.AddCell(CreateCell("السعر", PdfPCell.ALIGN_CENTER, 22, true));


                    argyTableShort.AddCell(CreateCell("الاسم", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTableShort.AddCell(CreateCell("العدد", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTableShort.AddCell(CreateCell("السعر", PdfPCell.ALIGN_CENTER, 22, true));


                }

                foreach (int row in ArgyID)
                {


                    int price = Convert.ToInt32(ArgyListPrice.ElementAt(iiii).ToString()) * Convert.ToInt32(ArgyAmount.ElementAt(iiii).ToString());


                    argyTable.AddCell(CreateCell(ArgyListName.ElementAt(iiii).ToString(), PdfPCell.ALIGN_CENTER));
                    argyTableShort.AddCell(CreateCell(ArgyListName.ElementAt(iiii).ToString(), PdfPCell.ALIGN_CENTER));
                    argyTableShort.AddCell(CreateCell(ArgyAmount.ElementAt(iiii).ToString(), PdfPCell.ALIGN_CENTER, 22));
                    argyTable.AddCell(CreateCell(ArgyAmount.ElementAt(iiii).ToString(), PdfPCell.ALIGN_CENTER, 22));
                    int price1 = 0;
                    int priceshort = 0;
                    if (ArgyListName.ElementAt(iiii).ToString().Contains("VIP"))
                    {
                        price1 = (Convert.ToInt32(ArgyListPrice.ElementAt(iiii).ToString())) * Convert.ToInt32(ArgyAmount.ElementAt(iiii).ToString());
                        priceshort = (Convert.ToInt32(ArgyListPrice.ElementAt(iiii).ToString()) - 2000) * Convert.ToInt32(ArgyAmount.ElementAt(iiii).ToString());
                    }
                    else
                    {

                        price1 = (Convert.ToInt32(ArgyListPrice.ElementAt(iiii).ToString())) * Convert.ToInt32(ArgyAmount.ElementAt(iiii).ToString());
                        priceshort = Convert.ToInt32(ArgyListPrice.ElementAt(iiii).ToString()) * Convert.ToInt32(ArgyAmount.ElementAt(iiii).ToString());


                    }
                    argyTable.AddCell(CreateCell(price1 + "", PdfPCell.ALIGN_CENTER, 22));
                    argyTableShort.AddCell(CreateCell(priceshort + "", PdfPCell.ALIGN_CENTER, 22));


                    iiii++;
                }


                if (ArgyID.Count > 0)
                {



                    System.IO.FileStream Argyfs = new FileStream("Argyrec" +
                        ".pdf", FileMode.Open);

                    float h3 = 0;
                    h3 += ImageTable.TotalHeight;
                    h3 += table.TotalHeight;
                    h3 += argyTableShort.TotalHeight;


                    // h3 += timeTbl.TotalHeight;
                    var newdockArgy = new Rectangle(390, h3 + 10);
                    //  MessageBox.Show(newdock1.Width+"-"+ newdock1.Height);
                    // MessageBox.Show(table.TotalHeight + "- "+ table.TotalWidth);
                    newdockArgy.BackgroundColor = new BaseColor(Color.White);


                    iTextSharp.text.Document Argydocument = new iTextSharp.text.Document(newdockArgy, 10, 10, 0, 0);

                    /*       iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A7);
                     rec.BackgroundColor = new BaseColor(Color.White);
                     iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(rec, 15, 15, 20, 20);*/


                    PdfWriter Argywriter = PdfWriter.GetInstance(Argydocument, Argyfs);








                    Argywriter.Open();
                    Argydocument.Open();
                    Argydocument.Add(ImageTable);




                    argytableBOOL = true;



                    Argydocument.Add(table);

                    Argydocument.Add(argyTableShort);



                    //  Argydocument.Add(timeTbl);


                    Argydocument.Close();
                    Argywriter.Close();

                    Argyfs.Close();

                }















            }

            PdfPTable priceTable = new PdfPTable(2);

            priceTable.WidthPercentage = 100;

            priceTable.HorizontalAlignment = Element.ALIGN_CENTER;
            priceTable.SetWidths(new float[] { 300, 300 });
            priceTable.SpacingBefore = 2f;
            priceTable.SpacingAfter = 0f;
            priceTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            priceTable.TotalWidth = 380f;
            priceTable.LockedWidth = true;
            priceTable.AddCell(CreateCell("السعر الكلي : ", PdfPCell.ALIGN_CENTER, 22, true));
            priceTable.AddCell(CreateCell(TotalPricelbl.Text, PdfPCell.ALIGN_CENTER, 24));




            System.IO.FileStream Kfs = new FileStream("Krec.pdf" +
                "", FileMode.Open);

            float h2 = 0;
            h2 += ImageTable.TotalHeight;
            h2 += table.TotalHeight;
            h2 += OrderTable.TotalHeight;
            h2 += priceTable.TotalHeight;
            // h2 += timeTbl.TotalHeight;
            var newdock11 = new Rectangle(390, h2 + 10);
            //  MessageBox.Show(newdock1.Width+"-"+ newdock1.Height);
            // MessageBox.Show(table.TotalHeight + "- "+ table.TotalWidth);
            newdock11.BackgroundColor = new BaseColor(Color.White);


            iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(newdock11, 10, 10, 0, 0);

            /*       iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A7);
             rec.BackgroundColor = new BaseColor(Color.White);
             iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(rec, 15, 15, 20, 20);*/


            PdfWriter Kwriter = PdfWriter.GetInstance(Kdocument, Kfs);





            if (drinkIsSet == true || foodISSet == true)

            {
                //  MessageBox.Show(drinkIsSet+"");
                ordertableBOOL = true;

                Kwriter.Open();
                Kdocument.Open();
                Kdocument.Add(ImageTable);

                Kdocument.Add(table);

                Kdocument.Add(OrderTable);

                Kdocument.Add(priceTable);

                // Kdocument.Add(timeTbl);


                Kdocument.Close();
                Kwriter.Close();
                // Kwriter.CloseStream = true;

            }
            else
            {



            }
            Kfs.Close();

            float h1 = 0;
            h1 += ImageTable.TotalHeight;
            h1 += table.TotalHeight;
            h1 += durationTable.TotalHeight;
            h1 += OrderTable.TotalHeight;
            argyTable.DeleteRow(0);
            h1 += argyTable.TotalHeight;
            h1 += priceTable.TotalHeight;
            // h1 += timeTbl.TotalHeight;
            var newdock1 = new Rectangle(390, h1 + 10);
            //  MessageBox.Show(newdock1.Width+"-"+ newdock1.Height);
            // MessageBox.Show(table.TotalHeight + "- "+ table.TotalWidth);
            newdock1.BackgroundColor = new BaseColor(Color.White);


            iTextSharp.text.Document document = new iTextSharp.text.Document(newdock1, 10, 10, 0, 0);

            /*       iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A7);
             rec.BackgroundColor = new BaseColor(Color.White);
             iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(rec, 15, 15, 20, 20);*/


            PdfWriter writer = PdfWriter.GetInstance(document, fs);




            document.Open();
            document.Add(ImageTable);

            document.Add(table);
            document.Add(durationTable);
            document.Add(OrderTable);


            document.Add(argyTable);

            document.Add(priceTable);

            //document.Add(timeTbl);

            document.Close();
            writer.Close();
            fs.Close();





            /*   var settings = new MagickReadSettings();
               // Settings the density to 300 dpi will create an image with a better quality
               settings.Density = new Density(300);

               using (var images = new MagickImageCollection())
               {
                   // Add all the pages of the pdf file to the collection
                   images.Read("rec.pdf", settings);



                   // Create new image that appends all the pages vertically
                   using (var vertical = images.AppendVertically())
                   {
                       // Save result as a png
                       vertical.Write("rec.bmp");
                   }
               }*/

            var settings = new MagickReadSettings();
            settings.Density = new Density(300, 300);
            var pageE = 0;

            try
            {
                string filePath = "reci0.bmp";


                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }


            }
            catch (IOException e)
            {

            }

            using (var images = new MagickImageCollection())
            {
                //  MessageBox.Show("write");

                string o = "";
                images.Read("rec.pdf", settings);


                foreach (var image1 in images)
                {

                    image1.Write("reci0.bmp");
                    // MessageBox.Show("write");
                    //   pageE++;

                }

            }


            if (casherPState)
            {

                if (!firstPrint)
                {

                    Bitmap image33;
                    using (var bitmap = new Bitmap("reci0.bmp"))
                    {
                        image33 = new Bitmap(bitmap);

                    }



                    /* Bitmap image33 = new Bitmap(Bitmap.FromFile("reci0.bmp"));
                     printer.Image(image33);*/
                    if (printCB.Checked)
                    {
                        printer.Image(image33);
                        printer.FullPaperCut();

                    }
                    firstPrint = true;

                    /*     string fileToCopy = "reci" + 0 + ".bmp";
                         string destinationDirectory = "C:\\Users\\GAMA\\Desktop\\reci0.bmp";

                        File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));*/

                }

            }
            if (drinkIsSet == true || foodISSet == true)
                if (ordertableBOOL && (!tableIdLabel.Text.Equals("0")))
                {


                    var Ksettings = new MagickReadSettings();
                    Ksettings.Density = new Density(300, 300);
                    var KpageE = 0;
                    using (var images = new MagickImageCollection())
                    {
                        images.Read("Krec.pdf", Ksettings);


                        foreach (var image2 in images)
                        {
                            image2.WriteAsync("Kreci" + KpageE + ".bmp");

                            KpageE++;
                        }

                    }

                    if (kitchenPState)
                    {

                        if (!secondPrint)
                        {



                            Bitmap image22;
                            using (var bitmap = new Bitmap("Kreci" + 0 + ".bmp"))
                            {
                                image22 = new Bitmap(bitmap);

                            }



                            /* Bitmap image33 = new Bitmap(Bitmap.FromFile("reci0.bmp"));
                             printer.Image(image33);*/
                            if (kitchenCB.Checked)
                            {
                                Kprinter.Image(image22);

                                Kprinter.FullPaperCut();
                                // printer.PrintDocument();
                            }
                            secondPrint = true;


                            /*    string fileToCopy = "Kreci" + 0 + ".bmp";
                                string destinationDirectory = "C:\\Users\\GAMA\\Desktop\\Kreci.bmp";

                                File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));*/
                        }

                    }
                    else if (casherPState)
                    {





                        Bitmap image22;
                        using (var bitmap = new Bitmap("Kreci" + 0 + ".bmp"))
                        {
                            image22 = new Bitmap(bitmap);

                        }



                        /* Bitmap image33 = new Bitmap(Bitmap.FromFile("reci0.bmp"));
                         printer.Image(image33);*/


                        secondPrint = true;

                        if (kitchenCB.Checked)
                        {
                            printer.Image(image22);
                            printer.FullPaperCut();
                        }
                        /*string fileToCopy = "Kreci" + 0 + ".bmp";
                        string destinationDirectory = "C:\\Users\\GAMA\\Desktop\\Kreci.bmp";

                        File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));*/


                    }

                }

            if (ArgyID.Count > 0)
            {

                var Asettings = new MagickReadSettings();
                Asettings.Density = new Density(300, 300);
                var ApageE = 0;
                using (var images = new MagickImageCollection())
                {
                    images.Read("Argyrec.pdf", Asettings);


                    foreach (var image3 in images)
                    {
                        image3.WriteAsync("Argyrec" + ApageE + ".bmp");

                        ApageE++;
                    }
                }
                if (kitchenPState)
                {

                    if (!thirdPrint)
                    {


                        Bitmap image22;
                        using (var bitmap = new Bitmap("Argyrec" + 0 + ".bmp"))
                        {
                            image22 = new Bitmap(bitmap);

                        }

                        if (kitchenCB.Checked)
                        {
                            Kprinter.Image(image22);


                            Kprinter.FullPaperCut();
                        }

                        thirdPrint = true;




                    }
                }
                else
                {


                    Bitmap image22;
                    using (var bitmap = new Bitmap("Argyrec" + 0 + ".bmp"))
                    {
                        image22 = new Bitmap(bitmap);

                    }

                    thirdPrint = true;



                    if (kitchenCB.Checked)
                    {
                        printer.Image(image22);


                        printer.FullPaperCut();
                    }


                }

            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (casherPState)
            {
            printer.PrintDocument();

                // printer.Clear();

                // MessageBox.Show("printer");
            }
            if (kitchenPState)
            {
              Kprinter.PrintDocument();
                // Kprinter.Clear();
                // MessageBox.Show("Kprinter");

            }
            printer.Clear();
            Kprinter.Clear();
            ordertableBOOL = false;
            firstPrint = false;
            secondPrint = false;
            thirdPrint = false;

            drinkIsSet = false;
            foodISSet = false;


            DrinkListName.Clear();
            DrinkAmount.Clear();
            DrinkListPrice.Clear();

            FoodListName.Clear();
            FoodAmount.Clear();
            FoodListPrice.Clear();

            ArgyListPrice.Clear();
            ArgyListName.Clear();
            ArgyAmount.Clear();


            /*         try
             {
                 string filePath = "Argyrec" + 0 + ".bmp";


                 if (File.Exists(filePath))
                 {
                     File.Delete(filePath);
                 }


             }
             catch (IOException e)
             {

             }
             try
             {
                 string filePath = "Kreci" + 0 + ".bmp";


                 if (File.Exists(filePath))
                 {
                     File.Delete(filePath);
                 }


             }
             catch (IOException e)
             {

             } */
            /*     try
                 {
                     string filePath = "reci" + 0 + ".bmp";


                     if (File.Exists(filePath))
                     {
                         File.Delete(filePath);
                     }


                 }
                 catch (IOException e)
                 {

                 }*/


        }
        private static PdfPCell CreateCell(string text, int align, int textSize = 0, bool gray = false)
        {


            string fontLoc = "font.ttf"; // make sure to have the correct path to the font file
            BaseFont bf = BaseFont.CreateFont(fontLoc, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font f;
            if (textSize == 0)
            {
                if (text.Length <= 7)
                {
                    f = new Font(bf, Convert.ToInt16((23 + 4)));
                }
                else if (text.Length > 7 && text.Length <= 12)
                {
                    f = new Font(bf, Convert.ToInt16((21 + 4)));

                }
                else if (text.Length > 12 && text.Length <= 17)

                { f = new Font(bf, Convert.ToInt16((20 + 4))); }
                else

                { f = new Font(bf, Convert.ToInt16((18 + 4))); }
            }
            else
            {
                f = new Font(bf, textSize + 4);

            }
            Phrase phrase = new Phrase(text, f);
            PdfPCell cell = new PdfPCell(phrase);

            if (gray)
            {
                cell.BackgroundColor = GrayColor.GRAY;
                cell.BorderWidth = 3.5f;

            }
            else
            {
                cell.BackgroundColor = GrayColor.WHITE;
                cell.BorderWidth = 1.5f;

            }
            cell.FixedHeight = 60f;
            cell.HorizontalAlignment = align;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            return cell;


        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path);
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;



            return cell;
        }
        private void button13_Click(object sender, EventArgs e)
        {
        }
        double timeAsIntH = 0;
        double timeAsIntM = 0;
        int timeInMinits;
        private void button11_Click(object sender, EventArgs e)
        {


            if (timeAsIntM != 0)
            {

                timeAsIntM = 00;
                timeAsIntH++;

            }
            else
            {
                timeAsIntM = 30;

            }
            timeInMinits = Convert.ToInt32((timeAsIntH * 60) + timeAsIntM);
            if (tableIdLabel.Text.Equals("99"))
            {
                if (timeAsIntM == 0)
                {
                    TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (2000)).ToString();
                }
                else
                {
                    TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (3000)).ToString();

                }
            }
            else if (tableIdLabel.Text.Equals("100"))
            {

                TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (4000)).ToString();

            }
            else
            {

                TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) + (2000)).ToString();

            }
            ResDurLbl.Text = timeAsIntH + ":" + timeAsIntM;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            BAL.timeHasBeenChanged = true;
            if (!ResDurLbl.Text.Equals("0:0"))
            {
                if (timeAsIntM == 0 && timeAsIntH > 0)
                {

                    timeAsIntM = 30;
                    timeAsIntH--;

                }
                else
                {
                    timeAsIntM = 00;

                }
                timeInMinits = Convert.ToInt32((timeAsIntH * 60) + timeAsIntM);
                if (tableIdLabel.Text.Equals("99"))
                {
                    if (timeAsIntM != 0)
                    {
                        TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (2000)).ToString();
                    }
                    else
                    {
                        TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (3000)).ToString();

                    }
                }
                else if (tableIdLabel.Text.Equals("100"))
                {

                    TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (4000)).ToString();

                }
                else
                {

                    TotalPricelbl.Text = (Convert.ToInt32(TotalPricelbl.Text) - (2000)).ToString();

                }
                ResDurLbl.Text = timeAsIntH + ":" + timeAsIntM;
            }
        }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            View.Visible = true;
            AddPanel.Visible = false;
            timerPanel.Visible = false;
            FinisedTimerPanel.Visible = false;
            finishedClearButtonPanel.Visible = false;

            DataTable dt = BAL.GetReservation();


            dt.Columns["ID"].ColumnName = "ID";
            dt.Columns["TableOrPs"].ColumnName = "رقم الطاولة";
            dt.Columns["ResDuration"].ColumnName = "مدة الحجز";
            dt.Columns["TimeAndDate"].ColumnName = "وقت الحجز";


            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            // MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }


        private void button18_Click(object sender, EventArgs e)
        {

            BAL.ResDT = BAL.GetResByID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.DrinksDT = BAL.GetDrinkOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.FoodDT = BAL.GetFoodOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.ArgyDT = BAL.GetArgyOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));



            ViewForm vf = new ViewForm();
            var dialogResult = vf.ShowDialog();


            button3.PerformClick();





        }

        private void button20_Click(object sender, EventArgs e)
        {


            string message = "سوف يتم حذف هذا السجل";
            string title = "تحذير!! ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                 int o = 0;


                    foreach (Panel p in timerPanel.Controls)
                    {
                        if (p.BackColor == Color.Green && p.Controls[0].Text.Equals(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()))
                        {

                            counterSelector = 0;
  
                            tempLabel[o].Text = 2 + "";

                            timerPanel.Controls[o].Controls[1].Text = 0+ ":" + 2 % 60;
                        }

                        o++;

                    }
                    BAL.DelResAndOrders(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                    button3.PerformClick();



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

        private void button19_Click(object sender, EventArgs e)
        {

            BAL.ResDT = BAL.GetResByID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.DrinksDT = BAL.GetDrinkOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.FoodDT = BAL.GetFoodOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            BAL.ArgyDT = BAL.GetArgyOrderByResID(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

            EditForm vf = new EditForm();
            var dialogResult = vf.ShowDialog();
            if (BAL.okEdit)
            {
                if (BAL.itemsHadBeenChanged || BAL.timeHasBeenChanged)
                {

                    printFromEdit = true;


                    TimeAndDateLabel.Text = BAL.timeAndDAte;

                    tableIdLabel.Text = BAL.TableIDLabel;
                    TableOrder.Add(Convert.ToInt32(BAL.TableIDLabel));

                    DrinkID = BAL.DrinkAmount;
                    DrinkAmount = BAL.DrinkAmount;

                    FoodID = BAL.FoodAmount;
                    FoodAmount = BAL.FoodAmount;

                    ArgyID = BAL.ArgyAmount;
                    ArgyAmount = BAL.ArgyAmount;


                    DrinkListName = BAL.DrinkListName;
                    FoodListName = BAL.FoodListName;
                    ArgyListName = BAL.ArgyListName;


                    DrinkListPrice = BAL.DrinkListPrice;
                    FoodListPrice = BAL.FoodListPrice;
                    ArgyListPrice = BAL.ArgyListPrice;
                    TotalPricelbl.Text = BAL.TotalPrice;
                    timeInMinits = BAL.newTimeInminits;

                    kitchenCB.Checked = BAL.PrintKitch;
                    printCB.Checked = BAL.printCus;

                    if (BAL.timeHasBeenChanged)
                    {
                        int o = 0;

                        foreach (Panel p in timerPanel.Controls)
                        {
                            if (p.BackColor == Color.Green && p.Controls[0].Text.Equals(tableIdLabel.Text))
                            {







                                int labelTime = Convert.ToInt32(tempLabel[o].Text);


                                labelTime = labelTime + ((timeInMinits * 60) - labelTime);

                                if (labelTime < 0) { labelTime = 1;

                                    counterSelector = 0;
                                }





                                tempLabel[o].Text = labelTime + "";

                                timerPanel.Controls[o].Controls[1].Text = labelTime / 60 + ":" + labelTime % 60;
                               
                            }

                            o++;

                        }



                    }
                    Print();
                }
            }

            button3.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            BAL.GetLog();
            Log log = new Log();
            log.Show();



        }




        FlowLayoutPanel timerSquare;
        Label timerUpLabel;
        Label timerDownLabel;
        Label tempLabelSingel;
        List<System.Windows.Forms.Label> tempLabel = new List<System.Windows.Forms.Label>();
        int activeTimerCounter = 0;
        List<int> ActiveTimersListHolder = new List<int>();
        bool once = true;
        List<int> ActiveTimersList = new List<int>();
        int labelcounter;
        private void button21_Click(object sender, EventArgs e)
        {
            timerPanel.Visible = true;
            FinisedTimerPanel.Visible = true;
            finishedClearButtonPanel.Visible = true;
            View.Visible = false;
            AddPanel.Visible = false;




        }
        public void fireATimer(string TblName, int timeValue)
        {


            tempLabelSingel = new Label();

            tempLabel.Add(tempLabelSingel);
            ActiveTimersList.Add(activeTimerCounter);
            activeTimerCounter++;
            timerSquare = new FlowLayoutPanel();

            timerSquare.Width = 250;
            timerSquare.Height = 175;
            //Row.SuspendLayout();


            timerSquare.BackColor = Color.Green;
            timerSquare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            timerUpLabel = new Label();
            timerUpLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            timerUpLabel.Font = new System.Drawing.Font("Lotus Linotype", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            timerUpLabel.ForeColor = System.Drawing.Color.White;
            timerUpLabel.Location = new System.Drawing.Point(0, 0);

            timerUpLabel.Size = new System.Drawing.Size(timerSquare.Width, timerSquare.Height / 2 - 5);
            timerUpLabel.TextAlign = ContentAlignment.MiddleCenter;
            timerUpLabel.Text = TblName;




            timerDownLabel = new Label();
            timerDownLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            timerDownLabel.Font = new System.Drawing.Font("Lotus Linotype", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            timerDownLabel.ForeColor = System.Drawing.Color.White;
            timerDownLabel.Location = new System.Drawing.Point(0, 0);

            timerDownLabel.Size = new System.Drawing.Size(timerSquare.Width, timerSquare.Height / 2 - 5);
            timerDownLabel.TextAlign = ContentAlignment.MiddleCenter;

            timerSquare.Controls.Add(timerUpLabel);
            timerSquare.Controls.Add(timerDownLabel);
            timerPanel.Controls.Add(timerSquare);


            CreateTimer(timeValue);


        }

        public Dictionary<System.Windows.Forms.Timer, Label> dict = new Dictionary<System.Windows.Forms.Timer, Label>();

        int n = 1;
        int timersListCounter = 0;
        int timesec = 30 * 60;
        System.Windows.Forms.Timer timer;


        List<System.Windows.Forms.Timer> timersList = new List<System.Windows.Forms.Timer>();




        private void CreateTimer(int timerValue)
        {

            timer = new System.Windows.Forms.Timer();
            timersList.Add(timer);

            // timersList[0] = new System.Windows.Forms.Timer();
            timersList.Last().Tick += timer_Tick;
            timersList.Last().Interval = (1000);//1 sec


            //timerLabel.Text = timesec / 60 + ":" + timesec % 60;
            tempLabel[timersListCounter].Text = timerValue + "";



            dict.Add(timersList.Last(), tempLabel[timersListCounter]);
            timersList.Last().Enabled = true;
            timersList.Last().Start();
            n++;
            timersListCounter++;
            /*  if (timersList.Count==1)
              {
                   counterSelector = 0;
              }*/
            counterSelector = 0;
        }

        int counterSelector = 0;
        int counterSelectorOutOfTime = 0;
        int o = 0;
        int labelToBeRemoved;
        int removedTimers = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (counterSelector >= tempLabel.Count || counterSelector < 0 || counterSelector >= timerPanel.Controls.Count) { counterSelector = 0; }

            if (timerPanel.Controls.Count > 0)
            {

                System.Windows.Forms.Timer t = (System.Windows.Forms.Timer)sender;
                if (counterSelector >= tempLabel.Count|| counterSelector <0 || counterSelector >= timerPanel.Controls.Count) { counterSelector = 0; }

                int labelTime = Convert.ToInt32(tempLabel[counterSelector].Text);
                labelTime--;

                counterSelector++;

                // if (counterSelector >= timerPanel.Controls.Count|| counterSelector >= tempLabel.Count || counterSelector >= tempLabel.Count) 
                //  {counterSelector = 1;}

                tempLabel[counterSelector - 1].Text = labelTime + "";

                timerPanel.Controls[counterSelector - 1].Controls[1].Text = labelTime / 60 + ":" + labelTime % 60;

                if (counterSelector >= timersList.Count())
                {

                    counterSelector = 0;
                }
                else { }
                if (labelTime <= 0)
                {

                    int i = 0;
                    foreach (Panel p in timerPanel.Controls)
                    {
                        if (p.BackColor == Color.Green && Convert.ToInt32(tempLabel[i].Text) <= 0)
                        {
                            if (counterSelector > 0) { 
                            counterSelector--;
                            }

                            counterSelectorOutOfTime++;
                            t.Stop();
                            int plus = 0;
                            p.BackColor = Color.Red;

                            FinisedTimerPanel.Controls.Add(p);
                            FinisedTimerPanel.Controls[FinisedTimerPanel.Controls.Count - 1].BringToFront();
                            timerPanel.Controls.Remove(p);
                            timersList.RemoveAt(i);
                            tempLabel.RemoveAt(i);
                            timersListCounter--;
                            break;
                        }

                        i++;

                    }
                }



            }




        }

        public void clearAddPanel()
        {



            OrderRowPanel.Controls.Clear();
            ResDurLbl.Text = "0:0";
            TotalPricelbl.Text = "0";
            tableIdLabel.Text = "";
            TabelLabelName.Text = "";
            timeInMinits = 0;
            timeAsIntH = 0;
            timeAsIntM = 0;
            printFromEdit = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            BAL.PasswordFormSelector = 1;
            LogInForm filter = new LogInForm();

            filter.Show();

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

            //change
            FloorLayout fl = new FloorLayout();
            var dialogResult = fl.ShowDialog();


            if (BAL.TableName.Length > 0)
            {
                clearAddPanel();
                button11.Enabled = true;
                button16.Enabled = true;
                DateTime now = DateTime.Now;


                TimeAndDateLabel.Text = now.ToString("d") + " - " + now.ToString("t");
                if (!(BAL.TableID == 0))
                {
                    TabelLabelName.Text = "رقم " + BAL.TableName;
                }
                else
                {
                    TabelLabelName.Text = BAL.TableName;

                }

                if (BAL.TableName.Equals("الطاولة") || BAL.TableName.Equals("الفيشة") || BAL.TableName.Equals("البليارد") || BAL.TableName.Equals("طلب خارجي"))
                {

                    button11.Enabled = false;
                    button16.Enabled = false;
                    timeInMinits = 0;

                }

                AddPanel.Visible = true;
                View.Visible = false;
                timerPanel.Visible = false;

                tableIdLabel.Text = BAL.TableID + "";
                AddPanel.Visible = true;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            BAL.PasswordFormSelector = 2;
            LogInForm Emp = new LogInForm();

            Emp.Show();
        }

        private void menuManager_Click(object sender, EventArgs e)
        {
            MenuManager menumanager = new MenuManager();

            menumanager.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            printerSettingForm printer = new printerSettingForm();

            printer.Show();
        }

        private void ResDurLbl_Click(object sender, EventArgs e)
        {

        }

        private void tableIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            FinisedTimerPanel.Controls.Clear();
        }
    }
}