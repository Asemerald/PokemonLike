using System;
using System.Collections.Generic;

public class Gen2ExchangeBox
{
    private List<PokemonGen2> storedPokemons = new List<PokemonGen2>();

    public Gen2ExchangeBox()
    {
        // Ajout d’un Pokémon de 2ème génération
        storedPokemons.Add(new PokemonGen2("Héricendre", 10, 8, 12, 15, 14, 12));
    }

    public PokemonGen2 Exchange(PokemonGen1 playerPokemon)
    {
        if (storedPokemons.Count == 0)
        {
            Console.WriteLine("La boîte est vide !");
            return null;
        }

        PokemonGen2 exchangedPokemon = storedPokemons[0];
        storedPokemons.RemoveAt(0);

        // Utilise l’Adapter pour convertir le Pokémon de Gen1 → Gen2
        PokemonGen2 adaptedPokemon = PokemonAdapter.ConvertToGen2(playerPokemon);
        storedPokemons.Add(adaptedPokemon);

        return exchangedPokemon;
    }

    public PokemonGen1 ReverseExchange(PokemonGen2 playerPokemon)
    {
        if (storedPokemons.Count == 0)
        {
            Console.WriteLine("La boîte est vide !");
            return null;
        }

        PokemonGen1 exchangedPokemon = PokemonAdapter.ConvertToGen1(storedPokemons[0]);
        storedPokemons.RemoveAt(0);

        PokemonGen1 adaptedPokemon = PokemonAdapter.ConvertToGen1(playerPokemon);
        storedPokemons.Add(PokemonAdapter.ConvertToGen2(adaptedPokemon));

        return exchangedPokemon;
    }
}