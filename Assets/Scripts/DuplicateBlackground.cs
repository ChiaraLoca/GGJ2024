using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBlackground : MonoBehaviour
{
    [SerializeField] int nPezzi;
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnValidate()
    {

        for (int i = 0; i < nPezzi; i++)
        {
            GameObject newInstance = Instantiate(prefab, transform);
            newInstance.transform.position = new Vector3(newInstance.GetComponent<SpriteRenderer>().size.x * i, 1.2f, 0);
            newInstance.name = i + "_Back";
        }
    }

}
