using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    #region Singleton

    private static TimerManager _instance = null;

    public static TimerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TimerManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: TimeManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public int duration;

    private float time;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        if (GameFlowManager.Instance.IsGameOver)
        {
            return;
        }

        if (time > duration)
        {
            GameFlowManager.Instance.GameOver();
            return;
        }

        time += Time.deltaTime;
    }

    // Fitur tambah waktu saat bertambah score
    public void AddTime()
    {
        duration += 10;
    }

    public float GetRemainingTime()
    {
        return duration - time;
    }
}
