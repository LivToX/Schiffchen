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
using Schiffchen6.Models;

namespace Schiffchen6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Ship> Ships = new List<Ship>();
        public static int serial = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Ship ship = new Ship(Sea, serial++);
            Ships.Add(ship);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
} 
