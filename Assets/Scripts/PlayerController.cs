using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _upForce = 350f;
    [SerializeField] private float _ceiling = 5f;
    private Rigidbody2D _playerRB2D;
    private AudioSource _audioSource;
    private void Awake()
    {
        _playerRB2D = GetComponent<Rigidbody2D>();
        if (!_playerRB2D)
        {
            return;
        }
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        PlayerInput();
        ResetPlayerPositionOnY();
    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRB2D.velocity = Vector2.zero;
            _playerRB2D.AddForce(Vector2.up * _upForce);
            _audioSource.Play();
        }
    }
    private void ResetPlayerPositionOnY()
    {
        if (transform.position.y >= _ceiling)
        {
            transform.position = new Vector2(transform.position.x, _ceiling);
            _playerRB2D.AddForce(Vector2.down);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Floor"))
        {
            ArcadeModeManager arcadeModeManager;
            arcadeModeManager = FindObjectOfType<ArcadeModeManager>();
            ScoreSaver scoreSaver;
            scoreSaver = FindObjectOfType<ScoreSaver>();
            StoryModeManager storyModeManager;
            storyModeManager = FindObjectOfType<StoryModeManager>();
            if (arcadeModeManager != null)
            {
                scoreSaver.SetHighScore();
                arcadeModeManager.SetIsGameOver(true);
            }
            else if (storyModeManager != null)
            {
                storyModeManager.SetIsGameOver(true);
            }
        }
    }
}