using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLevel : MonoBehaviour
{
    [SerializeField] float minBatteryLevel;
    [SerializeField] float maxBatteryLevel;
    [SerializeField] float chargeSpeed;

    [SerializeField] GameManager gameManager;

    [SerializeField] Text batteryCheckLevelText; 

    public float batteryLevel;// під заміну

    public void Awake()
    {
        batteryLevel = maxBatteryLevel;
    }

    private void Start()
    {
        ChargeBattery();
    }

    public void ChargeBattery()
    {
        if (batteryLevel < maxBatteryLevel)
        {
            gameManager.DecreaseBatteryNumber();
            gameManager.DisableMovement();
            gameManager.DisableCharging();
            StartCoroutine(ChargeBatteryCoroutine());
        }   
    }


    public IEnumerator ChargeBatteryCoroutine()
    {
        while(batteryLevel < maxBatteryLevel)
        {
            batteryLevel += chargeSpeed;
            if (batteryLevel > maxBatteryLevel)
            {
                batteryLevel = maxBatteryLevel;
                
            }
            if (batteryLevel < maxBatteryLevel)
            {
                yield return new WaitForSeconds(1f);
            }
        }
        
   
        gameManager.EnableMovement();
        if (gameManager.getNumbersOfBatteries() > 0)
        {
            gameManager.EnableCharging();
        }

    }
    public void decreaseBatteryLevel(float batteryDecrease)
    {
        if (batteryLevel >= batteryDecrease)
        {
            batteryLevel -= batteryDecrease;
        }
    }

    public float checkBatteryLevel()
    {
        return Mathf.Round(batteryLevel);
    }

    public void showCurrentBatteryLevel()
    {
        batteryCheckLevelText.text = checkBatteryLevel() + "%";
    }
}
