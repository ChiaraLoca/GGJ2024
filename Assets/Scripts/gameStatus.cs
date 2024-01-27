using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStatus : MonoBehaviour
{
    [SerializeField] public int mushrooms = 0;
    [SerializeField] public int mushroomsMax;
    [SerializeField] public int speedStack = 1;
    [SerializeField] public int primaSoglia;
    [SerializeField] public int secondaSoglia;
    [SerializeField] public StaticAudioSourceManager audioManager;
    private int sogliaAttuale = 1;
    public int Mushrooms { get => mushrooms; set => mushrooms = value; }
    public int SpeedStack { get => speedStack; set => speedStack = value; }
    public int SogliaAttuale { get => sogliaAttuale; }

    public static gameStatus instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStatus(int status)
    {
        switch(status) 
        {
            case 1:
                {
                    sogliaAttuale = 1;
                    changeMusic(1);
                    changePsych(1);
                    //FARE COSE
                    break;
                }
            case 2:
                {
                    sogliaAttuale = 2;
                    changeMusic(2);
                    changePsych(2);
                    //FARE COSE
                    break;
                }
            case 3:
                {
                    sogliaAttuale = 3;
                    changeMusic(3);
                    changePsych(3);
                    //FARE COSE
                    break;
                }
        }
    }

    private void changePsych(int v)
    {
        
    }

    private void changeMusic(int v)
    {
       audioManager.track(v, false);
    }
}
