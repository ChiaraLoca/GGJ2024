using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    public static MenuUi Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private ButtonBehaviour _startButton;
    [SerializeField] private ButtonBehaviour _settingsButton;
    [SerializeField] private ButtonBehaviour _exitButton;

    

    private void Start()
    {
        _startButton.Create(StartButtonClick);
        _settingsButton.Create(SettingsButtonClick);
        _exitButton.Create(ExitButtonClick);


    }

    public void StartButtonClick()
    {
        Debug.Log("Start");
    }

    public void SettingsButtonClick()
    {
        Debug.Log("Settings");
    }

    public void ExitButtonClick()
    {
        Debug.Log("Settings");
    }

}
