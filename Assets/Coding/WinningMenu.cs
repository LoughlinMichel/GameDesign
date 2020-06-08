using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{   
    public void PlayAgian() //This is public, so that it can be called on button press.
    {
        Debug.Log("Playing Agian"); //Lets me know if the script is working.
        SceneManager.LoadScene("Level One"); //When button is pressed game will be played again.
    }

    public void Quit() //This is public, so that it can be called on button press.
    {
        Debug.Log("Quit"); //Lets me know if the script is working.
        Application.Quit(); //When button is pressed game will quit, this will not quit unity.
    }
}
