using UnityEngine;
using NUnit.Framework;

namespace Tests.Editor
{
    public sealed class EditorTests
    {
        [Test]
        public void EditorTest()
        {
            var gameObject = new GameObject();
            Assert.IsNotNull(gameObject);
        }
    }
}
