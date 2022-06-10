namespace GraphicsPackage
{
    partial class MidpointCircleAlgorithm
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
            this.circle = new System.Windows.Forms.PictureBox();
            this.xCenter = new System.Windows.Forms.TextBox();
            this.yCenter = new System.Windows.Forms.TextBox();
            this.Radius = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Xdw = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.circle)).BeginInit();
            this.SuspendLayout();
            // 
            // circle
            // 
            this.circle.Location = new System.Drawing.Point(344, 6);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(544, 465);
            this.circle.TabIndex = 0;
            this.circle.TabStop = false;
            // 
            // xCenter
            // 
            this.xCenter.Location = new System.Drawing.Point(106, 91);
            this.xCenter.Name = "xCenter";
            this.xCenter.Size = new System.Drawing.Size(107, 20);
            this.xCenter.TabIndex = 1;
            this.xCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yCenter
            // 
            this.yCenter.Location = new System.Drawing.Point(109, 170);
            this.yCenter.Name = "yCenter";
            this.yCenter.Size = new System.Drawing.Size(104, 20);
            this.yCenter.TabIndex = 2;
            this.yCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Radius
            // 
            this.Radius.Location = new System.Drawing.Point(106, 243);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(107, 20);
            this.Radius.TabIndex = 3;
            this.Radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Midpoint Circle Algorithm ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Xdw
            // 
            this.Xdw.AutoSize = true;
            this.Xdw.Location = new System.Drawing.Point(27, 94);
            this.Xdw.Name = "Xdw";
            this.Xdw.Size = new System.Drawing.Size(73, 13);
            this.Xdw.TabIndex = 5;
            this.Xdw.Text = "X displacment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y displacment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Radius";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MidpointCircleAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 481);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Xdw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.yCenter);
            this.Controls.Add(this.xCenter);
            this.Controls.Add(this.circle);
            this.Name = "MidpointCircleAlgorithm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.circle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox circle;
        private System.Windows.Forms.TextBox xCenter;
        private System.Windows.Forms.TextBox yCenter;
        private System.Windows.Forms.TextBox Radius;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Xdw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}