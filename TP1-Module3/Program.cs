using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Module3.BO;

namespace TP1_Module3
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        public static void Main(string[] args)
        {
            InitialiserDatas();
            Console.WriteLine("Prénoms auteurs dont noms commencent par G :");
            var auteursG = ListeAuteurs.Where(auteurs => auteurs.Nom.StartsWith("G")).Select(auteurs => auteurs.Prenom);
            foreach (var prenom in auteursG)
            {
                Console.WriteLine(prenom);
            }

            var auteursMaxLivres = ListeLivres.GroupBy(livres => livres.Auteur).OrderByDescending(auteurs => auteurs.Count()).FirstOrDefault().Key;
            Console.WriteLine("Auteur qui a écrit le plus de livres : ");
            Console.WriteLine($"{auteursMaxLivres.Prenom} {auteursMaxLivres.Nom}");

            var livreParAuteur = ListeLivres.GroupBy(livres => livres.Auteur);
            Console.WriteLine("Nombre moyen de pages par livre et par auteur : ");
            foreach (var auteur in livreParAuteur)
            {
                Console.WriteLine($"{auteur.Key.Prenom} {auteur.Key.Nom} moyenne des pages = {auteur.Average(livres => livres.NbPages)}");
            }

            var livreMax = ListeLivres.OrderByDescending(livres => livres.NbPages).First();
            Console.WriteLine("Livre avec le nombre max de pages : ");
            Console.WriteLine(livreMax.Titre);

            var argentAuteurMoyenne = ListeAuteurs.Average(auteurs => auteurs.Factures.Sum(factures => factures.Montant));
            Console.WriteLine("Argent gagné en moyenne par les auteurs : ");
            Console.WriteLine($"{argentAuteurMoyenne} euros");

            // correction cours
            var correctionArgentMoyenn = ListeAuteurs.Where(x => x.Factures.Count > 0).Average(x => x.Factures.Average(y => y.Montant));
            Console.WriteLine("Correction argent gagné en moyenne par les auteurs");
            Console.WriteLine($"{correctionArgentMoyenn} euros");

            var livresParAuteur = ListeLivres.GroupBy(livres => livres.Auteur);
            foreach (var livres in livresParAuteur)
            {
                Console.WriteLine($"Auteur: {livres.Key.Prenom} {livres.Key.Nom}");
                foreach (var livre in livres)
                {
                    Console.WriteLine(livre.Titre);
                }
            }

            Console.ReadLine();
        }


        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
