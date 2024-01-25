using UnityEngine;
using NUnit.Framework;

namespace Tests.Runtime
{
    public sealed class RuntimeTests
    {
        [Test]
        public void RuntimeTest()
        {
            var gameObject = new GameObject();
            Assert.IsNotNull(gameObject);
        }
    }
}
