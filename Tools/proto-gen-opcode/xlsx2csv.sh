#!/bin/sh
cd `dirname $0`
xlsxpath='./'
csvpath='./'
echo $path
python ../xlsx2csv/xlsx2csv/xlsx2csv.py -i -d ';' -b -s 1 $xlsxpath $csvpath
