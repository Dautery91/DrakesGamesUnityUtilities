using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

[EventListenerClass]
public class Listener : MonobehaviourEventListenerBaseClass
{
    [GlobalEventListenerMethod]
    void ListenerMethodExample(MyEventInfo eventInfo)
    {
        Debug.Log("Event Listened to: " + eventInfo.MyField);
    }
}
