using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class CameraShakeController : MonoBehaviour
    {
        public float shakeDuration = 0.1f;
        public float shakeMagnitude = 0.5f;

        private Vector3 originalPosition;
        private float elapsed = 0f;

        void Start()
        {
            originalPosition = transform.localPosition;
        }

        void Update()
        {
            if (elapsed < shakeDuration)
            {
                float x = Random.Range(-1f, 1f) * shakeMagnitude;
                float y = Random.Range(-1f, 1f) * shakeMagnitude;

                transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

                elapsed += Time.deltaTime;
            }
            else
            {
                transform.localPosition = originalPosition;
            }
        }

        public void Shake()
        {
            elapsed = 0f;
        }
    }
}