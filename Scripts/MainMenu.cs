using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("levelCompleted") || PlayerPrefs.GetInt("levelCompleted") < 0)
        {
            PlayerPrefs.SetInt("levelCompleted", 0);
        }
    }

    
    // These two functions for testing levels.
    //public void ResetValue()
    //{
    //    PlayerPrefs.SetInt("levelCompleted", 0);
    //}

    //public void Increment()
    //{
    //    PlayerPrefs.SetInt("levelCompleted", PlayerPrefs.GetInt("levelCompleted") + 1);
    //}

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
