using System;

public interface IEncounter
{
    public void Attack();
    public void Heal();
    public void EnnemyAttack();
    public void End();

    // Méthodes optionnelles, par défaut non implémentées
    public void Capture()
    {
        throw new NotImplementedException("Cette action n'est pas disponible.");
    }

    public void Flee()
    {
        throw new NotImplementedException("Cette action n'est pas disponible.");
    }
    
    public void PickRandomPokemon()
    {
        throw new NotImplementedException("Cette action n'est pas disponible.");
    }
}