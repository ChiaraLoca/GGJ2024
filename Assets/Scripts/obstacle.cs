using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class obstacle : MonoBehaviour
{
    [SerializeField] int stackValue;
    private bool playerInWarningArea;
    private bool playerInJumpArea;
    private bool taskComplete = false;

    public int StackValue { get => stackValue; }
    // Start is called before the first frame update
    void Start()
    {
        KeywordRecognizerManager.Instance.PhraseRecognized += PhraseRecognized;
    }
    
    private void PhraseRecognized(string s)
    {
        if (playerInWarningArea)
        {
            taskComplete = true;
        }
        /*
         player in zona di ascolto per me?
        task complete
         */
    }    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void warningAreaEnter(Collider2D collision)
    {
        playerInWarningArea = true;
    }

    public void warningAreaExit(Collider2D collision)
    {
        playerInWarningArea = false;
    }

    public void jumpAreaEnter(Collider2D collision)
    {
        playerInJumpArea = true;
        if (taskComplete)
        {
            collision.gameObject.GetComponent<playerScript>().Jump(true);
        }
    }

    public void jumpAreaExit(Collider2D collision)
    {
        playerInJumpArea = false;
    }
}
