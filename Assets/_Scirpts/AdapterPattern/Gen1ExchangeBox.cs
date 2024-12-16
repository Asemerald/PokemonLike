using System;
using System.Collections.Generic;

public class Gen1ExchangeBox
{
    public List<PokemonGen1> storedPokemons = new List<PokemonGen1>();

    public Gen1ExchangeBox()
    {
        // Ajout d’un Pokémon de 1ère génération
        storedPokemons.Add(new PokemonGen1("Bulbizarre", 5, 5, 7, 10, 6));
    }

    public PokemonGen1 Exchange(PokemonGen1 playerPokemon)
    {
        if (storedPokemons.Count == 0)
        {
            Console.WriteLine("La boîte est vide !");
            return null;
        }

        PokemonGen1 exchangedPokemon = storedPokemons[0];
        storedPokemons.RemoveAt(0);

        // Ajoute le Pokémon du joueur dans la boîte
        storedPokemons.Add(playerPokemon);

        return exchangedPokemon;
    }
}