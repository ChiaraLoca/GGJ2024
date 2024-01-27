
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordRecognizerManager : MonoBehaviour
{
    public static KeywordRecognizerManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private string[] _keyWord;

    private KeywordRecognizer m_Recognizer;

    public event Action<String> PhraseRecognized;

    void Start()
    {
        _keyWord = new string[1];
        _keyWord[0] = "Yes";
        try
        {
            m_Recognizer = new KeywordRecognizer(_keyWord);
        }
        catch (Exception)
        {
            Debug.Log("Speech Recognition NOT supported");
        }

        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;

        m_Recognizer.Start();
    }

    public void Add(string s)
    {
        _keyWord[0] = s;
        Restart();

    }
    public void Restart()
    {
        m_Recognizer.Dispose();
        m_Recognizer = null;
        m_Recognizer = new KeywordRecognizer(_keyWord);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (PhraseRecognized != null)
            PhraseRecognized.Invoke(args.text);
    }
}