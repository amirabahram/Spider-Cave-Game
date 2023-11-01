using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField] 
    private Button resumeButton;
     public void GamePause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => ResumeGame());
        GameObject resb = resumeButton.gameObject;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Gameplay");
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => RestartGame());

    }
    public void GoToMenu()
    {
        Time.timeScale = 0;
        Application.LoadLevel("Main Menu");
    }
}
