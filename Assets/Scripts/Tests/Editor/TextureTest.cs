using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Tests.Editor
{
    public class TextureTest
    {
        [SetUp]
        public void SetUp()
        {
            AssetDatabase.CreateFolder("Assets", "Temp");
        }

        [Test]
        public void CreateTextureTest()
        {
            var texture = new Texture2D(1, 1);
            Assert.IsNotNull(texture);
        }

        [Test]
        public void SaveTextureTest()
        {
            var texture = new Texture2D(1, 1);
            AssetDatabase.CreateAsset(texture, "Assets/Temp/Texture.asset");
            AssetDatabase.SaveAssets();

            var loadedTexture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Temp/Texture.asset");
            Assert.IsNotNull(loadedTexture);
        }

        [Test]
        public void ReadAndWriteTexturePixelTest()
        {
            var texture = new Texture2D(2, 2);

            texture.SetPixel(0, 0, Color.red);
            texture.SetPixel(1, 0, Color.green);
            texture.SetPixel(0, 1, Color.blue);
            texture.SetPixel(1, 1, Color.white);

            texture.Apply();

            Assert.AreEqual(Color.red, texture.GetPixel(0, 0));
            Assert.AreEqual(Color.green, texture.GetPixel(1, 0));
            Assert.AreEqual(Color.blue, texture.GetPixel(0, 1));
            Assert.AreEqual(Color.white, texture.GetPixel(1, 1));
        }

        [TearDown]
        public void TearDown()
        {
            AssetDatabase.DeleteAsset("Assets/Temp");
        }
    }
}
