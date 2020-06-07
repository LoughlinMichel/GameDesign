using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingTrig : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            text.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(text);
        Destroy(gameObject);
    }
}
