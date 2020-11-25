using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Schiffchen6.Models;

namespace Schiffchen6
{
    
    public class SchiffController
    {
        
        public static void moveShips(Canvas Sea)
        {
            foreach (Ship ship in new List<Ship>(MainWindow.Ships))
            {
                ship.x = Canvas.GetLeft(ship.rect);
                ship.y = Canvas.GetTop(ship.rect);
                Canvas.SetLeft(ship.rect, ship.x + ship.stepX);
                Canvas.SetTop(ship.rect, ship.y + ship.stepY);
            }
        }

        void killShips()
        {

        }

        void collisionCheck()
        {

        }

        void createship()
        {

        }
    }
}
