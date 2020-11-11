using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Schiffchen6
{
    class Ship
    {
        //Postion
        //double x;
        //double y;

       // double speed;
        //double direction;

        Rectangle rect;
        
        public Ship(Canvas Sea)
        {
            rect = new Rectangle
            {
                Fill = Brushes.Red,
                Width = 10,
                Height = 10
            };
    
            Sea.Children.Add(rect);
        }

    }
}
