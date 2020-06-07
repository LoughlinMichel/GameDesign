using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void Respawn()
    {
        Debug.Log("Resapwn");
        SceneManager.LoadScene("Level One");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

