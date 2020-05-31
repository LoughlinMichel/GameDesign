using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenOff : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform respawnPoint = null;

    private void OnTriggerEnter2D(Collider2D other) //When player collides with void collider then...
    {
        Debug.Log("Fallen off");
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        player.transform.position = respawnPoint.transform.position;
    }

}

