#! usr/bin/bash

git add .

echo "Was hast du gemacht?"

read commit

git commit -m $commit

git push

echo "Enter any key
read stop
