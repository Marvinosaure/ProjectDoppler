using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPause : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Playback()
    {
        Time.timeScale = 1;
    }

    public void SlowsDown()
    {
        Time.timeScale = 0.2f;
    }
}
