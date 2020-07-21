﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpModule3.BO;

namespace TpModule3
{
    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        public static void Main(string[] args)
        {
            InitialiserDatas();


            //Section Auteur par G 

            var auteursParG = ListeAuteurs.Where(n => n.Nom.StartsWith("G"));

            Console.WriteLine("Noms des auteurs commençant par G : ");
            Console.WriteLine();
            foreach (var auteur in auteursParG)
            {
                Console.WriteLine(auteur.Nom);
            }



            //Section plus de livres 
            Console.WriteLine();
            Console.WriteLine("Auteur ayant écrit le plus de livres");
            Console.WriteLine();
            var auteurProlifique = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(n => n.Count()).Take(1);

            foreach (var auteur in auteurProlifique)
            {
                Console.WriteLine(auteur.Key.Nom);
            }

            //Section nombre moyen de pages par livres par auteur
            Console.WriteLine();
            Console.WriteLine("Nombre moyen de pages par livres par auteur" );
            Console.WriteLine();
            var livresParAuteur = ListeLivres.GroupBy(l => l.Auteur);

            foreach (var livre in livresParAuteur)
            {
                Console.WriteLine($"Auteur {livre.Key.Nom} {livre.Key.Prenom} moyenne de pages = {livre.Average(l => l.NbPages)}");
            }

            //Section titre du livre avec plus de pages

            var livresVolumineux = ListeLivres.OrderByDescending(l => l.NbPages).Take(1);

            Console.WriteLine();

            foreach (var livrePlusVolumineux in livresVolumineux)
            {
                Console.WriteLine($"Livre le plus volumineux {livrePlusVolumineux.Titre}");
            }
           

            Console.ReadKey();
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
