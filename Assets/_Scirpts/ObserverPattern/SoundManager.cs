using UnityEngine;

public class SoundManager : IObserver
{
    public void OnNotify(string eventType, object eventData)
    {
        if (eventType == "PokemonCaptured")
        {
            PlayCaptureJingle();
        }
    }

    private void PlayCaptureJingle()
    {
        Debug.Log("Jingle de capture joué : *Ding ding ding*");
        // Ajouter les sons 
    }
}