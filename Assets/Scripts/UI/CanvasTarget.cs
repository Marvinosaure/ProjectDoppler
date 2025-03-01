﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTarget : MonoBehaviour
{
    private PlayerCamera _camera;
    private Canvas _canvasComponent;

    private void Awake()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
        _canvasComponent = transform.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_camera.FPViewMode)
        {
            _canvasComponent.enabled = true;
        }
        else
        {
            _canvasComponent.enabled = false;
        }
    }
}
