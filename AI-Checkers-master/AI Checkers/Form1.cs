using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace AICheckers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAIvsAI_Click(object sender, EventArgs e)
        {

        }

        private void PvP_Click(object sender, EventArgs e)
        {
            FormPvP formPvP = new FormPvP();
            formPvP.Show();
        }

        private void MiniMax_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
          //  this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
