using BallBlastReplika.Combats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class BallController : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float maxhealht = 99f;
        [SerializeField] private float phealth = 0f;
        [SerializeField] private bool _moveDirection = true;

        private bool _isMoving;
        [Header("Other")]
        TextMeshPro healthText;
        [SerializeField] private GameObject ballBlastParticlePrefab;
        [SerializeField] private GameObject[] ballPrefabs;
        [SerializeField] private AudioClip _ballGroundClip;
        [SerializeField] private SpriteRenderer _ballRenderer;
        [SerializeField] private Color[] colors;
        [Header("Physics")]
        Rigidbody2D _rigidbody2d;


        private void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
            healthText = GetComponentInChildren<TextMeshPro>();
            _ballRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void Start()
        {
            healthText.text = maxhealht.ToString();
            BallColor();
        }
        private void Update()
        {
            healthText.text = maxhealht.ToString();
            if (maxhealht <= phealth)
            {
                GameObject blastParticle = Instantiate(ballBlastParticlePrefab, transform.position, Quaternion.identity);
                ParticleSystem particle = blastParticle.GetComponentInChildren<ParticleSystem>();
                particle.Play();
                Die();
            }
        }
        private void FixedUpdate()
        {
            float moveHorizontal = moveSpeed * (_moveDirection ? 1 : -1);
            Vector2 movement = new Vector2(moveHorizontal, _rigidbody2d.velocity.y);
            _rigidbody2d.velocity = movement;
        }
        private void Die()
        {
            if (gameObject.layer == LayerMask.NameToLayer("Ball6"))
            {
                Destroy(this.gameObject);
                float distance = ballPrefabs[4].GetComponent<CircleCollider2D>().radius * 0.3f; // Calculate distance based on collider size
                Vector3 newPosLeft = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                Vector3 newPosRight = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                Instantiate(ballPrefabs[4], newPosLeft, Quaternion.identity);
                GameObject ball4 = Instantiate(ballPrefabs[4], newPosRight, Quaternion.identity);
            }
            if (gameObject.layer == LayerMask.NameToLayer("Ball5"))
            {
                Destroy(this.gameObject);
                float distance = ballPrefabs[3].GetComponent<CircleCollider2D>().radius * 0.3f; // Calculate distance based on collider size
                Vector3 newPosLeft = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                Vector3 newPosRight = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                Instantiate(ballPrefabs[3], newPosLeft, Quaternion.identity);
                GameObject ball3 = Instantiate(ballPrefabs[3], newPosRight, Quaternion.identity);

            }
            if (gameObject.layer == LayerMask.NameToLayer("Ball4"))
            {
                Destroy(this.gameObject);
                float distance = ballPrefabs[2].GetComponent<CircleCollider2D>().radius * 0.3f; // Calculate distance based on collider size
                Vector3 newPosLeft = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                Vector3 newPosRight = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                Instantiate(ballPrefabs[2], newPosLeft, Quaternion.identity);
                GameObject ball2 = Instantiate(ballPrefabs[2], newPosRight, Quaternion.identity);
            }
            if (gameObject.layer == LayerMask.NameToLayer("Ball3"))
            {
                Destroy(this.gameObject);
                float distance = ballPrefabs[1].GetComponent<CircleCollider2D>().radius * 0.3f; // Calculate distance based on collider size
                Vector3 newPosLeft = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                Vector3 newPosRight = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                Instantiate(ballPrefabs[1], newPosLeft, Quaternion.identity);
                GameObject ball1 = Instantiate(ballPrefabs[1], newPosRight, Quaternion.identity);
            }
            if (gameObject.layer == LayerMask.NameToLayer("Ball2"))
            {
                Destroy(this.gameObject);
                float distance = ballPrefabs[0].GetComponent<CircleCollider2D>().radius * 0.3f; // Calculate distance based on collider size
                Vector3 newPosLeft = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
                Vector3 newPosRight = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                Instantiate(ballPrefabs[0], newPosLeft, Quaternion.identity);
                GameObject ball0 = Instantiate(ballPrefabs[0], newPosRight, Quaternion.identity);
            }
            //if (gameObject.layer == LayerMask.NameToLayer("Ball6"))
            //{
            //    Destroy(this.gameObject);
            //    Instantiate(ballPrefabs[4], transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), Quaternion.identity);
            //    GameObject ball4 = Instantiate(ballPrefabs[4], transform.position = new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity);
            //    ball4.GetComponent<BallController>()._moveDirection = !_moveDirection;
            //}
            //if (gameObject.layer == LayerMask.NameToLayer("Ball5"))
            //{
            //    Destroy(this.gameObject);
            //    Instantiate(ballPrefabs[3], transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), Quaternion.identity);
            //    GameObject ball3 = Instantiate(ballPrefabs[3], transform.position = new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity);
            //    ball3.GetComponent<BallController>()._moveDirection = !_moveDirection;
            //}
            //if (gameObject.layer == LayerMask.NameToLayer("Ball4"))
            //{
            //    Destroy(this.gameObject);
            //    Instantiate(ballPrefabs[2], transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), Quaternion.identity);
            //    GameObject ball2 = Instantiate(ballPrefabs[2], transform.position = new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity);
            //    ball2.GetComponent<BallController>()._moveDirection = !_moveDirection;
            //}
            //if (gameObject.layer == LayerMask.NameToLayer("Ball3"))
            //{
            //    Destroy(this.gameObject);
            //    Instantiate(ballPrefabs[1], transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), Quaternion.identity);
            //    GameObject ball1 = Instantiate(ballPrefabs[1], transform.position = new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity);
            //    ball1.GetComponent<BallController>()._moveDirection = !_moveDirection;
            //}
            //if (gameObject.layer == LayerMask.NameToLayer("Ball2"))
            //{
            //    Destroy(this.gameObject);
            //    Instantiate(ballPrefabs[0], transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), Quaternion.identity);
            //    GameObject ball = Instantiate(ballPrefabs[0], transform.position = new Vector3(transform.position.x + 3, transform.position.y), Quaternion.identity);
            //    ball.GetComponent<BallController>()._moveDirection = !_moveDirection;
            //}
            if (gameObject.layer == LayerMask.NameToLayer("Ball1"))
            {
                Destroy(this.gameObject);
            }
        }
        private void BallColor()
        {
            int randomColorIndex = Random.Range(0, 5);
            if(randomColorIndex == 0)
            {
                _ballRenderer.color = new Color32(252, 122, 30,255);
            }
            else if(randomColorIndex == 1)
            {
                _ballRenderer.color = new Color32(69, 31, 85, 255);
            } 
            else if(randomColorIndex==2)
            {
                _ballRenderer.color= new Color32(114,78,145,255);
            }
            else if(randomColorIndex==3)
            {
                _ballRenderer.color = new Color(229,79,109,255);
            }
            else
            {
                _ballRenderer.color = new Color32(248, 198, 48, 255);
            }
        }
        public void TakeDamage(int damage)
        {
            maxhealht -= damage;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 10);
                CameraShakeController camshake = Camera.main.GetComponent<CameraShakeController>();
                camshake.Shake();
                SoundManagerController.instance.PlayEnemySound(_ballGroundClip);
            }
            else
            {
                _moveDirection = !_moveDirection;
            }
        }
    }
}