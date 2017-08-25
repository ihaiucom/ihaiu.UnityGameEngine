#!/bin/sh
cd `dirname $0`
echo `dirname $0`
xlsxpath='../../../gamemt_doc/config'
csvpath='../../Game/Assets/Game/Config'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ',' -b -s 1 $xlsxpath $csvpath

xlsxpath='../../../gamemt_doc/config/Client'
csvpath='../../Game/Assets/Game/Config/Client'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ',' -b -s 1 $xlsxpath $csvpath



xlsxpath='../../../gamemt_doc/config/Common'
csvpath='../../Game/Assets/Game/Config/Common'
echo $xlsxpath
echo $csvpath
python ./xlsx2csv/xlsx2csv.py -i -d ',' -b -s 1 $xlsxpath $csvpath
read -n 1 -p 'Press any key to exit...' INP 
if [[ $INP != '' ]] ; then 
    echo -ne '
' 
fi 