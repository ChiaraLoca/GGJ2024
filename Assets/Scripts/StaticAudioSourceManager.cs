using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAudioSourceManager : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] AudioClip track1;
    [SerializeField] AudioClip track2;
    [SerializeField] AudioClip track3;
    [SerializeField] AudioClip switchTrack;
    [SerializeField] FXScript fx;
    Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        track(1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void track(int trackIndex, bool firstStart)
    {
        AudioSource musicAudioSource = music.GetComponent<AudioSource>();
        AudioClip nextTrack;
        switch (trackIndex)
        {
            case 1:
                nextTrack = track1;
                
                break;
            case 2:
                nextTrack = track2;
                break;
            case 3:
                nextTrack = track3;
                break;
            default:
                nextTrack = track1;
                break;
        }

        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(musicChangeCorutine(musicAudioSource, nextTrack, firstStart));


    }

    private IEnumerator musicChangeCorutine(AudioSource musicAudioSource, AudioClip track, bool firstStart)
    {
        if (!firstStart) {
            musicAudioSource.Stop();
            musicAudioSource.clip = switchTrack;
            musicAudioSource.loop = false;
            musicAudioSource.Play();
            yield return new WaitForSeconds(switchTrack.length);
        }
        musicAudioSource.Stop();
        musicAudioSource.clip = track;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public void jump()
    {
        fx.Jump();
    }

    public void obstacleHit()
    {
        fx.ObstacleHit();
    }

    public void mushroom()
    {
        fx.Mushroom();
    }

    internal void MusicVolume(float t)
    {
        AudioSource musicAudioSource = music.GetComponent<AudioSource>();
        musicAudioSource.volume = t;
    }
}
