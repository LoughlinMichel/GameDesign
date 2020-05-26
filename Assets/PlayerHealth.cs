﻿using System.Collections;
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
    }
}