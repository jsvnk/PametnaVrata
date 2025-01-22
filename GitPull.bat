@echo off
:: Premakni se v mapo, kjer je shranjen projekt
cd /d "C:\Users\peter\source\repos\DockerProjekt\PametnaVrata"

:: Preveri, ali je direktorij Git repozitorij
if not exist .git (
    echo Ta mapa ni povezana z Git repozitorijem.
    echo Prekinitev...
    pause
    exit /b
)

:: Povleci najnovejše spremembe iz GitHub in omogoči prepis datotek
echo Povleci spremembe iz GitHub (prepis datotek je omogočen)...
git fetch origin main
git reset --hard origin/main

:: Preveri, ali je bil ukaz uspešen
if %errorlevel% neq 0 (
    echo Napaka pri povleku sprememb iz GitHub.
    echo Prekinitev...
    pause
    exit /b
)

echo Povlečenje in prepis sprememb iz GitHub je bilo uspešno.
pause