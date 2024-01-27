using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class KeywordUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _showCommand;
    [SerializeField] public TMP_InputField _inputField;

    private void Start()
    {
        _inputField.onSubmit.AddListener((string str)=> {
            Submit(str); 
        });
    }
    private void Submit(string str)
    {
        KeywordRecognizerManager.Instance.Add(str);
        _showCommand.text = str.ToUpper();
    }
}
