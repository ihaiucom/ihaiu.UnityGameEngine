#!/bin/sh
cd `dirname $0`
echo `dirname $0`

rm -rf ./Config/*.csv

xlsxpath='../../svn/config'
csvpath='./Config'
echo $xlsxpath
echo $csvpath
python ../xlsx2csv/xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath

xlsxpath='../../svn/config/Client'
echo $xlsxpath
echo $csvpath
python ../xlsx2csv/xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath



xlsxpath='../../svn/config/Common'
echo $xlsxpath
echo $csvpath
python ../xlsx2csv/xlsx2csv/xlsx2csv.py -i -d ';' -b -r -s 1 $xlsxpath $csvpath

rm -rf ./Config/~*.csv
read -n 1 -p 'Press any key to exit...' INP 
if [[ $INP != '' ]] ; then 
    echo -ne '
' 
fi 