using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject Credits;

    public void Start() 
    {
       //Credits.SetActive(false);    
    }

    public void PlayButton()
    {
        if (gameObject.tag == "PlayButton") {
            SceneManager.LoadScene("SampleScene");
        }

        if (gameObject.tag  == "CreditsButton") {
            Credits.SetActive(true);
        }

        if (gameObject.tag == "BackButton") {
            Credits.SetActive(false);
        }

        if (gameObject.tag == "QuitButton") {
            Application.Quit();
        }
    }
}
