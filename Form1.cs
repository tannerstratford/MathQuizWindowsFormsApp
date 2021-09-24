using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuizWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        /// 

        private bool CheckTheAnswer()
        {
            if(addend1 + addend2 == sum.Value 
                && minuend - subtrahend == difference.Value
                && multiplicand * multiplier == product.Value
                && dividend / divisor == quotient.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

        public void StartTheQuiz()
        {
            timeLabel.BackColor = Color.Transparent;
            //sets up addition problem with
            //random values
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //sets the text in the form to display the
            //values of addend1 and addend2
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //makes sure the original value of the NumericUpDown control
            //is equal to 0.
            sum.Value = 0;

            //subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            timeLeft = 30;
            timeLabel.Text = $"{timeLeft} seconds";
            timer1.Start();


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timeLabel.BackColor = Color.Transparent;
                timer1.Stop();
                MessageBox.Show("Congratulations! You got all of the answers right");
                startButton.Enabled = true;
            }
            
            else if(timeLeft > 0)
            {
                //update the time left and display it
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                if(timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Times up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answerEnter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
