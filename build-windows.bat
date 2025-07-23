@echo off
echo ========================================
echo  Compilation du Calculateur Joules Windows
echo ========================================
echo.

REM Vérification de .NET
echo [1/4] Vérification de .NET...
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ERREUR: .NET SDK n'est pas installé ou accessible.
    echo Téléchargez .NET 8.0 SDK depuis: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo .NET SDK détecté: 
dotnet --version
echo.

REM Nettoyage des anciens builds
echo [2/4] Nettoyage des anciens builds...
if exist "bin" rmdir /s /q "bin"
if exist "obj" rmdir /s /q "obj"
if exist "publish" rmdir /s /q "publish"
echo Nettoyage terminé.
echo.

REM Compilation en mode Release
echo [3/4] Compilation en mode Release...
dotnet build CalculateurJoulesWindows.csproj -c Release --verbosity minimal
if %errorlevel% neq 0 (
    echo ERREUR: Échec de la compilation.
    pause
    exit /b 1
)
echo Compilation réussie.
echo.

REM Publication en exécutable autonome 64 bits
echo [4/4] Création de l'exécutable Windows 64 bits...
dotnet publish CalculateurJoulesWindows.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishReadyToRun=true -o publish
if %errorlevel% neq 0 (
    echo ERREUR: Échec de la publication.
    pause
    exit /b 1
)

echo.
echo ========================================
echo  COMPILATION TERMINÉE AVEC SUCCÈS!
echo ========================================
echo.
echo L'exécutable a été créé dans le dossier 'publish':
echo - CalculateurJoulesWindows.exe (Windows 64 bits)
echo.
echo Taille du fichier:
for %%A in (publish\CalculateurJoulesWindows.exe) do echo - %%~zA octets (%%~zA bytes)
echo.
echo Vous pouvez maintenant:
echo 1. Exécuter: publish\CalculateurJoulesWindows.exe
echo 2. Distribuer le fichier .exe (aucune installation requise)
echo 3. Copier sur n'importe quel PC Windows 64 bits
echo.
echo Appuyez sur une touche pour lancer l'application...
pause >nul

REM Lancement de l'application
echo Lancement de l'application...
start "" "publish\CalculateurJoulesWindows.exe"