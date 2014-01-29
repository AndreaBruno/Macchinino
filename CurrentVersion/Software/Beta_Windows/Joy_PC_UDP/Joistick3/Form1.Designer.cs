namespace Joistick3
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BoxAvanti = new System.Windows.Forms.PictureBox();
            this.BoxSinistra = new System.Windows.Forms.PictureBox();
            this.BoxDestra = new System.Windows.Forms.PictureBox();
            this.BoxDietro = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BoxAvanti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxSinistra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDestra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDietro)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connetti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Avvia";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BoxAvanti
            // 
            this.BoxAvanti.Location = new System.Drawing.Point(118, 99);
            this.BoxAvanti.Name = "BoxAvanti";
            this.BoxAvanti.Size = new System.Drawing.Size(45, 39);
            this.BoxAvanti.TabIndex = 3;
            this.BoxAvanti.TabStop = false;
            // 
            // BoxSinistra
            // 
            this.BoxSinistra.Location = new System.Drawing.Point(72, 146);
            this.BoxSinistra.Name = "BoxSinistra";
            this.BoxSinistra.Size = new System.Drawing.Size(45, 39);
            this.BoxSinistra.TabIndex = 4;
            this.BoxSinistra.TabStop = false;
            // 
            // BoxDestra
            // 
            this.BoxDestra.Location = new System.Drawing.Point(164, 146);
            this.BoxDestra.Name = "BoxDestra";
            this.BoxDestra.Size = new System.Drawing.Size(45, 39);
            this.BoxDestra.TabIndex = 5;
            this.BoxDestra.TabStop = false;
            // 
            // BoxDietro
            // 
            this.BoxDietro.Location = new System.Drawing.Point(118, 193);
            this.BoxDietro.Name = "BoxDietro";
            this.BoxDietro.Size = new System.Drawing.Size(45, 39);
            this.BoxDietro.TabIndex = 6;
            this.BoxDietro.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1sdjshfdudhsa";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(133, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxDietro);
            this.Controls.Add(this.BoxDestra);
            this.Controls.Add(this.BoxSinistra);
            this.Controls.Add(this.BoxAvanti);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.BoxAvanti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxSinistra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDestra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDietro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox BoxAvanti;
        private System.Windows.Forms.PictureBox BoxSinistra;
        private System.Windows.Forms.PictureBox BoxDestra;
        private System.Windows.Forms.PictureBox BoxDietro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}

