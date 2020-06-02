using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Talking : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        else if(textDisplay.text != sentences[index])
        {
            continueButton.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
}