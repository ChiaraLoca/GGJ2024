using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PsychCounter : MonoBehaviour
{

    public static PsychCounter Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] GameObject prefab;
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddMushrooms()
    {
        GameObject newInstance = Instantiate(prefab, transform.GetChild(0));
        //fACCIO COSE
    }
    public void DeleteMushrooms()
    {
        Destroy(transform.GetChild(0).GetChild(transform.GetChild(0).childCount-1));
        //fACCIO COSE
    }
}
