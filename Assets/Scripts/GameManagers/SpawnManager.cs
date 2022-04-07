using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;

    private float _positionX = 20f;
    private float _positionY = 0f;
    private float _positionYUpper = 4f;
    private float _positionYLower = -3f;
    private int _obstacleCount = 0;
    private int _obstacleLimit = 5;
    private float _timeDelay = 2.75f;

    void Start()
    {
        if (_obstaclePrefab == null)
        {
            return;
        }
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        for (; _obstacleCount < _obstacleLimit; _obstacleCount++)
        {
            Instantiate(_obstaclePrefab, RandomPositionOnY(), _obstaclePrefab.transform.rotation, gameObject.transform);
            yield return new WaitForSeconds(_timeDelay);
        }
        StopCoroutine(SpawnObstacles());
    }
    
    private Vector2 RandomPositionOnY()
    {
        _positionY = Random.Range(_positionYLower, _positionYUpper);
        return new Vector2(_positionX, _positionY);
    }

}
