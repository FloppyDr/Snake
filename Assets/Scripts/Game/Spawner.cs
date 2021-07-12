using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefub;
    [SerializeField] private GameObject _wallPrefub;
    [SerializeField] private GameObject _cellPrefub;

    [SerializeField] private SnakeHead _head;

    private List<int> _positionsX = new List<int>();
    private List<int> _positionsY = new List<int>();
    private List<GameObject> _cells = new List<GameObject>();

    private void OnEnable()
    {
        _head.FooodCollected += OnFoodCollected;
    }

    private void OnDisable()
    {
        _head.FooodCollected -= OnFoodCollected;
    }


    private void Start()
    {
        for (int i = 0; i < 37; i++)
        {
            _positionsX.Add(i - 18);
        }

        for (int i = 0; i < 27; i++)
        {
            _positionsY.Add(i - 13);
        }

        for (int i = _positionsX[0]; i < _positionsX.Count; i++)
        {
            for (int j = _positionsY[0]; j < _positionsY.Count; j++)
            {
                if (i <= 18 && j <= 13)
                {
                    var cell = Instantiate(_cellPrefub, new Vector3(i, j, 0), Quaternion.identity, transform);

                    _cells.Add(cell);
                }
            }
        }

        SpawnFood();
        SpawnFood();
        SpawnFood();
        SpawnFood();
        SpawnFood();
        SpawnFood();
        SpawnFood();
        SpawnFood();
    }

    private void OnFoodCollected()
    {
        SpawnFood();

        SpawnWall();
        SpawnWall();
        SpawnWall();
    }

    private void SpawnFood()
    {
        int foodIndex = Random.Range(0, _cells.Count);
        if (_cells[foodIndex].GetComponent<Cell>().IsEmpty)
        {
            Instantiate(_foodPrefub, _cells[foodIndex].transform.position, Quaternion.identity);
        }
    }

    private void SpawnWall()
    {
        int wallIndex = Random.Range(0, _cells.Count);

        if (_cells[wallIndex].GetComponent<Cell>().IsEmpty)
        {
            Instantiate(_wallPrefub, _cells[wallIndex].transform.position, Quaternion.identity);
            _cells.RemoveAt(wallIndex);
        }
    }
}