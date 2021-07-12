using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private float _maxTimer = 0.35f;
    [SerializeField] private Transform _segmentPrefub;

    private Vector2Int _direction = Vector2Int.right;
    private float _timer = 0;

    private List<Transform> _segments;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_direction != Vector2Int.down)
            {
                _direction = Vector2Int.up;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_direction != Vector2Int.up)
            {
                _direction = Vector2Int.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_direction != Vector2Int.left)
            {
                _direction = Vector2Int.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_direction != Vector2Int.right)
            {
                _direction = Vector2Int.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Grow();
        }

        _timer += Time.deltaTime;


        if (_timer >= _maxTimer)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            transform.position = new Vector3(transform.position.x + _direction.x, transform.position.y + _direction.y);
            _timer = 0;
        }
    }

    //private void FixedUpdate()
    //{
    //    for (int i = _segments.Count - 1; i > 0; i--)
    //    {
    //        _segments[i].position = _segments[i - 1].position;
    //    }

    //    transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y);
    //}

    public void Grow()
    {
        Transform segment = Instantiate(_segmentPrefub);
        if (_segments.Count == 1)
        {
            if (_direction.x > 0)
            {
                segment.position = new Vector3(_segments[_segments.Count - 1].position.x - 1, _segments[_segments.Count - 1].position.y, 0);
            }
            if (_direction.x < 0)
            {
                segment.position = new Vector3(_segments[_segments.Count - 1].position.x + 1, _segments[_segments.Count - 1].position.y, 0);
            }
            if (_direction.y > 0)
            {
                segment.position = new Vector3(_segments[_segments.Count - 1].position.x, _segments[_segments.Count - 1].position.y - 1, 0);
            }
            if (_direction.y < 0)
            {
                segment.position = new Vector3(_segments[_segments.Count - 1].position.x - 1, _segments[_segments.Count - 1].position.y + 1, 0);
            }
        }
        else
        {
            segment.position = _segments[_segments.Count - 1].position;
        }


        _segments.Add(segment);
    }
}
