using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health; //The health the player has which can decrease or increase during the game.
    const int numberOfHearts = 3; //Number of hearts is a constant number and doesnt change.

    public Image[] hearts; //Place holders so that a full heart can be lost to a empty heart or visa versa.
    public Sprite fullHeart; //Sprite/Picture of a red (full heart)
    public Sprite emptyHeart; //Sprite/Picture of a black (empty heart)

    private RippleProcessor cameraRipple;

    private void Start()
    {
        cameraRipple = Camera.main.GetComponent<RippleProcessor>();
    }

    void Update()
    {
        for (int x = 0; x < hearts.Length; x++)
        {
            if (x < health)
            {
                hearts[x].sprite = fullHeart;
            }
            else
            {
                hearts[x].sprite = emptyHeart;
            }

            if (x < numberOfHearts)
            {
                hearts[x].enabled = true;
            }
            else
            {
                hearts[x].enabled = false;
            }
        }

        if (health <= 0) //If health is equal to or less than 0 player will respawn.
        {
            Debug.Log("Gameover");
            SceneManager.LoadScene("Dead Menu");
        }
    }


    public void TakeDamage()
    {
        Debug.Log("Hit");
        cameraRipple.RippleEffect();
        health -= 1;
    }

    public void NextLevel()
    {
        health += 3;
    }
}
