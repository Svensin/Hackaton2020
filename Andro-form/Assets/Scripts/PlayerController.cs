using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D playerRigidbody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(moveInput * speed, playerRigidbody.velocity.y);

        if(!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            playerRigidbody.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidbody.velocity = Vector2.up * jumpForce;
        }


        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 newPlayerScale = transform.localScale;
        newPlayerScale.x *= -1;
        transform.localScale = newPlayerScale;
    }
}
