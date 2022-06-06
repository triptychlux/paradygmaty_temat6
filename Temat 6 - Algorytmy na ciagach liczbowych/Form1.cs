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

            string a = Convert.ToString(textBox1);
            List<string> strSeq1 = a.Split(' ').ToList();
            List<int> sequence1 = strSeq1.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
            string b = Convert.ToString(textBox2);
            List<string> strSeq2 = b.Split(' ').ToList();
            List<int> sequence2 = strSeq2.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();

            int i, j, k, t;
            int s1Len = sequence1.Count;
            int s2Len = sequence2.Count;
            int[] z = new int[(s1Len + 1) * (s2Len + 1)];
            int[,] c = new int[(s1Len + 1), (s2Len + 1)];

            for (i = 0; i <= s1Len; ++i)
                c[i, 0] = z[i * (s2Len + 1)];

            for (i = 1; i <= s1Len; ++i)
            {
                for (j = 1; j <= s2Len; ++j)
                {
                    if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        if (c[i - 1, j] > c[i, j - 1])
                        {
                            c[i, j] = c[i - 1, j];
                        }
                        else
                        {
                            c[i, j] = c[i, j - 1];
                        }
                    }
                }
            }
            t = c[s1Len, s2Len];
            int[] outputSB = new int[t];

            for (i = s1Len, j = s2Len, k = t - 1; k >= 0;)
            {
                if (sequence1[i - 1] == sequence2[j - 1])
                {
                    outputSB[k] = sequence1[i - 1];
                    --i;
                    --j;
                    --k;
                }
                else if (c[i, j - 1] > c[i - 1, j])
                    --j;
                else
                    --i;
            }
            string outputString = string.Join(" ", outputSB);

            label2.Text = Convert.ToString(outputString);

            label4.Text = Convert.ToString(t);

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
            LCS();




            /*
             CAŁKOWICIE TESTOWE GÓWNO

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

            */
        }
    }
}
