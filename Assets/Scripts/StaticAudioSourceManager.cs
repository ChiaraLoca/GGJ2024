using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAudioSourceManager : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] AudioClip track1;
    [SerializeField] AudioClip track2;
    [SerializeField] AudioClip track3;
    [SerializeField] GameObject fx;
    // Start is called before the first frame update
    void Start()
    {
        track(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void track(int trackIndex)
    {
        AudioSource musicAudioSource = music.GetComponent<AudioSource>();

        switch (trackIndex)
        {
            case 1:
                musicAudioSource.Stop();
                musicAudioSource.clip = track1;
                musicAudioSource.loop = true;
                musicAudioSource.Play();
                break;
            case 2:
                musicAudioSource.Stop();
                musicAudioSource.clip = track2;
                musicAudioSource.loop = true;
                musicAudioSource.Play();
                break;
            case 3:
                musicAudioSource.Stop();
                musicAudioSource.clip = track3;
                musicAudioSource.loop = true;
                musicAudioSource.Play();
                break;
            
        }
    }
}
