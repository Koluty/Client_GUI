using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_GUI
{
    internal class Client
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void Client_Connection()
        {
            try
            {
                socket.Connect("127.0.0.1", 8888);
                MessageBox.Show($"Підключення до {socket.RemoteEndPoint} встановлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Не вдалося встановити підключення до ", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void SendNumbers(double[] numbers)
        {
            // Створення буфера для відправки даних
            byte[] buffer = new byte[sizeof(double) * numbers.Length];

            // Конвертація чисел у байти і додавання їх до буфера
            for (int i = 0; i < numbers.Length; i++)
            {
                byte[] tempBuffer = BitConverter.GetBytes(numbers[i]);
                tempBuffer.CopyTo(buffer, i * sizeof(double));
            }

            // Відправка буфера на сервер
            socket.Send(buffer);
        }

        public double ReciveResult()
        {
            byte[] resultBuffer = new byte[512];
            socket.Receive(resultBuffer);
            return BitConverter.ToDouble(resultBuffer, 0);
        }
    }
}


