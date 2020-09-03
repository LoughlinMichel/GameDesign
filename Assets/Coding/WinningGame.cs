using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You Won"); // Tells us in the if we have won in the console.
        SceneManager.LoadScene("Winning Menu"); // When player collides with checkpoint the scene/level will go to the final scene.s
    }
}


