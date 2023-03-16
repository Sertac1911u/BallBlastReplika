using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class WheelController : MonoBehaviour
    {
        bool _isMoving;
        PlayerController _controller;
        public GameObject wheel, wheel2;
        private void Start()
        {
            _controller = GetComponent<PlayerController>();
        }
        private void Update()
        {
            _isMoving = _controller._isMoving;
            if (_isMoving)
            {
                wheel.transform.Rotate(Vector3.forward * Time.deltaTime * 360f);
                wheel2.transform.Rotate(Vector3.forward * Time.deltaTime * 360f);
            }
        }
    }

}