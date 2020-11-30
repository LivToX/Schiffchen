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
    public class Ship
    {
        public int _serial { get; set; }
        public int exists = 0; 
        int divisor;
       
        public VectorC vector { get; set; }

        public Rectangle rect;
        Random rnd = new Random();
        public Ship(Canvas Sea , int serial )
        {
            _serial = serial;

            divisor = rnd.Next(155, 200);
            VectorC vectorC = new VectorC(Sea,serial,divisor);
            vector = vectorC;

            MainWindow.shipCount++;

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
