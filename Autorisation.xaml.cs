using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Trade
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        TradeEntities connection = new TradeEntities();
        private string code = "";
        private int failcount = 0;
        private double blocktime = 0;
        private int blockInterval = 60000;
        private const string filename = "data.lock";
        public Autorisation()
        {
            InitializeComponent();


            string chars = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890@?#";
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 7; i++)
            {
                int a = random.Next(0, chars.Length - 1);
                code += chars.Substring(a, 1);
            }

            Captcha_Box.Text = code;

#if DEBUG
            Login.Text = "";
            Password.Password = "";
#endif
        }
        private void Enter_Btn_Click(object sender, RoutedEventArgs e)
        {
            string number_ad = Login.Text;
            string password_ad = Password.Password;
            string cap = Cod.Text;

            if ((number_ad.Length == 0) && (password_ad.Length == 0) && (cap.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if (Cod.Text != code)
            {
                MessageBox.Show("Неверный код проверки или некорректные данные!");
                failcount++;
                return;
            }

           

                var employee = connection.User.Where(em => em.UserLogin == number_ad && em.UserPassword == password_ad && em.UserRole == 1).FirstOrDefault();
                if (employee != null)
                {
                    MessageBox.Show("Добро пожаловать Администратор!");
                    NavigationService.Navigate(MainWindow.tradeAdministration);
                }
                var employ = connection.User.Where(em => em.UserLogin == number_ad && em.UserPassword == password_ad && em.UserRole ==2).FirstOrDefault();
                if (employ != null)
                {
                    MessageBox.Show("Добро пожаловать Менеджер!");
                    NavigationService.Navigate(MainWindow.trade);
                }
                var emplo = connection.User.Where(em => em.UserLogin == number_ad && em.UserPassword == password_ad && em.UserRole == 3).FirstOrDefault();
                if (emplo != null)
                {
                    MessageBox.Show("Добро пожаловать Клиент!");
                    NavigationService.Navigate(MainWindow.trade);
                }
            }
            // else
            //{
            //    //MessageBox.Show("Введены некорректные данные!!!");
            //}
        
    }
}
