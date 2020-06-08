using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Talking : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; //This is the actual text area/ position, or the text box.
    public string[] sentences; //These are sentences I can change through inspect through unity to make it easier.
    private int index; //This is how many sentences there will be, I can also change this through unity.
    public GameObject continueButton; //This relates to the button to use to get to the next sentence.
    public PlayerController controller; //This is how I relate to the player.

    void Start()
    {
        StartCoroutine(Type()); //Starts Coroutine, which works as a timer which plays a function after a certain amount of time.
        controller.enabled = false; //This disbales the controller from the start while text is displayed.
    }

    void Update()
    {
        if(textDisplay.text == sentences[index]) //If the text box has a sentence in it then...
        {
            continueButton.SetActive(true); //Button will be displayed and will be able to use.
            controller.enabled = false; //This disables the player's movement while text is displayed.

        }
        else if(textDisplay.text != sentences[index]) //If the text box doesnt have a sentence then...
        {
            continueButton.SetActive(false); //Button will not be displayed and will not be able to use.
        }
    }

    IEnumerator Type() //This is the funtion that the coroutine communicate to and starts a timer.
    {
        foreach(char letter in sentences[index].ToCharArray()) //This is what allows the text to have a typing effect. 
        {
            textDisplay.text += letter; //Every few seconds a letter will be added to the text box to give the typing effect.
            yield return new WaitForSeconds(0.05f); //This is the time between each letter being displayed.
        }
    }

    public void NextSentence() //Next sentence void.
    {
        if (index < sentences.Length - 1) //Index should always equal amount of sentences, it should not exceed this limit.
        {
            index++; 
            textDisplay.text = "";
            StartCoroutine(Type()); //When a new sentence is displayed then start the coroutine agian to add typing effect.
        }
        else
        {
            textDisplay.text = "";
            controller.enabled = true; //This enables the controller after it being disabled
        }
    }
}