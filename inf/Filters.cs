using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace inf
{
    public partial class Filters : Form
    {
        System.Data.DataTable DrinksDT = new System.Data.DataTable();
        System.Data.DataTable FoodDT = new System.Data.DataTable();
        System.Data.DataTable ArgyDT = new System.Data.DataTable();

        public Filters()
        {
            InitializeComponent();
            DrinksDT = BAL.GetDrinks();
            FoodDT = BAL.GetFood();
            ArgyDT = BAL.GetArgy();

            // fromTimePicker.Format = DateTimePickerFormat.Time;
            fromTimePicker.ShowUpDown = true;
            // toTimePicker.Format = DateTimePickerFormat.Time;
            toTimePicker.ShowUpDown = true;


            fromTimePicker.CustomFormat = "hh:mm tt";
            toTimePicker.CustomFormat = "hh:mm tt";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void foodCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void argyCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabelCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {



        }

        private void fromToCB_CheckedChanged(object sender, EventArgs e)
        {
        }
        int from = 0;
        private void toBtn_Click(object sender, EventArgs e)
        {

            // calander.Enabled = true;



        }

        private void fromBtn_Click(object sender, EventArgs e)
        {
            //  calander.Enabled = true;



        }

        private void calander_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        int drinkId;
        int foodId;
        int argyId;
        private void drinkBtn_Click(object sender, EventArgs e)
        {




        }

        private void foodBtn_Click(object sender, EventArgs e)
        {

        }

        private void argyBtn_Click(object sender, EventArgs e)
        {


        }
        int tabelId;
        private void tabelBtn_Click(object sender, EventArgs e)
        {

        }
        double timeAsIntH = 0;
        double timeAsIntM = 0;
        int timeInMinits;
        private void plusBtn_Click(object sender, EventArgs e)
        {

        }

        private void subBtn_Click(object sender, EventArgs e)
        {






        }
        public string GetItemPrice(int flag, string ID)
        {
            string name = "";

            if (flag == 1)
            {
                foreach (DataRow row in DrinksDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["DrinkPrice"].ToString();

                    }

                }

            }
            else if (flag == 2)
            {
                foreach (DataRow row in FoodDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["FoodPrice"].ToString();

                    }

                }
            }
            else if (flag == 3)
            {

                foreach (DataRow row in ArgyDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["ArgylahPrice"].ToString();

                    }

                }

            }
            return name;

        }

        int totalDrinkAmount = 0;
        int totalFoodAmount = 0;
        int totalArgyAmount = 0;

        int totalDrinkPrice = 0;
        int totalFoodPrice = 0;
        int totalArgyPrice = 0;

        int totalPrice = 0;

        public string GetItemName(int flag, string ID)
        {
            string name = "";

            if (flag == 1)
            {
                foreach (DataRow row in DrinksDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["DrinkName"].ToString();

                    }

                }

            }
            else if (flag == 2)
            {
                foreach (DataRow row in FoodDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["FoodName"].ToString();

                    }

                }
            }
            else if (flag == 3)
            {

                foreach (DataRow row in ArgyDT.Rows)
                {

                    if (row["ID"].ToString().Equals(ID))
                    {

                        name = row["Argylah"].ToString();

                    }

                }

            }
            return name;

        }
        public System.Data.DataTable SetUpDataTable(System.Data.DataTable RawTable)
        {


            System.Data.DataTable drinksTable = new System.Data.DataTable();
            System.Data.DataTable foodTable = new System.Data.DataTable(); ;
            System.Data.DataTable argyTable = new System.Data.DataTable(); ;

            Hashtable hTable3 = new Hashtable();
         
            ArrayList duplicateList3 = new ArrayList();
         

            if (allArgyCB.Checked) {
               // MessageBox.Show("a");
                argyTable = RawTable; 
            foreach (DataRow drow in argyTable.Rows)
            {
                if (hTable3.Contains(drow["ID3"]))


                {
                    duplicateList3.Add(drow);
                }
                else
                {
                    hTable3.Add(drow["ID3"], string.Empty);
              

                }
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList3)
                    argyTable.Rows.Remove(dRow);




                argyTable.AcceptChanges();
                RawTable = argyTable;
        }
            if (allFoodCB.Checked)
            {
                foodTable = RawTable;

                Hashtable hTable2 = new Hashtable();
                ArrayList duplicateList2 = new ArrayList();


                foreach (DataRow drow in foodTable.Rows)
                {
                    if (hTable2.Contains(drow["ID2"]))
                        duplicateList2.Add(drow);
                    else
                        hTable2.Add(drow["ID2"], string.Empty);
                }

                //Removing a list of duplicate items from datatable.
                foreach (DataRow dRow in duplicateList2)
                    foodTable.Rows.Remove(dRow);



                foodTable.AcceptChanges();

                RawTable = foodTable;

            }
            if (allDrinksCB.Checked)
            {
                drinksTable = RawTable;

                Hashtable hTable1 = new Hashtable();
                ArrayList duplicateList1 = new ArrayList();


                foreach (DataRow drow in drinksTable.Rows)
                {
                    if (hTable1.Contains(drow["ID1"]))
                        duplicateList1.Add(drow);
                    else
                        hTable1.Add(drow["ID1"], string.Empty);
                }

                //Removing a list of duplicate items from datatable.
                foreach (DataRow dRow in duplicateList1)
                    drinksTable.Rows.Remove(dRow);



                drinksTable.AcceptChanges();
                RawTable = drinksTable;

            }







            if (RawTable.Rows.Count < 1)
            {


                return null;


            }

            totalDrinkAmount = 0;
            totalFoodAmount = 0;
            totalArgyAmount = 0;

            totalDrinkPrice = 0;
            totalFoodPrice = 0;
            totalArgyPrice = 0;
            totalPrice = 0;


            //  string tf = @fromTimePicker.Value.ToString().Substring(@fromTimePicker.Value.ToString().Length - 10); 
            string tf = @fromTimePicker.Text.ToString();
            // tf.Replace(@tf.ToString().Split(' ').First(), selectDayLbl.Text);


            //  string tt = @toTimePicker.Value.ToString().Substring(@toTimePicker.Value.ToString().Length - 10);
            string tt = @toTimePicker.Text.ToString();
            // tt.Replace(@tt.ToString().Split(' ').First(), selectDayLbl.Text);

            //string fromTime = selectDayLbl.Text.Split(' ').First().Trim() + " " + tf;
            //string toTime = selectDayLbl.Text.Split(' ').First().Trim() + " " + tt;

            //  fromTime = fromTime.Replace(fromTime.Split(' ').Last().Trim()+"", "");
            //  toTime = toTime.Replace(toTime.Split(' ').Last().Trim() + "", "");
            //  int test = System.DateTime.Compare(System.DateTime.Parse(tf, CultureInfo.InvariantCulture), System.DateTime.Parse(tt, CultureInfo.InvariantCulture));


            //  MessageBox.Show(test+"");
            //  MessageBox.Show(tt);

            if (fromToCB.Checked)
            {

                if (!fromLbl.Text.Equals("-------") || !toLbl.Text.Equals("-------"))
                {
                    System.Data.DataTable temp = RawTable;
                    // foreach (DataRow r in temp.Rows)
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {

                        if ((System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split(' ').First().Trim(), CultureInfo.InvariantCulture) < System.DateTime.Parse(fromLbl.Text, CultureInfo.InvariantCulture)) || (System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split(' ').First().Trim(), CultureInfo.InvariantCulture) > System.DateTime.Parse(toLbl.Text, CultureInfo.InvariantCulture)))

                        {








                            RawTable.Rows[i].Delete();



                        }


                    }


                    temp = RawTable;
                    RawTable.AcceptChanges();

                    if (RawTable.Rows.Count == 0)
                    {
                        return null;
                    }


                    for (int i = 0; i < temp.Rows.Count; i++)
                    {


                        string timeFromDB = (System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim()).ToString("HH:mm"));
                        string timetf = (System.DateTime.Parse(tf).ToString("HH:mm"));
                        string timett = (System.DateTime.Parse(tt).ToString("HH:mm"));


                      //  MessageBox.Show(timeFromDB);
                        int resultsF = System.DateTime.Compare(System.DateTime.Parse(timeFromDB, CultureInfo.InvariantCulture), System.DateTime.Parse(timetf, CultureInfo.InvariantCulture));
                        int resultsT = System.DateTime.Compare(System.DateTime.Parse(timeFromDB, CultureInfo.InvariantCulture), System.DateTime.Parse(timett, CultureInfo.InvariantCulture));
                        int resultsofSmallerAndBiger = System.DateTime.Compare(System.DateTime.Parse(timetf, CultureInfo.InvariantCulture), System.DateTime.Parse(timett, CultureInfo.InvariantCulture));


                        // if (System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim(), CultureInfo.InvariantCulture) <= (System.DateTime.Parse(tf, CultureInfo.InvariantCulture)) || System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim(), CultureInfo.InvariantCulture) >= (System.DateTime.Parse(tt, CultureInfo.InvariantCulture)))

                        if (resultsofSmallerAndBiger < 0)
                        {

                            if (resultsF < 0 || resultsT > 0)
                            {
                                RawTable.Rows[i].Delete();


                            }

                        }
                        else {

                            if (resultsF < 0 && resultsT > 0)
                            {
                                RawTable.Rows[i].Delete();


                            }
                        }




                    }


                }
                else { MessageBox.Show("يجب تحديد الفترة الزمنية"); }


            }
            else if (selectDayCB.Checked)
            {

                if (!selectDayLbl.Text.Equals("-------"))
                {
                    System.Data.DataTable temp = RawTable;
                    // foreach (DataRow r in temp.Rows)
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {

                        if ((System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split(' ').First().Trim(), CultureInfo.InvariantCulture) != System.DateTime.Parse(selectDayLbl.Text, CultureInfo.InvariantCulture)))

                        {
                            RawTable.Rows[i].Delete();



                        }


                    }

                    temp = RawTable;
                    RawTable.AcceptChanges();
                    if (RawTable.Rows.Count == 0)
                    {
                        return null;
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {


                        string timeFromDB = (System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim()).ToString("HH:mm"));
                        string timetf = (System.DateTime.Parse(tf).ToString("HH:mm"));
                        string timett = (System.DateTime.Parse(tt).ToString("HH:mm"));

                        int resultsF = System.DateTime.Compare(System.DateTime.Parse(timeFromDB, CultureInfo.InvariantCulture), System.DateTime.Parse(timetf, CultureInfo.InvariantCulture));
                        int resultsT = System.DateTime.Compare(System.DateTime.Parse(timeFromDB, CultureInfo.InvariantCulture), System.DateTime.Parse(timett, CultureInfo.InvariantCulture));
                        int resultsofSmallerAndBiger = System.DateTime.Compare(System.DateTime.Parse(timetf, CultureInfo.InvariantCulture), System.DateTime.Parse(timett, CultureInfo.InvariantCulture));


                        // if (System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim(), CultureInfo.InvariantCulture) <= (System.DateTime.Parse(tf, CultureInfo.InvariantCulture)) || System.DateTime.Parse(RawTable.Rows[i]["TimeAndDate"].ToString().Split('-').Last().Trim(), CultureInfo.InvariantCulture) >= (System.DateTime.Parse(tt, CultureInfo.InvariantCulture)))
                        if (resultsofSmallerAndBiger < 0)
                        {

                            if (resultsF < 0 || resultsT > 0)
                            {
                                RawTable.Rows[i].Delete();


                            }

                        }
                        else
                        {

                            if (resultsF < 0 && resultsT > 0)
                            {
                                RawTable.Rows[i].Delete();


                            }
                        }




                    }



                }






                else { MessageBox.Show("يجب تحديد الفترة الزمنية"); }


            }
            //  DataTable tempDT = RawTable;
            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            RawTable.Columns.Add("DrinkName", typeof(String));
            RawTable.Columns["DrinkName"].SetOrdinal(RawTable.Columns["TimeAndDate"].Ordinal + 1);


            RawTable.Columns.Add("DrinkPrice", typeof(String));
            RawTable.Columns["DrinkPrice"].SetOrdinal(RawTable.Columns["DrinkName"].Ordinal);

            RawTable.Columns.Add("FoodName", typeof(String));
            RawTable.Columns.Add("FoodPrice", typeof(String));
            RawTable.Columns["FoodName"].SetOrdinal(RawTable.Columns["ResRecordID"].Ordinal + 1);
            RawTable.Columns["FoodPrice"].SetOrdinal(RawTable.Columns["FoodName"].Ordinal);

            RawTable.Columns.Add("ArgylahName", typeof(String));
            RawTable.Columns.Add("ArgylahPrice", typeof(String));
            RawTable.Columns["ArgylahName"].SetOrdinal(RawTable.Columns["TimeAndDate2"].Ordinal + 1);
            RawTable.Columns["ArgylahPrice"].SetOrdinal(RawTable.Columns["ArgylahName"].Ordinal);



            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow row in RawTable.Rows)
            {

                if (row["DrinkID"].ToString().Length > 0)
                {

                    row["DrinkName"] = GetItemName(1, row["DrinkID"].ToString());
                    row["DrinkPrice"] = GetItemPrice(1, row["DrinkID"].ToString());

                    if (row["DrinkPrice"].ToString().Length > 0)
                    {
                        totalDrinkPrice += Convert.ToInt32(row["DrinkPrice"]) * Convert.ToInt32(row["Amount"]);
                        totalDrinkAmount += Convert.ToInt32(row["Amount"]);

                    }
                }
                if (row["FoodID"].ToString().Length > 0)
                {

                    row["FoodName"] = GetItemName(2, row["FoodID"].ToString());
                    row["FoodPrice"] = GetItemPrice(2, row["FoodID"].ToString());

                    if (row["FoodPrice"].ToString().Length > 0)
                    {
                        totalFoodPrice += Convert.ToInt32(row["FoodPrice"]) * Convert.ToInt32(row["Amount1"]);
                        totalFoodAmount += Convert.ToInt32(row["Amount1"]);

                    }

                }
                if (row["ArgylahID"].ToString().Length > 0)
                {

                    row["ArgylahName"] = GetItemName(3, row["ArgylahID"].ToString());
                    row["ArgylahPrice"] = GetItemPrice(3, row["ArgylahID"].ToString());

                    if (row["ArgylahPrice"].ToString().Length > 0)
                    {
                        totalArgyPrice += Convert.ToInt32(row["ArgylahPrice"]) * Convert.ToInt32(row["Amount2"]);
                        totalArgyAmount += Convert.ToInt32(row["Amount2"]);

                    }

                }

            }
            /*  int firstRowID3=0;
              for (int i = 0; i < RawTable.Rows.Count; i++)
              {

                  if (RawTable.Rows[0]["ID3"].ToString().Count() > 0) {
                      firstRowID3 = Convert.ToInt32(RawTable.Rows[i]["ID3"].ToString());
                      i = RawTable.Rows.Count;
                      break;
                  }
              }*/



            /*   // totalPrice = ((Convert.ToInt32(RawTable.Rows[0]["ResDuration"].ToString())) / 30) * 2000;
               for (int i = 1; i < RawTable.Rows.Count; i++)
               {

                   if (RawTable.Rows[i]["ID3"].ToString().Count() > 0)
                   {
                       if ((Convert.ToInt32(RawTable.Rows[i]["ID3"].ToString()) == (firstRowID3)))
                       {

                            MessageBox.Show(RawTable.Rows[i]["ID3"].ToString() + "");
                           RawTable.Rows[i].Delete();



                       }
                       else
                       {

                           firstRowID3 = Convert.ToInt32(RawTable.Rows[i]["ID3"].ToString());

                       }

                   }

               }
   */

            /*  var UniqueRows = RawTable.AsEnumerable().Distinct(DataRowComparer.Default);
              RawTable = UniqueRows.CopyToDataTable();
  */


            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.






             RawTable.Columns.Remove(RawTable.Columns["ID3"]);

            RawTable.Columns.Remove(RawTable.Columns["ArgylahID"]);
            RawTable.Columns.Remove(RawTable.Columns["ID2"]);

            RawTable.Columns.Remove(RawTable.Columns["FoodID"]);
            RawTable.Columns.Remove(RawTable.Columns["DrinkID"]);
            RawTable.Columns.Remove(RawTable.Columns["ID1"]);




            RawTable.AcceptChanges(); if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            if (drinksCB.Checked || allDrinksCB.Checked)
            {
                if (!allFoodCB.Checked && RawTable.Columns.Contains("Amount1"))
                {

                    RawTable.Columns.Remove(RawTable.Columns["Amount1"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate2"]);
                    RawTable.Columns.Remove(RawTable.Columns["RedRecordID"]);




                    RawTable.Columns.Remove(RawTable.Columns["FoodName"]);
                    RawTable.Columns.Remove(RawTable.Columns["FoodPrice"]);
                }

                if (!allArgyCB.Checked && RawTable.Columns.Contains("Amount2"))
                {

                    RawTable.Columns.Remove(RawTable.Columns["ArgylahName"]);
                    RawTable.Columns.Remove(RawTable.Columns["ArgylahPrice"]);


                    RawTable.Columns.Remove(RawTable.Columns["Amount2"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate3"]);
                    RawTable.Columns.Remove(RawTable.Columns["ResRecordID1"]);
                }
                if (allDrinksCB.Checked && !allFoodCB.Checked && !allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allDrinksCB.Checked && allFoodCB.Checked && !allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allDrinksCB.Checked && !allFoodCB.Checked && allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }

                else if (allDrinksCB.Checked && allFoodCB.Checked && allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1 && RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }

                RawTable.AcceptChanges();
                if (RawTable.Rows.Count == 0)
                {
                    return null;
                }
            }
            if (foodCB.Checked || allFoodCB.Checked)
            {

                if (!allDrinksCB.Checked && RawTable.Columns.Contains("Amount"))
                {

                    RawTable.Columns.Remove(RawTable.Columns["Amount"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate1"]);
                    RawTable.Columns.Remove(RawTable.Columns["ResRecordID"]);
                    RawTable.Columns.Remove(RawTable.Columns["DrinkName"]);
                    RawTable.Columns.Remove(RawTable.Columns["DrinkPrice"]);

                }
                if (!allArgyCB.Checked && RawTable.Columns.Contains("Amount2"))
                {
                    RawTable.Columns.Remove(RawTable.Columns["Amount2"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate3"]);
                    RawTable.Columns.Remove(RawTable.Columns["ResRecordID1"]);



                    RawTable.Columns.Remove(RawTable.Columns["ArgylahName"]);
                    RawTable.Columns.Remove(RawTable.Columns["ArgylahPrice"]);

                }


                if (allFoodCB.Checked && !allDrinksCB.Checked && !allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allFoodCB.Checked && allDrinksCB.Checked && !allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allFoodCB.Checked && !allDrinksCB.Checked && allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["FoodName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }

                else if (allFoodCB.Checked && allDrinksCB.Checked && allArgyCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1 && RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }

                RawTable.AcceptChanges();
                if (RawTable.Rows.Count == 0)
                {
                    return null;
                }
            }
            if (argyCB.Checked || allArgyCB.Checked)
            {
                if (!allDrinksCB.Checked && RawTable.Columns.Contains("Amount"))
                {
                    RawTable.Columns.Remove(RawTable.Columns["Amount"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate1"]);
                    RawTable.Columns.Remove(RawTable.Columns["ResRecordID"]);

                    RawTable.Columns.Remove(RawTable.Columns["DrinkName"]);
                    RawTable.Columns.Remove(RawTable.Columns["DrinkPrice"]);
                }

                if (!allFoodCB.Checked && RawTable.Columns.Contains("Amount1"))
                {
                    RawTable.Columns.Remove(RawTable.Columns["Amount1"]);
                    RawTable.Columns.Remove(RawTable.Columns["TimeAndDate2"]);
                    RawTable.Columns.Remove(RawTable.Columns["RedRecordID"]);


                    RawTable.Columns.Remove(RawTable.Columns["FoodName"]);
                    RawTable.Columns.Remove(RawTable.Columns["FoodPrice"]);
                }



                if (allArgyCB.Checked && !allDrinksCB.Checked && !allFoodCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["ArgylahName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allArgyCB.Checked && allDrinksCB.Checked && !allFoodCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                else if (allArgyCB.Checked && !allDrinksCB.Checked && allFoodCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["FoodName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }

                else if (allArgyCB.Checked && allDrinksCB.Checked && allFoodCB.Checked)
                {




                    for (int i = 0; i < RawTable.Rows.Count; i++)
                    {

                        if (RawTable.Rows[i]["DrinkName"].ToString().Length < 1 && RawTable.Rows[i]["ArgylahName"].ToString().Length < 1 && RawTable.Rows[i]["FoodName"].ToString().Length < 1)

                        {

                            RawTable.Rows[i].Delete();


                        }


                    }

                }
                RawTable.AcceptChanges();

                if (RawTable.Rows.Count == 0)
                {
                    return null;
                }

            }

            if (allTablesCB.Checked)

            {


                for (int i = 0; i < RawTable.Rows.Count; i++)
                {


                    if ((Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) >= 1 && Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) <= 19)
||
                        Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) == 99 ||
                        Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) == 100)
                    {

                        RawTable.Rows[i].Delete();



                    }


                }


            }

            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }

            if (allPSCB.Checked)

            {


                for (int i = 0; i < RawTable.Rows.Count; i++)
                {


                    if ((Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) > 19) ||
                        Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) == 0)
                    {

                        if (Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) != 99 && (Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) != 100))

                        {


                            RawTable.Rows[i].Delete();
                        }

                    }



                }

                RawTable.AcceptChanges();
                string firstRowID = RawTable.Rows[0]["ID"].ToString();
                totalPrice = ((Convert.ToInt32(RawTable.Rows[0]["ResDuration"].ToString())) / 30) * 2000;
                for (int i = 1; i < RawTable.Rows.Count; i++)
                {


                    if ((RawTable.Rows[i]["ID"].ToString().Equals(firstRowID)))
                    {

                        //MessageBox.Show(RawTable.Rows[i]["ID"].ToString() +"");
                        RawTable.Rows[i].Delete();



                    }
                    else
                    {

                        firstRowID = RawTable.Rows[i]["ID"].ToString();
                        if (Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) == 100)
                        {
                            totalPrice += ((Convert.ToInt32(RawTable.Rows[i]["ResDuration"].ToString())) / 30) * 4000;
                        }
                        else if (Convert.ToInt32(RawTable.Rows[i]["TableOrPs"].ToString()) == 99)
                        {
                            int switcher = 1000;
                            int total = 0;
                            for (int ii = 0; ii < Convert.ToInt32(RawTable.Rows[i]["ResDuration"].ToString()) / 30; ii++)
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
                                totalPrice += total;
                            }

                        }
                        else
                        {
                            totalPrice += ((Convert.ToInt32(RawTable.Rows[i]["ResDuration"].ToString())) / 30) * 2000;
                        }
                    }



                }







                RawTable.Columns.Remove(RawTable.Columns["Amount"]);
                RawTable.Columns.Remove(RawTable.Columns["TimeAndDate1"]);
                RawTable.Columns.Remove(RawTable.Columns["ResRecordID"]);

                RawTable.Columns.Remove(RawTable.Columns["DrinkName"]);
                RawTable.Columns.Remove(RawTable.Columns["DrinkPrice"]);


                RawTable.Columns.Remove(RawTable.Columns["Amount1"]);
                RawTable.Columns.Remove(RawTable.Columns["TimeAndDate2"]);
                RawTable.Columns.Remove(RawTable.Columns["RedRecordID"]);


                RawTable.Columns.Remove(RawTable.Columns["FoodName"]);
                RawTable.Columns.Remove(RawTable.Columns["FoodPrice"]);

                RawTable.Columns.Remove(RawTable.Columns["ArgylahName"]);
                RawTable.Columns.Remove(RawTable.Columns["ArgylahPrice"]);


                RawTable.Columns.Remove(RawTable.Columns["Amount2"]);
                RawTable.Columns.Remove(RawTable.Columns["TimeAndDate3"]);
                RawTable.Columns.Remove(RawTable.Columns["ResRecordID1"]);

            }

            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }

            /*    int totalDrinkAmount = 0;
                int totalFoodAmount = 0;
                int totalArgyAmount = 0;

                int totalDrinkPrice = 0;
                int totalFoodPrice = 0;
                int totalArgyPrice = 0;

                int totalPrice = 0;*/
            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            if (RawTable.Rows.Count > 0)



                if (drinksCB.Checked || allDrinksCB.Checked)
                {
                    RawTable.AcceptChanges();
                    if (RawTable.Rows.Count == 0)
                    {
                        return null;
                    }
                    totalPrice += totalDrinkPrice;

                    RawTable.Columns.Add("totalDrinkPrice", typeof(String));
                    RawTable.Columns["totalDrinkPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                    RawTable.Columns.Add("totalDrinkAmount", typeof(String));
                    RawTable.Columns["totalDrinkAmount"].SetOrdinal(RawTable.Columns.Count - 1);



                    RawTable.Rows[0]["totalDrinkPrice"] = totalDrinkPrice + "";
                    RawTable.Rows[0]["totalDrinkAmount"] = totalDrinkAmount + "";




                }
            RawTable.AcceptChanges();

            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            if (foodCB.Checked || allFoodCB.Checked)
            {


                totalPrice += totalFoodPrice;

                RawTable.Columns.Add("totalFoodPrice", typeof(String));
                RawTable.Columns["totalFoodPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                RawTable.Columns.Add("totalFoodAmount", typeof(String));
                RawTable.Columns["totalFoodAmount"].SetOrdinal(RawTable.Columns.Count - 1);




                RawTable.Rows[0]["totalFoodPrice"] = totalFoodPrice + "";
                RawTable.Rows[0]["totalFoodAmount"] = totalFoodAmount + "";




            }
            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            if (argyCB.Checked || allArgyCB.Checked)
            {



                totalPrice += totalArgyPrice;



                RawTable.Columns.Add("totalArgyPrice", typeof(String));
                RawTable.Columns["totalArgyPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                RawTable.Columns.Add("totalArgyAmount", typeof(String));
                RawTable.Columns["totalArgyAmount"].SetOrdinal(RawTable.Columns.Count - 1);




                RawTable.Rows[0]["totalArgyPrice"] = totalArgyPrice + "";

                RawTable.Rows[0]["totalArgyAmount"] = totalArgyAmount + "";


            }
            RawTable.AcceptChanges();
            if (RawTable.Rows.Count == 0)
            {
                return null;
            }
            if (drinksCB.Checked || allDrinksCB.Checked)
            {



            }
            else if (foodCB.Checked || allFoodCB.Checked)
            {





            }
            else if (argyCB.Checked || allArgyCB.Checked)
            {






            }
            else if (allPSCB.Checked)
            {




            }
            else
            {


                totalPrice = totalDrinkPrice + totalFoodPrice + totalArgyPrice;

                RawTable.Columns.Add("totalDrinkPrice", typeof(String));
                RawTable.Columns["totalDrinkPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                RawTable.Columns.Add("totalDrinkAmount", typeof(String));
                RawTable.Columns["totalDrinkAmount"].SetOrdinal(RawTable.Columns.Count - 1);


                RawTable.Rows[0]["totalDrinkPrice"] = totalDrinkPrice + "";
                RawTable.Rows[0]["totalDrinkAmount"] = totalDrinkAmount + "";
                RawTable.Columns.Add("totalFoodPrice", typeof(String));
                RawTable.Columns["totalFoodPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                RawTable.Columns.Add("totalFoodAmount", typeof(String));
                RawTable.Columns["totalFoodAmount"].SetOrdinal(RawTable.Columns.Count - 1);


                RawTable.Rows[0]["totalFoodPrice"] = totalFoodPrice + "";
                RawTable.Columns.Add("totalArgyPrice", typeof(String));
                RawTable.Columns["totalArgyPrice"].SetOrdinal(RawTable.Columns.Count - 1);

                RawTable.Rows[0]["totalFoodAmount"] = totalFoodAmount + "";

                RawTable.Columns.Add("totalArgyAmount", typeof(String));
                RawTable.Columns["totalArgyAmount"].SetOrdinal(RawTable.Columns.Count - 1);


                RawTable.Rows[0]["totalArgyPrice"] = totalArgyPrice + "";

                RawTable.Rows[0]["totalArgyAmount"] = totalArgyAmount + "";
            }
            RawTable.Columns.Add("totalPrice", typeof(String));
            RawTable.Columns["totalPrice"].SetOrdinal(RawTable.Columns.Count - 1);
            RawTable.Rows[0]["totalPrice"] = totalPrice + "";

            // for (int i = 0; i < RawTable.Columns.Count; i++) {

            if (RawTable.Columns.Contains("totalDrinkPrice"))
            {

                RawTable.Columns["totalDrinkPrice"].SetOrdinal(RawTable.Columns.Count - 1);
                RawTable.Columns["totalDrinkAmount"].SetOrdinal(RawTable.Columns.Count - 1);

            }
            if (RawTable.Columns.Contains("totalFoodPrice"))
            {

                RawTable.Columns["totalFoodPrice"].SetOrdinal(RawTable.Columns.Count - 1);
                RawTable.Columns["totalFoodAmount"].SetOrdinal(RawTable.Columns.Count - 1);

            }
            if (RawTable.Columns.Contains("totalArgyPrice"))
            {

                RawTable.Columns["totalArgyPrice"].SetOrdinal(RawTable.Columns.Count - 1);
                RawTable.Columns["totalArgyAmount"].SetOrdinal(RawTable.Columns.Count - 1);

            }

            RawTable.Columns["totalPrice"].SetOrdinal(RawTable.Columns.Count - 1);

            //   }






            System.Data.DataTable dtt = RawTable;
            // RawTable.Clear(); 

            return dtt;




        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        System.Data.DataTable FinalTbl = new System.Data.DataTable();
        bool FinalIsSet = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            string filter = "";
            if (drinksCB.Checked)
            {

                filter += " AND DrinkOrder.DrinkID ='" + drinkLbl.Text + "'";
            }


            else if (foodCB.Checked)
            {

                filter += " AND FoodOrder.FoodID ='" + foodLbl.Text + "'";
            }



            else if (argyCB.Checked)
            {

                filter += " AND ArgylahOrder.ArgylahID ='" + argyLbl.Text + "'";
            }


            if (tabelCB.Checked)
            {

                filter += " AND Reservation.TableOrPs ='" + tabelLbl.Text + "'";
            }

            if (durationCB.Checked)
            {

                filter += " AND Reservation.ResDuration ='" + timeInMinits + "'";
            }

            /*    if (todayCB.Checked)
                {

                    filter += " AND Reservation.TimeAndDate Like ='%" + todayLbl.Text + "%'";
                } */








            string connString = @"Server=GAMMA\SQLEXPRESS;Database=infinityDB;Trusted_Connection = True;";
            string query = " select* from Reservation left join DrinkOrder on DrinkOrder.ResRecordID = Reservation.ID left join FoodOrder on FoodOrder.RedRecordID = Reservation.ID left join ArgylahOrder on ArgylahOrder.ResRecordID = Reservation.ID where Reservation.ID Like '%%'";
            query += filter;

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);
            conn.Close();
            da.Dispose();





            FinalIsSet = true;

            if (dt.Rows.Count > 0)
                FinalTbl = SetUpDataTable(dt);


            if (FinalTbl != null)
            {
                dataGridView1.DataSource = FinalTbl;
            }
            else
            {

                MessageBox.Show("لا توجد نتائج");
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void plusBtn_Click_1(object sender, EventArgs e)
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

            durationLbl.Text = timeAsIntH + ":" + timeAsIntM;
        }

        private void tabelBtn_Click_1(object sender, EventArgs e)
        {
            FloorLayout fl = new FloorLayout();
            var dialogResult = fl.ShowDialog();




            if (BAL.TableName.Length > 0)
            {



                tabelId = BAL.TableID;

                tabelLbl.Text = BAL.TableID + "";
                /* if (!(BAL.TableID == 0))
                 {
                     tabelLbl.Text = "رقم " + BAL.TableName;
                 }
                 else
                 {
                     tabelLbl.Text = BAL.TableName;

                 }
        */



            }
        }

        private void argyBtn_Click_1(object sender, EventArgs e)
        {
            BAL.AddedLast = 3;

            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {
                argyId = BAL.ArgyIDHolderList.First();

                argyLbl.Text = BAL.ArgyIDHolderList.First() + "";




            }
        }

        private void foodBtn_Click_1(object sender, EventArgs e)
        {
            BAL.AddedLast = 2;

            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {
                foodId = BAL.FoodIDHolderList.First();

                foodLbl.Text = BAL.FoodIDHolderList.First() + "";




            }
        }

        private void drinkBtn_Click_1(object sender, EventArgs e)
        {
            BAL.AddedLast = 1;

            Menu d = new Menu();




            var dialogResult = d.ShowDialog();

            if (BAL.dataEnterdByMenu)
            {
                drinkId = BAL.DrinkIDHolderList.First();

                drinkLbl.Text = BAL.DrinkIDHolderList.First() + "";




            }
        }

        private void drinksCB_CheckedChanged(object sender, EventArgs e)
        {

            if (drinksCB.Checked)
            {
                drinksCB.Parent.BackColor = Color.DarkBlue;
                drinkBtn.Enabled = true;
                foodBtn.Enabled = false;
                argyBtn.Enabled = false;

                argyCB.Checked = false;
                foodCB.Checked = false;


                argyCB.Parent.BackColor = Color.Transparent;
                foodCB.Parent.BackColor = Color.Transparent;

            }
            else
            {

                drinksCB.Parent.BackColor = Color.Transparent;
                drinkBtn.Enabled = false;
            }
        }

        private void foodCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (foodCB.Checked)
            {
                foodCB.Parent.BackColor = Color.DarkBlue;
                foodBtn.Enabled = true;
                drinkBtn.Enabled = false;
                argyCB.Checked = false;

                argyCB.Checked = false;
                drinksCB.Checked = false;

                argyCB.Parent.BackColor = Color.Transparent;
                drinkBtn.Parent.BackColor = Color.Transparent;

            }
            else
            {

                foodCB.Parent.BackColor = Color.Transparent;
                foodBtn.Enabled = false;
            }
        }

        private void argyCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (argyCB.Checked)
            {
                argyCB.Parent.BackColor = Color.DarkBlue;
                argyBtn.Enabled = true;

                foodCB.Checked = false;
                foodBtn.Enabled = false;
                drinksCB.Checked = false;
                drinkBtn.Enabled = false;
                drinkBtn.Parent.BackColor = Color.Transparent;
                foodBtn.Parent.BackColor = Color.Transparent;

            }
            else
            {

                argyCB.Parent.BackColor = Color.Transparent;
                argyBtn.Enabled = false;
            }
        }

        private void tabelCB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (tabelCB.Checked)
            {
                tabelCB.Parent.BackColor = Color.DarkBlue;
                tabelBtn.Enabled = true;


            }
            else
            {

                tabelCB.Parent.BackColor = Color.Transparent;
                tabelBtn.Enabled = false;
            }
        }

        private void durationCB_CheckedChanged(object sender, EventArgs e)
        {
            if (durationCB.Checked)
            {
                durationCB.Parent.BackColor = Color.DarkBlue;
                plusBtn.Enabled = true;
                subBtn.Enabled = true;


            }
            else
            {

                durationCB.Parent.BackColor = Color.Transparent;
                plusBtn.Enabled = false;
                subBtn.Enabled = false;
                durationLbl.Text = "-------";

            }
        }

        private void todayCB_CheckedChanged(object sender, EventArgs e)
        {
            /*  DateTime now = DateTime.Now;


              if (todayCB.Checked)
              {
                  todayCB.Parent.BackColor = Color.DarkBlue;
                  todayLbl.Text = now.ToString();


                  if (fromToCB.Checked)
                  {
                      fromToCB.Parent.BackColor = Color.Transparent;
                      fromToCB.Checked = false;
                      fromBtn.Enabled = false;
                      toBtn.Enabled = false;
                      fromLbl.Text = "-------";
                      toLbl.Text = "-------";

                  }




              }
              else
              {

                  todayLbl.Parent.BackColor = Color.Transparent;
                  todayLbl.Text = "-------";

              }
        */


        }

        private void subBtn_Click_1(object sender, EventArgs e)
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

            durationLbl.Text = timeAsIntH + ":" + timeAsIntM;
        }

        private void fromToCB_CheckedChanged_1(object sender, EventArgs e)
        {

            if (fromToCB.Checked)
            {
                fromToCB.Parent.BackColor = Color.DarkBlue;
                fromBtn.Enabled = true;
                toBtn.Enabled = true;




            }
            else
            {

                fromToCB.Parent.BackColor = Color.Transparent;
                fromBtn.Enabled = false;
                toBtn.Enabled = false;
                fromLbl.Text = "-------";
                toLbl.Text = "-------";


            }
        }

        private void fromBtn_Click_1(object sender, EventArgs e)
        {



            from = 1;
        }

        private void toBtn_Click_1(object sender, EventArgs e)
        {
            from = 2;
        }

        private void calander_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            if (fromToCB.Checked)
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
            if (selectDayCB.Checked)
            {


                if (from == 3)
                {

                    selectDayLbl.Text = calander.SelectionRange.End.Date + "";

                    //  calander.Enabled = false;
                    from = 0;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FinalIsSet)
            {




                XLWorkbook wb = new XLWorkbook();

                wb.Worksheets.Add(FinalTbl, "Filter");
                var folderBrowserDialog1 = new FolderBrowserDialog();

                // Show the FolderBrowserDialog.
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    // MessageBox.Show(folderName);
                    wb.SaveAs(folderName + "\\Filter.xlsx");

                }










            }
            else { MessageBox.Show("الرجاء تنفيذ عملية البحث اولاً"); }
        }

        private void fromLbl_Click(object sender, EventArgs e)
        {

        }

        private void selectDayCB_CheckedChanged(object sender, EventArgs e)
        {
            if (selectDayCB.Checked)
            {

                selectDayCB.Parent.BackColor = Color.DarkBlue;
                fromBtn.Enabled = false;
                selectDayBtn.Enabled = true;
                toBtn.Enabled = false;




            }
            else
            {

                selectDayBtn.Parent.BackColor = Color.Transparent;

                selectDayBtn.Enabled = false;

                selectDayLbl.Text = "-------";


            }
        }

        private void selectDayBtn_Click(object sender, EventArgs e)
        {
            from = 3;
        }

        private void allArgyCB_CheckedChanged(object sender, EventArgs e)
        {

            if (allArgyCB.Checked)
            {
                allArgyCB.BackColor = Color.DarkBlue;



                argyCB.Parent.BackColor = Color.Transparent;
                argyBtn.Enabled = false;

                foodCB.Checked = false;
                foodBtn.Enabled = false;
                argyCB.Checked = false;
                drinksCB.Checked = false;
                drinkBtn.Enabled = false;
                drinkBtn.Parent.BackColor = Color.Transparent;
                foodBtn.Parent.BackColor = Color.Transparent;


                allFoodCB.Checked = false;
                allDrinksCB.Checked = false;

                allFoodCB.BackColor = Color.Transparent;
                allDrinksCB.BackColor = Color.Transparent;


            }
            else
            {

                allArgyCB.BackColor = Color.Transparent;



            }
        }

        private void allFoodCB_CheckedChanged(object sender, EventArgs e)
        {
            if (allFoodCB.Checked)
            {
                allFoodCB.BackColor = Color.DarkBlue;


                argyCB.Parent.BackColor = Color.Transparent;
                argyBtn.Enabled = false;

                foodCB.Checked = false;
                foodBtn.Enabled = false;
                argyCB.Checked = false;
                drinksCB.Checked = false;
                drinkBtn.Enabled = false;
                drinkBtn.Parent.BackColor = Color.Transparent;
                foodBtn.Parent.BackColor = Color.Transparent;

                allDrinksCB.Checked = false;
                allArgyCB.Checked = false;

                allDrinksCB.BackColor = Color.Transparent;
                allArgyCB.BackColor = Color.Transparent;


            }
            else
            {

                allFoodCB.BackColor = Color.Transparent;



            }
        }

        private void allDrinksCB_CheckedChanged(object sender, EventArgs e)
        {
            if (allDrinksCB.Checked)
            {
                allDrinksCB.BackColor = Color.DarkBlue;



                argyCB.Parent.BackColor = Color.Transparent;
                argyBtn.Enabled = false;

                foodCB.Checked = false;
                foodBtn.Enabled = false;
                argyCB.Checked = false;
                drinksCB.Checked = false;
                drinkBtn.Enabled = false;
                drinkBtn.Parent.BackColor = Color.Transparent;
                foodBtn.Parent.BackColor = Color.Transparent;

                allFoodCB.Checked = false;
                allArgyCB.Checked = false;

                allFoodCB.BackColor = Color.Transparent;
                allArgyCB.BackColor = Color.Transparent;

            }
            else
            {

                allDrinksCB.BackColor = Color.Transparent;



            }
        }

        private void kitchenCB_CheckedChanged(object sender, EventArgs e)
        {
            if (kitchenCB.Checked)
            {
                kitchenCB.BackColor = Color.DarkBlue;


                allArgyCB.BackColor = Color.DarkBlue;
                allFoodCB.BackColor = Color.DarkBlue;
                allDrinksCB.BackColor = Color.DarkBlue;
                allPSCB.BackColor = Color.Transparent;
                allArgyCB.Checked = true;
                allPSCB.Checked = false;
                allFoodCB.Checked = true;
                allDrinksCB.Checked = true;






                argyCB.Parent.BackColor = Color.Transparent;
                argyBtn.Enabled = false;

                foodCB.Checked = false;
                foodBtn.Enabled = false;
                argyCB.Checked = false;
                drinksCB.Checked = false;
                drinkBtn.Enabled = false;
                drinkBtn.Parent.BackColor = Color.Transparent;
                foodBtn.Parent.BackColor = Color.Transparent;









            }
            else
            {

                kitchenCB.BackColor = Color.Transparent;


                allArgyCB.BackColor = Color.Transparent;
                allFoodCB.BackColor = Color.Transparent;
                allDrinksCB.BackColor = Color.Transparent;
                allArgyCB.Checked = false;
                allFoodCB.Checked = false;
                allDrinksCB.Checked = false;




            }

        }

        private void allTablesCB_CheckedChanged(object sender, EventArgs e)
        {
            if (allTablesCB.Checked)
            {
                allTablesCB.BackColor = Color.DarkBlue;

                allPSCB.BackColor = Color.Transparent;
                allPSCB.Checked = false;


            }
            else
            {

                allTablesCB.BackColor = Color.Transparent;


            }
        }

        private void allPSCB_CheckedChanged(object sender, EventArgs e)
        {
            if (allPSCB.Checked)
            {
                allPSCB.BackColor = Color.DarkBlue;

                allTablesCB.BackColor = Color.Transparent;
                allTablesCB.Checked = false;

                kitchenCB.BackColor = Color.Transparent;
                kitchenCB.Checked = false;
            }
            else
            {

                allPSCB.BackColor = Color.Transparent;


            }
        }
    }
}
