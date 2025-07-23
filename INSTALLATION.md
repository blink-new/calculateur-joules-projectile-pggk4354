# 🚀 Installation rapide - Ubuntu

## Option 1 : Installation automatique (.NET ou Mono)

```bash
# Rendre le script exécutable
chmod +x run.sh

# Exécuter l'application (détecte automatiquement .NET ou Mono)
./run.sh
```

## Option 2 : Installation avec .NET

```bash
# Installer .NET
sudo apt update
sudo apt install -y dotnet-sdk-8.0

# Compiler et exécuter
chmod +x build.sh
./build.sh
```

## Option 3 : Installation avec Mono

```bash
# Installer Mono
sudo apt update
sudo apt install -y mono-complete

# Compiler et exécuter
chmod +x build-mono.sh
./build-mono.sh
```

## Option 4 : Exécutable autonome

```bash
# Créer un exécutable autonome (nécessite .NET)
chmod +x publish.sh
./publish.sh

# Exécuter l'application
./publish/CalculateurJoules
```

## 📋 Test rapide

Une fois l'application lancée, testez avec ces valeurs :
- Grains de poudre : `42`
- Poids de la balle : `9.5` (grammes)
- Vitesse : `350` (m/s)

**Résultat attendu :** `581.25 Joules`

## 🔧 Dépannage

### Erreur "command not found"
- Vérifiez que .NET ou Mono est installé
- Utilisez `./run.sh` qui détecte automatiquement

### Problème d'encodage
- L'application gère automatiquement l'UTF-8
- Si les caractères spéciaux ne s'affichent pas, votre terminal ne supporte peut-être pas l'UTF-8

### Permissions
```bash
# Donner les permissions d'exécution à tous les scripts
chmod +x *.sh
```