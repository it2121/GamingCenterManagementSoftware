namespace inf
{
    partial class printerSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printerSettingForm));
            this.casherPrinterTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.casherCB = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printerCasherNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.casherPrinterBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printerrkitchenNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kitchenPrinterBtn = new System.Windows.Forms.Button();
            this.kitchenPrinterTB = new System.Windows.Forms.TextBox();
            this.kitchenCB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // casherPrinterTB
            // 
            this.casherPrinterTB.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.casherPrinterTB.Location = new System.Drawing.Point(389, 81);
            this.casherPrinterTB.Name = "casherPrinterTB";
            this.casherPrinterTB.Size = new System.Drawing.Size(286, 32);
            this.casherPrinterTB.TabIndex = 1;
            this.casherPrinterTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lotus Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(481, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "اسم الطابعة";
            // 
            // casherCB
            // 
            this.casherCB.AutoSize = true;
            this.casherCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.casherCB.Font = new System.Drawing.Font("Lotus Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.casherCB.ForeColor = System.Drawing.Color.Lime;
            this.casherCB.Location = new System.Drawing.Point(20, 3);
            this.casherCB.Name = "casherCB";
            this.casherCB.Size = new System.Drawing.Size(200, 55);
            this.casherCB.TabIndex = 3;
            this.casherCB.Text = "تفعيل طابعة الكاشير";
            this.casherCB.UseVisualStyleBackColor = true;
            this.casherCB.CheckedChanged += new System.EventHandler(this.kitechnCB_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.printerCasherNameLbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.casherPrinterBtn);
            this.panel1.Controls.Add(this.casherPrinterTB);
            this.panel1.Controls.Add(this.casherCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 209);
            this.panel1.TabIndex = 4;
            // 
            // printerCasherNameLbl
            // 
            this.printerCasherNameLbl.AutoSize = true;
            this.printerCasherNameLbl.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.printerCasherNameLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.printerCasherNameLbl.Location = new System.Drawing.Point(153, 72);
            this.printerCasherNameLbl.Name = "printerCasherNameLbl";
            this.printerCasherNameLbl.Size = new System.Drawing.Size(17, 25);
            this.printerCasherNameLbl.TabIndex = 6;
            this.printerCasherNameLbl.Text = " ";
            this.printerCasherNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lotus Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(20, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "اسم الطابعة الحالي :";
            // 
            // casherPrinterBtn
            // 
            this.casherPrinterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.casherPrinterBtn.Enabled = false;
            this.casherPrinterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.casherPrinterBtn.Font = new System.Drawing.Font("Lotus Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.casherPrinterBtn.ForeColor = System.Drawing.Color.Black;
            this.casherPrinterBtn.Location = new System.Drawing.Point(436, 146);
            this.casherPrinterBtn.Name = "casherPrinterBtn";
            this.casherPrinterBtn.Size = new System.Drawing.Size(192, 48);
            this.casherPrinterBtn.TabIndex = 4;
            this.casherPrinterBtn.Text = "تأكيد";
            this.casherPrinterBtn.UseVisualStyleBackColor = false;
            this.casherPrinterBtn.Click += new System.EventHandler(this.casherPrinterBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.printerrkitchenNameLbl);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.kitchenPrinterBtn);
            this.panel2.Controls.Add(this.kitchenPrinterTB);
            this.panel2.Controls.Add(this.kitchenCB);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 209);
            this.panel2.TabIndex = 5;
            // 
            // printerrkitchenNameLbl
            // 
            this.printerrkitchenNameLbl.AutoSize = true;
            this.printerrkitchenNameLbl.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.printerrkitchenNameLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.printerrkitchenNameLbl.Location = new System.Drawing.Point(153, 72);
            this.printerrkitchenNameLbl.Name = "printerrkitchenNameLbl";
            this.printerrkitchenNameLbl.Size = new System.Drawing.Size(17, 25);
            this.printerrkitchenNameLbl.TabIndex = 6;
            this.printerrkitchenNameLbl.Text = " ";
            this.printerrkitchenNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.printerrkitchenNameLbl.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lotus Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(20, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 41);
            this.label4.TabIndex = 5;
            this.label4.Text = "اسم الطابعة الحالي :";
            // 
            // kitchenPrinterBtn
            // 
            this.kitchenPrinterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kitchenPrinterBtn.Enabled = false;
            this.kitchenPrinterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitchenPrinterBtn.Font = new System.Drawing.Font("Lotus Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kitchenPrinterBtn.ForeColor = System.Drawing.Color.Black;
            this.kitchenPrinterBtn.Location = new System.Drawing.Point(436, 146);
            this.kitchenPrinterBtn.Name = "kitchenPrinterBtn";
            this.kitchenPrinterBtn.Size = new System.Drawing.Size(192, 48);
            this.kitchenPrinterBtn.TabIndex = 4;
            this.kitchenPrinterBtn.Text = "تأكيد";
            this.kitchenPrinterBtn.UseVisualStyleBackColor = false;
            this.kitchenPrinterBtn.Click += new System.EventHandler(this.kitchenPrinterBtn_Click);
            // 
            // kitchenPrinterTB
            // 
            this.kitchenPrinterTB.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kitchenPrinterTB.Location = new System.Drawing.Point(389, 81);
            this.kitchenPrinterTB.Name = "kitchenPrinterTB";
            this.kitchenPrinterTB.Size = new System.Drawing.Size(286, 32);
            this.kitchenPrinterTB.TabIndex = 1;
            this.kitchenPrinterTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kitchenCB
            // 
            this.kitchenCB.AutoSize = true;
            this.kitchenCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitchenCB.Font = new System.Drawing.Font("Lotus Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kitchenCB.ForeColor = System.Drawing.Color.Lime;
            this.kitchenCB.Location = new System.Drawing.Point(20, 3);
            this.kitchenCB.Name = "kitchenCB";
            this.kitchenCB.Size = new System.Drawing.Size(187, 55);
            this.kitchenCB.TabIndex = 3;
            this.kitchenCB.Text = "تفعيل طابعة المطبخ";
            this.kitchenCB.UseVisualStyleBackColor = true;
            this.kitchenCB.CheckedChanged += new System.EventHandler(this.kitchenCB_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lotus Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(481, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 46);
            this.label5.TabIndex = 2;
            this.label5.Text = "اسم الطابعة";
            // 
            // printerSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(815, 448);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "printerSettingForm";
            this.Text = "printerSettingForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox casherPrinterTB;
        private Label label2;
        private CheckBox casherCB;
        private Panel panel1;
        private Label printerCasherNameLbl;
        private Label label1;
        private Button casherPrinterBtn;
        private Panel panel2;
        private Label printerrkitchenNameLbl;
        private Label label4;
        private Button kitchenPrinterBtn;
        private TextBox kitchenPrinterTB;
        private CheckBox kitchenCB;
        private Label label5;
    }
}