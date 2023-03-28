using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Projekt1_Nesster_59112
{

  

    public partial class Form_Projekt1 : Form
    {
        

        /* deklaracja tablicy zezwoleń otwarcia
        * stron kontenera TabControl */
        bool[] vnStanStron = { true, false, false };

        // pomocnicze deklaracje stałych
        const int vnOdstęp = 60;
        const ushort vnSzerokośćKolumny = 65; // kontrolki DGV
        const ushort vnWysokośćWiersza = 20; // kontrolki DGV
        const int vnDolnaGranicaPrzedziału = 10;
        const int vnGórnaGgranicaPrzedziału = 100;
        const double vnDolnaGranicaPrzedziałuDouble = 200.0;
        const double vnGórnaGgranicaPrzedziałuDouble = 800.0;

        // deklaracja pomoccnicza tablicy zezwoleń na otwarcie stron zakładki TabControl

        // deklaracje opisujące rozmiar Macierzy
        // deklaracja macierzy
        Macierz vnA;
        Macierz vnB;
        Macierz vnC;

        // deklaracje zmiennych referycyjnych do egzemplarzy kontrolek, ktorę
        // zostaną dodane do 1 strony Zakładki podczas działania programu 
        DataGridView dgvMacierzA;
        DataGridView dgvMacierzB;
        DataGridView dgvMacierzC;

        // utworzenie liczb zespolonych
        LiczbaZespolona vnZ1;
        LiczbaZespolona vnZ2;
        LiczbaZespolona vnZ3;

        // deklaracje zmiennych referycyjnych do egzemplarzy kontrolek, ktorę
        // zostaną dodane do 1 strony Zakładki podczas działania programu 

        public Form_Projekt1()
        {
            InitializeComponent();
        }

        private void tabPageKokpit_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonMacierze_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście od strony Kokpit kontenera TabControl,
            * gdyż ma nastąpic przejście do innej strony
            */
            vnStanStron[0] = false;
            // zezwolenie ns przejście do strony działania na Macierzach
            vnStanStron[1] = true;
            // realizacja prejścia do strony działania na Macierzach
            tabControlMenu.SelectedTab = tabPageMacierze;
        }

        private void buttonLiczbyZespolone_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście od strony Kokpit kontenera TabControl,
           * gdyż ma nastąpic przejście do innej strony
           */
            vnStanStron[0] = false;
            // zezwolenie ns przejście do strony liczb zespolonych
            vnStanStron[2] = true;
            // realizacja prejścia do strony liczb zespolonych
            tabControlMenu.SelectedTab = tabPageLiczbyZespolone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście od strony Kokpit kontenera TabControl,
         * gdyż ma nastąpic przejście do innej strony
         */
            vnStanStron[2] = false;
            // zezwolenie ns przejście do strony liczb zespolonych
            vnStanStron[0] = true;
            // realizacja prejścia do strony liczb zespolonych
            tabControlMenu.SelectedTab = tabPageKokpit;
        }

        private void buttonPowrót_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście od strony Kokpit kontenera TabControl,
         * gdyż ma nastąpic przejście do innej strony
         */
            vnStanStron[1] = false;
            // zezwolenie ns przejście do strony liczb zespolonych
            vnStanStron[0] = true;
            // realizacja prejścia do strony liczb zespolonych
            tabControlMenu.SelectedTab= tabPageKokpit;
        }


        private void tabControlMenu_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
                // indentyfikacja wybranej strony kontenera TabControl
                if (e.TabPage == tabControlMenu.TabPages[0]) // czy to jest strona Kokpit?
                    if (vnStanStron[0]) // sprawdzmy czy jest zezwolenie na jej otwarcie
                    {
                        e.Cancel = false; // jest zezwolenie, czyli przejście do niej nie może być skasowane
                        tabControlMenu.SelectedTab = tabPageKokpit; // odsłonięcie strony Kokpit

                    }

                    else
                        e.Cancel = true; // nie ma zezwolenie, czyli przejście do niej musi być skasowane


            else
                if (e.TabPage == tabControlMenu.TabPages[1]) // czy to jest strona Macierze?
                    if (vnStanStron[1]) // sprawdzmy czy jest zezwolenie na jej otwarcie
                    {
                        e.Cancel = false; // jest zezwolenie, czyli przejście do niej nie może być skasowane
                        tabControlMenu.SelectedTab = tabPageMacierze; // odsłonięcie strony Macierze

                    }

                    else
                        e.Cancel = true; // nie ma zezwolenie, czyli przejście do niej musi być skasowane


           else
              if (e.TabPage == tabControlMenu.TabPages[2])  // czy to jest strona Liczb Zespolonych?
                if (vnStanStron[2]) // sprawdzmy czy jest zezwolenie na jej otwarcie
                {
                    e.Cancel = false; // jest zezwolenie, czyli przejście do niej nie może być skasowane
                    tabControlMenu.SelectedTab = tabPageLiczbyZespolone; // odsłonięcie strony Liczb Zespolonych

                }

                else
                    e.Cancel = true; // nie ma zezwolenie, czyli przejście do niej musi być skasowane



            
        }

        private void labelPrzeciązanie_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }
            dgvMacierzA = new DataGridView();
            dgvMacierzA.Location = new Point(groupBox1.Location.X + groupBox1.Width + vnOdstęp, buttonPowrót.Top);
            dgvMacierzA.Size = new Size((LiczbaKolumnMacierzy + 1) * vnSzerokośćKolumny, (LiczbaWierszyMacierzy + 1) * vnWysokośćWiersza);
            dgvMacierzA.ColumnCount = LiczbaKolumnMacierzy;
            dgvMacierzA.ColumnHeadersVisible = true;
            dgvMacierzA.ReadOnly = false;
            dgvMacierzA.AllowUserToAddRows = false;
            dgvMacierzA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMacierzA.MultiSelect = false;
            DataGridViewCellStyle StylHeaderKolumny = new DataGridViewCellStyle();
            StylHeaderKolumny.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderKolumny.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StylHeaderKolumny.Format = "  ";
            dgvMacierzA.ColumnHeadersDefaultCellStyle = StylHeaderKolumny;
            DataGridViewCellStyle StylHeaderWiersza = new DataGridViewCellStyle();
            StylHeaderWiersza.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderWiersza.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMacierzA.RowHeadersDefaultCellStyle = StylHeaderWiersza;
            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
            {

                dgvMacierzA.Columns[i].HeaderText = "(" + i + ")";
                dgvMacierzA.Columns[i].Width = vnSzerokośćKolumny;
                dgvMacierzA.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            for (ushort i = 0; i < LiczbaWierszyMacierzy; i++)
                dgvMacierzA.Rows.Add();

            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
                dgvMacierzA.Rows[i].HeaderCell.Value = "(" + i + ")";
            tabControlMenu.TabPages[1].Controls.Add(dgvMacierzA);
            dgvMacierzA.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvMacierzA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ustawienie stanu Enabled
            buttonUtwMacierzyA.Enabled = false;
            buttonGeneracjaElMacierzyA.Enabled = true;
            buttonAkceptujWarościMacA.Enabled = true;
            buttonUtwMacierzyB.Enabled = true;
            dgvMacierzA.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKolumny_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;

            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }
            
            //ERROR
            errorProvider1.Dispose();
                for (ushort i = 0; i < dgvMacierzB.Rows.Count; i++)
                    for (ushort j = 0; j < dgvMacierzB.Columns.Count; j++)
                        if (dgvMacierzA.Rows[i].Cells[j].Value is null)
                        {
                            MessageBox.Show("dgvMacierzA.Rows[i].Cells[j].Value is null");
                            errorProvider1.SetError(buttonAkceptujWarościMacB, "Error: wszystkie komórki kontrolki DataGridView dla" +
                                "macierz A muszą być wypełnione wartościami jej elementów");
                            return;
                        }
                dgvMacierzB.ReadOnly = true;
                dgvMacierzB.Enabled = false;
                buttonAkceptujWarościMacB.Enabled = false;

            // zadania rozmiarów macierzy
            vnB = new Macierz((ushort)dgvMacierzB.Rows.Count, (ushort)dgvMacierzB.Columns.Count);

            // przepisanie elementów macierzy
            vnB.PrzepiszElementyDataGridViewDoMAcierzy(dgvMacierzB);


            // udtawienie stanu Enabled true
            buttonRóznicaBiA.Enabled = true;
            buttonDzielenieAiB.Enabled = true;
            buttonDobAiB.Enabled = true;
            buttonRóżnicaAiB.Enabled = true;
            buttonSumaAiB.Enabled = true;
        }



        private void groupBoxWierzyKolumny_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.FromArgb(25, Color.Black);
        }


        private void buttonGeneracjaElMacierzyA_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;

            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }

            Random rnd = new Random();
                for (ushort i = 0; i < dgvMacierzA.Rows.Count; i++)
                    for (ushort j = 0; j < dgvMacierzA.Columns.Count; j++)
                        dgvMacierzA.Rows[i].Cells[j].Value = rnd.Next(vnDolnaGranicaPrzedziału, vnGórnaGgranicaPrzedziału);
            buttonGeneracjaElMacierzyA.Enabled = false;
            
        }

        private void buttonAkceptujWarościMacA_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;

            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }


            errorProvider1.Dispose();
                for (ushort i = 0; i < dgvMacierzA.Rows.Count; i++)
                    for (ushort j = 0; j < dgvMacierzA.Columns.Count; j++)
                        if (dgvMacierzA.Rows[i].Cells[j].Value is null)
                        {
                            MessageBox.Show("Wpisz znaczenia w macierz !");
                            errorProvider1.SetError(buttonAkceptujWarościMacA, "Error: wszystkie komórki kontrolki DataGridView dla" +
                                "macierz A muszą być wypełnione wartościami jej elementów");
                            return;
                        }

                dgvMacierzA.ReadOnly = true;
                dgvMacierzA.Enabled = false;
                buttonAkceptujWarościMacA.Enabled = false;

            // zadania rozmiarów
            vnA = new Macierz((ushort)dgvMacierzA.Rows.Count, (ushort)dgvMacierzA.Columns.Count);

            // przepisanie elementów
            vnA.PrzepiszElementyDataGridViewDoMAcierzy(dgvMacierzA);


        }

        private void buttonUtwMacierzyB_Click(object sender, EventArgs e)
        {
           


            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }
            dgvMacierzB = new DataGridView();
            dgvMacierzB.Location = new Point(groupBox1.Location.X + groupBox1.Width + vnOdstęp, buttonAkceptujWarościMacA.Location.Y);
            dgvMacierzB.Size = new Size((LiczbaKolumnMacierzy + 1) * vnSzerokośćKolumny, (LiczbaWierszyMacierzy + 1) * vnWysokośćWiersza);
            dgvMacierzB.ColumnCount = LiczbaKolumnMacierzy;
            dgvMacierzB.ColumnHeadersVisible = true;
            dgvMacierzB.ReadOnly = false;
            dgvMacierzB.AllowUserToAddRows = false;
            dgvMacierzB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMacierzB.MultiSelect = false;
            DataGridViewCellStyle StylHeaderKolumny = new DataGridViewCellStyle();
            StylHeaderKolumny.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderKolumny.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StylHeaderKolumny.Format = "  ";
            dgvMacierzB.ColumnHeadersDefaultCellStyle = StylHeaderKolumny;
            DataGridViewCellStyle StylHeaderWiersza = new DataGridViewCellStyle();
            StylHeaderWiersza.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderWiersza.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMacierzA.RowHeadersDefaultCellStyle = StylHeaderWiersza;
            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
            {

                dgvMacierzB.Columns[i].HeaderText = "(" + i + ")";
                dgvMacierzB.Columns[i].Width = vnSzerokośćKolumny;
                dgvMacierzB.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            for (ushort i = 0; i < LiczbaWierszyMacierzy; i++)
                dgvMacierzB.Rows.Add();

            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
                dgvMacierzB.Rows[i].HeaderCell.Value = "(" + i + ")";
            tabControlMenu.TabPages[1].Controls.Add(dgvMacierzB);
            dgvMacierzB.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvMacierzB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ustawienie stanu enablaed
            buttonUtwMacierzyB.Enabled = false;
            buttonGeneracjaElMacierzyB.Enabled = true;
            buttonAkceptujWarościMacB.Enabled = true;
            buttonUtwMacierzyB.Enabled = false;

            dgvMacierzB.Visible = true;
        }

        private void buttonGeneracjaElMacierzyB_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;

            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }

            Random rnd = new Random();
                for (ushort i = 0; i < dgvMacierzB.Rows.Count; i++)
                    for (ushort j = 0; j < dgvMacierzB.Columns.Count; j++)
                        dgvMacierzB.Rows[i].Cells[j].Value = rnd.Next(vnDolnaGranicaPrzedziału, vnGórnaGgranicaPrzedziału);
            buttonGeneracjaElMacierzyB.Enabled = false;
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void buttonSumaAiB_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wpisz ilość kolumn i wierzów");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wwpisz ilość kolumn i wierzów");
                return;

            }

            if (vnC is null)
            {
                UtwC();
            }

            

            vnC = new Macierz((ushort)dgvMacierzC.Rows.Count, (ushort)dgvMacierzC.Columns.Count);

            vnC = vnA + vnB;

            vnC.PrzepiszElementyMacierzyDoKontrolkiDataGridView(dgvMacierzC);

            // ustawienie stanu visible
            dgvMacierzC.Visible = true;
            



        }

        private void buttonRóżnicaAiB_Click(object sender, EventArgs e)
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wpisz ilość kolumn i wierzów");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wwpisz ilość kolumn i wierzów");
                return;

            }


            if (vnC is null)
            {
                UtwC();
            }



            vnC = new Macierz((ushort)dgvMacierzC.Rows.Count, (ushort)dgvMacierzC.Columns.Count);

            vnC = vnA - vnB;

            vnC.PrzepiszElementyMacierzyDoKontrolkiDataGridView(dgvMacierzC);

            // ustawienie stanu visible
            dgvMacierzC.Visible = true;
        }


        void UtwC()
        {
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wystąpił niedozwolony znak w zapisie liczby wierszy macierzy");
                return;

            }
            dgvMacierzC = new DataGridView();
            dgvMacierzC.Location = new Point(groupBox1.Location.X + groupBox1.Width + vnOdstęp, buttonGeneracjaElMacierzyB.Location.Y);
            dgvMacierzC.Size = new Size((LiczbaKolumnMacierzy + 1) * vnSzerokośćKolumny, (LiczbaWierszyMacierzy + 1) * vnWysokośćWiersza);
            dgvMacierzC.ColumnCount = LiczbaKolumnMacierzy;
            dgvMacierzC.ColumnHeadersVisible = true;
            dgvMacierzC.ReadOnly = false;
            dgvMacierzC.AllowUserToAddRows = false;
            dgvMacierzC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMacierzC.MultiSelect = false;
            DataGridViewCellStyle StylHeaderKolumny = new DataGridViewCellStyle();
            StylHeaderKolumny.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderKolumny.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StylHeaderKolumny.Format = "  ";
            dgvMacierzB.ColumnHeadersDefaultCellStyle = StylHeaderKolumny;
            DataGridViewCellStyle StylHeaderWiersza = new DataGridViewCellStyle();
            StylHeaderWiersza.Font = new Font("Arial", 10, FontStyle.Bold);
            StylHeaderWiersza.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMacierzC.RowHeadersDefaultCellStyle = StylHeaderWiersza;
            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
            {

                dgvMacierzC.Columns[i].HeaderText = "(" + i + ")";
                dgvMacierzC.Columns[i].Width = vnSzerokośćKolumny;
                dgvMacierzC.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            for (ushort i = 0; i < LiczbaWierszyMacierzy; i++)
                dgvMacierzC.Rows.Add();

            for (ushort i = 0; i < LiczbaKolumnMacierzy; i++)
                dgvMacierzC.Rows[i].HeaderCell.Value = "(" + i + ")";
            tabControlMenu.TabPages[1].Controls.Add(dgvMacierzC);
            dgvMacierzC.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvMacierzC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void buttonDobAiB_Click(object sender, EventArgs e)
        {


            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wpisz ilość kolumn i wierzów");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wwpisz ilość kolumn i wierzów");
                return;

            }

            if (vnC is null)
            {
                UtwC();
            }



            vnC = new Macierz((ushort)dgvMacierzC.Rows.Count, (ushort)dgvMacierzC.Columns.Count);

            vnC = vnA * vnB;

            vnC.PrzepiszElementyMacierzyDoKontrolkiDataGridView(dgvMacierzC);


            // ustawienie stanu visible
            dgvMacierzC.Visible = true;
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wpisz ilość kolumn i wierzów");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wwpisz ilość kolumn i wierzów");
                return;

            }

            if (vnC is null)
            {
                UtwC();
            }



            vnC = new Macierz((ushort)dgvMacierzC.Rows.Count, (ushort)dgvMacierzC.Columns.Count);

            vnC = vnA / vnB;

            vnC.PrzepiszElementyMacierzyDoKontrolkiDataGridView(dgvMacierzC);

            // ustawienie stanu visible
            dgvMacierzC.Visible = true;
        }

        private void buttonRóznicaBiA_Click(object sender, EventArgs e)
        {


            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(textBoxWierzy,
                    "Error: wpisz ilość kolumn i wierzów");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(textBoxKolumny,
                    "Error: wwpisz ilość kolumn i wierzów");
                return;

            }

            if (vnC is null)
            {
                UtwC();
            }



            vnC = new Macierz((ushort)dgvMacierzC.Rows.Count, (ushort)dgvMacierzC.Columns.Count);

            vnC = vnB - vnA;

            vnC.PrzepiszElementyMacierzyDoKontrolkiDataGridView(dgvMacierzC);

            // ustawienie stanu visible
            dgvMacierzC.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPageMacierze_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // ErrorProvider
            ushort LiczbaWierszyMacierzy;
            ushort LiczbaKolumnMacierzy;
            errorProvider1.Dispose();
            if (!ushort.TryParse(textBoxWierzy.Text, out LiczbaWierszyMacierzy))
            {
                errorProvider1.SetError(buttonReset,
                    "Error: forma jest pusta");
                return;
            }
            if (!ushort.TryParse(textBoxKolumny.Text, out LiczbaKolumnMacierzy))
            {
                errorProvider1.SetError(buttonReset,
                    "Error: forma jest pusta");
                return;

            }

            // aktywacja stanu Enable
            buttonUtwMacierzyA.Enabled = true;
            buttonGeneracjaElMacierzyA.Enabled = true;
            buttonAkceptujWarościMacA.Enabled = true;
            buttonUtwMacierzyB.Enabled = true;
            buttonGeneracjaElMacierzyB.Enabled = true;
            buttonAkceptujWarościMacB.Enabled = true;

            // zgaszenie ErrorProvider1
            errorProvider1.Dispose();

            // oczyszczenie textBox
            textBoxKolumny.Text = "";
            textBoxWierzy.Text = "";

            // ustawienie stanu unvisible
            dgvMacierzA.Visible = false;
            dgvMacierzB.Visible = false;
            dgvMacierzC.Visible = false;

            // udtawienie stanu Enabled false
            buttonRóznicaBiA.Enabled = false;
            buttonDzielenieAiB.Enabled = false;
            buttonDobAiB.Enabled = false;
            buttonRóżnicaAiB.Enabled = false;
            buttonSumaAiB.Enabled = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelRzeczywista_Click(object sender, EventArgs e)
        {

        }

        private void tabPageLiczbyZespolone_Click(object sender, EventArgs e)
        {

        }

        bool vnDaneWejśćioweLiczby(out double vnRe1, out double vnRe2, out double vnIm1, out double vnIm2)
        {
            errorProvider2.Dispose();

            vnRe1 = vnIm1 = vnRe2 = vnIm2 = 0.0;
            if (!double.TryParse(textBoxLiczba1Rzeczywista.Text, out vnRe1))
            {
                if (vnRe1 != 0.0)
                {
                    errorProvider2.SetError(textBoxLiczba1Rzeczywista, "ERROR: w zapisie wartości Re wystąpił niedozwolony znak");
                    return false;
                }
            }
            else
                errorProvider2.Dispose();
            if (!double.TryParse(textBoxLiczba1Urojona.Text, out vnIm1))
            {
                if (vnIm1 != 0.0)
                {
                    errorProvider2.SetError(textBoxLiczba1Urojona, "ERROR: w zapisie wartości Im wystąpił niedozwolony znak");
                    return false;
                }
            }
            else
                errorProvider2.Dispose();
            if (!double.TryParse(textBoxLiczba2Rzeczywista.Text, out vnRe2))
            {
                if (vnRe2 != 0.0)
                {
                    errorProvider2.SetError(textBoxLiczba2Rzeczywista, "ERROR: w zapisie wartości Re wystąpił niedozwolony znak");
                    return false;
                }
            }
            else
                errorProvider2.Dispose();
            if (!double.TryParse(textBoxLiczba2Urojona.Text, out vnIm2))
            {
                if (vnIm2 != 0.0)
                {
                    errorProvider2.SetError(textBoxLiczba2Urojona, "ERROR: w zapisie wartości Im wystąpił niedozwolony znak");
                    return false;
                }
            }
            else
                errorProvider2.Dispose();
            textBoxLiczba2Rzeczywista.ReadOnly = true;
            textBoxLiczba2Urojona.ReadOnly = true;
            textBoxLiczba1Rzeczywista.ReadOnly = true;
            textBoxLiczba1Urojona.ReadOnly = true;
            return true;
        }

        private void buttonDodawanie_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ2 = new LiczbaZespolona(vnRe2, vnIm2);
            vnZ3 = vnZ1 + vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonDodawanie.Enabled = false;
        }

        private void buttonOdejmowanie_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ2 = new LiczbaZespolona(vnRe2, vnIm2);
            vnZ3 = vnZ1 - vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonOdejmowanie.Enabled = false;
        }

        private void buttonMnożenie_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ2 = new LiczbaZespolona(vnRe2, vnIm2);
            vnZ3 = vnZ1 * vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonMnożenie.Enabled = false;
        }

        private void buttonDżielenie_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ2 = new LiczbaZespolona(vnRe2, vnIm2);
            vnZ3 = vnZ1 / vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonDżielenie.Enabled = false;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2, vnLiczba;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnLiczba = !vnZ1;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnLiczba);
            textBoxWynikUrojona.Text = "";
            buttonmodulZ1.Enabled = false;
        }

        private void buttonModulZ2_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2, vnLiczba;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ2 = new LiczbaZespolona(vnRe1, vnIm1);
            vnLiczba = !vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnLiczba);
            textBoxWynikUrojona.Text = "";
            buttonModulZ2.Enabled = false;
        }

        private void buttonSprzZ1_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ3 = ~vnZ1;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonSprzZ1.Enabled = false;
        }

        private void buttonSprzZ2_Click(object sender, EventArgs e)
        {
            double vnRe1, vnIm1, vnRe2, vnIm2;
            vnDaneWejśćioweLiczby(out vnRe1, out vnRe2, out vnIm1, out vnIm2);
            vnZ1 = new LiczbaZespolona(vnRe1, vnIm1);
            vnZ3 = ~vnZ2;
            textBoxWynikRzeczywista.Text = Convert.ToString(vnZ3.vnRe);
            textBoxWynikUrojona.Text = Convert.ToString(vnZ3.vnIm);
            buttonSprzZ2.Enabled = false;
        }

        private void buttonResetuj_Click(object sender, EventArgs e)
        {
            // ustawienie stanu enabled true
            buttonDodawanie.Enabled = true;
            buttonDżielenie.Enabled = true;
            buttonmodulZ1.Enabled = true;
            buttonModulZ2.Enabled = true;
            buttonSprzZ1.Enabled = true;
            buttonSprzZ2.Enabled = true;
            buttonMnożenie.Enabled = true;
            buttonOdejmowanie.Enabled = true;

            // ustawienie zerowego TextBox
            textBoxLiczba1Urojona.Text = "";
            textBoxLiczba1Rzeczywista.Text = "";
            textBoxLiczba2Urojona.Text = "";
            textBoxLiczba2Rzeczywista.Text = "";
            textBoxWynikUrojona.Text = "";
            textBoxWynikRzeczywista.Text = "";




        }
    }



    //deklaracja klasy pomocniczej, która roszerzy właściwości klasy Macierz
    static class RoszerzenieWłaśćiwościKlasyMacierz
    {
        public static void PrzepiszElementyDataGridViewDoMAcierzy(this Macierz vnX,
            DataGridView vndgvMacierzX)
        {
            //pobieranie wartości elementów z kontrolki DataGridView i jej wpisanie do macierzy X
            for (ushort vni = 0; vni < vnX.vnLiczbaWierzy; vni++)
                for (ushort vnj = 0; vnj < vnX.vnLiczbaKolumn; vnj++)
                    vnX[vni, vnj] = float.Parse((vndgvMacierzX.Rows[vni].Cells[vnj].Value.ToString()));
        }

        public static void PrzepiszElementyMacierzyDoKontrolkiDataGridView(this Macierz vnX,
            DataGridView vndgvMacierzX)
        {
            //wpisanie do DataGridView elementów macierzy X
            for (ushort vni = 0; vni < vndgvMacierzX.Rows.Count; vni++)
                for (ushort vnj = 0; vnj < vndgvMacierzX.Columns.Count; vnj++)
                    vndgvMacierzX.Rows[vni].Cells[vnj].Value = string.Format("{0:F2}", vnX[vni, vnj]);
        }
    }

   
}
