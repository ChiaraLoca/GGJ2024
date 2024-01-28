using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class obstacle : MonoBehaviour
{
    [SerializeField] int stackValue;
    private Prompt prompt;
    private bool playerInWarningArea;
    private bool playerInJumpArea;
    private bool taskComplete = false;

    public int StackValue { get => stackValue; }
    // Start is called before the first frame update
    void Start()
    {
        KeywordRecognizerManager.Instance.PhraseRecognized += PhraseRecognized;
        prompt = KeywordUI.instance.prompt;

    }
    
    private void PhraseRecognized(string s,int index)
    {
        //index 0 contains command for jump
        if (playerInWarningArea && index==0)
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
        prompt.warningZone(true);
        playerInWarningArea = true;
    }

    public void warningAreaExit(Collider2D collision)
    {
        prompt.warningZone(false);
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
