public class PokemonAdapter
{
    // Conversion Gen1 → Gen2
    public static PokemonGen2 ConvertToGen2(PokemonGen1 gen1)
    {
        return new PokemonGen2(
            gen1.Name,
            gen1.Attack * 2,
            gen1.Defense * 2,
            gen1.Speed * 2,
            gen1.HealthPoints * 2,
            gen1.Special,  // Special split into Special Attack
            gen1.Special  // Special split into Special Defense
        );
    }

    // Conversion Gen2 → Gen1
    public static PokemonGen1 ConvertToGen1(PokemonGen2 gen2)
    {
        int combinedSpecial = (gen2.SpecialAttack + gen2.SpecialDefense) / 2;
        return new PokemonGen1(
            gen2.Name,
            gen2.Attack / 2,
            gen2.Defense / 2,
            gen2.Speed / 2,
            gen2.HealthPoints / 2,
            combinedSpecial
        );
    }
}