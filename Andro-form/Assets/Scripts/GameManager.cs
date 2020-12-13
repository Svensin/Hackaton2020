using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BatteryLevel batteryLevelManager;
    [SerializeField] PlayerController playerController;

    [SerializeField] int numberOfBatteries = 0;
    [SerializeField] GameObject batteryButton;

    [SerializeField] GameObject playerControllerUI;
    [SerializeField] GameObject KPKControllerUI;


    [SerializeField] GameObject currentLevelElement;
    [SerializeField] List<GameObject> LevelElementList;

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

    public void SelectLevelElement(int id)
    {
        

        foreach (GameObject levelElement in LevelElementList)
        {
            levelElement.GetComponent<LevelElementController>().DisableBlockMovement();

            levelElement.GetComponent<LevelElementController>().DisableYellowLine();
        }

        

        print(currentLevelElement.name);

        currentLevelElement = LevelElementList[id];

        currentLevelElement.GetComponent<LevelElementController>().EnableBlockMovement();

        currentLevelElement.GetComponent<LevelElementController>().EnableYellowLine();
    }

    public void ActivateKPKControl()
    {
        EnableKPKUI();
        DisablePlayerUI();
        DisableMovement();

        currentLevelElement = LevelElementList[0];

        LevelElementController currentLevelElementController = currentLevelElement.GetComponent<LevelElementController>();

        currentLevelElementController.EnableBlockMovement();

        currentLevelElementController.EnableYellowLine();
    }

    public void DeactivateKPKControl()
    {
        DisableKPKUI();
        EnablePlayerUI();
        EnableMovement();

        LevelElementController currentLevelElementController = currentLevelElement.GetComponent<LevelElementController>();

        currentLevelElementController.DisableBlockMovement();

        currentLevelElementController.DisableYellowLine();
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

    public void EnablePlayerUI()
    {
        playerControllerUI.SetActive(true);
    }

    public void DisablePlayerUI()
    {
        playerControllerUI.SetActive(false);
    }

    public void EnableKPKUI()
    {
        KPKControllerUI.SetActive(true);
    }

    public void DisableKPKUI()
    {
        KPKControllerUI.SetActive(false);
    }
}
