using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenOff : MonoBehaviour
{
    [SerializeField] private Transform player = null; // This is how I relate to the players position to change it, null was added to remove errors.
    [SerializeField] private Transform respawnPoint = null; // This is how I tell the script where my repsawn position should be, null was added to remove errors.

    private void OnTriggerEnter2D(Collider2D other) // When player collides with void collider then...
    {
        Debug.Log("Fallen off"); // Debug is added to find errors.
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(); 
        player.transform.position = respawnPoint.transform.position; // If function is called then players position is move or transformed to respawn point position.
    }

}

