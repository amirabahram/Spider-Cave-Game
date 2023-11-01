using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
     public void PlayGame()
    {
        Application.LoadLevel("Gameplay");
        Time.timeScale = 1.0f;
    }
    public void BackToMenu()
    {
        Application.LoadLevel("Main Menu");
    }
}
