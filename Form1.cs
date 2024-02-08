using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_GUI
{
    public partial class Form1 : Form
    {
        double a;
        double b;
        double c;
        Client client = new Client();
        bool connection_flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            Calculate_value calculate_Value = new Calculate_value();
            a = (double)value_a.Value;

            calculate_Value.C = a;
            calculate_Value.B = calculate_Value.C;

            c = calculate_Value.C;
            b = calculate_Value.B;

            value_b.Text = calculate_Value.B.ToString();
            value_c.Text = calculate_Value.C.ToString();
        }

        private void Conection_button_Click(object sender, EventArgs e)
        {
            if (connection_flag == false)
            {
                client.Client_Connection();
                connection_flag = true; 
            }
            else
                MessageBox.Show("Ви вже підключені до серву !", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] numbers = new double[3] { a, b, c };
            client.SendNumbers(numbers);
            label_result.Text = client.ReciveResult().ToString();
        }
    }
}
