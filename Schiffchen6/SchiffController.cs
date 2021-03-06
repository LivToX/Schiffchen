﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Schiffchen6.Models;

namespace Schiffchen6
{

    public class SchiffController
    {
        public static void moveShips(Canvas Sea)
        {
            foreach (Ship ship in new List<Ship>(MainWindow.Ships))
            {
                ship.collisionCheck(Sea);
                ship.vector.Start = new Point(Canvas.GetLeft(ship.rect), Canvas.GetTop(ship.rect));
                ship.exists++;
                Canvas.SetLeft(ship.rect, ship.vector.Start.X + ship.vector.stepSizeX);
                Canvas.SetTop(ship.rect, ship.vector.Start.Y + ship.vector.stepSizeY);
                
                if (ship.exists > 5 && (ship.vector.Start.X >= Sea.Width - 10 || ship.vector.Start.Y >= Sea.Height - 10 || ship.vector.Start.X < 0 || ship.vector.Start.Y < 0))
                {
                    killShip(Sea, ship);
                }
            }
        }

        public static void killShip(Canvas Sea, Ship ship)
        {
            Sea.Children.Remove(ship.rect);
            Sea.Children.Remove(ship.ellipse);
            int idx = MainWindow.Ships.FindIndex(x => x._serial == ship._serial);
            if (idx != -1)
                MainWindow.Ships.RemoveAt(idx);
            Sea.Children.Remove(ship.vector.line);
            MainWindow.shipCount--;

        }

        public static void showPath(Canvas Sea)
        {
            if (!MainWindow.linesOn)
            {
                foreach (Ship ship in new List<Ship>(MainWindow.Ships))
                {
                    Sea.Children.Add(ship.vector.line);
                    Sea.Children.Remove(ship.rect);
                    Sea.Children.Add(ship.rect);

                }
                MainWindow.linesOn = true;
            }
            else
            {
                foreach (Ship ship in new List<Ship>(MainWindow.Ships))
                {
                    Sea.Children.Remove(ship.vector.line);
                }
                MainWindow.linesOn = false;
            }


        }
        public static void collisionCheck()
        {
            
        }

        public static void createship(Canvas Sea)
        {
            Ship ship = new Ship(Sea, MainWindow.serial++);
            MainWindow.Ships.Add(ship);
            MainWindow.shipCount++;
        }
    }
}
