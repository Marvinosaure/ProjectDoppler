using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtonMenuTransmo : MonoBehaviour
{
    private SimpleButton _simpleButton;

    private void Awake()
    {
        _simpleButton = GetComponent<SimpleButton>();
    }

    public void CreateButton(float y, string txt)
    {
        _simpleButton.CreateButton(transform, new Vector3(transform.position.x, y * 60, transform.position.z), txt);
    }
}
