using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string[] words = { "granivorous", "crusty", "mouse", "universal", "tepid", "thermopile", "interrogation", "subjacent", "eclectic", "dutiable", "enounce", "cost", "pinaceous", "mover", "langsyne", "methodical", "preceptor", "solemn", "depart", "caiman" };
        public static char[] arrayWords;
        public static int wordRandom;
        Random random = new Random();


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{


        //    wordRandom = random.Next(0, words.Length);//words[]'deki mevcut kelime kadar olan random üretimi
        //    arrayWords = words[wordRandom].ToCharArray();//Rastgele seçilen Cümlenin Harfleri
        //    TextBox[] textbox = new TextBox[arrayWords.Length];//Oluşturulacak kelime ağacı uzunluğu 
        //    for (int i = 0; i < arrayWords.Length; i++)//Kullanılan kelimenin parça uzunluğu
        //    {

        //        textbox[i] = new TextBox();
        //        textbox[i].Text = arrayWords[i].ToString();
        //        panel1.Controls.Add(textbox[i]);//Her bir Kelimenin textBox'a basılması
        //        textbox[i].Top = 30;
        //        textbox[i].Left = i * 30; 
        //        textbox[i].Width = 30;

        //    }
        //    button1.Enabled = false;
        //    button2.Enabled = true;
        //}

        private void button1_Click(object sender, EventArgs e)
        {


            wordRandom = random.Next(0, words.Length);//words[]'deki mevcut kelime kadar olan random üretimi
            arrayWords = words[wordRandom].ToCharArray();//Rastgele seçilen Cümlenin Harfleri
            TextBox[] textbox = new TextBox[arrayWords.Length];//Oluşturulacak kelime ağacı uzunluğu 
            for (int i = 0; i < arrayWords.Length; i++)//Kullanılan kelimenin parça uzunluğu
            {

                textbox[i] = new TextBox();
                textbox[i].Text = arrayWords[i].ToString();
                textbox[i].Name = "textbox-" + i;
                panel1.Controls.Add(textbox[i]);//Her bir Kelimenin textBox'a basılması
                textbox[i].Top = 30;
                textbox[i].Left = i * 30;
                textbox[i].Width = 30;
                textbox[i].KeyPress += Form1_KeyPress;

            }
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textbox = (TextBox)sender;

            var index = int.Parse(textbox.Name.Split('-')[1]);

            if (textbox.Text == arrayWords[index].ToString())
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("fail");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {

                ((Panel)panel).Controls.Clear();
            }
            button1.Enabled = true;
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int giveNumber = random.Next(0, words[wordRandom].Length);
            label1.Text = giveNumber.ToString();


        }
    }
}
