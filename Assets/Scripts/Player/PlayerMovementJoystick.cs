using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

    void FixedUpdate()
    {
        if(joystick.joyVec.y != 0)
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
