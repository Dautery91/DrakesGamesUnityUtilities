using System;
using System.Collections;
using System.Collections.Generic;
using DrakesGames;
using Events;
using Sirenix.OdinInspector;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Timer timer;

    private Timer[] timers;
    // Start is called before the first frame update
    void OnEnable()
    {
        // MyEventInfo eventInfo = new MyEventInfo();
        // eventInfo.MyField = "poops";
        // EventManager.Instance.FireGlobalEvent(eventInfo);

        Action[] onComplete = new Action[1];
        
        // timer = new Timer(5, onComplete);
        // timer.StartTimer(this.gameObject);

        timers = new Timer[10];
        for (int i = 0; i < 10; i++)
        {
            onComplete[0] = () => Debug.Log(i.ToString()+ ": Finished!!");
            timers[i] = new Timer(i, onComplete);
            timers[i].StartTimer(this.gameObject);
        }
    }

    private void OnDisable()
    {
        timer.DeleteTimer();
    }

    [Button("Reset Timer")]
    public void ResetTimer1()
    {
        timer.ResetTimer();
        timer.StartTimer(this.gameObject);
    }
}
