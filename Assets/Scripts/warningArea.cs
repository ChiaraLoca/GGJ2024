using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class warningArea : MonoBehaviour
{
    [SerializeField] private obstacle obstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerScript>() != null) {
            obstacle.warningAreaEnter(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<playerScript>() != null)
        {
            obstacle.warningAreaExit(collision);
        }
    }

}
