using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 800f;

    Rigidbody2D rb;
    bool facingRight = true;

    private Transform groundCheck;    // A position marking where to check if the player is grounded.
    const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded;            // Whether or not the player is grounded.
    [SerializeField]
    private LayerMask whatIsGround;                  // A mask determining what is ground to the character

    Animator anim;

    bool canMove = true;

    void OnEnable() {
        EventManager.StartListening("StartRitual", StopMoving);
        EventManager.StartListening("StopRitual", StartMoving);
    }
    void OnDisable() {
        EventManager.StopListening("StartRitual", StopMoving);
        EventManager.StopListening("StopRitual", StartMoving);
    }

    void Start() {
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        grounded = false;
        //Check for ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                grounded = true;
            }
        }
        anim.SetBool("Grounded", grounded);
//        anim.SetFloat("ySpeed", rb.velocity.y);

    }
    void Update() {
        if (canMove) {
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(move));

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight) {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight) {
                // ... flip the player.
                Flip();
            }

            if (Input.GetButtonDown("Jump")) {
                if (grounded) {
                    grounded = false;
                    anim.SetBool("Grounded", false);
                    rb.AddForce(new Vector2(0f, jumpForce));
                }
            }
        }

    }

    void StopMoving() {
        canMove = false;
        rb.velocity = new Vector2(0,0);
    }

    void StartMoving() {
        canMove = true;
    }

    private void Flip() {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
