using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Schiffchen6
{
    
    public class Model
    {
        
        public void moveShips(Canvas Sea)
        {
            VectorC Testv = new VectorC(Sea);
            Ship ship = new Ship(Sea);
            ship.moveShip(Sea, Testv.Testx, Testv.Testy);

        }

        void killShips()
        {

        }

        void collisionCheck()
        {

        }

        void createship()
        {

        }
    }
}
