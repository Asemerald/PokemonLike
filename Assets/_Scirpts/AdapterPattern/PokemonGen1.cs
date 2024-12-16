public class PokemonGen1
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int HealthPoints { get; set; }
    public int Special { get; set; }

    public PokemonGen1(string name, int attack, int defense, int speed, int healthPoints, int special)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        HealthPoints = healthPoints;
        Special = special;
    }

    public override string ToString()
    {
        return $"[Gen1] {Name} - ATK: {Attack}, DEF: {Defense}, SPD: {Speed}, HP: {HealthPoints}, SPC: {Special}";
    }
}