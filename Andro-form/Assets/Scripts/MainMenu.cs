using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// BEGIN 2d_mainmenu
using UnityEngine.SceneManagement;

// Manages the main menu.
public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	//public GameObject settingsMenu;
	public GameObject chooseLevelMenu;

	

	GameObject currentMenu;



	public void Start() {
		currentMenu = mainMenu;
		currentMenu.SetActive(true);
		//settingsMenu.SetActive(false);
		chooseLevelMenu.SetActive(false);

	}

    public void BackToMainMenu()
    {
		currentMenu.SetActive(false);
		mainMenu.SetActive(true);
		currentMenu = mainMenu;
    }

	//public void ToSettingsMenu()
	//{
	//	currentMenu.SetActive(false);
	//	settingsMenu.SetActive(true);
	//	currentMenu = settingsMenu;
	//}

	public void ToChooseLevelMenu()
	{
		currentMenu.SetActive(false);
		chooseLevelMenu.SetActive(true);
		currentMenu = chooseLevelMenu;
	}


	public void LoadLevel(int id)
    {
		SceneManager.LoadScene(id);
    }


	

	public void QuitApplication()
    {
		Application.Quit();
    }

	
}
// END 2d_mainmenu
