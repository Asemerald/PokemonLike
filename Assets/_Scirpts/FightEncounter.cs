using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FightEncounter : IEncounter
{
    private List<string> pokemons = new List<string> { "Rattata", "Roucool", "Nosferapti", "Machoc" };
    private List<string> trainers = new List<string> { "Dresseur Jo", "Dresseuse Anna", "Dresseur Max" };
    private string pokemon;
    private string trainer;

    public void PickRandomPokemon()
    {
        Random random = new Random();
        int pokemonIndex = random.Next(0, pokemons.Count);
        int trainerIndex = random.Next(0, trainers.Count);
        pokemon = pokemons[pokemonIndex];
        trainer = trainers[trainerIndex];
        Debug.Log($"{trainer} apparaît avec un {pokemon} !");
    }

    public void Attack()
    {
        Debug.Log($"Vous attaquez le {pokemon} de {trainer} !");
        EnnemyAttack();
        
        // add une chance de tuer le pokemon et finir le combat
        Random random = new Random();
        if (random.Next(0, 3) == 0)
        {
            Debug.Log($"Vous avez tué le {pokemon} de {trainer} !");
            End();
        }
    }

    public void Heal()
    {
        Debug.Log("Vous soignez votre Pokémon !");
        EnnemyAttack();
    }

    public void EnnemyAttack()
    {
        Debug.Log($"Le {pokemon} de {trainer} vous attaque !");
        
        // add une chance de tuer votre pokemon et finir le combat
        
        Random random = new Random();
        if (random.Next(0, 3) == 0)
        {
            Debug.Log($"Le {pokemon} de {trainer} vous a tué !");
            End();
        }
    }

    public void Capture()
    {
        Debug.Log("Vous ne pouvez pas capturer le Pokémon d'un dresseur !");
    }

    public void Flee()
    {
        Debug.Log("Vous fuyez le combat contre le dresseur !");
        End();
    }

    public void End()
    {
        Debug.Log("Fin du combat.");
        EncounterManager.Instance.EndCombat();
    }
}