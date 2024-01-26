using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Tests.Editor
{
    public sealed class RenderTextureTest
    {
        [SetUp]
        public void SetUp()
        {
            AssetDatabase.CreateFolder("Assets", "Temp");
        }

        [Test]
        public void CreateRenderTextureTest()
        {
            var renderTexture = new RenderTexture(1, 1, 0);
            Assert.IsNotNull(renderTexture);
        }

        [Test]
        public void SaveRenderTextureTest()
        {
            var renderTexture = new RenderTexture(1, 1, 0);
            AssetDatabase.CreateAsset(renderTexture, "Assets/Temp/RenderTexture.asset");
            AssetDatabase.SaveAssets();

            var loadedRenderTexture = AssetDatabase.LoadAssetAtPath<RenderTexture>("Assets/Temp/RenderTexture.asset");
            Assert.IsNotNull(loadedRenderTexture);
        }

        [TearDown]
        public void TearDown()
        {
            AssetDatabase.DeleteAsset("Assets/Temp");
        }
    }
}
