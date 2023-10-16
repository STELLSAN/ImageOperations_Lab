namespace ImageOperations
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открыть1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открыть2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(572, 518);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(689, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(575, 518);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1453, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открыть1ToolStripMenuItem,
            this.открыть2ToolStripMenuItem,
            this.mSEToolStripMenuItem,
            this.uIQToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открыть1ToolStripMenuItem
            // 
            this.открыть1ToolStripMenuItem.Name = "открыть1ToolStripMenuItem";
            this.открыть1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открыть1ToolStripMenuItem.Text = "Открыть_1";
            this.открыть1ToolStripMenuItem.Click += new System.EventHandler(this.открыть1ToolStripMenuItem_Click);
            // 
            // открыть2ToolStripMenuItem
            // 
            this.открыть2ToolStripMenuItem.Name = "открыть2ToolStripMenuItem";
            this.открыть2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открыть2ToolStripMenuItem.Text = "Открыть_2";
            this.открыть2ToolStripMenuItem.Click += new System.EventHandler(this.открыть2ToolStripMenuItem_Click);
            // 
            // mSEToolStripMenuItem
            // 
            this.mSEToolStripMenuItem.Name = "mSEToolStripMenuItem";
            this.mSEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mSEToolStripMenuItem.Text = "MSE";
            this.mSEToolStripMenuItem.Click += new System.EventHandler(this.mSEToolStripMenuItem_Click);
            // 
            // uIQToolStripMenuItem
            // 
            this.uIQToolStripMenuItem.Name = "uIQToolStripMenuItem";
            this.uIQToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uIQToolStripMenuItem.Text = "UIQ";
            this.uIQToolStripMenuItem.Click += new System.EventHandler(this.uIQToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 704);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открыть1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открыть2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uIQToolStripMenuItem;
    }
}

