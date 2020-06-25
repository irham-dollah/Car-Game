using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Game
{
    public partial class Form1 : Form
    {
        int gamespeed = 1;
        int speedEnemy = 1;
        int coinVal = 0;
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void moveLine(int speed, int car)
        {
            if (pictureBox1.Top >= 376) { pictureBox1.Top = 0; } else { pictureBox1.Top += speed; }
            if (pictureBox2.Top >= 376) { pictureBox2.Top = 0; } else { pictureBox2.Top += speed; }
            if (pictureBox3.Top >= 376) { pictureBox3.Top = 0; } else { pictureBox3.Top += speed; }
            if (pictureBox4.Top >= 376) { pictureBox4.Top = 0; } else { pictureBox4.Top += speed; }
            if (pictureBox7.Bottom <=0) { pictureBox7.Top = 376; } else { pictureBox7.Top -= car; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(3, gamespeed);
            enemy(speedEnemy);
            coin();
            gameOver();
        }
        int i = 0;
        void enemy(int speed)
        {
            Random r = new Random();
            int x, y;
            if (pictureBox9.Top > 376)
            {
                x = r.Next(11, 135);
                y = -76;
                pictureBox9.Location = new Point(x, y);
                if (speedEnemy < 8)
                {
                    speedEnemy++;
                }
                else
                {
                    speedEnemy = 1;
                }
            }
            else
            {
                pictureBox9.Top += speed;
            }
        }

        void coin()
        {
            Random r = new Random();
            int x, y;
            if ((pictureBox7.Bounds.IntersectsWith(pictureBox10.Bounds)))
            {
                coinVal++;
                label5.Text = coinVal.ToString();
                x = r.Next(35, 135);
                y = r.Next(5,365) ;
                pictureBox10.Location = new Point(x, y);
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    return;
                }
            }
            if (e.KeyCode == Keys.Left)
            { 
                if(pictureBox7.Left>21)
                    pictureBox7.Left -= (gamespeed+10); 
            }
            if (e.KeyCode == Keys.Right)
            {
                if (pictureBox7.Right < 145)
                    pictureBox7.Left += (gamespeed+10);
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 10)
                    gamespeed++;
            }
            if(e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)
                    gamespeed--;
            }
        }
        void gameOver()
        {
            if (pictureBox7.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                timer1.Enabled = false;
                label4.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
