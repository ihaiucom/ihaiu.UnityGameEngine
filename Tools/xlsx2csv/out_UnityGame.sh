#!/bin/sh
cd `dirname $0`
xlsxpath='../../svn/config'
csvpath='../../UnityGame/Assets/Game/Config'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath

xlsxpath='../../svn/config/Client'
csvpath='../../UnityGame/Assets/Game/Config/Client'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath

xlsxpath='../../svn/config/Common'
csvpath='../../UnityGame/Assets/Game/Config/Common'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath

read -n 1 -p 'Press any key to exit...' INP 
if [[ $INP != '' ]] ; then 
    echo -ne '
' 
fi 