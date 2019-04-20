if [ $1"x" = x ]
then
  echo "need message"
else
  git add .
  git commit -m $1
  if [ $2"x" = x ]
  then
    echo "no pushing"
  else
    git push origin master
  fi
fi
