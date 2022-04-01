using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Oblicz_an(ulong an, double a1, double a2)
        {
            double result = 0;
            Console.Write("=> wartość a1 = {0}\n=> wartość a2 = {1}\n", a1, a2);
            Console.WriteLine("Wartości \"an\" w ciągu:");
            for (uint i = 2; i < an; i++)
            {
                result = 2 * a1 - a2;
                Console.WriteLine("=> {0}", result);
                a1 = a2;
                a2 = result;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("\nTreść zadania:" +
                "\nNapisać program, który pobierze od użytkownika dwa pierwsze wyrazy (typ zmiennoprzecinkowy)" +
                "\noraz liczbę elementów ciągu (bezznakowy typ całkowity), a następnie wypisze" +
                "\nw kolejnych liniach wszystkie jego wyrazy według wzoru" +
                "\n\t a1 = podane przez użytkownika," +
                "\n\t a2 = podane przez użytkownika," +
                "\n\t an = (2 * (an - a1)) - (an - a2)" +
                "\n\nPo zakończeniu program ma spytać użytkownika," +
                "\nczy ten chce wyjść, czy powtórzyć program od początku.\n");

            string no = "n";
            do
            {
                Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////");

                Console.WriteLine("\nWitaj w programie obliczającym ciąg dla wzoru \"an = 2*an-1 - an-2\"!" +
                    "\nPodaj wartości, jakie mają zostać użyte przy obliczeniach programu.\n");
                double
                    a1,
                    a2;

                Console.WriteLine("-> Podaj wartość dla pierwszego wyrazu zmiennoprzecinkowego: ");
                a1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("-> Podaj wartość dla drugiego wyrazu zmiennoprzecinkowego: ");
                a2 = Convert.ToDouble(Console.ReadLine());

                ulong an;

                Console.WriteLine("\n-> Podaj liczbę elementów ciągu (beznakowy typ całkowity - co najmniej 3): ");
                an = Convert.ToUInt64(Console.ReadLine());

                Console.WriteLine("\nDla wzoru \"an = 2*an-1 - an-2\": ");
                Oblicz_an(an, a1, a2);

                Console.WriteLine(
                    $"\nCzy chcesz powtórzyć działanie programu?" +
                    $"\n=> jeśli tak, wpisz \"y\" lub cokolwiek innego;" +
                    $"\n=> jeśli nie, wpisz \"n\" (przerywa to działanie programu).");
            } while (!(Console.ReadLine() == no));

            Console.ReadKey();
        }
    }
}
