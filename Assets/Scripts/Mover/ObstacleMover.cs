using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour, IMoveable
{
    [SerializeField] private float _obstacleSpeed = 3.5f;
    private float _resetPosition = -21f;
    private float _startingPositionX = 21f;
    private float _positionYLimitUpper = 4f;
    private float _positionYLimitLower = -3f;
    private Vector2 _startingPosition;

    void Update()
    {
        MoveLeft();
        ResetPosition();
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * _obstacleSpeed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        if (transform.position.x < _resetPosition)
        {
            _startingPosition = new Vector2(_startingPositionX, Random.Range(_positionYLimitLower, _positionYLimitUpper));
            transform.position = _startingPosition;
        }
    }
}
