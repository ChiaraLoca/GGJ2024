using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateMarciapysis : MonoBehaviour
{
    [SerializeField] private int nPezzi;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool canValidate=true;


    /*private void OnValidate()
    {
        if (prefab != null && canValidate)
        {
            Debug.Log("DuplicateMarciapysis");
                
                for (int i = 0; i < nPezzi; i++)
                {
                    GameObject newInstance = Instantiate(prefab, transform);
                    newInstance.transform.position = new Vector3(newInstance.GetComponent<SpriteRenderer>().size.x * i, 0, 0);
                    newInstance.name = i + "_Floor";
                }
            
        }
    }*/
}


