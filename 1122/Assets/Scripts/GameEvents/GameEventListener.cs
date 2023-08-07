using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.onEventRaised.AddListener(response.Invoke);
    }

    private void OnDisable()
    {
        gameEvent.onEventRaised.RemoveListener(response.Invoke);
    }
}