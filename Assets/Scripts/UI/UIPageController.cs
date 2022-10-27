using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPageController : MonoBehaviour
{
    [SerializeField]
    private Game _game;
    [SerializeField]
    private Menu _menu;
    [SerializeField]
    private GameOver _gameOver;

    private void Start()
    {
        _menu.gameObject.SetActive(true);
        _game.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
    }
    public void OnStartButtonClicked()
    {
        _menu.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        _game.gameObject.SetActive(true);
    }
    public void OnGameOver()
    {
        _game.gameObject.SetActive(false);
        _menu.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(true);
    }
    public void OnRestartButtonClicked()
    {
        _menu.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);

        _game.gameObject.SetActive(true);
    }
    public void OnMenuButtonClicked()
    {
        _game.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        _menu.gameObject.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
