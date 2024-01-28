using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterScript : MonoBehaviour
{
    [SerializeField] float baseSpeed;
    [SerializeField] float maxDistance;
    Vector3 startingPosition;

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
        float speed = baseSpeed * (gameStatus.instance.SogliaAttuale - 1);
        float xcount = UnityEngine.Random.Range(-speed, speed);
        float ycount = UnityEngine.Random.Range(-speed, speed);
        transform.position += new Vector3(xcount, ycount, 0);
        Vector3 movementVector = transform.position - startingPosition;

        if (movementVector.magnitude > maxDistance)
        {
            transform.position = startingPosition + movementVector.normalized * maxDistance;
        }
    }
}
