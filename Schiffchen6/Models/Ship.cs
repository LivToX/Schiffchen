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

        Line line;
        bool lineAdded = false;
        bool collision = false;

        public Rectangle rect;
        Random rnd = new Random();
        public Ship(Canvas Sea, int serial)
        {
            _serial = serial;

            divisor = rnd.Next(155, 200);
            VectorC vectorC = new VectorC(Sea, serial, divisor);
            vector = vectorC;
            line = new Line
            {
                Fill = Brushes.Purple,
                Stroke = Brushes.Red,
                StrokeThickness = 1
            };
            rect = new Rectangle
            {
                Fill = Brushes.Yellow,
                Width = 10,
                Height = 10
            };
            Canvas.SetLeft(rect, vectorC.Start.X);
            Canvas.SetTop(rect, vectorC.Start.Y);
            Sea.Children.Add(rect);
        }

        public void collisionCheck(Canvas Sea)
        {
            Point p = this.vector.Start;
            foreach (Ship ship in new List<Ship>(MainWindow.Ships.Where(x => x._serial != this._serial)))
            {
                Point p1 = ship.vector.Start;
                double distance = Point.Subtract(p, p1).Length;
                if (distance <= 100 && !ship.collision)
                {
                    line.X1 = p.X +(rect.Width/2);
                    line.Y1 = p.Y + (rect.Height / 2);
                    line.X2 = p1.X+ (rect.Width / 2);
                    line.Y2 = p1.Y+ (rect.Height / 2);
                    if (!lineAdded)
                    {
                        Sea.Children.Add(line);
                        lineAdded = true;
                    }
                }

                if (distance <= 1)
                {
                    this.rect.Fill = Brushes.Red;
                    ship.rect.Fill = Brushes.Red;
                    collision = true;
                }
            }
        }


    }
}
