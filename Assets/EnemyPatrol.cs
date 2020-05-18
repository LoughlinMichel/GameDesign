using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed; //Enemies speed will change depending on enemy public makes it easier to change.

    private bool movingLeft = false; //Enemy will go right until it cant no more.

    public Transform groundDetecton; //Empty will be created to detect ground infront of enemy.



    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Enemy movemnt will equal right * speed * time, meaning it will be constant velocity.

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetecton.position, Vector2.down, 2f); //Raycast will check if there is ground 2 metres below the "groundDetection" which infront of enemy.

        if (groundInfo.collider == false)
        {
            if (movingLeft == false) //Enemy will turn around and go left if it cant go right.
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = true;
            }
            else //Otherwise if enemy can go right then it will continue ahead until no ground is detected.
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = false;
            }
        }
    }

}
