using System;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;

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
            var outputDir = GetArg("-outputPath");
            BuildTarget platform = GetBuildTarget(GetArg("-targetPlatform"));

            string[] defaultScene = GetAllActiveScenes();

            BuildPipeline.BuildPlayer(defaultScene, outputDir,
                platform, BuildOptions.None);
        }

        private static BuildTarget GetBuildTarget(string pBuildTargetname)
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