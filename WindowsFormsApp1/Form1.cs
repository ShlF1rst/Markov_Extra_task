using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int count = 0;
        TextBox[] tbs1 = new TextBox[100];
        TextBox[] tbs2 = new TextBox[100];
        Label[] lbs = new Label[100];

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int left = 20;
            int top = 110;
            int.TryParse(count_of_ch.Text, out count);
            tbs1 = new TextBox[100];
            tbs2 = new TextBox[100];
            lbs = new Label[100];

            this.Controls.Clear();
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(count_of_ch);
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(label4);
            this.Controls.Add(textBox3);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Controls.Add(label7);

            for (int i = 0; i < count; i++)
            {
                tbs1[i] = new TextBox();
                tbs1[i].Location = new Point(left, top);
                tbs2[i] = new TextBox();
                tbs2[i].Location = new Point(left+200, top);
                lbs[i] = new Label();
                lbs[i].Location = new Point(left+120,top);
                lbs[i].Text = "---------------->";
                this.Controls.Add(tbs1[i]);
                this.Controls.Add(tbs2[i]);
                this.Controls.Add(lbs[i]);
              
                top += 30;
            }
            TextBox word_box = new TextBox();
            word_box.Location = new Point(button1.Left + 150, button1.Top+2);
            this.Controls.Add(word_box);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool check = false;
            string word = textBox1.Text;
            string prom = word;
            int ind = -1;
            if (word == "eps")
                word = "";
            while (true)
            {
                int j = 0;
                j++;
                for (int i = 0; i < count; i++)
                {
                    ind = word.IndexOf(tbs1[i].Text);
                    if (tbs1[i].Text == "eps")
                        ind = 0;
                    if (ind != -1)
                    {
                       
                        check = true;
                        if (j>=500)
                        {
                            word = "Эта подстановка не выполнима на этом слове - происходит зацикливание.";
                            check = false;
                            break;
                        }
                        

                        string ins = tbs2[i].Text;
                        if (ins.IndexOf('.') == 0)
                        {
                            ins = ins.Remove(0, 1);
                            check = false;
                        }
                        if (tbs1[i].Text != "eps")
                            word = word.Remove(ind, tbs1[i].Text.Length);
                        if (ins!="eps")
                            word = word.Insert(ind, ins);
                        prom += " ---> " + word;
                        break;
                    }
                    else
                        check = false;
                    
                }
                textBox2.Text = word;

                textBox3.Text = prom;
                if (!check)
                    break;
                

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
