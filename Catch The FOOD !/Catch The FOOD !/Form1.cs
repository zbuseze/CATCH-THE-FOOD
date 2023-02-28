using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch_The_FOOD__
{
    public partial class Form1 : Form
    {
        static int scoreCount = 0;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public static string Score2;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<Button> buttonlar = new List<Button>();
        Stack<Button> heart = new Stack<Button>();
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            heart.Push(button2);
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            heart.Push(button3);
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            heart.Push(button4);
            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            int z = 2;
            Button but = new Button();
            but.Image = Image.FromFile("mama1.png");
            but.BackColor = Color.Transparent;
            but.TabStop = false;
            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.BorderSize = 0;
            Random x = new Random();
            Point pt = new Point(int.Parse(x.Next(1480).ToString()), int.Parse(x.Next(0).ToString()));
            but.Location = pt;
            but.Size = new Size(50, 50);
            this.Controls.Add(but);
            buttonlar.Add(but);
            for (int m = 0; m < buttonlar.Count(); m++)
            {

                buttonlar[m].Location = new Point(buttonlar[m].Location.X, buttonlar[m].Location.Y + z);
                z += 15;

            }

        }
        static bool flag = false;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (flag == false)
            {
                button1.Text = "PAUSE ";
                timer1.Start();
                timer2.Start();
                flag = true;

            }
            else if (flag == true)
            {
                button1.Text = "START ";
                timer1.Stop();
                timer2.Stop();
                flag = false;
            }
        }

         private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            if (e.KeyCode == Keys.D)
                x += 20;
            else if (e.KeyCode == Keys.A)
                x -= 20;
            else if (e.KeyCode == Keys.S)
                y = y + 20;
            else if (e.KeyCode == Keys.W)
                y = y - 20;
            pictureBox1.Location = new Point(x, y);
        }

        int removeBut = 0;
        int heartCount = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
           
            int l = 0;
            while (l < buttonlar.Count)
            {
                if ((buttonlar[l].Location.X + 50 >= pictureBox1.Location.X) && (pictureBox1.Location.X + 100 >= buttonlar[l].Location.X))
                {
                    if ((buttonlar[l].Location.Y + 50 >= pictureBox1.Location.Y) && (buttonlar[l].Location.Y <= pictureBox1.Location.Y + 80))
                    {
                        buttonlar[l].Dispose();
                        buttonlar[l] = buttonlar[buttonlar.Count - 1];
                        buttonlar.RemoveAt(buttonlar.Count - 1);
                        scoreCount++;
                        label1.Text = ("Score: " + scoreCount);
                        
                    }

                }

                l++;
            }
            
            l = 0;
            while (l < buttonlar.Count)
            {
               
                if (buttonlar[l].Location.Y >= this.Height)
                {

                    buttonlar[l].Dispose();                            // butonu siler
                    buttonlar[l] = buttonlar[buttonlar.Count - 1];     // butonlardaki "l" elementine son butonu koyar    
                    buttonlar.RemoveAt(buttonlar.Count - 1);           // son butonu listeden kaldırır
                    removeBut++;
                    if (removeBut == 3)
                    {
                    
                        heart.Peek().Dispose();
                        heart.Pop();
                        heartCount++;
                        if (heartCount == 3)
                        {
                            Score2 = label1.Text;
                            Form2 form2 = new Form2();
                            form2.Show();
                            timer1.Stop();
                            timer2.Stop();
                        }
                        removeBut = 0;
                    }
                }
                l++;
            }

        }

    }
}
