using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10f)] [SerializeField] public float speed = 9f; // Player's x is multiplied by this, it's public so it can be changed easily in the inspect.
    [Range(0, 5f)] [SerializeField] public float crouchSpeed = 5f; // Player's x is multipled by this when player is crouched, it has a slider to look nicer.
    const float jumpForce = 15f; // Player's y is multiplied by this, this is constant as it doesnt change.
    public LayerMask whatIsGround; // This is the layer that is detected for ground.
    private Rigidbody2D rb; // This is how i relate to the player.
    private float inputHorizontal; // This is my player's x movement.
    private bool facingLeft = false; // Player's goal is to go right so it must face right not left.
    public Collider2D standCollider; // 
    public Collider2D crouchCollider; // This is the collider that is disabled and enabled throughout the game.
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Allowing the player to be controlled easily with "rb".

        standCollider.enabled = true;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal"); // Horrizontal is already known by unity, rather that "if a is pushed then go left".

        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y); // Player new position will equal direction * speed * its movemnt in the sky, allowing player to move while jumping.

        animator.SetFloat("Velocity", Mathf.Abs(inputHorizontal));

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, whatIsGround); // Raycast will check if there is ground 0.2 metres below player.
        {
            if (hitInfo.collider != null) // If ground is detected then...
            {
                if (Input.GetButton("Jump")) // When "Jump" button is pressed then player's position will be multiplied upwards by jumpForce.
                {
                    rb.velocity = Vector2.up * jumpForce; // Player can move while jumping as movemnt is multiplied by jumpforce.
                }
            }

        }

        if (facingLeft == true && inputHorizontal > 0) // If player is moving right then player will face right.
        {
            Flip(); // Communicate with the flip void and runs it.
        }
        else if (facingLeft == false && inputHorizontal < 0) // If player is moving left then player will face left.
        {
            Flip(); // Communicate with the flip void and plays function.
        }

        Crouch();
    }

    void Flip() // Void allowing the player to face left or right.
    {
        facingLeft = !facingLeft; // Player will be not be facing left on default.
        Vector3 Scaler = transform.localScale; // Players postion.
        Scaler.x *= -1; // Scale of player will be multiplied by -1 meaning it will flip to the left or right.
        transform.localScale = Scaler; // Players will transform will be adjusted to do a 180 in the correct direction.
    }

    void Crouch()
    {

        /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 2f, whatIsGround);
        
        if (hitInfo.collider != null)
        {
            disableCollider.enabled = false;
            speed = crouchSpeed;
        }*/

        if (Input.GetButtonDown("Crouch")) // If "Crouch" button is pressed then the following will be played...
        {
            standCollider.enabled = false;
            crouchCollider.enabled = true; // Collider is disabled allowing the player to pass under objects.
            speed = crouchSpeed; // A new speed is set for the player while crouching.
            animator.SetBool("Crouching", true);
            Debug.Log("Crouched"); // Debug is added to find errors.
        }

        if (Input.GetButtonUp("Crouch")) // If "Crouch" button is unpressed then the following with be active...
        {
            standCollider.enabled = true;
            crouchCollider.enabled = false; // Collider is enabled not allowing player to pass under objetcs.
            speed = 9f; // Player's speed is set back to normal.
            animator.SetBool("Crouching", false);
            Debug.Log("Uncrouched"); // Debug is added to find errors.
        }


    }
}

