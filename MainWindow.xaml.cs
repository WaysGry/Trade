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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public static Start start;
        public static Autorisation autorisation;
        public static Trade trade;
        public static TradeAdministration tradeAdministration;
        public MainWindow()
        {
            start = new Start();
            autorisation = new Autorisation();
            trade = new Trade();
            tradeAdministration = new TradeAdministration();
            InitializeComponent();
            MainFrame.Navigate(start);
        }
    }
}
