using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int sumvar1, sumvar2;
        int diffvar1, diffvar2;
        int multvar1, multvar2;
        int subvar1, subvar2;
        int timeLeft;

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            sumvar1 = randomizer.Next(51);
            sumvar2 = randomizer.Next(51);
            plusLeftLabel.Text = sumvar1.ToString();
            plusRightLabel.Text = sumvar2.ToString();
            sum.Value = 0;

            diffvar1 = randomizer.Next(1, 101);
            diffvar2 = randomizer.Next(1, diffvar1);
            minusLeftLabel.Text = diffvar1.ToString();
            minusRightLabel.Text = diffvar2.ToString();
            difference.Value = 0;

            multvar1 = randomizer.Next(2, 11);
            multvar2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = multvar1.ToString();
            timesRightLabel.Text = multvar2.ToString();
            product.Value = 0;

            subvar2 = randomizer.Next(2, 11);
            int tempSth = randomizer.Next(2, 11);
            subvar1 = subvar2 * tempSth;
            dividedLeftLabel.Text = subvar1.ToString();
            dividedRightLabel.Text = subvar2.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "Ai 30 secunde.";
            timer1.Start();
        }
        public bool CheckIfTrue()
        {
            if((sumvar1 + sumvar2 == sum.Value) && (diffvar1 - diffvar2 == difference.Value) && (multvar1 * multvar2 == product.Value) && (subvar1 / subvar2 == quotient.Value))
            { return true; }
            else
            { return false; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckIfTrue())
            {
                timer1.Stop();
                MessageBox.Show("Yaaay", "Azi nu luam 4 la mate!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Opaaa. Nu mai ai.";
                MessageBox.Show("Trebuia sa mai bagi viteza.", "Aia e");
                sum.Value = sumvar1 + sumvar2;
                difference.Value = diffvar1 - diffvar2;
                product.Value = multvar1 * multvar2;
                quotient.Value = subvar1 / subvar2;
                startButton.Enabled = true;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
