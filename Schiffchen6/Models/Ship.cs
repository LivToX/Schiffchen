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

namespace Schiffchen6.Models
{
    class Ship
    {
        int serial { get; set; }


        double x;
        double y;

        // double speed;
        //double direction;

        Rectangle rect;
        
        public Ship(Canvas Sea , int _serial )
        {
            serial = _serial;
            VectorC vectorC = new VectorC(Sea,serial);
            
            rect = new Rectangle
            {
                Fill = Brushes.Red,
                Width = 10,
                Height = 10
            };
            Canvas.SetLeft(rect, vectorC.Start.X);
            Canvas.SetTop(rect, vectorC.Start.Y);
            Sea.Children.Add(rect);
        }


    }
}
