using UnityEngine;
using PenguinDungeon.Core;

namespace PenguinDungeon.Player
{
    public class Player : MonoBehaviour
    {
        public float speed = 5f;
        public Rigidbody2D playerRb;
        public Animator animator;

        private float speedBoost;
        private float boostTimer;
        private bool boosting;

        Vector2 movimento;

        // Start is called before the first frame update
        void Start()
        {
            speedBoost = 5;
            boostTimer = 0;
            boosting = false;

            playerRb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            movimento.x = Input.GetAxisRaw("Horizontal");
            movimento.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("horizontal", movimento.x);
            animator.SetFloat("vertical", movimento.y);
            animator.SetFloat("velocidade", movimento.sqrMagnitude);

            if (movimento != Vector2.zero)
            {
                animator.SetFloat("horizontalidle", movimento.x);
                animator.SetFloat("verticalidle", movimento.y);
            }

            if(boosting)
            {
                boostTimer += Time.deltaTime;
                if(boostTimer >= 5)
                {
                    speedBoost = 5;
                    boostTimer = 0;
                    boosting = false;
                }
            }
            
            playerRb.MovePosition(playerRb.position + movimento * (speedBoost * Time.deltaTime));
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                PlayerManager.isGameOver = true;
                Destroy(gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "SpeedBoost")
            {
                boosting = true;
                speedBoost = 15;
            }
        }
    }
}
