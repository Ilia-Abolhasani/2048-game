using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_game
{
    public partial class Form1 : Form
    {        
        classic_game_bord f0;
        time_trial f1;
        public Form1()
        {
            InitializeComponent();
            f0 = new classic_game_bord(this);
            f1 = new time_trial(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            f0.Show();
            this.Hide();
        }
    }
}
