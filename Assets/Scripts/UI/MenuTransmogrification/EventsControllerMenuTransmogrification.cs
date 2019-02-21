using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsControllerMenuTransmogrification : MonoBehaviour
{
    private StateMenuTransmo _stateMenuTransmo;
    private CursorUIScript _cursor;

    private void Awake()
    {
        _stateMenuTransmo = GetComponent<StateMenuTransmo>();
        _cursor = GameObject.Find("Main Camera").GetComponent<CursorUIScript>();
    }

    void Update()
    {
        KeyBoardEvents();
    }    

    private void KeyBoardEvents()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _cursor.ShowCursor();
            _stateMenuTransmo.ShowMenu();        
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            _cursor.HideCursor();
            _stateMenuTransmo.HideMenu();        
        }
    }
}