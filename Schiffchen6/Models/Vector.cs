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
        public Point Start = new Point();
        public Point End = new Point();
        Vector StepVector = new Vector();
        Line line;

        int _serial;

        public double stepSizeX { get; set; }
        
        public double stepSizeY { get; set; }
        public VectorC(Canvas Sea,int serial)
        {
            _serial = serial;
            pickASite(Sea);
            GetStepSize(Start, End);

            line = new Line
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Green,
                StrokeThickness = 2,

                X1 = Start.X,
                Y1 = Start.Y,
                X2 = End.X,
                Y2 = End.Y
            };
            Sea.Children.Add(line);
           
        }

        private (double, double, double, double) pickASite(Canvas Sea)
        {
            int SeaHeight = Convert.ToInt32(Sea.Height);
            int SeaWidth = Convert.ToInt32(Sea.Width);
            Random rnd = new Random();
            int Startsite;
            int Finishsite;
            Startsite = rnd.Next(1, 5);
            Finishsite = rnd.Next(1, 4);
            switch (Startsite)              //Anfang vom Vektor
            {                                                                                           // immer im Uhrzeigersinn
                case 1:                                               //top
                    Start.Y = 0;
                    Start.X = rnd.Next(0, SeaWidth);
                    switch (Finishsite)     //Ende vom Vektor        
                    {

                        case 1:
                            End.X = SeaWidth;
                            End.Y = rnd.Next(0, SeaHeight); // alles was fehlt am ende hinzufügen ?!
                            break;
                        case 2:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = SeaHeight;
                            break;
                        case 3:
                            End.X = 0;
                            End.Y = rnd.Next(0, SeaHeight);
                            break;
                    }
                    break;
                case 2:                                             //right
                    Start.X = SeaWidth;
                    Start.Y = rnd.Next(0, SeaHeight);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = SeaHeight;
                            break;
                        case 2:
                            End.X = 0;
                            End.Y = rnd.Next(0, SeaHeight);
                            break;
                        case 3:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = 0;
                            break;
                    }

                    break;
                case 3:                                              //bottom
                    Start.Y = SeaHeight;
                    Start.X = rnd.Next(0, SeaWidth);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:
                            End.X = 0;
                            End.Y = rnd.Next(0, SeaHeight);
                            break;
                        case 2:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = 0;
                            break;
                        case 3:
                            End.X = SeaWidth;
                            End.Y = rnd.Next(0, SeaHeight);
                            break;
                    }

                    break;
                case 4:                                             //Left
                    Start.X = 0;
                    Start.Y = rnd.Next(0, SeaHeight);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = 0;
                            break;
                        case 2:
                            End.X = SeaWidth;
                            End.Y = rnd.Next(0, SeaHeight);
                            break;
                        case 3:
                            End.X = rnd.Next(0, SeaWidth);
                            End.Y = SeaHeight;
                            break;
                    }
                    break;


            }

            return (Start.X, End.X, Start.Y, End.Y);
        }
        private (double, double) GetStepSize(Point Start, Point End)
        {
            Vector Vec123 = new Vector();
            Vec123.X = End.X - Start.X;
            Vec123.Y = End.Y - Start.Y;
            
            StepVector = Vec123 / 5;
            stepSizeX = StepVector.X;
            stepSizeY = StepVector.Y;
            return (stepSizeX, stepSizeY);
        }
    }
}
