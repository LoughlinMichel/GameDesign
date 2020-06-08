using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void Respawn() //What the Respawn button will do, public so that it can be called.
    {
        Debug.Log("Resapwn"); //Debug is added to find errors.
        SceneManager.LoadScene("Level One"); //When player dies player will respawn back at level one, this adds a challenge.
    }

    public void Quit() //What the quit button will do, public so that it can be called.
    {
        Debug.Log("Quit"); //Debug is added to find errors.
        Application.Quit(); //This will quit the game but wont quit out of unity.
    }
}

