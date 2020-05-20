using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MayinTarlasi
{
    class Tarla
    {
        Size buyukluk_;
        List<Mayin> mayinlar;
        int DoluMayinlar;
        Random rnd = new Random();
        private Size size;

        public Tarla(Size buyukluk,int mayin_sayisi)
        {
            DoluMayinlar = mayin_sayisi;
            mayinlar = new List<Mayin>();
            buyukluk_ = buyukluk;
            for(int x=0; x < buyukluk.Width; x = x + 20)
            {
                for(int y = 0; y < buyukluk.Height; y = y + 20)
                {
                    Mayin m = new Mayin(new Point(x, y));
                    MayinEkle(m);
                }
            }
            MayinlariDoldur();
        }

        public Tarla(Size size)
        {
            this.size = size;
        }
        public Size buyuklugu
        {
            get { return buyukluk_; }
        }
        public void MayinEkle(Mayin m)
        {
            mayinlar.Add(m);
        }
        private void MayinlariDoldur()
        {
            int sayi = 0;
            while (sayi < DoluMayinlar)
            {
                int i = rnd.Next(0, mayinlar.Count);
                Mayin item = mayinlar[i];
                if (item.mayin_var_mi == false)
                {
                    item.mayin_var_mi = true;
                    sayi++;
                }
            }
        }
        public Mayin mayin_al_loc(Point loc)
        {
            foreach(Mayin item in mayinlar)
            {
                if(item.KonumAl == loc)
                {
                    return item;
                }
                    
            }
            return null;
        }
        public List<Mayin> GetAllMayin
        {
            get { return mayinlar; }
            
        }
        
        

        }
    }

