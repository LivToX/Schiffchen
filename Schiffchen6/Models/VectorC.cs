using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Schiffchen6.Models
{
    public class VectorC
    {
        public Point Start { get { return _Start; } set { _Start = value; line.X1 = value.X; line.Y1 = value.Y; } }
        Point _Start { get; set; } = new Point();

        public Point End { get { return _End; } set { _End = value; line.X2 = value.X; line.Y2 = value.Y; } }
        Point _End { get; set; } = new Point();

        Vector StepVector = new Vector();
        public Line line;
        int _divisor;
        int _serial;

        
        public double stepSizeX { get; set; }

        public double stepSizeY { get; set; }
        public VectorC(Canvas Sea, int serial, int divisor)
        {
            _serial = serial;

            _divisor = divisor;
            line = new Line
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Green,
                StrokeThickness = 2,
            };
            End = new Point(0, 0);
            Start = new Point(0, 0);
            pickASite(Sea);
            GetStepSize(Start, End);

            //Sea.Children.Add(line);

        }

        private void pickASite(Canvas Sea)
        {
            int SeaHeight = Convert.ToInt32(Sea.Height);
            int SeaWidth = Convert.ToInt32(Sea.Width);
            Random rnd = new Random();
            int start = rnd.Next(1, 5);
            int finish = RandomInt(start);
            Site Startsite = (Site)start;
            Site Finishsite = (Site)finish;

            switch (Startsite)              
            {                                                                                           
                case Site.Oben:
                    Start = new Point(rnd.Next(0, SeaWidth - 10), Start.Y);
                    break;
                case Site.Rechts:                                             
                    Start = new Point(SeaWidth - 10, rnd.Next(0, SeaHeight - 10));
                    break;
                case Site.Unten:                                              
                    Start = new Point(rnd.Next(0, SeaWidth - 10), SeaHeight -10 );
                    break;
                case Site.Links:                                            
                    Start = new Point(Start.X, rnd.Next(0, SeaHeight -10));
                    break;
            }

            switch (Finishsite)       
            {
                case Site.Oben:
                    End = new Point(rnd.Next(0, SeaWidth), End.Y);
                    break;
                case Site.Rechts:                                             
                    End = new Point(SeaWidth, rnd.Next(0, SeaHeight));
                    break;
                case Site.Unten:                                              
                    End = new Point(rnd.Next(0, SeaWidth), SeaHeight);
                    break;
                case Site.Links:
                    End = new Point(End.X, rnd.Next(0, SeaHeight));
                    break;
            }
        }

        private int RandomInt(int exclude)
        {
            var ex = new HashSet<int>() { exclude };
            var range = Enumerable.Range(1, 4).Where(x => !ex.Contains(x));

            var rand = new Random();
            int idx = rand.Next(0, 4 - ex.Count);
            return range.ElementAt(idx);
        }

        private (double, double) GetStepSize(Point Start, Point End)
        {
            Vector Vec123 = new Vector();
            Vec123.X = End.X - Start.X;
            Vec123.Y = End.Y - Start.Y;

            StepVector = Vec123 / _divisor;
            stepSizeX = StepVector.X;
            stepSizeY = StepVector.Y;
            return (stepSizeX, stepSizeY);
        }

        enum Site
        {
            Oben = 1,
            Rechts,
            Unten,
            Links
        }
    }
}
