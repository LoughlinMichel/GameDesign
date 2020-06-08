using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Next Level"); //Lets me know if the script is working.
        collision.gameObject.GetComponent<PlayerHealth>().NextLevel(); //This is communicate to the next level funtion which will add 3 to the players health.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //When player collides with checkpoint the scene/level will make the buildIndex increase by +1.
    }

}
