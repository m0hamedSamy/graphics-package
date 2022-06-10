namespace GraphicsPackage
{
    partial class DDA
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
            this.button1 = new System.Windows.Forms.Button();
            this.X1 = new System.Windows.Forms.TextBox();
            this.Y1 = new System.Windows.Forms.MaskedTextBox();
            this.Y2 = new System.Windows.Forms.TextBox();
            this.X2 = new System.Windows.Forms.TextBox();
            this.WWW = new System.Windows.Forms.Label();
            this.Y1WDA = new System.Windows.Forms.Label();
            this.AD = new System.Windows.Forms.Label();
            this.WDAD = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.bf1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bf1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "DDA Algorithm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // X1
            // 
            this.X1.Location = new System.Drawing.Point(41, 58);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(100, 20);
            this.X1.TabIndex = 1;
            // 
            // Y1
            // 
            this.Y1.Location = new System.Drawing.Point(155, 58);
            this.Y1.Name = "Y1";
            this.Y1.Size = new System.Drawing.Size(100, 20);
            this.Y1.TabIndex = 2;
            // 
            // Y2
            // 
            this.Y2.Location = new System.Drawing.Point(155, 153);
            this.Y2.Name = "Y2";
            this.Y2.Size = new System.Drawing.Size(100, 20);
            this.Y2.TabIndex = 3;
            // 
            // X2
            // 
            this.X2.Location = new System.Drawing.Point(41, 153);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(100, 20);
            this.X2.TabIndex = 4;
            // 
            // WWW
            // 
            this.WWW.AutoSize = true;
            this.WWW.Location = new System.Drawing.Point(74, 27);
            this.WWW.Name = "WWW";
            this.WWW.Size = new System.Drawing.Size(20, 13);
            this.WWW.TabIndex = 5;
            this.WWW.Text = "X1";
            // 
            // Y1WDA
            // 
            this.Y1WDA.AutoSize = true;
            this.Y1WDA.Location = new System.Drawing.Point(186, 27);
            this.Y1WDA.Name = "Y1WDA";
            this.Y1WDA.Size = new System.Drawing.Size(20, 13);
            this.Y1WDA.TabIndex = 6;
            this.Y1WDA.Text = "Y1";
            // 
            // AD
            // 
            this.AD.AutoSize = true;
            this.AD.Location = new System.Drawing.Point(74, 127);
            this.AD.Name = "AD";
            this.AD.Size = new System.Drawing.Size(20, 13);
            this.AD.TabIndex = 7;
            this.AD.Text = "X2";
            // 
            // WDAD
            // 
            this.WDAD.AutoSize = true;
            this.WDAD.Location = new System.Drawing.Point(186, 127);
            this.WDAD.Name = "WDAD";
            this.WDAD.Size = new System.Drawing.Size(20, 13);
            this.WDAD.TabIndex = 8;
            this.WDAD.Text = "Y2";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // bf1
            // 
            this.bf1.Location = new System.Drawing.Point(337, 12);
            this.bf1.Name = "bf1";
            this.bf1.Size = new System.Drawing.Size(500, 500);
            this.bf1.TabIndex = 9;
            this.bf1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 56);
            this.button2.TabIndex = 10;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 560);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bf1);
            this.Controls.Add(this.WDAD);
            this.Controls.Add(this.AD);
            this.Controls.Add(this.Y1WDA);
            this.Controls.Add(this.WWW);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.Y2);
            this.Controls.Add(this.Y1);
            this.Controls.Add(this.X1);
            this.Controls.Add(this.button1);
            this.Name = "DDA";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bf1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox X1;
        private System.Windows.Forms.MaskedTextBox Y1;
        private System.Windows.Forms.TextBox Y2;
        private System.Windows.Forms.TextBox X2;
        private System.Windows.Forms.Label WWW;
        private System.Windows.Forms.Label Y1WDA;
        private System.Windows.Forms.Label AD;
        private System.Windows.Forms.Label WDAD;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.PictureBox bf1;
        private System.Windows.Forms.Button button2;
    }
}

