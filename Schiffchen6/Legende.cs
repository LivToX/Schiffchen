using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Schiffchen6
{
    class Legende
    {
        Line line;

        public Legende(Canvas Sea)
        {

            line = new Line {
                X1 =  10,
                Y1 = Sea.Height +10,
                X2 =  110,
                Y2 = Sea.Height+ 10,

                Fill = Brushes.Black,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Sea.Children.Add(line);
        }




    }
}
