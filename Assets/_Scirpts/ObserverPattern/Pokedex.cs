using System.Collections.Generic;
using UnityEngine;

public class Pokedex : IObserver
{
    private HashSet<string> capturedPokemons = new HashSet<string>();
    
    public void OnNotify(string eventType, object eventData)
    {
        if (eventType == "PokemonCaptured")
        {
            string pokemonName = (string)eventData;
            capturedPokemons.Add(pokemonName);
            Debug.Log($"Pokédex mis à jour : {pokemonName} ajouté.");
        }
    }
}