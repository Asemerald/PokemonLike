using UnityEngine;

public class PokemonTradeDemo : MonoBehaviour
{
    void Start()
    {
        PokemonGen1 playerPokemon = new PokemonGen1("Pikachu", 7, 6, 10, 12, 8);
        
        // Pokemon de depart
        Debug.Log($"Votre Pokémon : {playerPokemon}");

        // Échange Gen1
        Gen1ExchangeBox gen1Box = new Gen1ExchangeBox();
        PokemonGen1 tradedGen1 = gen1Box.Exchange(playerPokemon);
        Debug.Log($"Échange en Gen1 : {tradedGen1}");
        //says that pikachu is traded for bulbizarre
        playerPokemon = tradedGen1;
        Debug.Log($"{gen1Box.storedPokemons[0].Name} est échangé contre {tradedGen1.Name}");

        // Échange Gen2
        Gen2ExchangeBox gen2Box = new Gen2ExchangeBox();
        PokemonGen2 tradedGen2 = gen2Box.Exchange(playerPokemon);
        Debug.Log($"{tradedGen2} va en Gen 2 et a donc de nouvelles stats");
        

        // Échange inverse (Gen2 → Gen1)
        PokemonGen1 reverseTradedGen1 = gen2Box.ReverseExchange(tradedGen2);
        Debug.Log($"Échange inverse en Gen1 : {reverseTradedGen1}");
    }
}