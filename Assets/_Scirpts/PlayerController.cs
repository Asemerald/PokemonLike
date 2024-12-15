using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public GameObject player;       // Référence du joueur (GameObject avec Sprite)
    public Tilemap tilemap;         // Référence à la tilemap
    public float moveSpeed = 5f;    // Vitesse de déplacement (pour smooth movement)

    private Vector3Int currentCell; // Position actuelle du joueur sur la tilemap
    private Vector3 targetPosition; // Position cible pour le joueur
    
    public bool isFighting = false;
    
    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Initialiser la position du joueur à la position de départ sur la tilemap
        currentCell = tilemap.WorldToCell(player.transform.position);
        targetPosition = tilemap.GetCellCenterWorld(currentCell);
        player.transform.position = targetPosition;
    }

    private void Update()
    {
        if (isFighting) return;
        
        // Si le joueur est déjà en mouvement, on l'empêche de bouger jusqu'à atteindre la position cible
        if (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            return;
        }

        // Obtenir l'input pour déterminer la direction
        Vector3Int direction = Vector3Int.zero;
        
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            direction = new Vector3Int(0, 1, 0);    // Haut
            EncounterManager.Instance.moved = true;
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = new Vector3Int(0, -1, 0);   // Bas
            EncounterManager.Instance.moved = true;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = new Vector3Int(-1, 0, 0);   // Gauche
            EncounterManager.Instance.moved = true;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = new Vector3Int(1, 0, 0);    // Droite
            EncounterManager.Instance.moved = true;
        }
        
        Vector3Int nextCell = currentCell + direction;
        
        if (IsWalkable(nextCell))
        {
            // Mettre à jour la position actuelle et la position cible
            currentCell = nextCell;
            targetPosition = tilemap.GetCellCenterWorld(currentCell);
        }
    }

    // Vérifie si la cellule donnée est walkable
    private bool IsWalkable(Vector3Int cellPosition)
    {
        TileBase tile = tilemap.GetTile(cellPosition);
        return tile != null;  // Tu peux ajouter d'autres conditions ici si nécessaire
    }

    public string TypeofTile()
    {
        //Debug de la tuile selon le nom de son sprite
        TileBase tile = tilemap.GetTile(currentCell);
        Debug.Log(tile.name);
        return tile.name;
    }
}
