using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsControllerMenuTransmogrification : MonoBehaviour
{
    private StateMenuTransmo _stateMenuTransmo;    

    private void Awake()
    {
        _stateMenuTransmo = GetComponent<StateMenuTransmo>();        
    }

    void Update()
    {
        KeyBoardEvents();
    }    

    private void KeyBoardEvents()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _stateMenuTransmo.ToggleMenu();
        }
    }
}