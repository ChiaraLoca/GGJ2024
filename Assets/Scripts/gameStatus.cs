using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStatus : MonoBehaviour
{
    [SerializeField] static int mushrooms = 0;
    [SerializeField] static int mushroomsMax;
    [SerializeField] static int speedStack = 1;
    [SerializeField] public static int primaSoglia;
    [SerializeField] public static int secondaSoglia;
    public static int sogliaAttuale =1;
    public static int Mushrooms { get => mushrooms; set => mushrooms = value; }
    public static int SpeedStack { get => speedStack; set => speedStack = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ChangeStatus(int status)
    {
        switch(status) 
        {
            case 1:
                {
                    sogliaAttuale = 1;

                    //FARE COSE
                    break;
                }
            case 2:
                {
                    sogliaAttuale = 2;

                    //FARE COSE
                    break;
                }
            case 3:
                {
                    sogliaAttuale = 3;

                    //FARE COSE
                    break;
                }
        }
    }
}
