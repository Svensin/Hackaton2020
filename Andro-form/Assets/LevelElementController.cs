using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LevelElementController : MonoBehaviour
{
    [SerializeField] bool isLevelMoving = false;
    [SerializeField] float speed;
    [SerializeField] GameObject yellowLine;
    [SerializeField] BatteryLevel batteryLevelManager;
    [SerializeField] float movementDecrease;

    float verticalInput;
    float horizontalInput;

    Rigidbody2D blockRigidBody2D;

    // Start is called before the first frame update

    private void OnEnable()
    {
        blockRigidBody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLevelMoving)
        {
            verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                batteryLevelManager.decreaseBatteryLevel(movementDecrease * Time.deltaTime);
            }

            blockRigidBody2D.velocity = new Vector2(blockRigidBody2D.velocity.x, verticalInput * speed);

            horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");// не працю з боку в бік

            if (horizontalInput != 0)
            {
                batteryLevelManager.decreaseBatteryLevel(movementDecrease * Time.deltaTime);
            }
            print(horizontalInput);
            blockRigidBody2D.velocity = new Vector2(horizontalInput * speed, blockRigidBody2D.velocity.y);
        }
        
    }

    public void EnableBlockMovement()
    {
        isLevelMoving = true;
    }

    public void DisableBlockMovement()
    {
        isLevelMoving = false;
    }

    public void EnableYellowLine()
    {
        yellowLine.SetActive(true);
    }

    public void DisableYellowLine()
    {
        yellowLine.SetActive(false);
    }
}
