using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        public float delay = 0f;

        private void Start()
        {
            Destroy(gameObject, delay);
        }
    }

}