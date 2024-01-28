using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class KeywordUI : MonoBehaviour
{

    public static KeywordUI instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] public TextMeshProUGUI _showCommand;
    [SerializeField] public TMP_InputField _inputField;
    [SerializeField] public Prompt prompt;
    

    private void Start()
    {
        _inputField.onSubmit.AddListener((string str)=> {
            Submit(str); 
        });
        GetComponentInChildren<Prompt>().write("YES");
    }
    private void Submit(string str)
    {
        KeywordRecognizerManager.Instance.Add(str,0);
        //_showCommand.text = str.ToUpper();
        GetComponentInChildren<Prompt>().write(str.ToUpper());
        _inputField.text = "";
        _inputField.ActivateInputField();
    }
}
