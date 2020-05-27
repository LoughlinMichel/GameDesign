using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health; //The health the player has which can decrease or increase during the game.
    const int numberOfHearts = 3; //Number of hearts is a constant number and doesnt change.

    public Image[] hearts; //Place holders so that a full heart can be lost to a empty heart or visa versa.
    public Sprite fullHeart; //Sprite/Picture of a red (full heart)
    public Sprite emptyHeart; //Sprite/Picture of a black (empty heart)

    [SerializeField] private Transform player = null;
    [SerializeField] private Transform respawnPoint = null;

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
            Die();
        }
    }


    public void TakeDamage()
    {
        Debug.Log("Hit");
        health -= 1;
    }

    void Die()
    {
        Debug.Log("GameOver");
        Invoke("Respawn", 0);
    }

    public void Respawn()
    {
        health = 3;
        player.transform.position = respawnPoint.transform.position; //When player dies will respawn at the respawn point with 3 new hearts.
    }

}
