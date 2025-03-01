﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleButton : MonoBehaviour
{
    private Sprite _sprite;
    private Font _font;
    private 

    void Start()
    {
        _sprite = Resources.Load<Sprite>("Sprites/btn-medieval");
        _font = Resources.Load<Font>("Fonts/Medieval");
    }

    public GameObject CreateButton(Transform parent, Vector3 pos, string txt)
    {
        GameObject button = new GameObject();
        button.transform.SetParent(parent);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<Image>().sprite = _sprite;
        button.name = "Button";
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 50);
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().localPosition = pos;        

        GameObject text = new GameObject();
        text.transform.parent = button.transform;
        text.AddComponent<RectTransform>();
        text.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        text.AddComponent<Text>();
        text.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        text.GetComponent<Text>().text = txt;
        text.GetComponent<Text>().font = _font;
        text.GetComponent<Text>().color = new Color(0, 0, 0);
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;        
        text.name = "Text";

        return button;
    }


}
