#!/bin/bash

# Script simple pour compiler et exécuter le calculateur
# Compatible avec .NET ou Mono selon ce qui est disponible

echo "🚀 Calculateur d'énergie en joules pour projectiles"
echo "=================================================="

# Tentative avec .NET Core/5+
if command -v dotnet &> /dev/null; then
    echo "✅ .NET détecté - Utilisation de .NET"
    echo ""
    if [ -f "CalculateurJoules.csproj" ]; then
        dotnet run --configuration Release
    else
        echo "❌ Fichier .csproj manquant"
        exit 1
    fi
# Tentative avec Mono
elif command -v mcs &> /dev/null && command -v mono &> /dev/null; then
    echo "✅ Mono détecté - Utilisation de Mono"
    echo ""
    
    # Compilation si nécessaire
    if [ ! -f "CalculateurJoules.exe" ] || [ "CalculateurJoulesMono.cs" -nt "CalculateurJoules.exe" ]; then
        echo "🔨 Compilation..."
        mcs -out:CalculateurJoules.exe CalculateurJoulesMono.cs
        if [ $? -ne 0 ]; then
            echo "❌ Erreur de compilation"
            exit 1
        fi
        echo "✅ Compilation réussie"
        echo ""
    fi
    
    # Exécution
    mono CalculateurJoules.exe
else
    echo "❌ Ni .NET ni Mono n'est installé sur ce système."
    echo ""
    echo "Pour installer .NET sur Ubuntu :"
    echo "  sudo apt update"
    echo "  sudo apt install -y dotnet-sdk-8.0"
    echo ""
    echo "Pour installer Mono sur Ubuntu :"
    echo "  sudo apt update"
    echo "  sudo apt install -y mono-complete"
    echo ""
    exit 1
fi