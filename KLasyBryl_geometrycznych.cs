using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OOP_Projekt3_Nester59112
{
    public class KlasyBrył_Geometrycznych
    {

        //deklaracja klasy abstrakcyjnej
        public abstract class BryłaAbstrakcyjna
        {
            //deklaracja klasy abstrakcyjnej
           
                protected float KątProsty = 90.0F;
                //deklaracja typu wyliczniewego, którego elemeny będą "znacznikami"
                //wpisanymi w egzemlarzy każdej bryły
                public enum TypyBrył
                {
                    BG_Walec,
                    BG_Kula,
                    BG_Ostrosłup,
                    BG_Graniastosłup,
                    BG_Sześcian,
                    BG_Stożek,
                    BG_StożekPochylony,
                    BG_StożekPodwójny
                };
                //deklaracja zmiennych dla wspólnych atrybutów geometrycznych
                protected int vnXsP, vnYsP;
                protected int vnWysokośćBryły;
                protected float vnKątPochylenia;
                //deklaracja zmiennych dla wspólnych atrybutów graficznych
                protected Color vnKolor_Linii;
                protected DashStyle vnStyl_Linii;
                protected int vnGrubość_Linii;
                //deklaracja zmiennych dla implementacji przyszłych funkcjonalności
                public TypyBrył RodzajBryły;
                protected bool vnKierunekObrotu; //false: w prawo, true: w lewo
                protected float PowierzchiaBryły;
                protected float ObjętnośćBryły;
                protected bool Widoczny;
                //deklaracja konstuktora
                public BryłaAbstrakcyjna(Color KolorLinii, DashStyle StylLinii, int GrubośćLinii, bool vnKierunekObrotu)
                {
                    this.vnKolor_Linii = KolorLinii;
                    this.vnStyl_Linii = StylLinii;
                    this.vnGrubość_Linii = GrubośćLinii;
                    this.vnKątPochylenia = KątProsty;
                    this.vnKierunekObrotu = vnKierunekObrotu;
                }
                //deklaracja metod abstakcyjnych 
                public abstract void Wykreśl(Graphics Rysownica);



                public abstract void Wymaż(Control Kontrolka, Graphics Rysownica);

                public abstract void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu);

                public abstract void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y);

                public void UstalAtrybutyGraficzne(Color KolorLinii, DashStyle StylLinii, int GrubośćLinii)
                {
                    this.vnKolor_Linii = KolorLinii;
                    this.vnStyl_Linii = StylLinii;
                    this.vnGrubość_Linii = GrubośćLinii;
                }

            }//od Klasy BryłaAbstrakcyjna
             //deklaracja klasy BryłyObrotowe
            public class BryłyObrotowe : BryłaAbstrakcyjna
            {
                protected int PromieńBryły;
                //deklaracja konstruktora
                public BryłyObrotowe(int R, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii, bool vnKierunekObrotu) :
                    base(KolorLinii, StylLinii, GrubośćLinii, vnKierunekObrotu)
                {
                    //zapisanie (przechowanie) promienia R
                    PromieńBryły = R;
                }
                //nadpisanie wszystkich metod abstrakcyjnych z klasy BryłaAbstrakcyjna
                public override void Wykreśl(Graphics Rysownica)
                {

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {

                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {

                }
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {

                }

            }//od BryłyObrotowe
             //deklaracja klasy potomnej Walec
            public class Walec : BryłyObrotowe
            {
                //deklaracja uzupełniająca dla bryły Walec
                Point[] WielokątPodłogi;
                Point[] WielokątSufitu;
                int XsS, YsS;
                //stopień wielokąta podstawy i sufitu Walca
                int StopieńWielokątaPodstawy;
                float Oś_Duża, Oś_Mała;
                //kąta środkowy między wierzchołkami wielokąta podstawy
                float KątMiędzyWierzchołkami;
                //kąt połozenie pierwszego wierzcołka wielokąta podstwy
                float KątPołożenie;
                //wektor przesunięcia środka sufitu pochylonego Walca
                int WektorPrzesunięciaSrodkaSufituWalca;
                //deklaracja konstuktora
                public Walec(int R, int WysokośćWalca, int StopieńWielokątaPodstawy,
                    int vnXsP, int vnYsP,/* int KątPochyleniaWalca,*/ Color KolorLinii, DashStyle StylLinii,
                    int GrubośćLinii, bool vnKierunekObrotu) : base(R, KolorLinii, StylLinii, GrubośćLinii, vnKierunekObrotu)
                {

                    this.vnXsP = vnXsP; this.vnYsP = vnYsP;
                    //ustawienie rodzaju bryły
                    RodzajBryły = TypyBrył.BG_Walec;
                    vnWysokośćBryły = WysokośćWalca;
                    this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
                    //wyznaczenie osi elipsy wykreślonej w podłodze i suficie Walca
                    Oś_Duża = 2 * PromieńBryły;//   2 * R
                    Oś_Mała = PromieńBryły / 2;//   R / 2
                                               //sprawdyenie kąta pochylenia Walca
                                               //if (KątPochyleniaWalca == KątProsty)
                                               //{
                                               //    XsS = vnXsP;
                                               //}
                                               //else
                                               //    MessageBox.Show("Sorry: Pracuje nad taką możliwością");
                    XsS = vnXsP;
                    YsS = vnYsP - WysokośćWalca;
                    //wyznaczenie pozostałych współrzędnych
                    //KątPochyleniaWalca = 360;
                    KątPołożenie = 0F;
                    //wyznaczenie współrzędnych punktów w podłoże i suficie walca dla wykreślienia
                    //prążków  na ścianie bocznej Walca
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                    WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];
                    //utworzenie egzemlarzy punktów w podłoże i suficie oraz wpisanie do
                    //nich wyznaczonych współrzędnych na obwodzie elipsy
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątSufitu[i] = new Point();

                        //podłoga
                        WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (vnKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (vnKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));

                        //sufit: Walca
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + KątMiędzyWierzchołkami) / 180F));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + KątMiędzyWierzchołkami) / 180F));

                    }
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        //ustalenie stylu linii
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie podłogi Walca
                        Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP - Oś_Mała / 2,
                            Oś_Duża, Oś_Mała);
                        //wykreślenie "sufitu" Walca
                        Rysownica.DrawEllipse(vnPióro, XsS - Oś_Duża / 2,
                            YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = vnStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    WielokątSufitu[i]);
                            }
                        }
                        //wykreślenie krawędzi bocznych Walca
                        Rysownica.DrawLine(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP, XsS - Oś_Duża / 2, YsS);
                        //wykreślenie prawej Krawędzi bocznej Walca
                        Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                            vnYsP, XsS + Oś_Duża / 2, YsS);
                        //odnotowanie
                        Widoczny = true;
                    }//koniec using i zwilnienie vnPióro

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                    {

                        //ustalenie stylu linii
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie podłogi Walca
                        Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP - Oś_Mała / 2,
                            Oś_Duża, Oś_Mała);
                        //wykreślenie "sufitu" Walca
                        Rysownica.DrawEllipse(vnPióro, XsS - Oś_Duża / 2,
                            YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = vnStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    WielokątSufitu[i]);
                            }
                        }
                        //wykreślenie krawędzi bocznych Walca
                        Rysownica.DrawLine(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP, XsS - Oś_Duża / 2, YsS);
                        //wykreślenie prawej Krawędzi bocznej Walca
                        Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                            vnYsP, XsS + Oś_Duża / 2, YsS);
                        //odnotowanie
                        Widoczny = true;




                        ////ustalenie stylu linii
                        //vnPióro.DashStyle = vnStyl_Linii;
                        ////wykreślenie podłogi Walca
                        //Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                        //    vnYsP - Oś_Mała / 2,
                        //    Oś_Duża, Oś_Mała);
                        ////wykreślenie "sufitu" Walca
                        //Rysownica.DrawEllipse(vnPióro, XsS - Oś_Duża / 2,
                        //    YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        ////wykreślenie krawędzi bocznych Walca
                        //Rysownica.DrawLine(vnPióro, vnXsP - Oś_Duża / 2,
                        //    vnYsP, XsS - Oś_Duża / 2, YsS);
                        ////wykreślenie prawej Krawędzi bocznej Walca
                        //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                        //    vnYsP, XsS + Oś_Duża / 2, YsS);
                        ////wykreślenie "prążków" na ścianie bocznej Walca
                        //for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        //{
                        //    Rysownica.DrawLine(vnPióro, WielokątPodłogi[i],
                        //        WielokątSufitu[i]);
                        //}

                        //Widoczny = false;
                    }
                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {

                    //wymazanie bryły Walca w aktualnym jej położeniu
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego położenie dla pierwszego wierzchołka wpisanego w "podłogę"
                        if (vnKierunekObrotu)
                        {
                            KątPołożenie -= vnKątObrotu;
                        }
                        else
                            KątPołożenie += vnKątObrotu;
                        //wyznaczenie nowych współrzędnych wierzchołków wielokąta "podłogi" oraz "sufitu"
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o vnKątObrotu
                            WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                        }
                        //wykreślenie
                        Wykreśl(Rysownica);
                    }

                }//Obróć i Wykreśl

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //deklaracja pomocnicze
                    int dX, dY;
                    //wymazanie bryły Walec w aktualnym położeniu
                    if (Widoczny)
                        Wymaż(Kontrolka, Rysownica);
                    //wyznaczenie przyrostów zmiana współrzędnej X oraz Y
                    dX = vnXsP < X ? X - vnXsP : -(vnXsP - X);
                    dY = vnYsP < Y ? Y - vnYsP : -(vnYsP - Y);

                    //ustalenie nowego położenia dla "środków" podłogi i sufitu
                    vnXsP = vnXsP + dX;
                    vnYsP = vnYsP + dY;
                    XsS = XsS + dX;
                    YsS = YsS + dY;
                    //wyznaczenie nowego położenia wierzchołków wielokąta podłogi i sufitu
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        //wierzchołki wielokąta  "podłogi"
                        WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));

                        WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));
                        //wierzchołkami wielokąta "sufitu" po obrócenie o vnKątObrotu
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                    }
                    //wykreślenie bryły Walec w nowym położeniu
                    Wykreśl(Rysownica);
                }


            }

            public class Stożek : BryłyObrotowe
            {
                protected int XsS;
                protected int YsS; //wierzchołek Stożka
                protected int StopieńWielokątaPodstawy;
                //osie elipsy
                protected float Oś_Duża, Oś_Mała;
                //kąt środowy między wierzchołkami wielokąta podstawy Stożka
                protected float KątMiędzyWierzchołkami;
                protected float KątPołożeniaPierwszegoWierzchołkamiWielokąta;
                //deklaracja zmiennej tablicowej dla przechowania referencji egzemplarzy wierzchołków wielokąta
                protected Point[] WielokątPodłogi;
                //protected bool vnKierunekObrotu;
                //deklaracja konstruktora

                public Stożek(int R, int WysokośćStożka, int StopieńWielokąta, int vnXsP, int vnYsP,
                    Color vnKolor_Linii, DashStyle vnStyl_Linii, float vnGrubość_Linii, bool vnKierunekObrotu) :
                    base(R, vnKolor_Linii, vnStyl_Linii, (int)vnGrubość_Linii, vnKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Stożek;
                    Widoczny = false;
                    //vnKierunekObrotu = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    vnWysokośćBryły = WysokośćStożka;
                    this.vnXsP = vnXsP;
                    this.vnYsP = vnYsP;
                    XsS = vnXsP; YsS = vnYsP - WysokośćStożka;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];


                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Stożka
                    // .  .  .
                    //obliczenie objętności Stożka
                    // .  .  .



                }//od konstruktora klasy Stożek


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Stożka
                        Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                        vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                        using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = vnStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    new Point(XsS, YsS));
                            }
                        }//koniec using, czyli zwolnienie PióroPrążków
                         //wykreślenie krawędzi bocznych Stożka
                         //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                         //    vnYsP, XsS, YsS);
                         //Rysownica.DrawLine(vnPióro, vnXsP - Oś_Duża / 2,
                         //    vnYsP, XsS, YsS);
                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        using (Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                        {
                            vnPióro.DashStyle = vnStyl_Linii;
                            //wykreślenie podstawy ("podłogi") Stożka
                            Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                            //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                            using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                            {
                                PióroPrążków.DashStyle = vnStyl_Linii;
                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                        new Point(XsS, YsS));
                                }
                            }//koniec using, czyli zwolnienie PióroPrążków
                             //wykreślenie krawędzi bocznych Stożka
                             //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                             //    vnYsP, XsS, YsS);
                             //Rysownica.DrawLine(vnPióro, vnXsP - Oś_Duża / 2,
                             //    vnYsP, XsS, YsS);
                            Widoczny = false;

                        }//koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {
                    if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (vnKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= vnKątObrotu;
                        }
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += vnKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //if (Widoczny)
                    {
                        int dX, dY;
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostu dX oraz dY przesunięcia Stożka
                        dX = vnXsP < X ? X - vnXsP : -(vnXsP - X);
                        dY = vnYsP < Y ? Y - vnYsP : -(vnYsP - Y);
                        //ustalenie nowej lokalizacji Stożka
                        vnXsP = vnXsP + dX;
                        vnYsP = vnYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }//od klasy Stożek

            public class StożekPochylony : Stożek
            {
                public StożekPochylony(int R, int WysokośćStożka, int StopieńWielokąta,
                    int vnXsP, int vnYsP, float KątPochyleniaStożka,
                    Color vnKolor_Linii, DashStyle vnStyl_Linii, float vnGrubość_Linii, bool vnKierunekObrotu)
                    : base(R, WysokośćStożka, StopieńWielokąta, vnXsP, vnYsP,
                         vnKolor_Linii, vnStyl_Linii, (int)vnGrubość_Linii, vnKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_StożekPochylony;
                    Widoczny = false;
                    // vnKierunekObrotu = false;

                    //wyznaczenie współrzędnych wierzchołka Stożka przesuniętego względem
                    //środka podłogi Stożka
                    XsS = vnXsP + (int)(WysokośćStożka / Math.Tan(Math.PI * KątPochyleniaStożka / 180F));
                    YsS = vnYsP - WysokośćStożka;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];


                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();

                        WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Stożka
                    // .  .  .
                    //obliczenie objętności Stożka
                    // .  .  .



                }//od konstruktora klasy Stożek


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Stożka
                        Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                        vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                        using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = vnStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    new Point(XsS, YsS));
                            }
                        }//koniec using, czyli zwolnienie PióroPrążków
                         //wykreślenie krawędzi bocznych Stożka
                         //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                         //    vnYsP, XsS, YsS);

                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    //if (Widoczny)
                    {
                        using (Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                        {
                            vnPióro.DashStyle = vnStyl_Linii;
                            //wykreślenie podstawy ("podłogi") Stożka
                            Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2,
                            vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                            //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                            using (Pen PióroPrążków = new Pen(vnPióro.Color, vnGrubość_Linii))
                            {
                                PióroPrążków.DashStyle = vnStyl_Linii;
                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                        new Point(XsS, YsS));
                                }
                            }//koniec using, czyli zwolnienie PióroPrążków
                             //wykreślenie krawędzi bocznych Stożka
                             //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                             //    vnYsP, XsS, YsS);

                            //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2, vnYsP, XsS, YsS);

                            Widoczny = false;

                        }//koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {
                    //if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (vnKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= vnKątObrotu;
                        }
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += vnKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    // if (Widoczny)
                    {
                        int dX, dY;
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostu dX oraz dY przesunięcia Stożka
                        dX = vnXsP < X ? X - vnXsP : -(vnXsP - X);
                        dY = vnYsP < Y ? Y - vnYsP : -(vnYsP - Y);
                        //ustalenie nowej lokalizacji Stożka
                        vnXsP = vnXsP + dX;
                        vnYsP = vnYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }

            public class StożekPodwójny : Stożek
            {

                public StożekPodwójny(int R, int WysokośćStożka, int StopieńWielokąta, int vnXsP, int vnYsP, Color KolorLinii, DashStyle StylLinii, int GruboscLinii, bool vnKierunekObrotu)
                    : base(R, WysokośćStożka, StopieńWielokąta, vnXsP, vnYsP, KolorLinii, StylLinii, GruboscLinii, vnKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_StożekPodwójny;
                    //Widoczny = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    vnWysokośćBryły = WysokośćStożka;
                    this.vnXsP = vnXsP;
                    this.vnYsP = vnYsP;

                    XsS = vnXsP; YsS = vnYsP - WysokośćStożka;

                    //os duza i mala
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;

                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;

                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];

                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();

                        //podloga Stozka
                        WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                    }

                    //obliczenia pola powierchni stozka
                    this.PowierzchiaBryły = (float)(Math.PI * (R * R) + (Math.PI * R * WysokośćStożka));
                    //obliczenie objetnosci
                    this.ObjętnośćBryły = (float)((Math.PI * (R * R) * WysokośćStożka) / 3);
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    using (Pen Pioro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        Pioro.DashStyle = vnStyl_Linii;

                        Rysownica.DrawEllipse(Pioro, vnXsP - Oś_Duża / 2, vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);

                        using (Pen PióroPrążków = new Pen(Pioro.Color, Pioro.Width / 2))
                        {
                            PióroPrążków.DashStyle = Pioro.DashStyle;

                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, vnYsP + vnWysokośćBryły));

                            }
                        }

                        //lewa gorna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, vnXsP - Oś_Duża / 2, vnYsP, XsS, YsS);
                        //prawa gorna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, vnXsP + Oś_Duża / 2, vnYsP, XsS, YsS);

                        //lewa dolna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, vnXsP - Oś_Duża / 2, vnYsP, XsS, vnYsP + vnWysokośćBryły);
                        //prawa dolna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, vnXsP + Oś_Duża / 2, vnYsP, XsS, vnYsP + vnWysokośćBryły);

                        Widoczny = true;
                    }
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        using (Pen Pioro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                        {
                            Pioro.DashStyle = vnStyl_Linii;

                            Rysownica.DrawEllipse(Pioro, vnXsP - Oś_Duża / 2, vnYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);

                            using (Pen PióroPrążków = new Pen(Pioro.Color, Pioro.Width / 2))
                            {
                                PióroPrążków.DashStyle = Pioro.DashStyle;

                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, vnYsP + vnWysokośćBryły));
                                }
                            }

                            //lewa krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, vnXsP - Oś_Duża / 2, vnYsP, XsS, YsS);
                            //prawa krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, vnXsP + Oś_Duża / 2, vnYsP, XsS, YsS);

                            //lewa dolna krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, vnXsP - Oś_Duża / 2, vnYsP, XsS, vnYsP + vnWysokośćBryły);
                            //prawa dolna krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, vnXsP + Oś_Duża / 2, vnYsP, XsS, vnYsP + vnWysokośćBryły);

                            Widoczny = false;
                        }
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KatObrotu)
                {
                    if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);

                        if (vnKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= KatObrotu;
                        }
                        else
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += KatObrotu;
                        }

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            //podloga Stozka
                            WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                            WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                        }

                        //wykreslenia stozka po obrocie
                        Wykreśl(Rysownica);
                    }
                }
            }







            public class Wielościany : BryłaAbstrakcyjna
            {
                //dodatkowe deklaracje zmiennych dla opisu wspólnych atrybutów dla Wielościanów
                protected Point[] WielokątPodłogi;//podstawy Wielościanu
                protected Point[] WielokątSufitu;//sufitu Wielościanu
                protected int XsS, YsS;//środek "sufitu" Wielościanu
                protected int StopieńWielokątaPodstawy;
                protected int PromieńPodstawyWielościanu;
                //deklaracja konstruktora
                public Wielościany(int R, int StopieńWielokąta,
                    Color KolorLinii, DashStyle StylLinii,
                                float GrubośćLinii, bool vnKierunekObrotu) : base(KolorLinii, StylLinii, (int)GrubośćLinii, vnKierunekObrotu)
                {
                    PromieńPodstawyWielościanu = R;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                }
                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {
                }

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                }

            }//od class Wielościan

            public class Graniastosłup : Wielościany
            {

                //deklaracja uzupewnienia dla klass 
                float Oś_Duża, Oś_Mała;
                //kąta środkowy między wierzchołkami wielokąta podstawy
                float KątMiędzyWierzchołkami;
                //kąt połozenie pierwszego wierzcołka wielokąta podstwy
                float KątPołożenie;
                //wektor przesunięcia środka sufitu pochylonego Walca
                int WektorPrzesunięciaSrodkaSufituWalca;
                //deklaracja konstuktora
                public Graniastosłup(int R, int WysokośćGraniastosłupa, int StopieńWielokątaPodstawy,
                    int vnXsP, int vnYsP, Color KolorLinii, DashStyle StylLinii,
                    int GrubośćLinii, bool vnKierunekObrotu) : base(R, StopieńWielokątaPodstawy, KolorLinii, StylLinii, GrubośćLinii, vnKierunekObrotu)
                {
                    //ustawienie rodzaju bryły
                    RodzajBryły = TypyBrył.BG_Graniastosłup;
                    vnWysokośćBryły = WysokośćGraniastosłupa;
                    this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;

                    this.vnXsP = vnXsP; this.vnYsP = vnYsP;

                    XsS = vnXsP;
                    YsS = vnYsP - WysokośćGraniastosłupa;
                    //wyznaczenie osi elipsy wykreślonej w podłodze i suficie Walca
                    Oś_Duża = 2 * R;//   2 * R
                    Oś_Mała = R / 2;//   R / 2
                                    //wyznaczenie kąta 
                    KątMiędzyWierzchołkami = 360 / StopieńWielokątaPodstawy;
                    //wyznaczenie pozostałych współrzędnych
                    KątPołożenie = 0F;
                    //wyznaczenie współrzędnych punktów w podłoże i suficie walca dla wykreślienia
                    //prążków  na ścianie bocznej Walca
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                    WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];
                    //wyznaczenie współrzędnych wierzchołka wielokąta wpisanego w elipsę "podłogi"
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątSufitu[i] = new Point();

                        //podłoga GraniaStosłupa
                        WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (vnKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (vnKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));


                        WielokątSufitu[i].X = WielokątPodłogi[i].X;
                        WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćGraniastosłupa;
                        //sufit: Walca
                        //WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                        //    (KątPołożenie + KątMiędzyWierzchołkami)) / 180F);
                        //WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Cos(Math.PI *
                        //    (KątPołożenie + KątMiędzyWierzchołkami)) / 180F);

                    }
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie "podłogi" Graniasłupa
                        for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                            Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);


                        for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                            Rysownica.DrawLine(vnPióro, WielokątSufitu[i], WielokątSufitu[i + 1]);

                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                            Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątSufitu[i]);


                        Widoczny = true;

                    }//koniec using i zwilnienie vnPióro

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        //utworzenie i sformatowanie Pióra
                        using (Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                        {
                            vnPióro.DashStyle = vnStyl_Linii;
                            //wykreślenie "podłogi" Graniasłupa
                            for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                                Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                            //wykreślenie "sufitu" Graniasłupa
                            for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                                Rysownica.DrawLine(vnPióro, WielokątSufitu[i], WielokątSufitu[i + 1]);

                            //krawędz
                            for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                                Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątSufitu[i]);

                            Widoczny = false;
                        }
                    }
                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {

                    //wymazanie bryły Graniastosłup w aktualnym jej położeniu
                    if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego położenie dla pierwszego wierzchołka wpisanego w "podłogę"
                        if (vnKierunekObrotu)
                        {
                            KątPołożenie -= vnKątObrotu;
                        }
                        else
                            KątPołożenie += vnKątObrotu;
                        //wyznaczenie nowych współrzędnych wierzchołków wielokąta "podłogi" oraz "sufitu"
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o vnKątObrotu
                            WielokątSufitu[i].X = WielokątPodłogi[i].X;
                            WielokątSufitu[i].Y = WielokątPodłogi[i].Y - vnWysokośćBryły;
                        }
                        //wykreślenie
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //deklaracja pomocnicze
                    int dX, dY;
                    //wymazanie bryły Walec w aktualnym położeniu
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostów zmiana współrzędnej X oraz Y
                        dX = vnXsP < X ? X - vnXsP : -(vnXsP - X);
                        dY = vnYsP < Y ? Y - vnYsP : -(vnYsP - Y);

                        //ustalenie nowego położenia dla "środków" podłogi i sufitu
                        vnXsP = vnXsP + dX;
                        vnYsP = vnYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowego położenia wierzchołków wielokąta podłogi i sufitu
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(vnXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o vnKątObrotu
                            WielokątSufitu[i].X = WielokątPodłogi[i].X;
                            WielokątSufitu[i].Y = WielokątPodłogi[i].Y - vnWysokośćBryły;
                        }
                        //wykreślenie bryły Graniastosłup w nowym położeniu
                        Wykreśl(Rysownica);
                    }
                }


            }//od GraniaStosłupa



            public class Ostrosłup : Wielościany
            {

                //osie elipsy
                protected int Oś_Duża, Oś_Mała;
                //kąt środowy między wierzchołkami wielokąta podstawy Stożka
                protected float KątMiędzyWierzchołkami;
                protected float KątPołożeniaPierwszegoWierzchołkamiWielokąta;

                //deklaracja konstruktora
                public Ostrosłup(int R, int WysokośćOstrosłupa, int StopieńWielokąta, int vnXsP, int vnYsP,
                    Color vnKolor_Linii, DashStyle vnStyl_Linii, float vnGrubość_Linii, bool vnKierunekObrotu) :
                    base(R, StopieńWielokąta, vnKolor_Linii, vnStyl_Linii, vnGrubość_Linii, vnKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Ostrosłup;
                    Widoczny = false;
                    //vnKierunekObrotu = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    vnWysokośćBryły = WysokośćOstrosłupa;
                    this.vnXsP = vnXsP;
                    this.vnYsP = vnYsP;
                    XsS = vnXsP; YsS = vnYsP - WysokośćOstrosłupa;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];


                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Ostrosłupa
                    // .  .  .
                    //obliczenie objętności Ostrosłupa
                    // .  .  .



                }//od konstruktora klasy Ostrosłupa


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii))
                    {
                        vnPióro.DashStyle = vnStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Ostrosłupa
                        for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                            Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Ostrosłupa

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            Rysownica.DrawLine(vnPióro, WielokątPodłogi[i],
                                new Point(XsS, YsS));

                        //koniec using, czyli zwolnienie PióroPrążków
                        //wykreślenie krawędzi bocznych Stożka
                        //Rysownica.DrawLine(vnPióro, vnXsP + Oś_Duża / 2,
                        //    vnYsP, XsS, YsS);

                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {

                        using (Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii))
                        {
                            vnPióro.DashStyle = vnStyl_Linii;
                            //wymazanie podstawy ("podłogi") Ostrosłupa
                            for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                                Rysownica.DrawLine(vnPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                            //wymazanie prążków (cienkich linii) na ścianie bocznej Ostrosłupa

                            for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                                Rysownica.DrawLine(vnPióro, WielokątPodłogi[i],
                                    new Point(XsS, YsS));

                            Widoczny = false;
                        }//koniec using, czyli zwolnienie Pióra

                        //koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {
                    if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (vnKierunekObrotu)
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= vnKątObrotu;
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += vnKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //ustawienie nowych współrzędnych
                        vnXsP = X; vnYsP = Y;
                        XsS = vnXsP; YsS = vnYsP - vnWysokośćBryły;

                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.vnXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.vnYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }//od klasy Ostrosłup


            public class Kula : BryłyObrotowe
            {
                float Oś_Duża, Oś_Mała;
                int PrzesunięcieObręczy;
                float KątPołożeniaObręczy;
                //konstruktor klasy Kula
                public Kula(int R, Point środekPodłogi, Color KolorLinii, DashStyle StylLinii,
                    float GrubośćLinii, bool vnKierunekObrotu) : base(R, KolorLinii, StylLinii, (int)GrubośćLinii, vnKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Kula;
                    Widoczny = false;
                    //vnKierunekObrotu = false;
                    vnXsP = środekPodłogi.X;
                    vnYsP = środekPodłogi.Y;
                    Oś_Duża = R * 2;
                    Oś_Mała = R / 2;
                    KątPołożeniaObręczy = 0;
                    PrzesunięcieObręczy = 0;
                    //obliczenie objętości i pola powierzchni kuli
                    //objętność Kuli = 4 / 3 * Pi * r^3

                    this.ObjętnośćBryły = 4 / 3 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2)
                        * (Oś_Duża / 2));
                    // pole Kuli = 4 * Pi * r^2
                    this.PowierzchiaBryły = 4 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2));
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    Pen vnPióro = new Pen(vnKolor_Linii, vnGrubość_Linii);
                    Pen PióroObręczy = new Pen(vnPióro.Color, vnGrubość_Linii);
                    PióroObręczy.DashStyle = vnStyl_Linii;
                    vnPióro.DashStyle = vnStyl_Linii;
                    //wykreślenie okręgu
                    Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP - Oś_Mała / 2,
                        Oś_Duża, Oś_Duża);
                    //wykreślenie przekroju (elipsy) kuli wzłuż jego średnicy poziomej
                    Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP + Oś_Mała, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie "obręczy" (która będzie obracana) pionowej
                    Rysownica.DrawEllipse(PióroObręczy, PrzesunięcieObręczy / 2 + vnXsP - Oś_Duża / 2,
                        vnYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    Widoczny = true;
                    //PióroObręczy.Dispose();
                    //vnPióro.Dispose();
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    Pen vnPióro = new Pen(Kontrolka.BackColor, vnGrubość_Linii);

                    Pen PióroObręczy = new Pen(vnPióro.Color, vnGrubość_Linii);
                    PióroObręczy.DashStyle = vnStyl_Linii;
                    vnPióro.DashStyle = vnStyl_Linii;
                    //wykreślenie okręgu
                    Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP - Oś_Mała / 2,
                        Oś_Duża, Oś_Duża);
                    //wykreślenie przekroju (elipsy) kuli wzłuż jego średnicy poziomej
                    Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP + Oś_Mała, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie "obręczy" (która będzie obracana) pionowej
                    Rysownica.DrawEllipse(PióroObręczy, PrzesunięcieObręczy / 2 + vnXsP - Oś_Duża / 2,
                        vnYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    Widoczny = false;

                    //PióroObręczy.Dispose();
                    //vnPióro.Dispose();




                    //vnPióro.DashStyle = vnStyl_Linii;

                    //Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP - Oś_Mała / 2,
                    //    Oś_Duża, Oś_Duża);
                    //Rysownica.DrawEllipse(vnPióro, vnXsP - Oś_Duża / 2, vnYsP + Oś_Mała,
                    //    Oś_Duża, Oś_Mała);
                    //Rysownica.DrawEllipse(vnPióro, PrzesunięcieObręczy / 2 + vnXsP - Oś_Duża / 2,
                    //    vnYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    //Widoczny = false;
                    //vnPióro.Dispose();
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float vnKątObrotu)
                {
                    KątPołożeniaObręczy = (KątPołożeniaObręczy + vnKątObrotu) % 360;

                    Wymaż(Kontrolka, Rysownica);
                    PrzesunięcieObręczy = (int)(KątPołożeniaObręczy % (int)(Oś_Duża)) * 2;
                    Wykreśl(Rysownica);
                }

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    Wymaż(Kontrolka, Rysownica);
                    vnXsP = X;
                    vnYsP = Y;
                    Wykreśl(Rysownica);
                }
            }

       /* public class OstroslupPodwojny : Ostrosłup
        {
            public OstroslupPodwojny(int R, int vnWysokoscOstroslupa, int vnStopienWielokata, int vnXsP, int vnYsP, Color vnKolorLinii, DashStyle vnStylLinii, int vnGruboscLinii)
                : base(R, vnWysokoscOstroslupa, vnStopienWielokata, vnXsP, vnYsP, vnKolorLinii, vnStylLinii, vnGruboscLinii)
            {
                vnRodzajBryly = TypBryły.BG_StozekPodwojny;
                Widoczny = false;
                vnKierunekObrotu = false;
                vnWysokoscBryly = vnWysokoscOstroslupa;
                vStopienWielokataPodstawy = vnStopienWielokata;
                this.vnXsP = vnXsP; this.vnYsP =vn YsP;

                //wyznaczeniewspolzednych wierzcholka Ostroslupa
                XsS = XsP; YsS = YsP - dyWysokoscOstroslupa;

                Os_duza = 2 * R;
                Os_mala = R / 2;
                dyKatPolozeniaPierwszegoWierchowka = 0F;
                dyKatSrodkowyMiedzyWierchowkami = 360 / dyStopienWielokata;
                dyWielokatPodlogi = new Point[dyStopienWielokataPodstawy + 1];
            }

            public override void Wykreśl(Graphics dyPowierchniaGraficzna)
            {
                using (Pen Pioro = new Pen(vnKolorLinii, vnGruboscLinii))
                {
                    Pioro.DashStyle = vnStylLinii;

                    //wykreslenie podwogi
                    for (int i = 0; i < dyWielokatPodlogi.Length - 1; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], dyWielokatPodlogi[i + 1]);
                    }

                    //wykresleni krawedzi bocznych
                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsS));
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsP + dyWysokoscBryly));
                    }

                    dyWidoczny = true;
                }
            }

            public override void dyWymaz(Control dyKontrolka, Graphics dyPowierchniaGraficzna)
            {
                using (Pen Pioro = new Pen(dyKontrolka.BackColor, dyGruboscLinii))
                {
                    Pioro.DashStyle = dyStylLinii;

                    //wykreslenie podwogi
                    for (int i = 0; i < dyWielokatPodlogi.Length - 1; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], dyWielokatPodlogi[i + 1]);
                    }

                    //wykresleni krawedzi bocznych
                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsS));
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsP + dyWysokoscBryly));
                    }

                    Widoczny = true;
                }
            }

            public override void dyObroc_i_Wykresl(Control dyKontrolka, Graphics dyPowierchniaGraficzna, float dyKatObrotu, bool dyKierunekObrotu)
            {
                if (Widoczny)
                {
                    dyWymaz(dyKontrolka, dyPowierchniaGraficzna);

                    if (dyKierunekObrotu)
                    {
                        dyKatPolozeniaPierwszegoWierchowka -= dyKatObrotu;
                    }
                    else
                    {
                        dyKatPolozeniaPierwszegoWierchowka += dyKatObrotu;
                    }

                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyWielokatPodlogi[i].X = (int)(XsP + Os_duza / 2 * Math.Cos(Math.PI * (dyKatPolozeniaPierwszegoWierchowka + i * dyKatSrodkowyMiedzyWierchowkami) / 180));
                        dyWielokatPodlogi[i].Y = (int)(YsP + Os_mala / 2 * Math.Sin(Math.PI * (dyKatPolozeniaPierwszegoWierchowka + i * dyKatSrodkowyMiedzyWierchowkami) / 180));
                    }

                    dyWykresl(dyPowierchniaGraficzna);
                }
            }
        }*/
    }
    }

