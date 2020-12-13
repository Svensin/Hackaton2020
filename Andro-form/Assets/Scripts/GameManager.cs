using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BatteryLevel batteryLevelManager;
    [SerializeField] PlayerController playerController;

    [SerializeField] int numberOfBatteries = 0;
    [SerializeField] GameObject batteryButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        batteryLevelManager.showCurrentBatteryLevel();
    }

    public int getNumbersOfBatteries()
    {
        return numberOfBatteries;
    }

    public void DecreaseBatteryNumber()
    {
        if (numberOfBatteries > 0)
        {
            numberOfBatteries--;
        }

        if (numberOfBatteries == 0)
        {
            batteryButton.SetActive(false);
        }
    }

    public void IncreaseBatteryNumber()
    {
        batteryButton.SetActive(true);
        numberOfBatteries++;
    }

    public void EnableMovement()
    {
        playerController.isPlayerMoving = true;
    }

    public void DisableMovement()
    {
        playerController.isPlayerMoving = false;
    }

    public void EnableCharging()
    {
        batteryButton.SetActive(true);
    }

    public void DisableCharging()
    {
        batteryButton.SetActive(false);
    }
}
