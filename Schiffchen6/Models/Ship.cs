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

        Ellipse ellipse;
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
            ellipse = new Ellipse
            {                
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Width = 100,
                Height = 100
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
                    Canvas.SetLeft(ellipse, p.X-(ellipse.Width/2) + (rect.Width / 2));
                    Canvas.SetTop(ellipse, p.Y - (ellipse.Height / 2) + (rect.Height / 2));
                    //line.X1 = p.X +(rect.Width/2);
                    //line.Y1 = p.Y + (rect.Height / 2);
                    //line.X2 = p1.X+ (rect.Width / 2);
                    //line.Y2 = p1.Y+ (rect.Height / 2);
                    if (!lineAdded)
                    {
                        Sea.Children.Remove(this.rect);
                        Sea.Children.Remove(ship.rect);
                        Sea.Children.Add(ellipse);
                        Sea.Children.Add(this.rect);
                        Sea.Children.Add(ship.rect);
                        lineAdded = true;
                    }
                    if(lineAdded && distance >= 100)
                    {
                        Sea.Children.Remove(ellipse);

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
