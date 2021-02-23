using System;

namespace DrakesGames.Events
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EventListenerClass : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class GlobalEventListenerMethod : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class LocalEventListenerMethod : Attribute
    {
    }
}