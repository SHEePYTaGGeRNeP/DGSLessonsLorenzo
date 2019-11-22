using Assets.Scripts.Game;
using System;
using UnityEngine.Events;

namespace Assets.Scripts.Helpers
{
    [Serializable]
    public class UnityHealthChangedEvent : UnityEvent<HealthChangedEventArgs> { }
}
