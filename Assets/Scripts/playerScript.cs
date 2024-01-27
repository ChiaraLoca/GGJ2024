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
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D.velocity = new Vector2(horizontalAcceleration, 0f);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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
            horizontalMaxSpeed = 0f;
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
        PsychCounter.Instance.DeleteMushrooms();
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
        PsychCounter.Instance.AddMushrooms();
        CheckSoglia();
        modifySpeed(collision.gameObject.GetComponent<mushroom>().StackValue);
        collision.gameObject.SetActive(false);
    }

    private void CheckSoglia()
    {
        switch(gameStatus.SogliaAttuale)
        {
            case 1:
                {
                    if (PsychCounter.Instance.GetMushrooms() >= gameStatus.primaSoglia)
                    {
                        gameStatus.ChangeStatus(2);
                    }
                    break;
                }
            case 2:
                {
                    if (PsychCounter.Instance.GetMushrooms() >= gameStatus.secondaSoglia)
                    {
                        gameStatus.ChangeStatus(3);
                    }
                    if (PsychCounter.Instance.GetMushrooms() < gameStatus.primaSoglia)
                    {
                        gameStatus.ChangeStatus(1);
                    }
                    break;
                }
            case 3:
                {
                 
                    if (PsychCounter.Instance.GetMushrooms() < gameStatus.secondaSoglia)
                    {
                        gameStatus.ChangeStatus(2);
                    }
                    break;
                }
        }
    }
}

