SET mypath=%~dp0

set projectPath=%1
set logFile=%2
set outputPath=%3
set buildTarget=%4

echo %mypath:~0,-1%/%logFile%

Unity -quit -batchmode -buildTarget Android -projectPath "%mypath:~0,-1%/%projectPath%" -logFile %mypath:~0,-1%/%logFile%  -executeMethod CICDUtils.Builder.BuildProject -outputPath %mypath:~0,-1%/%outputPath% -targetPlatform %buildTarget%

@REM Unity -quit -batchmode -buildTarget Android -projectPath "D:\Documents\Repos\BeeYouGames" -logFile "D:\Documents\Repos\BeeYouGames\CICDscripts\log.txt" -executeMethod CICDUtils.Builder.BuildProject -outputPath "D:\\Documents\\Repos\\BeeYouGames\\Builds\\MyGame3.apk" -targetPlatform "windows64"