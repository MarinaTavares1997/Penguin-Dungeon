using UnityEngine;

namespace PenguinDungeon.Player
{
    public class PlayerMovementJoystick : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D playerRb;
        public Joystick joystick;

        private float speedBoost;
        private float boostTimer;
        private bool boosting;

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();

            speedBoost = 5;
            boostTimer = 0;
            boosting = false;
        }

        void Update()
        {
            if(joystick.joyVec != Vector2.zero)
            {
                playerRb.velocity = new Vector2(joystick.joyVec.x * speed, joystick.joyVec.y * speed);
            }
            else
            {
                playerRb.velocity = Vector2.zero;
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
#if UNITY_EDITOR
            var horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal != 0)
            {
                joystick.joyVec.x = horizontal;
            }
            
            var vertical = Input.GetAxisRaw("Vertical");

            if (vertical != 0)
            {
                joystick.joyVec.y = vertical;
            }
#endif
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
