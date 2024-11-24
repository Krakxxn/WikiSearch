using System;
using System.Diagnostics;
using System.Net;
using System.Web;

class Program
{
    static void Main(string[] args)
    {
        // Afficher "WikiSearch" dans le terminal
        Console.WriteLine("========================================");
        Console.WriteLine("            WikiSearch");
        Console.WriteLine("========================================");

        while (true)
        {
            Console.Write("\nEntrez un mot ou une phrase (ou tapez 'exit' pour quitter) : ");
            string input = Console.ReadLine();

            // Si l'utilisateur tape 'exit', on quitte le programme
            if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
            {
                Console.WriteLine("Merci d'avoir utilisé ce programme. À bientôt !");
                break;
            }

            // Encoder le texte pour l'URL
            string query = HttpUtility.UrlEncode(input);

            // Construire l'URL de recherche Wikipédia
            string wikipediaUrl = $"https://fr.wikipedia.org/wiki/{query}";

            Console.WriteLine($"Ouverture de la page Wikipédia pour : {input}");

            try
            {
                // Ouvrir l'URL dans le navigateur par défaut
                Process.Start(new ProcessStartInfo
                {
                    FileName = wikipediaUrl,
                    UseShellExecute = true // Obligatoire pour ouvrir dans un navigateur
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue lors de l'ouverture du navigateur : {ex.Message}");
            }
        }

        // Ajouter cette ligne pour garder la fenêtre ouverte
        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey();
    }
}
