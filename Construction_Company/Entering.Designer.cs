namespace Construction_Company
{
    partial class Entering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entering));
            Admin = new Button();
            BOD = new Button();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            Exit = new Button();
            Customer = new Button();
            pictureBox5 = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // Admin
            // 
            Admin.BackColor = Color.MediumAquamarine;
            Admin.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            Admin.Location = new Point(62, 294);
            Admin.Name = "Admin";
            Admin.Size = new Size(236, 38);
            Admin.TabIndex = 2;
            Admin.Text = "Admin";
            Admin.UseVisualStyleBackColor = false;
            Admin.Click += Admin_Click;
            // 
            // BOD
            // 
            BOD.BackColor = Color.FromArgb(0, 230, 254);
            BOD.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            BOD.Location = new Point(62, 240);
            BOD.Name = "BOD";
            BOD.Size = new Size(236, 38);
            BOD.TabIndex = 1;
            BOD.Text = "Director";
            BOD.UseVisualStyleBackColor = false;
            BOD.Click += BOD_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Cyan;
            pictureBox4.Location = new Point(2, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(356, 2);
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Cyan;
            pictureBox1.Location = new Point(2, 478);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(356, 2);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Cyan;
            pictureBox2.Location = new Point(2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(2, 476);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Cyan;
            pictureBox3.Location = new Point(358, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(2, 476);
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // Exit
            // 
            Exit.BackColor = Color.White;
            Exit.FlatStyle = FlatStyle.Popup;
            Exit.Font = new Font("Gill Sans Ultra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Exit.Location = new Point(327, 6);
            Exit.Name = "Exit";
            Exit.Padding = new Padding(3, 0, 0, 0);
            Exit.Size = new Size(29, 29);
            Exit.TabIndex = 0;
            Exit.Text = "X";
            Exit.UseVisualStyleBackColor = false;
            Exit.Click += Exit_Click;
            // 
            // Customer
            // 
            Customer.BackColor = Color.Turquoise;
            Customer.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            Customer.Location = new Point(62, 348);
            Customer.Name = "Customer";
            Customer.Size = new Size(236, 38);
            Customer.TabIndex = 3;
            Customer.Text = "Customer";
            Customer.UseVisualStyleBackColor = false;
            Customer.Click += Customer_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(102, 24);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(150, 150);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 20;
            pictureBox5.TabStop = false;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(5, 190);
            label4.Name = "label4";
            label4.Size = new Size(350, 35);
            label4.TabIndex = 19;
            label4.Text = "Your Position";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Entering
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 35, 65);
            ClientSize = new Size(360, 480);
            Controls.Add(pictureBox5);
            Controls.Add(label4);
            Controls.Add(Customer);
            Controls.Add(Exit);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox4);
            Controls.Add(Admin);
            Controls.Add(BOD);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Entering";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entering";
            Load += Entering_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Admin;
        private Button BOD;
        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button Exit;
        private Button Customer;
        private PictureBox pictureBox5;
        private Label label4;
    }
}