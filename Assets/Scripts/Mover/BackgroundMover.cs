using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour, IMoveable
{
    [SerializeField] private float _imageSpeed = 1f;
    [SerializeField] private float _resetPosition;
    [SerializeField] private float _startingPositionOnX;

    private void Update()
    {
        MoveLeft();
        ResetPosition();
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * _imageSpeed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        if (transform.position.x < _resetPosition)
        {
            Vector3 startingPosition = new Vector3(_startingPositionOnX, 0f, 0f);
            transform.position = startingPosition;
        }
    }
}
