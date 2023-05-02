
namespace AICheckers
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
            this.MiniMax = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.PvP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MiniMax
            // 
            this.MiniMax.Location = new System.Drawing.Point(358, 152);
            this.MiniMax.Name = "MiniMax";
            this.MiniMax.Size = new System.Drawing.Size(114, 56);
            this.MiniMax.TabIndex = 0;
            this.MiniMax.Text = "MiniMax";
            this.MiniMax.UseVisualStyleBackColor = true;
            this.MiniMax.Click += new System.EventHandler(this.MiniMax_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 153);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "Random";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PvP
            // 
            this.PvP.Location = new System.Drawing.Point(536, 153);
            this.PvP.Name = "PvP";
            this.PvP.Size = new System.Drawing.Size(125, 55);
            this.PvP.TabIndex = 5;
            this.PvP.Text = "Player vs Player";
            this.PvP.UseVisualStyleBackColor = true;
            this.PvP.Click += new System.EventHandler(this.PvP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(243, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 83);
            this.label2.TabIndex = 7;
            this.label2.Text = "Checkers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PvP);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.MiniMax);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MiniMax;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button PvP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}