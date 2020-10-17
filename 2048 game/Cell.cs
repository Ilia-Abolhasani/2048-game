using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2048_game
{
    class Cell
    {
        public Button b;
        private int value;
        public Cell(classic_game_bord f)
        {
            b = new Button();
            b.Size = new Size(110, 110);
            b.Font = new Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));            
            value = 0;                        
            b.KeyUp += new System.Windows.Forms.KeyEventHandler(f.button_KeyUp);
            b.BackColor = SystemColors.Control;                                
        }
        public Cell(time_trial f)
        {
            b = new Button();
            b.Size = new Size(110, 110);
            b.Font = new Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            value = 0;
            b.KeyUp += new System.Windows.Forms.KeyEventHandler(f.button_KeyUp);
            b.BackColor = SystemColors.Control;
        }      
        public void setV(int v)
        {
            value = v;
        }
        public int getV()
        {
            return value;            
        }
        public void set_number(int n)
        {            
            value = n;
            if (n != 0)
            b.Text = value.ToString();
            if (n == 0)
                b.Text ="";
            set_color();
        }
        public void set_color()
        {            
            if (value==0)    
                b.BackColor = SystemColors.Control;                                
            else if (value==2)            
                b.BackColor = Color.PapayaWhip;                                
            else if (value == 4)
                b.BackColor = Color.Wheat;
            else if (value == 8)
                b.BackColor = Color.LightSalmon;
            else if (value == 16)
                b.BackColor = Color.Coral;
            else if (value == 32)
                b.BackColor = Color.Tomato;
            else if (value == 64)
                b.BackColor = Color.OrangeRed;
            else if (value == 128)
                b.BackColor = Color.Khaki;
            else if (value == 256)
                b.BackColor = Color.PeachPuff;                
            else if (value == 512)
                b.BackColor = Color.Gold;
            else if (value == 1024)
                b.BackColor = Color.Orange;
            else if (value == 2048)
                b.BackColor = Color.YellowGreen;
            else if (value == 4096)                
                b.BackColor = SystemColors.GrayText;
            else if (value == 8192)                
                b.BackColor = SystemColors.ActiveCaption;
        }
    }
}
