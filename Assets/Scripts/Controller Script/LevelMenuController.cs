using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame()
    {
        Application.LoadLevel("game play");
    }

    public void BackToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
