﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WildEncounter : IEncounter
{
    private List<string> pokemons = new List<string> { "Pikachu", "Bulbizarre", "Salamèche", "Carapuce" };
    private string pokemon;

    public void PickRandomPokemon()
    {
        Debug.Log("Un Pokémon sauvage apparaît !");
        Random random = new Random();
        int index = random.Next(0, pokemons.Count);
        pokemon = pokemons[index];
        Debug.Log($"C'est un {pokemon} !");
    }

    public void Attack()
    {
        Debug.Log($"Vous attaquez {pokemon} !");
        EnnemyAttack();
    }

    public void Heal()
    {
        Debug.Log("Vous soignez votre Pokémon !");
        EnnemyAttack();
    }

    public void EnnemyAttack()
    {
        Debug.Log($"{pokemon} vous attaque !");
    }

    public void Capture()
    {
        Debug.Log("Vous lancez une Pokéball !");
        Random random = new Random();
        bool isCaptured = random.Next(0, 2) == 0;
        if (isCaptured)
        {
            Debug.Log($"Vous avez capturé {pokemon} !");
            EventManager.Instance.Notify("PokemonCaptured", pokemon);
        }
        else
        {
            Debug.Log($"{pokemon} s'est échappé !");
        }
        End();
    }

    public void Flee()
    {
        Debug.Log("Vous fuyez la rencontre !");
        End();
    }

    public void End()
    {
        Debug.Log("Fin de la rencontre.");
        EncounterManager.Instance.EndCombat();
    }
}