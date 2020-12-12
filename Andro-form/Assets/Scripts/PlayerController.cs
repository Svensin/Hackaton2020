﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BatteryLevel batteryLevelManager;

    public float movementDecrease;
    public float jumpDecrease;

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
        if (batteryLevelManager.checkBatteryLevel() > 0)
        {

            Debug.Log(batteryLevelManager.checkBatteryLevel());
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            moveInput = Input.GetAxis("Horizontal");

            if (moveInput != 0)
            {
                batteryLevelManager.decreaseBatteryLevel(movementDecrease * Time.deltaTime);
            }

            playerRigidbody.velocity = new Vector2(moveInput * speed, playerRigidbody.velocity.y);

            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryLevelManager.checkBatteryLevel() > 0)
        {
            if (isGrounded)
            {
                extraJumps = extraJumpsValue;
            }
            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                playerRigidbody.velocity = Vector2.up * jumpForce;
                extraJumps--;
                batteryLevelManager.decreaseBatteryLevel(jumpDecrease);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            {
                playerRigidbody.velocity = Vector2.up * jumpForce;
                batteryLevelManager.decreaseBatteryLevel(jumpDecrease);
            }
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
