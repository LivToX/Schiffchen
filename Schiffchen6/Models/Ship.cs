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

        int divisor;
        //public double x;
        //public double y;
        //public double stepX;
        //public double stepY;
        //public double xEnd;
        public VectorC vector { get; set; }

        // double speed;
        //double direction;

        public Rectangle rect;
        Random rnd = new Random();
        public Ship(Canvas Sea , int serial )
        {
            _serial = serial;

            divisor = rnd.Next(100, 500);
            VectorC vectorC = new VectorC(Sea,serial,divisor);
            vector = vectorC;

            //x = vectorC.Start.X;
            //y = vectorC.Start.Y;
            //stepX = vectorC.stepSizeX;
            //stepY = vectorC.stepSizeY;
            //xEnd = vectorC.End.X;

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
