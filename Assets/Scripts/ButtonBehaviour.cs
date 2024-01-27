using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
   
    [SerializeField] private Button _button;
    [SerializeField] private string _keyWord;
    [SerializeField] private int _indexOfCommand;
    [SerializeField] private TextMeshProUGUI _text;
    UnityAction _realAction;
    public void Create(UnityAction realAction)
    {
        KeywordRecognizerManager.Instance.PhraseRecognized += PhraseRecognized;
        _realAction = realAction;
        _button.onClick.AddListener(BaitClick);

    }

    public void BaitClick()
    {
        string res = KeywordRecognizerManager.Instance.GetRandomKeyWord(_indexOfCommand);
        if (!res.Equals(""))
            _keyWord = res;
        _text.text = _keyWord.ToUpper();
    }

    public void PhraseRecognized(string phrase,int index)
    {
        
        if (phrase.ToLower().Equals(_keyWord.ToLower()) && index== _indexOfCommand)
            _realAction.Invoke();
    }
}