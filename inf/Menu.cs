using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace inf
{
    public partial class Menu : Form
    {
        int DrinksCounter = 0;
        DataTable ItemsTbl = null;
        public Menu()
        {

            InitializeComponent();
            BAL.dataEnterdByMenu = false;


            BAL.DrinkIDHolderList.Clear();
            BAL.DrinkIDPriceList.Clear();
            BAL.DrinkNameHolderList.Clear();


            BAL.FoodIDHolderList.Clear();
            BAL.FoodIDPriceList.Clear();
            BAL.FoodNameHolderList.Clear();


            BAL.ArgyIDHolderList.Clear();
            BAL.ArgyIDPriceList.Clear();
            BAL.ArgyNameHolderList.Clear();


            if (BAL.AddedLast == 1)
            {
                ItemsTbl = BAL.GetDrinks();
            }
            else if (BAL.AddedLast == 2)
            {
                ItemsTbl = BAL.GetFood();

            }
            else if (BAL.AddedLast == 3)
            {
                ItemsTbl = BAL.GetArgy();

            }
            int switchCounter = 0 ;
            FlowLayoutPanel Row1 = new FlowLayoutPanel();
            FlowLayoutPanel Row2 = new FlowLayoutPanel();
            FlowLayoutPanel Row3 = new FlowLayoutPanel();
            FlowLayoutPanel Row4 = new FlowLayoutPanel();

            for (int i = 0; i < ItemsTbl.Rows.Count; i++)
            {



              

                Row1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
                Row1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Row1.FlowDirection = FlowDirection.LeftToRight;
                Row1.Size = new System.Drawing.Size(DrinksPanel.Width / 4 -10, DrinksPanel.Height- 144);
                Row1.AutoScroll = true;
               

                Row2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
                Row2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Row2.FlowDirection = FlowDirection.LeftToRight;
                Row2.Size = new System.Drawing.Size(DrinksPanel.Width / 4 - 10, DrinksPanel.Parent.Height- 144);
                Row2.AutoScroll = true;

                Row3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
                Row3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Row3.FlowDirection = FlowDirection.LeftToRight;
                Row3.Size = new System.Drawing.Size(DrinksPanel.Width / 4 - 10, DrinksPanel.Parent.Height - 144);
                Row3.AutoScroll = true;

                Row4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
                Row4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Row4.FlowDirection = FlowDirection.LeftToRight;
                Row4.Size = new System.Drawing.Size(DrinksPanel.Width/4 - 10, DrinksPanel.Parent.Height - 144);
                Row4.AutoScroll = true;
                //Row.AutoSize = true;

                DataRow result = ItemsTbl.Rows[i];


                CheckBox PickADrink = new CheckBox();

                PickADrink.BackColor = Color.White;
                PickADrink.Appearance = Appearance.Button;

                PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                PickADrink.Location = new System.Drawing.Point(3, 3);

                PickADrink.Size = new System.Drawing.Size(84, 68);
                PickADrink.TabIndex = 1;
                DrinksCounter++;
                PickADrink.Text = result[1].ToString() + " - " + result[0].ToString();
                PickADrink.UseVisualStyleBackColor = true;
                PickADrink.ForeColor = Color.Black;
               
                PickADrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));

                //PickADrink.BackColor = System.Drawing.Color.White;
         


                if (!result["Color"].ToString().Equals(""))
                {
                    Row1.BackColor = ColorTranslator.FromHtml("#0099F4"); ;
                    Row2.BackColor = ColorTranslator.FromHtml("#E5A66D"); ;
                    Row3.BackColor = ColorTranslator.FromHtml("#EBDF7B"); ;
                    Row4.BackColor = ColorTranslator.FromHtml("#B92B4A"); ;

                    Row1.BackColor = Color.Black;
                    Row2.BackColor = Color.Black;
                    Row3.BackColor = Color.Black;
                    Row4.BackColor = Color.Black;

                }
                else {
                    Row1.BackColor = Color.White;
                    Row2.BackColor = Color.White;
                    Row3.BackColor = Color.White;
                    Row4.BackColor = Color.White;


                }

                PickADrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                PickADrink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                PickADrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                PickADrink.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                PickADrink.Location = new System.Drawing.Point(3, 3);
               // PickADrink.Size = new System.Drawing.Size(200, 80);
                PickADrink.Size = new System.Drawing.Size(DrinksPanel.Width / 4 - 15, 80);
                PickADrink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                PickADrink.UseVisualStyleBackColor = false;

                PickADrink.Click += new System.EventHandler(this.PickADrink_Click);

                if (PickADrink.Text.ToCharArray().Count()>10) {

                    PickADrink.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);


                }

                string ColorHash = "";
                if (result["Color"].ToString().Equals("1"))
                {
                    PickADrink.BackColor = ColorTranslator.FromHtml("#0099F4"); 
                    Row1.Controls.Add(PickADrink);

                }
                else if (result["Color"].ToString().Equals("2"))
                {
                    PickADrink.BackColor = ColorTranslator.FromHtml("#E5A66D"); ;

                    Row2.Controls.Add(PickADrink);

                }
                else if (result["Color"].ToString().Equals("3"))
                {

                    PickADrink.BackColor = ColorTranslator.FromHtml("#EBDF7B"); ;

                    Row3.Controls.Add(PickADrink);

                }
                else {

                    PickADrink.BackColor = ColorTranslator.FromHtml("#B92B4A"); ;

                    Row4.Controls.Add(PickADrink);

                }


                // Row.Controls.Add(PickADrink);
                DrinksPanel.Controls.Add(Row1);
                DrinksPanel.Controls.Add(Row2);
                DrinksPanel.Controls.Add(Row3);
                DrinksPanel.Controls.Add(Row4);

                /*string ColorHash = "";
                if (result["Color"].ToString().Equals("1"))
                {

                    ColorHash = "#0099F4";

                }
                else if (result["Color"].ToString().Equals("2"))
                {
                    ColorHash = "#E5A66D";

                }
                else if (result["Color"].ToString().Equals("3"))
                {
                    ColorHash = "#EBDF7B";

                }
                else if (result["Color"].ToString().Equals("4"))
                {
                    ColorHash = "#B92B4A";

                }*/
            }



        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }




        private void PickADrink_Click(object sender, EventArgs e)
        {

            /*  CheckBox btn = sender as CheckBox;

              // MessageBox.Show(btn.Text.Split('-').Last());
              // MessageBox.Show(btn.Text.Split('-').First());



              if (BAL.AddedLast == 1) { 
              BAL.DrinkIDHolder = Convert.ToInt32(btn.Text.Split('-').Last());
              BAL.DrinkNameHolder = btn.Text.Split('-').First();

                  foreach (DataRow r in ItemsTbl.Rows) {


                      if (Convert.ToInt16(r[0].ToString()) == BAL.DrinkIDHolder) { 

                          BAL.DrinkIDPrice = Convert.ToInt32(r[2].ToString());

                      }

                  }


                  }else if(BAL.AddedLast == 2)
              {


                  BAL.FoodIDHolder = Convert.ToInt32(btn.Text.Split('-').Last());
                  BAL.FoodNameHolder = btn.Text.Split('-').First();
                  foreach (DataRow r in ItemsTbl.Rows)
                  {


                      if (Convert.ToInt16(r[0].ToString()) == BAL.FoodIDHolder)
                      {

                          BAL.FoodIDHPrice = Convert.ToInt32(r[2].ToString());

                      }

                  }
              }
              else if (BAL.AddedLast == 3)
              {


                  BAL.ArgyIDHolder = Convert.ToInt32(btn.Text.Split('-').Last());
                  BAL.ArgyNameHolder = btn.Text.Split('-').First();
                  foreach (DataRow r in ItemsTbl.Rows)
                  {


                      if (Convert.ToInt16(r[0].ToString()) == BAL.ArgyIDHolder)
                      {

                          BAL.ArgyIDPrice = Convert.ToInt32(r[2].ToString());

                      }

                  }
              }*/

            //   this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (BAL.AddedLast == 1)
            {


                foreach (Control cc in DrinksPanel.Controls)
                {
                    foreach (Control c in cc.Controls)
                    {
                        if (c is CheckBox)
                    {
                        System.Windows.Forms.CheckBox cb = c as System.Windows.Forms.CheckBox;

                        if (cb.Checked)
                        {

                            BAL.DrinkIDHolderList.Add(Convert.ToInt32(c.Text.Split('-').Last()));
                            BAL.DrinkNameHolderList.Add(c.Text.Split('-').First());
                                BAL.dataEnterdByMenu = true;
                                foreach (DataRow r in ItemsTbl.Rows)
                            {


                                if (Convert.ToInt16(r[0].ToString()) == BAL.DrinkIDHolderList.Last())
                                {

                                    BAL.DrinkIDPriceList.Add(Convert.ToInt32(r[2].ToString()));

                                }
                            }


                        }
                        }

                    }
                }



            }
            else if (BAL.AddedLast == 2)
            {
                foreach (Control cc in DrinksPanel.Controls)
                {
                    foreach (Control c in cc.Controls)
                    {
                        if (c is CheckBox)
                    {
                        System.Windows.Forms.CheckBox cb = c as System.Windows.Forms.CheckBox;

                        if (cb.Checked)
                        {

                            BAL.FoodIDHolderList.Add(Convert.ToInt32(c.Text.Split('-').Last()));
                            BAL.FoodNameHolderList.Add(c.Text.Split('-').First());
                                BAL.dataEnterdByMenu = true;
                                foreach (DataRow r in ItemsTbl.Rows)
                            {


                                if (Convert.ToInt16(r[0].ToString()) == BAL.FoodIDHolderList.Last())
                                {

                                    BAL.FoodIDPriceList.Add(Convert.ToInt32(r[2].ToString()));

                                }
                            }


                        }

                    }
                    }
                }



            }
            else if (BAL.AddedLast == 3)
            {
                foreach (Control cc in DrinksPanel.Controls)
                {
                    foreach (Control c in cc.Controls)
                    {
                        if (c is CheckBox)
                    {
                        System.Windows.Forms.CheckBox cb = c as System.Windows.Forms.CheckBox;

                        if (cb.Checked)
                        {
                            BAL.ArgyIDHolderList.Add(Convert.ToInt32(c.Text.Split('-').Last()));
                            BAL.ArgyNameHolderList.Add(c.Text.Split('-').First());
                             
                                BAL.dataEnterdByMenu=   true;
                            foreach (DataRow r in ItemsTbl.Rows)
                            {


                                if (Convert.ToInt16(r[0].ToString()) == BAL.ArgyIDHolderList.Last())
                                {

                                    BAL.ArgyIDPriceList.Add(Convert.ToInt32(r[2].ToString()));

                                }
                            }
                        }
                    }
                }
                }


            }


            this.Close();
        }
    }
}
