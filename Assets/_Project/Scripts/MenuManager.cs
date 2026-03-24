using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void VictoryMenu(GameObject victoryMenu)
    {
        if (victoryMenu != null)
            victoryMenu.SetActive(true);
    }

    public void GameOverMenu(GameObject gameOverMenu)
    {
        if (gameOverMenu != null)
            gameOverMenu.SetActive(true);
    }

    public void PauseMenu(GameObject pauseMenu, bool state)
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(state);
    }
}
