using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Schiffchen6.Models;

namespace Schiffchen6
{
    
    public class SchiffController
    {
        public static void moveShips(Canvas Sea)
        {
            foreach (Ship ship in new List<Ship>(MainWindow.Ships))
            {
                ship.vector.Start = new Point(Canvas.GetLeft(ship.rect), Canvas.GetTop(ship.rect));

                Canvas.SetLeft(ship.rect, ship.vector.Start.X + ship.vector.stepSizeX);
                Canvas.SetTop(ship.rect, ship.vector.Start.Y + ship.vector.stepSizeY);
                if(ship.vector.Start.X +10 >= Sea.Width  || ship.vector.Start.Y + 10 >= Sea.Height || ship.vector.Start.X <0 || ship.vector.Start.Y < 0)
                {
                    killShip(Sea, ship);
                }

            }
        }

        public static void killShip(Canvas Sea, Ship ship)
        {
            Sea.Children.Remove(ship.rect);
            int idx = MainWindow.Ships.FindIndex(x => x._serial == ship._serial);
            if (idx != -1)
                MainWindow.Ships.RemoveAt(idx);
            Sea.Children.Remove(ship.vector.line);
        }

        void collisionCheck()
        {

        }

        void createship()
        {

        }
    }
}
