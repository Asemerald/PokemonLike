using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager Instance;
    
    
    public bool moved  = false;
    
    private PlayerController playerController;
    
    [SerializeField] private GameObject EncounterPanel;
    [SerializeField] private Button CatchButton;
    [SerializeField] private Button FleeButton;
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button HealButton;
    
    private IEncounter currentEncounter;

    private void Awake()
    {
        Instance = this;
        
        CatchButton.onClick.AddListener(() =>
        {
            currentEncounter.Capture();
        });
        
        FleeButton.onClick.AddListener(() =>
        {
            currentEncounter.Flee();
        });
        
        AttackButton.onClick.AddListener(() =>
        {
            currentEncounter.Attack();
        });
        
        HealButton.onClick.AddListener(() =>
        {
            currentEncounter.Heal();
        });
        
        
    }

    private void Start()
    {
        playerController = PlayerController.Instance;
        
    }
    
    public void EndCombat()
    {
        EncounterPanel.SetActive(false);
        playerController.isFighting = false;
    }

    // A chaque fois que move est true, on a une chance sur 10 d'avoir une rencontre
    private void Update()
    {
        if (moved)
        {
            moved = false;

            // 1/10 chance to trigger an encounter
            Random random = new Random();
            if (random.Next(0, 10) == 0)
            {
                EncounterGenerator generator;

                // 50% chance of WildEncounter or FightEncounter
                if (random.Next(0, 2) == 0)
                {
                    generator = new WildEncounterGenerator();
                    Debug.Log("Wild Encounter"); //TODO REMOVE
                }
                else
                {
                    generator = new FightEncounterGenerator();
                    Debug.Log("Fight Encounter"); //TODO REMOVE
                }

                currentEncounter = generator.CreateEncounter();
                currentEncounter.PickRandomPokemon();

                // Enable encounter UI
                playerController.isFighting = true;
                EncounterPanel.SetActive(true);
            }
        }
    }

    
    
}

public class WildEncounterGenerator : EncounterGenerator
{
    public override IEncounter CreateEncounter()
    {
        return new WildEncounter();
    }
}


public class FightEncounterGenerator : EncounterGenerator
{
    public override IEncounter CreateEncounter()
    {
        return new FightEncounter();
    }
}