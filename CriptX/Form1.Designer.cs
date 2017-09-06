namespace CriptX
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Procurar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Procurar = new System.Windows.Forms.TextBox();
            this.btn_Encriptar = new System.Windows.Forms.Button();
            this.btn_Decriptar = new System.Windows.Forms.Button();
            this.textBox_PalavraChave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_Outro = new System.Windows.Forms.RadioButton();
            this.radioButton_Texto = new System.Windows.Forms.RadioButton();
            this.checkBox_Remontar = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.avançadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encriptarTextoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Procurar
            // 
            this.btn_Procurar.Location = new System.Drawing.Point(197, 19);
            this.btn_Procurar.Name = "btn_Procurar";
            this.btn_Procurar.Size = new System.Drawing.Size(75, 23);
            this.btn_Procurar.TabIndex = 0;
            this.btn_Procurar.Text = "Procurar";
            this.btn_Procurar.UseVisualStyleBackColor = true;
            this.btn_Procurar.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_Procurar
            // 
            this.textBox_Procurar.Location = new System.Drawing.Point(12, 20);
            this.textBox_Procurar.Name = "textBox_Procurar";
            this.textBox_Procurar.ReadOnly = true;
            this.textBox_Procurar.Size = new System.Drawing.Size(179, 20);
            this.textBox_Procurar.TabIndex = 1;
            // 
            // btn_Encriptar
            // 
            this.btn_Encriptar.Enabled = false;
            this.btn_Encriptar.Location = new System.Drawing.Point(107, 89);
            this.btn_Encriptar.Name = "btn_Encriptar";
            this.btn_Encriptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Encriptar.TabIndex = 2;
            this.btn_Encriptar.Text = "OK";
            this.btn_Encriptar.UseVisualStyleBackColor = true;
            this.btn_Encriptar.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Decriptar
            // 
            this.btn_Decriptar.Enabled = false;
            this.btn_Decriptar.Location = new System.Drawing.Point(161, 89);
            this.btn_Decriptar.Name = "btn_Decriptar";
            this.btn_Decriptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Decriptar.TabIndex = 3;
            this.btn_Decriptar.Text = "Decriptar";
            this.btn_Decriptar.UseVisualStyleBackColor = true;
            this.btn_Decriptar.Visible = false;
            this.btn_Decriptar.Click += new System.EventHandler(this.btn_Decriptar_Click);
            // 
            // textBox_PalavraChave
            // 
            this.textBox_PalavraChave.Enabled = false;
            this.textBox_PalavraChave.Location = new System.Drawing.Point(12, 63);
            this.textBox_PalavraChave.Name = "textBox_PalavraChave";
            this.textBox_PalavraChave.PasswordChar = '●';
            this.textBox_PalavraChave.Size = new System.Drawing.Size(179, 20);
            this.textBox_PalavraChave.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arquivo para Encriptar/Decriptar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha (Apenas números, sem espaços)";
            // 
            // radioButton_Outro
            // 
            this.radioButton_Outro.AutoSize = true;
            this.radioButton_Outro.Enabled = false;
            this.radioButton_Outro.Location = new System.Drawing.Point(231, 66);
            this.radioButton_Outro.Name = "radioButton_Outro";
            this.radioButton_Outro.Size = new System.Drawing.Size(51, 17);
            this.radioButton_Outro.TabIndex = 7;
            this.radioButton_Outro.Text = "Outro";
            this.radioButton_Outro.UseVisualStyleBackColor = true;
            this.radioButton_Outro.Visible = false;
            // 
            // radioButton_Texto
            // 
            this.radioButton_Texto.AutoSize = true;
            this.radioButton_Texto.Checked = true;
            this.radioButton_Texto.Enabled = false;
            this.radioButton_Texto.Location = new System.Drawing.Point(231, 50);
            this.radioButton_Texto.Name = "radioButton_Texto";
            this.radioButton_Texto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_Texto.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Texto.TabIndex = 8;
            this.radioButton_Texto.TabStop = true;
            this.radioButton_Texto.Text = "Texto";
            this.radioButton_Texto.UseVisualStyleBackColor = true;
            this.radioButton_Texto.Visible = false;
            this.radioButton_Texto.CheckedChanged += new System.EventHandler(this.radioButton_Texto_CheckedChanged);
            // 
            // checkBox_Remontar
            // 
            this.checkBox_Remontar.AutoSize = true;
            this.checkBox_Remontar.Location = new System.Drawing.Point(211, 93);
            this.checkBox_Remontar.Name = "checkBox_Remontar";
            this.checkBox_Remontar.Size = new System.Drawing.Size(69, 17);
            this.checkBox_Remontar.TabIndex = 10;
            this.checkBox_Remontar.Text = "Decriptar";
            this.checkBox_Remontar.UseVisualStyleBackColor = true;
            this.checkBox_Remontar.CheckedChanged += new System.EventHandler(this.checkBox_Remontar_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avançadoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(-3, 91);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(128, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // avançadoToolStripMenuItem
            // 
            this.avançadoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.avançadoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.avançadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encriptarTextoToolStripMenuItem});
            this.avançadoToolStripMenuItem.Enabled = false;
            this.avançadoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.avançadoToolStripMenuItem.Name = "avançadoToolStripMenuItem";
            this.avançadoToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.avançadoToolStripMenuItem.Text = "...";
            this.avançadoToolStripMenuItem.Click += new System.EventHandler(this.avançadoToolStripMenuItem_Click);
            // 
            // encriptarTextoToolStripMenuItem
            // 
            this.encriptarTextoToolStripMenuItem.CheckOnClick = true;
            this.encriptarTextoToolStripMenuItem.Name = "encriptarTextoToolStripMenuItem";
            this.encriptarTextoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.encriptarTextoToolStripMenuItem.Text = "Encriptar texto";
            this.encriptarTextoToolStripMenuItem.Click += new System.EventHandler(this.encriptarTextoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(284, 116);
            this.Controls.Add(this.checkBox_Remontar);
            this.Controls.Add(this.radioButton_Texto);
            this.Controls.Add(this.radioButton_Outro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PalavraChave);
            this.Controls.Add(this.btn_Decriptar);
            this.Controls.Add(this.btn_Encriptar);
            this.Controls.Add(this.textBox_Procurar);
            this.Controls.Add(this.btn_Procurar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriptX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Procurar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_Procurar;
        private System.Windows.Forms.Button btn_Encriptar;
        private System.Windows.Forms.Button btn_Decriptar;
        private System.Windows.Forms.TextBox textBox_PalavraChave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_Outro;
        private System.Windows.Forms.RadioButton radioButton_Texto;
        private System.Windows.Forms.CheckBox checkBox_Remontar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem avançadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encriptarTextoToolStripMenuItem;
    }
}

