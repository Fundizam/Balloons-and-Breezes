using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowControlsTimer : MonoBehaviour
{
    private TextMeshProUGUI _controlsText;
    private float _timer = 10f;
    private string _controls = "Press Space to jump!";

    private IEnumerator Start()
    {
        gameObject.SetActive(true);
        _controlsText = GetComponent<TextMeshProUGUI>();
        _controlsText.text = _controls;
        yield return new WaitForSeconds(_timer);
        gameObject.SetActive(false);
        StopCoroutine(Start());
    }
}
