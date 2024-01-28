using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    [SerializeField] float horizontalAcceleration;
    [SerializeField] float horizontalStartingMaxSpeed;
    [SerializeField] float horizontalMaxSpeed;
    [SerializeField] float baseSpeedIncrease;
    [SerializeField] int jumpSpeed;
    [SerializeField] bool dead = false;
    [SerializeField] Animator animator;
    [SerializeField] StaticAudioSourceManager audioManager;
    [SerializeField] SpriteRenderer fadeIn;
    bool isJumping = false;
    Rigidbody2D rigidbody2D;
    Collider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D.velocity = new Vector2(horizontalAcceleration, 0f);

        StartCoroutine(fadeInIE(1,2));
    }

    IEnumerator fadeInIE(float timeAllBlack, float timeFade)
    {
        fadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeAllBlack);


        for (float t = 0; t < 1; t += Time.deltaTime / timeFade)
        {
            fadeIn.color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        //Destroy(fadeIn);
        fadeIn.gameObject.SetActive(false);

    }

    IEnumerator fadeOutIE(float timeAllBlack, float timeFade)
    {
        fadeIn.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeAllBlack);

          // scale of the object at the end of the animation

        for (float t = 0; t < 1; t += Time.deltaTime / timeFade)
        {
            audioManager.MusicVolume(t);

            fadeIn.color = new Color(0, 0, 0,t);
            yield return null;
        }

        yield return new WaitForSeconds(timeAllBlack);
        //Destroy(fadeIn);
        fadeIn.gameObject.SetActive(false);

        SceneManager.LoadScene("0_Menu", LoadSceneMode.Single);
    }

    void Death() {
        StartCoroutine(fadeOutIE(1,2));
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

            Death();

        }
    }

    public void Jump(bool voiceTrigger = false)
    {
        if (Input.GetKeyUp("space") || voiceTrigger)
        {
            rigidbody2D.velocity += new Vector2(0f, jumpSpeed);

            animator.SetTrigger("Jump");
            isJumping = true;
            audioManager.jump();

            gameStatus.instance.nCorrectJump++;
            gameStatus.instance.calculateScore();
        }

        
    }

    private void Run()
    {
        rigidbody2D.velocity += new Vector2(horizontalAcceleration, 0f);
        if (rigidbody2D.velocity.x>horizontalMaxSpeed) {
            rigidbody2D.velocity = new Vector2(horizontalMaxSpeed, rigidbody2D.velocity.y);
        }
        float _speed = rigidbody2D.velocity.x*1/65;

        
        animator.SetFloat("Blend",_speed);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.GetComponent<Floor>()!=null)
        {
            if (isJumping)
            {
                animator.SetTrigger("EndJump");
                isJumping = false;
            }
        }
    }

    private void obstacleImpact(Collider2D collision)
    {
        audioManager.obstacleHit();
        modifySpeed(collision.gameObject.GetComponent<obstacle>().StackValue);
        PsychCounter.Instance.DeleteMushrooms();
        collision.enabled = false;
    }

    private void modifySpeed(int v)
    {
        gameStatus.instance.SpeedStack += v;
        horizontalMaxSpeed = gameStatus.instance.SpeedStack * baseSpeedIncrease;
    }

    private void collectMushroom(Collider2D collision)
    {
        audioManager.mushroom();
        gameStatus.instance.Mushrooms++;
        PsychCounter.Instance.AddMushrooms();
        CheckSoglia();
        modifySpeed(collision.gameObject.GetComponent<mushroom>().StackValue);
        collision.gameObject.SetActive(false);
    }

    private void CheckSoglia()
    {
        switch(gameStatus.instance.SogliaAttuale)
        {
            case 1:
                {
                    if (PsychCounter.Instance.GetMushrooms() >= gameStatus.instance.primaSoglia)
                    {
                        gameStatus.instance.ChangeStatus(2);
                    }
                    break;
                }
            case 2:
                {
                    if (PsychCounter.Instance.GetMushrooms() >= gameStatus.instance.secondaSoglia)
                    {
                        gameStatus.instance.ChangeStatus(3);
                    }
                    if (PsychCounter.Instance.GetMushrooms() < gameStatus.instance.primaSoglia)
                    {
                        gameStatus.instance.ChangeStatus(1);
                    }
                    break;
                }
            case 3:
                {
                 
                    if (PsychCounter.Instance.GetMushrooms() < gameStatus.instance.secondaSoglia)
                    {
                        gameStatus.instance.ChangeStatus(2);
                    }
                    break;
                }
        }
    }
}

