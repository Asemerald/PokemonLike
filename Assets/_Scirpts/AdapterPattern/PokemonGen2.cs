public class PokemonGen2
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int HealthPoints { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }

    public PokemonGen2(string name, int attack, int defense, int speed, int healthPoints, int specialAttack, int specialDefense)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        HealthPoints = healthPoints;
        SpecialAttack = specialAttack;
        SpecialDefense = specialDefense;
    }

    public override string ToString()
    {
        return $"[Gen2] {Name} - ATK: {Attack}, DEF: {Defense}, SPD: {Speed}, HP: {HealthPoints}, SPC ATK: {SpecialAttack}, SPC DEF: {SpecialDefense}";
    }
}