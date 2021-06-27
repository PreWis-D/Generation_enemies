using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _pointsSpawn;
    [SerializeField] private float _durationCooldown;

    private Transform[] _points;
    private float _currentTimeCooldown;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_pointsSpawn.childCount];

        for (int i = 0; i < _pointsSpawn.childCount; i++)
        {
            _points[i] = _pointsSpawn.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        if (_currentTimeCooldown <= _durationCooldown)
        {
            _currentTimeCooldown += Time.deltaTime;
        }
        else
        {
            _currentTimeCooldown = 0;

            GameObject enemy = Instantiate(_enemy, target.position, Quaternion.identity);
            
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
