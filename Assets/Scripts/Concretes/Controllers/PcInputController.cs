using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class PcInputController
    {
        public float moveHorizontal => Input.GetAxisRaw("Horizontal");
        public bool _inputSpace =>Input.GetKey(KeyCode.Space);
        public bool _inputT => Input.GetKey(KeyCode.T);
        public bool _inputR => Input.GetKey(KeyCode.R);
    }

}