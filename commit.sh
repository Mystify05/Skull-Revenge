#! usr/bin/bash

# Ich glaube es funktioniert

git add .

echo "Was hast du gemacht?"

read commit

git commit -m "$commit"

git push

echo "Press any key"

read stop
