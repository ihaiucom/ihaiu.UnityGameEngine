@echo off

for %%i in (*.xlsx) do (
  echo Converting %%i to ..\..\UnityGame\Assets\Game\Config\%%~ni.csv...
  xlsx2csv\xlsx2csv -i -d ; -s 1 %%i ..\..\UnityGame\Assets\Game\Config\%%~ni.csv
)

pause