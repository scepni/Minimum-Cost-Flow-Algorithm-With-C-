namespace endusukmaliyet_yontemi
{
    partial class input
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
            this.input_sehir_tb = new System.Windows.Forms.TextBox();
            this.input_fabrika_tb = new System.Windows.Forms.TextBox();
            this.Onayla_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input_sehir_tb
            // 
            this.input_sehir_tb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.input_sehir_tb.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.input_sehir_tb.Location = new System.Drawing.Point(83, 212);
            this.input_sehir_tb.Multiline = true;
            this.input_sehir_tb.Name = "input_sehir_tb";
            this.input_sehir_tb.Size = new System.Drawing.Size(290, 59);
            this.input_sehir_tb.TabIndex = 0;
            this.input_sehir_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sehir_input_KeyPress);
            // 
            // input_fabrika_tb
            // 
            this.input_fabrika_tb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.input_fabrika_tb.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.input_fabrika_tb.Location = new System.Drawing.Point(83, 82);
            this.input_fabrika_tb.Multiline = true;
            this.input_fabrika_tb.Name = "input_fabrika_tb";
            this.input_fabrika_tb.Size = new System.Drawing.Size(290, 59);
            this.input_fabrika_tb.TabIndex = 1;
            this.input_fabrika_tb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.input_fabrika_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Onayla_button
            // 
            this.Onayla_button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Onayla_button.FlatAppearance.BorderSize = 15;
            this.Onayla_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Onayla_button.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Onayla_button.Location = new System.Drawing.Point(142, 287);
            this.Onayla_button.Name = "Onayla_button";
            this.Onayla_button.Size = new System.Drawing.Size(175, 68);
            this.Onayla_button.TabIndex = 2;
            this.Onayla_button.Text = "Onayla ";
            this.Onayla_button.UseVisualStyleBackColor = false;
            this.Onayla_button.Click += new System.EventHandler(this.Onayla_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(83, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = " Fabrika Sayısını Giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(83, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = " Şehir Sayısını Giriniz";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(454, 376);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Onayla_button);
            this.Controls.Add(this.input_fabrika_tb);
            this.Controls.Add(this.input_sehir_tb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "En Düşük Maliyet Yöntemi";
            this.Load += new System.EventHandler(this.input_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Onayla_button;
        private Label label1;
        private Label label2;
        public TextBox input_sehir_tb;
        public TextBox input_fabrika_tb;
    }
}