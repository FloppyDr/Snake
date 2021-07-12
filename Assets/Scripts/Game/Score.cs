using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private AudioSource _source;

    private int _score;

    private void OnEnable()
    {
        _head.FooodCollected += OnFoodCollected;
    }
    private void OnDisable()
    {
        _head.FooodCollected -= OnFoodCollected;
    }

    private void OnFoodCollected()
    {
        _score++;
        _scoreDisplay.text = string.Format("{0:d5}", _score);

        if (_score%10==0)
        {
            _source.Play();
        }
    }
}
