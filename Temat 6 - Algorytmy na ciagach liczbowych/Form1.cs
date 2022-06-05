using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Temat_6___Algorytmy_na_ciagach_liczbowych
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void LCS()
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(textBox1);
            List<string> strSeq1 = a.Split(' ').ToList();
            List<int> sequence1 = strSeq1.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
            //test
            int total1 = sequence1.Sum();


            int total2 = 0;
            int total = 0;

            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                string b = Convert.ToString(textBox2);
                List<string> strSeq2 = b.Split(' ').ToList();
                List<int> sequence2 = strSeq2.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
                //test
                total2 = sequence2.Sum();
                total = total1 + total2;
                label2.Text = Convert.ToString("Dwujeczka GIT " + total);
            }
            else
            {
                total = total1 + total2;
                label2.Text = Convert.ToString("Dwujeczka pusta " + total);
            }
        }
    }
}
