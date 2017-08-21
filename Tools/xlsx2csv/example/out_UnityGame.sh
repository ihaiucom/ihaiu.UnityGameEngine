#!/bin/sh
cd `dirname $0`
path='../../UnityGame/Assets/Game/Config'
echo $path
python ../xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 . $path
read -n 1 -p 'Press any key to exit...' INP 
if [[ $INP != '' ]] ; then 
    echo -ne '
' 
fi 