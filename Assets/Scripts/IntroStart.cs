using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public VideoPlayer video;
    void Start()
    {
        
    }
    private void Awake()
    {
        StartCoroutine(PlayVideo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(1.6f);
        video.Play();
        
    }
}

