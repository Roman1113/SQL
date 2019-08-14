using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParolGeneratoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void SendParol(string send)
        {
            var fromAddress = new MailAddress("maksutroman@gmail.com");
            var fromPassword = "romeo123123123";
            var toAddress = new MailAddress("maksutroman@ukr.net");

            string subject = "Пароль для входу у систему!!!";
            string body = "Ваш пароль для входу у систему - " + send;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
            label.Content = "Пароль відправлено на пошту";
        }

        public MainWindow()
        {
            InitializeComponent();

        }
        private void btnGenerationParol(object sender, RoutedEventArgs e)
        {
            string result = "";
            string simbol = "qwertyuopasdfghjkzxcvbnm";
            simbol += "!@#$%^&*()";
            simbol += "23456789";
            simbol += "QWERTYUOPASDFGHJKZXCVBNM";
            Random rnd = new Random();
            int val = rnd.Next(6, 10);
            int lng = simbol.Length;
            for (int i = 0; i < val; i++)
                result += simbol[rnd.Next(lng)];
            textBox.Text = result;
            string send = textBox.Text;

            SendParol(send);
        }
    }
}
