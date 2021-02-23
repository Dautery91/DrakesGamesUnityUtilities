using DrakesGames.Factory;
using UnityEngine;

namespace DrakesGames.Events.UnityEventIntegration
{
    public class CustomEventsListener : MonoBehaviour
    {
        private GOLocalEventManager localEM;

        private void Awake()
        {
            if (useLocalEvents && localEM == null)
            {
                localEM = GetComponent<GOLocalEventManager>();
                if (localEM == null) localEM = GetComponentInParent<GOLocalEventManager>();
                if (localEM == null) localEM = GetComponentInChildren<GOLocalEventManager>();
            }
        }

        private void OnEnable()
        {
            if (useGlobalEvents)
                foreach (var mapping in eventListenerMappings)
                    EventManager.Instance.RegisterByString(mapping.Listeners, mapping.eventType);

            if (useLocalEvents)
                foreach (var mapping in localEventListenerMappings)
                    localEM.RegisterByString(mapping.Listeners, mapping.eventType, this);
        }

        private void OnDisable()
        {
            if (useGlobalEvents && EventManager.Instance != null)
                foreach (var mapping in eventListenerMappings)
                    EventManager.Instance.UnregisterByString(mapping.Listeners, mapping.eventType);

            if (useLocalEvents && localEM != null) localEM.UnregisterLocalListener(this);
        }
        
        private void Validation()
        {
            if (useGlobalEvents)
                foreach (var mapping in eventListenerMappings)
                    if (!GenericFactory<EventInfoBase>.CheckIfTypeExists(mapping.eventType))
                        Debug.Log("No event exists with this name! : " + mapping.eventType);

            if (useLocalEvents)
                foreach (var mapping in localEventListenerMappings)
                    if (!GenericFactory<EventInfoBase>.CheckIfTypeExists(mapping.eventType))
                        Debug.Log("No event exists with this name! : " + mapping.eventType);
        }
#pragma warning disable CS0649
        [SerializeField] private bool useGlobalEvents = true;
        [SerializeField] private bool useLocalEvents = true;
        
        [SerializeField]
        private CustomEventToUnityEvent[] eventListenerMappings;
        
        [SerializeField]
        private CustomEventToUnityEvent[] localEventListenerMappings;

#pragma warning restore CS0649
    }
}