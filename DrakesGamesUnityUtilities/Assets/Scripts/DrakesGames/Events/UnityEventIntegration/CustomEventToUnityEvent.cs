using System;

namespace DrakesGames.Events.UnityEventIntegration
{
    [Serializable]
    public struct CustomEventToUnityEvent
    {
        [EventType] public string eventType;
        public UnityEventEventInfo Listeners;
    }
}