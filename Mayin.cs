using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MayinTarlasi
{
   public class Mayin
    {
        Point loc;
        bool dolu;
        bool bakildi;
        public Mayin(Point Loca)
        {
            dolu = false;
            loc = Loca;
        }
        public Point KonumAl
        {
            get { return loc; }
        }
        public bool mayin_var_mi
        {
            get { return dolu; }
            set { dolu = value; }
        }
        public bool bakildi_mi
        {
            get { return bakildi; }
            set { bakildi = value; }
        }
    }
}
