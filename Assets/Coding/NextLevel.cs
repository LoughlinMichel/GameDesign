using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Next Level");
        collision.gameObject.GetComponent<PlayerHealth>().NextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //When player collides with checkpoint the scene/level will make the buildIndex increase by +1.
    }

}
