using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryLevel : MonoBehaviour
{
    [SerializeField] float minBatteryLevel;
    [SerializeField] float maxBatteryLevel;

    [SerializeField] Text batteryCheckLevelText; 

    public float batteryLevel;// під заміну

    public void Awake()
    {
        batteryLevel = maxBatteryLevel;
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
