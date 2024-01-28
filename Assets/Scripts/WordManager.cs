
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    private void Awake()
    {
        Instance = this;

        //_wordList = new List<Word>() { new Word("yes"), new Word("start"), new Word("setting"), new Word("exit"),  new Word("banana"), new Word("bambini") };
        Load();

        Debug.Log("WordManager: ");
        foreach (Word w in _wordList)
        {
            Debug.Log(w.value);
        }
    }
    List<Word> _wordList = new List<Word>();
    List<Word> _wordListThisGame = new List<Word>();
    List<Word> _correctWordListThisGame = new List<Word>();

    public List<Word> WordListThisGame { get => _wordListThisGame; set => _wordListThisGame = value; }

    public void Load()
    {
        FileInfo file = StramingAssetsManager.GetFileInDirectory("File", "WordList.json");
        String str = File.ReadAllText(file.FullName);
        _wordList = JsonConvert.DeserializeObject<List<Word>>(str);
    }


    public void Save()
    {


        string str = JsonConvert.SerializeObject(_wordList);
        StramingAssetsManager.CreateFile("File", "WordList.json", str);
    }

    public void Add(Word s)
    {
        if (!_wordList.Contains(s))
        { 
            _wordList.Add(s);
            _wordListThisGame.Add(s);
        }
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
    public void OnDestroy()
    {
        Save();
    }

    internal void AddNewCorrectWord(string s)
    {
        Word w = new Word(s);

        if (!_correctWordListThisGame.Contains(w)  && _wordListThisGame.Contains(w)) 
        {
            _correctWordListThisGame.Add(w);
            gameStatus.instance.nCorrectNewWord++;
        }
    }
}
