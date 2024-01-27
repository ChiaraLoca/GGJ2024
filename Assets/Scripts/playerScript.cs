using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] float horizontalAcceleration;
    [SerializeField] int speedStack = 1;
    [SerializeField] float horizontalStartingMaxSpeed;
    [SerializeField] float horizontalMaxSpeed;
    [SerializeField] int mushrooms = 0;
    [SerializeField] int mushroomsMax;
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

    private void Jump()
    {
        if (Input.GetKeyUp("space"))
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
        speedStack += v;
        horizontalMaxSpeed = speedStack * baseSpeedIncrease;
    }

    private void collectMushroom(Collider2D collision)
    {
        mushrooms++;
        modifySpeed(collision.gameObject.GetComponent<mushroom>().StackValue);
        collision.gameObject.SetActive(false);
    }
}
