#!/bin/bash

# Script de publication pour créer un exécutable autonome
# Compatible avec Ubuntu et autres distributions Linux

echo "📦 Publication du calculateur d'énergie en joules..."
echo "===================================================="

# Vérification de .NET
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET n'est pas installé sur ce système."
    exit 1
fi

# Création du dossier de publication
mkdir -p publish

echo "🔨 Création de l'exécutable autonome..."

# Publication pour Linux x64 (Ubuntu compatible)
if dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -o publish/; then
    echo "✅ Publication réussie !"
    echo ""
    echo "📁 L'exécutable se trouve dans le dossier 'publish/'"
    echo "🚀 Pour l'exécuter :"
    echo "   chmod +x publish/CalculateurJoules"
    echo "   ./publish/CalculateurJoules"
    echo ""
    
    # Rendre l'exécutable... exécutable
    chmod +x publish/CalculateurJoules
    
    echo "📊 Taille de l'exécutable :"
    ls -lh publish/CalculateurJoules
    echo ""
    
    echo "✨ L'application est prête à être distribuée !"
    echo "   Cet exécutable fonctionne sur Ubuntu et autres distributions Linux x64"
    echo "   sans nécessiter l'installation de .NET sur le système cible."
    
else
    echo "❌ Erreur lors de la publication."
    exit 1
fi