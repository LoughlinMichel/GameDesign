using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool invincible; // Bool to turns invincible to true or false which will then run to a void. 
    public Collider2D squareColl; // This is the collider of the enemy and will disable after a certain amount of time.

    private void Start()
    {
        if (invincible == true) // If invinible is true then...
        {
            squareColl.enabled = false;

        }
        else if (invincible == false) // If invinible is false then...
        {
            squareColl.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage();
       //  Invoke("Invincible", 1);
    }

    void Invincible()
    {
        Debug.Log("Invincible");
        invincible = true;
        Invoke("InvincibleReset", 2);
    }

    void InvincibleReset()
    {
        invincible = false;
    }
}