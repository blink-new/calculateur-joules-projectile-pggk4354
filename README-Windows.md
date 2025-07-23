# 🧮 Calculateur d'énergie en joules - Version Windows

Application Windows Forms native pour calculer l'énergie cinétique d'un projectile en joules.

## 🎯 Description

Cette application reproduit fidèlement la version web React en tant qu'application Windows native. Elle calcule l'énergie cinétique d'un projectile à partir de :
- **Nombre de grains** de poudre
- **Poids de la balle** (en grammes)
- **Vitesse** (en m/s)

**Formule utilisée :** `E = ½ × m × v²`

## ✨ Fonctionnalités

### 🎨 Interface moderne
- Design inspiré de la version web avec palette de couleurs identique
- Interface Windows Forms native avec animations fluides
- Layout responsive en 2 colonnes (formulaire + résultats)
- Validation en temps réel des entrées

### ⚡ Calcul automatique
- Calcul instantané dès la saisie des valeurs
- Support des virgules et points décimaux
- Conversion automatique grammes → kilogrammes
- Résultat affiché avec 2 décimales de précision

### 📊 Affichage détaillé
- Énergie en joules mise en évidence
- Récapitulatif des valeurs saisies
- Classification de l'énergie (Faible/Modérée/Élevée/Très haute)
- Formule mathématique expliquée

### 🔧 Fonctionnalités pratiques
- Bouton de réinitialisation
- Validation stricte des champs numériques
- Messages d'aide et unités claires
- Interface accessible et ergonomique

## 🚀 Installation et compilation

### Prérequis
- **Windows 10/11** (64 bits)
- **.NET 8.0 SDK** ou plus récent
  - Télécharger depuis : https://dotnet.microsoft.com/download

### Méthode 1 : Script Batch (Recommandé)
```batch
# Double-cliquez sur le fichier ou exécutez en ligne de commande
build-windows.bat
```

### Méthode 2 : Script PowerShell
```powershell
# Clic droit → "Exécuter avec PowerShell" ou en ligne de commande
.\build-windows.ps1
```

### Méthode 3 : Ligne de commande manuelle
```bash
# Compilation
dotnet build CalculateurJoulesWindows.csproj -c Release

# Publication en exécutable autonome 64 bits
dotnet publish CalculateurJoulesWindows.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishReadyToRun=true -o publish
```

## 📁 Structure des fichiers

```
📦 Calculateur Joules Windows
├── 📄 CalculateurJoulesWindows.cs      # Code source principal
├── 📄 CalculateurJoulesWindows.csproj  # Fichier de projet .NET
├── 📄 build-windows.bat               # Script de compilation Batch
├── 📄 build-windows.ps1               # Script de compilation PowerShell
├── 📄 README-Windows.md               # Cette documentation
└── 📁 publish/                        # Dossier de sortie
    └── 📄 CalculateurJoulesWindows.exe # Exécutable final (après compilation)
```

## 🎮 Utilisation

### Lancement
1. **Après compilation :** Double-cliquez sur `publish/CalculateurJoulesWindows.exe`
2. **Ou :** Exécutez le script de compilation qui lance automatiquement l'app

### Interface
1. **Saisie des données :**
   - Entrez le nombre de grains de poudre
   - Saisissez le poids de la balle en grammes
   - Indiquez la vitesse en m/s

2. **Résultats automatiques :**
   - L'énergie en joules s'affiche instantanément
   - Classification de l'énergie affichée
   - Récapitulatif des valeurs dans des panneaux colorés

3. **Réinitialisation :**
   - Cliquez sur "🔄 Réinitialiser" pour vider tous les champs

### Exemple de calcul
- **Grains :** `42`
- **Poids :** `9.5g`
- **Vitesse :** `350 m/s`
- **Résultat :** `581.25 Joules` (Énergie modérée)

## 🔧 Caractéristiques techniques

### Configuration de compilation
- **Framework :** .NET 8.0 Windows
- **Architecture :** x64 (64 bits)
- **Type :** Exécutable autonome (self-contained)
- **Fichier unique :** Oui (PublishSingleFile)
- **Optimisé :** ReadyToRun activé

### Compatibilité
- **OS :** Windows 10 version 1809+ / Windows 11
- **Architecture :** x64 uniquement
- **Dépendances :** Aucune (runtime inclus)
- **Taille :** ~15-20 MB (exécutable autonome)

### Sécurité et validation
- Validation stricte des entrées numériques
- Support des formats décimaux (virgule et point)
- Gestion d'erreurs robuste
- Interface utilisateur sécurisée

## 🆚 Comparaison avec les autres versions

| Fonctionnalité | Web React | Console C# | **Windows Forms** |
|----------------|-----------|------------|-------------------|
| Interface graphique | ✅ Moderne | ❌ Console | ✅ **Native Windows** |
| Calcul temps réel | ✅ | ❌ | ✅ **Instantané** |
| Validation entrées | ✅ | ✅ | ✅ **Stricte** |
| Classification énergie | ❌ | ✅ | ✅ **Visuelle** |
| Portabilité | 🌐 Web | 🐧 Linux | 🪟 **Windows uniquement** |
| Installation requise | ❌ | ❌ | ❌ **Autonome** |
| Taille | ~2MB | ~50MB | **~18MB** |

## 🐛 Dépannage

### Erreur "dotnet command not found"
- Installez .NET 8.0 SDK depuis https://dotnet.microsoft.com/download
- Redémarrez votre terminal/invite de commande

### Erreur de compilation
- Vérifiez que tous les fichiers sont présents
- Assurez-vous d'avoir les permissions d'écriture dans le dossier
- Essayez de nettoyer avec `dotnet clean` puis recompilez

### L'application ne se lance pas
- Vérifiez que vous êtes sur Windows 64 bits
- Essayez d'exécuter en tant qu'administrateur
- Vérifiez l'antivirus (peut bloquer les nouveaux exécutables)

## 📝 Notes de développement

### Architecture
- **Pattern :** Windows Forms avec séparation logique
- **Validation :** Temps réel avec gestion d'erreurs
- **UI :** Design moderne inspiré de Material Design
- **Performance :** Optimisé pour la réactivité

### Personnalisation
Le code source est entièrement modifiable :
- Couleurs dans les constructeurs de `Color.FromArgb()`
- Polices dans les constructeurs de `Font()`
- Layout dans les propriétés `Location` et `Size`
- Logique de calcul dans la méthode `CalculateEnergy()`

## 📄 Licence

Ce projet est distribué sous licence libre. Vous pouvez l'utiliser, le modifier et le redistribuer librement.

---

**🎯 Version Windows native du Calculateur d'énergie en joules**  
*Interface moderne • Calcul instantané • Exécutable autonome*