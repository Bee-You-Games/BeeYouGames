set projectPath=%1
set logFile=%2
set outputPath=%3
set buildTarget=%4

Unity -quit -batchmode -buildTarget Android -projectPath %projectPath% -logFile %logFile% -executeMethod CICDUtils.Builder.BuildProject -outputPath %outputPath% -targetPlatform %buildTarget%

@REM Unity -quit -batchmode -buildTarget Android -projectPath "D:\Documents\Repos\BeeYouGames" -logFile "D:\Documents\Repos\BeeYouGames\CICDscripts\log.txt" -executeMethod CICDUtils.Builder.BuildProject -outputPath "D:\\Documents\\Repos\\BeeYouGames\\Builds\\MyGame3.apk" -targetPlatform "windows64"