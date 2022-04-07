using System;

namespace kalendarz_kolokwium_Łukasz_Tworzydło_gd29623
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
        static bool JakaData(int Jak)
        {
            if (Jak == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            // określenie sposobu pobrania daty do programu
            // jeśli wartość to 'true' użytkownik wprowadza dane
            // zaś przy wartości 'false' dane są pobierane z komputera
        }
        static bool CzyPrzestepnyRok(int rok)
        {
            return ((rok % 4 == 0 && rok % 100 != 0) || rok % 400 == 0);
            // jeśli wartość wychodzi 'false' to oznacza, iż jest to nie jest rok przestępny
            // natomiast przy wartości 'true' to oznacza, iż dany rok jest rokiem przystępnym
        }
        static int DniMiesiącaRoku(int miesiąc, int rok)
        {
            return LiczbaDni[CzyPrzestepnyRok(rok) ? 1 : 0, miesiąc];
            // zwracanie określonej liczby dni w miesiącach
            // [ zależne od tego, czy jest rok przystępny ]
            // wyświetla odpowiednią ilość dni w przypadku tworzenia [...]
            // [...] kalendarza wizualnego dla danego miesiąca określonego roku
        }
        static int NumerDnia(int dzień, int miesiąc, int rok)
        {
            int numer = CzyPrzestepnyRok(rok) ? 1 : 0;
            while (--miesiąc > 0)
                dzień += LiczbaDni[numer, miesiąc];
            return dzień;
            // zwraca informację, jaki jest numer dnia w danym roku
        }
        static int JakiDzieńTygodnia(int dzień, int miesiąc, int rok)
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
            {365, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}, // rok tradycyjny
            {366, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31} // rok przystępny
            // określenie, czy rok jest przystępny, czy nie
            // pierwsza linijka określa rok zwykły
            // druga linijka określa rok przystępny

            // dokładnie cały rok ma około 365,242199 dnia,
            // też dlatego ma zwykle 365 dni, zaś co 4 lata ma 366 dni,
            // czyli przykładowo rok 2016, 2020, bądź 2024 to rok przystępny
        };
        static readonly string[] DzieńTygodnia =
        {
            "niedziela", // wartość => 0
            "poniedziałek", // wartość => 1
            "wtorek", // wartość => 2
            "środa", // wartość => 3
            "czwartek", // wartość => 4
            "piątek", // wartość => 5
            "sobota", // wartość => 6
            // wypisanie konkretnego dnia tygodnia
        };
        static readonly string[] MiesiącNazwy =
        {
            null,
            "Styczeń", "Luty", "Marzec", // Q1 [ pierwszy kwartał roku ]
            "Kwiecień", "Maj", "Czerwiec", // Q2 [ drugi kwartał roku ]
            "Lipiec", "Sierpień", "Wrzesień", // Q3 [ trzeci kwartał roku ]
            "Październik", "Listopad", "Grudzień" // Q4 [ czwarty kwartał roku ]
        };
        static void NazwaMiesiącaRoku(int miesiąc, int rok)
        {
            Console.CursorLeft = (27 - MiesiącNazwy[miesiąc].Length) / 2;
            Console.WriteLine("{0} {1}", MiesiącNazwy[miesiąc], rok);
        }
        static void NagłówekKalendarza()
        {
            Console.WriteLine(" \n " +
                " pon " +
                "wto " +
                "śro " +
                "czw " +
                "pią " +
                "sob " +
                "nie");
        }
        static void WnętrzeKalendarza(int miesiąc, int rok)
        {
            int iN = JakiDzieńTygodnia(0, miesiąc, rok), jM = DniMiesiącaRoku(miesiąc, rok);
            Console.CursorLeft = 4 * iN;
            for (int kD = 1; kD <= jM; kD++)
            {
                Console.Write("{0,4}", kD);
                if ((kD + iN) % 7 == 0)
                    Console.WriteLine("");
            }
        }
        static void Instrukcje(int dzień, int miesiąc, int rok)
        {
            // Console.WriteLine(CzyPrzestepnyRok(rok));
            // powyższa instrukcja wyłącznie do testów

            Console.WriteLine($"\n\tWybrana data to: {dzień}/{miesiąc}/{rok}");
            Console.WriteLine("\t... i to jest {0} dzień roku! ^.^", Program.NumerDnia(dzień, miesiąc, rok));

            if (CzyPrzestepnyRok(rok) == false)
            {
                Console.WriteLine($"\n[1] NIE => Rok {rok} NIE JEST rokiem przystępnym! :<");
            }
            else
            {
                Console.WriteLine($"\n[1] TAK => Rok {rok} JEST rokiem przystępnym! :>");
            }

            Console.WriteLine("\n[2] Dla roku " + rok + " pierwszy styczeń to {0}. ;>",
                (DzieńTygodnia)[Program.JakiDzieńTygodnia(1, 1, rok)]);

            Console.WriteLine("\n////////////////////////////////////////////////////////////////////////////////////");

            Console.WriteLine($"\n[3] Kalendarz na miesiąc {(MiesiącNazwa)(4)} {rok} roku :>>>\n");

            NazwaMiesiącaRoku(4, rok);
            NagłówekKalendarza();
            WnętrzeKalendarza(4, rok);

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
                    Console.Write("->>> Wpisz numer dnia : ");
                    int dzień = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("->>> Wpisz numer miesiąca : ");
                    int miesiąc = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("->>> Wpisz konkretny rok : ");
                    int rok = Convert.ToInt32(Console.ReadLine().Trim());

                    Instrukcje(dzień, miesiąc, rok);
                }
                else
                {
                    Console.WriteLine("\n->>> Data została pobrana z komputera");

                    DateTime date = DateTime.Today;

                    int dzień = date.Day;
                    int miesiąc = date.Month;
                    int rok = date.Year;

                    Instrukcje(dzień, miesiąc, rok);
                }

                Console.WriteLine(
                    "\nCzy chcesz powtórzyć działanie programu?" +
                    "\n=> jeśli tak, wpisz \"tak\" lub cokolwiek innego;" +
                    "\n=> jeśli nie, wpisz \"nie\" (przerywa to działanie programu).");
            } while (!(Console.ReadLine() == nie));

            Console.ReadKey();
        }
    }
}