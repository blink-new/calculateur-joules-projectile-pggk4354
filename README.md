# Calculateur d'énergie en joules pour projectiles

## 🎯 Description

Application console C# compatible Ubuntu qui calcule l'énergie cinétique d'un projectile en joules à partir du nombre de grains de poudre, du poids de la balle et de sa vitesse en m/s.

Cette version C# reproduit exactement la logique de calcul de l'application web React originale, avec une interface utilisateur en ligne de commande interactive et colorée.

## ⚡ Fonctionnalités

- **Calcul précis** : Utilise la formule E = ½ × m × v²
- **Interface interactive** : Saisie guidée avec validation des données
- **Support UTF-8** : Affichage correct des caractères spéciaux sur Ubuntu
- **Validation robuste** : Gestion des erreurs de saisie et formats numériques
- **Classification** : Évaluation du niveau d'énergie calculé
- **Calculs multiples** : Possibilité d'effectuer plusieurs calculs successifs
- **Affichage détaillé** : Présentation claire des résultats et du détail du calcul

## 🔧 Prérequis

### Installation de .NET sur Ubuntu

```bash
# Mise à jour du système
sudo apt update

# Installation de .NET 8.0 SDK
sudo apt install -y dotnet-sdk-8.0

# Vérification de l'installation
dotnet --version
```

### Alternative : Installation via Microsoft

```bash
# Téléchargement et installation du package Microsoft
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt update
sudo apt install -y dotnet-sdk-8.0
```

## 🚀 Installation et utilisation

### Méthode 1 : Compilation et exécution avec .NET

```bash
# Cloner ou télécharger les fichiers du projet
# Puis dans le dossier du projet :

# Rendre le script exécutable
chmod +x build.sh

# Compiler et exécuter
./build.sh
```

### Méthode 2 : Compilation manuelle

```bash
# Compilation
dotnet build --configuration Release

# Exécution
dotnet run --configuration Release
```

### Méthode 3 : Création d'un exécutable autonome

```bash
# Rendre le script exécutable
chmod +x publish.sh

# Créer l'exécutable autonome
./publish.sh

# Exécuter l'application
./publish/CalculateurJoules
```

## 📋 Utilisation

1. **Lancement** : Exécutez l'application
2. **Saisie des données** :
   - Nombre de grains de poudre
   - Poids de la balle en grammes
   - Vitesse du projectile en m/s
3. **Résultats** : L'application affiche :
   - L'énergie cinétique en joules
   - Le détail du calcul
   - Une classification de l'énergie
4. **Nouveau calcul** : Possibilité de recommencer

## 🔢 Formule utilisée

```
E = ½ × m × v²

Où :
• E = Énergie cinétique (Joules)
• m = Masse (kg) - convertie automatiquement depuis les grammes
• v = Vitesse (m/s)
```

## 📊 Exemple d'utilisation

```
🔸 Nombre de grains de poudre (grains): 42
🔸 Poids de la balle (grammes) (g): 9.5
🔸 Vitesse du projectile (m/s) (m/s): 350

🎯 ÉNERGIE CINÉTIQUE: 581.25 JOULES

📋 Paramètres utilisés:
   • Grains de poudre: 42.0
   • Poids de la balle: 9.5 g (0.0095 kg)
   • Vitesse: 350.0 m/s

🔢 Détail du calcul:
   E = ½ × m × v²
   E = 0.5 × 0.0095 kg × (350.0 m/s)²
   E = 0.5 × 0.0095 × 122500.00
   E = 581.25 Joules

📊 Classification de l'énergie:
   ➤ Énergie élevée (581.25 J)
```

## 🎨 Fonctionnalités techniques

- **Encodage UTF-8** : Support complet des caractères spéciaux
- **Validation des entrées** : Gestion des formats numériques avec virgule et point
- **Interface colorée** : Utilisation des couleurs de console pour une meilleure lisibilité
- **Gestion d'erreurs** : Messages d'erreur clairs et récupération gracieuse
- **Calculs de précision** : Résultats affichés avec 2 décimales
- **Classification automatique** : Évaluation du niveau d'énergie

## 📁 Structure du projet

```
├── CalculateurJoules.cs      # Code source principal
├── CalculateurJoules.csproj  # Fichier de projet .NET
├── build.sh                  # Script de compilation et exécution
├── publish.sh                # Script de création d'exécutable autonome
└── README.md                 # Documentation
```

## 🔄 Comparaison avec la version web

| Fonctionnalité | Version Web (React) | Version Console (C#) |
|----------------|--------------------|--------------------|
| Calcul en temps réel | ✅ | ✅ (à la validation) |
| Validation des entrées | ✅ | ✅ |
| Affichage de la formule | ✅ | ✅ |
| Interface responsive | ✅ | ✅ (adaptée console) |
| Calculs multiples | ❌ | ✅ |
| Classification énergie | ❌ | ✅ |
| Détail du calcul | ✅ | ✅ (plus détaillé) |

## 🐧 Compatibilité

- **Ubuntu** 20.04, 22.04, 24.04
- **Debian** 11, 12
- **CentOS/RHEL** 8, 9
- **Fedora** 37+
- **Autres distributions Linux** avec .NET 8.0

## 📝 Notes

- L'application utilise la même formule physique que la version web
- Les résultats sont identiques à ceux de l'application React
- L'interface console est optimisée pour une utilisation en terminal
- Support complet de l'UTF-8 pour l'affichage des caractères spéciaux

## 🤝 Contribution

Cette application C# est une duplication fidèle de l'application web React originale, adaptée pour un environnement console Ubuntu.