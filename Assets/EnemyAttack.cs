using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool invincible;

    public Collider2D squareColl;

    private void Start()
    {
        if (invincible == true)
        {
            squareColl.enabled = false;

        }
        else if (invincible == false)
        {
            squareColl.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage();
       // Invoke("Invincible", 1);
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