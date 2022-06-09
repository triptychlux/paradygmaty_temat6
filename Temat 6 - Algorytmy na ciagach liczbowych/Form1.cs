using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temat_6___Algorytmy_na_ciagach_liczbowych
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool IsPrime(int n)
        {
            int i;
            for (i = 2; i <= n - 1; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            if (i == n)
            {
                return true;
            }
            return false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // najdłuższy wspólny podciąg

            string a = Convert.ToString(textBox1);
            List<string> strSeq1 = a.Split(' ').ToList();
            List<int> sequence1 = strSeq1.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
            string b = Convert.ToString(textBox2);
            List<string> strSeq2 = b.Split(' ').ToList();
            List<int> sequence2 = strSeq2.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
            int i;
            int j;
            int k;
            int l;
            int seq1L = sequence1.Count;
            int seq2L = sequence2.Count;
            int[] arrA = new int[(seq1L + 1) * (seq2L + 1)];
            int[,] arrB = new int[(seq1L + 1), (seq2L + 1)];

            for (i = 0; i <= seq1L; ++i)
                arrB[i, 0] = arrA[i * (seq2L + 1)];

            for (i = 1; i <= seq1L; ++i)
            {
                for (j = 1; j <= seq2L; ++j)
                {
                    if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        arrB[i, j] = arrB[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        if (arrB[i - 1, j] > arrB[i, j - 1])
                        {
                            arrB[i, j] = arrB[i - 1, j];
                        }
                        else
                        {
                            arrB[i, j] = arrB[i, j - 1];
                        }
                    }
                }
            }
            l = arrB[seq1L, seq2L];
            int[] outputArr = new int[l];

            for (i = seq1L, j = seq2L, k = l - 1; k >= 0;)
            {
                if (sequence1[i - 1] == sequence2[j - 1])
                {
                    outputArr[k] = sequence1[i - 1];
                    --i;
                    --j;
                    --k;
                }
                else if (arrB[i, j - 1] > arrB[i - 1, j])
                    --j;
                else
                    --i;
            }
            string outputString = string.Join(" ", outputArr);
            label7.Text = Convert.ToString("Wspólne elementy ciągów: " + outputString);
            label4.Text = Convert.ToString("Suma wspólnych elementów: " + l);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // generator liczb pierwszych

            int amount = Convert.ToInt32(textBox3.Text);
            int start = Convert.ToInt32(textBox4.Text);
            List<int> numbers = new List<int>();

            for (; numbers.Count < amount; start++)
            {
                if (IsPrime(start) == true)
                {
                    numbers.Add(start);
                }
            }
            string outputString = string.Join(" ", numbers);
            label2.Text = Convert.ToString("Wygenerowane liczby:");
            textBox6.Text = Convert.ToString(outputString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // sprawdzenie ciągu liczb pierwszych

            string a = Convert.ToString(textBox5);
            List<string> strSeq = a.Split(' ').ToList();
            List<int> sequence = strSeq.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList();
            int[] arrSeq = sequence.ToArray();
            int counter = 0;
            int rise = 0;
            int ss = 0;

            foreach (int num in arrSeq)
            {
                if (num <= 1)
                {
                    counter--;
                }
                for (int i = 2; i < Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        counter--;
                    }
                }
                counter++;
                if (ss > 0)
                {
                    if (arrSeq[ss] > arrSeq[ss - 1])
                    {
                        rise++;
                    }
                }
                ss++;
            }
            if (counter == arrSeq.Length && (rise + 1) == arrSeq.Length)
            {
                label9.Text = "Podany ciąg jest ciągiem liczb pierwszych i jest rosnący";
            }
            else if (counter == arrSeq.Length)
            {
                label9.Text = "Podany ciąg jest ciągiem liczb pierwszych ale nie jest stale rosnący";
            }
            else
            {
                label9.Text = "To nie jest ciąg liczb pierwszych";
            }
        }
    }
}

