using System;
// regex voor de validator
using System.Text.RegularExpressions;

namespace EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string y_n;
            string input;
            string pattern = @"^\w+@[a-zA-Z]+(?:\.\w{1,3})+$";
            // ^: begin van de newline, er mag dus geen spatie aan het begin zijn
            // \w: alle woord-characters; [a-zA-Z0-9_]
            // +: een of meer van woord-characters
            // @: er moet een "@" in de string zitten
            // [a-zA-Z]: characters tussen a-z en A-Z mogen worden gebruikt
            // +: een of meer van wat hierboven staat
            // (?:\.\w{1,3}): (?:) alles van de string ná de domeinnaam moet hiermee overeenkomen:
            // \.: er moet een punt staan
            // \w: alle woord-characters; [a-zA-Z0-9_]
            // {1, 3}: er moeten tussen de 1 en 3 van deze characters staan
            // +: dit moet een of meerdere malen gebeuren
            // $: eind van de newline, er mag dus geen spatie na volgen

            Match m;
            Console.WriteLine($"pattern: {pattern}");
            do
            {
                Console.WriteLine();
                Console.WriteLine("Voer een E-mail adres in: ");
                input = Console.ReadLine();

                m = Regex.Match(input, pattern);
                Console.WriteLine(m.Success);

                Console.Write("\nandere mail testen? (y | n): ");
                y_n = Console.ReadLine();
            } while (y_n.ToLower() != "n");
        }
    }
}
