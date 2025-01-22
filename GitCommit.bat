@echo off
echo Initializing Git repository...
git init

echo Adding .gitignore...
echo ".vs/" > .gitignore
echo "bin/" >> .gitignore
echo "obj/" >> .gitignore
echo "*.log" >> .gitignore
echo "*.vsidx" >> .gitignore

echo Staging changes...
git add .

echo Committing changes...
git commit -m "Nova Verzija"

echo Setting main branch...
git branch -M main

echo Removing existing remote origin...
git remote remove origin 2>nul

echo Adding remote origin...
git remote add origin https://github.com/jsvnk/PametnaVrata.git

echo Pushing changes to GitHub...
git push -u origin main --force

echo Done!
pause
