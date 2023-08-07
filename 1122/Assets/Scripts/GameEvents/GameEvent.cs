using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New GameEvent", menuName = "Game Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    public UnityEvent onEventRaised;

    public void RaiseEvent()
    {
        onEventRaised?.Invoke();
    }
}

