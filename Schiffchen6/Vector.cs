﻿using System;
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

namespace Schiffchen6
{
    public class Vector
    {
        public Point Start = new Point();
        public Point End = new Point();
        public double SX { get; set; }
        public double EX { get; set; }
        public double SY { get; set; }
        public double EY { get; set; }

        Line line;
        public Vector(Canvas Sea)
        {
            pickASite(Sea);


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




        }

        public (double, double, double, double) pickASite(Canvas Sea)
        {
            int SeaHeight = Convert.ToInt32(Sea.Height);
            int SeaWidth = Convert.ToInt32(Sea.Width);
            Random rnd = new Random();
            int Startsite;
            int Finishsite;
            Startsite = rnd.Next(1, 5);
            Finishsite = rnd.Next(1, 4);
            switch (Startsite)              //Anfang
            {
                case 1:                                               //top
                    Start.Y = 0;
                    Start.X = rnd.Next(0, SeaWidth);
                    switch (Finishsite)     //Ende                   
                    {

                        case 1:
                            End.X = SeaWidth;
                            End.Y = rnd.Next(0, SeaHeight); // alles was fehlt am ende hinzufügen ?!
                            break;
                        case 2:
                            End.X =
                            End.Y =
                            break;
                        case 3:
                            End.X =
                            End.Y =
                            break;
                    }
                    break;
                case 2:                                             //right
                    Start.X = SeaWidth;
                    Start.Y = rnd.Next(0, SeaHeight);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:
                            End.X =
                            End.Y =
                            break;
                        case 2:
                            End.X =
                            End.Y =
                            break;
                        case 3:
                            End.X =
                            End.Y =
                            break;
                    }

                    break;
                case 3:                                              //bottom
                    Start.Y = SeaHeight;
                    Start.X = rnd.Next(0, SeaWidth);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:
                            End.X =
                            End.Y =
                            break;
                        case 2:
                            End.X =
                            End.Y =
                            break;
                        case 3:
                            End.X =
                            End.Y =
                            break;
                    }

                    break;
                case 4:                                             //Left
                    Start.X = 0;
                    Start.Y = rnd.Next(0, SeaHeight);
                    switch (Finishsite)     //Ende        
                    {

                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                    }
                    break;


            }




            return (Start.X, End.X, Start.Y, End.Y);
        }





    }
}
