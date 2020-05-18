using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 9f;

    const float jumpForce = 15f;

    public LayerMask whatIsGround;


    private Rigidbody2D rb;
    private float inputHorizontal;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Allowing the player to be controlled easily with "rb".
    }

    private void Update()
    {

        inputHorizontal = Input.GetAxisRaw("Horizontal"); //Horrizontal is already known by unity, rather that "if a is pushed then go left".

        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y); //Player new position will equal direction * speed * its movemnt in the sky, allowing player to move while jumping.

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 2f, whatIsGround); //Raycast will check if there is ground 0.2 metres below player.
        {
            if (hitInfo.collider != null) //If ground is detected then...
            {
                if (Input.GetKeyDown(KeyCode.W)) //When "W" is pressed then player's position will be multiplied upwards by jumpForce.
                {
                    rb.velocity = Vector2.up * jumpForce;
                    Debug.Log("Jump"); //Debug is added to find errors.

                }
            }

        }
    }
}
