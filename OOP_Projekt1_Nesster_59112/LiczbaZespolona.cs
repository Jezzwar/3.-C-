using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Projekt1_Nesster_59112
{
    class LiczbaZespolona
    {   
            // część rzeczywista liczby zespolonej  
            private double vnRE;
            // część urojona liczby zespolonej  
            private double vnIM;

        // pozostałe deklaracje klasy LiczzbaZespolona
            public LiczbaZespolona()
            {// domyślne ustawienie wartościa =częśśći rzeczywistej i urononej
                this.vnRE = 0.0; this.vnIM = 0.0;
            }
        // deklaracja konstruktora dwuargomentowego dtr LiczbyZespolonej
            public LiczbaZespolona(double vnRe, double vnIm)
            {
                this.vnRE = vnRe; this.vnIM = vnIm;
            }
        // deklaracja konstruktora jednoargumentowego str LZ z bezpośrednim  nadaniem wartości częśći rzeczywistej(re) i wartości liczby urojonej (im)
            public LiczbaZespolona(double vnRe)
            {
                this.vnRE = vnRe; this.vnIM = 0.0;
            }

            /*LiczbaZespolona vnZ1 = new LiczbaZespolona();
            LiczbaZespolona vnZ2 = new LiczbaZespolona(2.5, -1.6);
            LiczbaZespolona vnz3 = new LiczbaZespolona(-5.5);*/

        // deklaracja właśćiwości dla odczytywania  i zapisywania  prywatnych deklaracji  pól str LZ
            public double vnRe
            {
                set { vnRE = value; }
                get { return vnRE; }
            }
            public double vnIm
            {
                set { vnIM = value; }
                get { return vnIM; }

            }
            public double this[int vnI]
            {
                get
                {// sprawdzenie dozwolonej wartośći indeksu
                    if ((vnI < 0)||(vnI > 1))
                        throw new System.IndexOutOfRangeException
                            ("Error: wykroczenie indeksu poza zakres");
                    if (vnI == 0)
                        return vnRE;
                    else
                        return vnIM;
                }
                set
            {// sprawdzenie dozwolonej wartośći indeksu
                if ((vnI < 0)||(vnI > 1))
                        throw new System.IndexOutOfRangeException
                            ("Error: wykroczenie indeksu poza zakres");
                    if (vnI == 0)
                        vnRE = value;
                    else
                        vnIM = value;
                }

            }
        // preciążanie operatorów jednoargumentowych
            public static LiczbaZespolona operator +(LiczbaZespolona vnZ)
            { return vnZ; }
            public static LiczbaZespolona operator -(LiczbaZespolona vnZ)
            { return new LiczbaZespolona(-vnZ.vnRe, -vnZ.vnIm); }
            // operator ~ wyznaczający  liczbe szprężoną
            public static LiczbaZespolona operator ~(LiczbaZespolona vnZ)
            {  return new LiczbaZespolona(vnZ.vnRe, -vnZ.vnIm); }
            // operator ! wyznaczający moduł liczbe zespolonej
            public static double operator !(LiczbaZespolona vnZ)
            { return Math.Sqrt(vnZ.vnRe * vnZ.vnRe + vnZ.vnIm * vnZ.vnIm); }
        

            // przeciążanie operatorów dwuargomentowych
            public static LiczbaZespolona operator +(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
            { return new LiczbaZespolona((vnZ1.vnRe + vnZ2.vnRe), (vnZ1.vnIm + vnZ2.vnIm)); }
            public static LiczbaZespolona operator -(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
            { return new LiczbaZespolona((vnZ1.vnRe - vnZ2.vnRe), (vnZ1.vnIm - vnZ2.vnIm)); }
            public static LiczbaZespolona operator *(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
            { return new LiczbaZespolona((vnZ1.vnRe * vnZ2.vnRe) - (vnZ1.vnIm * vnZ2.vnIm), (vnZ1.vnRe * vnZ2.vnIm) + (vnZ2.vnRe * vnZ1.vnIm)); }
        public static LiczbaZespolona operator /(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
        {
            return new LiczbaZespolona((((vnZ1.vnRe * vnZ2.vnRe) - (vnZ1.vnIm * vnZ2.vnIm)) / ((vnZ2.vnRe * vnZ2.vnRe) + (vnZ2.vnIm * vnZ2.vnIm))),
           (((vnZ1.vnIm * vnZ2.vnRe) - (vnZ1.vnRe * vnZ2.vnIm)) / ((vnZ2.vnRe * vnZ2.vnRe) + (vnZ2.vnIm * vnZ2.vnIm))));
        }

        /// przeciążanie operatorów relacji
        /*public static bool operator ==(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
            { return vnZ1.vnRe == vnZ2.vnRe && vnZ1.vnIm == vnZ2.vnIm; }
            public static bool operator !=(LiczbaZespolona vnZ1, LiczbaZespolona vnZ2)
            { return !(vnZ1 == vnZ2); }*/


            public override bool Equals(object vnObj)
            {// porównanie stanu wskazanej w argumencie instancji objektu ze stanem obiektu bieżacego
                if (vnObj is null || !(vnObj is LiczbaZespolona))
                    return false;
                LiczbaZespolona vnZ = (LiczbaZespolona)vnObj; // rzutujemy parametr (argument) "obj"na typ LZ
                return this.vnRE == vnZ.vnRe && this.vnIM == vnZ.vnIm;
            //porównojemy wartości rzeczywiste i urojone, a gdy są one równe , to zwracana jest wartość true, a wartość false gde nie równe
            }


            public override int GetHashCode()
            { // generuje liczbu całkowitu, wartość której będzie zależałą od stanu obiektu, czyli od wartości jego pól
                return vnRE.GetHashCode() ^ vnIM.GetHashCode();
             // operator ^ zwraca 1, gdy są różne bity  na tych samych  pozycjach argumentu  lewego i praweogo
            }

            // definicja operatora konwersji  liczby rzeczywistej na zespoloną
            public static implicit operator LiczbaZespolona(double vnL)
            { return new LiczbaZespolona(vnL, 0.0); }

            // definicja operatora konwersji  liczby zespolonej na liczbę rzeczywistą
            public static explicit operator double(LiczbaZespolona vnZ)
            {
                if (vnZ.vnIm == 0.0)
                    return vnZ.vnRe;
                else
                    throw new Exception("ERROR: konwersja liczby zespolonej na" +
                                            "wartość double jest niemożliwa (gdyż część" +
                                            "urojona liczby zespolonej jest od zera");
            }
        

    }
}

