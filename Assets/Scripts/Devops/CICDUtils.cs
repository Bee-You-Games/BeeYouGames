using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
//using UnityEditor.Build.Reporting;

namespace CICDUtils
{
    public static class Builder
    {
        private static string GetArg(string name)
        {
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && args.Length > i + 1)
                {
                    return args[i + 1];
                }
            }
            return null;
        }

        public static void BuildProject()
        {
            string[] defaultScene = GetAllActiveScenes();

            BuildPipeline.BuildPlayer(defaultScene, "D:\\Documents\\Repos\\BeeYouGames\\Builds\\MyGame.apk",
                BuildTarget.Android, BuildOptions.None);



            //Console.WriteLine("Start script Execution");

            //var outputDir = GetArg("-outputPath");
            //Console.WriteLine(outputDir);
            //BuildTarget platform = getBuildTarget(GetArg("-targetPlatform"));
            //Console.WriteLine(platform);


            //BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            //buildPlayerOptions.scenes = GetAllActiveScenes();
            //buildPlayerOptions.locationPathName = "/builds";
            //buildPlayerOptions.target = BuildTarget.StandaloneWindows;
            //buildPlayerOptions.options = BuildOptions.None;

            //BuildPipeline.BuildPlayer(buildPlayerOptions);


            //BuildSummary summary = report.summary;

            //if (summary.result == BuildResult.Succeeded)
            //{
            //    Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            //}

            //if (summary.result == BuildResult.Failed)
            //{
            //    Debug.Log("Build failed");
            //}
        }

        private static BuildTarget getBuildTarget(string pBuildTargetname)
        {
            if (pBuildTargetname.ToLower().Contains("windows64")) {
                return BuildTarget.StandaloneWindows64;
            }

            if (pBuildTargetname.ToLower().Contains("android")) {
                return BuildTarget.Android;
            }

            Console.WriteLine("Unkown Build Target");
            throw new Exception("Unkown Build Target");
        }

        private static string[] GetAllActiveScenes()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            string[] scenes = new string[sceneCount];

            for (int i = 0; i < sceneCount; i++)
            {
                scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
            }

            return scenes;
        }
    }
}
#endif