using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// BEGIN 2d_mainmenu
using UnityEngine.SceneManagement;

// Manages the main menu.
public class MenuManeger : MonoBehaviour
{

	//public GameObject settingsMenu;


	GameObject currentMenu;



	public void Start()
	{

	}



	//public void ToSettingsMenu()
	//{
	//	currentMenu.SetActive(false);
	//	settingsMenu.SetActive(true);
	//	currentMenu = settingsMenu;
	//}



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
