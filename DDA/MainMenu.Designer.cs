namespace GraphicsPackage
{
    partial class MainMenu
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_ellipse = new System.Windows.Forms.Button();
            this.btn_2d = new System.Windows.Forms.Button();
            this.btn_3d = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 62);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "DDA Algorithm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Bresenham Algorithm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(732, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(267, 62);
            this.button3.TabIndex = 2;
            this.button3.Text = "Midpoint Circle Algorithm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_ellipse
            // 
            this.btn_ellipse.Location = new System.Drawing.Point(43, 203);
            this.btn_ellipse.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ellipse.Name = "btn_ellipse";
            this.btn_ellipse.Size = new System.Drawing.Size(267, 62);
            this.btn_ellipse.TabIndex = 3;
            this.btn_ellipse.Text = "Midpoint Ellipse Algorithm";
            this.btn_ellipse.UseVisualStyleBackColor = true;
            this.btn_ellipse.Click += new System.EventHandler(this.btn_ellipse_Click);
            // 
            // btn_2d
            // 
            this.btn_2d.Location = new System.Drawing.Point(395, 203);
            this.btn_2d.Margin = new System.Windows.Forms.Padding(4);
            this.btn_2d.Name = "btn_2d";
            this.btn_2d.Size = new System.Drawing.Size(267, 62);
            this.btn_2d.TabIndex = 4;
            this.btn_2d.Text = "2D Transformations";
            this.btn_2d.UseVisualStyleBackColor = true;
            this.btn_2d.Click += new System.EventHandler(this.btn_2d_Click);
            // 
            // btn_3d
            // 
            this.btn_3d.Location = new System.Drawing.Point(732, 203);
            this.btn_3d.Margin = new System.Windows.Forms.Padding(4);
            this.btn_3d.Name = "btn_3d";
            this.btn_3d.Size = new System.Drawing.Size(267, 62);
            this.btn_3d.TabIndex = 5;
            this.btn_3d.Text = "3D Transformations";
            this.btn_3d.UseVisualStyleBackColor = true;
            this.btn_3d.Click += new System.EventHandler(this.btn_3d_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btn_3d);
            this.Controls.Add(this.btn_2d);
            this.Controls.Add(this.btn_ellipse);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_ellipse;
        private System.Windows.Forms.Button btn_2d;
        private System.Windows.Forms.Button btn_3d;
    }
}