using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenOff : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform respawnPoint = null; //null was added to remove the error.

    private void OnTriggerEnter2D(Collider2D other) //When player collides with void collider then...
    {
        player.transform.position = respawnPoint.transform.position; //When player falls off into void player will respawn at the respawn point.


    }

}

