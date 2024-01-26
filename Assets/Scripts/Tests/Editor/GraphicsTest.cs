using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Editor
{
    public sealed class GraphicsTest
    {
        private static Color[] _colorsTestCase =
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.white,
        };

        [TestCaseSource(nameof(_colorsTestCase))]
        public void GraphicsBlitTest(Color color)
        {

            var src = new Texture2D(1, 1);
            src.SetPixel(0, 0, color);
            src.Apply();
            var dst = new RenderTexture(1, 1, 0);
            Graphics.Blit(src, dst);

            RenderTexture.active = dst;
            var textureForRead = new Texture2D(1, 1);
            textureForRead.ReadPixels(new Rect(0, 0, 1, 1), 0, 0);
            textureForRead.Apply();

            Assert.AreEqual(color ,textureForRead.GetPixel(0, 0));
        }
    }
}
