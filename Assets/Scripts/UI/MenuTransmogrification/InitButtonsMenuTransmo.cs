using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitButtonsMenuTransmo : MonoBehaviour
{
    [SerializeField] private Button _btnTransmo;

    private Transmogrification _transmogrification;

    private void Awake()
    {
        _transmogrification = GetComponent<Transmogrification>();
    }
    void Start()
    {
        InstanciateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstanciateButtons()
    {
        for(int i = 0; i < 3; i++)
        {
            /*_btnTransmo.GetComponentInChildren<Text>().text = "numéro: " + i;
            _btnTransmo.transform.SetParent(transform);
            _btnTransmo.transform.position = new Vector2(transform.position.x, i * _btnTransmo.transform.GetComponent<RectTransform>().sizeDelta.y + 10);
            Instantiate(_btnTransmo);*/
        }
    }
}
