using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float moveSpeed = 10f;

        [SerializeField] private float maxLifeTime = 20f;
        protected float _currentTime;
        [SerializeField] private GameObject bulletParticlePrefab;


        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > maxLifeTime)
            {
                KillGameObject();
            }
        }
        private void OnEnable()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * moveSpeed;
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0,12) * moveSpeed,ForceMode2D.Impulse);
        }
        private void KillGameObject()
        {
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                GameObject bulletParticle = Instantiate(bulletParticlePrefab, transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z-1), Quaternion.identity);
                bulletParticle.GetComponentInChildren<ParticleSystem>().Play();
                collision.gameObject.GetComponent<BallController>().TakeDamage(damage);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50f, ForceMode2D.Impulse);
                Destroy(gameObject);
                GameManager.Instance.IncreaseScore();
                GameManager.Instance.IncreaseMoney();
            }
        }
    }

}