using UnityEngine;

namespace Runtime
{
    public sealed class RandomObjectRotation : MonoBehaviour
    {
        private Vector3 rotationPerSecond = Vector3.zero;
        private Vector3 targetRotationPerSecond = Vector3.zero;
        private Vector3 rotationChangingVelocity = Vector3.zero;

        private float nextRetargetTime;

        private void Update()
        {
            if (Time.time > nextRetargetTime)
            {
                targetRotationPerSecond =
                    new Vector3(Random.value, Random.value, Random.value) * 720 - Vector3.one * 360;
                nextRetargetTime = Time.time + Random.Range(1f, 5f);
            }

            rotationPerSecond = Vector3.SmoothDamp(rotationPerSecond, targetRotationPerSecond,
                ref rotationChangingVelocity, 1f);

            transform.Rotate(rotationPerSecond * Time.deltaTime);
        }
    }
}
