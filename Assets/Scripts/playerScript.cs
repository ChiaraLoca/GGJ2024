using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] float horizontalAcceleration;
    [SerializeField] float horizontalStartingMaxSpeed;
    [SerializeField] float horizontalMaxSpeed;
    [SerializeField] float baseSpeedIncrease;
    [SerializeField] int jumpSpeed;
    [SerializeField] bool dead = false;

    Rigidbody2D rigidbody2D;
    Collider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D.velocity = new Vector2(horizontalAcceleration, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        DeathCheck();
    }

    private void DeathCheck()
    {
        if (horizontalMaxSpeed<baseSpeedIncrease && !dead) {
            Debug.Log("DEATH TRIGGER");
            dead= true;
        }
    }

    public void Jump(bool voiceTrigger = false)
    {
        if (Input.GetKeyUp("space") || voiceTrigger)
        {
            rigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }

        
    }

    private void Run()
    {
        rigidbody2D.velocity += new Vector2(horizontalAcceleration, 0f);
        if (rigidbody2D.velocity.x>horizontalMaxSpeed) {
            rigidbody2D.velocity = new Vector2(horizontalMaxSpeed, rigidbody2D.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<mushroom>() != null)
        {
            collectMushroom(collision);
        }

        if (collision.gameObject.GetComponent<obstacle>() != null)
        {
            obstacleImpact(collision);
        }
    }

    private void obstacleImpact(Collider2D collision)
    {
        modifySpeed(collision.gameObject.GetComponent<obstacle>().StackValue);
        collision.enabled = false;
    }

    private void modifySpeed(int v)
    {
        gameStatus.SpeedStack += v;
        horizontalMaxSpeed = gameStatus.SpeedStack * baseSpeedIncrease;
    }

    private void collectMushroom(Collider2D collision)
    {
        gameStatus.Mushrooms++;
        modifySpeed(collision.gameObject.GetComponent<mushroom>().StackValue);
        collision.gameObject.SetActive(false);
    }
}
