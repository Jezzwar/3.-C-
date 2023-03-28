using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Projekt1_Nesster_59112
{
    public class Macierz
    {
        private float[,] vnmacierz;


        //deklaracja konstruktorska
        public Macierz(ushort vnliczbaWierzy, ushort vnliczbaKolumn)
        {
            vnmacierz = new float[vnliczbaWierzy, vnliczbaKolumn];
        }


        //deklaracja właściwości klasy Macierz


        public ushort vnLiczbaWierzy
        {
            get { return (ushort)vnmacierz.GetLength(0); }
        }
        public ushort vnLiczbaKolumn
        {
            get { return (ushort)vnmacierz.GetLength(1); }
        }
        public float this[ushort vnNrWiersza, ushort vnNrKolumny]
        {
            set
            {
                if ((vnNrWiersza >= 0) && (vnNrWiersza < vnmacierz.GetLength(0)) &&
                    (vnNrKolumny >= 0) && (vnNrKolumny < vnmacierz.GetLength(1)))
                    vnmacierz[vnNrWiersza, vnNrKolumny] = value;
                else//wypisanie blędu
                    throw new IndexOutOfRangeException("ERROR: wartość jednego z indeksów" +
                        "macierzy wykracza poza dozwolonych zekres");
            }
            get
            {
                if ((vnNrWiersza >= 0) && (vnNrWiersza < vnmacierz.GetLength(0)) &&
                   (vnNrKolumny >= 0) && (vnNrKolumny < vnmacierz.GetLength(1)))
                    return vnmacierz[vnNrWiersza, vnNrKolumny];
                else//wypisanie blędu
                    throw new IndexOutOfRangeException("ERROR: wartość jednego z indeksów" +
                        "macierzy wykracza poza dozwolonych zekres");
            }
        }



        public static Macierz operator +(Macierz vna, Macierz vnb)
        {
            if (vna.vnLiczbaWierzy != vnb.vnLiczbaWierzy ||
            vna.vnLiczbaKolumn != vnb.vnLiczbaKolumn)
                throw new ArgumentException("Zły rozmiar macierzy");
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vna.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vna.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = vna.vnmacierz[vni, vnj] + vnb.vnmacierz[vni, vnj];
                }
            }
            return vnc;
        }



        public static Macierz operator -(Macierz vna, Macierz vnb)
        {
            if (vna.vnLiczbaWierzy != vnb.vnLiczbaWierzy ||
            vna.vnLiczbaKolumn != vnb.vnLiczbaKolumn)
                throw new ArgumentException("Zły rozmiar macierzy");
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vna.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vna.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = vna.vnmacierz[vni, vnj] - vnb.vnmacierz[vni, vnj];
                }
            }
            return vnc;
        }

        public static Macierz operator ^ (Macierz vnb, Macierz vna)
        {
            if (vna.vnLiczbaWierzy != vnb.vnLiczbaWierzy ||
            vna.vnLiczbaKolumn != vnb.vnLiczbaKolumn)
                throw new ArgumentException("Zły rozmiar macierzy");
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vna.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vna.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = vnb.vnmacierz[vni, vnj] - vna.vnmacierz[vni, vnj];
                }
            }
            return vnc;
        }

        public static Macierz operator /(Macierz vna, Macierz vnb)
        {
            if (vna.vnLiczbaWierzy != vnb.vnLiczbaWierzy ||
            vna.vnLiczbaKolumn != vnb.vnLiczbaKolumn)
                throw new ArgumentException("Zły rozmiar macierzy");
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vnb.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vnb.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = 0;
                    for (ushort vnk = 0; vnk < vnb.vnLiczbaWierzy; vnk++)
                    {
                        vnc.vnmacierz[vni, vnj] += vna.vnmacierz[vni, vnk] / vnb.vnmacierz[vnk, vnj];
                    }
                }

            }
            return vnc;
        }


        public static Macierz operator /(Macierz vna, float vnLiczba)
        {
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vna.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vna.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = vnLiczba / vna.vnmacierz[vni, vnj];
                }
            }
            return vnc;
        }



        public static Macierz operator *(Macierz vna, Macierz vnb)
        {
            if (vna.vnLiczbaWierzy != vnb.vnLiczbaWierzy ||
            vna.vnLiczbaKolumn != vnb.vnLiczbaKolumn)
                throw new ArgumentException("Zły rozmiar macierzy");
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vnb.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vnb.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = 0;
                    for (ushort vnk = 0; vnk < vnb.vnLiczbaWierzy; vnk++)
                    {
                        vnc.vnmacierz[vni, vnj] += vna.vnmacierz[vni, vnk] * vnb.vnmacierz[vnk, vnj];
                    }
                }

            }
            return vnc;
        }



        public static Macierz operator *(Macierz vna, float vnLiczba)
        {
            Macierz vnc = new Macierz(vna.vnLiczbaWierzy, vna.vnLiczbaKolumn);
            for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
            {
                for (ushort vnj = 0; vnj < vna.vnLiczbaKolumn; vnj++)
                {
                    vnc.vnmacierz[vni, vnj] = vnLiczba * vna.vnmacierz[vni, vnj];
                }
            }
            return vnc;
        }


        public static bool operator ==(Macierz vna, Macierz vnb)
        {
            if (vna.vnLiczbaWierzy == vnb.vnLiczbaWierzy &&
                vna.vnLiczbaKolumn == vnb.vnLiczbaKolumn)
            {
                for (ushort vni = 0; vni < vna.vnLiczbaWierzy; vni++)
                    for (ushort vnj = 0; vnj < vnb.vnLiczbaKolumn; vnj++)
                        if (vna.vnmacierz[vni, vnj] != vnb.vnmacierz[vni, vnj])
                            return false;
                return true;
            }
            else
                return false;

        }



        public static bool operator !=(Macierz vna, Macierz vnb)
        {
            return !(vna == vnb);
        }



        public override bool Equals(object vnobj)
        {
            //sparwdzenie parametru vnobj
            if ((vnobj is null) || (!(vnobj is Macierz)))
                return false;
            //pomocnicza deklaracja
            Macierz vnm = (Macierz)vnobj;
            //sprawdzenie danego elementu
            for (ushort vni = 0; vni < vnm.vnLiczbaWierzy; vni++)
                for (ushort vnj = 0; vnj < vnm.vnLiczbaKolumn; vnj++)
                    if (this.vnmacierz[vni, vnj] != vnm[vni, vnj])
                        return false;
            return true;
        }



        public override int GetHashCode()
        {
            return this.vnmacierz.GetHashCode();
        }



        //deklaracja operatora konwersji dla klasy Macierz
        public static explicit operator Macierz(float vnx)
        {
            Macierz vnc = new Macierz(1, 1);
            //wpisanie wartośći parametru x do macierzy c
            vnc.vnmacierz[0, 0] = vnx;
            //zwrócenie wyniku
            return vnc;
        }
    }

    
}
