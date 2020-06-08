using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 9f; //Player's x is multiplied by this, its private as it doesnt need to be changed.
    const float jumpForce = 15f; //Player's y is multiplied by this, this is constant as it doesnt change.
    public LayerMask whatIsGround; //This is the layer that is detected for ground.
    private Rigidbody2D rb; //This is how i relate to the player.
    private float inputHorizontal; //This is my player's x movement.
    private bool facingLeft = false; //Player's goal is to go right so it must face right not left.

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

        if (facingLeft == true && inputHorizontal > 0) //If player is moving right then player will face right.
        {
            Flip(); //Communicate with the flip void and runs it.
        }
        else if (facingLeft == false && inputHorizontal < 0) //If player is moving left then player will face left.
        {
            Flip(); //Communicate with the flip void and plays function.
        }
    }

    void Flip() //Void allowing the player to face left or right.
    {
        facingLeft = !facingLeft; //Player will be not be facing left on default.
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1; //Scale of player will be multiplied by -1 meaning it will flip to the left or right.
        transform.localScale = Scaler; //Players will transform will be adjusted to do a 180 in the correct direction.
    }
}
