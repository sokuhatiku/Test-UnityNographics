using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tests.Editor
{
    public sealed class BuildTest
    {
        [TestCase(0)]
        [TestCase(32)]
        public void DoBuildTest(int textureSizeOverride)
        {
            var graphicState = SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null ? "nographics" : "withgraphics";

            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();
            EditorUserBuildSettings.overrideMaxTextureSize = textureSizeOverride;
            AssetDatabase.Refresh();
            var options = new BuildPlayerOptions()
            {
                scenes = scenes,
                targetGroup = BuildTargetGroup.Standalone,
                target = BuildTarget.StandaloneWindows64,
                locationPathName = $"Builds/{graphicState}-{textureSizeOverride}/Build.exe"
            };
            var result = BuildPipeline.BuildPlayer(options);

            Assert.AreEqual(BuildResult.Succeeded, result.summary.result);
        }
    }
}
