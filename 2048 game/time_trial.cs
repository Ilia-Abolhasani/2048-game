using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2048_game
{
    public partial class time_trial : Form
    {
        Cell[] c = new Cell[16];
        int score = 0;
        Point p;        
        int best_score = 0;
        Form1 f;
        bool for_timer = true;
        int move_counter = 0;
        int timer_counter = 0;
        bool loos = false;
        public time_trial(Form1 f)
        {
            this.f = f;
            InitializeComponent();
            p = label6.Location;
            for (int i = 0; i < 16; i++)
            {
                c[i] = new Cell(this);
                this.Controls.Add(c[i].b);
            }
            start_Location();
            if (File.Exists("score_for_time2048.txt"))
            {               
                StreamReader SR = new StreamReader("score_for_time2048.txt");
                best_score = Convert.ToInt16(SR.ReadLine());
                label3.Text = best_score.ToString();
                SR.Close();
            }
            else
                File.CreateText("score_for_time2048.txt");  
        }
        private void start_Location()
        {
            for (int i = 0; i < 16; i++)
                c[i].b.Location = new Point(12 + ((i % 4 * 116)), 53 + (i / 4 * 116));
        }
        private void start_create()
        {
            Random r = new Random();
            c[r.Next(16)].set_number(2);
            while (true)
            {
                int temp = r.Next(16);
                if (c[temp].getV() != 2)
                {
                    c[temp].set_number(2);
                    break;
                }
            }
        }
        private void time_trial_Load(object sender, EventArgs e)
        {
            label2.Text = score.ToString();
            start_create();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void do_up()
        {
            for (int i = 0; i < 4; i++)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i + (j * 4)].getV() != 0)
                        count++;
                if (count == 1)
                {
                    for (int j = 1; j < 4; j++)
                        if (c[i + (j * 4)].getV() != 0)
                        {
                            c[i].set_number(c[i + (j * 4)].getV());
                            c[i + (j * 4)].set_number(0);
                        }
                    continue;
                }
                if (count == 2)
                {
                    int[] temp = new int[2];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + (j * 4)].getV() != 0)
                            temp[k++] = i + (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 4].set_number(0);
                        c[i + 8].set_number(0);
                        c[i + 12].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 4].set_number(c[temp[1]].getV());
                        c[i + 8].set_number(0);
                        c[i + 12].set_number(0);
                    }
                    continue;
                }
                if (count == 3)
                {
                    int[] temp = new int[3];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + (j * 4)].getV() != 0)
                            temp[k++] = i + (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 4].set_number(c[temp[2]].getV());
                        c[i + 8].set_number(0);
                        c[i + 12].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 4].set_number(c[temp[2]].getV() * 2);
                        c[i + 8].set_number(0);
                        c[i + 12].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 4].set_number(c[temp[1]].getV());
                        c[i + 8].set_number(c[temp[2]].getV());
                        c[i + 12].set_number(0);
                    }
                    continue;
                }
                if (count == 4)
                {
                    int[] temp = new int[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + (j * 4)].getV() != 0)
                            temp[k++] = i + (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV() && c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 4].set_number(c[temp[2]].getV() * 2);
                        c[i + 8].set_number(0);
                        c[i + 12].set_number(0);

                    }
                    else if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 4].set_number(c[temp[2]].getV());
                        c[i + 8].set_number(c[temp[3]].getV());
                        c[i + 12].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 4].set_number(c[temp[1]].getV() * 2);
                        c[i + 8].set_number(c[temp[3]].getV());
                        c[i + 12].set_number(0);
                    }
                    else if (c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 4].set_number(c[temp[1]].getV());
                        c[i + 8].set_number(c[temp[3]].getV() * 2);
                        c[i + 12].set_number(0);
                    }
                }

            }
        }
        private void do_right()
        {
            for (int i = 3; i < 16; i += 4)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i - j].getV() != 0)
                        count++;
                if (count == 1)
                {
                    for (int j = 1; j < 4; j++)
                        if (c[i - j].getV() != 0)
                        {
                            c[i].set_number(c[i - j].getV());
                            c[i - j].set_number(0);
                        }
                    continue;
                }
                if (count == 2)
                {
                    int[] temp = new int[2];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - j].getV() != 0)
                            temp[k++] = i - j;
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 1].set_number(0);
                        c[i - 2].set_number(0);
                        c[i - 3].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 1].set_number(c[temp[1]].getV());
                        c[i - 2].set_number(0);
                        c[i - 3].set_number(0);
                    }
                    continue;
                }
                if (count == 3)
                {
                    int[] temp = new int[3];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - j].getV() != 0)
                            temp[k++] = i - j;
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 1].set_number(c[temp[2]].getV());
                        c[i - 2].set_number(0);
                        c[i - 3].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 1].set_number(c[temp[2]].getV() * 2);
                        c[i - 2].set_number(0);
                        c[i - 3].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 1].set_number(c[temp[1]].getV());
                        c[i - 2].set_number(c[temp[2]].getV());
                        c[i - 3].set_number(0);
                    }
                    continue;
                }
                if (count == 4)
                {
                    int[] temp = new int[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - j].getV() != 0)
                            temp[k++] = i - j;
                    if (c[temp[0]].getV() == c[temp[1]].getV() && c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 1].set_number(c[temp[2]].getV() * 2);
                        c[i - 2].set_number(0);
                        c[i - 3].set_number(0);
                    }
                    else if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 1].set_number(c[temp[2]].getV());
                        c[i - 2].set_number(c[temp[3]].getV());
                        c[i - 3].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 1].set_number(c[temp[1]].getV() * 2);
                        c[i - 2].set_number(c[temp[3]].getV());
                        c[i - 3].set_number(0);
                    }
                    else if (c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 1].set_number(c[temp[1]].getV());
                        c[i - 2].set_number(c[temp[3]].getV() * 2);
                        c[i - 3].set_number(0);
                    }
                }

            }
        }
        private void do_down()
        {
            for (int i = 15; i > 11; i--)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i - (j * 4)].getV() != 0)
                        count++;
                if (count == 1)
                {
                    for (int j = 1; j < 4; j++)
                        if (c[i - (j * 4)].getV() != 0)
                        {
                            c[i].set_number(c[i - (j * 4)].getV());
                            c[i - (j * 4)].set_number(0);
                        }
                    continue;
                }
                if (count == 2)
                {
                    int[] temp = new int[2];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - (j * 4)].getV() != 0)
                            temp[k++] = i - (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 4].set_number(0);
                        c[i - 8].set_number(0);
                        c[i - 12].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 4].set_number(c[temp[1]].getV());
                        c[i - 8].set_number(0);
                        c[i - 12].set_number(0);
                    }
                    continue;
                }
                if (count == 3)
                {
                    int[] temp = new int[3];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - (j * 4)].getV() != 0)
                            temp[k++] = i - (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 4].set_number(c[temp[2]].getV());
                        c[i - 8].set_number(0);
                        c[i - 12].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 4].set_number(c[temp[2]].getV() * 2);
                        c[i - 8].set_number(0);
                        c[i - 12].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 4].set_number(c[temp[1]].getV());
                        c[i - 8].set_number(c[temp[2]].getV());
                        c[i - 12].set_number(0);
                    }
                    continue;
                }
                if (count == 4)
                {
                    int[] temp = new int[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i - (j * 4)].getV() != 0)
                            temp[k++] = i - (j * 4);
                    if (c[temp[0]].getV() == c[temp[1]].getV() && c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 4].set_number(c[temp[2]].getV() * 2);
                        c[i - 8].set_number(0);
                        c[i - 12].set_number(0);

                    }
                    else if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i - 4].set_number(c[temp[2]].getV());
                        c[i - 8].set_number(c[temp[3]].getV());
                        c[i - 12].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 4].set_number(c[temp[1]].getV() * 2);
                        c[i - 8].set_number(c[temp[3]].getV());
                        c[i - 12].set_number(0);
                    }
                    else if (c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i - 4].set_number(c[temp[1]].getV());
                        c[i - 8].set_number(c[temp[3]].getV() * 2);
                        c[i - 12].set_number(0);
                    }
                }

            }
        }
        private void do_left()
        {
            for (int i = 0; i < 16; i += 4)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i + j].getV() != 0)
                        count++;
                if (count == 1)
                {
                    for (int j = 1; j < 4; j++)
                        if (c[i + j].getV() != 0)
                        {
                            c[i].set_number(c[i + j].getV());
                            c[i + j].set_number(0);
                        }
                    continue;
                }
                if (count == 2)
                {
                    int[] temp = new int[2];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + j].getV() != 0)
                            temp[k++] = i + j;
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 1].set_number(0);
                        c[i + 2].set_number(0);
                        c[i + 3].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 1].set_number(c[temp[1]].getV());
                        c[i + 2].set_number(0);
                        c[i + 3].set_number(0);
                    }
                    continue;
                }
                if (count == 3)
                {
                    int[] temp = new int[3];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + j].getV() != 0)
                            temp[k++] = i + j;
                    if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 1].set_number(c[temp[2]].getV());
                        c[i + 2].set_number(0);
                        c[i + 3].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 1].set_number(c[temp[2]].getV() * 2);
                        c[i + 2].set_number(0);
                        c[i + 3].set_number(0);
                    }
                    else
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 1].set_number(c[temp[1]].getV());
                        c[i + 2].set_number(c[temp[2]].getV());
                        c[i + 3].set_number(0);
                    }
                    continue;
                }
                if (count == 4)
                {
                    int[] temp = new int[4];
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                        if (c[i + j].getV() != 0)
                            temp[k++] = i + j;
                    if (c[temp[0]].getV() == c[temp[1]].getV() && c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 1].set_number(c[temp[2]].getV() * 2);
                        c[i + 2].set_number(0);
                        c[i + 3].set_number(0);

                    }
                    else if (c[temp[0]].getV() == c[temp[1]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV() * 2);
                        c[i + 1].set_number(c[temp[2]].getV());
                        c[i + 2].set_number(c[temp[3]].getV());
                        c[i + 3].set_number(0);
                    }
                    else if (c[temp[1]].getV() == c[temp[2]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 1].set_number(c[temp[1]].getV() * 2);
                        c[i + 2].set_number(c[temp[3]].getV());
                        c[i + 3].set_number(0);
                    }
                    else if (c[temp[2]].getV() == c[temp[3]].getV())
                    {
                        c[i].set_number(c[temp[0]].getV());
                        c[i + 1].set_number(c[temp[1]].getV());
                        c[i + 2].set_number(c[temp[3]].getV() * 2);
                        c[i + 3].set_number(0);
                    }
                }

            }
        }
        private bool test_do_up()
        {
            for (int i = 0; i < 4; i++)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i + (j * 4)].getV() != 0)
                        count++;
                if (count == 1)
                    if (c[i].getV() == 0)
                        return true;
                if (count == 2)
                    if (c[i].getV() == 0 || c[i + 4].getV() == 0 || c[i].getV() == c[i + 4].getV())
                        return true;
                if (count == 3)
                {
                    if (c[i].getV() == 0 || c[i + 4].getV() == 0 || c[i + 8].getV() == 0)
                        return true;
                    else if (c[i].getV() == c[i + 4].getV() || c[i + 4].getV() == c[i + 8].getV())
                        return true;
                }
                if (count == 4)
                {
                    if (c[i].getV() == c[i + 4].getV())
                        return true;
                    else if (c[i + 4].getV() == c[i + 8].getV())
                        return true;
                    else if (c[i + 8].getV() == c[i + 12].getV())
                        return true;
                }
            }
            return false;
        }
        private bool test_do_right()
        {
            for (int i = 3; i < 16; i += 4)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i - j].getV() != 0)
                        count++;
                if (count == 1)
                    if (c[i].getV() == 0)
                        return true;
                if (count == 2)
                    if (c[i].getV() == 0 || c[i - 1].getV() == 0 || c[i].getV() == c[i - 1].getV())
                        return true;
                if (count == 3)
                {
                    if (c[i].getV() == 0 || c[i - 1].getV() == 0 || c[i - 2].getV() == 0)
                        return true;
                    else if (c[i].getV() == c[i - 1].getV() || c[i - 1].getV() == c[i - 2].getV())
                        return true;
                }
                if (count == 4)
                {
                    if (c[i].getV() == c[i - 1].getV())
                        return true;
                    else if (c[i - 1].getV() == c[i - 2].getV())
                        return true;
                    else if (c[i - 2].getV() == c[i - 3].getV())
                        return true;
                }
            }
            return false;
        }
        private bool test_do_down()
        {
            for (int i = 15; i > 11; i--)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i - (j * 4)].getV() != 0)
                        count++;
                if (count == 1)
                    if (c[i].getV() == 0)
                        return true;
                if (count == 2)
                    if (c[i].getV() == 0 || c[i - 4].getV() == 0 || c[i].getV() == c[i - 4].getV())
                        return true;
                if (count == 3)
                {
                    if (c[i].getV() == 0 || c[i - 4].getV() == 0 || c[i - 8].getV() == 0)
                        return true;
                    else if (c[i].getV() == c[i - 4].getV() || c[i - 4].getV() == c[i - 8].getV())
                        return true;
                }
                if (count == 4)
                {
                    if (c[i].getV() == c[i - 4].getV())
                        return true;
                    else if (c[i - 4].getV() == c[i - 8].getV())
                        return true;
                    else if (c[i - 8].getV() == c[i - 12].getV())
                        return true;
                }
            }
            return false;
        }
        private bool test_do_left()
        {
            for (int i = 0; i < 16; i += 4)
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                    if (c[i + j].getV() != 0)
                        count++;
                if (count == 1)
                    if (c[i].getV() == 0)
                        return true;
                if (count == 2)
                    if (c[i].getV() == 0 || c[i + 1].getV() == 0 || c[i].getV() == c[i + 1].getV())
                        return true;
                if (count == 3)
                {
                    if (c[i].getV() == 0 || c[i + 1].getV() == 0 || c[i + 2].getV() == 0)
                        return true;
                    else if (c[i].getV() == c[i + 1].getV() || c[i + 1].getV() == c[i + 2].getV())
                        return true;
                }
                if (count == 4)
                {
                    if (c[i].getV() == c[i + 1].getV())
                        return true;
                    else if (c[i + 1].getV() == c[i + 2].getV())
                        return true;
                    else if (c[i + 2].getV() == c[i + 3].getV())
                        return true;
                }
            }
            return false;
        }
        private bool do_key(int x)
        {
            if (loos)
                return true;
            if (Text_creat())
            {
                MessageBox.Show("you loss");
                loos = true;
                timer1.Stop();
                save_score();
            }     	        
            bool ans = false;
            if (x == 0)
            {
                ans = test_do_up();
                do_up();
            }
            else if (x == 1)
            {
                ans = test_do_right();
                do_right();
            }
            else if (x == 2)
            {
                ans = test_do_down();
                do_down();
            }
            else if (x == 3)
            {
                ans = test_do_left();
                do_left();
            }            
            Write_score();
            if (ans)
            {
                if (for_timer)
                {
                    for_timer = false;
                    timer1.Start();
                    timer2.Start();
                }                
                move_counter++;
                label7.Text = move_counter.ToString();
                create();                
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.Show();
        }        
        private void Write_score()
        {
            int temp_score = mind_score();
            int temp_digit = Multi_digit(score);
            label2.Text = score.ToString();
            if (temp_digit == 2)
                label6.Location = new Point(p.X + 10, p.Y);
            if (temp_digit == 3)
                label6.Location = new Point(p.X + 24, p.Y);
            if (temp_digit > 3)
            {
                float x = score / 1000f;
                x = ((int)(x * 10)) / 10f;
                label2.Text = x.ToString() + "k";
                label6.Location = new Point(p.X + 26, p.Y);
            }
            if (temp_score == score)
                label6.Text = "";
            else
                label6.Text = "+" + (temp_score - score).ToString();
            score = temp_score;
        }
        private int Multi_digit(int n)
        {
            if (n == 0)
                return 0;
            int i = 1;
            for (; ; i++)
            {
                if (n - (pow(10, i)) >= 0)
                {

                }
                else
                    break;
            }
            return i;
        }
        private int pow(int a, int b)
        {
            int ans = 1;
            for (int i = 0; i < b; i++)
                ans *= a;
            return ans;
        }
        private int mind_score()
        {
            int sum = 0;
            for (int i = 0; i < 16; i++)
                if (c[i].getV() > 2)
                    sum += score_value(c[i].getV());
            return sum;
        }
        private int score_value(int n)
        {
            if (n == 4)
                return 4;
            return n + (score_value(n / 2) * 2);
        }
        private void create()
        {
            int count = 0;
            for (int i = 0; i < 16; i++)
                if (c[i].getV() == 0)
                    count++;
            if (count != 0)
            {
                int[] temp = new int[count];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    if (c[i].getV() == 0)
                        temp[k++] = i;
                Random r = new Random();
                c[temp[r.Next(count)]].set_number(2);
            }

        }
        public void button_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Up)            
                do_key(0);
            if (e.KeyCode == Keys.Right)
                do_key(1);
            if (e.KeyCode == Keys.Down)
                do_key(2);
            if (e.KeyCode == Keys.Left)
                do_key(3);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            score = 0;
            for (int i = 0; i < 16; i++)
            {
                c[i].set_number(0);
            }
            label2.Text = score.ToString();
            label6.Text = "";
            start_create();   
        }
        private void time_trial_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_score();
        }
        private void save_score()
        {
            if (score > best_score)
            {
                //File.Create("score.txt");
                StreamWriter sw = new StreamWriter("score_for_time2048.txt");
                sw.WriteLine(score.ToString());
                sw.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Text_creat())
            {
                MessageBox.Show("you loss");
                loos = true;
                timer1.Stop();
                save_score();
            }                            
            else
            create();            
        }
        private bool Text_creat()
        {
            for (int i = 0; i < 16; i++)
                if (c[i].getV() == 0)
                    return false;
            return true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer_counter++;
            set_timer(timer_counter);
        }
        private void set_timer(int n)
        {
            label8.Text = "";
            if (n < 60)
                label8.Text = "00:";
            if (Multi_digit(n / 60) == 1)
                label8.Text = "0" + (n / 60).ToString() + ":";
            if (Multi_digit(n / 60) ==2)
                label8.Text = (n / 60).ToString() + ":";
            if (n % 60 == 0)
                label8.Text += "00";            
            if (Multi_digit(n % 60) == 1)
                label8.Text += "0" + (n % 60).ToString();
            if (Multi_digit(n % 60) == 2)
                label8.Text += (n % 60).ToString();
        }
    }
}
