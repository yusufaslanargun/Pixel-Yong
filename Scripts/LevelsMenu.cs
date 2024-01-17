using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButtons;

    private void Start()
    {

        for (int i = PlayerPrefs.GetInt("levelCompleted") + 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }
}
