using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inf
{
    public partial class EditForm : Form
    {
        bool thereIsRow = false;
        int OrigenalTimeInMinits;
        int OrigenalTotalPrice;
        bool ItemHassBeenAdded;

        public EditForm()
        {
            InitializeComponent();

            BAL.timeHasBeenChanged = false;

            //  BAL.UpdateRes(Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString()), 55, 55, "55");
            OrderRowPanel.AutoScroll = true;
            button11.Enabled = false;
            button16.Enabled = false;
            TimeAndDateLabel.Text = BAL.ResDT.Rows[0]["TimeAndDate"] + "";
            tableIdLabel.Text = BAL.ResDT.Rows[0]["TableOrPs"] + "";
            int tableId = Convert.ToInt32(tableIdLabel.Text);

            if (tableId >= 1 || tableId <= 19)
            {




            }
            if (tableId == 100 || tableId == 99)
            {



            }
            ResDurLbl.Text = Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) / 60 + ":" + Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) % 60;
            timeAsIntH = Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) / 60;
            timeAsIntM = Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) % 60;
            int DrinksTotal = 0;
            foreach (DataRow row in BAL.DrinksDT.Rows)
            {

                DrinksTotal += ((Convert.ToInt16((row["DrinkPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["DrinkName"].ToString() + "-" + row["DrinkID"].ToString(), row["DrinkPrice"].ToString(), row["Amount"].ToString(), "1");
                thereIsRow = true;
            }
            int FoodToaol = 0;
            foreach (DataRow row in BAL.FoodDT.Rows)
            {

                FoodToaol += ((Convert.ToInt16((row["FoodPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["FoodName"].ToString() + "-" + row["FoodID"].ToString(), row["FoodPrice"].ToString(), row["Amount"].ToString(), "2");
                thereIsRow = true;


            }
            int ArgyToaol = 0;
            foreach (DataRow row in BAL.ArgyDT.Rows)
            {

                ArgyToaol += ((Convert.ToInt16((row["ArgylahPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["Argylah"].ToString() + "-" + row["ArgylahID"].ToString(), row["ArgylahPrice"].ToString(), row["Amount"].ToString(), "3");

                thereIsRow = true;

            }


            TotalPricelbl.Text = ArgyToaol + FoodToaol + DrinksTotal + "";
            timeInMinits = Convert.ToInt32((timeAsIntH * 60) + timeAsIntM);
            OrigenalTimeInMinits = timeInMinits;
            BAL.newTimeInminits = OrigenalTimeInMinits;
            int tableID = Convert.ToInt16(tableIdLabel.Text);
            if (tableID >= 1 && tableID <= 19)
            {

                TotalPricelbl.Text = Convert.ToInt32(TotalPricelbl.Text) + ((timeInMinits / 30) * 2000) + "";




            }

            if (tableIdLabel.Text.Equals("99"))
            {

                int switcher = 1000;
                int total = 0;
                for (int i = 0; i < (timeInMinits / 30); i++)
                {

                    total += 2000 + switcher;
                    if (switcher == 1000)
                    {

                        switcher = 0;
                    }
                    else
                    {
                        switcher = 1000;
                    }
                }
                TotalPricelbl.Text = ((Convert.ToInt32(TotalPricelbl.Text)) + total) + "";
                TabelLabelName.Text = "VR";
                button11.Enabled = true;
                button16.Enabled = true;
            }
            else if (tableIdLabel.Text.Equals("100"))
            {
                TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + ((timeInMinits / 30) * 4000) + "";
                TabelLabelName.Text = "السينما";
                button11.Enabled = true;
                button16.Enabled = true;

            }
            else if (tableIdLabel.Text.Equals("30"))
            {
                TabelLabelName.Text = "البليارد";


            }
            else if (tableIdLabel.Text.Equals("31"))
            {
                TabelLabelName.Text = "البليارد";


            }
            else if (tableIdLabel.Text.Equals("40"))
            {
                TabelLabelName.Text = "الفيشة";


            }
            else if (tableIdLabel.Text.Equals("0"))
            {
                TabelLabelName.Text = "طلب خارجي";


            }
            else if ((Convert.ToInt32(tableIdLabel.Text) >= 1 && Convert.ToInt32(tableIdLabel.Text) <= 19))
            {

                button11.Enabled = true;
                button16.Enabled = true;
                TabelLabelName.Text = "رقم البلي";

            }


            OrigenalTotalPrice = Convert.ToInt32(TotalPricelbl.Text);
            /*

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

                        }*/





        }
        FlowLayoutPanel Row = new FlowLayoutPanel();
        public void RowGenerator(string name, string price, string Amount, string secret)
        {


            thereIsRow = true;
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
            PickADrink.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PickADrink.Location = new System.Drawing.Point(3, 3);
            PickADrink.Size = new System.Drawing.Size(200, 80);

            PickADrink.UseVisualStyleBackColor = false;

            PickADrink.Click += new System.EventHandler(this.PickADrink_Click);





            Label l = new Label();
            l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            l.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(938, 0);

            l.Size = new System.Drawing.Size(272, 46);
            l.TextAlign = ContentAlignment.MiddleCenter;



            System.Windows.Forms.TextBox amount = new System.Windows.Forms.TextBox();
            amount.Text = "0";
            amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            amount.Font = new System.Drawing.Font("Lotus Linotype", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            amount.ForeColor = System.Drawing.Color.White;
            amount.BackColor = System.Drawing.Color.DarkGray;
            amount.ReadOnly = true;


            amount.TextAlign = HorizontalAlignment.Center;

            amount.Text = Amount;
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

            l.Text = name;






            Label pl = new Label();
            pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pl.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pl.ForeColor = System.Drawing.Color.White;
            pl.Location = new System.Drawing.Point(938, 0);

            pl.Size = new System.Drawing.Size(200, 46);
            pl.TextAlign = ContentAlignment.MiddleCenter;


            pl.AutoSize = false;

            pl.Text = price;






            System.Windows.Forms.Button removeRow = new System.Windows.Forms.Button();
            removeRow.BackColor = Color.White;


            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            removeRow.Location = new System.Drawing.Point(3, 3);

            removeRow.Size = new System.Drawing.Size(20, 68);
            removeRow.TabIndex = 1;
            //   removeRow.Text = RowRemovalCounter + "";
            removeRow.UseVisualStyleBackColor = true;
            removeRow.ForeColor = Color.White;
            removeRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            removeRow.BackColor = System.Drawing.Color.Transparent;
            removeRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            removeRow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            removeRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            removeRow.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            removeRow.Location = new System.Drawing.Point(3, 3);
            removeRow.Size = new System.Drawing.Size(100, 80);


            removeRow.UseVisualStyleBackColor = false;
            removeRow.Text = "حذف";
            removeRow.Click += new System.EventHandler(this.removeRowF_Click);
            removeRow.AutoSize = true;
            removeRow.ForeColor = System.Drawing.Color.Pink;





            System.Windows.Forms.LinkLabel hiddinlabel = new System.Windows.Forms.LinkLabel();
            hiddinlabel.Text = secret;
            hiddinlabel.Visible = false;
            hiddinlabel.Size = new System.Drawing.Size(20, 20);


            Row.Controls.Add(hiddinlabel);
            Row.Controls.Add(PickADrink);
            Row.Controls.Add(l);
            Row.Controls.Add(amount);
            Row.Controls.Add(add);
            Row.Controls.Add(sub);
            Row.Controls.Add(pl);
            Row.Controls.Add(removeRow);

            OrderRowPanel.Controls.Add(Row);








        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {




        }
        double timeAsIntH = 0;
        double timeAsIntM = 0;
        int timeInMinits;

        private void button11_Click(object sender, EventArgs e)
        {





        }

        private void button16_Click(object sender, EventArgs e)
        {

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


        List<int> TableOrder = new List<int>();
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
            ItemHassBeenAdded = true;
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

                ItemHassBeenAdded = true;

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {



        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {



            BAL.printCus = printCB.Checked;
            BAL.PrintKitch = kitchenCB.Checked;

            bool haltAll = false;


            foreach (Control row in OrderRowPanel.Controls)
            {
                bool first = true;
                foreach (Control items in row.Controls)
                {
                    if (items is System.Windows.Forms.TextBox)
                    {

                        if (Convert.ToInt16(items.Text) == 0)
                        {
                            haltAll = true; break;
                        }


                    }
                }
            }

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

                if (thereIsRow)
                {
                    foreach (Control row in OrderRowPanel.Controls)
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
                                        BAL.DrinkListName.Add(items.Text.Split('-').First().Trim());


                                    }
                                    else
                                    if (selector == 2)
                                    {
                                        FoodListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                        BAL.FoodListName.Add(items.Text.Split('-').First().Trim());

                                    }
                                    else
                                    if (selector == 3)
                                    {
                                        ArgyListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                        BAL.ArgyListName.Add(items.Text.Split('-').First().Trim());

                                    }

                                    first = false;

                                }
                                else
                                {

                                    if (selector == 1)
                                    {

                                        BAL.DrinkListPrice.Add(items.Text);
                                    }
                                    else
                                    if (selector == 2)
                                    {

                                        BAL.FoodListPrice.Add(items.Text);
                                    }
                                    else
                                    if (selector == 3)
                                    {

                                        BAL.ArgyListPrice.Add(items.Text);
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


                if (BAL.DelOrders(Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString()))) { }







                BAL.DrinkAmount = DrinkListAmount;
                BAL.FoodAmount = FoodListAmount;
                BAL.ArgyAmount = ArgyListAmount;



                int ii = 0;

                if (BAL.UpdateRes(Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString()), Convert.ToInt32(tableIdLabel.Text), timeInMinits, TimeAndDateLabel.Text))
                {

                    int i = 0;
                    int iii = 0;
                    int iiii = 0;
                    foreach (int id in DrinkListID)
                    {
                        if (BAL.InsertDrinkOrder(DrinkListID.ElementAt(i), DrinkListAmount.ElementAt(i), TimeAndDateLabel.Text, Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString())))
                        {

                            i++;
                            // MessageBox.Show(i + "");
                            //  MessageBox.Show(DrinkAmount.Count()+"");


                        }
                    }
                    foreach (int id in FoodListID)
                    {
                        if (BAL.InsertFoodOrder(FoodListID.ElementAt(iii), FoodListAmount.ElementAt(iii), TimeAndDateLabel.Text, Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString())))

                        {

                            iii++;
                            // MessageBox.Show(i + "");
                            //  MessageBox.Show(DrinkAmount.Count()+"");


                        }
                    }
                    foreach (int id in ArgyListID)
                    {
                        if (BAL.InsertArgyOrder(ArgyListID.ElementAt(iiii), ArgyListAmount.ElementAt(iiii), TimeAndDateLabel.Text, Convert.ToInt32(BAL.ResDT.Rows[0]["ID"].ToString())))

                        {

                            iiii++;
                            // MessageBox.Show(i + "");
                            //  MessageBox.Show(DrinkAmount.Count()+"");


                        }
                    }

                    int u = 0;
                    List<string> DrinkListNameTemp = BAL.DrinkListName;
                    foreach (DataRow row in BAL.DrinksDT.Rows)
                    {
                        u = 0;
                        foreach (string st in DrinkListNameTemp.ToList())
                        {

                            if (row["DrinkName"].ToString().Equals(st) && (row["Amount"].ToString().Equals(BAL.DrinkAmount[u] + "")))
                            {


                                BAL.DrinkListName.RemoveAt(u);
                                BAL.DrinkListPrice.RemoveAt(u);
                                BAL.DrinkAmount.RemoveAt(u);


                            }
                            u++;
                        }
                    }
                    List<string> FoodListNameTemp = BAL.FoodListName;

                    foreach (DataRow row in BAL.FoodDT.Rows)
                    {
                        u = 0;
                        foreach (string st in FoodListNameTemp.ToList())
                        {

                            if (row["FoodName"].ToString().Equals(st) && (row["Amount"].ToString().Equals(BAL.FoodAmount[u] + "")))
                            {


                                BAL.FoodListName.RemoveAt(u);
                                BAL.FoodListPrice.RemoveAt(u);
                                BAL.FoodAmount.RemoveAt(u);


                            }
                            u++;
                        }
                    }
                    List<string> ArgyListNameTemp = BAL.ArgyListName;


                    foreach (DataRow row in BAL.ArgyDT.Rows)
                    {
                        u = 0;
                        foreach (string st in ArgyListNameTemp.ToList())
                        {

                            if (row["Argylah"].ToString().Equals(st) && (row["Amount"].ToString().Equals(BAL.ArgyAmount[u] + "")))
                            {


                                BAL.ArgyListName.RemoveAt(u);
                                BAL.ArgyListPrice.RemoveAt(u);
                                BAL.ArgyAmount.RemoveAt(u);


                            }

                            u++;
                        }
                    }
                    BAL.itemsHadBeenChanged = ItemHassBeenAdded;
                    BAL.timeAndDAte = TimeAndDateLabel.Text;
                    BAL.TableIDLabel = tableIdLabel.Text;

                   //Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) / 60;
                  //  Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) % 60;

                  //  ResDurLbl

                    BAL.TotalPrice = Convert.ToInt32(TotalPricelbl.Text) + "";


                    if (Convert.ToInt32(BAL.TotalPrice) < 0) { BAL.TotalPrice = (Convert.ToInt32(BAL.TotalPrice) * -1) + ""; }



                    BAL.okEdit = true;

                    this.Close();

                }
            }
            else
            {

                MessageBox.Show("الرجاء عدم ترك اي طلب بالكمية صفر ");
            }

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {







            BAL.AddedLast = 3;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {

                int u = BAL.ArgyIDHolderList.Count;
                for (int i = 0; i < u; i++)
                {
                    bool first = true;
                    RowGenerator(BAL.ArgyNameHolderList.Last() + "-" + BAL.ArgyIDHolderList.Last(), BAL.ArgyIDPriceList.Last() + "", "1", "3");

                    TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + Convert.ToInt16(BAL.ArgyIDPriceList.Last()) + "";


                    BAL.ArgyIDHolderList.Remove(BAL.ArgyIDHolderList.Last());
                    BAL.ArgyNameHolderList.Remove(BAL.ArgyNameHolderList.Last());
                    BAL.ArgyIDPriceList.Remove(BAL.ArgyIDPriceList.Last());

                }
                ItemHassBeenAdded = true;

            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            BAL.timeHasBeenChanged = true;
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
            BAL.newTimeInminits = timeInMinits;
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

        private void button14_Click(object sender, EventArgs e)
        {

            BAL.AddedLast = 2;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();



            if (BAL.dataEnterdByMenu)
            {
                int u = BAL.FoodIDHolderList.Count;

                for (int i = 0; i < u; i++)
                {
                    bool first = true;

                    RowGenerator(BAL.FoodNameHolderList.Last() + "-" + BAL.FoodIDHolderList.Last(), BAL.FoodIDPriceList.Last() + "", "1", "2");
                    TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + Convert.ToInt16(BAL.FoodIDPriceList.Last()) + "";


                    BAL.FoodIDHolderList.Remove(BAL.FoodIDHolderList.Last());
                    BAL.FoodNameHolderList.Remove(BAL.FoodNameHolderList.Last());
                    BAL.FoodIDPriceList.Remove(BAL.FoodIDPriceList.Last());




                }
                ItemHassBeenAdded = true;

            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            BAL.AddedLast = 1;
            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {

                int u = BAL.DrinkIDHolderList.Count;
                for (int i = 0; i < u; i++)
                {
                    bool first = true;

                    RowGenerator(BAL.DrinkNameHolderList.Last() + "-" + BAL.DrinkIDHolderList.Last(), BAL.DrinkIDPriceList.Last() + "", "1", "1");


                    TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + Convert.ToInt16(BAL.DrinkIDPriceList.Last()) + "";

                    BAL.DrinkIDHolderList.Remove(BAL.DrinkIDHolderList.Last());
                    BAL.DrinkNameHolderList.Remove(BAL.DrinkNameHolderList.Last());
                    BAL.DrinkIDPriceList.Remove(BAL.DrinkIDPriceList.Last());


                }
                ItemHassBeenAdded = true;
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
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
                BAL.timeHasBeenChanged = true;
                timeInMinits = Convert.ToInt32((timeAsIntH * 60) + timeAsIntM);
                BAL.newTimeInminits = timeInMinits;
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

        private void button13_Click_2(object sender, EventArgs e)
        {
            FloorLayout fl = new FloorLayout();
            var dialogResult = fl.ShowDialog();

            if (BAL.TableName.Length > 0)
            {
                button11.Enabled = true;
                button16.Enabled = true;
                DateTime now = DateTime.Now;
                TableOrder.Add(BAL.TableID);
                if (!(BAL.TableID == 0))
                {
                    TabelLabelName.Text = "رقم " + BAL.TableName;
                }
                else
                {
                    TabelLabelName.Text = BAL.TableName;

                }
                TimeAndDateLabel.Text = now.ToString("d") + " - " + now.ToString("t");
                tableIdLabel.Text = BAL.TableID + "";


                if (BAL.TableName.Equals("الطاولة") || BAL.TableName.Equals("الفيشة") || BAL.TableName.Equals("البليارد") || BAL.TableName.Equals("طلب خارجي"))
                {


                    button11.Enabled = false;
                    button16.Enabled = false;
                    timeInMinits = 0;

                }

            }
        }
    }


}
