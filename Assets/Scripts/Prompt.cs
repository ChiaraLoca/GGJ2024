using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prompt : MonoBehaviour
{
    [SerializeField] GameObject UICharacter;
    [SerializeField] int characterFontWidth;
    private List<char> chars;
    // Start is called before the first frame update
    void Start()
    {
        chars = new List<char>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void write(string s)
    {
        chars.Clear();
        foreach (Transform t in transform) { 
            Destroy(t.gameObject);
        }
        char[] charArray = s.ToCharArray();
        chars.AddRange(charArray);
        writeArrayToUI();
    }

    private void writeArrayToUI()
    {
        for (int i = 0; i < chars.Count; i++)
        {
            GameObject currentLetter = Instantiate(UICharacter, transform);
            if (chars.Count % 2 == 0)
            {
                currentLetter.transform.localPosition = new Vector3((characterFontWidth * (i - chars.Count / 2)+characterFontWidth/2), 0f, 0f);
            }
            else
            {
                currentLetter.transform.localPosition = new Vector3(characterFontWidth*(i-chars.Count/2), 0f, 0f);
            }
            currentLetter.GetComponent<TextMeshProUGUI>().text = chars[i].ToString();
        }
    }
}
