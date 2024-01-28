using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXScript : MonoBehaviour

    
{
    [SerializeField] GameObject audioFX;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip obstacleHit;
    [SerializeField] AudioClip mushroom;
    AudioSource audioFXSource;
    // Start is called before the first frame update
    void Start()
    {
        audioFXSource = audioFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        audioFXSource.PlayOneShot(jump);
    }

    public void ObstacleHit()
    {
        audioFXSource.PlayOneShot(obstacleHit);

    }

    public void Mushroom()
    {
        audioFXSource.PlayOneShot(mushroom);

    }
}
