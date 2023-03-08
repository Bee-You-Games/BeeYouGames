SET mypath=%~dp0

set projectPath=%1
set outputPath=%2
set buildTarget=%3

call :joinpath %mypath% %projectPath%
set projectPathFull=%Result%
echo %projectPathFull%

call :joinpath %mypath% %logFile%
set logPathFull=%Result%
echo %logPathFull%

call :joinpath %mypath% %outputPath%
set outputPathFull=%Result%
echo %outputPath%

Unity -quit -batchmode -buildTarget Android -projectPath %projectPathFull% -logFile "log.txt" -executeMethod CICDUtils.Builder.BuildProject -outputPath %outputPathFull% -targetPlatform %buildTarget%

:joinpath
set Path1=%~1
set Path2=%~2
if {%Path1:~-1,1%}=={\} (set Result=%Path1%%Path2%) else (set Result=%Path1%\%Path2%)
goto :eof
