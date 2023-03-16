using BallBlastReplika.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Combats
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletTrans,bulletTrans2,bulletTrans3,bulletTransParent;
        [SerializeField] private bool _isShooting;
         public float delayProjectile = 2f;
        float _currentDelayTime=0f;
        [SerializeField] private AudioClip _fireClip;
        public Animator muzzleFlash;
        public Animator canonAnim;
        private void Update()
        {
            _currentDelayTime += Time.deltaTime;
            if(_currentDelayTime> delayProjectile )
            {
                _isShooting = true;
                _currentDelayTime= 0f;
            }
        }
        public void ShootAction()
        {
            if(_isShooting)
            {
                GameObject newBullet = Instantiate(bullet, bulletTrans.position, bulletTrans.rotation);
                newBullet.transform.parent = bulletTransParent.transform;
                muzzleFlash.SetTrigger("Flash");
                canonAnim.SetTrigger("isFire");
                SoundManagerController.instance.PlaySound(_fireClip);
                _isShooting= false;
            }
        }
        public void ShootAction2()
        {
            if (_isShooting)
            {
                GameObject newBullet2 = Instantiate(bullet, bulletTrans2.position, bulletTrans2.rotation);
                newBullet2.transform.parent = bulletTransParent.transform;
                GameObject newBullet = Instantiate(bullet, bulletTrans.position, bulletTrans.rotation);
                newBullet.transform.parent = bulletTransParent.transform;
                muzzleFlash.SetTrigger("Flash");
                canonAnim.SetTrigger("isFire");
                SoundManagerController.instance.PlaySound(_fireClip);
                _isShooting = false;
            }
        }
        public void ShootAction3()
        {
            if (_isShooting)
            {
                GameObject newBullet3 = Instantiate(bullet, bulletTrans3.position, bulletTrans3.rotation);
                newBullet3.transform.parent = bulletTransParent.transform;
                GameObject newBullet2 = Instantiate(bullet, bulletTrans2.position, bulletTrans2.rotation);
                newBullet2.transform.parent = bulletTransParent.transform;
                GameObject newBullet = Instantiate(bullet, bulletTrans.position, bulletTrans.rotation);
                newBullet.transform.parent = bulletTransParent.transform;
                muzzleFlash.SetTrigger("Flash");
                canonAnim.SetTrigger("isFire");
                SoundManagerController.instance.PlaySound(_fireClip);
                _isShooting = false;
            }
        }
    }

}