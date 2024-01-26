using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

namespace Tests.Editor
{
    public sealed class VideoTest
    {
        private const string VideoFileGuid = "e74adc3befdcae34b8ffd8e19f222edc";

        [Test]
        public void LoadTest()
        {
            var video = AssetDatabase.LoadAssetAtPath<VideoClip>(AssetDatabase.GUIDToAssetPath(VideoFileGuid));
            Assert.IsNotNull(video);

            Assert.AreEqual(2.04d, video.length);
            Assert.AreEqual(51, video.frameCount);
            Assert.AreEqual(1280, video.width);
            Assert.AreEqual(720, video.height);
            Assert.AreEqual(25, video.frameRate);
            Assert.AreEqual(0, video.audioTrackCount);
        }

        [Test]
        public void SetToVideoPlayerTest()
        {
            var video = AssetDatabase.LoadAssetAtPath<VideoClip>(AssetDatabase.GUIDToAssetPath(VideoFileGuid));
            var gameObject = new GameObject("VideoPlayer");
            var meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = new Mesh();
            var meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = new Material(Shader.Find("Standard"));
            var videoPlayer = gameObject.AddComponent<VideoPlayer>();
            videoPlayer.clip = video;

            Assert.AreEqual(video, videoPlayer.clip);
        }
    }
}
