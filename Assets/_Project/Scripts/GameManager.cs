using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _pauseMenu;

    private bool _isPaused;
    private bool _gameEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        //AudioManager.Instance.PlayMusic(_backgroundMusic);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (_gameEnded) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0;
        MenuManager.Instance.PauseMenu(_pauseMenu, true);
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        MenuManager.Instance.PauseMenu(_pauseMenu, false);
    }

    public void Victory()
    {
        _gameEnded = true;
        Time.timeScale = 0;
        MenuManager.Instance.VictoryMenu(_victoryMenu);     
    }

    public void GameOver()
    {
        _gameEnded = true;
        Time.timeScale = 0;
        MenuManager.Instance.GameOverMenu(_gameOverMenu);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
