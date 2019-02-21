using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUIScript : MonoBehaviour
{    
    private void Start()
    {
        Cursor.visible = false;
    }
    

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

}
