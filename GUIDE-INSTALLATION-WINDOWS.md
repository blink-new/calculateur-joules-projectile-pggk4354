# 🚀 Guide d'installation rapide - Version Windows

## 📋 Étapes simples

### 1️⃣ Prérequis (5 minutes)
Installez .NET 8.0 SDK :
- 🔗 **Lien direct :** https://dotnet.microsoft.com/download/dotnet/8.0
- 📥 Téléchargez "SDK x64" pour Windows
- ▶️ Exécutez l'installateur et suivez les instructions
- 🔄 Redémarrez votre invite de commande

### 2️⃣ Compilation (2 minutes)
**Option A - Script automatique (Recommandé) :**
```batch
# Double-cliquez sur le fichier
build-windows.bat
```

**Option B - PowerShell :**
```powershell
# Clic droit → "Exécuter avec PowerShell"
.\build-windows.ps1
```

**Option C - Ligne de commande :**
```cmd
dotnet publish CalculateurJoulesWindows.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish
```

### 3️⃣ Utilisation
- 📁 Ouvrez le dossier `publish/`
- 🖱️ Double-cliquez sur `CalculateurJoulesWindows.exe`
- 🎉 L'application se lance !

## ⚡ Test rapide
Avant la compilation complète, testez avec :
```batch
test-compilation.bat
```

## 🎯 Résultat final
- ✅ **Fichier :** `CalculateurJoulesWindows.exe` (~18 MB)
- ✅ **Autonome :** Aucune installation requise
- ✅ **Portable :** Copiez sur n'importe quel PC Windows 64 bits
- ✅ **Interface :** Identique à la version web

## 🆘 Problèmes courants

| Problème | Solution |
|----------|----------|
| "dotnet command not found" | Installez .NET SDK et redémarrez le terminal |
| Erreur de compilation | Vérifiez que tous les fichiers sont présents |
| Antivirus bloque l'exe | Ajoutez une exception pour le dossier |
| App ne se lance pas | Vérifiez Windows 64 bits + exécutez en admin |

## 📞 Support
- 📖 Documentation complète : `README-Windows.md`
- 🔧 Test de compilation : `test-compilation.bat`
- 💡 Exemples de calcul dans l'application

---
**⏱️ Temps total : ~7 minutes**  
**🎯 Résultat : Application Windows native prête à utiliser !**