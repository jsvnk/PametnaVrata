@echo off
echo Initializing Git repository...
git init

echo Adding .gitignore...
echo # Ignore Visual Studio-specific files > .gitignore
echo .vs/ >> .gitignore
echo bin/ >> .gitignore
echo obj/ >> .gitignore
echo *.user >> .gitignore
echo *.suo >> .gitignore
echo Migrations/ >> .gitignore

echo Removing unwanted files from Git tracking...
git rm -r --cached .vs 2>nul
git rm -r --cached bin 2>nul
git rm -r --cached obj 2>nul
git rm -r --cached Migrations 2>nul

echo Staging changes...
git add .

echo Committing changes...
git commit -m "Updated repository with proper .gitignore settings"

echo Setting main branch...
git branch -M main

echo Removing existing remote origin...
git remote remove origin 2>nul

echo Adding remote origin...
git remote add origin https://github.com/jsvnk/PametnaVrata.git

echo Pushing changes to GitHub...
git push -u origin main

echo Done!
pause
