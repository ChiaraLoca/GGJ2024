
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordRecognizerManager : MonoBehaviour
{
    public static KeywordRecognizerManager Instance;
    private bool isUsable = true;

    public WordManager _wordManager = new WordManager();
    private void Awake()
    {
        Instance = this;
    }
    //0 jump 1 start
  
    private List<string> _keyWordList;

    private KeywordRecognizer m_Recognizer;

    public event Action<String,int> PhraseRecognized;

    void Start()
    {
       
        try
        {
            m_Recognizer = new KeywordRecognizer(_keyWordList.ToArray());
        }
        catch (Exception)
        {
            Debug.Log("Speech Recognition NOT supported");
            isUsable = false;
        }

        if (isUsable)
        {
            m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
            _keyWordList = new List<String>() { "yes", "start", "settings", "exit" };

            m_Recognizer = new KeywordRecognizer(_keyWordList.ToArray());

            /* foreach (var x in m_Recognizer.Keywords)
             {
                 Debug.Log(x.ToString());
             }*/
            m_Recognizer.Start();
        }
    }

    public bool Add(string s, int index)
    {
        bool res = false;
        if (!_keyWordList.Contains(s) && !_keyWordList[index].Equals(s))
        {
            _keyWordList[index] = s;
            res = true;
        }
        Restart();
        return res;

    }
    public void Restart()
    {
            if (isUsable)
            {
                m_Recognizer.Dispose();
                m_Recognizer = null;
                m_Recognizer = new KeywordRecognizer(_keyWordList.ToArray());
                m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;

                m_Recognizer.Start();
            }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (PhraseRecognized != null)
        {
            int index = _keyWordList.IndexOf(args.text);
            PhraseRecognized.Invoke(args.text, index);
        }
    }

    internal string GetRandomKeyWord(int index)
    {
        string key= _wordManager.GetRandomKeyWord(_keyWordList);
        bool res = Add(key, index);
        if (res)
            return key;
        else
            return "";

       

        
    }
}
public class WordManager
{
    List<Word> _wordList = new List<Word>();

    public WordManager()
    {
        _wordList = new List<Word>() { new Word("yes"), new Word("posa"), new Word("start"), new Word("exit"), new Word("settings"), new Word("scoreggia"), new Word("pillola"),new Word("banana") };
    }

    public void Add(Word s)
    {
        if (!_wordList.Contains(s))
        { _wordList.Add(s); }
    }



    internal string GetRandomKeyWord(List<String> list)
    {
        
        string res = "";
        while (res.Equals(""))
        {
            int index = UnityEngine.Random.Range(0, _wordList.Count);
            string s= _wordList[index].value;
            if (!list.Contains(s.ToLower()))
            {
                res = s;
            }
        }
        return res;
        
    }
}

[Serializable]
public class Word
{
    public string value;

    public Word(string value)
    {
        this.value = value;
    }
}