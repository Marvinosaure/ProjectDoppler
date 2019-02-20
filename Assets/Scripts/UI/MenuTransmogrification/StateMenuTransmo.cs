using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenuTransmo : MonoBehaviour
{
    private bool _isVisible;
    private Canvas _canvas;
    private ScriptPause _scriptPause;

    private void Awake()
    {
        _scriptPause = GetComponent<ScriptPause>();

        _canvas = GetComponent<Canvas>();
        _canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void Start()
    {        
        if (_canvas.enabled)
        {
            _isVisible = true;
        }
        else
        {
            _isVisible = false;
        }
    }

    public void ToggleMenu()
    {
        if (_isVisible)
        {
            _canvas.enabled = false;
            _isVisible = false;
            _scriptPause.Playback();
        }
        else
        {
            _canvas.enabled = true;
            _isVisible = true;
            _scriptPause.Pause();
        }
    }
}