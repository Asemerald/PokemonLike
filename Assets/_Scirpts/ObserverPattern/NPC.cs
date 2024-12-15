using UnityEngine;

public class NPC : IObserver
{
    private bool isBlocked = true;

    public void OnNotify(string eventType, object eventData)
    {
        if (eventType == "PokemonCaptured")
        {
            isBlocked = false;
            Debug.Log("Le PNJ vous laisse maintenant passer.");

            // Defer le desabo pour pas faire une erreur pendant la boucle de notif
            EventManager.Instance.DeferUnsubscribe(this);
        }
    }
}