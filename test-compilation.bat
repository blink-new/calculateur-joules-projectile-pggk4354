@echo off
echo ========================================
echo  Test de compilation rapide
echo ========================================
echo.

REM Test de .NET
echo Test de .NET SDK...
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ERREUR: .NET SDK non trouvé
    echo Installez .NET 8.0 SDK depuis: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo .NET SDK OK: 
dotnet --version
echo.

REM Test de compilation simple
echo Test de compilation...
dotnet build CalculateurJoulesWindows.csproj -c Release --verbosity quiet
if %errorlevel% neq 0 (
    echo ERREUR: Échec de la compilation
    pause
    exit /b 1
)

echo Compilation OK!
echo.

REM Test de publication
echo Test de publication...
dotnet publish CalculateurJoulesWindows.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o test-publish --verbosity quiet
if %errorlevel% neq 0 (
    echo ERREUR: Échec de la publication
    pause
    exit /b 1
)

echo Publication OK!
echo.

REM Vérification du fichier
if exist "test-publish\CalculateurJoulesWindows.exe" (
    echo ✅ Exécutable créé avec succès!
    for %%A in (test-publish\CalculateurJoulesWindows.exe) do echo Taille: %%~zA octets
    
    REM Nettoyage
    rmdir /s /q "test-publish"
    if exist "bin" rmdir /s /q "bin"
    if exist "obj" rmdir /s /q "obj"
    
    echo.
    echo ========================================
    echo  TOUS LES TESTS RÉUSSIS! ✅
    echo ========================================
    echo.
    echo Vous pouvez maintenant utiliser:
    echo - build-windows.bat (recommandé)
    echo - build-windows.ps1 (PowerShell)
    echo.
) else (
    echo ❌ Erreur: Exécutable non créé
)

pause