#!/bin/bash

# Script de compilation avec Mono pour Ubuntu
# Calculateur d'énergie en joules pour projectiles

echo "🔧 Compilation du calculateur d'énergie en joules (Mono)..."
echo "========================================================="

# Vérification de l'installation de Mono
if ! command -v mcs &> /dev/null; then
    echo "❌ Mono n'est pas installé sur ce système."
    echo ""
    echo "Pour installer Mono sur Ubuntu, exécutez les commandes suivantes :"
    echo ""
    echo "sudo apt update"
    echo "sudo apt install -y mono-complete"
    echo ""
    echo "Ou visitez : https://www.mono-project.com/download/stable/#download-lin"
    exit 1
fi

# Affichage de la version de Mono
echo "✅ Version de Mono détectée :"
mono --version | head -1
echo ""

# Compilation du projet avec Mono
echo "🔨 Compilation en cours..."
if mcs -out:CalculateurJoules.exe CalculateurJoulesMono.cs; then
    echo "✅ Compilation réussie !"
    echo ""
    
    # Exécution du programme
    echo "🚀 Lancement du calculateur..."
    echo "=================================================="
    echo ""
    mono CalculateurJoules.exe
else
    echo "❌ Erreur lors de la compilation."
    exit 1
fi