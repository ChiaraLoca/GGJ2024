using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
    
{
    /*[SerializeField] float maxOffsetUp;
    [SerializeField] float maxOffsetDown;
    [SerializeField] float maxOffsetLeft;
    [SerializeField] float maxOffsetRight;*/
    [SerializeField] int stackValue;
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    Vector3 startingPosition;

    public int StackValue { get => stackValue; }

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        IdleFloat();
    }

    private void IdleFloat()
    {
        
        float xcount = UnityEngine.Random.Range(-speed, speed);
 
        float ycount = UnityEngine.Random.Range(-speed, speed);
        transform.position += new Vector3(xcount, ycount, 0);
        Vector3 movementVector = transform.position - startingPosition;

        if (movementVector.magnitude > maxDistance)
        {
            transform.position = startingPosition + movementVector.normalized*maxDistance;
        }
        /*
        if (movement.y > maxOffsetUp)
        {
            transform.position = new Vector3(transform.position.x, startingPosition.y+maxOffsetUp);
        }
        if (movement.y < maxOffsetDown)
        {
            transform.position = new Vector3(transform.position.x, startingPosition.y- maxOffsetDown);
        }
        if (movement.x > maxOffsetRight)
        {
            transform.position = new Vector3(transform.position.x+maxOffsetRight, transform.position.y);
        }
        if (movement.x < maxOffsetLeft)
        {
            transform.position = new Vector3(transform.position.x-maxOffsetLeft, transform.position.y);
        }*/

    }
}
