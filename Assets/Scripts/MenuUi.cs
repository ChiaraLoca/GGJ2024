using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("1_Intro");
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
