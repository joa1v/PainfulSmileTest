using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionTimer : MonoBehaviour
{
    public static float SessionTime;

    public delegate void TimeEndEventHandler();
    public event TimeEndEventHandler OnTimeEnded;

    private void Awake()
    {
        SessionTime = PlayerPrefs.GetInt(PlayerPrefsKeys.GameSessionTime);

        SessionTime *= 60;
    }

    private void Update()
    {
        if (SessionTime <= 0)
            return;

        SessionTime -= Time.deltaTime;

        if (SessionTime < 0)
        {
            EndSession();
        }

    }

    private void EndSession()
    {
        OnTimeEnded?.Invoke();
    }
}
