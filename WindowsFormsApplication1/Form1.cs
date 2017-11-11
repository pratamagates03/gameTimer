using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Stopwatch objStopWatch = new Stopwatch();
        bool paused = false;
        int tamp = 0;
        int[] array;
        int[] array2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nilairand();
        }



        public void createbddsdutton()
        {

            int top = 108;
            int k = 1;
            for (int i = 0; i < 5; i++)
            {
                int left = 29;
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(34, 34);
                    button.Left = left;
                    button.Top = top;
                    this.Controls.Add(button);
                    left += 39;
                    button.Name = "button" + k;
                    button.Click += tombolklik;
                    k++;
                }
                top += 39;
            }
        }

        private void tombolklik(object sender, EventArgs e)
        {
            Button button=sender as Button;
            button.Text = cek(Int32.Parse(button.Text));
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (objStopWatch.IsRunning)
            {
                TimeSpan objTimeSpan = TimeSpan.FromMilliseconds(objStopWatch.ElapsedMilliseconds);
                label2.Text = String.Format(CultureInfo.CurrentCulture, "{0:00}:{1:00}:{2:00}.{3:00}", objTimeSpan.Hours, objTimeSpan.Minutes, objTimeSpan.Seconds, objTimeSpan.Milliseconds / 10);
                if (paused)
                {
                    paused = false;
                }
                
            }
        }

        string cek(int x)
        {
            string angka = Convert.ToString(x);
            if (x == Int32.Parse(label3.Text) + 1)
            {
                label3.Text = Convert.ToString(Int32.Parse(label3.Text) + 1);
                tamp++;
                if (x <= 25)
                    angka = array2[x - 1].ToString();
                else if (x > 25 && tamp == x)
                    angka = " ";
            }
            if (x == 1) objStopWatch.Start();
            else if (tamp == 50) { objStopWatch.Stop(); label5.Visible = true; }
            return angka;
        }

        
        public void nilairand()
        {
            createbddsdutton();
            label5.Visible = false;
            Random random = new Random();
            array = new int[25];
            array2 = new int[25];
            int nom;
            for (int i = 0; i < 25; i++)
            {
                nom = random.Next(1, 26);
                if (!array.Contains(nom))
                    array[i] = nom;
                else
                    i--;
            }
            for (int i = 0; i < 25; i++)
            {
                nom = random.Next(26, 51);
                if (!array2.Contains(nom))
                    array2[i] = nom;
                else
                    i--;
            }

            for (int i = 1; i < 26; i++)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button && c.Name.EndsWith(i.ToString()))
                    {
                        c.Text = array[i - 1].ToString();
                    }

                }
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label2.Text = "00:00:00.00";
            label3.Text = "0";
            objStopWatch.Reset();
            nilairand();
        }

        

        

        
    }
}

