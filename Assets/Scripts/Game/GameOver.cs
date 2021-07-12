using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private GameObject _gameOverScreen;

    private bool _isGameOver = false;

    private void OnEnable()
    {
        _head.Died += OnDied;
    }

    private void OnDisable()
    {
        _head.Died -= OnDied;
    }

    private void OnDied()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        _isGameOver = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown && _isGameOver)
        {
            _isGameOver = false;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
