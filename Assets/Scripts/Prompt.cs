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
    private List<TextMeshProUGUI> UIletters;
    // Start is called before the first frame update
    void Start()
    {
        chars = new List<char>();
        UIletters = new List<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void write(string s)
    {
        chars.Clear();
        UIletters.Clear();
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
            TextMeshProUGUI letterTMP = currentLetter.GetComponent<TextMeshProUGUI>();
            letterTMP.text = chars[i].ToString();
            letterTMP.outlineWidth = 0.1f;
            letterTMP.outlineColor = new Color32(0, 0, 0, 255);
            UIletters.Add(letterTMP);
            
        }
    }

    public void warningZone(bool inside)
    {
        foreach(var v in UIletters)
        {
            if (inside)
            {
                v.outlineWidth += 0.2f;
                v.outlineColor = new Color32(255, 0, 0, 255);
            } else
            {
                v.outlineWidth -= 0.2f;
                v.outlineColor = new Color32(0, 0, 0, 255);
            }
        }
    }
}
