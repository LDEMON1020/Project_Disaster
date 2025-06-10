using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    // Start is called before the first frame update
    public void TimePause()
    {
        Time.timeScale = 0f;
    }

    public void TimeActivate()
    {
        Time.timeScale = 1f;
    }
}
