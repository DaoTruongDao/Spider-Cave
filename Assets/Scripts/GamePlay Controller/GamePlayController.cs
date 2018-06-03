using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button resumeGame;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners(); //giúp cho nút resume có 2 chức năng chức năng thứ 1 là pause game chức năng thứ 2 là khi thắng game ấn vào sẽ chơi lại
        resumeGame.onClick.AddListener(() =>ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }

    public void RestarGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("game play");
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners(); 
        resumeGame.onClick.AddListener(() =>RestarGame());
    }
}
