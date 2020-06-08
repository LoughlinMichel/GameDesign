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
    private RippleProcessor cameraRipple; //This is how I communicate to my ripple effect script.
    [SerializeField] private Transform player = null; //This is how I relate to the players position to change it, null was added to remove errors.
    [SerializeField] private Transform respawnPoint = null; //This is how I tell the script where my repsawn position should be, null was added to remove errors.

    private void Start()
    {
        cameraRipple = Camera.main.GetComponent<RippleProcessor>(); //This is how I communicate to my ripple effect script.
    }

    void Update()
    {
        for (int x = 0; x < hearts.Length; x++) //Array is used to change the health's display from full heart to empty heart, and x equals 0 for reference.
        {
            if (x < health)
            {
                hearts[x].sprite = fullHeart; //If health is more than 0 then full hearts will be dispalyed.
            }
            else
            {
                hearts[x].sprite = emptyHeart; //If health is less than 0 then empty heart will be displayed instead.
            }

            if (x < numberOfHearts)
            {
                hearts[x].enabled = true; //No matter what, the number of hearts will stay the same even when number of hearts is more tahn 0.
            }
            else
            {
                hearts[x].enabled = false; //No matter what, the number of hearts will stay the same even when number of hearts is less than 0.
            }
        }

        if (health <= 0) //If health is equal to or less than 0 player will respawn.
        {
            Debug.Log("Gameover"); //Debug is added to find errors.
            SceneManager.LoadScene("Dead Menu"); //When player dies then dead menu will be opened and player from there the player can play again.
            //health += 3; //If player is respawned then players health will go up by 3, giveing the player full health.
            //player.transform.position = respawnPoint.transform.position; //If function is called then players position is move or transformed to respawn point position.

        }
    }


    public void TakeDamage()
    {
        cameraRipple.RippleEffect(); //If player takes damage, ripple effect will be played.
        health -= 1; //When player is damaged then health will decrease by 1.
    }

    public void NextLevel()
    {
        health += 3; //When player passes level and moves to the next level then players health will increase by 3.
    }
}
