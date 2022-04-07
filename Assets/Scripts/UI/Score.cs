using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    ArcadeModeManager _arcadeModeManager;
    private void Awake()
    {
        _arcadeModeManager = FindObjectOfType<ArcadeModeManager>();
        if (_arcadeModeManager == null)
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        _arcadeModeManager.UpdateScore();

    }
}