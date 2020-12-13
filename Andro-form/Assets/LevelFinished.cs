using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelFinished : MonoBehaviour
{
    public GameObject gameOverMenu;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }
}
