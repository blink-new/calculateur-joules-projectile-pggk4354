# Script PowerShell pour compiler le Calculateur Joules Windows
Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Compilation du Calculateur Joules Windows" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Vérification de .NET
Write-Host "[1/4] Vérification de .NET..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host ".NET SDK détecté: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "ERREUR: .NET SDK n'est pas installé ou accessible." -ForegroundColor Red
    Write-Host "Téléchargez .NET 8.0 SDK depuis: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    Read-Host "Appuyez sur Entrée pour quitter"
    exit 1
}
Write-Host ""

# Nettoyage des anciens builds
Write-Host "[2/4] Nettoyage des anciens builds..." -ForegroundColor Yellow
if (Test-Path "bin") { Remove-Item -Recurse -Force "bin" }
if (Test-Path "obj") { Remove-Item -Recurse -Force "obj" }
if (Test-Path "publish") { Remove-Item -Recurse -Force "publish" }
Write-Host "Nettoyage terminé." -ForegroundColor Green
Write-Host ""

# Compilation en mode Release
Write-Host "[3/4] Compilation en mode Release..." -ForegroundColor Yellow
$buildResult = dotnet build CalculateurJoulesWindows.csproj -c Release --verbosity minimal
if ($LASTEXITCODE -ne 0) {
    Write-Host "ERREUR: Échec de la compilation." -ForegroundColor Red
    Read-Host "Appuyez sur Entrée pour quitter"
    exit 1
}
Write-Host "Compilation réussie." -ForegroundColor Green
Write-Host ""

# Publication en exécutable autonome 64 bits
Write-Host "[4/4] Création de l'exécutable Windows 64 bits..." -ForegroundColor Yellow
$publishResult = dotnet publish CalculateurJoulesWindows.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishReadyToRun=true -o publish
if ($LASTEXITCODE -ne 0) {
    Write-Host "ERREUR: Échec de la publication." -ForegroundColor Red
    Read-Host "Appuyez sur Entrée pour quitter"
    exit 1
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host " COMPILATION TERMINÉE AVEC SUCCÈS!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""

# Informations sur le fichier créé
$exePath = "publish\CalculateurJoulesWindows.exe"
if (Test-Path $exePath) {
    $fileInfo = Get-Item $exePath
    $fileSizeMB = [math]::Round($fileInfo.Length / 1MB, 2)
    
    Write-Host "L'exécutable a été créé dans le dossier 'publish':" -ForegroundColor Cyan
    Write-Host "- CalculateurJoulesWindows.exe (Windows 64 bits)" -ForegroundColor White
    Write-Host ""
    Write-Host "Taille du fichier: $fileSizeMB MB ($($fileInfo.Length) octets)" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Vous pouvez maintenant:" -ForegroundColor Cyan
    Write-Host "1. Exécuter: publish\CalculateurJoulesWindows.exe" -ForegroundColor White
    Write-Host "2. Distribuer le fichier .exe (aucune installation requise)" -ForegroundColor White
    Write-Host "3. Copier sur n'importe quel PC Windows 64 bits" -ForegroundColor White
    Write-Host ""
    
    # Proposition de lancement
    $launch = Read-Host "Voulez-vous lancer l'application maintenant? (O/N)"
    if ($launch -eq "O" -or $launch -eq "o" -or $launch -eq "Y" -or $launch -eq "y") {
        Write-Host "Lancement de l'application..." -ForegroundColor Green
        Start-Process $exePath
    }
} else {
    Write-Host "ERREUR: Le fichier exécutable n'a pas été trouvé." -ForegroundColor Red
}