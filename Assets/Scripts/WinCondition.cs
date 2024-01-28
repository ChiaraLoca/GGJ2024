using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerScript>() != null)
        {
            Debug.Log("Won");
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);

        }
    }
}
