using UnityEngine;

public class SaveManager : IObserver
{
    public void OnNotify(string eventType, object eventData)
    {
        if (eventType == "PokemonCaptured")
        {
            UpdateSaveData();
        }
    }

    private void UpdateSaveData()
    {
        Debug.Log("Sauvegarde automatique mise à jour.");
        // Add Save logic
    }
}