using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class WarningDisplay : MonoBehaviour
{
    private static WarningDisplay instance;

    public static WarningDisplay getInstance()
    {
        return instance;
    }

    private GameController gameController;
    private TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }

    private bool warning = false;
    Stopwatch stopWatch = new Stopwatch();

    void Start()
    {
        gameController = GameController.GetInstance();
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        string warningText = " ";
        if (warning)
        {
            int timeDelta = stopWatch.Elapsed.Seconds;

            int remainingTime = 3 - timeDelta;
            Debug.Log("Maximum." + ",timeDelta=" + timeDelta);

            if (remainingTime >= 1)
            {
                warningText = "WARNING!\nYou will become lost in space in " + remainingTime + " seconds!";
                text.color = Color.red;
            }
            else
            {
                // // Unit test start: player state
                // if (gameController.GetGameState() != GameController.PLAYING)
                // {
                //     Debug.Log("Player state wrong when addressing warning:" + gameController.GetGameState());
                // }
                // // Unit test end


                gameController.PlayerDeath();
                StopWarning();
            }
        }

        text.text = warningText;
    }


    public void StartWarning()
    {
        if (!warning)
        {
            stopWatch.Start();
            warning = true;
        }
    }

    public void StopWarning()
    {
        if (warning)
        {
            warning = false;
            stopWatch.Stop();
            stopWatch.Reset();
        }
    }
}