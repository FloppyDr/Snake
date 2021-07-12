using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private AudioSource _deathSource;
    [SerializeField] private AudioSource _foodSource;

    private SnakeMover _mover;

    public event UnityAction FooodCollected;
    public event UnityAction Died;

    private void Awake()
    {
        _mover = GetComponent<SnakeMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Food food))
        {
            _foodSource.Play();

            _mover.Grow();
            food.Die();
            FooodCollected?.Invoke();
        }

        if (collision.TryGetComponent(out SnakeSegment segment))
        {
            Die();
        }
    }

    public void Die()
    {
        _deathSource.Play();
        Died?.Invoke();
    }
}
