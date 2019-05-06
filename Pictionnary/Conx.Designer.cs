namespace Pictionnary
{
    partial class Conx
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
            this.pseudobox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelerror = new System.Windows.Forms.Label();
            this.portbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pseudobox
            // 
            this.pseudobox.Location = new System.Drawing.Point(129, 173);
            this.pseudobox.Name = "pseudobox";
            this.pseudobox.Size = new System.Drawing.Size(127, 22);
            this.pseudobox.TabIndex = 3;
            this.pseudobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pseudobox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pseudo ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Veuillez entrez un pseudo valide !";
            this.label2.Visible = false;
            // 
            // labelerror
            // 
            this.labelerror.AutoSize = true;
            this.labelerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelerror.ForeColor = System.Drawing.Color.DarkRed;
            this.labelerror.Location = new System.Drawing.Point(3, 211);
            this.labelerror.Name = "labelerror";
            this.labelerror.Size = new System.Drawing.Size(288, 17);
            this.labelerror.TabIndex = 4;
            this.labelerror.Text = "Erreur lors de la connexion au serveur";
            this.labelerror.Visible = false;
            // 
            // portbox
            // 
            this.portbox.Location = new System.Drawing.Point(129, 120);
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(127, 22);
            this.portbox.TabIndex = 2;
            this.portbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portbox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adresse IP";
            // 
            // ipbox
            // 
            this.ipbox.Location = new System.Drawing.Point(128, 67);
            this.ipbox.Name = "ipbox";
            this.ipbox.Size = new System.Drawing.Size(127, 22);
            this.ipbox.TabIndex = 1;
            this.ipbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipbox_KeyDown);
            // 
            // Conx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(294, 283);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portbox);
            this.Controls.Add(this.labelerror);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pseudobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Conx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pseudo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pseudobox;
        private System.Windows.Forms.Label labelerror;
        private System.Windows.Forms.TextBox portbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipbox;
    }
}