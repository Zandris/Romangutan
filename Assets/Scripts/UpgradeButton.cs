using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButton : MonoBehaviour
{
    public GameObject upgradesMenu;
    
    public void Start() 
    {
        upgradesMenu.SetActive(false);
    }
    
    public void upgradesButton () 
    {

        if (gameObject.tag == "UpgradesButton") {
            upgradesMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (gameObject.tag == "ResumeButton") {
            upgradesMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (gameObject.tag == "MenuButton") {
            SceneManager.LoadScene("MainMenu");
        }

        if (gameObject.tag == "NewGameButton") {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
//https://www.youtube.com/watch?v=9dYDBomQpBQ
