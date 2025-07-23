using System;
using System.Globalization;

namespace CalculateurJoules
{
    /// <summary>
    /// Calculateur d'énergie cinétique pour projectiles
    /// Compatible Ubuntu - Version C#
    /// </summary>
    public class CalculateurJoules
    {
        private const string VERSION = "1.0.0";
        private const string TITRE = "Calculateur d'énergie en joules pour projectiles";
        
        public static void Main(string[] args)
        {
            // Configuration pour Ubuntu (support UTF-8)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            AfficherEntete();
            
            bool continuer = true;
            while (continuer)
            {
                try
                {
                    ExecuterCalcul();
                    continuer = DemanderContinuer();
                }
                catch (Exception ex)
                {
                    AfficherErreur($"Erreur inattendue: {ex.Message}");
                    continuer = DemanderContinuer();
                }
            }
            
            AfficherAuRevoir();
        }
        
        /// <summary>
        /// Affiche l'en-tête de l'application
        /// </summary>
        private static void AfficherEntete()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║        🎯 CALCULATEUR D'ÉNERGIE EN JOULES v" + VERSION + "           ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║        Calcul de l'énergie cinétique des projectiles        ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📋 Formule utilisée: E = ½ × m × v²");
            Console.WriteLine("   • E = Énergie cinétique (Joules)");
            Console.WriteLine("   • m = Masse (kg)");
            Console.WriteLine("   • v = Vitesse (m/s)");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        /// <summary>
        /// Exécute le calcul principal
        /// </summary>
        private static void ExecuterCalcul()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("📊 SAISIE DES PARAMÈTRES");
            Console.ResetColor();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            
            // Saisie des données
            double grains = SaisirValeur("🔸 Nombre de grains de poudre", "grains", 0.1, 1000);
            double poidsGrammes = SaisirValeur("🔸 Poids de la balle (grammes)", "g", 0.1, 1000);
            double vitesse = SaisirValeur("🔸 Vitesse du projectile (m/s)", "m/s", 0.1, 2000);
            
            // Calcul de l'énergie
            double energie = CalculerEnergie(poidsGrammes, vitesse);
            
            // Affichage des résultats
            AfficherResultats(grains, poidsGrammes, vitesse, energie);
        }
        
        /// <summary>
        /// Saisit une valeur numérique avec validation
        /// </summary>
        private static double SaisirValeur(string prompt, string unite, double min, double max)
        {
            double valeur;
            bool valide = false;
            
            do
            {
                Console.Write($"{prompt} ({unite}): ");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine()?.Trim() ?? "";
                Console.ResetColor();
                
                if (string.IsNullOrEmpty(input))
                {
                    AfficherErreur("Veuillez saisir une valeur.");
                    continue;
                }
                
                // Support des formats numériques avec virgule et point
                input = input.Replace(',', '.');
                
                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out valeur))
                {
                    if (valeur >= min && valeur <= max)
                    {
                        valide = true;
                    }
                    else
                    {
                        AfficherErreur($"La valeur doit être comprise entre {min} et {max} {unite}.");
                    }
                }
                else
                {
                    AfficherErreur("Format numérique invalide. Utilisez le point ou la virgule comme séparateur décimal.");
                }
                
            } while (!valide);
            
            return valeur;
        }
        
        /// <summary>
        /// Calcule l'énergie cinétique
        /// </summary>
        /// <param name="poidsGrammes">Poids en grammes</param>
        /// <param name="vitesse">Vitesse en m/s</param>
        /// <returns>Énergie en joules</returns>
        private static double CalculerEnergie(double poidsGrammes, double vitesse)
        {
            // Conversion grammes -> kilogrammes
            double masseKg = poidsGrammes / 1000.0;
            
            // Formule: E = 1/2 * m * v²
            double energie = 0.5 * masseKg * Math.Pow(vitesse, 2);
            
            return energie;
        }
        
        /// <summary>
        /// Affiche les résultats du calcul
        /// </summary>
        private static void AfficherResultats(double grains, double poidsGrammes, double vitesse, double energie)
        {
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⚡ RÉSULTATS DU CALCUL");
            Console.ResetColor();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            
            // Résultat principal
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"🎯 ÉNERGIE CINÉTIQUE: {energie:F2} JOULES");
            Console.ResetColor();
            Console.WriteLine();
            
            // Détails du calcul
            Console.WriteLine("📋 Paramètres utilisés:");
            Console.WriteLine($"   • Grains de poudre: {grains:F1}");
            Console.WriteLine($"   • Poids de la balle: {poidsGrammes:F1} g ({poidsGrammes/1000:F4} kg)");
            Console.WriteLine($"   • Vitesse: {vitesse:F1} m/s");
            Console.WriteLine();
            
            // Détail du calcul
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🔢 Détail du calcul:");
            Console.WriteLine($"   E = ½ × m × v²");
            Console.WriteLine($"   E = 0.5 × {poidsGrammes/1000:F4} kg × ({vitesse:F1} m/s)²");
            Console.WriteLine($"   E = 0.5 × {poidsGrammes/1000:F4} × {Math.Pow(vitesse, 2):F2}");
            Console.WriteLine($"   E = {energie:F2} Joules");
            Console.ResetColor();
            Console.WriteLine();
            
            // Classification de l'énergie
            AfficherClassificationEnergie(energie);
        }
        
        /// <summary>
        /// Affiche une classification de l'énergie calculée
        /// </summary>
        private static void AfficherClassificationEnergie(double energie)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📊 Classification de l'énergie:");
            
            string classification;
            ConsoleColor couleur;
            
            if (energie < 100)
            {
                classification = "Faible énergie";
                couleur = ConsoleColor.Green;
            }
            else if (energie < 500)
            {
                classification = "Énergie modérée";
                couleur = ConsoleColor.Yellow;
            }
            else if (energie < 1000)
            {
                classification = "Énergie élevée";
                couleur = ConsoleColor.DarkYellow;
            }
            else
            {
                classification = "Très haute énergie";
                couleur = ConsoleColor.Red;
            }
            
            Console.ForegroundColor = couleur;
            Console.WriteLine($"   ➤ {classification} ({energie:F2} J)");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        /// <summary>
        /// Demande si l'utilisateur veut continuer
        /// </summary>
        private static bool DemanderContinuer()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.Write("Voulez-vous effectuer un autre calcul ? (o/n): ");
            Console.ForegroundColor = ConsoleColor.White;
            string reponse = Console.ReadLine()?.Trim().ToLower() ?? "";
            Console.ResetColor();
            
            return reponse == "o" || reponse == "oui" || reponse == "y" || reponse == "yes";
        }
        
        /// <summary>
        /// Affiche un message d'erreur
        /// </summary>
        private static void AfficherErreur(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Erreur: {message}");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Affiche le message d'au revoir
        /// </summary>
        private static void AfficherAuRevoir()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║                    👋 Au revoir !                           ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║            Merci d'avoir utilisé le calculateur             ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}