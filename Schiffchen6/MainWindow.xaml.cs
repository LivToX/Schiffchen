using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool moving = false;
        public static bool linesOn = false;
        public static int shipCount = 0;
        double ticks = 0;
        public MainWindow()
        {
            InitializeComponent();
            Legende legende = new Legende(Sea);
            Tick();
        }

        private void AddShip_Click(object sender, RoutedEventArgs e)
        {
            SchiffController.createship(Sea);
            lblShipCount.Content = shipCount;
            if (shipCount > 19)
            {
                AddShip.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (moving)
                moving = false;
            else
                moving = true;
        }

        private async void Tick()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            lblShipCount.Content = shipCount;
           
            if (shipCount < 20)
            {
                AddShip.IsEnabled = true;
            }       
            
            if (moving)
            {
                SchiffController.moveShips(Sea);
            }

            if (ticks >= 1 && shipCount < 20)
            {
                ticks = 0;
                                
                SchiffController.createship(Sea);
                lblShipCount.Content = shipCount;
            }
            ticks++;
            watch.Stop();
            await Task.Delay(100);

            Tick();
        }



        private void btnshowPath_Click(object sender, RoutedEventArgs e)
        {
            SchiffController.showPath(Sea);
        }
    }
}
