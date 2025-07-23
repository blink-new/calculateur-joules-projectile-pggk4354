#!/bin/bash

# Script de compilation et exécution pour Ubuntu
# Calculateur d'énergie en joules pour projectiles

echo "🔧 Compilation du calculateur d'énergie en joules..."
echo "=================================================="

# Vérification de l'installation de .NET
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET n'est pas installé sur ce système."
    echo ""
    echo "Pour installer .NET sur Ubuntu, exécutez les commandes suivantes :"
    echo ""
    echo "sudo apt update"
    echo "sudo apt install -y dotnet-sdk-8.0"
    echo ""
    echo "Ou visitez : https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu"
    exit 1
fi

# Affichage de la version de .NET
echo "✅ Version de .NET détectée :"
dotnet --version
echo ""

# Compilation du projet
echo "🔨 Compilation en cours..."
if dotnet build --configuration Release; then
    echo "✅ Compilation réussie !"
    echo ""
    
    # Exécution du programme
    echo "🚀 Lancement du calculateur..."
    echo "=================================================="
    echo ""
    dotnet run --configuration Release
else
    echo "❌ Erreur lors de la compilation."
    exit 1
fi