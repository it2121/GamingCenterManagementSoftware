using DocumentFormat.OpenXml.Drawing;
using ESC_POS_USB_NET.Enums;
using ESC_POS_USB_NET.Printer;
using Microsoft.Win32.SafeHandles;
using SixLabors.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;
using System.Net.Http;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Security.Policy;
using ImageMagick;
using System.Collections;
using inf.Properties;
using Aspose.Words.XAttr;
using Color = System.Drawing.Color;
using static iTextSharp.awt.geom.Point2D;
using PageSize = iTextSharp.text.PageSize;
using Aspose.Words;

namespace inf
{

    public partial class ViewForm : Form
    {
        Printer printer;

        Printer Kprinter;
        bool firstPrint = false;
        bool secondPrint = false;
        bool thirdPrint = false;
        bool casherPState = false;
        bool kitchenPState = false;
        string casherPName = "";
        string kitchenPName = "";
        public ViewForm()
        {
            InitializeComponent();
            /*     printer.TestPrinter();
                 printer.FullPaperCut();
                 printer.PrintDocument();*/

            ReadPrintersStatsAndNames();
            printer = new Printer(casherPName);
            Kprinter = new Printer(kitchenPName);
            TimeAndDateLabel.Text = @BAL.ResDT.Rows[0]["TimeAndDate"] + "";

            tableIdLabel.Text = BAL.ResDT.Rows[0]["TableOrPs"] + "";


            ResDurLbl.Text = Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) / 60 + ":" + Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"]) % 60;

            int DrinksTotal = 0;
            foreach (DataRow row in BAL.DrinksDT.Rows)
            {

                DrinksTotal += ((Convert.ToInt16((row["DrinkPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["DrinkName"].ToString(), row["DrinkPrice"].ToString(), row["Amount"].ToString());

            }
            int FoodToaol = 0;
            foreach (DataRow row in BAL.FoodDT.Rows)
            {

                FoodToaol += ((Convert.ToInt16((row["FoodPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["FoodName"].ToString(), row["FoodPrice"].ToString(), row["Amount"].ToString());


            }
            int ArgyToaol = 0;
            foreach (DataRow row in BAL.ArgyDT.Rows)
            {

                ArgyToaol += ((Convert.ToInt16((row["ArgylahPrice"].ToString()))) * (Convert.ToInt16((row["Amount"].ToString()))));
                RowGenerator(row["Argylah"].ToString(), row["ArgylahPrice"].ToString(), row["Amount"].ToString());


            }


            TotalPricelbl.Text = ArgyToaol + FoodToaol + DrinksTotal + "";
            int timeInMinits = Convert.ToInt32(Convert.ToInt16(BAL.ResDT.Rows[0]["ResDuration"].ToString()));
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

            }
            else if (tableIdLabel.Text.Equals("100"))
            {
                TotalPricelbl.Text = Convert.ToInt16(TotalPricelbl.Text) + ((timeInMinits / 30) * 4000) + "";
                TabelLabelName.Text = "السينما";


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

                TabelLabelName.Text = "رقم البلي";

            }




















        }


        public void ReadPrintersStatsAndNames()
        {



            using (StreamReader readtext = new StreamReader("p1.txt"))
            {
                string casherPStateS = readtext.ReadLine();
                if (casherPStateS.Equals("1"))
                {

                    casherPState = true;


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


                }
            }
            using (StreamReader readtext = new StreamReader("p22.txt"))
            {
                kitchenPName = readtext.ReadLine();

            }










        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        FlowLayoutPanel Row;
        public void RowGenerator(string name, string price, string Amount)
        {


            Row = new FlowLayoutPanel();
            OrderRowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;

            Row.Width = OrderRowPanel.Width - 10;


            Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            Row.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;



            Label l = new Label();
            l.Anchor = System.Windows.Forms.AnchorStyles.Top;
            l.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(938, 0);

            l.Size = new System.Drawing.Size(272, 46);
            l.TextAlign = ContentAlignment.MiddleCenter;


            l.AutoSize = false;

            l.Text = name;

            System.Windows.Forms.TextBox amount = new System.Windows.Forms.TextBox();
            amount.Text = "0";
            amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            amount.Font = new System.Drawing.Font("Lotus Linotype", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            amount.ForeColor = System.Drawing.Color.White;
            amount.BackColor = System.Drawing.Color.DarkGray;
            amount.ReadOnly = true;


            amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            amount.Text = Amount;




            Label pl = new Label();
            pl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pl.Font = new System.Drawing.Font("Lotus Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pl.ForeColor = System.Drawing.Color.White;
            pl.Location = new System.Drawing.Point(938, 0);

            pl.Size = new System.Drawing.Size(272, 46);
            pl.TextAlign = ContentAlignment.MiddleCenter;


            pl.AutoSize = false;

            pl.Text = price;




            Row.Controls.Add(l);
            Row.Controls.Add(amount);

            Row.Controls.Add(pl);


            OrderRowPanel.Controls.Add(Row);



        }





        private void button1_Click(object sender, EventArgs e)
        {

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
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {


            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        public string[] GetFiles()
        {



            DirectoryInfo dirInfo = new DirectoryInfo("pdfs");
            FileInfo[] fileInfos = dirInfo.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {

                list.Add(info.FullName);


            }
            return (string[])list.ToArray(typeof(string));
        }
        public void PDFToBMP(string output)
        {
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 500 dpi will create an image with a better quality
            settings.Density = new Density(500);

            string[] files = GetFiles();
            foreach (string file in files)
            {
                string fichwithout = System.IO.Path.GetFileNameWithoutExtension(file);
                string path = System.IO.Path.Combine(output, fichwithout);
                using (MagickImageCollection images = new MagickImageCollection())
                {
                    images.Read(file);
                    foreach (MagickImage image in images)
                    {
                        settings.Height = image.Height;
                        settings.Width = image.Width;
                        image.Format = MagickFormat.Bmp; //if you want to do other formats of image, just change the extension here! 
                        image.Write(path + ".bmp"); //and here!
                    }
                }
            }
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
        bool ordertableBOOL = false;
        bool argytableBOOL = false;
        bool MainTableBOOL = false;
        private void button12_Click(object sender, EventArgs e)
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





            /*
                        List<int> DrinkListID = new List<int>();
                        List<int> DrinkListAmount = new List<int>();

                        List<int> FoodListID = new List<int>();
                        List<int> FoodListAmount = new List<int>();

                        List<int> ArgyListID = new List<int>();
                        List<int> ArgyListAmount = new List<int>();*/

            int selector = 0;



            /*
                        if (OrderRowPanel.Controls.Count > 1)
                        {
                            foreach (System.Windows.Forms.Control row in Row.Parent.Controls)
                            {
                                bool first = true;
                                foreach (System.Windows.Forms.Control items in row.Controls)
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
                                            }
                                            else
                                            if (selector == 2)
                                            {
                                                FoodListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                            }
                                            else
                                            if (selector == 3)
                                            {
                                                ArgyListID.Add(Convert.ToInt32(items.Text.Split('-').Last()));
                                            }

                                            first = false;

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

            */


















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
            int durationinminits = Convert.ToInt32(BAL.ResDT.Rows[0]["ResDuration"].ToString());
            string tableid = tableIdLabel.Text;
            bool priceIsInserted = false;
            string total = TotalPricelbl.Text;
            table.AddCell(CreateCell("الوقت : ", PdfPCell.ALIGN_CENTER, 26, true));
            table.AddCell(CreateCell(BAL.ResDT.Rows[0]["TimeAndDate"].ToString().Split('-').Last(), PdfPCell.ALIGN_CENTER, 24));




            int tableID = Convert.ToInt16(tableIdLabel.Text);
            bool TimeIsInserted = false;
            if ((tableID >= 1 && tableID <= 19) || tableIdLabel.Text.Equals("99") || tableIdLabel.Text.Equals("100"))
            {


                string devicename = "";
                if ((tableID >= 1 && tableID <= 19)) { devicename = "بلي ستيشن " + tableID; }
                else if (tableIdLabel.Text.Equals("99")) { devicename = "VR"; }

                else { devicename = "السينما"; }

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
                //  table.AddCell(CreateCell(timeofticket, PdfPCell.LEFT_BORDER, 10));



                //  MagickNET.SetGhostscriptDirectory("Ghostscript");

                durationTable.AddCell(CreateCell("مدة الحجز : ", PdfPCell.ALIGN_CENTER, 24, true));
                durationTable.AddCell(CreateCell(howmanyhours + andAhalf, PdfPCell.ALIGN_CENTER, 24));







                /*                var settings = new MagickReadSettings();
                                // Settings the density to 300 dpi will create an image with a better quality
                                settings.Density = new Density(300, 300);

                                using (var images = new MagickImageCollection())
                                {
                                    // Add all the pages of the pdf file to the collection
                                    images.Read("rec.pdf", settings);

                                    var page = 1;
                                    foreach (var image in images)
                                    {
                                        // Write page to file that contains the page number
                                        image.Write("rec" + page + ".bmp");
                                        // Writing to a specific format works the same as for a single image
                                        image.Format = MagickFormat.Ptif;
                                        image.Write("rec" + page + ".tif");
                                        page++;
                                    }
                                }*/

                /*           MagickReadSettings settings = new MagickReadSettings();
                           // Settings the density to 500 dpi will create an image with a better quality
                           settings.Density = new Density(500);

                           string fichwithout = System.IO.Path.GetFileNameWithoutExtension("m.pdf");
                           string path1 = System.IO.Path.Combine("image.bmp", fichwithout);
                           using (MagickImageCollection images = new MagickImageCollection())
                           {
                               images.Read("m.pdf");
                               foreach (MagickImage image in images)
                               {
                                   settings.Height = image.Height;
                                   settings.Width = image.Width;
                                   image.Format = MagickFormat.Bmp; //if you want to do other formats of image, just change the extension here! 
                                   image.Write(path1 + ".bmp"); //and here!
                               }
                           }*/





                //PDFToBMP("IMAGE");



                /*    var doc = new Aspose.Words.Document("rec.pdf");
                int counter = 0;
                for (int page = 0; page < doc.PageCount; page++)
                {
                    var extractedPage = doc.ExtractPages(page, 1);
                    extractedPage.Save($"Output_{page + 1}.bmp");
                    counter++;
                }

                for (int page = 0; page < counter; page++)
                {
                    Bitmap image = new Bitmap(Bitmap.FromFile("Output_" + page + ".bmp"));
                    printer.Image(image);

                }
                printer.FullPaperCut();
                printer.PrintDocument();*/






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
                    tn = tableID + "";
                    table.AddCell(CreateCell("رقم الطاولة : ", PdfPCell.ALIGN_CENTER, 24, true));
                    table.AddCell(CreateCell(tn + "", PdfPCell.ALIGN_CENTER, 24));
                }


                // table.AddCell(CreateCell("رقم الطاولة : ", PdfPCell.ALIGN_CENTER, 24, true));
                // table.AddCell(CreateCell(tableID + "", PdfPCell.ALIGN_CENTER, 24));
                //  document.Add(table);
                /*
                                document.Close();
                                writer.Close();
                                fs.Close();*/

            }



            table.AddCell(CreateCell("التاريخ : ", PdfPCell.ALIGN_CENTER, 24, true));
            table.AddCell(CreateCell((@BAL.ResDT.Rows[0]["TimeAndDate"].ToString()).Split('-').First(), PdfPCell.ALIGN_CENTER, 24));



            int ii = 0;

            // MessageBox.Show(@BAL.ResDT.Rows[0]["TimeAndDate"].ToString());
            /*    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A7);
                rec.BackgroundColor = new BaseColor(Color.White);
                iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(rec, 15, 15, 20, 20);*/

            // iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(newdock);

            PdfPTable OrderTable = new PdfPTable(3);
            PdfPTable argyTable = new PdfPTable(3);
            PdfPTable argyTableShort = new PdfPTable(3);


            // PdfWriter Kwriter = PdfWriter.GetInstance(Kdocument, Kfs);

            if (BAL.DrinksDT.Rows.Count > 0 || BAL.FoodDT.Rows.Count > 0 || BAL.ArgyDT.Rows.Count > 0)
            {




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

                foreach (DataRow row in BAL.DrinksDT.Rows)
                {



                    //  MessageBox.Show(BAL.DrinksDT.Rows[i]["DrinkName"].ToString()+"-  " + BAL.DrinksDT.Rows[i]["DrinkName"].ToString().Length);
                    OrderTable.AddCell(CreateCell(BAL.DrinksDT.Rows[i]["DrinkName"].ToString(), PdfPCell.ALIGN_CENTER));
                    OrderTable.AddCell(CreateCell(BAL.DrinksDT.Rows[i]["Amount"].ToString(), PdfPCell.ALIGN_CENTER, 22));

                    int price = Convert.ToInt32(BAL.DrinksDT.Rows[i]["DrinkPrice"].ToString()) * Convert.ToInt32(BAL.DrinksDT.Rows[i]["Amount"].ToString());

                    OrderTable.AddCell(CreateCell(price + "", PdfPCell.ALIGN_CENTER, 22));

                    i++;



                }


                foreach (DataRow row in BAL.FoodDT.Rows)
                {
                    OrderTable.AddCell(CreateCell(BAL.FoodDT.Rows[iii]["FoodName"].ToString(), PdfPCell.ALIGN_CENTER));
                    OrderTable.AddCell(CreateCell(BAL.FoodDT.Rows[iii]["Amount"].ToString(), PdfPCell.ALIGN_CENTER, 22));


                    int price = Convert.ToInt32(BAL.FoodDT.Rows[iii]["FoodPrice"].ToString()) * Convert.ToInt32(BAL.FoodDT.Rows[iii]["Amount"].ToString());

                    OrderTable.AddCell(CreateCell(price + "", PdfPCell.ALIGN_CENTER, 22));


                    iii++;
                }

                if (BAL.ArgyDT.Rows.Count > 0)
                {

                    argyTable.AddCell(CreateCell("الاسم", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTable.AddCell(CreateCell("العدد", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTable.AddCell(CreateCell("السعر", PdfPCell.ALIGN_CENTER, 22, true));


                    argyTableShort.AddCell(CreateCell("الاسم", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTableShort.AddCell(CreateCell("العدد", PdfPCell.ALIGN_CENTER, 22, true));
                    argyTableShort.AddCell(CreateCell("السعر", PdfPCell.ALIGN_CENTER, 22, true));


                }

                foreach (DataRow row in BAL.ArgyDT.Rows)
                {
                    // OrderTable.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Argylah"].ToString(), PdfPCell.ALIGN_CENTER));
                    // OrderTable.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Amount"].ToString(), PdfPCell.ALIGN_CENTER, 22));

                    int price = Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["ArgylahPrice"].ToString()) * Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["Amount"].ToString());

                    // OrderTable.AddCell(CreateCell(price + "", PdfPCell.ALIGN_CENTER, 22));

                    argyTable.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Argylah"].ToString(), PdfPCell.ALIGN_CENTER));
                    argyTableShort.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Argylah"].ToString(), PdfPCell.ALIGN_CENTER));
                    argyTableShort.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Amount"].ToString(), PdfPCell.ALIGN_CENTER, 22));
                    argyTable.AddCell(CreateCell(BAL.ArgyDT.Rows[iiii]["Amount"].ToString(), PdfPCell.ALIGN_CENTER, 22));
                    int price1 = 0;
                    int priceshort = 0;
                    if (BAL.ArgyDT.Rows[iiii]["Argylah"].ToString().Contains("VIP"))
                    {
                        price1 = (Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["ArgylahPrice"].ToString())) * Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["Amount"].ToString());
                        priceshort = (Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["ArgylahPrice"].ToString()) - 2000) * Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["Amount"].ToString());
                    }
                    else
                    {
                        price1 = (Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["ArgylahPrice"].ToString())) * Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["Amount"].ToString());
                        priceshort = Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["ArgylahPrice"].ToString()) * Convert.ToInt32(BAL.ArgyDT.Rows[iiii]["Amount"].ToString());


                    }
                    argyTable.AddCell(CreateCell(price1 + "", PdfPCell.ALIGN_CENTER, 22));
                    argyTableShort.AddCell(CreateCell(priceshort + "", PdfPCell.ALIGN_CENTER, 22));


                    iiii++;
                }



                if (BAL.ArgyDT.Rows.Count > 0)
                {



                    System.IO.FileStream Argyfs = new FileStream("Argyrec.pdf", FileMode.Create);

                    float h3 = 0;
                    h3 += ImageTable.TotalHeight;
                    h3 += table.TotalHeight;
                    h3 += argyTableShort.TotalHeight;


                    //   h3 += timeTbl.TotalHeight;
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



                    //   Argydocument.Add(timeTbl);


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




            System.IO.FileStream Kfs = new FileStream("Krec.pdf", FileMode.Create);

            float h2 = 0;
            h2 += ImageTable.TotalHeight;
            h2 += table.TotalHeight;
            h2 += OrderTable.TotalHeight;
            h2 += priceTable.TotalHeight;
            //   h2 += timeTbl.TotalHeight;
            var newdock11 = new Rectangle(390, h2 + 10);
            //  MessageBox.Show(newdock1.Width+"-"+ newdock1.Height);
            // MessageBox.Show(table.TotalHeight + "- "+ table.TotalWidth);
            newdock11.BackgroundColor = new BaseColor(Color.White);


            iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(newdock11, 10, 10, 0, 0);

            /*       iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A7);
             rec.BackgroundColor = new BaseColor(Color.White);
             iTextSharp.text.Document Kdocument = new iTextSharp.text.Document(rec, 15, 15, 20, 20);*/


            PdfWriter Kwriter = PdfWriter.GetInstance(Kdocument, Kfs);







            if (BAL.DrinksDT.Rows.Count > 0 || BAL.FoodDT.Rows.Count > 0)
            {
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
            //  h1 += timeTbl.TotalHeight;
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

            // document.Add(timeTbl);

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
            using (var images = new MagickImageCollection())
            {
                images.Read("rec.pdf", settings);


                foreach (var image1 in images)
                {
                    image1.Write("reci" + pageE + ".bmp");

                    pageE++;
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

                    printer.Image(image33);

                    /*    Bitmap image33 = new Bitmap(Bitmap.FromFile("reci" + 0 + ".bmp"));
                        printer.Image(image33);*/


                    printer.FullPaperCut();


                    firstPrint = true;
                }

            }
            if (BAL.DrinksDT.Rows.Count > 0 || BAL.FoodDT.Rows.Count > 0)

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
                            image2.Write("Kreci" + KpageE + ".bmp");

                            KpageE++;
                        }
                    }

                    if (kitchenPState)
                    {
                        if (!secondPrint)
                        {
                            Bitmap image22 = new Bitmap(Bitmap.FromFile("Kreci" + 0 + ".bmp"));
                            Kprinter.Image(image22);


                            Kprinter.FullPaperCut();
                            // printer.PrintDocument();

                            secondPrint = true;
                        }

                    }
                    else
                    {


                        Bitmap image22 = new Bitmap(Bitmap.FromFile("Kreci" + 0 + ".bmp"));
                        printer.Image(image22);


                        printer.FullPaperCut();

                    }

                }

            if (argytableBOOL)
            {

                var Asettings = new MagickReadSettings();
                Asettings.Density = new Density(300, 300);
                var ApageE = 0;
                using (var images = new MagickImageCollection())
                {
                    images.Read("Argyrec.pdf", Asettings);


                    foreach (var image3 in images)
                    {
                        image3.Write("Argyrec" + ApageE + ".bmp");

                        ApageE++;
                    }
                }
                if (kitchenPState)
                {

                    if (!thirdPrint)
                    {
                        Bitmap image11 = new Bitmap(Bitmap.FromFile("Argyrec" + 0 + ".bmp"));
                        Kprinter.Image(image11);


                        Kprinter.FullPaperCut();
                        // printer.PrintDocument();

                        thirdPrint = true;
                    }
                }
                else
                {
                    Bitmap image11 = new Bitmap(Bitmap.FromFile("Argyrec" + 0 + ".bmp"));
                    printer.Image(image11);


                    printer.FullPaperCut();

                }

            }


            if (casherPState)
            {
              printer.PrintDocument();

                printer.Clear();

                // MessageBox.Show("printer");
            }
            if (kitchenPState)
            {
               Kprinter.PrintDocument();
                Kprinter.Clear();
                // MessageBox.Show("Kprinter");

            }
            ordertableBOOL = false;

            firstPrint = false;
            secondPrint = false;
            thirdPrint = false;

            /*   for (int page = 0; page < pageE; page++)
               {
                




            /*            if (OrderRowPanel.Controls.Count > 0)
                        {

                        
                            foreach (int id in DrinkListID)
                            {



                                *//*  if (BAL.InsertDrinkOrder(DrinkID.ElementAt(i), DrinkAmount.ElementAt(i), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                                  {

                                      i++;
                                      // MessageBox.Show(i + "");
                                      //  MessageBox.Show(DrinkAmount.Count()+"");


                                  }
                                  else
                                  {
                                      Done = false;

                                  }*//*
                            }
                            foreach (int id in FoodListID)
                            {
                                *//* if (BAL.InsertFoodOrder(FoodID.ElementAt(iii), FoodAmount.ElementAt(iii), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                                 {

                                     iii++;
                                     // MessageBox.Show(i + "");
                                     //  MessageBox.Show(DrinkAmount.Count()+"");


                                 }
                                 else
                                 {
                                     Done = false;

                                 }*//*
                            }
                            foreach (int id in ArgyListID)
                            {
                                *//*  if (BAL.InsertArgyOrder(ArgyID.ElementAt(iiii), ArgyAmount.ElementAt(iiii), TimeAndDateLabel.Text, BAL.GetNextRes() - 1))
                                  {

                                      iiii++;
                                      // MessageBox.Show(i + "");
                                      //  MessageBox.Show(DrinkAmount.Count()+"");


                                  }
                                  else
                                  {
                                      Done = false;

                                  }*//*
                            }

                        }
            */

























































            //Print Image:

            /*
                        Bitmap image = new Bitmap(Bitmap.FromFile("Icon.bmp"));
                        printer.Image(image);
                        printer.FullPaperCut();
                        printer.PrintDocument();


                        //Print Barcodes:
                        printer.Append("Code 128");
                        printer.Code128("123456789");
                        printer.Separator();
                        printer.Append("Code39");
                        printer.Code39("123456789");
                        printer.Separator();
                        printer.Append("Ean13");
                        printer.Ean13("1234567891231");
                        printer.FullPaperCut();
                        printer.PrintDocument();


                        //Open Drawer:


                        printer.OpenDrawer();
                        printer.PrintDocument();

                        //Different Types of Separators:


                        printer.Separator(); // Deafult
                        printer.Separator('.'); // .
                        printer.Separator('|'); // |
                        printer.Separator('='); // =
                        printer.Separator('+'); // +
                        printer.Separator('*'); // *
                        printer.Separator('^'); // ^
                        printer.Separator('~'); // ~
                        printer.Separator(':'); // :
                        printer.Separator('#'); // #
                        printer.FullPaperCut();
                        printer.PrintDocument();


                        //Typography Test:



                        printer.Append("NORMAL - 48 COLUMNS");
                        printer.Append("1...5...10...15...20...25...30...35...40...45.48");
                        printer.Separator();
                        printer.Append("Text Normal");
                        printer.BoldMode("Bold Text");
                        printer.UnderlineMode("Underlined text");
                        printer.Separator();
                        printer.ExpandedMode(PrinterModeState.On);
                        printer.Append("Expanded - 23 COLUMNS");
                        printer.Append("1...5...10...15...20..23");
                        printer.ExpandedMode(PrinterModeState.Off);
                        printer.Separator();
                        printer.CondensedMode(PrinterModeState.On);
                        printer.Append("Condensed - 64 COLUMNS");
                        printer.Append("1...5...10...15...20...25...30...35...40...45...50...55...60..64");
                        printer.CondensedMode(PrinterModeState.Off);
                        printer.Separator();
                        printer.DoubleWidth2();
                        printer.Append("Font Width 2");
                        printer.DoubleWidth3();
                        printer.Append("Font Width 3");
                        printer.NormalWidth();
                        printer.Append("Normal width");
                        printer.Separator();
                        printer.AlignRight();
                        printer.Append("Right aligned text");
                        printer.AlignCenter();
                        printer.Append("Center-aligned text");
                        printer.AlignLeft();
                        printer.Append("Left aligned text");
                        printer.Separator();
                        printer.Font("Font A", Fonts.FontA);
                        printer.Font("Font B", Fonts.FontB);
                        printer.Font("Font C", Fonts.FontC);
                        printer.Font("Font D", Fonts.FontD);
                        printer.Font("Font E", Fonts.FontE);
                        printer.Font("Font Special A", Fonts.SpecialFontA);
                        printer.Font("Font Special B", Fonts.SpecialFontB);
                        printer.Separator();
                        printer.InitializePrint();
                        printer.SetLineHeight(24);
                        printer.Append("This is first line with line height of 30 dots");
                        printer.SetLineHeight(40);
                        printer.Append("This is second line with line height of 24 dots");
                        printer.Append("This is third line with line height of 40 dots");
                        printer.NewLines(3);
                        printer.Append("End of Test :)");
                        printer.Separator();
                        printer.FullPaperCut();
                        printer.PrintDocument();*/




        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            recevedTB.Text = Convert.ToInt32(recevedTB.Text) + 5000 + "";

            remainingLbl.Text = Convert.ToInt32(TotalPricelbl.Text) - Convert.ToInt32(recevedTB.Text) + "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(recevedTB.Text) > 0 && (Convert.ToInt32(recevedTB.Text) - 5000) >= 0)
            {

                recevedTB.Text = Convert.ToInt32(recevedTB.Text) - 5000 + "";
                remainingLbl.Text = Convert.ToInt32(TotalPricelbl.Text) - Convert.ToInt32(recevedTB.Text) + "";


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            recevedTB.Value = recevedTB.Value + 1000;
            remainingLbl.Text = Convert.ToInt32(TotalPricelbl.Text) - recevedTB.Value + "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(recevedTB.Text) > 0 && (Convert.ToInt32(recevedTB.Text) - 1000) >= 0)
            {

                recevedTB.Value = recevedTB.Value - 1000;
                remainingLbl.Text = Convert.ToInt32(TotalPricelbl.Text) - recevedTB.Value + "";


            }
        }

        private void recevedTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void recevedTB_ValueChanged(object sender, EventArgs e)
        {

            remainingLbl.Text = Convert.ToInt32(TotalPricelbl.Text) - recevedTB.Value + "";

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
