using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        StartCoroutine(CambioScena());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(2f);
        video.Play();
        
    }

    public IEnumerator CambioScena()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("2_Level");

    }
}

