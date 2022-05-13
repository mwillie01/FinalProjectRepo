using System.Media;

namespace AdditionFun
{
    public partial class Form1 : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            methodX(); //call the method to calculate 
        }

        int cal = 0;

        public void methodX()
        {
            Random rand = new Random(); //generate random numbers
            int first_value = rand.Next(100, 500); //first number is randomly generated between a range of 100 through 500
            int second_value = rand.Next(100, 500); //second number is randomly generated between a range of 100 through 500

            cal = first_value + second_value;
            label3.Text = first_value + " + " + second_value + " = ?";
        }
        Label lbl = new Label();
        private Button button1;


        private void button1_Click(object sender, EventArgs e)
        {
            string x = textBox1.Text;

            int currentLivesLeft = int.Parse(label5.Text);
            if (currentLivesLeft > 0)
            {
                string useranswer = textBox1.Text;
                if (!IsANumber(useranswer))
                {
                    DecrementLives(currentLivesLeft);
                    MessageBox.Show("Your answer is incorrect:( Remember, only enter numbers!");
                }
                else
                {
                    if (double.Parse(useranswer).Equals(cal))
                    {
                        playsound("Applause");
                        MessageBox.Show("Your answer is correct! Keep going! You're doing great!");
                        methodX();
                    }
                    else
                    {
                        playsound("booing");
                        DecrementLives(currentLivesLeft);
                        MessageBox.Show("Your answer is incorrect:(");
                    }
                }
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("You have no lives left:(");
            }
        }

        private void playsound(string soundtype)
        {

        }

        private void DecrementLives(int currentLivesLeft)
        {
            currentLivesLeft = currentLivesLeft - 1;
            label5.Text = currentLivesLeft.ToString();
            if (currentLivesLeft == 1)
            {
                label5.ForeColor = Color.Yellow;
            }
            else if (currentLivesLeft == 0)
            {
                label5.ForeColor = Color.Red;
               
            }
            
        }

        private bool IsANumber(string imputstr)
        {
            return decimal.TryParse(imputstr, out var result);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Color defaultcolor = button1.BackColor;
            button1.BackColor = System.Drawing.Color.LightPink;

        }

        private void button1_MouseLeave(object sender, EventArgs e) => button1.BackColor = Color.LightCyan;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               button1_Click(null, null);
            }
        }
        
    }
        
           
    
}

