using System;

namespace calendar_KK
{
    enum MiesiącNazwa
    {
        Styczeń = 1,
        Luty = 2,
        Marzec = 3,
        Kwiecień = 4,
        Maj = 5,
        Czerwiec = 6,
        Lipiec = 7,
        Sierpień = 8,
        Wrzesień = 9,
        Październik = 10,
        Listopad = 11,
        Grudzień = 12
    }
    class Program
    {

        static public bool JakaData(int Jak)
        {
            if (Jak == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            // określenie sposobu pobrania dany do programu
        }

        static public bool CzyPrzestepnyRok(int rok)
        {
            return ((rok % 4 == 0 && rok % 100 != 0) || rok % 400 == 0);
            // jeśli wartość wychodzi 'false' to oznacza, iż jest to nie jest rok przestępny
            // natomiast przy wartości 'true' to oznacza, iż dany rok jest rokiem przystępnym
        }

        static public int DniRoku(int rok)
        {
            return LiczbaDni[CzyPrzestepnyRok(rok) ? 1 : 0, 0];
            // zwracanie określonej liczby dni w roku
            // [ zależne od tego, czy jest rok przystępny ]
        }

        static public int DniMiesiącaRoku(int miesiąc, int rok)
        {
            return LiczbaDni[CzyPrzestepnyRok(rok) ? 1 : 0, miesiąc];
            // zwracanie określonej liczby dni w miesiącach
            // [ zależne od tego, czy jest rok przystępny ]

        }

        static public int NumerDnia(int dzień, int miesiąc, int rok)
        {
            int numer = CzyPrzestepnyRok(rok) ? 1 : 0;
            while (--miesiąc > 0)
                dzień += LiczbaDni[numer, miesiąc];
            return dzień;
            // zwraca informację, jaki jest numer dnia w danym roku
        }


        //////////////////////////////////////////////////////////////////////////////
        static public int Kdr(int dzień, int miesiąc, int rok)
        {
            return DniRoku(rok) - NumerDnia(dzień, miesiąc, rok);
            // zwraca informację, ile zostało dni do końca roku < jeszcze nie użyte >
        }
        //////////////////////////////////////////////////////////////////////////////

        static public int JakiDzieńTygodnia(int dzień, int miesiąc, int rok)
        {
            if (miesiąc > 2)
                miesiąc -= 2;
            else
            {
                miesiąc += 10;
                rok--;
            }
            int wartość = rok / 100;
            rok %= 100;
            return (dzień + (13 * miesiąc - 1) / 5 + rok + rok / 4 + wartość / 4 + 5 * wartość) % 7;
            // oblicza i zwraca informację, jaki dzień tygodnia przedstawia określona data
            // 0 - niedziela, 1 - poniedziałek, - 2 - wtorek, 3 - środa ... 6 - sobota
        }

        static readonly int[,] LiczbaDni =
        {
                {365, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31},
                {366, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
                // określenie, czy rok jest przystępny, czy nie
                // pierwsza linijka określa rok zwykły
                // druga linijka określa rok przystępny
            };

        static string[] DzieńTygodnia =
        {
                "Niedziela",
                "Poniedziałek",
                "Wtorek",
                "Środa",
                "Czwartek",
                "Piątek",
                "Sobota"
                // wypisanie konkretnego dnia tygodnia
            };

        //////////////////////////////////////////////////////////////////////////////
        // poniższe cztery [4] instrukcje powodują błąd < kod wyłącznie do wglądu >
        /*static void NagłówekMiesiąca(int miesiąc, int rok) // instrukcja 1-4
        {
            Console.WriteLine(((MiesiącNazwa)(miesiąc)) + " " + rok);
            Console.WriteLine("Pon     Wt      Śr      Czw     Pt      Sob     Niedz");
        }
        static void UzupełnijKalendarz(int dzień, int miesiąc, int rok) // instrukcja 2-4
        {
            int IlośćDni = DniMiesiącaRoku(miesiąc, rok);
            int ObecnyDzień = NumerDnia(dzień,miesiąc,rok);
            var ObecnyDzieńTygodnia = JakiDzieńTygodnia(dzień, miesiąc, rok);
            for (int i = 0; i < KalendarzConsole.GetLength(0); i++)
            {
                for (int j = 0; j < KalendarzConsole.GetLength(1) && ObecnyDzień - ObecnyDzieńTygodnia + 1 <= IlośćDni; j++)
                {
                    if (i == 0)
                    {
                        KalendarzConsole[i, j] = 0;
                    }
                    else
                    {
                        KalendarzConsole[i, j] = ObecnyDzień - ObecnyDzieńTygodnia + 1;
                        ObecnyDzień++;
                    }
                }
            }
        }
        static void RysujKalendarz() // instrukcja 3-4
        {
            for (int i = 0; i < KalendarzConsole.GetLength(0); i++)
            {
                for (int j = 0; j < KalendarzConsole.GetLength(1); j++)
                {
                    if (KalendarzConsole[i, j] > 0)
                    {
                        if (KalendarzConsole[i, j] < 10)
                        {
                            Console.Write("" + KalendarzConsole[i, j] + "\t");
                        }
                        else
                        {
                            Console.Write(KalendarzConsole[i, j] + "\t");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }
        static int[,] KalendarzConsole = new int[6, 7]; // instrukcja 4-4*/
        //////////////////////////////////////////////////////////////////////////////

        static void NarysujCałyMiesiąc(int miesiąc, int rok)
        {
            Console.WriteLine("");
            Console.CursorLeft = (17 - MiesiącNazwy[miesiąc].Length) / 2;
            Console.WriteLine("{0} {1}", MiesiącNazwy[miesiąc], rok);
            Console.WriteLine(" --------------------\n Po Wt Śr Cz Pt So Nd");
            int n = JakiDzieńTygodnia(0, miesiąc, rok), max = DniMiesiącaRoku(miesiąc, rok);
            Console.CursorLeft = 3 * n;
            for (int d = 1; d <= max; d++)
            {
                Console.Write("{0,3}", d);
                if ((d + n) % 7 == 0)
                    Console.WriteLine();
            }
        }
        static readonly string[] MiesiącNazwy = {null,
            "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec",
            "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"};


        static void Instrukcje(int dzień, int miesiąc, int rok)
        {
            Console.WriteLine("[1] Dzisiaj jest {0}, {1} dzień roku.",
                    DzieńTygodnia[Program.JakiDzieńTygodnia(dzień, miesiąc, rok)], Program.NumerDnia(dzień, miesiąc, rok));

            // Console.WriteLine(CzyPrzestepnyRok(rok));
            // powyższa instrukcja wyłącznie do testów

            if (CzyPrzestepnyRok(rok) == false)
            {
                Console.WriteLine($"\n[2] Rok {rok} NIE JEST rokiem przystępnym! :<");
            }
            else
            {
                Console.WriteLine($"\n[2] Rok {rok} JEST rokiem przystępnym! :>");
            }

            Console.WriteLine("\n[3] Dla roku " + rok + " pierwszy styczeń to {0} i jest to {1} dzień roku. ;>",
                DzieńTygodnia[Program.JakiDzieńTygodnia(1, 1, rok)], Program.NumerDnia(1, 1, rok));

            Console.WriteLine("\n////////////////////////////////////////////////////////////////////////////////////");

            Console.WriteLine($"\nKalendarz na miesiąc {(MiesiącNazwa)(miesiąc)} {rok} rok/u :>>>");

            //////////////////////////////////////////////////////////////////////////////
            //poniższe komendy odnoszą się do wcześniejszych 4 instrukcji < błędnych >

            /*NagłówekMiesiąca(miesiąc, rok);
            UzupełnijKalendarz(dzień, miesiąc, rok);
            RysujKalendarz();*/

            //////////////////////////////////////////////////////////////////////////////

            NarysujCałyMiesiąc(miesiąc, rok);

            Console.WriteLine("\n\n////////////////////////////////////////////////////////////////////////////////////");
        }

        static void Main(string[] args)
        {

            string nie = "nie";
            do
            {
                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////");
                Console.Write("\nChcesz wprowadzić dowolną datę ręcznie, czy chcesz ją pobrać z komputera?" +
                    "\n=> jeśli chcesz wpisać daną datę ręcznie [dzień, miesiąc, rok] to wpisz liczbę \"1\"" +
                    "\n=> w przeciwnym razie wpisz \"0\" bądź inną liczbę, aby pobrać dane lokalne" +
                    "\n\t\t\t-> Wpisz wybraną wartość: ");

                int Jak = Convert.ToInt32(Console.ReadLine());
                if (JakaData(Jak) == true)
                {
                    Console.Write("Wpisz numer dnia : ");
                    int dzień = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("Wpisz numer miesiąca : ");
                    int miesiąc = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("Wpisz konkretny rok : ");
                    int rok = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.WriteLine("\n");
                    Instrukcje(dzień, miesiąc, rok);
                }
                else
                {
                    Console.WriteLine("Data została pobrana z komputera");

                    DateTime date = DateTime.Today;

                    int dzień = date.Day;
                    int miesiąc = date.Month;
                    int rok = date.Year;

                    Console.WriteLine("\n");
                    Instrukcje(dzień, miesiąc, rok);

                }

                Console.WriteLine(
                    $"\nCzy chcesz powtórzyć działanie programu?" +
                    $"\n=> jeśli tak, wpisz \"tak\" lub cokolwiek innego;" +
                    $"\n=> jeśli nie, wpisz \"nie\" (przerywa to działanie programu).");
            } while (!(Console.ReadLine() == nie));

            Console.ReadKey();

        }
    }
}
