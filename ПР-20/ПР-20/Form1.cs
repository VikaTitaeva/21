using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace ПР_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog SaveDlg = new OpenFileDialog();
        OpenFileDialog OpenDlg = new OpenFileDialog();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cTRLOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьCtrlOToolStripMenuItem_Click(object sender, EventArgs e) //открыть файл
        {
            
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.UTF8);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();

        }

        private void mn_SaveFileDialog_Click(object sender, EventArgs e) //сохранить файл
        {

            if (SaveDlg.ShowDialog() == DialogResult.OK)
             {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox1.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mn_ExitFileDialog_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это я создала, да");
        }

        private void button14_Click(object sender, EventArgs e) //начать
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Clear();
            checkBox1.Checked=false;
            radioButton1.Checked = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //поиск
        {
            listBox2.Items.Clear();
            string Find = textBox1.Text;
            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox2.Items.Add(String);
                }
            }

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox2.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox3.Items)
                {
                    if (String.Contains(Find)) listBox2.Items.Add(String);
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)//очистить
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }

        }

        private void button6_Click(object sender, EventArgs e)//сортировка
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            if(comboBox1.SelectedIndex==0)//алфавит по возрастанию
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                listBox1.Items.Clear();
                foreach (var item in list)
                listBox1.Items.Add(item);
            }
            if(comboBox1.SelectedIndex==1)//алфавит по убыванию
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(item);
            }
            if(comboBox1.SelectedIndex==2)//длина по возрастанию
            {
                List<String> list = new List<string>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
            if(comboBox1.SelectedIndex==3)//длина по убыванию
            {
                List<String> list = new List<string>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)//перенос текста вперед
        {
            listBox3.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
          
            listBox3.BeginUpdate();
            foreach (object Item in listBox1.SelectedItems)
            {
                listBox3.Items.Add(Item);
            }
            listBox3.EndUpdate();

        }

        private void button2_Click(object sender, EventArgs e)//перенос текста назад
        {
            listBox1.Items.AddRange(listBox3.Items);
            listBox3.Items.Clear();

            listBox1.BeginUpdate();
            foreach (object Item in listBox3.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
        }

        private void button3_Click(object sender, EventArgs e)//перенос выбранных строк вперед
        {
            listBox3.BeginUpdate();
            foreach (object Item in listBox1.SelectedItems)
            {
                listBox3.Items.Add(Item);
            }
            listBox3.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)//перенос выбранных строк назад
        {
            listBox1.BeginUpdate();
            foreach (object Item in listBox3.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)//сортировка 2
        {
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            if (comboBox2.SelectedIndex == 0)
            {
                List<String> list = new List<String>();
                foreach (var item in listBox3.Items)
                    list.Add(item.ToString());

                list.Sort();
                listBox3.Items.Clear();
                foreach (var item in list)
                    listBox3.Items.Add(item);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                List<String> list = new List<String>();
                foreach (var item in listBox3.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                listBox3.Items.Clear();
                foreach (var item in list)
                    listBox3.Items.Add(item);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                List<String> list = new List<string>();
                foreach (var item in listBox3.Items)
                    list.Add(item.ToString());

                listBox3.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox3.Items.Add(item);
            }
            if (comboBox2.SelectedIndex == 3)
            {
                List<String> list = new List<string>();
                foreach (var item in listBox3.Items)
                    list.Add(item.ToString());

                listBox3.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    listBox3.Items.Add(item);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
