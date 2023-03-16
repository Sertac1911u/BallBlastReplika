using BallBlastReplika.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float moveSpeed = 2.5f;
        [SerializeField] private bool _canMove = true;
        [SerializeField] public bool _isMoving;
        [SerializeField] private bool _isAlive = true;
        [SerializeField] private bool _isDobuleShoot = false;
        [SerializeField] private bool _isTrippleShoot = false;
        [Header("Physics")]
        Rigidbody2D _rigidbody2d;

        [Header("Scripts")]
        PcInputController _inputPc;
        Shoot _shooting;


        private void Awake()
        {
            _rigidbody2d= GetComponent<Rigidbody2D>();
            _inputPc = new PcInputController();
            _shooting = GetComponent<Shoot>();
        }
        private void Update()
        {
            if(_isAlive)
            {
                _canMove= true;
                if(_inputPc._inputSpace)
                {
                    if(_isDobuleShoot)
                    {
                        _shooting.ShootAction2();
                        _isTrippleShoot=false;
                    }
                    if(_isTrippleShoot)
                    {
                        _shooting.ShootAction3();
                        _isDobuleShoot= false;
                    }
                    else
                    {
                        _shooting.ShootAction();
                    }
                }
            }
            else
            {
                _canMove= false;    
            }
            if (!_isAlive) Die();
        }
        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(_inputPc.moveHorizontal, 0);
            if(_canMove)
                _rigidbody2d.velocity= movement.normalized * moveSpeed;
            if(_rigidbody2d.velocity.magnitude>0) _isMoving = true;
            else _isMoving = false;
            if (_rigidbody2d.velocity.magnitude > 0) _isMoving = true;
            else _isMoving = false;
        }
        private void Die()
        {
            Time.timeScale = 0f;
        }
    }   

}