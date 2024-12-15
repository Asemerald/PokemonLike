using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private List<IObserver> subscribers = new List<IObserver>();
    private List<IObserver> deferredUnsubscribes = new List<IObserver>();

    public static EventManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        Subscribe(new SaveManager());
        Subscribe(new Pokedex());
        Subscribe(new NPC());
        Subscribe(new SoundManager());
    }

    // Méthode pour ajouter un abonné
    public void Subscribe(IObserver observer)
    {
        if (!subscribers.Contains(observer))
        {
            subscribers.Add(observer);
            Debug.Log($"{observer.GetType().Name} a été abonné.");
        }
    }

    // Méthode pour retirer un abonné
    public void Unsubscribe(IObserver observer)
    {
        if (subscribers.Contains(observer))
        {
            subscribers.Remove(observer);
            Debug.Log($"{observer.GetType().Name} a été désabonné.");
        }
    }

    // Méthode pour notifier tous les abonnés
    public void Notify(string eventType, object eventData)
    {
        // Liste temporaire pour éviter de modifier la collection pendant l'énumération
        foreach (var subscriber in subscribers)
        {
            try
            {
                subscriber.OnNotify(eventType, eventData);
            }
            catch (Exception e)
            {
                Debug.LogError($"Erreur avec l'abonné {subscriber.GetType().Name}: {e.Message}");
            }
        }

        // Unsubscribe deferred observers after notification
        foreach (var observer in deferredUnsubscribes)
        {
            Unsubscribe(observer);
        }

        // Clear the deferred unsubscribe list
        deferredUnsubscribes.Clear();
    }

    // Méthode pour différer l'annulation de l'abonnement
    public void DeferUnsubscribe(IObserver observer)
    {
        if (!deferredUnsubscribes.Contains(observer))
        {
            deferredUnsubscribes.Add(observer);
            Debug.Log($"{observer.GetType().Name} sera désabonné après la notification.");
        }
    }
}